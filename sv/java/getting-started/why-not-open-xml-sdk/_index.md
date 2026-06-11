---
title: Varför inte Open XML SDK
type: docs
weight: 120
url: /sv/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- jämförelse
- presentationsobjektmodell
- konvertering av hög kvalitet
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Se varför Aspose.Slides är ett bättre val än det kostnadsfria Open XML SDK: jämför funktioner, automatiseringsfri konvertering och brett stöd för PPT, PPTX och ODP."
---
## **Översikt**

Denna artikel förklarar när utvecklare kan välja Open XML SDK eller Aspose.Slides för att arbeta med presentationsdokument. Den beskriver Open XML SDK som ett bibliotek för att manipulera OOXML-paket och deras underliggande XML-element, medan Aspose.Slides presenteras som ett presentationsbearbetningsbibliotek med en hög nivå objektmodell och stöd för många PowerPoint-relaterade uppgifter.

Artikeln jämför båda alternativen utifrån stöd för format, programmeringsmodell, renderings- och utskriftsmöjligheter, plattformsstöd och vanliga användningsfall. Den förklarar också att Open XML SDK kan vara lämplig för grundläggande PPTX‑operationer eller direkt åtkomst till OOXML‑element, medan Aspose.Slides är mer lämplig för komplexa presentationsuppgifter såsom arbete med flera PowerPoint-format, kopiering eller kloning av former, ersättning av text, tillämpning av animationer och konvertering av presentationer till PDF, TIFF eller XPS.

## **Vad är Open XML SDK?**
Enligt [MSDN-biblioteket](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) är Open XML SDK definierat som: 

Open XML SDK 2.0 förenklar uppgiften att manipulera Open XML-paket och de underliggande Open XML‑schemaelementen i ett paket. Open XML SDK 2.0 kapslar in många vanliga uppgifter som utvecklare utför på Open XML‑paket, så att du kan utföra komplexa operationer med bara några få kodrader.

OOXML-dokument är i huvudsak zip‑ade XML‑filer och Open XML SDK är en samling klasser som låter dig arbeta med innehållet i OOXML‑dokument på ett starkt typat sätt. Istället för att packa upp en fil för att extrahera XML, ladda den XML:n i ett DOM‑träd och arbeta med XML‑element och attribut direkt, tillhandahåller Open XML SDK klasser för att göra det.

## **Vad är Aspose.Slides?**
Aspose.Slides är ett klassbibliotek som låter din applikation utföra följande presentationsbearbetningsuppgifter:

- Programmering med en **Presentation**-objektmodell.
- Högkvalitativa konverteringar mellan alla populära stödda PowerPoint-presentationformat, inklusive konvertering till PDF, XPS och TIFF.
- Möjlighet att generera bildspel-miniaturer i välkända format som PNG, JPEG och BMP samt exportera bildspel till SVG.
- Möjlighet att bygga presentationer från grunden eller genom att kombinera ett eller flera dokument.
- Stöd för att lägga till animationer, Ole‑ramar, tabeller, skapa och hantera diagram.
- Tillgänglighet av omfattande kontroll för hantering av textformatering på TextFrames-, Paragraphs- och Portionsnivå.

För mer detaljer om de funktioner som stöds, besök gärna [Aspose.Slides-funktioner](/slides/sv/java/product-overview/).

## **Jämför Open XML SDK med Aspose.Slides**
{{% alert color="primary" %}} 

Följande tabell jämför Open XML SDK och Aspose.Slides-funktioner.

{{% /alert %}} 

|**Funktion eller Funktionskategori**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Stödda presentationsformat|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertering från PPT till PPTX |No|Yes|
|<p>Hög nivå programmering med ett Presentation Document Object Model (DOM):</p><p>- Sök och ersätt text.</p><p>- Sammanställ bilder i presentationer.</p>|No|Yes|
|Detaljerad programmering med ett dokumentobjektmodell, åtkomst till individuella element och formatering såsom TextHolders, TextFrames, Paragraphs och Portions.|Yes|Yes|
|Lågnivå direkt och full åtkomst till de underliggande XML-elementen och attributen såsom relationsidentifikatorer, listidentifikatorer i ett OOXML-dokument.|Yes|No|
|<p>Renderning:</p><p>- Rendera presentationer till PDF, PDF‑anteckningar, XPS, TIFF‑bilder.</p><p>- Rendera bildspelsminiaturer till PNG, JPEG, BMP, SVG och TIFF.</p><p>- Specificera bildupplösning, kvalitet, komprimering och andra alternativ.</p>|No|Yes |
|Stödda plattformar|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Slutsats**
{{% alert color="primary" %}} 

Open XML SDK och Aspose.Slides konkurrerar inte direkt med varandra eftersom de adresserar ganska olika behov och målgrupper. Open XML SDK är ett klassbibliotek som tillhandahåller ett starkt typat sätt att arbeta med OOXML‑dokument. Aspose.Slides är ett mycket användbart presentationsbearbetningsbibliotek som ger omfattande stöd för nästan alla Microsoft PowerPoint‑filformat.

Ifall du bara behöver utföra en ganska grundläggande programmeringsoperation på ett PPTX‑dokument, kan Open XML SDK vara ett lämpligt val. Med Open XML SDK är du relativt bekväm med att göra enkla uppgifter som att generera ett enkelt PPTX‑dokument eller ta bort kommentarer, sidhuvuden/sidfötter, extrahera bilder eller annat. Vissa uppgifter kan uppnås med Open XML SDK, men kan inte uppnås med Aspose.Slides. Till exempel, om du behöver direkt åtkomst till XML‑elementen och attributen i ett OOXML‑dokument, bör du använda Open XML SDK. Men om du behöver utföra komplexa operationer på dokument, såsom några av följande uppgifter, är Aspose.Slides ditt bästa alternativ:

- Stöd för äldre PowerPoint-format utöver PPTX.
- Kopiera eller klona former i bilder på ett sätt som kombinerar objekt, stilar och annan formatering på ett lämpligt sätt.
- Ersätt formaterad eller oformatterad text.
- Tillämpa animationer och använda anslutningar med former.
- Konvertera ett dokument till PDF, TIFF eller XPS så att det ser exakt ut som Microsoft PowerPoint skulle ha konverterat det.
- Utveckla en .NET- eller Java-applikation i både skrivbords- och webbmiljöer.

{{% /alert %}}