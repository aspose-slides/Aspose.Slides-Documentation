---
title: Varför inte Open XML SDK
type: docs
weight: 120
url: /sv/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- jämföra
- presentationsobjektmodell
- konvertering av hög kvalitet
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Se varför Aspose.Slides är ett bättre val än det fria Open XML SDK: jämför funktioner, automatiseringsfri konvertering och brett stöd för PPT, PPTX och ODP."
---
## **Översikt**

Den här artikeln förklarar när utvecklare kan välja Open XML SDK eller Aspose.Slides för att arbeta med presentationsdokument. Den beskriver Open XML SDK som ett bibliotek för att manipulera OOXML‑paket och deras underliggande XML‑element, medan Aspose.Slides presenteras som ett presentationsbearbetningsbibliotek med en hög nivå objektmodell och stöd för många PowerPoint‑relaterade uppgifter.

Artikeln jämför båda alternativen utifrån stödda format, programmeringsmodell, renderings‑ och utskriftsmöjligheter, plattformsstöd och vanliga användningsfall. Den klargör också att Open XML SDK kan vara lämplig för grundläggande PPTX‑operationer eller direkt åtkomst till OOXML‑element, medan Aspose.Slides är mer lämplig för komplexa presentationsuppgifter såsom att arbeta med flera PowerPoint‑format, kopiera eller klona former, ersätta text, applicera animationer och konvertera presentationer till PDF, TIFF eller XPS.

## **Vad är Open XML SDK?**
Enligt [MSDN‑biblioteket](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), definieras Open XML SDK som: 

Open XML SDK 2.0 förenklar uppgiften att manipulera Open XML‑paket och de underliggande Open XML‑schemaelementen i ett paket. Open XML SDK 2.0 kapslar in många vanliga uppgifter som utvecklare utför på Open XML‑paket, så att du kan utföra komplexa operationer med bara några få kodrader.

OOXML‑dokument är i princip zip‑ade XML‑filer och Open XML SDK är en samling klasser som låter dig arbeta med innehållet i OOXML‑dokument på ett starkt typat sätt. Det innebär att i stället för att packa upp en fil för att extrahera XML, ladda XML‑en i ett DOM‑träd och arbeta med XML‑element och attribut direkt, tillhandahåller Open XML SDK klasser för att göra det.

## **Vad är Aspose.Slides?**
Aspose.Slides är ett klassbibliotek som låter din applikation utföra följande presentationsbearbetningsuppgifter:

- Programmering med en **Presentation**‑objektmodell.
- Högkvalitativa konverteringar mellan alla populära stödda PowerPoint‑presentationsformat, inklusive konvertering till PDF, XPS och TIFF.
- Möjlighet att generera bildspårsminiatyrer i välkända format som PNG, JPEG och BMP samt exportera bildspår till SVG.
- Möjlighet att bygga presentationer från grunden eller genom att kombinera en eller flera dokument.
- Stöd för att lägga till animationer, Ole‑ramar, tabeller, skapa och hantera diagram.
- Tillgång till omfattande kontroll för att hantera textformatering på TextFrames‑, Paragraph‑ och Portions‑nivå.

För mer information om de stödda funktionerna, besök gärna [Aspose.Slides‑funktioner](/slides/sv/php-java/product-overview/).

## **Jämför Open XML SDK med Aspose.Slides**
{{% alert color="primary" %}} 

Följande tabell jämför Open XML SDK och Aspose.Slides funktioner.

{{% /alert %}} 

|**Funktion eller Funktionskategori**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Stödda presentationsformat|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertering från PPT till PPTX|Nej|Ja|
|<p>Hög nivå programmering med ett Presentation Document Object Model (DOM):</p><p>- Hitta och ersätta text.</p><p>- Sätta ihop bilder i presentationer.</p>|Nej|Ja|
|Detaljerad programmering med ett dokumentobjektmodell, åtkomst till enskilda element och formatering såsom TextHolders, TextFrames, Paragraphs och Portions.|Ja|Ja|
|Lågnivå direkt och fullständig åtkomst till de underliggande XML‑elementen och attributen såsom relationsidentifierare, listidentifierare i ett OOXML‑dokument.|Ja|Nej|
|<p>Rendering:</p><p>- Rendera presentationer till PDF, PDF‑anteckningar, XPS, TIFF‑bilder.</p><p>- Rendera bildspårsminiatyrer till PNG, JPEG, BMP, SVG och TIFF.</p><p>- Specificera bildupplösning, kvalitet, kompression och andra alternativ.</p>|Nej|Ja|
|Stödda plattformar|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Slutsats**
{{% alert color="primary" %}} 

Open XML SDK och Aspose.Slides konkurrerar inte direkt med varandra eftersom de tillgodoser ganska olika behov och målgrupper. Open XML SDK är ett klassbibliotek som ger ett starkt typat sätt att arbeta med OOXML‑dokument. Aspose.Slides är ett mycket användbart presentationsbearbetningsbibliotek som ger utmärkt stöd för nästan alla Microsoft PowerPoint‑filformat.

Om allt du behöver göra är en ganska grundläggande programmeringsoperation på ett PPTX‑dokument, kan Open XML SDK vara ett lämpligt val. Med Open XML SDK kommer du att känna dig ganska bekväm med att utföra enkla uppgifter som att generera ett enkelt PPTX‑dokument eller ta bort kommentarer, sidhuvuden/sidfötter, extrahera bilder eller liknande. Vissa uppgifter kan uppnås med Open XML SDK, men kan inte uppnås med Aspose.Slides. Till exempel, om du behöver direkt åtkomst till XML‑elementen och attributen i ett OOXML‑dokument, bör du använda Open XML SDK. Däremot, om du behöver utföra komplexa operationer på dokument, såsom några av följande uppgifter, är användning av Aspose.Slides ditt bästa alternativ:

- Stöd för äldre PowerPoint‑format utöver PPTX.
- Kopiera eller klona former i bildspår på ett sätt som kombinerar objekt, stilar och annan formatering på ett lämpligt sätt.
- Ersätta formaterad eller oformaterad text.
- Applicera animationer och använda anslutare med former.
- Konvertera ett dokument till PDF, TIFF eller XPS så att det ser exakt ut som Microsoft PowerPoint skulle ha konverterat det.
- Utveckla en .NET‑ eller Java‑applikation i både skrivbords- och webbaserade miljöer.

{{% /alert %}}