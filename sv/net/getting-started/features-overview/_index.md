---
title: Översikt över funktioner
type: docs
weight: 94
url: /sv/net/features-overview/
keywords:
- funktioner
- stödda plattformar
- filformat
- konvertering
- rendering
- presentationens innehåll
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska vad Aspose.Slides for .NET omfattar innan du utvärderar det: stödda plattformar, filformat, bildrendering och det innehåll du kan skapa och redigera."
---
## **Översikt**

Aspose.Slides for .NET är ett klassbibliotek för att skapa, läsa, redigera, konvertera och rendera PowerPoint‑ och OpenDocument‑presentationer. Det har inget eget användargränssnitt och kräver inte Microsoft PowerPoint eller Office, så du kan använda det i konsolprogram, skrivbordsprogram som Windows Forms, webbprogram och webbtjänster. Den här artikeln sammanfattar vad biblioteket täcker och länkar till artiklarna som beskriver varje område.

## **Stödda plattformar**

Aspose.Slides for .NET distribueras som två NuGet‑paket med samma API:

|**Paket**|**Byggningar i paketet**|**Operativsystem**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0 och .NET 6. Använd med .NET Framework 4.6.2 eller senare, eller med .NET 6 eller senare.|Windows. Linux och macOS med `libgdiplus`‑biblioteket och växeln `System.Drawing.EnableUnixSupport`.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. Använd med .NET 6 eller senare.|Windows (x86, x64), Linux (x64 med glibc 2.23 eller senare, ARM64 med glibc 2.39 eller senare) och macOS (x64, ARM64).|

[Installation](/slides/sv/net/installation/) förklarar vilket paket du ska välja och vad varje paket kräver på Linux. [Systemkrav](/slides/sv/net/system-requirements/) listar de stödda plattformarna i detalj.

## **Filformat och konverteringar**

Aspose.Slides öppnar och sparar PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP och PowerPoint‑XML‑presentationer. Det importerar PDF‑ och HTML‑innehåll till bilder och sparar presentationer som PDF, XPS, HTML, HTML5, TIFF, animerad GIF, SWF, Markdown och XAML. [Stödda filformat](/slides/sv/net/supported-file-formats/) listar varje format med det API som läser eller skriver det.

|**Funktion**|**Beskrivning**|
| :- | :- |
|[PPT och PPTX](/slides/sv/net/ppt-vs-pptx/)|Läs och skriv både det binära PowerPoint‑97‑2003‑formatet och Office Open XML‑formatet.|
|[PPT‑till‑PPTX‑konvertering](/slides/sv/net/convert-ppt-to-pptx/)|Konvertera äldre PPT‑presentationer till PPTX.|
|[Portable Document Format (PDF)](/slides/sv/net/convert-powerpoint-to-pdf/)|Exportera presentationer till PDF, inklusive PDF/A‑ och PDF/UA‑dokument.|
|[XML Paper Specification (XPS)](/slides/sv/net/convert-powerpoint-to-xps/)|Exportera presentationer till XPS‑dokument.|
|[Tagged Image File Format (TIFF)](/slides/sv/net/convert-powerpoint-to-tiff/)|Exportera presentationer till TIFF‑bilder.|
|[HTML](/slides/sv/net/convert-powerpoint-to-html/)|Exportera presentationer till HTML och HTML5.|
|[PDF‑ och HTML‑import](/slides/sv/net/import-presentation/)|Skapa bilder från PDF‑sidor och HTML‑innehåll.|

## **Rendering av presentationer**

Aspose.Slides renderar bilder och enskilda former som PNG, JPEG, BMP, GIF, TIFF och SVG, samt bilder som EMF‑metafiler. Se [Konvertera presentationsbilder till bilder](/slides/sv/net/convert-slide/), [Rendera en bild som en SVG‑bild](/slides/sv/net/render-a-slide-as-an-svg-image/) och [Skapa miniatyrer för former](/slides/sv/net/create-shape-thumbnails/).

## **Innehållsfunktioner**

Aspose.Slides låter dig skapa, läsa och ändra nästan allt innehåll i en presentation:

