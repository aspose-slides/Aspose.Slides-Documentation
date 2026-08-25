---
title: Hantera bildsektioner i presentationer på Android
linktitle: Bildsektion
type: docs
weight: 90
url: /sv/androidjava/slide-section/
keywords:
- skapa sektion
- lägga till sektion
- redigera sektion
- ändra sektion
- sektionens namn
- hämta sektionens bilder
- behandla sektionbilder
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Hantera bildsektioner med Aspose.Slides för Android via Java: skapa, byta namn, omordna, hämta och bearbeta sektionbilder i PPTX-presentationer."
---
## **Introduktion**

Sektioner organiserar på varandra följande bilder i namngivna grupper utan att ändra bildinnehållet. Med Aspose.Slides för Android via Java kan du skapa, omordna, byta namn, inspektera och ta bort sektioner via metoden [Presentation.getSections](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSections--).

Sektioner är särskilt användbara när:

- en stor presentation behöver delas in i logiska ämnen eller kapitel;
- olika grupper av bilder tilldelas olika medarbetare;
- bilder måste bearbetas, flyttas eller slås samman som grupper.

Välj koncisa sektionnamn som beskriver syftet med de grupperade bilderna. Eftersom sektioner är en del av presentationsstrukturen, använd sektion‑API:erna för att avgöra medlemskap istället för att härleda det från bildpositioner.

## **Skapa och hantera sektioner**

Använd [ISectionCollection.addSection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) för att skapa en sektion genom att ange dess namn och startbild. Aspose.Slides avgör vilka bilder som tillhör sektionen utifrån presentationens aktuella sektionstruktur.

Samma [ISectionCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isectioncollection/) låter dig också:

- flytta en sektion tillsammans med dess bilder genom att använda [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- ta bara bort sektionens definition med [ISectionCollection.removeSection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), vilket behåller dess bilder;
- ta bort en sektion och dess bilder med [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- lägga till en tom sektion i slutet med [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

Följande exempel skapar två sektioner, flyttar en av dem, tar bort den tillsammans med dess bilder och lägger till en tom sektion:

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

Efter dessa operationer innehåller presentationen `Introduction`-sektionen med dess bilder och en tom `Appendix`-sektion. `Results`-sektionen och dess bilder har tagits bort.

## **Byta namn på sektioner**

För att byta namn på en sektion, anropa dess [ISection.setName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isection/#setName-java.lang.String-)‑metod. Sektionens bilder och position förblir oförändrade.

Följande exempel skapar en sektion och ändrar dess namn:

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

## **Hämta bilder från sektioner**

Metoden [Presentation.getSections](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSections--) returnerar en [ISectionCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isectioncollection/) som du kan iterera över. För varje [ISection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isection/), anropa [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) för att hämta de bilder som för närvarande tillhör den. Metoden returnerar en [ISectionSlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isectionslidecollection/), som tillhandahåller en räknare, indexerad åtkomst och iteration.

Följande exempel skapar två ifyllda sektioner och en tom sektion, och skriver sedan ut varje sektionens [namn](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isection/#getName--), [identifierare](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isection/#getSectionId--), [startbild](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), bildantal och bildnummer. Det använder [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) för att läsa den första bilden och ett förbättrat `for`‑statement för att bearbeta varje bild. För den tomma sektionen har den returnerade samlingen storlek noll, metoden anropas inte och iterationen utför inga operationer.

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

Sektionstillhörighet bestäms av presentationens sektionstruktur. Räkna inte ut en sektons intervall manuellt från [ISection.getStartedFromSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), bildindex och nästa sektons startbild.

Strukturella redigeringar kan ändra både de bilder som returneras för en sektion och deras bildnummer. Detta inkluderar omordning av bilder, kloning av en bild till en sektion, flytt av en sektion tillsammans med dess bilder, borttagning av bilder och borttagning av sektioner. Nästa exempel anropar [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) efter varje sådan förändring istället för att behålla antaganden om sektionens tidigare gränser.

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

Anropa [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) igen när bilder eller sektioner har omordnats, klonats, flyttats eller tagits bort. Detta håller efterföljande bearbetning i linje med den aktuella presentationsstrukturen.

PPT‑formatet (PowerPoint 97–2003) bevarar inte sektionmetadata. Använd detta arbetsflöde med ett format som stödjer sektioner, till exempel PPTX; konvertering till PPT tar bort den sektionstruktur som behövs för senare iteration.

## **Vanliga frågor**

**Behålls sektioner när man sparar till PPT (PowerPoint 97–2003)-formatet?**

Nej. PPT‑formatet stöder inte sektionmetadata, så sektionerna försvinner när man sparar till .ppt.

**Kan en hel sektion "gömmas"?**

Nej. En sektion har inget synlighetstillstånd. För att gömma dess innehåll, anropa [ISlide.setHidden](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/#setHidden-boolean-) för varje bild i sektionen.

**Hur kan jag hitta sektionen som innehåller en bild?**

Iterera över samlingen som returneras av [Presentation.getSections](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSections--), anropa [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) för varje sektion och jämför de returnerade bilderna med målbilden. För en icke‑tom sektion returnerar [ISection.getStartedFromSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) dess första bild; för en tom sektion returnerar den `null`.