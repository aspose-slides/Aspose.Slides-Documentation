---
title: Varför inte Open XML SDK
type: docs
weight: 50
url: /sv/net/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- jämförelse
- presentationsobjektmodell
- konvertering med hög kvalitet
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Se varför Aspose.Slides är ett bättre val än det fria Open XML SDK: jämför funktioner, konvertering utan automatisering och brett stöd för PPT, PPTX och ODP."
---
## **Översikt**

Denna artikel förklarar när utvecklare kan välja Open XML SDK eller Aspose.Slides för att arbeta med presentationsdokument. Den beskriver Open XML SDK som ett bibliotek för att manipulera OOXML‑paket och deras underliggande XML‑element, medan Aspose.Slides presenteras som ett presentationsbearbetningsbibliotek med en hög‑nivå objektmodell och stöd för många PowerPoint‑relaterade uppgifter.

Artikeln jämför båda alternativen utifrån stödda format, programmeringsmodell, renderings‑ och utskriftsfunktioner, plattformsstöd och vanliga användningsfall. Den klargör också att Open XML SDK kan vara lämpligt för grundläggande PPTX‑operationer eller direkt åtkomst till OOXML‑element, medan Aspose.Slides är mer lämpligt för komplexa presentationer såsom arbete med flera PowerPoint‑format, kopiering eller kloning av former, ersättning av text, tillämpning av animationer och konvertering av presentationer till PDF, TIFF eller XPS.

## **Vad är Open XML SDK?**
Ibland får vi frågan: *Varför ska vi använda Aspose‑produkter istället för det fria Open XML SDK?* 

Vi finner det enkelt att svara på denna fråga i termer av funktioner och möjligheter. 

Enligt [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) definieras Open XML SDK så här: 

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **Vad är Aspose.Slides?**
Aspose.Slides är ett klassbibliotek som låter applikationer utföra följande presentationsbearbetningsuppgifter: 

- Programmering med en presentationsobjektmodell.

- Högkvalitativa konverteringar som omfattar alla populära stödjade PowerPoint‑format, inklusive konvertering till PDF, XPS, TIFF och utskrift.

- Generering av bildminiatyrer i välkända format såsom PNG, JPEG och BMP samt export av bilder till SVG.

- Bygga presentationer från grunden eller genom att kombinera element från ett eller flera dokument.

- Lägga till animationer, OLE‑ramar, tabeller, skapa och hantera diagram.

- Kontrollera (omfattande kontroll) och hantera textformatering på TextFrames‑, Paragraph‑ och Portionsnivå. 

  För mer information om de tillgängliga funktionerna, se [Aspose.Slides Features](/slides/sv/net/product-overview/) sidan.

## **Jämför Open XML SDK med Aspose.Slides**
Denna tabell jämför Open XML SDK:s möjligheter och funktioner med Aspose.Slides.

|**Funktion eller Funktionskategori**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Stödda presentationsformat|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertering från PPT till PPTX|Nej|Ja|
|<p>Hög‑nivå programmering med ett Presentation Document Object Model (DOM): </p><p>- Söka och ersätta text.</p><p>- Sammanställa bilder i presentationer.</p>|Nej|Ja|
|Detaljerad programmering med ett dokumentobjektmodell; åtkomst till enskilda element och formatering såsom TextHolders, TextFrames, Paragraphs och Portions.|Ja|Ja|
|Låg‑nivå direkt och fullständig åtkomst till underliggande XML‑element och attribut såsom relationsidentifierare, listidentifierare i ett OOXML‑dokument.|Ja|Nej|
|<p>Rendering och utskrift:</p><p>- Rendera presentationer till PDF, PDF‑Notes, XPS, TIFF‑bilder.</p><p>- Rendera bildminiatyrer till PNG, JPEG, BMP, SVG och TIFF.</p><p>- Specificera bildupplösning, kvalitet, komprimering och andra alternativ.</p><p>- Skriva ut presentationer med .NET‑utskriftsinfrastrukturen. Komponenten har inbyggd utskriftsmetod för att skriva ut presentationer som visas i Utskriftsförhandsgranskning i MS PowerPoint.</p>|Nej|Ja|
|Stödda plattformar|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Slutsats**
Open XML SDK och Aspose.Slides konkurrerar inte direkt eftersom de adresserar avsevärt olika behov och riktar sig till olika målgrupper. 

{{% alert color="primary" %}} 

Open XML SDK är ett klassbibliotek som erbjuder ett starkt typat sätt att arbeta med OOXML‑dokument medan Aspose.Slides är ett otroligt användbart presentationsbearbetningsbibliotek som ger omfattande stöd för nästan alla Microsoft PowerPoint‑filformat. 

{{% /alert %}} 

Om ditt arbetsflöde är en grundläggande programmeringsoperation på ett PPTX‑dokument, kan Open XML SDK vara ett bra val. Med Open XML SDK bör du kunna utföra enkla uppgifter som att generera ett enkelt PPTX‑dokument eller ta bort kommentarer, sidhuvud/sidfot, extrahera bilder eller liknande. Vissa uppgifter kan utföras med Open XML SDK men inte med Aspose.Slides. Till exempel, om du behöver direkt åtkomst till XML‑element och attribut i ett OOXML‑dokument, bör du använda Open XML SDK. 

Om du behöver utföra komplexa uppgifter på dokument—såsom uppgifterna i listan nedan—är Aspose.Slides ditt bästa alternativ. 

- Operationer som involverar äldre PowerPoint‑format (och PPTX också).  
- Kopiering eller kloning av former inom bilder på ett sätt som kombinerar objekt, stilar och andra formateringselement på ett lämpligt sätt.  
- Ersätta formaterad eller icke‑formaterad text.  
- Tillämpa animationer och använda kopplingar med former.  
- Konvertera ett dokument till PDF, TIFF eller XPS så att det ser ut som om Microsoft PowerPoint gjorde konverteringen.  
- Utveckla en .NET‑ eller Java‑applikation i både skrivbords‑ och webbmiljöer.