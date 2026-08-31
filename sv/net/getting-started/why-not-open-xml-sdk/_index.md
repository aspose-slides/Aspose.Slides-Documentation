---
title: Varför inte Open XML SDK
type: docs
weight: 50
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
description: "Se varför Aspose.Slides är ett bättre val än det kostnadsfria Open XML SDK: jämför funktioner, automatiseringsfri konvertering och brett stöd för PPT, PPTX och ODP."
---
## **Översikt**

Denna artikel förklarar när utvecklare kan välja Open XML SDK eller Aspose.Slides för att arbeta med presentationsdokument. Den beskriver Open XML SDK som ett bibliotek för att manipulera OOXML‑paket och deras underliggande XML‑element, medan Aspose.Slides presenteras som ett presentationsbearbetningsbibliotek med en hög nivå objektmodell och stöd för många PowerPoint‑relaterade uppgifter.

Artikeln jämför båda alternativen utifrån stödda format, programmeringsmodell, rendering, plattformsstöd och vanliga användningsfall. Den klargör också att Open XML SDK kan vara lämplig för grundläggande PPTX‑operationer eller direkt åtkomst till OOXML‑element, medan Aspose.Slides är mer lämplig för komplexa presentationsuppgifter som att arbeta med flera PowerPoint‑format, kopiera eller klona former, ersätta text, tillämpa animationer och konvertera presentationer till PDF, TIFF eller XPS.

## **Vad är Open XML SDK?**
Ibland får vi denna fråga: *Varför ska vi använda Aspose‑produkter istället för det kostnadsfria Open XML SDK?* 

Vi tycker det är enkelt att besvara denna fråga i termer av funktioner och egenskaper. 

Enligt [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) definieras Open XML SDK på följande sätt: 

> "Open XML SDK 2.0 förenklar uppgiften att manipulera Open XML‑paket och de underliggande Open XML‑schematelementen i ett paket. Open XML SDK 2.0 kapslar in många vanliga uppgifter som utvecklare utför på Open XML‑paket, så att du kan utföra komplexa operationer med bara några få kodrader. OOXML‑dokument är i huvudsak zipade XML‑filer och Open XML SDK är en samling klasser som låter dig arbeta med innehållet i OOXML‑dokument på ett starkt typat sätt. Det innebär att i stället för att packa upp en fil för att extrahera XML, ladda den XML:n i ett DOM‑träd och arbeta direkt med XML‑element och attribut, tillhandahåller Open XML SDK klasser för att göra detta."

## **Vad är Aspose.Slides?**
Aspose.Slides är ett klassbibliotek som låter applikationer utföra dessa presentationsbearbetningsuppgifter: 

- Programmering med en presentationsobjektmodell.  
- Högkvalitativa konverteringar som omfattar alla populära stödda PowerPoint‑presentationsformat, inklusive konvertering till PDF, XPS och TIFF.  
- Generering av bildminiatyrer i välkända format som PNG, JPEG och BMP samt export av bilder till SVG.  
- Bygga presentationer från grunden eller genom att kombinera element från ett eller flera dokument.  
- Lägga till animationer, OLE‑ramar, tabeller, skapa och hantera diagram.  
- Styrning (omfattande kontroll) och hantering av textformat på TextFrames-, Paragraph- och Portionsnivå.  

För mer information om de tillgängliga funktionerna, se sidan [Aspose.Slides Features](/slides/sv/net/product-overview/).

## **Jämför Open XML SDK med Aspose.Slides**
Denna tabell jämför Open XML SDK-funktioner och egenskaper med Aspose.Slides.

|**Funktion eller funktionkategori**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Stödda presentationsformat|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertering från PPT till PPTX |No|Yes|
|<p>Hög nivå programmering med ett Presentation Document Object Model (DOM): </p><p>- Hitta och ersätta text.</p><p>- Sätt ihop bilder i presentationer.</p>|No|Yes|
|Detaljerad programmering med ett dokumentobjektmodell; åtkomst till individuella element och formatering såsom TextHolders, TextFrames, Paragraphs och Portions.|Yes|Yes|
|Lågnivå direkt och full åtkomst till de underliggande XML‑elementen och attributen såsom relationsidentifierare, listidentifierare i ett OOXML‑dokument.|Yes|No|
|<p>Rendering av presentationer:</p><p>- Rendera presentationer till PDF, PDF‑anteckningar, XPS, TIFF‑bilder.</p><p>- Rendera miniatyrbilder till PNG, JPEG, BMP, SVG och TIFF.</p><p>- Ange bildupplösning, kvalitet, komprimering och andra alternativ.</p>|No|Yes|
|Stödda plattformar|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Slutsats**
Open XML SDK och Aspose.Slides konkurrerar inte direkt eftersom de adresserar helt olika behov och vänder sig till olika målgrupper. 

{{% alert color="info" %}} 

Open XML SDK är ett klassbibliotek som ger ett starkt typat sätt att arbeta med OOXML‑dokument medan Aspose.Slides är ett oerhört användbart presentationsbearbetningsbibliotek som ger utmärkt stöd för nästan alla Microsoft PowerPoint‑filformat. 

{{% /alert %}} 

Om ditt arbetsflöde är en grundläggande programmeringsoperation på ett PPTX‑dokument, kan Open XML SDK vara ett bra val. Med Open XML SDK bör du kunna utföra enkla uppgifter som att generera ett enkelt PPTX‑dokument eller ta bort kommentarer, sidhuvuden/sidfötter, extrahera bilder eller liknande. Vissa uppgifter kan utföras med Open XML SDK men kan inte utföras med Aspose.Slides. Till exempel, om du behöver direkt åtkomst till XML‑elementen och attributen i ett OOXML‑dokument, bör du använda Open XML SDK. 

Om du behöver utföra komplexa uppgifter på dokument – såsom uppgifterna i listan nedan – är Aspose.Slides ditt bästa alternativ. 

- Operationer som involverar äldre PowerPoint‑format (och även PPTX).  
- Kopiera eller klona former inom bilder på ett sätt som kombinerar objekt, stilar och andra formateringskomponenter på ett lämpligt sätt.  
- Ersätta formaterad eller oformaterad text.  
- Tillämpa animationer och använda anslutningar med former.  
- Konvertera ett dokument till PDF, TIFF eller XPS så att det ser ut som om Microsoft PowerPoint gjorde konverteringen.  
- Utveckla en .NET‑ eller Java‑applikation både i skrivbords‑ och webbmiljöer.