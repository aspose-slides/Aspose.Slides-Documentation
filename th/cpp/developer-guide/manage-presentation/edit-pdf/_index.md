---
title: แก้ไขเอกสาร PDF ใน C++
linktitle: แก้ไข PDF
type: docs
weight: 65
url: /th/cpp/edit-pdf/
keywords:
- แก้ไข PDF
- แทนที่ข้อความ PDF
- PDF ไปยัง PPTX
- PPTX ไปยัง PDF
- C++
- Aspose.Slides
description: "แก้ไขเอกสาร PDF ใน C++ โดยนำเข้าลงใน Aspose.Slides, แทนที่ข้อความ, และบันทึกการนำเสนอที่แก้ไขกลับเป็น PDF."
---
## **ภาพรวม**

Aspose.Slides for C++ ให้คุณแก้ไขเนื้อหา PDF โดยการนำเข้าหน้าต่าง ๆ เป็นสไลด์, แก้ไขการนำเสนอ, และส่งออกกลับเป็น PDF. บทความนี้แสดงการแทนที่ข้อความอย่างง่าย. การนำเสนอจะอยู่ในหน่วยความจำ, ดังนั้นการบันทึกไฟล์ PPTX ชั่วคราวเป็นทางเลือก.

## **แทนที่ข้อความใน PDF**

ใช้ [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/th/cpp/aspose.slides/slidecollection/addfrompdf/) เพื่อนำเข้าหน้าที่, [Presentation::ReplaceText](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/replacetext/) เพื่ออัปเดตข้อความ, และ [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) เพื่อส่งออกผลลัพธ์.

ตัวอย่างต่อไปนี้คาดว่า `input.pdf` มีคำว่า "Draft" เป็นข้อความที่สามารถแก้ไขได้หลังการนำเข้า. มันจะเปลี่ยนคำนั้นเป็น "Final" และเขียนไฟล์ `edited.pdf`. การล้างสไลด์แรกก่อนการนำเข้าจะป้องกันหน้าเปล่าที่เพิ่มขึ้นในผลลัพธ์. การค้นหาจะตรงกับคำทั้งหมดโดยคำนึงถึงตัวพิมพ์เล็กและใหญ่; `nullptr` หมายถึงไม่ต้องการ callback ผลลัพธ์.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

สำหรับตัวเลือกเพิ่มเติม, ดูที่ [การค้นหาและแทนที่ข้อความ](/slides/th/cpp/search-and-replace-text/) และ [แปลง PowerPoint เป็น PDF](/slides/th/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
การแทนที่ข้อความทำงานกับข้อความที่นำเข้า, ไม่ใช่ข้อความในภาพที่สแกน. การแปลงอาจส่งผลต่อการจัดวางและการจัดรูปแบบ, ดังนั้นควรตรวจสอบผลลัพธ์, โดยเฉพาะเมื่อข้อความที่แทนที่ยาวกว่าเดิม.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันจำเป็นต้องบันทึกไฟล์ PPTX ก่อนส่งออกเป็น PDF หรือไม่?**

ไม่. คุณสามารถแก้ไขและส่งออกรายการนำเสนอเดียวกันในหน่วยความจำ. บันทึกสำเนา PPTX เฉพาะเมื่อคุณต้องการแก้ไขต่อใน PowerPoint; ดูที่ [บันทึกการนำเสนอ](/slides/th/cpp/save-presentation/).

**ทำไมข้อความบางส่วนอาจไม่ได้เปลี่ยนแปลง?**

ตัวอย่างจะตรงกับคำเต็ม "Draft" ด้วยตัวอักษรตรงกัน. ข้อความที่นำเข้าเป็นภาพหรือแบ่งเป็นกรอบข้อความหลายกรอบอาจไม่ตรงกับการค้นหา. ตรวจสอบเนื้อหาที่นำเข้าและปรับการค้นหาให้เหมาะกับเอกสารของคุณ.