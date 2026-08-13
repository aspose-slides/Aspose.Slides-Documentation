---
title: ดึงคุณสมบัติรูปร่างที่ Effective จากการนำเสนอใน C++
linktitle: คุณสมบัติ Effective
type: docs
weight: 50
url: /th/cpp/shape-effective-properties/
keywords:
- คุณสมบัติรูปร่าง
- คุณสมบัติกล้อง
- ระบบแสง
- รูปร่างเบเวล
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงฟอนต์
- รูปแบบการเติม
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบว่าการคำนวณและการใช้คุณสมบัติรูปร่างที่ Effective ของ Aspose.Slides for C++ ทำอย่างไรเพื่อการเรนเดอร์ PowerPoint อย่างแม่นยำ"
---
## **ภาพรวม**

หัวข้อนี้อธิบายความแตกต่างระหว่างคุณสมบัติ **local** และ **effective** ค่าท้องถิ่นคือค่าที่ตั้งโดยตรงที่ระดับการจัดรูปแบบเฉพาะ เช่น:

1. คุณสมบัติส่วนบนสไลด์
1. สไตล์ข้อความของรูปร่างต้นแบบบนเค้าโครงหรือสไลด์มาสเตอร์ เมื่อรูปร่างกรอบข้อความของส่วนมีสไตล์อยู่
1. การตั้งค่าข้อความระดับทั่วทั้งการนำเสนอ

ค่าท้องถิ่นสามารถกำหนดหรือละเว้นได้ที่ระดับใดก็ได้ เมื่อ Aspose.Slides ต้องการการจัดรูปแบบขั้นสุดท้าย "as rendered" มันจะแก้ไขสายการสืบทอดและคืนค่าที่ **effective** คุณสามารถดึงค่าเหล่านั้นได้โดยเรียกเมธอด `GetEffective` บนวัตถุรูปแบบท้องถิ่น

ตัวอย่างต่อไปนี้แสดงวิธีการดึงค่าที่ **effective** โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ที่มีกรอบข้อความและมีอย่างน้อยหนึ่งส่วน

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="info" %}}
ข้อมูลการจัดรูปแบบที่ **effective** แทนค่าการจัดรูปแบบที่คำนวณแล้วหลังจากการสืบทอดถูกนำมาใช้ ในการทำงานปัจจุบันวัตถุบางประเภทของข้อมูลที่ **effective** เช่น [IPortionFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformateffectivedata/) อาจถูกแคชภายใน การเรียก `GetEffective` อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบของพาเรนท์หรือที่สืบทอดมาจะทำให้แคชรีเฟรชและวัตถุที่ได้ก่อนหน้านี้อาจไม่แสดงสถานะเดิมอีกต่อไป หากคุณต้องการเก็บค่าที่ **effective** เพื่อนำกลับใช้ในภายหลัง ให้คัดลอกคุณสมบัติที่ต้องการ เช่น ความสูงของฟอนต์ สีเติม สไตล์ฟอนต์ หรือการจัดแนว ไปยังอ็อบเจ็กต์ข้อมูลของคุณเอง
{{% /alert %}}

## **ดึงคุณสมบัติ Effective ของกล้อง**

Aspose.Slides อนุญาตให้คุณดึงคุณสมบัติ Effective ของกล้อง อินเทอร์เฟซ [ICameraEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/icameraeffectivedata/) แสดงอ็อบเจ็กต์ไม่เปลี่ยนแปลงที่บรรจุคุณสมบัติกล้องที่ Effective อินสแตนซ์ของ [ICameraEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/icameraeffectivedata/) แสดงผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ Effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/)

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **ดึงคุณสมบัติ Effective ของ Light Rig**

Aspose.Slides อนุญาตให้คุณดึงคุณสมบัติ Effective ของ Light Rig อินเทอร์เฟซ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilightrigeffectivedata/) แสดงอ็อบเจ็กต์ไม่เปลี่ยนแปลงที่บรรจุคุณสมบัติ Light Rig ที่ Effective อินสแตนซ์ของ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilightrigeffectivedata/) แสดงผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ Effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/)