|**Område**|**Vad du kan göra**|
| :- | :- |
|[Bilder](/slides/sv/net/presentation-slide/)|Lägg till, klona, omordna och ta bort bilder; tillämpa layouter och masterblad; organisera bilder i avsnitt; ändra bildstorlek.|
|[Design](/slides/sv/net/presentation-design/)|Ställ in bakgrunder, temafärger, sidhuvuden och sidfötter samt teckensnitt.|
|[Text](/slides/sv/net/manage-text/)|Skapa och redigera textramar, stycken och textdelar; ange teckensnitt, färger, punktlistor och justering; sök och ersätt text.|
|[Former](/slides/sv/net/powerpoint-shapes/)|Skapa AutoShapes, linjer, anslutningar, gruppera former och bildramar; ange position, storlek, linje samt solid, gradient‑ eller mönsterfyllning; hitta en form via dess alternativa text.|
|[Tabeller](/slides/sv/net/powerpoint-table/), [diagram](/slides/sv/net/powerpoint-charts/) och [SmartArt](/slides/sv/net/powerpoint-smartart/)|Skapa och redigera tabeller, Microsoft Office‑diagram och SmartArt‑diagram.|
|[Media](/slides/sv/net/manage-media-files/), [OLE‑objekt](/slides/sv/net/manage-ole/) och [ActiveX‑kontroller](/slides/sv/net/activex/)|Lägg till inbäddade eller länkade ljud‑ och videoramper, bädda in OLE‑objekt samt lägga till, modifiera eller ta bort ActiveX‑kontroller.|
|[Anteckningar](/slides/sv/net/presentation-notes/) och [kommentarer](/slides/sv/net/presentation-comments/)|Lägg till, läs och redigera talaranteckningar och granskningskommentarer.|
|[Animation](/slides/sv/net/powerpoint-animation/) och [övergångar](/slides/sv/net/slide-transition/)|Tillämpa animationseffekter på former, ange bildövergångar och konfigurera bildspelsinställningar.|
|[Säkerhet](/slides/sv/net/presentation-security/)|Kryptera presentationer med ett lösenord, ange skrivskydd och arbeta med digitala signaturer.|
|[VBA‑makron](/slides/sv/net/presentation-via-vba/)|Lägg till, extrahera och ta bort VBA‑moduler i makro‑aktiverade presentationer.|
|[Egenskaper](/slides/sv/net/presentation-properties/)|Läs och redigera dokumentegenskaper.|

## **Vanliga frågor**

**Behöver jag installera Microsoft PowerPoint på servern eller PC:n för att biblioteket ska fungera?**

Nej. PowerPoint krävs inte; Aspose.Slides är en fristående motor för att skapa, redigera, konvertera och rendera presentationer.

**Hur fungerar trådad körning? Kan bearbetning parallelliseras?**

Det är säkert att bearbeta olika dokument i olika trådar; samma [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑objekt får inte användas av [flera trådar](/slides/sv/net/multithreading/) samtidigt.

**Stöds fillösenord och kryptering?**

Ja. [Du kan](/slides/sv/net/password-protected-presentation/) öppna krypterade presentationer, ange eller ta bort ett öppnings‑ och skrivlösenord samt kontrollera skyddstatusen.

**Måste jag ta hänsyn till teckensnitt i Linux‑containrar?**

Ja. De teckensnitt som används i dina presentationer, eller lämpliga ersättningar, måste vara installerade på systemet för att text ska renderas korrekt. Du kan också [ange teckensnittskataloger](/slides/sv/net/custom-font/) i din applikation. [Installation](/slides/sv/net/installation/) listar Linux‑förutsättningarna för varje paket.

**Finns det begränsningar i utvärderingsversionen?**

Ja. Utan en [licens](/slides/sv/net/licensing/) lägger Aspose.Slides till ett vattenstämpel för utvärdering på varje bild som sparas och trunkerar text som läses från presentationer. En [30‑dagars temporär licens](https://purchase.aspose.com/temporary-license/) finns tillgänglig för fullständig funktionstestning.

**Stöds import av externa format till en presentation (PDF eller HTML till PPTX)?**

Ja. Du kan lägga till [PDF‑sidor och HTML‑innehåll](/slides/sv/net/import-presentation/) i en presentation och omvandla dem till bilder.