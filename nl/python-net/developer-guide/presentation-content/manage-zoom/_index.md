---
title: Zooms beheren in presentaties met Python
linktitle: Zoom
type: docs
weight: 60
url: /nl/python-net/manage-zoom/
keywords:
- zoom
- zoomframe
- dia-zoom
- sectie-zoom
- samenvatting-zoom
- zoom toevoegen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Maak en pas Zoom aan met Aspose.Slides voor Python via .NET - spring tussen secties, voeg miniaturen en overgangen toe in PPT-, PPTX- en ODP-presentaties."
---
## **Inleiding**

Zooms in PowerPoint stellen u in staat om naar specifieke dia's, secties en delen van een presentatie te springen en er weer vanaf te keren. Tijdens het presenteren kan deze mogelijkheid om snel door de inhoud te navigeren erg handig blijken. 

![overzicht](overview.png)

* Om een volledige presentatie op één dia samen te vatten, gebruik een [Samenvatting Zoom](#Summary-Zoom).
* Om alleen geselecteerde dia's weer te geven, gebruik een [Dia Zoom](#Slide-Zoom).
* Om slechts één sectie weer te geven, gebruik een [Sectie Zoom](#Section-Zoom).

## **Dia Zoom**

Een dia‑zoom kan uw presentatie dynamischer maken door u vrij te laten navigeren tussen dia's in elke volgorde die u kiest, zonder de flow van uw presentatie te onderbreken. Dia‑zooms zijn geweldig voor korte presentaties zonder veel secties, maar u kunt ze ook in andere presentatiescenario’s gebruiken.

Dia‑zooms helpen u meerdere informatie‑stukken te verkennen terwijl u het gevoel heeft op één enkel canvas te werken. 

![slidezoomsel](slidezoomsel.png)

Voor dia‑zoomobjecten biedt Aspose.Slides de enumeratie [ZoomImageType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/zoomimagetype/), de klasse [ZoomFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/zoomframe/) en een aantal methoden in de klasse [ShapeCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/).

### **Zoom‑frames maken**
U kunt op de volgende manier een zoom‑frame aan een dia toevoegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Maak nieuwe dia’s aan waarnaar u wilt linken. 
3. Voeg een identificatietekst en achtergrond toe aan de gemaakte dia’s.
4. Voeg zoom‑frames (met de verwijzingen naar de gemaakte dia’s) toe aan de eerste dia.
5. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze voorbeeldcode toont hoe u een zoom‑frame in een dia maakt:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Voeg nieuwe dia's toe aan de presentatie
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Maak een achtergrond voor de tweede dia
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Maak een tekstvak voor de tweede dia
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Maak een achtergrond voor de derde dia
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Maak een tekstvak voor de derde dia
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Voeg ZoomFrame-objecten toe
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Sla de presentatie op
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Zoom‑frames maken met aangepaste afbeeldingen**
Met Aspose.Slides for Python via .NET kunt u op de volgende manier een zoom‑frame maken met een andere afbeelding dan de dia‑voorbeeldafbeelding: 
1. Maak een instantie van de `Presentation`‑klasse.
2. Maak een nieuwe dia aan waarnaar u wilt linken. 
3. Voeg een identificatietekst en achtergrond toe aan de gemaakte dia.
4. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/)‑object door een afbeelding toe te voegen aan de Images‑collectie van het Presentation‑object die wordt gebruikt om het frame te vullen.
5. Voeg zoom‑frames (met de verwijzing naar de gemaakte dia) toe aan de eerste dia.
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze python‑code toont hoe u een zoom‑frame maakt met een andere afbeelding:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Voeg een nieuwe dia toe aan de presentatie
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Maak een achtergrond voor de tweede dia
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Maak een tekstvak voor de derde dia
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Maak een nieuwe afbeelding voor het zoom-object
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Voeg het ZoomFrame-object toe
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Sla de presentatie op
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Zoom‑frames opmaken**
In de voorgaande secties (hierboven) hebben we u laten zien hoe u eenvoudige zoom‑frames maakt. Om meer gecompliceerde zoom‑frames te maken, moet u de opmaak van de frames wijzigen. Er zijn verschillende opmaakinstellingen die u op een zoom‑frame kunt toepassen. 

U kunt de opmaak van een zoom‑frame in een dia op de volgende manier beheren:

1. Maak een instantie van de `Presentation`‑klasse.
2. Maak nieuwe dia’s om naar te linken.
3. Voeg identificatietekst en achtergrond toe aan de gemaakte dia’s.
4. Voeg zoom‑frames (met de verwijzingen naar de gemaakte dia’s) toe aan de eerste dia.
5. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/)‑object door een afbeelding toe te voegen aan de Images‑collectie van het Presentation‑object die wordt gebruikt om het frame te vullen.
6. Stel een aangepaste afbeelding in voor het eerste zoom‑frame‑object.
7. Wijzig de lijnopmaak voor het tweede zoom‑frame‑object.
8. Verwijder de achtergrond van een afbeelding van het tweede zoom‑frame‑object.
5. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze python‑voorbeeldcode toont hoe u de opmaak van een zoom‑frame wijzigt: 

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Voeg nieuwe dia's toe aan de presentatie
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Maak een achtergrond voor de tweede dia
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Maak een tekstvak voor de tweede dia
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Maak een achtergrond voor de derde dia
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Maak een tekstvak voor de derde dia
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Voeg ZoomFrame-objecten toe
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Maak een nieuwe afbeelding voor het zoom-object
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Stel aangepaste afbeelding in voor zoomFrame1-object
    zoomFrame1.image = image

    # Stel een zoomframe-opmaak in voor zoomFrame2-object
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Toon geen achtergrond voor zoomFrame2-object
    zoomFrame2.show_background = False

    # Sla de presentatie op
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Sectie Zoom**

