---
title: แปลงงานนำเสนอเป็น HTML
type: docs
weight: 40
url: /th/net/convert-presentation-to-html/
---
**HTML** เป็นหนึ่งในรูปแบบที่ใช้กันอย่างแพร่หลายหลายรูปแบบสำหรับการแลกเปลี่ยนข้อมูล. **Aspose.Slides for .NET** ให้การสนับสนุนการแปลงการนำเสนอเป็น HTML. ด้านล่างเป็นโค้ดตัวอย่างที่แสดงวิธีทำ.
## **ตัวอย่าง**
``` 
 //สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
Presentation pres = new Presentation("Conversion.ppt");
HtmlOptions htmlOpt = new HtmlOptions();
htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);
//บันทึกงานนำเสนอเป็น HTML
pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);
``` 
## **ดาวน์โหลดตัวอย่างที่ทำงาน**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

สำหรับรายละเอียดเพิ่มเติม, โปรดเยี่ยมชม [แปลงงานนำเสนอ PowerPoint เป็น HTML ใน .NET](/slides/th/net/convert-powerpoint-to-html/).

{{% /alert %}}