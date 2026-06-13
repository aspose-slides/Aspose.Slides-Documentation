---
title: แสดงเป็น Tiff
type: docs
weight: 30
url: /th/net/rendered-as-tiff/
---
รูปแบบ TIFF มีชื่อเสียงในความยืดหยุ่นที่สามารถรองรับภาพหลายหน้าและข้อมูลต่าง ๆ การพิจารณาถึงความสำคัญและความนิยมของรูปแบบ TIFF, Aspose.Slides for .NET ให้การสนับสนุนการแปลงการพรีเซนเทชันเป็นเอกสาร TIFF
บทความนี้อธิบายวิธีการของตัวเลือกการส่งออก TIFF ที่ต่างกัน:

- แปลง Presentation เป็น TIFF ด้วยขนาดเริ่มต้น.
- แปลง Presentation เป็น TIFF ด้วยขนาดที่กำหนดเอง.

เมธอด **Save** ที่เปิดให้ใช้งานโดยคลาส **Presentation** สามารถถูกเรียกโดยนักพัฒนาเพื่อแปลงพรีเซนเทชันทั้งหมดเป็นเอกสาร **TIFF** ได้ นอกจากนี้คลาส TiffOptions จะเปิดเผยคุณสมบัติ ImageSize ที่ช่วยให้นักพัฒนากำหนดขนาดของภาพตามต้องการ.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์พรีเซนเทชัน

using (Presentation pres = new Presentation(srcFileName))

{

    //บันทึกพรีเซนเทชันเป็นเอกสาร TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)