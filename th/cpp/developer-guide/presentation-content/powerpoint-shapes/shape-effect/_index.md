---
title: ใช้เอฟเฟกต์รูปทรงในงานนำเสนอด้วย C++
linktitle: เอฟเฟกต์รูปทรง
type: docs
weight: 30
url: /th/cpp/shape-effect/
keywords:
- เอฟเฟกต์รูปทรง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์แสงเรือง
- เอฟเฟกต์ขอบอ่อน
- รูปแบบเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ C++ — สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้เพื่อทำให้รูปทรงโดดเด่นขึ้น, พวกมันแตกต่างจาก [การเติมสี](/slides/th/cpp/shape-formatting/#gradient-fill) หรือเส้นขอบ. การใช้เอฟเฟกต์ของ PowerPoint, คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปทรง, กระจาย glow ของรูปทรง, เป็นต้น.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถใช้กับรูปทรงได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปทรงหนึ่งได้. 

* การรวมเอฟเฟกต์บางอย่างดูดีกว่าการรวมอื่น ๆ ด้วยเหตุนี้ PowerPoint มีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset นั้นโดยพื้นฐานคือการรวมเอฟเฟกต์ที่ดูดีสองแบบหรือมากกว่าที่รู้จักกันดี ด้วยวิธีนี้เมื่อเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือรวมเอฟเฟกต์ต่าง ๆ เพื่อค้นหาการรวมที่ดี.

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.effect_format/) ที่ให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint.

## **ใช้เอฟเฟกต์เงา**

โค้ด C++ นี้แสดงวิธีการใช้เอฟเฟกต์เงานอก ([OuterShadowEffect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) กับสี่เหลี่ยมผืนผ้า:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(System::Drawing::Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **ใช้เอฟเฟกต์การสะท้อน**

โค้ด C++ นี้แสดงวิธีการใช้เอฟเฟกต์การสะท้อนกับรูปทรง:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(55);
reflectionEffect->set_BlurRadius(4);

pres->Save(u"reflection.pptx", SaveFormat::Pptx);
```

## **ใช้เอฟเฟกต์ Glow**

โค้ด C++ นี้แสดงวิธีการใช้เอฟเฟกต์ Glow กับรูปทรง:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(System::Drawing::Color::get_Magenta());
glowEffect->set_Radius(15);

pres->Save(u"glow.pptx", SaveFormat::Pptx);
```

## **ใช้เอฟเฟกต์ขอบอ่อน**

โค้ด C++ นี้แสดงวิธีการใช้ขอบอ่อนกับรูปทรง:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(15);

pres->Save(u"softEdges.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปทรงเดียวกันได้หรือไม่?**

ได้, คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อน, และ Glow, บนรูปทรงเดียวเพื่อสร้างลักษณะที่ไดนามิกมากขึ้น.

**รูปทรงใดที่ฉันสามารถใช้เอฟเฟกต์ได้?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงหลากหลายรวมถึง autoshapes, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE, และอื่น ๆ อีกมากมาย.

**ฉันสามารถใช้เอฟเฟ็กต์กับรูปทรงที่จัดกลุ่มได้หรือไม่?**

ได้, คุณสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด.