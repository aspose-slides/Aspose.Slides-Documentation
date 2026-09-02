---
title: จัดการตัวเชื่อมต่อในงานนำเสนอด้วย C++
linktitle: ตัวเชื่อมต่อ
type: docs
weight: 10
url: /th/cpp/connector/
keywords:
- ตัวเชื่อมต่อ
- ประเภทของตัวเชื่อมต่อ
- จุดของตัวเชื่อมต่อ
- เส้นเชื่อมต่อ
- มุมของตัวเชื่อมต่อ
- จุดเชื่อมต่อ
- จุดปรับค่า
- เชื่อมต่อรูปร่าง
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่ม, เชื่อมต่อ, เปลี่ยนเส้นทาง, ปรับค่า, และตรวจสอบตัวเชื่อมต่อ PowerPoint แบบตรง, หัก, และโค้งด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

ตัวเชื่อมต่อคือเส้นที่สามารถค้างอยู่กับสองรูปร่างเมื่อรูปร่างใดรูปร่างหนึ่งเคลื่อนที่ ปลายของมันเชื่อมต่อกับจุดเชื่อมต่อซึ่งแสดงด้วยจุดสีเขียวใน PowerPoint ตัวเชื่อมต่อแบบโค้งและหักบางประเภทยังแสดงจุดปรับค่าโดยจุดสีส้มซึ่งควบคุมตำแหน่งของส่วนต่าง ๆ ของตัวเชื่อมต่อ

Aspose.Slides แสดงตัวเชื่อมต่อผ่านอินเทอร์เฟซ [IConnector](https://reference.aspose.com/slides/th/cpp/aspose.slides/iconnector/) คุณสามารถสร้างมัน, เชื่อมต่อปลายของมันกับรูปร่าง, เลือกจุดเชื่อมต่อ, ทำการเปลี่ยนเส้นทาง, และแก้ไขเรขาคณิตของตัวเชื่อมต่อที่มีจุดปรับค่าได้

## **ประเภทของตัวเชื่อมต่อ**

The [ShapeType](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapetype/) enumeration includes preset ตัวเชื่อมต่อแบบตรง, หัก, และโค้ง ตารางต่อไปนี้แสดงรูปทรงของตัวเชื่อมต่อที่มีอยู่และจำนวนจุดปรับค่าที่กำหนดโดยแต่ละ preset

| ตัวเชื่อมต่อ | รูปภาพ | จำนวนจุดปรับค่า |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

จำนวนและความหมายของจุดปรับค่าจะเป็นส่วนหนึ่งของ preset ของตัวเชื่อมต่อที่เลือก อย่าสันนิษฐานว่าตัวเชื่อมต่อสองประเภทที่แตกต่างกันจะแสดงการจัดเรียงคอลเลกชันเดียวกัน

## **เชื่อมต่อสองรูปร่าง**

ใช้ [IShapeCollection::AddConnector](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addconnector/) เพื่อเพิ่มตัวเชื่อมต่อ และเรียก [IConnector::set_StartShapeConnectedTo](https://reference.aspose.com/slides/th/cpp/aspose.slides/iconnector/set_startshapeconnectedto/) และ [IConnector::set_EndShapeConnectedTo](https://reference.aspose.com/slides/th/cpp/aspose.slides/iconnector/set_endshapeconnectedto/) เพื่อเชื่อมต่อปลายของมัน หลังจากเชื่อมต่อปลายทั้งสองแล้ว [IConnector::Reroute](https://reference.aspose.com/slides/th/cpp/aspose.slides/iconnector/reroute/) จะเลือกเส้นทางสั้น ๆ ระหว่างรูปร่าง

ตัวอย่างต่อไปนี้เชื่อมต่อรูปวงรีและสี่เหลี่ยมผืนผ้าด้วยตัวเชื่อมต่อแบบหัก:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);
connector->Reroute();

presentation->Save(u"connected-shapes.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
การเรียก `IConnector::Reroute` อาจเปลี่ยนค่าของ [IConnector::set_StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/th/cpp/aspose.slides/iconnector/set_startshapeconnectionsiteindex/) และ [IConnector::set_EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/th/cpp/aspose.slides/iconnector/set_endshapeconnectionsiteindex/) ให้กำหนดจุดเชื่อมต่อเฉพาะหลังจากทำการเปลี่ยนเส้นทาง หากจุดเหล่านั้นต้องคงที่
{{% /alert %}}

## **เลือกจุดเชื่อมต่อ**

แต่ละรูปร่างที่สามารถเชื่อมต่อได้รายงานจำนวนจุดผ่าน [IShape::get_ConnectionSiteCount](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_connectionsitecount/). ให้ตรวจสอบดัชนีจุดที่ต้องการโดยเริ่มจากศูนย์ก่อนกำหนดให้กับปลายของตัวเชื่อมต่อ; จำนวนจุดจะแตกต่างตามเรขาคณิตของรูปร่าง

ตัวอย่างนี้เชื่อมต่อปลายของตัวเชื่อมต่อไปยังจุดเฉพาะบนรูปวงรีเมื่อจุดนั้นมีอยู่:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);

int32_t preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse->get_ConnectionSiteCount())
{
    connector->set_StartShapeConnectionSiteIndex(preferredSiteIndex);
}
else
{
    Console::WriteLine(u"The ellipse has only {0} connection sites.", ellipse->get_ConnectionSiteCount());
}

