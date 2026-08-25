---
title: การดำเนินการนำเสนอแบบ Low-Code ใน .NET
linktitle: API Low-Code
type: docs
weight: 50
url: /th/net/low-code-presentation-operations/
keywords:
- API การนำเสนอแบบ Low-Code
- แปลงการนำเสนอ
- ผสานการนำเสนอ
- วนลูปสไลด์
- วนลูปรูปทรง
- วนลูปข้อความ
- รวบรวมรูปทรง
- บีบอัดการนำเสนอ
- ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้
- ลบเลย์เอาต์สไลด์ที่ไม่ได้ใช้
- บีบอัดฟอนต์ที่ฝังอยู่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้ Aspose.Slides low-code API ใน .NET เพื่อแปลงและผสานการนำเสนอ, วนลูปผ่านเนื้อหา, รวบรวมรูปทรง, และลดขนาดการนำเสนอ."
---
## **Overview**

[Aspose.Slides.LowCode](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/) namespace ให้คลาสช่วยเหลือแบบสถิตสำหรับการดำเนินการนำเสนอทั่วไป ตัวช่วยเหลือนี้ห่อหุ้มขั้นตอนการทำงานของโมเดลวัตถุที่ใช้บ่อยในเมธอดที่มุ่งเน้น ทำให้คุณสามารถแปลงหรือผสานไฟล์ ประมวลผลส่วนประกอบของการนำเสนอ รวบรวมรูปทรง และลบเนื้อหาที่ไม่ได้ใช้โดยใช้โค้ดน้อยลง

ตัวช่วยแบบ low‑code จะมีประโยชน์ที่สุดเมื่อการดำเนินการใช้กับไฟล์หรือการนำเสนอทั้งหมดและกระบวนการทำงานเริ่มต้นตรงกับความต้องการของคุณ ใช้ [Aspose.Slides object model](https://reference.aspose.com/slides/th/net/aspose.slides/) เต็มรูปแบบเมื่อคุณต้องการการควบคุมระดับละเอียดสำหรับสไลด์แต่ละสไลด์ มาสเตอร์, เลย์เอาต์, รูปทรง, การตั้งค่าการส่งออก หรือความสัมพันธ์ระหว่างส่วนประกอบของการนำเสนอ

ตารางต่อไปนี้สรุปตัวช่วยที่มีให้:

| ตัวช่วย | ใช้สำหรับ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/convert/) | การแปลงการนำเสนอเป็นรูปแบบอื่นด้วยการเรียกไฟล์ต่อไฟล์โดยตรง |
| [Merger](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/merger/) | การรวมไฟล์การนำเสนอทั้งหมดที่มีรูปแบบเดียวกัน |
| [ForEach](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/) | การดำเนินการกับสไลด์, รูปทรง, ย่อหน้า หรือส่วนข้อความแต่ละรายการ |
| [Collect](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/collect/) | การดึงรูปทรงจากการนำเสนอทั้งหมดเพื่อการประมวลผลหรือวิเคราะห์ซ้ำ |
| [Compress](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/) | การลบมาสเตอร์และเลย์เอาต์ที่ไม่ได้ใช้และการลดข้อมูลฟอนต์ที่ฝังอยู่ |

## **Convert a Presentation**

ใช้ [Convert.AutoByExtension](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/convert/autobyextension/) เมื่อส่วนขยายไฟล์ผลลัพธ์เพียงพอที่จะเลือกรูปแบบการส่งออก เมธอดจะเปิดการนำเสนอต้นฉบับ, กำหนดรูปแบบที่ต้องการจากเส้นทางไฟล์ผลลัพธ์, แล้วเขียนผลลัพธ์

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

คลาส [Convert](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/convert/) ยังมีเมธอดเฉพาะสำหรับการส่งออกเป็น PDF, SVG, JPEG, PNG, และ TIFF ใช้วัตถุโมเดลเต็มรูปแบบเมื่อคุณต้องการตรวจสอบหรือแก้ไขการนำเสนอก่อนการส่งออกหรือกำหนดตัวเลือกการส่งออกที่ตัวช่วยไม่ได้เปิดเผย ดู [Convert Presentation](/slides/th/net/convert-presentation/) สำหรับกระบวนการทำงานและตัวเลือกตามรูปแบบ

