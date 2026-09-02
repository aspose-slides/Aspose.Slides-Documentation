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
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ C++ เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการแบรนด์ที่สม่ำเสมอ."
---
## **บทนำ**

ธีมการนำเสนอคือชุดสี ฟอนต์ สไตล์พื้นหลัง การเติม สีเส้น และเอฟเฟกต์ที่ประสานกันอย่างสอดคล้องกัน อ็อบเจ็กต์ที่รับรู้ธีมจะอ้างอิงถึงคำนิยามที่ใช้ร่วมกันเหล่านี้แทนการเก็บค่าคุณสมบัติสำหรับแต่ละอ็อบเจ็กต์เป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัปเดตหลายอ็อบเจ็กต์พร้อมกันได้

ใน Aspose.Slides ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_mastertheme/). การนำเสนอยังสามารถมีการเขียนทับธีมในระดับที่ต่ำกว่าได้ มาสเตอร์สามารถเขียนทับธีมของการนำเสนอผ่าน [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), ในขณะที่เลย์เอาต์หรือสไลด์แต่ละสไลด์สามารถใช้ [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). โดยปฏิบัติแล้ว ธีมที่ใช้จริงสำหรับสไลด์จะถูกกำหนดผ่านห่วงโซ่การสืบทอดนี้: ธีมการนำเสนอ → การเขียนทับของมาสเตอร์ → การเขียนทับของเลย์เอาต์ → การเขียนทับของสไลด์

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

ส่วนต่อไปนี้จะแสดงเวิร์กโฟลว์ธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้รับการแก้ไขแล้ว

## **ตรวจสอบธีม**

อ็อบเจ็กต์ [MasterTheme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/mastertheme/) เปิดเผยเมธอด [get_ColorScheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), และ [get_FormatScheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) ของธีม การตรวจสอบคอลเลกชันเหล่านี้ก่อนการแก้ไขเป็นประโยชน์อย่างยิ่งเมื่อการนำเสนอมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติเบื้องต้นของธีมและรายงานจำนวนสไตล์พื้นหลัง, เติม, เส้น, และเอฟเฟกต์ที่จัดเก็บอยู่ในธีม:

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

หากไฟล์ใช้หลายมาสเตอร์ อย่ายืนยันว่าทุกสไลด์มีธีมที่มีผลเหมือนกัน ตรวจสอบมาสเตอร์ที่สัมพันธ์กับสไลด์ และใช้เวิร์กโฟลว์ธีมที่มีผลที่แสดงต่อไปในบทความนี้เมื่อมีการเขียนทับของเลย์เอาต์หรือสไลด์

## **เปลี่ยนสีของธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีเชิงตรรกะจากรายการ [SchemeColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [IColorScheme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/icolorscheme/) ของธีม, ทุกอ็อบเจ็กต์ที่ยังอ้างอิงสีของธีมนั้นจะได้รับการประมวลผลใหม่ตามค่าที่เปลี่ยน แต่อ็อบเจ็กต์ที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัปเดตสีธีม

ตัวอย่างต่อไปนี้เป็นตัวอย่างแบบครบวงจรที่สร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีเติมที่มีผล:

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

เพราะสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4`, สีที่มองเห็นจะกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสคีมด้วยสีโดยตรงบนรูปทรง การเปลี่ยนแปลงในภายหลังของ `Accent4` จะไม่กระทบต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างสีที่อ่อนและเข้มจากสีธีมโดยการใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน [ColorTransformOperation](https://reference.aspose.com/slides/th/cpp/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - สีอ่อนและสีเข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอิงจาก `Accent4`, ทำการแปลงความสว่างสำหรับห้ารูป, และบันทึกผลลัพธ์:

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

รูปแบบเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` มีการเปลี่ยนแปลงในภายหลัง สีที่แปลงจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมปค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

