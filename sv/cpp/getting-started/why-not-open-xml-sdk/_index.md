---
title: Varför inte Open XML SDK
type: docs
weight: 100
url: /sv/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- jämförelse
- presentationsobjektmodell
- högkvalitativ konvertering
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Se varför Aspose.Slides är ett bättre val än det fria Open XML SDK: jämför funktioner, konvertering utan automatisering och omfattande stöd för PPT, PPTX och ODP."
---
## **Översikt**

Den här artikeln förklarar när utvecklare kan välja Open XML SDK eller Aspose.Slides för att arbeta med presentationsdokument. Den beskriver Open XML SDK som ett bibliotek för att manipulera OOXML-paket och deras underliggande XML-element, medan Aspose.Slides presenteras som ett presentationsbearbetningsbibliotek med en hög nivå objektmodell och stöd för många PowerPoint‑relaterade uppgifter.

Artikeln jämför båda alternativen utifrån stödda format, programmeringsmodell, renderings‑ och utskriftsfunktioner, plattformsstöd och vanliga användningsfall. Den klargör också att Open XML SDK kan vara lämplig för grundläggande PPTX‑operationer eller direkt åtkomst till OOXML‑element, medan Aspose.Slides är mer lämplig för komplexa presentationsuppgifter såsom arbete med flera PowerPoint‑format, kopiering eller kloning av former, ersättning av text, applicering av animationer och konvertering av presentationer till PDF, TIFF eller XPS.

## **Vad är Open XML SDK?**
Vi hör ibland frågan: Varför ska vi använda Aspose‑produkter istället för det fria Open XML SDK? Denna fråga är enkel att svara på: funktioner och funktionalitet. Enligt [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) definieras Open XML SDK som: Open XML SDK 2.0 förenklar uppgiften att manipulera Open XML‑paket och de underliggande Open XML‑schematelementen i ett paket. Open XML SDK 2.0 kapslar in många vanliga uppgifter som utvecklare utför på Open XML‑paket, så att du kan utföra komplexa operationer med bara några rader kod. OOXML‑dokument är i princip zip‑ade XML‑filer och Open XML SDK är en samling klasser som låter dig arbeta med innehållet i OOXML‑dokument på ett starkt typat sätt. Det innebär att i stället för att packa upp en fil för att extrahera XML, ladda den XML‑en i ett DOM‑träd och arbeta med XML‑element och attribut direkt, så tillhandahåller Open XML SDK klasser för att göra detta.

## **Vad är Aspose.Slides?**
Aspose.Slides är ett klassbibliotek som låter din applikation utföra följande presentationsbearbetningsuppgifter:

- Programmering med en **Presentation**‑objektmodell.
- Högkvalitativa konverteringar mellan alla populära stödde PowerPoint‑presentationsformat, inklusive konvertering till PDF och XPS.
- Möjlighet att generera bildminiatyrer i välkända format som PNG, JPEG och BMP samt exportera bilder till SVG.
- Möjlighet att bygga presentationer från grunden eller genom att kombinera en eller flera dokument.
- Stöd för att lägga till animationer, Ole‑ramar, tabeller, skapa och hantera diagram.
- Tillgänglighet av omfattande kontroll för hantering av textformatering på TextFrames‑, Paragraph‑ och Portions‑nivå.

För mer detaljer om de stödda funktionerna, besök gärna [Aspose.Slides-funktioner](/slides/sv/cpp/product-overview/).

## **Jämför Open XML SDK och Aspose.Slides**
Följande tabell jämför funktionerna i Open XML SDK och Aspose.Slides.

|**Funktion eller funktionskategori**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Stödda presentationsformat|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertering från PPT till PPTX|No|Yes|
|<p>Hög nivå programmering med ett Presentation Document Object Model (DOM):</p><p>- Sök och ersätt text.</p><p>- Sammanställ bilder i presentationer.</p>|No|Yes|
|Detaljerad programmering med ett dokumentobjektmodell, åtkomst till enskilda element och formatering såsom TextHolders, TextFrames, Paragraphs och Portions.|Yes|Yes|
|Lågnivå direkt och fullständig åtkomst till underliggande XML‑element och attribut såsom relationsidentifierare, listidentifierare i ett OOXML-dokument.|Yes|No|
|<p>Renderning:</p><p>- Rendera presentationer till PDF, PDF‑anteckningar, XPS, TIFF‑bilder.</p><p>- Rendera bildminiatyrer till PNG, JPEG, BMP, SVG och TIFF.</p><p>- Ange bildupplösning, kvalitet, kompression och andra alternativ.</p>|No|Yes|

## **Slutsats**
Open XML SDK och Aspose.Slides konkurrerar inte direkt med varandra eftersom de adresserar helt olika behov och målgrupper. Open XML SDK är ett klassbibliotek som ger ett starkt typat sätt att arbeta med OOXML‑dokument. Aspose.Slides är ett mycket användbart presentationsbearbetningsbibliotek som ger utmärkt stöd för nästan alla Microsoft PowerPoint‑filformat. Om allt du behöver göra är en ganska grundläggande programmeringsoperation på ett PPTX‑dokument, kan Open XML SDK vara ett lämpligt val. Med Open XML SDK kommer du att känna dig bekväm med enkla uppgifter som att generera ett enkelt PPTX‑dokument eller ta bort kommentarer, sidhuvud/sidfot, extrahera bilder eller liknande. Vissa uppgifter kan utföras med Open XML SDK, men kan inte uppnås med Aspose.Slides. Till exempel, om du behöver direkt åtkomst till XML‑element och attribut i ett OOXML‑dokument, bör du använda Open XML SDK. Däremot, om du behöver utföra komplexa operationer på dokument, såsom några av följande uppgifter, är Aspose.Slides ditt bästa alternativ:

- Stöd för äldre PowerPoint‑format utöver PPTX.
- Kopiera eller klona former inom bilder på ett sätt som kombinerar objekt, stilar och annan formatering på ett lämpligt sätt.
- Ersätt formaterad eller icke‑formaterad text.
- Applicera animationer och använda anslutare med former.
- Konvertera ett dokument till PDF eller XPS så att det ser exakt ut som Microsoft PowerPoint skulle ha konverterat det.
- Utveckla en C++‑applikation både i skrivbords‑ och konsolmiljöer.