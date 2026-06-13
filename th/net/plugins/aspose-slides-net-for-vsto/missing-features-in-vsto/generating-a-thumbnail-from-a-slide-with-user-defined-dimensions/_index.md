---
title: การสร้างภาพย่อจากสไลด์ด้วยมิติที่กำหนดโดยผู้ใช้
type: docs
weight: 100
url: /th/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
เพื่อสร้างรูปภาพย่อย (thumbnail) ของสไลด์ที่ต้องการใด ๆ ด้วย Aspose.Slides for .NET:

- สร้างอินสแตนซ์ของคลาส Presentation.
- รับอ้างอิงของสไลด์ที่ต้องการโดยใช้ ID หรือดัชนีของมัน.
- รับค่าปัจจัยสเกล X และ Y ตามมิติ X และ Y ที่ผู้ใช้กำหนด.
- ดึงภาพย่อของสไลด์ที่อ้างอิงในสเกลที่กำหนด.
- บันทึกภาพย่อในรูปแบบไฟล์ภาพที่ต้องการใด ๆ.
## **ตัวอย่าง**
```cs
//สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //เข้าถึงสไลด์แรก
    ISlide sld = pres.Slides[0];

    //มิติที่กำหนดโดยผู้ใช้
    int desiredX = 1200;
    int desiredY = 800;

    //รับค่าปรับสเกลของ X และ Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //สร้างภาพเต็มสเกล
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //บันทึกรูปภาพลงดิสก์ในรูปแบบ JPEG
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **ดาวน์โหลดตัวอย่างการทำงาน**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
สำหรับรายละเอียดเพิ่มเติม เยี่ยมชม [แปลงสไลด์](/slides/th/net/convert-slide/).
{{% /alert %}}