---
title: "Mejore sus presentaciones con AutoFit en Python"
linktitle: "Configuración de Autofit"
type: docs
weight: 30
url: /es/python-java/manage-autofit-settings/
keywords:
- "cuadro de texto"
- "autofit"
- "no autofit"
- "ajustar texto"
- "reducir texto"
- "ajustar texto"
- "redimensionar forma"
- "PowerPoint"
- "OpenDocument"
- "presentación"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aprenda a gestionar la configuración de AutoFit en Aspose.Slides para Python a través de Java para optimizar la visualización del texto en sus presentaciones de PowerPoint y OpenDocument y mejorar la legibilidad del contenido."
---
## **Introducción**

Por defecto, cuando añades un cuadro de texto, Microsoft PowerPoint usa la configuración **Resize shape to fix text** para el cuadro de texto; redimensiona automáticamente el cuadro de texto para garantizar que su contenido siempre quepa en él. 

![caja de texto en PowerPoint](textbox-in-powerpoint.png)

* Cuando el texto del cuadro de texto se vuelve más largo o más grande, PowerPoint amplía automáticamente el cuadro de texto—incrementa su altura—para permitir que contenga más texto. 
* Cuando el texto del cuadro de texto se vuelve más corto o más pequeño, PowerPoint reduce automáticamente el cuadro de texto—disminuye su altura—para eliminar el espacio redundante. 

En PowerPoint, estos son los 4 parámetros u opciones importantes que controlan el comportamiento de autofit para un cuadro de texto: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![opciones autofit en PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java proporciona opciones similares—algunas propiedades bajo la clase [TextFrameFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/)—que le permiten controlar el comportamiento de autofit para los cuadros de texto en presentaciones. 

## **Redimensionar una forma para que se ajuste al texto**

Si desea que el texto en un recuadro se ajuste siempre a ese recuadro después de realizar cambios en el texto, debe usar la opción **Resize shape to fix text**. Para especificar esta configuración, utilice el método [setAutofitType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setAutofitType) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/)) con [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/textautofittype/#Shape).

![configuración siempre ajustada en PowerPoint](alwaysfit-setting-powerpoint.png)

Este código Python le muestra cómo especificar que un texto siempre debe caber en su recuadro en una presentación de PowerPoint:

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

Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (aumentará su altura) para asegurar que todo el texto quepa en él. Si el texto se vuelve más corto, ocurre lo contrario. 

## **No autofit**

Si desea que un cuadro de texto o forma mantenga sus dimensiones sin importar los cambios realizados en el texto que contiene, debe usar la opción **Do not Autofit**. Para especificar esta configuración, utilice el método [setAutofitType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setAutofitType) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/)) con [None](https://reference.aspose.com/slides/es/python-java/aspose.slides/textautofittype/#None). 

![configuración no autofit en PowerPoint](donotautofit-setting-powerpoint.png)

Este código Python le muestra cómo especificar que un cuadro de texto debe mantener siempre sus dimensiones en una presentación de PowerPoint:

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
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cuando el texto se vuelve demasiado largo para su recuadro, se desborda. 

## **Reducir texto al desbordarse**

Si un texto se vuelve demasiado largo para su recuadro, mediante la opción **Shrink text on overflow** puede indicar que el tamaño y el espaciado del texto deben reducirse para que quepan en el recuadro. Para especificar esta configuración, utilice el método [setAutofitType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setAutofitType) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/)) con [Normal](https://reference.aspose.com/slides/es/python-java/aspose.slides/textautofittype/#Normal).

![configuración reducir texto al desbordarse en PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Este código Python le muestra cómo especificar que un texto debe reducirse al desbordarse en una presentación de PowerPoint:

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
Cuando se usa la opción **Shrink text on overflow**, la configuración se aplica solo cuando el texto se vuelve demasiado largo para su recuadro. 
{{% /alert %}}

## **Ajustar texto**

Si desea que el texto en una forma se ajuste dentro de esa forma cuando el texto supera el borde de la forma (solo el ancho), debe usar el parámetro **Wrap text in shape**. Para especificar esta configuración, debe utilizar el método [setWrapText](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setWrapText) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/)) con [NullableBool.True](https://reference.aspose.com/slides/es/python-java/aspose.slides/nullablebool/#True). 

Este código Python le muestra cómo usar la configuración Wrap Text en una presentación de PowerPoint:

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
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Advertencia" color="warning" %}} 
Si utiliza el método [setWrapText](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setWrapText) con [NullableBool.False](https://reference.aspose.com/slides/es/python-java/aspose.slides/nullablebool/#False) para una forma, cuando el texto dentro de la forma se vuelve más largo que el ancho de la forma, el texto se extiende más allá de los bordes de la forma en una sola línea. 
{{% /alert %}}

## **FAQ**

**¿Los márgenes internos del marco de texto afectan a AutoFit?**

Sí. El relleno (márgenes internos) reduce el área usable para el texto, por lo que AutoFit se activará antes, reduciendo la fuente o redimensionando la forma con mayor rapidez. Compruebe y ajuste los márgenes antes de afinar AutoFit.

**¿Cómo interactúa AutoFit con los saltos de línea manuales y suaves?**

Los saltos forzados permanecen en su lugar, y AutoFit adapta el tamaño de la fuente y el espaciado a su alrededor. Eliminar saltos innecesarios a menudo reduce la agresividad con la que AutoFit necesita reducir el texto.

**¿Cambiar la fuente del tema o activar la sustitución de fuentes afecta a los resultados de AutoFit?**

Sí. Sustituir una fuente por otra con métricas de glifos diferentes modifica el ancho/alto del texto, lo que puede alterar el tamaño final de la fuente y el ajuste de líneas. Después de cualquier cambio o sustitución de fuente, vuelva a comprobar las diapositivas.