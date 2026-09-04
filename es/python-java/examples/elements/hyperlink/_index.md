---
title: Hipervínculo
type: docs
weight: 130
url: /es/python-java/examples/elements/hyperlink/
keywords:
- ejemplo de código
- hipervínculo
- agregar hipervínculo
- acceder al hipervínculo
- eliminar hipervínculo
- actualizar hipervínculo
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Agregar y gestionar hipervínculos en Aspose.Slides para Python mediante Java: crear, acceder, eliminar y actualizar enlaces en presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo agregar, acceder, eliminar y actualizar hipervínculos en formas usando **Aspose.Slides for Python via Java**.

Instale el paquete según se describe en [Instalación](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y, a continuación, importa la API una vez que la JVM está en ejecución.

## **Agregar un hipervínculo**

Cree una forma rectangular con un hipervínculo que apunte a un sitio web externo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **Acceder a un hipervínculo**

Lea la información del hipervínculo de la porción de texto de una forma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **Eliminar un hipervínculo**

Borre el hipervínculo del texto de una forma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **Actualizar un hipervínculo**

Cambie el destino de un hipervínculo existente. Utilice [HyperlinkManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkmanager/) para modificar texto que ya contiene un hipervínculo, lo que imita cómo PowerPoint actualiza los hipervínculos de forma segura.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # Cambiar un hipervínculo dentro del texto existente debe hacerse a través de
    # HyperlinkManager en lugar de establecer la propiedad directamente.
    # Esto imita cómo PowerPoint actualiza los hipervínculos de manera segura.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```