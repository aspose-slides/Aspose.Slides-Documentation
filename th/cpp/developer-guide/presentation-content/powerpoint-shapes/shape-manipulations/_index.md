---
title: จัดการรูปร่างการนำเสนอใน C++
linktitle: การจัดการรูปร่าง
type: docs
weight: 40
url: /th/cpp/shape-manipulations/
keywords:
- รูปร่าง PowerPoint
- รูปร่างการนำเสนอ
- รูปร่างบนสไลด์
- ค้นหารูปร่าง
- คัดลอกรูปร่าง
- ลบรูปร่าง
- ซ่อนรูปร่าง
- เปลี่ยนลำดับรูปร่าง
- รับ ID รูปร่าง Interop
- ข้อความแทนที่ของรูปร่าง
- จุดปรับค่ารูปร่าง
- การปรับค่ารูปร่างตามพรีเซ็ต
- เรขาคณิตของรูปทรง
- รูปแบบเลย์เอาต์ของรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดแนวรูปร่าง
- พลิกรูปร่าง
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีระบุ, ปรับค่า, คัดลอก, ลบ, ซ่อน, จัดลำดับใหม่, ส่งออก, จัดแนว, และพลิกรูปร่างการนำเสนอด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides for C++ แสดงรูปร่างบนสไลด์เป็น [IShapeCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/) ที่จัดลำดับไว้. คอลเลกชันเป็นทั้งสถานที่ที่คุณค้นหาและแก้ไขรูปร่างและเป็นแหล่งที่มาของลำดับการซ้อนกัน: ดัชนี `0` คือรูปร่างที่อยู่ด้านหลังสุด, ส่วนดัชนีสุดท้ายคือรูปร่างที่อยู่ด้านหน้าสุด.

บทความนี้ทำตามแบบจำลองนั้น. แรกเริ่มอธิบายวิธีระบุรูปร่างอย่างแม่นยำและแก้ไขจุดปรับค่ารูปร่างที่กำหนดไว้ล่วงหน้า, จากนั้นแสดงวิธีการคัดลอก, ลบ, ซ่อน, และจัดลำดับรูปร่างใหม่. ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลย์เอาต์, การส่งออกเป็น SVG, การจัดแนว, และการตั้งค่าการพลิก. ตัวอย่างแต่ละส่วนเป็นอิสระ, ดังนั้นคุณสามารถใช้เฉพาะการดำเนินการที่ต้องการในกระบวนการทำงานของคุณ.

## **ระบุและค้นหารูปร่าง**

ดัชนีของคอลเลกชันสะดวกเมื่อประมวลผลไฟล์ที่รู้จัก, แต่ไม่ใช่ตัวระบุที่มั่นคง. การเพิ่ม, ลบ, หรือจัดลำดับรูปร่างใหม่สามารถเปลี่ยนดัชนีของมันได้. เลือกตัวระบุให้สอดคล้องกับวิธีการสร้างและดูแลพรีเซนเทชัน:

- [Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_name/) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและง่ายต่อการตรวจสอบใน **Selection Pane** ของ PowerPoint. สามารถแก้ไขได้และไม่รับประกันว่าจะเป็นเอกลักษณ์, ดังนั้นควรกำหนดกฎการตั้งชื่อหากโค้ดต้องพึ่งพาชื่อนั้น.
- [AlternativeText](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_alternativetext/) มีประโยชน์เมื่อคำอธิบายเพื่อการเข้าถึงหรือแท็กที่ผู้เขียนกำหนดไว้แล้วระบุรูปร่าง. มันมองเห็นได้โดยผู้ใช้, อาจแปลภาษาหรือแก้ไขเพื่อการเข้าถึง, และไม่รับประกันว่าจะเป็นเอกลักษณ์. อย่าใช้ข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลโดยไม่ระบุ.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_officeinteropshapeid/) เป็นตัวระบุแบบอ่านอย่างเดียวที่เป็นเอกลักษณ์ภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint interop ใช้. ใช้เมื่อต้องทำงานร่วมกับ PowerPoint หรือเมื่อจำเป็นต้องอ้างอิงที่ชัดเจนตลอดอายุของรูปร่าง. รูปร่างที่ถูกคัดลอกหรือสร้างใหม่จะได้รับ ID ใหม่.

