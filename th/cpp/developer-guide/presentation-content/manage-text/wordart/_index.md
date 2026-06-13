---
title: สร้างและใช้เอฟเฟ็กต์ WordArt ใน C++
linktitle: WordArt
type: docs
weight: 110
url: /th/cpp/wordart/
keywords:
- WordArt
- สร้าง WordArt
- แม่แบบ WordArt
- เอฟเฟ็กต์ WordArt
- เอฟเฟ็กต์เงา
- เอฟเฟ็กต์การแสดงผล
- เอฟเฟ็กต์แสงเรืองแสง
- การแปลง WordArt
- เอฟเฟ็กต์ 3 มิติ
- เอฟเฟ็กต์เงานอก
- เอฟเฟ็กต์เงาภายใน
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "สร้างและปรับแต่งเอฟเฟ็กต์ WordArt ใน Aspose.Slides สำหรับ C++. คู่มือขั้นตอนต่อขั้นตอนนี้ช่วยนักพัฒนาเพิ่มประสิทธิภาพการนำเสนอด้วยข้อความมืออาชีพใน C++."
---
## **ภาพรวม**

เอฟเฟ็กต์ WordArt ช่วยให้คุณเพิ่มข้อความที่มีรูปแบบสวยงามและน่ามองเข้าไปในงานนำเสนอ PowerPoint ของคุณ. ด้วย Aspose.Slides นักพัฒนาสามารถสร้าง ปรับแต่ง และจัดการ WordArt อย่างอัตโนมัติได้เช่นเดียวกับใน Microsoft PowerPoint — โดยไม่ต้องติดตั้ง Office. บทความนี้ให้ภาพรวมของการทำงานกับ WordArt รวมถึงวิธีการใช้การแปลงข้อความ, สไตล์การเติม, เส้นขอบ, เงา, และตัวเลือกการจัดรูปแบบอื่น ๆ เพื่อทำให้เนื้อหาการนำเสนอของคุณมีความแสดงออกและดึงดูดมากขึ้น. WordArt ทำให้คุณสามารถจัดการข้อความเป็นวัตถุกราฟิก. มันประกอบด้วยเอฟเฟ็กต์หรือการแก้ไขพิเศษที่นำไปใช้กับข้อความเพื่อทำให้ดูน่าสนใจหรือเด่นขึ้น.

## **สร้างเทมเพลต WordArt ง่ายและนำไปใช้กับข้อความ**

**การใช้ Aspose.Slides** 

แรก, เราสร้างข้อความง่าย ๆ ด้วยโค้ด C++ นี้: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

ตอนนี้, เราตั้งค่าความสูงของฟอนต์ของข้อความให้ใหญ่ขึ้นเพื่อทำให้เอฟเฟ็กต์เด่นชัดขึ้นโดยใช้โค้ดนี้:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**การใช้ Microsoft PowerPoint**

ไปที่เมนูเอฟเฟ็กต์ WordArt ใน Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

จากเมนูทางขวา, คุณสามารถเลือกเอฟเฟ็กต์ WordArt ที่กำหนดล่วงหน้า. จากเมนูทางซ้าย, คุณสามารถระบุการตั้งค่าสำหรับ WordArt ใหม่.

นี่คือบางส่วนของพารามิเตอร์หรือ ตัวเลือกที่มีให้:

![todo:image_alt_text](image-20200930114015-3.png)

**การใช้ Aspose.Slides**

ที่นี่, เราใช้สีแบบ SmallGrid pattern กับข้อความและเพิ่มขอบข้อความสีดำความกว้าง 1 โดยใช้โค้ดนี้:

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

ข้อความที่ได้:

![todo:image_alt_text](image-20200930114108-4.png)

## **ใช้เอฟเฟ็กต์ WordArt อื่น ๆ**

**การใช้ Microsoft PowerPoint**

จากอินเทอร์เฟซของโปรแกรม, คุณสามารถใช้เอฟเฟ็กต์เหล่านี้กับข้อความ, บล็อกข้อความ, รูปร่าง, หรือองค์ประกอบที่คล้ายกัน:

![todo:image_alt_text](image-20200930114129-5.png)

ตัวอย่างเช่น, เอฟเฟ็กต์ Shadow, Reflection, และ Glow สามารถใช้กับข้อความ; เอฟเฟ็กต์ 3D Format และ 3D Rotation สามารถใช้กับบล็อกข้อความ; คุณสมบัติ Soft Edges สามารถใช้กับวัตถุ Shape (ยังคงทำงานแม้ไม่มีการตั้งค่า 3D Format).

### **ใช้เอฟเฟ็กต์เงากับข้อความ**

ที่นี่, เราตั้งค่าคุณสมบัติเกี่ยวกับข้อความเท่านั้น. เราใช้เอฟเฟ็กต์เงากับข้อความโดยใช้โค้ด C++ นี้:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

Aspose.Slides API รองรับประเภทเงา 3 ประเภท: OuterShadow, InnerShadow, และ PresetShadow.

