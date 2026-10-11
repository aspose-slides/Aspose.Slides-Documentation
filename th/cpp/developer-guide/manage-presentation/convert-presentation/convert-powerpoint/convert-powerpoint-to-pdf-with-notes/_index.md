---
title: แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมบันทึกผู้พูดใน C++
linktitle: PowerPoint เป็น PDF พร้อมบันทึกผู้พูด
type: docs
weight: 50
url: /th/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PDF
- งานนำเสนอเป็น PDF
- สไลด์เป็น PDF
- PPT เป็น PDF
- PPTX เป็น PDF
- บันทึกงานนำเสนอเป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- บันทึกผู้พูด
- PDF พร้อมบันทึก
- C++
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมบันทึกผู้พูดโดยใช้ Aspose.Slides สำหรับ C++. รักษาการจัดวางและบันทึกผู้พูดสำหรับการนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นรูปแบบ PDF พร้อมบันทึกผู้พูดโดยใช้ Aspose.Slides คู่มือนี้จะครอบคลุมขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณทำงานนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบบทความนี้ คุณจะสามารถ:

- ดำเนินกระบวนการแปลงเพื่อแปลงสไลด์ PowerPoint เป็นเอกสาร PDF พร้อมคงบันทึกผู้พูดไว้
- ปรับแต่งไฟล์ PDF ที่ส่งออกเพื่อให้บันทึกผู้พูดรวมอยู่และจัดรูปแบบตามความต้องการของคุณ

เพื่อกำหนดขนาดและแนวหน้าของหน้าบันทึกก่อนการส่งออก ดูที่ [ขนาดหน้าบันทึก](/slides/th/cpp/notes-size/).

## **แปลง PowerPoint เป็น PDF พร้อมบันทึก**

เมธอด `Save` ในคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) สามารถใช้เพื่อแปลงงานนำเสนอ PPT หรือ PPTX เป็น PDF พร้อมบันทึกผู้พูดได้ ด้วย Aspose.Slides คุณเพียงโหลดงานนำเสนอ ตั้งค่าตัวเลือกการจัดเลย์เอาต์โดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notescommentslayoutingoptions/) เพื่อรวมบันทึกผู้พูด แล้วบันทึกไฟล์เป็น PDF ตัวอย่างโค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอ ตัวอย่างเป็น PDF ในมุมมองสไลด์บันทึก

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // เรนเดอร์บันทึกผู้พูดด้านล่างสไลด์
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
คุณอาจต้องการตรวจสอบ Aspose [ตัวแปลง PowerPoint เป็น PDF ออนไลน์](https://products.aspose.app/slides/th/conversion).
{{% /alert %}}