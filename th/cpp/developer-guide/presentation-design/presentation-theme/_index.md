---
title: จัดการธีมงานนำเสนอใน C++
linktitle: ธีมงานนำเสนอ
type: docs
weight: 10
url: /th/cpp/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมงานนำเสนอ
- ธีมสไลด์
- ตั้งค่าธีม
- เปลี่ยนธีม
- จัดการธีม
- สีธีม
- พาเลตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ควบคุมธีมงานนำเสนอใน Aspose.Slides สำหรับ C++ เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมงานนำเสนอกำหนดชุดสี แบบอักษร รูปแบบพื้นหลัง การเติม สีเส้น และเอฟเฟกต์ที่สอดคล้องกัน อ็อบเจกต์ที่รับรู้ธีมอ้างอิงถึงการกำหนดร่วมเหล่านี้แทนการเก็บค่าทรัพย์สินภาพแต่ละตัวเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมสามารถอัปเดตหลายอ็อบเจกต์พร้อมกันได้

ใน Aspose.Slides ธีมระดับงานนำเสนอพร้อมใช้งานผ่าน [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_mastertheme/). งานนำเสนออาจมีการเขียนทับธีมในระดับที่ต่ำลงได้ มาสเตอร์สามารถเขียนทับธีมของงานนำเสนอผ่าน [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), ขณะที่เลย์เอาต์หรือสไลด์แต่ละอันสามารถใช้ [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). จริง ๆ แล้ว ธีมที่ใช้ได้จริงสำหรับสไลด์หนึ่งจะถูกแก้ไขตามโซ่การสืบทอดนี้: ธีมงานนำเสนอ → การเขียนทับของมาสเตอร์ → การเขียนทับของเลย์เอาต์ → การเขียนทับของสไลด์

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

ส่วนต่อไปนี้จะแสดงขั้นตอนการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่ได้จริงหลังจากการสืบทอดและการเขียนทับถูกแก้ไขแล้ว

## **ตรวจสอบธีม**

อ็อบเจกต์ [MasterTheme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/mastertheme/) เปิดเผยวิธีการ [get_ColorScheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), และ [get_FormatScheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) ของธีม การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์อย่างยิ่งเมื่อไฟล์งานนำเข้ามาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่เก็บไว้ในธีม:

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

หากไฟล์ใช้มาสเตอร์หลายใบ อยันคิดว่าแต่ละสไลด์มีธีมที่ได้ผลเหมือนกัน ให้ตรวจสอบมาสเตอร์ที่เชื่อมกับสไลด์นั้น และใช้ขั้นตอนการทำงานของธีมที่ได้ผลตามที่อธิบายต่อไปนี้เมื่ออาจมีการเขียนทับในระดับเลย์เอาต์หรือสไลด์

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงถึงสีสาระสำคัญจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [IColorScheme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/icolorscheme/) ของธีม แล้วอ็อบเจกต์ทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะได้รับค่าใหม่จากสีที่อัปเดต ส่วนอ็อบเจกต์ที่ใช้สี RGB ตรงจะไม่เปลี่ยนแปลงจากการอัปเดตสีธีม

ตัวอย่างต่อไปนี้เป็นกระบวนการตั้งแต่ต้นถึงสุดสร้างรูปร่างที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกงานนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีการเติมที่ได้ผล:

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