คุณสมบัติ [UniqueId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_uniqueid/) ที่เกี่ยวข้องมีขอบเขตระดับพรีเซนเทชัน, แต่ถูกออกแบบสำหรับแอดอินและอาจถูกกำหนดใหม่. ไม่ควรถือเป็นคีย์ภายนอกถาวร. หากต้องการอัตลักษณ์ระยะยาว, ให้เก็บการแมปในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปร่างที่คาดหวังยังคงมีอยู่หรือไม่.

ตัวอย่างต่อไปนี้ค้นหาโดย `Name` และรายงาน Interop ID ที่อยู่ระดับสไลด์. เมื่อเทมเพลตไม่มีรูปร่างที่คาดหวัง, โค้ดจะรายงานผลนั้นแทนที่จะดำเนินต่อด้วยอ็อบเจ็กต์ที่ผิดพลาด.

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

เมื่อการดำเนินการเฉพาะประเภทของรูปร่าง, ให้ตรวจสอบอินเทอร์เฟซก่อนใช้สมาชิกเฉพาะประเภท. ตัวอย่างนี้อัปเดตข้อความและข้อความแทนที่เฉพาะเมื่ออ็อบเจ็กต์ที่ระบุชื่อเป็น [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/).

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

## **ระบุและแก้ไขการปรับค่ารูปร่างที่กำหนดไว้ล่วงหน้า**

รูปร่างที่มีเรขาคณิตกำหนดล่วงหน้าสามารถเปิดเผยจุดปรับค่าเพื่อควบคุมคุณสมบัติต่าง ๆ เช่น ขนาดมุม, อัตราส่วนของลูกศร, หรือมุมของโค้ง. เข้าถึงได้ผ่านคอลเลกชันแบบอ่านอย่างเดียว [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/th/cpp/aspose.slides/igeometryshape/get_adjustments/). คอลเลกชันถูกจัดหาโดยรูปร่าง, แต่ละ [IAdjustValue](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/) มีค่า ซึ่งสามารถเปลี่ยนแปลงได้.

อย่าพึ่งพาดัชนีคอลเลกชันที่คงที่. ลูปผ่านการปรับค่าและตรวจสอบคุณสมบัติแบบอ่านอย่างเดียว [IAdjustValue::get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/get_type/) ซึ่งค่าของ [ShapeAdjustmentType](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapeadjustmenttype/) บรรยายว่าการปรับค่ามีผลควบคุมอะไร. คุณสมบัติแบบอ่านอย่างเดียว [IAdjustValue::get_Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/get_name/) ให้ข้อมูลระบุเพิ่มเติมและเป็นประโยชน์เมื่อพรีเซ็ตมีการปรับค่ามากกว่าหนึ่งค่าที่มีประเภทเชิงความหมายเดียวกัน.

