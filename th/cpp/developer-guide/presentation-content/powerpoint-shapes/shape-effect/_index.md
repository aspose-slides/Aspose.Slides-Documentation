---
title: ประยุกต์ใช้เอฟเฟกต์รูปทรงในงานนำเสนอด้วย C++
linktitle: เอฟเฟกต์รูปทรง
type: docs
weight: 30
url: /th/cpp/shape-effect/
keywords:
- เอฟเฟกต์รูปทรง
- เอฟเฟ็กต์เงา
- เอฟเฟ็กต์การสะท้อน
- เอฟเฟกต์อำพราง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ C++ — สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในเวลาไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้ทำให้รูปทรงเด่นออกมาได้ แต่ก็แตกต่างจาก [การเติม](/slides/th/cpp/shape-formatting/#gradient-fill) หรือขอบเส้น. ด้วยการใช้เอฟเฟกต์ของ PowerPoint, คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปทรง, กระจายแสงอำพรางของรูปทรง, ฯลฯ.

![เอฟเฟกต์รูปทรง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถใช้กับรูปทรงได้ คุณสามารถใช้เอฟเฟกต์หนึ่งหรือหลายเอฟเฟกต์กับรูปทรงได้.

บางการผสมผสานของเอฟเฟกต์ดูดีกว่าการผสมผสานอื่น ๆ ด้วยเหตุนี้ PowerPoint มีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset โดยพื้นฐานคือการผสมผสานของสองหรือหลายเอฟเฟกต์ที่รู้ว่าดูดีร่วมกัน วิธีนี้เมื่อเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือผสมผสานเอฟเฟกต์ต่าง ๆ เพื่อหาแนวผสมที่ดี

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) ที่ช่วยให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides สำหรับ C++ รองรับเงานอกและเงาภายในสำหรับรูปทรง คุณสามารถปรับแต่งสี, ทิศทาง, ระยะทางและรัศมีเบลอร์เพื่อให้สอดคล้องกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงเด่นขึ้นจากพื้นหลังสไลด์ เงาจะขยายออกไปนอกขอบของรูปทรง สร้างความรู้สึกว่ารูปทรงยกขึ้นเหนือสไลด์ ปรับสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด C++ นี้แสดงวิธีการใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) กับสี่เหลี่ยม:

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

### **ใช้เงาภายใน**

เมื่อทำสำเนาการออกแบบภาพของเทมเพลต, ใช้เงาภายในเพื่อให้การ์ดหรือแผงดูเหมือนถูกฝังลงไป เงานอกขยายนอกรูปทรงทำให้ดูยกขึ้น, ส่วนเงาภายในให้เงาในด้านในของขอบของรูปทรง

เรียกใช้ [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), จากนั้นกำหนดค่า [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). ค่ารัศมีเบลอร์ที่ใหญ่กว่าจะให้ขอบนุ่มขึ้น

ตัวอย่าง C++ นี้สร้างการ์ดสีฟ้าอ่อนพร้อมเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX:

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

![สี่เหลี่ยมสีน้ำเงินอ่อนพร้อมเงาภายใน](inner_shadow_effect.png)

เพื่อลบเงาภายใน, เรียกใช้ [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) บนรูปแบบเอฟเฟกต์ของรูปทรง

### **ใช้, แก้ไขและลบ Preset Shadow**

เรียกใช้ [EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) แล้วใช้ [set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/) เพื่อเลือก [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/). เพื่อสลับสไตล์, เปลี่ยน preset บนรูปทรงเดียวกัน. เรียกใช้ [DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/) เพื่อลบเงาโดยคงการเติมและขอบไว้

ตัวอย่างนี้เก็บสำเนาของสี่เหลี่ยมในแต่ละขั้นตอน เงาทั้งสองถูกเลื่อนออก 10 จุด ทิศทาง 225° ทำให้เงาแรกอยู่ด้านบนและซ้ายของสี่เหลี่ยม, และ 45° ทำให้เงาที่สองอยู่ด้านล่างและขวา

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

| ต้นฉบับ | Preset แรก | Preset ที่สอง | หลังการลบ |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides สำหรับ C++, คุณสามารถเพิ่มการสะท้อนแบบกระจกให้กับรูปทรง, ปรับพารามิเตอร์เช่น ระยะ, ความโปร่งแสงและขนาด. เอฟเฟกต์นี้ทำให้การนำเสนอของคุณดูหรูหราและเป็นมืออาชีพยิ่งขึ้น. การทำงานง่ายด้วยโค้ดไม่กี่บรรทัด, สามารถนำไปใช้กับหลายองค์ประกอบอย่างรวดเร็วเพื่อความสอดคล้องของดีไซน์

