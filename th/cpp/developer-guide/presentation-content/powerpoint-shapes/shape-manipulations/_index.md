---
title: จัดการรูปทรงพรีเซนเทชันใน C++
linktitle: การจัดการรูปทรง
type: docs
weight: 40
url: /th/cpp/shape-manipulations/
keywords:
- รูปทรง PowerPoint
- รูปทรงพรีเซนเทชัน
- รูปทรงบนสไลด์
- ค้นหารูปทรง
- โคลนรูปทรง
- ลบรูปทรง
- ซ่อนรูปทรง
- เปลี่ยนลำดับรูปทรง
- รับ ID รูปทรง interop
- ข้อความทางเลือกของรูปทรง
- จุดปรับรูปทรง
- การปรับรูปทรงพรีเซ็ต
- เรขาคณิตรูปทรง
- รูปแบบเลย์เอาต์รูปทรง
- รูปทรงเป็น SVG
- แปลงรูปทรงเป็น SVG
- จัดแนวรูปทรง
- พลิกรูปทรง
- PowerPoint
- พรีเซนเทชัน
- C++
- Aspose.Slides
description: "เรียนรู้วิธีระบุ, ปรับ, โคลน, ลบ, ซ่อน, จัดเรียงใหม่, ส่งออก, จัดแนว, และพลิกรูปทรงพรีเซนเทชันด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides for C++ แสดงรูปทรงบนสไลด์เป็น [IShapeCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/) ที่จัดลำดับเป็นลำดับที่กำหนดไว้ คอลเลกชันเป็นทั้งที่ที่คุณค้นหาและแก้ไขรูปทรงและเป็นแหล่งของลำดับการซ้อน: ดัชนี `0` คือรูปทรงที่อยู่ด้านหลังที่สุด ในขณะที่ดัชนีสุดท้ายคือรูปทรงที่อยู่ด้านหน้าที่สุด

บทความนี้อิงตามโมเดลนั้น โดยแรกจะอธิบายวิธีระบุรูปทรงอย่างเชื่อถือได้และแก้ไขจุดปรับรูปทรงที่ตั้งไว้ จากนั้นจะแสดงวิธีโคลน, ลบ, ซ่อนและจัดเรียงรูปทรงใหม่ ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลย์เอาต์, การส่งออกเป็น SVG, การจัดตำแหน่ง, และการตั้งค่าการพลิกแต่ละรูปทรง ตัวอย่างแต่ละส่วนเป็นอิสระกัน ดังนั้นคุณสามารถใช้เพียงการดำเนินการที่เวิร์กโฟลว์ของคุณต้องการได้

## **ระบุและค้นหารูปทรง**

ดัชนีของคอลเลกชันสะดวกเมื่อต้องประมวลผลไฟล์ที่รู้ล่วงหน้า แต่ไม่ใช่ตัวระบุที่มั่นคง การเพิ่ม, ลบ หรือจัดเรียงรูปทรงใหม่อาจทำให้ดัชนีเปลี่ยน ควรเลือกตัวระบุตามวิธีการสร้างและการบำรุงรักษาพรีเซนเทชัน:

- [Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_name/) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและตรวจสอบง่ายในแผงการเลือกของ PowerPoint ชื่อสามารถแก้ไขได้และไม่ได้รับการรับประกันว่ามีเอกลักษณ์ ดังนั้นจึงควรกำหนดแนวทางการตั้งชื่อหากโค้ดพึ่งพา
- [AlternativeText](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_alternativetext/) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนใส่ไว้แล้วระบุรูปทรง มันมองเห็นได้โดยผู้ใช้ อาจแปลเป็นภาษาหรือเขียนใหม่เพื่อการเข้าถึง และไม่ได้รับการรับประกันว่ามีเอกลักษณ์ อย่าแปลงข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลโดยไม่มีการแจ้งเตือน
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_officeinteropshapeid/) เป็นตัวระบุแบบอ่านอย่างเดียวที่มีเอกลักษณ์ภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint interop ใช้ ใช้เมื่อทำการบูรณาการกับ PowerPoint หรือเมื่อคุณต้องการอ้างอิงที่ไม่คลุมเครือในช่วงอายุของรูปทรง รูปทรงที่โคลนหรือสร้างใหม่เป็นรูปทรงที่แตกต่างและจะได้รับ ID ของตนเอง

