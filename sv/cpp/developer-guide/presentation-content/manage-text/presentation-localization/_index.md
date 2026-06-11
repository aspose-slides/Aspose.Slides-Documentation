---
title: Automatisera presentationlokalisering i C++
linktitle: Presentation lokalisering
type: docs
weight: 100
url: /sv/cpp/presentation-localization/
keywords:
- ändra språk
- stavningskontroll
- språk-id
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Automatisera lokalisering av PowerPoint- och OpenDocument-bilder i C++ med Aspose.Slides, med praktiska kodexempel och tips för snabbare global utrullning."
---
## **Översikt**

Denna artikel förklarar hur du ställer in `LanguageId` för text i en presentation med hjälp av Aspose.Slides. Den visar hur du öppnar en presentation, lägger till en form med text, tilldelar ett språkidentifierare till en textdel och sparar resultatet som en PPTX-fil.

## **Ändra språk för en presentation och formtext**
- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑klassen.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typ Rectangle på bilden.
- Lägg till lite text i TextFrame.
- Ställa in Language Id för texten.
- Skriv presentationen som en PPTX‑fil.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **Vanliga frågor**

**Utökar språk‑ID automatisk översättning av text?**

Nej. [Language ID](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_languageid/) i Aspose.Slides lagrar språket för stavningskontroll och grammatikkontroll, men den översätter eller ändrar inte textinnehållet. Det är metadata som PowerPoint förstår för korrekturläsning.

**Påverkar språk‑ID bindestreckning och radbrytning vid rendering?**

I Aspose.Slides är [Language ID](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_languageid/) avsedd för korrekturläsning. Kvaliteten på bindestreckning och radbrytning beror främst på tillgången till [korrekta fonter](/slides/sv/cpp/powerpoint-fonts/) samt layout‑/radbrytningsinställningar för skriftsystemet. För att säkerställa korrekt rendering, gör de nödvändiga fonterna tillgängliga, konfigurera [fontsubstitutionsregler](/slides/sv/cpp/font-substitution/) och/eller [bädda in fonter](/slides/sv/cpp/embedded-font/) i presentationen.

**Kan jag ange olika språk inom ett och samma stycke?**

Ja. [Language ID](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_languageid/) tillämpas på textdelnivå, så ett enda stycke kan blanda flera språk med olika korrekturinställningar.