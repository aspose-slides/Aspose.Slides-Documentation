---
title: Hantera bildavsnitt i presentationer med Java
linktitle: Bildavsnitt
type: docs
weight: 90
url: /sv/java/slide-section/
keywords:
- skapa avsnitt
- lägg till avsnitt
- redigera avsnitt
- ändra avsnitt
- avsnittsnamn
- hämta avsnittsbilder
- bearbeta avsnittsbilder
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Hantera bildavsnitt med Aspose.Slides för Java: skapa, byta namn, omordna, hämta och bearbeta avsnittsbilder i PPTX-presentationer."
---
## **Introduktion**

Avsnitt organiserar på varandra följande bilder i namngivna grupper utan att ändra bildens innehåll. Med Aspose.Slides for Java kan du skapa, omordna, byta namn, inspektera och ta bort avsnitt via metoden [Presentation.getSections](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSections--) .

Avsnitt är särskilt användbara när:

- en stor presentation måste delas in i logiska ämnen eller kapitel;
- olika grupper av bilder tilldelas olika medarbetare;
- bilder måste bearbetas, flyttas eller slås ihop som grupper.

Välj koncisa avsnittsnamn som beskriver syftet med de grupperade bilderna. Eftersom avsnitt är en del av presentationens struktur, använd avsnitts‑API‑erna för att avgöra medlemskap istället för att härleda det från bildpositioner.

## **Skapa och hantera avsnitt**

Använd [ISectionCollection.addSection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) för att skapa ett avsnitt genom att ange dess namn och startbild. Aspose.Slides bestämmer vilka bilder som tillhör avsnittet utifrån presentationens aktuella avsnittsstruktur.

Samma [ISectionCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isectioncollection/) låter dig också:

- flytta ett avsnitt tillsammans med dess bilder genom att använda [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- ta bort endast avsnittsdefinitionen med [ISectionCollection.removeSection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), vilket behåller dess bilder;
- ta bort ett avsnitt och dess bilder med [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- lägga till ett tomt avsnitt i slutet med [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

Följande exempel skapar två avsnitt, flyttar det ena, tar bort det tillsammans med dess bilder och lägger till ett tomt avsnitt:

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

Efter dessa operationer innehåller presentationen avsnittet `Introduction` med dess bilder samt ett tomt avsnitt `Appendix`. Avsnittet `Results` och dess bilder har tagits bort.

## **Byt namn på avsnitt**

För att byta namn på ett avsnitt, anropa dess [ISection.setName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isection/#setName-java.lang.String-)‑metod. Avsnittets bilder och position förblir oförändrade.

Följande exempel skapar ett avsnitt och ändrar dess namn:

```java
import com.aspose.slides.ISection;
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

## **Hämta bilder från avsnitt**

Metoden [Presentation.getSections](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSections--) returnerar en [ISectionCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isectioncollection/) som du kan iterera över. För varje [ISection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isection/), anropa [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isection/#getSlidesListOfSection--) för att få de bilder som för närvarande tillhör den. Metoden returnerar en [ISectionSlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isectionslidecollection/), som ger antal, indexerad åtkomst och iteration.

Följande exempel skapar två fyllda avsnitt och ett tomt avsnitt, och skriver sedan ut varje avsnitts [name](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isection/#getName--), [identifier](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isection/#getSectionId--), [starting slide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isection/#getStartedFromSlide--), bildantal och bildnummer. Det använder [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) för att läsa den första bilden och ett förbättrat `for`‑uttryck för att bearbeta varje bild. För det tomma avsnittet har den returnerade samlingen storlek noll, metoden anropas inte och iterationen utför inga operationer.

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

Avsnittstillhörighet bestäms av presentationens avsnittsstruktur. Beräkna inte ett avsnitts intervall manuellt från [ISection.getStartedFromSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isection/#getStartedFromSlide--), bildindex och nästa avsnitts startbild.

Strukturella ändringar kan ändra både de bilder som returneras för ett avsnitt och deras bildnummer. Detta inkluderar omordning av bilder, kloning av en bild till ett avsnitt, flytt av ett avsnitt tillsammans med dess bilder, borttagning av bilder och borttagning av avsnitt. Nästa exempel anropar [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isection/#getSlidesListOfSection--) efter varje sådan förändring i stället för att behålla antaganden om avsnittets tidigare gränser.

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

Anropa [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isection/#getSlidesListOfSection--) igen närhelst bilder eller avsnitt omordnas, klonas, flyttas eller tas bort. Detta håller efterföljande bearbetning i linje med den aktuella presentationsstrukturen.

PPT‑formatet (PowerPoint 97–2003) bevarar inte avsnittsmetadata. Använd detta arbetsflöde med ett format som stödjer avsnitt, såsom PPTX; konvertering till PPT tar bort avsnittstrukturen som behövs för senare iteration.

## **FAQ**

**Behålls avsnitt när man sparar till PPT‑formatet (PowerPoint 97–2003)?**

Nej. PPT‑formatet stödjer inte avsnittsmetadata, så avsnittsgroupering går förlorad vid sparning till .ppt.

**Kan ett helt avsnitt ”gömmas”?**

Nej. Ett avsnitt har inget synlighetsattribut. För att dölja dess innehåll, anropa [ISlide.setHidden](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#setHidden-boolean-) för varje bild i avsnittet.

**Hur hittar jag avsnittet som innehåller en specifik bild?**

Iterera över samlingen som returneras av [Presentation.getSections](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSections--), anropa [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isection/#getSlidesListOfSection--) för varje avsnitt, och jämför de returnerade bilderna med mål‑bilden. För ett icke‑tomt avsnitt returnerar [ISection.getStartedFromSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isection/#getStartedFromSlide--) dess första bild; för ett tomt avsnitt returnerar den `null`.