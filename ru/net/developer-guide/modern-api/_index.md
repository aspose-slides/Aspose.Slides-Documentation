---
title: Усовершенствование обработки изображений с Modern API
linktitle: Modern API
type: docs
weight: 234
url: /ru/net/modern-api/
keywords:
- System.Drawing
- Modern API
- рисование
- миниатюра слайда
- преобразование слайда в изображение
- миниатюра фигуры
- преобразование фигуры в изображение
- миниатюра презентации
- преобразование презентации в изображения
- добавить изображение
- добавить картинку
- .NET
- C#
- Aspose.Slides
description: "Модернизируйте обработку изображений слайдов, заменив устаревшие API обработки изображений на .NET Modern API для бесшовной автоматизации PowerPoint и OpenDocument."
---
## **Введение**

Historically, Aspose Slides has a dependency on System.Drawing and has in the public API the following classes from there:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

As of version 24.4, this public API is declared deprecated.

Since System.Drawing support in versions .NET6 and above is removed for non-Windows versions ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides has implemented a two-package approach:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - support for .NET6+ for Windows, .NETStandard for Windows/Linux/MacOS, .NETFramework 2+ (Windows).
  - has a dependence on [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - Windows/Linux/MacOS version without dependencies.

The inconvenience of [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) is that it implements its own version of System.Drawing in the same namespace (to support backward compatibility with the public API). Thus, when Aspose.Slides.NET6.CrossPlatform and System.Drawing from .NET Framework or System.Drawing.Common package are used at the same time, a name conflict occurs unless alias is used.

In order to get rid of dependencies on System.Drawing in the main Aspose.Slides.NET package, we added the so-called "Modern API" - i.e. the API that should be used instead of the deprecated one, whose signatures contain dependencies on the following types from System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) and [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) and [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) are declared deprecated and their support is removed from the public Slides API.

In current versions, treat the public API that depends on System.Drawing as legacy/deprecated. Use the Modern API for new code and when migrating existing image-processing workflows.

## **Современный API**

Added the following classes and enums to the public API:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) - представляет растровое или векторное изображение.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) - представляет файловый формат изображения.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) - методы для создания и работы с интерфейсом [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).

Please note that [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) is disposable (it implements the [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) interface and its use should be wrapped in using or disposed in another convenient way).

Use `GetImage` to render a single slide or shape. Use `GetImages` to render several presentation slides. Use [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) methods to load images, `AddImage` with [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) to add them to a presentation, and `ReplaceImage` with [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) to update an existing presentation image.

A typical scenario of using the new API may look as follows:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // создать одноразовый экземпляр IImage из файла на диске.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // создать изображение PowerPoint, добавив экземпляр IImage в набор изображений презентации.
        ppImage = pres.Images.AddImage(image);
    }

    // добавить форму изображения на слайд #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // получить экземпляр IImage, представляющий слайд #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // сохранить изображение на диске.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Замена старого кода на Modern API**

For ease of transition, the interface of the new [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) repeats the separate signatures of the [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) and [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) classes. In general, you will just need to replace the call to the old method using System.Drawing with the new one.

### **Получение миниатюры слайда**

Legacy/deprecated API:

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

### **Получение миниатюры фигуры**

Legacy/deprecated API:

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

### **Получение миниатюры презентации**

Legacy/deprecated API:

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

### **Добавление изображения в презентацию**

Legacy/deprecated API:

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

## **Устаревшие методы/свойства и их замена в Modern API**

### **Presentation**
| Подпись метода | Подпись метода-замены |
|-----------------------------------------------|---------------------------------------------------------|
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
| Подпись метода | Подпись метода-замены |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Подпись метода | Подпись метода-замены |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
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
| Подпись метода | Подпись метода-замены |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Подпись метода | Подпись метода-замены |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Подпись метода | Подпись метода-замены |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Подпись метода/свойства | Подпись метода-замены |
|--------------------------|-----------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Подпись метода | Подпись метода-замены |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Подпись метода | Подпись метода-замены |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Поддержка Graphics и PrinterSettings в API**

The [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) class is not supported for cross-platform versions of .NET6 and higher. In Aspose Slides, use the Modern API image-rendering methods instead of the API that renders to [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Also, the API that is related to printing through [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) has no direct Modern API replacement:

[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

### Почему удалён [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)?

Support for [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) is deprecated in the public API to unify work with rendering and images, eliminate ties to platform-specific dependencies, and switch to a cross-platform approach with [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Use `GetImage` or `GetImages` instead of rendering to [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

### Какова практическая выгода от [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) по сравнению с [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) unifies working with both raster and vector images, simplifies saving to various formats via [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), reduces dependence on `System.Drawing`, and makes code more portable across environments.

### Повлияет ли Modern API на производительность генерации миниатюр?

Switching from `GetThumbnail` to `GetImage` does not worsen scenarios: the new methods provide the same capabilities for producing images with options and sizes, while retaining support for rendering options. The specific gain or drop depends on the scenario, but functionally the replacements are equivalent.