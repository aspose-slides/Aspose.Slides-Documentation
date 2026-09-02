---
title: แสดงเป็น Tiff
type: docs
weight: 30
url: /th/net/rendered-as-tiff/
---
รูปแบบ TIFF มีความยืดหยุ่นในการรองรับภาพหลายหน้าและข้อมูลต่างๆ ได้เป็นที่รู้จัก เมื่อพิจารณาถึงความสำคัญและความนิยมของรูปแบบ TIFF, Aspose.Slides for .NET ให้การสนับสนุนการแปลงการนำเสนอเป็นเอกสาร TIFF.
บทความนี้อธิบายวิธีการเลือกตัวเลือกการส่งออก TIFF ที่แตกต่างกัน:

- แปลงการนำเสนอเป็น TIFF ด้วยขนาดเริ่มต้น.
- แปลงการนำเสนอเป็น TIFF ด้วยขนาดที่กำหนดเอง.

เมธอด **Save** ที่เปิดให้ใช้โดยคลาส **Presentation** สามารถถูกเรียกโดยนักพัฒนาเพื่อแปลงการนำเสนอทั้งหมดเป็นเอกสาร **TIFF** ได้ อีกทั้งคลาส TiffOptions ยังเปิดเผยคุณสมบัติ ImageSize ให้ผู้พัฒนากำหนดขนาดของภาพได้หากต้องการ.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//สร้างออบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ

using (Presentation pres = new Presentation(srcFileName))

{

    //บันทึกการนำเสนอเป็นเอกสาร TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)