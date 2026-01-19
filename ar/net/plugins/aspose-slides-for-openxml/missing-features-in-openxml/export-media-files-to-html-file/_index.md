---
title: تصدير ملفات الوسائط إلى ملف HTML
type: docs
weight: 40
url: /ar/net/export-media-files-to-html-file/
---

من أجل تصدير ملفات الوسائط إلى HTML. يرجى اتباع الخطوات أدناه:

- إنشاء كائن من فئة Presentation
- الحصول على مرجع الشريحة
- تعيين تأثير الانتقال
- حفظ العرض التقديمي كملف PPTX

في المثال الموجود أدناه، قمنا بتصدير ملفات الوسائط إلى HTML.
## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Loading a presentation

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Setting HTML options

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Saving the file

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **تنزيل الكود النموذجي**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **تنزيل المثال التشغيلي**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 
لمزيد من التفاصيل، زر [تصدير ملفات الوسائط إلى ملف html](/slides/ar/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).
{{% /alert %}}