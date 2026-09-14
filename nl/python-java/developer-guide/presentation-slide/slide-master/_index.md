---
title: "Beheer presentatie slide‑masters in Python via Java"
linktitle: "Dia‑master"
type: docs
weight: 70
url: /nl/python-java/slide-master/
keywords:
- "dia‑master"
- "master‑dia"
- "PPT‑master‑dia"
- "meerdere master‑dia's"
- "master‑dia's vergelijken"
- achtergrond
- placeholder
- "master‑dia klonen"
- "master‑dia kopiëren"
- "master‑dia dupliceren"
- "ongebruikte master‑dia"
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer dia‑masters in Aspose.Slides voor Python via Java: toegang, bewerken, klonen, vergelijken en verwijderen van master‑dia's in PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Een **slide master** definieert gedeelde ontwerpinstellingen voor een groep dia's. Hij kan gemeenschappelijke vormen, logo's, achtergronden, tekststijlen, themainstellingen en voettekstinstellingen bevatten. In PowerPoint is het bewerken van een slide master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides for Python via Java ondersteunt hetzelfde model. Een presentatie kan één of meer masterdia's bevatten, en elke masterdia kan meerdere layoutdia's bevatten. Normale dia's verwijzen gewoonlijk niet rechtstreeks naar een masterdia. In plaats daarvan gebruikt een normale dia een layoutdia, en die layoutdia behoort tot een masterdia.

Hiërarchie:

1. **Slide master** – definieert het gedeelde ontwerp en thema.  
1. **Layout slide** – definieert een specifieke indeling van placeholders en layout‑niveau opmaak.  
1. **Normal slide** – bevat de feitelijke presentatiewaarde en gebruikt één layoutdia.

