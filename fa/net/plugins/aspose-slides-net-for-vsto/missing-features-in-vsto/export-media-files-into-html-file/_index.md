---
title: صادر کردن فایل‌های رسانه‌ای به فایل HTML
type: docs
weight: 80
url: /fa/net/export-media-files-into-html-file/
---
برای صادر کردن فایل‌های رسانه‌ای به HTML، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید
- مرجع اسلاید را دریافت کنید
- تنظیم اثر انتقال
- ارائه را به‌عنوان فایل PPTX ذخیره کنید

در مثال زیر، ما فایل‌های رسانه‌ای را به HTML صادر کرده‌ایم.
## **مثال**
``` 

 //بارگذاری یک ارائه

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //تنظیم گزینه‌های HTML

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //ذخیره‌سازی فایل

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}
``` 
## **دانلود مثال اجرایی**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **دانلود کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)