---
title: Automatisera presentationlokalisering med Python
linktitle: Presentationlokalisering
type: docs
weight: 100
url: /sv/python-net/presentation-localization/
keywords:
- ändra språk
- stavningskontroll
- språk-id
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Automatisera lokalisering av PowerPoint- och OpenDocument‑bilder i Python med Aspose.Slides, med praktiska kodexempel och tips för snabbare global utrullning."
---
## **Översikt**

Den här artikeln förklarar hur du anger `language_id` för text i en presentation med hjälp av Aspose.Slides. Den visar hur du öppnar en presentation, lägger till en form med text, tilldelar ett språkidentifierare till en textdel och sparar resultatet som en PPTX‑fil.

## **Ändra språk för presentation och formens text**
- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
- Hämta referensen till en bild genom att använda dess index.
- Lägg till en AutoShape av typen rektangel på bilden.
- Lägg till lite text i TextFrame.
- Ställ in språk‑ID för texten.
- Spara presentationen som en PPTX‑fil.

Implementeringen av ovanstående steg visas nedan i ett exempel.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Utlöser språk‑ID automatisk textöversättning?**

Nej. [language_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/language_id/) i Aspose.Slides lagrar språket för stavningskontroll och grammatikkontroll, men den översätter inte eller ändrar textinnehållet. Det är metadata som PowerPoint förstår för korrekturläsning.

**Påverkar språk‑ID avstavning och radbrytningar vid rendering?**

I Aspose.Slides används [language_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/language_id/) för korrekturläsning. Avstavningskvalitet och radbrytning beror främst på tillgängligheten av [korrekta teckensnitt](/slides/sv/python-net/powerpoint-fonts/) samt layout-/radbrytningsinställningar för skriftsystemet. För att säkerställa korrekt rendering, gör de nödvändiga teckensnitten tillgängliga, konfigurera [teckensnittsbytesregler](/slides/sv/python-net/font-substitution/) och/eller [bädda in teckensnitt](/slides/sv/python-net/embedded-font/) i presentationen.

**Kan jag ange olika språk inom ett enda stycke?**

Ja. [language_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/language_id/) tillämpas på textrubblens nivå, så ett enda stycke kan blanda flera språk med olika korrekturläsningsinställningar.