---
title: Ondersteunde bestandsformaten
type: docs
weight: 96
url: /nl/net/supported-file-formats/
keywords:
- ondersteunde bestandsformaten
- presentatie laden
- PDF importeren
- HTML importeren
- presentatie opslaan
- dia's renderen
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- .NET
- C#
- Aspose.Slides
description: "Bekijk welke bestandsformaten Aspose.Slides for .NET kan laden, importeren, opslaan en renderen, en welke API elk formaat leest of schrijft."
---
## **Overzicht**

Aspose.Slides for .NET opent en slaat PowerPoint‑ en OpenDocument‑presentaties op. Het kan tevens PDF‑ en HTML‑inhoud importeren in dia’s, presentaties opslaan naar document‑, web‑ en afbeeldingsformaten, en individuele dia’s en vormen renderen als afbeeldingen. Dit artikel geeft een overzicht van elk ondersteund formaat en benoemt de API die het leest of schrijft.

Beide NuGet‑pakketten, Aspose.Slides.NET en Aspose.Slides.NET6.CrossPlatform, ondersteunen dezelfde formaten; zie [Installation](/slides/nl/net/installation/) om er één te kiezen. Voor een overzicht van bewerkingsfuncties, zie [Features Overview](/slides/nl/net/features-overview/).

## **Ondersteunde Microsoft PowerPoint‑versies**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (voorheen Office 365)

{{% alert color="info" title="Note" %}}

Presentaties die opgeslagen zijn met PowerPoint 95 of eerdere versies kunnen niet geopend worden. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) herkent een PowerPoint 95‑bestand en rapporteert `LoadFormat.Ppt95`, maar de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)‑constructor gooit een [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) hiervoor.

{{% /alert %}}

## **Ondersteunde bestandsformaten**

De tabel gebruikt vier bewerkingen:

- **Laden**: de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)‑constructor opent het bestand als een bewerkbare presentatie.
- **Importeren**: een [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/)‑methode maakt dia’s van de bestandsinhoud en voegt ze toe aan een bestaande presentatie. De Presentation‑constructor laadt deze bestanden niet als presentaties.
- **Opslaan**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) schrijft de presentatie naar een bestand of stream. Elk formaat behalve XAML wordt geselecteerd met een [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)‑waarde.
- **Renderen**: een render‑methode tekent een dia of een vorm als afbeelding. Formaten die uitsluitend gerenderd worden zijn geen SaveFormat‑waarden.

|**Formaat**|**Beschrijving**|**Laden / Importeren**|**Opslaan / Renderen**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint‑presentatie 97‑2003|Laden|Opslaan|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint‑sjabloon 97‑2003|Laden|Opslaan|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint‑diavoorstelling 97‑2003|Laden|Opslaan|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint‑presentatie|Laden|Opslaan|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint‑sjabloon|Laden|Opslaan|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint‑diavoorstelling|Laden|Opslaan|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint‑macro‑enabled presentatie|Laden|Opslaan|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint‑macro‑enabled sjabloon|Laden|Opslaan|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint‑macro‑enabled diavoorstelling|Laden|Opslaan|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument‑presentatie|Laden|Opslaan|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat XML OpenDocument‑presentatie|Laden|Opslaan|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument‑presentatiesjabloon|Laden|Opslaan|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint‑XML‑presentatie|Laden|Opslaan|`SaveFormat.Xml`; geladen bestanden rapporteren `SourceFormat.Xml` (er is geen `LoadFormat`‑waarde)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Importeren|Opslaan|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Importeren|Opslaan|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Opslaan|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Opslaan, Renderen|`SaveFormat.Tiff`; `ImageFormat.Tiff` (één dia)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Opslaan, Renderen|`SaveFormat.Gif` (geanimeerd, alle dia’s); `ImageFormat.Gif` (één dia)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Opslaan|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Opslaan|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Opslaan|`Presentation.Save(IXamlOptions)`, één XAML‑bestand per dia; geen `SaveFormat`‑waarde|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Renderen|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG‑afbeelding|—|Renderen|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap‑afbeelding|—|Renderen|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Renderen|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Renderen|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Laden en importeren**

