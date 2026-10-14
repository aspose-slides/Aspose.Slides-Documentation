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

บทความนี้อธิบายวิธีแปลงสไลด์การนำเสนอเป็นภาพ PNG ด้วย Aspose.Slides สำหรับ .NET คุณสามารถโหลดการนำเสนอในรูปแบบเช่น PPT, PPTX และ ODP, แสดงผลแต่ละสไลด์, และบันทึกเป็นไฟล์ PNG แยกแต่ละไฟล์ได้

ตัวอย่างด้านล่างนี้แสดงการเรนเดอร์รูปย่อ, การตั้งค่าอัตราส่วนการขยาย, การระบุขนาดผลลัพธ์เป็นพิกเซล, และการเลือกสไตล์การเรนเดอร์ไล่สี

## **แปลง PowerPoint เป็น PNG**

Load a presentation with the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class and access its slides through the [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) collection. The example renders every slide with [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) without parameters to create a thumbnail. It then calls [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) with [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) to save each rendered slide as a PNG image.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
การเรียกใช้ [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) แบบไม่มีพารามิเตอร์จะเรนเดอร์ที่สเกล 0.2 ตัวอย่างเช่น สไลด์ที่มีขนาด 720 × 540 จุดจะสร้างรูปย่อขนาด 144 × 108 พิกเซล เพื่อควบคุมขนาดผลลัพธ์ ให้ใช้เวอร์ชันที่รองรับอัตราส่วนการขยายหรือขนาดภาพที่ระบุโดยชัดเจนตามที่แสดงด้านล่าง
{{% /alert %}}

## **แปลง PowerPoint เป็น PNG ด้วยขนาดที่กำหนดเอง**

ส่งอัตราส่วนการขยายแนวนอนและแนวตั้งไปยัง [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) เพื่อควบคุมขนาดการเรนเดอร์ ในตัวอย่างนี้อัตราส่วนทั้งสองเป็น 2 ดังนั้นสไลด์ที่มีขนาด 720 × 540 จุดจะสร้างภาพขนาด 1440 × 1080 พิกเซล อัตราส่วนที่เท่ากันจะรักษาอัตราส่วนภาพของสไลด์ไว้ ภาพแต่ละภาพจะถูกบันทึกในรูปแบบ PNG ด้วย [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **แปลง PowerPoint เป็น PNG ด้วยขนาดกำหนดเอง**

เพื่อระบุขนาดผลลัพธ์เป็นพิกเซล ให้ส่งขนาดไปยัง [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) แทนการใช้สเกล ตัวอย่างนี้จะเรนเดอร์สไลด์ทั้งหมดที่ขนาด 960 × 720 พิกเซลและบันทึกผลลัพธ์ด้วย [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) เลือกขนาดที่สอดคล้องกับอัตราส่วนของสไลด์เพื่อหลีกเลี่ยงการบิดเบือนภาพ

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **เลือกสไตล์การเรนเดอร์ไล่สี**

สมมติว่ามีสไลด์ที่มีการเติมไล่สี แต่การเปลี่ยนแปลงใน PNG ที่ส่งออกอาจดูอ่อนแอหรือแตกต่างจากที่เห็นใน PowerPoint คุณสามารถใช้คุณสมบัติ [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) ของ [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) เพื่อเลือกวิธีการเรนเดอร์ไล่สีได้

ดาวน์โหลดไฟล์ [gradient-styles.pptx](gradient-styles.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีไล่สีเชิงเส้นสองแบบ: จากสีไซอานไปสีส้มที่ด้านบนและจากสีฟ้าไปสีเหลืองที่ด้านล่าง แต่ละไล่สีมีจุดหยุดสองจุดที่ 0% และ 100%

ตัวอย่างต่อไปนี้โหลดการนำเสนอนี้และเรนเดอร์สไลด์แรกเดียวกันในทั้งสองโหมดด้วย [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/)

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

ภาพด้านล่างแสดงผลลัพธ์จากสไลด์เดียวกัน โดยมีไล่สีทั้งสองแบบในแต่ละภาพ:

| Default | PowerPointUI |
| --- | --- |
| ![ไล่สีไซอาน-ส้มและสีน้ำเงิน-เหลืองที่แสดงด้วย Default](gradient-Default.png) | ![ไล่สีเดียวกันที่แสดงด้วย PowerPointUI](gradient-PowerPointUI.png) |

ในตัวอย่างนี้ `Default` ให้สีกลางที่อ่อนกว่า ในขณะที่ `PowerPointUI` ให้สีกลางที่เข้มกว่า ความแตกต่างขึ้นอยู่กับสีและจุดหยุดในไล่สี

เลือก `Default` เมื่อผลลัพธ์มาตรฐานของ Aspose.Slides ตรงกับความต้องการของคุณ ใช้ `PowerPointUI` เมื่อคุณต้องการให้ภาพตรงกับการแสดงผลใน PowerPoint เปรียบเทียบผลลัพธ์ทั้งสองกับผลลัพธ์ที่คุณต้องการ; ไม่มีโหมดใดที่ดีกว่ากันโดยทั่วไป

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกรูปร่างเฉพาะ เช่น ชาร์ตหรือภาพ แทนการส่งออกทั้งสไลด์ได้อย่างไร?**

Aspose.Slides รองรับการ [สร้างรูปย่อสำหรับรูปร่างแต่ละชิ้น](/slides/th/net/create-shape-thumbnails/), ทำให้คุณสามารถเรนเดอร์รูปร่างเป็นภาพ PNG ได้

**รองรับการแปลงแบบขนานบนเซิร์ฟเวอร์หรือไม่?**

ใช่ ใช้การสร้างอินสแตนซ์การนำเสนอแยกต่างหากสำหรับแต่ละเธรดหรือกระบวนการ; [ห้ามแชร์อินสแตนซ์เดียวกันในหลายเธรด](/slides/th/net/multithreading/)

**ข้อจำกัดของโหมดประเมินผลเมื่อส่งออกเป็น PNG มีอะไรบ้าง?**

โหมดประเมินผลจะเพิ่มลายน้ำให้กับภาพผลลัพธ์และใช้ [ข้อจำกัดอื่น ๆ](/slides/th/net/licensing/) จนกว่าจะมีการใช้ไลเซนส์