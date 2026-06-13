---
title: ส่งออกไฟล์สื่อเป็นไฟล์ HTML
type: docs
weight: 40
url: /th/net/export-media-files-to-html-file/
---
เพื่อส่งออกไฟล์สื่อไปยัง HTML โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส Presentation
- รับการอ้างอิงของสไลด์
- ตั้งค่าเอฟเฟกต์การเปลี่ยนสไลด์
- บันทึกงานนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างที่แสดงด้านล่าง เราได้ส่งออกไฟล์สื่อไปยัง HTML แล้ว.
## **ตัวอย่าง**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//กำลังโหลดงานนำเสนอ

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //ตั้งค่าตัวเลือก HTML

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //กำลังบันทึกไฟล์

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}
``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **ดาวน์โหลดตัวอย่างที่ทำงาน**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 

สำหรับรายละเอียดเพิ่มเติม กรุณาเยี่ยมชม [การส่งออกไฟล์สื่อไปยังไฟล์ HTML](/slides/th/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}