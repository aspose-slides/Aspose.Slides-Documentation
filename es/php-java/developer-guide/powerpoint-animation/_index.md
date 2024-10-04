---
title: Animación de PowerPoint
type: docs
weight: 150
url: /php-java/powerpoint-animation/
keywords: "animación de PowerPoint"
description: "Animación de PowerPoint, animación de diapositivas de PowerPoint con Aspose.Slides."
---

Dado que las presentaciones están destinadas a presentar algo, siempre se considera su apariencia visual y comportamiento interactivo al crearlas.

**La animación de PowerPoint** juega un papel importante para hacer que la presentación sea atractiva y llamativa para los espectadores. Aspose.Slides para PHP a través de Java ofrece una amplia gama de opciones para agregar animación a la presentación de PowerPoint:

- aplicar varios tipos de efectos de animación de PowerPoint en formas, gráficos, tablas, objetos OLE y otros elementos de la presentación.
- usar múltiples efectos de animación de PowerPoint en una forma.
- usar una línea de tiempo de animación para controlar los efectos de animación.
- crear animación personalizada.

En Aspose.Slides para PHP a través de Java, se pueden aplicar varios efectos de animación en las formas. Dado que cada elemento en la diapositiva, incluida la texto, imágenes, objeto OLE, tabla, etc., se considera como una forma, significa que podemos aplicar efectos de animación en cada elemento de una diapositiva.


## **Efectos de Animación**
Aspose.Slides soporta **más de 150 efectos de animación**, incluidos efectos de animación básicos como Rebote, Camino de Fútbol, efecto de Zoom y efectos de animación específicos como OLEObjectShow, OLEObjectOpen. Puede encontrar una lista completa de efectos de animación en [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype)enumeración.

Adicionalmente, estos efectos de animación se pueden usar en combinación con los siguientes:

- [ColorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/php-java/aspose.slides/SetEffect)

## **Animación Personalizada**
Es posible crear sus propias **animaciones personalizadas** en Aspose.Slides. 
Esto se puede lograr si combina varios comportamientos en una nueva animación personalizada.

[**Behavior**](https://reference.aspose.com/slides/php-java/aspose.slides/Behavior) es una unidad de construcción de cualquier efecto de animación de PowerPoint. Todos los efectos de animación son en realidad un conjunto de comportamientos compuestos en una estrategia. Puede combinar comportamientos en una animación personalizada una vez y reutilizarla en otras presentaciones. Si agrega un nuevo comportamiento a un efecto de animación de PowerPoint estándar, será otra animación personalizada. Por ejemplo, puede agregar un comportamiento de repetición a una animación para hacer que se repita unas cuantas veces.

[**Animation Point**](https://reference.aspose.com/slides/php-java/aspose.slides/Point) es un punto donde se debe aplicar el comportamiento.

## **Línea de Tiempo de Animación**
[**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) es una colección de efectos de animación aplicados a una forma concreta.

[**Timeline**](https://reference.aspose.com/slides/php-java/aspose.slides/AnimationTimeLine) es un conjunto de secuencias utilizadas en una diapositiva concreta. Es un motor de animación representado desde PowerPoint 2002. En versiones anteriores de PowerPoint, era complicado agregar efectos de animación a la presentación, lo cual solo se podía lograr con diferentes soluciones alternativas. La línea de tiempo viene a reemplazar la antigua clase AnimationSettings y proporciona un modelo de objeto más claro para la animación de PowerPoint. Una diapositiva puede tener solo una línea de tiempo de animación.

## **Animación Interactiva**
[**Trigger**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectTriggerType) permite definir acciones del usuario (por ejemplo, clic en un botón), que harán que comience cierta animación. Los disparadores se han agregado en la última versión de PowerPoint solamente.

## **Animación de Forma**
Aspose.Slides permite aplicar animación a formas, que pueden ser en realidad texto, rectángulo, línea, marco, objeto OLE, etc.

{{% alert color="primary" %}} 
Lea más sobre [**Animación de Forma**](/slides/php-java/shape-animation/).
{{% /alert %}}

## **Gráficos Animados**
Para crear gráficos animados, debe utilizar todas las mismas clases que para las formas. Sin embargo, es posible utilizar la animación de PowerPoint solo en categorías de gráficos o series de gráficos. También puede aplicar un efecto de animación a un elemento de categoría o elemento de serie.

{{% alert color="primary" %}} 
Lea más sobre [**Gráficos Animados**](/slides/php-java/animated-charts/).
{{% /alert %}}

## **Texto Animado**
Además del texto animado, también es posible aplicar animación a un párrafo.

{{% alert color="primary" %}} 
Lea más sobre [**Texto Animado**](/slides/php-java/animated-text/).
{{% /alert %}}