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
description: "通过使用 .NET 现代 API 替换已弃用的图像 API，现代化幻灯片图像处理，实现 PowerPoint 和 OpenDocument 的无缝自动化。"
---

## **介绍**

Historically, Aspose Slides has a dependency on System.Drawing and has in the public API the following classes from there:
- [图形](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [图像](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [位图](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [打印机设置](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

从 24.4 版开始，此公共 API 已被声明为已弃用。

由于 .NET6 及以上版本的 System.Drawing 支持已在非 Windows 版本中移除（[重大更改](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)），Slides 实现了两种库版本的方案：
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - 支持 Windows 上的 .NET6+，Windows/Linux/MacOS 上的 .NETStandard，Windows 上的 .NETFramework 2+。
  - 依赖于 [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/)。
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - Windows/Linux/MacOS 版本，无任何依赖。

[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) 的不便之处在于它在同一命名空间中实现了自己的 System.Drawing（以保持对公共 API 的向后兼容）。因此，当同时使用 Aspose.Slides.NET6.CrossPlatform 与 .NETFramework 中的 System.Drawing 或 System.Drawing.Common 包时，除非使用别名，否则会发生名称冲突。

为了摆脱主 Aspose.Slides.NET 包对 System.Drawing 的依赖，我们添加了所谓的“现代 API”——即应该取代已弃用 API 的 API，其签名不再依赖于 System.Drawing 中的 Image 和 Bitmap 类型。PrinterSettings 和 Graphics 已声明为已弃用，并且其在公共 Slides API 中的支持已被移除。

在 24.8 版发布时，将移除带有 System.Drawing 依赖的已弃用公共 API。

## **现代 API**

向公共 API 添加了以下类和枚举：

- Aspose.Slides.IImage - 表示光栅或矢量图像。
- Aspose.Slides.ImageFormat - 表示图像的文件格式。
- Aspose.Slides.Images - 用于实例化和使用 IImage 接口的方法。

请注意，IImage 实现了 IDisposable 接口，使用时应放在 using 中或以其他合适方式释放。

使用新 API 的典型场景如下所示：
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // 从磁盘文件实例化一个可释放的 IImage 实例。  
    using (IImage image = Images.FromFile("image.png"))
    {
        // 通过将 IImage 实例添加到演示文稿的图像集合中创建 PowerPoint 图像。
        ppImage = pres.Images.AddImage(image);
    }

    // 在幻灯片 #1 上添加图片形状
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // 获取表示幻灯片 #1 的 IImage 实例。
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // 将图像保存到磁盘。
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```


## **用现代 API 替换旧代码**

为了便于迁移，新 IImage 接口复用了 Image 和 Bitmap 类的独立签名。一般情况下，您只需将使用 System.Drawing 的旧方法调用替换为新的调用即可。

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


## **将被移除的方法/属性及其在现代 API 中的替代方案**

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
|----------------------------------------------------------|-----------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| 方法/属性签名 | 替代方法签名 |
|--------------------------|---------------------------|
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

## **Graphics 和 PrinterSettings 的 API 支持将被终止**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) 类在 .NET6 及更高版本的跨平台环境中不再受支持。在 Aspose Slides 中，使用该类的 API 部分将被移除：
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

此外，与打印相关的 API 部分也将被移除：

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

# **常见问题**

**为什么放弃了 System.Drawing.Graphics？**

从公共 API 中移除 `Graphics` 支持是为了统一渲染和图像的处理，消除对平台特定依赖的关联，并转向使用跨平台的 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 的方式。所有面向 `Graphics` 的渲染方法都将被删除。

**IImage 相比 Image/Bitmap 有什么实际好处？**

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 将光栅图像和矢量图像统一在一个接口下，简化了通过 [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) 保存为多种格式的过程，降低了对 `System.Drawing` 的依赖，使代码在不同环境中的可移植性更高。

**现代 API 会影响生成缩略图的性能吗？**

从 `GetThumbnail` 切换到 `GetImage` 并不会导致性能下降：新方法提供了相同的图像生成功能，并支持相同的选项和尺寸。具体的性能提升或下降取决于使用场景，但功能上两者是等价的。