ด้วย PresetShadow, คุณสามารถใช้เงาสำหรับข้อความ (โดยใช้ค่าที่กำหนดไว้แล้ว).

**การใช้ Microsoft PowerPoint**

ใน PowerPoint, คุณสามารถใช้เงาแบบหนึ่งประเภทเท่านั้น. ตัวอย่างเช่น:

![todo:image_alt_text](image-20200930114225-6.png)

**การใช้ Aspose.Slides**

Aspose.Slides จริง ๆ แล้วอนุญาตให้คุณใช้เงาสองประเภทพร้อมกัน: InnerShadow และ PresetShadow.

**หมายเหตุ:**

- เมื่อใช้ OuterShadow และ PresetShadow ร่วมกัน, จะใช้เฉพาะเอฟเฟ็กต์ OuterShadow เท่านั้น.
- หากใช้ OuterShadow และ InnerShadow พร้อมกัน, ผลลัพธ์หรือเอฟเฟ็กต์ที่ใช้ขึ้นอยู่กับเวอร์ชันของ PowerPoint. ตัวอย่างเช่น, ใน PowerPoint 2013, เอฟเฟ็กต์จะเพิ่มเป็นสองเท่า. แต่ใน PowerPoint 2007, จะใช้เอฟเฟ็กต์ OuterShadow.

### **ใช้เอฟเฟ็กต์การสะท้อน**

เราเพิ่มการสะท้อนให้กับข้อความผ่านตัวอย่างโค้ด C++ นี้:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

### **ใช้เอฟเฟ็กต์แสงเรืองแสง**

เรานำเอฟเฟ็กต์ Glow ไปใช้กับข้อความเพื่อทำให้ข้อความสว่างหรือโดดเด่นโดยใช้โค้ดนี้:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

ผลลัพธ์ของการดำเนินการ:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

คุณสามารถเปลี่ยนพารามิเตอร์สำหรับเงา, การแสดงผล, และ Glow. คุณสมบัติของเอฟเฟ็กต์จะถูกตั้งค่าที่แต่ละส่วนของข้อความแยกกัน. 

{{% /alert %}} 

### **ใช้การแปลงใน WordArt**

เราใช้เมธอด set_Transform (ทำงานทั่วบล็อกข้อความทั้งหมด) ผ่านโค้ดนี้:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

ผลลัพธ์:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

ทั้ง Microsoft PowerPoint และ Aspose.Slides สำหรับ C++ มีประเภทการแปลงที่กำหนดล่วงหน้าจำนวนหนึ่ง. 

{{% /alert %}} 

**การใช้ PowerPoint**

เพื่อเข้าถึงประเภทการแปลงที่กำหนดไว้ล่วงหน้า, ไปที่: **Format** -> **TextEffect** -> **Transform**

**การใช้ Aspose.Slides**

เพื่อเลือกประเภทการแปลง, ใช้ enum TextShapeType. 

### **ใช้เอฟเฟ็กต์ 3 มิติกับข้อความและรูปทรง**

เราตั้งค่าเอฟเฟ็กต์ 3D ให้กับรูปทรงข้อความโดยใช้ตัวอย่างโค้ดนี้:

``` cpp 
auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

ข้อความและรูปทรงที่ได้:

![todo:image_alt_text](image-20200930114816-9.png)

เรานำเอฟเฟ็กต์ 3D ไปใช้กับข้อความด้วยโค้ด C++ นี้:

``` cpp 
auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

ผลลัพธ์ของการดำเนินการ:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

การใช้เอฟเฟ็กต์ 3D กับข้อความหรือรูปทรงของข้อความและการโต้ตอบระหว่างเอฟเฟ็กต์นั้นอิงตามกฎบางประการ.

พิจารณาซีนสำหรับข้อความและรูปทรงที่บรรจุข้อความนั้น. เอฟเฟ็กต์ 3D มีส่วนประกอบการแสดงวัตถุ 3D และซีนที่วัตถุถูกวางไว้.

- เมื่อซีนถูกตั้งค่าสำหรับทั้งรูปร่างและข้อความ, ซีนของรูปร่างจะได้ลำดับความสำคัญสูงกว่า — ซีนของข้อความจะถูกละเว้น.
- เมื่อรูปร่างไม่มีซีนของตนเองแต่มีการแสดงผล 3D, จะใช้ซีนของข้อความ.
- มิฉะนั้น — เมื่อรูปทรงเดิมไม่มีเอฟเฟ็กต์ 3D — รูปทรงจะอยู่ในรูปแบบแบนและเอฟเฟ็กต์ 3D จะถูกนำไปใช้เฉพาะกับข้อความ.

คำอธิบายเหล่านี้เชื่อมโยงกับเมธอด ThreeDFormat.getLightRig() และ ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **ใช้เอฟเฟ็กต์เงานอกกับรูปทรง**
Aspose.Slides สำหรับ C++ มีคลาส [**IOuterShadow**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.effects.i_outer_shadow) และ [**IInnerShadow**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.effects.i_inner_shadow) ที่อนุญาตให้คุณใช้เอฟเฟ็กต์เงากับข้อความที่อยู่ใน TextFrame. ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) .
2. ดึงอ้างอิงของสไลด์โดยใช้ดัชนีของมัน.
3. เพิ่ม AutoShape ประเภท Rectangle ลงในสไลด์.
4. เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape.
5. ตั้งค่า FillType ของ AutoShape เป็น NoFill.
6. สร้างอินสแตนซ์ของคลาส OuterShadow.
7. ตั้งค่า BlurRadius ของเงา.
8. ตั้งค่า Direction ของเงา.
9. ตั้งค่า Distance ของเงา.
10. ตั้งค่า RectanglelAlign เป็น TopLeft.
11. ตั้งค่า PresetColor ของเงาเป็น Black.
12. บันทึกการนำเสนอเป็นไฟล์ PPTX.

โค้ดตัวอย่างใน C++ — การดำเนินการตามขั้นตอนข้างต้น — แสดงวิธีใช้เอฟเฟ็กต์เงานอกกับข้อความ:

``` cpp
auto pres = System::MakeObject<Presentation>();
// รับอ้างอิงของสไลด์
auto sld = pres->get_Slides()->idx_get(0);

// เพิ่ม AutoShape ประเภท Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// เพิ่ม TextFrame ลงใน Rectangle
ashp->AddTextFrame(u"Aspose TextBox");

// ปิดการเติมรูปทรงในกรณีที่เราต้องการเงาของข้อความ
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// เพิ่มเงานอกและตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// บันทึกการนำเสนอลงดิสก์
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **ใช้เอฟเฟ็กต์เงาภายในกับรูปทรง**
ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) .
2. ดึงอ้างอิงของสไลด์.
3. เพิ่ม AutoShape ประเภท Rectangle.
4. เปิดใช้งาน InnerShadowEffect.
5. ตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น.
6. ตั้งค่า ColorType เป็น Scheme.
7. ตั้งค่าสี Scheme.
8. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) .

โค้ดตัวอย่าง (อิงตามขั้นตอนข้างต้น) แสดงวิธีเพิ่มคอนเนคเตอร์ระหว่างสองรูปทรงใน C++:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// รับอ้างอิงของสไลด์
auto slide = presentation->get_Slides()->idx_get(0);

// เพิ่ม AutoShape ประเภท Rectangle
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// เพิ่ม TextFrame ลงใน Rectangle
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// เปิดใช้งาน InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// ตั้งค่าพารามิเตอร์ที่จำเป็นทั้งหมด
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// ตั้งค่า ColorType เป็น Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// ตั้งค่าสี Scheme
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// บันทึกการนำเสนอ
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**สามารถใช้เอฟเฟ็กต์ WordArt กับฟอนต์หรือสคริปต์ที่แตกต่าง (เช่น Arabic, Chinese) ได้หรือไม่?**

ได้, Aspose.Slides รองรับ Unicode และทำงานกับฟอนต์และสคริปต์หลักทั้งหมด. เอฟเฟ็กต์ WordArt เช่น เงา, การเติม, และเส้นขอบสามารถใช้ได้ไม่ว่าจะเป็นภาษาใด, แม้ว่า Availability ของฟอนต์และการแสดงผลอาจขึ้นอยู่กับฟอนต์ในระบบ.

**สามารถใช้เอฟเฟ็กต์ WordArt กับองค์ประกอบของ Slide Master ได้หรือไม่?**

ได้, คุณสามารถใช้เอฟเฟ็กต์ WordArt กับรูปร่างบนมาสเตอร์สไลด์, รวมถึง placeholder ของหัวเรื่อง, ส่วนล่าง, หรือข้อความพื้นหลัง. การเปลี่ยนแปลงในมาสเตอร์จะสะท้อนไปยังสไลด์ที่ใช้มาสเตอร์นั้นทั้งหมด.

**เอฟเฟ็กต์ WordArt มีผลต่อขนาดไฟล์ของงานนำเสนอหรือไม่?**

มีผลเล็กน้อย. เอฟเฟ็กต์ WordArt เช่น เงา, แสงเรืองแสง, และการเติมแบบไล่สีอาจเพิ่มขนาดไฟล์เล็กน้อยเนื่องจากเมตาดาต้าเพิ่มขึ้น, แต่ความแตกต่างมักไม่สำคัญ.

**สามารถดูตัวอย่างผลของเอฟเฟ็กต์ WordArt โดยไม่บันทึกงานนำเสนอได้หรือไม่?**

ได้, คุณสามารถเรนเดอร์สไลด์ที่มี WordArt เป็นภาพ (เช่น PNG, JPEG) โดยใช้เมธอด `GetImage` จากอินเตอร์เฟซ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) หรือ [ISlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/) นี้ช่วยให้คุณดูผลลัพธ์ในหน่วยความจำหรือบนหน้าจอก่อนบันทึกหรือส่งออกงานนำเสนอเต็มรูปแบบ.