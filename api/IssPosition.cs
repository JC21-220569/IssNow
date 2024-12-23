using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IssNow.api
{
    // ISS位置を格納するクラス
    public class IssPosition
    {
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }

        // 絶対値の緯度を返す
        public double LatitudeAbsolute
        {
            get
            {
                if (double.TryParse(Latitude, out double lat))
                {
                    return Math.Truncate(Math.Abs(lat) * Math.Pow(10, 2)) / Math.Pow(10, 2);
                }
                return 0; // デフォルト値（必要に応じて調整）
            }
        }

        // 絶対値の経度を返す
        public double LongitudeAbsolute
        {
            get
            {
                if (double.TryParse(Longitude, out double lon))
                {
                    return Math.Truncate(Math.Abs(lon) * Math.Pow(10, 2)) / Math.Pow(10, 2);
                }
                return 0; // デフォルト値（必要に応じて調整）
            }
        }

        // 緯度の方向（NまたはS）を返す
        public string LatitudeDirection
        {
            get
            {
                if (double.TryParse(Latitude, out double lat))
                {
                    return lat >= 0 ? "N" : "S";
                }
                return "Invalid"; // エラー時の値
            }
        }

        // 経度の方向（EまたはW）を返す
        public string LongitudeDirection
        {
            get
            {
                if (double.TryParse(Longitude, out double lon))
                {
                    return lon >= 0 ? "E" : "W";
                }
                return "Invalid"; // エラー時の値
            }
        }
    }
}
