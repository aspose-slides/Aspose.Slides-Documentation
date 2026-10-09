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
- งานนำเสนอ
- C++
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปร่างขั้นสูงโดยใช้ Aspose.Slides for C++ — สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถทำให้รูปร่างเด่นขึ้นได้ แต่เอฟเฟกต์จะแตกต่างจาก [การเติมสี](/slides/th/cpp/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ของ PowerPoint ทำให้คุณสร้างการสะท้อนที่ดูสมจริงบนรูปร่าง ทำให้รูปร่างมีแสงเรืองแสง ฯลฯ

![เอฟเฟกต์รูปร่าง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถใช้กับรูปร่างได้ คุณสามารถใช้เอฟเฟกต์อย่างน้อยหนึ่งหรือหลายแบบกับรูปร่างหนึ่งรูป

การผสมผสานเอฟเฟกต์บางแบบดูดีกว่าบางแบบ ดังนั้น PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset คือการผสมผสานที่ได้รับการพิสูจน์แล้วว่าดูดีของสองหรือหลายเอฟเฟกต์ ด้วยวิธีนี้เมื่อเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อค้นหาการผสมที่เหมาะสม

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) ที่ทำให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for C++ รองรับเงานอกและเงาภายในสำหรับรูปร่าง คุณสามารถปรับสี ทิศทาง ระยะทาง และรัศมีเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือพาเนลโดดเด่นเหนือพื้นหลังสไลด์ เงานี้ขยายออกนอกขอบของรูปร่าง ทำให้รูปร่างดูเหมือนยกขึ้นเหนือสไลด์ ปรับสี ทิศทาง ระยะทาง และรัศมีเบลอร์ให้สอดคล้องกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด C++ นี้แสดงวิธีใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) กับสี่เหลี่ยม:

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

เมื่อต้องการคัดลอกสไตล์ภาพของเทมเพลต ให้ใช้เงาภายในเพื่อทำให้การ์ดหรือพาเนลดูเป็นช่องแทรก เงานอกขยายออกนอกรูปร่างและทำให้ดูยกขึ้น ส่วนเงาภายในจะทำให้ขอบด้านในดูมืดลง

เรียกใช้ [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) แล้วกำหนดค่า [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) ค่ารัศมีเบลอร์ที่สูงกว่าจะทำให้ขอบนุ่มขึ้น

ตัวอย่าง C++ นี้สร้างการ์ดสีน้ำเงินอ่อนพร้อมเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX:

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

หากต้องการลบเงาภายใน ให้เรียกใช้ [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) บนฟอร์แมตเอฟเฟกต์ของรูปร่าง

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for C++ คุณสามารถเพิ่มการสะท้อนคล้ายกระจกให้กับรูปร่าง ปรับพารามิเตอร์เช่น ระยะทาง ความโปร่งใส และขนาด เอฟเฟกต์นี้ทำให้การนำเสนอของคุณดูสวยงามและเป็นมืออาชีพมากขึ้น ใช้ง่ายด้วยโค้ดไม่กี่บรรทัด ทำให้สามารถนำไปใช้กับหลายองค์ประกอบได้อย่างรวดเร็วเพื่อให้การออกแบบสอดคล้องกัน

โค้ด C++ นี้แสดงวิธีใช้ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) กับรูปร่าง:

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

เพื่อใช้เอฟเฟกต์เรืองแสงกับรูปร่างใน Aspose.Slides for C++ คุณสามารถเพิ่มแสงออร่าที่นุ่มนวลรอบรูปร่าง ปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยให้รูปร่างโดดเด่นและเพิ่มความน่าสนใจให้กับสไลด์ของคุณ ใช้ง่ายด้วยโค้ดสั้น ๆ ทำให้ภาพรวมของสไลด์ดูดีขึ้น

โค้ด C++ นี้แสดงวิธีใช้ [เอฟเฟกต์เรืองแสง](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) กับรูปร่าง:

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

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides for C++ คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอร์รอบขอบของรูปร่าง เอฟเฟกต์นี้ให้ลุคที่ละเอียดอ่อนและประณีต เหมาะกับการออกแบบที่ต้องการลุคอ่อนโยน คุณสามารถปรับพารามิเตอร์เช่น รัศมีเพื่อให้ได้ผลลัพธ์ตามต้องการสำหรับรูปร่างหลายแบบในงานนำเสนอของคุณ

โค้ด C++ นี้แสดงวิธีใช้ [ขอบนุ่ม](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) กับรูปร่าง:

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

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปร่างเดียวกันได้หรือไม่?**

ได้ คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา การสะท้อน และเรืองแสงบนรูปร่างเดียวเพื่อสร้างลุคที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลากหลายประเภทรวมถึงออโตชป์, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับกลุ่มรูปร่างได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับกลุ่มรูปร่างได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมดอย่างเดียวกัน