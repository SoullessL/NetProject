﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace IocAndAop.CustomWebApi
{
    public class GeoPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static bool TryParse(string s, out GeoPoint result)
        {
            result = null;

            var parts = s.Split(',');
            if (parts.Length != 2)
            {
                return false;
            }

            double latitude, longitude;
            if (double.TryParse(parts[0], out latitude) &&
                double.TryParse(parts[1], out longitude))
            {
                result = new GeoPoint() { Longitude = longitude, Latitude = latitude };
                return true;
            }
            return false;
        }
    }

    public class GeoPointModelBinder : IModelBinder
    {
        // List of known locations.
        private static ConcurrentDictionary<string, GeoPoint> _locations
            = new ConcurrentDictionary<string, GeoPoint>(StringComparer.OrdinalIgnoreCase);

        static GeoPointModelBinder()
        {
            _locations["redmond"] = new GeoPoint() { Latitude = 47.67856, Longitude = -122.131 };
            _locations["paris"] = new GeoPoint() { Latitude = 48.856930, Longitude = 2.3412 };
            _locations["tokyo"] = new GeoPoint() { Latitude = 35.683208, Longitude = 139.80894 };
        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(GeoPoint))
            {
                return false;
            }

            ValueProviderResult val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (val == null)
            {
                return false;
            }

            string key = val.RawValue as string;
            if (key == null)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Wrong value type");
                return false;
            }

            GeoPoint result;
            if (_locations.TryGetValue(key, out result) || GeoPoint.TryParse(key, out result))
            {
                bindingContext.Model = result;
                return true;
            }

            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Cannot convert value to Location");
            return false;
        }
    }
}
