---
title: แปลงสไลด์ PowerPoint เป็น PNG ใน .NET
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/net/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PNG
- งานนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- บันทึก PPT เป็น PNG
- บันทึก PPTX เป็น PNG
- ส่งออก PPT เป็น PNG
- ส่งออก PPTX เป็น PNG
- .NET
- C#
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็นภาพ PNG คุณภาพสูงอย่างรวดเร็วด้วย Aspose.Slides สำหรับ .NET เพื่อให้ได้ผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการแปลงงานนำเสนอ PowerPoint เป็นรูปภาพ PNG ด้วย Aspose.Slides พร้อมแสดงวิธีโหลดไฟล์งานนำเสนอในรูปแบบเช่น PPT, PPTX และ ODP, ทำการเรนเดอร์สไลด์เป็นภาพ และบันทึกผลลัพธ์เป็นรูปแบบ PNG  

บทความยังสาธิตวิธีปรับแต่งภาพ PNG ที่สร้างโดยการกำหนดค่าตำแหน่งสเกลหรือระบุความกว้างและความสูงที่ต้องการ  

## **แปลง PowerPoint เป็น PNG**

ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. ดึงอ็อบเจกต์สไลด์จากคอลเล็กชัน [Presentation.Slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/properties/slides) ภายใต้ส่วนติดต่อ [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide)  
3. ใช้เมธอด [ISlide.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/) เพื่อรับภาพย่อของแต่ละสไลด์  
4. ใช้เมธอด [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/th/net/aspose.slides.ipresentation/save/methods/5) เพื่อบันทึกภาพย่อของสไลด์เป็นรูปแบบ PNG  

โค้ด C# นี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PNG โดยอ็อบเจกต์ Presentation สามารถโหลดไฟล์ PPT, PPTX, ODP เป็นต้น แล้วแต่ละสไลด์ในอ็อบเจกต์ Presentation จะถูกแปลงเป็นรูปแบบ PNG หรือรูปแบบภาพอื่น ๆ  

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **แปลง PowerPoint เป็น PNG ด้วยมิติที่กำหนดเอง**

หากต้องการรับไฟล์ PNG ที่มีสเกลใกล้เคียงกับที่ต้องการ คุณสามารถตั้งค่าตัวแปร `desiredX` และ `desiredY` ซึ่งกำหนดขนาดของภาพย่อผลลัพธ์ได้  

โค้ดใน C# นี้สาธิตการดำเนินการที่อธิบายไว้:  

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **แปลง PowerPoint เป็น PNG ด้วยขนาดที่กำหนดเอง**

หากต้องการรับไฟล์ PNG ที่มีขนาดใกล้เคียงตามที่ต้องการ คุณสามารถส่งอาร์กิวเมนต์ `width` และ `height` ที่ต้องการสำหรับ `imageSize`  

โค้ดนี้แสดงวิธีแปลง PowerPoint เป็น PNG พร้อมระบุขนาดของภาพ:  

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกเฉพาะรูปร่างที่กำหนด (เช่น แผนภูมิหรือรูปภาพ) แทนที่จะส่งออกสไลด์ทั้งหมดได้อย่างไร?**  

Aspose.Slides รองรับ [generating thumbnails for individual shapes](/slides/th/net/create-shape-thumbnails/); คุณสามารถเรนเดอร์รูปร่างเป็นภาพ PNG  

**การแปลงพร้อมกันแบบขนานรองรับบนเซิร์ฟเวอร์หรือไม่?**  

ใช่ แต่ต้อง [don’t share](/slides/th/net/multithreading/) อินสแตนซ์ Presentation เดียวข้ามเธรด ใช้อินสแตนซ์แยกต่อเธรดหรือกระบวนการ  

**ข้อจำกัดของรุ่นทดลองเมื่อส่งออกเป็น PNG มีอะไรบ้าง?**  

โหมดการประเมินค่าจะใส่น้ำแสดงบนภาพผลลัพธ์และบังคับใช้ [other restrictions](/slides/th/net/licensing/) จนกว่าจะมีการใส่ใบอนุญาต