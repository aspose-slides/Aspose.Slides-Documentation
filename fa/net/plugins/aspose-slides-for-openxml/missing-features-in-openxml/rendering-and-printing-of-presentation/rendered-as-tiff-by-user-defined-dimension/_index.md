---
title: رندر شده به TIFF با ابعاد تعریف‌شده توسط کاربر
type: docs
weight: 40
url: /fa/net/rendered-as-tiff-by-user-defined-dimension/
---
مثال زیر نشان می‌دهد که چگونه می‌توان یک ارائه را به سند TIFF با اندازه تصویر سفارشی تبدیل کرد با استفاده از کلاس **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//یک شیء Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی می‌کند
Presentation pres = new Presentation(srcFileName);

//کلاس TiffOptions را نمونه‌سازی می‌کند
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//تنظیم نوع فشرده‌سازی
opts.CompressionType = TiffCompressionTypes.Default;

//انواع فشرده‌سازی
//Default - طرح فشرده‌سازی پیش‌فرض (LZW) را تعیین می‌کند.
 //None - عدم فشرده‌سازی را تعیین می‌کند.
//CCITT3
//CCITT4
//LZW
//RLE
//Depth - بستگی به نوع فشرده‌سازی دارد و نمی‌توان به‌دست‌ساز تنظیم کرد.
//Resolution unit - همیشه برابر با "2" (نقطه بر اینچ) است
//تنظیم DPI تصویر
opts.DpiX = 200;
opts.DpiY = 100;

//تنظیم اندازه تصویر
opts.ImageSize = new Size(1728, 1078);

//ارائه را با اندازه تصویر مشخص به TIFF ذخیره می‌کند
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **بارگیری کد نمونه**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [بیت‌باكت](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)