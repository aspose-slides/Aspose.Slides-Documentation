---
title: تصدير ملفات الوسائط إلى ملف HTML
type: docs
weight: 80
url: /ar/net/export-media-files-into-html-file/
---

لتصدير ملفات الوسائط إلى HTML. يرجى اتباع الخطوات التالية:

- إنشاء كائن من فئة Presentation
- الحصول على مرجع الشريحة
- تعيين تأثير الانتقال
- كتابة العرض التقديمي كملف PPTX

في المثال المعطى أدناه، قمنا بتصدير ملفات الوسائط إلى HTML.
## **مثال**
``` 

 //Loading a presentation

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //Setting HTML options

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Saving the file

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **تحميل مثال تشغيل**
- [جيتهاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **تحميل الكود النموذجي**
- [جيتهاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)