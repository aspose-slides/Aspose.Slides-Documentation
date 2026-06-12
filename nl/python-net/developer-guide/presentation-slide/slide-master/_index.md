---
title: "Beheer Dia‑masters van Presentatie in Python"
linktitle: "Dia‑master"
type: docs
weight: 80
url: /nl/python-net/slide-master/
keywords:
- "dia‑master"
- "masterdia"
- "PPT‑masterdia"
- "meerdere masterdia's"
- "masterdia's vergelijken"
- "achtergrond"
- "tijdelijke aanduiding"
- "masterdia klonen"
- "masterdia kopiëren"
- "masterdia dupliceren"
- "ongebruikte masterdia"
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer dia‑masters in Aspose.Slides voor Python via .NET: toegang, bewerken, klonen, vergelijken en verwijderen van masterdia's in PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Een **slide‑master** definieert gedeelde ontwerpen voor een groep dia's. Hij kan gemeenschappelijke vormen, logo's, achtergronden, tekststijlen, themainstellingen en voettekstinstellingen bevatten. In PowerPoint is het bewerken van een slide‑master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides for Python via .NET ondersteunt hetzelfde model. Een presentatie kan één of meer masterdia's bevatten, en elke masterdia kan meerdere lay-outdia's bevatten. Normale dia's verwijzen meestal niet rechtstreeks naar een masterdia. In plaats daarvan gebruikt een normale dia een lay-outdia, en die lay-outdia behoort tot een masterdia.

De hiërarchie is:

1. **Slide master** – definieert het gedeelde ontwerp en thema.  
1. **Layout slide** – definieert een specifieke plaatsing van tijdelijke aanduidingen en opmaak op lay-outniveau.  
1. **Normal slide** – bevat de feitelijke presentatiewaarde en gebruikt één lay-outdia.