## **Merge Presentations**

ใช้ [Merger.Process](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/merger/process/) เพื่อผสานไฟล์การนำเสนอทั้งหมดด้วยการเรียกครั้งเดียว การนำเสนอที่ป้อนเข้าต้องมีรูปแบบไฟล์เดียวกัน

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

ตัวช่วยนี้เหมาะเมื่อสไลด์ทั้งหมดควรต่อท้ายเป็นผลลัพธ์เดียวโดยไม่ต้องเลือกหรือทำแผนที่สไลด์แยกใช้ ใช้วัตถุโมเดลเต็มรูปแบบเมื่อคุณต้องการผสานสไลด์ที่เลือก, ใช้มาสเตอร์หรือเลย์เอาต์ปลายทาง, รักษาภาคส่วนอย่างชัดเจน, หรือจัดการขนาดสไลด์ที่แตกต่างกัน ดู [Merge Presentations](/slides/th/net/merge-presentation/) สำหรับสถานการณ์เหล่านั้น

## **Iterate Through Presentation Elements**

คลาส [ForEach](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/) เรียกคอลแบ็กสำหรับแต่ละประเภทของส่วนประกอบการนำเสนอที่ร้องขอ ช่วยหลีกเลี่ยงการวนลูปคอลเลกชันซ้อนกันและสะดวกสำหรับการตรวจสอบหรือการเปลี่ยนแปลงรูปแบบทั่วทั้งการนำเสนอ

ตัวอย่างต่อไปนี้ใช้ [ForEach.Slide](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/paragraph/), และ [ForEach.Portion](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/portion/) เพื่อสำรวจส่วนประกอบที่สอดคล้องกัน:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

โดยค่าเริ่มต้น การท่องรูปทรงและข้อความทั่วทั้งการนำเสนอจะรวมสไลด์แบบปกติ, มาสเตอร์ และเลย์เอาต์ การโอเวอร์โหลดที่มีพารามิเตอร์ `includeNotes` สามารถประมวลผลสไลด์โน้ตได้เช่นกัน ใช้วิธีวนลูปคอลเลกชันโดยตรงเมื่อลำดับการท่อง, การออกจากลูปก่อนเวลา, การกรองก่อนเรียกคอลแบ็ก, หรือการควบคุมความสัมพันธ์แม่-ลูกอย่างละเอียดมีความสำคัญ

## **Collect Shapes**

ใช้ [Collect.Shapes](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/collect/shapes/) เมื่อคุณต้องการคอลเลกชันของรูปทรงทั้งหมดในการนำเสนอแทนการใช้คอลแบ็กสำหรับแต่ละรูปทรง สิ่งนี้มีประโยชน์เมื่อชุดเดียวกันจะต้องถูกกรอง, นับ, หรือประมวลผลหลายครั้ง

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

ใช้ [ForEach.Shape](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/shape/) แทนเมื่อแต่ละรูปทรงสามารถจัดการได้ทันทีและคุณไม่จำเป็นต้องเก็บผลลัพธ์ที่รวบรวมไว้

## **Compress Presentation Content**

คลาส [Compress](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/) สามารถลบองค์ประกอบโครงสร้างที่ไม่ได้ใช้และลดข้อมูลฟอนต์ที่ฝังอยู่:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) ลบสไลด์เลย์เอาต์ที่ไม่มีสไลด์ปกติอ้างอิง
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) ลบมาสเตอร์สไลด์ที่ไม่ถูกใช้แล้ว
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/compressembeddedfonts/) ลบอักขระที่ไม่ได้ใช้จากฟอนต์ที่ฝังอยู่

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

ให้ลบเลย์เอาต์ที่ไม่ได้ใช้ก่อนมาสเตอร์ที่ไม่ได้ใช้ เพื่อให้มาสเตอร์ที่กลายเป็นไม่มีการอ้างอิงหลังจากทำความสะอาดเลย์เอาต์ก็สามารถลบได้ บันทึกการนำเสนอที่ปรับแต่งแล้วเป็นไฟล์ใหม่หากคุณอาจต้องการมาสเตอร์, เลย์เอาต์, หรือข้อมูลฟอนต์ที่ฝังเต็มรูปแบบในภายหลัง สำหรับรายละเอียดเพิ่มเติม ดู [Slide Master](/slides/th/net/slide-master/) และ [Embedded Font](/slides/th/net/embedded-font/)

