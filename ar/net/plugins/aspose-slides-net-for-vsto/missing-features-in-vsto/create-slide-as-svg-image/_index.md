---
title: إنشاء شريحة كصورة SVG
type: docs
weight: 70
url: /ar/net/create-slide-as-svg-image/
---

لإنشاء صورة SVG من أي شريحة مرغوبة باستخدام Aspose.Slides.Pptx لـ .NET، يرجى اتباع الخطوات أدناه:

- إنشاء مثال من فئة Presentation.  
- الحصول على مرجع الشريحة المطلوبة باستخدام معرفها (ID) أو الفهرس.  
- الحصول على صورة SVG في تدفق الذاكرة.  
- حفظ تدفق الذاكرة إلى ملف.  

## **مثال**

```csharp

 //Instantiate a Presentation class that represents the presentation file

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Access the second slide

   ISlide sld = pres.Slides[1];

   //Create a memory stream object

   MemoryStream SvgStream = new MemoryStream();

   //Generate SVG image of slide and save in memory stream

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Save memory stream to file

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

## **تحميل المثال التشغيلي**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)

## **تحميل عينة الكود**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

لمزيد من التفاصيل، زر [Render Presentation Slides as SVG Images in .NET](/slides/ar/net/render-a-slide-as-an-svg-image/).

{{% /alert %}}