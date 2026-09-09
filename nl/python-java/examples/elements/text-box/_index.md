---
title: Tekstvak
type: docs
weight: 40
url: /nl/python-java/examples/elements/text-box/
keywords:
- codevoorbeeld
- tekstvak
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Werk met tekstvakken in Aspose.Slides for Python via Java: voeg toe, formatteer, zoek en verwijder tekst in PowerPoint- en OpenDocument-presentaties."
---
In **Aspose.Slides for Python via Java** is een tekstvak een autovorm die tekst bevat. Bijna elke vorm kan tekst bevatten, maar een typisch tekstvak heeft geen opvulling of rand en toont alleen tekst.

Deze gids legt uit hoe u tekstvakken programmatisch kunt toevoegen, openen en verwijderen.

Installeer het pakket zoals beschreven in [Installatie](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` vóór het starten van de JVM, en importeert vervolgens de API nadat de JVM draait.

## **Tekstvak toevoegen**

Maak een rechthoek, verwijder de opvulling en rand, en ken opgemaakte tekst toe.

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

    # Maak een rechthoekvorm aan.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # Verwijder de opvulling en rand om alleen tekst weer te geven.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # Stel de standaardtekstopmaak in.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **Toegang tot tekstvakken op basis van inhoud**

Voeg een voorbeeldtekstvak toe, zoek vervolgens vormen waarvan de tekst het trefwoord "Slide" bevat.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
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
                # Gebruik het overeenkomende tekstvak.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **Verwijderen van tekstvakken op basis van inhoud**

Zoek en verwijder tekstvakken op de eerste dia die een specifiek trefwoord bevatten.

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
Verzamel overeenkomende vormen in een aparte lijst voordat u ze verwijdert, om te voorkomen dat de vormverzameling tijdens het itereren wordt aangepast.
{{% /alert %}}