---
title: Современный API
type: docs
weight: 237
url: /ru/net/modern-api/
keywords: "Кроссплатформенный Современный API System.Drawing"
description: "Современный API"
---

## Введение

Исторически, Aspose Slides зависел от System.Drawing и имел в публичном API следующие классы оттуда:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

По состоянию на версию 24.4, этот публичный API объявлен устаревшим.

Поскольку поддержка System.Drawing в версиях .NET6 и выше была удалена для некорректных версий (изменение, нарушающее совместимость) ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides реализовал подход с двумя библиотеками:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - поддержка для .NET6+ для Windows, .NETStandard для Windows/Linux/MacOS, .NETFramework 2+ (Windows).
  - имеет зависимость от [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - версия для Windows/Linux/MacOS без зависимостей.

Неудобство [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) заключается в том, что он реализует свою версию System.Drawing в том же пространстве имен (для поддержки обратной совместимости с публичным API). Таким образом, когда используются Aspose.Slides.NET6.CrossPlatform и System.Drawing из .NETFramrwork или пакет System.Drawing.Common одновременно, возникает конфликт имен, если не используется псевдоним.

Чтобы избавиться от зависимостей на System.Drawing в основном пакете Aspose.Slides.NET, мы добавили так называемый "Современный API" - т.е. API, который должен использоваться вместо устаревшего, чьи сигнатуры содержат зависимости от следующих типов из System.Drawing: Image и Bitmap. PrinterSettings и Graphics объявлены устаревшими, и их поддержка удалена из публичного API Slides.

Удаление устаревшего публичного API с зависимостями от System.Drawing будет в релизе 24.8.

## Современный API

Добавлены следующие классы и перечисления в публичный API:

- Aspose.Slides.IImage - представляет растровое или векторное изображение.
- Aspose.Slides.ImageFormat - представляет формат файла изображения.
- Aspose.Slides.Images - методы для инстанцирования и работы с интерфейсом IImage.

Обратите внимание, что IImage является управляемым ресурсом (он реализует интерфейс IDisposable, и его использование должно быть обернуто в конструкцию using или освобождено другим удобным способом).

Типичный сценарий использования нового API может выглядеть следующим образом:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // инстанцируем управляемый экземпляр IImage из файла на диске.
    using (IImage image = Images.FromFile("image.png"))
    {
        // создаем изображение PowerPoint, добавляя экземпляр IImage в изображения презентации.
        ppImage = pres.Images.AddImage(image);
    }

    // добавляем форму изображения на слайд #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // получаем экземпляр IImage, представляющий слайд #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // сохраняем изображение на диске.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## Замена старого кода на Современный API

Для облегчения перехода, интерфейс нового IImage повторяет отдельные сигнатуры классов Image и Bitmap. В целом, вам просто нужно заменить вызов старого метода, использующего System.Drawing, на новый.

### Получение миниатюры слайда

Код, использующий устаревший API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Современный API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### Получение миниатюры фигуры

Код, использующий устаревший API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Современный API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### Получение миниатюры презентации

Код, использующий устаревший API:

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

Современный API:

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

### Добавление изображения в презентацию

Код, использующий устаревший API:

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

Современный API:

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
## Методы/свойства, которые будут удалены, и их замена в Современном API

### Презентация
| Подпись метода                                         | Подпись заменяющего метода                                      |
|-------------------------------------------------------|-----------------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages)                   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1)   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | Будет удалено полностью |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | Будет удалено полностью |
| public void Print()                                   | Будет удалено полностью                                             |
| public void Print(PrinterSettings printerSettings)    | Будет удалено полностью                                             |
| public void Print(string printerName)                 | Будет удалено полностью                                             |
| public void Print(PrinterSettings printerSettings, string presName) | Будет удалено полностью                                |

### Фигура
| Подпись метода                                                         | Подпись заменяющего метода                                         |
|------------------------------------------------------------------------|--------------------------------------------------------------------|
| public Bitmap GetThumbnail()                                            | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage)                                                              |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### Слайд
| Подпись метода                                                         | Подпись заменяющего метода                                         |
|------------------------------------------------------------------------|--------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY)                | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5)                                  |
| public Bitmap GetThumbnail()                                           | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage)                                                             |
| public Bitmap GetThumbnail(IRenderingOptions options)                  | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1)                                   |
| public Bitmap GetThumbnail(Size imageSize)                             | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6)                                            |
| public Bitmap GetThumbnail(ITiffOptions options)                      | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4)                                     |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3)               |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | Будет удалено полностью                                      |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | Будет удалено полностью                          |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | Будет удалено полностью                                 |

#### Вывод
| Подпись метода                                             | Подпись заменяющего метода                      |
|-----------------------------------------------------------|-------------------------------------------------|
| public IOutputFile Add(string path, Image image)         | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1)                               |

### КоллекцияИзображений
| Подпись метода                          | Подпись заменяющего метода            |
|-----------------------------------------|---------------------------------------|
| IPPImage AddImage(Image image)         | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage)                      |

### ФабрикаОбертокИзображений
| Подпись метода                                        | Подпись заменяющего метода                              |
|-------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image)        | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper)                        |

### PPImage
| Подпись метода/свойства                                | Подпись заменяющего метода |
|------------------------------------------------------|-----------------------------|
| void ReplaceImage(Image newImage)                    | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage)            |
| Image SystemImage { get; }                             | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image)                    |

### ФорматШаблона
| Подпись метода                                           | Подпись заменяющего метода                         |
|---------------------------------------------------------|----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1)         |
| Bitmap GetTileImage(Color styleColor)                   | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile)                           |

### IEffективныеДанныеФорматаШаблона
| Подпись метода                                          | Подпись заменяющего метода                          |
|---------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage)                    |

## Поддержка Aspose.Slides.NET6.CrossPlatform будет прекращена

После выхода версии [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) 24.8, поддержка [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) будет прекращена.

## Поддержка API для Graphics и PrinterSettings будет прекращена

Класс [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) не поддерживается для кроссплатформенных версий .NET6 и выше. В Aspose Slides, часть API, которая его использует, будет удалена:
[Слайд](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Кроме того, часть API, связанная с печатью, будет удалена:

[Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)