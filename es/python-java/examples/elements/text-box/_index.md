---
title: Cuadro de texto
type: docs
weight: 40
url: /es/python-java/examples/elements/text-box/
keywords:
- ejemplo de código
- cuadro de texto
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Trabaje con cuadros de texto en Aspose.Slides para Python mediante Java: añada, dé formato, busque y elimine texto en presentaciones de PowerPoint y OpenDocument."
---
En **Aspose.Slides for Python via Java**, un cuadro de texto es una forma automática que contiene texto. Casi cualquier forma puede contener texto, pero un cuadro de texto típico no tiene relleno ni borde y solo muestra texto.

Esta guía explica cómo añadir, acceder y eliminar cuadros de texto mediante código.

Instale el paquete como se describe en [Installation](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y, a continuación, importa la API una vez que la JVM se está ejecutando.

## **Add a Text Box**

Cree un rectángulo, elimine su relleno y borde, y asigne texto con formato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Crear una forma rectangular.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # Eliminar el relleno y el borde para mostrar solo texto.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # Establecer el formato de texto predeterminado.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **Access Text Boxes by Content**

Añada un cuadro de texto de ejemplo y, a continuación, busque formas cuyo texto contenga la palabra clave "Slide".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # Utilizar el cuadro de texto coincidente.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **Remove Text Boxes by Content**

Encuentre y elimine los cuadros de texto en la primera diapositiva que contengan una palabra clave específica.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
Recoja las formas coincidentes en una lista separada antes de eliminarlas para evitar modificar la colección de formas durante la iteración.
{{% /alert %}}