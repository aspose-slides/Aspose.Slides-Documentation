---
title: 使用现代 API 加强图像处理
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
description: "通过使用 .NET 现代 API 替换已弃用的图像 API，实现幻灯片图像处理的现代化，从而实现 PowerPoint 和 OpenDocument 的无缝自动化。"
---
## **简介**

从历史上看，Aspose Slides 依赖于 System.Drawing，并在公共 API 中包含以下来自该库的类：
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

自 24.4 版本起，此公共 API 已标记为已弃用。

由于 .NET6 及以上版本的非 Windows 平台已移除 System.Drawing 支持（[breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)），Slides 实现了两包方案：
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - 支持 Windows 的 .NET6+，以及 Windows/Linux/MacOS 的 .NETStandard，Windows 的 .NETFramework 2+。  
  - 依赖于 [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/)。
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - 不含依赖的 Windows/Linux/MacOS 版本。

[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) 的不便之处在于，它在相同命名空间中实现了自己的 System.Drawing（以保持与公共 API 的向后兼容）。因此，当同时使用 Aspose.Slides.NET6.CrossPlatform 与 .NET Framework 中的 System.Drawing 或 System.Drawing.Common 包时，除非使用别名，否则会出现命名冲突。

为了去除主 Aspose.Slides.NET 包对 System.Drawing 的依赖，我们添加了所谓的“现代 API”——即应取代已弃用 API 的 API，其签名不再依赖 System.Drawing 中的 [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) 和 [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) 类型。[PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) 和 [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) 已标记为已弃用，并且其支持已从公共 Slides API 中移除。

在当前版本中，请将依赖于 System.Drawing 的公共 API 视为遗留/已弃用。新代码以及迁移现有图像处理工作流时请使用现代 API。

## **现代 API**

向公共 API 添加了以下类和枚举：

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) - 表示光栅或矢量图像。
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/imageformat/) - 表示图像的文件格式。
- [Aspose.Slides.Images](https://reference.aspose.com/slides/zh/net/aspose.slides/images/) - 用于实例化和操作 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 接口的方法。

请注意，[IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 实现了 [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) 接口，使用时应放入 using 块或以其他方便的方式进行释放。

使用 `GetImage` 渲染单张幻灯片或形状。使用 `GetImages` 渲染多张演示文稿幻灯片。使用 [Images](https://reference.aspose.com/slides/zh/net/aspose.slides/images/) 方法加载图像，使用带有 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 的 `AddImage` 将其添加到演示文稿，使用带有 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 的 `ReplaceImage` 更新已有的演示文稿图像。

使用新 API 的典型场景可能如下所示：

```csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // 实例化一个可释放的 IImage 实例，从磁盘上的文件中加载。  
    using (IImage image = Images.FromFile("image.png"))
    {
        // 通过将 IImage 实例添加到演示文稿的图像集合来创建 PowerPoint 图像。
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

为了便于迁移，新 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 接口重复了 [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) 和 [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) 类的独立签名。通常，只需将使用 System.Drawing 的旧方法调用替换为对应的新方法。

### **获取幻灯片缩略图**

遗留/已弃用 API：

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

遗留/已弃用 API：

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

遗留/已弃用 API：

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

遗留/已弃用 API：

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

## **已弃用的方法/属性及其在现代 API 中的替代**

### **Presentation**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | 没有 Modern API 替代 |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | 没有 Modern API 替代 |
| public void Print() | 没有 Modern API 替代 |
| public void Print(PrinterSettings printerSettings) | 没有 Modern API 替代 |
| public void Print(string printerName) | 没有 Modern API 替代 |
| public void Print(PrinterSettings printerSettings, string presName) | 没有 Modern API 替代 |

### **Shape**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | 没有 Modern API 替代 |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | 没有 Modern API 替代 |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | 没有 Modern API 替代 |

### **Output**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------|---------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/zh/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------|---------------------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/zh/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/zh/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| 方法/属性签名 | 替代方法签名 |
|-----------------------------------------------|---------------------------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/zh/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/zh/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------|---------------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/zh/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/zh/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------|---------------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/zh/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Graphics 和 PrinterSettings 的 API 支持**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) 类在 .NET6 及更高版本的跨平台版本中不受支持。在 Aspose Slides 中，请使用现代 API 的图像渲染方法，而不是渲染到 [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) 的 API：
[ISlide](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/rendertographics/#rendertographics_5)

同样，与通过 [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) 打印相关的 API 没有直接的现代 API 替代：

[IPresentation](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/print/#print_2)

## **常见问答**

**为什么移除了 [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)？**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) 在公共 API 中已被弃用，以统一渲染和图像处理工作，消除平台特定依赖，并转向使用跨平台的 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 方法。请使用 `GetImage` 或 `GetImages` 代替渲染到 [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)。

**相较于 [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) / [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)，[IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 的实际优势是什么？**

[IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 统一了光栅和矢量图像的处理，简化了通过 [ImageFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/imageformat/) 保存为多种格式的操作，降低了对 `System.Drawing` 的依赖，使代码在不同环境中更具可移植性。

**使用现代 API 会影响生成缩略图的性能吗？**

从 `GetThumbnail` 切换到 `GetImage` 并不会降低性能：新方法提供了相同的图像生成能力和可选尺寸/选项，同时保留了渲染选项的支持。具体的提升或下降取决于使用场景，但在功能上这两者是等价的。