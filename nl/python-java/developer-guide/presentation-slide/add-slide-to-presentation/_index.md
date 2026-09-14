---
title: "Dia's toevoegen aan presentaties in Python"
linktitle: "Dia toevoegen"
type: docs
weight: 10
url: /nl/python-java/add-slide-to-presentation/
keywords:
- "dia toevoegen"
- "dia aanmaken"
- "lege dia"
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Voeg eenvoudig dia's toe aan uw PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via Java—naadloze, efficiënte dia-invoeging in enkele seconden."
---
## **Overzicht**

Aspose.Slides maakt het mogelijk om dia's programmatisch toe te voegen aan PowerPoint‑presentaties. Een presentatie bevat master‑/indelingsdia's en normale dia's, en de normale dia's worden gerangschikt op een nul‑gebaseerde index. Elke dia heeft een unieke ID, en presentaties zonder dia's worden niet ondersteund.

Dit artikel legt uit hoe u een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object maakt, toegang krijgt tot de dia‑collectie, een lege dia toevoegt, werkt met de nieuw toegevoegde dia en de bijgewerkte presentatie opslaat. Het behandelt ook gerelateerde punten, zoals het invoegen van dia's op een specifieke positie, het gebruik van lay-outs en het begrijpen van de lege dia die aanwezig is in een nieuw aangemaakte presentatie.

## **Een dia toevoegen aan een presentatie**

Voordat we bespreken hoe dia's aan presentaties worden toegevoegd, laten we enkele feiten over dia's herzien. Elk PowerPoint‑presentatiebestand bevat **master/indeling**‑dia's en **normale** dia's. Een presentatiebestand bevat minimaal één dia. Presentatiebestanden zonder dia's worden niet ondersteund door Aspose.Slides for Python via Java. Elke dia heeft een unieke ID, en alle normale dia's worden gerangschikt volgens een nul‑gebaseerde index.

Aspose.Slides for Python via Java stelt ontwikkelaars in staat lege dia's aan hun presentaties toe te voegen. Om een lege dia toe te voegen aan een presentatie, volgt u deze stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse aan.
- Verkrijg een referentie naar het [SlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/)‑object met behulp van de [getSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlides)‑methode die beschikbaar is via het [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object.
- Voeg een lege dia toe aan het einde van de slide‑collectie van de presentatie door de [addEmptySlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addEmptySlide)‑methode van het [SlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/)‑object aan te roepen.
- Voer wat bewerkingen uit op de nieuw toegevoegde lege dia.
- Schrijf tenslotte het presentatie‑bestand weg met behulp van het [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantieer de Presentation-klasse die het presentatie‑bestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de slide‑collectie op.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # Voeg een lege dia toe aan de slide‑collectie.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # Voer wat bewerkingen uit op de nieuw toegevoegde dia.

    # Sla het PPTX‑bestand op naar schijf.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik een nieuwe dia op een specifieke positie invoegen, niet alleen aan het einde?**

Ja. De bibliotheek ondersteunt dia‑collecties en [insert](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#insertClone)‑bewerkingen, zodat u een dia kunt toevoegen op de vereiste index in plaats van alleen aan het einde.

**Worden thema’s/opmaak behouden bij het toevoegen van een dia op basis van een lay-out?**

Ja. Een lay-out erft de opmaak van de master, en de nieuwe dia erft van de geselecteerde lay-out en de bijbehorende master.

**Welke dia staat er in een nieuwe “lege” presentatie voordat er dia's worden toegevoegd?**

Een nieuw aangemaakte presentatie bevat al één lege dia met index nul. Dit is belangrijk om in gedachten te houden bij het berekenen van invoeg‑indices.

**Hoe kies ik de “juiste” lay-out voor een nieuwe dia als de master veel opties biedt?**

Kies over het algemeen de [LayoutSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/) die overeenkomt met de vereiste structuur ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidelayouttype/)). Als zo’n lay-out ontbreekt, kunt u [add it to the master](/slides/nl/python-java/slide-layout/) toevoegen aan de master en deze vervolgens gebruiken.