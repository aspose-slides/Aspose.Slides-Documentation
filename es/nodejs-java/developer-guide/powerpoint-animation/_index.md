---
title: Mejorar presentaciones de PowerPoint con animaciones en JavaScript
linktitle: Animación de PowerPoint
type: docs
weight: 150
url: /es/nodejs-java/powerpoint-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Utilice Aspose.Slides for Node.js via Java para gestionar animaciones de PowerPoint. Esta visión general destaca las características clave y ofrece ideas para mejorar sus presentaciones."
---
## **Introducción**

Dado que las presentaciones están destinadas a presentar algo, su apariencia visual y su comportamiento interactivo siempre se tienen en cuenta durante su creación.

**PowerPoint animation** desempeña un papel importante en hacer que una presentación sea llamativa y atractiva para los espectadores. Aspose.Slides for Node.js via Java proporciona una amplia gama de opciones para añadir animaciones a presentaciones de PowerPoint:

- Aplicar varios tipos de efectos de animación de PowerPoint a formas, gráficos, tablas, objetos OLE y otros elementos de la presentación.
- Utilizar múltiples efectos de animación de PowerPoint en una única forma.
- Utilizar la línea de tiempo de animación para controlar los efectos de animación.
- Crear animaciones personalizadas.

En Aspose.Slides for Node.js via Java, se pueden aplicar diversos efectos de animación a las formas. Dado que cada elemento de una diapositiva, incluidos texto, imágenes, objetos OLE y tablas, se considera una forma, los efectos de animación pueden aplicarse a cualquier elemento de la diapositiva.

## **Efectos de animación**
Aspose.Slides admite **más de 150 efectos de animación**, incluidos efectos básicos como Bounce, PathFootball y Zoom, y efectos específicos como OLEObjectShow y OLEObjectOpen. Puede consultar una lista completa en la enumeración [EffectType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effecttype/).

Además, estos efectos de animación pueden utilizarse en combinación con los siguientes comportamientos:

- [ColorEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SetEffect)

## **Animación personalizada**

Para obtener ejemplos completos en JavaScript que crean, inspeccionan y modifican comportamientos y rutas de movimiento editables, consulte [Animación personalizada](/slides/es/nodejs-java/custom-animation/).

Es posible crear sus propias **animaciones personalizadas** en Aspose.Slides. Esto puede lograrse combinando varios comportamientos en una nueva animación personalizada.

[Behavior](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behavior/) es un bloque de construcción de un efecto de animación de PowerPoint. Combine comportamientos para personalizar un efecto, o añada un comportamiento para ampliar un efecto predefinido. La repetición se configura mediante la configuración de tiempo en lugar de un comportamiento de repetición separado.

[Animation Point](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/point/) es un punto en el que se debe aplicar un comportamiento.

## **Línea de tiempo de animación**
[Sequence](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/) es una colección de efectos de animación que pueden dirigirse a distintas formas.

[Timeline](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/animationtimeline/) es un conjunto de secuencias utilizadas en una diapositiva específica. Es un motor de animación introducido en PowerPoint 2002. En versiones anteriores de PowerPoint, añadir efectos de animación a las presentaciones era complicado y solo se podía lograr mediante diversas soluciones alternativas. La línea de tiempo ofrece un modelo de objetos más claro para las animaciones de PowerPoint. Una diapositiva solo puede tener una línea de tiempo de animación.

## **Animación interactiva**
[Trigger](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effecttriggertype/) le permite definir acciones de usuario, como hacer clic en un botón, que inician una animación concreta.

## **Animación de formas**
Aspose.Slides le permite aplicar animaciones a formas, que pueden incluir texto, rectángulos, líneas, marcos, objetos OLE y más.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca de la animación de formas**](/slides/es/nodejs-java/shape-animation/)
{{% /alert %}}

## **Gráficos animados**
Para crear gráficos animados, debe utilizar las mismas clases que para las formas. Sin embargo, las animaciones de PowerPoint solo pueden aplicarse a categorías de gráficos o series de gráficos. También puede aplicar efectos de animación a un elemento de categoría o a un elemento de serie.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca de los gráficos animados**](/slides/es/nodejs-java/animated-charts/)
{{% /alert %}}

## **Texto animado**
Además de animar texto, puede aplicar animación a un párrafo.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca del texto animado**](/slides/es/nodejs-java/animated-text/)
{{% /alert %}}

## **FAQ**

**¿Se conservarán las animaciones al exportar a PDF?**

No. PDF es un formato estático, por lo que las animaciones y las [transiciones de diapositiva](/slides/es/nodejs-java/slide-transition/) no se reproducen. Si necesita movimiento, exporte a [HTML5](/slides/es/nodejs-java/export-to-html5/), [GIF animado](/slides/es/nodejs-java/convert-powerpoint-to-animated-gif/) o [video](/slides/es/nodejs-java/convert-powerpoint-to-video/) en su lugar.

**¿Puedo convertir una presentación animada en un vídeo y controlar la velocidad de fotogramas y el tamaño del fotograma?**

Sí. Puede [renderizar la presentación como fotogramas](/slides/es/nodejs-java/convert-powerpoint-to-video/) y codificarlos en un vídeo (p.ej., mediante ffmpeg), eligiendo los FPS y la resolución. Las animaciones y las transiciones de diapositiva se reproducen durante el renderizado.

**¿Se mantendrán las animaciones al trabajar con ODP (no solo PPTX)?**

PPT, PPTX y ODP son compatibles para la [lectura](/slides/es/nodejs-java/open-presentation/) y la [escritura](/slides/es/nodejs-java/save-presentation/), pero esto no garantiza la conservación de las animaciones. Los datos de animación personalizada pueden perderse al convertir a ODP. Consulte [Animación personalizada](/slides/es/nodejs-java/custom-animation/) para obtener ejemplos y orientación sobre la comprobación de la compatibilidad de formatos.