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
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอหลักใน Aspose.Slides สำหรับ C++ เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมของงานนำเสนอกำหนดชุดสี, แบบอักษร, สไตล์พื้นหลัง, การเติม, เส้น และเอฟเฟกต์ที่ประสานกัน วัตถุตระหนักธีมจะอ้างอิงคำนิยามที่แชร์เหล่านี้แทนการเก็บคุณสมบัติการแสดงผลแต่ละอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมสามารถอัปเดตวัตถุหลายรายการพร้อมกันได้

ใน Aspose.Slides, ธีมระดับงานนำเสนอสามารถเข้าถึงได้ผ่าน[Presentation::get_MasterTheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_mastertheme/). งานนำเสนออาจมีการแทนที่ธีมในระดับล่างได้ มาสเตอร์สามารถแทนที่ธีมของงานนำเสนอผ่าน[MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), ในขณะที่เลย์เอาต์หรือสไลด์เดี่ยวสามารถใช้[IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). โดยปฏิบัติ ธีมที่มีผลสำหรับสไลด์จะถูกกำหนดผ่านสายการสืบทอดนี้: ธีมงานนำเสนอ, การแทนที่ของมาสเตอร์, การแทนที่ของเลย์เอาต์, และการแทนที่ของสไลด์

![ส่วนประกอบของธีม: สี, แบบอักษร, สไตล์พื้นหลัง, และเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงขั้นตอนการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้รับการแก้ไขแล้ว

## **ตรวจสอบธีม**

วัตถุ[MasterTheme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/mastertheme/) เปิดเผยเมธอด[get_ColorScheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), และ[get_FormatScheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) ของธีม การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์โดยเฉพาะเมื่อไฟล์งานนำมาจากแหล่งภายนอก เพราะจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, เติม, เส้น, และเอฟเฟกต์ที่จัดเก็บในธีม:

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

หากไฟล์ใช้มาสเตอร์หลายตัว อย่ากล่าวสรุปว่าทุกสไลด์มีธีมที่มีผลเหมือนกัน ตรวจสอบมาสเตอร์ที่เชื่อมกับสไลด์และใช้ขั้นตอนการทำงานของธีมที่มีผลที่แสดงต่อไปในบทความนี้เมื่ออาจมีการแทนที่ที่ระดับเลย์เอาต์หรือสไลด์

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่ตระหนักธีมสามารถอ้างอิงสีตรรกะจาก enumeration[SchemeColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันในธีมของ[IColorScheme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/icolorscheme/), ทุกวัตถุที่ยังอ้างอิงสีธีมนั้นจะได้รับค่าใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนโดยการอัปเดตสีธีม

ตัวอย่างต่อไปนี้สร้างรูปทรงที่ใช้`Accent4`, เปลี่ยนสีธีม`Accent4`เป็นสีแดง, บันทึกงานนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีเติมที่มีผล:

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

เนื่องจากสี่เหลี่ยมยังเชื่อมต่อกับ`Accent4`, สีที่มองเห็นจะกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสคีมด้วยสีโดยตรงบนรูปทรง การเปลี่ยนแปลงต่อไปของ`Accent4` จะไม่ส่งผลต่อเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันสีอิ่มและสีเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน[ColorTransformOperation](https://reference.aspose.com/slides/th/cpp/aspose.slides/colortransformoperation/)

![สีธีมหลักและสีอิ่มและสีเข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - เวอร์ชันสีอิ่มและสีเข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างหกสี่เหลี่ยมตาม`Accent4`, ใช้การแปลงความสว่างกับห้าสี่เหลี่ยม, แล้วบันทึกผลลัพธ์:

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

เวอร์ชันเหล่านี้ยังคงอิงจากสีธีม หาก`Accent4`เปลี่ยนในภายหลัง สีที่แปลงจะถูกคำนวณใหม่จากค่า`Accent4`ใหม่

### **แม็พค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration[SchemeColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/schemecolor/) ใช้`Text1`, `Background1`, `Text2`, และ`Background2`, ในขณะที่[IColorScheme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น`Dark1`, `Light1`, `Dark2`, และ`Light2`. การแม็พคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ใช่ค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งไปอีกรูปแบบหนึ่ง

## **เปลี่ยนแบบอักษรธีม**

สกีมแบบอักษรธีมประกอบด้วยชุดแบบอักษรหลักสำหรับหัวเรื่องและชุดแบบอักษรรองสำหรับเนื้อหาเนื้อความ เมธอด[FontScheme::get_Major()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/fontscheme/get_major/) และ[FontScheme::get_Minor()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/fontscheme/get_minor/) เปิดเผยชุดเหล่านั้น

ตัวระบุแบบอักษรธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในการฟอร์แมตข้อความ:

* `+mn-lt` - แบบอักษรตัวอักษรหลัก Body Font Latin (Minor Latin Font)
* `+mj-lt` - แบบอักษรหัวเรื่อง Heading Font Latin (Major Latin Font)
* `+mn-ea` - แบบอักษร Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - แบบอักษร Heading Font East Asian (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้แบบอักษร Latin หลักและบรรทัดเนื้อความหนึ่งที่ใช้แบบอักษร Latin รอง แล้วเปลี่ยนแบบอักษรธีมและบันทึกผลลัพธ์:

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

หัวเรื่องใช้แบบอักษรหลักและข้อความใช้แบบอักษรรอง ข้อความที่มีชื่อแบบอักษรโดยตรงแทนที่ตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อสกีมแบบอักษรธีมเปลี่ยน

คอลเลกชันแบบอักษรหลักและรองสามารถมีการแม็พแบบอักษรสำหรับระบบเขียนแต่ละระบบ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana หากต้องการตรวจสอบ, เพิ่ม, แทนที่ หรือเอาการแม็พเหล่านี้ออก ดู[Script-Specific Theme Fonts](/slides/th/cpp/script-specific-font-mappings/)

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรในงานนำเสนอ ดู[PowerPoint Fonts](/slides/th/cpp/powerpoint-fonts/)
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

ขั้นตอนงานต่อไปนี้แก้ไขปัญหาที่เกี่ยวกับธีมต่าง ๆ

### **ใช้ธีมภายนอกกับสไลด์ที่พึ่งพามาสเตอร์**

ใช้[IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/)เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์ทุกสไลด์ที่พึ่งพามาสเตอร์เฉพาะเลือกมาสเตอร์จากคอลเลกชัน[Presentation::get_Masters](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_masters/) ซึ่งทำหน้าที่เป็น[IMasterSlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslidecollection/), แล้วส่งพาธไฟล์ธีมไปยังเมธอด

เมธอดทำงานต่อไปนี้:

1. สร้างมาสเตอร์สไลด์ใหม่จากมาสเตอร์ที่เลือก
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่เคยพึ่งพามาสเตอร์ที่เลือก
1. คืนค่า[IMasterSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslide/)ที่สร้างใหม่

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่พึ่งพามาสเตอร์แรกและบันทึกงานนำเสนอ:

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

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด[PptxException](https://reference.aspose.com/slides/th/cpp/aspose.slides/pptxexception/)หรือคลาสย่อยที่เกี่ยวกับรูปแบบ ตรวจสอบพาธที่ผู้ใช้ระบุ, จัดการความล้มเหลวในการเข้าถึงระบบไฟล์, และบันทึกงานนำเสนอเมื่อธีมถูกใช้สำเร็จเท่านั้น

เฉพาะสไลด์ที่พึ่งพามาสเตอร์ที่เลือกเท่านั้นที่จะถูกเปลี่ยน มาสเตอร์อื่น ๆ ยังคงมาสเตอร์และธีมเดิม สี, แบบอักษร, การเติม, เส้น, พื้นหลัง, และเอฟเฟกต์ที่ตระหนักธีมจะอิงกับธีมภายนอก สี, แบบอักษร, การเติม และการฟอร์แมตที่กำหนดโดยตรงอาจคงเดิม การแทนที่ระดับเลย์เอาต์และระดับสไลด์ยังอาจมีลำดับความสำคัญเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่

ธีมอาจอ้างอิงแบบอักษรที่ไม่มีในสภาพแวดล้อมรันไทม์ เพื่อการเรนเดอร์และการส่งออกที่สม่ำเสมอ ให้ติดตั้งแบบอักษรที่ต้องการ, ให้บริการผ่าน[custom font sources](/slides/th/cpp/custom-font/), หรือกำหนดค่า[font substitution](/slides/th/cpp/font-substitution/)

นี่เป็นขั้นตอนระดับมาสเตอร์โดยตรง: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการแทนที่ธีมระดับสไลด์หรือเลย์เอาต์ด้วยตนเอง

### **ใช้ธีมภายนอกที่ต่างกันในงานนำเสนอหลายมาสเตอร์**

เมื่อมาสเตอร์ที่ต้องการไม่ทราบล่วงหน้า ให้ดึงมาสเตอร์จากสไลด์ที่เป็นตัวแทนผ่าน[ISlide::get_LayoutSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/get_layoutslide/)และ[ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/get_masterslide/). เก็บอ้างอิงมาสเตอร์เดิมก่อนการใช้ธีมใด ๆ เพราะแต่ละการเรียกจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อระบุมาสเตอร์และใช้ธีมภายนอกที่ต่างกันกับแต่ละกลุ่ม:

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

การเรียกครั้งแรกมีผลเฉพาะสไลด์ที่พึ่งพา`firstGroupMaster`, การเรียกครั้งที่สองมีผลเฉพาะสไลด์ที่พึ่งพา`secondGroupMaster`. สไลด์ที่เชื่อมกับมาสเตอร์อื่นจะไม่ถูกปรับสไตล์

### **รักษาธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและรักษาการออกแบบเดิม ให้โคลนมาสเตอร์ต้นฉบับเข้าไปในงานนำหมายโดยใช้[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslidecollection/addclone/), จากนั้นโคลนสไลด์ด้วย[ISlideCollection::AddClone()](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/)และมาสเตอร์ที่โคลนไว้ วิธีนี้จะพามาสเตอร์, เลย์เอาต์, และธีมที่เกี่ยวข้องไปด้วย

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

นี่เป็นขั้นตอนที่แนะนำเมื่อสไลด์ต้นฉบับต้องการลักษณะเดียวกันในปลายทาง การโคลนเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, แบบอักษร, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนโดยธีมเปลี่ยนแปลง

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลย์เอาต์ปัจจุบัน ให้เริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นฉบับ เมธอด[OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), และ[OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) คัดลอกสามส่วนหลักของธีมไปยังการแทนที่

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

วิธีนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบธีมที่สืบทอดจากสไลด์อื่น ๆ หากต้องการลบการแทนที่ในระดับท้องถิ่นและคืนค่าเป็นค่าที่สืบทอด ให้เรียก[OverrideTheme::Clear()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/overridetheme/clear/)

### **ใช้การแทนที่ธีมกับเลย์เอาต์**

การแทนที่ระดับเลย์เอาต์มีผลกับสไลด์ที่ใช้เลย์เอาต์นั้น เว้นแต่สไลด์บางตัวจะมีการแทนที่ของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน[IOverrideThemeManager](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ioverridethememanager/) ของเลย์เอาต์ได้:

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

ใช้ธีมระดับมาสเตอร์หรือระดับงานนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ควรแชร์การออกแบบฐานเดียวกัน ใช้การแทนที่เลย์เอาต์เมื่อกลุ่มเลย์เอาต์ต้องการสไตล์ที่แตกต่างและใช้การแทนที่สไลด์เฉพาะเมื่อเป็นข้อยกเว้นจริง การแทนที่ระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมทั่วโลกในภายหลังคาดเดาได้ยากขึ้น

## **อัปเดตสไตล์พื้นหลังของธีม**

สไตล์การเติมพื้นหลังของธีมถูกจัดเก็บใน[FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการเติมที่จัดเก็บในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมงานนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่จัดเก็บและ[Background::get_StyleIndex()](https://reference.aspose.com/slides/th/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` ใช้ค่า `0` เพื่อไม่มีการเติมที่มีธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม ซึ่งต่างจากการเข้าถึงคอลเลกชัน C++ โดยตรงด้วย `idx_get(0)` ที่ `0` หมายถึงรายการแรก อย่าสรุปว่าทุกงานนำเสนอมีจำนวนสไตล์การเติมพื้นหลังเท่าเดิม

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มีอยู่, กำหนดการอ้างอิงพื้นหลังที่มีธีมให้กับมาสเตอร์แรก, และบันทึกงานนำเสนอ:

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

ผลลัพธ์ที่แสดงขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการแทนที่พื้นหลังที่เลย์เอาต์หรือระดับสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังของมาสเตอร์เพียงอย่างเดียวอาจไม่กระทบสไลด์นั้น ใช้[Background::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/background/geteffective/)เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอดถูกนำไปใช้

{{% alert color="warning" title="คำเตือน" %}}
อย่าปฏิบัติเช่น `StyleIndex` เป็นดัชนีคอลเลกชันที่เริ่มจากศูนย์ รวมถึงอย่าเข้ารหัสหมายเลขสไตล์จากไฟล์หนึ่งและสันนิษฐานว่ามีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ของธีมขึ้นกับงานนำเสนอแต่ละไฟล์
{{% /alert %}}

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับการฟอร์แมตพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดู[Presentation Background](/slides/th/cpp/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สกีมรูปแบบของธีมประกอบด้วยคอลเลกชันที่แยกจากกันของ[FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/formatscheme/get_linestyles/), และ[FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) โดยทั่วไปธีมของ Office จะมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการฟอร์แมตแบบละเอียด, ปานกลาง, และเข้ม แต่ควรตรวจสอบแต่ละคอลเลกชันแทนการสันนิษฐานว่ามีจำนวนคงที่

![เอฟเฟกต์ธีมแบบละเอียด, ปานกลาง, และเข้มที่ใช้กับรูปทรงเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน C++ ดัชนีคอลเลกชันเริ่มจากศูนย์: `idx_get(0)` คือสไตล์แรกที่จัดเก็บและ `idx_get(2)` คือสไตล์ที่สาม ดัชนีการอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกต่างหากที่เปิดเผยผ่าน[IShapeStyle](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapestyle/). การแก้ไขสไตล์ธีมส่งผลต่อรูปทรงที่อ้างอิงสไตล์ธีมนั้น; รูปทรงที่มีการฟอร์แมตโดยตรงอาจคงเดิม

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดการใช้เงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงานอกด้วยระยะ 10 จุด ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นกับรูปทรงอ้างอิงช่องใดและการฟอร์แมตโดยตรงที่อาจทับธีม

![สไตล์เอฟเฟกต์ของธีมหลังจากเปลี่ยนเส้น, เติม, และการตั้งค่าการเงา](presentation-design_11.png)

## **อ่านค่าธีมที่มีผล**

วัตถุธีมดิบบอกสิ่งที่กำหนดในระดับใดระดับหนึ่ง ค่าที่มีผลบอกสิ่งที่สไลด์หรือรูปทรงใช้จริงหลังจากการสืบทอดและการแทนที่ในระดับท้องถิ่นได้รับการแก้ไขแล้ว สำหรับสไลด์ ให้เรียก[IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). สำหรับพื้นหลัง ใช้[Background::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/background/geteffective/), และสำหรับการเติม ใช้[FillFormat::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/geteffective/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมรูปแรกจากสไลด์:

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

ใช้ข้อมูลที่มีผลสำหรับการตรวจสอบการเรนเดอร์, การตรวจสอบความถูกต้อง, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ[Presentation::get_MasterTheme()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_mastertheme/), คุณอาจพลาดการแทนที่ที่มาจากมาสเตอร์, เลย์เอาต์, สไลด์, หรือรูปทรงที่เปลี่ยนลักษณะสุดท้าย

## **คำถามที่พบบ่อย**

**การใช้ธีมภายนอกส่งผลต่อทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) จะกำหนดเฉพาะสไลด์ที่พึ่งพามาสเตอร์ที่เลือก สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิม

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ใช้[IOverrideThemeManager](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ioverridethememanager/) ของสไลด์และเริ่มต้นธีมแทนที่ การเปลี่ยนแปลงจะอยู่ในระดับสไลด์เท่านั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมเดิม

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และต้องการรักษาลักษณะต้นฉบับ ให้โคลนมาสเตอร์ต้นฉบับเข้าสู่ปลายทางและโคลนสไลด์พร้อมมาสเตอร์นั้นโดยใช้[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslidecollection/addclone/)และ[ISlideCollection::AddClone()](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/). วิธีนี้ทำให้มาสเตอร์, เลย์เอาต์, และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้อย่างไร?**

ใช้[IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) สำหรับสไลด์หรือธีมเลย์เอาต์และเมธอดข้อมูลที่มีผลที่สอดคล้องสำหรับวัตถุฟอร์แมต เช่น[Background::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/background/geteffective/)และ[FillFormat::GetEffective()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/geteffective/). API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการแทนที่ถูกใช้.