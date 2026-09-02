---
title: แปลงสไลด์เป็นภาพย่อเป็น JPEG
type: docs
weight: 60
url: /th/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** ถูกใช้เพื่อสร้างไฟล์พรีเซนเทชันที่มีสไลด์ สไลด์เหล่านี้สามารถดูได้โดยการเปิดไฟล์พรีเซนเทชันด้วย Microsoft PowerPoint แต่บางครั้งนักพัฒนาอาจต้องการดูสไลด์เป็นรูปภาพโดยใช้โปรแกรมดูรูปที่ชื่นชอบ ในกรณีเช่นนี้ Aspose.Slides for .NET ช่วยคุณสร้างรูปภาพย่อของสไลด์

เพื่อสร้างรูปภาพย่อของสไลด์ใดๆ ที่ต้องการโดยใช้ Aspose.Slides for .NET:

1. สร้างอินสแตนซ์ของคลาส **Presentation**.
1. รับอ้างอิงของสไลด์ที่ต้องการโดยใช้ ID หรือดัชนี.
1. รับรูปภาพย่อของสไลด์ที่อ้างอิงในสเกลที่ระบุ.
1. บันทึกรูปภาพย่อในรูปแบบภาพที่ต้องการใดๆ.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์พรีเซนเทชัน
using (Presentation pres = new Presentation(srcFileName))
{
    //เข้าถึงสไลด์แรก
    ISlide sld = pres.Slides[0];

    //สร้างภาพเต็มสเกล
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //บันทึกภาพลงดิสก์ในรูปแบบ JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)