- **Laden:** Geef een pad of een stream door aan de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)‑constructor. Het formaat wordt gedetecteerd uit de inhoud; [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) levert instellingen zoals een wachtwoord. Om een bestand vóór het openen te controleren, roep je [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) aan, die een [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/)‑waarde rapporteert. Voor PowerPoint‑XML rapporteert het `LoadFormat.Unknown`, maar de constructor opent zo’n bestand wel, en [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) retourneert vervolgens `SourceFormat.Xml`. Zie [Open Presentations](/slides/nl/net/open-presentation/) en [Determine the Original Presentation Format](/slides/nl/net/detect-presentation-source-format/).
- **Importeren:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) voegt één dia per PDF‑pagina toe aan het einde van een presentatie. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) voegt dia’s toe die uit HTML zijn gemaakt, en [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) plaatst ze op een opgegeven positie. De Presentation‑constructor importeert niet: hij gooit een [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) voor een PDF‑bestand en converteert HTML‑markering niet naar dia‑inhoud. Zie [Import Presentations from PDF or HTML](/slides/nl/net/import-presentation/).

## **Opslaan en renderen**

- **Opslaan:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) schrijft de presentatie in het formaat van een [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)‑waarde. Overloads die bovendien een options‑object accepteren bepalen de output, bijvoorbeeld [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), en [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). Overloads die een array van dia‑posities (beginnend bij 1) ontvangen, schrijven alleen die dia’s; ze accepteren PDF, XPS, TIFF, HTML, HTML5, SWF, GIF en Markdown, maar niet de presentatieformaten of PowerPoint‑XML. XAML heeft een eigen overload die [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/) accepteert. Zie [Save Presentations](/slides/nl/net/save-presentation/), [Convert Presentations](/slides/nl/net/convert-presentation/) en [Export Presentations to XAML](/slides/nl/net/export-to-xaml/).
- **Renderen:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) en [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) retourneren een [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), en [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) schrijft deze als PNG, JPEG, BMP, GIF of TIFF, geselecteerd met een [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)‑waarde. [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) renderen alle dia’s of geselecteerde dia’s in één keer. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) en [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) schrijven SVG, en [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) schrijft EMF. Zie [Convert Presentation Slides to Images](/slides/nl/net/convert-slide/) en [Render a Slide as an SVG Image](/slides/nl/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat bevat ook de waarden `Emf`, `Wmf`, `Icon`, `Exif` en `MemoryBmp`, maar IImage.Save produceert die formaten niet: het bestand dat geschreven wordt bevat PNG‑data. Gebruik Slide.WriteAsEmf om een EMF‑afbeelding van een dia te krijgen.

{{% /alert %}}

## **FAQ**

**Kan ik een PPT‑presentatie omzetten naar PPTX of ODP?**

Ja. Open het PPT‑bestand met de Presentation‑constructor en sla het op met `SaveFormat.Pptx` of `SaveFormat.Odp`. Zie [Convert PPT to PPTX](/slides/nl/net/convert-ppt-to-pptx/).

**Kan ik een PDF‑ of HTML‑bestand openen als presentatie?**

Nee. Maak of open een presentatie, importeer de PDF‑pagina’s of HTML‑inhoud met de hierboven beschreven SlideCollection‑methoden, en sla vervolgens op in elk ondersteund formaat.

**Kan ik een geëxporteerde PNG‑ of SVG‑afbeelding laden als bewerkbare presentatie?**

Nee. Een afbeelding legt alleen vast hoe een dia eruitziet, niet de tekst, vormen of grafieken. Bewaar de originele presentatie als je later wilt bewerken.

**Kan ik PDF/A‑ of PDF/UA‑documenten opslaan?**

Ja. Stel [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) in op een [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/)‑waarde: PDF/A‑1a, PDF/A‑1b, PDF/A‑2a, PDF/A‑2b, PDF/A‑2u, PDF/A‑3a, PDF/A‑3b, of PDF/UA.

**Kan ik controleren of een bestand met een wachtwoord beschermd is voordat ik het open?**

Ja. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) inspecteert een bestand zonder een Presentation‑object te maken, en de eigenschap [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/) geeft aan of een wachtwoord nodig is. Zie [Password‑Protect Presentations](/slides/nl/net/password-protected-presentation/).

**Ondersteunen de twee NuGet‑pakketten verschillende formaten?**

Nee. Aspose.Slides.NET en Aspose.Slides.NET6.CrossPlatform hebben dezelfde LoadFormat‑ en SaveFormat‑waarden en dezelfde import‑ en rendermethoden. Ze verschillen in de platforms waarop ze draaien en in wat die platforms nodig hebben; zie [Installation](/slides/nl/net/installation/).