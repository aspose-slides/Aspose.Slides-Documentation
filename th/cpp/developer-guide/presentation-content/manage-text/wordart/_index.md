---
title: สร้างและใช้เอฟเฟกต์ WordArt ใน C++
linktitle: WordArt
type: docs
weight: 110
url: /th/cpp/wordart/
keywords:
- WordArt
- สร้าง WordArt
- เทมเพลต WordArt
- เอฟเฟกต์ WordArt
- เอฟเฟกต์เงา
- เอฟเฟกต์การแสดงผล
- เอฟเฟกต์แสงเรืองแสง
- การแปลง WordArt
- เอฟเฟกต์ 3 มิติ
- เอฟเฟกต์เงานอก
- เอฟเฟกต์เงาภายใน
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "สร้างและปรับแต่งเอฟเฟกต์ WordArt ใน Aspose.Slides สำหรับ C++ คู่มือขั้นตอนต่อขั้นตอนนี้ช่วยนักพัฒนาเสริมการนำเสนอด้วยข้อความระดับมืออาชีพใน C++"
---
## **ภาพรวม**

เอฟเฟกต์ WordArt ช่วยให้คุณเพิ่มข้อความที่สวยงามและมีสไตล์ให้กับงานนำเสนอ PowerPoint ของคุณได้อย่างมีเสน่ห์ด้วย Aspose.Slides นักพัฒนาสามารถสร้าง ปรับแต่ง และจัดการ WordArt อย่างโปรแกรมเมติกได้เช่นเดียวกับใน Microsoft PowerPoint—โดยไม่ต้องติดตั้ง Office บทความนี้ให้ภาพรวมเกี่ยวกับการทำงานกับ WordArt รวมถึงวิธีการใช้การแปลงข้อความ รูปแบบการเติม สีเส้นขอบ เงา และตัวเลือกการจัดรูปแบบอื่น ๆ เพื่อทำให้เนื้อหาในการนำเสนอของคุณมีความแสดงออกและดึงดูดมากขึ้น WordArt ทำให้คุณสามารถจัดการข้อความเป็นวัตถุกราฟิกได้ โดยประกอบด้วยเอฟเฟกต์หรือการปรับเปลี่ยนพิเศษที่นำไปใช้กับข้อความเพื่อให้ดูน่าสนใจหรือเด่นชัดยิ่งขึ้น

## **สร้างเทมเพลต WordArt ง่าย ๆ และนำไปใช้กับข้อความ**

**ใช้ Aspose.Slides** 

แรก เราได้สร้างข้อความง่าย ๆ ด้วยโค้ด C++ นี้: 

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

ต่อไป เราตั้งค่าความสูงของแบบอักษรของข้อความให้ใหญ่ขึ้นเพื่อทำให้เอฟเฟกต์ชัดเจนยิ่งขึ้นด้วยโค้ดนี้:

``` cpp 
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**ใช้ Microsoft PowerPoint**

ไปที่เมนูเอฟเฟกต์ WordArt ใน Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

จากเมนูด้านขวา คุณสามารถเลือกเอฟเฟกต์ WordArt ที่กำหนดไว้ล่วงหน้าได้ จากเมนูด้านซ้าย คุณสามารถระบุการตั้งค่าสำหรับ WordArt ใหม่ได้.

ต่อไปนี้เป็นพารามิเตอร์หรือทางเลือกที่มีอยู่บางส่วน:

![todo:image_alt_text](image-20200930114015-3.png)

**ใช้ Aspose.Slides**

ที่นี่ เราใช้สีแบบ SmallGrid กับข้อความและเพิ่มเส้นขอบข้อความสีดำความกว้าง 1 ด้วยโค้ดนี้:

``` cpp 
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

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

## **ใช้เอฟเฟกต์ WordArt อื่น ๆ**

**ใช้ Microsoft PowerPoint**

จากอินเทอร์เฟซของโปรแกรม คุณสามารถใช้เอฟเฟกต์เหล่านี้กับข้อความ, บล็อกข้อความ, รูปร่าง หรือองค์ประกอบที่คล้ายกันได้:

![todo:image_alt_text](image-20200930114129-5.png)

ตัวอย่างเช่น เอฟเฟกต์เงา, การสะท้อน, และแสงเรืองแสง สามารถใช้กับข้อความ; เอฟเฟกต์รูปแบบ 3D และการหมุน 3D สามารถใช้กับบล็อกข้อความ; คุณสมบัติขอบนุ่มสามารถใช้กับวัตถุรูปร่าง (ยังคงมีผลเมื่อไม่ได้ตั้งค่าคุณสมบัติรูปแบบ 3D).

### **ใช้เอฟเฟกต์เงากับข้อความ**

ที่นี่ เราตั้งใจจะกำหนดคุณสมบัติที่เกี่ยวข้องกับข้อความเท่านั้น เราใช้เอฟเฟกต์เงากับข้อความด้วยโค้ด C++ นี้:

