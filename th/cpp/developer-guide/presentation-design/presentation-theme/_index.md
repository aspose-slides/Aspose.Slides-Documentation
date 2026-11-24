---
title: จัดการธีมการนำเสนอใน C++
linktitle: ธีมการนำเสนอ
type: docs
weight: 10
url: /th/cpp/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมการนำเสนอ
- ธีมสไลด์
- ตั้งค่าธีม
- เปลี่ยนธีม
- จัดการธีม
- ธีมภายนอก
- THMX
- สีธีม
- พาเลตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ธีมการนำเสนอหลักใน Aspose.Slides สำหรับ C++ เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ให้มีการสร้างแบรนด์อย่างสม่ำเสมอ."
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี, ฟอนต์, สไตล์พื้นหลัง, การเติมสี, เส้น, และเอฟเฟกต์ที่สอดคล้องกัน วัตถุที่รับรู้ธีมจะอ้างอิงถึงการกำหนดร่วมเหล่านี้แทนการเก็บคุณสมบัติภาพทั้งหมดเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมสามารถอัปเดตวัตถุหลาย ๆ รายการพร้อมกัน

ใน Aspose.Slides, ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/). การนำเสนออาจมีการแทนที่ธีมในระดับที่ต่ำลงได้ มาสเตอร์สามารถแทนที่ธีมการนำเสนอผ่าน [MasterThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), ในขณะที่เลย์เอาต์หรือสไลด์แต่ละรายการสามารถใช้ [IOverrideThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). โดยปฏิบัติแล้ว ธีมที่มีผลสำหรับสไลด์จะถูกตัดสินผ่านสายการสืบทอดนี้: ธีมการนำเสนอ, การแทนที่ของมาสเตอร์, การแทนที่ของเลย์เอาต์, และการแทนที่ของสไลด์

