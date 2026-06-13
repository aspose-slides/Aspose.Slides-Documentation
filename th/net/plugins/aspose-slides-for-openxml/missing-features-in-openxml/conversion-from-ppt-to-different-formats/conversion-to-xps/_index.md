---
title: การแปลงเป็น XPS
type: docs
weight: 40
url: /th/net/conversion-to-xps/
---
**XPS** format ยังเป็นที่นิยมอย่างกว้างขวางสำหรับการแลกเปลี่ยนข้อมูล. Aspose.Slides for .NET ให้ความสำคัญกับมันและมอบการสนับสนุนแบบในตัวสำหรับการแปลงงานนำเสนอเป็นเอกสาร XPS.

เมธอด **Save** ที่เปิดให้ใช้งานโดยคลาส Presentation สามารถใช้เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร **XPS**. ต่อไป, คลาส **XpsOptions** จะเปิดเผยพร็อพเพอร์ตี้ **SaveMetafileAsPng** ที่สามารถตั้งค่าเป็น true หรือ false ตามความต้องการ.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ

Presentation pres = new Presentation(srcFileName);

//กำลังบันทึกงานนำเสนอเป็นเอกสาร TIFF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)