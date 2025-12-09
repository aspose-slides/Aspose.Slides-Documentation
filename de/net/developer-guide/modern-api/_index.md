---
title: Bildverarbeitung mit der Modernen API verbessern
linktitle: Moderne API
type: docs
weight: 237
url: /de/net/modern-api/
keywords:
- System.Drawing
- moderne API
- Zeichnen
- Folien-Vorschaubild
- Folie zu Bild
- Form-Vorschaubild
- Form zu Bild
- Präsentations-Vorschaubild
- Präsentation zu Bildern
- Bild hinzufügen
- Grafik hinzufügen
- .NET
- C#
- Aspose.Slides
description: "Modernisieren Sie die Bildverarbeitung von Folien, indem Sie veraltete Bild‑APIs durch die .NET Moderne API ersetzen, um eine nahtlose PowerPoint‑ und OpenDocument‑Automatisierung zu ermöglichen."
---

## **Einleitung**

Historisch hat Aspose Slides eine Abhängigkeit von System.Drawing und stellt in der öffentlichen API die folgenden Klassen daraus zur Verfügung:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Ab Version 24.4 wird diese öffentliche API als veraltet markiert.

Da die System.Drawing-Unterstützung in den Versionen .NET6 und höher für nicht‑Windows‑Versionen entfernt wurde ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), hat Slides einen Ansatz mit zwei Bibliotheksversionen implementiert:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - Unterstützung für .NET6+ unter Windows, .NETStandard für Windows/Linux/MacOS, .NETFramework 2+ (Windows).  
  - hat eine Abhängigkeit von [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - Windows/Linux/MacOS‑Version ohne Abhängigkeiten.

Der Nachteil von [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) ist, dass es seine eigene Version von System.Drawing im selben Namespace implementiert (um die Rückwärtskompatibilität mit der öffentlichen API zu unterstützen). Daher kommt es zu einem Namenskonflikt, wenn Aspose.Slides.NET6.CrossPlatform und System.Drawing aus .NETFramework oder dem System.Drawing.Common‑Paket gleichzeitig verwendet werden, sofern kein Alias verwendet wird.

Um die Abhängigkeiten von System.Drawing im Hauptpaket Aspose.Slides.NET zu entfernen, haben wir die sogenannte „Moderne API“ hinzugefügt – also die API, die anstelle der veralteten verwendet werden soll und deren Signaturen Abhängigkeiten von den folgenden Typen aus System.Drawing enthalten: Image und Bitmap. PrinterSettings und Graphics sind als veraltet deklariert und ihre Unterstützung wurde aus der öffentlichen Slides‑API entfernt.

Die Entfernung der veralteten öffentlichen API mit Abhängigkeiten von System.Drawing erfolgt in Release 24.8.

## **Moderne API**

Folgende Klassen und Enums wurden der öffentlichen API hinzugefügt:

- Aspose.Slides.IImage - repräsentiert das Raster‑ oder Vektor‑Bild.
- Aspose.Slides.ImageFormat - repräsentiert das Dateiformat des Bildes.
- Aspose.Slides.Images - Methoden zum Instanziieren und Arbeiten mit der IImage‑Schnittstelle.

Bitte beachten Sie, dass IImage entsorgbar ist (es implementiert das IDisposable‑Interface und sollte in einem using‑Block oder auf andere bequeme Weise entsorgt werden).

Ein typisches Szenario zur Verwendung der neuen API kann wie folgt aussehen:
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // Instanziiere eine disposable Instanz von IImage aus der Datei auf der Festplatte.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // Erstelle ein PowerPoint-Bild, indem du eine Instanz von IImage zu den Bildern der Präsentation hinzufügst.
        ppImage = pres.Images.AddImage(image);
    }

    // Füge eine Bildform auf Folie #1 hinzu
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // Erhalte eine Instanz von IImage, die Folie #1 darstellt.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // Speichere das Bild auf der Festplatte.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```


## **Ersetzen von altem Code mit der Modernen API**

Zur Erleichterung der Umstellung wiederholt die Schnittstelle von IImage die separaten Signaturen der Klassen Image und Bitmap. Im Allgemeinen müssen Sie lediglich den Aufruf der alten Methode, die System.Drawing verwendet, durch die neue ersetzen.

### **Abrufen eines Folien‑Vorschaubildes**

Code, der eine veraltete API verwendet:
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


### **Abrufen eines Shape‑Vorschaubildes**

Code, der eine veraltete API verwendet:
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


### **Abrufen eines Präsentations‑Vorschaubildes**

Code, der eine veraltete API verwendet:
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

Code, der eine veraltete API verwendet:
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


## **Methoden/Eigenschaften, die entfernt werden und ihre Ersatz in der Modernen API**

### **Präsentation**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|-----------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | Wird vollständig entfernt |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | Wird vollständig entfernt |
| public void Print() | Wird vollständig entfernt |
| public void Print(PrinterSettings printerSettings) | Wird vollständig entfernt |
| public void Print(string printerName) | Wird vollständig entfernt |
| public void Print(PrinterSettings printerSettings, string presName) | Wird vollständig entfernt |

### **Shape**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|-----------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|-----------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | Wird vollständig entfernt |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | Wird vollständig entfernt |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | Wird vollständig entfernt |

### **Output**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|-----------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|-----------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|-----------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Methoden-/Eigenschaftssignatur | Ersetzungsmethodensignatur |
|--------------------------------|-----------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|-----------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|-----------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Unterstützung für Graphics und PrinterSettings wird eingestellt**

Die Klasse [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) wird für plattformübergreifende Versionen von .NET6 und höher nicht unterstützt. In Aspose Slides wird der Teil der API, der sie verwendet, entfernt:
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Auch der Teil der API, der mit dem Drucken zusammenhängt, wird entfernt:

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

# **FAQ**

**Warum wurde System.Drawing.Graphics entfernt?**

Die Unterstützung für `Graphics` wird aus der öffentlichen API entfernt, um die Arbeit mit Rendering und Bildern zu vereinheitlichen, Abhängigkeiten von plattformspezifischen Bibliotheken zu eliminieren und zu einem plattformübergreifenden Ansatz mit [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) zu wechseln. Alle Rendering‑Methoden zu `Graphics` werden entfernt.

**Welchen praktischen Nutzen hat IImage im Vergleich zu Image/Bitmap?**

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) vereinheitlicht die Arbeit mit Raster‑ und Vektor‑Bildern, vereinfacht das Speichern in verschiedene Formate über [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), reduziert die Abhängigkeit von `System.Drawing` und macht den Code portabler über verschiedene Umgebungen hinweg.

**Beeinflusst die Moderne API die Performance beim Erzeugen von Vorschaubildern?**

Der Umstieg von `GetThumbnail` zu `GetImage` verschlechtert die Szenarien nicht: Die neuen Methoden bieten dieselben Möglichkeiten zur Erzeugung von Bildern mit Optionen und Größen, während sie weiterhin Rendering‑Optionen unterstützen. Der konkrete Gewinn oder Verlust hängt vom jeweiligen Szenario ab, funktional sind die Ersatzmethoden jedoch gleichwertig.