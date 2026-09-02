---
title: Konvertera presentationsbilder till bilder i .NET
linktitle: Bild till bild
type: docs
weight: 41
url: /sv/net/convert-slide/
keywords:
- konvertera bild
- exportera bild
- bild till bild
- spara bild som bild
- bild till EMF
- bild till PNG
- bild till JPEG
- bild till bitmap
- bild till TIFF
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Konvertera bilder från PPT-, PPTX- och ODP-presentationer till PNG, JPEG, GIF, TIFF, EMF och andra bildformat i C# med Aspose.Slides för .NET."
---
## **Introduktion**

Aspose.Slides för .NET kan rendera enskilda bilder från PowerPoint- och OpenDocument-presentationer som PNG, JPEG, GIF, TIFF och andra bildformat.

För att konvertera en bild till en bildfil, följ dessa steg:

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
2. Välj den bild du vill rendera.
3. Om nödvändigt, konfigurera rendering med klassen [RenderingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/renderingoptions/) eller [TiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/).
4. Anropa metoden [GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/). Den returnerar ett [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/)-objekt.
5. Anropa metoden [IImage.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/save/) och ange utdataformatet med ett [ImageFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/imageformat/)-värde.

## **Konvertera en bild till en PNG-bild**

Den enklaste konverteringen använder standardinställningarna för rendering. Det resulterande [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/)-objektet kan bearbetas i minnet eller sparas till en fil.

Följande C#-exempel renderar den första bilden och sparar den som en PNG-bild:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Konvertera bilder till bildfiler med anpassade storlekar**

Använd överlagringen av [GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/) som tar emot ett [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size)-värde för att rendera en bild med exakta pixeldimensioner.

Följande exempel skapar en 1820 × 1040 JPEG-bild:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Konvertera bilder med anteckningar och kommentarer till bildfiler**

Som standard innehåller bildfiler inga anteckningar eller kommentarer. Tilldela ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/notescommentslayoutingoptions/)‑objekt till egenskapen [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) för att kontrollera var anteckningar och kommentarer visas.

Följande exempel placerar avkortade anteckningar under bilden och kommentarer till höger om den:

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
För konvertering från slide till bild, ange inte egenskapen [NotesPosition](https://reference.aspose.com/slides/sv/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) till [BottomFull](https://reference.aspose.com/slides/sv/net/aspose.slides.export/notespositions/). Anteckningar kan innehålla mer text än den fasta bildstorleken kan rymma. Använd [BottomTruncated](https://reference.aspose.com/slides/sv/net/aspose.slides.export/notespositions/) istället.
{{% /alert %}}

## **Konvertera bilder till bildfiler med TIFF-alternativ**

Klassen [TiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/) låter dig kontrollera storlek, upplösning och andra egenskaper för den renderade TIFF-bilden.

Följande exempel renderar den första bilden som en 2160 × 2880 TIFF-bild med 300 DPI:

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

## **Konvertera alla bilder till bildfiler**

Iterera igenom bildsamlingen för att konvertera hela presentationen till en serie bildfiler. Dolda bilder inkluderas om du inte explicit hoppar över dem.

Följande exempel renderar varje bild som en JPEG-bild med horisontella och vertikala skalningsfaktorer på 2:

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

## **Skapa Enhanced Metafile-utdata**

Enhanced Metafile (EMF) är användbart när vektorgrafik måste utbytas med Microsoft Office eller andra Windows‑applikationer som stödjer Windows‑metafiler. Till skillnad från en pixelbaserad bild kan en EMF bevara vektorritningar som kan skalas utan samma förlust av skärpa. EMF är dock främst ett kompatibilitetsformat för applikationer med stöd för Windows‑metafiler, inte ett universellt utbytesformat. Dessutom kan komplext bildinnehåll, såsom bitmapbilder och vissa effekter, lagras som rasteriserade element i vektormetafilsbehållaren.

### **Exportera en bild till EMF**

Metoden [ISlide.WriteAsEmf](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/writeasemf/) skriver en [ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/) till ett mål‑ström i EMF-format. Följande exempel laddar en presentation, väljer den första bilden och skriver den till ett EMF‑filström:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

Anroparen äger strömmen som skickas till [ISlide.WriteAsEmf](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/writeasemf/) och måste stänga eller disponera den. Aspose.Slides skriver på strömmens aktuella position och lämnar strömmen öppen.

### **Konvertera en SVG-bild till EMF och lägg till den i en presentation**

Använd [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/writeasemf/) för att konvertera SVG-innehåll till EMF. De resulterande bytena kan läggas till i presentationen via [IImageCollection.AddImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimagecollection/addimage/) och placeras på en bild med [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addpictureframe/).

Följande exempel skapar en [SvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/svgimage/) från SVG‑markup, konverterar den till ett EMF‑objekt i minnet, infogar metafilen på den första bilden och sparar presentationen:

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

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/writeasemf/) tar inte ägandeskap över destinationsströmmen. Efter skrivning är strömmens position i slutet av den genererade datan. Återställ `Position` till början innan samma sökbara ström skickas till en läsare, som visas ovan. Håll strömmen öppen tills konsumenten har läst färdigt den och disponera den därefter. Alternativt kan du anropa `ToArray` och skicka den returnerade byte‑arrayen till [IImageCollection.AddImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimagecollection/addimage/); `ToArray` returnerar hela bufferten oavsett strömmens aktuella position.

EMF‑generering är tillgänglig på de operativsystem som stöds av den valda Aspose.Slides för .NET‑byggnaden, men rendering kan skilja sig åt mellan plattformar när typsnitt eller inhemska grafikberoenden saknas. Installera de typsnitt som används av källinnehållet eller konfigurera lämpliga ersättningar, följ [platform requirements](/slides/sv/net/system-requirements/) för ditt Aspose.Slides‑paket och validera resultatet i den mål‑EMF‑konsumerande applikationen. Linux‑ och macOS‑applikationer har ofta begränsat eller inkonsekvent stöd för att visa och redigera Windows‑metafiler.

## **Rendering av färgade emojis**

{{% alert title="Note" color="info" %}}
För att rendera färgade emojis korrekt när presentationsbilder konverteras till bildfiler måste de emoji‑typsnitt som används i presentationen vara installerade och tillgängliga på systemet som utför konverteringen. Till exempel, om presentationen använder **Segoe UI Emoji** och detta typsnitt saknas, kan emojis visas i monokrom i utdata‑bilderna.
{{% /alert %}}

## **FAQ**

**Stöder Aspose.Slides rendering av bilder med animationer?**

Nej. Metoden [GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/) renderar en statisk bild av sliden och exporterar inte animationer.

**Kan dolda bilder exporteras som bildfiler?**

Ja. Dolda bilder kan renderas som vanliga bilder. Inkludera dem i bearbetningsloopen, som visas i exemplet ovan.

**Bevaras skuggor och andra effekter i bildfiler?**

Ja. Aspose.Slides renderar skuggor, transparens och andra stödjade grafiska effekter i bildfiler.