---
title: Beheer presentatienotities in Python
linktitle: Presentatienotities
type: docs
weight: 110
url: /nl/python-net/presentation-notes/
keywords:
- notities
- notitieslide
- notities toevoegen
- notities verwijderen
- notitiestijl
- masternotities
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Pas presentatienotities aan met Aspose.Slides voor Python via .NET. Werk moeiteloos met PowerPoint- en OpenDocument-notities om uw productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notitieslides uit een presentatie. In dit onderwerp introduceren we deze functie, inclusief hoe notities te verwijderen en hoe een stijl toe te passen op notitieslides in een presentatie. Aspose.Slides stelt je in staat om notities van elke dia te verwijderen en tevens styling toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Notities van een specifieke dia in een presentatie verwijderen.
- Notities van alle dia's in een presentatie verwijderen.

## **Notities van dia verwijderen**
Notities van een specifieke dia kunnen worden verwijderd zoals weergegeven in het voorbeeld hieronder:

```py
import aspose.slides as slides

# Instantieer een Presentation‑object dat een presentatie‑bestand vertegenwoordigt
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Notities van de eerste dia verwijderen
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # presentatie opslaan op schijf
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Notities van alle dia's verwijderen**
Notities van alle dia's in een presentatie kunnen worden verwijderd zoals weergegeven in het voorbeeld hieronder:

```py
import aspose.slides as slides

# Instantieer een Presentation-object dat een presentatie-bestand vertegenwoordigt 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Notities van alle dia's verwijderen
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # presentatie opslaan op schijf
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Notitiesstijl toevoegen**
De [notes_style](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslide/notes_style/) eigenschap is toegevoegd aan de [MasterNotesSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslide/) klasse. Deze eigenschap specificeert de stijl van een notitietekst. De implementatie wordt getoond in het voorbeeld hieronder.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse die het presentiebestand vertegenwoordigt
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Haal de tekststijl van MasterNotesSlide op
        notesStyle = notesMaster.notes_style

        #Stel symbool opsommingsteken in voor de alinea's van het eerste niveau
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # sla het PPTX‑bestand op naar de schijf
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Veelgestelde vragen**

**Welke API-entiteit biedt toegang tot de notities van een specifieke dia?**

Notities worden benaderd via de notitiebeheerder van de dia: de dia heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/notesslidemanager/) en een [property](https://reference.aspose.com/slides/nl/python-net/aspose.slides/notesslidemanager/notes_slide/) die het notitie‑object retourneert, of `None` wanneer er geen notities zijn.

**Zijn er verschillen in notitie‑ondersteuning tussen de PowerPoint‑versies waarmee de bibliotheek werkt?**

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑formaten (97‑en nieuwer) en ODP; notities worden ondersteund in deze formaten zonder dat er een geïnstalleerde copie van PowerPoint nodig is.