---
title: Stödda filformat
type: docs
weight: 106
url: /sv/java/supported-file-formats/
keywords:
- stödda filformat
- ladda presentation
- importera PDF
- importera HTML
- spara presentation
- rendera bilder
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
description: "Se vilka filformat Aspose.Slides for Java kan ladda, importera, spara och rendera, samt vilket API som läser eller skriver vart och ett."
---
## **Översikt**

Aspose.Slides for Java öppnar och sparar PowerPoint‑ och OpenDocument‑presentationer. Den importerar också PDF‑ och HTML‑innehåll till bilder, sparar presentationer till dokument‑, webb‑ och bildformat och renderar enskilda bilder och former som bilder. Denna artikel listar varje stödd format och namnger API‑et som läser eller skriver det.

För en översikt över redigeringsfunktioner, se [Funktionsöversikt](/slides/sv/java/features-overview/).

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

{{% alert color="info" title="Note" %}}

Presentationer sparade av PowerPoint 95 och tidigare versioner kan inte öppnas. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) identifierar en PowerPoint 95‑fil och rapporterar `LoadFormat.Ppt95`, men [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#Presentation-java.lang.String-)‑konstruktorn kastar [PptUnsupportedFormatException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pptunsupportedformatexception/) för den.

{{% /alert %}}

## **Stödda filformat**

Tabellen använder fyra operationer:

- **Ladda**: [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#Presentation-java.lang.String-)‑konstruktorn öppnar filen som en redigerbar presentation.
- **Importera**: en [SlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidecollection/)‑metod skapar bilder från filens innehåll och lägger till dem i en befintlig presentation. Presentation‑konstruktorn konverterar inte dessa filer till bilder.
- **Spara**: [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-) skriver presentationen till en fil eller ström. Varje format förutom XAML väljs med ett [SaveFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveformat/)-värde.
- **Rendera**: en renderingsmetod ritar en bild eller en form som en bild. Format som endast renderas är inte SaveFormat‑värden.

|**Format**|**Beskrivning**|**Ladda / Importera**|**Spara / Rendera**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint‑presentation 97‑2003|Ladda|Spara|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint‑mall 97‑2003|Ladda|Spara|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint‑bildspel 97‑2003|Ladda|Spara|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint‑presentation|Ladda|Spara|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint‑mall|Ladda|Spara|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint‑bildspel|Ladda|Spara|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint‑makroaktiverad presentation|Ladda|Spara|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint‑makroaktiverad mall|Ladda|Spara|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint‑makroaktiverat bildspel|Ladda|Spara|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument‑presentation|Ladda|Spara|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat XML OpenDocument‑presentation|Ladda|Spara|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument‑mall för presentation|Ladda|Spara|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML‑presentation|Ladda|Spara|`SaveFormat.Xml`; inlästa filer rapporterar `SourceFormat.Xml` (det finns inget `LoadFormat`‑värde)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Importera|Spara|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Importera|Spara|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Spara|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Spara, Rendera|`SaveFormat.Tiff` (en sida per bild); `ImageFormat.Tiff` (en bild)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Spara, Rendera|`SaveFormat.Gif` (animera, alla bilder); `ImageFormat.Gif` (en bild)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Spara|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Spara|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Spara|`Presentation.save(IXamlOptions)`, en XAML‑fil per bild; inget `SaveFormat`‑värde|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Rendera|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG‑bild|—|Rendera|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap‑bild|—|Rendera|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Rendera|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Rendera|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Ladda och importera**

- **Ladda:** Skicka en filsökväg eller en ström till [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#Presentation-java.lang.String-)‑konstruktorn. Formatet identifieras från innehållet; [LoadOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/) tillhandahåller inställningar såsom lösenord. För att kontrollera en fil innan den öppnas, anropa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), som rapporterar ett [LoadFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadformat/)-värde. Det rapporterar `LoadFormat.Unknown` för PowerPoint‑XML, men konstruktorn öppnar sådan fil och [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSourceFormat--) returnerar sedan `SourceFormat.Xml`. Se [Open Presentations](/slides/sv/java/open-presentation/) och [Determine the Original Presentation Format](/slides/sv/java/detect-presentation-source-format/).
- **Importera:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) lägger till en bild per PDF‑sida i slutet av en presentation. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) lägger till bilder skapade från HTML, och [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) sätter in dem på en given position. Presentation‑konstruktorn importerar inte: den kastar [PptUnsupportedFormatException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pptunsupportedformatexception/) för en PDF‑fil och konverterar inte HTML‑markup till bildinnehåll. Se [Import Presentations from PDF or HTML](/slides/sv/java/import-presentation/).

## **Spara och rendera**

- **Spara:** [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-) skriver presentationen i formatet som ett [SaveFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveformat/)-värde anger. Överlagringar som också tar ett alternativobjekt styr utdata, exempelvis [PdfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/sv/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/tiffoptions/), och [GifOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/gifoptions/). Överlagringar som tar en array med bildpositioner, räknade från 1, skriver bara de bilderna; de stödjer PDF, XPS, TIFF, HTML, HTML5, SWF, GIF och Markdown, men inte presentation‑formaten eller PowerPoint‑XML. XAML har sin egen överlagring, [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), som tar [IXamlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ixamloptions/). Se [Save Presentations](/slides/sv/java/save-presentation/), [Convert Presentations](/slides/sv/java/convert-presentation/), och [Export Presentations to XAML](/slides/sv/java/export-to-xaml/).
- **Rendera:** [Slide.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#getImage-float-float-) och [Shape.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getImage--) returnerar ett [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/), och [IImage.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/#save-java.lang.String-int-) skriver det som PNG, JPEG, BMP, GIF eller TIFF, valt med ett [ImageFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imageformat/)-värde. [Presentation.getImages](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) renderar alla bilder eller valda bilder på en gång. [Slide.writeAsSvg](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) och [Shape.writeAsSvg](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) skriver SVG, och [Slide.writeAsEmf](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) skriver EMF. Se [Convert Presentation Slides to Images](/slides/sv/java/convert-slide/) och [Render Presentation Slides as SVG Images](/slides/sv/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat har även värdena `Emf`, `Wmf`, `Icon`, `Exif` och `MemoryBmp`, men IImage.save producerar inte dessa format: den fil den skriver innehåller PNG‑data. För att få en EMF‑bild av en bild, använd Slide.writeAsEmf.

{{% /alert %}}

## **FAQ**

**Kan jag konvertera en PPT‑presentation till PPTX eller ODP?**

Ja. öppna PPT‑filen med Presentation‑konstruktorn och spara den med `SaveFormat.Pptx` eller `SaveFormat.Odp`. Se [Convert PPT to PPTX](/slides/sv/java/convert-ppt-to-pptx/).

**Kan jag öppna en PDF‑ eller HTML‑fil som en presentation?**

Nej. Presentation‑konstruktorn kastar PptUnsupportedFormatException för en PDF‑fil och konverterar inte HTML‑markup till bilder. Skapa eller öppna en presentation, importera PDF‑sidorna eller HTML‑innehållet med metoderna i bildsamlingen beskrivna ovan, och spara sedan i vilket stödformat som helst.

**Kan jag ladda en exporterad PNG‑ eller SVG‑bild som en redigerbar presentation?**

Nej. Bildutdata registrerar hur en bild ser ut, inte dess text, former eller diagram. Behåll originalpresentationen om du behöver redigera den senare.

**Kan jag spara PDF/A‑ eller PDF/UA‑dokument?**

Ja. Skicka ett [PdfCompliance](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfcompliance/)-värde till [PdfOptions.setCompliance](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A‑1a, PDF/A‑1b, PDF/A‑2a, PDF/A‑2b, PDF/A‑2u, PDF/A‑3a, PDF/A‑3b eller PDF/UA.

**Kan jag kontrollera om en fil är lösenordsskyddad innan jag öppnar den?**

Ja. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) inspekterar en fil utan att skapa ett Presentation‑objekt, och [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) rapporterar om ett lösenord krävs. Se [Password‑Protect Presentations](/slides/sv/java/password-protected-presentation/).