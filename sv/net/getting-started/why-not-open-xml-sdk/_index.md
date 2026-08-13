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

Denna artikel förklarar när utvecklare kan välja Open XML SDK eller Aspose.Slides för att arbeta med presentationsdokument. Den beskriver Open XML SDK som ett bibliotek för att manipulera OOXML‑paket och deras underliggande XML‑element, medan Aspose.Slides presenterar sig som ett presentationsbearbetningsbibliotek med en hög nivå‑objektmodell och stöd för många PowerPoint‑relaterade uppgifter.

Artikeln jämför båda alternativen utifrån stödda format, programmeringsmodell, renderings‑ och utskriftsmöjligheter, plattformsstöd och vanliga användningsfall. Den klargör också att Open XML SDK kan vara lämpligt för enkla PPTX‑operationer eller direkt åtkomst till OOXML‑element, medan Aspose.Slides är mer passande för komplexa presentationsuppgifter såsom arbete med flera PowerPoint‑format, kopiering eller kloning av former, ersättning av text, tillämpning av animationer och konvertering av presentationer till PDF, TIFF eller XPS.

## **Vad är Open XML SDK?**
Ibland får vi den här frågan: *Varför ska vi använda Aspose‑produkter istället för det kostnadsfria Open XML SDK?*  

Vi finner det enkelt att besvara frågan i termer av funktioner och möjligheter.  

Enligt [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) definieras Open XML SDK på följande sätt:  

> "Open XML SDK 2.0 förenklar uppgiften att manipulera Open XML‑paket och de underliggande Open XML‑schematelementen i ett paket. Open XML SDK 2.0 kapslar in många vanliga uppgifter som utvecklare utför på Open XML‑paket, så att du kan utföra komplexa operationer med bara några rader kod. OOXML‑dokument är i princip zip‑ade XML‑filer och Open XML SDK är en samling klasser som låter dig arbeta med innehållet i OOXML‑dokument på ett starkt typat sätt. Det innebär att i stället för att packa upp en fil för att extrahera XML, ladda XML i ett DOM‑träd och arbeta direkt med XML‑element och attribut, tillhandahåller Open XML SDK klasser för att göra detta."

## **Vad är Aspose.Slides?**
Aspose.Slides är ett klassbibliotek som låter applikationer utföra följande presentationsbearbetningsuppgifter:  

- Programmering med en presentationsobjektmodell.  
- Högkvalitativa konverteringar som omfattar alla populära stödda PowerPoint‑presentationsformat, inklusive konvertering till PDF, XPS, TIFF och utskrift.  
- Generering av bildförhandsvisningar i välkända format som PNG, JPEG och BMP samt export av bilder till SVG.  
- Bygga presentationer från grunden eller genom att kombinera element från ett eller flera dokument.  
- Lägga till animationer, OLE‑ramar, tabeller, skapa och hantera diagram.  
- Styrning (omfattande kontroll) och hantering av textformatering på TextFrames‑, Paragraph‑ och Portion‑nivå.  

För mer detaljer om de tillgängliga funktionerna, se sidan [Aspose.Slides Features](/slides/sv/net/product-overview/).

## **Jämför Open XML SDK med Aspose.Slides**
Denna tabell jämför Open XML SDK:s möjligheter och funktioner med Aspose.Slides.

|**Funktion eller Funktionskategori**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Stödda presentationsformat|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertering från PPT till PPTX|Nej|Ja|
|<p>Hög nivå‑programmering med ett Presentation Document Object Model (DOM): </p><p>- Hitta och ersätt texter.</p><p>- Sätt ihop bildspel i presentationer.</p>|Nej|Ja|
|Detaljerad programmering med ett dokumentobjektmodell; åtkomst till enskilda element och formatering såsom TextHolders, TextFrames, Paragraphs och Portions.|Ja|Ja|
|Låg nivå‑direkt och full åtkomst till de underliggande XML‑elementen och attributen såsom relations‑identifierare, list‑identifierare i ett OOXML‑dokument.|Ja|Nej|
|<p>Rendering och utskrift:</p><p>- Rendera presentationer till PDF, PDF‑Notes, XPS, TIFF‑bilder.</p><p>- Rendera bildförhandsvisningar till PNG, JPEG, BMP, SVG och TIFF.</p><p>- Specificera bildupplösning, kvalitet, komprimering och andra alternativ.</p><p>- Skriva ut presentationer med .NET‑utskriftsinfrastruktur. Komponenten har inbyggd utskriftsmetod för att skriva ut presentationer som i Print Preview i MS PowerPoint.</p>|Nej|Ja|
|Stödda plattformar|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Slutsats**
Open XML SDK och Aspose.Slides konkurrerar inte direkt eftersom de adresserar avsevärt olika behov och vänder sig till olika målgrupper.  

{{% alert color="info" %}}  

Open XML SDK är ett klassbibliotek som erbjuder ett starkt typat sätt att arbeta med OOXML‑dokument medan Aspose.Slides är ett otroligt användbart presentationsbearbetningsbibliotek som ger utmärkt stöd för nästan alla Microsoft PowerPoint‑filformat.  

{{% /alert %}}  

Om ditt arbetsflöde är en grundläggande programmeringsoperation på ett PPTX‑dokument, kan Open XML SDK vara ett bra val. Med Open XML SDK bör du känna dig bekväm med att utföra enkla uppgifter som att generera ett enkelt PPTX‑dokument eller ta bort kommentarer, sidhuvuden/sidfötter, extrahera bilder eller liknande. Vissa uppgifter kan utföras med Open XML SDK men inte med Aspose.Slides. Till exempel, om du behöver direkt åtkomst till XML‑element och attribut i ett OOXML‑dokument, bör du använda Open XML SDK.  

Om du behöver utföra komplexa uppgifter på dokument – såsom uppgifterna i listan nedan – är Aspose.Slides ditt bästa alternativ.  

- Operationer som involverar äldre PowerPoint‑format (och PPTX också).  
- Kopiera eller klona former inom bildspel på ett sätt som kombinerar objekt, stilar och andra formateringselement på ett lämpligt sätt.  
- Ersätta formaterad eller oformatterad text.  
- Tillämpa animationer och använda anslutningar med former.  
- Konvertera ett dokument till PDF, TIFF eller XPS så att det ser ut som Microsoft PowerPoint gjorde konverteringen.  
- Utveckla en .NET‑ eller Java‑applikation i både skrivbords‑ och webbaserade miljöer.