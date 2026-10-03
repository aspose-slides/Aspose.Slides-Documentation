---
title: Ondersteunde bestandsindelingen
type: docs
weight: 106
url: /nl/java/supported-file-formats/
keywords:
- ondersteunde bestandsindelingen
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
- Java
- Aspose.Slides
description: "Bekijk welke bestandsindelingen Aspose.Slides for Java kan laden, importeren, opslaan en renderen, en welke API elk formaat leest of schrijft."
---
## **Overzicht**

Aspose.Slides for Java opent en slaat PowerPoint- en OpenDocument-presentaties op. Het kan ook PDF- en HTML-inhoud importeren in dia’s, presentaties opslaan naar document-, web- en afbeelding-formaten, en individuele dia’s en vormen renderen als afbeeldingen. Dit artikel somt elk ondersteund formaat op en noemt de API die het leest of schrijft.

Voor een overzicht van bewerkingsfuncties, zie [Overzicht van functies](/slides/nl/java/features-overview/).

## **Ondersteunde Microsoft PowerPoint-versies**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint voor Mac
- PowerPoint voor Microsoft 365 (voorheen Office 365)

{{% alert color="info" title="Note" %}}

Presentaties die zijn opgeslagen door PowerPoint 95 en eerdere versies kunnen niet worden geopend. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) herkent een PowerPoint 95-bestand en meldt `LoadFormat.Ppt95`, maar de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) constructor gooit [PptUnsupportedFormatException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptunsupportedformatexception/) hiervoor.

{{% /alert %}}

## **Ondersteunde bestandsindelingen**

De tabel gebruikt vier bewerkingen:

- **Load**: de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) constructor opent het bestand als een bewerkbare presentatie.
- **Import**: een [SlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidecollection/)‑methode maakt dia’s aan vanuit de bestandsinhoud en voegt ze toe aan een bestaande presentatie. De Presentation‑constructor converteert deze bestanden niet naar dia’s.
- **Save**: [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) schrijft de presentatie naar een bestand of stream. Elk formaat behalve XAML wordt geselecteerd met een [SaveFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/)‑waarde.
- **Render**: een render‑methode tekent een dia of een vorm als een afbeelding. Formaten die alleen gerenderd worden, zijn geen SaveFormat-waarden.

|**Formaat**|**Omschrijving**|**Load / Import**|**Save / Render**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint-presentatie 97-2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint-sjabloon 97-2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint-diavoorstelling 97-2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint-presentatie|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint-sjabloon|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint-diavoorstelling|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint-macro-ingeschakelde presentatie|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint-macro-ingeschakelde sjabloon|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint-macro-ingeschakelde diavoorstelling|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument-presentatie|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat-XML-OpenDocument-presentatie|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument-presentatiesjabloon|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint-XML-presentatie|Load|Save|`SaveFormat.Xml`; geladen bestanden melden `SourceFormat.Xml` (er is geen `LoadFormat`-waarde)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff` (een pagina per dia); `ImageFormat.Tiff` (een dia)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (anime, alle dia’s); `ImageFormat.Gif` (een dia)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.save(IXamlOptions)`, één XAML-bestand per dia; geen `SaveFormat`-waarde|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG-afbeelding|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap-afbeelding|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Laden en importeren**

- **Load:** Geef een bestandspad of een stream door aan de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) constructor. Het formaat wordt automatisch gedetecteerd op basis van de inhoud; [LoadOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/) biedt instellingen zoals een wachtwoord. Om een bestand te controleren voordat het wordt geopend, roep je [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) aan, die een [LoadFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadformat/)-waarde rapporteert. Voor PowerPoint-XML rapporteert deze `LoadFormat.Unknown`, maar de constructor opent zo’n bestand wel, en [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSourceFormat--) geeft vervolgens `SourceFormat.Xml` terug. Zie [Open presentaties](/slides/nl/java/open-presentation/) en [Bepaal het oorspronkelijke presentatieformaat](/slides/nl/java/detect-presentation-source-format/).
- **Import:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) voegt één dia per PDF-pagina toe aan het einde van een presentatie. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) voegt dia’s toe die uit HTML zijn gemaakt, en [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) plaatst ze op een opgegeven positie. De Presentation-constructor importeert niet: hij gooit [PptUnsupportedFormatException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptunsupportedformatexception/) voor een PDF-bestand en zet HTML-opmaak niet om in dia-inhoud. Zie [Importeer presentaties vanuit PDF of HTML](/slides/nl/java/import-presentation/).

