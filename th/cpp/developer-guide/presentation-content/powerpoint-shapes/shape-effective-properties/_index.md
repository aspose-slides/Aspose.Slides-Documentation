---
title: รับคุณสมบัติแบบ Effective ของ Shape จากการนำเสนอใน C++
linktitle: คุณสมบัติแบบ Effective
type: docs
weight: 50
url: /th/cpp/shape-effective-properties/
keywords:
- คุณสมบัติของรูปทรง
- คุณสมบัติของกล้อง
- ระบบแสง
- รูปทรง bevel
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงของฟอนต์
- รูปแบบการเติม
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีใช้ Aspose.Slides สำหรับ C++ เพื่อแยกแยะการจัดรูปแบบ Shape แบบ local, inherited และ effective ในการนำเสนอ PowerPoint."
---
## **ทำความเข้าใจ Local, Inherited และ Effective Properties**

การจัดรูปแบบ PowerPoint สามารถมาจากหลายแหล่ง ค่าเก็บโดยตรงบนอ็อบเจ็กต์คือ **ค่า local** ถ้าค่านั้นไม่ได้ตั้งค่า PowerPoint จะมองที่แหล่งข้อมูลแบบพาเรนต์ เช่น ค่าตั้งต้นของย่อหน้า, สไตล์ข้อความ, เมนูหรือสไลด์แม่, ธีม หรือค่าตั้งต้นระดับการนำเสนอ ค่าต่าง ๆ เหล่านี้คือ **ค่า inherited** ค่าที่เหลือหลังจากที่ลำดับชั้นทั้งหมดได้รับการแก้ไขคือ **ค่า effective** — ค่าที่ใช้ในการเรนเดอร์อ็อบเจ็กต์

ตัวอย่างเช่น ส่วนของข้อความอาจไม่ได้กำหนดความสูงของฟอนต์ของตนเอง ความสูงของฟอนต์ **local** ของมันจึงเป็น `std::numeric_limits<float>::quiet_NaN()` ซึ่งหมายถึง “ไม่ได้ตั้งค่าให้ที่นี่” ส่วนของข้อความสามารถสืบทอดความสูงจากย่อหน้า, สไตล์ข้อความตั้งต้นของการนำเสนอ หรือแหล่งที่สามารถใช้งานได้อื่น ๆ การเรียก [GetEffective](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformat/) บนรูปแบบส่วนจะคืนค่าความสูงที่ถูกแก้ไขแล้ว

ใช้ข้อมูลการจัดรูปแบบสองแบบเพื่อวัตถุประสงค์ที่ต่างกัน:

- อ่านหรือเปลี่ยนอ็อบเจ็กต์รูปแบบ **local** เช่น [IPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformat/) เมื่อคุณต้องการควบคุมว่าค่าถูกกำหนดที่ระดับใด
- อ่านอ็อบเจ็กต์ข้อมูล **effective** เช่น [IPortionFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformateffectivedata/) เมื่อคุณต้องการผลลัพธ์ที่ได้หลังการเรนเดอร์ ข้อมูล effective เป็นแบบอ่าน‑เท่านั้น

## **เปรียบเทียบ Local, Inherited และ Effective Values**

ตัวอย่างเต็มต่อไปนี้สร้างรูปทรงและกำหนดความสูงของฟอนต์ในระดับการนำเสนอ, ย่อหน้าและส่วนของข้อความแต่ละระดับ แต่ละขั้นตอนจะพิมพ์ค่าที่กำหนดในระดับเหล่านั้นและค่า effective ที่ได้จากส่วนข้อความเดียวกัน ตัวอย่างยังแสดงว่าทำไมต้องอ่านข้อมูล effective อีกครั้งหลังจากมีการเปลี่ยนแปลงการจัดรูปแบบ

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// กำหนดค่าที่สืบทอดในสองระดับที่แตกต่างกัน.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // อ่านข้อมูล effective หลังจากการเปลี่ยนแปลงก่อนหน้า.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// ค่าท้องถิ่นบนส่วนจะครอบคลุมค่าที่สืบทอดทั้งสองค่า.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// การเปลี่ยนค่าที่สืบทอดจะไม่ทับค่าท้องถิ่นที่มีอยู่.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// ลบค่าท้องถิ่นออก ตอนนี้ส่วนจะสืบทอดจากย่อหน้าอีกครั้ง.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// ลบค่าของย่อหน้าออก ค่าตั้งต้นของการนำเสนอจะเป็นผลลัพธ์ตอนนี้.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ลำดับความสำคัญในตัวอย่างนี้คือการจัดรูปแบบ **local** ของส่วน, ตามด้วยการจัดรูปแบบของย่อหน้า, แล้วจึงเป็นค่าตั้งต้นของการนำเสนอ วัตถุอื่น ๆ อาจมีห่วงโซ่การสืบทอดที่แตกต่างกัน แต่หลักการคงเดิม: ค่าที่ระบุอย่างเฉพาะเจาะจะแซงค่าที่สืบทอด และ [GetEffective](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformat/) จะคืนค่าผลลัพธ์สุดท้าย

