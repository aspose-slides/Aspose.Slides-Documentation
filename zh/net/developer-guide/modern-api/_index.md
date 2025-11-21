---
title: 使用现代 API 增强图像处理
linktitle: 现代 API
type: docs
weight: 237
url: /zh/net/modern-api/
keywords:
- System.Drawing
- 现代 API
- 绘图
- 幻灯片缩略图
- 幻灯片转图像
- 形状缩略图
- 形状转图像
- 演示文稿缩略图
- 演示文稿转图像
- 添加图像
- 添加图片
- .NET
- C#
- Aspose.Slides
description: "通过使用 .NET 现代 API 替代已弃用的成像 API，实现幻灯片图像处理现代化，支持无缝的 PowerPoint 和 OpenDocument 自动化。"
---

## **介绍**

从历史上看，Aspose Slides 依赖于 System.Drawing，并在公共 API 中提供了以下来自该命名空间的类：
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

自 24.4 版本起，这些公共 API 已标记为已弃用。

由于在 .NET6 及更高版本中，System.Drawing 在非 Windows 平台上已被移除（[breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)），Slides 实现了两套库的方案：
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – 支持 Windows 上的 .NET6+，以及 Windows/Linux/macOS 上的 .NETStandard，Windows 上的 .NETFramework 2+。
  - 依赖于 [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/)。
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – Windows/Linux/macOS 版本，无任何依赖。

[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) 的不便之处在于它在相同命名空间中实现了自己的 System.Drawing（用于保持与旧公共 API 的向后兼容）。因此，当同时使用 Aspose.Slides.NET6.CrossPlatform 与 .NETFramework 中的 System.Drawing 或 System.Drawing.Common 包时，除非使用别名，否则会出现名称冲突。

为了消除对主 Aspose.Slides.NET 包中 System.Drawing 的依赖，我们加入了所谓的“现代 API”——即应替代已弃用 API 使用的 API，其签名不再依赖 System.Drawing 中的 Image 与 Bitmap。PrinterSettings 与 Graphics 已标记为已弃用，并从公共 Slides API 中移除。

带有 System.Drawing 依赖的已弃用公共 API 将在 24.8 版本中移除。

## **现代 API**

向公共 API 中添加了以下类和枚举：

- Aspose.Slides.IImage – 表示光栅或矢量图像。
- Aspose.Slides.ImageFormat – 表示图像的文件格式。
- Aspose.Slides.Images – 用于实例化和操作 IImage 接口的方法。

请注意，IImage 实现了 IDisposable 接口，使用时应放在 using 块中或以其他适当方式进行释放。

使用新 API 的典型场景可能如下所示：
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // 实例化一个可释放的 IImage 实例，来自磁盘上的文件。  
    using (IImage image = Images.FromFile("image.png"))
    {
        // 通过将 IImage 实例添加到演示文稿的图像集合来创建 PowerPoint 图像。
        ppImage = pres.Images.AddImage(image);
    }

    // 在幻灯片 #1 上添加图片形状
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // 获取表示幻灯片 #1 的 IImage 实例。
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // 将图像保存到磁盘上。
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```


## **使用现代 API 替换旧代码**

为便于迁移，新 IImage 接口复用了 Image 与 Bitmap 类的各个签名。一般情况下，只需将使用 System.Drawing 的旧方法调用替换为对应的新方法。

### **获取幻灯片缩略图**

使用已弃用 API 的代码：
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```


现代 API：
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```


### **获取形状缩略图**

使用已弃用 API 的代码：
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```


现代 API：
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```


### **获取演示文稿缩略图**

使用已弃用 API 的代码：
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


现代 API：
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


### **向演示文稿添加图片**

使用已弃用 API 的代码：
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


现代 API：
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

## **将在 Modern API 中删除的方法/属性及其替代方案**

### **Presentation**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | 将被完全删除 |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | 将被完全删除 |
| public void Print() | 将被完全删除 |
| public void Print(PrinterSettings printerSettings) | 将被完全删除 |
| public void Print(string printerName) | 将被完全删除 |
| public void Print(PrinterSettings printerSettings, string presName) | 将被完全删除 |

### **Shape**
| 方法签名 | 替代方法签名 |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| 方法签名 | 替代方法签名 |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | 将被完全删除 |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | 将被完全删除 |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | 将被完全删除 |

### **Output**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| 方法签名 | 替代方法签名 |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| 方法签名 | 替代方法签名 |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| 方法/属性签名 | 替代方法签名 |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Graphics 和 PrinterSettings 的 API 支持将被停止**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) 类在跨平台的 .NET6 及更高版本中不受支持。在 Aspose Slides 中，使用该类的 API 将被移除：
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

同时，与打印相关的 API 也将被移除：

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)：
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

# **常见问题**

**为什么放弃了 System.Drawing.Graphics？**

`Graphics` 正在从公共 API 中移除，以统一渲染和图像的处理，消除对平台特定依赖的绑定，并通过 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 采用跨平台方案。所有渲染到 `Graphics` 的方法都将被删除。

**IImage 相比 Image/Bitmap 有什么实际优势？**

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 统一了对光栅和矢量图像的操作，简化了通过 [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) 保存为多种格式的流程，减少了对 `System.Drawing` 的依赖，使代码在不同环境间更具可移植性。

**现代 API 会影响生成缩略图的性能吗？**

从 `GetThumbnail` 切换到 `GetImage` 并不会导致性能下降：新方法在提供相同生成图像功能（包括选项和尺寸）的同时，保留了对渲染选项的支持。具体的提升或下降取决于使用场景，但在功能上两者是等价的。