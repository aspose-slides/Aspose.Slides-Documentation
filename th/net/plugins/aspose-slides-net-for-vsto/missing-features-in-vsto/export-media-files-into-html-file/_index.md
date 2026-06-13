---
title: ส่งออกไฟล์สื่อเป็นไฟล์ HTML
type: docs
weight: 80
url: /th/net/export-media-files-into-html-file/
---
เพื่อส่งออกไฟล์สื่อเป็น HTML โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส Presentation
- รับอ้างอิงของสไลด์
- กำหนดเอฟเฟกต์การเปลี่ยน
- บันทึกการนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ส่งออกไฟล์สื่อเป็น HTML แล้ว.
## **ตัวอย่าง**
``` 

 //โหลดการนำเสนอ

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //ตั้งค่าตัวเลือก HTML

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //บันทึกไฟล์

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **ดาวน์โหลดตัวอย่างทำงาน**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)