คุณสมบัติที่เกี่ยวข้อง [UniqueId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_uniqueid/) มีขอบเขตระดับพรีเซนเทชัน แต่ตั้งใจให้ใช้กับแอดอินและอาจถูกกำหนดใหม่ ไม่ควรถือว่าเป็นคีย์ภายนอกถาวร หากต้องการอัตลักษณ์ระยะยาว ให้เก็บการแมพในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปทรงที่คาดหวังยังคงมีอยู่

สำหรับตัวอย่างการอ่านและอัปเดตทั้งหัวเรื่องและคำอธิบายข้อความทางเลือก โปรดดู [Manage Alternative Text Titles and Descriptions](/slides/th/cpp/presentation-accessibility/) ใช้ข้อความทางเลือกเพื่ออธิบายความหมายของภาพให้ผู้อ่าน และแยกออกจากชื่อรูปทรงที่โค้ดใช้ค้นหา

ตัวอย่างต่อไปนี้ค้นหาโดย `Name` และรายงาน Interop ID ในระดับสไลด์ เมื่อเทมเพลตไม่มีรูปทรงที่คาดหวัง โค้ดจะแจ้งผลลัพธ์นั้นแทนที่จะดำเนินต่อด้วยอ็อบเจ็กต์ที่ผิดพลาด

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