## **FAQ**

**เมื่อใดควรใช้ low‑code API แทนการใช้วัตถุโมเดลเต็มรูปแบบ?**

ใช้ตัวช่วย low‑code เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือการนำเสนอทั้งหมดและไม่ต้องการการควบคุมละเอียดในส่วนประกอบแต่ละส่วน ใช้วัตถุโมเดลเต็มรูปแบบเมื่อคุณต้องการเลือกสไลด์เฉพาะ, ควบคุมความสัมพันธ์ของมาสเตอร์และเลย์เอาต์, ตรวจสอบสถานะกลาง, หรือกำหนดพฤติกรรมที่ตัวช่วยไม่ได้เปิดเผย

**Merger สามารถผสานการนำเสนอในรูปแบบไฟล์ต่างกันได้หรือไม่?**

ไม่ได้ ตัวช่วย [Merger.Process](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/merger/process/) ต้องการการนำเสนอที่ป้อนเข้ามาในรูปแบบเดียวกัน ให้แปลงไฟล์อินพุตเป็นรูปแบบทั่วไปก่อน เช่นด้วย [Convert.AutoByExtension](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/convert/autobyextension/), จากนั้นจึงผสานไฟล์ที่แปลงแล้ว

**ForEach ประมวลผลมาสเตอร์, เลย์เอาต์, และสไลด์โน้ตหรือไม่?**

[ForEach.Slide](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/slide/) ท่องผ่านสไลด์การนำเสนอปกติ [ForEach.Shape](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/paragraph/), และ [ForEach.Portion](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/portion/) จะรวมสไลด์ปกติ, มาสเตอร์, และเลย์เอาต์โดยค่าเริ่มต้น ใช้โอเวอร์โหลดที่กำหนด `includeNotes` เป็น `true` เพื่อรวมสไลด์โน้ต

**ความแตกต่างระหว่าง ForEach.Shape และ Collect.Shapes คืออะไร?**

ใช้ [ForEach.Shape](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/shape/) เพื่อประมวลผลแต่ละรูปทรงทันทีผ่านคอลแบ็ก ใช้ [Collect.Shapes](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/collect/shapes/) เมื่อคุณต้องการผลลัพธ์เชิง enumerable ที่สามารถเก็บ, กรอง, นับ, หรือท่องหลายครั้งได้

**Compress ทำให้ไฟล์การนำเสนอมีขนาดเล็กลงเสมอหรือไม่?**

ไม่จำเป็น ผลลัพธ์ขึ้นอยู่กับว่าการนำเสนอมีเลย์เอาต์ที่ไม่ได้ใช้, มาสเตอร์ที่ไม่ได้ใช้, หรือฟอนต์ที่ฝังที่มีอักขระไม่ได้ใช้หรือไม่ หากไม่มีสิ่งเหล่านี้ การดำเนินการ [Compress](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/) อาจไม่ลดขนาดไฟล์

**การเปลี่ยนแปลงที่ทำโดย ForEach หรือ Compress จะถูกบันทึกอัตโนมัติหรือไม่?**

ไม่ ตัวช่วยเหลือนี้ทำงานบนวัตถุ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ที่โหลดอยู่ในหน่วยความจำ หลังจากแก้ไขส่วนประกอบในคอลแบ็กของ [ForEach](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/) หรือเรียกใช้ [Compress](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/) ให้เรียก [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) เพื่อบันทึกผลลัพธ์

## **Related Articles**

- [Convert Presentation](/slides/th/net/convert-presentation/)
- [Merge Presentations](/slides/th/net/merge-presentation/)
- [Slide Master](/slides/th/net/slide-master/)
- [Manage Text Box](/slides/th/net/manage-textbox/)
- [Embedded Font](/slides/th/net/embedded-font/)