---
title: จัดการ SmartArt ในงานนำเสนอ PowerPoint ด้วย C++
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/cpp/manage-smartart/
keywords:
- SmartArt
- ข้อความ SmartArt
- ประเภทเค้าโครง
- คุณสมบัติซ่อน
- แผนภูมิโครงสร้างองค์กร
- แผนภูมิโครงสร้างองค์กรแบบรูปภาพ
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้การสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides สำหรับ C++ โดยใช้ตัวอย่างโค้ดที่ชัดเจนซึ่งช่วยเร่งการออกแบบสไลด์และการทำงานอัตโนมัติ"
---
## **ภาพรวม**

SmartArt คือแผนภาพ PowerPoint ที่สร้างจากโหนด, รูปร่างโหนด, และเค้าโครง. ด้วย Aspose.Slides for C++ คุณสามารถสร้าง SmartArt, อ่านข้อความจากโหนดของมัน, เปลี่ยนเค้าโครง, ตรวจสอบโหนดที่ซ่อนอยู่, ตั้งค่าเค้าโครงแผนภูมิโครงสร้างองค์กร, และสร้างแผนภูมิโครงสร้างองค์กรแบบรูปภาพ.

## **รับข้อความจากอ็อบเจ็กต์ SmartArt**

โหนด SmartArt สามารถมีรูปร่างได้หนึ่งหรือหลายรูปแบบ. เพื่ออ่านข้อความจากรูปร่างของโหนด ให้วนลูปผ่าน [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/), จากนั้นอ่าน [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) ที่ส่งกลับโดย [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/).

ตัวอย่างนี้ต้องการงานนำเสนอที่มีอย่างน้อยหนึ่งสไลด์และอ็อบเจ็กต์ SmartArt เป็นรูปร่างแรกบนสไลด์นั้น. มันพิมพ์แต่ละกรอบข้อความที่มีอยู่ไปยังคอนโซล.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **เปลี่ยนประเภทเค้าโครงของอ็อบเจ็กต์ SmartArt**

เค้าโครง SmartArt กำหนดวิธีจัดเรียงและเชื่อมต่อโหนดต่างๆ. ตัวอย่างต่อไปนี้สร้างอ็อบเจ็กต์ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, แล้วเปลี่ยนเป็นค่า `BasicProcess` และบันทึกงานนำเสนอ. ตำแหน่งและขนาดที่ส่งให้ [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) มีหน่วยเป็นพอยต์. ใช้ [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) เพื่อเปลี่ยนเค้าโครง.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตรวจสอบว่าโหนด SmartArt ถูกซ่อนหรือไม่**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) บ่งบอกว่าโหนดนั้นถูกซ่อนอยู่ในโมเดลข้อมูล SmartArt หรือไม่. โหนดที่ซ่อนอยู่สามารถมีอยู่ในโครงสร้างแม้ว่าเค้าโครงที่เลือกจะไม่แสดงเป็นองค์ประกอบแผนภาพที่มองเห็นได้.

ตัวอย่างต่อไปนี้เพิ่มโหนดเข้าไปในอ็อบเจ็กต์ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` และตรวจสอบสถานะการซ่อนของโหนดที่เพิ่มเข้าไป. มันพิมพ์ข้อความหากโหนดถูกซ่อนและบันทึกแผนภาพ.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **รับหรือกำหนดเค้าโครงแผนภูมิโครงสร้างองค์กร**

สำหรับแผนภาพ SmartArt ที่ใช้เค้าโครงแผนภูมิโครงสร้างองค์กร, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) และ [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) กำหนดวิธีจัดเรียงโหนดลูกใต้โหนดพ่อแม่. ตัวอย่างเช่น คุณสามารถตั้งค่าให้โหนดลูกห้อยจากด้านซ้าย, ขวา หรือทั้งสองด้าน, ขึ้นอยู่กับค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) ที่เลือก.

ตัวอย่างต่อไปนี้สร้างแผนภูมิโครงสร้างองค์กรและตั้งค่าเค้าโครงสำหรับโหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`. ดัชนีเริ่มต้นจากศูนย์ `0` เลือกโหนดระดับบนสุดแรก; โหนดลูกของมันจะใช้การจัดเรียงที่เลือก. งานนำเสนอที่แก้ไขแล้วจึงถูกบันทึก.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **สร้างแผนภูมิโครงสร้างองค์กรแบบรูปภาพ**

แผนภูมิโครงสร้างองค์กรแบบรูปภาพคือเค้าโครง SmartArt ที่ออกแบบมาสำหรับแผนภาพลำดับชั้นที่มีที่วางภาพ. ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` เมื่อเพิ่มอ็อบเจ็กต์ SmartArt ลงในสไลด์. ตัวอย่างนี้บันทึกแผนภาพที่มีที่วางภาพ; ไม่ได้เติมที่วางภาพด้วยรูปภาพ.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **แปลงแผนภาพ Legacy เป็นกลุ่มของรูปร่าง**

เมื่อต้องปรับปรุงงานนำเสนอที่มีอยู่ คุณอาจต้องอัปเดตแผนภูมิโครงสร้างองค์กรที่สร้างขึ้นใน PowerPoint 97–2003. Aspose.Slides แสดงแผนภาพ Legacy เหล่านี้เป็นอ็อบเจ็กต์ [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/). ใช้ [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) เพื่อแปลงแผนภาพเป็นกลุ่มของรูปร่างเพื่อให้คุณสามารถแก้ไของค์ประกอบภาพแต่ละส่วนได้. ดู [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/) สำหรับรายละเอียด.

การแปลงจะเพิ่มกลุ่มใหม่ลงในคอลเลกชันของรูปร่างโดยไม่ลบแผนภาพต้นฉบับ. หลังจากการแปลงสำเร็จ ให้ลบต้นฉบับด้วย [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) เพื่อหลีกเลี่ยงเนื้อหาซ้ำซ้อน. รวบรวมแผนภาพ legacy ลงในเวกเตอร์ก่อนทำการแปลงเพื่อให้การเพิ่มและลบรูปร่างไม่ทำให้การวนลูปถูกขัดจังหวะ.

ตัวอย่างต่อไปนี้เปิดงานนำเสนอ, ค้นหาทุกสไลด์, แปลงแผนภาพเป็นกลุ่มของรูปร่าง, และบันทึกงานนำเสนอที่อัปเดตเป็น PPTX.

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

งานนำเสนอที่บันทึกไว้จะมีกลุ่มของรูปร่างที่แก้ไขได้แทนแผนภาพ legacy ที่แปลงแล้ว, โดยไม่มีแผนภาพต้นฉบับเหลืออยู่เคียงข้าง. เปิดไฟล์ PPTX ใน PowerPoint เพื่อแก้ไของค์ประกอบแต่ละรายการภายในแต่ละกลุ่ม, เช่น ข้อความ, การเติมสี หรือ ตำแหน่ง.

## **คำถามที่พบบ่อย**

**SmartArt รองรับการสะท้อนหรือการกลับด้านสำหรับภาษาตำแหน่งจากขวาไปซ้าย (RTL) หรือไม่?**

มี. เมธอด [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) จะสลับทิศทางของแผนภาพจากซ้ายไปขวาเป็นขวาไปซ้าย หรือกลับกัน, เมื่อเค้าโครง SmartArt ที่เลือกรองรับการกลับด้าน.

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังงานนำเสนออื่นโดยคงรูปแบบไว้ได้อย่างไร?**

คุณสามารถ [คัดลอกรูปร่าง SmartArt](/slides/th/cpp/shape-manipulations/) ด้วย [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) หรือ [คัดลอกสไลด์ทั้งหมด](/slides/th/cpp/clone-slides/) ที่มี SmartArt. ทั้งสองวิธีจะคงขนาด, ตำแหน่ง, และรูปแบบไว้.

**ฉันจะเรนเดอร์ SmartArt เป็นภาพราสเตอร์เพื่อการแสดงตัวอย่างหรือส่งออกเว็บได้อย่างไร?**

[เรนเดอร์สไลด์](/slides/th/cpp/convert-powerpoint-to-png/) หรือทั้งงานนำเสนอเป็น PNG หรือ JPEG. SmartArt จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์.

**ฉันจะหาวัตถุ SmartArt เฉพาะบนสไลด์ได้อย่างไรหากมีหลายอ็อบเจ็กต์?**

กำหนดค่า [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) หรือ [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) ที่เป็นเอกลักษณ์บนรูปร่าง SmartArt, ค้นหาค่าดังกล่าวใน [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/), จากนั้นตรวจสอบว่ารูปร่างที่ตรงกันเป็น [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/).