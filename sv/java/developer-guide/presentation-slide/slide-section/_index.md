---
title: Hantera bildsektioner i presentationer med Java
linktitle: Bildsektion
type: docs
weight: 90
url: /sv/java/slide-section/
keywords:
- skapa sektion
- lägga till sektion
- redigera sektion
- ändra sektion
- sektionens namn
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Optimera bildsektioner i PowerPoint och OpenDocument med Aspose.Slides för Java — dela, byt namn och omordna för att förbättra PPTX- och ODP-arbetsflöden."
---
## **Introduction**

Med Aspose.Slides för Java kan du organisera en PowerPoint‑presentation i sektioner. Du kan skapa sektioner som innehåller specifika bilder.  

Du kanske vill skapa sektioner och använda dem för att organisera eller dela upp bilder i en presentation i logiska delar i följande situationer:

- När du arbetar med en stor presentation tillsammans med andra personer eller ett team—och du behöver tilldela vissa bilder till en kollega eller några teammedlemmar. 
- När du hanterar en presentation som innehåller många bilder—och du har svårt att hantera eller redigera dess innehåll på en gång.

Idealt bör du skapa en sektion som innehåller liknande bilder—bilderna har något gemensamt eller kan finnas i en grupp baserat på en regel—och ge sektionen ett namn som beskriver bilderna i den. 

## **Create Sections in Presentations**

För att lägga till en sektion som ska innehålla bilder i en presentation tillhandahåller Aspose.Slides för Java metoden [addSection()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) som låter dig ange namnet på sektionen du vill skapa och bilden från vilken sektionen startar. 

Denna exempelkod visar hur du skapar en sektion i en presentation i Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 kommer att avslutas vid newSlide2 och därefter startar section2   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change the Names of Sections**

Efter att du har skapat en sektion i en PowerPoint‑presentation kan du besluta dig för att ändra dess namn. 

Denna exempelkod visar hur du ändrar namn på en sektion i en presentation i Java med hjälp av Aspose.Slides:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Behålls sektioner när du sparar i PPT (PowerPoint 97–2003)-formatet?**

Nej. PPT-formatet stöder inte sektionmetadata, så sektionens gruppering går förlorad när du sparar till .ppt.

**Kan en hel sektion vara "dold"?**

Nej. Endast enskilda bilder kan döljas. En sektion som enhet har inget "dold"-tillstånd.

**Kan jag snabbt hitta en sektion via en bild och, omvänt, den första bilden i en sektion?**

Ja. En sektion definieras unikt av sin startbild; med en given bild kan du avgöra vilken sektion den tillhör, och för en sektion kan du komma åt dess första bild.