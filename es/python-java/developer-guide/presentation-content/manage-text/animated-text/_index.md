---
title: Animar texto de PowerPoint en Python via Java
linktitle: Texto animado
type: docs
weight: 60
url: /es/python-java/animated-text/
keywords:
- texto animado
- animación de texto
- párrafo animado
- animación de párrafo
- efecto de animación
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Cree texto animado dinámico en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Python via Java, con ejemplos de código Python fáciles de seguir y optimizados."
---
## **Descripción general**

Este artículo explica cómo trabajar con texto animado en Aspose.Slides aplicando efectos de animación a párrafos individuales y recuperando los efectos ya asignados a los párrafos en un cuadro de texto. Se centra en los métodos de la API utilizados para añadir animación a nivel de párrafo y examinar los efectos de animación de párrafo existentes en una presentación.

## **Añadir efectos de animación a los párrafos**

El método [addEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/sequence/#addEffect) de la clase [Sequence](https://reference.aspose.com/slides/es/python-java/aspose.slides/sequence/) permite añadir efectos de animación a un solo párrafo. Este código de ejemplo muestra cómo añadir un efecto de animación a un solo párrafo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Seleccione el párrafo al que añadir un efecto.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Añada un efecto de animación Fly al párrafo seleccionado.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obtener efectos de animación de los párrafos**

Puede que necesite averiguar los efectos de animación añadidos a un párrafo; por ejemplo, en un escenario desea obtener los efectos de animación de un párrafo porque planea aplicar esos efectos a otro párrafo o forma.

Aspose.Slides for Python via Java le permite obtener todos los efectos de animación aplicados a los párrafos contenidos en un cuadro de texto (forma). Este código de ejemplo muestra cómo obtener los efectos de animación en un párrafo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿En qué se diferencian las animaciones de texto de las transiciones de diapositiva, y pueden combinarse?**

Las animaciones de texto controlan el comportamiento del objeto a lo largo del tiempo en una diapositiva, mientras que [transitions](/slides/es/python-java/slide-transition/) controlan cómo cambian las diapositivas. Son independientes y pueden usarse juntas; el orden de reproducción lo determina la línea de tiempo de animación y la configuración de la transición.

**¿Se conservan las animaciones de texto al exportar a PDF o imágenes?**

No. PDF e imágenes rasterizadas son estáticas, por lo que verá un único estado de la diapositiva sin movimiento. Para conservar el movimiento, use la exportación a [video](/slides/es/python-java/convert-powerpoint-to-video/) o [HTML](/slides/es/python-java/export-to-html5/).

**¿Funcionan las animaciones de texto en los diseños y la diapositiva maestra?**

Los efectos aplicados a objetos de diseño/maestra se heredan por las diapositivas, pero su temporización e interacción con animaciones a nivel de diapositiva dependen de la secuencia final en la diapositiva.