## **Opslaan en renderen**

- **Save:** [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) schrijft de presentatie in het formaat dat wordt opgegeven door een [SaveFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/)‑waarde. Overloads die ook een opties-object ontvangen, regelen de output, bijvoorbeeld [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tiffoptions/), en [GifOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/gifoptions/). Overloads die een array met dia-posities (beginnend bij 1) ontvangen, schrijven alleen die dia’s; ze ondersteunen PDF, XPS, TIFF, HTML, HTML5, SWF, GIF en Markdown, maar niet de presentatie-formaten of PowerPoint-XML. XAML heeft een eigen overload, [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), die [IXamlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ixamloptions/) accepteert. Zie [Presentaties opslaan](/slides/nl/java/save-presentation/), [Presentaties converteren](/slides/nl/java/convert-presentation/), en [Presentaties exporteren naar XAML](/slides/nl/java/export-to-xaml/).
- **Render:** [Slide.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#getImage-float-float-) en [Shape.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getImage--) retourneren een [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/), en [IImage.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/#save-java.lang.String-int-) schrijft deze weg als PNG, JPEG, BMP, GIF of TIFF, geselecteerd met een [ImageFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imageformat/)-waarde. [Presentation.getImages](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) rendert alle of geselecteerde dia’s in één keer. [Slide.writeAsSvg](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) en [Shape.writeAsSvg](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) schrijven SVG, en [Slide.writeAsEmf](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) schrijft EMF. Zie [Dia’s converteren naar afbeeldingen](/slides/nl/java/convert-slide/) en [Dia’s renderen als SVG-afbeeldingen](/slides/nl/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat heeft ook de waarden `Emf`, `Wmf`, `Icon`, `Exif` en `MemoryBmp`, maar IImage.save produceert die formaten niet: het bestand dat wordt geschreven bevat PNG-gegevens. Gebruik Slide.writeAsEmf om een EMF-afbeelding van een dia te krijgen.

{{% /alert %}}

## **FAQ**

**Kan ik een PPT-presentatie converteren naar PPTX of ODP?**

Ja. Open het PPT-bestand met de Presentation-constructor en sla het op met `SaveFormat.Pptx` of `SaveFormat.Odp`. Zie [PPT naar PPTX converteren](/slides/nl/java/convert-ppt-to-pptx/).

**Kan ik een PDF- of HTML-bestand openen als presentatie?**

Nee. De Presentation-constructor gooit PptUnsupportedFormatException voor een PDF-bestand en zet HTML-opmaak niet om in dia’s. Maak of open een presentatie, importeer de PDF-pagina’s of HTML-inhoud met de hierboven beschreven slide-collectiemethoden, en sla vervolgens op in elk ondersteund formaat.

**Kan ik een geëxporteerde PNG- of SVG-afbeelding laden als bewerkbare presentatie?**

Nee. De afbeelding legt alleen vast hoe een dia eruitziet, niet de tekst, vormen of grafieken. Bewaar de bronpresentatie als je later wilt bewerken.

**Kan ik PDF/A- of PDF/UA-documenten opslaan?**

Ja. Geef een [PdfCompliance](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfcompliance/)‑waarde door aan [PdfOptions.setCompliance](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b of PDF/UA.

**Kan ik controleren of een bestand met een wachtwoord beschermd is voordat ik het open?**

Ja. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) inspecteert een bestand zonder een Presentation-object te maken, en [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) geeft aan of een wachtwoord nodig is. Zie [Presentaties met wachtwoord beveiligen](/slides/nl/java/password-protected-presentation/).