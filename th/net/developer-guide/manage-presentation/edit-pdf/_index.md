---
title: แก้ไขเอกสาร PDF ใน .NET
linktitle: แก้ไข PDF
type: docs
weight: 65
url: /th/net/edit-pdf/
keywords:
- แก้ไข PDF
- แทนที่ข้อความ PDF
- PDF เป็น PPTX
- PPTX เป็น PDF
- .NET
- C#
- Aspose.Slides
description: "แก้ไขเอกสาร PDF ใน C# โดยนำเข้าไปยัง Aspose.Slides, แทนที่ข้อความ, และบันทึกการนำเสนอที่แก้ไขกลับเป็น PDF."
---
## **ภาพรวม**

Aspose.Slides for .NET ให้คุณแก้ไขเนื้อหา PDF โดยนำเข้าหน้าต่างต่าง ๆ เป็นสไลด์ แก้ไขการนำเสนอ และส่งออกกลับเป็น PDF บทความนี้แสดงวิธีการแทนข้อความอย่างง่าย การนำเสนอจะคงอยู่ในหน่วยความจำ ดังนั้นการบันทึกไฟล์ PPTX ชั่วคราวจึงเป็นทางเลือกเสริม

## **แทนข้อความใน PDF**

ใช้ [AddFromPdf](https://reference.aspose.com/slides/th/net/aspose.slides/slidecollection/addfrompdf/) เพื่อเอาเข้าหน้าต่างต่าง ๆ, [ReplaceText](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/replacetext/) เพื่ออัปเดตข้อความ, และ [Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) เพื่อส่งออกผลลัพธ์

ตัวอย่างต่อไปนี้คาดว่าไฟล์ `input.pdf` มีคำว่า "Draft" เป็นข้อความที่สามารถแก้ไขได้หลังการนำเข้า ตัวอย่างจะเปลี่ยนคำนั้นเป็น "Final" และเขียนไฟล์ `edited.pdf` การลบสไลด์เริ่มต้นก่อนการนำเข้าเพื่อปิดไม่ให้มีหน้าว่างเพิ่มเติมในผลลัพธ์ การค้นหาตรงกับคำเต็มที่มีตัวอักษรตรงกัน; `null` หมายถึงไม่ต้องการ callback ผลลัพธ์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

สำหรับตัวเลือกเพิ่มเติม ดูที่ [ค้นหาและแทนข้อความ](/slides/th/net/search-and-replace-text/) และ [แปลง PowerPoint เป็น PDF](/slides/th/net/convert-powerpoint-to-pdf/)

{{% alert color="info" title="Note" %}}
การแทนข้อความทำงานกับข้อความที่นำเข้า ไม่ใช่ข้อความในภาพที่สแกน การแปลงอาจส่งผลต่อรูปแบบและการจัดวาง ดังนั้นควรตรวจสอบผลลัพธ์ โดยเฉพาะเมื่อข้อความที่แทนมีความยาวมากกว่าข้อความเดิม
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันจำเป็นต้องบันทึกไฟล์ PPTX ก่อนส่งออกเป็น PDF หรือไม่?**

ไม่ คุณสามารถแก้ไขและส่งออกการนำเสนอเดียวกันในหน่วยความจำได้ ให้บันทึกสำเนา PPTX เฉพาะเมื่อคุณต้องการแก้ไขต่อใน PowerPoint; ดูที่ [บันทึกการนำเสนอ](/slides/th/net/save-presentation/).

**ทำไมข้อความบางส่วนอาจไม่ถูกเปลี่ยน?**

ตัวอย่างจะตรงกับคำเต็ม "Draft" ด้วยตัวอักษรที่ตรงกันอย่างแม่นยำ ข้อความที่นำเข้าเป็นภาพหรือถูกแยกเป็นกรอบข้อความหลายกรอบอาจไม่ตรงกับการค้นหา ตรวจสอบเนื้อหาที่นำเข้าและปรับการค้นหาตามเอกสารของคุณ