---
title: Automatisera presentationslokalisering i .NET
linktitle: Presentationslokalisering
type: docs
weight: 100
url: /sv/net/presentation-localization/
keywords:
- ändra språk
- stavningskontroll
- språk-id
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Automatisera lokalisering av PowerPoint- och OpenDocument-bilder i .NET med Aspose.Slides, med praktiska C#-kodexempel och tips för snabbare global utrullning."
---
## **Översikt**

Den här artikeln förklarar hur du ställer in `LanguageId` för text i en presentation med Aspose.Slides. Den visar hur du öppnar en presentation, lägger till en form med text, tilldelar ett språkidentifierare till ett textavsnitt och sparar resultatet som en PPTX‑fil.

## **Ändra språk för en presentation och formtext**
- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)klass.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typen Rectangle på bilden.
- Lägg till lite text i TextFrame.
- Ställ in Language Id för texten.
- Spara presentationen som en PPTX‑fil.

Implementeringen av stegen ovan demonstreras nedan i ett exempel.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Utlöses automatisk översättning av språk‑ID?**

Nej. [LanguageId](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/languageid/) i Aspose.Slides lagrar språket för stavningskontroll och grammatikkontroll, men den översätter eller ändrar inte textinnehållet. Det är metadata som PowerPoint förstår för korrekturläsning.

**Påverkar språk‑ID avstavning och radbrytningar vid rendering?**

I Aspose.Slides används [LanguageId](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/languageid/) för korrekturläsning. Kvaliteten på avstavning och radbrytning beror främst på tillgången till [proper fonts](/slides/sv/net/powerpoint-fonts/) och layout‑/radbrytningsinställningar för skriftsystemet. För att säkerställa korrekt rendering, se till att nödvändiga teckensnitt finns tillgängliga, konfigurera [font substitution rules](/slides/sv/net/font-substitution/) och/eller [embed fonts](/slides/sv/net/embedded-font/) i presentationen.

**Kan jag ange olika språk inom ett enda stycke?**

Ja. [LanguageId](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/languageid/) tillämpas på textradsnivå, så ett enda stycke kan blanda flera språk med olika korrekturläsningsinställningar.