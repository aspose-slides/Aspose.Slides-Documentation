---
title: Verbeter beeldverwerking met de Moderne API
linktitle: Moderne API
type: docs
weight: 237
url: /nl/net/modern-api/
keywords:
- System.Drawing
- moderne API
- tekenen
- slide-miniatuur
- slide naar afbeelding
- vorm-miniatuur
- vorm naar afbeelding
- presentatie-miniatuur
- presentatie naar afbeeldingen
- afbeelding toevoegen
- foto toevoegen
- .NET
- C#
- Aspose.Slides
description: "Moderniseer de slide-beeldverwerking door verouderde imaging-API's te vervangen door de .NET Moderne API voor naadloze PowerPoint- en OpenDocument-automatisering."
---
## **Inleiding**

Historisch gezien heeft Aspose Slides een afhankelijkheid van System.Drawing en bevat de openbare API de volgende klassen daarvan:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Vanaf versie 24.4 wordt deze openbare API gemarkeerd als verouderd.

Aangezien System.Drawing‑ondersteuning in .NET 6 en hoger voor niet‑Windows‑versies is verwijderd ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), heeft Slides een twee‑pakketbenadering geïmplementeerd:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – ondersteuning voor .NET 6+ op Windows, .NETStandard voor Windows/Linux/macOS, .NETFramework 2+ (Windows).  
  - heeft een afhankelijkheid van [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – Windows/Linux/macOS‑versie zonder afhankelijkheden.

Het ongemak van [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) is dat het een eigen versie van System.Drawing implementeert in dezelfde namespace (om backward compatibility met de publieke API te ondersteunen). Daardoor ontstaat er een naamsconflict wanneer Aspose.Slides.NET6.CrossPlatform en System.Drawing van .NET Framework of het System.Drawing.Common‑pakket gelijktijdig worden gebruikt, tenzij een alias wordt toegepast.

Om de afhankelijkheden van System.Drawing in het hoofdpakket Aspose.Slides.NET te elimineren, hebben we de zogenoemde “Moderne API” toegevoegd – d.w.z. de API die in plaats van de verouderde moet worden gebruikt, waarvan de handtekeningen afhankelijk zijn van de volgende types uit System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) en [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) en [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) zijn gemarkeerd als verouderd en hun ondersteuning is verwijderd uit de publieke Slides‑API.

In de huidige versies moet de publieke API die afhankelijk is van System.Drawing als legacy/verouderd worden beschouwd. Gebruik de Moderne API voor nieuwe code en bij het migreren van bestaande beeldverwerkingsworkflows.

## **Moderne API**

De volgende klassen en enumeraties zijn toegevoegd aan de publieke API:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) – vertegenwoordigt het raster‑ of vector‑beeld.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/imageformat/) – vertegenwoordigt het bestandsformaat van het beeld.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/nl/net/aspose.slides/images/) – methoden om een [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/)‑interface te instantieren en te gebruiken.

Let op: [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) is disposable (het implementeert de [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable)‑interface en moet worden omgeven met `using` of op een andere handige manier worden vrijgegeven).

Gebruik `GetImage` om één enkele slide of vorm te renderen. Gebruik `GetImages` om meerdere presentatieslides te renderen. Gebruik de methoden van [Images](https://reference.aspose.com/slides/nl/net/aspose.slides/images/) om beelden te laden, `AddImage` met een [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) om ze aan een presentatie toe te voegen, en `ReplaceImage` met een [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) om een bestaand presentatiefoto bij te werken.

Een typisch scenario met de nieuwe API ziet er als volgt uit:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // instantieer een disposable instantie van IImage vanaf het bestand op de schijf.
    using (IImage image = Images.FromFile("image.png"))
    {
        // maak een PowerPoint‑afbeelding aan door een IImage‑instantie toe te voegen aan de images van de presentatie.
        ppImage = pres.Images.AddImage(image);
    }

    // voeg een afbeeldingvorm toe op slide #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // verkrijg een IImage‑instantie die slide #1 voorstelt.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // sla de afbeelding op de schijf op.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Oude code vervangen door Moderne API**

Om de transitie te vergemakkelijken herhaalt de interface van de nieuwe [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) de afzonderlijke handtekeningen van de klassen [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) en [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). Over het algemeen hoef je alleen de aanroep van de oude methode die System.Drawing gebruikte te vervangen door de nieuwe.

### **Een slide‑miniatuur ophalen**

Legacy/verouderde API:

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

### **Een vorm‑miniatuur ophalen**

Legacy/verouderde API:

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

### **Een presentatieminiatuur ophalen**

Legacy/verouderde API:

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

### **Een afbeelding aan een presentatie toevoegen**

Legacy/verouderde API:

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

## **Verouderde methoden/eigenschappen en hun vervanging in Moderne API**

### **Presentation**
| Methodehandtekening | Vervangende methodehandtekening |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| Methodehandtekening | Vervangende methodehandtekening |
|-----------------------------------------------|-----------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Methodehandtekening | Vervangende methodehandtekening |
|-----------------------------------------------|-----------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| Methodehandtekening | Vervangende methodehandtekening |
|-----------------------------------------------|-----------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/nl/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Methodehandtekening | Vervangende methodehandtekening |
|-------------------------------------------|-----------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/nl/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Methodehandtekening | Vervangende methodehandtekening |
|------------------------------------------|-----------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/nl/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Methode/eigenschap | Vervangende methode |
|---------------------|----------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/nl/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/nl/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Methodehandtekening | Vervangende methodehandtekening |
|-------------------------------------------|-----------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/nl/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/nl/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Methodehandtekening | Vervangende methodehandtekening |
|-------------------------------------------|-----------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/nl/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **API‑ondersteuning voor Graphics en PrinterSettings**

De [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)‑klasse wordt niet ondersteund voor cross‑platform versies van .NET 6 en hoger. In Aspose Slides moet je de Moderne API‑methoden voor beeldrendering gebruiken in plaats van de API die naar [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) rendert:
[ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Ook de API die verband houdt met afdrukken via [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) heeft geen directe Moderne API‑vervanging:

[IPresentation](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

**Waarom is [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) verwijderd?**

Ondersteuning voor [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) is gemarkeerd als verouderd in de publieke API om het werk met renderen en beelden te uniformiseren, afhankelijkheden van platform‑specifieke libraries te elimineren en over te stappen op een cross‑platform aanpak met [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/). Gebruik `GetImage` of `GetImages` in plaats van renderen naar [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

**Wat is het praktische voordeel van [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) ten opzichte van [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?**

[IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) verenigt het werken met zowel raster‑ als vector‑beelden, vereenvoudigt het opslaan naar verschillende formaten via [ImageFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/imageformat/), vermindert de afhankelijkheid van `System.Drawing` en maakt de code draagbaarder tussen verschillende omgevingen.

**Zal de Moderne API de prestaties van het genereren van miniaturen beïnvloeden?**

Overschakelen van `GetThumbnail` naar `GetImage` schaadt de prestaties niet: de nieuwe methoden bieden dezelfde mogelijkheden om beelden met opties en afmetingen te produceren, terwijl ze de render‑opties behouden. De exacte winst of verlies hangt af van het scenario, maar functioneel zijn de vervangingen gelijkwaardig.