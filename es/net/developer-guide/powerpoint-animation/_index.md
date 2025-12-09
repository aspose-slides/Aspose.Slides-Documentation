---
title: Mejorar presentaciones de PowerPoint con animaciones en .NET
linktitle: Animación de PowerPoint
type: docs
weight: 150
url: /es/net/powerpoint-animation/
keywords:
- agregar animación
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
description: "Explore las capacidades de Aspose.Slides para .NET en el manejo de animaciones de PowerPoint. Esta visión general destaca las características clave y ofrece ideas para mejorar sus presentaciones."
---

## **Visión general**

Dado que las presentaciones están destinadas a presentar algo, su apariencia visual y comportamiento interactivo siempre se tienen en cuenta durante su creación.

**Animación de PowerPoint** juega un papel importante en hacer que una presentación sea llamativa y atractiva para los espectadores. Aspose.Slides para .NET ofrece una amplia gama de opciones para agregar animaciones a presentaciones de PowerPoint:

- Aplicar varios tipos de efectos de animación de PowerPoint a formas, gráficos, tablas, objetos OLE y otros elementos de la presentación.
- Utilizar varios efectos de animación de PowerPoint en una sola forma.
- Utilizar la línea de tiempo de animación para controlar los efectos de animación.
- Crear animaciones personalizadas.

En Aspose.Slides para .NET, se pueden aplicar varios efectos de animación a las formas. Dado que cada elemento en una diapositiva, incluidos texto, imágenes, objetos OLE y tablas, se considera una forma, los efectos de animación pueden aplicarse a cualquier elemento de la diapositiva.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) namespace provee clases para trabajar con animaciones de PowerPoint.

## **Efectos de animación**

Aspose.Slides admite **más de 150 efectos de animación**, incluidos efectos básicos como Bounce, PathFootball y Zoom, así como efectos específicos como OLEObjectShow y OLEObjectOpen. Puedes encontrar una lista completa de los efectos de animación en la enumeración [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype).

Además, estos efectos de animación pueden usarse en combinación con los siguientes:

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)

## **Animación personalizada**

Es posible crear tus propias **animaciones personalizadas** en Aspose.Slides. Esto se puede lograr combinando varios comportamientos en una nueva animación personalizada.

[Behaviour](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) es un bloque de construcción de cualquier efecto de animación de PowerPoint. Todos los efectos de animación son esencialmente un conjunto de comportamientos compuestos en una estrategia. Puedes combinar comportamientos en una animación personalizada una vez y reutilizarla en otras presentaciones. Si añades un nuevo comportamiento a un efecto de animación estándar de PowerPoint, se convertirá en otra animación personalizada. Por ejemplo, puedes añadir un comportamiento de repetición a una animación para que se repita varias veces.

[Animation Point](https://reference.aspose.com/slides/net/aspose.slides.animation/point) es un punto en el que se debe aplicar un comportamiento.

## **Línea de tiempo de animación**

[Sequence](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) es una colección de efectos de animación aplicados a una forma específica.

[Timeline](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) es un conjunto de secuencias usadas en una diapositiva específica. Es un motor de animación introducido en PowerPoint 2002. En versiones anteriores de PowerPoint, añadir efectos de animación a presentaciones era complicado y sólo se podía lograr con varias soluciones alternativas. La línea de tiempo reemplaza la antigua clase AnimationSettings y proporciona un modelo de objetos más claro para las animaciones de PowerPoint. Una diapositiva solo puede tener una línea de tiempo de animación.

## **Animación interactiva**

[Trigger](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) te permite definir acciones del usuario (p.ej., clic en un botón) que iniciarán una animación específica. Los disparadores fueron introducidos en la última versión de PowerPoint.

## **Animación de forma**

Aspose.Slides te permite aplicar animaciones a formas, que pueden incluir texto, rectángulos, líneas, marcos, objetos OLE y más.

{{% alert color="primary" %}} 
Leer más [**Acerca de la animación de forma**](/slides/es/net/shape-animation/).
{{% /alert %}}

## **Gráficos animados**

Para crear gráficos animados, debes usar las mismas clases que para las formas. Sin embargo, las animaciones de PowerPoint solo pueden aplicarse a categorías de gráfico o series de gráfico. También puedes aplicar efectos de animación a un elemento de categoría o a un elemento de serie.

{{% alert color="primary" %}} 
Leer más [**Acerca de los gráficos animados**](/slides/es/net/animated-charts/).
{{% /alert %}}

## **Texto animado**

Además del texto animado, también es posible aplicar animación a un párrafo.

{{% alert color="primary" %}} 
Leer más [**Acerca del texto animado**](/slides/es/net/animated-text/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se conservarán las animaciones al exportar a PDF?**

No. PDF es un formato estático, por lo que las animaciones y las [transiciones de diapositivas](/slides/es/net/slide-transition/) no se reproducen. Si necesitas movimiento, exporta a [HTML5](/slides/es/net/export-to-html5/), [GIF animado](/slides/es/net/convert-powerpoint-to-animated-gif/) o [video](/slides/es/net/convert-powerpoint-to-video/) en su lugar.

**¿Puedo convertir una presentación animada en un video y controlar la velocidad de fotogramas y el tamaño del fotograma?**

Sí. Puedes [renderizar la presentación como fotogramas](/slides/es/net/convert-powerpoint-to-video/) y codificarlos en un video (p. ej., mediante ffmpeg), eligiendo los FPS y la resolución. Las animaciones y las transiciones de diapositivas se reproducen durante el renderizado.

**¿Se mantendrán las animaciones intactas al trabajar con ODP (no solo PPTX)?**

PPT, PPTX y ODP son compatibles para [leer](/slides/es/net/open-presentation/) y [escribir](/slides/es/net/save-presentation/), pero las diferencias de formato hacen que ciertos efectos puedan verse o comportarse ligeramente diferentes. Valida los casos críticos con muestras reales.