![ส่วนประกอบของธีม: สี, ฟอนต์, สไตล์พื้นหลัง, และเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงขั้นตอนการทำงานของธีมที่พบมากที่สุด: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้รับการแก้ไขแล้ว

## **ตรวจสอบธีม**

วัตถุ [MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/) เผยแพร่วิธีการของธีม ได้แก่ [get_ColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), และ [get_FormatScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์อย่างยิ่งเมื่อการนำเสนอมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัตธีมหลักและรายงานจำนวนสไตล์พื้นหลัง, การเติมสี, เส้น, และเอฟเฟกต์ที่จัดเก็บในธีม:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

หากไฟล์ใช้มาสเตอร์หลายตัว อย่าสมมติว่าสไลด์ทุกสไลด์มีธีมที่มีผลเดียวกัน ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์ และใช้ขั้นตอนการทำงานของธีมที่มีผลซึ่งแสดงต่อไปในบทความนี้เมื่ออาจมีการแทนที่ในเลย์เอาต์หรือสไลด์

## **เปลี่ยนสีของธีม**

การเติมสี, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงถึงสีเชิงตรรกะจากการนับถือ [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) ของธีม, วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะได้รับการแก้ไขตามค่าที่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัปเดตสีธีม

ตัวอย่างต่อไปนี้สร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีการเติมที่มีผล:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจึงเปลี่ยนเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสคีมด้วยสีโดยตรงบนรูปทรง การเปลี่ยนแปลงต่อมาใน `Accent4` จะไม่มีผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลทเพิ่มเติม**

PowerPoint สร้างรูปแบบสีอ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน [ColorTransformOperation](https://reference.aspose.com/slides/cpp/aspose.slides/colortransformoperation/)

![สีธีมหลักและสีอ่อนและเข้มที่สร้างจากพาเลทเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - รูปแบบสีอ่อนและเข้มที่ผลิตจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอิงจาก `Accent4`, ใช้การแปลงความสว่างกับห้ารูป, และบันทึกผลลัพธ์:

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

รูปแบบเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมปค่าของ `SchemeColor` ไปยังช่องของ `IColorScheme`**

การนับถือ [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2`, ขณะที่ [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2`. การแมปคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อสลับของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง

## **เปลี่ยนฟอนต์ของธีม**

สกีมฟอนต์ของธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับข้อความหลัก วิธีการ [FontScheme::get_Major](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_major/) และ [FontScheme::get_Minor](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_minor/) เปิดเผยชุดเหล่านั้น

ตัวระบุฟอนต์ของธีมที่เข้ากันกับ PowerPoint สามารถใช้ได้ในการจัดรูปแบบข้อความ:

* `+mn-lt` - ฟอนต์หลักภาษา Latin (Minor Latin Font)
* `+mj-lt` - ฟอนต์หัวเรื่องภาษา Latin (Major Latin Font)
* `+mn-ea` - ฟอนต์หลักภาษา East Asian (Minor East Asian Font)
* `+mj-ea` - ฟอนต์หัวเรื่องภาษา East Asian (Major East Asian Font)
* `+mn-cs` - ฟอนต์หลักภาษา Complex Script (Minor Complex Script Font)
* `+mj-cs` - ฟอนต์หัวเรื่องภาษา Complex Script (Major Complex Script Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งรายการที่ใช้ฟอนต์ Latin หลักของธีมและบรรทัดข้อความหนึ่งรายการที่ใช้ฟอนต์ Latin รองของธีม จากนั้นเปลี่ยนฟอนต์ของธีมและบันทึกผลลัพธ์:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

หัวเรื่องใช้ฟอนต์หลักและข้อความใช้ฟอนต์รอง ข้อความที่มีชื่อฟอนต์โดยตรงแทนตัวระบุธีมจะไม่สลับโดยอัตโนมัติเมื่อสกีมฟอนต์ของธีมเปลี่ยน

คอลเลกชันฟอนต์หลักและรองยังอาจมีการแมปฟอนต์สำหรับระบบเขียนต่าง ๆ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana เพื่อดู, เพิ่ม, แทนที่ หรือเอาแมปเหล่านี้ออก ให้ดูที่ [Script-Specific Theme Fonts](/slides/th/cpp/script-specific-font-mappings/)

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์การนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/cpp/powerpoint-fonts/)
{{% /alert %}}

### **แก้ไขการอ้างอิงฟอนต์ของธีม**

เมื่อทำการตรวจสอบข้อความ, [IFontData::get_FontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/get_fontname/) อาจมีการอ้างอิงธีมเช่น `+mn-lt` แทนชื่อฟอนต์ ให้เรียกใช้ [IFontData::GetFontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/getfontname/) พร้อมกับ [IThemeEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeeffectivedata/) ที่เหมาะสมเพื่อแก้ไขการอ้างอิงนั้น คำนำหน้า `+mj` และ `+mn` เลือกชุดฟอนต์หลักและรอง; ส่วนต่อท้าย `-lt`, `-ea`, และ `-cs` เลือกฟอนต์ Latin, East Asian, และ Complex Script ตามลำดับ

รับธีมที่มีผลผ่าน [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) บนวัตถุที่ธีมใช้กับข้อความที่ตรวจสอบ สำหรับข้อความธรรมดาบนสไลด์ ใช้ `slide->CreateThemeEffective()` เพื่อให้บริบทรวมธีมที่สืบทอดจากสไลด์และการแทนที่ภายใน หากตรวจสอบเลย์เอาต์หรือมาสเตอร์เอง ให้ใช้ธีมที่มีผลของมันเอง อย่าสมมติว่าธีมของมาสเตอร์แรกจะใช้กับทุกสไลด์

ตัวอย่างต่อไปนี้สร้างส่วนข้อความที่อ้างอิงฟอนต์ Latin รองโดยตรง เริ่มต้นสกีมฟอนต์สไลด์ผ่าน [IOverrideTheme::InitFontSchemeFromInherited](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) และตั้งค่าครอบครัวฟอนต์ Latin หลักและรองเป็น `Arial` และ `Calibri` เพื่อให้ผลลัพธ์ทำซ้ำได้โดยไม่มีไฟล์อินพุต:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto theme = slide->get_ThemeManager()->get_OverrideTheme();
theme->InitFontSchemeFromInherited();
theme->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Arial"));
theme->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Calibri"));

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 60.0f);
shape->get_TextFrame()->set_Text(u"Text using the minor theme font");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

auto font = portion->get_PortionFormat()->get_LatinFont();
auto effectiveTheme = slide->CreateThemeEffective();
auto resolvedFontName = font->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", font->get_FontName(), resolvedFontName);

auto explicitFont = MakeObject<FontData>(u"Verdana");
auto explicitFontName = explicitFont->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", explicitFont->get_FontName(), explicitFontName);
```

ผลลัพธ์คือ `+mn-lt -> Calibri` ตามด้วย `Verdana -> Verdana` การอ้างอิงที่เก็บไว้ยังคงไม่เปลี่ยนแปลง ส่วนชื่อฟอนต์ที่ระบุโดยตรงจะถูกคืนค่าเช่นนั้น หากส่วนข้อความใช้ `+mj-lt` จะถูกแก้ไขเป็น `Arial` ในธีมนี้

การแก้ไขการอ้างอิงธีมบ่งบอกครอบครัวฟอนต์ที่ธีมระบุ ไม่ได้ตรวจสอบความพร้อมใช้งานของฟอนต์หรือกำหนดไฟล์ฟอนต์ที่ใช้จริงหลังจากการแทนที่หรือ fallback ระหว่างการเรนเดอร์ ดูที่ [Font Selection Sequence](/slides/th/cpp/font-selection-sequence/) และ [Font Substitution](/slides/th/cpp/font-substitution/) สำหรับขั้นตอนแยกเหล่านั้น

## **คัดลอกหรือใช้ธีม**

ขั้นตอนการทำงานด้านล่างแก้ปัญหาเกี่ยวกับธีมต่าง ๆ

### **ใช้ธีมภายนอกกับสไลด์ที่ขึ้นกับมาสเตอร์**

ใช้ [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์ทุกสไลด์ที่ขึ้นกับมาสเตอร์เฉพาะ เลือกมาสเตอร์จากคอลเลกชัน [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) ซึ่งทำงานเป็น [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/) และส่งพาธไฟล์ธีมไปยังเมธอด

เมธอดทำตามขั้นตอนต่อไปนี้:

1. สร้างสไลด์มาสเตอร์ใหม่โดยอิงจากมาสเตอร์ที่เลือก
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่เคยขึ้นกับมาสเตอร์ที่เลือก
1. ส่งคืนอ็อบเจ็กต์ [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/) ที่สร้างใหม่

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่ขึ้นกับมาสเตอร์แรกและบันทึกการนำเสนอ:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);

auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");
Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());

presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) หรือคลาสย่อยที่เกี่ยวกับรูปแบบ ตรวจสอบพาธที่ผู้ใช้ป้อน, จัดการข้อผิดพลาดการเข้าถึงไฟล์ระบบ, และบันทึกการนำเสนอหลังจากธีมถูกนำไปใช้สำเร็จเท่านั้น

เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือกเท่านั้นที่ถูกกำหนดใหม่ สไลด์ที่เชื่อมโยงกับมาสเตอร์อื่นจะคงมาสเตอร์และธีมเดิมไว้ สี, ฟอนต์, การเติม, เส้น, พื้นหลัง, และเอฟเฟกต์ที่รับรู้ธีมจะถูกแก้ตามธีมภายนอก สี, ฟอนต์, การเติมและการจัดรูปแบบที่กำหนดโดยตรงอาจคงเดิมไว้ การแทนที่ระดับเลย์เอาต์และสไลด์ก็อาจมีลำดับความสำคัญเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่

ธีมอาจอ้างอิงฟอนต์ที่ไม่มีในสภาพแวดล้อมการทำงาน เพื่อให้การเรนเดอร์และการส่งออกสอดคล้อง ควรติดตั้งฟอนต์ที่จำเป็น, จัดหาให้ผ่าน [custom font sources](/slides/th/cpp/custom-font/), หรือกำหนด [font substitution](/slides/th/cpp/font-substitution/)

นี่เป็นขั้นตอนทำงานระดับมาสเตอร์โดยตรง: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการแทนที่ธีมระดับสไลด์หรือเลย์เอาต์ด้วยตนเอง

### **ใช้ธีมภายนอกที่แตกต่างในงานนำเสนอหลายมาสเตอร์**

เมื่อไม่ทราบมาสเตอร์ที่เกี่ยวข้องล่วงหน้า ให้นำมาสเตอร์มาจากสไลด์ตัวแทนผ่าน [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) และ [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_masterslide/). เก็บอ้างอิงมาสเตอร์เดิมก่อนใช้ธีมใด ๆ เพราะการเรียกใช้แต่ละครั้งจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อระบุมาสเตอร์ของพวกมันและใช้ธีมภายนอกที่แตกต่างกันกับแต่ละกลุ่ม:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());

        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

การเรียกครั้งแรกมีผลต่อสไลด์ที่ขึ้นกับ `firstGroupMaster` เท่านั้น, ส่วนการเรียกครั้งที่สองมีผลต่อสไลด์ที่ขึ้นกับ `secondGroupMaster` เท่านั้น สไลด์ที่เชื่อมโยงกับมาสเตอร์อื่นจะไม่ได้รับการปรับสไตล์ใหม่

### **คงธีมต้นฉบับเมื่อนำสไลด์ไปยังงานนำเสนออื่น**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและคงการออกแบบเดิม ให้ทำการโคลนมาสเตอร์ต้นฉบับเข้าสู่งานนำหมายด้วย [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/), แล้วโคลนสไลด์ด้วย [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) พร้อมมาสเตอร์ที่โคลน นี่จะทำให้มาสเตอร์, เลย์เอาต์, และธีมที่เชื่อมโยงมาด้วยกัน

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");

auto sourceSlide = source->get_Slide(0);

auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);

target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

นี่เป็นขั้นตอนทำงานที่แนะนำเมื่อสไลด์ต้นฉบับต้องแสดงผลเหมือนกันในปลายทาง การโคลนเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนโดยธีมเปลี่ยนแปลง

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลย์เอาต์ปัจจุบัน ให้เริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นฉบับ วิธีการ [OverrideTheme::InitColorSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), และ [OverrideTheme::InitFormatSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) คัดลอกส่วนประกอบธีมสามส่วนหลักเข้าสู่การแทนที่

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);

auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());

target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

ขั้นตอนนี้เปลี่ยนธีมที่ใช้โดยสไลด์นั้นโดยไม่กระทบต่อธีมที่สืบทอดโดยสไลด์อื่น ๆ เพื่อลบการแทนที่ท้องถิ่นและกลับสู่ค่าที่สืบทอด ให้เรียก [OverrideTheme::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/clear/)

### **ใช้การแทนที่ธีมกับเลย์เอาต์**

การแทนที่ระดับเลย์เอาต์จะมีผลต่อสไลด์ที่ใช้เลย์เอาต์นั้น ยกเว้นกรณีที่สไลด์ใดมีการแทนที่ของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) ของเลย์เอาต์ได้:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);

auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());

target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ต้องการออกแบบฐานเดียวกัน ใช้การแทนที่เลย์เอาต์เมื่อครอบครัวเลย์เอาต์หนึ่งต้องการสไตล์ที่แตกต่าง และใช้การแทนที่สไลด์เฉพาะเมื่อเป็นข้อยกเว้นจริง การแทนที่ระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมระดับทั่วโลกในภายหลังคาดเดาได้ยาก

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกจัดเก็บใน [FormatScheme::get_BackgroundFillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการกำหนดการเติมที่เก็บในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![แกลเลอรีสไตล์พื้นหลัง PowerPoint สำหรับธีมการนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ตรวจสอบคอลเลกชันที่เก็บและค่า [Background::get_StyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` ใช้ `0` หมายถึงไม่มีการเติมที่เป็นธีม; ค่าบวกหมายถึงการอ้างอิงสไตล์พื้นหลังของธีม นี่แตกต่างจากการจัดทำดัชนีคอลเลกชัน C++ โดยตรงด้วย `idx_get(0)`, ที่ `0` หมายถึงรายการแรกที่เก็บไว้ อย่าสมมติว่าการนำเสนอทุกชุดมีจำนวนสไตล์การเติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังของธีมให้กับมาสเตอร์แรก, และบันทึกการนำเสนอ:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);

    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการแทนที่พื้นหลังที่เลย์เอาต์หรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังของมาสเตอร์อย่างเดียวอาจไม่กระทบต่อสไลด์นั้น ใช้ [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอด

{{% alert color="warning" title="Warning" %}}
อย่าพิจารณา `StyleIndex` เป็นดัชนีคอลเลกชันแบบศูนย์ฐาน นอกจากนี้ อย่า hard‑code หมายเลขสไตล์จากไฟล์หนึ่งและสมมติว่ามีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ของธีมเป็นเอกลักษณ์ของการนำเสนอ
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/cpp/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สกีมรูปแบบของธีมมีคอลเลกชันแยกต่างหากสำหรับ [FormatScheme::get_FillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_linestyles/), และ [FormatScheme::get_EffectStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). ธีม Office ปกติอาจมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบแบบ Subtle, Moderate, และ Intense, อย่างไรก็ตาม โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติว่ามีจำนวนคงที่

![เอฟเฟกต์ธีมแบบ Subtle, Moderate, และ Intense ที่ใช้กับรูปทรงเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน C++, ดัชนีคอลเลกชันเริ่มจากศูนย์: `idx_get(0)` คือสไตล์แรกที่เก็บไว้และ `idx_get(2)` คือสไตล์ที่สาม ดัชนีการอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกที่เผยให้เห็นผ่าน [IShapeStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/). การแก้ไขสไตล์ธีมจะส่งผลต่อรูปทรงที่อ้างอิงสไตล์ธีมนั้น; รูปทรงที่มีการจัดรูปแบบโดยตรงอาจคงเดิมไว้

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่จำเป็นหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดใช้งานเงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าซึ่งเป็นสีทึบ, และสไตล์เอฟเฟกต์ที่สามจะมีเงานอกที่ระยะ 10 จุด ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นกับรูปทรงแต่ละรูปอ้างอิงช่องใดและว่าการจัดรูปแบบโดยตรงได้แทนที่ธีมหรือไม่

![สไตล์เอฟเฟกต์ของธีมหลังจากเปลี่ยนเส้น, เติม, และการตั้งค่าเงา](presentation-design_11.png)

## **เลือกสไตล์การเติมและเส้นของธีมสำหรับรูปทรง**

รูปทรงสามารถเลือกการเติมและเส้นขอบแยกกันได้ผ่าน [IShapeStyle::set_FillStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_fillstyleindex/) และ [IShapeStyle::set_LineStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_linestyleindex/). สำหรับทั้งสองตัวตั้ง ค่า `1` เลือกรายการแรกในคอลเลกชันธีมที่สอดคล้อง (`idx_get(0)`), ค่า `2` เลือกรายการที่สอง

ตัวอย่างต่อไปนี้ตั้งค่าสไตล์การเติมสองแบบ (ทองและฟ้าอากาศ) และสไตล์เส้นสองแบบ (สีน้ำเงินเข้มที่ 6 pt และสีแดงเข้มที่ 12 pt) ในธีมเริ่มต้นของงานนำเสนอใหม่ จากนั้นบันทึกสไลด์ในสามช่วงเพื่อให้คุณเปรียบเทียบผลลัพธ์ใน PowerPoint

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeStyle.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto styles = presentation->get_MasterTheme()->get_FormatScheme();

auto goldFill = styles->get_FillStyles()->idx_get(0);
goldFill->set_FillType(FillType::Solid);
goldFill->get_SolidFillColor()->set_Color(Color::get_Gold());
auto blueFill = styles->get_FillStyles()->idx_get(1);
blueFill->set_FillType(FillType::Solid);
blueFill->get_SolidFillColor()->set_Color(Color::get_SkyBlue());

auto thinLine = styles->get_LineStyles()->idx_get(0);
thinLine->get_FillFormat()->set_FillType(FillType::Solid);
thinLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
thinLine->set_Width(6.0);
auto thickLine = styles->get_LineStyles()->idx_get(1);
thickLine->get_FillFormat()->set_FillType(FillType::Solid);
thickLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkRed());
thickLine->set_Width(12.0);

auto shapes = presentation->get_Slide(0)->get_Shapes();
auto left = shapes->AddAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
auto right = shapes->AddAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
auto leftStyle = left->get_ShapeStyle();
auto rightStyle = right->get_ShapeStyle();
leftStyle->set_FillStyleIndex(1);
rightStyle->set_FillStyleIndex(2);
leftStyle->set_LineStyleIndex(1);
rightStyle->set_LineStyleIndex(1);
presentation->Save(u"01-initial.pptx", SaveFormat::Pptx);

rightStyle->set_LineStyleIndex(2);
presentation->Save(u"02-line-changed.pptx", SaveFormat::Pptx);

goldFill->get_SolidFillColor()->set_Color(Color::get_SeaGreen());
presentation->Save(u"03-theme-changed.pptx", SaveFormat::Pptx);
```

| สไตล์เริ่มต้น | เปลี่ยนขอบขวา | แก้ไขการเติมธีมแรก |
|:---:|:---:|:---:|
| ![สี่เหลี่ยมทองและสีฟ้าอากาศที่มีขอบเส้นสีฟ้าเข้มบางตรงกัน](theme-style-initial.png) | ![สี่เหลี่ยมสีฟ้าอากาศตอนนี้มีขอบสีแดงเข้มหนา](theme-style-line-changed.png) | ![สี่เหลี่ยมซ้ายตอนนี้เป็นสีเขียวและขอบทั้งสองคงเดิม](theme-style-fill-changed.png) |

การเลือกสไตล์เส้นที่แตกต่างจะเปลี่ยนเฉพาะขอบของสี่เหลี่ยมขวา การแก้ไขการเติมธีมแรกจะอัปเดตทุกรูปทรงที่ใช้มัน ที่นี่สี่เหลี่ยมซ้ายจึงเปลี่ยนเป็นสีเขียว

บนรูปทรงที่มีอยู่ การเติมสีท้องถิ่น, สีเส้น, หรือความกว้างเส้นสามารถแทนที่ส่วนของสไตล์ธีมได้ หากการเปลี่ยนดัชนีสไตล์ไม่มีผลปรากฏ ให้ตรวจสอบ [direct formatting](/slides/th/cpp/shape-formatting/)

## **ตรวจสอบว่าการเติมแบบทึบที่มีผลใช้สีธีมหรือไม่**

การเติมอาจถูกเก็บโดยตรงบนวัตถุหรือสืบทอดจากย่อหน้า, เลย์เอาต์, มาสเตอร์, สไตล์ธีม, หรือระดับการจัดรูปแบบอื่น ๆ เรียกใช้ [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/) เพื่อแก้ลำดับชั้นนี้เป็นข้อมูลที่ไม่แปรเปลี่ยนของ [IFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/). ตรวจสอบแรกคือ [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). เฉพาะเมื่อค่าเป็น `FillType::Solid` จึงควรอ่านคุณสมบัติการเติมแบบทึบ

สำหรับการเติมแบบทึบ, [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) คืนค่ารหัส RGB ที่เรนเดอร์สุดท้ายหลังจากสืบทอด, การค้นหาธีม, และการแปลงสี [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) คืนค่าสล็อตเชิงตรรกะของ [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) เช่น `Text1` หรือ `Accent6`. ค่า `SchemeColor::NotDefined` หมายถึงการเติมแบบทึบที่มีผลไม่ได้อิงตามสีสคีม ในขั้นตอนทำงานที่การเติมเป็นสีธีมหรือสี RGB โดยตรง ค่าดังกล่าวบ่งบอกการเติม RGB โดยตรง

อย่าใช้ค่า [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_schemecolor/) ท้องถิ่นเพียงอย่างเดียวเพื่อจำแนกการเติม ตัวอย่างเช่น ส่วนข้อความอาจไม่มีสีสคีมที่กำหนดบนท้องถิ่น ดังนั้นค่าท้องถิ่นเป็น `NotDefined` ในขณะที่การเติมที่มีผลสืบทอดสีธีมและแก้เป็น `Text1` หรือ `Accent6`. ในทางกลับกัน `get_SolidFillSchemeColor` บอกว่าช่องธีมเชิงตรรกะใดที่สร้างสีที่มีผล, แต่ไม่บอกว่าช่องนั้นมาจากวัตถุ, ย่อหน้า, เลย์เอาต์, มาสเตอร์ หรือระดับอื่นของลำดับการจัดรูปแบบ

ตัวอย่างต่อไปนี้โหลดการนำเสนอ, ตรวจสอบการเติมของรูปทรงและส่วนข้อความ, พิมพ์ค่ RGB สุดท้ายและสคีมที่เกี่ยวข้อง, และทำเครื่องหมายการเติมแบบทึบที่ไม่ติดตามการเปลี่ยนสีธีม:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

สาขา `NotDefined` ให้รายการตรวจสอบการเติมแบบทึบที่ไม่ตอบสนองต่อการเปลี่ยนแปลงช่องสีธีม ตรวจสอบวัตถุเหล่านั้นเมื่อการนำเสนอจำเป็นต้องสอดคล้องกับพาเลตแบรนด์ใหม่ ค่ารหัส RGB ที่รายงานยังคงแสดงลักษณะปัจจุบัน, ส่วนค่าช่องสคีมอธิบายว่าลักษณะนั้นเชื่อมต่อกับธีมหรือไม่

วัตถุรูปแบบที่มีผลเป็นภาพสแนปช็อต หลังจากเปลี่ยนธีมการนำเสนอ, การแทนที่ธีม, หรือการจัดรูปแบบที่สืบทอด, เรียก `GetEffective` อีกครั้งและอ่านอ็อบเจ็กต์ `IFillFormatEffectiveData` ใหม่ก่อนทำการเปรียบเทียบหรือรายงานสี

## **อ่านค่าธีมที่มีผล**

อ็อบเจ็กต์ธีมดิบบอกว่ามีการกำหนดอะไรบ้างในระดับที่ระบุ ค่าที่มีผลบอกว่าหน้าสไลด์หรือรูปทรงใช้อะไรจริงหลังจากสืบทอดและการแทนที่ท้องถิ่นได้รับการแก้แล้ว สำหรับสไลด์ ให้เรียก [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). สำหรับพื้นหลัง ให้ใช้ [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/), สำหรับการเติม ให้ใช้ [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมของรูปทรงแรกจากสไลด์:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบความถูกต้อง, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/), คุณอาจพลาดการแทนที่ของมาสเตอร์, เลย์เอาต์, สไลด์, หรือรูปทรงที่เปลี่ยนลักษณะสุดท้าย

## **คำถามที่พบบ่อย**

**การใช้ธีมภายนอกส่งผลต่อทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) จะกำหนดใหม่เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือก สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิม

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ใช้ [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) ของสไลด์และเริ่มต้นธีมแทนที่ การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่นยังคงสืบทอดธีมเดิมต่อไป

**วิธีที่ปลอดภัยที่สุดในการนำธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอคืออะไร?**

เมื่อย้ายสไลด์และต้องคงลักษณะต้นฉบับ, ให้โคลนมาสเตอร์ต้นฉบับไปยังปลายทางและโคลนสไลด์พร้อมมาสเตอร์นั้นโดยใช้ [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) และ [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/). วิธีนี้จะคงมาสเตอร์, เลย์เอาต์, และธีมไว้ด้วยกัน

**จะดูค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้อย่างไร?**

ใช้ [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) สำหรับสไลด์หรือธีมเลย์เอาต์และเมธอดข้อมูลที่มีผลที่สอดคล้องสำหรับอ็อบเจ็กต์รูปแบบ เช่น [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) และ [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/). API เหล่านี้คืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการแทนที่ถูกนำไปใช้.