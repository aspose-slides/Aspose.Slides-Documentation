---
title: Varför Inte Open XML SDK
type: docs
weight: 50
url: /sv/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- jämföra
- presentationsobjektmodell
- konvertering av hög kvalitet
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Se varför Aspose.Slides är ett bättre val än det gratis Open XML SDK: jämför funktioner, automatiseringsfri konvertering och brett stöd för PPT, PPTX och ODP."
---
## **Översikt**

Denna artikel förklarar när utvecklare kan välja Open XML SDK eller Aspose.Slides för att arbeta med presentationsdokument. Den beskriver Open XML SDK som ett bibliotek för att manipulera OOXML‑paket och deras underliggande XML‑element, medan Aspose.Slides presenteras som ett presentationsbearbetningsbibliotek med en hög nivå‑objektmodell och stöd för många PowerPoint‑relaterade uppgifter.

Artikeln jämför båda alternativen utifrån stödda format, programmeringsmodell, renderings‑ och utskriftsmöjligheter, plattformsstöd och vanliga användningsfall. Den klargör också att Open XML SDK kan vara lämpligt för grundläggande PPTX‑operationer eller direkt åtkomst till OOXML‑element, medan Aspose.Slides är mer passande för komplexa presentationsuppgifter såsom arbete med flera PowerPoint‑format, kopiering eller kloning av former, ersättning av text, tillämpning av animationer och konvertering av presentationer till PDF, TIFF eller XPS.

## **Vad är Open XML SDK?**
Ibland får vi frågan: *Varför ska vi använda Aspose‑produkter istället för det gratis‑tillgängliga Open XML SDK?* 

Vi finner det enkelt att svara på den frågan i termer av funktioner och möjligheter. 

Enligt [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) definieras Open XML SDK så här: 

> "Open XML SDK 2.0 förenklar uppgiften att manipulera Open XML‑paket och de underliggande Open XML‑schematelementen inom ett paket. Open XML SDK 2.0 kapslar in många vanliga uppgifter som utvecklare utför på Open XML‑paket, så att du kan utföra komplexa operationer med bara några rader kod. OOXML‑dokument är i princip zip‑ade XML‑filer och Open XML SDK är en samling klasser som låter dig arbeta med innehållet i OOXML‑dokument på ett starkt typat sätt. Det innebär att i stället för att packa upp en fil för att extrahera XML, läsa in den XML:n i ett DOM‑träd och arbeta med XML‑element och attribut direkt, erbjuder Open XML SDK klasser för att göra detta."

## **Vad är Aspose.Slides?**
Aspose.Slides är ett klassbibliotek som låter applikationer utföra dessa presentationsbearbetningsuppgifter: 

- Programmering med en presentationsobjektmodell.  
- Högkvalitativa konverteringar som omfattar alla populära stödjade PowerPoint‑format, inklusive konvertering till PDF, XPS, TIFF och utskrift.  
- Generering av bildminiaturer i välkända format såsom PNG, JPEG och BMP samt export av bilder till SVG.  
- Byggande av presentationer från grunden eller genom att kombinera element från ett eller flera dokument.  
- Tillägg av animationer, OLE‑ramar, tabeller, samt skapande och hantering av diagram.  
- Omfattande kontroll och hantering av textformatering på TextFrames‑, Paragraph‑ och Portion‑nivå.  

För fler detaljer om tillgängliga funktioner, se [Aspose.Slides Features](/slides/sv/net/product-overview/) sidan.

## **Jämför Open XML SDK med Aspose.Slides**
Den här tabellen jämför Open XML SDK:s möjligheter och funktioner med Aspose.Slides.

|**Funktion eller Funktionskategori**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Stödda presentationsformat|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertering från PPT till PPTX|Nej|Ja|
|<p>Hög‑nivå programmering med ett Presentation Document Object Model (DOM): </p><p>- Hitta och ersätt texter.</p><p>- Sammanfoga bilder i presentationer.</p>|Nej|Ja|
|Detaljerad programmering med ett dokument‑objektmodell; åtkomst till enskilda element och formatering såsom TextHolders, TextFrames, Paragraphs och Portions.|Ja|Ja|
|Låg‑nivå direkt och fullständig åtkomst till underliggande XML‑element och attribut såsom relations‑identifierare, list‑identifierare i ett OOXML‑dokument.|Ja|Nej|
|<p>Rendering och utskrift:</p><p>- Rendera presentationer till PDF, PDF‑Notes, XPS, TIFF‑bilder.</p><p>- Rendera bildminiaturer till PNG, JPEG, BMP, SVG och TIFF.</p><p>- Specificera bildupplösning, kvalitet, komprimering och andra alternativ.</p><p>- Skriva ut presentationer med .NET‑utskriftsinfrastrukturen. Komponenten har en inbyggd utskriftsmetod för att skriva ut presentationer som i Utskriftsförhandsgranskning i MS PowerPoint.</p>|Nej|Ja|
|Stödda plattformar|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Slutsats**
Open XML SDK och Aspose.Slides konkurrerar inte direkt eftersom de adresserar väsentligt olika behov och riktar sig till olika målgrupper. 

{{% alert color="primary" %}} 

Open XML SDK är ett klassbibliotek som erbjuder ett starkt typat sätt att arbeta med OOXML‑dokument medan Aspose.Slides är ett otroligt användbart presentationsbearbetningsbibliotek som ger utmärkt stöd för nästan alla Microsoft PowerPoint‑filformat. 

{{% /alert %}} 

Om ditt arbetsflöde är en grundläggande programmeringsoperation på ett PPTX‑dokument, kan Open XML SDK vara ett bra val. Med Open XML SDK bör du känna dig bekväm med att utföra enkla uppgifter som att skapa ett enkelt PPTX‑dokument eller att ta bort kommentarer, sidhuvuden/sidfötter, extrahera bilder eller liknande. Vissa uppgifter kan utföras med Open XML SDK men kan inte utföras med Aspose.Slides. Till exempel, om du behöver direkt åtkomst till XML‑element och attribut i ett OOXML‑dokument, bör du använda Open XML SDK. 

Om du behöver utföra komplexa uppgifter på dokument — såsom uppgifterna i listan nedan — är Aspose.Slides ditt bästa alternativ. 

- Operationer som involverar äldre PowerPoint‑format (och PPTX också).  
- Kopiering eller kloning av former inom bilder på ett sätt som kombinerar objekt, stilar och andra formateringselement på ett lämpligt sätt.  
- Ersättande av formaterad eller oformatterad text.  
- Tillämpning av animationer och användning av anslutningar med former.  
- Konvertering av ett dokument till PDF, TIFF eller XPS så att det ser ut som Microsoft PowerPoint gjorde konverteringen.  
- Utveckling av en .NET‑ eller Java‑applikation i både skrivbords‑ och webbaserade miljöer.