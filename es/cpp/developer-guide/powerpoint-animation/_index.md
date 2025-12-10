---
title: Mejorar presentaciones PowerPoint con animaciones en C++
linktitle: Animación PowerPoint
type: docs
weight: 150
url: /es/cpp/powerpoint-animation/
keywords:
- agregar animación
- actualizar animación
- cambiar animación
- eliminar animación
- administrar animación
- controlar animación
- efecto de animación
- animación PowerPoint
- línea de tiempo de animación
- animación interactiva
- animación personalizada
- animación de forma
- gráfico animado
- texto animado
- forma animada
- objeto OLE animado
- imagen animada
- tabla animada
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo agregar y controlar efectos de animación avanzados en Aspose.Slides para C++ para crear presentaciones dinámicas de PowerPoint y OpenDocument."
---

Dado que las presentaciones están destinadas a presentar algo, su apariencia visual y comportamiento interactivo siempre se consideran al crearlas.

**PowerPoint animation** juega un papel importante para que la presentación sea llamativa y atractiva para los espectadores. Aspose.Slides for C++ ofrece una amplia gama de opciones para agregar animación a una presentación de PowerPoint:

- aplicar varios tipos de efectos de animación de PowerPoint en formas, gráficos, tablas, objetos OLE y otros elementos de la presentación.
- usar múltiples efectos de animación de PowerPoint en una forma.
- usar la línea de tiempo de animación para controlar los efectos de animación.
- crear animación personalizada.

En Aspose.Slides for C++, se pueden aplicar varios efectos de animación en las formas. Dado que cada elemento en la diapositiva, incluidos texto, imágenes, OLE Object, tabla, etc., se considera una forma, significa que podemos aplicar efectos de animación en cada elemento de una diapositiva.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **namespace** proporciona clases para trabajar con animaciones de PowerPoint.
## **Efectos de animación**
Aspose.Slides admite **más de 150 efectos de animación**, incluidos efectos básicos como Bounce, PathFootball, efecto Zoom y efectos específicos como OLEObjectShow, OLEObjectOpen. Puedes encontrar una lista completa de efectos de animación en la enumeración [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) enumeración.

Además, estos efectos de animación pueden usarse en combinación con ellos:

- [ColorEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.color_effect/t)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **Animación personalizada**
Es posible crear tus propias **animaciones personalizadas** en Aspose.Slides.  
Esto se puede lograr si combinas varios comportamientos en una nueva animación personalizada.

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) es una unidad constructora de cualquier efecto de animación de PowerPoint. Todos los efectos de animación son en realidad un conjunto de comportamientos compuestos en una estrategia. Puedes combinar comportamientos en una animación personalizada una vez y reutilizarla en otras presentaciones. Si agregas un nuevo comportamiento a un efecto de animación estándar de PowerPoint, será otra animación personalizada. Por ejemplo, puedes agregar un comportamiento de repetición a una animación para que se repita varias veces.

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) es un punto donde se debe aplicar el comportamiento.

## **Línea de tiempo de animación**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) es una colección de efectos de animación, aplicados a una forma concreta.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) es un conjunto de Secuencias usadas en una diapositiva concreta. Es un motor de animación que existe desde PowerPoint 2002. En versiones anteriores de PowerPoint, era difícil agregar efectos de animación a la presentación, lo que solo se podía lograr con distintas soluciones alternativas. La línea de tiempo reemplaza a la antigua clase AnimationSettings y brinda un modelo de objetos más claro para la animación de PowerPoint. Una diapositiva solo puede tener una línea de tiempo de animación.

## **Animación interactiva**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) permite definir acciones de usuario (p. ej., clic de botón), que harán que una animación específica comience. Los disparadores solo se han añadido en la última versión de PowerPoint.

## **Animación de forma**
Aspose.Slides permite aplicar animación a formas, que pueden ser texto, rectángulo, línea, marco, OLE Object, etc.

{{% alert color="primary" %}} 
Leer más [**Acerca de la animación de forma**](/slides/es/cpp/shape-animation/).
{{% /alert %}}

## **Gráficos animados**
Para crear gráficos animados, debes usar las mismas clases que para las formas. Sin embargo, es posible usar la animación de PowerPoint solo en categorías de gráfico o series de gráfico. También puedes aplicar efectos de animación a un elemento de categoría o a un elemento de serie.

{{% alert color="primary" %}} 
Leer más [**Acerca de los gráficos animados**](/slides/es/cpp/animated-charts/).
{{% /alert %}}

## **Texto animado**
Además del texto animado, también es posible aplicar animación a un párrafo.

{{% alert color="primary" %}} 
Leer más [**Acerca del texto animado**](/slides/es/cpp/animated-text/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se conservarán las animaciones al exportar a PDF?**

No. PDF es un formato estático, por lo que las animaciones y [transiciones de diapositiva](/slides/es/cpp/slide-transition/) no se reproducen. Si necesitas movimiento, exporta a [HTML5](/slides/es/cpp/export-to-html5/), [GIF animado](/slides/es/cpp/convert-powerpoint-to-animated-gif/), o [video](/slides/es/cpp/convert-powerpoint-to-video/) en su lugar.

**¿Puedo convertir una presentación animada en un video y controlar la velocidad de fotogramas y el tamaño del cuadro?**

Sí. Puedes [renderizar la presentación como fotogramas](/slides/es/cpp/convert-powerpoint-to-video/) y codificarlos en un video (p. ej., mediante ffmpeg), eligiendo los FPS y la resolución. Las animaciones y las transiciones de diapositiva se reproducen durante el renderizado.

**¿Se mantendrán las animaciones intactas al trabajar con ODP (no solo PPTX)?**

PPT, PPTX y ODP son compatibles para [leer](/slides/es/cpp/open-presentation/) y [escribir](/slides/es/cpp/save-presentation/), pero las diferencias de formato hacen que ciertos efectos puedan verse o comportarse ligeramente diferentes. Valida los casos críticos con muestras reales.