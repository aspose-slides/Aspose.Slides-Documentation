---
title: Automatisera presentationens lokalisering på Android
linktitle: Presentation lokalisering
type: docs
weight: 100
url: /sv/androidjava/presentation-localization/
keywords:
- ändra språk
- stavningskontroll
- språk-id
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Automatisera lokalisering av PowerPoint- och OpenDocument-bilder i Java med Aspose.Slides för Android, med praktiska kodexempel och tips för snabbare global utrullning."
---
## **Översikt**

Denna artikel förklarar hur man ställer in `LanguageId` för text i en presentation med Aspose.Slides. Den visar hur man öppnar en presentation, lägger till en form med text, tilldelar ett språkidentifierare till en textdel och sparar resultatet som en PPTX‑fil.

## **Ändra språk för en presentation och formtext**
- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) klass.  
- Hämta referensen till en bild genom att använda dess index.  
- Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAutoShape) av typen [Rectangle](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ShapeType#Rectangle) på bilden.  
- Lägg till lite text i TextFrame.  
- [Ställa in språk‑ID](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) för text.  
- Skriv presentationen som en PPTX‑fil.

Implementeringen av stegen ovan demonstreras nedan i ett exempel.

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

**Utlöser språk‑ID automatisk textöversättning?**

Nej. [Language ID](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) i Aspose.Slides lagrar språket för stavningskontroll och grammatikkontroll, men den översätter inte eller ändrar textinnehållet. Det är metadata som PowerPoint förstår för korrekturläsning.

**Påverkar språk‑ID bindestreck och radbrytningar vid rendering?**

I Aspose.Slides är [language ID](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) för korrekturläsning. Kvaliteten på bindestreck och radbrytning beror främst på tillgängligheten av [proper fonts](/slides/sv/androidjava/powerpoint-fonts/) och layout‑/radbrytningsinställningar för skriftsystemet. För att säkerställa korrekt rendering, gör de nödvändiga typsnitten tillgängliga, konfigurera [font substitution rules](/slides/sv/androidjava/font-substitution/) och/eller [embed fonts](/slides/sv/androidjava/embedded-font/) i presentationen.

**Kan jag ange olika språk inom ett enda stycke?**

Ja. [Language ID](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) tillämpas på textdelnivå, så ett enda stycke kan blanda flera språk med separata korrekturinställningar.