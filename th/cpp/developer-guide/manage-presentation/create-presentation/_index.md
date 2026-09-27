---
title: สร้างการนำเสนอใน C++
linktitle: สร้างการนำเสนอ
type: docs
weight: 10
url: /th/cpp/create-presentation/
keywords:
- สร้างการนำเสนอ
- การนำเสนอใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "สร้างการนำเสนอใน C++ ด้วย Aspose.Slides—สร้างไฟล์ PPT, PPTX, และ ODP, รับประโยชน์จากการสนับสนุน OpenDocument, และบันทึกอย่างโปรแกรมเมติกเพื่อผลลัพธ์ที่เชื่อถือได้."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างพรีเซนเทชันใน Aspose.Slides, เพิ่มกล่องข้อความในสไลด์แรก, และบันทึกผลลัพธ์เป็นไฟล์. ส่วนFAQสั้น ๆ ที่ส่วนท้ายครอบคลุมคำถามทั่วไปเกี่ยวกับรูปแบบ, แม่แบบ, ขนาดสไลด์, หน่วยวัด, การใช้หน่วยความจำ, การทำงานหลายเธรด, การให้ลิขสิทธิ์, ลายเซ็นดิจิทัล, และการสนับสนุน VBA.

ก่อนเริ่ม, เพิ่ม Aspose.Slides ลงในโปรเจคของคุณ: จาก NuGet ในโปรเจค Visual Studio บน Windows, หรือจากแพ็กเกจ ZIP พร้อม CMake บน Linux. ดูที่ [การติดตั้ง](/slides/th/cpp/installation/).

## **สร้างพรีเซนเทชัน PowerPoint**

เพื่อสร้างพรีเซนเทชันและใส่กล่องข้อความบนสไลด์แรก, ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) . พรีเซนเทชันใหม่จะมีสไลด์เปล่าหนึ่งสไลด์อยู่แล้ว.
2. ดึงสไลด์นั้นด้วยเมธอด [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) และใช้ดัชนี 0.
3. เพิ่มรูปสี่เหลี่ยมโดยใช้เมธอด [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) และตั้งค่าข้อความด้วยเมธอด [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/).
4. บันทึกพรีเซนเทชันเป็นไฟล์ PPTX ด้วยเมธอด [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

มุมบนซ้ายของรูปสี่เหลี่ยมอยู่ห่างจากขอบซ้าย 50 พอยต์และห่างจากขอบบน 50 พอยต์, และรูปสี่เหลี่ยมมีความกว้าง 400 พอยต์และสูง 100 พอยต์. โปรแกรมบันทึก *hello.pptx* ในไดเรกทอรีทำงานของมัน, โดยมีสไลด์หนึ่งสไลด์ที่บรรจุรูปสี่เหลี่ยมและข้อความของมัน. หากไม่มีลิขสิทธิ์, Aspose.Slides จะเพิ่มลายน้ำการประเมินผลในทุกสไลด์ที่บันทึก; ดูที่ [การให้ลิขสิทธิ์](/slides/th/cpp/licensing/).

## **คำถามที่พบบ่อย**

### ฉันสามารถบันทึกพรีเซนเทชันใหม่เป็นรูปแบบใดได้บ้าง?

คุณสามารถบันทึกเป็น [PPTX, PPT, and ODP](/slides/th/cpp/save-presentation/) และส่งออกเป็น [PDF](/slides/th/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/th/cpp/convert-powerpoint-to-xps/), [HTML](/slides/th/cpp/convert-powerpoint-to-html/), [SVG](/slides/th/cpp/render-a-slide-as-an-svg-image/), และ [images](/slides/th/cpp/convert-powerpoint-to-png/), เป็นต้น.

### ฉันสามารถเริ่มจากแม่แบบ (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?

ได้. โหลดแม่แบบแล้วบันทึกเป็นรูปแบบที่ต้องการ; POTX/POTM/PPTM และรูปแบบที่คล้ายกัน [ได้รับการสนับสนุน](/slides/th/cpp/supported-file-formats/).

### ฉันจะควบคุมขนาด/อัตราส่วนของสไลด์เมื่อสร้างพรีเซนเทชันได้อย่างไร?

ตั้งค่า [ขนาดสไลด์](/slides/th/cpp/slide-size/) (รวมถึงค่า preset เช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกวิธีการปรับขนาดเนื้อหา.

### ขนาดและพิกัดวัดเป็นหน่วยอะไร?

เป็นหน่วยพอยน์ท์: 1 นิ้วเท่ากับ 72 หน่วย.

### ฉันจะจัดการพรีเซนเทชันขนาดใหญ่มาก (มีไฟล์สื่อจำนวนมาก) เพื่อลดการใช้หน่วยความจำได้อย่างไร?

ใช้ [กลยุทธ์การจัดการ BLOB](/slides/th/cpp/manage-blob/), จำกัดการจัดเก็บในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และแนะนำเวิร์กโฟลว์แบบไฟล์เป็นหลักแทนสตรีมในหน่วยความจำทั้งหมด.

### ฉันสามารถสร้าง/บันทึกพรีเซนเทชันพร้อมกันได้หรือไม่?

คุณไม่สามารถดำเนินการบนอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) เดียวจาก [หลายเธรด](/slides/th/cpp/multithreading/) ได้. ให้เรียกใช้งานอินสแตนซ์แยกที่แยกจากกันต่อแต่ละเธรดหรือกระบวนการ.

### ฉันจะลบลายน้ำการทดลองและข้อจำกัดออกได้อย่างไร?

[ใช้ลิขสิทธิ์](/slides/th/cpp/licensing/) หนึ่งครั้งต่อกระบวนการ. XML ของลิขสิทธิ์ต้องไม่ถูกแก้ไข, และการตั้งค่าลิขสิทธิ์ควรประสานกันหากมีหลายเธรดเข้ามาเกี่ยวข้อง.

### ฉันสามารถลงลายเซ็นดิจิทัลใน PPTX ที่สร้างได้หรือไม่?

ได้. [ลายเซ็นดิจิทัล](/slides/th/cpp/digital-signature-in-powerpoint/) (การเพิ่มและการตรวจสอบ) ได้รับการสนับสนุนสำหรับพรีเซนเทชัน.

### แมโคร (VBA) ได้รับการสนับสนุนในพรีเซนเทชันที่สร้างหรือไม่?

ได้. คุณสามารถ [สร้าง/แก้ไขโครงการ VBA](/slides/th/cpp/presentation-via-vba/) และบันทึกไฟล์ที่เปิดใช้งานแมโคร เช่น PPTM/PPSM.