Een sectie‑zoom is een koppeling naar een sectie in uw presentatie. U kunt sectie‑zooms gebruiken om terug te gaan naar secties die u echt wilt benadrukken. Of u kunt ze gebruiken om te laten zien hoe bepaalde delen van uw presentatie met elkaar verbonden zijn. 

![seczoomsel](seczoomsel.png)

Voor sectie‑zoomobjecten biedt Aspose.Slides de klasse [SectionZoomFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sectionzoomframe/) en enkele methoden onder de klasse [ShapeCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/).

### **Sectie‑zoom‑frames maken**

U kunt op de volgende manier een sectie‑zoom‑frame aan een dia toevoegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Maak een nieuwe dia. 
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waarnaar u het zoom‑frame wilt linken. 
5. Voeg een sectie‑zoom‑frame (met verwijzingen naar de gemaakte sectie) toe aan de eerste dia.
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze python‑code toont hoe u een zoom‑frame op een dia maakt:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Voegt een nieuwe dia toe aan de presentatie
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Voegt een nieuwe sectie toe aan de presentatie
    pres.sections.add_section("Section 1", slide)

    # Voegt een SectionZoomFrame-object toe
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Slaat de presentatie op
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Sectie‑zoom‑frames maken met aangepaste afbeeldingen**

