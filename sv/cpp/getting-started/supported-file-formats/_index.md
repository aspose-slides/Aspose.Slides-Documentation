---
title: Stödda filformat
type: docs
weight: 20
url: /sv/cpp/supported-file-formats/
keywords:
- filformat
- stödda format
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
- C++
- Aspose.Slides
description: "Upptäck alla filformat som Aspose.Slides för C++ kan öppna, spara och konvertera — inklusive PPT, PPTX och ODP — med tydliga anteckningar om import/export‑stöd."
---
## **Översikt**

Aspose.Slides stöder presentationsfiler från Microsoft PowerPoint 97 till Office 365, inklusive Microsoft PowerPoint för Mac. Denna artikel listar de PowerPoint‑versioner som stöds av biblioteket och ger en tabell över filformat som kan läsas in, sparas eller både och.

Artikeln svarar också på vanliga frågor om PDF‑kompatibilitet, inbäddning av teckensnitt, lösenordsskyddade filer, anpassade teckensnitt, teckensnittsfallback och XPS‑exportalternativ.

## **Stödda Microsoft PowerPoint‑versioner**
- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint för MAC
- Office 365

## **Stödda filformat**
Denna tabell innehåller de filformat som Aspose.Slides för С++ kan läsa in och spara:

|**Format**|**Beskrivning**|**Läs in**|**Spara**|**Kommentarer**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint‑presentation 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint‑mall 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint‑show 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint‑presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint‑mall|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint‑show|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint‑presentation med makron|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint‑show med makron|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint‑mall med makron|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument‑presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument‑mall för presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tag Image File Format||{{< emoticons/tick >}}||
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile Format||{{< emoticons/tick >}}||
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

**Kan jag spara presentationer till PDF som uppfyller arkiverings‑ och tillgänglighetsstandarder (PDF/A och PDF/UA)?**

Ja. Aspose.Slides stöder export till PDF med efterlevnadsnivåer såsom PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b samt PDF/UA via inställningen [compliance](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/set_compliance/) i [PDF‑exportalternativ](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/).

**Stöder biblioteket inbäddning av teckensnitt vid export till PDF, med finjusterad kontroll över vad som inbäddas?**

Ja. Du kan kontrollera om teckensnitt skrivs in helt eller som delmängd (endast använda tecken), specificera hur vanliga systemteckensnitt behandlas och konfigurera beteendet för ASCII‑text via [PDF‑exportalternativ](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/).

**Kan jag upptäcka om en fil är lösenordsskyddad innan den faktiskt läses in?**

Ja. Med hjälp av [factory‑based inspection API](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentationfactory/), kan du fråga en presentationsfil för att avgöra om den är lösenordsskyddad utan att öppna den helt.

**Finns det mekanismer för teckensnittsfallback och stöd för anpassade teckensnitt?**

Ja. Biblioteket stöder [laddning](/slides/sv/cpp/custom-font/) och [inbäddning](/slides/sv/cpp/embedded-font/) av anpassade teckensnitt och erbjuder font‑[fallback‑regler](/slides/sv/cpp/fallback-font/) för att förhindra saknade tecken under rendering och konvertering.

**Kan jag exportera bilder till XPS, och finns det alternativ för att finjustera XPS‑utdata?**

Ja. [Export to XPS](/slides/sv/cpp/convert-powerpoint-to-xps/) stöds, och du kan justera relevanta [save options](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/xpsoptions/) för att kontrollera kvaliteten och innehållet i XPS‑dokumentet.