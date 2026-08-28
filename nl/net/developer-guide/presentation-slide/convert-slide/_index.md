---
title: Presentatiedia's omzetten naar afbeeldingen in .NET
linktitle: Dia naar afbeelding
type: docs
weight: 41
url: /nl/net/convert-slide/
keywords:
- dia converteren
- dia exporteren
- dia naar afbeelding
- dia opslaan als afbeelding
- dia naar EMF
- dia naar PNG
- dia naar JPEG
- dia naar bitmap
- dia naar TIFF
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Converteer dia's van PPT-, PPTX- en ODP-presentaties naar PNG, JPEG, GIF, TIFF, EMF en andere afbeeldingsformaten in C# met Aspose.Slides voor .NET."
---
## **Introductie**

Aspose.Slides for .NET kan individuele dia's renderen vanuit PowerPoint- en OpenDocument-presentaties als PNG, JPEG, GIF, TIFF en andere afbeeldingsformaten.

Om een dia om te zetten in een afbeelding, volg u deze stappen:

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
2. Selecteer de dia die u wilt renderen.
3. Indien nodig, configureer de rendering met de [RenderingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/renderingoptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/) klasse.
4. Roep de [GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/) methode aan. Deze retourneert een [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) object.
5. Roep de [IImage.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/save/) methode aan en specificeer het uitvoerformaat met een [ImageFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/imageformat/) waarde.

## **Een dia omzetten naar een PNG-afbeelding**

De eenvoudigste conversie gebruikt de standaardrenderinginstellingen. Het resulterende [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) object kan in het geheugen worden verwerkt of naar een bestand worden opgeslagen.

Het volgende C#-voorbeeld rendert de eerste dia en slaat deze op als een PNG-afbeelding:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Dia's omzetten naar afbeeldingen met aangepaste afmetingen**

Gebruik de overload van [GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/) die een [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) waarde accepteert om een dia te renderen met exacte pixelafmetingen.

Het volgende voorbeeld maakt een JPEG-afbeelding van 1820 × 1040 pixels:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Dia's met notities en commentaren omzetten naar afbeeldingen**

Standaard bevatten dia-afbeeldingen geen notities of commentaren. Wijs een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/notescommentslayoutingoptions/) object toe aan de eigenschap [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) om te bepalen waar notities en commentaren verschijnen.