```cpp
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **ดึงคุณสมบัติ Effective ของรูปแบบ Bevel**

Aspose.Slides อนุญาตให้คุณดึงคุณสมบัติ Effective ของ bevel รูปร่าง อินเทอร์เฟซ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapebeveleffectivedata/) แสดงอ็อบเจ็กต์ไม่เปลี่ยนแปลงที่บรรจุคุณสมบัติ relief ของรูปแบบ อินสแตนซ์ของ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapebeveleffectivedata/) แสดงผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ Effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/)

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **ดึงคุณสมบัติ Effective ของ Text Frame**

ด้วย Aspose.Slides คุณสามารถดึงคุณสมบัติ Effective ของ Text Frame อินเทอร์เฟซ [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformateffectivedata/) มีคุณสมบัติการจัดรูปแบบ Text Frame ที่ Effective

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextFrameFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **ดึงคุณสมบัติ Effective ของ Text Style**

ด้วย Aspose.Slides คุณสามารถดึงคุณสมบัติ Effective ของ Text Style อินเทอร์เฟซ [ITextStyleEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextstyleeffectivedata/) มีคุณสมบัติ Text Style ที่ Effective

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/ITextStyleEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **ดึงค่า Effective ของความสูงฟอนต์**

ด้วย Aspose.Slides คุณสามารถดึงความสูงฟอนต์ที่ Effective ตัวอย่างโค้ดต่อไปนี้แสดงว่า ความสูงฟอนต์ของส่วนที่ Effective จะเปลี่ยนอย่างไรเมื่อค่าความสูงฟอนต์ระดับท้องถิ่นถูกตั้งที่ระดับโครงสร้างการนำเสนอที่แตกต่างกัน

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ดึงรูปแบบ Fill Effective สำหรับตาราง**

ด้วย Aspose.Slides คุณสามารถดึงการจัดรูปแบบ Fill ที่ Effective สำหรับส่วนต่าง ๆ ของตาราง อินเทอร์เฟซ [IFillFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifillformateffectivedata/) มีคุณสมบัติการเติมที่ Effective การจัดรูปแบบเซลล์มีระดับความสำคัญสูงกว่าการจัดรูปแบบแถว, การจัดรูปแบบแถวสูงกว่าการจัดรูปแบบคอลัมน์, และการจัดรูปแบบคอลัมน์สูงกว่าการจัดรูปแบบตารางทั้งหมด

ผลคือคุณสมบัติของ [ICellFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/icellformateffectivedata/) จะถูกใช้ในการวาดเซลล์ตาราง ตัวอย่างโค้ดต่อไปนี้แสดงวิธีดึงการจัดรูปแบบ Fill ที่ Effective สำหรับส่วนต่าง ๆ ของตาราง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/)

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/ICellFormatEffectiveData.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IColumnFormatEffectiveData.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/IRowFormatEffectiveData.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <DOM/Table/ITableFormatEffectiveData.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **FAQ**

### `GetEffective` คืนค่า snapshot หรือไม่?

ไม่เสมอไป ข้อมูลที่ **effective** แสดงการจัดรูปแบบที่คำนวณแล้วหลังจากการสืบทอดถูกนำมาใช้ แต่บางอ็อบเจ็กต์ข้อมูลที่ **effective** อาจถูกแคชภายใน การเรียก `GetEffective` ครั้งต่อมาหลังจากเปลี่ยนแปลงการจัดรูปแบบของพาเรนท์หรือที่สืบทอดอาจคำนวณใหม่และรีเฟรชแคช ดังนั้นอ็อบเจ็กต์ที่ได้ก่อนหน้านี้ไม่ควรถือเป็น snapshot ที่คงที่

### ควรอ่านคุณสมบัติที่ Effective อีกครั้งเมื่อใด?

ให้เรียก `GetEffective` อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบท้องถิ่น, สไตล์ของพาเรนท์, การจัดรูปแบบเค้าโครง, การจัดรูปแบบมาสเตอร์ หรือค่าเริ่มต้นระดับการนำเสนอ การเรียกครั้งถัดไปจะประเมินลำดับชั้นการจัดรูปแบบใหม่และคืนผลลัพธ์ที่ Effective ปัจจุบัน

### การเปลี่ยนแปลงหรือการลบสไลด์เค้าโครง/มาสเตอร์ส่งผลต่อคุณสมบัติที่ Effective ที่ได้แล้วหรือไม่?

ใช่ แต่การเปลี่ยนแปลงจะปรากฏในการเรียก `GetEffective` ครั้งถัดไป หากแหล่งข้อมูลการจัดรูปแบบระดับพาเรนท์ถูกเปลี่ยนหรือถูกลบ ข้อมูลที่ Effective ที่ได้ก่อนหน้านี้อาจล้าสมัย เมื่อเรียก `GetEffective` อีกครั้ง Aspose.Slides จะประเมินต้นไม้การจัดรูปแบบใหม่และค่าต่าง ๆ เช่น ฟอนต์ สี ขนาด หรือค่าอื่น ๆ อาจเปลี่ยนแปลงไป

### สามารถแก้ไขค่าผ่านอ็อบเจ็กต์ข้อมูลที่ Effective ได้หรือไม่?

ไม่ได้ อ็อบเจ็กต์ข้อมูลที่ **effective** เฉพาะให้ค่าที่คำนวณแล้ว ทำการเปลี่ยนแปลงในอ็อบเจ็กต์การจัดรูปแบบท้องถิ่น แล้วดึงค่าที่ **effective** ใหม่อีกครั้ง

### ถ้าคุณสมบัติไม่ได้ถูกตั้งที่ระดับรูปร่าง, ไม่ได้ตั้งที่เค้าโครง/มาสเตอร์และไม่ตั้งที่การตั้งค่าทั่วไป จะเกิดอะไรขึ้น?

ค่าที่ **effective** จะถูกกำหนดโดยกลไกค่าเริ่มต้น ซึ่งรวมถึงค่าเริ่มต้นของ PowerPoint และ Aspose.Slides ค่า resolve นี้จะเป็นส่วนหนึ่งของข้อมูลที่ **effective** ปัจจุบัน

### จากค่าฟอนต์ที่ **effective** ฉันจะรู้ได้หรือไม่ว่ามาจากระดับใด?

ไม่โดยตรง ข้อมูลที่ **effective** ให้ค่าที่สุดท้าย หากต้องการทราบแหล่งที่มา ให้ตรวจสอบค่าท้องถิ่นที่ส่วน, ย่อหน้า, กรอบข้อความและสไตล์ข้อความที่ระดับเค้าโครง, มาสเตอร์และการนำเสนอ เพื่อดูว่าการกำหนดที่ชัดเจนแรกปรากฏที่ระดับใด

### ทำไมค่าที่ **effective** บางครั้งดูเหมือนเหมือนค่าท้องถิ่น?

เพราะค่าท้องถิ่นนั้นกลับเป็นค่าที่สุดท้าย (ไม่มีการสืบทอดจากระดับที่สูงกว่า) ดังนั้นค่าที่ **effective** จึงตรงกับค่าท้องถิ่น

### ควรใช้คุณสมบัติที่ **effective** หรือใช้เฉพาะค่าท้องถิ่นเมื่อใด?

ใช้ข้อมูลที่ **effective** เมื่อคุณต้องการผลลัพธ์ “as rendered” หลังจากการสืบทอดทั้งหมด เช่น การปรับสี, ระยะเยื้องหรือขนาด หากคุณต้องการเก็บค่าดังกล่าวไว้โดยไม่ให้การเปลี่ยนแปลงการจัดรูปแบบภายหลังทำให้ค่าเปลี่ยน ให้คัดลอกคุณสมบัติที่ต้องการไปยังอ็อบเจ็กต์ของคุณเอง หากต้องการเปลี่ยนแปลงการจัดรูปแบบที่ระดับใดระดับหนึ่ง ให้แก้ไขค่าท้องถิ่นและจากนั้นอาจอ่านข้อมูลที่ **effective** อีกครั้งเพื่อยืนยันผลลัพธ์