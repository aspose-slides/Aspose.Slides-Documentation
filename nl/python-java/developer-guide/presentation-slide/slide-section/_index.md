---
title: Beheer dia secties in presentaties met Python via Java
linktitle: Dia sectie
type: docs
weight: 90
url: /nl/python-java/slide-section/
keywords:
- sectie maken
- sectie toevoegen
- sectie bewerken
- sectie wijzigen
- sectienaam
- sectiedia's ophalen
- sectiedia's verwerken
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer dia secties met Aspose.Slides for Python via Java: maak, hernoem, herschik, haal op en verwerk sectiedia's in PPTX presentaties."
---
## **Introductie**

Secties organiseren opeenvolgende dia's in benoemde groepen zonder de inhoud van de dia's te wijzigen. Met Aspose.Slides for Python via Java kun je secties maken, herschikken, hernoemen, inspecteren en verwijderen via de [Presentation.getSections](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSections) methode.

Secties zijn vooral nuttig wanneer:

- een grote presentatie moet worden onderverdeeld in logische onderwerpen of hoofdstukken;
- verschillende groepen dia's worden toegewezen aan verschillende medewerkers;
- dia's moeten worden verwerkt, verplaatst of samengevoegd als groepen.

Kies beknopte sectienaam die het doel van de gegroepeerde dia's beschrijven. Aangezien secties onderdeel zijn van de presentatiestructuur, gebruik de sectie‑API's om lidmaatschap te bepalen in plaats van dit af te leiden van diapositie‑indices.

## **Secties maken en beheren**

Gebruik [SectionCollection.addSection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sectioncollection/#addSection) om een sectie te maken door de naam en de beginnende dia op te geven. Aspose.Slides bepaalt welke dia's tot de sectie behoren op basis van de huidige sectiestructuur van de presentatie.

Dezelfde [SectionCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sectioncollection/) laat je ook de volgende dingen doen:

- een sectie samen met haar dia's verplaatsen met [reorderSectionWithSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- alleen de sectiedefinitie verwijderen met [removeSection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sectioncollection/#removeSection), waarbij de dia's behouden blijven;
- een sectie en haar dia's verwijderen met [removeSectionWithSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- een lege sectie aan het einde toevoegen met [appendEmptySection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sectioncollection/#appendEmptySection).

Het volgende voorbeeld maakt twee secties, verplaatst er één, verwijdert deze samen met haar dia's, en voegt een lege sectie toe:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

Na deze bewerkingen bevat de presentatie de `Introduction`‑sectie met haar dia's en een lege `Appendix`‑sectie. De `Results`‑sectie en haar dia's zijn verwijderd.

## **Secties hernoemen**

Om een sectie te hernoemen, roep je de [Section.setName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/section/#setName)‑methode aan. De dia's en positie van de sectie blijven ongewijzigd.

Het volgende voorbeeld maakt een sectie en verandert de naam:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **Dia's ophalen uit secties**

De [Presentation.getSections](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSections)‑methode retourneert een [SectionCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sectioncollection/) die je kunt doorlopen. Voor elke [Section](https://reference.aspose.com/slides/nl/python-java/aspose.slides/section/) roep je [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/section/#getSlidesListOfSection) aan om de dia's te verkrijgen die momenteel tot die sectie behoren. De methode retourneert een [SectionSlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sectionslidecollection/), die een telling, indextoegang en iteratie biedt.

Het volgende voorbeeld maakt twee gevulde secties en één lege sectie, en print vervolgens voor elke sectie de [name](https://reference.aspose.com/slides/nl/python-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/nl/python-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/section/#getStartedFromSlide), het aantal dia's en de dia‑nummers. Het gebruikt [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sectionslidecollection/#get_Item) om de eerste dia te lezen en een `for`‑statement om elke dia te verwerken. Voor de lege sectie heeft de geretourneerde collectie een grootte van nul, de methode wordt niet aangeroepen en iteratie voert geen acties uit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

Sectie‑lidmaatschap wordt bepaald door de sectiestructuur van de presentatie. Bereken de reikwijdte van een sectie niet handmatig aan de hand van [Section.getStartedFromSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/section/#getStartedFromSlide), dia‑indices en de startdia van de volgende sectie.

Structurele bewerkingen kunnen zowel de teruggegeven dia's voor een sectie als hun dia‑nummers wijzigen. Dit omvat het herschikken van dia's, een dia klonen naar een sectie, een sectie samen met haar dia's verplaatsen, dia's verwijderen en secties verwijderen. Het volgende voorbeeld roept [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/section/#getSlidesListOfSection) aan na elke dergelijke wijziging in plaats van aan te nemen dat de vorige grenzen nog gelden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

Roep [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/section/#getSlidesListOfSection) opnieuw aan telkens wanneer dia's of secties worden herschikt, gekloond, verplaatst of verwijderd. Dit houdt latere verwerking gesynchroniseerd met de huidige presentatiestructuur.

Het PPT‑formaat (PowerPoint 97–2003) bewaart geen sectiemetadata. Gebruik deze werkwijze met een formaat dat secties ondersteunt, zoals PPTX; bij conversie naar PPT gaat de sectiestructuur die nodig is voor latere iteratie verloren.

## **FAQ**

**Worden secties behouden bij het opslaan naar het PPT‑formaat (PowerPoint 97–2003)?**

Nee. Het PPT‑formaat ondersteunt geen sectiemetadata, waardoor sectie‑groepering verloren gaat bij het opslaan als .ppt.

**Kan een volledige sectie "verborgen" worden?**

Nee. Een sectie heeft geen zichtbaarheidstoestand. Om de inhoud te verbergen, roep je [Slide.setHidden](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#setHidden) aan voor elke dia in de sectie.

**Hoe kan ik de sectie vinden die een dia bevat?**

Doorloop de collectie die wordt geretourneerd door [Presentation.getSections](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSections), roep voor elke sectie [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/section/#getSlidesListOfSection) aan en vergelijk de geretourneerde dia's met de doeldia. Voor een niet‑lege sectie geeft [Section.getStartedFromSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/section/#getStartedFromSlide) de eerste dia terug; voor een lege sectie geeft deze `None` terug.