เนื่องจากสี่เหลี่ยมยังคงลิงก์กับ `Accent4` สีที่มองเห็นได้จึงกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสคีมด้วยสีตรงบนรูปร่าง การเปลี่ยนแปลง `Accent4` ในภายหลังจะไม่กระทบต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างสีอ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน [ColorTransformOperation](https://reference.aspose.com/slides/th/cpp/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - สีอ่อนและสีเข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกอันโดยอิงจาก `Accent4`, ใช้การแปลงความสว่างกับห้าอัน, แล้วบันทึกผลลัพธ์:

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

สีเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงแล้วจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมพค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2` ขณะที่ [IColorScheme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2` การแมพคงที่ตามนี้:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงจากรูปแบบหนึ่งเป็นอีกรูปแบบแบบไดนามิก

## **เปลี่ยนแบบอักษรธีม**

สกีมแบบอักษรของธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับเนื้อหา ตัวเมธอด [FontScheme::get_Major()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/fontscheme/get_major/) และ [FontScheme::get_Minor()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/fontscheme/get_minor/) เปิดเผยชุดเหล่านั้น

ตัวระบุฟอนต์ธีมที่เข้ากันกับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn-lt` - ฟอนต์ข้อความหลัก (Minor Latin Font)
* `+mj-lt` - ฟอนต์หัวเรื่อง (Major Latin Font)
* `+mn-ea` - ฟอนต์ข้อความเอเชียตะวันออก (Minor East Asian Font)
* `+mj-ea` - ฟอนต์หัวเรื่องเอเชียตะวันออก (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้ฟอนต์ธีม Latin หลักและบรรทัดเนื้อหาเดียวที่ใช้ฟอนต์ธีม Latin รอง จากนั้นเปลี่ยนฟอนต์ธีมและบันทึกผลลัพธ์:

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

หัวเรื่องใช้ฟอนต์หลักและข้อความใช้ฟอนต์รอง ข้อความที่ระบุชื่อฟอนต์โดยตรงแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อสกีมฟอนต์ธีมเปลี่ยน

คอลเลกชันฟอนต์หลักและรองอาจมีการแมพฟอนต์สำหรับระบบเขียนเฉพาะ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana เพื่อทำการตรวจสอบ, เพิ่ม, แทนที่ หรือเอาการแมพเหล่านี้ออก ให้ดูที่ [Script-Specific Theme Fonts](/slides/th/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์ในงานนำเสนอ ดูที่ [ฟอนต์ PowerPoint](/slides/th/cpp/powerpoint-fonts/).
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

มีสองกระบวนการทำงานที่พบบ่อยและแก้ปัญหาต่างกัน

### **รักษาธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและรักษาการออกแบบเดิม ให้คัดลอกมาสเตอร์ต้นฉบับไปยังงานนำหมายโดยใช้ [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslidecollection/addclone/), จากนั้นคัดลอกสไลด์ด้วย [ISlideCollection::AddClone()](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) และมาสเตอร์ที่คัดลอกไว้ การทำเช่นนี้จะนำมาสเตอร์, เลย์เอาต์, และธีมที่เชื่อมโยงมาด้วยกัน

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

นี่คือกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องการรูปลักษณ์เหมือนกันในปลายทาง การคัดลอกเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่มีความเกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนโดยธีมเปลี่ยนแปลงได้

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์ปลายทางต้องคงอยู่บนมาสเตอร์และเลย์เอาต์ปัจจุบัน ให้สร้างการเขียนทับระดับสไลด์จากธีมต้นฉบับ เมธอด [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), และ [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) คัดลอกส่วนประกอบธีมหลักสามส่วนเข้าสู่การเขียนทับ

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

การทำเช่นนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบต่อธีมที่สไลด์อื่นสืบทอด หากต้องการลบการเขียนทับในระดับท้องถิ่นและกลับไปใช้ค่าที่สืบทอด ให้เรียก [OverrideTheme::Clear()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/overridetheme/clear/)

### **ใช้การเขียนทับธีมกับเลย์เอาต์**

การเขียนทับระดับเลย์เอาต์จะมีผลต่อสไลด์ที่ใช้เลย์เอาต์นั้น ยกเว้นกรณีที่สไลด์ใดมีการเขียนทับของตนเอง เมธอดการเริ่มต้นเดียวกันสามารถใช้ผ่าน [IOverrideThemeManager](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ioverridethememanager/) ของเลย์เอาต์ได้

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

ใช้ธีมระดับมาสเตอร์หรือระดับงานนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ต้องการออกแบบฐานเดียวกัน ใช้การเขียนทับระดับเลย์เอาต์เมื่อกลุ่มเลย์เอาต์หนึ่งต้องการสไตล์ที่ต่างออกไป และใช้การเขียนทับระดับสไลด์เฉพาะเมื่อเป็นข้อยกเว้นที่แท้จริง การเขียนทับระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมทั่วโลกในภายหลังคาดเดายาก

## **อัปเดตสไตล์พื้นหลังของธีม**

สไตล์การเติมพื้นหลังของธีมถูกเก็บไว้ใน [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าที่มีการกำหนดในคอลเลกชันนี้ เพราะ UI สามารถผสมการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่เก็บและค่า [Background::get_StyleIndex()](https://reference.aspose.com/slides/th/cpp/aspose.slides/background/get_styleindex/) ปัจจุบัน `StyleIndex` ใช้ค่า `0` เพื่อแสดงว่าไม่มีการเติมธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม สิ่งนี้แตกต่างจากการใช้ดัชนีของคอลเลกชัน C++ โดยตรงด้วย `idx_get(0)` ซึ่ง `0` หมายถึงรายการแรกที่เก็บไว้ อย่ assumes ว่าทุกงานนำเสนอมีจำนวนสไตล์การเติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มีอยู่, กำหนดการอ้างอิงพื้นหลังแบบธีมให้กับมาสเตอร์แรก, และบันทึกงานนำเสนอ:

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

ผลลัพธ์ที่มองเห็นได้ขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการเขียนทับพื้นหลังที่อาจมีในระดับเลย์เอาต์หรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังของมาสเตอร์เพียงอย่างเดียวอาจไม่กระทบต่อสไลด์นั้น ใช้ [Background::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/background/geteffective/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอดถูกนำมาใช้

{{% alert color="warning" title="Warning" %}}
不要將 `StyleIndex` 視為零基索引的集合。也避免將某個檔案的樣式編號硬編碼並假設在另一個檔案中具有相同外觀；主題樣式定義是針對特定簡報的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ให้ดูที่ [Presentation Background](/slides/th/cpp/presentation-background/).
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สกีมรูปแบบของธีมมีคอลเลกชันแยกต่าง ๆ ได้แก่ [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/formatscheme/get_linestyles/), และ [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) typical Office themes มักมีสามรายการสไตล์หลักที่สอดคล้องกับการจัดรูปแบบแบบ Subtle, Moderate, และ Intense แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสันนิษฐานว่ามีจำนวนคงที่

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน C++ ดัชนีของคอลเลกชันเริ่มจากศูนย์: `idx_get(0)` คือสไตล์แรกที่เก็บไว้และ `idx_get(2)` คือสไตล์ที่สาม ดัชนีการอ้างอิงสไตล์ของรูปแบบเป็นแนวคิดแยกต่างหากที่เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapestyle/). การแก้ไขสไตล์ของธีมจะมีผลต่อรูปที่อ้างอิงสไตล์นั้น; รูปที่มีการจัดรูปแบบตรงอาจไม่ถูกเปลี่ยน

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่จำเป็นหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดเงาภายนอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์เติมธีมที่สามจะกลายเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงาภายนอกระยะ 10 จุด ผลลัพธ์ภาพจริงยังคงขึ้นกับว่ารูปแต่ละอันอ้างอิงช่องใดและว่าการจัดรูปแบบโดยตรงได้เขียนทับธีมหรือไม่

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **อ่านค่าธีมที่ได้ผล**

อ็อบเจกต์ธีมดิบบอกว่ามีการกำหนดอะไรที่ระดับใดระดับหนึ่ง ค่าที่ได้ผลบอกว่าสไลด์หรือรูปใช้ค่าอะไรจริงหลังจากการสืบทอดและการเขียนทับในระดับท้องถิ่นถูกแก้ไขแล้ว สำหรับสไลด์ให้เรียก [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). สำหรับพื้นหลังใช้ [Background::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/background/geteffective/), และสำหรับการเติมใช้ [FillFormat::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/geteffective/)

ตัวอย่างต่อไปนี้อ่านธีมที่ได้ผล, พื้นหลัง, และการเติมของรูปร่างแรกจากสไลด์หนึ่ง:

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

ใช้ข้อมูลที่ได้ผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_mastertheme/) คุณอาจพลาดการเขียนทับของมาสเตอร์, เลย์เอาต์, สไลด์, หรือรูปที่เปลี่ยนลักษณะสุดท้าย

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้ ใช้ [IOverrideThemeManager](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ioverridethememanager/) ของสไลด์และเริ่มต้นธีมการเขียนทับ การเปลี่ยนแปลงจะอยู่ในระดับท้องถิ่นของสไลด์นั้น; สไลด์อื่นยังคงสืบทอดธีมเดิม

**วิธีที่ปลอดภัยที่สุดในการนำธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอคืออะไร?**

เมื่อย้ายสไลด์และต้องการรักษารูปแบบต้นฉบับ ให้คัดลอกมาสเตอร์ต้นฉบับไปยังปลายทางและคัดลอกสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslidecollection/addclone/) และ [ISlideCollection::AddClone()](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) วิธีนี้ทำให้มาสเตอร์, เลย์เอาต์, และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่ได้ผลหลังจากการสืบทอดและการเขียนทับได้อย่างไร?**

ใช้ [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) สำหรับสไลด์หรือธีมเลย์เอาต์และใช้เมธอดข้อมูลที่ได้ผลที่สอดคล้องสำหรับออบเจกต์รูปแบบเช่น [Background::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/background/geteffective/) และ [FillFormat::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/geteffective/) API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการเขียนทับถูกนำไปใช้