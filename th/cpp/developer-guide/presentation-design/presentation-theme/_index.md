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
- พาเล็ตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ C++ เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint พร้อมแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมการนำเสนอกำหนดคุณสมบัติขององค์ประกอบการออกแบบ เมื่อคุณเลือกธีมการนำเสนอ คุณกำลังเลือกชุดขององค์ประกอบภาพและคุณสมบัติเฉพาะของมัน

ใน PowerPoint ธีมประกอบด้วยสี, [ฟอนต์](/slides/th/cpp/powerpoint-fonts/), [สไตล์พื้นหลัง](/slides/th/cpp/presentation-background/), และเอฟเฟกต์

![ส่วนประกอบของธีม](theme-constituents.png)

## **เปลี่ยนสีธีม**

ธีม PowerPoint ใช้ชุดสีเฉพาะสำหรับองค์ประกอบต่างๆ บนสไลด์ หากคุณไม่ชอบสีเหล่านั้น คุณสามารถเปลี่ยนสีโดยการกำหนดสีใหม่ให้กับธีม เพื่อให้คุณเลือกสีธีมใหม่ Aspose.Slides มีค่าที่ให้เลือกภายใต้ enumeration [SchemeColor](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28)

โค้ด C++ นี้แสดงวิธีเปลี่ยนสีอักเซนต์ของธีม:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

คุณสามารถกำหนดค่าที่มีผลของสีที่ได้โดยวิธีนี้:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (สี [A=255, R=128, G=100, B=162])
```

เพื่อสาธิตการเปลี่ยนสีต่อไป เราจะสร้างองค์ประกอบอื่นและกำหนดสีอักเซนต์ (จากการดำเนินการแรก) ให้กับมัน จากนั้นเปลี่ยนสีในธีม:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

สีใหม่จะถูกนำไปใช้โดยอัตโนมัติบนทั้งสององค์ประกอบ

### **ตั้งค่าสีธีมจากพาเล็ตเพิ่มเติม**

เมื่อคุณใช้การแปลงความสว่างกับสีธีมหลัก(1) จะสร้างสีจากพาเล็ตเพิ่มเติม(2) คุณจึงสามารถตั้งค่าและดึงค่าสีธีมเหล่านั้นได้

![สีจากพาเล็ตเพิ่มเติม](additional-palette-colors.png)

**1**- สีธีมหลัก  
**2**- สีจากพาเล็ตเพิ่มเติม  

โค้ด C++ นี้แสดงการดึงสีพาเล็ตเพิ่มเติมจากสีธีมหลักและใช้ในรูปร่าง:

```c++
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

เมื่อคุณทำงานกับ [SchemeColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/schemecolor/) คุณอาจสังเกตว่ามีค่าธีมสีต่อไปนี้: `Background1`, `Background2`, `Text1`, และ `Text2`  

อย่างไรก็ตาม `Presentation::get_MasterTheme()::get_ColorScheme()` จะคืนค่า [IColorScheme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/icolorscheme/) ซึ่งเปิดเผยสีที่สอดคล้องกันเป็น: `Dark1`, `Dark2`, `Light1`, และ `Light2`

ความแตกต่างนี้เป็นเพียงชื่อเท่านั้น ค่าดังกล่าวอ้างอิงถึงตำแหน่งสีธีมเดียวกันและการแมปคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ไม่มีการแปลงแบบไดนามิกระหว่าง `Text`/`Background` กับ `Dark`/`Light` พวกมันเป็นชื่อทางเลือกของสีธีมเดียวกันเท่านั้น

ความแตกต่างของชื่อเหล่านี้มาจากคำศัพท์ของ Microsoft Office รุ่นเก่าใช้ `Dark 1`, `Light 1`, `Dark 2`, `Light 2` ในขณะที่ UI รุ่นใหม่แสดงตำแหน่งเดียวกันเป็น `Text 1`, `Background 1`, `Text 2`, `Background 2`

## **เปลี่ยนฟอนต์ธีม**

เพื่อให้คุณเลือกฟอนต์สำหรับธีมและวัตถุประสงค์อื่นๆ Aspose.Slides ใช้ตัวระบุตัวพิเศษเหล่านี้ (คล้ายกับที่ใช้ใน PowerPoint):

* **+mn-lt** - ฟอนต์ส่วนข้อความ ลาติน (ฟอนต์ลาตินรอง)
* **+mj-lt** - ฟอนต์ส่วนหัว ลาติน (ฟอนต์ลาตินหลัก)
* **+mn-ea** - ฟอนต์ส่วนข้อความ เอเชียตะวันออก (ฟอนต์เอเชียตะวันออกรอง)
* **+mj-ea** - ฟอนต์ส่วนหัว เอเชียตะวันออก (ฟอนต์เอเชียตะวันออกหลัก)