![De hiërarchie van masterdia's, layoutdia's en normale dia's](slide-master_2.jpg)

In Aspose.Slides wordt een slide master weergegeven door de [MasterSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/)‑klasse. Alle masterdia's in een presentatie zijn beschikbaar via de [Presentation.getMasters](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getMasters)‑collectie, die wordt vertegenwoordigd door [MasterSlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Wanneer dezelfde eigenschap op meer dan één niveau wordt gedefinieerd, wint het specifiekere niveau. Bijvoorbeeld, als een masterdia en een layoutdia beide een achtergrond definiëren, gebruiken dia's die op die layout zijn gebaseerd de layout‑achtergrond. Voor meer informatie over layoutdia's, zie [Apply or Change Slide Layouts](/slides/nl/python-java/slide-layout/).
{{% /alert %}}

## **Toegang tot slide masters**

In PowerPoint kun je de Slide Master‑weergave openen via **View** > **Slide Master**.

![De Slide Master‑opdracht op het PowerPoint‑tabblad View](slide-master_3.jpg)

In Aspose.Slides gebruik je de [Presentation.getMasters](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getMasters)‑collectie om masterdia's te benaderen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

Je kunt ook de masterdia ophalen die door een normale dia wordt gebruikt via zijn layout:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Wat een slide master bevat**

Een masterdia is een object dat op een dia lijkt. Het erft van [BaseSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/), waardoor het veel van dezelfde dia‑eigenschappen exposeert die worden gebruikt door normale en layoutdia's. Master‑specifieke leden staan opgesomd op de API‑pagina van [MasterSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/).

Veelgebruikte masterdia‑leden zijn onder andere:

| Lid | Doel |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getBackground) | Stelt de achtergrond van de master‑dia in. |
| [getShapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getShapes) | Bevat vormen die op de master zijn geplaatst, zoals logo's, afbeeldingskaders en gedeelde tekst. |
| [getLayoutSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#getLayoutSlides) | Bevat de layoutdia's die bij de master horen. |
| [getThemeManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#getThemeManager) | Biedt toegang tot de master‑thema‑API's. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Beheert kopteksten, voetteksten, datums en dia‑nummers voor de master en haar onderliggende layouts. |
| [getDependingSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#getDependingSlides) | Geeft de normale dia's terug die via hun layouts afhankelijk zijn van de master. |

## **Een afbeelding toevoegen aan een slide master**

Wanneer je een afbeelding toevoegt aan een masterdia, verschijnt deze op dia's die layouts van die master gebruiken. Dit is handig voor logo's, watermerken, decoratieve balken en andere herhaalde visuele elementen.

Het volgende voorbeeld voegt een logo toe aan de eerste masterdia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Voor meer informatie over afbeeldingskaders, zie [Picture Frame](/slides/nl/python-java/picture-frame/).

## **Werken met placeholders**

Placeholders worden normaal gedefinieerd op layoutdia's. De masterdia levert de gedeelde stijl en het thema waarvan die layouts erven, terwijl elke layout bepaalt welke placeholders beschikbaar zijn en waar ze geplaatst worden.

In PowerPoint zijn placeholder‑opdrachten beschikbaar in de Slide Master‑weergave.

![De opdracht Placeholder invoegen in de PowerPoint‑Slide‑Master‑weergave](slide-master_5.png)

Om nieuwe placeholders toe te voegen met Aspose.Slides, werk je met de layoutdia die bij de master hoort:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Je kunt ook placeholder‑vormen opmaken die al bestaan op een masterdia. Het volgende voorbeeld zoekt de titel‑placeholder en past een lineaire gradiëntvulling toe:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Opgemaakte titel‑placeholder geërfd door normale dia's](slide-master_8.png)

Voor meer opties omtrent placeholders en tekstopmaak, zie [Set Prompt Text in Placeholder](/slides/nl/python-java/manage-placeholder/) en [Text Formatting](/slides/nl/python-java/text-formatting/).

## **Achtergrond van een slide master wijzigen**

Een master‑achtergrond wordt geërfd door layouts en dia's die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste masterdia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Voor verwante onderwerpen, zie [Presentation Background](/slides/nl/python-java/presentation-background/) en [Presentation Theme](/slides/nl/python-java/presentation-theme/).

## **Een slide master klonen naar een andere presentatie**

Gebruik [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslidecollection/#addClone) om een masterdia te kopiëren naar een andere presentatie. De gekopieerde master kan vervolgens worden gebruikt door layouts en dia's in de doelsjabloon.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Als je normale dia's samen met hun master wilt klonen, zie [Clone Slides](/slides/nl/python-java/clone-slides/).

## **Meerdere slide masters toevoegen**

Een presentatie kan meerdere masterdia's bevatten. Dit is handig wanneer verschillende secties andere branding, paginastuctuur of themainstellingen vereisen.

![PowerPoint‑opdrachten voor het invoegen en beheren van masterdia's](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaard‑master, geeft de kloon een andere achtergrond, maakt een layout onder die gekloonde master aan en voegt een nieuwe dia toe gebaseerd op die layout:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Slide masters vergelijken**

Masterdia's kunnen worden vergeleken met de [equals](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#equals)‑methode die van [BaseSlide] is geërfd. De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Het vergelijkt niet de unieke identificatoren, zoals dia‑ID's, of dynamische placeholder‑waarden, zoals de huidige datum.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

Voor meer informatie, zie [Compare Presentation Slides](/slides/nl/python-java/compare-slides/).

## **Slide Master‑weergave instellen als standaardweergave**

Gebruik de [setLastView](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#setLastView)‑methode op [ViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint als eerste opent. Het volgende voorbeeld opent de presentatie in Slide Master‑weergave:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Voor meer weergave‑instellingen, zie [Save Presentation](/slides/nl/python-java/save-presentation/).

## **Ongebruikte masterdia's verwijderen**

Presentaties kunnen soms masterdia's bevatten die niet meer door enige normale dia worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik [removeUnused](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslidecollection/#removeUnused) om ongebruikte masters te verwijderen uit de [Presentation.getMasters](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getMasters)‑collectie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Je kunt ook de low‑code‑methode [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/#removeUnusedMasterSlides) gebruiken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Wat is het verschil tussen een slide master en een layout slide?**

Een slide master definieert gedeelde ontwerpeigenschappen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een layout slide behoort tot een master slide en definieert een specifieke indeling van placeholders. Een normale dia gebruikt een layout slide, waardoor hij van zowel de layout als de master erft.

**Kan één presentatie meerdere slide masters bevatten?**

Ja. Een presentatie kan meerdere slide masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding vereisen.

**Moet ik placeholders toevoegen aan een master slide of een layout slide?**

In de meeste gevallen voeg je placeholders toe aan layoutdia's. Plaats gedeelde visuele elementen en gedeelde opmaak op de master slide, en zet de inhouds‑placeholders op de layouts die de normale dia's gebruiken.

**Kan ik een master slide verwijderen die nog wordt gebruikt?**

Nee. Een master slide die afhankelijke dia's heeft kan niet direct veilig worden verwijderd. Verplaats die dia's eerst naar layouts onder een andere master, of gebruik een opruimingsmethode voor ongebruikte masters die alleen masters verwijdert die niet in gebruik zijn.