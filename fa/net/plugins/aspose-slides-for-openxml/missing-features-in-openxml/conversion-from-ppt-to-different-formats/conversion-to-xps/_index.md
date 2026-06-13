---
title: تبدیل به XPS
type: docs
weight: 40
url: /fa/net/conversion-to-xps/
---
**XPS** فرمت همچنین به‌طور گسترده‌ای برای تبادل داده‌ها استفاده می‌شود. Aspose.Slides برای .NET به اهمیت آن توجه کرده و پشتیبانی داخلی برای تبدیل یک ارائه به سند XPS را فراهم می‌کند.

متد **Save** که توسط کلاس Presentation ارائه شده است می‌تواند برای تبدیل کل ارائه به سند **XPS** استفاده شود. همچنین، کلاس **XpsOptions** ویژگی **SaveMetafileAsPng** را ارائه می‌دهد که می‌توان آن را بر حسب نیاز به true یا false تنظیم کرد.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//یک شی Presentation را که نمایانگر یک فایل ارائه است، ایجاد می‌کند

Presentation pres = new Presentation(srcFileName);

//ذخیره ارائه به سند TIFF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)