ใช้คุณสมบัติค่าที่สอดคล้องกับความหมายของการปรับค่า:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | ขนาดของมุมโค้ง | [RawValue](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | ความหนาของหางลูกศร | `RawValue` |
| `ArrowheadLength` | ความยาวของหัวลูกศร | `RawValue` |
| `ArrowheadWidth` | ความกว้างของหัวลูกศร | `RawValue` |
| `StartAngle` | มุมเริ่มต้นของพายหรือโค้ง | [AngleValue](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | มุมสิ้นสุดของพายหรือโค้ง | `AngleValue` |

`Type` และ `Name` ไม่สามารถกำหนดค่าได้. `RawValue` เป็นจำนวนเต็มที่อ่าน/เขียนในหน่วยเรขาคณิตดั้งเดิมของพรีเซ็ต, ส่วน `AngleValue` เป็นมุมที่อ่าน/เขียนเป็นองศา. จำนวน, ลำดับ, ความหมาย, และช่วงค่าที่ถูกต้องของการปรับค่าขึ้นอยู่กับ [ShapeType](https://reference.aspose.com/slides/th/cpp/aspose.slides/igeometryshape/get_shapetype/) ของพรีเซ็ต. ค่าที่ใช้ได้กับพรีเซ็ตหนึ่งอาจไม่ถูกต้องหรือให้ผลต่างสำหรับพรีเซ็ตอื่น.

เมื่อ `Type` มีค่า `ShapeAdjustmentType::Custom`, API จะไม่รับรู้ความหมายเชิงมาตรฐาน. ตรวจสอบ `Name`, ประเภทพรีเซ็ต, และค่าที่มีอยู่, แล้วปล่อยให้การปรับค่าไม่เปลี่ยนแปลงหากไม่ทราบความหมายและช่วงที่คาดหวัง. แม้สำหรับประเภทที่รู้จัก, ควรตรวจสอบว่าประเภทเดียวกันปรากฏหลายครั้งหรือไม่ก่อนเลือกค่า. บทความ [Connector](/slides/th/cpp/connector/) แสดงสถานการณ์นี้ด้วยการปรับค่าพันธมิตรของคอนเนคเตอร์.

ตัวอย่างต่อไปนี้สร้างเวอร์ชันเริ่มต้นและเวอร์ชันที่แก้ไขของรูปร่างพรีเซ็ตสามแบบ. มันวนลูปผ่านการปรับค่าทั้งหมด, รายงาน `Name` และ `Type`, เปลี่ยนค่าที่เกี่ยวกับขนาดผ่าน `RawValue`, เปลี่ยนมุมผ่าน `AngleValue`, แล้วบันทึกผลลัพธ์. คอลัมน์ซ้ายเก็บเรขาคณิตเริ่มต้น; คอลัมน์ขวาแสดงสี่เหลี่ยมมุมโค้งที่ปรับค่า, ลูกศรสี่ทาง, และพาย.

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

// เพิ่มหัวคอลัมน์สำหรับคอลัมน์รูปร่างเริ่มต้นและรูปร่างที่ปรับค่า
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

การตรวจสอบประเภทเชิงความหมายก่อนเปลี่ยนค่าทำให้โค้ดชัดเจนในเจตนาและหลีกเลี่ยงการสันนิษฐานว่าดัชนีคอลเลกชันที่แน่นอนมีความหมายเดียวกันในพรีเซ็ตต่าง ๆ.

## **แก้ไขคอลเลกชันรูปร่าง**

เมธอดเพิ่ม, คัดลอก, ลบ, และจัดลำดับทำงานบนคอลเลกชันโดยทันที. หากการดำเนินการเปลี่ยนจำนวนหรือลำดับของรูปร่าง, อย่าพึ่งพาดัชนีที่จับได้ก่อนการดำเนินการนั้น.

### **คัดลอกรูปร่าง**

[AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addclone/) สร้างสำเนาอิสระและต่อท้ายไปยังคอลเลกชันเป้าหมาย. [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/insertclone/) ก็สร้างสำเนาเช่นกันแต่วางไว้ที่ดัชนี z‑order ที่ระบุ. overload ที่รับพิกัดจะย้ายคลอนโดยไม่เปลี่ยนขนาด; overload ที่รับความกว้างและความสูงสามารถปรับขนาดได้เช่นกัน.

ตัวอย่างสร้างสไลด์เป้าหมาย, คัดลอกสี่เหลี่ยมที่มีฉลากไปยังด้านหน้า, แล้วแทรกคลอนที่สองไว้ด้านหลัง. การเปลี่ยนแปลงใด ๆ กับคลอนแต่ละอันจะไม่กระทบรูปร่างต้นฉบับ.

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

การคัดลอกจะคัดสำเนาเนื้อหาและการจัดรูปแบบของรูปร่าง รวมถึงชื่อและข้อความแทนที่. หากค่าดังกล่าวต้องเป็นเอกลักษณ์ให้กำหนดตัวระบุเชิงตรรกะใหม่ให้กับคลอน. ทรัพยากรของรูปร่างซับซ้อนจะจัดการโดยพรีเซนเทชัน, แต่คลอนยังคงเป็นรายการใหม่ในคอลเลกชันพร้อมอัตลักษณ์รูปร่างใหม่.

### **ลบรูปร่าง**

[Remove](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/remove/) ลบอ็อบเจ็กต์รูปร่างที่ระบุจากคอลเลกชันของมัน. เมื่อลบหลายรายการระหว่างการวนลูปตามดัชนี, ให้วนจากท้ายไปหน้าเพื่อให้ดัชนีที่เหลือยังคงใช้ได้.

ตัวอย่างนี้ลบรูปร่างทุกรูปร่างที่มีชื่อที่กำหนดไว้. มันอ่านรูปร่างตามดัชนีปัจจุบัน, ไม่ใช้อ็อบเจ็กต์คอลเลกชันที่คงที่, และไม่ทำการคาสท์รูปร่างโดยไม่จำเป็น.

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

หลังการลบ, จำนวนรูปร่างและดัชนีของรูปร่างต่อมาจะเปลี่ยน. การอ้างอิงรูปร่างที่ไม่ได้รับผลกระทบจะคงความน่าเชื่อถือมากกว่าการบันทึกดัชนีไว้ล่วงหน้า. ควรพิจารณาคอนเนคเตอร์, แอนิเมชัน, และคุณลักษณะพรีเซนเทชันอื่น ๆ ที่อาจอ้างอิงอ็อบเจ็กต์ที่ลบ; การลบรูปร่างที่มองเห็นได้อาจทำให้มีการเปลี่ยนแปลงมากกว่าที่สไลด์แสดง.

### **ซ่อนรูปร่าง**

การตั้งค่า [Hidden](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/set_hidden/) เป็น `true` จะทำให้รูปร่างคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในการแสดงสไลด์ปกติ. ดัชนี, การจัดรูปแบบ, และเนื้อหายังคงสามารถเข้าถึงได้จากโค้ด, ดังนั้นการซ่อนเหมาะสำหรับส่วนประกอบที่อาจคืนค่าได้ในภายหลัง.

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

การซ่อนไม่ใช่การลบหรือความปลอดภัย. อ็อบเจ็กต์ยังคงสามารถค้นพบและยกเลิกการซ่อนได้โดยผู้ใช้หรือโดยโค้ด, และยังคงเป็นส่วนหนึ่งของไฟล์พรีเซนเทชัน.

### **เปลี่ยน Z‑Order**

รูปร่างที่ทับซ้อนกันจะวาดตามลำดับในคอลเลกชัน. [Reorder](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/reorder/) ย้ายรูปร่างที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่คัดลอก. ดัชนี `0` คือด้านหลัง; `Count - 1` คือด้านหน้า.

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

สี่เหลี่ยมถูกสร้างก่อนและเริ่มต้นอยู่ด้านหลังวงรี. การย้ายไปยังดัชนีสุดท้ายทำให้มันอยู่ด้านหน้า. ควรจัดลำดับ z‑order หลังจากเพิ่มหรือคัดลอกรูปร่างที่เกี่ยวข้องทั้งหมด, เนื่องจากการดำเนินการเหล่านั้นจะต่อท้ายหรือแทรกรายการใหม่ในคอลเลกชันและอาจเปลี่ยนสแตกที่ตั้งใจไว้.

## **ตรวจสอบรูปร่างบนสไลด์เลย์เอาต์**

สไลด์ปกติ, สไลด์เลย์เอาต์, และสไลด์มาสเตอร์มีคอลเลกชันรูปร่างแยกกัน. รูปร่างในคอลเลกชันเลย์เอาต์ไม่ใช่วัตถุเดียวกับรูปร่างที่อยู่ในตำแหน่งเดียวกันบนสไลด์ปกติ. ตรวจสอบรูปร่างในเลย์เอาต์เมื่อคุณต้องการเข้าใจหรือเปลี่ยนแปลงการจัดรูปแบบที่มาจากเลย์เอาต์.

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_fillformat/) และ [LineFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_lineformat/) ของแต่ละรูปร่างในเลย์เอาต์โดยไม่สันนิษฐานว่าทุกรูปร่างเป็น `AutoShape`.

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

การแก้ไขเลย์เอาต์อาจส่งผลต่อหลายสไลด์ที่ใช้เลย์เอาต์นั้น. ก่อนเปลี่ยนรูปร่างในเลย์เอาต์, ให้ตรวจสอบว่าสไลด์ปกติสืบทอดอ็อบเจ็กต์นั้นหรือมีการเขียนทับแบบท้องถิ่น, และทดสอบทุกสไลด์ที่ใช้เลย์เอาต์นั้น.

## **ส่งออกรูปร่างเป็น SVG**

[WriteAsSvg](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/writeassvg/) เขียนเนื้อหาที่เรนเดอร์ของรูปร่างหนึ่งไปยังสตรีม. ผลลัพธ์จะมีเฉพาะรูปร่าง, ไม่ใช่พื้นหลังสไลด์ทั้งหมดหรือรูปร่างใกล้เคียง.

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

ให้เปิดพรีเซนเทชันขณะเรนเดอร์. ผลลัพธ์ขึ้นอยู่กับการจัดรูปแบบของรูปร่างและทรัพยากรเช่น ฟอนต์และรูปภาพ. หากต้องการคอมโพสเต็มรูปแบบ, ให้ส่งออกสไลด์แทนการส่งออกรูปร่างเดี่ยว. ผู้เรียกเป็นเจ้าของสตรีมและต้องปิดหรือกำจัดสตรีมนั้น.

## **จัดแนวรูปร่าง**

เมธอด [SlideUtil::AlignShapes](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/alignshapes/) มี overload ที่จัดแนวทุกรูปร่างหรือดัชนีที่เลือกในคอลเลกชัน. [ShapesAlignmentType](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapesalignmenttype/) กำหนดขอบ, เส้นศูนย์กลาง, หรือโหมดการกระจาย. ตั้งค่า `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งเป็น `false` เพื่อจัดแนวรูปร่างที่เลือกสัมพันธ์กัน.

ตัวอย่างนี้จัดแนวสามรูปร่างให้ชิดขอบบนของสไลด์. การอ้างอิงรูปร่างที่ส่งกลับจะถูกแปลงเป็นดัชนีปัจจุบันทันทีก่อนการจัดแนว.

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

การจัดแนวเปลี่ยนตำแหน่ง, ไม่เปลี่ยน z‑order. การจัดแนวสัมพันธ์ทั่วไปต้องมีอย่างน้อยสองรูปร่าง, ขณะที่การกระจายแนวนอนหรือแนวตั้งต้องมีรูปร่างเพียงพอเพื่อกำหนดระยะห่าง. หากคุณแก้ไขคอลเลกชันก่อนเรียกเมธอด, ให้คำนวณดัชนีใหม่.

## **พลิกรูปร่าง**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapeframe/) จัดเก็บตำแหน่ง, ขนาด, การตั้งค่าพลิกแนวนอนและแนวตั้ง, และการหมุน. ค่า `FlipH` และ `FlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/cpp/aspose.slides/nullablebool/): `True` เปิดการพลิก, `False` ปิด, และ `NotDefined` รักษาสถานะที่ไม่ได้ระบุ/ค่าเริ่มต้น.

พรีเซนเทชันตัวอย่างด้านล่างมีรูปร่างที่ไม่ได้พลิก.

![รูปร่างก่อนการพลิก](shape_to_be_flipped.png)

ตัวอย่างนี้คงค่ากรอบอื่น ๆ ทั้งหมดไว้และแทนที่เฉพาะค่าการพลิกสองค่าเท่านั้น. สิ่งนี้สำคัญเพราะการกำหนดค่าใหม่ให้กับ [Frame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/set_frame/) จะทับกรอบทั้งหมด.

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

รูปร่างที่บันทึกจะถูกสะท้อนแนวนอนและแนวตั้งโดยคงตำแหน่ง, ขนาด, และการหมุนไว้.

![รูปร่างหลังการพลิก](flipped_shape.png)

## **คำถามที่พบบ่อย**

**ควรใช้ดัชนีคอลเลกชันเป็นตัวระบรูปร่างหรือไม่?**

เฉพาะสำหรับการประมวลผลระยะสั้นที่คอลเลกชันจะไม่เปลี่ยนแปลงก่อนใช้ดัชนี. ควรใช้ชื่อ (`Name`) หรือข้อความแทนที่ (`AlternativeText`) ที่ตรวจสอบแล้วสำหรับเทมเพลตที่สร้างขึ้น, หรือ `OfficeInteropShapeId` สำหรับงานที่เกี่ยวข้องกับ interop ระดับสไลด์.

**การซ่อนรูปร่างทำให้มันหายจาก z‑order หรือไม่?**

ไม่. รูปร่างที่ซ่อนยังคงอยู่ในคอลเลกชันที่ดัชนีเดียวกัน. สามารถค้นหา, จัดลำดับใหม่, แก้ไข, หรือทำให้มองเห็นได้อีกครั้ง.

**ทำไมรูปร่างที่คัดลอกจึงปรากฏอยู่หน้ารูปร่างอื่น?**

`AddClone` ต่อท้ายคลอนไปยังตำแหน่งสุดท้ายของคอลเลกชัน, ซึ่งเป็นด้านหน้าของ z‑order. ใช้ `InsertClone` เพื่อเลือกดัชนีเริ่มต้นหรือใช้ `Reorder` หลังจากเพิ่มรูปร่างทั้งหมดแล้ว.

**สามารถใช้ดัชนีคงที่เพื่อระบุการปรับค่าพรีเซ็ตของรูปร่างได้หรือไม่?**

ได้เฉพาะเมื่อยืนยันพรีเซ็ตและเลย์เอาต์คอลเลกชันอย่างแม่นยำ. แนะนำให้วนลูปผ่าน `IGeometryShape::get_Adjustments` และตรวจสอบ `IAdjustValue::get_Type`; ใช้ `IAdjustValue::get_Name` เป็นข้อมูลเพิ่มเติมเมื่อประเภทเชิงความหมายเดิมปรากฏหลายครั้ง.