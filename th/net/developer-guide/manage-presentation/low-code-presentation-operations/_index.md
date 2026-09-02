---
title: การดำเนินการงานนำเสนอแบบ Low-Code ใน .NET
linktitle: API Low-Code
type: docs
weight: 50
url: /th/net/low-code-presentation-operations/
keywords:
- API การนำเสนอแบบ low-code
- แปลงงานนำเสนอ
- ผสานงานนำเสนอ
- วนซ้ำสไลด์
- วนซ้ำรูปร่าง
- วนซ้ำข้อความ
- รวบรวมรูปร่าง
- บีบอัดงานนำเสนอ
- ลบมาสเตอร์สไลด์ที่ไม่ใช้
- ลบเลเอาต์สไลด์ที่ไม่ใช้
- บีบอัดฟอนต์ที่ฝังอยู่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้ Aspose.Slides low-code API ใน .NET เพื่อแปลงและผสานงานนำเสนอ, วนซ้ำเนื้อหา, รวบรวมรูปร่าง, และลดขนาดของงานนำเสนอ"
---
## **ภาพรวม**

เนมสเปซ [Aspose.Slides.LowCode](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/) ให้คลาสตัวช่วยแบบสแตติกสำหรับการทำงานทั่วไปของงานนำเสนอ ตัวช่วยเหล่านี้ห่อหุ้มเวิร์กฟลอว์ของอ็อบเจ็กต์โมเดลที่ใช้บ่อยในเมธอดที่มุ่งเน้น ทำให้คุณสามารถแปลงหรือผสานไฟล์ ประมวลผลองค์ประกอบของงานนำเสนอ รวบรวมรูปร่าง และลบเนื้อหาที่ไม่ได้ใช้ได้ด้วยโค้ดที่สั้นลง

ตัวช่วยแบบ Low-code มีประโยชน์สูงสุดเมื่อการดำเนินการใช้กับไฟล์หรือการนำเสนอทั้งหมดและเวิร์กฟลอว์ค่าเริ่มต้นตรงกับความต้องการของคุณ ใช้ [Aspose.Slides object model](https://reference.aspose.com/slides/th/net/aspose.slides/) อย่างเต็มที่เมื่อคุณต้องการการควบคุมระดับละเอียดบนสไลด์แต่ละสไลด์ มาสเตอร์ การจัดวาง รูปร่าง การตั้งค่าแบบส่งออก หรือความสัมพันธ์ระหว่างองค์ประกอบของงานนำเสนอ

ตารางต่อไปนี้สรุปตัวช่วยที่มีอยู่:

| ตัวช่วย | ใช้สำหรับ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/convert/) | แปลงงานนำเสนอเป็นรูปแบบอื่นด้วยการเรียกโดยตรงไฟล์ต่อไฟล์ |
| [Merger](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/merger/) | รวมไฟล์งานนำเสนอทั้งหมดที่มีรูปแบบเดียวกัน |
| [ForEach](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/) | ดำเนินการสำหรับสไลด์ รูปร่าง ย่อหน้า หรือส่วนข้อความทุกรายการ |
| [Collect](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/collect/) | ดึงรูปร่างจากงานนำเสนอทั้งหมดเพื่อการประมวลผลหรือวิเคราะห์ซ้ำหลายครั้ง |
| [Compress](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/) | ลบมาสเตอร์และเลเอาต์ที่ไม่ใช้และลดข้อมูลฟอนต์ที่ฝังอยู่ |

## **แปลงงานนำเสนอ**

ใช้ [Convert.AutoByExtension](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/convert/autobyextension/) เมื่อส่วนขยายไฟล์ผลลัพธ์เพียงพอที่จะเลือกรูปแบบการส่งออก เมธอดนี้จะเปิดงานนำเสนอต้นฉบับ กำหนดรูปแบบที่ต้องการจากเส้นทางไฟล์ผลลัพธ์ และเขียนผลลัพธ์ออกไป

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