presentation->Save(u"specific-connection-site.pptx", SaveFormat::Pptx);
```

## **ปรับจุดของตัวเชื่อมต่อ**

ตัวเชื่อมต่อที่มีจุดปรับค่าจะเปิดเผยจุดเหล่านั้นผ่าน [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/th/cpp/aspose.slides/igeometryshape/get_adjustments/). ตรวจสอบแต่ละ [IAdjustValue](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/) และตรวจสอบ [IAdjustValue::get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/get_type/) ก่อนเปลี่ยนค่า [IAdjustValue::set_RawValue](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/set_rawvalue/). กฎทั่วไปสำหรับการระบุการปรับค่า preset ของรูปร่างได้อธิบายไว้ใน [Shape Manipulation](/slides/th/cpp/shape-manipulations/).

จำนวน, ลำดับ, ความหมาย, และช่วงค่าที่ถูกต้องของการปรับค่าตัวเชื่อมต่อขึ้นอยู่กับ preset ของตัวเชื่อมต่อ ประเภทที่คืนค่าจาก `IAdjustValue::get_Type` เป็นแบบอ่านอย่างเดียว ในขณะที่ค่าการปรับดิบสามารถเขียนได้ วิธีการอ่านอย่างเดียว [IAdjustValue::get_Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/iadjustvalue/get_name/) ให้ข้อมูลระบุตัวเพิ่มเติมเมื่อมีตัวเชื่อมต่อที่มีการปรับค่าเดียวกันหลายรายการ

### **หลีกเลี่ยงอุปสรรค**

ในเลเยอร์ต่อไปนี้ ตัวเชื่อมต่อ `ShapeType::BentConnector5` ระหว่างสองรูปร่างผ่านรูปร่างที่สาม:

![connector-obstruction](connector-obstruction.png)

โค้ดนี้สร้างตัวเชื่อมต่อที่ถูกขวาง:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

presentation->Save(u"connector-obstruction.pptx", SaveFormat::Pptx);
```

การย้ายส่วนหักแนวตั้งทำให้เส้นทางเปลี่ยนเพื่อให้ตัวเชื่อมต่อเลี่ยงอุปสรรค:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

