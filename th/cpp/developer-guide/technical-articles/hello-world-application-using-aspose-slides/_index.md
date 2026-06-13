---
title: แอปพลิเคชัน Hello World โดยใช้ Aspose.Slides สำหรับ C++
type: docs
weight: 80
url: /th/cpp/hello-world-application-using-aspose-slides/
keywords:
- สวัสดีโลก
- แอปพลิเคชัน
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "สร้างแอป C++ แรกของคุณด้วย Aspose.Slides ตัวอย่าง Hello World อย่างง่ายที่ช่วยให้คุณพร้อมสำหรับการอัตโนมัติการนำเสนอ PPT, PPTX และ ODP"
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างงานนำเสนอ PowerPoint แบบ **Hello World** อย่างง่ายโดยใช้ Aspose.Slides ตัวอย่างแสดงวิธีสร้างงานนำเสนอใหม่, เข้าถึงสไลด์แรก, เพิ่ม AutoShape ประเภทสี่เหลี่ยมที่ตำแหน่งที่กำหนด, ใส่ TextFrame ที่มีข้อความ **Hello World**, และปรับรูปแบบของรูปร่างและข้อความ

นอกจากนี้ยังอธิบายวิธีทำให้ข้อความมองเห็นได้โดยเปลี่ยนสีเป็นสีดำ, ซ่อนขอบรูปร่างโดยตั้งค่าสีเส้นเป็นสีขาว, ลบการเติมสีของรูปร่าง, และบันทึกงานนำเสนอเป็นไฟล์ PPTX

## **ขั้นตอนในการสร้างแอปพลิเคชัน Hello World**

ทำตามขั้นตอนด้านล่างเพื่อสร้างแอปพลิเคชัน **Hello World** ด้วย Aspose.Slides for C++ API:

- สร้างอินสแตนซ์ของคลาส Presentation
- รับอ้างอิงของสไลด์แรกในงานนำเสนอซึ่งถูกสร้างขึ้นเมื่อทำการ instantiate ของ Presentation
- เพิ่ม AutoShape ที่ ShapeType เป็น Rectangle ที่ตำแหน่งที่กำหนดบนสไลด์
- เพิ่ม TextFrame ให้กับ AutoShape โดยมีข้อความ Hello World เป็นข้อความเริ่มต้น
- เปลี่ยนสีข้อความเป็นสีดำเนื่องจากสีเริ่มต้นเป็นสีขาวและไม่มองเห็นได้บนสไลด์ที่มีพื้นหลังสีขาว
- เปลี่ยนสีเส้นของรูปร่างเป็นสีขาวเพื่อซ่อนขอบรูปร่าง
- ลบรูปแบบการเติมสีเริ่มต้นของรูปร่าง
- สุดท้าย, บันทึกงานนำเสนอเป็นรูปแบบไฟล์ที่ต้องการโดยใช้วัตถุ Presentation

การทำงานของขั้นตอนข้างต้นแสดงในตัวอย่างด้านล่าง

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // ดึงสไลด์แรก
    auto slide = pres->get_Slides()->idx_get(0);

    // เพิ่ม AutoShape ชนิดสี่เหลี่ยม
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // เพิ่ม TextFrame ไปยังสี่เหลี่ยม
    shape->AddTextFrame(u"Hello World");

    // เปลี่ยนสีข้อความเป็นสีดำ (ที่เป็นสีขาวโดยค่าเริ่มต้น)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // เปลี่ยนสีเส้นของสี่เหลี่ยมเป็นสีขาว
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // ลบการจัดรูปแบบการเติมสีทั้งหมดในรูปร่าง
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // บันทึกงานนำเสนอลงดิสก์
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```