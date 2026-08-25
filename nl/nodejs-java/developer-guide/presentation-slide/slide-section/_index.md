---
title: Beheer dia‑secties in presentaties met JavaScript
linktitle: Dia‑sectie
type: docs
weight: 90
url: /nl/nodejs-java/slide-section/
keywords:
- sectie maken
- sectie toevoegen
- sectie bewerken
- sectie wijzigen
- sectienaam
- dia's van sectie ophalen
- dia's van sectie verwerken
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer dia‑secties met Aspose.Slides voor Node.js via Java: maak, hernoem, herschik, haal op en verwerk sectiedia's in PPTX‑presentaties."
---
## **Introductie**

Secties organiseren opeenvolgende dia's in benoemde groepen zonder de inhoud van de dia's te wijzigen. Met Aspose.Slides voor Node.js via Java kun je secties aanmaken, herschikken, hernoemen, inspecteren en verwijderen via de [Presentation.getSections](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSections)‑methode.

Secties zijn vooral nuttig wanneer:

- een grote presentatie moet worden opgesplitst in logische onderwerpen of hoofdstukken;
- verschillende groepen dia's worden toegewezen aan verschillende medewerkers;
- dia's als groepen moeten worden verwerkt, verplaatst of samengevoegd.

Kies beknopte sectienaam die het doel van de gegroepeerde dia's beschrijft. Omdat secties deel uitmaken van de presentatiestructuur, gebruik je de sectie‑API’s om lidmaatschap te bepalen in plaats van dit af te leiden uit de positie van de dia's.

## **Secties aanmaken en beheren**

Gebruik [SectionCollection.addSection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sectioncollection/#addSection) om een sectie aan te maken door de naam en de startdia op te geven. Aspose.Slides bepaalt welke dia's tot de sectie behoren op basis van de huidige sectiestructuur van de presentatie.

Dezelfde [SectionCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sectioncollection/) biedt tevens de mogelijkheid om:

- een sectie samen met de dia's te verplaatsen met [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- alleen de sectiedefinitie te verwijderen met [SectionCollection.removeSection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sectioncollection/#removeSection), waarbij de dia's behouden blijven;
- een sectie en de bijbehorende dia's te verwijderen met [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- een lege sectie aan het einde toe te voegen met [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

Het volgende voorbeeld maakt twee secties, verplaatst er één, verwijdert deze samen met de dia's en voegt een lege sectie toe:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Na deze bewerkingen bevat de presentatie de `Introduction`‑sectie met de bijbehorende dia's en een lege `Appendix`‑sectie. De `Results`‑sectie en de dia's daarvan zijn verwijderd.

## **Secties hernoemen**

Om een sectie te hernoemen, roep je de [Section.setName](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/section/#setName)‑methode aan. De dia's en de positie van de sectie blijven ongewijzigd.

Het volgende voorbeeld maakt een sectie aan en wijzigt de naam:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Dia's uit secties ophalen**

De [Presentation.getSections](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSections)‑methode retourneert een [SectionCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sectioncollection/) die je kunt benaderen op index. Voor elke [Section](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/section/) roep je [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/section/#getSlidesListOfSection) aan om de dia's te verkrijgen die momenteel tot die sectie behoren. De methode retourneert een [SectionSlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sectionslidecollection/), die een teller en indextoegang biedt.

Het volgende voorbeeld maakt twee gevulde secties en één lege sectie, en print vervolgens de [name](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/section/#getStartedFromSlide), het aantal dia's en de dia‑nummers van elke sectie. Het gebruikt [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) om zowel de eerste dia als elke dia in de collectie te lezen. Voor de lege sectie heeft de geretourneerde collectie een grootte van nul, wordt indextoegang overgeslagen en voert de lus geen bewerkingen uit.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

Sectielidmaatschap wordt bepaald door de sectiestructuur van de presentatie. Bereken een sectiebereik niet handmatig op basis van [Section.getStartedFromSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/section/#getStartedFromSlide), dia‑indexen en de startdia van de volgende sectie.

Structurele bewerkingen kunnen zowel de dia’s die voor een sectie worden geretourneerd als hun dia‑nummers wijzigen. Dit omvat het herschikken van dia's, een dia klonen naar een sectie, een sectie verplaatsen samen met de dia's, dia's verwijderen en secties verwijderen. Het volgende voorbeeld roept [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/section/#getSlidesListOfSection) aan na elke dergelijke wijziging in plaats van aannames te behouden over de vroegere grenzen van de sectie.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Roep [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/section/#getSlidesListOfSection) opnieuw aan wanneer dia's of secties worden herschikt, gekloond, verplaatst of verwijderd. Hierdoor blijft de verdere verwerking in lijn met de actuele presentatiestructuur.

Het PPT‑formaat (PowerPoint 97–2003) behoudt geen sectiemetagegevens. Gebruik deze werkwijze met een formaat dat secties ondersteunt, zoals PPTX; conversie naar PPT verwijdert de sectiestructuur die nodig is voor latere iteratie.

## **FAQ**

**Worden secties behouden bij het opslaan naar het PPT‑formaat (PowerPoint 97–2003)?**

Nee. Het PPT‑formaat ondersteunt geen sectiemetagegevens, waardoor de sectiegroepering verloren gaat bij het opslaan als .ppt.

**Kan een hele sectie “verborgen” worden?**

Nee. Een sectie heeft geen zichtbaarheidsstatus. Om de inhoud te verbergen, roep je [Slide.setHidden](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#setHidden) aan voor elke dia in de sectie.

**Hoe vind ik de sectie die een bepaalde dia bevat?**

Door elke sectie in de collectie die wordt geretourneerd door [Presentation.getSections](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSections) te doorlopen, voor elke sectie [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/section/#getSlidesListOfSection) aan te roepen en de geretourneerde dia's te vergelijken met de doel‑dia. Voor een niet‑lege sectie geeft [Section.getStartedFromSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/section/#getStartedFromSlide) de eerste dia terug; voor een lege sectie retourneert het `null`.