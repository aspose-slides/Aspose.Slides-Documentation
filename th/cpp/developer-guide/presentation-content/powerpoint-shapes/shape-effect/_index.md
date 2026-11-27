---
title: ใช้เอฟเฟกต์รูปร่างในงานนำเสนอด้วย C++
linktitle: เอฟเฟกต์รูปร่าง
type: docs
weight: 30
url: /th/cpp/shape-effect/
keywords:
- เอฟเฟกต์รูปร่าง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์แสงเรืองแสง
- เอฟเฟกต์ขอบอมนุ่มนวล
- รูปแบบเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เปลี่ยนไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปร่างขั้นสูงโดยใช้ Aspose.Slides สำหรับ C++ — สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพภายในไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้ทำให้รูปร่างโดดเด่นได้ แต่พวกมันจะแตกต่างจาก [การเติมสี](/slides/th/cpp/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ใน PowerPoint คุณสามารถสร้างเงาสะท้อนที่น่าเชื่อถือบนรูปร่าง กระจายแสงเรืองแสงของรูปร่าง ฯลฯ

![เอฟเฟกต์รูปร่าง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถนำไปใช้กับรูปร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปร่างได้

บางการผสมผสานของเอฟเฟกต์ดูดีกว่าการผสมอื่น ๆ ด้วยเหตุนี้ PowerPoint มีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset คือการผสมผสานของสองหรือมากกว่าหนึ่งเอฟเฟกต์ที่รู้ว่าดูดีร่วมกัน วิธีนี้โดยการเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อค้นหาการผสมที่ดี

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) ที่ให้คุณสามารถนำเอฟเฟกต์เดียวกันไปใช้กับรูปร่างในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for C++ รองรับเงานอกและเงาภายในสำหรับรูปร่าง คุณสามารถปรับแต่งสี, ทิศทาง, ระยะทาง, และรัศมีเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงเด่นขึ้นจากพื้นหลังของสไลด์ เงาจะขยายเกินขอบของรูปร่าง ทำให้ดูเหมือนรูปร่างลอยเหนือสไลด์ ปรับสี, ทิศทาง, ระยะทาง, และรัศมีเบลอร์ให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด C++ นี้แสดงวิธีใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) กับสี่เหลี่ยมผืนผ้า:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

presentation->Save(u"shadow_effect.pptx", SaveFormat::Pptx);
```

![เอฟเฟกต์เงา](shadow_effect.png)

#### **ควบคุมทิศทางเงาเมื่อรูปร่างหมุน**

โดยค่าเริ่มต้น เงานอกจะหมุนตามรูปร่างของมัน เพื่อให้รูปร่างที่มีการหมุนต่างกันดูเหมือนรับแสงจากทิศทางเดียวกัน ให้เรียกใช้ [set_RotateShadowWithShape](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_rotateshadowwithshape/) ด้วยค่า `false` แล้วใช้ [set_Direction](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_direction/) เพื่อกำหนดมุมเงาให้เท่ากัน

ตัวอย่างสร้างลูกศรสองลูกที่มีเงาสีเทาเลื่อนไปทางขวา (0°) จากนั้นทำสำเนาสไลด์และหมุนลูกศรทั้งสอง 90° ตามเข็มนาฬิกา

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto before = presentation->get_Slide(0);

auto left = before->get_Shapes()->AddAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
left->get_FillFormat()->set_FillType(FillType::Solid);
left->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
left->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

left->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = left->get_EffectFormat()->get_OuterShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_Gray());
shadow->set_Direction(0);
shadow->set_Distance(42);
shadow->set_BlurRadius(0);
shadow->set_RotateShadowWithShape(true);

auto right = before->get_Shapes()->AddClone(left);
right->set_X(395);
right->get_EffectFormat()->get_OuterShadowEffect()->set_RotateShadowWithShape(false);

auto after = presentation->get_Slides()->AddClone(before);
for (auto i = 0; i < after->get_Shapes()->get_Count(); ++i)
{
    after->get_Shape(i)->set_Rotation(90);
}

presentation->Save(u"arrow_shadows.pptx", SaveFormat::Pptx);
```

บนสไลด์ที่สอง ลูกศรซ้ายทำเงาลงด้านล่าง ในขณะที่ลูกศรขวายังคงทำเงาไปทางขวามือ ทิศทางที่กำหนดยังคงเป็น 0° สำหรับเงาทั้งสอง

![การเรนเดอร์ PowerPoint ก่อนและหลังการหมุน 90° ทั้งสองเงาเริ่มที่ด้านขวา หลังการหมุน เงาย้ายไปด้านล่างของลูกศรซ้ายและคงอยู่ด้านขวาของลูกศรขวา](arrow-shadow-rotation.png)

### **ใช้เงาภายใน**

