---
title: Formeffekt
type: docs
weight: 30
url: /de/cpp/shape-effect
keywords: "Formeffekt, PowerPoint-Präsentation, C++, CPP, Aspose.Slides für C++"
description: "Effekt auf eine PowerPoint-Form in C++ anwenden"
---

Während Effekte in PowerPoint verwendet werden können, um eine Form hervorzuheben, unterscheiden sie sich von [Füllungen](/slides/de/cpp/shape-formatting/#gradient-fill) oder Umrissen. Mit PowerPoint-Effekten können Sie überzeugende Reflexionen auf einer Form erstellen, den Glanz einer Form verbreiten usw.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint bietet sechs Effekte, die auf Formen angewendet werden können. Sie können einer Form einen oder mehrere Effekte hinzufügen. 

* Einige Kombinationen von Effekten sehen besser aus als andere. Aus diesem Grund bietet PowerPoint Optionen unter **Vorgabe**. Die Vorgabeoptionen sind im Wesentlichen eine bekannte, gut aussehende Kombination aus zwei oder mehr Effekten. Auf diese Weise müssen Sie beim Auswählen einer Vorgabe keine Zeit mit dem Testen oder Kombinieren verschiedener Effekte verschwenden, um eine ansprechende Kombination zu finden.

Aspose.Slides bietet Eigenschaften und Methoden unter der [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format/) Klasse, mit denen Sie dieselben Effekte auf Formen in PowerPoint-Präsentationen anwenden können.

## **Schatteneffekt anwenden**

Dieser C++-Code zeigt Ihnen, wie Sie den äußeren Schatteneffekt ([OuterShadowEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) auf ein Rechteck anwenden:

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

## **Reflexionseffekt anwenden**

Dieser C++-Code zeigt Ihnen, wie Sie den Reflexionseffekt auf eine Form anwenden:

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

## **Glüheffekt anwenden**

Dieser C++-Code zeigt Ihnen, wie Sie den Glüheffekt auf eine Form anwenden:

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

## **Weiche Kanten anwenden**

Dieser C++-Code zeigt Ihnen, wie Sie die weichen Kanten auf eine Form anwenden:

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