เมื่อการดำเนินการเฉพาะกับประเภทรูปทรง ให้ตรวจสอบอินเทอร์เฟซก่อนใช้สมาชิกเฉพาะประเภท ตัวอย่างนี้อัปเดตข้อความและข้อความทางเลือกเฉพาะเมื่ออ็อบเจ็กต์ที่กำหนดชื่อเป็น [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **ระบุและแก้ไขการปรับรูปทรงที่ตั้งไว้**

รูปทรงเรขาคณิตที่ตั้งค่าไว้สามารถเปิดเผยจุดปรับที่ควบคุมคุณลักษณะต่าง ๆ เช่น ขนาดมุม, สัดส่วนลูกศร, หรือมุมโค้ง เข้าถึงได้ผ่านคอลเลกชันแบบอ่านอย่างเดียว [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/th/cpp/aspose.slides/igeometryshape/get_adjustments/) คอลเลกชันเองถูกจัดหาจากรูปทรง แต่ละ [IAdjustValue](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/) มีค่าที่สามารถเปลี่ยนได้

อย่าพึ่งพาดัชนีคอลเลกชันคงที่เท่านั้น ให้วนลูปผ่านการปรับและตรวจสอบคุณสมบัติแบบอ่านอย่างเดียว [IAdjustValue::get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/get_type/) ซึ่งค่าของ [ShapeAdjustmentType](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapeadjustmenttype/) บรรยายว่าการปรับควบคุมอะไรคุณสมบัติแบบอ่านอย่างเดียว [IAdjustValue::get_Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/get_name/) ให้ข้อมูลการระบุตัวเพิ่มเติมและมีประโยชน์โดยเฉพาะเมื่อพรีเซ็ตมีการปรับมากกว่าหนึ่งรายการที่มีประเภทเชิงความหมายเดียวกัน

ใช้คุณสมบัติค่าเดียวกับความหมายของการปรับ:

| ประเภทการปรับ | วัตถุประสงค์ | ค่าเพื่อเปลี่ยน |
|---|---|---|
| `CornerSize` | ขนาดของมุมโค้ง | [RawValue](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | ความหนาของหางลูกศร | `RawValue` |
| `ArrowheadLength` | ความยาวของหัวลูกศร | `RawValue` |
| `ArrowheadWidth` | ความกว้างของหัวลูกศร | `RawValue` |
| `StartAngle` | มุมเริ่มต้นของพายหรือส่วนโค้ง | [AngleValue](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | มุมสิ้นสุดของพายหรือส่วนโค้ง | `AngleValue` |

`Type` และ `Name` ไม่สามารถกำหนดค่าได้ `RawValue` เป็นจำนวนเต็มแบบอ่าน/เขียนในหน่วยเรขาคณิตของพรีเซ็ต ส่วน `AngleValue` เป็นมุมแบบอ่าน/เขียนเป็นองศา จำนวน, ลำดับ, ความหมายและช่วงค่าที่ถูกต้องของการปรับขึ้นอยู่กับพรีเซ็ต [ShapeType](https://reference.aspose.com/slides/th/cpp/aspose.slides/igeometryshape/get_shapetype/) ค่าที่ถูกต้องสำหรับพรีเซ็ตหนึ่งอาจไม่ถูกหรือให้ผลลัพธ์ต่างกันกับพรีเซ็ตอื่น

เมื่อ `Type` เป็น `ShapeAdjustmentType::Custom` API จะไม่รู้ความหมายเชิงมาตรฐาน ตรวจสอบ `Name`, ประเภทพรีเซ็ต, และค่าที่มีอยู่แล้วและอย่าปรับการปรับนั้นหากไม่ได้รู้ความหมายและช่วงค่าที่คาดหวัง แม้สำหรับประเภทที่รับรู้แล้ว ให้ตรวจสอบว่าชนิดเดียวปรากฏหลายครั้งหรือไม่ก่อนเลือกค่า บทความ [Connector](/slides/th/cpp/connector/) แสดงสถานการณ์นี้กับการปรับโค้งของคอนเนคเตอร์

ตัวอย่างสมบูรณ์ต่อไปนี้สร้างเวอร์ชันเริ่มต้นและเวอร์ชันที่แก้ไขของรูปทรงพรีเซ็ตสามแบบ ทำการวนลูปผ่านทุกการปรับ รายงาน `Name` และ `Type` ของแต่ละรายการ เปลี่ยนค่าที่เกี่ยวกับขนาดผ่าน `RawValue` เปลี่ยนมุมผ่าน `AngleValue` แล้วบันทึกผลลัพธ์ คอลัมน์ซ้ายคงเรขาคณิตเริ่มต้น; คอลัมน์ขวาแสดงสี่เหลี่ยมมุมโค้งที่ปรับ, ลูกศรสี่ทาง, และพายที่ปรับ

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// เพิ่มหัวข้อสำหรับคอลัมน์รูปทรงเริ่มต้นและรูปทรงที่ปรับแล้ว.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การตรวจสอบประเภทเชิงความหมายก่อนเปลี่ยนค่าทำให้โค้ดชัดเจนเกี่ยวกับเจตนาและหลีกเลี่ยงการสันนิษฐานว่าดัชนีคอลเลกชันเดียวมีความหมายเดียวกันในรูปทรงพรีเซ็ตที่ต่างกัน

## **แก้ไขคอลเลกชันรูปทรง**

เมธอดเพิ่ม, โคลน, ลบ, และจัดเรียงทำงานบนคอลเลกชันโดยทันที หากการดำเนินการทำให้จำนวนหรือลำดับของรูปทรงเปลี่ยน อย่าพึ่งพาดัชนีที่จับไว้ก่อนหน้านั้นต่อไป

### **โคลนรูปทรง**

[AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addclone/) สร้างสำเนาอิสระและผนวกลงในคอลเลกชันเป้าหมาย [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/insertclone/) ก็สร้างสำเนาเช่นกันแต่วางไว้ที่ดัชนี z‑order ที่ระบุ การโอเวอร์โหลดที่รับพิกัดย้ายโคลนโดยไม่เปลี่ยนขนาด; การโอเวอร์โหลดที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย

ตัวอย่างนี้สร้างสไลด์ปลายทาง, โคลนสี่เหลี่ยมที่มีป้ายชื่อไปยังด้านหน้า, และแทรกโคลนที่สองไปยังด้านหลัง การเปลี่ยนแปลงใด ๆ กับโคลนใดโคลนหนึ่งจะไม่กระทบรูปทรงต้นทาง

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การโคลนคัดลอกเนื้อหาและการจัดรูปแบบของรูปทรง รวมถึงชื่อและข้อความทางเลือก กำหนดตัวระบุตรรกะใหม่ให้กับโคลนเมื่อค่าดังกล่าวต้องเป็นเอกลักษณ์ ทรัพยากรที่ใช้โดยรูปทรงซับซ้อนจะจัดการโดยพรีเซนเทชัน แต่โคลนยังคงเป็นรายการคอลเลกชันใหม่ที่มีอัตลักษณ์รูปทรงใหม่

### **ลบรูปทรง**

[Remove](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/remove/) ลบอ็อบเจ็กต์รูปทรงเฉพาะออกจากคอลเลกชันของมัน เมื่อทำการลบหลายรายการขณะวนลูปตามดัชนี ให้เดินจากท้ายรายการเพื่อให้ดัชนีที่เหลือยังคงถูกต้อง

ตัวอย่างนี้ลบทุกรูปทรงที่มีชื่อที่กำหนดไว้ มันอ่านรูปทรงที่จัดทำดัชนีในปัจจุบัน ไม่ใช่รายการคอลเลกชันคงที่ และไม่ได้ทำการคาสต์รูปทรงโดยไม่จำเป็น

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

หลังการลบ จำนวนรูปทรงและดัชนีของรูปทรงต่อมาจะเปลี่ยน การอ้างอิงรูปทรงที่ไม่ได้รับผลกระทบจึงคงเชื่อถือได้กว่าการบันทึกดัชนี ควรพิจารณาคอนเนคเตอร์, แอนิเมชัน, และคุณลักษณะพรีเซนเทชันอื่น ๆ ที่อาจอ้างอิงถึงอ็อบเจ็กต์ที่ลบ; การลบรูปทรงที่มองเห็นได้อาจเปลี่ยนมากกว่าลักษณะของสไลด์

### **ซ่อนรูปทรง**

การตั้งค่า [Hidden](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/set_hidden/) เป็น `true` ทำให้รูปทรงคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในการแสดงสไลด์ปกติ ดัชนี, การจัดรูปแบบ, และเนื้อหายังคงพร้อมให้โค้ดใช้ ดังนั้นการซ่อนจึงเหมาะสำหรับองค์ประกอบทางเลือกที่อาจคืนค่าได้ในภายหลัง

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การซ่อนไม่ได้หมายถึงการลบหรือความปลอดภัย อ็อบเจ็กต์ยังคงสามารถค้นหาและยกเลิกการซ่อนได้โดยผู้ใช้หรือโดยโค้ด และยังคงเป็นส่วนหนึ่งของไฟล์พรีเซนเทชัน

### **เปลี่ยนลำดับ Z‑Order**

รูปทรงที่ทับซ้อนกันจะวาดตามลำดับคอลเลกชัน [Reorder](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/reorder/) ย้ายรูปทรงที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ต้องโคลน ดัชนี `0` คือด้านหลัง; `Count - 1` คือด้านหน้า

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

สี่เหลี่ยมถูกสร้างก่อนและเริ่มต้นอยู่หลังวงรี การย้ายไปยังดัชนีสุดท้ายทำให้มันอยู่หน้ากว่า ควรสรุปลำดับ z‑order หลังจากเพิ่มหรือโคลนรูปทรงที่เกี่ยวข้องทั้งหมด เพราะการดำเนินการเหล่านั้นจะผนวกหรือแทรกรายการคอลเลกชันใหม่และอาจเปลี่ยนสแต็กที่ตั้งใจไว้

## **ตรวจสอบรูปทรงบนสไลด์เลย์เอาต์**

สไลด์ทั่วไป, สไลด์เลย์เอาต์, และสไลด์มาสเตอร์มีคอลเลกชันรูปทรงแยกกัน รูปทรงในคอลเลกชันเลย์เอาต์ไม่ใช่อ็อบเจ็กต์เดียวกับรูปทรงที่อยู่ในตำแหน่งเดียวกันบนสไลด์ทั่วไป ตรวจสอบรูปทรงเลย์เอาต์เมื่อคุณต้องการทำความเข้าใจหรือเปลี่ยนการจัดรูปแบบที่เลย์เอาต์จัดหาให้

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_fillformat/) และ [LineFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_lineformat/) ของแต่ละรูปทรงเลย์เอาต์โดยไม่สมมติว่าทุกรูปทรงเป็น `AutoShape`

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

การแก้ไขเลย์เอาต์อาจส่งผลต่อหลายสไลด์ที่ใช้เลย์เอาต์นั้น ก่อนเปลี่ยนรูปทรงเลย์เอาต์ ให้กำหนดว่ามีสไลด์ปกติเพิ่มเติมออบเจ็กต์นั้นหรือมีการทับซ้อนแบบท้องถิ่นหรือไม่ และทดสอบทุกสไลด์ที่ใช้เลย์เอาต์นั้น

## **ส่งออกรูปทรงเป็น SVG**

[WriteAsSvg](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/writeassvg/) เขียนเนื้อหาที่เรนเดอร์ของรูปทรงหนึ่งเป็นสตรีม ผลลัพธ์จะมีเฉพาะรูปทรง ไม่รวมพื้นหลังของสไลด์ทั้งหมดหรือรูปทรงที่อยู่ใกล้เคียง

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

ให้เปิดพรีเซนเทชันขณะทำการเรนเดอร์ ผลลัพธ์ขึ้นอยู่กับการจัดรูปแบบของรูปทรงและทรัพยากรเช่นแบบอักษรและรูปภาพ หากต้องการส่วนประกอบทั้งหมด ให้ส่งออกรูปสไลด์แทนการส่งออกรูปทรงเดี่ยว ผู้เรียกต้องเป็นเจ้าของสตรีมและต้องปิดหรือทำลายสตรีมเอง

## **จัดแนวรูปทรง**

เมธอด [SlideUtil::AlignShapes](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/alignshapes/) มีการโอเวอร์โหลดที่จัดแนวทั้งชุดรูปทรงหรือดัชนีคอลเลกชันที่เลือก [ShapesAlignmentType](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapesalignmenttype/) ระบุขอบ, เส้นศูนย์กลาง, หรือโหมดการแจกจ่าย ตั้งค่า `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งเป็น `false` เพื่อจัดแนวรูปทรงที่เลือกสัมพันธ์กัน

ตัวอย่างนี้จัดแนวสามรูปทรงไปยังขอบบนของสไลด์ การอ้างอิงรูปทรงที่คืนค่าจะถูกแปลงเป็นดัชนีปัจจุบันทันทีก่อนการจัดแนว

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การจัดแนวเปลี่ยนตำแหน่ง ไม่เปลี่ยน z‑order การจัดแนวสัมพันธ์โดยทั่วไปต้องมีอย่างน้อยสองรูปทรง ส่วนการแจกจ่ายแนวนอนหรือแนวตั้งต้องมีจำนวนรูปทรงพอที่จะกำหนดระยะห่าง หากแก้ไขคอลเลกชันก่อนเรียกเมธอด ให้คำนวณดัชนีใหม่

## **พลิกรูปทรง**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การตั้งค่าการพลิกแนวนอนและแนวตั้ง, และการหมุน ค่า `FlipH` และ `FlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/cpp/aspose.slides/nullablebool/): `True` เปิดการพลิก, `False` ปิดการพลิก, และ `NotDefined` รักษาสถานะที่ไม่ได้กำหนด/ค่าเริ่มต้น

พรีเซนเทชันอินพุตด้านล่างมีรูปทรงที่ยังไม่ได้พลิก

![The shape before flipping](shape_to_be_flipped.png)

ตัวอย่างนี้เก็บค่ากรอบอื่น ๆ ทั้งหมดไว้และแทนที่แค่การตั้งค่าการพลิกสองค่าเท่านั้น สิ่งนี้สำคัญเพราะการกำหนด [Frame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/set_frame/) ใหม่จะแทนที่กรอบทั้งหมด

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

รูปทรงที่บันทึกจะถูกสะท้อนทั้งแนวนอนและแนวตั้งขณะคงตำแหน่ง, ขนาด, และการหมุนเดิม

![The shape after flipping](flipped_shape.png)

## **คำถามที่พบบ่อย**

**ควรใช้ดัชนีคอลเลกชันเป็นตัวระบุรูปทรงหรือไม่?**

ใช้ได้เฉพาะการประมวลผลระยะสั้นที่คอลเลกชันจะไม่เปลี่ยนแปลงก่อนใช้ดัชนี แนะนำให้ใช้ `Name` หรือ `AlternativeText` ที่ตรวจสอบแล้วสำหรับเทมเพลตที่สร้างโดยผู้เขียน, หรือ `OfficeInteropShapeId` สำหรับงานที่ต้องอ้างอิงระดับสไลด์

**การซ่อนรูปทรงทำให้มันหายไปจาก z‑order หรือไม่?**

ไม่ รูปทรงที่ซ่อนคงอยู่ในคอลเลกชันที่ดัชนีเดียวกัน สามารถค้นหา, จัดเรียงใหม่, แก้ไข, หรือทำให้มองเห็นได้อีกครั้ง

**ทำไมรูปทรงที่โคลนจึงปรากฏอยู่หน้ารูปทรงอื่น?**

`AddClone` ผนวกโคลนไปยังตำแหน่งสุดท้ายของคอลเลกชัน ซึ่งคือด้านหน้าของ z‑order ใช้ `InsertClone` เพื่อเลือกดัชนีเริ่มต้นหรือใช้ `Reorder` หลังจากเพิ่มรูปทรงทั้งหมดแล้ว

**สามารถใช้ดัชนีคงที่เพื่อระบุการปรับรูปทรงพรีเซ็ตได้หรือไม่?**

ได้เฉพาะหลังจากตรวจสอบพรีเซ็ตและโครงสร้างคอลเลกชันอย่างชัดเจน แนะนำให้วนลูปผ่าน `IGeometryShape::get_Adjustments` และตรวจสอบ `IAdjustValue::get_Type`; หากประเภทเชิงความหมายเดียวปรากฏหลายครั้ง ให้ใช้ `IAdjustValue::get_Name` เป็นข้อมูลเพิ่มเติม**