แทนที่จะสันนิษฐานว่าดัชนีคอลเลกชัน `1` เป็นส่วนหักแนวตั้งเสมอ ตัวอย่างนี้จะค้นหา `ShapeAdjustmentType::ConnectorBendPositionY` และเปลี่ยนเฉพาะเมื่อประเภทเชิงความหมายที่คาดหวังปรากฏอยู่:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend->set_RawValue(60000);
    presentation->Save(u"connector-obstruction-fixed.pptx", SaveFormat::Pptx);
}
```

`ShapeType::BentConnector5` มีการปรับค่า `ShapeAdjustmentType::ConnectorBendPositionX` สองค่าและ `ShapeAdjustmentType::ConnectorBendPositionY` หนึ่งค่า หากประเภทที่คุณต้องการปรากฏมากกว่าหนึ่งครั้ง ให้ตรวจสอบ `IAdjustValue::get_Name` และเรขาคณิตที่ทราบของ preset นั้นก่อนเลือก หากการปรับค่ารายงานเป็น `ShapeAdjustmentType::Custom` ให้ถือว่าความหมายและช่วงเป็นแบบกำหนดเฉพาะ preset และไม่เปลี่ยนจนกว่าจะทราบสัญญานั้น

## **เชื่อมโยงค่าการปรับกับเรขาคณิตของตัวเชื่อมต่อ**

สำหรับตัวเชื่อมต่อแบบหัก ค่าการปรับสามารถใช้ประมาณตำแหน่งของส่วนต่าง ๆ ได้ การคำนวณเหล่านี้เป็นแบบเฉพาะของ preset ของตัวเชื่อมต่อ:

- `ShapeType::BentConnector4` ปกติจะเปิดเผยการปรับค่า `ShapeAdjustmentType::ConnectorBendPositionX` หนึ่งค่าและ `ShapeAdjustmentType::ConnectorBendPositionY` อีกหนึ่งค่า
- สำหรับตำแหน่งหักเหล่านี้ `RawValue / 100000.0f` จะให้สัดส่วนของความกว้างหรือความสูงของกรอบตัวเชื่อมต่อตามที่ตัวอย่างด้านล่างใช้
- กรอบของตัวเชื่อมต่ออาจถูกหมุนหรือพลิก ดังนั้นพิกัดของกรอบต้องถูกแปลงก่อนที่จะเปรียบเทียบกับพิกัดของสไลด์

ตัวอย่างต่อไปนี้ใช้ `IAdjustValue::get_Type` เพื่อระบุการปรับค่าก่อน พวกเขาไม่ได้ถือว่าดัชนีคอลเลกชันเป็นตัวระบุแบบพกพา

### **ตัวเชื่อมต่อที่ไม่ได้หมุน**

เลย์เอาต์เริ่มแรกมีสองรูปร่างข้อความที่เชื่อมต่อด้วย `ShapeType::BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

ตัวอย่างนี้ตรวจสอบตัวเชื่อมต่อและดึงการปรับค่าการหักในแนวนอนและแนวตั้ง:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Crimson());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
}
```

เพื่อเปลี่ยนการหักทั้งสอง ให้ค้นหาประเภทที่คาดหวังแต่ละอันและปรับค่าก็ต่อเมื่อพบทั้งสองแล้ว:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);
    presentation->Save(u"connector-adjusted.pptx", SaveFormat::Pptx);
}
```

ผลลัพธ์คือตัวเชื่อมต่อที่ส่วนในแนวนอนและแนวตั้งได้เคลื่อนที่:

![connector-adjusted-1](connector-adjusted-1.png)

เมื่อทราบประเภทเชิงความหมายแล้ว ค่าของมันสามารถแปลงเป็นพิกัดของกรอบตัวเชื่อมต่อ ตัวอย่างนี้วาดสี่เหลี่ยมผอมเหนือส่วนแนวตั้งที่ควบคุมโดยการปรับค่าการหักสองค่า:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    float x = connector->get_X() + connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float y = connector->get_Y();
    float height = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    shapes->AddAutoShape(ShapeType::Rectangle, x, y, 1, height);
    presentation->Save(u"connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

รูปร่างแนวทางทำเครื่องหมายส่วนที่คำนวณได้:

![connector-adjusted-2](connector-adjusted-2.png)

### **ตัวเชื่อมต่อที่หมุนหรือพลิก**

เมื่อเรขาคณิตของตัวเชื่อมต่อเดียวกันถูกจัดให้เป็นแนวตั้ง ค่า [IShape::get_Frame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_frame/), [IShapeFrame::get_FlipH](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapeframe/get_fliph/), และ [IShapeFrame::get_FlipV](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapeframe/get_flipv/) มีผลต่อการแปลงจากพิกัดของกรอบตัวเชื่อมต่อไปยังพิกัดของสไลด์

ตัวอย่างนี้สร้างและปรับตัวเชื่อมต่อที่จัดเป็นแนวตั้ง:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To 1");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_MediumAquamarine());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 20000);
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 200000);
    }
}

