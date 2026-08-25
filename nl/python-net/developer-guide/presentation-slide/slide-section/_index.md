---
title: Beheer dia‑secties in presentaties met Python
linktitle: Dia‑sectie
type: docs
weight: 100
url: /nl/python-net/slide-section/
keywords:
- sectie maken
- sectie toevoegen
- sectie bewerken
- sectie wijzigen
- sectienaam
- sectie‑dia's ophalen
- sectie‑dia's verwerken
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer dia‑secties met Aspose.Slides voor Python via .NET: maak, hernoem, hersorteer, haal op en verwerk sectie‑dia's in PPTX‑presentaties."
---
## **Inleiding**

Secties organiseren opeenvolgende dia's in benoemde groepen zonder de inhoud van de dia's te wijzigen. Met Aspose.Slides voor Python via .NET kun je secties maken, herordenen, hernoemen, inspecteren en verwijderen via de [Presentation.sections](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/sections/) eigenschap.

Secties zijn vooral handig wanneer:
- een grote presentatie moet worden opgesplitst in logische onderwerpen of hoofdstukken;
- verschillende groepen dia's worden toegewezen aan verschillende medewerkers;
- dia's moeten worden verwerkt, verplaatst of samengevoegd als groepen.

Kies beknopte sectienamen die het doel van de gegroepeerde dia's beschrijven. Aangezien secties deel uitmaken van de presentatie‑structuur, gebruik je de sectie‑API's om lidmaatschap te bepalen in plaats van het af te leiden van dia‑posities.

## **Secties maken en beheren**

Gebruik [SectionCollection.add_section](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sectioncollection/add_section/) om een sectie te maken door de naam en de startdia op te geven. Aspose.Slides bepaalt welke dia's tot de sectie behoren op basis van de huidige sectiestructuur van de presentatie.

Dezelfde [SectionCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sectioncollection/) biedt ook:
- een sectie samen met zijn dia's verplaatsen met behulp van [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/);
- alleen de sectiedefinitie verwijderen met [SectionCollection.remove_section](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sectioncollection/remove_section/), waarbij de dia's behouden blijven;
- een sectie en de bijbehorende dia's verwijderen met [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sectioncollection/remove_section_with_slides/);
- een lege sectie toevoegen aan het einde met [SectionCollection.append_empty_section](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sectioncollection/append_empty_section/).

Het volgende voorbeeld maakt twee secties, verplaatst er één, verwijdert deze samen met zijn dia's, en voegt een lege sectie toe:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

Na deze bewerkingen bevat de presentatie de `Introduction` sectie met zijn dia's en een lege `Appendix` sectie. De `Results` sectie en de bijbehorende dia's zijn verwijderd.

## **Secties hernoemen**

Om een sectie te hernoemen, stel je de [Section.name](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/name/) eigenschap in. De dia's en de positie van de sectie blijven ongewijzigd.

Het volgende voorbeeld maakt een sectie en wijzigt de naam:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Dia's opvragen uit secties**

De [Presentation.sections](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/sections/) eigenschap retourneert een [SectionCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sectioncollection/) die je kunt itereren. Voor elke [Section](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/) roep je [Section.get_slides_list_of_section](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/get_slides_list_of_section/) aan om de dia's te verkrijgen die momenteel tot die sectie behoren. De methode retourneert een [SectionSlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sectionslidecollection/), die een telling, genummerde toegang en iteratie biedt.

Het volgende voorbeeld maakt twee gevulde secties en één lege sectie, en drukt vervolgens voor elke sectie de [name](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/name/), [identifier](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/section_id/), [starting slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/started_from_slide/), het aantal dia's en de dia‑nummers af. Het gebruikt genummerde toegang om de eerste dia te lezen en een `for`‑lus om elke dia te verwerken. Voor de lege sectie heeft de geretourneerde collectie een telling van nul, wordt de index niet benaderd en wordt er niet geïtereerd.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

Sectielidmaatschap wordt bepaald door de sectiestructuur van de presentatie. Bereken de reikwijdte van een sectie niet handmatig op basis van [Section.started_from_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/started_from_slide/), dia‑indexen en de startdia van de volgende sectie.

Bewerkingen aan de structuur kunnen zowel de voor een sectie geretourneerde dia's als hun dia‑nummers wijzigen. Dit omvat het herordenen van dia's, het klonen van een dia naar een sectie, het verplaatsen van een sectie samen met zijn dia's, het verwijderen van dia's en het verwijderen van secties. Het volgende voorbeeld roept [Section.get_slides_list_of_section](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/get_slides_list_of_section/) aan na elke wijziging in plaats van veronderstellingen over de eerdere grenzen van de sectie te behouden.

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

Roep [Section.get_slides_list_of_section](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/get_slides_list_of_section/) opnieuw aan telkens wanneer dia's of secties worden herordend, gekloond, verplaatst of verwijderd. Hierdoor blijft de daaropvolgende verwerking in overeenstemming met de huidige presentatiestructuur.

Het PPT‑formaat (PowerPoint 97–2003) behoudt geen sectiemetadata. Gebruik deze werkwijze met een formaat dat secties ondersteunt, zoals PPTX; converteren naar PPT verwijdert de sectiestructuur die nodig is voor latere iteratie.

## **FAQ**

**Worden secties behouden bij het opslaan in het PPT‑formaat (PowerPoint 97–2003)?**

Nee. Het PPT‑formaat ondersteunt geen sectiemetadata, dus het groeperen in secties gaat verloren bij het opslaan naar .ppt.

**Kan een hele sectie "verborgen" worden?**

Nee. Een sectie heeft geen zichtbaarheidsstatus. Om de inhoud te verbergen, stel je de [Slide.hidden](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/hidden/) eigenschap in voor elke dia in de sectie.

**Hoe kan ik de sectie vinden die een dia bevat?**

Itereer over [Presentation.sections](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/sections/), roep [Section.get_slides_list_of_section](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/get_slides_list_of_section/) aan voor elke sectie, en vergelijk de geretourneerde dia's met de doel‑dia. Voor een niet‑lege sectie geeft [Section.started_from_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/started_from_slide/) de eerste dia terug; voor een lege sectie geeft het `None` terug.