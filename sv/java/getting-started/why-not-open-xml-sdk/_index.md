---
title: Varför inte Open XML SDK
type: docs
weight: 180
url: /sv/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- jämförelse
- presentationsobjektmodell
- högkvalitativ konvertering
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Se varför Aspose.Slides är ett bättre val än det kostnadsfria Open XML SDK: jämför funktioner, automatiseringsfri konvertering och brett stöd för PPT, PPTX och ODP."
---
## **Översikt**

Denna artikel förklarar när utvecklare kan välja Open XML SDK eller Aspose.Slides för att arbeta med presentationsdokument. Den beskriver Open XML SDK som ett bibliotek för att manipulera OOXML‑paket och deras underliggande XML‑element, medan Aspose.Slides presenteras som ett presentationsbearbetningsbibliotek med en hög‑nivå objektmodell och stöd för många PowerPoint‑relaterade uppgifter.

Artikeln jämför båda alternativen efter stödda format, programmeringsmodell, rendering, plattformsstöd och vanliga användningsfall. Den klargör också att Open XML SDK kan vara lämpligt för grundläggande PPTX‑operationer eller direkt åtkomst till OOXML‑element, medan Aspose.Slides är mer lämpligt för komplexa presentationsuppgifter såsom arbete med flera PowerPoint‑format, kopiering eller kloning av former, ersättning av text, tillämpning av animationer och konvertering av presentationer till PDF, TIFF eller XPS.

## **Vad är Open XML SDK?**
Enligt [MSDN Library](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk) definieras Open XML SDK som:

Open XML SDK 2.0 förenklar uppgiften att manipulera Open XML‑paket och de underliggande Open XML‑schemanelementen inom ett paket. Open XML SDK 2.0 kapslar in många vanliga uppgifter som utvecklare utför på Open XML‑paket, så att du kan utföra komplexa operationer med bara några få kodrader.

OOXML‑dokument är i princip zip‑ade XML‑filer och Open XML SDK är en samling klasser som låter dig arbeta med innehållet i OOXML‑dokument på ett starkt typat sätt. Istället för att packa upp en fil för att extrahera XML, läsa in XML i ett DOM‑träd och arbeta med XML‑element och attribut direkt, tillhandahåller Open XML SDK klasser för att göra detta.

## **Vad är Aspose.Slides?**
Aspose.Slides är ett klassbibliotek som låter din applikation utföra följande presentationsbearbetningsuppgifter:

- Programmering med en **Presentation**-objektmodell.
- Högkvalitativa konverteringar mellan alla populära stödda PowerPoint‑presentationsformat, inklusive konvertering till PDF, XPS och TIFF.
- Möjlighet att generera bildminiatyrer i välkända format som PNG, JPEG och BMP samt exportera bilder till SVG.
- Möjlighet att skapa presentationer från början eller genom att kombinera en eller flera dokument.
- Stöd för att lägga till animationer, Ole‑Frames, Tabeller, skapa och hantera diagram.
- Tillgänglighet av omfattande kontroll för att hantera textformatering på TextFrames‑, Paragraph‑ och Portionsnivå.

För mer information om de stödda funktionerna, besök [Aspose.Slides‑funktioner](/slides/sv/java/product-overview/).

## **Jämför Open XML SDK med Aspose.Slides**
{{% alert color="info" title="Note" %}}
Följande tabell jämför funktionerna i Open XML SDK och Aspose.Slides.
{{% /alert %}}

|**Funktion eller funktionskategori**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Stödda presentationsformat|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertering från PPT till PPTX|No|Yes|
|<p>High-level programming with a Presentation Document Object Model (DOM):</p><p>- Find and replace text.</p><p>- Assemble slides in presentations.</p>|No|Yes|
|Detaljerad programmering med ett dokumentobjektmodell, åtkomst till enskilda element och formatering såsom TextHolders, TextFrames, Paragraphs och Portions.|Yes|Yes|
|Lågnivå direkt och full åtkomst till underliggande XML‑element och attribut såsom relationsidentifierare, listidentifierare i ett OOXML‑dokument.|Yes|No|
|<p>Rendering:</p><p>- Render presentations to PDF, PDF Notes, XPS, TIFF images.</p><p>- Render slide thumbnails to PNG, JPEG, BMP, SVG and TIFF.</p><p>- Specify image resolution, quality, compression and other options.</p>|No|Yes|
|Stödda plattformar|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Slutsats**
{{% alert color="info" title="Note" %}}
Open XML SDK och Aspose.Slides konkurrerar inte direkt eftersom de adresserar ganska olika behov och målgrupper. Open XML SDK är ett klassbibliotek som erbjuder ett starkt typat sätt att arbeta med OOXML‑dokument. Aspose.Slides är ett mycket användbart presentationsbearbetningsbibliotek som ger stort stöd för nästan alla Microsoft PowerPoint‑filformat.

Om allt du behöver göra är en relativt grundläggande programmeringsoperation på ett PPTX‑dokument, kan Open XML SDK vara ett lämpligt val. Med Open XML SDK kan du enkelt utföra enkla uppgifter som att generera ett enkelt PPTX‑dokument eller ta bort kommentarer, sidhuvuden/sidfötter, extrahera bilder eller liknande. Vissa uppgifter kan uppnås med Open XML SDK, men kan inte uppnås med Aspose.Slides. Till exempel, om du behöver direkt åtkomst till XML‑element och attribut i ett OOXML‑dokument, bör du använda Open XML SDK. Men om du behöver utföra komplexa operationer på dokument, såsom några av följande uppgifter, är Aspose.Slides ditt bästa alternativ:

- Stöd för äldre PowerPoint‑format utöver PPTX.
- Kopiera eller klona former i bilder på ett sätt som kombinerar objekt, stilar och annan formatering på ett lämpligt sätt.
- Ersätt formaterad eller oformatterad text.
- Tillämpa animationer och använda anslutningar med former.
- Konvertera ett dokument till PDF, TIFF eller XPS så att det ser exakt ut som Microsoft PowerPoint skulle ha konverterat det.
- Utveckla en .NET- eller Java‑applikation i både skrivbords‑ och webb‑baserade miljöer.
{{% /alert %}}