---
title: Mejorar presentaciones PowerPoint con animaciones en Android
linktitle: Animación PowerPoint
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
- Android
- Java
- Aspose.Slides
description: "Explore las capacidades de Aspose.Slides para Android via Java al manejar animaciones de PowerPoint. Esta visión general destaca las características clave."
---
## **Introducción**

Dado que las presentaciones están destinadas a presentar algo, su apariencia visual y comportamiento interactivo se consideran siempre al crearlas.

**PowerPoint animation** desempeña un papel importante para que la presentación resulte llamativa y atractiva para los espectadores. Aspose.Slides for Android via Java ofrece una amplia gama de opciones para añadir animación a una presentación PowerPoint:

- aplicar varios tipos de efectos de animación de PowerPoint a formas, gráficos, tablas, objetos OLE y otros elementos de la presentación.
- usar varios efectos de animación de PowerPoint en una forma.
- usar la línea de tiempo de animación para controlar los efectos de animación.
- crear animación personalizada.

En Aspose.Slides for Android via Java, se pueden aplicar varios efectos de animación a las formas. Dado que cada elemento de la diapositiva, incluido texto, imágenes, objeto OLE, tabla, etc., se considera una forma, significa que podemos aplicar efectos de animación a cualquier elemento de una diapositiva.

## **Efectos de animación**
Aspose.Slides admite **más de 150 efectos de animación**, incluidos efectos básicos como Bounce, PathFootball, efecto Zoom y efectos específicos como OLEObjectShow, OLEObjectOpen. Puede encontrar una lista completa de efectos de animación en la enumeración [**EffectType**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/effecttype/).

Además, estos efectos de animación pueden combinarse con:

- [ColorEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SetEffect)

## **Animación personalizada**
Es posible crear sus propias **animaciones personalizadas** en Aspose.Slides.  
Esto se puede lograr si combina varios comportamientos en una nueva animación personalizada.

[**Behavior**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Behavior) es una unidad de construcción de cualquier efecto de animación de PowerPoint. Todos los efectos de animación son en realidad un conjunto de comportamientos compuestos en una estrategia. Puede combinar comportamientos en una animación personalizada una vez y reutilizarla en otras presentaciones. Si agrega un nuevo comportamiento a un efecto de animación estándar de PowerPoint, será otra animación personalizada. Por ejemplo, puede añadir un comportamiento de repetición a una animación para que se repita varias veces.

[**Animation Point**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Point) es un punto donde se debe aplicar el comportamiento.

## **Línea de tiempo de animación**
[**Sequence**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Sequence) es una colección de efectos de animación, aplicados a una forma concreta.

[**Timeline**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/AnimationTimeLine) es un conjunto de Sequences utilizado en una diapositiva concreta. Es un motor de animación presente desde PowerPoint 2002. En versiones anteriores de PowerPoint, era complicado añadir efectos de animación a la presentación, lo que sólo podía lograrse mediante diferentes soluciones alternativas. Timeline sustituye a la antigua clase AnimationSettings y proporciona un modelo de objetos más claro para la animación de PowerPoint. Una diapositiva puede tener solo una línea de tiempo de animación.

## **Animación interactiva**
[**Trigger**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/EffectTriggerType) permite definir acciones del usuario (p. ej., clic de botón) que harán que una determinada animación comience. Los disparadores se añadieron solo en la última versión de PowerPoint.

## **Animación de forma**
Aspose.Slides permite aplicar animación a formas, que pueden ser texto, rectángulo, línea, marco, objeto OLE, etc.

{{% alert color="info" %}} 
Lee más [**Acerca de la animación de forma**](/slides/es/androidjava/shape-animation/).
{{% /alert %}}

## **Gráficos animados**
Para crear gráficos animados, debe usar las mismas clases que para las formas. Sin embargo, es posible aplicar animación de PowerPoint solo a categorías de gráfico o series de gráfico. También puede aplicar efectos de animación a un elemento de categoría o a un elemento de serie.

{{% alert color="info" %}} 
Lee más [**Acerca de los gráficos animados**](/slides/es/androidjava/animated-charts/).
{{% /alert %}}

## **Texto animado**
Además del texto animado, también es posible aplicar animación a un párrafo.

{{% alert color="info" %}} 
Lee más [**Acerca del texto animado**](/slides/es/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

### ¿Se conservarán las animaciones al exportar a PDF?

No. PDF es un formato estático, por lo que las animaciones y las [transiciones de diapositiva](/slides/es/androidjava/slide-transition/) no se reproducen. Si necesita movimiento, exporte a [HTML5](/slides/es/androidjava/export-to-html5/), [GIF animado](/slides/es/androidjava/convert-powerpoint-to-animated-gif/) o [vídeo](/slides/es/androidjava/convert-powerpoint-to-video/) en su lugar.

### ¿Puedo convertir una presentación animada en un vídeo y controlar la velocidad de fotogramas y el tamaño del fotograma?

Sí. Puede [renderizar la presentación como fotogramas](/slides/es/androidjava/convert-powerpoint-to-video/) y codificarlos en un vídeo (p. ej., con ffmpeg), eligiendo los FPS y la resolución. Las animaciones y las transiciones de diapositiva se reproducen durante el renderizado.

### ¿Se mantendrán las animaciones intactas al trabajar con ODP (no solo PPTX)?

PPT, PPTX y ODP son compatibles para la [lectura](/slides/es/androidjava/open-presentation/) y la [escritura](/slides/es/androidjava/save-presentation/), pero las diferencias de formato hacen que ciertos efectos puedan verse o comportarse ligeramente diferentes. Valide los casos críticos con muestras reales.