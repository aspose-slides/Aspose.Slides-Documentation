---
title: ایجاد اسلاید به عنوان تصویر SVG
type: docs
weight: 70
url: /fa/net/create-slide-as-svg-image/
---
برای ایجاد تصویر SVG از هر اسلاید دلخواه با Aspose.Slides.Pptx برای .NET، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید.
- مرجع اسلاید موردنظر را با استفاده از شناسه یا اندیس آن به دست آورید.
- تصویر SVG را در یک Memory Stream دریافت کنید.
- Memory Stream را به فایل ذخیره کنید.
## **مثال**

```

 // یک شیء از کلاس Presentation که نشانگر فایل ارائه است ایجاد کنید

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
   // دسترسی به اسلاید دوم
   ISlide sld = pres.Slides[1];
   // ایجاد یک شیء Memory Stream
   MemoryStream SvgStream = new MemoryStream();
   // تولید تصویر SVG از اسلاید و ذخیره آن در Memory Stream
   sld.WriteAsSvg(SvgStream);
   SvgStream.Position = 0;
   // ذخیره Memory Stream در فایل
   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))
   {
     byte[] buffer = new byte[8 * 1024];
     int len;
     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
     {
       fileStream.Write(buffer, 0, len);
     }
   }

SvgStream.Close();

``` 
## **بارگیری مثال در حال اجرا**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **بارگیری کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

برای جزئیات بیشتر، به [نمایش اسلایدهای ارائه به عنوان تصاویر SVG در .NET](/slides/fa/net/render-a-slide-as-an-svg-image/) مراجعه کنید.

{{% /alert %}}