คลาส [Convert](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/convert/) ยังมีเมธอดเฉพาะสำหรับการส่งออกเป็น PDF, SVG, JPEG, PNG และ TIFF ใช้โมเดลอ็อบเจ็กต์เต็มเมื่อคุณต้องการตรวจสอบหรือแก้ไขงานนำเสนอก่อนการส่งออก หรือกำหนดค่าตัวเลือกการส่งออกที่ตัวช่วยที่เลือกไม่เปิดเผย ดูที่ [Convert Presentation](/net/convert-presentation/) สำหรับเวิร์กฟลอว์และตัวเลือกตามรูปแบบ

## **ผสานงานนำเสนอ**

ใช้ [Merger.Process](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/merger/process/) เพื่อรวมไฟล์งานนำเสนอทั้งหมดด้วยการเรียกครั้งเดียว งานนำเข้าสำหรับเข้า ต้องมีรูปแบบไฟล์เดียวกัน

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

ตัวช่วยนี้เหมาะเมื่อสไลด์ทั้งหมดควรถูกต่อท้ายเป็นผลลัพธ์เดียวโดยไม่ต้องเลือกหรือแมปแต่ละสไลด์ ใช้โมเดลอ็อบเจ็กต์เต็มเมื่อคุณต้องการผสานสไลด์ที่เลือก ใช้มาสเตอร์หรือเลเอาต์ปลายทาง รักษาส่วนต่างอย่างชัดเจน หรือปรับขนาดสไลด์ที่แตกต่างกัน ดูที่ [Merge Presentations](/net/merge-presentation/) สำหรับสถานการณ์เหล่านั้น

## **วนรอบผ่านองค์ประกอบของงานนำเสนอ**

คลาส [ForEach](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/) จะเรียกคอลแบ็กสำหรับแต่ละประเภทขององค์ประกอบงานนำเสนอที่ร้องขอ ช่วยหลีกเลี่ยงลูปการเก็บข้อมูลซ้อนกันและสะดวกสำหรับการตรวจสอบหรือการเปลี่ยนรูปแบบทั่วทั้งงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้ [ForEach.Slide](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/paragraph/), และ [ForEach.Portion](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/portion/) เพื่อสอบถามองค์ประกอบที่สอดคล้องกัน:

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

โดยค่าเริ่มต้น การเดินทางผ่านรูปร่างและข้อความทั่วงานนำเสนอจะรวมสไลด์ปกติ มาสเตอร์ และเลเอตต์ เวอร์ชันที่มีพารามิเตอร์ `includeNotes` สามารถประมวลผลสไลด์โน้ตได้ด้วย ใช้ลูปการเก็บข้อมูลโดยตรงเมื่ออันดับการเดินทาง การออกก่อนเวลา การกรองก่อนเรียกคอลแบ็ก หรือการควบคุมพาเรนต์-ชิลด์อย่างละเอียดเป็นสิ่งสำคัญ

## **รวบรวมรูปร่าง**

ใช้ [Collect.Shapes](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/collect/shapes/) เมื่อคุณต้องการคอลเลกชันของรูปร่างทั้งหมดในงานนำเสนอแทนคอลแบ็กสำหรับแต่ละรูปร่าง เหมาะเมื่อชุดเดียวกันต้องการการกรอง นับ หรือประมวลผลหลายครั้ง

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

ใช้ [ForEach.Shape](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/shape/) แทนเมื่อต้องการจัดการแต่ละรูปร่างโดยทันทีและไม่จำเป็นต้องเก็บผลลัพธ์ที่รวบรวมไว้

## **บีบอัดเนื้อหางานนำเสนอ**

คลาส [Compress](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/) สามารถลบองค์ประกอบโครงสร้างที่ไม่ใช้และลดข้อมูลฟอนต์ที่ฝังอยู่ได้:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) ลบสไลด์เลเอาต์ที่ไม่มีสไลด์ปกติอ้างอิง
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้แล้ว
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

