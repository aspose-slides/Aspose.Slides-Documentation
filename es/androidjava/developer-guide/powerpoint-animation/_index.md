---
title: Mejorar presentaciones de PowerPoint con animaciones en Android
linktitle: Animación de PowerPoint
type: docs
weight: 150
url: /es/androidjava/powerpoint-animation/
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
- Android
- Java
- Aspose.Slides
description: "Explore las capacidades de Aspose.Slides para Android mediante Java al gestionar animaciones de PowerPoint. Esta visión general destaca las funciones clave."
---
## **Introducción**

Dado que las presentaciones tienen como objetivo presentar algo, siempre se tiene en cuenta su apariencia visual y su comportamiento interactivo durante su creación.

**PowerPoint animation** desempeña un papel importante para que una presentación sea llamativa y atractiva para los espectadores. Aspose.Slides ofrece una amplia gama de opciones para añadir animaciones a presentaciones de PowerPoint:

- Aplicar varios tipos de efectos de animación de PowerPoint a formas, gráficos, tablas, objetos OLE y otros elementos de la presentación.
- Utilizar varios efectos de animación de PowerPoint en una única forma.
- Utilizar la línea de tiempo de animación para controlar los efectos de animación.
- Crear animaciones personalizadas.

En Aspose.Slides, se pueden aplicar varios efectos de animación a las formas. Dado que cada elemento en una diapositiva, incluido el texto, las imágenes, los objetos OLE y las tablas, se considera una forma, los efectos de animación pueden aplicarse a cualquier elemento de la diapositiva.

## **Efectos de animación**
Aspose.Slides admite **más de 150 efectos de animación**, incluidos efectos básicos como Bounce, PathFootball y Zoom, y efectos específicos como OLEObjectShow y OLEObjectOpen. Puede encontrar una lista completa en la clase [EffectType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/effecttype/).

Además, estos efectos de animación pueden usarse en combinación con los siguientes comportamientos:

- [ColorEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SetEffect)

## **Animación personalizada**

Para obtener ejemplos completos en Java que crean, inspeccionan y modifican comportamientos y rutas de movimiento editables, consulte [Custom Animation](/slides/es/java/custom-animation/).

Es posible crear sus propias **animaciones personalizadas** en Aspose.Slides. Esto se puede lograr combinando varios comportamientos en una nueva animación personalizada.

[Behavior](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/behavior/) es un bloque de construcción de un efecto de animación de PowerPoint. Combine comportamientos para personalizar un efecto, o añada un comportamiento para ampliar un efecto predefinido. La repetición se configura a través de la configuración de temporización en lugar de un comportamiento de repetición separado.

[Animation Point](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/point/) es un punto en el que se debe aplicar un comportamiento.

## **Línea de tiempo de animación**
[Sequence](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sequence/) es una colección de efectos de animación que pueden dirigirse a diferentes formas.

[Timeline](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/animationtimeline/) es un conjunto de secuencias utilizado en una diapositiva específica. Es un motor de animación introducido en PowerPoint 2002. En versiones anteriores de PowerPoint, añadir efectos de animación a las presentaciones era complicado y sólo se podía lograr mediante diversas soluciones alternativas. La línea de tiempo proporciona un modelo de objetos más claro para las animaciones de PowerPoint. Una diapositiva sólo puede tener una línea de tiempo de animación.

## **Animación interactiva**
[Trigger](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/effecttriggertype/) le permite definir acciones de usuario, como hacer clic en un botón, que inician una animación concreta.

## **Animación de formas**
Aspose.Slides le permite aplicar animaciones a formas, que pueden incluir texto, rectángulos, líneas, marcos, objetos OLE y más.

{{% alert color="info" title="Note" %}}
Leer más [**About Shape Animation**](/slides/es/androidjava/shape-animation/).
{{% /alert %}}

## **Gráficos animados**
Para crear gráficos animados, debe utilizar las mismas clases que para las formas. Sin embargo, las animaciones de PowerPoint sólo pueden aplicarse a categorías de gráficos o series de gráficos. También puede aplicar efectos de animación a un elemento de categoría o a un elemento de serie.

{{% alert color="info" title="Note" %}}
Leer más [**About Animated Charts**](/slides/es/androidjava/animated-charts/).
{{% /alert %}}

## **Texto animado**
Además de animar texto, puede aplicar animación a un párrafo.

{{% alert color="info" title="Note" %}}
Leer más [**About Animated Text**](/slides/es/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**¿Se conservarán las animaciones al exportar a PDF?**

No. PDF es un formato estático, por lo que las animaciones y las [slide transitions](/slides/es/androidjava/slide-transition/) no se reproducen. Si necesita movimiento, exporte a [HTML5](/slides/es/androidjava/export-to-html5/), [animated GIF](/slides/es/androidjava/convert-powerpoint-to-animated-gif/), o [video](/slides/es/androidjava/convert-powerpoint-to-video/) en su lugar.

**¿Puedo convertir una presentación animada en un video y controlar la velocidad de fotogramas y el tamaño del cuadro?**

Sí. Puede [render the presentation as frames](/slides/es/androidjava/convert-powerpoint-to-video/) y codificarlos en un video (p. ej., mediante ffmpeg), eligiendo los FPS y la resolución. Las animaciones y las transiciones de diapositiva se reproducen durante el renderizado.

**¿Se mantendrán intactas las animaciones al trabajar con ODP (no solo PPTX)?**

PPT, PPTX y ODP son compatibles para [reading](/slides/es/androidjava/open-presentation/) y [writing](/slides/es/androidjava/save-presentation/), pero esto no garantiza la preservación de las animaciones. Los datos de animación personalizada pueden perderse al convertir a ODP. Consulte [Custom Animation for Java](/slides/es/java/custom-animation/) para ejemplos y orientación sobre cómo comprobar la compatibilidad de formatos.