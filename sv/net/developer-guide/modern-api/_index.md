---
title: Förbättra bildbehandling med Modern API
linktitle: Modern API
type: docs
weight: 234
url: /sv/net/modern-api/
keywords:
- System.Drawing
- modernt API
- ritning
- bildminiatyr
- bildspel till bild
- formminiatyr
- form till bild
- presentationsminiatyr
- presentation till bilder
- lägg till bild
- lägg till bild
- .NET
- C#
- Aspose.Slides
description: "Modernisera bildbehandling för bildspel genom att ersätta föråldrade bild-API:er med .NET Modern API för sömlös PowerPoint- och OpenDocument‑automatisering."
---
## **Introduktion**

Historiskt har Aspose Slides ett beroende av System.Drawing och har i det offentliga API:et följande klasser därifrån:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Från och med version 24.4 är detta offentliga API markerat som föråldrat.

Eftersom stöd för System.Drawing i versionerna .NET 6 och senare har tagits bort för icke‑Windows‑versioner ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), har Slides implementerat ett två‑paket‑förhållningssätt:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – stöd för .NET 6+ för Windows, .NETStandard för Windows/Linux/macOS, .NETFramework 2+ (Windows).  
  - har ett beroende på [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – Windows/Linux/macOS‑version utan beroenden.

Det som är besvärligt med [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) är att den implementerar sin egen version av System.Drawing i samma namnrymd (för att stödja bakåtkompatibilitet med det offentliga API:et). Därför uppstår en namnkonflikt när Aspose.Slides.NET6.CrossPlatform och System.Drawing från .NET Framework eller System.Drawing.Common‑paketet används samtidigt, såvida inte ett alias används.

För att bli av med beroendet på System.Drawing i huvudpaketet Aspose.Slides.NET har vi lagt till det så kallade “Modern API” – dvs. API‑et som ska användas i stället för det föråldrade, vars signaturer innehåller beroenden på följande typer från System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) och [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) och [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) är markerade som föråldrade och deras stöd har tagits bort från det offentliga Slides‑API:et.

I nuvarande versioner bör det offentliga API som beror på System.Drawing betraktas som legacy/föråldrat. Använd Modern API för ny kod och vid migrering av befintliga bildbehandlingsflöden.

## **Modern API**

Följande klasser och uppräkningar har lagts till i det offentliga API:et:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) – representerar raster‑ eller vektorbilder.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) – representerar filformatet för bilden.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) – metoder för att instansiera och arbeta med [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)-gränssnittet.

Observera att [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) är disposable (den implementerar [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable)-gränssnittet och bör användas i en `using`‑sats eller på annat lämpligt sätt).

Använd `GetImage` för att rendera en enda bild eller form. Använd `GetImages` för att rendera flera presentationsbilder. Använd metoderna i [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) för att ladda bilder, `AddImage` med [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) för att lägga till dem i en presentation och `ReplaceImage` med [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) för att uppdatera en befintlig presentationsbild.

Ett typiskt användningsscenario för det nya API:t kan se ut så här:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // instansiera en disposable-instans av IImage från filen på disken.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // skapa en PowerPoint-bild genom att lägga till en IImage-instans till presentationens bilder.
        ppImage = pres.Images.AddImage(image);
    }

    // lägg till en bildform på bild #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // hämta en IImage-instans som representerar bild #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // spara bilden på disken.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Ersätta gammal kod med Modern API**

För att underlätta övergången upprepar gränssnittet för den nya [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) de separata signaturerna för klasserna [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) och [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). I princip behöver du bara byta ut anropet till den gamla metoden som använder System.Drawing mot den nya.

### **Hämta en bildminiatyr för en bild**

Legacy/föråldrat API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Modern API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Hämta en bildminiatyr för en form**

Legacy/föråldrat API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Modern API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Hämta en bildminiatyr för en presentation**

Legacy/föråldrat API:

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

Modern API:

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

### **Lägga till en bild i en presentation**

Legacy/föråldrat API:

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

Modern API:

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

## **Föråldrade metoder/egenskaper och deras ersättning i Modern API**

### **Presentation**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | Ingen ersättning i Modern API |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | Ingen ersättning i Modern API |
| public void Print() | Ingen ersättning i Modern API |
| public void Print(PrinterSettings printerSettings) | Ingen ersättning i Modern API |
| public void Print(string printerName) | Ingen ersättning i Modern API |
| public void Print(PrinterSettings printerSettings, string presName) | Ingen ersättning i Modern API |

### **Shape**
| Metodsignatur | Ersättningsmetodsignatur |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Metodsignatur | Ersättningsmetodsignatur |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | Ingen ersättning i Modern API |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | Ingen ersättning i Modern API |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | Ingen ersättning i Modern API |

### **Output**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Metodsignatur | Ersättningsmetodsignatur |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Metodsignatur | Ersättningsmetodsignatur |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Metod/Egenskapssignatur | Ersättningsmetodsignatur |
|--------------------------|---------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **API‑stöd för Graphics och PrinterSettings**

Klassen [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) stöds inte i cross‑platform‑versioner av .NET 6 och högre. I Aspose Slides ska du använda bildrenderingsmetoderna i Modern API i stället för API‑et som renderar till [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Dessutom har API‑et som är kopplat till utskrift via [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) ingen direkt ersättning i Modern API:

[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **Vanliga frågor**

### Varför togs [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) bort?

Stödet för [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) är föråldrat i det offentliga API:et för att förena rendering och bildhantering, eliminera beroenden till plattforms‑specifik kod och byta till ett cross‑platform‑tillvägagångssätt med [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Använd `GetImage` eller `GetImages` i stället för att rendera till [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

### Vad är det praktiska fördelen med [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) jämfört med [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) förenar arbete med både raster‑ och vektorbilder, förenklar sparande till olika format via [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), minskar beroendet av `System.Drawing` och gör koden mer portabel över olika miljöer.

### Påverkar Modern API prestandan när man genererar miniatyrer?

Att byta från `GetThumbnail` till `GetImage` försämrar inte scenarierna: de nya metoderna erbjuder samma möjlighet att producera bilder med alternativ och storlekar, samtidigt som de behåller stöd för renderingsalternativ. Den specifika vinsten eller förlusten beror på scenariot, men funktionellt är ersättningarna likvärdiga.