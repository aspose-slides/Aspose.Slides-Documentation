---
title: แสดงสไลด์เป็นภาพขนาดย่อเป็น JPEG
type: docs
weight: 60
url: /th/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** ใช้เพื่อสร้างไฟล์พรีเซนเทชันที่ประกอบด้วยสไลด์ สไลด์เหล่านี้สามารถดูได้โดยการเปิดไฟล์พรีเซนเทชันด้วย Microsoft PowerPoint แต่บางครั้งนักพัฒนาอาจต้องการดูสไลด์ในรูปของภาพโดยใช้โปรแกรมดูภาพที่ชอบ ในกรณีเช่นนี้ Aspose.Slides for .NET ช่วยคุณสร้างภาพขนาดย่อของสไลด์

เพื่อสร้างภาพขนาดย่อของสไลด์ที่ต้องการโดยใช้ Aspose.Slides for .NET:

1. สร้างอินสแตนซ์ของคลาส **Presentation**.
2. รับอ้างอิงของสไลด์ที่ต้องการโดยใช้ ID หรือดัชนีของมัน.
3. ได้รับภาพขนาดย่อของสไลด์ที่อ้างอิงในสเกลที่ระบุ.
4. บันทึกภาพขนาดย่อในรูปแบบภาพที่ต้องการใดก็ได้.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์พรีเซนเทชัน
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

## **ดาวน์โหลดตัวอย่างโค้ด**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)