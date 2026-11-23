---
title: Bildverarbeitung mit der Modernen API verbessern
linktitle: Moderne API
type: docs
weight: 234
url: /de/net/modern-api/
keywords:
- System.Drawing
- Moderne API
- Zeichnen
- Folien-Vorschaubild
- Folie zu Bild
- Form-Vorschaubild
- Form zu Bild
- Präsentations-Vorschaubild
- Präsentation zu Bildern
- Bild hinzufügen
- Bild einfügen
- .NET
- C#
- Aspose.Slides
description: "Modernisieren Sie die Bildverarbeitung von Folien, indem Sie veraltete Imaging-APIs durch die .NET Moderne API ersetzen, für nahtlose PowerPoint- und OpenDocument-Automatisierung."
---
## **Einführung**

Historisch hat Aspose Slides eine Abhängigkeit von System.Drawing und enthält in der öffentlichen API die folgenden Klassen davon:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Ab Version 24.4 ist diese öffentliche API als veraltet deklariert.

Da die System.Drawing-Unterstützung in den Versionen .NET6 und höher für Nicht‑Windows‑Versionen entfernt wurde ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), hat Slides einen zweipaketigen Ansatz implementiert:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – Unterstützung für .NET6+ unter Windows, .NETStandard für Windows/Linux/macOS, .NETFramework 2+ (Windows). – hat eine Abhängigkeit von [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – Windows/Linux/macOS‑Version ohne Abhängigkeiten.

Der Nachteil von [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) ist, dass es seine eigene Version von System.Drawing im selben Namespace implementiert (um die Abwärtskompatibilität mit der öffentlichen API zu unterstützen). Daher entsteht ein Namenskonflikt, wenn Aspose.Slides.NET6.CrossPlatform und System.Drawing aus dem .NET‑Framework oder dem System.Drawing.Common‑Paket gleichzeitig verwendet werden, es sei denn, ein Alias wird benutzt.

Um die Abhängigkeiten von System.Drawing im Hauptpaket Aspose.Slides.NET zu entfernen, haben wir die sogenannte „Modern API“ hinzugefügt – also die API, die anstelle der veralteten verwendet werden sollte und deren Signaturen Abhängigkeiten von den folgenden Typen aus System.Drawing enthalten: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) und [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) und [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) sind als veraltet deklariert und ihre Unterstützung wurde aus der öffentlichen Slides‑API entfernt.

In den aktuellen Versionen sollte die öffentliche API, die von System.Drawing abhängt, als veraltet/legacy behandelt werden. Verwenden Sie die Modern API für neuen Code und beim Migrieren bestehender Bildverarbeitungs‑Workflows.

## **Moderne API**

Folgende Klassen und Aufzählungen wurden zur öffentlichen API hinzugefügt:
- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) – stellt das Raster‑ oder Vektorbild dar.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) – stellt das Dateiformat des Bildes dar.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) – Methoden zum Instanziieren und Arbeiten mit der [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)‑Schnittstelle.

Bitte beachten Sie, dass [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) entsorgbar ist (es implementiert das [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable)-Interface und seine Verwendung sollte mit using umschlossen oder auf andere geeignete Weise freigegeben werden).

Verwenden Sie `GetImage`, um eine einzelne Folie oder Form zu rendern. Verwenden Sie `GetImages`, um mehrere Präsentationsfolien zu rendern. Verwenden Sie die Methoden von [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) , um Bilder zu laden, `AddImage` mit [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) , um sie einer Präsentation hinzuzufügen, und `ReplaceImage` mit [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) , um ein vorhandenes Präsentationsbild zu aktualisieren.

Ein typisches Anwendungsszenario der neuen API könnte wie folgt aussehen:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // Instanziieren Sie eine entsorgbare Instanz von IImage aus der Datei auf der Festplatte.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // Erstellen Sie ein PowerPoint-Bild, indem Sie eine Instanz von IImage zu den Bildern der Präsentation hinzufügen.
        ppImage = pres.Images.AddImage(image);
    }

    // Fügen Sie ein Bild-Shape auf Folie #1 hinzu.
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // Holen Sie eine Instanz des IImage, das Folie #1 darstellt.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // Speichern Sie das Bild auf der Festplatte.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Alten Code durch Moderne API ersetzen**

Zur Erleichterung der Umstellung wiederholt die Schnittstelle des neuen [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) die separaten Signaturen der Klassen [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) und [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). Im Allgemeinen müssen Sie lediglich den Aufruf der alten Methode, die System.Drawing verwendet, durch die neue ersetzen.

### **Erstellen eines Folien‑Vorschaubildes**

Legacy/überholte API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Moderne API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Erstellen eines Form‑Vorschaubildes**

Legacy/überholte API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Moderne API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Erstellen eines Präsentations‑Vorschaubildes**

Legacy/überholte API:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **Ein Bild zu einer Präsentation hinzufügen**

Legacy/überholte API:

``` csharp
using System.Drawing;
using Aspose.Slides;

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
using Aspose.Slides;

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

## **Veraltete Methoden/Eigenschaften und deren Ersatz in der Modernen API**

### **Presentation**
| Methodensignatur | Ersatz‑Methodensignatur |
|------------------|------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| Methodensignatur | Ersatz‑Methodensignatur |
|------------------|------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Methodensignatur | Ersatz‑Methodensignatur |
|------------------|------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| Methodensignatur | Ersatz‑Methodensignatur |
|------------------|------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Methodensignatur | Ersatz‑Methodensignatur |
|------------------|------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Methodensignatur | Ersatz‑Methodensignatur |
|------------------|------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Methoden-/Eigenschaftssignatur | Ersatz‑Methodensignatur |
|-------------------------------|--------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Methodensignatur | Ersatz‑Methodensignatur |
|------------------|------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Methodensignatur | Ersatz‑Methodensignatur |
|------------------|------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **API-Unterstützung für Graphics und PrinterSettings**

Die Klasse [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) wird für plattformübergreifende Versionen von .NET6 und höher nicht unterstützt. Verwenden Sie in Aspose Slides die Bild‑Rendering‑Methoden der Modern API anstelle der API, die auf [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) rendert:
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Auch die API, die das Drucken über [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) betrifft, hat keinen direkten Ersatz in der Modern API:

[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

### Warum wurde [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) entfernt?

Die Unterstützung für [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) ist in der öffentlichen API veraltet, um die Arbeit mit Rendering und Bildern zu vereinheitlichen, Abhängigkeiten zu plattformspezifischen Bibliotheken zu entfernen und auf einen plattformübergreifenden Ansatz mit [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) umzustellen. Verwenden Sie `GetImage` oder `GetImages` anstelle des Renderns zu [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

### Welchen praktischen Nutzen hat [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) im Vergleich zu [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) vereinheitlicht die Arbeit mit Raster‑ und Vektor‑Bildern, vereinfacht das Speichern in verschiedenen Formaten über [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), reduziert die Abhängigkeit von `System.Drawing` und macht den Code portabler über verschiedene Umgebungen hinweg.

### Wird die Moderne API die Leistung bei der Erstellung von Vorschaubildern beeinflussen?

Der Wechsel von `GetThumbnail` zu `GetImage` verschlechtert die Szenarien nicht: Die neuen Methoden bieten dieselben Möglichkeiten zur Bild‑Erstellung mit Optionen und Größen, wobei die Unterstützung für Rendering‑Optionen erhalten bleibt. Der konkrete Gewinn oder Verlust hängt vom jeweiligen Szenario ab, funktional sind die Ersatzmethoden jedoch äquivalent.