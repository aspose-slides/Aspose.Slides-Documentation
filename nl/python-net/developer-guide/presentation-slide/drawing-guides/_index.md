---
title: Beheer teken‑gidsen in presentaties in Python
linktitle: Teken‑gidsen
type: docs
weight: 85
url: /nl/python-net/drawing-guides/
keywords:
- teken‑gids
- horizontale gids
- verticale gids
- uitlijningsgids
- diaweergave
- master‑dia
- layout‑dia
- notitie‑master
- handout‑master
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Voeg horizontale en verticale teken‑gidsen toe, benader ze en wis ze in PowerPoint‑presentaties met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Teken‑gidsen zijn verstelbare horizontale en verticale lijnen die gebruikers helpen vormen consistent uit te lijnen tijdens het bewerken van een presentatie in PowerPoint. Ze zijn vooral nuttig wanneer een applicatie een presentatie genereert die later handmatig verfijnd wordt: de applicatie kan dezelfde uitlijningshulpmiddelen opslaan die auteurs moeten volgen bij het toevoegen of verplaatsen van inhoud.

Teken‑gidsen zijn hulpmiddelen bij het bewerken, geen dia‑inhoud. Ze verschijnen niet in een diavoorstelling of gerenderde uitvoer. Aspose.Slides for Python via .NET maakt ze beschikbaar via de [IDrawingGuidesCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/idrawingguidescollection/) interface. Een gids wordt vertegenwoordigd door [IDrawingGuide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/idrawingguide/) en heeft een oriëntatie, een positie en een kleur.

De positie wordt gemeten in points vanaf de linkerbovenhoek van de betreffende dia of master. Een verticale gids gebruikt een horizontale coördinaat, doorgaans tussen nul en de breedte van de dia. Een horizontale gids gebruikt een verticale coördinaat, doorgaans tussen nul en de hoogte van de dia.

## **Guides toevoegen aan de diaweergave**

Gebruik [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) om gidsen te beheren die worden weergegeven tijdens het bewerken van normale dia's. Roep [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/nl/python-net/aspose.slides/idrawingguidescollection/add/) aan met een [Orientation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/orientation/)‑waarde en een positie in points.

Het volgende voorbeeld voegt één verticale gids toe rechts van het midden van de dia en één horizontale gids eronder:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot teken‑gidsen**

De eigenschap [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/nl/python-net/aspose.slides/idrawingguidescollection/count/) en de indexer geven toegang tot bestaande gidsen. De eigenschappen [IDrawingGuide.orientation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/nl/python-net/aspose.slides/idrawingguide/position/) en [IDrawingGuide.color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/idrawingguide/color/) kunnen gelezen of gewijzigd worden.

Het volgende voorbeeld leest de gidsen van de diaweergave uit de presentatie die hierboven is aangemaakt:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Guides toevoegen aan master‑ en layout‑dia's**

Een master‑dia en elk van zijn layout‑dia's kunnen hun eigen collecties teken‑gidsen hebben. Gebruik [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasterslide/drawing_guides/) voor een master‑dia en [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ilayoutslide/drawing_guides/) voor een layout‑dia.

Het volgende voorbeeld voegt een verticale gids toe aan de eerste master‑dia en een horizontale gids aan de eerste layout‑dia:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Guides toevoegen aan notitie‑ en handout‑masters**

Notitie‑masters en handout‑masters ondersteunen eveneens teken‑gidsen. Gebruik [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasternotesslide/drawing_guides/) en [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) om hun collecties te benaderen. Als een presentatie geen van deze masters bevat, creëert [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) of [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) de standaard‑master en retourneert deze.

Het volgende voorbeeld voegt een horizontale gids toe aan een notitie‑master en een verticale gids aan een handout‑master:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Guides wissen**

Roep [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides/idrawingguidescollection/clear/) aan om elke gids uit een bepaalde collectie te verwijderen. Het wissen van één collectie heeft geen invloed op gidsen die in een andere scope zijn opgeslagen.

Het volgende voorbeeld wist de gidsen van de diaweergave en alle gidsen op master‑dia's, layout‑dia's, de notitie‑master en de handout‑master zonder ontbrekende masters aan te maken:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Worden teken‑gidsen getoond in een diavoorstelling of geëxporteerde afbeeldingen?**

Nee. Teken‑gidsen zijn uitlijningshulpmiddelen voor het bewerken en worden niet gerenderd als presentatiewijziging.

**Kan een teken‑gids direct toegevoegd worden aan een individuele normale dia?**

Gidsen voor normale‑dia‑bewerking worden opgeslagen in de dia‑weergave‑eigenschappen van de presentatie. Aparte gidscollecties zijn beschikbaar voor master‑dia's, layout‑dia's, notitie‑masters en handout‑masters.

**Welke eenheden worden gebruikt voor gidsposities?**

Posities worden opgegeven in points, waarbij 72 points gelijk zijn aan één inch. Verticale posities worden gemeten vanaf de linkerkant, horizontale posities vanaf de bovenkant.

**Verwijdert het wissen van teken‑gidsen vormen of wijzigt het de dia‑inhoud?**

Nee. De `clear`‑methode verwijdert alleen de gidsen in de geselecteerde collectie. Vormen en andere dia‑inhoud blijven ongewijzigd.