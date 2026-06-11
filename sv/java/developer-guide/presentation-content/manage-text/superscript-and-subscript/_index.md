---
title: Hantera upphöjd och nedsänkt text i presentationer med Java
linktitle: Upphöjd och nedsänkt text
type: docs
weight: 80
url: /sv/java/superscript-and-subscript/
keywords:
- upphöjd
- nedsänkt
- lägg till upphöjd
- lägg till nedsänkt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Behärska upphöjd och nedsänkt text i Aspose.Slides för Java och lyft dina presentationer med professionell textformatering för maximal effekt."
---
## **Översikt**

Aspose.Slides tillhandahåller funktioner för att integrera upphöjd och nedsänkt text i dina PowerPoint‑presentationer (PPT, PPTX) och OpenDocument‑presentationer (ODP). Oavsett om du behöver markera kemiska formler, matematiska ekvationer eller kommentera innehåll med fotnoter, hjälper dessa specialiserade formateringsalternativ till att behålla tydlighet och precision. I den här artikeln lär du dig hur du smidigt använder upphöjd‑ och nedsänkt‑format och säkerställer professionella resultat i varje bild.

## **Hantera upphöjd och nedsänkt text**
Du kan lägga till upphöjd och nedsänkt text i valfri stycke‑del. För att lägga till upphöjd eller nedsänkt text i en Aspose.Slides‑textruta måste du använda [**setEscapement**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-)‑metoden i klassen [PortionFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/PortionFormat).

Denna egenskap returnerar eller anger upphöjd eller nedsänkt text (värde från -100% (nedsänkt) till 100% (upphöjd)). Till exempel:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
- Hämta referensen till en bild genom att använda dess index.
- Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAutoShape) av typen [Rectangle](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ShapeType#Rectangle) på bilden.
- Åtkomst till [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITextFrame) som är kopplad till [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAutoShape).
- Rensa befintliga stycken.
- Skapa ett nytt styckeobjekt för att hålla upphöjd text och lägg till det i samlingen [IParagraphs](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITextFrame#getParagraphs--) för [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITextFrame).
- Skapa ett nytt delobjekt.
- Ange egenskapen Escapement för delen mellan 0 och 100 för att lägga till upphöjd text. (0 betyder ingen upphöjd text)
- Tilldela någon text till [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Portion) och lägg sedan till den i delsamlingen för stycket.
- Skapa ett nytt styckeobjekt för att hålla nedsänkt text och lägg till det i IParagraphs‑samlingen för ITextFrame.
- Skapa ett nytt delobjekt.
- Ange egenskapen Escapement för delen mellan 0 och -100 för att lägga till nedsänkt text. (0 betyder ingen nedsänkt text)
- Tilldela någon text till [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Portion) och lägg sedan till den i delsamlingen för stycket.
- Spara presentationen som en PPTX‑fil.

Implementeringen av stegen ovan visas nedan.

```java
// Instansiera en Presentation-klass som representerar en PPTX
Presentation pres = new Presentation();
try {
    // Hämta bild
    ISlide slide = pres.getSlides().get_Item(0);

    // Skapa textruta
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Skapa stycke för upphöjd text
    IParagraph superPar = new Paragraph();

    // Skapa del med vanlig text
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Skapa del med upphöjd text
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Skapa stycke för nedsänkt text
    IParagraph paragraph2 = new Paragraph();

    // Skapa del med vanlig text
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Skapa del med nedsänkt text
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Lägg till stycken i textrutan
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kommer upphöjd och nedsänkt text att bevaras vid export till PDF eller andra format?**

Ja, Aspose.Slides behåller korrekt upphöjd och nedsänkt formatering när presentationer exporteras till PDF, PPT/PPTX, bilder och andra stödda format. Den specialiserade formateringen förblir intakt i alla utdatafiler.

**Kan upphöjd och nedsänkt text kombineras med andra formateringsstilar som fetstil eller kursiv?**

Ja, Aspose.Slides låter dig blanda olika textstilar inom ett enda textavsnitt. Du kan aktivera fetstil, kursiv, understrykning och samtidigt applicera upphöjd eller nedsänkt text genom att konfigurera motsvarande egenskaper i [PortionFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portionformat/).

**Fungerar upphöjd och nedsänkt formatering för text i tabeller, diagram eller SmartArt?**

Ja, Aspose.Slides stöder formatering i de flesta objekt, inklusive tabeller och diagramelement. När du arbetar med SmartArt måste du komma åt de relevanta elementen (såsom [SmartArtNode](https://reference.aspose.com/slides/sv/java/com.aspose.slides/smartartnode/)) och deras texthållare, och sedan konfigurera [PortionFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portionformat/)-egenskaperna på liknande sätt.