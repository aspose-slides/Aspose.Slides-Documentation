---
title: Dia's van een presentatie klonen in Python
linktitle: Dia's klonen
type: docs
weight: 35
url: /nl/python-java/clone-slides/
keywords:
- dia klonen
- dia kopiëren
- dia opslaan
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Dupliceer snel PowerPoint-dia's met Aspose.Slides voor Python via Java. Volg onze duidelijke codevoorbeelden om het maken van PPT's in enkele seconden te automatiseren en handmatig werk te elimineren."
---
## **Inleiding**

Klonen is het proces van het maken van een exacte kopie of replica van iets. Aspose.Slides voor Python via Java maakt het ook mogelijk om een kopie of kloon van een willekeurige dia te maken en die gekloonde dia vervolgens in de huidige presentatie of een andere geopende presentatie in te voegen. Het proces van dia‑klonen creëert een nieuwe dia die door ontwikkelaars kan worden aangepast zonder de oorspronkelijke dia te wijzigen. Er zijn verschillende mogelijke manieren om een dia te klonen:

- Kloon aan het einde binnen een presentatie.
- Kloon op een andere positie binnen een presentatie.
- Kloon aan het einde in een andere presentatie.
- Kloon op een andere positie in een andere presentatie.
- Kloon samen met zijn masterslide naar een andere presentatie.

