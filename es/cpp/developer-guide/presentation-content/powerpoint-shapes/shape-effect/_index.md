---
title: Aplicar efectos de forma en presentaciones usando C++
linktitle: Efecto de forma
type: docs
weight: 30
url: /es/cpp/shape-effect/
keywords:
- efecto de forma
- efecto de sombra
- efecto de reflexión
- efecto de brillo
- efecto de bordes suaves
- formato de efecto
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Transforme sus archivos PPT y PPTX con efectos de forma avanzados usando Aspose.Slides para C++ — cree diapositivas impactantes y profesionales en segundos."
---

Aunque los efectos en PowerPoint pueden usarse para resaltar una forma, difieren de los [rellenos](/slides/es/cpp/shape-formatting/#gradient-fill) o contornos. Con los efectos de PowerPoint, puedes crear reflejos convincentes en una forma, extender el brillo de una forma, etc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint ofrece seis efectos que se pueden aplicar a formas. Puedes aplicar uno o más efectos a una forma. 

* Algunas combinaciones de efectos se ven mejor que otras. Por esta razón, PowerPoint ofrece opciones bajo **Preset**. Las opciones de Preset son esencialmente una combinación conocida y atractiva de dos o más efectos. De esta manera, al seleccionar un preset, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides ofrece propiedades y métodos bajo la clase [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format/) que permiten aplicar los mismos efectos a formas en presentaciones de PowerPoint.

## **Aplicar un efecto de sombra**

Este código C++ muestra cómo aplicar el efecto de sombra externa ([OuterShadowEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) a un rectángulo:
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


## **Aplicar un efecto de reflexión**

Este código C++ muestra cómo aplicar el efecto de reflexión a una forma:
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


## **Aplicar un efecto de brillo**

Este código C++ muestra cómo aplicar el efecto de brillo a una forma:
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


## **Aplicar un efecto de bordes suaves**

Este código C++ muestra cómo aplicar los bordes suaves a una forma:
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


## **Preguntas frecuentes**

**¿Puedo aplicar varios efectos a la misma forma?**

Sí, puedes combinar diferentes efectos, como sombra, reflexión y brillo, en una sola forma para crear una apariencia más dinámica.

**¿A qué formas puedo aplicar efectos?**

Puedes aplicar efectos a diversas formas, incluidas autoshapes, gráficos, tablas, imágenes, objetos SmartArt, objetos OLE y más.

**¿Puedo aplicar efectos a formas agrupadas?**

Sí, puedes aplicar efectos a formas agrupadas. El efecto se aplicará a todo el grupo.