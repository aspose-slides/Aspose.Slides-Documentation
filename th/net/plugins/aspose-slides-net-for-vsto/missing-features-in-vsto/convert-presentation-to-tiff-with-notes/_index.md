---
title: แปลงพรีเซนเทชันเป็น Tiff พร้อมโน้ต
type: docs
weight: 50
url: /th/net/convert-presentation-to-tiff-with-notes/
---
TIFF คือหนึ่งในหลายรูปแบบภาพที่ใช้กันอย่างแพร่หลายที่ Aspose.Slides for .NET รองรับสำหรับการแปลงพรีเซนเทชันที่มีโน้ตเป็นภาพ คุณยังสามารถสร้างภาพย่อของสไลด์ในมุมมองสไลด์โน้ตได้ ด้านล่างนี้เป็นสองตัวอย่างโค้ดที่แสดงวิธีการสร้างภาพ TIFF ของพรีเซนเทชันในมุมมองสไลด์โน้ต

เมธอด [Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/methods/save) ที่เปิดโดยคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) สามารถใช้เพื่อแปลงพรีเซนเทชันทั้งหมดในมุมมองสไลด์โน้ตเป็น TIFF คุณยังสามารถสร้างภาพย่อสไลด์ในมุมมองสไลด์โน้ตสำหรับสไลด์แต่ละอันได้

## **ตัวอย่าง**

``` 

  //สร้างอ็อบเจกต์ Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน

 Presentation pres = new Presentation("Conversion.pptx");

 //บันทึกพรีเซนเทชันเป็น TIFF พร้อมโน้ต

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **ดาวน์โหลดตัวอย่างที่กำลังทำงาน**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

สำหรับรายละเอียดเพิ่มเติม โปรดเยี่ยมชม [แปลงการนำเสนอ PowerPoint เป็น TIFF พร้อมโน้ตใน .NET](/slides/th/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}