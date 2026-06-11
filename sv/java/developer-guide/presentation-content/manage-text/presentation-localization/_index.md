---
title: Automatisera lokalisering av presentationer i Java
linktitle: Presentation lokalisering
type: docs
weight: 100
url: /sv/java/presentation-localization/
keywords:
- ändra språk
- stavningskontroll
- språk-id
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Automatisera lokalisering av PowerPoint- och OpenDocument-bilder i Java med Aspose.Slides, med praktiska kodexempel och tips för snabbare global utrullning."
---
## **Översikt**

Den här artikeln förklarar hur du ställer in `LanguageId` för text i en presentation med Aspose.Slides. Den visar hur du öppnar en presentation, lägger till en form med text, tilldelar ett språkidentifierare till en textdel och sparar resultatet som en PPTX‑fil.

## **Ändra språk för en presentation och formtext**
- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)-klassen.  
- Hämta referensen till en bild genom att använda dess index.  
- Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAutoShape) av typen [Rectangle](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ShapeType#Rectangle) till bilden.  
- Lägg till lite text i TextFrame.  
- [Setting Language Id](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) för text.  
- Spara presentationen som en PPTX‑fil.

Implementeringen av ovanstående steg visas nedan i ett exempel.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Utlöser språk‑ID automatisk översättning av text?**

Nej. [Language ID](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) i Aspose.Slides lagrar språket för stavningskontroll och grammatikkontroll, men den översätter inte eller ändrar textinnehållet. Det är metadata som PowerPoint förstår för korrekturläsning.

**Påverkar språk‑ID bindestreckning och radbrytningar under rendering?**

I Aspose.Slides är [language ID](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) för korrekturläsning. Kvaliteten på bindestreckning och radbrytning beror främst på tillgången till [proper fonts](/slides/sv/java/powerpoint-fonts/) och layout-/radbrytningsinställningar för skriftsystemet. För att säkerställa korrekt rendering, gör de nödvändiga typsnitten tillgängliga, konfigurera [font substitution rules](/slides/sv/java/font-substitution/) och/eller [embed fonts](/slides/sv/java/embedded-font/) i presentationen.

**Kan jag ange olika språk inom ett enda stycke?**

Ja. [Language ID](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) tillämpas på textdelnivå, så ett enda stycke kan blanda flera språk med olika korrekturinställningar.