Met Aspose.Slides for Python kunt u op de volgende manier een sectie‑zoom‑frame maken met een andere dia‑voorbeeldafbeelding: 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Maak een nieuwe dia.
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waarnaar u het zoom‑frame wilt linken. 
5. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/)‑object door een afbeelding toe te voegen aan de Images‑collectie van het [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑object die wordt gebruikt om het frame te vullen.
6. Voeg een sectie‑zoom‑frame (met een verwijzing naar de gemaakte sectie) toe aan de eerste dia.
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze python‑code toont hoe u een zoom‑frame maakt met een andere afbeelding:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Voegt een nieuwe dia toe aan de presentatie
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Voegt een nieuwe sectie toe aan de presentatie
    pres.sections.add_section("Section 1", slide)

    # Maakt een nieuwe afbeelding voor het zoom-object
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Voegt een SectionZoomFrame-object toe
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Slaat de presentatie op
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Sectie‑zoom‑frames opmaken**

Om meer gecompliceerde sectie‑zoom‑frames te maken, moet u de opmaak van een eenvoudig frame wijzigen. Er zijn verschillende opmaakopties die u op een sectie‑zoom‑frame kunt toepassen. 

U kunt de opmaak van een sectie‑zoom‑frame op een dia op de volgende manier beheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Maak een nieuwe dia.
3. Voeg identificatie‑achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waarnaar u het zoom‑frame wilt linken. 
5. Voeg een sectie‑zoom‑frame (met verwijzingen naar de gemaakte sectie) toe aan de eerste dia.
6. Wijzig de grootte en positie van het gemaakte sectie‑zoom‑object.
7. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/)‑object door een afbeelding toe te voegen aan de Images‑collectie van het [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑object die wordt gebruikt om het frame te vullen.
8. Stel een aangepaste afbeelding in voor het gemaakte sectie‑zoom‑frame‑object.
9. Stel de *terugkeer naar de oorspronkelijke dia vanuit de gekoppelde sectie* in.
10. Verwijder de achtergrond van een afbeelding van het sectie‑zoom‑frame‑object.
11. Wijzig de lijnopmaak voor het tweede zoom‑frame‑object.
12. Wijzig de overgangsduur.
13. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze python‑code toont hoe u de opmaak van een sectie‑zoom‑frame wijzigt:

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Voegt een nieuwe dia toe aan de presentatie
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Voegt een nieuwe sectie toe aan de presentatie
    pres.sections.add_section("Section 1", slide)

    # Voeg SectionZoomFrame-object toe
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Opmaak voor SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Slaat de presentatie op
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Samenvatting Zoom**

Een samenvatting‑zoom is als een landingspagina waarop alle onderdelen van uw presentatie tegelijk worden weergegeven. Tijdens het presenteren kunt u de zoom gebruiken om van de ene naar de andere plaats in uw presentatie te gaan, in elke gewenste volgorde. U kunt creatief zijn, vooruit springen of delen van uw diavoorstelling opnieuw bezoeken zonder de stroom van uw presentatie te onderbreken.

![summaryzoom](summaryzoom.png)

Voor samenvatting‑zoomobjecten biedt Aspose.Slides de klasse [SummaryZoomFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/summaryzoomsection/) en [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/summaryzoomsectioncollection/) en een aantal methoden onder de klasse [ShapeCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/).

### **Samenvatting‑zoom maken**

U kunt op de volgende manier een samenvatting‑zoom‑frame aan een dia toevoegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de gemaakte dia’s.
3. Voeg het samenvatting‑zoom‑frame toe aan de eerste dia.
4. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze python‑code toont hoe u een samenvatting‑zoom‑frame op een dia maakt:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Maak een array van dia's
    for slideNumber in range(5):
        #Voeg nieuwe dia's toe aan de presentatie
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Maak een achtergrond voor de dia
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Maak een tekstvak voor de dia
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Maak zoomobjecten voor alle dia's in de eerste dia
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Stel de ReturnToParent‑eigenschap in om terug te keren naar de eerste dia
        zoomFrame.return_to_parent = True

    # Sla de presentatie op
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **Samenvatting‑zoom‑secties toevoegen en verwijderen**

Alle secties in een samenvatting‑zoom‑frame worden vertegenwoordigd door [SummaryZoomSection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/summaryzoomsection/)-objecten, die worden opgeslagen in het [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/summaryzoomsectioncollection/)-object. U kunt een samenvatting‑zoom‑sectie‑object toevoegen of verwijderen via de [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/summaryzoomsectioncollection/)-klasse op de volgende manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de gemaakte dia’s.
3. Voeg een samenvatting‑zoom‑frame toe aan de eerste dia.
4. Voeg een nieuwe dia en sectie toe aan de presentatie.
5. Voeg de gemaakte sectie toe aan het samenvatting‑zoom‑frame.
6. Verwijder de eerste sectie uit het samenvatting‑zoom‑frame.
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze python‑code toont hoe u secties toevoegt en verwijdert in een samenvatting‑zoom‑frame:

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Voegt een nieuwe dia toe aan de presentatie
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Voegt een nieuwe sectie toe aan de presentatie
    pres.sections.add_section("Section 1", slide)

    #Voegt een nieuwe dia toe aan de presentatie
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Voegt een nieuwe sectie toe aan de presentatie
    pres.sections.add_section("Section 2", slide)

    # Voegt SummaryZoomFrame-object toe
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Voegt een nieuwe dia toe aan de presentatie
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Voegt een nieuwe sectie toe aan de presentatie
    section3 = pres.sections.add_section("Section 3", slide)

    # Voegt een sectie toe aan de Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Verwijdert sectie uit de Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Slaat de presentatie op
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Samenvatting‑zoom‑secties opmaken**

Om meer gecompliceerde samenvatting‑zoom‑sectie‑objecten te maken, moet u de opmaak van een eenvoudig frame wijzigen. Er zijn verschillende opmaakopties die u op een samenvatting‑zoom‑sectie‑object kunt toepassen. 

U kunt de opmaak van een samenvatting‑zoom‑sectie‑object in een samenvatting‑zoom‑frame op de volgende manier beheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de gemaakte dia’s.
3. Voeg een samenvatting‑zoom‑frame toe aan de eerste dia.
4. Haal een samenvatting‑zoom‑sectie‑object op voor het eerste object uit de `SummaryZoomSectionCollection`.
5. Maak een `PPImage`‑object door een afbeelding toe te voegen aan de images‑collectie van het [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑object die wordt gebruikt om het frame te vullen.
6. Stel een aangepaste afbeelding in voor het gemaakte sectie‑zoom‑frame‑object.
7. Stel de *terugkeer naar de oorspronkelijke dia vanuit de gekoppelde sectie* in. 
8. Wijzig de lijnopmaak voor het tweede zoom‑frame‑object.
9. Wijzig de overgangsduur.
10. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze python‑code toont hoe u de opmaak van een samenvatting‑zoom‑sectie‑object wijzigt:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Voegt een nieuwe dia toe aan de presentatie
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Voegt een nieuwe sectie toe aan de presentatie
    pres.sections.add_section("Section 1", slide)

    #Voegt een nieuwe dia toe aan de presentatie
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Voegt een nieuwe sectie toe aan de presentatie
    pres.sections.add_section("Section 2", slide)

    # Voegt een SummaryZoomFrame-object toe
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Haalt het eerste SummaryZoomSection-object op
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Opmaak voor SummaryZoomSection-object
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Slaat de presentatie op
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik de terugkeer naar de ‘ouder’-dia regelen nadat het doel is getoond?**

Ja. Het [Zoom frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/zoomframe/) of de [sectie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sectionzoomframe/) heeft een `return_to_parent`‑gedrag dat, wanneer ingeschakeld, kijkers terugstuurt naar de oorspronkelijke dia nadat ze de doelinhoud hebben bezocht.

**Kan ik de ‘snelheid’ of duur van de Zoom‑overgang aanpassen?**

Ja. Zoom ondersteunt het instellen van een `transition_duration` zodat u kunt bepalen hoe lang de sprong‑animatie duurt.

**Zijn er limieten voor het aantal Zoom‑objecten dat een presentatie kan bevatten?**

Er is geen harde API‑limiet gedocumenteerd. Praktische limieten hangen af van de algehele complexiteit van de presentatie en de prestaties van de viewer. U kunt veel Zoom‑frames toevoegen, maar houd rekening met de bestandsomvang en render‑tijd.