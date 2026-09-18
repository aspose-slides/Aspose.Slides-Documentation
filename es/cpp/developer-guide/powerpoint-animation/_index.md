---
title: Mejorar presentaciones de PowerPoint con animaciones en C++
linktitle: Animación de PowerPoint
type: docs
weight: 150
url: /es/cpp/powerpoint-animation/
keywords:
- añadir animación
- actualizar animación
- cambiar animación
- eliminar animación
- gestionar animación
- controlar animación
- efecto de animación
- animación de PowerPoint
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
description: "Aprenda cómo añadir y controlar efectos avanzados de animación en Aspose.Slides para C++ y crear presentaciones dinámicas de PowerPoint y OpenDocument."
---
## **Introducción**

Dado que las presentaciones están diseñadas para presentar algo, su apariencia visual y su comportamiento interactivo siempre se tienen en cuenta durante su creación.

**PowerPoint animation** juega un papel importante al hacer que una presentación sea llamativa y atractiva para los espectadores. Aspose.Slides ofrece una amplia gama de opciones para añadir animaciones a presentaciones de PowerPoint:

- Aplicar varios tipos de efectos de animación de PowerPoint a formas, gráficos, tablas, objetos OLE y otros elementos de la presentación.
- Utilizar varios efectos de animación de PowerPoint en una sola forma.
- Utilizar la línea de tiempo de animación para controlar los efectos de animación.
- Crear animaciones personalizadas.

En Aspose.Slides, se pueden aplicar varios efectos de animación a las formas. Dado que cada elemento en una diapositiva, incluyendo texto, imágenes, objetos OLE y tablas, se considera una forma, los efectos de animación pueden aplicarse a cualquier elemento de la diapositiva.

El [Aspose::Slides::Animation](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/) namespace proporciona clases para trabajar con animaciones de PowerPoint.

## **Efectos de animación**

Aspose.Slides admite **más de 150 efectos de animación**, incluidos efectos básicos como Bounce, PathFootball y Zoom, y efectos específicos como OLEObjectShow y OLEObjectOpen. Puede encontrar una lista completa en la enumeración [EffectType](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/effecttype/).

Además, estos efectos de animación pueden usarse en combinación con los siguientes comportamientos:

- [ColorEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/seteffect/)

## **Animación personalizada**

Para ejemplos completos en C++ que crean, inspeccionan y modifican comportamientos y rutas de movimiento editables, consulte [Custom Animation](/slides/es/cpp/custom-animation/).

Es posible crear sus propias **animaciones personalizadas** en Aspose.Slides. Esto se puede lograr combinando varios comportamientos en una nueva animación personalizada.

[Behavior](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/behavior/) es un bloque de construcción de un efecto de animación de PowerPoint. Combine comportamientos para personalizar un efecto, o añada un comportamiento para ampliar un efecto predefinido. La repetición se configura mediante la configuración de tiempo en lugar de un comportamiento de repetición separado.

[Animation Point](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/point/) es un punto en el que se debe aplicar un comportamiento.

## **Línea de tiempo de animación**

[Sequence](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/sequence/) es una colección de efectos de animación que pueden dirigirse a diferentes formas.

[IAnimationTimeLine](https://reference.aspose.com/slides/es/cpp/aspose.slides/ianimationtimeline/) es un conjunto de secuencias utilizado en una diapositiva específica. Es un motor de animación introducido en PowerPoint 2002. En versiones anteriores de PowerPoint, añadir efectos de animación a las presentaciones era complicado y solo se podía lograr mediante diversas soluciones alternativas. La línea de tiempo ofrece un modelo de objetos más claro para las animaciones de PowerPoint. Una diapositiva solo puede tener una línea de tiempo de animación.

## **Animación interactiva**

[Trigger](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/effecttriggertype/) le permite definir acciones del usuario, como hacer clic en un botón, que inicien una animación concreta.

## **Animación de formas**

Aspose.Slides le permite aplicar animaciones a formas, que pueden incluir texto, rectángulos, líneas, marcos, objetos OLE y más.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca de la animación de forma**](/slides/es/cpp/shape-animation/).
{{% /alert %}}

## **Gráficos animados**

Para crear gráficos animados, debe utilizar las mismas clases que para las formas. Sin embargo, las animaciones de PowerPoint solo pueden aplicarse a categorías de gráfico o series de gráfico. También puede aplicar efectos de animación a un elemento de categoría o a un elemento de serie.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca de los gráficos animados**](/slides/es/cpp/animated-charts/).
{{% /alert %}}

## **Texto animado**

Además de animar texto, puede aplicar animación a un párrafo.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca del texto animado**](/slides/es/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**¿Se conservarán las animaciones al exportar a PDF?**

No. PDF es un formato estático, por lo que las animaciones y las [transiciones de diapositivas](/slides/es/cpp/slide-transition/) no se reproducen. Si necesita movimiento, exporte a [HTML5](/slides/es/cpp/export-to-html5/), [GIF animado](/slides/es/cpp/convert-powerpoint-to-animated-gif/) o [vídeo](/slides/es/cpp/convert-powerpoint-to-video/) en su lugar.

**¿Puedo convertir una presentación animada en un vídeo y controlar la velocidad de fotogramas y el tamaño del fotograma?**

Sí. Puede [renderizar la presentación como fotogramas](/slides/es/cpp/convert-powerpoint-to-video/) y codificarlos en un vídeo (p. ej., mediante ffmpeg), eligiendo los FPS y la resolución. Las animaciones y las transiciones de diapositivas se reproducen durante el renderizado.

**¿Se mantendrán las animaciones intactas al trabajar con ODP (no solo PPTX)?**

PPT, PPTX y ODP son compatibles para [leer](/slides/es/cpp/open-presentation/) y [escribir](/slides/es/cpp/save-presentation/), pero esto no garantiza la conservación de las animaciones. Los datos de animación personalizada pueden perderse al convertir a ODP. Consulte [Custom Animation](/slides/es/cpp/custom-animation/) para obtener ejemplos y orientación sobre la comprobación de la compatibilidad de formatos.