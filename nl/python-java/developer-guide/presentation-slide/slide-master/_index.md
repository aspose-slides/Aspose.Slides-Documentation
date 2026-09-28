---
title: Beheer presentatieslide‑masters in Python via Java
linktitle: Dia‑master
type: docs
weight: 70
url: /nl/python-java/slide-master/
keywords:
- dia‑master
- masterdia
- PPT‑masterdia
- meerdere masterdia's
- masterdia's vergelijken
- achtergrond
- placeholder
- masterdia klonen
- masterdia kopiëren
- masterdia dupliceren
- ongebruikte masterdia
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer slide masters in Aspose.Slides voor Python via Java: toegang, bewerking, klonen, vergelijken en verwijderen van masterdia's in PowerPoint- en OpenDocument‑presentaties."
---
## **Overzicht**

Een **slide master** definieert gedeelde ontwerpeigenschappen voor een groep dia's. Het kan gemeenschappelijke vormen, logo's, achtergronden, tekststijlen, themainstellingen en voetteksteigenschappen bevatten. In PowerPoint is het bewerken van een slide master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides for Python via Java ondersteunt hetzelfde model. Een presentatie kan één of meer masterdia's bevatten, en elke masterdia kan meerdere layoutdia's bevatten. Normale dia's verwijzen meestal niet direct naar een masterdia. In plaats daarvan gebruikt een normale dia een layoutdia, en die layoutdia behoort tot een masterdia.

De hiërarchie is:

1. **Slide master** - definieert het gedeelde ontwerp en thema.  
1. **Layout slide** - definieert een specifieke rangschikking van placeholders en lay‑outformaten.  
1. **Normal slide** - bevat de daadwerkelijke presentatiewaarde en gebruikt één layout slide.

![De hiërarchie van masterdia's, layoutdia's en normale dia's](slide-master_2.jpg)

In Aspose.Slides wordt een slide master vertegenwoordigd door de [MasterSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/) klasse. Alle masterdia's in een presentatie zijn beschikbaar via de [Presentation.getMasters](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getMasters) collectie, die wordt weergegeven door [MasterSlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Wanneer dezelfde eigenschap op meer dan één niveau wordt gedefinieerd, wint het specifiekere niveau. Bijvoorbeeld, als een masterdia en een layoutdia beiden een achtergrond definiëren, gebruiken dia's die op die layout zijn gebaseerd de layout‑achtergrond. Voor meer informatie over layoutdia's, zie [Lay-outdia's toepassen of wijzigen](/slides/nl/python-java/slide-layout/).
{{% /alert %}}

## **Toegang tot Slide Masters**

In PowerPoint kun je de weergave Slide Master openen via **Beeld** > **Slide Master**.

![De Slide Master‑opdracht op het PowerPoint‑tabblad Beeld](slide-master_3.jpg)

In Aspose.Slides gebruik je de [Presentation.getMasters](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getMasters) collectie om masterdia's te benaderen:

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

Je kunt ook de masterdia ophalen die door een normale dia wordt gebruikt via de layout daarvan:

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

## **Wat een Slide Master Bevat**

Een masterdia is een object dat lijkt op een dia. Het erft van [BaseSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/), dus het biedt veel van dezelfde dia‑eigenschappen die normale en layoutdia's gebruiken. Master‑specifieke leden staan vermeld op de [MasterSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/) API‑pagina.

Veelgebruikte masterdia‑leden omvatten:

