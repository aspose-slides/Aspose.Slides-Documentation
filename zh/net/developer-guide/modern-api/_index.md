---
title: 使用现代 API 增强图像处理
linktitle: 现代 API
type: docs
weight: 234
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
description: "通过使用 .NET 现代 API 替代已弃用的图像 API，现代化幻灯片图像处理，实现 PowerPoint 和 OpenDocument 的无缝自动化。"
---
## **介绍**

从历史上看，Aspose Slides 依赖于 System.Drawing，并在公共 API 中包含以下来自该库的类：
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

自 24.4 版起，此公共 API 已标记为已弃用。

由于在 .NET6 及以上版本中，非 Windows 系统的 System.Drawing 支持已被移除（[破坏性更改](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)），Slides 实现了两包方案：
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - 支持 Windows 上的 .NET6+，以及 Windows/Linux/macOS 上的 .NETStandard，Windows 上的 .NETFramework 2+。
  - 依赖于 [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/)。
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - Windows、Linux、macOS 版本，且没有依赖。

[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) 的不便之处在于其在同一命名空间中实现了自己的 System.Drawing（以支持对公共 API 的向后兼容）。因此，同时使用 Aspose.Slides.NET6.CrossPlatform 与 .NET Framework 的 System.Drawing 或 System.Drawing.Common 包时，会产生命名冲突，除非使用别名。

为了消除主 Aspose.Slides.NET 包对 System.Drawing 的依赖，我们加入了所谓的“现代 API”——即应取代已弃用 API 使用的 API，其签名中涉及以下 System.Drawing 类型：[Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) 和 [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)。[PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) 和 [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) 已被声明为已弃用，并从公共 Slides API 中移除。

在当前版本中，请将依赖于 System.Drawing 的公共 API 视为遗留/已弃用。对新代码以及迁移现有图像处理工作流时，请使用现代 API。

## **现代 API**

已向公共 API 添加以下类和枚举：

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) - 表示光栅或矢量图像。
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) - 表示图像的文件格式。
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) - 提供实例化和使用 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 接口的方法。

请注意，[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 是可释放的（它实现了 [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) 接口，使用时应放在 using 语句中或以其他方便的方式释放）。

使用 `GetImage` 可渲染单个幻灯片或形状。使用 `GetImages` 可渲染多个演示文稿幻灯片。使用 [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) 方法加载图像，使用 `AddImage` 搭配 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 将图像添加到演示文稿，使用 `ReplaceImage` 搭配 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 更新已有的演示文稿图像。

使用新 API 的典型场景如下：

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // 实例化一个可释放的 IImage 实例，来自磁盘上的文件。  
    using (IImage image = Images.FromFile("image.png"))
    {
        // 通过将 IImage 实例添加到演示文稿的图像集合中，创建 PowerPoint 图像。
        ppImage = pres.Images.AddImage(image);
    }

    // 在第 1 张幻灯片上添加图片形状
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // 获取表示第 1 张幻灯片的 IImage 实例。
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // 将图像保存到磁盘。
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **使用现代 API 替换旧代码**

为简化过渡，新 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 接口复用了 [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) 和 [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) 类的各个签名。通常，只需将使用 System.Drawing 的旧方法调用替换为对应的新方法即可。

### **获取幻灯片缩略图**

旧版/已弃用 API：

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

现代 API：

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **获取形状缩略图**

旧版/已弃用 API：

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

现代 API：

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **获取演示文稿缩略图**

旧版/已弃用 API：

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

现代 API：

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

### **向演示文稿添加图片**

旧版/已弃用 API：

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

现代 API：

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

## **已弃用的方法/属性及其在现代 API 中的替代**

### **演示文稿**
| 方法签名 | 替代方法签名 |
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

### **形状**
| 方法签名 | 替代方法签名 |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **幻灯片**
| 方法签名 | 替代方法签名 |
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

### **输出**
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

## **API 对 Graphics 和 PrinterSettings 的支持**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) 类在跨平台的 .NET6 及更高版本中不受支持。在 Aspose Slides 中，请使用现代 API 的图像渲染方法，而不是渲染到 [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) 的 API：
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

此外，涉及通过 [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) 打印的 API 没有直接的现代 API 替代：

[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **常见问题**

### 为什么会弃用 [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)？

在公共 API 中弃用对 [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) 的支持，旨在统一渲染和图像处理方式，消除对平台特定依赖的绑定，并通过 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 实现跨平台方案。请改用 `GetImage` 或 `GetImages` 而不是渲染到 [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)。

### 与 [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) 相比，[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 的实际好处是什么？

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 统一了对光栅和矢量图像的处理，简化了通过 [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) 保存为多种格式的流程，降低了对 `System.Drawing` 的依赖，使代码在不同环境之间更具可移植性。

### 现代 API 会影响生成缩略图的性能吗？

将 `GetThumbnail` 替换为 `GetImage` 并不会导致性能下降：新方法在提供相同的选项和尺寸生成图像能力的同时，仍保留对渲染选项的支持。具体的提升或下降取决于实际使用场景，但功能上两者是等价的。