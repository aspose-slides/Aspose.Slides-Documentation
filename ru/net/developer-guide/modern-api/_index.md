---
title: "Улучшите обработку изображений с помощью Modern API"
linktitle: "Современный API"
type: docs
weight: 237
url: /ru/net/modern-api/
keywords:
- System.Drawing
- современный API
- рисование
- миниатюра слайда
- слайд в изображение
- миниатюра фигуры
- фигура в изображение
- миниатюра презентации
- презентация в изображения
- добавить изображение
- добавить картинку
- .NET
- C#
- Aspose.Slides
description: "Модернизируйте обработку изображений слайдов, заменив устаревшие API обработки изображений на современный .NET API для беспрепятственной автоматизации PowerPoint и OpenDocument."
---
## **Введение**

Исторически Aspose Slides зависит от System.Drawing и в публичном API содержит следующие классы из него:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Начиная с версии 24.4, этот публичный API объявлен устаревшим.

Поскольку поддержка System.Drawing в версиях .NET 6 и выше удалена для не‑Windows‑платформ ([нарушающее совместимость изменение](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides реализовал двухпакетный подход:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – поддержка .NET 6+ для Windows, .NETStandard для Windows/Linux/macOS, .NETFramework 2+ (Windows).  
  - имеет зависимость от [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – версия для Windows/Linux/macOS без внешних зависимостей.

Недостаток [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) состоит в том, что он реализует свою собственную версию System.Drawing в том же пространстве имён (для обеспечения обратной совместимости с публичным API). Поэтому при одновременном использовании Aspose.Slides.NET6.CrossPlatform и System.Drawing из .NET Framework или пакета System.Drawing.Common возникает конфликт имён, если не использовать алиасы.

Чтобы избавиться от зависимостей от System.Drawing в основном пакете Aspose.Slides.NET, мы добавили так называемый «Modern API» – т.е. API, который следует использовать вместо устаревшего, подписи которого содержат зависимости от следующих типов System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) и [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) и [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) объявлены устаревшими, и их поддержка удалена из публичного API Slides.

В текущих версиях публичный API, зависящий от System.Drawing, рассматривается как устаревший/наследованный. Для нового кода и при миграции существующих рабочих процессов обработки изображений используйте Modern API.

## **Modern API**

В публичный API добавлены следующие классы и перечисления:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) – представляет растровое или векторное изображение.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/imageformat/) – представляет файловый формат изображения.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/ru/net/aspose.slides/images/) – методы для создания экземпляров и работы с интерфейсом [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/).

Обратите внимание, что [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) реализует интерфейс [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) и должен использоваться в конструкции `using` или быть освобождён другим удобным способом.

Используйте `GetImage` для рендеринга одного слайда или фигуры. Используйте `GetImages` для рендеринга нескольких слайдов презентации. Методы из [Images](https://reference.aspose.com/slides/ru/net/aspose.slides/images/) позволяют загружать изображения, `AddImage` с [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) – добавлять их в презентацию, и `ReplaceImage` с [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) – обновлять существующее изображение в презентации.

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

## **Замена старого кода на Modern API**

Для упрощения перехода интерфейс нового [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) повторяет отдельные подписи классов [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) и [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). Как правило, достаточно заменить вызов старого метода, использующего System.Drawing, на новый.

### **Получение миниатюры слайда**

Устаревший/наследованный API:

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

### **Получение миниатюры фигуры**

Устаревший/наследованный API:

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

### **Получение миниатюры презентации**

Устаревший/наследованный API:

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

### **Добавление изображения в презентацию**

Устаревший/наследованный API:

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
## **Устаревшие методы/свойства и их замены в Modern API**

### **Presentation**
| Подпись метода | Подпись заменяющего метода |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| Подпись метода | Подпись заменяющего метода |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Подпись метода | Подпись заменяющего метода |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| Подпись метода | Подпись заменяющего метода |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/ru/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Подпись метода | Подпись заменяющего метода |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/ru/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Подпись метода | Подпись заменяющего метода |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/ru/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Подпись метода/свойства | Подпись заменяющего метода |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/ru/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/ru/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Подпись метода | Подпись заменяющего метода |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/ru/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/ru/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Подпись метода | Подпись заменяющего метода |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/ru/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Поддержка Graphics и PrinterSettings в API**

Класс [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) не поддерживается в кросс‑платформенных версиях .NET 6 и выше. В Aspose Slides используйте методы рендеринга изображений Modern API вместо API, который рендерит в [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Также API, связанный с печатью через [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings), не имеет прямой замены в Modern API:

[IPresentation](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

**Почему убрали [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)?**

Поддержка [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) объявлена устаревшей в публичном API для унификации работы с рендерингом и изображениями, устранения привязки к платформо‑специфичным зависимостям и перехода к кросс‑платформенному подходу с использованием [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/). Вместо рендеринга в [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) используйте `GetImage` или `GetImages`.

**В чём практическая выгода [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) по сравнению с [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?**

[IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) объединяет работу как с растровыми, так и с векторными изображениями, упрощает сохранение в различные форматы через [ImageFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/imageformat/), снижает зависимость от `System.Drawing` и делает код более переносимым между средами.

**Повлияет ли Modern API на производительность генерации миниатюр?**

Переход от `GetThumbnail` к `GetImage` не ухудшает сценарии: новые методы предоставляют те же возможности по созданию изображений с различными параметрами и размерами, сохраняя поддержку параметров рендеринга. Конкретный прирост или падение производительности зависит от сценария, но функционально замены эквивалентны.