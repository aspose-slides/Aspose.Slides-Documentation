---
title: 在 .NET 中管理演示文稿中的图片框
linktitle: 图片框
type: docs
weight: 10
url: /zh/net/picture-frame/
keywords:
- 图片框
- 添加图片框
- 创建图片框
- 嵌入图像
- 链接图像
- 提取图像
- 栅格图像
- SVG 图像
- 裁剪图像
- 删除已裁剪区域
- 压缩图像
- StretchOffset
- 图片框格式化
- 相对缩放
- 图像效果
- 宽高比
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在演示文稿中创建、格式化、链接、裁剪、提取和压缩图片框。"
---
## **概览**

图片框是一种显示图像的幻灯片形状。在 Aspose.Slides 中，图像资源与显示它的形状是分离的对象：一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 通过其 [Images](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/images/) 集合拥有嵌入的图像资源，而一个 [IPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/) 控制图像的位置、大小、线条格式、旋转、裁剪、图片效果以及其他框级设置。

这种分离在同一图像需要显示多次时非常有用。将图像一次添加到演示文稿中，保留返回的 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/)，在创建图片框时使用该图像资源。

图片框可以包含 PNG 或 JPEG 等栅格图像以及 SVG 等矢量图像。它们也可以引用链接图像，而不是将图像字节存储在演示文稿中。此选择会影响可移植性、文件大小、提取和导出行为，因此在进行格式设置或优化之前，决定图像应如何存储是很有用的。

## **添加并格式化嵌入图像**

对于嵌入图像，先将图像数据添加到演示文稿，然后使用 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addpictureframe/) 创建图片框。图像会成为演示文稿包的一部分，因此将演示文稿移动到另一台计算机时仍保持自包含。

下面的示例添加 JPEG 图像，按图像的原始尺寸创建框，并应用线条格式和旋转：

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

图片框控制显示的几何形状；更改框的大小不会更改嵌入图像资源中存储的原始像素尺寸。此区别在以后对图像进行裁剪或压缩时非常重要。

## **使用相对缩放**

[IPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/) 提供框的相对宽度和高度缩放。值 `1.0` 对应原始图片大小的 100%。相对缩放在工作流需要保持与源图像大小的比例关系而不是手动计算最终尺寸时非常有用。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

相对缩放会更改框的缩放设置；它不会对嵌入的图像进行重新采样或压缩。

## **嵌入图像和链接图像**

嵌入图片将图像数据存储在演示文稿内部，是可移植性和可预测渲染的最安全选择。链接图片通过 [ISlidesPicture](https://reference.aspose.com/slides/zh/net/aspose.slides/islidespicture/) 的链接路径指向外部位置，而不是以相同方式嵌入图像数据。

链接图像可以减小 PPTX 中存储的图像数据量，但会引入外部依赖。打开或渲染演示文稿的应用程序必须能够访问该链接文件。如果路径更改、文件移动或资源不可用，链接图片可能无法按预期显示。对于必须通过电子邮件发送、归档或在隔离环境中渲染的演示文稿，嵌入图像通常更可靠。

### **添加链接图像**

下面的示例创建一个图片框并指向本地图像文件。它仅处理图像链接；视频链接是单独的媒体工作流，故意未混入此示例。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

在外部文件管理是有意的情况下使用链接。不要仅将其作为压缩的替代方案：一个带有破损图像依赖关系的小 PPTX 往往不如一个较大的自包含演示文稿有用。

## **从图片框提取图像**

在从现有演示文稿提取图像之前，检查形状是否实际为 [IPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/) 且是否包含嵌入图像。链接图片框可能不包含可供同样方式提取的图像字节。

### **提取栅格图像**

现代图像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/)，不再需要旧的系统图像包装器。下面的示例在幻灯片上找到第一个嵌入的栅格图片并以 PNG 保存：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

通过 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 保存会将提取的图像转换为请求的输出格式。如果需要演示文稿中存储的编码字节而不是已转换的栅格文件，请使用图像资源的二进制数据。

### **提取 SVG 图像**

