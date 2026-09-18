---
title: Mejorar presentaciones de PowerPoint con animaciones en Python
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
description: "Explore las capacidades de Aspose.Slides for Python via .NET para gestionar animaciones de PowerPoint. Esta visión general destaca características clave y ofrece ideas para mejorar sus presentaciones."
---
## **Introducción**

Las presentaciones están diseñadas para transmitir información, por lo que su apariencia visual y comportamiento interactivo son consideraciones clave durante su creación.

**PowerPoint animation** desempeña un papel importante para que una presentación sea atractiva y cautivadora para los espectadores. Aspose.Slides for Python via .NET ofrece una amplia gama de opciones para añadir animación a una presentación de PowerPoint. Puedes:

- Aplicar varios efectos de animación a formas, gráficos, tablas, objetos OLE y otros elementos.
- Usar múltiples efectos de animación en una sola forma.
- Controlar los efectos mediante la línea de tiempo de animación.
- Crear animaciones personalizadas.

En Aspose.Slides for Python via .NET, los efectos de animación pueden aplicarse a formas. Dado que cada elemento de una diapositiva —incluido texto, imágenes, objetos OLE y tablas— se trata como una forma, puedes aplicar efectos de animación a cualquier elemento de la diapositiva.

El espacio de nombres [aspose.slides.animation](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/) proporciona las clases para trabajar con animaciones de PowerPoint.

## **Instalación**

```bash
pip install aspose.slides
```

## **Añadir un efecto de animación a una forma en Python**

Los efectos de animación se encuentran en la secuencia principal de una diapositiva. Añade una forma y luego llama a `add_effect` en `slide.timeline.main_sequence`, pasando el tipo de efecto, su subtipo y el desencadenador que lo inicia.

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

El archivo guardado contiene un efecto en la primera diapositiva: el rectángulo entra volando desde la izquierda durante dos segundos cuando el presentador hace clic. Al volver a abrirlo y leer `slide.timeline.main_sequence` se obtiene ese efecto, por lo que la animación sobrevive al proceso de ida y vuelta en lugar de existir sólo en la memoria.

## **Efectos de animación**

Aspose.Slides soporta **más de 150 efectos de animación**, incluidos efectos básicos como Bounce, PathFootball y Zoom, así como efectos especializados como OLEObjectShow y OLEObjectOpen. Puedes encontrar la lista completa en la enumeración [EffectType](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effecttype/).

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

Para ejemplos completos en Python que crean, inspeccionan y modifican comportamientos y rutas de movimiento editables, consulta [Animación personalizada](/slides/es/python-net/custom-animation/).

Puedes crear tus propias **animaciones personalizadas** en Aspose.Slides combinando varios comportamientos en un único efecto.

[Behavior](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behavior/) es un bloque de construcción de un efecto de animación de PowerPoint. Combina comportamientos para personalizar un efecto, o añade un comportamiento para ampliar un efecto predefinido. La repetición se configura mediante la configuración de tiempo en lugar de un comportamiento de repetición separado.

[Animation Point](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/point/) marca el momento o la posición en que se aplica un comportamiento (un fotograma clave).

## **Línea de tiempo de animación**

[Sequence](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/sequence/) es una colección de efectos de animación que pueden dirigirse a diferentes formas.

[Timeline](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/animationtimeline/) es el conjunto de secuencias utilizado en una diapositiva concreta. Fue introducido en PowerPoint 2002. En versiones anteriores de PowerPoint, añadir efectos de animación era difícil y a menudo requería soluciones alternativas. Timeline sustituye a la antigua clase `AnimationSettings` y proporciona un modelo de objetos más claro para la animación en PowerPoint. Cada diapositiva solo puede tener una única línea de tiempo de animación.

## **Animación interactiva**

[Trigger](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effecttriggertype/) te permite definir acciones de usuario (p.ej., el clic de un botón) que inician una animación específica. Los disparadores solo se añadieron en las versiones más recientes de PowerPoint.

## **Animación de formas**

Aspose.Slides te permite aplicar animaciones a formas —como texto, rectángulos, líneas, marcos, objetos OLE y más.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca de la animación de formas**](/slides/es/python-net/shape-animation/).
{{% /alert %}}

## **Gráficos animados**

Para crear gráficos animados, utiliza las mismas clases que usas para formas. Sin embargo, las animaciones de PowerPoint solo pueden aplicarse a categorías de gráfico o series de gráfico. También puedes aplicar un efecto de animación a un elemento de categoría individual o a un elemento de serie.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca de los gráficos animados**](/slides/es/python-net/animated-charts/).
{{% /alert %}}

## **Texto animado**

Además de animar texto, puedes **aplicar animación a un párrafo**.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca del texto animado**](/slides/es/python-net/animated-text/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se conservarán las animaciones al exportar a PDF?**

No. PDF es un formato estático, por lo que las animaciones y las [transiciones de diapositiva](/slides/es/python-net/slide-transition/) no se reproducen. Si necesitas movimiento, exporta a [HTML5](/slides/es/python-net/export-to-html5/), [GIF animado](/slides/es/python-net/convert-powerpoint-to-animated-gif/), o [vídeo](/slides/es/python-net/convert-powerpoint-to-video/) en su lugar.

**¿Puedo convertir una presentación animada en un vídeo y controlar la velocidad de fotogramas y el tamaño del fotograma?**

Sí. Puedes [renderizar la presentación como fotogramas](/slides/es/python-net/convert-powerpoint-to-video/) y codificarlos en un vídeo (p. ej., mediante ffmpeg), eligiendo los FPS y la resolución. Las animaciones y las transiciones de diapositiva se reproducen durante el renderizado.

**¿Se mantendrán las animaciones intactas al trabajar con ODP (no solo PPTX)?**

PPT, PPTX y ODP son compatibles para [leer](/slides/es/python-net/open-presentation/) y [escribir](/slides/es/python-net/save-presentation/), pero esto no garantiza la preservación de las animaciones. Los datos de animación personalizada pueden perderse al convertir a ODP. Consulta [Animación personalizada](/slides/es/python-net/custom-animation/) para ejemplos y orientación sobre cómo comprobar la compatibilidad de formatos.