---
title: สร้างงานนำเสนอใน .NET
linktitle: สร้างงานนำเสนอ
type: docs
weight: 10
url: /th/net/create-presentation/
keywords:
- สร้างงานนำเสนอ
- งานนำเสนอใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างงานนำเสนอใน .NET ด้วย Aspose.Slides—สร้างไฟล์ PPT, PPTX และ ODP, ใช้ประโยชน์จากการสนับสนุน OpenDocument, และบันทึกแบบโปรแกรมเพื่อผลลัพธ์ที่เชื่อถือได้"
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างงานนำเสนอใน Aspose.Slides, เพิ่มกล่องข้อความในสไลด์แรก, และบันทึกผลเป็นไฟล์ นอกจากนี้ยังอธิบายวิธีสร้างและบันทึกงานนำเสนอเปล่า, รวมถึงวิธีเปิดงานนำเสนอที่มีอยู่ในรูปแบบที่สนับสนุนและบันทึกในรูปแบบอื่น ๆ ส่วนคำถามที่พบบ่อยสั้น ๆ ณ ส่วนท้ายจะครอบคลุมคำถามทั่วไปเกี่ยวกับรูปแบบ, แม่แบบ, ขนาดสไลด์, หน่วยวัด, การใช้หน่วยความจำ, การทำงานหลายเธรด, การให้สิทธิ์, ลายเซ็นดิจิทัล, และการสนับสนุน VBA

ก่อนเริ่ม, เพิ่ม Aspose.Slides ไปยังโปรเจกต์ของคุณจาก NuGet ดูที่ [การติดตั้ง](/slides/th/net/installation/) เพื่อดูแพ็กเกจที่ใช้บน Windows, Linux, และ macOS

## **สร้างงานนำเสนอ PowerPoint**

เพื่อสร้างงานนำเสนอและใส่กล่องข้อความบนสไลด์แรก, ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) คลาสใหม่จะมีสไลด์ว่างหนึ่งสไลด์อยู่แล้ว
1. รับสไลด์นั้นจากคอลเลกชัน [Slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slides/th/) โดยใช้ดัชนี 0
1. เพิ่มสี่เหลี่ยมโดยใช้เมธอด [AddAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addautoshape/) และตั้งค่า [text](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/text/)
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX ด้วยเมธอด [Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

มุมบนซ้ายของสี่เหลี่ยมอยู่ห่างจากขอบซ้าย 50 จุดและห่างจากขอบบน 50 จุด, และสี่เหลี่ยมกว้าง 400 จุด สูง 100 จุด ไฟล์ที่บันทึกจะมีหนึ่งสไลด์ที่มีสี่เหลี่ยมและข้อความนั้น หากไม่มีใบอนญาต, Aspose.Slides จะเพิ่มลายน้ำแบบประเมินผลในทุกสไลด์ที่บันทึก; ดูที่ [Licensing](/slides/th/net/licensing/)

## **สร้างและบันทึกงานนำเสนอ**

<a name="csharp-create-save-presentation"></a>

เพื่อสร้างงานนำเสนอเปล่าและบันทึก, สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) แล้วบันทึกในรูปแบบใดก็ได้จากการนับค่าใน enumeration [SaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/) ผลลัพธ์คืองานนำเสนอที่มีสไลด์เปล่าเดียว

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **เปิดและบันทึกงานนำเสนอ**

<a name="csharp-open-save-presentation"></a>

เพื่อแปลงงานนำเสนอจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง, เปิดไฟล์โดยส่งพาธให้กับคอนสตรักเตอร์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/presentation/) แล้วบันทึกในรูปแบบเป้าหมาย Aspose.Slides ตรวจจับรูปแบบอินพุต เช่น PPT, PPTX, หรือ ODP จากไฟล์โดยตรง

ตัวอย่างด้านล่างคาดว่าไฟล์งานนำเสนอ OpenDocument ชื่อ *Sample.odp* จะอยู่ในไดเรกทอรีทำงานและบันทึกเป็น PPTX

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### รูปแบบใดบ้างที่ฉันสามารถบันทึกงานนำเสนอใหม่เป็นได้?

คุณสามารถบันทึกเป็น [PPTX, PPT, และ ODP](/slides/th/net/save-presentation/) และส่งออกเป็น [PDF](/slides/th/net/convert-powerpoint-to-pdf/), [XPS](/slides/th/net/convert-powerpoint-to-xps/), [HTML](/slides/th/net/convert-powerpoint-to-html/), [SVG](/slides/th/net/render-a-slide-as-an-svg-image/), และ [images](/slides/th/net/convert-powerpoint-to-png/) เป็นต้น

### ฉันสามารถเริ่มจากเทมเพลต (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?

ได้ โหลดเทมเพลตแล้วบันทึกเป็นรูปแบบที่ต้องการ; รูปแบบ POTX/POTM/PPTM และรูปแบบที่คล้ายกัน [ได้รับการสนับสนุน](/slides/th/net/supported-file-formats/)

### ฉันจะควบคุมขนาดสไลด์/อัตราส่วนภาพอย่างไรเมื่อต้องสร้างงานนำเสนอ?

ตั้งค่า [slide size](/slides/th/net/slide-size/) (รวมถึงพรีเซ็ตเช่น 4:3 และ 16:9 หรือขนาดตามต้องการ) แล้วเลือกวิธีการสเกลเนื้อหา

### หน่วยวัดขนาดและพิกัดใช้หน่วยอะไร?

เป็นจุด: 1 นิ้วเท่ากับ 72 หน่วย

### ฉันจะจัดการงานนำเสนอขนาดใหญ่มาก (มีไฟล์สื่อจำนวนมาก) เพื่อลดการใช้หน่วยความจำอย่างไร?

ใช้ [BLOB management strategies](/slides/th/net/manage-blob/), จำกัดการจัดเก็บในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และแนะนำเวิร์กโฟลว์แบบไฟล์แทนการสตรีมในหน่วยความจำเต็มรูปแบบ

### ฉันสามารถสร้าง/บันทึกงานนำเสนอได้แบบขนานหรือไม่?

คุณไม่สามารถดำเนินการกับอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เดียวจากหลาย [threads](/slides/th/net/multithreading/) ได้ ทำการแยกอินสแตนซ์แยกกันสำหรับแต่ละเธรดหรือแต่ละกระบวนการ

### ฉันจะลบลายน้ำทดลองและข้อจำกัดต่าง ๆ ได้อย่างไร?

[Apply a license](/slides/th/net/licensing/) หนึ่งครั้งต่อกระบวนการ XML ของใบอนญาตต้องไม่ถูกแก้ไขและการตั้งค่าใบอนญาตควรทำให้สอดคล้องกันหากมีหลายเธรดทำงานพร้อมกัน

### ฉันสามารถลงลายเซ็นดิจิทัลให้กับ PPTX ที่สร้างได้หรือไม่?

ได้ รองรับ [Digital signatures](/slides/th/net/digital-signature-in-powerpoint/) (การเพิ่มและการตรวจสอบ) สำหรับงานนำเสนอ

### ไมโคร (VBA) ถูกสนับสนุนในงานนำเสนอที่สร้างหรือไม่?

ได้ คุณสามารถ [create/edit VBA projects](/slides/th/net/presentation-via-vba/) และบันทึกไฟล์ที่เปิดใช้งานแมโครเช่น PPTM/PPSM