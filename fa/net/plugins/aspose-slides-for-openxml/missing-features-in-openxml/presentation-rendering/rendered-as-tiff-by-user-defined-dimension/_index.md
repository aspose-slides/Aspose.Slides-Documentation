---
title: رندر شده به Tiff با ابعاد تعریف شده توسط کاربر
type: docs
weight: 40
url: /fa/net/rendered-as-tiff-by-user-defined-dimension/
---
مثال زیر نشان می‌دهد که چگونه می‌توان یک ارائه را به سند TIFF با اندازه تصویر سفارشی تبدیل کرد با استفاده از کلاس **TiffOptions**.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است

Presentation pres = new Presentation(srcFileName);

//ایجاد نمونه‌ای از کلاس TiffOptions

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//تنظیم نوع فشرده‌سازی

opts.CompressionType = TiffCompressionTypes.Default;

//انواع فشرده‌سازی

//Default - طرح فشرده‌سازی پیش‌فرض (LZW) را مشخص می‌کند.

//None - عدم فشرده‌سازی را مشخص می‌کند.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - بسته به نوع فشرده‌سازی است و نمی‌تواند به‌صورت دستی تنظیم شود.

//Resolution unit - همیشه برابر "2" است (نقطه بر اینچ)

//تنظیم DPI تصویر

opts.DpiX = 200;

opts.DpiY = 100;

//تنظیم اندازه تصویر

opts.ImageSize = new Size(1728, 1078);

//ذخیره ارائه به فرمت TIFF با اندازه تصویر مشخص شده

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **دانلود کد نمونه**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [بیت‌باکت](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)