รายการ [SchemeColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2`, ในขณะที่ [IColorScheme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2`. การแมปเป็นค่าคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่ถูกแปลงแบบไดนามิกจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่ง

## **เปลี่ยนฟอนต์ของธีม**

สคีมฟอนต์ของธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับข้อความตัว本文. เมธอด [FontScheme::get_Major()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/fontscheme/get_major/) และ [FontScheme::get_Minor()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/fontscheme/get_minor/) เปิดเผยชุดเหล่านั้น

ตัวระบุฟอนต์ธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความ:

* `+mn-lt` - ฟอนต์ 본문 ละติน (Minor Latin Font)
* `+mj-lt` - ฟอนต์หัวเรื่อง ละติน (Major Latin Font)
* `+mn-ea` - ฟอนต์ 본문 เอเชียตะวันออก (Minor East Asian Font)
* `+mj-ea` - ฟอนต์หัวเรื่อง เอเชียตะวันออก (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้ฟอนต์ละตินหลักของธีมและบรรทัด 본문 หนึ่งที่ใช้ฟอนต์ละตินรองของธีม จากนั้นเปลี่ยนฟอนต์ธีมและบันทึกผลลัพธ์:

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

หัวเรื่องใช้ฟอนต์หลักและข้อความ 본문 ใช้ฟอนต์รอง ข้อความที่ระบุชื่อฟอนต์อย่างชัดเจนแทนตัวระบุธีมจะไม่สลับโดยอัตโนมัติเมื่อสคีมฟอนต์ธีมเปลี่ยน

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์การนำเสนอ โปรดดู [PowerPoint Fonts](/slides/th/cpp/powerpoint-fonts/).
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

มีสองเวิร์กโฟลว์ที่พบบ่อยและแก้ปัญหาที่แตกต่างกัน

### **เก็บธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังการนำเสนออื่นและต้องการรักษาการออกแบบเดิมไว้ ให cloned มาสเตอร์ต้นฉบับไปยังการนำเสนอเป้าหมายด้วย [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslidecollection/addclone/), จากนั้น cloned สไลด์ด้วย [ISlideCollection::AddClone()](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) และมาสเตอร์ที่ cloned นี้ การทำเช่นนี้จะพัดมาสเตอร์, เลย์เอาต์, และธีมที่สัมพันธ์ไปด้วย

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

นี่เป็นเวิร์กโฟลว์ที่แนะนำเมื่อสไลด์ต้นฉบับต้องดูเหมือนเดิมในเป้าหมาย การทำคล cloning เนื้อหาไปยังมาสเตอร์เป้าหมายที่ไม่มีความสัมพันธ์อาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลง

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลย์เอาต์ปัจจุบัน ให้เริ่มต้นการเขียนทับระดับสไลด์จากธีมต้นฉบับ เมธอด [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), และ [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) คัดลอกส่วนประกอบธีมหลักทั้งสามเข้าสู่การเขียนทับ

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

วิธีนี้เปลี่ยนธีมที่ใช้โดยสไลด์นั้นโดยไม่กระทบต่อธีมที่สืบทอดโดยสไลด์อื่น ๆ เพื่อเอาการเขียนทับระดับท้องถิ่นออกและกลับไปยังค่าที่สืบทอด ให้เรียก [OverrideTheme::Clear()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/overridetheme/clear/)

### **ใช้การเขียนทับธีมกับเลย์เอาต์**

การเขียนทับระดับเลย์เอาต์จะใช้กับสไลด์ที่ใช้เลย์เอาต์นั้น ยกเว้นสไลด์ที่มีการเขียนทับของตนเอง เมธอดเริ่มต้นเดียวกันสามารถใช้ผ่าน [IOverrideThemeManager](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ioverridethememanager/) ของเลย์เอาต์ได้:

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

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อต้องการให้หลายเลย์เอาต์และสไลด์แชร์การออกแบบฐานเดียวกัน ใช้การเขียนทับระดับเลย์เอาต์เมื่อกลุ่มเลย์เอาต์ต้องการสไตล์ที่แตกต่าง และใช้การเขียนทับระดับสไลด์เฉพาะเมื่อมีข้อยกเว้นจริง ๆ การเขียนทับระดับสไลด์มากเกินไปทำให้การเปลี่ยนแปลงธีมทั่วโลกในภายหลังคาดเดายาก

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกจัดเก็บใน [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการกำหนดการเติมที่จัดเก็บในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่จัดเก็บและค่าปัจจุบันของ [Background::get_StyleIndex()](https://reference.aspose.com/slides/th/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` ใช้ค่า `0` สำหรับไม่มีการเติมธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม ซึ่งแตกต่างจากการใช้ดัชนีคอลเลกชัน C++ โดยตรงด้วย `idx_get(0)` ที่ `0` หมายถึงรายการแรกที่จัดเก็บ อย่ายืนยันว่าการนำเสนอทุกไฟล์มีจำนวนสไตล์การเติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มีอยู่, กำหนดการอ้างอิงพื้นหลังที่มีธีมให้กับมาสเตอร์แรก, และบันทึกการนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการเขียนทับพื้นหลังที่เลย์เอาต์หรือระดับสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังของมาสเตอร์เท่านั้นอาจไม่กระทบต่อสไลด์นั้น ใช้ [Background::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/background/geteffective/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอดถูกนำไปใช้

{{% alert color="warning" title="Warning" %}}
อย่าใช้ `StyleIndex` เป็นดัชนีคอลเลกชันที่เริ่มจากศูนย์ อีกทั้งหลีกเลี่ยงการกำหนดหมายเลขสไตล์โดยตรงจากไฟล์หนึ่งแล้วสมมติว่ามีรูปร่างเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ของธีมเป็นลักษณะเฉพาะของการนำเสนอ
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง โปรดดู [Presentation Background](/slides/th/cpp/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สคีมรูปแบบของธีมประกอบด้วยคอลเลกชันแยกต่างหากของ [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/formatscheme/get_linestyles/), และ [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). ธีม Office ทั่วไปมักมีรายการสไตล์หลักสามรายการที่สื่อถึงการจัดรูปแบบแบบ Subtle, Moderate, และ Intense อย่างไรก็ตาม โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติว่ามีจำนวนคงที่

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน C++ ดัชนีคอลเลกชันเริ่มจากศูนย์: `idx_get(0)` เป็นสไตล์แรกที่จัดเก็บและ `idx_get(2)` เป็นสไตล์ที่สาม ดัชนีอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกต่างหากที่เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapestyle/). การแก้ไขสไตล์ธีมจะส่งผลต่อรูปทรงที่อ้างอิงสไตล์นั้น; รูปทรงที่มีการจัดรูปแบบโดยตรงอาจไม่เปลี่ยน

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดเงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงานอกด้วยระยะ 10 pt ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นอยู่กับว่ารูปทรงแต่ละรูปอ้างอิงช่องสไตล์ใดและการจัดรูปแบบโดยตรงจะเขียนทับธีมหรือไม่

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **อ่านค่าที่มีผลของธีม**

อ็อบเจ็กต์ธีมดิบบอกคุณว่ามีการกำหนดอะไรที่ระดับใดระดับหนึ่ง ค่าที่มีผลบอกคุณว่าสไลด์หรือรูปทรงใช้ค่าอะไรจริง ๆ หลังจากการสืบทอดและการเขียนทับในระดับท้องถิ่นได้ถูกแก้ไขแล้ว สำหรับสไลด์ ให้เรียก [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). สำหรับพื้นหลัง ใช้ [Background::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/background/geteffective/), และสำหรับเติม ใช้ [FillFormat::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/geteffective/)

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบความถูกต้อง, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_mastertheme/) คุณอาจพลาดการเขียนทับของมาสเตอร์, เลย์เอาต์, สไลด์, หรือรูปทรงที่ทำให้ลักษณะสุดท้ายเปลี่ยนไป

## **FAQ**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ใช้ [IOverrideThemeManager](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ioverridethememanager/) ของสไลด์และเริ่มต้นธีมการเขียนทับของมัน การเปลี่ยนแปลงจะคงอยู่เฉพาะสไลด์นั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมที่มีอยู่

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และต้องการรักษาลักษณะเดิมของต้นฉบับ ให้คล clones มาสเตอร์ต้นฉบับไปยังปลายทางและคล clones สไลด์พร้อมมาสเตอร์นั้นด้วย [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslidecollection/addclone/) และ [ISlideCollection::AddClone()](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/). วิธีนี้จะรักษามาสเตอร์, เลย์เอาต์, และธีมไว้ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้อย่างไร?**

ใช้ [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) สำหรับสไลด์หรือธีมเลย์เอาต์และเมธอดข้อมูลที่มีผลที่สอดคล้องสำหรับออบเจ็กต์รูปแบบ เช่น [Background::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/background/geteffective/) และ [FillFormat::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/geteffective/). API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการเขียนทับถูกนำไปใช้.