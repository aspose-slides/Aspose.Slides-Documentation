---
title: تصدير ملفات الوسائط إلى ملف HTML
type: docs
weight: 80
url: /net/export-media-files-into-html-file/
---

لتصدير ملفات الوسائط إلى HTML. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة Presentation
- الحصول على مرجع الشريحة
- إعداد تأثير الانتقال
- كتابة العرض التقديمي كملف PPTX

في المثال المعطى أدناه، قمنا بتصدير ملفات الوسائط إلى HTML.
## **مثال**
``` 

 //تحميل عرض تقديمي

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //إعداد خيارات HTML

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //حفظ الملف

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **تحميل مثال قيد التشغيل**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Export media files into html/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **تحميل نموذج الكود**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)