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
- เอฟเฟกต์เรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ C++ - สร้างสไลด์ที่น่าตื่นตาตื่นใจและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้เพื่อทำให้รูปร่างโดดเด่นได้ แต่พวกมันแตกต่างจาก [การเติม](/slides/th/cpp/shape-formatting/#gradient-fill) หรือขอบเส้น. การใช้เอฟเฟกต์ใน PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปร่าง, กระจายแสงเรืองแสงของรูปร่าง, เป็นต้น.

![เอฟเฟกต์รูป](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกประเภทที่สามารถใช้กับรูปร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปร่างหนึ่งรูปได้.

การผสมผสานบางอย่างของเอฟเฟกต์ดูดีกว่าการผสมอื่น ๆ ด้วยเหตุผลนี้ PowerPoint มีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการรวมกันของสองหรือมากกว่าของเอฟเฟกต์ที่รู้ว่าดูดีร่วมกัน วิธีนี้เมื่อเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือรวมเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่ดี.

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) ที่อนุญาตให้คุณใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint.

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides สำหรับ C++ รองรับเงานอกและเงาภายในสำหรับรูปร่าง คุณสามารถปรับแต่งสี, ทิศทาง, ระยะทาง, และรัศมีเบลอให้ตรงกับการออกแบบงานนำเสนอของคุณ.

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงโดดเด่นเหนือพื้นหลังของสไลด์ เงาขยายออกนอกขอบของรูปร่าง ทำให้ดูเหมือนรูปร่างยกขึ้นเหนือสไลด์ ปรับสี, ทิศทาง, ระยะทาง, และรัศมีเบลอให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ

This C++ code shows how to apply the [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) to a rectangle:

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

เมื่อทำซ้ำสไตล์ภาพของเทมเพลต ให้ใช้เงาภายในเพื่อให้การ์ดหรือแผงดูเหมือนถมลงไปภายใน เงานอกขยายออกนอกรูปร่างและทำให้ดูยกขึ้น ในขณะที่เงาภายในทำให้ด้านในของขอบเงามืดลง

Call [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), then configure [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Larger blur radius values produce softer edges.

This C++ example creates a light blue card with a dark gray inner shadow and saves it as a PPTX file:

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

![สี่เหลี่ยมสีน้ำเงินอ่อนที่มีเงาภายใน](inner_shadow_effect.png)

เพื่อเอาเงาภายในออก ให้เรียก [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) บนฟอร์แมตเอฟเฟกต์ของรูปร่าง

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides สำหรับ C++ คุณสามารถเพิ่มการสะท้อนคล้ายกระจกให้กับรูปร่างโดยปรับพารามิเตอร์เช่น ระยะ, ความโปร่งแสง, และขนาด เอฟเฟกต์นี้ช่วยยกระดับความสวยงามของงานนำเสนอของคุณโดยให้รูปร่างดูเรียบหรูและทันสมัย ใช้ง่ายด้วยโค้ดง่าย ๆ ทำให้สามารถนำไปใช้กับหลายองค์ประกอบได้อย่างรวดเร็วเพื่อการออกแบบที่สม่ำเสมอ

This C++ code shows how to apply the [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) to a shape:

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

## **ใช้เอฟเฟกต์เรืองแสง**

เพื่อใช้เอฟเฟกต์เรืองแสงกับรูปร่างใน Aspose.Slides สำหรับ C++ คุณสามารถเพิ่มออร่าระยางอ่อน ๆ รอบรูปร่างโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยทำให้รูปร่างโดดเด่นและเพิ่มองค์ประกอบภาพที่ดึงดูดสายตาให้กับงานนำเสนอของคุณ ใช้ง่ายด้วยโค้ดเพียงเล็กน้อย ทำให้สไลด์ของคุณดูสวยงามยิ่งขึ้น

This C++ code shows how to apply the [เอฟเฟกต์เรืองแสง](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) to a shape:

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

![เอฟเฟกต์เรืองแสง](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบนุ่ม**

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides สำหรับ C++ คุณสามารถสร้างการเปลี่ยนแปลงรอบขอบของรูปร่างให้เรียบและเบลอได้ เอฟเฟกต์นี้ให้ลุคที่ละเอียดอ่อนและพริ้วไหว เหมาะสำหรับออกแบบที่ต้องการลุคอ่อนโยนและนุ่มนวล คุณสามารถปรับพารามิเตอร์เช่น รัศมี เพื่อให้ได้ผลลัพธ์ตามต้องการบนรูปร่างต่าง ๆ ในงานนำเสนอของคุณ

This C++ code shows how to apply the [ขอบนุ่ม](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) to a shape:

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

ใช้การเบลอรูปร่างเพื่อทำให้การเติมและขอบของรูปร่างอ่อนลงโดยยังคงให้รูปร่างแก้ไขได้ เรียก [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) บนฟอร์แมตเอฟเฟกต์ของรูปร่าง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ โดยค่าที่ใหญ่กว่าจะทำให้เบลอแรงขึ้น รัศมีศูนย์จะไม่เปลี่ยนลักษณะใด ๆ

การตั้งค่า [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) ควบคุมขอบเขตที่มองเห็นของเอฟเฟกต์ เมื่อเป็น `false` การเบลอจะถูกคลิปให้ตรงกับขอบเขตที่ทาสีเดิมรวมถึงขอบเส้น เมื่อเป็น `true` การเบลออาจขยายออกนอกขอบเขตนั้น ทั้งสองค่าจะไม่เปลี่ยนตำแหน่งหรือขนาดของรูปร่าง

การเปรียบเทียบด้านล่างใช้การเติม, ขอบ, และขนาดรูปร่างเดียวกันตลอด ряда แถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`.

![สี่เหลี่ยมต้นฉบับเปรียบเทียบกับรัศมีเบลอ 5 และ 15 จุด, กับการเปิด/ปิดการขยาย](shape_blur_comparison.png)

This C++ example creates an orange rectangle with a dark blue outline, applies a 5‑point blur, and then updates it to a 15‑point blur by calling [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) again. It saves both blurred states, then calls [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) and saves the shape without blur.

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

การเบลอรูปทรงส่งผลต่อการเติมและขอบเส้นพร้อมกัน เอฟเฟกต์ขอบนุ่มทำให้ขอบของรูปทรงจางหายไป ในขณะที่การเบลอเงาเบลอเฉพาะเงาเท่านั้น เอฟเฟกต์การแปลงภาพทำงานกับเนื้อหาภาพ; ตัวอย่างนี้ใช้การเบลอโดยตรงกับฟอร์แมตเอฟเฟกต์ของรูปร่างโดยไม่ต้องแปลงรูปร่างเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปร่างเดียวกันได้หรือไม่?**

ใช่, คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อน, และเรืองแสงบนรูปร่างเดียวเพื่อสร้างลุคที่มีพลวัตมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลากหลายประเภท รวมถึงอัตโนมัติรูปร่าง, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE, และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับกลุ่มรูปร่างได้หรือไม่?**

ได้, คุณสามารถใช้เอฟเฟกต์กับกลุ่มรูปร่างได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมดโดยรวม.