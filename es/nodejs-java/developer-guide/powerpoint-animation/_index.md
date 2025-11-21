---
title: "Animación de PowerPoint"
type: docs
weight: 150
url: /es/nodejs-java/powerpoint-animation/
keywords: "Animación de PowerPoint"
description: "Animación de PowerPoint, animación de diapositivas de PowerPoint con Aspose.Slides."
---

Dado que las presentaciones están destinadas a presentar algo, su apariencia visual y comportamiento interactivo siempre se consideran al crearlas.

**PowerPoint animation** juega un papel importante para que la presentación sea llamativa y atractiva para los espectadores. Aspose.Slides for Node.js via Java ofrece una amplia gama de opciones para **añadir animación** a una presentación de PowerPoint:

- aplicar varios tipos de efectos de animación de PowerPoint en formas, gráficos, tablas, objetos OLE y otros elementos de la presentación.  
- usar múltiples efectos de animación de PowerPoint en una forma.  
- usar la línea de tiempo de animación para controlar los efectos.  
- crear animaciones personalizadas.

En Aspose.Slides for Node.js via Java, se pueden aplicar diversos efectos de animación en las formas. Como cada elemento de la diapositiva, incluido texto, imágenes, objeto OLE, tabla, etc., se considera una forma, podemos aplicar efectos de animación a **cualquier** elemento de una diapositiva.

## **Animation Effects**
Aspose.Slides admite **más de 150 efectos de animación**, incluidos efectos básicos como Bounce, PathFootball, Zoom y efectos específicos como OLEObjectShow, OLEObjectOpen. Puede encontrar un listado completo de efectos de animación en la enumeración [**EffectType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype/).

Además, estos efectos de animación pueden combinarse con:

- [ColorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SetEffect)

## **Custom Animation**
Es posible crear sus propias **animaciones personalizadas** en Aspose.Slides.  
Esto se logra combinando varios comportamientos en una nueva animación personalizada.

[**Behavior**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Behavior) es la unidad de construcción de cualquier efecto de animación de PowerPoint. Todos los efectos son, en realidad, un conjunto de comportamientos compuestos en una estrategia. Puede combinar comportamientos en una animación personalizada **una vez** y reutilizarla en otras presentaciones. Si añade un nuevo comportamiento a un efecto de animación estándar de PowerPoint, obtendrá otra animación personalizada. Por ejemplo, puede añadir un comportamiento de repetición a una animación para que se repita varias veces.

[**Animation Point**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Point) es el punto donde se debe aplicar el comportamiento.

## **Animation Time Line**
[**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) es una colección de efectos de animación, aplicados a una forma concreta.

[**Timeline**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AnimationTimeLine) es un conjunto de Sequences usado en una diapositiva concreta. Es el motor de animación introducido desde PowerPoint 2002. En versiones anteriores de PowerPoint, agregar efectos de animación a una presentación era complicado y solo se lograba mediante diferentes soluciones alternativas. La línea de tiempo reemplaza la antigua clase AnimationSettings y proporciona un modelo de objetos más claro para la animación de PowerPoint. Una diapositiva puede tener **solo una** línea de tiempo de animación.

## **Interactive Animation**
[**Trigger**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EffectTriggerType) permite definir acciones del usuario (p. ej., clic en un botón) que harán que comience una animación específica. Los disparadores se añadieron solo en la versión más reciente de PowerPoint.

## **Shape Animation**
Aspose.Slides permite aplicar animación a formas, que pueden ser texto, rectángulo, línea, marco, objeto OLE, etc.

{{% alert color="primary" %}} 
Leer más [**Acerca de la animación de formas**](/slides/es/nodejs-java/shape-animation/).
{{% /alert %}}

## **Animated Charts**
Para crear gráficos animados, debe usar las mismas clases que para las formas. Sin embargo, es posible aplicar la animación de PowerPoint solo a categorías o series del gráfico. También puede aplicar un efecto de animación a un elemento de categoría o a un elemento de serie.

{{% alert color="primary" %}} 
Leer más [**Acerca de los gráficos animados**](/slides/es/nodejs-java/animated-charts/).
{{% /alert %}}

## **Animated text**
Además del texto animado, también es posible aplicar animación a un párrafo.

{{% alert color="primary" %}} 
Leer más [**Acerca del texto animado**](/slides/es/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**¿Se conservarán las animaciones al exportar a PDF?**

No. PDF es un formato estático, por lo que las animaciones y las [transiciones de diapositivas](/slides/es/nodejs-java/slide-transition/) no se reproducen. Si necesita movimiento, exporte a [HTML5](/slides/es/nodejs-java/export-to-html5/), [GIF animado](/slides/es/nodejs-java/convert-powerpoint-to-animated-gif/) o [video](/slides/es/nodejs-java/convert-powerpoint-to-video/) en su lugar.

**¿Puedo convertir una presentación animada en un video y controlar la tasa de fotogramas y el tamaño del cuadro?**

Sí. Puede [renderizar la presentación como fotogramas](/slides/es/nodejs-java/convert-powerpoint-to-video/) y codificarlos en un video (p. ej., con ffmpeg), eligiendo FPS y resolución. Las animaciones y transiciones de diapositiva se reproducen durante el renderizado.

**¿Las animaciones permanecerán intactas al trabajar con ODP (no solo PPTX)?**

PPT, PPTX y ODP son compatibles para [lectura](/slides/es/nodejs-java/open-presentation/) y [escritura](/slides/es/nodejs-java/save-presentation/), pero las diferencias de formato pueden hacer que ciertos efectos se vean o se comporten ligeramente distintos. Valide los casos críticos con muestras reales.