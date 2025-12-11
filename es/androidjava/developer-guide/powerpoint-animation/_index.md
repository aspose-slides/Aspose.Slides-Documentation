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
description: Explore las capacidades de Aspose.Slides para Android mediante Java al manejar animaciones de PowerPoint. Esta visión general destaca las características clave.
---

Dado que las presentaciones están destinadas a presentar algo, su apariencia visual y comportamiento interactivo siempre se consideran al crearlas.

**Animación de PowerPoint** juega un papel importante para que la presentación sea llamativa y atractiva para los espectadores. Aspose.Slides for Android via Java ofrece una amplia gama de opciones para añadir animación a una presentación de PowerPoint:

- aplicar varios tipos de efectos de animación de PowerPoint en formas, gráficos, tablas, objetos OLE y otros elementos de la presentación.
- usar múltiples efectos de animación de PowerPoint en una forma.
- utilizar la línea de tiempo de animación para controlar los efectos de animación.
- crear animación personalizada.

En Aspose.Slides for Android a través de Java, se pueden aplicar varios efectos de animación en las formas. Como cada elemento en la diapositiva, incluyendo texto, imágenes, objeto OLE, tabla, etc., se considera una forma, significa que podemos aplicar efectos de animación a cada elemento de una diapositiva.

## **Efectos de animación**
Aspose.Slides admite **más de 150 efectos de animación**, incluidos efectos básicos como Bounce, PathFootball, efecto Zoom y efectos específicos como OLEObjectShow, OLEObjectOpen. Puede encontrar una lista completa de efectos de animación en la enumeración [**EffectType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype/).

Además, estos efectos de animación pueden usarse en combinación con ellos:

- [ColorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SetEffect)

## **Animación personalizada**
Es posible crear sus propias **animaciones personalizadas** en Aspose.Slides. Esto se puede lograr si combina varios comportamientos en una nueva animación personalizada.

[**Behavior**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) es una unidad de construcción de cualquier efecto de animación de PowerPoint. Todos los efectos de animación son en realidad un conjunto de comportamientos compuestos en una estrategia. Puede combinar comportamientos en una animación personalizada una vez y reutilizarla en otras presentaciones. Si agrega un nuevo comportamiento a un efecto de animación estándar de PowerPoint, será otra animación personalizada. Por ejemplo, puede añadir un comportamiento de repetición a una animación para que se repita varias veces.

[**Animation Point**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) es un punto donde debe aplicarse el comportamiento.

## **Línea de tiempo de animación**
[**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) es una colección de efectos de animación, aplicados a una forma concreta.

[**Timeline**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) es un conjunto de Secuencias utilizado en una diapositiva concreta. Es un motor de animación representado desde PowerPoint 2002. En versiones anteriores de PowerPoint, era difícil añadir efectos de animación a la presentación, lo que solo se podía lograr con diferentes soluciones alternativas. La línea de tiempo viene a reemplazar la antigua clase AnimationSettings y proporcionar un modelo de objetos más claro para la animación de PowerPoint. Una diapositiva puede tener solo una línea de tiempo de animación.

## **Animación interactiva**
[**Trigger**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) permite definir acciones del usuario (p.ej., clic de botón), que harán que comience una animación determinada. Los disparadores se han añadido solo en la última versión de PowerPoint.

## **Animación de formas**
Aspose.Slides permite aplicar animación a formas, que pueden ser texto, rectángulo, línea, marco, objeto OLE, etc.

{{% alert color="primary" %}} 
Leer más [**Acerca de la animación de formas**](/slides/es/androidjava/shape-animation/).
{{% /alert %}}

## **Gráficos animados**
Para crear gráficos animados, debe utilizar las mismas clases que para las formas. Sin embargo, es posible usar la animación de PowerPoint solo en categorías de gráficos o series de gráficos. También puede aplicar un efecto de animación a un elemento de categoría o a un elemento de serie.

{{% alert color="primary" %}} 
Leer más [**Acerca de los gráficos animados**](/slides/es/androidjava/animated-charts/).
{{% /alert %}}

## **Texto animado**
Además del texto animado, también es posible aplicar animación a un párrafo.

{{% alert color="primary" %}} 
Leer más [**Acerca del texto animado**](/slides/es/androidjava/animated-text/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se conservarán las animaciones al exportar a PDF?**

No. PDF es un formato estático, por lo que las animaciones y las [transiciones de diapositivas](/slides/es/androidjava/slide-transition/) no se reproducen. Si necesita movimiento, exporte a [HTML5](/slides/es/androidjava/export-to-html5/), [GIF animado](/slides/es/androidjava/convert-powerpoint-to-animated-gif/), o [video](/slides/es/androidjava/convert-powerpoint-to-video/) en su lugar.

**¿Puedo convertir una presentación animada en un video y controlar la velocidad de fotogramas y el tamaño del cuadro?**

Sí. Puede [renderizar la presentación como fotogramas](/slides/es/androidjava/convert-powerpoint-to-video/) y codificarlos en un video (p.ej., mediante ffmpeg), eligiendo los FPS y la resolución. Las animaciones y las transiciones de diapositivas se reproducen durante el renderizado.

**¿Se mantendrán las animaciones intactas al trabajar con ODP (no solo PPTX)?**

PPT, PPTX y ODP son compatibles para [lectura](/slides/es/androidjava/open-presentation/) y [escritura](/slides/es/androidjava/save-presentation/), pero las diferencias de formato hacen que ciertos efectos puedan verse o comportarse ligeramente diferentes. Valide los casos críticos con muestras reales.