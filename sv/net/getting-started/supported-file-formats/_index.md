---
title: Stödda filformat
type: docs
weight: 96
url: /sv/net/supported-file-formats/
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
- .NET
- C#
- Aspose.Slides
description: "Se vilka filformat Aspose.Slides för .NET kan läsa, importera, spara och rendera, samt vilket API som läser eller skriver var och en."
---
## **Översikt**

Aspose.Slides för .NET öppnar och sparar PowerPoint‑ och OpenDocument‑presentationer. Det importerar också PDF‑ och HTML‑innehåll till bilder, sparar presentationer till dokument‑, webb‑ och bildformat och renderar enskilda bilder och former som bilder. Den här artikeln listar varje stödformat och namnger API:et som läser eller skriver det.

Båda NuGet‑paketen, Aspose.Slides.NET och Aspose.Slides.NET6.CrossPlatform, stödjer samma format; se [Installation](/slides/sv/net/installation/) för att välja mellan dem. För en översikt över redigeringsfunktioner, se [Funktionsöversikt](/slides/sv/net/features-overview/).

## **Stödda Microsoft PowerPoint-versioner**

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
- PowerPoint för Microsoft 365 (tidigare Office 365)

{{% alert color="info" title="Note" %}}
Presentationer som sparats av PowerPoint 95 och tidigare versioner kan inte öppnas. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) känner igen en PowerPoint 95‑fil och rapporterar `LoadFormat.Ppt95`, men [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)‑konstruktorn kastar [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) för den.
{{% /alert %}}

## **Stödda filformat**

Tabellen använder fyra operationer:

- **Load**: konstruktorn för [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) öppnar filen som en redigerbar presentation.
- **Import**: en metod i [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) skapar bilder från filens innehåll och lägger till dem i en befintlig presentation. Presentation‑konstruktorn laddar inte dessa filer som presentationer.
- **Save**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) skriver presentationen till en fil eller ström. Varje format förutom XAML väljs med ett [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)-värde.
- **Render**: en renderingsmetod ritar en bild eller en form som en bild. Format som endast renderas har inga SaveFormat‑värden.

|**Format**|**Beskrivning**|**Load / Import**|**Save / Render**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint‑presentation 97‑2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint‑mall 97‑2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint‑bildspel 97‑2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint‑presentation|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint‑mall|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint‑bildspel|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint‑presentation med makron|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint‑mall med makron|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint‑bildspel med makron|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument‑presentation|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat XML OpenDocument‑presentation|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument‑presentationsmall|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint‑XML‑presentation|Load|Save|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|Portabelt dokumentformat|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Taggat bildfilformat|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.Save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG‑bild|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap‑bild|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Läs och importera**

- **Läs:** Skicka en filsökväg eller en ström till [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)-konstruktorn. Formatet identifieras från innehållet; [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) tillhandahåller inställningar som ett lösenord. För att kontrollera en fil innan du öppnar den, anropa [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/), som rapporterar ett [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/)-värde. Det rapporterar `LoadFormat.Unknown` för PowerPoint‑XML, men konstruktorn öppnar en sådan fil, och [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) returnerar då `SourceFormat.Xml`. Se [Open Presentations](/slides/sv/net/open-presentation/) och [Determine the Original Presentation Format](/slides/sv/net/detect-presentation-source-format/).
- **Importera:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) lägger till en bild per PDF‑sida i slutet av en presentation. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) lägger till bilder skapade från HTML, och [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) sätter in dem på en given position. Presentation‑konstruktorn importerar inte: den kastar [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) för en PDF‑fil och konverterar inte HTML‑markup till bildinnehåll. Se [Import Presentations from PDF or HTML](/slides/sv/net/import-presentation/).

## **Spara och rendera**

- **Spara:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) skriver presentationen i formatet som anges av ett [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)-värde. Överlagringar som även tar ett alternativ‑objekt styr utdata, till exempel [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), och [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). Överlagringar som tar en array med bildpositioner, räknat från 1, skriver endast de angivna bilderna; de accepterar PDF, XPS, TIFF, HTML, HTML5, SWF, GIF och Markdown, men inte presentationsformaten eller PowerPoint‑XML. XAML har sin egen överlagring som tar [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/). Se [Save Presentations](/slides/sv/net/save-presentation/), [Convert Presentations](/slides/sv/net/convert-presentation/), och [Export Presentations to XAML](/slides/sv/net/export-to-xaml/).
- **Rendera:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) och [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) returnerar ett [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), och [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) skriver det som PNG, JPEG, BMP, GIF eller TIFF, valt med ett [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)-värde. [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) renderar alla bilder eller valda bilder på en gång. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) och [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) skriver SVG, och [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) skriver EMF. Se [Convert Presentation Slides to Images](/slides/sv/net/convert-slide/) och [Render a Slide as an SVG Image](/slides/sv/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}
ImageFormat har även `Emf`, `Wmf`, `Icon`, `Exif` och `MemoryBmp`‑värden, men IImage.Save producerar inte dessa format: filen den skriver innehåller PNG‑data. För att få en EMF‑bild av en bild, använd Slide.WriteAsEmf.
{{% /alert %}}

## **FAQ**

**Kan jag konvertera en PPT‑presentation till PPTX eller ODP?**

Ja. Öppna PPT‑filen med Presentation‑konstruktorn och spara den med `SaveFormat.Pptx` eller `SaveFormat.Odp`. Se [Convert PPT to PPTX](/slides/sv/net/convert-ppt-to-pptx/).

**Kan jag öppna en PDF‑ eller HTML‑fil som en presentation?**

Nej. Skapa eller öppna en presentation, importera PDF‑sidorna eller HTML‑innehållet med slide‑samlingens metoder som beskrivs ovan, och spara sedan i ett av de stödda formaten.

**Kan jag läsa in en exporterad PNG‑ eller SVG‑bild som en redigerbar presentation?**

Nej. Bildutdata registrerar bara hur en bild ser ut, inte dess text, former eller diagram. Behåll originalpresentationen om du senare behöver redigera den.

**Kan jag spara PDF/A‑ eller PDF/UA‑dokument?**

Ja. Sätt [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) till ett [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/)-värde: PDF/A‑1a, PDF/A‑1b, PDF/A‑2a, PDF/A‑2b, PDF/A‑2u, PDF/A‑3a, PDF/A‑3b eller PDF/UA.

**Kan jag kontrollera om en fil är lösenordsskyddad innan jag öppnar den?**

Ja. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) granskar en fil utan att skapa ett Presentation‑objekt, och dess [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/)‑egenskap rapporterar om ett lösenord krävs. Se [Password‑Protect Presentations](/slides/sv/net/password-protected-presentation/).

**Stöder de två NuGet‑paketen olika format?**

Nej. Aspose.Slides.NET och Aspose.Slides.NET6.CrossPlatform har samma LoadFormat‑ och SaveFormat‑värden samt samma import‑ och renderingsmetoder. De skiljer sig åt i vilka plattformar de körs på och vad dessa plattformar kräver; se [Installation](/slides/sv/net/installation/).