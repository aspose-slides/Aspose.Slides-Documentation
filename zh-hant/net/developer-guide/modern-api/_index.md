---
title: 使用現代 API 強化影像處理
linktitle: 現代 API
type: docs
weight: 237
url: /zh-hant/net/modern-api/
keywords:
- System.Drawing
- 現代 API
- 繪圖
- 投影片縮圖
- 投影片轉影像
- 形狀縮圖
- 形狀轉影像
- 簡報縮圖
- 簡報轉影像
- 新增影像
- 新增圖片
- .NET
- C#
- Aspose.Slides
description: "透過使用 .NET 現代 API 取代已棄用的影像 API，讓投影片影像處理現代化，以達成無縫的 PowerPoint 與 OpenDocument 自動化。"
---
## **簡介**

在過去，Aspose Slides 依賴於 System.Drawing，且在公共 API 中提供了以下來自該命名空間的類別：
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

自 24.4 版起，此公共 API 已被宣告為已棄用。

由於 .NET6 以上版本在非 Windows 平台中已移除 System.Drawing 支援（[重大變更](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)），Slides 採用了兩套套件的方式：
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - 支援 Windows 上的 .NET6+，Windows/Linux/MacOS 上的 .NETStandard，Windows 上的 .NETFramework 2+。
  - 依賴於 [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/)。
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - Windows/Linux/MacOS 版本，無任何依賴。

[Aspose.Slides.NET6.CrossPlatform] 的不便之處在於它在同一命名空間中實作了自己的 System.Drawing 版本（以支援與公共 API 的向後相容性）。因此，當同時使用 Aspose.Slides.NET6.CrossPlatform 與 .NET Framework 的 System.Drawing 或 System.Drawing.Common 套件時，除非使用別名，否則會發生名稱衝突。

為了在主要的 Aspose.Slides.NET 套件中移除對 System.Drawing 的依賴，我們加入了所謂的「現代 API」——即應取代已棄用 API 的新 API，其簽章中不再依賴 System.Drawing 中的 [Image] 與 [Bitmap]。[PrinterSettings] 與 [Graphics] 已被宣告為已棄用，且其支援已從公共 Slides API 中移除。

在目前的版本中，請將依賴於 System.Drawing 的公共 API 視為舊版/已棄用。新程式碼以及遷移既有影像處理工作流程時，請使用現代 API。

## **現代 API**

已將以下類別與列舉加入公共 API：

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) - 代表點陣或向量影像。
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imageformat/) - 代表影像的檔案格式。
- [Aspose.Slides.Images](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/images/) - 用於實例化和操作 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 介面的相關方法。

請注意，[IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 為可釋放資源的物件（它實作了 [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) 介面，使用時應以 using 包住或以其他適當方式釋放）。

使用 `GetImage` 來渲染單一投影片或形狀。使用 `GetImages` 來渲染多張投影片。使用 [Images](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/images/) 方法載入影像，使用 `AddImage` 搭配 [IImage] 將影像加入簡報，並使用 `ReplaceImage` 搭配 [IImage] 來更新簡報中已存在的影像。

以下是一個使用新 API 的典型情境：

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // 從磁碟上的檔案實例化一個可釋放的 IImage 實例。  
    using (IImage image = Images.FromFile("image.png"))
    {
        // 透過將 IImage 實例加入簡報的影像集合來建立 PowerPoint 影像。
        ppImage = pres.Images.AddImage(image);
    }

    // 在投影片 #1 上新增圖片形狀
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // 取得代表投影片 #1 的 IImage 實例。
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // 將影像儲存至磁碟。
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **以現代 API 取代舊代碼**

為了簡化過渡，新 [IImage] 介面的設計重複了 [Image] 與 [Bitmap] 類別的各個簽章。一般而言，只需將使用 System.Drawing 的舊方法呼叫換成對應的新方法即可。

### **取得投影片縮圖**

舊版/已棄用 API：

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

現代 API：

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **取得形狀縮圖**

舊版/已棄用 API：

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

現代 API：

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **取得簡報縮圖**

舊版/已棄用 API：

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

現代 API：

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

### **將圖片加入簡報**

舊版/已棄用 API：

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

現代 API：

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

## **已棄用的方法/屬性及其在現代 API 中的取代方案**

### **簡報**
| 方法簽章 | 取代方法簽章 |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **形狀**
| 方法簽章 | 取代方法簽章 |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/getimage#getimage_1) |

### **投影片**
| 方法簽章 | 取代方法簽章 |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **輸出**
| 方法簽章 | 取代方法簽章 |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| 方法簽章 | 取代方法簽章 |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| 方法簽章 | 取代方法簽章 |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| 方法/屬性簽章 | 取代方法簽章 |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| 方法簽章 | 取代方法簽章 |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| 方法簽章 | 取代方法簽章 |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Graphics 與 PrinterSettings 的 API 支援**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) 類別在 .NET6 以上的跨平台版本中不受支援。在 Aspose Slides 中，請改用現代 API 的影像渲染方法取代渲染至 [Graphics] 的 API：
[ISlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/rendertographics/#rendertographics_5)

此外，與透過 [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) 相關的列印 API 目前沒有直接的現代 API 取代方案：

[IPresentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/)：
- [public void Presentation.Print](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/print/#print_2)

## **常見問題**

**為何棄用 [Graphics]？**

在公共 API 中棄用 [Graphics] 旨在統一渲染與影像的處理方式，消除對平台專屬依賴，並改以跨平台的 [IImage] 方式實作。請改用 `GetImage` 或 `GetImages` 取代渲染至 [Graphics]。

**[IImage] 相較於 [Image]/[Bitmap] 有什麼實務上的好處？**

[IImage] 統一了點陣與向量影像的操作，透過 [ImageFormat] 簡化多種格式的儲存，減少對 `System.Drawing` 的依賴，讓程式碼在不同環境間更具可移植性。

**使用現代 API 會影響產生縮圖的效能嗎？**

從 `GetThumbnail` 轉為 `GetImage` 不會降低效能；新方法在功能上與舊方法等價，皆支援相同的選項與尺寸。具體的效能提升或下降取決於實際情境，但在功能上兩者是等效的。