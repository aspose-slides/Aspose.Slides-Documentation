---
title: Hantera bildavsnitt i presentationer med JavaScript
linktitle: Bildavsnitt
type: docs
weight: 90
url: /sv/nodejs-java/slide-section/
keywords:
- skapa avsnitt
- lägga till avsnitt
- redigera avsnitt
- ändra avsnitt
- avsnittsnamn
- hämta avsnittsbilder
- bearbeta avsnittsbilder
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera bildavsnitt med Aspose.Slides för Node.js via Java: skapa, byta namn på, omordna, hämta och bearbeta avsnittsbilder i PPTX-presentationer."
---
## **Introduktion**

Avsnitt organiserar på varandra följande bilder i namngivna grupper utan att ändra bildinnehållet. Med Aspose.Slides för Node.js via Java kan du skapa, omordna, byta namn, inspektera och ta bort avsnitt via metoden [Presentation.getSections](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSections) metod.

Avsnitt är särskilt användbara när:

- en stor presentation behöver delas upp i logiska ämnen eller kapitel;
- olika grupper av bilder tilldelas olika medarbetare;
- bilder behöver bearbetas, flyttas eller slås ihop som grupper.

Välj koncisa avsnittsnamn som beskriver syftet med de grupperade bilderna. Eftersom avsnitt är en del av presentationens struktur, använd avsnitt‑API:erna för att avgöra medlemskap istället för att härleda det från bildpositioner.

## **Skapa och hantera avsnitt**

Använd [SectionCollection.addSection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sectioncollection/#addSection) för att skapa ett avsnitt genom att ange dess namn och startbild. Aspose.Slides bestämmer vilka bilder som tillhör avsnittet från presentationens nuvarande avsnittstruktur.

Samma [SectionCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sectioncollection/) låter dig också:

- flytta ett avsnitt tillsammans med dess bilder genom att använda [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- ta bara bort avsnittdefinitionen med [SectionCollection.removeSection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sectioncollection/#removeSection), vilket behåller dess bilder;
- ta bort ett avsnitt och dess bilder med [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- lägga till ett tomt avsnitt i slutet med [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

Följande exempel skapar två avsnitt, flyttar ett av dem, tar bort det tillsammans med dess bilder och lägger till ett tomt avsnitt:

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

Efter dessa operationer innehåller presentationen `Introduction`‑avsnittet med dess bilder samt ett tomt `Appendix`‑avsnitt. `Results`‑avsnittet och dess bilder har tagits bort.

## **Byt namn på avsnitt**

För att byta namn på ett avsnitt, anropa dess [Section.setName](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/section/#setName) metod. Avsnittets bilder och position förblir oförändrade.

Följande exempel skapar ett avsnitt och ändrar dess namn:

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

## **Hämta bilder från avsnitt**

[Presentation.getSections](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSections) metoden returnerar en [SectionCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sectioncollection/) som du kan komma åt via index. För varje [Section](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/section/), anropa [Section.getSlidesListOfSection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/section/#getSlidesListOfSection) för att hämta de bilder som för närvarande tillhör den. Metoden returnerar en [SectionSlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sectionslidecollection/), som ger ett räkneantal och indexerad åtkomst.

Följande exempel skapar två fyllda avsnitt och ett tomt avsnitt, och skriver sedan ut varje avsnitts [name](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/section/#getStartedFromSlide), bildantal och bildnummer. Det använder [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) för att läsa både den första bilden och varje bild i samlingen. För det tomma avsnittet har den returnerade samlingen size noll, indexerad åtkomst hoppas över och loopen utför inga operationer.

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

Avsnittstillhörighet bestäms av presentationens avsnittstruktur. Beräkna inte ett avsnitts intervall manuellt från [Section.getStartedFromSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/section/#getStartedFromSlide), bildindex och nästa avsnitts startbild.

Strukturella redigeringar kan förändra både de bilder som returneras för ett avsnitt och deras bildnummer. Detta inkluderar omordning av bilder, kloning av en bild till ett avsnitt, flytt av ett avsnitt tillsammans med dess bilder, borttagning av bilder och borttagning av avsnitt. Nästa exempel anropar [Section.getSlidesListOfSection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/section/#getSlidesListOfSection) efter varje sådan förändring istället för att behålla antaganden om avsnittets tidigare gränser.

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

Anropa [Section.getSlidesListOfSection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/section/#getSlidesListOfSection) igen när bilder eller avsnitt omordnas, klonas, flyttas eller tas bort. Detta håller efterföljande bearbetning i linje med den aktuella presentationsstrukturen.

PPT‑formatet (PowerPoint 97–2003) bevarar inte avsnittsmetadata. Använd detta arbetsflöde med ett format som stöder avsnitt, som PPTX; konvertering till PPT tar bort avsnittsstrukturen som behövs för senare iteration.

## **Vanliga frågor**

**Behålls avsnitt när man sparar till PPT (PowerPoint 97–2003)-formatet?**

Nej. PPT-formatet stöder inte avsnittsmetadata, så avsnittsgruppering går förlorad när man sparar till .ppt.

**Kan ett helt avsnitt vara "dolt"?**

Nej. Ett avsnitt har inget synlighetstillstånd. För att dölja dess innehåll, anropa [Slide.setHidden](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#setHidden) för varje bild i avsnittet.

**Hur kan jag hitta avsnittet som innehåller en bild?**

Åtkomst varje avsnitt i samlingen som returneras av [Presentation.getSections](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSections), anropa [Section.getSlidesListOfSection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/section/#getSlidesListOfSection) för varje avsnitt, och jämför de returnerade bilderna med mål‑bilden. För ett icke‑tomt avsnitt returnerar [Section.getStartedFromSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/section/#getStartedFromSlide) dess första bild; för ett tomt avsnitt returnerar det `null`.