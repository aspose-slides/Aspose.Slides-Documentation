---
title: Hantera bildavsnitt i presentationer på Android
linktitle: Bildavsnitt
type: docs
weight: 90
url: /sv/androidjava/slide-section/
keywords:
- skapa avsnitt
- lägga till avsnitt
- redigera avsnitt
- ändra avsnitt
- avsnittsnamn
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Effektivisera bildavsnitt i PowerPoint och OpenDocument med Aspose.Slides för Android via Java—dela, döp om och omordna för att optimera PPTX- och ODP-arbetsflöden."
---
## **Introduktion**

Med Aspose.Slides for Android via Java kan du organisera en PowerPoint‑presentation i avsnitt. Du kan skapa avsnitt som innehåller specifika bilder.

Du kan vilja skapa avsnitt och använda dem för att organisera eller dela upp bilder i en presentation i logiska delar i följande situationer:

- När du arbetar med en stor presentation tillsammans med andra eller ett team – och du behöver tilldela vissa bilder till en kollega eller några teammedlemmar. 
- När du hanterar en presentation som innehåller många bilder – och du har svårt att hantera eller redigera dess innehåll på en gång.

Idealiskt bör du skapa ett avsnitt som innehåller liknande bilder – bilderna har något gemensamt eller de kan finnas i en grupp baserad på en regel – och ge avsnittet ett namn som beskriver bilderna i det. 

## **Skapa avsnitt i presentationer**

För att lägga till ett avsnitt som ska innehålla bilder i en presentation tillhandahåller Aspose.Slides for Android via Java metoden [addSection()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) som låter dig ange namnet på avsnittet du vill skapa och bilden från vilken avsnittet startar.

Denna exempelkod visar hur du skapar ett avsnitt i en presentation i Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 avslutas vid newSlide2 och därefter startar section2   

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

## **Ändra namn på avsnitt**

Efter att du har skapat ett avsnitt i en PowerPoint‑presentation kan du bestämma dig för att ändra dess namn. 

Denna exempelkod visar hur du ändrar namn på ett avsnitt i en presentation i Java med Aspose.Slides:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Behålls avsnitt när man sparar till PPT (PowerPoint 97–2003)-formatet?**

Nej. PPT-formatet stöder inte avsnittmetadata, så avsnittsgruppning går förlorad när du sparar till .ppt.

**Kan ett helt avsnitt göras "dolt"?**

Nej. Endast enskilda bilder kan döljas. Ett avsnitt som enhet har inget "dolt"-tillstånd.

**Kan jag snabbt hitta ett avsnitt via en bild och, omvänt, den första bilden i ett avsnitt?**

Ja. Ett avsnitt definieras unikt av sin startbild; givet en bild kan du avgöra vilket avsnitt den tillhör, och för ett avsnitt kan du komma åt dess första bild.