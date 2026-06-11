---
title: Hantera bildsektioner i presentationer med JavaScript
linktitle: Bildsektion
type: docs
weight: 90
url: /sv/nodejs-java/slide-section/
keywords:
- skapa sektion
- lägga till sektion
- redigera sektion
- ändra sektion
- sektionens namn
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Effektivisera bildsektioner i PowerPoint och OpenDocument med Aspose.Slides för Node.js — dela, byt namn och omordna för att optimera PPTX- och ODP-arbetsflöden."
---
## **Introduktion**

Med Aspose.Slides för Node.js via Java kan du organisera en PowerPoint-presentation i sektioner. Du kan skapa sektioner som innehåller specifika bilder.

Du kan vilja skapa sektioner och använda dem för att organisera eller dela upp bilder i en presentation i logiska delar i följande situationer:

- När du arbetar med en stor presentation tillsammans med andra eller ett team — och du behöver tilldela vissa bilder till en kollega eller några teammedlemmar. 
- När du har en presentation som innehåller många bilder — och du har svårt att hantera eller redigera dess innehåll på en gång.

Idealiskt bör du skapa en sektion som samlar liknande bilder — bilderna har något gemensamt eller de kan existera i en grupp baserat på en regel — och ge sektionen ett namn som beskriver bilderna i den. 

## **Skapa sektioner i presentationer**

För att lägga till en sektion som samlar bilder i en presentation tillhandahåller Aspose.Slides för Node.js via Java metoden [addSection()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) som låter dig ange namnet på sektionen du vill skapa och bilden där sektionen börjar.

Denna exempelcode visar hur du skapar en sektion i en presentation i JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 kommer att avslutas vid newSlide2 och därefter kommer section2 att börja
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ändra namn på sektioner**

Efter att du har skapat en sektion i en PowerPoint-presentation kan du bestämma dig för att ändra dess namn.

Denna exempelcode visar hur du ändrar namnet på en sektion i en presentation i JavaScript med Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Behålls sektioner när man sparar till PPT (PowerPoint 97–2003)-formatet?**

Nej. PPT-formatet stöder inte sektionmetadata, så sektiongruppering går förlorad när man sparar till .ppt.

**Kan en hel sektion "döljas"?**

Nej. Endast enskilda bilder kan döljas. En sektion som enhet har inget "dolt" tillstånd.

**Kan jag snabbt hitta en sektion via en bild och, omvänt, den första bilden i en sektion?**

Ja. En sektion definieras unikt av sin startbild; given en bild kan du avgöra vilken sektion den tillhör, och för en sektion kan du komma åt dess första bild.