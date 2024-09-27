---
title: Эффект формы
type: docs
weight: 30
url: /ru/cpp/shape-effect
keywords: "Эффект формы, Презентация PowerPoint, C++, CPP, Aspose.Slides для C++"
description: "Применение эффекта к форме PowerPoint на C++"
---

Хотя эффекты в PowerPoint могут использоваться, чтобы сделать фигуру более заметной, они отличаются от [заполнений](/slides/ru/cpp/shape-formatting/#gradient-fill) или контуров. Используя эффекты PowerPoint, вы можете создать правдоподобные отражения на фигурах, размыть сияние фигуры и т. д.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint предоставляет шесть эффектов, которые можно применять к фигурам. Вы можете применить один или несколько эффектов к фигуре.

* Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint предусмотрены опции **Предустановки**. Опции предустановок по сути представляют собой известную хорошо выглядящую комбинацию двух или более эффектов. Таким образом, выбрав предустановку, вы не потратите время на тестирование или комбинирование различных эффектов, чтобы найти удачную комбинацию.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format/), которые позволяют применять те же эффекты к фигурам в презентациях PowerPoint.

## **Применение эффекта тени**

Этот код на C++ показывает, как применить эффект внешней тени ([OuterShadowEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) к прямоугольнику:

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

## **Применение эффекта отражения**

Этот код на C++ показывает, как применить эффект отражения к фигуре:

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

## **Применение эффекта свечения**

Этот код на C++ показывает, как применить эффект свечения к фигуре:

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

## **Применение эффекта мягких краев**

Этот код на C++ показывает, как применить эффект мягких краев к фигуре:

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