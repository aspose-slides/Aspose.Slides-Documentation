---
title: Ulepsz przetwarzanie obrazów za pomocą nowoczesnego API
linktitle: Nowoczesne API
type: docs
weight: 237
url: /pl/net/modern-api/
keywords:
- System.Drawing
- nowoczesne API
- rysowanie
- miniatura slajdu
- slajd na obraz
- miniatura kształtu
- kształt na obraz
- miniatura prezentacji
- prezentacja na obrazy
- dodaj obraz
- dodaj obraz
- .NET
- C#
- Aspose.Slides
description: "Zmodernizuj przetwarzanie obrazów slajdów, zastępując przestarzałe API graficzne nowoczesnym API .NET, aby zapewnić płynną automatyzację PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Historycznie Aspose Slides ma zależność od System.Drawing i w publicznym API posiada następujące klasy z tego zakresu:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Od wersji 24.4 to publiczne API jest oznaczone jako przestarzałe.

Ponieważ wsparcie System.Drawing w wersjach .NET6 i wyższych zostało usunięte w wersjach nie‑Windows ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides wprowadziło podejście dwupakietowe:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – wsparcie dla .NET6+ na Windows, .NETStandard dla Windows/Linux/MacOS, .NETFramework 2+ (Windows).  
  - ma zależność od [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – wersja Windows/Linux/MacOS bez zależności.

Uciążliwością [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) jest to, że implementuje własną wersję System.Drawing w tej samej przestrzeni nazw (aby zapewnić zgodność wsteczną z publicznym API). W związku z tym, gdy Aspose.Slides.NET6.CrossPlatform i System.Drawing z .NET Framework lub pakietu System.Drawing.Common są używane jednocześnie, występuje konflikt nazw, chyba że użyty zostanie alias.

Aby pozbyć się zależności od System.Drawing w głównym pakiecie Aspose.Slides.NET, dodaliśmy tzw. „Nowoczesne API” – czyli API, które powinno być używane zamiast przestarzałego, którego sygnatury zawierają zależności od następujących typów z System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) i [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) i [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) są oznaczone jako przestarzałe i ich wsparcie zostało usunięte z publicznego API Slides.

W bieżących wersjach traktuj publiczne API zależne od System.Drawing jako starsze/przestarzałe. Używaj Nowoczesnego API w nowym kodzie i przy migracji istniejących przepływów przetwarzania obrazów.

## **Nowoczesne API**

Dodano następujące klasy i wyliczenia do publicznego API:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) – reprezentuje obraz rastrowy lub wektorowy.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/imageformat/) – reprezentuje format pliku obrazu.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/pl/net/aspose.slides/images/) – metody służące do tworzenia i pracy z interfejsem [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/).

Należy zauważyć, że [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) jest obiektem z możliwością zwolnienia (implementuje interfejs [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) i jego użycie powinno być opakowane w using lub zwolnione w inny dogodny sposób).