ลบเลเอาต์ที่ไม่ใช้ก่อนมาสเตอร์ที่ไม่ใช้เพื่อให้มาสเตอร์ที่กลายเป็นไม่มีการอ้างอิงหลังจากทำความสะอาดเลเอาต์สามารถถูกลบได้ บันทึกงานนำเสนอที่ปรับแต่งแล้วเป็นไฟล์ใหม่หากคุณอาจต้องการมาสเตอร์เดิม เลเอาต์ หรือข้อมูลฟอนต์ที่ฝังทั้งหมดในภายหลัง สำหรับรายละเอียดเพิ่มเติม ดูที่ [Slide Master](/net/slide-master/) และ [Embedded Font](/net/embedded-font/).

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ Low-code API แทนโมเดลอ็อบเจ็กต์เต็ม?**

ใช้ตัวช่วย Low-code เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือการนำเสนอทั้งหมดและไม่ต้องการการควบคุมละเอียดบนแต่ละองค์ประกอบ ใช้โมเดลอ็อบเจ็กต์เต็มเมื่อคุณต้องการเลือกสไลด์เฉพาะ ควบคุมความสัมพันธ์ของมาสเตอร์และเลเอาต์ ตรวจสอบสถานะระหว่างขั้น หรือกำหนดพฤติกรรมที่ตัวช่วยไม่เปิดเผย

**Merger สามารถผสานงานนำเสนอในรูปแบบไฟล์ที่ต่างกันได้หรือไม่?**

ไม่. [Merger.Process](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/merger/process/) ต้องการงานนำเข้าสำหรับเข้าในรูปแบบเดียวกัน แปลงไฟล์เข้าเป็นรูปแบบเดียวกันก่อน เช่นโดยใช้ [Convert.AutoByExtension](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/convert/autobyextension/), แล้วจึงผสานไฟล์ที่แปลงแล้ว

**ForEach ประมวลผลสไลด์มาสเตอร์, เลเอต์, และโน้ตหรือไม่?**

[ForEach.Slide](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/slide/) วนซ้ำสไลด์ปกติของงานนำเสนอ การดำเนินการทั่วงานนำเสนอของ [ForEach.Shape](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/paragraph/), และ [ForEach.Portion](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/portion/) จะรวมสไลด์ปกติ มาสเตอร์ และเลเอตต์โดยค่าเริ่มต้น ใช้เวอร์ชันที่มีพารามิเตอร์ `includeNotes` ตั้งค่าเป็น `true` เพื่อรวมสไลด์โน้ต

**ความแตกต่างระหว่าง ForEach.Shape และ Collect.Shapes คืออะไร?**

ใช้ [ForEach.Shape](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/shape/) เพื่อประมวลผลแต่ละรูปร่างทันทีผ่านคอลแบ็ก ใช้ [Collect.Shapes](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/collect/shapes/) เมื่อคุณต้องการผลลัพธ์ที่เป็น enumerable ที่สามารถเก็บไว้ กรอง นับ หรือเดินทางหลายครั้ง

**Compress ทำให้ไฟล์งานนำเสนอเล็กลงเสมอหรือไม่?**

ไม่จำเป็น ผลลัพธ์ขึ้นอยู่กับว่ามีเลเอาต์ที่ไม่ใช้ มาสเตอร์ที่ไม่ใช้ หรือฟอนต์ที่ฝังซึ่งมีอักขระที่ไม่ใช้หรือไม่ หากไม่มีส่วนใดส่วนหนึ่ง การดำเนินการ [Compress](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/) ที่สอดคล้องอาจไม่ลดขนาดไฟล์

**การเปลี่ยนแปลงที่ทำโดย ForEach หรือ Compress จะถูกบันทึกโดยอัตโนมัติหรือไม่?**

ไม่ ตัวช่วยเหล่านี้ทำงานบนอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ที่โหลดอยู่ในหน่วยความจำ หลังจากเปลี่ยนแปลงองค์ประกอบในคอลแบ็กของ [ForEach](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/foreach/) หรือรัน [Compress](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/), ให้เรียก [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) เพื่อบันทึกผลลัพธ์

## **บทความที่เกี่ยวข้อง**

- [แปลงงานนำเสนอ](/net/convert-presentation/)
- [ผสานงานนำเสนอ](/net/merge-presentation/)
- [มาสเตอร์สไลด์](/net/slide-master/)
- [จัดการกล่องข้อความ](/net/manage-textbox/)
- [ฟอนต์ที่ฝัง](/net/embedded-font/)