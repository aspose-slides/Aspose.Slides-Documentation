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
description: "Pas presentatienotities aan met Aspose.Slides voor Python via .NET. Werk naadloos met PowerPoint- en OpenDocument-notities om uw productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notitieslides uit een presentatie. In dit onderwerp introduceren we deze functionaliteit, inclusief hoe notities te verwijderen en hoe een stijl toe te passen op notitieslides in een presentatie. Aspose.Slides stelt u in staat notities van elke dia te verwijderen en ook opmaak toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Notities verwijderen van een specifieke dia in een presentatie.
- Notities verwijderen van alle dia's in een presentatie.

Om de afmetingen van de notitiepagina te lezen of te wijzigen, de oriëntatie te wijzigen en het exportgedrag te controleren, zie [Notitiepagina-grootte](/slides/nl/python-net/notes-size/).

## **Notities van een dia verwijderen**
Notities van een specifieke dia kunnen worden verwijderd zoals weergegeven in het onderstaande voorbeeld:

```py
import aspose.slides as slides

# Maak een Presentation-object dat een presentatiebestand vertegenwoordigt 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Notities van de eerste dia verwijderen
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # sla de presentatie op naar schijf 
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Notities van alle dia's verwijderen**
Notities van alle dia's in een presentatie kunnen worden verwijderd zoals weergegeven in het onderstaande voorbeeld:

```py
import aspose.slides as slides

# Maak een Presentation-object dat een presentatiebestand vertegenwoordigt 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Notities van alle dia's verwijderen
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # sla de presentatie op naar schijf 
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Een notitiestijl toepassen**
De eigenschap [notes_style](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslide/notes_style/) is toegevoegd aan de klasse [MasterNotesSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslide/). Deze eigenschap geeft de stijl van de notitietekst aan. De implementatie wordt gedemonstreerd in het onderstaande voorbeeld.

```py
import aspose.slides as slides

# Instantieer Presentation-klasse die het presentiebestand vertegenwoordigt
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Haal tekststijl van MasterNotesSlide op
        notesStyle = notesMaster.notes_style

        #Stel symboolopsomming in voor alinea's van het eerste niveau
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # sla het PPTX-bestand op naar de schijf
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Welke API‑entiteit biedt toegang tot de notities van een specifieke dia?**

Notities worden benaderd via de notitiemanager van de dia: de dia heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/notesslidemanager/) en een [property](https://reference.aspose.com/slides/nl/python-net/aspose.slides/notesslidemanager/notes_slide/) die het notitie‑object retourneert, of `None` als er geen notities zijn.

**Zijn er verschillen in notitie‑ondersteuning tussen de PowerPoint‑versies waarvoor de bibliotheek werkt?**

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑indelingen (97‑en nieuwer) en ODP; notities worden ondersteund binnen deze indelingen zonder dat er een geïnstalleerde versie van PowerPoint nodig is.