## **รับคุณสมบัติของข้อความแบบ Effective**

การจัดรูปแบบข้อความถูกแยกออกเป็นหลายอ็อบเจ็กต์:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/) แก้ไขคุณสมบัติของเฟรมข้อความ เช่น ระยะขอบ, การยึด, autofit, และทิศทางข้อความแนวตั้ง
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextstyle/) แก้ไขการจัดรูปแบบย่อหน้าสำหรับแต่ละระดับของสไตล์ข้อความ
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/) แก้ไขคุณสมบัติของย่อหน้า เช่น การจัดแนว, การเยื้อง, และรายการสัญลักษณ์
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformat/) แก้ไขคุณสมบัติอักขระ เช่น ความสูงของฟอนต์, แบบอักษร, สี, ตัวหนาและตัวเอียง

สำหรับตัวอย่างต่อไป, ไฟล์ `text-formatting.pptx` ต้องมีอย่างน้อยหนึ่งสไลด์และหนึ่ง [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ที่มีกรอบข้อความไม่ว่างเปล่า IAutoShape สามารถปรากฏได้ตำแหน่งใดก็ได้ในคอลเลกชันของรูปทรง; โค้ดจะค้นหาอ็อบเจ็กต์ที่เหมาะสมและตรวจสอบก่อนใช้งาน

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **รับคุณสมบัติ 3D แบบ Effective**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/) คืนค่าอ็อบเจ็กต์ [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformateffectivedata/) หนึ่งตัวที่จัดกลุ่มการตั้งค่า 3D ทั้งหมดที่แก้ไขแล้ว ข้อมูล [camera](https://reference.aspose.com/slides/th/cpp/aspose.slides/icameraeffectivedata/), [light rig](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilightrigeffectivedata/), [top bevel](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapebeveleffectivedata/) และ [bottom bevel](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapebeveleffectivedata/) จะเปิดเผยการตั้งค่า effective ที่สอดคล้องกัน การอ่านการตั้งค่าเหล่านี้ร่วมกันทำให้เข้าใจรูปลักษณ์ 3D สุดท้ายของรูปทรงได้ง่ายขึ้น

สำหรับตัวอย่างนี้, ไฟล์ `shape-3d.pptx` ต้องมีอย่างน้อยหนึ่งรูปทรงบนสไลด์แรก หากคุณต้องการให้ผลลัพธ์มีค่าที่ไม่ใช่ค่าเริ่มต้น ให้กำหนดกล้อง 3D, การจัดแสง หรือการตั้งค่า bevel ให้กับรูปทรงนั้น

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **รับการจัดรูปแบบตารางแบบ Effective**

การจัดรูปแบบตารางสามารถมาจากสไตล์ตารางและจากฟอร์แมตที่ใช้กับตารางทั้งหมด, คอลัมน์, แถว หรือเซลล์เฉพาะ ในกรณีที่มีการขัดแย้งระหว่างการกำหนด fill อย่างชัดเจน ลำดับความสำคัญคือ เซลล์, แถว, คอลัมน์, แล้วจึงเป็นตารางทั้งหมด ฟอร์แมต effective ของเซลล์คือฟอร์แมตสุดท้ายที่ใช้ในการวาดเซลล์นั้น

สำหรับตัวอย่างนี้, ไฟล์ `table-formatting.pptx` ต้องมีอย่างน้อยหนึ่งตารางบนสไลด์แรก ตารางต้องมีอย่างน้อยหนึ่งแถวและหนึ่งคอลัมน์ โค้ดจะค้นหา [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) แทนการสันนิษฐานว่ารูปทรงแรกเป็นตาราง

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

หากคุณต้องการสีแทนที่จะเป็นประเภท fill อย่างเดียว ให้ตรวจสอบ [FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifillformateffectivedata/) ที่ effective ก่อน แล้วจึงอ่านคุณสมบัติที่สอดคล้องกับประเภทนั้น — ตัวอย่างเช่น [SolidFillColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifillformateffectivedata/) สำหรับ fill แบบทึบ

## **อ่าน Effective Data อีกครั้งหลังการเปลี่ยนแปลง**

Effective data อธิบายลำดับชั้นการจัดรูปแบบในขณะที่ได้รับการแก้ไข เรียก `GetEffective` อีกครั้งหลังจากเปลี่ยนแปลงสิ่งใดที่อาจมีส่วนร่วมในลำดับชั้นนั้น รวมถึง:

- การจัดรูปแบบ **local** ของอ็อบเจ็กต์;
- ค่าตั้งต้นของย่อหน้า หรือเฟรมข้อความ;
- สไตล์ตาราง, ตาราง, คอลัมน์, แถว หรือฟอร์แมตของเซลล์;
- การจัดรูปแบบของเลย์เอาต์หรือสไลด์แม่;
- ข้อมูลธีมหรือค่าตั้งต้นระดับการนำเสนอ;
- เลย์เอาต์หรือสไลด์แม่ที่กำหนดให้กับสไลด์

อย่าเก็บอ็อบเจ็กต์ effective data เป็นสแนปชอตถาวร Aspose.Slides อาจแคชบางส่วนของ effective data ภายในและการเรียก `GetEffective` ครั้งต่อมาจะรีเฟรชข้อมูลนั้น หากคุณต้องการเปรียบเทียบค่าก่อนและหลังการเปลี่ยนแปลง ให้คัดลอกค่าขนาดสเกลาร์ที่ต้องการ — เช่น ความสูงของฟอนต์, สี, การจัดแนว หรือความกว้างของ bevel — ไปยังตัวแปรของคุณก่อนทำการเปลี่ยนแปลง

เพื่อเปลี่ยนค่า ให้ปรับอ็อบเจ็กต์รูปแบบ **local** ที่เหมาะสมแล้วเรียก `GetEffective` เพื่อตรวจสอบผลลัพธ์ อ็อบเจ็กต์ effective data เองเป็นแบบอ่าน‑เท่านั้น

## **FAQ**

**ฉันจะทราบได้ว่าระดับใดให้ค่าที่ effective?**

Effective data มีค่าที่สุดท้าย ไม่ได้บอกแหล่งที่มาของค่า ตรวจสอบอ็อบเจ็กต์ **local** ที่เกี่ยวข้องจากระดับที่เจาะจงที่สุดแล้วค่อยขยายออกไป สำหรับข้อความอาจรวมถึงส่วน, ย่อหน้า, เฟรมข้อความ, เลย์เอาต์, สไลด์แม่, ธีม และค่าตั้งต้นของการนำเสนอ ค่าที่ไม่ได้กำหนดเช่น `std::numeric_limits<float>::quiet_NaN()` หรือ `nullptr` แสดงว่าการค้นหายังดำเนินต่อไปที่ระดับอื่น

**จะเกิดอะไรขึ้นเมื่อไม่มีระดับใดกำหนดคุณสมบัตินั้น?**

Aspose.Slides จะแก้ไขเป็นค่าเริ่มต้นของ PowerPoint หรือของไลบรารี ค่าที่แก้ไขแล้วจะปรากฏใน effective data แม้ว่าจะไม่มีอ็อบเจ็กต์ **local** ใดกำหนดค่าโดยตรง

**ทำไมค่าที่ effective บางครั้งจึงเท่ากับค่าที่ local?**

ค่าที่ local ชนะการคำนวณการสืบทอด ซึ่งเป็นที่คาดหวังเมื่อคุณสมบัติถูกตั้งค่าโดยเจาะจงบนอ็อบเจ็กต์และไม่มีกฎที่เฉพาะเจาะจงกว่าสามารถทับได้

**ควรใช้ข้อมูล local แทนข้อมูล effective เมื่อใด?**

ใช้ข้อมูล local เพื่อตรวจสอบหรือแก้ไขระดับการจัดรูปแบบเฉพาะ ใช้ข้อมูล effective เมื่อคุณต้องการลักษณะที่แสดงผลขั้นสุดท้ายหลังจากการสืบทอด, กฎของธีม, และสไตล์ที่เกี่ยวข้องทั้งหมดได้ถูกแก้ไขแล้ว ตัวอย่าง **การเปรียบเทียบเต็ม** (#compare-local-inherited-and-effective-values) แสดงการใช้ทั้งสองแบบในกระบวนการเดียวกัน