เมื่อทำสำเนาการออกแบบของเทมเพลต ให้ใช้เงาภายในเพื่อให้การ์ดหรือแผงดูเหมือนถูกกดลงไป เงานอกจะขยายออกนอกรูปร่างทำให้ดูเป็นดัดขึ้น ในขณะที่เงาภายในจะทำให้ขอบของรูปร่างด้านในมีเงา

เรียกใช้ [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) แล้วกำหนดค่า [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) ค่ารัศมีเบลอร์ที่ใหญ่กว่าจะให้ขอบนุ่มนวลขึ้น

ตัวอย่าง C++ นี้สร้างการ์ดสีฟ้าอ่อนที่มีเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX:

```cpp
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_LightBlue());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

shape->get_EffectFormat()->EnableInnerShadowEffect();
auto shadow = shape->get_EffectFormat()->get_InnerShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_DimGray());
shadow->set_Direction(225);
shadow->set_Distance(7);
shadow->set_BlurRadius(6);

presentation->Save(u"inner_shadow_effect.pptx", SaveFormat::Pptx);
```

![สี่เหลี่ยมผืนผ้าสีฟ้าอ่อนที่มีเงาภายใน](inner_shadow_effect.png)

เพื่อเอาเงาภายในออก ให้เรียกใช้ [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) บน EffectFormat ของรูปร่าง

### **ใช้, เปลี่ยน, และลบเงาตามค่า Preset**

เรียกใช้ [EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) แล้วใช้ [set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/) เพื่อเลือก [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/) หากต้องการสลับสไตล์ให้เปลี่ยน Preset บนรูปรShapeเดียวกัน ให้เรียกใช้ [DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/) เพื่อลบเงาโดยยังคงรักษาการเติมสีและเส้นขอบไว้

ตัวอย่างนี้เก็บสำเนาของสี่เหลี่ยมผืนผ้าในแต่ละขั้นตอน เงาทั้งสองถูกเลื่อนออก 10 จุด ทิศทาง 225° จะทำให้เงาแรกอยู่เหนือและด้านซ้ายของสี่เหลี่ยมผืนผ้า และ 45° จะทำให้เงาที่สองอยู่ด้านล่างและด้านขวา

```cpp
#include <DOM/Effects/IPresetShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/PresetShadowType.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/enum.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(800, 120, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
auto outline = shape->get_LineFormat()->get_FillFormat();
outline->set_FillType(FillType::Solid);
outline->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
auto textFrame = shape->get_TextFrame();
textFrame->set_Text(u"No shadow");
textFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(14);
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnablePresetShadowEffect();
auto shadow = effectFormat->get_PresetShadowEffect();
shadow->set_Preset(PresetShadowType::TopLeftDropShadow);
shadow->set_Distance(10);
shadow->set_Direction(225);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
shadow->set_Preset(PresetShadowType::BottomRightDropShadow);
shadow->set_Direction(45);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
effectFormat->DisablePresetShadowEffect();
textFrame->set_Text(u"No shadow");

presentation->Save(u"preset_shadows.pptx", SaveFormat::Pptx);
```

| ต้นฉบับ | พรีเซ็ตแรก | พรีเซ็ตที่สอง | หลังการลบ |
| :---: | :---: | :---: | :---: |
| ![ไม่มีเงา](preset_shadow_original.png) | ![เงาตกด้านบนซ้าย](preset_shadow_top_left.png) | ![เงาตกด้านล่างขวา](preset_shadow_bottom_right.png) | ![ไม่มีเงาหลังการลบ](preset_shadow_removed.png) |

## **ใช้เอฟเฟ็กต์การสะท้อน**

เพื่อใช้เอฟเฟ็กต์การสะท้อนใน Aspose.Slides for C++ คุณสามารถเพิ่มการสะท้อนเหมือนกระจกให้กับรูปร่างโดยปรับพารามิเตอร์เช่น ระยะ, ความโปร่งใส, และขนาด เอฟเฟ็กต์นี้ช่วยเพิ่มความงามของงานนำเสนอด้วยการทำให้รูปร่างดูเรียบหรูและเป็นมืออาชีพ ใช้งานง่ายด้วยโค้ดง่าย ๆ ทำให้สามารถนำไปใช้กับหลายองค์ประกอบได้อย่างรวดเร็วเพื่อให้ได้การออกแบบที่สม่ำเสมอ

โค้ด C++ นี้แสดงวิธีใช้ [เอฟเฟ็กต์การสะท้อน](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) กับรูปร่าง:

```cpp
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(40);
reflectionEffect->set_BlurRadius(2);

presentation->Save(u"reflection_effect.pptx", SaveFormat::Pptx);
```

![เอฟเฟ็กต์การสะท้อน](reflection_effect.png)

## **ใช้เอฟเฟกต์แสงเรืองแสง**