โค้ด C++ นี้แสดงวิธีการใช้ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) กับรูปทรง:

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

![เอฟเฟกต์การสะท้อน](reflection_effect.png)

## **ใช้เอฟเฟกต์อำพราง**

เพื่อใช้เอฟเฟกต์อำพรางกับรูปทรงใน Aspose.Slides สำหรับ C++, คุณสามารถเพิ่มอำพรางรอบรูปทรง, ปรับสีและขนาดได้. เอฟเฟกต์นี้ช่วยให้รูปทรงเด่นและเพิ่มความน่าสนใจให้กับสไลด์ของคุณ. ใช้งานง่ายด้วยโค้ดสั้น ๆ, ทำให้สไลด์ดูสวยงามยิ่งขึ้น

โค้ด C++ นี้แสดงวิธีการใช้ [เอฟเฟกต์อำพราง](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) กับรูปทรง:

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

![เอฟเฟกต์อำพราง](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบนุ่ม**

เพื่อใช้เอฟเฟ็กต์ขอบนุ่มใน Aspose.Slides สำหรับ C++, คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอกลมรอบขอบของรูปทรง. เอฟเฟกต์นี้ให้รูปลักษณ์ที่ละเอียดอ่อนและสวยงาม, เหมาะกับการออกแบบที่ต้องการความอ่อนโยน. สามารถปรับพารามิเตอร์เช่น รัศมีเพื่อให้ได้ผลลัพธ์ที่ต้องการในรูปทรงต่าง ๆ ของการนำเสนอ

โค้ด C++ นี้แสดงวิธีการใช้ [ขอบนุ่ม](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) กับรูปทรง:

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

![เอฟเฟกต์ขอบนุ่ม](soft_edges_effect.png)

## **ใช้เอฟเฟกต์เบลอ**

ใช้เบลอรูปทรงเพื่อทำให้การเติมและขอบของรูปทรงดูนุ่มขึ้นโดยยังคงรูปทรงสามารถแก้ไขได้ เรียกใช้ [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) บนรูปแบบเอฟเฟกต์ของรูปทรง. รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ, ค่าที่ใหญ่กว่าจะทำให้เบลอแรงขึ้น. รัศมี 0 จะไม่เปลี่ยนลักษณะใด ๆ

การตั้งค่า [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) ควบคุมขอบมองเห็นของเอฟเฟกต์. เมื่อ `false`, เบลอจะถูกตัดให้อยู่ในขอบสีที่วาดเดิมรวมทั้งขอบเส้น. เมื่อ `true`, เบลอสามารถขยายออกนอกขอบเหล่านั้นได้. ทั้งสองการตั้งค่าไม่เปลี่ยนตำแหน่งหรือขนาดของรูปทรง

การเปรียบเทียบด้านล่างใช้การเติม, ขอบและขนาดรูปทรงเดียวกันตลอด. แถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`.

![สี่เหลี่ยมต้นฉบับเทียบกับรัศมีเบลอ 5 และ 15 จุด, พร้อม grow ปิดและเปิด](shape_blur_comparison.png)

โค้ด C++ นี้สร้างสี่เหลี่ยมสีส้มพร้อมขอบสีน้ำเงินเข้ม, ใช้เบลอ 5 จุด, จากนั้นอัปเดตเป็นเบลอ 15 จุดโดยเรียก [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) อีกครั้ง. ทั้งสองสถานะเบลอจะถูกบันทึก, จากนั้นเรียก [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) และบันทึกรูปทรงโดยไม่มีเบลอ.

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

เบลอรูปทรงกระทบการเติมและขอบพร้อมกัน. เอฟเฟกต์ขอบนุ่มทำให้ขอบรูปทรงจางลง, ในขณะที่เบลอเงาทำให้เงานุ่มขึ้นเท่านั้น. เอฟเฟกต์การแปลงรูปภาพทำงานบนเนื้อหารูปภาพ; ตัวอย่างนี้ใช้เบลอโดยตรงบนรูปแบบเอฟเฟกต์ของรูปทรงโดยไม่ต้องแปลงรูปทรงเป็นรูปภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปทรงเดียวกันได้หรือไม่?**

ได้, คุณสามารถผสมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อนและอำพรางบนรูปทรงเดียวเพื่อสร้างลักษณะที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงต่าง ๆ รวมถึงรูปอัตโนมัติ, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มไว้ได้หรือไม่?**

ได้, คุณสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด