---
title: Bildverarbeitung mit der Modernen API verbessern
linktitle: Moderne API
type: docs
weight: 237
url: /de/net/modern-api/
keywords:
- System.Drawing
- moderne API
- Grafik
- Folien-Vorschaubild
- Folien in Bild
- Form-Vorschaubild
- Form in Bild
- Präsentations-Vorschaubild
- Präsentation zu Bildern
- Bild hinzufügen
- Bild einfügen
- .NET
- C#
- Aspose.Slides
description: "Modernisieren Sie die Folien-Bildverarbeitung, indem Sie veraltete Bild-APIs durch die .NET Moderne API ersetzen, um nahtlose PowerPoint- und OpenDocument-Automatisierung zu ermöglichen."
---

## **Einführung**

Historisch hat Aspose Slides eine Abhängigkeit von System.Drawing und stellt in der öffentlichen API die folgenden Klassen daraus bereit:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Ab Version 24.4 ist diese öffentliche API als veraltet markiert.

Da die Unterstützung von System.Drawing in .NET6 und höher für Nicht‑Windows‑Versionen entfernt wurde ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), hat Slides einen Ansatz mit zwei Bibliotheks‑Versionen implementiert:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – Unterstützung für .NET6+ unter Windows, .NETStandard für Windows/Linux/macOS, .NETFramework 2+ (Windows).
  - hat eine Abhängigkeit von [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – Windows/Linux/macOS‑Version ohne Abhängigkeiten.

Der Nachteil von [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) ist, dass es seine eigene Version von System.Drawing im selben Namespace implementiert (um die Abwärtskompatibilität der öffentlichen API zu gewährleisten). Wird Aspose.Slides.NET6.CrossPlatform gleichzeitig mit System.Drawing aus .NETFramework oder dem System.Drawing.Common‑Paket verwendet, entsteht ein Namenskonflikt, sofern kein Alias verwendet wird.

Um die Abhängigkeiten von System.Drawing im Hauptpaket Aspose.Slides.NET zu entfernen, haben wir die sogenannte „Modern API“ eingeführt – d. h. die API, die anstelle der veralteten verwendet werden soll und deren Signaturen keine Abhängigkeiten mehr von den Typen Image und Bitmap aus System.Drawing enthalten. PrinterSettings und Graphics sind als veraltet markiert und ihre Unterstützung wurde aus der öffentlichen Slides‑API entfernt.

Die Entfernung der veralteten öffentlichen API mit Abhängigkeiten von System.Drawing erfolgt in Release 24.8.

## **Moderne API**

Folgende Klassen und Aufzählungen wurden zur öffentlichen API hinzugefügt:

- Aspose.Slides.IImage – stellt das Raster‑ oder Vektor‑Bild dar.
- Aspose.Slides.ImageFormat – beschreibt das Dateiformat des Bildes.
- Aspose.Slides.Images – Methoden zum Instanziieren und Arbeiten mit dem IImage‑Interface.

Bitte beachten Sie, dass IImage disposable ist (es implementiert das IDisposable‑Interface und sollte in einem using‑Block oder auf andere bequeme Weise freigegeben werden).

Ein typisches Anwendungsbeispiel der neuen API könnte wie folgt aussehen:
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // instanziieren Sie eine disposable Instanz von IImage aus der Datei auf der Festplatte.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // erstellen Sie ein PowerPoint-Bild, indem Sie eine Instanz von IImage zu den Bildern der Präsentation hinzufügen.
        ppImage = pres.Images.AddImage(image);
    }

    // fügen Sie ein Bild-Shape auf Folie #1 hinzu
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // erhalten Sie eine Instanz von IImage, die Folie #1 darstellt.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // speichern Sie das Bild auf der Festplatte.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```


## **Alten Code durch Moderne API ersetzen**

Zur Erleichterung der Migration wiederholt das Interface des neuen IImage die separaten Signaturen der Klassen Image und Bitmap. Im Allgemeinen müssen Sie lediglich den Aufruf der alten Methode aus System.Drawing durch den neuen ersetzen.

### **Erstellen eines Folien‑Thumbnails**

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


### **Erstellen eines Shape‑Thumbnails**

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


### **Erstellen eines Präsentations‑Thumbnails**

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


### **Ein Bild zu einer Präsentation hinzufügen**

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

## **Methoden/Eigenschaften, die entfernt werden und deren Ersatz in der Modernen API**

### **Presentation**
| Method Signature                               | Replacement Method Signature                             |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | Will be deleted completely |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | Will be deleted completely |
| public void Print()                           | Will be deleted completely |
| public void Print(PrinterSettings printerSettings) | Will be deleted completely |
| public void Print(string printerName)         | Will be deleted completely |
| public void Print(PrinterSettings printerSettings, string presName) | Will be deleted completely |

### **Shape**
| Method Signature                                                      | Replacement Method Signature                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail()                                          | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Method Signature                                                      | Replacement Method Signature                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY)                | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail()                                         | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options)                | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize)                           | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options)                    | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | Will be deleted completely |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | Will be deleted completely |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | Will be deleted completely |

### **Output**
| Method Signature                                                | Replacement Method Signature                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image)               | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Method Signature                          | Replacement Method Signature               |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image)           | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Method Signature                                         | Replacement Method Signature                            |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image)           | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Method/Property Signature                     | Replacement Method Signature   |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage)   | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; }          | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Method Signature                                          | Replacement Method Signature                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor)                     | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Method Signature                                          | Replacement Method Signature                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Unterstützung für Graphics und PrinterSettings wird eingestellt**

Die Klasse [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) wird für plattformübergreifende Versionen von .NET6 und höher nicht unterstützt. In Aspose Slides wird der Teil der API, der sie verwendet, entfernt:
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Auch der Teil der API, der das Drucken betrifft, wird entfernt:

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

**Warum wurde System.Drawing.Graphics entfernt?**

Die Unterstützung für `Graphics` wird aus der öffentlichen API entfernt, um die Arbeit mit Rendering und Bildern zu vereinheitlichen, Abhängigkeiten von plattformspezifischen Bibliotheken zu eliminieren und auf einen plattformübergreifenden Ansatz mit [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) zu setzen. Alle Rendering‑Methoden, die `Graphics` verwenden, werden entfernt.

**Welchen praktischen Nutzen hat IImage im Vergleich zu Image/Bitmap?**

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) vereinheitlicht die Arbeit mit Raster‑ und Vektorbildern, vereinfacht das Speichern in verschiedene Formate über [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), reduziert die Abhängigkeit von `System.Drawing` und macht den Code portabler über verschiedene Umgebungen hinweg.

**Wird die Moderne API die Performance bei der Erzeugung von Thumbnails beeinflussen?**

Der Wechsel von `GetThumbnail` zu `GetImage` verschlechtert die Szenarien nicht: Die neuen Methoden bieten dieselben Möglichkeiten zur Bildgenerierung mit Optionen und Größen, während sie weiterhin Rendering‑Optionen unterstützen. Der konkrete Gewinn oder Verlust hängt vom jeweiligen Szenario ab, funktional sind die Ersatzmethoden jedoch äquivalent.