เพื่อใช้เอฟเฟกต์แสงเรืองแสงกับรูปร่างใน Aspose.Slides for C++ คุณสามารถเพิ่มออร่านุ่มนวลให้กับรูปร่างโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยให้รูปร่างโดดเด่นและเพิ่มองค์ประกอบที่ดึงดูดสายตาให้กับงานนำเสนอของคุณ ใช้งานง่ายด้วยโค้ดที่สั้นทำให้รูปลักษณ์โดยรวมของสไลด์ดูดีขึ้น

โค้ด C++ นี้แสดงวิธีใช้ [เอฟเฟกต์แสงเรืองแสง](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) กับรูปร่าง:

```cpp
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Magenta());
glowEffect->set_Radius(15);

presentation->Save(u"glow_effect.pptx", SaveFormat::Pptx);
```

![เอฟเฟ็กต์แสงเรืองแสง](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบนอมนุ่มนวล**

เพื่อใช้เอฟเฟกต์ขอบนอมนุ่มนวลใน Aspose.Slides for C++ คุณสามารถสร้างการเปลี่ยนแปลงที่ราบรื่นและเบลอร์รอบขอบของรูปร่าง เอฟเฟกต์นี้ให้ลุคที่ละเอียดอ่อนและเป็นมืออาชีพ เหมาะกับการออกแบบที่ต้องการความนุ่มนวล คุณสามารถปรับพารามิเตอร์เช่น รัศมีเพื่อให้ได้ผลลัพธ์ตามต้องการในรูปร่างต่าง ๆ ของงานนำเสนอ

โค้ด C++ นี้แสดงวิธีใช้ [ขอบอมนุ่มนวล](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) กับรูปร่าง:

```cpp
#include <DOM/Effects/ISoftEdge.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(8);

presentation->Save(u"soft_edges_effect.pptx", SaveFormat::Pptx);
```

![เอฟเฟกต์ขอบนอมนุ่มนวล](soft_edges_effect.png)

## **ใช้เอฟเฟกต์เบลอ**

ใช้การเบลอรูปร่างเพื่อทำให้สีเติมและเส้นขอบของรูปร่างนุ่มนวลลงในขณะที่รูปร่างยังคงแก้ไขได้ เรียกใช้ [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) บน EffectFormat ของรูปร่าง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าไม่เป็นลบ ค่าที่ใหญ่กว่าจะทำให้เบลอแรงขึ้น รัศมี 0 จะไม่เปลี่ยนลักษณะใด ๆ

การตั้งค่า [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) ควบคุมขอบที่มองเห็นได้ของเอฟเฟกต์ หากตั้งค่าเป็น `false` การเบลอจะถูกตัดกรอบตามขอบที่วาดเดิมรวมถึงเส้นขอบ หากตั้งค่าเป็น `true` การเบลออาจขยายเกินขอบเหล่านั้น การตั้งค่าใด ๆ ก็ไม่เปลี่ยนตำแหน่งหรือขนาดของรูปร่าง

การเปรียบเทียบด้านล่างใช้สีเติม, เส้นขอบ, และขนาดรูปร่างเดียวกันตลอด แถวบนใช้ `grow = false` แถวล่างใช้ `grow = true`

![สี่เหลี่ยมผืนผ้าต้นฉบับเปรียบเทียบกับรัศมีเบลอ 5 และ 15 จุด พร้อมการ grow ปิดและเปิด](shape_blur_comparison.png)

ตัวอย่าง C++ นี้สร้างสี่เหลี่ยมสีส้มที่มีเส้นขอบสีน้ำเงินเข้ม ใช้การเบลอ 5 จุด แล้วอัปเดตเป็นการเบลอ 15 จุดโดยเรียก [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) อีกครั้ง บันทึกสถานะเบลอทั้งสอง จากนั้นเรียก [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) เพื่อบันทึกรูปร่างโดยไม่มีการเบลอ

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 80.0f, 160.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
shape->get_LineFormat()->set_Width(8);

shape->get_EffectFormat()->SetBlurEffect(5, false);
presentation->Save(u"shape_blur_5.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->SetBlurEffect(15, true);
presentation->Save(u"shape_blur_15.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->DisableBlurEffect();
presentation->Save(u"shape_blur_removed.pptx", SaveFormat::Pptx);
```

การเบลอรูปร่างกระทบทั้งสีเติมและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบนอมนุ่มนวลทำให้ขอบของรูปร่างจางลง ขณะที่การเบลอเงาจะทำให้เงานุ่มนวลเพียงอย่างเดียว เอฟเฟกต์การแปลงภาพทำงานกับเนื้อหาภาพ; ตัวอย่างนี้ใช้การเบลอโดยตรงบน EffectFormat ของรูปร่างโดยไม่ต้องแปลงรูปร่างเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปร่างเดียวกันได้หรือไม่?**

ได้ คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อน, และแสงเรืองแสงบนรูปร่างเดียวกันเพื่อสร้างลักษณะที่มีความไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลายประเภท รวมถึงรูปอัตโนมัติ, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปแบบที่จัดกลุ่มได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปร่างที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมดโดยรวม