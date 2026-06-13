---
title: تبدیل ارائه به XPS
type: docs
weight: 60
url: /fa/net/convert-presentation-to-xps/
---
**XPS** قالب همچنین به طور گسترده‌ای برای تبادل داده‌ها استفاده می‌شود. Aspose.Slides برای .NET به اهمیت آن توجه دارد و پشتیبانی داخلی برای تبدیل یک ارائه به سند XPS را فراهم می‌کند.

متد **Save** که توسط کلاس Presentation ارائه می‌شود می‌تواند برای تبدیل کل ارائه به سند **XPS** استفاده شود. همچنین، کلاس **XpsOptions** خصوصیت **SaveMetafileAsPng** را افشا می‌کند که می‌تواند طبق نیاز به true یا false تنظیم شود.
## **مثال**

``` 

 //یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید

Presentation pres = new Presentation("Conversion.ppt");

//ذخیرهٔ ارائه به سند TIFF

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **دانلود مثال اجرا شده**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **دانلود کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

برای جزئیات بیشتر، به [تبدیل ارائه‌های پاورپوینت به XPS در .NET](/slides/fa/net/convert-powerpoint-to-xps/) مراجعه کنید.

{{% /alert %}}