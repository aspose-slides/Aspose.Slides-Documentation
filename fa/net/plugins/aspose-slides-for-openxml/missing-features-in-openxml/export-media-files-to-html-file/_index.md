---
title: استخراج فایل‌های رسانه‌ای به فایل HTML
type: docs
weight: 40
url: /fa/net/export-media-files-to-html-file/
---
به منظور استخراج فایل‌های رسانه‌ای به فرمت HTML، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید
- مرجع اسلاید را دریافت کنید
- تنظیم اثر انتقال
- ارائه را به عنوان فایل PPTX ذخیره کنید

در مثال زیر، ما فایل‌های رسانه‌ای را به HTML استخراج کرده‌ایم.
## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//بارگذاری یک ارائه

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //تنظیم گزینه‌های HTML

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //ذخیره‌سازی فایل

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **دانلود کد نمونه**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **دانلود مثال اجرایی**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 
برای دریافت جزئیات بیشتر، به [استخراج فایل‌های رسانه‌ای به فایل html](/slides/fa/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide) مراجعه کنید.
{{% /alert %}}