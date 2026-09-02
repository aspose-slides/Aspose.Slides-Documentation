---
title: Beheer slide‑masters in presentaties met Python
linktitle: Slide‑master
type: docs
weight: 80
url: /nl/python-net/slide-master/
keywords:
- slide‑master
- master‑dia
- PPT‑master‑dia
- meerdere master‑dia's
- master‑dia's vergelijken
- achtergrond
- placeholder
- master‑dia klonen
- master‑dia kopiëren
- master‑dia dupliceren
- ongebruikte master‑dia
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer slide‑masters in Aspose.Slides voor Python via .NET: toegang, bewerken, klonen, vergelijken en verwijderen van master‑dia's in PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Een **slide master** definieert gedeelde ontwerpinstellingen voor een groep dia's. Het kan gemeenschappelijke vormen, logo's, achtergronden, tekstopmaken, themainstellingen en voettekstinstellingen bevatten. In PowerPoint is het bewerken van een slide master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides voor Python via .NET ondersteunt hetzelfde model. Een presentatie kan één of meer masterdia's bevatten, en elke masterdia kan meerdere layoutdia's bevatten. Normale dia's verwijzen meestal niet rechtstreeks naar een masterdia. In plaats daarvan gebruikt een normale dia een layoutdia, en die layoutdia behoort tot een masterdia.

De hiërarchie is:

1. **Slide master** – definieert het gedeelde ontwerp en thema.  
1. **Layout slide** – definieert een specifieke rangschikking van tijdelijke aanduidingen en opmaak op lay-outniveau.  
1. **Normal slide** – bevat de daadwerkelijke presentatiesinhoud en gebruikt één layoutdia.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

In Aspose.Slides wordt een slide master weergegeven door de [MasterSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslide/)‑klasse. Alle masterdia's in een presentatie zijn beschikbaar via de `Presentation.masters`‑collectie.

{{% alert color="info" title="Inheritance" %}}
Wanneer dezelfde eigenschap op meer dan één niveau is gedefinieerd, heeft het specifiekere niveau voorrang. Bijvoorbeeld, als een masterdia en een layoutdia beide een achtergrond definiëren, gebruiken dia's die gebaseerd zijn op die layout de achtergrond van de layout. Voor meer informatie over layoutdia's, zie [Apply or Change Slide Layouts](/slides/nl/python-net/slide-layout/).
{{% /alert %}}

## **Toegang tot slide masters**

In PowerPoint kun je de Slide Master‑weergave openen via **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

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

Je kunt ook de masterdia ophalen die door een normale dia wordt gebruikt via zijn layout:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Wat een slide master bevat**

Een masterdia is een object dat op een dia lijkt. Het erft gemeenschappelijk dia‑gedrag van de [BaseSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslide/)‑klasse, zodat het veel van dezelfde dia‑eigenschappen blootlegt die door normale en layoutdia's worden gebruikt. Master‑specifieke leden staan vermeld op de [MasterSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslide/)‑API‑pagina.

Veelgebruikte masterdia‑leden omvatten:

| Lid | Doel |
| --- | --- |
| `background` | Stelt de achtergrond op masterniveau in. |
| `shapes` | Bewaart vormen die op de master zijn geplaatst, zoals logo's, fotolijsten en gedeelde tekst. |
| `layout_slides` | Bewaart de layoutdia's die bij de master horen. |
| `theme_manager` | Biedt toegang tot de master‑thema‑API’s. |
| `header_footer_manager` | Regelt kop‑ en voetteksten, datums en dia‑nummers voor de master en de onderliggende layouts. |
| `get_depending_slides` | Retourneert normale dia's die via hun layouts afhankelijk zijn van de master. |

## **Een afbeelding aan een slide master toevoegen**

Wanneer je een afbeelding toevoegt aan een masterdia, verschijnt deze op dia’s die layouts van die master gebruiken. Dit is handig voor logo's, watermerken, decoratieve banden en andere herhalende visuele elementen.

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

Voor meer informatie over fotolijsten, zie [Picture Frame](/slides/nl/python-net/picture-frame/).

## **Werken met placeholders**

Placeholders worden normaal gedefinieerd op layoutdia's. De masterdia levert de gedeelde stijl en het thema die die layouts erven, terwijl elke layout bepaalt welke placeholders beschikbaar zijn en waar ze worden geplaatst.

In PowerPoint zijn placeholder‑opdrachten beschikbaar in de Slide Master‑weergave.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Om nieuwe placeholders toe te voegen met Aspose.Slides, werk je met de layoutdia die bij de master hoort:

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

Je kunt ook de vorm van bestaande placeholders op een masterdia opmaken. Het volgende voorbeeld zoekt de titel‑placeholder en past een lineaire gradient‑vulling toe:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Voor meer opties voor placeholders en tekstopmaak, zie [Set Prompt Text in Placeholder](/slides/nl/python-net/manage-placeholder/) en [Text Formatting](/slides/nl/python-net/text-formatting/).

## **Een slide master‑achtergrond wijzigen**

Een master‑achtergrond wordt geërfd door layouts en dia's die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste masterdia:

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

Voor gerelateerde onderwerpen, zie [Presentation Background](/slides/nl/python-net/presentation-background/) en [Presentation Theme](/slides/nl/python-net/presentation-theme/).

## **Een slide master naar een andere presentatie klonen**

Gebruik de `add_clone`‑methode op de [MasterSlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/)‑klasse om een masterdia te kopiëren naar een andere presentatie. De gekopieerde master kan vervolgens worden gebruikt door layouts en dia's in de doelpresentatie.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Als je ook normale dia's samen met hun master wilt klonen, zie [Clone Slides](/slides/nl/python-net/clone-slides/).

## **Meerdere slide masters toevoegen**

Een presentatie kan meerdere masterdia's bevatten. Dit is handig wanneer verschillende secties verschillende branding, paginastuctuur of themainstellingen vereisen.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaardmaster, geeft de kloon een andere achtergrond, haalt een lege layout onder die gekloonde master op, en voegt een nieuwe dia toe op basis van die layout:

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

## **Slide masters vergelijken**

Masterdia's kunnen worden vergeleken met de `equals`‑methode die is geërfd van de [BaseSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslide/)‑klasse. De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Het vergelijkt geen unieke identifiers, zoals dia‑ID's, of dynamische placeholder‑waarden, zoals de huidige datum.

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

Voor meer informatie, zie [Compare Presentation Slides](/slides/nl/python-net/compare-slides/).

## **Slide master‑weergave als standaardweergave instellen**

Gebruik de `last_view`‑eigenschap op de presentatie‑[ViewProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint als eerste opent. Het volgende voorbeeld opent de presentatie in Slide Master‑weergave:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Voor meer weergave‑instellingen, zie [Save Presentation](/slides/nl/python-net/save-presentation/).

## **Ongebruikte masterdia's verwijderen**

Presentaties bevatten soms masterdia's die niet meer door enige normale dia worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik `remove_unused` om ongebruikte masters uit de `masters`‑collectie te verwijderen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Je kunt ook de low‑code‑methode `remove_unused_master_slides` gebruiken van de [Compress](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/)‑klasse:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### Wat is het verschil tussen een slide master en een layout slide?

Een slide master definieert gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekstopmaken. Een layout slide behoort tot een masterdia en definieert een specifieke rangschikking van placeholders. Een normale dia gebruikt een layout slide, waardoor hij zowel van de layout als van de master erft.

### Kan een enkele presentatie meerdere slide masters bevatten?

Ja. Een presentatie kan meerdere slide masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding nodig hebben.

### Moet ik placeholders toevoegen aan een masterdia of aan een layout slide?

In de meeste gevallen voeg je placeholders toe aan layoutdia's. Plaats gedeelde visuele elementen en gedeelde opmaak op de masterdia en zet content‑placeholders op de layouts die normale dia's zullen gebruiken.

### Kan ik een masterdia verwijderen die nog in gebruik is?

Nee. Een masterdia die afhankelijke dia's heeft, kan niet veilig direct worden verwijderd. Verplaats die dia's eerst naar layouts onder een andere master, of gebruik een opruimmethode voor ongebruikte masters die alleen masters verwijdert die niet in gebruik zijn.