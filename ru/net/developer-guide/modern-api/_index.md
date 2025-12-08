---
title: Современный API
type: docs
weight: 237
url: /ru/net/modern-api/
keywords: "Кросс‑платформенный Современный API System.Drawing"
description: "Современный API"
---

## **Введение**

Исторически Aspose Slides зависел от System.Drawing и в публичном API содержал следующие классы из него:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Начиная с версии 24.4, этот публичный API объявлен устаревшим.

Поскольку поддержка System.Drawing в версиях .NET 6 и выше удалена для неб Windows‑платформ ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides реализовал подход с двумя версиями библиотек:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) — поддержка .NET 6+ для Windows, .NETStandard для Windows/Linux/macOS, .NETFramework 2+ (Windows).  
  - имеет зависимость от [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) — версия для Windows/Linux/macOS без внешних зависимостей.

Недостаток [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) в том, что он реализует свою версию System.Drawing в том же пространстве имён (для поддержки обратной совместимости с публичным API). Поэтому при одновременном использовании Aspose.Slides.NET6.CrossPlatform и System.Drawing из .NETFramework или пакета System.Drawing.Common возникает конфликт имён, если не использовать алиасы.

Чтобы избавиться от зависимостей от System.Drawing в основном пакете Aspose.Slides.NET, мы добавили так называемый «Современный API» — то есть API, который следует использовать вместо устаревшего, сигнатуры которого содержат зависимости от следующих типов System.Drawing: Image и Bitmap. PrinterSettings и Graphics объявлены устаревшими, их поддержка удалена из публичного API Slides.

Удаление устаревшего публичного API с зависимостями от System.Drawing будет выполнено в релизе 24.8.

## **Современный API**

В публичный API добавлены следующие классы и перечисления:

- Aspose.Slides.IImage — представляет растровое или векторное изображение.  
- Aspose.Slides.ImageFormat — представляет файловый формат изображения.  
- Aspose.Slides.Images — методы для создания и работы с интерфейсом IImage.

Обратите внимание, что IImage реализует IDisposable и его следует использовать внутри `using` либо явно вызывать `Dispose`.

Типичный сценарий использования нового API может выглядеть следующим образом:
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // создать освобождаемый экземпляр IImage из файла на диске.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // создать изображение PowerPoint, добавив экземпляр IImage в коллекцию изображений презентации.
        ppImage = pres.Images.AddImage(image);
    }

    // добавить форму изображения на слайд №1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // получить экземпляр IImage, представляющий слайд №1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // сохранить изображение на диске.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```


## **Замена старого кода на Современный API**

Для упрощения перехода интерфейс нового IImage повторяет отдельные сигнатуры классов Image и Bitmap. Как правило, достаточно заменить вызов старого метода из System.Drawing на новый.

### **Получение миниатюры слайда**

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


### **Получение миниатюры фигуры**

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


### **Получение миниатюры презентации**

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


### **Добавление изображения в презентацию**

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


## **Методы/свойства, подлежащие удалению, и их замены в Современном API**

### **Presentation**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | Будет полностью удалён |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | Будет полностью удалён |
| public void Print() | Будет полностью удалён |
| public void Print(PrinterSettings printerSettings) | Будет полностью удалён |
| public void Print(string printerName) | Будет полностью удалён |
| public void Print(PrinterSettings printerSettings, string presName) | Будет полностью удалён |

### **Shape**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | Будет полностью удалён |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | Будет полностью удалён |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | Будет полностью удалён |

### **Output**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Сигнатура метода/свойства | Сигнатура заменяющего метода |
|----------------------------|------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Поддержка Graphics и PrinterSettings будет прекращена**

Класс [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) не поддерживается в кросс‑платформенных версиях .NET 6 и выше. В Aspose Slides часть API, использующая его, будет удалена:
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Также будет удалена часть API, связанная с печатью:

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

# **FAQ**

**Почему удалён System.Drawing.Graphics?**

Поддержка `Graphics` убирается из публичного API для унификации работы с рендерингом и изображениями, исключения привязки к платформенно‑специфическим зависимостям и перехода к кросс‑платформенному подходу с использованием [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Все методы рендеринга в `Graphics` будут удалены.

**Какова практическая выгода от IImage по сравнению с Image/Bitmap?**

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) объединяет работу как с растровыми, так и с векторными изображениями, упрощает сохранение в различные форматы через [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), снижает зависимость от `System.Drawing` и делает код более переносимым между средами.

**Повлияет ли Современный API на производительность генерации миниатюр?**

Переход от `GetThumbnail` к `GetImage` не ухудшает сценарии: новые методы предоставляют те же возможности по созданию изображений с параметрами и размерами, сохраняя поддержку опций рендеринга. Конкретный прирост или падение производительности зависит от сценария, но функционально замены эквивалентны.