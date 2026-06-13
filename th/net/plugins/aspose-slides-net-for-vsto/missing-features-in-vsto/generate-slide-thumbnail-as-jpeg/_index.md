---
title: สร้างภาพขนาดย่อของสไลด์เป็น JPEG
type: docs
weight: 90
url: /th/net/generate-slide-thumbnail-as-jpeg/
---
เพื่อสร้างภาพขนาดย่อของสไลด์ที่ต้องการใด ๆ โดยใช้ Aspose.Slides for .NET:

- สร้างอินสแตนซ์ของคลาส Presentation.
- รับการอ้างอิงของสไลด์ที่ต้องการโดยใช้ ID หรือดัชนีของมัน.
- ดึงภาพขนาดย่อของสไลด์ที่อ้างถึงในอัตราส่วนที่กำหนด.
- บันทึกภาพขนาดย่อในรูปแบบภาพที่ต้องการใด ๆ.
## **ตัวอย่าง**
```cs
//สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //เข้าถึงสไลด์แรก
    ISlide sld = pres.Slides[0];

    //สร้างภาพขนาดเต็ม
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //บันทึกภาพลงดิสก์ในรูปแบบ JPEG
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **ดาวน์โหลดตัวอย่างที่ทำงาน**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

สำหรับรายละเอียดเพิ่มเติม โปรดเยี่ยมชม [แปลง PPT และ PPTX เป็น JPG ใน .NET](/slides/th/net/convert-powerpoint-to-jpg/).

{{% /alert %}}