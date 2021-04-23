using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string DailyPriceInvalid = "Günlük kiralama fiyatı 0'dan büyük olmalı";
        public static string CarsListed = "Araçlar listelendi";
        public static string MaintenanceTime = "Sistem bakımda";
        internal static string BrandAdded = "Marka eklendi";
        internal static string BrandNameInvalid = "Marka 2 karakterden daha uzun olmalı";
        internal static string BrandDeleted = "Marka silindi";
        internal static string BrandModified = "Marka güncellendi";
    }
}
