---
title: Appliquer des effets de forme aux présentations avec C++
linktitle: Effet de forme
type: docs
weight: 30
url: /fr/cpp/shape-effect/
keywords:
- effet de forme
- effet d'ombre
- effet de réflexion
- effet de lueur
- effet de bords doux
- format d'effet
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Transformez vos fichiers PPT et PPTX avec des effets de forme avancés grâce à Aspose.Slides pour C++ — créez des diapositives percutantes et professionnelles en quelques secondes."
---


Alors que les effets dans PowerPoint peuvent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/fr/cpp/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets PowerPoint, vous pouvez créer des reflets convaincants sur une forme, diffuser la lueur d’une forme, etc.

<img src="shape-effect.png" alt="effet-de-forme" style="zoom:50%;" />

* PowerPoint propose six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme. 

* Certaines combinaisons d'effets sont plus attrayantes que d'autres. Pour cette raison, PowerPoint propose des options sous **Preset**. Les options Préréglées sont essentiellement une combinaison connue de deux effets ou plus offrant un bon rendu. Ainsi, en sélectionnant un préréglé, vous n’aurez pas à perdre du temps à tester ou à combiner différents effets pour trouver une bonne combinaison.

Aspose.Slides fournit des propriétés et des méthodes sous la classe [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format/) qui vous permettent d’appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Appliquer un effet d'ombre**

Ce code C++ vous montre comment appliquer l’effet d’ombre extérieure ([OuterShadowEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) à un rectangle :
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


## **Appliquer un effet de réflexion**

Ce code C++ vous montre comment appliquer l’effet de réflexion à une forme :
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


## **Appliquer un effet de lueur**

Ce code C++ vous montre comment appliquer l’effet de lueur à une forme :
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


## **Appliquer un effet de bords doux**

Ce code C++ vous montre comment appliquer les bords doux à une forme :
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


## **FAQ**

**Puis-je appliquer plusieurs effets à la même forme ?**

Oui, vous pouvez combiner différents effets, tels que l’ombre, la réflexion et la lueur, sur une seule forme pour créer un aspect plus dynamique.

**À quelles formes puis‑je appliquer des effets ?**

Vous pouvez appliquer des effets à diverses formes, y compris les formes automatiques, les graphiques, les tableaux, les images, les objets SmartArt, les objets OLE, etc.

**Puis‑je appliquer des effets à des formes groupées ?**

Oui, vous pouvez appliquer des effets à des formes groupées. L’effet sera appliqué à l’ensemble du groupe.