| Lid | Doel |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getBackground) | Stelt de achtergrond van de slide op meester‑niveau in. |
| [getShapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getShapes) | Slaat vormen op die op de master zijn geplaatst, zoals logo's, afbeeldingskaders en gedeelde tekst. |
| [getLayoutSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#getLayoutSlides) | Slaat de layoutdia's op die bij de master horen. |
| [getThemeManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#getThemeManager) | Biedt toegang tot de master‑thema‑API's. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Beheert kopteksten, voetteksten, datums en slidennummers voor de master en de onderliggende layouts. |
| [getDependingSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#getDependingSlides) | Retourneert normale dia's die via hun layouts van de master afhankelijk zijn. |

## **Afbeelding toevoegen aan een Slide Master**

Wanneer je een afbeelding toevoegt aan een masterdia, verschijnt deze op dia's die layouts van die master gebruiken. Dit is handig voor logo's, watermerken, decoratieve banden en andere herhaalde visuele elementen.

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

Voor meer informatie over afbeeldingskaders, zie [Afbeeldingskader](/slides/nl/python-java/picture-frame/).

## **Zichtbaarheid van Master‑graphics regelen**

Gebruik [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#setShowMasterShapes) om geërfde master‑graphics, zoals logo's of decoratieve vormen, te verbergen zonder ze van de master te verwijderen. Geef `False` door aan [Slide.setShowMasterShapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#setShowMasterShapes) op de dia die die graphics moet weglaten en houd `True` op dia's die ze wel moeten weergeven.

Het volgende zelfstandige voorbeeld creëert een blauwe decoratieve band op een master en twee dia's die dezelfde lege layout gebruiken. De band is zichtbaar op de eerste dia en verborgen op de tweede. Er is geen invoerpresentatie of afbeelding nodig.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het voorbeeld maakt gebruik van de **Blank** layout die bij een nieuwe presentatie wordt geleverd en verwijdert de oorspronkelijke placeholders van de eerste dia.

### **Kies de reikwijdte van de instelling**

Een normale dia gebruikt zijn master via [Slide.getLayoutSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getLayoutSlide) en [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#getMasterSlide). Het instellen van de eigenschap op een individuele dia beïnvloedt alleen die dia. Door `False` door te geven aan [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#setShowMasterShapes) verberg je master‑graphics voor alle dia's die die gedeelde layout gebruiken, zelfs als hun eigen instelling `True` is. Om graphics alleen op één dia te verbergen, wijzig je de dia‑eigenschap en laat je de gedeelde layout onaangetast.

De instelling wordt niet ondersteund als zichtbaarheid‑controle op de masterdia zelf. Op een master geeft [getShowMasterShapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#getShowMasterShapes) altijd `False` terug, en door `True` door te geven aan [setShowMasterShapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#setShowMasterShapes) wordt een exceptie opgegooid. Pas de methode toe op een normale dia of een layout.

### **Graphics onderscheiden van de achtergrond**

| Operatie | Effect |
| --- | --- |
| Master‑graphics verbergen | Regelt de zichtbaarheid van geërfde master‑vormen zonder ze te verwijderen of de eigen vormen van de dia te wijzigen. |
| Achtergrondvulling van de dia wijzigen | Wijzigt de achtergrondkleur, gradient of afbeelding. Master‑graphics zijn aparte vormen en kunnen zichtbaar blijven boven die achtergrond. Zie [Presentatie‑achtergrond](/slides/nl/python-java/presentation-background/). |
| Een vorm van de master verwijderen | Verwijdert de gedeelde bronvorm, zodat deze niet meer beschikbaar is voor enige dia die die master gebruikt. |

## **Werken met placeholders**

Placeholders worden normaal gedefinieerd op layoutdia's. De masterdia levert de gedeelde stijl en het thema waar deze layouts van erven, terwijl elke layout beslist welke placeholders beschikbaar zijn en waar ze geplaatst worden.

In PowerPoint zijn placeholder‑opdrachten beschikbaar in de Slide Master‑weergave.

![De Insert Placeholder‑opdracht in de PowerPoint Slide Master‑weergave](slide-master_5.png)

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

Je kunt ook placeholders op een masterdia opmaken die al bestaan. Het volgende voorbeeld vindt de titel‑placeholder en past een lineaire gradientvulling toe:

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

![Opgeformatteerde titel‑placeholder geërfd door normale dia's](slide-master_8.png)

Voor meer placeholder‑ en tekstopmaakopties, zie [Prompttekst instellen in placeholder](/slides/nl/python-java/manage-placeholder/) en [Tekstopmaak](/slides/nl/python-java/text-formatting/).

## **Achtergrond van een Slide Master wijzigen**

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

Voor gerelateerde onderwerpen, zie [Presentatie‑achtergrond](/slides/nl/python-java/presentation-background/) en [Presentatie‑thema](/slides/nl/python-java/presentation-theme/).

## **Een Slide Master klonen naar een andere presentatie**

Gebruik [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslidecollection/#addClone) om een masterdia te kopiëren naar een andere presentatie. De gekopieerde master kan vervolgens worden gebruikt door layouts en dia's in de bestemmingspresentatie.

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

Als je normale dia's samen met hun master wilt klonen, zie [Dia's klonen](/slides/nl/python-java/clone-slides/).

## **Meerdere Slide Masters toevoegen**

Een presentatie kan meerdere masterdia's bevatten. Dit is nuttig wanneer verschillende secties verschillende branding, paginacompositie of themainstellingen vereisen.

![PowerPoint‑opdrachten voor het invoegen en beheren van masterdia's](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaardslidemaster, geeft de kloon een andere achtergrond, maakt een layout onder die gekloonde master en voegt een nieuwe dia toe op basis van die layout:

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

## **Slide Masters vergelijken**

Masterdia's kunnen worden vergeleken met de [equals](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#equals) methode die wordt geërfd van [BaseSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/). De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Het vergelijkt geen unieke identifiers, zoals dia‑ID's, of dynamische placeholder‑waarden, zoals de huidige datum.

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

Voor meer informatie, zie [Dia's vergelijken in presentatie](/slides/nl/python-java/compare-slides/).

## **Slide Master‑weergave als standaardinstelling instellen**

Gebruik de [setLastView](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#setLastView) methode op [ViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint eerst opent. Het volgende voorbeeld opent de presentatie in Slide Master‑weergave:

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

Voor meer weergave‑instellingen, zie [Presentatie opslaan](/slides/nl/python-java/save-presentation/).

## **Ongebruikte masterdia's verwijderen**

Presentaties bevatten soms masterdia's die niet langer door enige normale dia worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik [removeUnused](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslidecollection/#removeUnused) om ongebruikte masters te verwijderen uit de [Presentation.getMasters](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getMasters) collectie:

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

Je kunt ook de low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/#removeUnusedMasterSlides) methode gebruiken:

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

## **Veelgestelde vragen**

**Wat is het verschil tussen een slide master en een layout slide?**

Een slide master definieert gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een layout slide behoort tot een masterdia en definieert een specifieke rangschikking van placeholders. Een normale dia gebruikt een layout slide, zodat hij zowel van de layout als van de master erft.

**Kan één presentatie meerdere slide masters bevatten?**

Ja. Een presentatie kan meerdere slide masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding nodig hebben.

**Moet ik placeholders toevoegen aan een masterdia of een layout slide?**

In de meeste gevallen voeg je placeholders toe aan layoutdia's. Plaats gedeelde visuele elementen en gedeelde opmaak op de masterdia, en zet de inhouds‑placeholders op de layouts die normale dia's zullen gebruiken.

**Kan ik een masterdia verwijderen die nog in gebruik is?**

Nee. Een masterdia met afhankelijke dia's kan niet veilig direct worden verwijderd. Verplaats die dia's eerst naar layouts onder een andere master, of gebruik een opruimingsmethode die alleen ongebruikte masters verwijdert.