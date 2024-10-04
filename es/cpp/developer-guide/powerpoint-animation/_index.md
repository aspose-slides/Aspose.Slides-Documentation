---
title: Animación de PowerPoint
type: docs
weight: 150
url: /es/cpp/powerpoint-animation/
keywords: "animación de PowerPoint"
description: "Animación de PowerPoint, animación de diapositivas de PowerPoint con Aspose.Slides."
---

Dado que las presentaciones están destinadas a presentar algo, su apariencia visual y comportamiento interactivo siempre se consideran al crearlas.

**La animación de PowerPoint** juega un papel importante para hacer que la presentación sea llamativa y atractiva para los espectadores. Aspose.Slides para C++ ofrece una amplia gama de opciones para agregar animación a la presentación de PowerPoint:

- aplicar varios tipos de efectos de animación de PowerPoint en formas, gráficos, tablas, objetos OLE y otros elementos de presentación.
- usar múltiples efectos de animación de PowerPoint en una forma.
- usar la línea de tiempo de animación para controlar los efectos de animación.
- crear animaciones personalizadas.

En Aspose.Slides para C++, se pueden aplicar varios efectos de animación en las formas. Dado que cada elemento en la diapositiva, incluidos texto, imágenes, objetos OLE, tablas, etc., se considera como una forma, significa que se puede aplicar un efecto de animación a cada elemento de una diapositiva.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **namespace** proporciona clases para trabajar con animaciones de PowerPoint.
## **Efectos de Animación**
Aspose.Slides soporta **más de 150 efectos de animación**, incluidos efectos de animación básicos como Bounce, PathFootball, efecto Zoom y efectos de animación específicos como OLEObjectShow, OLEObjectOpen. Puede encontrar una lista completa de efectos de animación en la enumeración [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

Además, estos efectos de animación se pueden usar en combinación con ellos:

- [ColorEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.color_effect/t)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **Animación Personalizada**
Es posible crear sus propias **animaciones personalizadas** en Aspose.Slides. 
Esto se puede lograr si combina varios comportamientos en una nueva animación personalizada.

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) es una unidad de construcción de cualquier efecto de animación de PowerPoint. Todos los efectos de animación son en realidad un conjunto de comportamientos compuestos en una estrategia. Puede combinar comportamientos en una animación personalizada una vez y reutilizarla en otras presentaciones. Si agrega un nuevo comportamiento a un efecto de animación estándar de PowerPoint, será otra animación personalizada. Por ejemplo, puede agregar un comportamiento de repetición a una animación para que se repita varias veces.

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) es un punto donde se debe aplicar el comportamiento.

## **Línea de Tiempo de Animación**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) es una colección de efectos de animación, aplicados en una forma concreta.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) es un conjunto de Secuencias utilizadas en una diapositiva concreta. Es un motor de animación representado desde PowerPoint 2002. En versiones anteriores de PowerPoint, era un desafío agregar efectos de animación a la presentación, que solo se podían lograr con diferentes soluciones alternativas. La línea de tiempo viene a reemplazar la antigua clase AnimationSettings y proporciona un modelo de objeto más claro para la animación de PowerPoint. Una diapositiva puede tener solo una línea de tiempo de animación.
## **Animación Interactiva**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) permite definir acciones del usuario (por ejemplo, clic en un botón), que harán que una determinada animación comience. Los disparadores se han agregado en la última versión de PowerPoint únicamente.

## **Animación de Formas**
Aspose.Slides permite aplicar animación a formas, que pueden ser texto, rectángulo, línea, marco, objeto OLE, etc.

{{% alert color="primary" %}} 
Leer más [**Sobre la Animación de Formas**](/slides/es/cpp/shape-animation/).
{{% /alert %}}

## **Gráficos Animados**
Para crear gráficos animados, debe usar todas las mismas clases que para las formas. Sin embargo, es posible usar la animación de PowerPoint solo en categorías de gráficos o series de gráficos. También puede aplicar un efecto de animación a un elemento de categoría o elemento de serie.

{{% alert color="primary" %}} 
Leer más [**Sobre los Gráficos Animados**](/slides/es/cpp/animated-charts/).
{{% /alert %}}

## **Texto Animado**
Además del texto animado, también es posible aplicar animación a un párrafo.

{{% alert color="primary" %}} 
Leer más [**Sobre el Texto Animado**](/slides/es/cpp/animated-text/).
{{% /alert %}}