In Aspose.Slides voor Python via Java biedt de dia‑collectie (een verzameling van [Slide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/)‑objecten) die door het [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object wordt blootgesteld, de methoden [addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addClone) en [insertClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#insertClone) om de hierboven genoemde soorten dia‑klonen uit te voeren.

## **Kloon een dia aan het einde van een presentatie**

Als je een dia wilt klonen en deze vervolgens binnen hetzelfde presentatiedocument aan het einde van de bestaande dia's wilt gebruiken, gebruik dan de [addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addClone)‑methode volgens de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse aan.
2. Haal het [SlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/)‑object op door te refereren naar de Slides‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object wordt blootgesteld.
3. Roep de [addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addClone)‑methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/)‑object wordt blootgesteld en geef de te klonen dia als parameter mee aan de [addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addClone)‑methode.
4. Schrijf het gewijzigde presentatiedocument weg.

In het onderstaande voorbeeld hebben we een dia gekloond (bevindt zich op de eerste positie – index nul – van de presentatie) naar het einde van de presentatie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Kloon de gewenste dia naar het einde van de collectie dia's in dezelfde presentatie
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Schrijf de gewijzigde presentatie naar schijf
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kloon een dia naar een andere positie binnen een presentatie**

Als je een dia wilt klonen en deze vervolgens binnen hetzelfde presentatiedocument maar op een andere positie wilt gebruiken, gebruik dan de [insertClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#insertClone)‑methode:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse aan.
2. Haal een referentie op naar de dia‑collectie die wordt geretourneerd door [getSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlides) op het [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object.
3. Roep de [insertClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#insertClone)‑methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/)‑object wordt blootgesteld en geef de te klonen dia samen met de index voor de nieuwe positie als parameter mee aan de [insertClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#insertClone)‑methode.
4. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een dia gekloond (bevindt zich op index 1 – positie 2 – van de presentatie) naar index 2 – positie 3 – van de presentatie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Haal de collectie dia's op in de presentatie
    slides = presentation.getSlides()

    # Kloon de gewenste dia naar de opgegeven index in dezelfde presentatie
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Schrijf de gewijzigde presentatie naar schijf
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kloon een dia aan het einde van een andere presentatie**

Als je een dia uit één presentatie moet klonen en deze in een andere presentatiedocument wilt gebruiken, aan het einde van de bestaande dia's:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse aan die de presentatie bevat waarvan de dia zal worden gekloond.
2. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse aan die de bestemmingspresentatie bevat waaraan de dia zal worden toegevoegd.
3. Haal het [SlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/)‑object op door te refereren naar de dia‑collectie die wordt geretourneerd door [getSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlides) op het [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object van de bestemmingspresentatie.
4. Roep de [addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addClone)‑methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/)‑object wordt blootgesteld en geef de dia uit de bronpresentatie als parameter mee aan de [addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addClone)‑methode.
5. Schrijf het gewijzigde bestemmingspresentatiedocument weg.

In het onderstaande voorbeeld hebben we een dia gekloond (van index 0 van de bronpresentatie) naar het einde van de bestemmingspresentatie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantie van de Presentation-klasse om het bronpresentatiebestand te laden
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instantie van de Presentation-klasse voor de bestemmings-PPTX (waar de dia moet worden gekloond)
    destination_presentation = Presentation()
    try:
        # Kloon de gewenste dia van de bronpresentatie naar het einde van de collectie dia's in de bestemmingspresentatie
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Schrijf de bestemmingspresentatie naar schijf
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Kloon een dia naar een andere positie in een andere presentatie**

Als je een dia uit één presentatie moet klonen en deze in een ander presentatiedocument op een specifieke positie wilt gebruiken:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse aan die de bronpresentatie bevat waarvan de dia zal worden gekloond.
2. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse aan die de presentatie bevat waaraan de dia zal worden toegevoegd.
3. Haal het [SlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/)‑object op door te refereren naar de Slides‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object van de bestemmingspresentatie wordt blootgesteld.
4. Roep de [insertClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#insertClone)‑methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/)‑object wordt blootgesteld en geef de dia uit de bronpresentatie samen met de gewenste positie als parameter mee aan de [insertClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#insertClone)‑methode.
5. Schrijf het gewijzigde bestemmingspresentatiedocument weg.

In het onderstaande voorbeeld hebben we een dia gekloond (van index nul van de bronpresentatie) naar index 1 (positie 2) van de bestemmingspresentatie.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantie van de Presentation-klasse om het bronpresentatiebestand te laden
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instantie van de Presentation-klasse voor de bestemmings‑PPTX (waar de dia moet worden gekloond)
    destination_presentation = Presentation()
    try:
        # Kloon de gewenste dia van de bronpresentatie naar de opgegeven index in de bestemmingspresentatie
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Schrijf de bestemmingspresentatie naar schijf
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Kloon een dia met zijn masterslide naar een andere presentatie**

Als je een dia met een masterslide uit één presentatie moet klonen en in een andere presentatie wilt gebruiken, moet je eerst de gewenste masterslide van de bronpresentatie naar de bestemmingspresentatie klonen. Gebruik daarna de gekloonde masterslide bij het klonen van de dia. De [addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addClone)‑methode verwacht een masterslide uit de bestemmingspresentatie in plaats van uit de bronpresentatie. Volg de onderstaande stappen om de dia met een master te klonen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse aan die de bronpresentatie bevat waarvan de dia zal worden gekloond.
2. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse aan die de bestemmingspresentatie bevat waarnaar de dia zal worden gekloond.
3. Toegang krijgen tot de te klonen dia samen met de masterslide.
4. Haal het [MasterSlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslidecollection/)‑object op door te refereren naar de Masters‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object van de bestemmingspresentatie wordt blootgesteld.
5. Roep de [addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslidecollection/#addClone)‑methode aan die door het [MasterSlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslidecollection/)‑object wordt blootgesteld en geef de master uit de bron‑PPTX die gekloond moet worden als parameter mee aan de [addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslidecollection/#addClone)‑methode.
6. Haal het [SlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/)‑object op door te refereren naar de Slides‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object van de bestemmingspresentatie wordt blootgesteld.
7. Roep de [addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addClone)‑methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/)‑object wordt blootgesteld en geef de dia uit de bronpresentatie die gekloond moet worden en de masterslide als parameters mee aan de [addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addClone)‑methode.
8. Schrijf het gewijzigde bestemmingspresentatiedocument weg.

In het onderstaande voorbeeld hebben we een dia gekloond met een master (bevindt zich op index nul van de bronpresentatie) naar het einde van de bestemmingspresentatie met gebruik van de master van de bron‑dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instantie van de Presentation-klasse om het bronpresentatiebestand te laden
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Instantie van de Presentation-klasse voor de bestemmingspresentatie (waar de dia moet worden gekloond)
    destination_presentation = Presentation()
    try:
        # Instantie van Slide uit de collectie dia's in de bronpresentatie samen met
        # Masterdia
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Kloon de gewenste masterdia van de bronpresentatie naar de collectie masters in de
        # Bestemmingspresentatie
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Kloon de gewenste dia van de bronpresentatie met de gewenste master naar het einde van de
        # Collectie dia's in de bestemmingspresentatie
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Sla de bestemmingspresentatie op naar schijf
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Kloon een dia aan het einde van een opgegeven sectie**

Als je een dia wilt klonen en deze vervolgens binnen hetzelfde presentatiedocument, maar in een andere sectie, wilt gebruiken, gebruik dan de [**addClone**](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addClone)‑methode die door de [**SlideCollection**](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/)‑klasse wordt blootgesteld. Aspose.Slides voor Python via Java maakt het mogelijk om een dia uit de eerste sectie te klonen en die gekloonde dia vervolgens in de tweede sectie van dezelfde presentatie in te voegen.

De volgende code‑fragment laat zien hoe je een dia kunt klonen en de gekloonde dia in een opgegeven sectie kunt invoegen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Sla de bestemmingspresentatie op naar schijf
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zorg voor overeenkomende dia‑grootte**

Wanneer dia's naar een andere presentatie worden gekloond, zorg ervoor dat de bestemmingspresentatie dezelfde dia‑grootte heeft als de bron. Als de dia‑groottes verschillen, schaalt Aspose.Slides de gekloonde vormen niet automatisch – hun oorspronkelijke coördinaten en afmetingen blijven behouden, wat kan leiden tot een verkeerde uitlijning of dat de inhoud buiten de dia‑grenzen valt.

Je kunt de dia‑grootte van de bestemmingspresentatie instellen om overeen te komen met die van de bron, vóór het klonen van de master en de dia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Doe dit vóór het klonen van de master en de dia.

## **FAQ**

**Worden aantekeningen van de spreker en beoordelingscommentaren gekloond?**

Ja. De notitiepagina en de beoordelingscommentaren worden meegenomen in de kloon. Als je ze niet wilt, [verwijder ze](/slides/nl/python-java/presentation-notes/) na het invoegen.

**Hoe worden grafieken en hun gegevensbronnen behandeld?**

Het grafiekobject, de opmaak en de ingesloten gegevens worden gekopieerd. Als de grafiek was gekoppeld aan een externe bron (bijv. een OLE‑ingesloten werkmap), blijft die koppeling behouden als een [OLE object](/slides/nl/python-java/manage-ole/). Na het verplaatsen tussen bestanden, controleer je de beschikbaarheid van de gegevens en het vernieuwingsgedrag.

**Kan ik de invoegpositie en secties voor de kloon beheersen?**

Ja. Je kunt de kloon invoegen op een specifieke dia‑index en deze plaatsen in een gekozen [sectie](/slides/nl/python-java/slide-section/). Als de doel‑sectie niet bestaat, maak deze dan eerst aan en verplaats vervolgens de dia ernaartoe.