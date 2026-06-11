---
title: Förbättra bildbehandling med det moderna API:et
linktitle: Modernt API
type: docs
weight: 237
url: /sv/net/modern-api/
keywords:
- System.Drawing
- modernt API
- ritning
- bildminiatyr
- bild till bild
- formminiatyr
- form till bild
- presentation miniatyr
- presentation till bilder
- lägg till bild
- lägg till bild
- .NET
- C#
- Aspose.Slides
description: "Modernisera bildbehandling för bildspel genom att ersätta föråldrade bild-API:er med .NET Modern API för sömlös PowerPoint- och OpenDocument‑automatisering."
---
## **Introduktion**

Historiskt har Aspose Slides ett beroende på System.Drawing och har i det offentliga API:et följande klasser från där:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Från version 24.4 är detta offentliga API deklarerat som föråldrat.

Eftersom stöd för System.Drawing i versioner .NET6 och senare har tagits bort för icke‑Windows‑versioner ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), har Slides implementerat ett två‑paket‑tillvägagångssätt:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – stöd för .NET6+ för Windows, .NETStandard för Windows/Linux/MacOS, .NETFramework 2+ (Windows).
  - har ett beroende på [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – Windows/Linux/MacOS‑version utan beroenden.

Problemet med [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) är att den implementerar sin egen version av System.Drawing i samma namnrymd (för att stödja bakåtkompatibilitet med det offentliga API:et). Således, när Aspose.Slides.NET6.CrossPlatform och System.Drawing från .NET Framework eller System.Drawing.Common‑paketet används samtidigt, uppstår en namnkonflikt om inte alias används.

För att bli av med beroenden på System.Drawing i huvudpaketet Aspose.Slides.NET har vi lagt till det så kallade “Modern API” – det vill säga API:et som bör användas i stället för det föråldrade, vars signaturer innehåller beroenden på följande typer från System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) och [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) och [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) är deklarerade som föråldrade och deras stöd har tagits bort från det offentliga Slides‑API:et.

I nuvarande versioner bör det offentliga API som beror på System.Drawing betraktas som legacy/föråldrat. Använd Modern API för ny kod och när befintliga bildbehandlingsarbetsflöden migreras.

## **Modern API**

Följande klasser och uppräkningar har lagts till i det offentliga API:et:
- [Aspose.Slides.IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) – representerar raster‑ eller vektorbilden.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/imageformat/) – representerar bildens filformat.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/sv/net/aspose.slides/images/) – metoder för att instansiera och arbeta med [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/)-gränssnittet.

Observera att [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) är avyttringbar (den implementerar [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable)-gränssnittet och dess användning bör omslutas av en using‑sats eller avyttras på annat lämpligt sätt).

Använd `GetImage` för att rendera en enskild bild eller form. Använd `GetImages` för att rendera flera presentationsbilder. Använd [Images](https://reference.aspose.com/slides/sv/net/aspose.slides/images/)‑metoder för att ladda bilder, `AddImage` med [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) för att lägga till dem i en presentation, och `ReplaceImage` med [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) för att uppdatera en befintlig presentationsbild.

Ett typiskt scenario för att använda det nya API:et kan se ut som följer:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // instansiera en avyttringbar instans av IImage från filen på disken.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // skapa en PowerPoint-bild genom att lägga till en instans av IImage till presentationens bilder.
        ppImage = pres.Images.AddImage(image);
    }

    // lägg till en bildform på bild #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // hämta en instans av IImage som representerar bild #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // spara bilden på disken.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Byta ut gammal kod med Modern API**

För att underlätta övergången upprepar gränssnittet för den nya [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) de separata signaturerna för [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)- och [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)-klasserna. I allmänhet behöver du bara ersätta anropet till den gamla metoden som använder System.Drawing med den nya.

### **Hämta en bildminiatyr för en bild**

Legacy/deprecated API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Modern API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Hämta en formminiatyr**

Legacy/deprecated API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Modern API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Hämta en presentationsminiatyr**

Legacy/deprecated API:

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

Modern API:

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

### **Lägga till en bild i en presentation**

Legacy/deprecated API:

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

Modern API:

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

## **Föråldrade metoder/egenskaper och deras ersättning i Modern API**

### **Presentation**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| Metodsignatur | Ersättningsmetodsignatur |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Metodsignatur | Ersättningsmetodsignatur |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/sv/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Metodsignatur | Ersättningsmetodsignatur |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/sv/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Metodsignatur | Ersättningsmetodsignatur |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/sv/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Metod/Egenskapssignatur | Ersättningsmetodsignatur |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/sv/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/sv/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/sv/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/sv/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/sv/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **API‑stöd för Graphics och PrinterSettings**

Klassen [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) stöds inte för plattformsoberoende versioner av .NET6 och senare. I Aspose Slides, använd Modern API‑metoder för bildrendering i stället för API:et som renderar till [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/rendertographics/#rendertographics_5)

API:et som är relaterat till utskrift via [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) har ingen direkt Modern API‑ersättning:

[IPresentation](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

**Varför togs [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) bort?**

Stödet för [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) är föråldrat i det offentliga API:et för att förena arbete med rendering och bilder, eliminera beroenden till plattforms‑specifika komponenter och gå över till ett plattformsoberoende tillvägagångssätt med [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/). Använd `GetImage` eller `GetImages` i stället för rendering till [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

**Vilken praktisk nytta har [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) jämfört med [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?**

[IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) förenar hantering av både raster‑ och vektorbilder, förenklar sparande till olika format via [ImageFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/imageformat/), minskar beroendet av `System.Drawing` och gör koden mer portabel mellan olika miljöer.

**Kommer Modern API att påverka prestandan vid generering av miniatyrer?**

Att byta från `GetThumbnail` till `GetImage` försämrar inte scenarierna: de nya metoderna ger samma möjligheter att producera bilder med alternativ och storlekar, samtidigt som stöd för renderingsalternativ behålls. Den konkreta vinsten eller förlusten beror på scenariot, men funktionellt är ersättningarna ekvivalenta.