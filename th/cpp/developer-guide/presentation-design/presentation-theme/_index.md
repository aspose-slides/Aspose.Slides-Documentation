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
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ C++ เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมการนำเสนอกำหนดคุณสมบัติขององค์ประกอบการออกแบบ เมื่อคุณเลือกธีมการนำเสนอ คุณกำลังเลือกเซตขององค์ประกอบภาพและคุณสมบัติเฉพาะของมัน

ใน PowerPoint ธีมประกอบด้วยสี, [แบบอักษร](/slides/th/cpp/powerpoint-fonts/), [สไตล์พื้นหลัง](/slides/th/cpp/presentation-background/), และเอฟเฟกต์

![theme-constituents](theme-constituents.png)

## **เปลี่ยนสีธีม**

ธีม PowerPoint ใช้ชุดสีเฉพาะสำหรับองค์ประกอบต่าง ๆ บนสไลด์ หากคุณไม่ชอบสีเหล่านั้น คุณสามารถเปลี่ยนสีโดยการกำหนดสีใหม่ให้กับธีม เพื่อให้คุณสามารถเลือกสีธีมใหม่ Aspose.Slides มีค่าที่อยู่ภายใต้การนับจำนวน [SchemeColor](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28)

โค้ด C++ นี้แสดงวิธีการเปลี่ยนสีเน้นสำหรับธีม:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

คุณสามารถกำหนดค่าที่มีผลของสีที่ได้จากผลลัพธ์ได้ดังนี้:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto fillEffective = shape->get_FillFormat()->GetEffective();

Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (สี [A=255, R=128, G=100, B=162])
```

เพื่อแสดงการเปลี่ยนสีเพิ่มเติม เราจะสร้างองค์ประกอบอีกอันหนึ่งและกำหนดสีเน้น (จากการดำเนินการเริ่มต้น) ให้กับมัน จากนั้นเปลี่ยนสีในธีม:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();

auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);

otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

สีใหม่จะถูกนำไปใช้โดยอัตโนมัติบนทั้งสององค์ประกอบ

### **ตั้งค่าสีธีมจากพาเลทเพิ่มเติม**

เมื่อคุณทำการแปลงความสว่างให้กับสีธีมหลัก(1) จะได้สีจากพาเลทเพิ่มเติม(2) คุณจึงสามารถตั้งค่าและดึงค่าสีธีมเหล่านั้นได้

![additional-palette-colors](additional-palette-colors.png)

**1**- สีธีมหลัก

**2**- สีจากพาเลทเพิ่มเติม

โค้ด C++ นี้แสดงการดำเนินการที่ดึงสีจากพาเลทเพิ่มเติมโดยอ้างอิงจากสีธีมหลักและนำไปใช้ในรูปทรง:

```c++
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

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Lighter 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Lighter 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Lighter 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Darker 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Darker 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **แมป `SchemeColor` ไปยังสี `IColorScheme`**

เมื่อคุณทำงานกับ [SchemeColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/schemecolor/) คุณอาจสังเกตว่ามีค่าธีมสีต่อไปนี้:

`Background1`, `Background2`, `Text1`, และ `Text2`.

แต่ `Presentation::get_MasterTheme()::get_ColorScheme()` จะคืนค่า [IColorScheme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/icolorscheme/) ซึ่งเปิดเผยสีที่สอดคล้องกันเป็น:

`Dark1`, `Dark2`, `Light1`, และ `Light2`.

ความแตกต่างนี้เพียงแค่ชื่อเท่านั้น ค่าดังกล่าวอ้างอิงถึงช่องสีธีมเดียวกันและการแมปถูกกำหนดไว้คงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ไม่มีการแปลงแบบไดนามิกระหว่าง `Text`/`Background` กับ `Dark`/`Light` เพียงแต่เป็นชื่อทางเลือกที่ใช้แทนสีธีมเดียวกัน

ความแตกต่างของชื่อเหล่านี้มาจากศัพท์ของ Microsoft Office เวอร์ชันเก่าใช้ `Dark 1`, `Light 1`, `Dark 2`, `Light 2` ส่วนเวอร์ชัน UI ใหม่นำเสนอช่องเดียวกันเป็น `Text 1`, `Background 1`, `Text 2`, `Background 2`

## **เปลี่ยนแบบอักษรธีม**

เพื่อให้คุณเลือกแบบอักษรสำหรับธีมและการใช้งานอื่น ๆ Aspose.Slides ใช้ตัวระบุพิเศษเหล่านี้ (คล้ายกับที่ใช้ใน PowerPoint):

