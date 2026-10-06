---
title: Översikt över funktioner
type: docs
weight: 104
url: /sv/java/features-overview/
keywords:
- funktioner
- stödda plattformar
- filformat
- konvertering
- rendering
- presentationsinnehåll
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska vad Aspose.Slides för Java omfattar innan du utvärderar det: stödda plattformar, filformat, bildrendering och det innehåll du kan skapa och redigera."
---
## **Översikt**

Aspose.Slides för Java är ett klassbibliotek för att skapa, läsa, redigera, konvertera och rendera PowerPoint‑ och OpenDocument‑presentationer. Det har inget eget användargränssnitt och kräver ingen Microsoft PowerPoint eller Microsoft Office. Denna artikel sammanfattar vad biblioteket täcker och länkar till artiklarna som beskriver varje område.

## **Stödda plattformar**

Aspose.Slides för Java är en enda JAR‑fil, publicerad i Asposes Maven‑arkiv med `jdk16`‑klassificeraren. Den är skriven i ren Java: JAR‑filen innehåller inga inhemska bibliotek och den är inte beroende av andra paket.

- **Java:** Java 8 eller senare. Aspose.Slides för Java 26.9 och tidigare versioner kör även på Java 6 och 7, vilket version 26.10 inte längre stöder; se [26.9 release notes](https://releases.aspose.com/slides/sv/java/release-notes/2026/aspose-slides-for-java-26-9-release-notes/).
- **Operativsystem:** vilket operativsystem som helst med en Java‑runtime, såsom Windows, Linux och macOS. På Linux måste fontconfig‑biblioteket och minst ett teckensnitt vara installerade.

[Installation](/slides/sv/java/installation/) visar hur du lägger till biblioteket i ett projekt och listar Linux‑förutsättningarna. [System Requirements](/slides/sv/java/system-requirements/) listar de stödda plattformarna i detalj.

## **Filformat och konverteringar**

Aspose.Slides öppnar och sparar PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP och PowerPoint‑XML‑presentationer. Det importerar PDF‑ och HTML‑innehåll till bilder, och sparar presentationer som PDF, XPS, HTML, HTML5, TIFF, animerad GIF, SWF, Markdown och XAML. [Supported File Formats](/slides/sv/java/supported-file-formats/) listar varje format med det API som läser eller skriver det.

|**Funktion**|**Beskrivning**|
| :- | :- |
|[PPT och PPTX](/slides/sv/java/ppt-vs-pptx/)|Läs och skriv både det binära PowerPoint‑formatet 97‑2003 och Office Open XML‑formatet.|
|[PPT till PPTX‑konvertering](/slides/sv/java/convert-ppt-to-pptx/)|Konvertera äldre PPT‑presentationer till PPTX.|
|[ODP till PPTX‑konvertering](/slides/sv/java/convert-odp-to-pptx/)|Öppna och spara ODP‑, OTP‑ och FODP‑presentationer samt konvertera ODP‑presentationer till PPTX.|
|[Portable Document Format (PDF)](/slides/sv/java/convert-powerpoint-to-pdf/)|Exportera presentationer till PDF, inklusive PDF/A‑ och PDF/UA‑dokument.|
|[XML Paper Specification (XPS)](/slides/sv/java/convert-powerpoint-to-xps/)|Exportera presentationer till XPS‑dokument.|
|[Tagged Image File Format (TIFF)](/slides/sv/java/convert-powerpoint-to-tiff/)|Exportera presentationer till flersidiga TIFF‑bilder, en sida per bild.|
|[HTML](/slides/sv/java/convert-powerpoint-to-html/)|Exportera presentationer till HTML och HTML5.|
|[PDF‑ och HTML‑import](/slides/sv/java/import-presentation/)|Skapa bilder från PDF‑sidor och HTML‑innehåll.|

## **Rendera presentationer**

Aspose.Slides renderar bilder och enskilda former som PNG-, JPEG-, BMP-, GIF-, TIFF- och SVG‑bilder samt bilder som EMF‑metafiler. Se [Konvertera presentationsbilder till bilder](/slides/sv/java/convert-slide/), [Rendera presentationsbilder som SVG‑bilder](/slides/sv/java/render-a-slide-as-an-svg-image/), och [Skapa miniatyrbilder av presentationsformer](/slides/sv/java/create-shape-thumbnails/).

## **Innehållsfunktioner**

Aspose.Slides låter dig skapa, läsa och ändra nästan allt innehåll i en presentation:

|**Område**|**Vad du kan göra**|
| :- | :- |
|[Bilder](/slides/sv/java/presentation-slide/)|Lägg till, klona, ändra ordning och ta bort bilder; applicera layouter och master‑bilder; organisera bilder i sektioner; ändra bildstorlek.|
|[Design](/slides/sv/java/presentation-design/)|Ställ in bakgrunder, temafärger, sidhuvuden och sidfötter samt teckensnitt.|
|[Text](/slides/sv/java/manage-text/)|Skapa och redigera textramar, stycken och delar; ställ in teckensnitt, färger, punktlistor och justering; hitta och ersätt text.|
|[Former](/slides/sv/java/powerpoint-shapes/)|Skapa AutoShapes, linjer, anslutningar, gruppera former och bildramar; ställ in position, storlek, linje samt fyllning (solid, gradient eller mönster); hitta en form via dess alternativa text.|
|[Tabeller](/slides/sv/java/powerpoint-table/), [diagram](/slides/sv/java/powerpoint-charts/), och [SmartArt](/slides/sv/java/powerpoint-smartart/)|Skapa och redigera tabeller, Microsoft Office‑diagram och SmartArt‑diagram.|
|[Media](/slides/sv/java/manage-media-files/), [OLE‑objekt](/slides/sv/java/manage-ole/), och [ActiveX‑kontroller](/slides/sv/java/activex/)|Lägg till inbäddade eller länkade ljud‑ och videoramar, bädda in OLE‑objekt samt lägg till, ändra eller ta bort ActiveX‑kontroller.|
|[Anteckningar](/slides/sv/java/presentation-notes/) och [kommentarer](/slides/sv/java/presentation-comments/)|Lägg till, läs och redigera talaranteckningar och granskningskommentarer.|
|[Animation](/slides/sv/java/powerpoint-animation/) och [övergångar](/slides/sv/java/slide-transition/)|Applicera animeringseffekter på former, ställ in bildövergångar och konfigurera bildspelsinställningar.|
|[Säkerhet](/slides/sv/java/presentation-security/)|Kryptera presentationer med ett lösenord, ställ in skrivskydd och arbeta med [digitala signaturer](/slides/sv/java/digital-signature-in-powerpoint/).|
|[VBA‑makron](/slides/sv/java/presentation-via-vba/)|Lägg till, extrahera och ta bort VBA‑moduler i makroaktiverade presentationer.|
|[Egenskaper](/slides/sv/java/presentation-properties/)|Läs och redigera dokumentegenskaper.|

## **Vanliga frågor**

**Behöver jag installera Microsoft PowerPoint på servern eller PC:n för att biblioteket ska fungera?**

Nej. PowerPoint krävs inte; Aspose.Slides är en fristående motor för att skapa, redigera, konvertera och rendera presentationer.

**Hur fungerar multitrådad bearbetning? Kan bearbetning parallelliseras?**

Det är säkert att bearbeta olika dokument i olika trådar; samma [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑objekt får inte användas av [multiple threads](/slides/sv/java/multithreading/) samtidigt.

**Stöds fillösenord och kryptering?**

Ja. [Du kan](/slides/sv/java/password-protected-presentation/) öppna krypterade presentationer, sätta eller ta bort ett öppnings‑ och skrivlösenord samt kontrollera skyddsstatusen.

**Måste jag ta hänsyn till teckensnitt i Linux‑behållare?**

Ja. På Linux måste fontconfig‑biblioteket och minst ett teckensnitt vara installerade, och de teckensnitt som används i dina presentationer, eller lämpliga ersättare, måste finnas för att text ska renderas korrekt. Du kan också [specify font directories](/slides/sv/java/custom-font/) i din applikation. Se [Installation](/slides/sv/java/installation/#linux).

**Finns det begränsningar i utvärderingsversionen?**

Ja. Utan en [licens](/slides/sv/java/licensing/) lägger Aspose.Slides till ett utvärderingsvattenstämpel på varje bild den sparar och trunkerar text som din kod läser via API‑et. En [30‑dagars tillfällig licens](https://purchase.aspose.com/temporary-license/) finns tillgänglig för fullständig funktionstestning.

**Stöds import av externa format till en presentation (PDF eller HTML till PPTX)?**

Ja. Du kan lägga till [PDF‑sidor och HTML‑innehåll](/slides/sv/java/import-presentation/) i en presentation och omvandla dem till bilder.