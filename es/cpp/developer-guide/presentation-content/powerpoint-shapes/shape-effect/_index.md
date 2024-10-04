---
title: Efecto de Forma
type: docs
weight: 30
url: /cpp/shape-effect
keywords: "Efecto de forma, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Aplica efecto a una forma de PowerPoint en C++"
---

Mientras que los efectos en PowerPoint pueden usarse para hacer que una forma destaque, difieren de los [rellenos](/slides/cpp/shape-formatting/#gradient-fill) o contornos. Usando los efectos de PowerPoint, puedes crear reflexiones convincentes en una forma, difundir el brillo de una forma, etc.

<img src="shape-effect.png" alt="efecto-de-forma" style="zoom:50%;" />

* PowerPoint proporciona seis efectos que se pueden aplicar a las formas. Puedes aplicar uno o más efectos a una forma.

* Algunas combinaciones de efectos se ven mejor que otras. Por esta razón, PowerPoint ofrece opciones bajo **Preset**. Las opciones de Preset son esencialmente una combinación conocida de dos o más efectos que se ven bien. De este modo, al seleccionar un preset, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides proporciona propiedades y métodos bajo la clase [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format/) que te permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar Efecto de Sombra**

Este código C++ te muestra cómo aplicar el efecto de sombra exterior ([OuterShadowEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) a un rectángulo:

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

## **Aplicar Efecto de Reflexión**

Este código C++ te muestra cómo aplicar el efecto de reflexión a una forma:

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

## **Aplicar Efecto de Brillo**

Este código C++ te muestra cómo aplicar el efecto de brillo a una forma:

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

## **Aplicar Efecto de Bordes Suaves**

Este código C++ te muestra cómo aplicar bordes suaves a una forma:

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