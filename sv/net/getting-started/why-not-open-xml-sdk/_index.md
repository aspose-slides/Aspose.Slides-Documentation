---
title: Varför inte Open XML SDK
type: docs
weight: 180
url: /sv/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- jämförelse
- presentationsobjektmodell
- högkvalitativ konvertering
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Se varför Aspose.Slides är ett bättre val än det fria Open XML SDK: jämför funktioner, konvertering utan automatisering och brett stöd för PPT, PPTX och ODP."
---
## **Översikt**

Den här artikeln förklarar när utvecklare kan välja Open XML SDK eller Aspose.Slides för att arbeta med presentationsdokument. Den beskriver Open XML SDK som ett bibliotek för att manipulera OOXML‑paket och deras underliggande XML‑element, medan Aspose.Slides presenteras som ett presentationsbearbetningsbibliotek med en hög nivå‑objektmodell och stöd för många PowerPoint‑relaterade uppgifter.

Artikeln jämför båda alternativen utifrån stödda format, programmeringsmodell, rendering, plattformsstöd och vanliga användningsfall. Den klargör också att Open XML SDK kan vara lämplig för grundläggande PPTX‑operationer eller direkt åtkomst till OOXML‑element, medan Aspose.Slides är mer passande för komplexa presentationsuppgifter såsom arbete med flera PowerPoint‑format, kopiering eller kloning av former, ersättning av text, tillämpning av animationer och konvertering av presentationer till PDF, TIFF eller XPS.

## **Vad är Open XML SDK?**
Ibland får vi den här frågan: *Varför ska vi använda Aspose‑produkter istället för det fria Open XML SDK?*

Vi tycker att det är enkelt att besvara frågan i termer av funktioner och egenskaper.

Enligt [MSDN Library](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk) definieras Open XML SDK på följande sätt:

> "Open XML SDK 2.0 förenklar uppgiften att manipulera Open XML‑paket och de underliggande Open XML‑schemanelementen inom ett paket. Open XML SDK 2.0 kapslar in många vanliga uppgifter som utvecklare utför på Open XML‑paket, så att du kan utföra komplexa operationer med bara några få kodrader. OOXML‑dokument är i princip zip‑ade XML‑filer och Open XML SDK är en samling klasser som låter dig arbeta med innehållet i OOXML‑dokument på ett starkt typat sätt. Det innebär att istället för att packa upp en fil för att extrahera XML, läsa in XML i ett DOM‑träd och arbeta med XML‑element och attribut direkt, så tillhandahåller Open XML SDK klasser för att göra det."

## **Vad är Aspose.Slides?**
Aspose.Slides är ett klassbibliotek som låter applikationer utföra dessa presentationsbearbetningsuppgifter:

- Programmering med en presentationsobjektmodell.
- Högkvalitativa konverteringar som omfattar alla populära stödda PowerPoint‑presentationsformat, inklusive konvertering till PDF, XPS och TIFF.
- Generering av bildminiatyrer i välkända format såsom PNG, JPEG och BMP samt export av bilder till SVG.
- Bygga presentationer från grunden eller genom att kombinera element från ett eller flera dokument.
- Lägga till animationer, OLE‑ramar, tabeller, skapa och hantera diagram.
- Kontroll (omfattande kontroll) och hantering av textformatering på TextFrames-, Paragraphs- och Portionsnivå.

För mer detaljer om de tillgängliga funktionerna, se sidan [Aspose.Slides-funktioner](/slides/sv/net/product-overview/).

## **Jämför Open XML SDK med Aspose.Slides**
Den här tabellen jämför Open XML SDK:s funktioner och egenskaper med Aspose.Slides.

|**Funktion eller Funktionskategori**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Stödda presentationsformat|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertering från PPT till PPTX |No|Yes|
|<p>Programmering på hög nivå med en Presentation Document Object Model (DOM): </p><p>- Hitta och ersätt text.</p><p>- Sätt ihop bilder i presentationer.</p>|No|Yes|
|Detaljerad programmering med en dokumentobjektmodell; åtkomst till enskilda element och formatering såsom TextHolders, TextFrames, Paragraphs och Portions.|Yes|Yes|
|Lågnivå direkt och fullständig åtkomst till de underliggande XML‑elementen och attributen såsom relationsidentifierare, listidentifierare i ett OOXML‑dokument.|Yes|No|
|<p>Rendering av presentationer:</p><p>- Rendera presentationer till PDF, PDF‑anteckningar, XPS, TIFF‑bilder.</p><p>- Rendera bildminiatyrer till PNG, JPEG, BMP, SVG och TIFF.</p><p>- Ange bildupplösning, kvalitet, kompression och andra alternativ.</p>|No|Yes|
|Stödda plattformar|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Slutsats**
Open XML SDK och Aspose.Slides konkurrerar inte direkt eftersom de adresserar avsevärt olika behov och vänder sig till olika målgrupper.

{{% alert color="info" title="Note" %}}
Open XML SDK är ett klassbibliotek som tillhandahåller ett starkt typat sätt att arbeta med OOXML‑dokument, medan Aspose.Slides är ett otroligt användbart biblioteks för presentationsbearbetning som ger stort stöd för nästan alla Microsoft PowerPoint‑filformat.
{{% /alert %}}

Om ditt arbetsflöde är en grundläggande programmeringsoperation på ett PPTX‑dokument, kan Open XML SDK vara ett bra val. Med Open XML SDK bör du känna dig bekväm med att utföra enkla uppgifter som att generera ett enkelt PPTX‑dokument eller ta bort kommentarer, sidhuvuden/sidfötter, extrahera bilder eller liknande. Vissa uppgifter kan utföras med Open XML SDK men kan inte utföras med Aspose.Slides. Till exempel, om du behöver direkt åtkomst till XML‑elementen och attributen i ett OOXML‑dokument, bör du använda Open XML SDK.

Om du behöver utföra komplexa uppgifter på dokument—såsom uppgifterna i listan nedan—är Aspose.Slides ditt bästa alternativ.

- Operationer som involverar äldre PowerPoint‑format (och även PPTX).
- Kopiering eller kloning av former inom bilder på ett sätt som kombinerar objekt, stilar och andra formateringselement på ett lämpligt sätt.
- Ersätta formaterad eller oformaterad text.
- Tillämpa animationer och använda anslutningar med former.
- Konvertera ett dokument till PDF, TIFF eller XPS så det ser ut som om Microsoft PowerPoint utförde konverteringen.
- Utveckla en .NET‑ eller Java‑applikation i både skrivbords‑ och webbmiljöer.