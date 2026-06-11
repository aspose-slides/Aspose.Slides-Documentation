---
title: Stödda filformat
type: docs
weight: 30
url: /sv/nodejs-java/supported-file-formats/
keywords:
- filformat
- stött format
- PPT
- POT
- PPS
- PPTX
- POTX
- PPSX
- PPTM
- PPSM
- POTM
- ODP
- FODP
- OTP
- TIFF
- EMF
- PDF
- XPS
- JPEG
- PNG
- GIF
- BMP
- SVG
- SWF
- HTML
- XAML
- MD
- XML
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck alla filformat som Aspose.Slides för Node.js via Java kan öppna, spara och konvertera — inklusive PPT, PPTX och ODP — med tydliga anteckningar om import/exportsstöd."
---
## **Översikt**

Aspose.Slides stöder presentationsfiler från Microsoft PowerPoint 97 till Office 365, inklusive Microsoft PowerPoint för Mac. Den här artikeln listar de PowerPoint-versioner som stöds av biblioteket och tillhandahåller en tabell med filformat som kan laddas, sparas eller båda.

Artikeln svarar också på vanliga frågor om PDF‑kompatibilitet, inbäddning av teckensnitt, lösenordsskyddade filer, anpassade teckensnitt, teckensnittsfallback och XPS‑exportalternativ.

## **Supporterade Microsoft PowerPoint-versioner**
- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for MAC
- Office 365

## **Supporterade filformat**
Den här tabellen innehåller de filformat som Aspose.Slides för Node.js via Java kan läsa och skriva:

|**Format**|**Beskrivning**|**Läsa**|**Spara**|**Anmärkningar**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003‑presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003‑mall|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003‑show|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint‑presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint‑mall|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint‑show|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Makroaktiverad PowerPoint‑presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Makroaktiverad PowerPoint‑show|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTM](https://docs.fileformat.com/presentation/potm/)|Makroaktiverad PowerPoint‑mall|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument‑presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument‑presentationmall|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tag Image File Format||{{< emoticons/tick >}}||
|[EMF](https://docs.fileformat.com/image/emf/)|Förbättrat Metafilformat||{{< emoticons/tick >}}||
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification||{{< emoticons/tick >}}||
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group||{{< emoticons/tick >}}||
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics||{{< emoticons/tick >}}||
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format||{{< emoticons/tick >}}||
|[BMP](https://docs.fileformat.com/image/bmp/)|Device Independent Bitmap||{{< emoticons/tick >}}||
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics||{{< emoticons/tick >}}||
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format||{{< emoticons/tick >}}||
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language||{{< emoticons/tick >}}||
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown||{{< emoticons/tick >}}||
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML‑presentation||{{< emoticons/tick >}}||

## **Vanliga frågor**

**Kan jag spara presentationer till PDF som uppfyller arkiverings- och tillgänglighetsstandarder (PDF/A och PDF/UA)?**

Ja. Aspose.Slides stöder export till PDF med efterlevnadsnivåer såsom PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b samt PDF/UA via inställningen [compliance](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pdfoptions/setcompliance/) i [PDF export options](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pdfoptions/).

**Stöder biblioteket inbäddning av teckensnitt vid export till PDF, med finmaskig kontroll över vad som inbäddas?**

Ja. Du kan kontrollera om teckensnitt är helt inbäddade eller delvis inbäddade (endast använda tecken), ange hur vanliga systemteckensnitt behandlas och konfigurera beteende för ASCII‑text via [PDF export options](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pdfoptions/).

**Kan jag upptäcka om en fil är lösenordsskyddad innan den faktiskt laddas?**

Ja. Med hjälp av [factory-based inspection API](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationfactory/) kan du fråga en presentationsfil för att avgöra om den är lösenordsskyddad utan att öppna den helt.

**Finns det mekanismer för teckensnittsfallback och stöd för anpassade teckensnitt?**

Ja. Biblioteket stöder [loading](/slides/sv/nodejs-java/custom-font/) och [embedding](/slides/sv/nodejs-java/embedded-font/) av anpassade teckensnitt och tillhandahåller teckensnitt [fallback rules](/slides/sv/nodejs-java/fallback-font/) för att förhindra saknade tecken vid rendering och konvertering.

**Kan jag exportera bilder till XPS, och finns det alternativ för att justera XPS‑utdata?**

Ja. [Export to XPS](/slides/sv/nodejs-java/convert-powerpoint-to-xps/) stöds, och du kan justera relevanta [save options](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xpsoptions/) för att kontrollera kvalitet och innehåll i XPS‑dokumentet.