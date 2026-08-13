---
title: แปลงการนำเสนอ PowerPoint เป็น PDF พร้อมโน้ตใน C++
linktitle: PowerPoint เป็น PDF พร้อมโน้ต
type: docs
weight: 50
url: /th/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PDF
- การนำเสนอเป็น PDF
- สไลด์เป็น PDF
- PPT เป็น PDF
- PPTX เป็น PDF
- บันทึกการนำเสนอเป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- โน้ตผู้พูด
- PDF พร้อมโน้ต
- C++
- Aspose.Slides
description: "แปลงรูปแบบ PPT และ PPTX เป็น PDF พร้อมโน้ตโดยใช้ Aspose.Slides สำหรับ C++. รักษาเค้าโครงและโน้ตผู้พูดสำหรับการนำเสนอระดับมืออาชีพ."
---
## **ภาพรวม**

ในบทความนี้ คุณจะได้เรียนรู้วิธีการแปลงการนำเสนอ PowerPoint เป็นรูปแบบ PDF พร้อมโน้ตผู้พูดโดยใช้ Aspose.Slides คู่มือฉบับนี้จะอธิบายขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ดเพื่อช่วยให้คุณดำเนินการนี้ได้อย่างมีประสิทธิภาพ เมื่ออ่านจบบทความนี้ คุณจะสามารถ:

- ดำเนินการแปลงสไลด์ PowerPoint ให้เป็นเอกสาร PDF พร้อมคงรักษาโน้ตผู้พูดไว้  
- ปรับแต่งไฟล์ PDF ที่ได้เพื่อให้แน่ใจว่าโน้ตผู้พูดถูกรวมอยู่และจัดรูปแบบตามความต้องการของคุณ  

## **แปลง PowerPoint เป็น PDF พร้อมโน้ต**

`Save` method ในคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) สามารถใช้เพื่อแปลงการนำเสนอ PPT หรือ PPTX ให้เป็น PDF พร้อมโน้ตผู้พูด ด้วย Aspose.Slides คุณเพียงแค่โหลดการนำเสนอ กำหนดตัวเลือกการจัดวางโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notescommentslayoutingoptions/) เพื่อรวมโน้ตผู้พูด แล้วบันทึกไฟล์เป็น PDF ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการแปลงการนำเสนอแบบตัวอย่างเป็น PDF ในมุมมองสไลด์โน้ต

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
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // แสดงโน้ตผู้พูดด้านล่างสไลด์.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
คุณอาจต้องการลองใช้ Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/th/conversion). 
{{% /alert %}}