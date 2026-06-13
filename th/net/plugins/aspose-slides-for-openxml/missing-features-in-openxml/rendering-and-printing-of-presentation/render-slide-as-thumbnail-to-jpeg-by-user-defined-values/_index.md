---
title: เรนเดอร์สไลด์เป็นภาพย่อเป็น JPEG ด้วยค่าที่กำหนดโดยผู้ใช้
type: docs
weight: 70
url: /th/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
เพื่อสร้างภาพย่อของสไลด์ใด ๆ ที่ต้องการโดยใช้ Aspose.Slides for .NET:

1. สร้างอินสแตนซ์ของคลาส **Presentation**
1. รับอ้างอิงของสไลด์ที่ต้องการโดยใช้ ID หรือดัชนีของมัน
1. รับค่าอัตราส่วนการขยาย X และ Y ตามมิติ X และ Y ที่ผู้ใช้กำหนด
1. รับภาพย่อนของสไลด์ที่อ้างอิงในอัตราส่วนที่ระบุ
1. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใด ๆ

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

    //สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์พรีเซนเทชัน
using (Presentation pres = new Presentation(srcFileName))
{
        //เข้าถึงสไลด์แรก
    ISlide sld = pres.Slides[0];

        //มิติที่กำหนดโดยผู้ใช้
    int desiredX = 1200;
    int desiredY = 800;

        //รับค่าการสเกลของ X và Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

        //สร้างภาพเต็มสเกล
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
            //บันทึกภาพลงดิสก์ในรูปแบบ JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
```
## **ดาวน์โหลดตัวอย่างโค้ด**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)