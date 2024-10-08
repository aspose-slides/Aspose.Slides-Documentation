---
title: Moderne API
type: docs
weight: 237
url: /de/net/modern-api/
keywords: "CrossPlatform Moderne API System.Drawing"
description: "Moderne API"
---

## Einführung

Historisch gesehen hat Aspose Slides eine Abhängigkeit von System.Drawing und hat in der öffentlichen API die folgenden Klassen daraus:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Seit Version 24.4 wird diese öffentliche API als veraltet deklariert.

Da die Unterstützung von System.Drawing in .NET6 und höheren Versionen für nicht-windows-Versionen entfernt wurde ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), hat Slides einen Ansatz mit zwei Bibliotheksversionen implementiert:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - Unterstützung für .NET6+ für Windows, .NETStandard für Windows/Linux/MacOS, .NETFramework 2+ (Windows).
  - hat eine Abhängigkeit von [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - Windows/Linux/MacOS-Version ohne Abhängigkeiten.

Der Nachteil von [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) ist, dass es seine eigene Version von System.Drawing im selben Namensraum implementiert (um die Abwärtskompatibilität mit der öffentlichen API zu unterstützen). Daher tritt ein Namenskonflikt auf, wenn Aspose.Slides.NET6.CrossPlatform und System.Drawing aus dem .NETFramework oder dem System.Drawing.Common-Paket gleichzeitig verwendet werden, es sei denn, es wird ein Alias verwendet.

Um die Abhängigkeiten von System.Drawing im Hauptpaket Aspose.Slides.NET loszuwerden, haben wir die sogenannte "Moderne API" hinzugefügt - d.h. die API, die anstelle der veralteten verwendet werden sollte, deren Signaturen Abhängigkeiten von den folgenden Typen aus System.Drawing enthalten: Image und Bitmap. PrinterSettings und Graphics sind als veraltet deklariert und ihre Unterstützung wurde aus der öffentlichen Slides API entfernt.

Die Entfernung der veralteten öffentlichen API mit Abhängigkeiten von System.Drawing wird in der Version 24.8 erfolgen.

## Moderne API

Die folgenden Klassen und Enums wurden zur öffentlichen API hinzugefügt:

- Aspose.Slides.IImage - repräsentiert das Raster- oder Vektorbild.
- Aspose.Slides.ImageFormat - repräsentiert das Dateiformat des Bildes.
- Aspose.Slides.Images - Methoden zur Instanziierung und Arbeit mit dem IImage-Interface.

Bitte beachten Sie, dass IImage entsorgbar ist (es implementiert das IDisposable-Interface und seine Verwendung sollte in using oder auf andere bequeme Weise entsorgt werden).

Ein typisches Szenario zur Verwendung der neuen API könnte folgendermaßen aussehen:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // Instanziieren Sie eine entsorgbare Instanz von IImage aus der Datei auf der Festplatte.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // Erstellen Sie ein PowerPoint-Bild, indem Sie eine Instanz von IImage zu den Bildern der Präsentation hinzufügen.
        ppImage = pres.Images.AddImage(image);
    }

    // Fügen Sie ein Bildfeld auf Folie #1 hinzu
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // Holen Sie sich eine Instanz von IImage, die Folie #1 repräsentiert.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // Speichern Sie das Bild auf der Festplatte.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## Ersetzen von altem Code durch die Moderne API

Zur Erleichterung des Übergangs wiederholt die Schnittstelle des neuen IImage die separaten Signaturen der Klassen Image und Bitmap. Im Allgemeinen müssen Sie lediglich den Aufruf der alten Methode mit System.Drawing durch die neue ersetzen.

### Holen eines Folien-Thumbnails

Code mit einer veralteten API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Moderne API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### Holen eines Shapes-Thumbnails

Code mit einer veralteten API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Moderne API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### Holen eines Präsentations-Thumbnails

Code mit einer veralteten API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var bitmaps = pres.GetThumbnails(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < bitmaps.Length; index++)
        {
            Bitmap thumbnail = bitmaps[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (Bitmap bitmap in bitmaps)
        {
            bitmap.Dispose();
        }
    }
}
```

Moderne API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var images = pres.GetImages(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < images.Length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (IImage image in images)
        {
            image.Dispose();
        }
    }
}
```

### Hinzufügen eines Bildes zu einer Präsentation

Code mit einer veralteten API:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (Image image = Image.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

Moderne API:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (IImage image = Aspose.Slides.Images.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```
## Methoden/Eigenschaften, die entfernt werden sollen, und deren Ersatz in der Modernen API

### Präsentation
| Methodensignatur                               | Ersetzung der Methodensignatur                             |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages)                   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1)   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | Wird vollständig gelöscht |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | Wird vollständig gelöscht |
| public void Print()                           | Wird vollständig gelöscht                               |
| public void Print(PrinterSettings printerSettings) | Wird vollständig gelöscht                            |
| public void Print(string printerName)         | Wird vollständig gelöscht                               |
| public void Print(PrinterSettings printerSettings, string presName) | Wird vollständig gelöscht                          |

### Form
| Methodensignatur                                                      | Ersetzung der Methodensignatur                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail()                                          | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage)                                                           |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### Folie
| Methodensignatur                                                      | Ersetzung der Methodensignatur                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY)                | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5)                                 |
| public Bitmap GetThumbnail()                                         | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage)                                                              |
| public Bitmap GetThumbnail(IRenderingOptions options)                | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1)                                  |
| public Bitmap GetThumbnail(Size imageSize)                           | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6)                                             |
| public Bitmap GetThumbnail(ITiffOptions options)                    | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4)                                      |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3)               |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | Wird vollständig gelöscht                                       |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | Wird vollständig gelöscht                             |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | Wird vollständig gelöscht                                    |

#### Ausgabe
| Methodensignatur                                                | Ersetzung der Methodensignatur                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image)               | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1)                               |

### ImageCollection
| Methodensignatur                          | Ersetzung der Methodensignatur               |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image)           | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage)                      |

### ImageWrapperFactory
| Methodensignatur                                         | Ersetzung der Methodensignatur                            |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image)           | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper)                        |

### PPImage
| Methoden-/Eigenschaftssignatur                     | Ersetzung der Methodensignatur   |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage)   | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage)            |
| Image SystemImage { get; }          | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image)                    |

### PatternFormat
| Methodensignatur                                          | Ersetzung der Methodensignatur                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1)         |
| Bitmap GetTileImage(Color styleColor)                     | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile)                           |

### IPatternFormatEffectiveData
| Methodensignatur                                          | Ersetzung der Methodensignatur                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage)                    |

## Unterstützung für Aspose.Slides.NET6.CrossPlatform wird eingestellt

Nach der Veröffentlichung von [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) Version 24.8 wird die Unterstützung für [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) eingestellt.

## API-Unterstützung für Graphics und PrinterSettings wird eingestellt

Die [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) Klasse wird nicht für plattformübergreifende Versionen von .NET6 und höher unterstützt. In Aspose Slides wird der Teil der API, der sie verwendet, entfernt:
[Folie](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Außerdem wird der Teil der API, der mit dem Drucken zu tun hat, entfernt:

[Präsentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)