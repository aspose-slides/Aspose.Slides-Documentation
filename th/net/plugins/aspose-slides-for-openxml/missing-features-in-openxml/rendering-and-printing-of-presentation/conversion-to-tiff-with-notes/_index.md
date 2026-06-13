---
title: การแปลงเป็น Tiff พร้อมบันทึก
type: docs
weight: 10
url: /th/net/conversion-to-tiff-with-notes/
---
TIFF คือหนึ่งในหลายรูปแบบภาพที่ได้รับความนิยมอย่างกว้างขวางซึ่ง Aspose.Slides สำหรับ .NET รองรับสำหรับการแปลงงานนำเสนอที่มีบันทึกเป็นภาพ คุณยังสามารถสร้างภาพย่อของสไลด์ในมุมมอง Notes Slide ได้ ด้านล่างเป็นตัวอย่างโค้ดสองส่วนที่แสดงวิธีการสร้างภาพ TIFF ของงานนำเสนอในมุมมอง Notes Slide

เมธอด **Save** ที่เปิดให้โดยคลาส **Presentation** สามารถใช้เพื่อแปลงงานนำเสนอทั้งหมดในมุมมอง Notes Slide เป็น TIFF ได้ คุณยังสามารถสร้างภาพย่อของสไลด์ในมุมมอง Notes Slide สำหรับสไลด์แต่ละสไลด์ได้เช่นกัน

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ

Presentation pres = new Presentation(srcFileName);

//บันทึกงานนำเสนอเป็น TIFF พร้อมบันทึก

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)