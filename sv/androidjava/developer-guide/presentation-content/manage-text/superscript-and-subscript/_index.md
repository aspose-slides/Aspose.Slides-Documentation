---
title: Hantera upphöjd och nedsänkt text i presentationer på Android
linktitle: Upphöjd och nedsänkt
type: docs
weight: 80
url: /sv/androidjava/superscript-and-subscript/
keywords:
- upphöjd
- nedsänkt
- lägg till upphöjd
- lägg till nedsänkt
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Behärska upphöjd och nedsänkt text i Aspose.Slides för Android via Java och höj dina presentationer med professionell textformatering för maximal effekt."
---
## **Översikt**

Aspose.Slides erbjuder funktioner för att integrera upphöjd och nedsänkt text i dina PowerPoint‑presentationer (PPT, PPTX) och OpenDocument‑presentationer (ODP). Oavsett om du behöver markera kemiska formler, matematiska ekvationer eller annotera innehåll med fotnoter, hjälper dessa specialiserade formateringsalternativ till att bevara tydlighet och precision. I den här artikeln lär du dig hur du sömlöst applicerar upphöjd‑ och nedsänkt‑stilar och säkerställer ett professionellt resultat på varje bild.

## **Hantera upphöjd och nedsänkt text**
Du kan lägga till upphöjd och nedsänkt text i valfri stycke‑del. För att lägga till upphöjd eller nedsänkt text i ett Aspose.Slides‑text‑ramverk måste du använda metoden [**setEscapement**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) i klassen [PortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/PortionFormat).

Denna egenskap returnerar eller anger upphöjd‑ eller nedsänkt‑text (värde från –100 % (nedsänkt) till 100 % (upphöjd)). Till exempel:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
- Hämta referensen till en bild genom att använda dess index.
- Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAutoShape) av typen [Rectangle](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ShapeType#Rectangle) på bilden.
- Få åtkomst till den [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITextFrame) som är associerad med [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAutoShape).
- Rensa befintliga stycken.
- Skapa ett nytt styckeobjekt för att hålla upphöjd text och lägg till det i samlingen [IParagraphs collection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) för [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITextFrame).
- Skapa ett nytt del‑objekt.
- Ställ in Escapement‑egenskapen för delen mellan 0 och 100 för att lägga till upphöjd text. (0 betyder ingen upphöjd text)
- Ange någon text för [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Portion) och lägg sedan till den i del‑samlingen för stycket.
- Skapa ett nytt styckeobjekt för att hålla nedsänkt text och lägg till det i IParagraphs‑samlingen för ITextFrame.
- Skapa ett nytt del‑objekt.
- Ställ in Escapement‑egenskapen för delen mellan 0 och –100 för att lägga till nedsänkt text. (0 betyder ingen nedsänkt text)
- Ange någon text för [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Portion) och lägg sedan till den i del‑samlingen för stycket.
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

Ja, Aspose.Slides behåller korrekt upphöjd‑ och nedsänkt‑formatering när presentationer exporteras till PDF, PPT/PPTX, bilder och andra stödda format. Den specialiserade formateringen förblir intakt i alla utdatafiler.

**Kan upphöjd och nedsänkt text kombineras med andra formateringsstilar som fetstil eller kursiv?**

Ja, Aspose.Slides låter dig blanda olika textstilar inom en enskild del av texten. Du kan aktivera fetstil, kursiv, understrykning och samtidigt tillämpa upphöjd eller nedsänkt text genom att konfigurera motsvarande egenskaper i [PortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portionformat/).

**Fungerar upphöjd och nedsänkt formatering för text i tabeller, diagram eller SmartArt?**

Ja, Aspose.Slides stöder formatering i de flesta objekt, inklusive tabeller och diagramdelar. När du arbetar med SmartArt måste du komma åt rätt element (såsom [SmartArtNode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/smartartnode/)) och deras textbehållare, och sedan konfigurera [PortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portionformat/)‑egenskaperna på liknande sätt.