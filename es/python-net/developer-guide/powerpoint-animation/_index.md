---
title: Animación de PowerPoint
type: docs
weight: 150
url: /python-net/powerpoint-animation/
keywords: "Animación, efectos de animación, animación de PowerPoint, línea de tiempo de animación, animación interactiva, animación de formas, gráfico animado, texto animado, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Animación y efectos de presentaciones de PowerPoint en Python"
---

Dado que las presentaciones están destinadas a presentar algo, siempre se considera su apariencia visual y comportamiento interactivo al crearlas.

**La animación de PowerPoint** juega un papel importante para hacer que la presentación sea llamativa y atractiva para los espectadores. Aspose.Slides para Python a través de .NET ofrece una amplia gama de opciones para agregar animación a la presentación de PowerPoint:

- aplicar varios tipos de efectos de animación de PowerPoint en formas, gráficos, tablas, objetos OLE y otros elementos de la presentación.
- usar múltiples efectos de animación de PowerPoint en una forma.
- usar línea de tiempo de animación para controlar los efectos de animación.
- crear animación personalizada.

En Aspose.Slides para Python a través de .NET, se pueden aplicar varios efectos de animación en las formas. Como cada elemento en la diapositiva, incluidos texto, imágenes, objeto OLE, tabla, etc., se considera como una forma, significa que podemos aplicar efectos de animación en cada elemento de una diapositiva.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) **namespace** proporciona clases para trabajar con animaciones de PowerPoint.
## **Efectos de Animación**
Aspose.Slides admite **más de 150 efectos de animación**, incluidos efectos de animación básicos como Bounce, PathFootball, efecto de Zoom y efectos de animación específicos como OLEObjectShow, OLEObjectOpen. Puedes encontrar una lista completa de los efectos de animación en la enumeración [**EffectType**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/).

Además, estos efectos de animación se pueden usar en combinación con ellos:

- [ColorEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/seteffect/)
## **Animación Personalizada**
Es posible crear tus propias **animaciones personalizadas** en Aspose.Slides. 
Esto se puede lograr si combinas varios comportamientos en una nueva animación personalizada.

[**Behavior**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/) es una unidad básica de cualquier efecto de animación de PowerPoint. Todos los efectos de animación son en realidad un conjunto de comportamientos compuestos en una estrategia. Puedes combinar comportamientos en una animación personalizada una vez y reutilizarla en otras presentaciones. Si agregas un nuevo comportamiento en un efecto de animación estándar de PowerPoint, será otra animación personalizada. Por ejemplo, puedes agregar un comportamiento de repetición a una animación para que se repita varias veces.

[**Animation Point**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/point/) es un punto donde se debe aplicar el comportamiento.
## **Línea de Tiempo de Animación**
[**Sequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) es una colección de efectos de animación, aplicados sobre una forma concreta.

[**Timeline**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animationtimeline/) es un conjunto de Secuencias utilizadas en una diapositiva concreta. Es un motor de animación representado desde PowerPoint 2002. En versiones anteriores de PowerPoint, era un desafío agregar efectos de animación a la presentación, lo que solo se podía lograr con diferentes soluciones alternativas. La línea de tiempo viene a reemplazar la antigua clase AnimationSettings y proporciona un modelo de objeto más claro para la animación de PowerPoint. Una diapositiva puede tener solo una línea de tiempo de animación.
## **Animación Interactiva**
[**Trigger**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) permite definir acciones del usuario (por ejemplo, clic en un botón), que harán que comience una animación determinada. Los triggers se han agregado solo en la última versión de PowerPoint.
## **Animación de Formas**
Aspose.Slides permite aplicar animación a formas, que pueden ser en realidad texto, rectángulo, línea, marco, objeto OLE, etc.

{{% alert color="primary" %}} 
Lee más [**Sobre la Animación de Formas**](/slides/python-net/shape-animation/).
{{% /alert %}}

## **Gráficos Animados**
Para crear gráficos animados, debes utilizar todas las mismas clases que para las formas. Sin embargo, es posible utilizar la animación de PowerPoint solo en categorías de gráficos o series de gráficos. También se puede aplicar un efecto de animación a un elemento de categoría o elemento de serie.

{{% alert color="primary" %}} 
Lee más [**Sobre Gráficos Animados**](/slides/python-net/animated-charts/).
{{% /alert %}}

## **Texto Animado**
Además del texto animado, también es posible aplicar animación a un párrafo.

{{% alert color="primary" %}} 
Lee más [**Sobre Texto Animado**](/slides/python-net/animated-text/).
{{% /alert %}}