Użyj `GetImage`, aby renderować pojedynczy slajd lub kształt. Użyj `GetImages`, aby renderować wiele slajdów prezentacji. Użyj metod z [Images](https://reference.aspose.com/slides/pl/net/aspose.slides/images/) do ładowania obrazów, `AddImage` z [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) aby dodać je do prezentacji oraz `ReplaceImage` z [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) aby zaktualizować istniejący obraz w prezentacji.

Typowy scenariusz użycia nowego API może wyglądać następująco:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // utwórz obiekt IImage z pliku na dysku, który jest przeznaczony do zwolnienia.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // utwórz obraz PowerPoint, dodając instancję IImage do kolekcji obrazów prezentacji.
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

## **Zastępowanie starego kodu nowoczesnym API**

Aby ułatwić przejście, interfejs nowego [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) powiela oddzielne sygnatury klas [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) i [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). Generalnie wystarczy zamienić wywołanie starej metody używającej System.Drawing na nową.

### **Pobieranie miniatury slajdu**

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

### **Pobieranie miniatury kształtu**

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

### **Pobieranie miniatury prezentacji**

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

### **Dodawanie obrazu do prezentacji**

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

## **Przestarzałe metody/właściwości i ich zamienniki w nowoczesnym API**

### **Presentation**
| Sygnatura metody                               | Sygnatura metody zamiennika                             |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/getimages#getimages)                   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/getimages#getimages_1)   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print()                           | No Modern API replacement                               |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement                            |
| public void Print(string printerName)         | No Modern API replacement                               |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement                          |

### **Shape**
| Sygnatura metody                                                      | Sygnatura metody zamiennika                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail()                                          | [GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/getimage#getimage)                                                           |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Sygnatura metody                                                      | Sygnatura metody zamiennika                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY)                | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/getimage#getimage_5)                                 |
| public Bitmap GetThumbnail()                                         | [GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/getimage#getimage)                                                              |
| public Bitmap GetThumbnail(IRenderingOptions options)                | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/getimage#getimage_1)                                  |
| public Bitmap GetThumbnail(Size imageSize)                           | [GetImage(Size imageSize)](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/getimage#getimage_6)                                             |
| public Bitmap GetThumbnail(ITiffOptions options)                    | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/getimage#getimage_4)                                      |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/getimage#getimage_3)               |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement                                       |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement                             |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement                                    |

### **Output**
| Sygnatura metody                                                | Sygnatura metody zamiennika                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image)               | [Add(string path, IImage image)](https://reference.aspose.com/slides/pl/net/aspose.slides.export.web/output/add#add_1)                               |

### **ImageCollection**
| Sygnatura metody                          | Sygnatura metody zamiennika               |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image)           | [AddImage(IImage image)](https://reference.aspose.com/slides/pl/net/aspose.slides/imagecollection/addimage#addimage)                      |

### **ImageWrapperFactory**
| Sygnatura metody                                         | Sygnatura metody zamiennika                            |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image)           | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/pl/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper)                        |

### **PPImage**
| Sygnatura metody/ własności                     | Sygnatura metody zamiennika   |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage)   | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/pl/net/aspose.slides/ppimage/replaceimage#replaceimage)            |
| Image SystemImage { get; }          | [IImage Image { get; }](https://reference.aspose.com/slides/pl/net/aspose.slides/ppimage/image)                    |

### **PatternFormat**
| Sygnatura metody                                          | Sygnatura metody zamiennika                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/pl/net/aspose.slides/patternformat/gettile#gettile_1)         |
| Bitmap GetTileImage(Color styleColor)                     | [GetTile(Color styleColor)](https://reference.aspose.com/slides/pl/net/aspose.slides/patternformat/gettile#gettile)                           |

### **IPatternFormatEffectiveData**
| Sygnatura metody                                          | Sygnatura metody zamiennika                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/pl/net/aspose.slides/ipatternformateffectivedata/gettileiimage)                    |

## **Wsparcie API dla Graphics i PrinterSettings**

Klasa [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) nie jest obsługiwana w wersjach cross‑platform .NET6 i wyższych. W Aspose Slides użyj metod renderujących obrazy z Nowoczesnego API zamiast API renderującego do [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Również API związane z drukowaniem poprzez [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) nie ma bezpośredniego zamiennika w Nowoczesnym API:

[IPresentation](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

**Dlaczego [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) został usunięty?**

Wsparcie dla [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) jest przestarzałe w publicznym API, aby ujednolicić pracę z renderowaniem i obrazami, wyeliminować powiązania z zależnościami specyficznymi dla platformy oraz przejść na podejście cross‑platform z użyciem [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/). Zamiast renderować do [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) użyj `GetImage` lub `GetImages`.

**Jaka jest praktyczna korzyść z [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) w porównaniu do [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?**

[IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) łączy pracę zarówno z obrazami rastrowymi, jak i wektorowymi, upraszcza zapisywanie do różnych formatów za pośrednictwem [ImageFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/imageformat/), zmniejsza zależność od `System.Drawing` i sprawia, że kod jest bardziej przenośny między środowiskami.

**Czy Nowoczesne API wpłynie na wydajność generowania miniatur?**

Przejście z `GetThumbnail` na `GetImage` nie pogarsza scenariuszy: nowe metody zapewniają te same możliwości tworzenia obrazów z opcjami i rozmiarami, zachowując wsparcie dla opcji renderowania. Konkretne zyski lub spadki zależą od scenariusza, ale funkcjonalnie zamienniki są równoważne.