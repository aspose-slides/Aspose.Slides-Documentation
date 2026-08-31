---
title: Varför inte Open XML SDK
type: docs
weight: 100
url: /sv/cpp/why-not-open-xml-sdk/
keywords:
  - Open XML SDK
  - jämförelse
  - presentationsobjektmodell
  - konvertering av hög kvalitet
  - PowerPoint
  - OpenDocument
  - presentation
  - C++
  - Aspose.Slides
description: "Se varför Aspose.Slides är ett bättre val än det gratis Open XML SDK: jämför funktioner, automatiseringsfri konvertering och brett stöd för PPT, PPTX och ODP."
---
## **Översikt**

Denna artikel förklarar när utvecklare kan välja Open XML SDK eller Aspose.Slides för att arbeta med presentationsdokument. Den beskriver Open XML SDK som ett bibliotek för att manipulera OOXML‑paket och deras underliggande XML‑element, medan Aspose.Slides presenteras som ett presentationsbearbetningsbibliotek med en hög nivå objektmodell och stöd för många PowerPoint‑relaterade uppgifter.

Artikeln jämför båda alternativen efter stödda format, programmeringsmodell, rendering, plattformsstöd och vanliga användningsfall. Den klargör också att Open XML SDK kan vara lämpligt för grundläggande PPTX‑operationer eller direkt åtkomst till OOXML‑element, medan Aspose.Slides är mer passande för komplexa presentationsuppgifter såsom arbete med flera PowerPoint‑format, kopiera eller klona former, ersätta text, tillämpa animationer och konvertera presentationer till PDF, TIFF eller XPS.

## **Vad är Open XML SDK?**
Vi hör ibland frågan: Varför ska vi använda Aspose‑produkter istället för det gratis Open XML SDK? Den här frågan är enkel att svara på: funktioner och funktionalitet. Enligt den[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) definieras Open XML SDK så här: Open XML SDK 2.0 förenklar uppgiften att manipulera Open XML‑paket och de underliggande Open XML‑schematelementen i ett paket. Open XML SDK 2.0 kapslar in många vanliga uppgifter som utvecklare utför på Open XML‑paket, så att du kan utföra komplexa operationer med bara några rader kod. OOXML‑dokument är i huvudsak zip‑ade XML‑filer och Open XML SDK är en samling klasser som låter dig arbeta med innehållet i OOXML‑dokument på ett starkt typat sätt. Det innebär att i stället för att packa upp en fil för att extrahera XML, ladda XML‑en i ett DOM‑träd och arbeta direkt med XML‑element och attribut, tillhandahåller Open XML SDK klasser för detta.

## **Vad är Aspose.Slides?**
Aspose.Slides är ett klassbibliotek som låter din applikation utföra följande presentationsbearbetningsuppgifter:

- Programmering med ett **Presentation**‑objektmodell.
- Högkvalitativa konverteringar mellan alla populära stödda PowerPoint‑presentationsformat, inklusive konvertering till PDF och XPS.
- Möjlighet att generera bildminiatyrer i välkända format som PNG, JPEG och BMP samt exportera bilder till SVG.
- Möjlighet att bygga presentationer från grunden eller genom att kombinera en eller flera dokument.
- Stöd för att lägga till animationer, Ole‑ramar, tabeller, skapa och hantera diagram.
- Omfattande kontroll för att hantera textformatering på TextFrames‑, Paragraph‑ och Portion‑nivå.
  För mer information om de stödda funktionerna, besök gärna [Aspose.Slides Features](/slides/sv/cpp/product-overview/).

## **Jämför Open XML SDK och Aspose.Slides**
Följande tabell jämför funktionerna i Open XML SDK och Aspose.Slides.

|**Funktion eller Funktionskategori**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Stödda presentationsformat|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertering från PPT till PPTX|Nej|Ja|
|<p>Programmering på hög nivå med ett Presentation Document Object Model (DOM):</p><p>- Söka och ersätta text.</p><p>- Sammanställa bilder i presentationer.</p>|Nej|Ja|
|Detaljerad programmering med ett dokumentobjektmodell, åtkomst till enskilda element och formatering såsom TextHolders, TextFrames, Paragraphs och Portions.|Ja|Ja|
|Lågnivådirekt och full åtkomst till underliggande XML‑element och attribut såsom relationsidentifikatorer, listaidentifikatorer i ett OOXML‑dokument.|Ja|Nej|
|<p>Rendering:</p><p>- Rendera presentationer till PDF, PDF‑Notes, XPS, TIFF‑bilder.</p><p>- Rendera bildminiatyrer till PNG, JPEG, BMP, SVG och TIFF.</p><p>- Specificera bildupplösning, kvalitet, komprimering och andra alternativ.</p>|Nej|Ja|

## **Slutsats**
Open XML SDK och Aspose.Slides konkurrerar inte direkt eftersom de riktar sig mot ganska olika behov och målgrupper. Open XML SDK är ett klassbibliotek som erbjuder ett starkt typat sätt att arbeta med OOXML‑dokument. Aspose.Slides är ett mycket användbart presentationsbearbetningsbibliotek som ger utmärkt stöd för i princip alla Microsoft PowerPoint‑filformat. Om allt du behöver göra är en relativt grundläggande programmeringsoperation på ett PPTX‑dokument, kan Open XML SDK vara ett lämpligt val. Med Open XML SDK kan du enkelt utföra enkla uppgifter som att skapa ett enkelt PPTX‑dokument eller ta bort kommentarer, sidhuvuden/sidfötter, extrahera bilder med mera. Vissa uppgifter kan uppnås med Open XML SDK, men inte med Aspose.Slides. Till exempel, om du behöver direkt åtkomst till XML‑element och attribut i ett OOXML‑dokument, bör du använda Open XML SDK. Men om du behöver utföra komplexa operationer på dokument, såsom några av följande uppgifter, är Aspose.Slides ditt bästa alternativ:

- Stöd för äldre PowerPoint‑format utöver PPTX.
- Kopiera eller klona former inom bilder på ett sätt som kombinerar objekt, stilar och annan formatering på ett lämpligt sätt.
- Ersätta formaterad eller oformatterad text.
- Tillämpa animationer och använda anslutningar med former.
- Konvertera ett dokument till PDF eller XPS så att det ser exakt ut som Microsoft PowerPoint skulle ha konverterat det.
- Utveckla en C++‑applikation i både skrivbords- och konsolbaserade miljöer.