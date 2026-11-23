---
title: "Ulepsz przetwarzanie obrazów za pomocą Nowoczesnego API"
linktitle: "Nowoczesne API"
type: docs
weight: 234
url: /pl/net/modern-api/
keywords:
- System.Drawing
- nowoczesne API
- rysowanie
- miniatura slajdu
- slajd do obrazu
- miniatura kształtu
- kształt do obrazu
- miniatura prezentacji
- prezentacja do obrazów
- dodaj obraz
- dodaj zdjęcie
- .NET
- C#
- Aspose.Slides
description: "Zmodernizuj przetwarzanie obrazów slajdów, zastępując przestarzałe interfejsy API przetwarzania obrazów Nowoczesnym API .NET, aby uzyskać płynną automatyzację PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Historycznie Aspose Slides miał zależność od System.Drawing i posiadał w publicznym API następujące klasy z tej biblioteki:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Od wersji 24.4 ten publiczny interfejs API jest oznaczony jako przestarzały.

Od wersji .NET 6 i wyższych obsługa System.Drawing została usunięta z wersji nie‑Windows ([przerwa w kompatybilności](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides wprowadził podejście dwupakietowe:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – wsparcie dla .NET6+ na Windows, .NETStandard dla Windows/Linux/macOS, .NETFramework 2+ (Windows).  
  - zależy od [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – wersja Windows/Linux/macOS bez zależności.

Uciążliwością [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) jest to, że implementuje własną wersję System.Drawing w tej samej przestrzeni nazw (w celu zachowania zgodności wstecznej z publicznym API). W efekcie, gdy jednocześnie używane są Aspose.Slides.NET6.CrossPlatform oraz System.Drawing z .NET Framework lub pakietu System.Drawing.Common, dochodzi do konfliktu nazw, chyba że użyty zostanie alias.

Aby usunąć zależności od System.Drawing w głównym pakiecie Aspose.Slides.NET, dodaliśmy tzw. „Nowoczesne API” – czyli API, które należy używać zamiast przestarzałego, a którego sygnatury nie zawierają zależności od typów System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) i [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) i [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) zostały oznaczone jako przestarzałe i ich obsługa została usunięta z publicznego API Slides.

W bieżących wersjach traktuj publiczne API zależne od System.Drawing jako dziedzictwo/przestarzałe. Używaj Nowoczesnego API w nowym kodzie oraz przy migracji istniejących przepływów przetwarzania obrazów.

## **Nowoczesne API**

Dodano następujące klasy i wyliczenia do publicznego API:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) – reprezentuje obraz rastrowy lub wektorowy.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) – reprezentuje format pliku obrazu.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) – metody służące do tworzenia i pracy z interfejsem [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).

Należy pamiętać, że [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) jest obiektem zwalniającym zasoby (implementuje interfejs [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) i powinien być używany w bloku `using` lub w inny wygodny sposób).

Użyj `GetImage`, aby wyrenderować pojedynczy slajd lub kształt. Użyj `GetImages`, aby wyrenderować wiele slajdów prezentacji. Korzystaj z metod z [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) aby wczytywać obrazy, `AddImage` z [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) aby dodać je do prezentacji oraz `ReplaceImage` z [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) aby zaktualizować istniejący obraz w prezentacji.

Typowy scenariusz użycia nowego API może wyglądać następująco:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // utwórz zwalnialną instancję IImage z pliku na dysku.
    using (IImage image = Images.FromFile("image.png"))
    {
        // utwórz obraz PowerPoint, dodając instancję IImage do obrazów prezentacji.
        ppImage = pres.Images.AddImage(image);
    }

    // dodaj kształt obrazu na slajdzie #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // pobierz instancję IImage reprezentującą slajd #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // zapisz obraz na dysku.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Zastępowanie starego kodu nowym API**

Dla ułatwienia przejścia interfejs nowego [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) powiela oddzielne sygnatury klas [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) i [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). Generalnie wystarczy zamienić wywołanie starej metody wykorzystującej System.Drawing na nowe.

### **Pobieranie miniatury slajdu**

Przestarzałe API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Nowoczesne API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Pobieranie miniatury kształtu**

Przestarzałe API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Nowoczesne API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Pobieranie miniatury prezentacji**

Przestarzałe API:

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

Nowoczesne API:

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

### **Dodawanie obrazu do prezentacji**

Przestarzałe API:

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

Nowoczesne API:

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

## **Przestarzałe metody/właściwości i ich zamienniki w Nowoczesnym API**

### **Presentation**
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
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
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
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
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Sygnatura metody/właściwości | Sygnatura metody zamiennika |
|------------------------------|-----------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Obsługa API dla Graphics i PrinterSettings**

Klasa [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) nie jest obsługiwana w wersjach wieloplatformowych .NET 6 i wyższych. W Aspose Slides użyj metod renderowania obrazu z Nowoczesnego API zamiast API renderującego do [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Ponadto API związane z drukowaniem przy użyciu [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) nie ma bezpośredniego zamiennika w Nowoczesnym API:

[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

### Dlaczego [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) został usunięty?

Obsługa [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) została oznaczona jako przestarzała w publicznym API w celu ujednolicenia pracy z renderowaniem i obrazami, usunięcia powiązań z zależnościami specyficznymi dla platformy oraz przejścia na podejście wieloplatformowe z [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Używaj `GetImage` lub `GetImages` zamiast renderowania do [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

### Jaka jest praktyczna korzyść z używania [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) w porównaniu do [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) łączy pracę zarówno z obrazami rastrowymi, jak i wektorowymi, upraszcza zapisywanie w różnych formatach za pośrednictwem [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), zmniejsza zależność od `System.Drawing` i sprawia, że kod jest bardziej przenośny między środowiskami.

### Czy Nowoczesne API wpłynie na wydajność generowania miniatur?

Przejście z `GetThumbnail` na `GetImage` nie pogarsza scenariuszy: nowe metody oferują te same możliwości tworzenia obrazów z opcjami i rozmiarami, zachowując wsparcie dla opcji renderowania. Konkretne zyski lub spadki wydajności zależą od scenariusza, ale funkcjonalnie zamienniki są równoważne.