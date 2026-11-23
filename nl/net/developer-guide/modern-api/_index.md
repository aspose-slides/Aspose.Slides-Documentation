---
title: Verbeter beeldverwerking met de Moderne API
linktitle: Moderne API
type: docs
weight: 234
url: /nl/net/modern-api/
keywords:
- System.Drawing
- moderne API
- tekenen
- dia-miniatuur
- dia naar afbeelding
- vorm-miniatuur
- vorm naar afbeelding
- presentatie-miniatuur
- presentatie naar afbeeldingen
- afbeelding toevoegen
- afbeelding toevoegen
- .NET
- C#
- Aspose.Slides
description: "Moderniseer de verwerking van dia-afbeeldingen door verouderde beeld-API's te vervangen door de .NET Moderne API voor naadloze PowerPoint- en OpenDocument-automatisering."
---
## **Inleiding**

Historisch gezien heeft Aspose Slides een afhankelijkheid van System.Drawing en bevat de openbare API de volgende klassen daarvan:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Vanaf versie 24.4 wordt deze openbare API als verouderd gemarkeerd.

Sinds System.Drawing-ondersteuning in versies .NET6 en hoger is verwijderd voor niet‑Windows versies ([kritieke wijziging](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), heeft Slides een twee‑pakketbenadering geïmplementeerd:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – ondersteuning voor .NET6+ voor Windows, .NETStandard voor Windows/Linux/MacOS, .NETFramework 2+ (Windows).
  - heeft een afhankelijkheid van [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – Windows/Linux/MacOS‑versie zonder afhankelijkheden.

Het ongemak van [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) is dat het zijn eigen versie van System.Drawing implementeert in dezelfde namespace (om terugwaartse compatibiliteit met de openbare API te ondersteunen). Wanneer Aspose.Slides.NET6.CrossPlatform en System.Drawing vanuit .NET Framework of het System.Drawing.Common‑pakket tegelijkertijd worden gebruikt, ontstaat er een naamconflict tenzij een alias wordt gebruikt.

Om de afhankelijkheden van System.Drawing in het hoofdpakket Aspose.Slides.NET te verwijderen, hebben we de zogenaamde “Moderne API” toegevoegd – dat wil zeggen de API die in plaats van de verouderde moet worden gebruikt, waarvan de handtekeningen afhankelijkheden bevatten van de volgende typen uit System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) en [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) en [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) worden als verouderd gemarkeerd en hun ondersteuning is verwijderd uit de openbare Slides‑API.

In de huidige versies moet de openbare API die afhankelijk is van System.Drawing als legacy/verouderd worden behandeld. Gebruik de Moderne API voor nieuwe code en bij het migreren van bestaande beeldverwerkingsworkflows.

## **Moderne API**

De volgende klassen en enumeraties zijn aan de openbare API toegevoegd:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) – vertegenwoordigt de raster‑ of vectorafbeelding.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) – vertegenwoordigt het bestandsformaat van de afbeelding.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) – methoden om de [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) interface te instantiëren en ermee te werken.

Let op dat [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) verwijderbaar is (het implementeert de [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) interface en het gebruik moet worden omgeven door een using‑statement of op een andere handige manier worden afgevoerd).

Gebruik `GetImage` om een enkele dia of vorm te renderen. Gebruik `GetImages` om meerdere presentatiedia’s te renderen. Gebruik de methoden van [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) om afbeeldingen te laden, `AddImage` met [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) om ze aan een presentatie toe te voegen, en `ReplaceImage` met [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) om een bestaande presentatieweergave bij te werken.

Een typisch scenario van het gebruik van de nieuwe API kan er als volgt uitzien:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // maak een verwijderbaar exemplaar van IImage aan vanuit het bestand op de schijf.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // maak een PowerPoint-afbeelding door een IImage‑exemplaar toe te voegen aan de afbeeldingen van de presentatie.
        ppImage = pres.Images.AddImage(image);
    }

    // voeg een afbeelding‑vorm toe aan dia #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // verkrijg een IImage‑exemplaar dat dia #1 voorstelt.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // sla de afbeelding op de schijf op.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Vervangen van oude code met Moderne API**

Om de transitie te vergemakkelijken herhaalt de interface van de nieuwe [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) de afzonderlijke handtekeningen van de [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)‑ en [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)‑klassen. In het algemeen hoef je alleen de aanroep van de oude methode die System.Drawing gebruikt te vervangen door de nieuwe.

### **Een dia-miniatuur ophalen**

Legacy/verouderde API:

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

### **Een vorm-miniatuur ophalen**

Legacy/verouderde API:

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

### **Een presentatieminiatuur ophalen**

Legacy/verouderde API:

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

### **Een afbeelding aan een presentatie toevoegen**

Legacy/verouderde API:

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

## **Verouderde methoden/eigenschappen en hun vervanging in Moderne API**

### **Presentation**
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|---------------------------------|
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
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|---------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|---------------------------------|
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
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|---------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|---------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|---------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Methode/ Eigenschap | Vervangende methodehandtekening |
|---------------------|---------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|---------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|---------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **API-ondersteuning voor Graphics en PrinterSettings**

De [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)‑klasse wordt niet ondersteund voor cross‑platformversies van .NET6 en hoger. In Aspose Slides gebruik je de Moderne API‑methoden voor beeld‑rendering in plaats van de API die naar [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) rendert:
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Ook heeft de API die gerelateerd is aan afdrukken via [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) geen directe Moderne API‑vervanging:

[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

### Waarom is [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) verwijderd?

Ondersteuning voor [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) is verouderd in de openbare API om het werk met rendering en afbeeldingen te verenigen, afhankelijkheden van platform‑specifieke bibliotheken te elimineren en over te stappen op een cross‑platformbenadering met [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Gebruik `GetImage` of `GetImages` in plaats van renderen naar [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

### Wat is het praktische voordeel van [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) ten opzichte van [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) verenigt het werken met zowel raster‑ als vectorafbeeldingen, vereenvoudigt het opslaan naar verschillende formaten via [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), vermindert de afhankelijkheid van `System.Drawing` en maakt code draagbaarder over verschillende omgevingen.

### Heeft de Moderne API invloed op de prestaties bij het genereren van miniaturen?

Het overstappen van `GetThumbnail` naar `GetImage` verslechtert de scenario’s niet: de nieuwe methoden bieden dezelfde mogelijkheden om afbeeldingen te produceren met opties en afmetingen, terwijl ze de ondersteuning voor rendering‑opties behouden. De specifieke winst of verlies hangt af van het scenario, maar functioneel zijn de vervangingen equivalent.