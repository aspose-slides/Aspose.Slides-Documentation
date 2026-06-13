---
title: การแปลงเป็น PDF
type: docs
weight: 30
url: /th/net/conversion-to-pdf/
---
เอกสาร PDF ถูกใช้เป็นอย่างกว้างขวางเป็นรูปแบบมาตรฐานสำหรับการแลกเปลี่ยนเอกสารระหว่างองค์กร, ภาครัฐและบุคคลทั่วไป. รูปแบบนี้เป็นที่นิยมจึงทำให้นักพัฒนามักได้รับการขอให้แปลงไฟล์การนำเสนอ Microsoft PowerPoint เป็นเอกสาร PDF. เพื่อรองรับความต้องการนี้, Aspose.Slides for .NET รองรับการแปลงการนำเสนอเป็นเอกสาร PDF โดยไม่ต้องใช้ส่วนประกอบอื่นใด.

**Aspose.Slides for .NET** มีคลาส Presentation ที่แสดงถึงไฟล์การนำเสนอ. คลาส **Presentation** มีเมธอด Save ที่สามารถเรียกใช้เพื่อแปลงการนำเสนอทั้งหมดเป็นเอกสาร **PDF**. คลาส **PdfOptions** มีตัวเลือกสำหรับการสร้าง **PDF** เช่น JpegQuality, TextCompression, Compliance และอื่น ๆ. ตัวเลือกเหล่านี้สามารถใช้เพื่อให้ได้มาตรฐาน PDF ที่ต้องการ.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ

Presentation pres = new Presentation(srcFileName);

//บันทึกการนำเสนอเป็น PDF ด้วยตัวเลือกเริ่มต้น

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)