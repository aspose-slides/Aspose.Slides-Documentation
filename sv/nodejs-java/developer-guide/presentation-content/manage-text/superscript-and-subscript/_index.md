---
title: Hantera upphöjd och nedsänkt text i presentationer med JavaScript
linktitle: Upphöjd och nedsänkt
type: docs
weight: 80
url: /sv/nodejs-java/superscript-and-subscript/
keywords:
- upphöjd
- nedsänkt
- lägg till upphöjd
- lägg till nedsänkt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Behärska upphöjd och nedsänkt text i Aspose.Slides för Node.js via Java och höj dina presentationer med professionell textformatering för maximal effekt."
---
## **Översikt**

Aspose.Slides tillhandahåller funktioner för att integrera upphöjd och nedsänkt text i dina PowerPoint‑ (PPT, PPTX) och OpenDocument‑ (ODP) presentationer. Oavsett om du behöver framhäva kemiska formler, matematiska ekvationer eller kommentera innehåll med fotnoter, hjälper dessa specialiserade formateringsalternativ till att upprätthålla tydlighet och precision. I den här artikeln lär du dig hur du sömlöst tillämpar upphöjd‑ och nedsänkt‑format och säkerställer professionella resultat i varje bild.

## **Hantera upphöjd och nedsänkt text**

Du kan lägga till upphöjd och nedsänkt text i någon som helst paragrafdel. För att lägga till upphöjd eller nedsänkt text i Aspose.Slides textruta måste du använda metoden [**setEscapement**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) i klassen [PortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PortionFormat).

Denna egenskap returnerar eller anger den upphöjda eller nedsänkta texten (värde från -100 % (nedsänkt) till 100 % (upphöjd)). Till exempel:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape) av typen [Rectangle](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeType#Rectangle) till bilden.
- Få åtkomst till [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrame) som är associerad med [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape).
- Rensa befintliga stycken
- Skapa ett nytt styckeobjekt för att hålla upphöjd text och lägg till det i [Paragraphs collection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrame#getParagraphs--) för [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrame).
- Skapa ett nytt portion‑objekt
- Ställ in Escapement‑egenskapen för portionen mellan 0 och 100 för att lägga till upphöjd text. (0 betyder ingen upphöjd text)
- Ange någon text för [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Portion) och lägg sedan till den i portionssamlingen för stycket.
- Skapa ett nytt styckeobjekt för att hålla nedsänkt text och lägg till det i IParagraphs‑samlingen för ITextFrame.
- Skapa ett nytt portion‑objekt
- Ställ in Escapement‑egenskapen för portionen mellan 0 och -100 för att lägga till nedsänkt text. (0 betyder ingen nedsänkt text)
- Ange någon text för [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Portion) och lägg sedan till den i portionssamlingen för stycket.
- Spara presentationen som en PPTX‑fil.

Implementeringen av stegen ovan visas nedan.

```javascript
// Instansiera en Presentation-klass som representerar en PPTX
var pres = new aspose.slides.Presentation();
try {
    // Hämta bild
    var slide = pres.getSlides().get_Item(0);
    // Skapa textruta
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Skapa stycke för upphöjd text
    var superPar = new aspose.slides.Paragraph();
    // Skapa portion med vanlig text
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Skapa portion med upphöjd text
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Skapa stycke för nedsänkt text
    var paragraph2 = new aspose.slides.Paragraph();
    // Skapa portion med vanlig text
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Skapa portion med nedsänkt text
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Lägg till stycken i textrutan
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Kommer upphöjd och nedsänkt text att bevaras vid export till PDF eller andra format?**

Ja, Aspose.Slides behåller korrekt upphöjd och nedsänkt formatering vid export av presentationer till PDF, PPT/PPTX, bilder och andra stödjade format. Den specialiserade formateringen förblir intakt i alla utskriftsfiler.

**Kan upphöjd och nedsänkt text kombineras med andra formateringsstilar som fetstil eller kursiv?**

Ja, Aspose.Slides låter dig blanda olika textstilar inom en enda textportion. Du kan aktivera fetstil, kursiv, understrykning och samtidigt tillämpa upphöjd eller nedsänkt text genom att konfigurera motsvarande egenskaper i [PortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portionformat/).

**Fungerar upphöjd och nedsänkt formatering för text i tabeller, diagram eller SmartArt?**

Ja, Aspose.Slides stöder formatering i de flesta objekt, inklusive tabeller och diagramdelar. När du arbetar med SmartArt måste du komma åt de relevanta elementen (t.ex. [SmartArtNode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartartnode/)) och deras textbehållare, och sedan konfigurera [PortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portionformat/)‑egenskaperna på liknande sätt.