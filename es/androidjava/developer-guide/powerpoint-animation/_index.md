---
title: Animación de PowerPoint
type: docs
weight: 150
url: /es/androidjava/powerpoint-animation/
keywords: "animación de PowerPoint"
description: "Animación de PowerPoint, animación de diapositivas de PowerPoint con Aspose.Slides."
---

Dado que las presentaciones están destinadas a presentar algo, su apariencia visual y comportamiento interactivo siempre se consideran al crearlas.

**La animación de PowerPoint** juega un papel importante para hacer que la presentación sea atractiva y llamativa para los espectadores. Aspose.Slides para Android a través de Java ofrece una amplia gama de opciones para añadir animación a las presentaciones de PowerPoint:

- aplicar varios tipos de efectos de animación de PowerPoint en formas, gráficos, tablas, objetos OLE y otros elementos de presentación.
- usar múltiples efectos de animación de PowerPoint en una forma.
- usar la línea de tiempo de animación para controlar los efectos de animación.
- crear animaciones personalizadas.

En Aspose.Slides para Android a través de Java, se pueden aplicar varios efectos de animación en las formas. Dado que cada elemento en la diapositiva, incluyendo texto, imágenes, objetos OLE, tablas, etc., se considera como una forma, esto significa que podemos aplicar efectos de animación en cada elemento de una diapositiva.

## **Efectos de Animación**
Aspose.Slides soporta **más de 150 efectos de animación**, incluyendo efectos de animación básicos como Rebote, Camino de Fútbol, Efecto de Zoom y efectos de animación específicos como OLEObjectShow, OLEObjectOpen. Puedes encontrar una lista completa de los efectos de animación en la enumeración [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype).

Además, estos efectos de animación se pueden utilizar en combinación con ellos:

- [ColorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SetEffect)

## **Animación Personalizada**
Es posible crear tus propias **animaciones personalizadas** en Aspose.Slides. 
Esto se puede lograr si combinas varios comportamientos en una nueva animación personalizada.

[**Behavior**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) es una unidad constructiva de cualquier efecto de animación de PowerPoint. Todos los efectos de animación son en realidad un conjunto de comportamientos compuestos en una estrategia. Puedes combinar comportamientos en una animación personalizada una vez y reutilizarla en otras presentaciones. Si añades un nuevo comportamiento a un efecto de animación estándar de PowerPoint, será otra animación personalizada. Por ejemplo, puedes añadir un comportamiento de repetición a una animación para que se repita varias veces.

[**Animation Point**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) es un punto donde se debe aplicar el comportamiento.

## **Línea de Tiempo de Animación**
[**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) es una colección de efectos de animación, aplicados en una forma concreta.

[**Timeline**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) es un conjunto de Secuencias utilizadas en una diapositiva concreta. Es un motor de animación representado desde PowerPoint 2002. En versiones anteriores de PowerPoint, era un desafío añadir efectos de animación a la presentación, lo cual solo se podía lograr mediante diferentes soluciones. La línea de tiempo viene a reemplazar la antigua clase AnimationSettings y proporciona un modelo de objeto más claro para la animación de PowerPoint. Una diapositiva puede tener solo una línea de tiempo de animación.

## **Animación Interactiva**
[**Trigger**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) permite definir acciones del usuario (por ejemplo, clic en un botón) que harán que una cierta animación comience. Los disparadores se han añadido solo en la última versión de PowerPoint.

## **Animación de Formas**
Aspose.Slides permite aplicar animación a formas, que pueden ser en realidad texto, rectángulo, línea, marco, objeto OLE, etc.

{{% alert color="primary" %}} 
Lee más [**Sobre la Animación de Formas**](/slides/es/androidjava/shape-animation/).
{{% /alert %}}

## **Gráficos Animados**
Para crear gráficos animados, debes usar las mismas clases que para las formas. Sin embargo, es posible utilizar la animación de PowerPoint solo en categorías de gráficos o series de gráficos. También puedes aplicar efectos de animación a un elemento de categoría o elemento de serie.

{{% alert color="primary" %}} 
Lee más [**Sobre los Gráficos Animados**](/slides/es/androidjava/animated-charts/).
{{% /alert %}}

## **Texto Animado**
Además de texto animado, también es posible aplicar animación a un párrafo.

{{% alert color="primary" %}} 
Lee más [**Sobre el Texto Animado**](/slides/es/androidjava/animated-text/).
{{% /alert %}}