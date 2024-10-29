---
title: تصدير ملفات الوسائط إلى ملف HTML
type: docs
weight: 40
url: /ar/net/export-media-files-to-html-file/
---

لكي يتم تصدير ملفات الوسائط إلى HTML، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة Presentation
- الحصول على مرجع الشريحة
- إعداد تأثير الانتقال
- كتابة العرض التقديمي كملف PPTX

في المثال المقدم أدناه، قمنا بتصدير ملفات الوسائط إلى HTML.
## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//تحميل عرض تقديمي

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //إعداد خيارات HTML

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //حفظ الملف

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **تحميل رمز العينة**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **تحميل المثال القابل للتشغيل**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Export media files into html/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

لمزيد من التفاصيل، تفضل بزيارة [تصدير ملفات الوسائط إلى ملف HTML](/slides/ar/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}