presentation->Save(u"vertical-connector-adjusted.pptx", SaveFormat::Pptx);
```

ตัวเชื่อมต่อที่ปรับแล้วปรากฏเป็นแนวตั้งระหว่างรูปร่าง:

![connector-adjusted-3](connector-adjusted-3.png)

สำหรับมุมการหมุนโดยสุ่ม `alpha` ให้หมุนจุดกรอบตัวเชื่อมต่อ `(x, y)` รอบศูนย์กลางกรอบ `(x0, y0)` ดังนี้:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

โค้ดต่อไปนี้จัดการกับการวางแนว 90 องศาที่ใช้ในตัวอย่างนี้และวาดแนวทางสีแดงเหนือส่วนของตัวเชื่อมต่อที่สอดคล้องกัน:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);

    float x = connector->get_X();
    float y = connector->get_Y();
    auto frame = connector->get_Frame();
    if (frame->get_FlipH() == NullableBool::True)
    {
        x += connector->get_Width();
    }
    if (frame->get_FlipV() == NullableBool::True)
    {
        y += connector->get_Height();
    }

    x += connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float rotatedX = frame->get_CenterX() - y + frame->get_CenterY();
    float rotatedY = x - frame->get_CenterX() + frame->get_CenterY();
    float segmentWidth = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    auto guide = shapes->AddAutoShape(ShapeType::Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    auto guideLineFillFormat = guide->get_LineFormat()->get_FillFormat();
    guideLineFillFormat->set_FillType(FillType::Solid);
    guideLineFillFormat->get_SolidFillColor()->set_Color(Color::get_Red());

    presentation->Save(u"rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

แนวทางสีแดงทำเครื่องหมายส่วนที่คำนวณได้หลังจากการแปลงพิกัด:

![connector-adjusted-4](connector-adjusted-4.png)

สูตรเหล่านี้อธิบาย preset ที่ใช้ในตัวอย่าง ไม่ใช่โมเดลตัวเชื่อมต่อสากล ให้ตรวจสอบประเภทการปรับค่า การจัดแนวกรอบ และช่วงค่า ก่อนนำการคำนวณเดิมไปใช้กับ preset อื่น

## **ค้นหามุมทิศทางของตัวเชื่อมต่อ**

ทิศทางของตัวเชื่อมต่อแบบตรงสามารถคำนวณได้จากความกว้างและความสูงของมัน โดยคำนึงถึงการพลิกในแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้รายงานมุมตามเข็มนาฬิกาจากแกนแนวนอนบวกในพิกัดสไลด์:

```cpp
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/math.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);
auto frame = connector->get_Frame();

bool flipH = frame->get_FlipH() == NullableBool::True;
bool flipV = frame->get_FlipV() == NullableBool::True;
float deltaX = connector->get_Width() * (flipH ? -1 : 1);
float deltaY = connector->get_Height() * (flipV ? -1 : 1);
double angle = Math::Atan2(deltaY, deltaX) * 180.0 / Math::PI;

if (angle < 0)
{
    angle += 360;
}

Console::WriteLine(u"Connector direction: {0:F2} degrees", angle);
```

## **คำถามที่พบบ่อย**

**ฉันจะรู้ได้อย่างไรว่าตัวเชื่อมต่อสามารถเชื่อมต่อกับรูปร่างได้หรือไม่?**

ตรวจสอบค่าของ `IShape::get_ConnectionSiteCount` ของรูปร่าง จำนวนบวกหมายถึงรูปร่างมีจุดเชื่อมต่อ ให้ตรวจสอบดัชนีจุดที่เลือกก่อนกำหนดให้กับปลายของตัวเชื่อมต่อใด ๆ

**ฉันสามารถระบุการปรับค่าตัวเชื่อมต่อด้วยดัชนีคอลเลกชันได้หรือไม่?**

ดัชนีมีความหมายเฉพาะกับ preset ของตัวเชื่อมต่อและการจัดเรียงคอลเลกชันที่ทราบ ให้ตรวจสอบ `IAdjustValue::get_Type` ก่อนแก้ไขค่า และใช้ `IAdjustValue::get_Name` เป็นข้อมูลเพิ่มเติมเมื่อประเภทเชิงความหมายเดียวกันปรากฏหลายครั้ง

**อะไรจะเกิดขึ้นเมื่อรูปร่างที่เชื่อมต่อถูกลบ?**

ปลายของตัวเชื่อมต่อที่เชื่อมโยงจะถูกถอดออก ตัวเชื่อมต่อยังคงอยู่บนสไลด์และสามารถลบได้, วางเป็นเส้นอิสระ, หรือเชื่อมต่อกับรูปร่างอื่น

**การผูกตัวเชื่อมต่อจะคงไว้เมื่อสไลด์ถูกคัดลอกหรือไม่?**

การผูกมักจะคงไว้เมื่อรูปร่างที่เชื่อมต่อถูกคัดลอกพร้อมกับสไลด์ หากตัวเชื่อมต่อถูกคัดลอกโดยไม่มีหนึ่งในรูปร่างเป้าหมาย ปลายที่ได้รับผลกระทบต้องเชื่อมต่อใหม่