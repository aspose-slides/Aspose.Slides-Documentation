---
title: Inkt
type: docs
weight: 180
url: /nl/python-java/examples/elements/ink/
keywords:
- codevoorbeeld
- inkt
- ink benaderen
- ink verwijderen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Toegang tot en verwijdering van inktvormen in Aspose.Slides voor Python via Java presentaties, inclusief PPT-, PPTX- en ODP-bestanden."
---
Dit artikel geeft voorbeelden van het benaderen van bestaande inktvormen en het verwijderen daarvan met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installatie](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` vóór het starten van de JVM, en importeert daarna de API nadat de JVM draait.

{{% alert color="info" title="Note" %}}
Inktvormen vertegenwoordigen gebruikersinvoer van gespecialiseerde apparaten. Aspose.Slides kan geen nieuwe inktstreken programmatig creëren, maar je kunt bestaande inkt lezen en aanpassen.
{{% /alert %}}

## **Inkt benaderen**

Lees de tags van de eerste inktvorm op een dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # Gebruik tag_name indien nodig.
finally:
    presentation.dispose()
```

## **Inkt verwijderen**

Verwijder een inktvorm van de dia als er één bestaat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```