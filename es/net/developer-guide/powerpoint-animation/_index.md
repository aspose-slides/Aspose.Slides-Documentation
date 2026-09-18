---
title: Mejorar presentaciones de PowerPoint con animaciones en .NET
linktitle: Animación de PowerPoint
type: docs
weight: 150
url: /es/net/powerpoint-animation/
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
- presentación de PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Explore las capacidades de Aspose.Slides para .NET en la gestión de animaciones de PowerPoint. Esta visión general destaca las características clave y ofrece ideas para mejorar sus presentaciones."
---
## **Introducción**

Dado que las presentaciones están destinadas a presentar algo, su aspecto visual y comportamiento interactivo siempre se tienen en cuenta durante su creación.

**Animación de PowerPoint** juega un papel importante para que una presentación resulte llamativa y atractiva para los espectadores. Aspose.Slides para .NET ofrece una amplia variedad de opciones para añadir animaciones a presentaciones de PowerPoint:

- Aplicar varios tipos de efectos de animación de PowerPoint a formas, gráficos, tablas, objetos OLE y otros elementos de la presentación.
- Utilizar varios efectos de animación de PowerPoint en una única forma.
- Utilizar la línea de tiempo de animación para controlar los efectos de animación.
- Crear animaciones personalizadas.

En Aspose.Slides para .NET, se pueden aplicar diversos efectos de animación a las formas. Dado que cada elemento en una diapositiva, incluido el texto, imágenes, objetos OLE y tablas, se considera una forma, los efectos de animación pueden aplicarse a cualquier elemento de la diapositiva.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/es/net/aspose.slides.animation/) espacio de nombres proporciona clases para trabajar con animaciones de PowerPoint.

## **Efectos de animación**

Aspose.Slides admite **más de 150 efectos de animación**, incluidos efectos básicos como Bounce, PathFootball y Zoom, así como efectos específicos como OLEObjectShow y OLEObjectOpen. Puedes encontrar una lista completa de efectos de animación en la enumeración [EffectType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/effecttype).

Además, estos efectos de animación pueden usarse en combinación con los siguientes:

- [ColorEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/seteffect)

## **Animación personalizada**

Para ver ejemplos completos en C# que crean, inspeccionan y modifican comportamientos y trayectorias de movimiento editables, consulte [Animación personalizada](/slides/es/net/custom-animation/).

Es posible crear tus propias **animaciones personalizadas** en Aspose.Slides. Esto se puede lograr combinando varios comportamientos en una nueva animación personalizada.

[Behavior](https://reference.aspose.com/slides/es/net/aspose.slides.animation/behavior) es un bloque de construcción de un efecto de animación de PowerPoint. Combina comportamientos para personalizar un efecto, o añade un comportamiento para ampliar un efecto predefinido. La repetición se configura mediante la configuración de tiempo en lugar de un comportamiento de repetición separado.

[Animation Point](https://reference.aspose.com/slides/es/net/aspose.slides.animation/point) es un punto en el que se debe aplicar un comportamiento.

## **Línea de tiempo de animación**

[Sequence](https://reference.aspose.com/slides/es/net/aspose.slides.animation/sequence) es una colección de efectos de animación que pueden dirigirse a diferentes formas.

[Timeline](https://reference.aspose.com/slides/es/net/aspose.slides.animation/animationtimeline) es un conjunto de secuencias utilizado en una diapositiva específica. Es un motor de animación introducido en PowerPoint 2002. En versiones anteriores de PowerPoint, añadir efectos de animación a las presentaciones era complicado y solo se podía lograr mediante diversas soluciones alternativas. La línea de tiempo reemplaza la antigua clase AnimationSettings y proporciona un modelo de objetos más claro para las animaciones de PowerPoint. Una diapositiva solo puede tener una línea de tiempo de animación.

## **Animación interactiva**

[Trigger](https://reference.aspose.com/slides/es/net/aspose.slides.animation/effecttriggertype) permite definir acciones de usuario (p.ej., un clic de botón) que iniciarán una animación específica. Los disparadores se introdujeron en la última versión de PowerPoint.

## **Animación de forma**

Aspose.Slides permite aplicar animaciones a formas, que pueden incluir texto, rectángulos, líneas, marcos, objetos OLE y más.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca de la animación de forma**](/slides/es/net/shape-animation/).
{{% /alert %}}

## **Gráficos animados**

Para crear gráficos animados, debes utilizar las mismas clases que para las formas. Sin embargo, las animaciones de PowerPoint solo pueden aplicarse a categorías de gráfico o series de gráfico. También puedes aplicar efectos de animación a un elemento de categoría o a un elemento de serie.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca de los gráficos animados**](/slides/es/net/animated-charts/).
{{% /alert %}}

## **Texto animado**

Además de animar texto, puedes aplicar animación a un párrafo.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca del texto animado**](/slides/es/net/animated-text/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se conservarán las animaciones al exportar a PDF?**

No. PDF es un formato estático, por lo que las animaciones y las [transiciones de diapositiva](/slides/es/net/slide-transition/) no se reproducen. Si necesitas movimiento, exporta a [HTML5](/slides/es/net/export-to-html5/), [GIF animado](/slides/es/net/convert-powerpoint-to-animated-gif/) o [video](/slides/es/net/convert-powerpoint-to-video/) en su lugar.

**¿Puedo convertir una presentación animada en un video y controlar la velocidad de fotogramas y el tamaño del fotograma?**

Sí. Puedes [renderizar la presentación como fotogramas](/slides/es/net/convert-powerpoint-to-video/) y codificarlos en un video (p.ej., mediante ffmpeg), eligiendo los FPS y la resolución. Las animaciones y las transiciones de diapositiva se reproducen durante el renderizado.

**¿Se mantendrán intactas las animaciones al trabajar con ODP (no solo PPTX)?**

PPT, PPTX y ODP son compatibles para [leer](/slides/es/net/open-presentation/) y [escribir](/slides/es/net/save-presentation/), pero esto no garantiza la conservación de las animaciones. Los datos de animación personalizada pueden perderse al convertir a ODP. Consulta [Animación personalizada](/slides/es/net/custom-animation/) para un ejemplo probado y limitaciones de formato.