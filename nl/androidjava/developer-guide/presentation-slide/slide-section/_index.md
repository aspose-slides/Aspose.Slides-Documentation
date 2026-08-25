---
title: Beheer dia secties in presentaties op Android
linktitle: Dia sectie
type: docs
weight: 90
url: /nl/androidjava/slide-section/
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
- Android
- Java
- Aspose.Slides
description: "Beheer dia secties met Aspose.Slides voor Android via Java: maak, hernoem, herschik, haal op en verwerk sectiedia's in PPTX presentaties."
---
## **Inleiding**

Secties ordenen opeenvolgende dia's in benoemde groepen zonder de inhoud van de dia's te wijzigen. Met Aspose.Slides voor Android via Java kunt u secties maken, herschikken, hernoemen, inspecteren en verwijderen via de [Presentation.getSections](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSections--) methode.

Secties zijn vooral nuttig wanneer:

- een grote presentatie moet worden opgedeeld in logische onderwerpen of hoofdstukken;
- verschillende groepen dia's toegewezen zijn aan verschillende medewerkers;
- dia's moeten worden verwerkt, verplaatst of samengevoegd als groepen.

Kies beknopte sectienamen die de bedoeling van de gegroepeerde dia's beschrijven. Omdat secties deel uitmaken van de presentatiestructuur, gebruik de sectie‑API's om lidmaatschap te bepalen in plaats van dit af te leiden uit de positie van de dia's.

## **Secties maken en beheren**

Gebruik [ISectionCollection.addSection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) om een sectie te maken door de naam en de startdia op te geven. Aspose.Slides bepaalt welke dia's tot de sectie behoren op basis van de huidige sectiestructuur van de presentatie.

Dezelfde [ISectionCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isectioncollection/) laat u ook:

- een sectie verplaatsen samen met zijn dia's door gebruik te maken van [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- alleen de sectiedefinitie verwijderen met [ISectionCollection.removeSection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), waarbij de dia's behouden blijven;
- een sectie en de bijbehorende dia's verwijderen met [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- een lege sectie toevoegen aan het einde met [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

Het volgende voorbeeld maakt twee secties, verplaatst er één, verwijdert deze samen met de dia's en voegt een lege sectie toe:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Na deze bewerkingen bevat de presentatie de `Introduction` sectie met zijn dia's en een lege `Appendix` sectie. De `Results` sectie en de bijbehorende dia's zijn verwijderd.

## **Secties hernoemen**

Om een sectie te hernoemen, roep u de [ISection.setName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isection/#setName-java.lang.String-) methode aan. De dia's en positie van de sectie blijven ongewijzigd.

Het volgende voorbeeld maakt een sectie en wijzigt de naam:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Dia's ophalen uit secties**

De [Presentation.getSections](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSections--) methode retourneert een [ISectionCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isectioncollection/) die u kunt doorlopen. Voor elke [ISection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isection/) roept u [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) aan om de dia's te verkrijgen die momenteel tot die sectie behoren. De methode retourneert een [ISectionSlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isectionslidecollection/), die een telling, indextoegang en iteratie biedt.

Het volgende voorbeeld maakt twee gevulde secties en één lege sectie, en drukt vervolgens voor elke sectie de [naam](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isection/#getName--) , [identifier](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isection/#getSectionId--) , [startdia](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) , het aantal dia's en de dia‑nummers af. Het gebruikt [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) om de eerste dia te lezen en een uitgebreide `for`‑lus om elke dia te verwerken. Voor de lege sectie heeft de geretourneerde collectie een grootte van nul, wordt de methode niet aangeroepen en voert de iteratie geen bewerkingen uit.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

Sectielidmaatschap wordt bepaald door de sectiestructuur van de presentatie. Bereken de reikwijdte van een sectie niet handmatig aan de hand van [ISection.getStartedFromSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), dia‑indexen en de startdia van de volgende sectie.

Structurele bewerkingen kunnen zowel de dia's die voor een sectie worden geretourneerd als hun dia‑nummers wijzigen. Dit omvat het herschikken van dia's, een dia klonen naar een sectie, een sectie verplaatsen samen met zijn dia's, dia's verwijderen en secties verwijderen. Het volgende voorbeeld roept [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) aan na elke dergelijke wijziging in plaats van veronderstellingen over de eerdere grenzen van de sectie te behouden.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Roep [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) opnieuw aan telkens wanneer dia's of secties worden herschikt, gekloond, verplaatst of verwijderd. Dit houdt latere verwerking in lijn met de huidige presentatiestructuur.

Het PPT (PowerPoint 97–2003) formaat behoudt geen sectiemetadata. Gebruik deze werkwijze met een formaat dat secties ondersteunt, zoals PPTX; converteren naar PPT verwijdert de sectiestructuur die nodig is voor latere iteratie.

## **FAQ**

**Worden secties behouden bij het opslaan naar het PPT (PowerPoint 97–2003) formaat?**

Nee. Het PPT‑formaat ondersteunt geen sectiemetadata, waardoor de sectiegroepering verloren gaat bij het opslaan als .ppt.

**Kan een hele sectie "verborgen" worden?**

Nee. Een sectie heeft geen zichtbaarheidsstatus. Om de inhoud te verbergen, roep je [ISlide.setHidden](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#setHidden-boolean-) aan voor elke dia in de sectie.

**Hoe kan ik de sectie vinden die een dia bevat?**

Itereer over de collectie die wordt geretourneerd door [Presentation.getSections](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSections--), roep voor elke sectie [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) aan en vergelijk de geretourneerde dia's met de doeldia. Voor een niet‑lege sectie geeft [ISection.getStartedFromSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) de eerste dia terug; voor een lege sectie retourneert het `null`.