* **+mn-lt** - Body Font Latin (Minor Latin Font)
* **+mj-lt** - Heading Font Latin (Major Latin Font)
* **+mn-ea** - Body Font East Asian (Minor East Asian Font)
* **+mj-ea** - Body Font East Asian (Major East Asian Font)

โค้ด C++ นี้แสดงวิธีการกำหนดแบบอักษร Latin ให้กับองค์ประกอบของธีม:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

โค้ด C++ นี้แสดงวิธีการเปลี่ยนแบบอักษรธีมของการนำเสนอ:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

แบบอักษรในกล่องข้อความทั้งหมดจะถูกอัปเดต

{{% alert color="info" title="TIP" %}} 

คุณอาจต้องการดู [PowerPoint fonts](/slides/th/cpp/powerpoint-fonts/)

{{% /alert %}}

## **เปลี่ยนสไตล์พื้นหลังธีม**

โดยค่าเริ่มต้น แอพ PowerPoint มีพื้นหลังที่กำหนดล่วงหน้า 12 แบบ แต่จะบันทึกไว้เพียง 3 แบบจาก 12 แบบในงานนำเสนอทั่วไป

![todo:image_alt_text](presentation-design_8.png)

เช่น หลังจากคุณบันทึกงานนำเสนอในแอพ PowerPoint คุณสามารถรันโค้ด C++ นี้เพื่อหาจำนวนพื้นหลังที่กำหนดล่วงหน้าในงานนำเสนอ:

```c++
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Theme;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 

โดยใช้คุณสมบัติ [BackgroundFillStyles](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.theme.i_format_scheme/) คุณสามารถเพิ่มหรือเข้าถึงสไตล์พื้นหลังในธีม PowerPoint

{{% /alert %}}

โค้ด C++ นี้แสดงวิธีการตั้งค่าพื้นหลังสำหรับการนำเสนอ:

```c++
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**คู่มือดัชนี**: 0 ใช้สำหรับไม่มีการเติม สี ดัชนีเริ่มจาก 1

{{% alert color="info" title="TIP" %}} 

คุณอาจต้องการดู [PowerPoint Background](/slides/th/cpp/presentation-background/)

{{% /alert %}}

## **เปลี่ยนเอฟเฟกต์ธีม**

ธีม PowerPoint ปกติมีค่า 3 ค่าในแต่ละอาเรย์สไตล์ ซึ่งอาเรย์เหล่านี้จะถูกรวมเป็น 3 เอฟเฟกต์: Subtle, Moderate, และ Intense ตัวอย่างเช่น นี่คือผลลัพธ์เมื่อเอฟเฟกต์ถูกนำไปใช้กับรูปทรงเฉพาะ:

![todo:image_alt_text](presentation-design_10.png)

โดยใช้ 3 คุณสมบัติ ([FillStyles](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.theme.i_format_scheme/) คุณสามารถเปลี่ยนองค์ประกอบในธีมได้ (ยืดหยุ่นกว่าตัวเลือกใน PowerPoint)

โค้ด C++ นี้แสดงวิธีการเปลี่ยนเอฟเฟกต์ธีมโดยการแก้ไขส่วนต่าง ๆ ขององค์ประกอบ:

```c++
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
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
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");

pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

การเปลี่ยนแปลงที่เกิดขึ้นในสีเติม, ประเภทการเติม, เอฟเฟกต์เงา ฯลฯ:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?

ได้ Aspose.Slides รองรับการกำหนดธีมระดับสไลด์ ทำให้คุณสามารถใช้ธีมท้องถิ่นกับสไลด์นั้นโดยไม่กระทบธีมมาสเตอร์ (ผ่าน [SlideThemeManager](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/slidethememanager/))

### วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานหนึ่งคืออะไร?

[Clone slides](/slides/th/cpp/clone-slides/) พร้อมกับมาสเตอร์ของมันไปยังงานนำเป้าหมาย วิธีนี้จะคงมาสเตอร์, Layouts, และธีมที่สัมพันธ์กัน ทำให้ลักษณะการแสดงผลคงที่

### ฉันจะดูค่าที่ “effective” หลังจากการสืบทอดและการทับทั้งหมดได้อย่างไร?

ใช้ “effective” view ของ API [/slides/th/cpp/shape-effective-properties/] สำหรับธีม/สี/แบบอักษร/เอฟเฟกต์ เพื่อรับค่าคุณสมบัติขั้นสุดท้ายที่ได้จากการประยุกต์มาสเตอร์และการทับในระดับท้องถิ่น