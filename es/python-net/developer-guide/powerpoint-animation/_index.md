---
title: Mejore las presentaciones de PowerPoint con animaciones en Python
linktitle: Animación de PowerPoint
type: docs
weight: 150
url: /es/python-net/powerpoint-animation/
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
- presentación de PowerPoint
- Python
- Aspose.Slides
description: "Explore las capacidades de Aspose.Slides for Python via .NET para manejar animaciones de PowerPoint. Esta visión general destaca características clave y ofrece ideas para mejorar sus presentaciones."
---
## **Introducción**

Las presentaciones están diseñadas para transmitir información, por lo que su apariencia visual y comportamiento interactivo son consideraciones clave durante su creación.

**PowerPoint animation** juega un papel importante para que una presentación sea llamativa y atractiva para los espectadores. Aspose.Slides for Python via .NET ofrece una amplia gama de opciones para agregar animación a una presentación PowerPoint. Usted puede:

- Aplicar varios efectos de animación a formas, gráficos, tablas, objetos OLE y otros elementos.
- Utilizar múltiples efectos de animación en una única forma.
- Controlar los efectos mediante la línea de tiempo de animación.
- Crear animaciones personalizadas.

En Aspose.Slides for Python via .NET, los efectos de animación pueden aplicarse a formas. Dado que cada elemento de una diapositiva —incluido texto, imágenes, objetos OLE y tablas— se trata como una forma, puede aplicar efectos de animación a cualquier elemento de la diapositiva.

El espacio de nombres [aspose.slides.animation](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/) proporciona las clases para trabajar con animaciones de PowerPoint.

## **Instalación**

```bash
pip install aspose.slides
```

## **Agregar un efecto de animación a una forma en Python**

Los efectos de animación residen en la secuencia principal de una diapositiva. Añada una forma y luego llame a `add_effect` en `slide.timeline.main_sequence`, pasando el tipo de efecto, su subtipo y el disparador que lo inicia.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

El archivo guardado contiene un efecto en la primera diapositiva: el rectángulo entra volando desde la izquierda durante dos segundos cuando el presentador hace clic. Al volver a abrirlo y leer `slide.timeline.main_sequence` se devuelve ese efecto, de modo que la animación sobrevive al proceso de ida y vuelta en lugar de existir solo en memoria.

## **Efectos de animación**

Aspose.Slides admite **más de 150 efectos de animación**, incluidos efectos básicos como Bounce, PathFootball y Zoom, así como efectos especializados como OLEObjectShow y OLEObjectOpen. Puede encontrar la lista completa en la enumeración [EffectType](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effecttype/).

Además, estos efectos de animación pueden combinarse con los siguientes efectos:

- [ColorEffect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/seteffect/)

## **Animación personalizada**

Puede crear sus propias **animaciones personalizadas** en Aspose.Slides combinando varios comportamientos en un solo efecto.

[Behavior](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behavior/) es el bloque básico de cualquier efecto de animación de PowerPoint. Cada efecto de animación es esencialmente un conjunto de comportamientos organizados en una estrategia o línea de tiempo. Puede ensamblar comportamientos en una animación personalizada una vez y reutilizarla en otras presentaciones. Si agrega un nuevo comportamiento a un efecto de animación estándar de PowerPoint, se convierte en una animación personalizada —por ejemplo, añadiendo un comportamiento de repetición para que la animación se reproduzca varias veces.

[Animation Point](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/point/) marca el momento o la posición en que se aplica un comportamiento (un fotograma clave).

## **Línea de tiempo de animación**

[Sequence](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/sequence/) es una colección de efectos de animación aplicados a una forma específica.

[Timeline](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/animationtimeline/) es el conjunto de secuencias usadas en una diapositiva específica. Fue introducida en PowerPoint 2002. En versiones anteriores de PowerPoint, agregar efectos de animación era difícil y a menudo requería soluciones alternativas. Timeline sustituye a la antigua clase `AnimationSettings` y ofrece un modelo de objetos más claro para la animación de PowerPoint. Cada diapositiva solo puede tener una única línea de tiempo de animación.

## **Animación interactiva**

[Trigger](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effecttriggertype/) le permite definir acciones del usuario (p. ej., un clic de botón) que inician una animación específica. Los disparadores se añadieron solo en las versiones más recientes de PowerPoint.

## **Animación de forma**

Aspose.Slides le permite aplicar animaciones a formas —como texto, rectángulos, líneas, marcos, objetos OLE y más.

{{% alert color="primary" %}}
Lea más [**Acerca de la animación de forma**](/slides/es/python-net/shape-animation/).
{{% /alert %}}

## **Gráficos animados**

Para crear gráficos animados, utilice las mismas clases que usa para formas. Sin embargo, las animaciones de PowerPoint solo pueden aplicarse a categorías de gráfico o series de gráfico. También puede aplicar un efecto de animación a un elemento de categoría individual o a un elemento de serie.

{{% alert color="primary" %}}
Lea más [**Acerca de los gráficos animados**](/slides/es/python-net/animated-charts/).
{{% /alert %}}

## **Texto animado**

Además de animar texto, puede aplicar animación a un párrafo.

{{% alert color="primary" %}}
Lea más [**Acerca del texto animado**](/slides/es/python-net/animated-text/).
{{% /alert %}}

## **Preguntas frecuentes**

### ¿Se conservarán las animaciones al exportar a PDF?

No. PDF es un formato estático, por lo que las animaciones y las [transiciones de diapositiva](/slides/es/python-net/slide-transition/) no se reproducen. Si necesita movimiento, exporte a [HTML5](/slides/es/python-net/export-to-html5/), [GIF animado](/slides/es/python-net/convert-powerpoint-to-animated-gif/) o [vídeo](/slides/es/python-net/convert-powerpoint-to-video/) en su lugar.

### ¿Puedo convertir una presentación animada en un vídeo y controlar la velocidad de fotogramas y el tamaño del fotograma?

Sí. Puede [renderizar la presentación como fotogramas](/slides/es/python-net/convert-powerpoint-to-video/) y codificarlos en un vídeo (p. ej., mediante ffmpeg), eligiendo los FPS y la resolución. Las animaciones y las transiciones de diapositiva se reproducen durante el renderizado.

### ¿Se mantendrán intactas las animaciones al trabajar con ODP (no solo PPTX)?

PPT, PPTX y ODP son compatibles para [lectura](/slides/es/python-net/open-presentation/) y [escritura](/slides/es/python-net/save-presentation/), pero las diferencias de formato hacen que ciertos efectos puedan verse o comportarse ligeramente diferente. Valide los casos críticos con muestras reales.