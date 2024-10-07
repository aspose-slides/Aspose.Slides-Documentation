---
title: تأثير الشكل
type: docs
weight: 30
url: /cpp/shape-effect
keywords: "تأثير الشكل، تقديم PowerPoint، C++، CPP، Aspose.Slides for C++"
description: "تطبيق تأثير على شكل PowerPoint في C++"
---

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل بارزًا، إلا أنها تختلف عن [التعبئات](/slides/cpp/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على شكل معين، ونشر توهج الشكل، وما إلى ذلك.

<img src="shape-effect.png" alt="تأثير الشكل" style="zoom:50%;" />

* يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على شكل معين.

* بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يوجد خيارات PowerPoint تحت **Preset**. خيارات Preset هي في الأساس تركيبة معروفة ذات مظهر جيد من تأثيرين أو أكثر. بهذه الطريقة، من خلال اختيار إعداد مسبق، لن تضيع الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة جميلة.

يوفر Aspose.Slides خصائص وطرق تحت الفئة [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format/) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint التقديمية.

## **تطبيق تأثير الظل**

يوضح لك هذا الكود بلغة C++ كيفية تطبيق تأثير الظل الخارجي ([OuterShadowEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) على مستطيل:

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

## **تطبيق تأثير الانعكاس**

يوضح لك هذا الكود بلغة C++ كيفية تطبيق تأثير الانعكاس على شكل معين:

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

## **تطبيق تأثير التوهج**

يوضح لك هذا الكود بلغة C++ كيفية تطبيق تأثير التوهج على شكل معين:

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

## **تطبيق تأثير الحواف الناعمة**

يوضح لك هذا الكود بلغة C++ كيفية تطبيق الحواف الناعمة على شكل معين:

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