``` cpp 
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

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

Aspose.Slides API รองรับเงาประเภท 3 แบบ: OuterShadow, InnerShadow, และ PresetShadow.  
ด้วย PresetShadow คุณสามารถใช้เงากับข้อความ (โดยใช้ค่าที่กำหนดไว้ล่วงหน้า).

**ใช้ Microsoft PowerPoint**

ใน PowerPoint คุณสามารถใช้เงาหนึ่งประเภท ต่อไปนี้เป็นตัวอย่าง:

![todo:image_alt_text](image-20200930114225-6.png)

**ใช้ Aspose.Slides**

Aspose.Slides จริง ๆ แล้วอนุญาตให้คุณใช้เงาสองประเภทพร้อมกัน: InnerShadow และ PresetShadow.

**หมายเหตุ:**

- เมื่อใช้ OuterShadow และ PresetShadow ร่วมกัน จะมีเพียงเอฟเฟกต์ OuterShadow เท่านั้นที่ถูกนำไปใช้.  
- หากใช้ OuterShadow และ InnerShadow พร้อมกัน ผลลัพธ์หรือเอฟเฟกต์ที่นำไปใช้ขึ้นกับเวอร์ชันของ PowerPoint ตัวอย่างเช่น ใน PowerPoint 2013 เอฟเฟกต์จะเพิ่มเป็นสองเท่า แต่ใน PowerPoint 2007 จะใช้เอฟเฟกต์ OuterShadow.

### **ใช้เอฟเฟกต์การสะท้อน**

เราเพิ่มการสะท้อนให้กับข้อความด้วยตัวอย่างโค้ด C++ นี้:

``` cpp 
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

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

### **ใช้เอฟเฟกต์แสงเรืองแสง**

เรานำเอฟเฟกต์แสงเรืองแสงไปใช้กับข้อความเพื่อให้มันส่องแสงหรือเด่นออกมาด้วยโค้ดนี้:

``` cpp 
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

ผลลัพธ์ของการดำเนินการ:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 
คุณสามารถเปลี่ยนพารามิเตอร์สำหรับเงา, การแสดงผล, และแสงเรืองแสงได้ คุณสมบัติของเอฟเฟกต์จะถูกตั้งค่าบนแต่ละส่วนของข้อความแยกกัน. 
{{% /alert %}} 

### **ใช้การแปลงใน WordArt**

เราใช้เมธอด set_Transform (ที่สืบทอดในบล็อกข้อความทั้งหมด) ด้วยโค้ดนี้:

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

ผลลัพธ์:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 
Microsoft PowerPoint และ Aspose.Slides สำหรับ C++ มีประเภทการแปลงที่กำหนดล่วงหน้าจำนวนหนึ่ง. 
{{% /alert %}} 

**ใช้ PowerPoint**

เพื่อเข้าถึงประเภทการแปลงที่กำหนดไว้ล่วงหน้า ไปที่: **Format** -> **TextEffect** -> **Transform**

**ใช้ Aspose.Slides**

เพื่อเลือกประเภทการแปลง ใช้ enum TextShapeType.

### **ใช้เอฟเฟกต์ 3 มิติกับข้อความและรูปร่าง**

เราใส่เอฟเฟกต์ 3 มิติให้กับรูปร่างข้อความด้วยตัวอย่างโค้ดนี้:

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
autoShape->get_TextFrame()->set_Text(u"Aspose.Slides");

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

ข้อความและรูปร่างที่ได้:

![todo:image_alt_text](image-20200930114816-9.png)

เรานำเอฟเฟกต์ 3 มิติไปใช้กับข้อความด้วยโค้ด C++ นี้:

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

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

{{% alert color="info" %}} 
การนำเอฟเฟกต์ 3 มิติไปใช้กับข้อความหรือรูปร่างและปฏิสัมพันธ์ระหว่างเอฟเฟกต์เป็นไปตามกฎบางอย่าง  

พิจารณาฉากสำหรับข้อความและรูปร่างที่บรรจุข้อความนั้น เอฟเฟกต์ 3 มิติประกอบด้วยการแสดงวัตถุ 3 มิติและฉากที่วัตถุถูกวาง  

- เมื่อตั้งค่าฉากสำหรับทั้งรูปและข้อความ ฉากของรูปจะได้ลำดับความสำคัญสูงกว่า—ฉากของข้อความจะถูกละเลย.  
- เมื่อรูปไม่มีฉากของตนเองแต่มีการแสดง 3 มิติ จะใช้ฉากของข้อความ.  
- หากรูปเดิมไม่มีเอฟเฟกต์ 3 มิติ รูปร่างจะเป็นแบนและเอฟเฟกต์ 3 มิติจะถูกนำไปใช้เฉพาะกับข้อความเท่านั้น.  

คำอธิบายเหล่านี้เชื่อมโยงกับเมธอด ThreeDFormat.getLightRig() และ ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **ใช้เอฟเฟ็กต์เงานอกกับรูปร่าง**
Aspose.Slides สำหรับ C++ มีคลาส [**IOuterShadow**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.effects.i_outer_shadow) และ [**IInnerShadow**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.effects.i_inner_shadow) ที่ให้คุณใช้เอฟเฟกต์เงากับข้อความที่อยู่ใน TextFrame ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) .
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน.
3. เพิ่ม AutoShape ประเภท Rectangle เข้าสู่สไลด์.
4. เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape.
5. ตั้งค่า FillType ของ AutoShape เป็น NoFill.
6. สร้างอินสแตนซ์ของคลาส OuterShadow
7. ตั้งค่า BlurRadius ของเงา.
8. ตั้งค่า Direction ของเงา
9. ตั้งค่า Distance ของเงา.
10. ตั้งค่า RectanglelAlign เป็น TopLeft.
11. ตั้งค่า PresetColor ของเงาเป็น Black.
12. บันทึกการพรีเซนเทชันเป็นไฟล์ PPTX.

โค้ดตัวอย่างใน C++ — การดำเนินการตามขั้นตอนข้างต้น — แสดงวิธีใช้เอฟเฟกต์เงานอกกับข้อความ:

``` cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
// รับอ้างอิงของสไลด์
auto sld = pres->get_Slides()->idx_get(0);

// เพิ่ม AutoShape ประเภทสี่เหลี่ยม
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// เพิ่ม TextFrame ลงในสี่เหลี่ยม
ashp->AddTextFrame(u"Aspose TextBox");

// ปิดการเติมสีของรูปร่างในกรณีที่ต้องการเงาข้อความ
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// เพิ่มเงานอกและตั้งค่าพารามิเตอร์ที่จำเป็นทั้งหมด
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

## **ใช้เอฟเฟกต์เงาภายในกับรูปร่าง**
ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) .
2. รับอ้างอิงของสไลด์.
3. เพิ่ม AutoShape ประเภท Rectangle.
4. เปิดใช้งาน InnerShadowEffect.
5. ตั้งค่าพารามิเตอร์ที่จำเป็นทั้งหมด.
6. ตั้งค่า ColorType เป็น Scheme.
7. ตั้งค่าสี Scheme.
8. บันทึกการพรีเซนเทชันเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) .

โค้ดตัวอย่างนี้ (ตามขั้นตอนข้างต้น) แสดงวิธีเพิ่มคอนเน็กเตอร์ระหว่างสองรูปร่างใน C++:

``` cpp
#include <DOM/ColorType.h>
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// รับอ้างอิงของสไลด์
auto slide = presentation->get_Slides()->idx_get(0);

// เพิ่ม AutoShape ประเภทสี่เหลี่ยม
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// เพิ่ม TextFrame ลงในสี่เหลี่ยม
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

### ฉันสามารถใช้เอฟเฟกต์ WordArt กับฟอนต์หรือสคริปต์ที่แตกต่างกัน (เช่น Arabic, Chinese) ได้หรือไม่?
ใช่, Aspose.Slides รองรับ Unicode และทำงานกับฟอนต์และสคริปต์หลักทั้งหมด เอฟเฟกต์ WordArt เช่น เงา, การเติม, และเส้นขอบ สามารถใช้ได้โดยไม่คำนึงถึงภาษา แม้ว่าการมีฟอนต์และการแสดงผลอาจขึ้นอยู่กับฟอนต์ที่ติดตั้งในระบบ.

### ฉันสามารถใช้เอฟเฟกต์ WordArt กับองค์ประกอบของสไลด์มาสเตอร์ได้หรือไม่?
ได้, คุณสามารถใช้เอฟเฟกต์ WordArt กับรูปร่างบนสไลด์มาสเตอร์ รวมถึงตำแหน่งเก็บหัวเรื่อง, ส่วนล่าง, หรือข้อความพื้นหลัง การเปลี่ยนแปลงในเลเอาต์มาสเตอร์จะสะท้อนไปยังสไลด์ที่เชื่อมโยงทั้งหมด.

### เอฟเฟกต์ WordArt มีผลต่อขนาดไฟล์พรีเซนเทชันหรือไม่?
เล็กน้อย. เอฟเฟกต์ WordArt เช่น เงา, แสงเรืองแสง, และการเติมแบบไล่สี อาจเพิ่มขนาดไฟล์เล็กน้อยเนื่องจากข้อมูลเมตาเพิ่มขึ้น แต่ส่วนต่างมักไม่สังเกตได้.

### ฉันสามารถดูตัวอย่างผลลัพธ์ของเอฟเฟกต์ WordArt โดยไม่ต้องบันทึกพรีเซนเทชันได้หรือไม่?
ได้, คุณสามารถแปลงสไลด์ที่มี WordArt เป็นภาพ (เช่น PNG, JPEG) โดยใช้เมธอด `GetImage` จากอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) หรือ [ISlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/) นี้ทำให้คุณดูตัวอย่างผลลัพธ์ในหน่วยความจำหรือบนหน้าจอก่อนบันทึกหรือส่งออกพรีเซนเทชันเต็มรูปแบบ.