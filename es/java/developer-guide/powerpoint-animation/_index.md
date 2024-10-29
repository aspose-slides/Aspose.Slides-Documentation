---
title: Animación de PowerPoint
type: docs
weight: 150
url: /es/java/powerpoint-animation/
keywords: "animación de PowerPoint"
description: "Animación de PowerPoint, animación de diapositivas de PowerPoint con Aspose.Slides."
---

Dado que las presentaciones están destinadas a presentar algo, siempre se considera su apariencia visual y comportamiento interactivo al crearlas.

**La animación de PowerPoint** juega un papel importante para hacer que la presentación sea atractiva y llamativa para los espectadores. Aspose.Slides para Java ofrece una amplia gama de opciones para agregar animación a la presentación de PowerPoint:

- aplicar varios tipos de efectos de animación de PowerPoint en formas, gráficos, tablas, objetos OLE y otros elementos de la presentación.
- usar múltiples efectos de animación de PowerPoint en una forma.
- usar la línea de tiempo de animación para controlar los efectos de animación.
- crear animaciones personalizadas.

En Aspose.Slides para Java, se pueden aplicar varios efectos de animación a las formas. Dado que cada elemento en la diapositiva, incluyendo texto, imágenes, objeto OLE, tabla, etc. se considera una forma, esto significa que podemos aplicar efectos de animación a cada elemento de una diapositiva.

## **Efectos de Animación**
Aspose.Slides soporta **más de 150 efectos de animación**, incluyendo efectos de animación básicos como Rebote, Caminamiento, Efecto Zoom y efectos de animación específicos como OLEObjectShow, OLEObjectOpen. Puedes encontrar una lista completa de efectos de animación en [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype)enumeración.

Adicionalmente, estos efectos de animación se pueden usar en combinación con ellos:

- [ColorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/java/com.aspose.slides/SetEffect)

## **Animación Personalizada**
Es posible crear tus propias **animaciones personalizadas** en Aspose.Slides. 
Esto se puede lograr si combinas varios comportamientos en una nueva animación personalizada.

[**Comportamiento**](https://reference.aspose.com/slides/java/com.aspose.slides/Behavior) es una unidad básica de cualquier efecto de animación de PowerPoint. Todos los efectos de animación son en realidad un conjunto de comportamientos compuestos en una estrategia. Puedes combinar comportamientos en una animación personalizada una vez y reutilizarla en otras presentaciones. Si agregas un nuevo comportamiento a un efecto de animación estándar de PowerPoint, será otra animación personalizada. Por ejemplo, puedes agregar un comportamiento de repetición a una animación para que se repita varias veces.

[**Punto de Animación**](https://reference.aspose.com/slides/java/com.aspose.slides/Point) es un punto donde se debe aplicar el comportamiento.

## **Línea de Tiempo de Animación**
[**Secuencia**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) es una colección de efectos de animación, aplicados a una forma concreta.

[**Línea de Tiempo**](https://reference.aspose.com/slides/java/com.aspose.slides/AnimationTimeLine) es un conjunto de Secuencias utilizadas en una diapositiva concreta. Es un motor de animación representado desde PowerPoint 2002. En versiones anteriores de PowerPoint, era complicado agregar efectos de animación a la presentación, lo que solo se podía lograr con diferentes soluciones alternativas. La línea de tiempo viene a reemplazar la antigua clase AnimationSettings y proporciona un modelo de objeto más claro para la animación de PowerPoint. Una diapositiva puede tener solo una línea de tiempo de animación.

## **Animación Interactiva**
[**Disparador**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectTriggerType) permite definir acciones del usuario (por ejemplo, clic en un botón), que harán que una cierta animación comience. Los disparadores se han agregado solo en la última versión de PowerPoint.

## **Animación de Formas**
Aspose.Slides permite aplicar animación a formas, que pueden ser en realidad texto, rectángulo, línea, marco, objeto OLE, etc.

{{% alert color="primary" %}} 
Lee más sobre [**Animación de Formas**](/slides/es/java/shape-animation/).
{{% /alert %}}

## **Gráficos Animados**
Para crear gráficos animados, deberías usar todas las mismas clases que para las formas. Sin embargo, es posible utilizar la animación de PowerPoint solo en categorías de gráficos o series de gráficos. También puedes aplicar un efecto de animación a un elemento de categoría o a un elemento de serie.

{{% alert color="primary" %}} 
Lee más sobre [**Gráficos Animados**](/slides/es/java/animated-charts/).
{{% /alert %}}

## **Texto Animado**
Excepto texto animado, también es posible aplicar animación a un párrafo.

{{% alert color="primary" %}} 
Lee más sobre [**Texto Animado**](/slides/es/java/animated-text/).
{{% /alert %}}