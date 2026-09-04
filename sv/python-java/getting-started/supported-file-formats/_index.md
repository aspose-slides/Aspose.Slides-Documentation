---
title: Stödda filformat
type: docs
weight: 30
url: /sv/python-java/supported-file-formats/
keywords:
- stödda filformat
- presentationsformat
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- bildspelsbilder
- Python
- Aspose.Slides for Python via Java
description: "Utforska de presentations-, dokument-, webb- och bildformat som Aspose.Slides for Python via Java kan läsa, importera, spara och exportera."
---
## **Översikt**

Aspose.Slides för Python via Java läser och skriver PowerPoint- och OpenDocument‑presentationer. Det kan också importera PDF‑ och HTML‑innehåll till bildspel och exportera presentationer eller enskilda bildspel till dokument‑, webb‑ och bildformat.

Tabellen nedan skiljer på presentationens inläsning, innehållsimport och bildrendering. För en översikt över redigerings‑ och renderingsmöjligheter, se [Features Overview](/slides/sv/python-java/features-overview/).

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
- Microsoft PowerPoint för Mac
- PowerPoint för Microsoft 365 (tidigare Office 365)


## **Stödda filformat**

Följande tabell listar stödda in‑ och utdataformat. **Läs / Importera** omfattar öppning av presentationsfiler samt import av PDF‑ eller HTML‑innehåll. **Spara / Exportera** omfattar sparande av presentationer och renderning av bildspel till bildfiler. Ett bindestreck betyder att den motsvarande operationen inte stöds som en presentationskonvertering.

|**Format**|**Beskrivning**|**Läs / Importera**|**Spara / Exportera**|**Anmärkningar**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003‑presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003‑mall|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003‑show|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint‑presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint‑mall|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint‑show|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint makro‑aktiverad presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint makro‑aktiverad show|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint makro‑aktiverad mall|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument‑presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Paketerat OpenDocument‑format.|
|FODP|Flat XML OpenDocument‑presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Lagrar presentationen som ett enda XML‑dokument.|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument‑presentationsmall|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|{{< emoticons/tick >}}|Stöder flersidig utdata.|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|{{< emoticons/tick >}}|Exporterar enskilda bildspel som vektorbilder.|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|{{< emoticons/tick >}}|Importerar PDF‑sidor som bildspel; exporterar presentationer till PDF.|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|{{< emoticons/tick >}}|Fast layout‑dokumentutgång.|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG‑bild|—|{{< emoticons/tick >}}|Renderar enskilda bildspel som rasterbilder.|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|{{< emoticons/tick >}}|Renderar enskilda bildspel som rasterbilder.|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|{{< emoticons/tick >}}|Bildutgång.|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap‑bild|—|{{< emoticons/tick >}}|Renderar enskilda bildspel som rasterbilder.|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|{{< emoticons/tick >}}|Exporterar enskilda bildspel som vektorbilder.|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format|—|{{< emoticons/tick >}}|Flash‑utdata.|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|{{< emoticons/tick >}}|Importerar HTML‑innehåll som bildspel; stöder export till HTML och HTML5.|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|{{< emoticons/tick >}}|Exporterar presentationsinnehåll som XAML.|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|{{< emoticons/tick >}}|Exporterar presentationsinnehåll till Markdown.|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML‑presentation|—|{{< emoticons/tick >}}|PowerPoint‑specifik XML‑utdata, inte godtycklig XML.|

## **Import‑ och exportanteckningar**

- **PDF- och HTML-import:** Använd [SlideCollection.addFromPdf](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addfrompdf) eller [SlideCollection.addFromHtml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addfromhtml) för att skapa bildspel från källinnehåll och lägga till dem i en presentation.
- **Presentationsexport:** [SaveFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/) listar de tillgängliga spara‑formaten för presentationer, inklusive separata HTML‑ och HTML5‑exportalternativ.
- **Bildexport:** Att exportera ett bildspel till en bild ger en visuell representation av bildspelet. Inmatningskolumnen beskriver inte huruvida en bild kan infogas i en presentation.

## **Vanliga frågor**

**Kan jag konvertera en PPT-presentation till PPTX eller ODP?**

Ja. PPT stöds som indataformat, och både PPTX och ODP stöds som utdataformat. Konverteringsresultatet beror på vilka funktioner som finns tillgängliga i målformatet.

**Öppnar PDF‑ eller HTML-import källan som en PowerPoint‑fil?**

Nej. Import skapar bildspel från PDF‑sidor eller HTML‑innehåll. Du kan sedan spara den resulterande presentationen i ett stödd presentationsformat.

**Kan jag läsa in en exporterad PNG eller SVG som en redigerbar presentation?**

Nej. Dessa exporter visar endast bildspelets utseende. Behåll originalpresentationen när du senare behöver redigera dess text, former, diagram och andra objekt.