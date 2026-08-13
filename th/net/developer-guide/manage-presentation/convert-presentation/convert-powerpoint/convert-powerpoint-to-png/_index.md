---
title: แปลงสไลด์ PowerPoint เป็น PNG ใน .NET
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/net/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PNG
- การนำเสนอเป็น PNG
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
description: "แปลงการนำเสนอ PowerPoint เป็นภาพ PNG คุณภาพสูงอย่างรวดเร็วด้วย Aspose.Slides สำหรับ .NET พร้อมผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงการนำเสนอ PowerPoint เป็นภาพ PNG ด้วย Aspose.Slides แสดงวิธีโหลดไฟล์การนำเสนอในรูปแบบเช่น PPT, PPTX และ ODP, เรนเดอร์สไลด์เป็นภาพ และบันทึกผลลัพธ์ในรูปแบบ PNG

บทความยังสาธิตวิธีปรับแต่งภาพ PNG ที่สร้างขึ้นโดยการกำหนดค่าตำแหน่งสเกลหรือระบุความกว้างและความสูงที่ต้องการ

## **แปลง PowerPoint เป็น PNG**

ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. รับอ็อบเจกต์สไลด์จากคอลเลกชัน [Presentation.Slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/properties/slides) ภายใต้อินเทอร์เฟซ [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide).
3. ใช้เมธอด [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/) เพื่อเรนเดอร์แต่ละสไลด์ตามสเกลที่คุณต้องการ
4. ใช้เมธอด [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/th/net/aspose.slides.ipresentation/save/methods/5) เพื่อบันทึกภาพย่อของสไลด์เป็นรูปแบบ PNG

โค้ด C# นี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็น PNG วัตถุ Presentation สามารถโหลดไฟล์ PPT, PPTX, ODP ฯลฯ แล้วแต่ละสไลด์ในวัตถุ Presentation จะถูกแปลงเป็นรูปแบบ PNG หรือรูปแบบภาพอื่น

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**หมายเหตุ:** อาร์กิวเมนต์สเกล `1f, 1f` เรนเดอร์แต่ละสไลด์ในขนาดเต็ม ดังนั้นสไลด์ขนาด 720×540 pt จะสร้างภาพขนาด 720×540 px เมธอด overload ของ [GetImage()](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/) ที่ไม่มีพารามิเตอร์จะคืนค่าภาพย่อตัวอย่างที่เล็กกว่ามาก
{{% /alert %}} 

## **แปลง PowerPoint เป็น PNG ด้วยมิติที่กำหนดเอง**

หากต้องการสร้างไฟล์ PNG ที่มีสเกลเฉพาะ คุณสามารถกำหนดค่าของ `desiredX` และ `desiredY` ซึ่งเป็นค่าที่กำหนดมิติของภาพย่อที่ได้

โค้ด C# นี้สาธิตการดำเนินการที่อธิบายไว้:

```c#
using Aspose.Slides;

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

หากต้องการสร้างไฟล์ PNG ที่มีขนาดเฉพาะ คุณสามารถส่งอาร์กิวเมนต์ `width` และ `height` ที่ต้องการสำหรับ `imageSize`

โค้ดนี้แสดงวิธีแปลง PowerPoint เป็น PNG พร้อมระบุขนาดของภาพ:

```c#
using System.Drawing;
using Aspose.Slides;

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

## **FAQ**

### ฉันจะส่งออกเฉพาะรูปทรงที่ระบุ (เช่น แผนภูมิหรือรูปภาพ) แทนการส่งออกสไลด์ทั้งหมดได้อย่างไร?

Aspose.Slides รองรับการสร้างภาพย่อสำหรับรูปทรงแต่ละรายการ คุณสามารถเรนเดอร์รูปทรงเป็นภาพ PNG ได้

### การแปลงแบบขนานสนับสนุนบนเซิร์ฟเวอร์หรือไม่?

ใช่ แต่ **ห้าม**แชร์อินสแตนซ์ Presentation เดียวกันข้ามเธรด ใช้อินสแตนซ์แยกสำหรับแต่ละเธรดหรือกระบวนการ

### ข้อจำกัดของเวอร์ชันทดลองเมื่อส่งออกเป็น PNG คืออะไร?

โหมดประเมินผลจะเพิ่มลายน้ำในภาพผลลัพธ์และบังคับใช้ [ข้อจำกัดอื่นๆ](/slides/th/net/licensing/) จนกว่าจะมีการใช้ใบอนุญาต