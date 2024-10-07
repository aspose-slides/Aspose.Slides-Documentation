---
title: إنشاء شريحة كصورة SVG
type: docs
weight: 70
url: /net/create-slide-as-svg-image/
---

لتوليد صورة SVG من أي شريحة مرغوبة باستخدام Aspose.Slides.Pptx لـ .NET، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة Presentation.
- الحصول على مرجع الشريحة المرغوبة باستخدام معرفها أو فهرسها.
- الحصول على صورة SVG في دفق الذاكرة.
- حفظ دفق الذاكرة إلى ملف.
## **مثال**

```
//إنشاء مثيل لفئة Presentation تمثل ملف العرض التقديمي

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //الوصول إلى الشريحة الثانية

   ISlide sld = pres.Slides[1];

   //إنشاء كائن دفق الذاكرة

   MemoryStream SvgStream = new MemoryStream();

   //توليد صورة SVG للشريحة وحفظها في دفق الذاكرة

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //حفظ دفق الذاكرة إلى ملف

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
## **تنزيل مثال قيد التشغيل**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Creating Slide SVG Image/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **تنزيل كود العينة**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

للمزيد من التفاصيل، تفضل بزيارة [إنشاء شريحة SVG](/slides/net/presentation-viewer/).

{{% /alert %}}