对于 SVG 图片，[IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 暴露一个 [ISvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/) 对象。这样可以直接检索 SVG 数据，而无需先光栅化图片。

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

保持 SVG 内容为 SVG 可以在演示文稿中保留矢量来源。PNG 或 JPEG 等栅格导出必然将该矢量内容渲染为像素。PDF 或 SVG 幻灯片导出同样是一种渲染操作，因此导出的图形不应被视为原始嵌入 SVG 的逐字节副本；当需要原始矢量资源本身时，请使用嵌入的 [ISvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/) 数据。

## **裁剪图像**

裁剪改变了在框内可见的图像部分。[IPictureFillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/) 上的裁剪值以源图像尺寸的百分比表示。裁剪不会立即从嵌入图像中删除隐藏的像素；它仅改变可见区域。

下面的示例安全地找到图片框并应用裁剪值：

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

由于隐藏的图像数据仍然存在，裁剪可以在以后更改而不会丢失原始像素。如果文件大小比可逆性更重要，可以按下一节所述物理移除裁剪区域。

## **删除已裁剪的图像数据**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 删除当前裁剪矩形之外的图像数据并返回结果图像资源。这可以减小文件大小，但是一种破坏性优化：演示文稿保存后，已删除的像素将不再可用于后续的取消裁剪操作。

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

该方法可能会向演示文稿添加新的图像资源。如果原始图像也被其他图片框使用，这些框仍需要其现有资源，因此删除裁剪区域不一定会减少图像总数。使用此方法裁剪 WMF 或 EMF 内容会将裁剪结果光栅化为 PNG。

## **压缩栅格图像**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/compressimage/) 根据图片实际显示的尺寸降低栅格图像分辨率。它也可以在同一次操作中删除已裁剪的区域。当图像被重新调整大小或裁剪时方法返回 `true`，未作更改时返回 `false`。

当标准目标分辨率足够时，使用预定义的 [PicturesCompression](https://reference.aspose.com/slides/zh/net/aspose.slides.export/picturescompression/) 值：

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

如果需要特定目标，也可以传入自定义的正 DPI 值而不是枚举值。

压缩旨在用于栅格图像。SVG 和元文件内容不会通过此栅格压缩工作流被减小。还要记住，降低分辨率和删除已裁剪区域后无法从优化后的演示文稿中恢复。应基于图像实际观看或导出时的最大尺寸来选择目标分辨率，而不是全局使用最低 DPI。

## **管理图像变换效果**

有关涵盖亮度、对比度、颜色变换、模糊、透明度、顺序链、检查、移除以及往返验证的完整工作流，请参阅 [Image Transform Effects](/slides/zh/net/image-transform-effects/)。

## **锁定图片框几何**

[IPictureFrameLock](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframelock/) 设置控制对图片框禁用哪些编辑操作。例如，宽高比锁定在调整大小时保持形状的比例。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

锁定作用于图片框形状本身。它不会强制源图像重新采样或永久改为相同的宽高比。

## **调整 StretchOffset 值**

当图片填充模式为 stretch 时， [IPictureFillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/) 上的 stretch-offset 值相对于图片框的边界框定义填充矩形。正百分比会从边缘向内收缩，负百分比会向外扩展。

这不同于裁剪。裁剪值选择源图像的哪一部分可见；stretch offset 改变可见图片填充被拉伸的矩形。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

使用 stretch offset 来定位填充。需要隐藏源图像边缘时使用裁剪属性。

## **存储、文件大小和导出注意事项**

当图像存储和图片框格式分开处理时，主要权衡更易管理：

- **嵌入图像** 使演示文稿自包含，是共享和服务器端渲染最可靠的方式，但大型栅格图像会增加 PPTX 大小和内存使用。
- **链接图像** 可以保持包体更小，但演示文稿依赖外部文件在存储路径或位置保持可用。
- **裁剪** 起初是非破坏性的。隐藏的像素会一直嵌入，直到显式删除裁剪区域或在压缩时移除。
- **压缩** 可以显著减小超大栅格图像的文件大小，但会牺牲源分辨率。应在确定幻灯片上实际显示尺寸后再应用。
- **SVG 图像** 在矢量保留重要时应保持为 SVG。当需要矢量资源本身时直接提取嵌入的 SVG。栅格幻灯片导出始终将渲染的幻灯片转换为像素。
- **重复图像** 应尽可能复用已有的 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 资源，而不是在演示文稿工作流中反复加载同一文件。

对于大型演示文稿，图像优化通常在有选择地执行时最有效：将标志和图表保留为矢量内容，根据实际显示大小压缩照片，仅在不需要后续编辑时移除裁剪像素，并除非依赖管理是部署设计的一部分，否则避免使用外部链接。

## **常见问题**

**图片框和图像资源有什么区别？**

[IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 表示与演示文稿关联的图像资源。[IPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/) 是幻灯片上的一种形状，用于显示图像并存储框级几何和格式，如大小、旋转、裁剪值、效果和锁定。

**应该嵌入还是链接图像？**

当演示文稿必须可移植、归档或在没有外部资源的情况下渲染时请嵌入图像。仅在有意将图像文件保留在 PPTX 外部且能够可靠维护外部位置时才链接图像。

**裁剪会减小 PPTX 文件大小吗？**

单独裁剪不会。普通裁剪设置会隐藏源图像的部分，但仍保留底层像素。使用 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 或在压缩时删除裁剪区域可永久丢弃这些像素。

**压缩后还能恢复图像质量吗？**

不能。压缩会降低存储的栅格分辨率，删除裁剪区域会丢弃图像数据。如果以后可能需要高分辨率编辑，请在演示文稿外保留原始源图像。

**应如何处理 SVG 图像？**

当矢量保真度重要时保持 SVG 内容为 SVG。嵌入的 [ISvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/) 可以直接提取。将幻灯片渲染为 PNG 或 JPEG 等栅格格式会将 SVG 光栅化为幻灯片图像。

**在读取已有幻灯片时如何避免不安全的强制转换？**

在使用图片框特定成员之前检查形状类型。使用 [IPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/) 的模式匹配或按该接口过滤形状集合，可避免无效强制转换，并让代码能够处理不包含图片框的幻灯片。