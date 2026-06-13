---
title: รับคุณสมบัติรูปร่างแบบ Effective จากงานนำเสนอใน C++
linktitle: คุณสมบัติ Effective
type: docs
weight: 50
url: /th/cpp/shape-effective-properties/
keywords:
- คุณสมบัติรูปร่าง
- คุณสมบัติกล้อง
- ชุดแสง
- รูปร่างแบบ bevel
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงฟอนท์
- รูปแบบเติม
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบวิธีที่ Aspose.Slides สำหรับ C++ คำนวณและนำคุณสมบัติรูปร่างแบบ Effective ไปใช้เพื่อการเรนเดอร์ PowerPoint ที่แม่นยำ"
---
## **ภาพรวม**

หัวข้อนี้อธิบายความแตกต่างระหว่างคุณสมบัติ **local** และ **effective** ค่าภายใน (local) คือค่าที่ตั้งโดยตรงที่ระดับการจัดรูปแบบเฉพาะ เช่น:

1. คุณสมบัติ portion บนสไลด์
1. สไตล์ข้อความของรูปร่างต้นแบบบนเลย์เอาต์หรือสไลด์มาสเตอร์ เมื่อรูปร่างกรอบข้อความของ portion มีสไตล์นั้น
1. การตั้งค่าข้อความระดับทั่วโลกในงานพรีเซนเทชัน

ค่าภายในสามารถกำหนดหรือเว้นไว้ที่ระดับใดก็ได้ เมื่อ Aspose.Slides ต้องการรูปแบบสุดท้าย “as rendered” มันจะทำการแก้ไขสายการสืบทอดและคืนค่า **effective** คุณสามารถรับค่าเหล่านี้โดยเรียกเมธอด `GetEffective` บนวัตถุรูปแบบ local

ตัวอย่างต่อไปนี้แสดงวิธีรับค่า effective โดยสมมุติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ที่มีกรอบข้อความและอย่างน้อยหนึ่ง portion

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
ข้อมูลการจัดรูปแบบแบบ effective แสดงถึงการจัดรูปแบบที่คำนวณแล้วหลังจากนำการสืบทอดมาใช้ ในการใช้งานปัจจุบันวัตถุข้อมูลแบบ effective บางตัว เช่น [IPortionFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformateffectivedata/) อาจถูกเก็บไว้ในแคชภายใน การเรียก `GetEffective` อีกครั้งหลังจากเปลี่ยนรูปแบบพาเรนท์หรือรูปแบบที่สืบทอดสามารถรีเฟรชข้อมูลแคชได้ และวัตถุที่ได้ก่อนหน้านี้อาจไม่แสดงสถานะเดิมอีกต่อไป หากคุณต้องการเก็บค่าที่ effective ไว้ใช้ต่อไป ให้นำคุณสมบัติที่ต้องการ เช่น ความสูงของฟอนท์ สีเติม สไตล์ฟอนท์ หรือการจัดแนว คัดลอกไปยังวัตถุข้อมูลของคุณเอง
{{% /alert %}}

## **รับคุณสมบัติ Effective ของกล้อง**

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติ effective ของกล้อง อินเทอร์เฟซ [ICameraEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/icameraeffectivedata/) แสดงถึงวัตถุที่ไม่เปลี่ยนแปลงซึ่งมีคุณสมบัติกล้องแบบ effective อินสแตนซ์ของ [ICameraEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/icameraeffectivedata/) จะถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/)

```cpp
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

## **รับคุณสมบัติ Effective ของ Light Rig**

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติ effective ของ Light Rig อินเทอร์เฟซ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilightrigeffectivedata/) แสดงถึงวัตถุที่ไม่เปลี่ยนแปลงซึ่งมีคุณสมบัติ Light Rig แบบ effective อินสแตนซ์ของ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilightrigeffectivedata/) จะถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/)

```cpp
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

## **รับคุณสมบัติ Effective ของ Bevel Shape**

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติ effective ของ bevel รูปร่าง อินเทอร์เฟซ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapebeveleffectivedata/) แสดงถึงวัตถุที่ไม่เปลี่ยนแปลงซึ่งมีคุณสมบัติ relief ของรูปแบบที่ effective สำหรับรูปร่าง อินสแตนซ์ของ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapebeveleffectivedata/) จะถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/)

```cpp
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

## **รับคุณสมบัติ Effective ของ Text Frame**

โดยใช้ Aspose.Slides คุณสามารถรับคุณสมบัติ effective ของกรอบข้อความ อินเทอร์เฟซ [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformateffectivedata/) มีคุณสมบัติการจัดรูปแบบกรอบข้อความแบบ effective

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีรับคุณสมบัติการจัดรูปแบบกรอบข้อความแบบ effective โดยสมมุติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ที่มีกรอบข้อความ

```cpp
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

## **รับคุณสมบัติ Effective ของ Text Style**

โดยใช้ Aspose.Slides คุณสามารถรับคุณสมบัติ effective ของสไตล์ข้อความ อินเทอร์เฟซ [ITextStyleEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextstyleeffectivedata/) มีคุณสมบัติสไตล์ข้อความแบบ effective

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีรับคุณสมบัติสไตล์ข้อความแบบ effective โดยสมมุติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ที่มีกรอบข้อความ

```cpp
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

## **รับค่า Effective ของความสูงฟอนท์**

โดยใช้ Aspose.Slides คุณสามารถรับความสูงฟอนท์ที่ effective ตัวอย่างโค้ดต่อไปนี้แสดงวิธีที่ความสูงฟอนท์ของ portion ที่ effective เปลี่ยนแปลงหลังจากตั้งค่าความสูงฟอนท์ระดับ local ที่ระดับต่าง ๆ ของโครงสร้างพรีเซนเทชัน

```cpp
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