![De hiërarchie van masterdia's, lay-outdia's en normale dia's](slide-master_2.jpg)

In Aspose.Slides wordt een slide‑master voorgesteld door de [MasterSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslide/)‑klasse. Alle masterdia's in een presentatie zijn beschikbaar via de `Presentation.masters`‑collectie.

{{% alert color="info" title="Erfenis" %}}

Wanneer dezelfde eigenschap op meer dan één niveau is gedefinieerd, heeft het specifiekere niveau voorrang. Bijvoorbeeld, als een masterdia en een lay-outdia beide een achtergrond definiëren, gebruiken dia's die op die lay-out zijn gebaseerd de lay-out‑achtergrond. Voor meer informatie over lay-outdia's, zie [Apply or Change Slide Layouts](/python-net/slide-layout/).

{{% /alert %}}

## **Slide‑masters benaderen**

In PowerPoint kun je de weergave Slide‑master openen via **Beeld** > **Slide‑master**.

![De Slide‑master‑opdracht op het PowerPoint‑tabblad Beeld](slide-master_3.jpg)

In Aspose.Slides gebruik je de `masters`‑collectie om masterdia's te benaderen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Je kunt ook de masterdia ophalen die door een normale dia wordt gebruikt via zijn lay-out:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Wat een slide‑master bevat**

Een masterdia is een object dat op een dia lijkt. Hij erft algemeen dia‑gedrag van de [BaseSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslide/)‑klasse, waardoor hij veel van dezelfde dia‑eigenschappen beschikbaar stelt als normale en lay-outdia's. Master‑specifieke leden staan vermeld op de [MasterSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslide/)‑API‑pagina.

Veelgebruikte masterdia‑leden zijn onder andere:

| Lid | Doel |
| --- | --- |
| `background` | Stelt de achtergrond op master‑niveau in. |
| `shapes` | Opslag voor vormen die op de master zijn geplaatst, zoals logo's, afbeeldingkaders en gedeelde tekst. |
| `layout_slides` | Opslag voor de lay-outdia's die bij de master horen. |
| `theme_manager` | Biedt toegang tot de master‑thema‑API's. |
| `header_footer_manager` | Beheert kopteksten, voetteksten, datums en dia‑nummers voor de master en diens onderliggende lay-outs. |
| `get_depending_slides` | Geeft normale dia's terug die via hun lay-outs afhankelijk zijn van de master. |

## **Een afbeelding toevoegen aan een slide‑master**

Wanneer je een afbeelding toevoegt aan een masterdia, verschijnt deze op dia's die lay-outs van die master gebruiken. Dit is handig voor logo's, watermerken, decoratieve strepen en andere herhaalde visuele elementen.

Het volgende voorbeeld voegt een logo toe aan de eerste masterdia:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

Voor meer informatie over afbeeldingkaders, zie [Picture Frame](/python-net/picture-frame/).

## **Werken met tijdelijke aanduidingen**

Tijdelijke aanduidingen worden normaal gesproken op lay-outdia's gedefinieerd. De masterdia biedt de gedeelde stijl en het thema die die lay-outs erven, terwijl elke lay-out beslist welke tijdelijke aanduidingen beschikbaar zijn en waar ze geplaatst worden.

In PowerPoint zijn de tijdelijke‑aanduidingsopdrachten beschikbaar in de Slide‑master‑weergave.

![De opdracht Tijdelijke aanduiding invoegen in PowerPoint‑Slide‑master‑weergave](slide-master_5.png)

Om nieuwe tijdelijke aanduidingen toe te voegen met Aspose.Slides, werk je met de lay-outdia die bij de master hoort:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

Je kunt ook de vorm van een bestaande tijdelijke aanduiding op een masterdia opmaken. Het volgende voorbeeld zoekt de titel‑tijdelijke aanduiding en past een lineaire gradiëntvulling toe:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Opgeformatteerde titel‑tijdelijke aanduiding die door normale dia's wordt geërfd](slide-master_8.png)

Voor meer opties rondom tijdelijke aanduidingen en tekstopmaak, zie [Set Prompt Text in Placeholder](/python-net/manage-placeholder/) en [Text Formatting](/python-net/text-formatting/).

## **Achtergrond van een slide‑master wijzigen**

Een master‑achtergrond wordt geërfd door lay-outs en dia's die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste masterdia:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

Voor gerelateerde onderwerpen, zie [Presentation Background](/python-net/presentation-background/) en [Presentation Theme](/python-net/presentation-theme/).

## **Een slide‑master klonen naar een andere presentatie**

Gebruik de `add_clone`‑methode op de [MasterSlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/)‑klasse om een masterdia naar een andere presentatie te kopiëren. De gekopieerde master kan vervolgens door lay-outs en dia's in de doelpresentatie worden gebruikt.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Als je normale dia's wilt klonen samen met hun master, zie [Clone Slides](/python-net/clone-slides/).

## **Meerdere slide‑masters toevoegen**

Een presentatie kan meerdere masterdia's bevatten. Dit is handig wanneer verschillende secties verschillende branding, paginavormgeving of themainstellingen vereisen.

![PowerPoint‑opdrachten voor het invoegen en beheren van masterdia's](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaardmaster, geeft het kloon een andere achtergrond, haalt een lege lay-out onder die gekloonde master op, en voegt een nieuwe dia toe op basis van die lay-out:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Slide‑masters vergelijken**

Masterdia's kunnen worden vergeleken met de `equals`‑methode die ze erven van de [BaseSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslide/)‑klasse. De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Unieke identifiers, zoals dia‑ID's, of dynamische tijdelijke‑aanduidingswaarden, zoals de huidige datum, worden niet vergeleken.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

Voor meer informatie, zie [Compare Presentation Slides](/python-net/compare-slides/).

## **Slide‑master‑weergave instellen als standaardweergave**

Gebruik de `last_view`‑eigenschap op de presentatie‑[ViewProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/) om te bepalen welke weergave PowerPoint als eerste opent. Het volgende voorbeeld opent de presentatie in Slide‑master‑weergave:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Voor meer weergave‑instellingen, zie [Save Presentation](/python-net/save-presentation/).

## **Ongebruikte masterdia's verwijderen**

Presentaties kunnen soms masterdia's bevatten die door geen enkele normale dia meer worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik `remove_unused` om ongebruikte masters uit de `masters`‑collectie te verwijderen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Je kunt ook de low‑code‑methode `remove_unused_master_slides` van de [Compress](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/)‑klasse gebruiken:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wat is het verschil tussen een slide‑master en een lay-outdia?**

Een slide‑master definieert gedeelde ontwerp‑instellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een lay‑outdia behoort tot een masterdia en definieert een specifieke plaatsing van tijdelijke aanduidingen. Een normale dia gebruikt een lay‑outdia, waardoor hij zowel van de lay‑out als van de master erft.

**Kan één presentatie meerdere slide‑masters bevatten?**

Ja. Een presentatie kan meerdere slide‑masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding nodig hebben.

**Moet ik tijdelijke aanduidingen toevoegen aan een masterdia of aan een lay‑outdia?**

In de meeste gevallen voeg je tijdelijke aanduidingen toe aan lay‑outdia's. Plaats gedeelde visuele elementen en gedeelde opmaak op de masterdia, en zet de inhoud‑tijdelijke aanduidingen op de lay‑outs die normale dia's zullen gebruiken.

**Kan ik een masterdia verwijderen die nog in gebruik is?**

Nee. Een masterdia met afhankelijke dia's kan niet veilig direct worden verwijderd. Verplaats eerst die dia's naar lay‑outs onder een andere master, of gebruik een opruim‑methode die alleen masters verwijdert die niet meer worden gebruikt.