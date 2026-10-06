---
title: Beheer presentatienotities in Python via Java
linktitle: Presentatienotities
type: docs
weight: 110
url: /nl/python-java/presentation-notes/
keywords:
- notities
- notitiesdia
- notities toevoegen
- notities verwijderen
- notitiestijl
- masternotities
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Pas presentatienotities aan met Aspose.Slides voor Python via Java. Werk moeiteloos met PowerPoint- en OpenDocument-notities om uw productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notities van een presentatie. Dit onderwerp introduceert deze functionaliteit, inclusief hoe notities te verwijderen en hoe een stijl toe te passen op notitieslides in een presentatie. Aspose.Slides maakt het mogelijk om notities van elke dia te verwijderen en stijl toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Notities verwijderen van een specifieke dia in een presentatie.
- Notities verwijderen van alle dia's in een presentatie.

Voor het lezen of wijzigen van de afmetingen van de notitiepagina, het wisselen van oriëntatie en het controleren van exportgedrag, zie [Notitiepagina-grootte](/slides/nl/python-java/notes-size/).

## **Notities van een dia verwijderen**

Notities van een specifieke dia kunnen worden verwijderd zoals weergegeven in het voorbeeld hieronder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Maak een Presentation-object dat een presentatiebestand vertegenwoordigt.
presentation = Presentation("presWithNotes.pptx")
try:
    # Verwijder notities van de eerste dia.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Sla de presentatie op de schijf op.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Notities van een presentatie verwijderen**

Notities van alle dia's in een presentatie kunnen worden verwijderd zoals weergegeven in het voorbeeld hieronder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Maak een Presentation-object dat een presentatiebestand vertegenwoordigt.
presentation = Presentation("presWithNotes.pptx")
try:
    # Verwijder notities van alle dia's.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Sla de presentatie op de schijf op.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Een notitiestijl toevoegen**

De [getNotesStyle](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masternotesslide/#getNotesStyle)‑methode van de klasse [MasterNotesSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masternotesslide/) biedt toegang tot de stijl van notitietekst. De implementatie wordt gedemonstreerd in het voorbeeld hieronder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Maak een Presentation-object dat een presentatiebestand vertegenwoordigt.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Haal de tekstopmaak van de master‑notitiesdia op.
        notes_style = notes_master.getNotesStyle()

        # Stel symbool‑opsommingstekens in voor alinea's van het eerste niveau.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Welke API‑entiteit biedt toegang tot de notities van een specifieke dia?**

Notities worden benaderd via de notitie‑manager van de dia: de dia heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notesslidemanager/) en een [getNotesSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notesslidemanager/#getNotesSlide)‑methode die het notitie‑object retourneert, of `None` als er geen notities aanwezig zijn.

**Zijn er verschillen in notitie‑ondersteuning tussen de PowerPoint‑versies waarmee de bibliotheek werkt?**

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑formaten (97 en later) en ODP; notities worden ondersteund binnen deze formaten zonder dat er een geïnstalleerde kopie van PowerPoint nodig is.