---
title: สร้างการพรีเซนต์ชันใน .NET
linktitle: สร้างการพรีเซนต์ชัน
type: docs
weight: 10
url: /th/net/create-presentation/
keywords:
- สร้างการพรีเซนต์ชัน
- การพรีเซนต์ชันใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- การพรีเซนต์ชัน
- .NET
- C#
- Aspose.Slides
description: "สร้างการพรีเซนต์ชันใน .NETด้วย Aspose.Slides—สร้างไฟล์ PPT, PPTX, และ ODP, ใช้ประโยชน์จากการสนับสนุน OpenDocument, และบันทึกโดยโปรแกรมเพื่อผลลัพธ์ที่เชื่อถือได้."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างการพรีเซนต์ชันใน Aspose.Slides, เพิ่มเนื้อหาง่าย ๆ ลงในสไลด์, และบันทึกผลลัพธ์เป็นไฟล์ นอกจากนี้ยังสาธิตวิธีสร้างและบันทึกการพรีเซนต์ชันใหม่, เปิดการพรีเซนต์ชันที่มีอยู่ในรูปแบบที่รองรับ, และบันทึกเป็นรูปแบบอื่น อีกทั้งบทความยังรวมส่วน FAQ สั้น ๆ ที่ครอบคลุมคำถามทั่วไปเกี่ยวกับรูปแบบ, แม่แบบ, ขนาดสไลด์, หน่วยวัด, การใช้หน่วยความจำ, การทำงานหลายเธรด, การให้สิทธิ์, ลายเซ็นดิจิทัล, และการสนับสนุน VBA

## **สร้างการพรีเซนต์ชัน PowerPoint**
เพื่อเพิ่มเส้นธรรมดาแบบง่ายลงในสไลด์ที่เลือกของการพรีเซนต์ชัน โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส Presentation
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
1. เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้โดยวัตถุ Shapes
1. บันทึกการพรีเซนต์ชันที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างที่ให้ด้านล่าง เราได้เพิ่มเส้นลงในสไลด์แรกของการพรีเซนต์ชัน

```c#
// สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์พรีเซนต์ชัน
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // เพิ่ม autoshape ประเภท line
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **สร้างและบันทึกการพรีเซนต์ชัน**

<a name="csharp-create-save-presentation"><strong>ขั้นตอน: สร้างและบันทึกการพรีเซนต์ชันใน C#</strong></a>

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) คลาส
2. บันทึก _Presentation_ เป็นรูปแบบใดก็ได้ที่รองรับโดย [SaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/)

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **เปิดและบันทึกการพรีเซนต์ชัน**

<a name="csharp-open-save-presentation"><strong>ขั้นตอน: เปิดและบันทึกการพรีเซนต์ชันใน C#</strong></a>

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) คลาสด้วยรูปแบบใดก็ได้ เช่น PPT, PPTX, ODP ฯลฯ
2. บันทึก _Presentation_ เป็นรูปแบบใดก็ได้ที่รองรับโดย [SaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/)

```c#
// โหลดไฟล์ที่รองรับทุกประเภทใน Presentation เช่น ppt, pptx, odp เป็นต้น
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกการพรีเซนต์ชันใหม่เป็นรูปแบบใดได้บ้าง?**

คุณสามารถบันทึกเป็น [PPTX, PPT, and ODP](/slides/th/net/save-presentation/) และส่งออกเป็น [PDF](/slides/th/net/convert-powerpoint-to-pdf/), [XPS](/slides/th/net/convert-powerpoint-to-xps/), [HTML](/slides/th/net/convert-powerpoint-to-html/), [SVG](/slides/th/net/convert-powerpoint-to-png/), และ [images](/slides/th/net/convert-powerpoint-to-png/) เป็นต้น

**ฉันสามารถเริ่มจากเทมเพลต (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?**

ใช่ โหลดเทมเพลตและบันทึกเป็นรูปแบบที่ต้องการ; รูปแบบเช่น POTX/POTM/PPTM และรูปแบบที่คล้ายกัน [ได้รับการสนับสนุน](/slides/th/net/supported-file-formats/).

**ฉันจะควบคุมขนาดสไลด์/อัตราส่วนภาพเมื่อสร้างการพรีเซนต์ชันได้อย่างไร?**

ตั้งค่า [slide size](/slides/th/net/slide-size/) (รวมถึงค่าตั้งล่วงหน้าเช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกวิธีการปรับขนาดเนื้อหา

**ขนาดและพิกัดวัดเป็นหน่วยใด?**

เป็นจุด: 1 นิ้วเท่ากับ 72 หน่วย

**ฉันจะจัดการกับการพรีเซนต์ชันขนาดใหญ่มาก (ที่มีไฟล์สื่อหลายไฟล์) เพื่อลดการใช้หน่วยความจำได้อย่างไร?**

ใช้ [BLOB management strategies](/slides/th/net/manage-blob/), จำกัดการเก็บข้อมูลในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และแนะนำให้ใช้กระบวนการทำงานแบบไฟล์เป็นหลักแทนการสตรีมทั้งหมดในหน่วยความจำ

**ฉันสามารถสร้าง/บันทึกการพรีเซนต์ชันพร้อมกันได้หรือไม่?**

คุณไม่สามารถดำเนินการกับอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เดียวจาก [multiple threads](/slides/th/net/multithreading/) ได้ ควรเรียกใช้อินสแตนซ์แยกและแยกจากกันต่อแต่ละเธรดหรือกระบวนการ

**ฉันจะลบลายน้ำทดลองและข้อจำกัดได้อย่างไร?**

[Apply a license](/slides/th/net/licensing/) หนึ่งครั้งต่อกระบวนการ ไฟล์ XML ของใบอนุญาตต้องไม่ถูกแก้ไข และการตั้งค่าใบอนุญาตควรทำให้สอดคล้องกันหากมีหลายเธรดเข้ามาเกี่ยวข้อง

**ฉันสามารถลงลายเซ็นดิจิทัลให้กับ PPTX ที่สร้างได้หรือไม่?**

ใช่ [Digital signatures](/slides/th/net/digital-signature-in-powerpoint/) (การเพิ่มและตรวจสอบ) ได้รับการสนับสนุนสำหรับการพรีเซนต์ชัน

**การใช้แมโคร (VBA) ได้รับการสนับสนุนในการพรีเซนต์ชันที่สร้างหรือไม่?**

ใช่ คุณสามารถ [create/edit VBA projects](/slides/th/net/presentation-via-vba/) และบันทึกไฟล์ที่เปิดใช้งานแมโครเช่น PPTM/PPSM