## **รับ Format เติมแบบ Effective สำหรับตาราง**

โดยใช้ Aspose.Slides คุณสามารถรับการจัดรูปแบบเติมแบบ effective สำหรับส่วนต่าง ๆ ของตาราง อินเทอร์เฟซ [IFillFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifillformateffectivedata/) มีคุณสมบัติการเติมแบบ effective การจัดรูปแบบเซลล์มีลำดับความสำคัญสูงกว่าการจัดรูปแบบแถว แถวมีความสำคัญสูงกว่าคอลัมน์ และคอลัมน์มีความสำคัญสูงกว่าการจัดรูปแบบตารางทั้งหมด

ผลคือคุณสมบัติ [ICellFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/icellformateffectivedata/) จะถูกใช้ในการวาดเซลล์ตาราง ตัวอย่างโค้ดต่อไปนี้แสดงวิธีรับการจัดรูปแบบเติมแบบ effective สำหรับส่วนต่าง ๆ ของตาราง โดยสมมุติว่ารูปร่างแรกบนสไลด์แรกเป็น [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/)

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**`GetEffective` คืนค่า snapshot หรือไม่?**

ไม่เสมอ ข้อมูล effective แสดงถึงการจัดรูปแบบที่คำนวณแล้วหลังจากนำการสืบทอดมาใช้ แต่บางวัตถุข้อมูล effective อาจถูกเก็บไว้ในแคชภายใน การเรียก `GetEffective` อีกครั้งอาจคำนวณใหม่และรีเฟรชแคช ดังนั้นวัตถุที่ได้ก่อนหน้านี้ไม่ควรถือเป็น snapshot ที่คงที่

**เมื่อใดควรอ่านคุณสมบัติ effective อีกครั้ง?**

เรียก `GetEffective` อีกครั้งหลังจากเปลี่ยนการจัดรูปแบบ local, สไตล์พาเรนท์, การจัดรูปแบบเลย์เอาต์, การจัดรูปแบบมาสเตอร์ หรือค่าเริ่มต้นระดับพรีเซนเทชัน การเรียกครั้งถัดไปจะประเมินลำดับการจัดรูปแบบใหม่และคืนค่า effective ปัจจุบัน

**การเปลี่ยนหรือการลบสไลด์เลย์เอาต์/มาสเตอร์มีผลต่อคุณสมบัติ effective ที่ได้แล้วหรือไม่?**

มีผล แต่การเปลี่ยนแปลงจะปรากฏในการเรียก `GetEffective` ถัดไป หากแหล่งข้อมูลการจัดรูปแบบพาเรนท์ถูกเปลี่ยนหรือถูกลบ ข้อมูล effective ที่เคยได้รับอาจล้าสมัย เมื่อนำ `GetEffective` เรียกใหม่ Aspose.Slides จะประเมินต้นไม้การจัดรูปแบบใหม่และค่าฟอนท์, สี, ขนาด หรือค่าอื่น ๆ อาจเปลี่ยนแปลง

**สามารถแก้ไขค่าผ่านวัตถุข้อมูล effective ได้หรือไม่?**

ไม่ได้ วัตถุข้อมูล effective เปิดเผยค่าที่คำนวณแล้ว ให้ทำการเปลี่ยนแปลงในวัตถุการจัดรูปแบบระดับ local แล้วจึงเรียกรับค่าที่ effective อีกครั้ง

**ถ้าคุณสมบัติไม่ได้ตั้งค่าไว้ที่ระดับรูปร่าง, เลย์เอาต์/มาสเตอร์ หรือการตั้งค่ารวม จะเกิดอะไรขึ้น?**

ค่าที่ effective จะถูกกำหนดโดยกลไกค่าเริ่มต้น ซึ่งรวมถึงค่าเริ่มต้นของ PowerPoint และ Aspose.Slides ค่าที่ถูกแก้ไขนี้จะเป็นส่วนหนึ่งของข้อมูล effective ปัจจุบัน

**จากค่าฟอนท์ที่ effective สามารถบอกได้หรือไม่ว่ามาจากระดับใด?**

ไม่ได้โดยตรง ข้อมูล effective คืนค่าที่สุดท้าย เพื่อหาที่มาของค่า ให้ตรวจสอบค่าที่ local ระดับ portion, paragraph, text frame, และสไตล์ข้อความที่เลย์เอาต์, มาสเตอร์, และระดับพรีเซนเทชันเพื่อดูว่าการกำหนดที่ชัดเจนแรกปรากฏที่ระดับใด

**ทำไมค่าที่ effective บางครั้งดูเหมือนค่าที่ local?**

เพราะค่าที่ local กลายเป็นค่าขั้นสุดท้าย (ไม่มีการสืบทอดจากระดับที่สูงกว่า) ในกรณีนั้นค่า effective จะตรงกับค่า local

**ควรใช้คุณสมบัติ effective เมื่อใด และควรใช้ค่า local อย่างเดียวเมื่อใด?**

ใช้ข้อมูล effective เมื่อคุณต้องการผลลัพธ์ “as rendered” หลังจากการสืบทอดทั้งหมด เช่น เพื่อให้สี, ระยะเยื้อง หรือขนาดตรงกัน หากคุณต้องการเก็บค่าตรงนี้ไว้แม้จะมีการเปลี่ยนแปลงการจัดรูปแบบภายหลัง ให้คัดลอกคุณสมบัติที่ต้องการไปยังวัตถุของคุณเอง หากต้องการเปลี่ยนการจัดรูปแบบที่ระดับเฉพาะ ให้แก้ไขค่าที่ local แล้วถ้าจำเป็นให้อ่านข้อมูล effective อีกครั้งเพื่อยืนยันผลลัพธ์