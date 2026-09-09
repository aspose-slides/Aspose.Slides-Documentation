---
title: Mejora tus presentaciones con AutoFit en Python
linktitle: Configuración de Autofit
type: docs
weight: 30
url: /es/python-java/manage-autofit-settings/
keywords:
- cuadro de texto
- ajuste automático
- no ajustar automáticamente
- ajustar texto
- reducir texto
- envolver texto
- redimensionar forma
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda a gestionar la configuración de AutoFit en Aspose.Slides para Python a través de Java para optimizar la visualización del texto en sus presentaciones de PowerPoint y OpenDocument y mejorar la legibilidad del contenido."
---
## **Introducción**

Por defecto, cuando añades un cuadro de texto, Microsoft PowerPoint usa la configuración **Resize shape to fit text** para el cuadro de texto: redimensiona automáticamente el cuadro de texto para garantizar que su texto siempre quepa en él.

![Cuadro de texto en PowerPoint](textbox-in-powerpoint.png)

* Cuando el texto del cuadro se hace más largo o más grande, PowerPoint amplía automáticamente el cuadro —aumenta su altura— para permitir que contenga más texto.  
* Cuando el texto del cuadro se acorta o disminuye, PowerPoint reduce automáticamente el cuadro —disminuye su altura— para eliminar el espacio sobrante.

En PowerPoint, estos son los 4 parámetros u opciones importantes que controlan el comportamiento de autofit para un cuadro de texto:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![opciones‑autofit‑powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java ofrece opciones similares —algunas propiedades bajo la clase [TextFrameFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/)— que permiten controlar el comportamiento de autofit para los cuadros de texto en presentaciones.

## **Redimensionar forma para ajustarse al texto**

Si deseas que el texto de un cuadro siempre quepa dentro de él después de cualquier cambio, debes usar la opción **Resize shape to fit text**. Para especificar esta configuración, usa el método [setAutofitType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setAutofitType) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/)) con [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/textautofittype/#Shape).

![ajuste‑siempre‑powerpoint](alwaysfit-setting-powerpoint.png)

Este código Python muestra cómo indicar que el texto debe ajustarse siempre a su cuadro en una presentación de PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (aumentará su altura) para que todo el texto quepa. Si el texto se acorta, ocurrirá lo inverso.

## **No autofit**

Si deseas que un cuadro de texto o forma mantenga sus dimensiones independientemente de los cambios en el texto que contiene, debes usar la opción **Do not Autofit**. Para especificar esta configuración, usa el método [setAutofitType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setAutofitType) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/)) con [None](https://reference.aspose.com/slides/es/python-java/aspose.slides/textautofittype/#None).

![no‑autofit‑powerpoint](donotautofit-setting-powerpoint.png)

Este código Python muestra cómo indicar que un cuadro de texto debe mantener siempre sus dimensiones en una presentación de PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cuando el texto supera el tamaño del cuadro, se desborda.

## **Reducir texto al desbordarse**

Si el texto se vuelve demasiado largo para su cuadro, puedes usar la opción **Shrink text on overflow** para indicar que el tamaño y el espaciado del texto deben reducirse para que quepa en el cuadro. Para especificar esta configuración, usa el método [setAutofitType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setAutofitType) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/)) con [Normal](https://reference.aspose.com/slides/es/python-java/aspose.slides/textautofittype/#Normal).

![reducir‑texto‑desbordamiento‑powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código Python muestra cómo indicar que el texto debe reducirse al desbordarse en una presentación de PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Nota" color="info" %}}
Cuando se utiliza la opción **Shrink text on overflow**, el ajuste se aplica solo cuando el texto supera el ancho del cuadro.  
{{% /alert %}}

## **Ajustar texto en forma**

Si deseas que el texto dentro de una forma se ajuste (haga wrap) cuando supera el borde de la forma (solo ancho), debes usar el parámetro **Wrap text in shape**. Para especificar esta configuración, debes usar el método [setWrapText](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setWrapText) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/)) con [NullableBool.True_](https://reference.aspose.com/slides/es/python-java/aspose.slides/nullablebool/#True).

Este código Python muestra cómo usar la configuración Wrap Text en una presentación de PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Advertencia" color="warning" %}} 
Si utilizas el método [setWrapText](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setWrapText) con [NullableBool.False](https://reference.aspose.com/slides/es/python-java/aspose.slides/nullablebool/#False) para una forma, cuando el texto dentro de la forma supera su anchura, el texto se extenderá más allá de los bordes de la forma en una sola línea.  
{{% /alert %}}

## **Preguntas frecuentes**

**¿Los márgenes internos del marco de texto afectan al AutoFit?**

Sí. El padding (márgenes internos) reduce el área utilizable para el texto, por lo que AutoFit se activará antes, reduciendo la fuente o el tamaño de la forma con mayor rapidez. Revisa y ajusta los márgenes antes de afinar AutoFit.

**¿Cómo interactúa AutoFit con saltos de línea manuales y suaves?**

Los saltos forzados permanecen, y AutoFit adapta el tamaño de la fuente y el espaciado a su alrededor. Eliminar saltos innecesarios suele reducir la agresividad con la que AutoFit debe encoger el texto.

**¿Cambiar la fuente del tema o activar la sustitución de fuentes afecta a los resultados de AutoFit?**

Sí. Sustituir una fuente por otra con métricas de glifos diferentes cambia el ancho/alto del texto, lo que puede modificar el tamaño final de la fuente y el ajuste de líneas. Tras cualquier cambio o sustitución de fuente, revisa nuevamente las diapositivas.