โค้ด C++ นี้แสดงวิธีกำหนดฟอนต์ลาตินให้กับองค์ประกอบธีม:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

โค้ด C++ นี้แสดงวิธีเปลี่ยนฟอนต์ธีมของการนำเสนอ:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

ฟอนต์ในกล่องข้อความทั้งหมดจะได้รับการอัปเดต

{{% alert color="primary" title="TIP" %}} 
คุณอาจต้องการดู [ฟอนต์ PowerPoint](/slides/th/cpp/powerpoint-fonts/). 
{{% /alert %}}

## **เปลี่ยนสไตล์พื้นหลังธีม**

โดยค่าเริ่มต้น แอป PowerPoint ให้พื้นหลังกำหนดล่วงหน้า 12 แบบ แต่เพียง 3 แบบจาก 12 แบบนั้นจะถูกบันทึกในงานนำเสนอทั่วไป

![todo:image_alt_text](presentation-design_8.png)

ตัวอย่างเช่น หลังจากคุณบันทึกงานนำเสนอในแอป PowerPoint คุณสามารถรันโค้ด C++ นี้เพื่อค้นหาจำนวนพื้นหลังกำหนดล่วงหน้าในงานนำเสนอ:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
โดยใช้คุณสมบัติ [BackgroundFillStyles](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.theme.i_format_scheme/) คุณสามารถเพิ่มหรือเข้าถึงสไตล์พื้นหลังในธีม PowerPoint ได้ 
{{% /alert %}}

โค้ด C++ นี้แสดงวิธีตั้งค่าพื้นหลังสำหรับงานนำเสนอ:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**คู่มือดัชนี**: 0 ใช้สำหรับไม่มีการเติม ดัชนีเริ่มจาก 1

{{% alert color="primary" title="TIP" %}} 
คุณอาจต้องการดู [พื้นหลัง PowerPoint](/slides/th/cpp/presentation-background/). 
{{% /alert %}}

## **เปลี่ยนเอฟเฟกต์ธีม**

ธีม PowerPoint มักมีค่า 3 ค่าในแต่ละอาร์เรย์สไตล์ ซึ่งอาร์เรย์เหล่านี้จะรวมเป็น 3 เอฟเฟกต์: ละเอียดอ่อน, ปานกลาง, และเข้มข้น ตัวอย่างเช่น นี่คือผลลัพธ์เมื่อเอฟเฟกต์ถูกนำไปใช้กับรูปร่างเฉพาะ:

![todo:image_alt_text](presentation-design_10.png)

โดยใช้คุณสมบัติ 3 อย่าง ([FillStyles](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.theme.i_format_scheme/) คุณสามารถเปลี่ยนส่วนต่างๆ ของธีมได้อย่างยืดหยุ่นกว่าใน PowerPoint

โค้ด C++ นี้แสดงวิธีเปลี่ยนเอฟเฟกต์ธีมโดยการปรับส่วนขององค์ประกอบ:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

การเปลี่ยนแปลงที่เกิดขึ้นในสีเติม, ประเภทการเติม, เอฟเฟกต์เงา ฯลฯ :

![todo:image_alt_text](presentation-design_11.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้ Aspose.Slides รองรับการแทนที่ธีมระดับสไลด์ ดังนั้นคุณสามารถใช้ธีมเฉพาะกับสไลด์นั้นโดยคงธีมมาสเตอร์ไว้ (ผ่าน [SlideThemeManager](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/slidethememanager/))

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งคืออะไร?**

[คัดลอกสไลด์](/slides/th/cpp/clone-slides/) พร้อมกับมาสเตอร์ของมันไปยังงานนำเป้าหมาย วิธีนี้จะรักษามาสเตอร์, เลย์เอาต์, และธีมที่เกี่ยวข้องไว้ ทำให้ลักษณะที่ปรากฏคงที่

**ฉันจะดูค่าที่ “effective” หลังจากการสืบทอดและการแทนที่ทั้งหมดได้อย่างไร?**

ใช้วิว ["effective"](/slides/th/cpp/shape-effective-properties/) ของ API สำหรับธีม/สี/ฟอนต์/เอฟเฟกต์ ซึ่งจะคืนค่าคุณสมบัติสุดท้ายที่ถูกแก้ไขหลังจากนำมาสเตอร์และการแทนที่ในระดับท้องถิ่นเรียบร้อยแล้ว.