Het volgende voorbeeld plaatst afgekorte notities onder de dia en commentaren rechts ervan:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
Voor dia-naar-afbeelding conversie mag de eigenschap [NotesPosition](https://reference.aspose.com/slides/nl/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) niet worden ingesteld op [BottomFull](https://reference.aspose.com/slides/nl/net/aspose.slides.export/notespositions/). Notities kunnen meer tekst bevatten dan de vaste afbeeldingsgrootte kan bevatten. Gebruik in plaats daarvan [BottomTruncated](https://reference.aspose.com/slides/nl/net/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Dia's omzetten naar afbeeldingen met TIFF-opties**

De [TiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/) klasse stelt u in staat de grootte, resolutie en andere eigenschappen van de gerenderde TIFF-afbeelding te regelen.

Het volgende voorbeeld rendert de eerste dia als een TIFF-afbeelding van 2160 × 2880 pixels bij 300 DPI:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Alle dia's omzetten naar afbeeldingen**

Itereer door de dia-collectie om de gehele presentatie om te zetten in een reeks afbeeldingen. Verborgen dia's worden opgenomen tenzij u ze expliciet overslaat.

Het volgende voorbeeld rendert elke dia als een JPEG-afbeelding met een horizontale en verticale schaalfactor van 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Enhanced Metafile-uitvoer maken**

Enhanced Metafile (EMF) is nuttig wanneer vectorgebaseerde grafieken moeten worden uitgewisseld met Microsoft Office of andere Windows-toepassingen die Windows-metabestanden ondersteunen. In tegenstelling tot een pixelgebaseerde afbeelding kan een EMF vectortekenoperaties behouden die schalen zonder hetzelfde verlies van scherpte. EMF is echter voornamelijk een compatibiliteitsformaat voor toepassingen met Windows-metabestandondersteuning, geen universeel uitwisselingsformaat. Bovendien kan complexe dia-inhoud, zoals bitmap-afbeeldingen en sommige effecten, worden opgeslagen als gerasterde elementen binnen de vector‑metabestand‑container.

### **Een dia exporteren naar EMF**

De [ISlide.WriteAsEmf](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/writeasemf/) methode schrijft een [ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/) naar een doelstream in EMF-formaat. Het volgende voorbeeld laadt een presentatie, selecteert de eerste dia en schrijft deze naar een EMF‑bestandstream:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

De aanroeper bezit de stream die wordt doorgegeven aan [ISlide.WriteAsEmf](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/writeasemf/) en moet deze sluiten of vrijgeven. Aspose.Slides schrijft op de huidige positie van de stream en laat de stream open.

### **Een SVG-afbeelding naar EMF converteren en toevoegen aan een presentatie**

Gebruik [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/writeasemf/) om SVG‑inhoud naar EMF te converteren. De resulterende bytes kunnen aan de presentatie worden toegevoegd via [IImageCollection.AddImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimagecollection/addimage/) en op een dia worden geplaatst met [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addpictureframe/).

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/writeasemf/) neemt geen eigendom van de doel‑stream. Na het schrijven staat de stream‑positie aan het einde van de gegenereerde gegevens. Reset `Position` naar het begin voordat u dezelfde zoekbare stream aan een lezer doorgeeft, zoals hierboven getoond. Houd de stream open totdat de consument klaar is met lezen, en geef deze vervolgens vrij. U kunt ook `ToArray` aanroepen en de geretourneerde byte‑array doorgeven aan [IImageCollection.AddImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimagecollection/addimage/); `ToArray` retourneert de volledige buffer, ongeacht de huidige stream‑positie.

EMF‑generatie is beschikbaar op de besturingssystemen die worden ondersteund door de geselecteerde Aspose.Slides for .NET‑build, maar rendering kan verschillen per platform wanneer lettertypen of native grafische afhankelijkheden niet beschikbaar zijn. Installeer de lettertypen die door de bron‑inhoud worden gebruikt of configureer geschikte substituties, volg de [platform requirements](/slides/nl/net/system-requirements/) voor uw Aspose.Slides‑pakket, en valideer het resultaat in de doel‑EMF‑consumerende toepassing. Linux‑ en macOS‑toepassingen hebben vaak beperkte of inconsistente ondersteuning voor het weergeven en bewerken van Windows‑metabestanden.

## **Kleur‑emoji rendering**

{{% alert title="Note" color="info" %}}
Om kleur‑emoji’s correct weer te geven bij het converteren van presentatiedia’s naar afbeeldingen, moeten de emoji‑lettertypen die in de presentatie worden gebruikt, geïnstalleerd en beschikbaar zijn op het systeem dat de conversie uitvoert. Bijvoorbeeld, als de presentatie **Segoe UI Emoji** gebruikt en dit lettertype ontbreekt, kunnen emoji’s in monochroom verschijnen in de uitvoer‑afbeeldingen.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides het renderen van dia's met animaties?**

Nee. De [GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/) methode rendert een statische afbeelding van de dia en exporteert geen animaties.

**Kunnen verborgen dia's geëxporteerd worden als afbeeldingen?**

Ja. Verborgen dia's kunnen worden gerenderd zoals gewone dia's. Neem ze op in de verwerkingslus, zoals in het voorbeeld hierboven weergegeven.

**Worden schaduwen en andere effecten behouden in dia‑afbeeldingen?**

Ja. Aspose.Slides rendert schaduwen, transparantie en andere ondersteunde grafische effecten in dia‑afbeeldingen.