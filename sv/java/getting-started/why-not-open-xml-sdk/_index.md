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
description: "Se varför Aspose.Slides är ett bättre val än det fria Open XML SDK: jämför funktioner, automatiseringsfri konvertering och brett stöd för PPT, PPTX och ODP."
---
## **Översikt**

Denna artikel förklarar när utvecklare kan välja Open XML SDK eller Aspose.Slides för att arbeta med presentationsdokument. Den beskriver Open XML SDK som ett bibliotek för att manipulera OOXML‑paket och deras underliggande XML‑element, medan Aspose.Slides presenteras som ett presentationsbearbetningsbibliotek med en hög nivå‑objektmodell och stöd för många PowerPoint‑relaterade uppgifter.

Artikeln jämför båda alternativen utifrån stödda format, programmeringsmodell, renderings‑ och utskriftsmöjligheter, plattformsstöd och vanliga användningsområden. Den klargör också att Open XML SDK kan vara lämplig för grundläggande PPTX‑operationer eller direkt åtkomst till OOXML‑element, medan Aspose.Slides är mer lämplig för komplexa presentationsuppgifter såsom arbete med flera PowerPoint‑format, kopiering eller kloning av former, ersättning av text, applicering av animationer och konvertering av presentationer till PDF, TIFF eller XPS.

## **Vad är Open XML SDK?**
Enligt [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) är Open XML SDK definierat som: 

Open XML SDK 2.0 förenklar uppgiften att manipulera Open XML‑paket och de underliggande Open XML‑schematelementen i ett paket. Open XML SDK 2.0 kapslar in många vanliga uppgifter som utvecklare utför på Open XML‑paket, så att du kan utföra komplexa operationer med bara några rader kod.

OOXML‑dokument är i princip zip‑ade XML‑filer och Open XML SDK är en samling klasser som låter dig arbeta med innehållet i OOXML‑dokument på ett starkt typat sätt. Det innebär att du istället för att packa upp en fil för att extrahera XML, ladda den XML‑en i ett DOM‑träd och arbeta med XML‑element och attribut direkt, använder klasser som tillhandahålls av Open XML SDK.

## **Vad är Aspose.Slides?**
Aspose.Slides är ett klassbibliotek som låter din applikation utföra följande presentationsbearbetningsuppgifter:

- Programmering med en **Presentation**-objektmodell.
- Högkvalitativa konverteringar mellan alla populära stödde PowerPoint‑presentationformat, inklusive konvertering till PDF, XPS och TIFF.
- Möjlighet att generera bildminiatyrer i välkända format som PNG, JPEG och BMP samt exportera bilder till SVG.
- Möjlighet att skapa presentationer från grunden eller genom att kombinera en eller flera dokument.
- Stöd för att lägga till animationer, Ole‑ramar, tabeller, skapa och hantera diagram.
- Tillgänglighet av omfattande kontroll för att hantera textformatering på TextFrames‑, Paragraphs‑ och Portionsnivå.

För mer information om de stödda funktionerna, besök [Aspose.Slides Features](/slides/sv/java/product-overview/).
## **Jämför Open XML SDK med Aspose.Slides**
{{% alert color="info" %}} 
Följande tabell jämför funktionerna i Open XML SDK och Aspose.Slides.
{{% /alert %}} 

|**Funktion eller Funktionskategori**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Stödda presentationsformat|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertering från PPT till PPTX|No|Yes|
|<p>Hög nivå‑programmering med en Presentation Document Object Model (DOM):</p><p>- Hitta och ersätt text.</p><p>- Sätt ihop bilder i presentationer.</p>|No|Yes|
|Detaljerad programmering med ett dokumentobjektmodell, åtkomst till enskilda element och formatering som TextHolders, TextFrames, Paragraphs och Portions.|Yes|Yes|
|Lågnivå direkt och fullständig åtkomst till de underliggande XML‑elementen och attributen, såsom relationsidentifierare, listidentifierare i ett OOXML‑dokument.|Yes|No|
|<p>Rendering:</p><p>- Rendera presentationer till PDF, PDF‑anteckningar, XPS, TIFF‑bilder.</p><p>- Rendera bildminiatyrer till PNG, JPEG, BMP, SVG och TIFF.</p><p>- Ange bildupplösning, kvalitet, komprimering och andra alternativ.</p>|No|Yes|
|Stödda plattformar|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Slutsats**
{{% alert color="info" %}} 

Open XML SDK och Aspose.Slides konkurrerar inte direkt eftersom de adresserar ganska olika behov och målgrupper. Open XML SDK är ett klassbibliotek som erbjuder ett starkt typat sätt att arbeta med OOXML‑dokument. Aspose.Slides är ett mycket användbart presentationsbearbetningsbibliotek som ger utmärkt stöd för nästan alla Microsoft PowerPoint‑filformat.

Om allt du behöver göra är en ganska grundläggande programmeringsoperation på ett PPTX‑dokument, kan Open XML SDK vara ett lämpligt val. Med Open XML SDK kan du enkelt utföra enkla uppgifter som att generera ett enkelt PPTX‑dokument eller ta bort kommentarer, sidhuvuden/sidfötter, extrahera bilder med mera. Vissa uppgifter kan uppnås med Open XML SDK, men inte med Aspose.Slides. Till exempel, om du behöver direkt åtkomst till XML‑element och attribut i ett OOXML‑dokument, bör du använda Open XML SDK. Men om du behöver utföra komplexa operationer på dokument, såsom några av följande uppgifter, är Aspose.Slides det bästa alternativet:

- Stöd för äldre PowerPoint‑format utöver PPTX.
- Kopiera eller klona former i bilder på ett sätt som kombinerar objekt, stilar och annan formatering på ett lämpligt sätt.
- Ersätta formaterad eller oformaterad text.
- Applicera animationer och använda anslutningslinjer med former.
- Konvertera ett dokument till PDF, TIFF eller XPS så att det ser exakt ut som Microsoft PowerPoint skulle ha konverterat det.
- Utveckla en .NET‑ eller Java‑applikation i både skrivbords‑ och webbaserade miljöer.

{{% /alert %}}