---
title: Automatisera lokalisering av presentationer i JavaScript
linktitle: Presentation lokalisering
type: docs
weight: 100
url: /sv/nodejs-java/presentation-localization/
keywords:
- ändra språk
- stavningskontroll
- språk-id
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatisera lokalisering av PowerPoint- och OpenDocument-bilder i JavaScript med Aspose.Slides, med praktiska kodexempel och tips för snabbare global utrullning."
---
## **Översikt**

Den här artikeln förklarar hur du anger `LanguageId` för text i en presentation med Aspose.Slides. Den visar hur du öppnar en presentation, lägger till en form med text, tilldelar ett språkidentifierare till ett textavsnitt och sparar resultatet som en PPTX‑fil.

## **Ändra språk för presentation och formens text**

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑klassen.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape) av typen [Rectangle](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeType#Rectangle) på bilden.
- Lägg till lite text i TextFrame.
- [Inställning av språk‑Id](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) för text.
- Skriv presentationen som en PPTX‑fil.

Implementeringen av stegen ovan visas nedanför i ett exempel.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Triggar språk‑ID automatisk översättning av text?**

Nej. [setLanguageId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) i Aspose.Slides lagrar språket för stavningskontroll och grammatikkontroll, men översätter inte och ändrar inte textinnehållet. Det är metadata som PowerPoint förstår för korrekturläsning.

**Påverkar språk‑ID avstavning och radbrytningar vid rendering?**

I Aspose.Slides används [setLanguageId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) för korrekturläsning. Kvaliteten på avstavning och radbrytning beror främst på tillgången till [korrekta typsnitt](/slides/sv/nodejs-java/powerpoint-fonts/) samt layout‑/radbrytningsinställningar för skriftsystemet. För att säkerställa korrekt rendering, se till att de nödvändiga typsnitten finns tillgängliga, konfigurera [typsnittsersättningsregler](/slides/sv/nodejs-java/font-substitution/) och/eller [bädda in typsnitt](/slides/sv/nodejs-java/embedded-font/) i presentationen.

**Kan jag ange olika språk inom ett enda stycke?**

Ja. [setLanguageId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) tillämpas på textavsnittsnivå, så ett enda stycke kan blanda flera språk med separata korrekturinställningar.