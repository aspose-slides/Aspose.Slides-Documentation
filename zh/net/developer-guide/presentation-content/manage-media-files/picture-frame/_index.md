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
- 光栅图像
- SVG 图像
- 裁剪图像
- 删除裁剪区域
- 压缩图像
- StretchOffset
- 图片框格式化
- 相对比例
- 图像效果
- 长宽比
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在演示文稿中创建、格式化、链接、裁剪、提取和压缩图片框。"
---
## **概述**

图片框是用于显示图像的幻灯片形状。在 Aspose.Slides 中，图像资源与显示该图像的形状是分离的对象：一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 通过其 [Images](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/images/) 集合拥有嵌入的图像资源，而一个 [IPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/) 控制图像的位置、大小、线条格式、旋转、裁剪、图片效果以及其他框级设置。

当同一图像需要显示多次时，这种分离非常有用。将图像一次添加到演示文稿中，保留返回的 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/)，在创建图片框时使用该图像资源。

图片框可以包含 PNG 或 JPEG 等光栅图像以及 SVG 向量图像。它们也可以引用链接图像，而不是将图像字节存储在演示文稿中。此选择会影响可移植性、文件大小、提取和导出行为，因此在进行格式化或优化之前，确定图像的存储方式是有益的。

## **添加并格式化嵌入图像**

对于嵌入图像，将图像数据添加到演示文稿并使用 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addpictureframe/) 创建图片框。图像成为演示文稿包的一部分，因此在将演示文稿移动到其他计算机时仍是自包含的。

以下示例添加 JPEG 图像，按图像的原始尺寸创建框，并应用线条格式和旋转：

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

图片框控制显示的几何形状；更改框的尺寸并不会改变嵌入图像资源中存储的原始像素尺寸。此区别在以后裁剪或压缩图像时变得重要。

## **使用相对比例**

[IPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/) 提供相对宽度和高度的缩放。`1.0` 的值对应原始图片大小的 100%。相对比例在需要保留与源图像尺寸关系而不是手动计算最终尺寸的工作流中非常有用。

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

相对比例更改框的缩放设置；它不重新采样或压缩嵌入图像。

## **嵌入图像 与 链接图像**

嵌入图片将图像数据存储在演示文稿内部，是可移植性和可预测渲染的最安全选择。链接图片通过 [ISlidesPicture](https://reference.aspose.com/slides/zh/net/aspose.slides/islidespicture/) 的链接路径指向外部位置，而不是以相同方式嵌入图像数据。

链接图像可以减小 PPTX 中存储的图像数据量，但会引入外部依赖。链接文件必须保持可供打开或渲染演示文稿的应用程序访问。如果路径更改、文件移动或资源不可用，链接图片可能无法按预期显示。对于必须通过电子邮件发送、归档或在隔离环境中渲染的演示文稿，嵌入图像通常更可靠。

### **添加链接图像**

以下示例创建一个图片框并指向本地图像文件。它仅处理图像链接；视频链接是单独的媒体工作流，此示例特意未混入。

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

在外部文件管理是有意为之时使用链接。不要仅将其用作压缩的替代方案：一个带有破损图像依赖的较小 PPTX 通常不如一个较大的自包含演示文稿实用。

## **从图片框提取图像**

在从现有演示文稿中提取图像之前，需检查形状是否真的为 [IPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/) 且是否包含嵌入图像。链接图片框可能不包含可同样方式提取的图像字节。

### **提取光栅图像**

现代图像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/)，不再需要旧的系统图像包装器。以下示例查找幻灯片上第一个嵌入的光栅图片并以 PNG 保存：

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

通过 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 保存时会将提取的图像转换为请求的输出格式。如果需要的是演示文稿中存储的编码字节而不是已转换的光栅文件，请使用图像资源的二进制数据。

### **提取 SVG 图像**

对于 SVG 图片，[IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 暴露一个 [ISvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/) 对象。这样可以直接检索 SVG 数据，而无需先对图片进行栅格化。

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

将 SVG 内容保持为 SVG 可在演示文稿内部保留向量源。PNG 或 JPEG 等光栅导出必然将该向量内容渲染为像素。PDF 或 SVG 幻灯片导出同样是渲染操作，因此导出的图形不应视为原始嵌入 SVG 的逐字复制；当需要原始向量资源本身时，请使用嵌入的 [ISvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/) 数据。

## **裁剪图像**

裁剪更改图像在框内可见的部分。[IPictureFillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/) 上的裁剪值是源图像尺寸的百分比。裁剪最初并不删除嵌入图像中的隐藏像素；它只改变可见区域。

以下示例安全地查找图片框并应用裁剪值：

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

由于隐藏的图像数据仍然存在，之后可以更改裁剪而不丢失原始像素。如果文件大小比可逆性更重要，可按下一节描述的方式物理删除裁剪区域。

## **删除裁剪的图像数据**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 删除当前裁剪矩形之外的图像数据并返回结果图像资源。这可以减小文件大小，但属于破坏性优化：演示文稿保存后，已删除的像素将不再可用于以后取消裁剪的操作。

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

此方法可能会向演示文稿添加新的图像资源。如果原始图像也被其他图片框使用，这些框仍需保留其现有资源，因此删除裁剪区域不一定会减少图像总数。使用此方法裁剪 WMF 或 EMF 内容会将裁剪结果栅格化为 PNG。

## **压缩光栅图像**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/compressimage/) 根据图片显示的尺寸相对降低光栅图像分辨率。它也可以在同一操作中删除裁剪区域。当图像已被重新尺寸化或裁剪时返回 `true`，如果无需更改则返回 `false`。

当标准目标分辨率足够时，可使用预定义的 [PicturesCompression](https://reference.aspose.com/slides/zh/net/aspose.slides.export/picturescompression/) 值：

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

如果需要特定目标，可传入自定义的正 DPI 值而不是枚举值。

压缩旨在针对光栅图像。SVG 和元文件内容不会通过此光栅压缩工作流减少。同样要记住，较低的分辨率和已删除的裁剪区域无法从优化后的演示文稿中恢复。应基于图像实际观看或导出的最大尺寸选择目标分辨率，而不是全局使用最低 DPI。

## **检查图像效果**

图片效果存储在框使用的图片上。图像变换集合可以包含透明度的固定 alpha 调制以及亮度/对比度的亮度调节等效果。下面的示例安全地读取幻灯片上一第一个图片框的两类效果：

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

这些效果改变图像在框中的渲染方式；它们不会重写原始嵌入图像的字节。

## **锁定图片框几何形状**

[IPictureFrameLock](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframelock/) 设置控制哪些编辑操作对图片框被禁用。例如，宽高比锁定在调整大小时保持形状比例。

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

锁定适用于图片框形状本身。它不会强制源图像重新采样或永久性地更改为相同的宽高比。

## **调整 StretchOffset 值**

当图片填充模式为 stretch 时，[IPictureFillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/) 上的 stretch‑offset 值定义相对于图片框边界框的填充矩形。正百分比在边缘形成内缩，负百分比则形成外伸。

这不同于裁剪。裁剪值选择源图像的可见部分；stretch‑offset 改变可见图片填充被拉伸的矩形。

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

使用 stretch‑offset 进行填充定位。需要隐藏源图像边缘时使用裁剪属性。

## **存储、文件大小与导出考虑事项**

当图像存储与图片框格式分开处理时，主要权衡更容易管理：

- **嵌入图像** 使演示文稿自包含，是共享和服务器端渲染最可靠的选择，但大型光栅图像会增加 PPTX 大小和内存使用。
- **链接图像** 可以保持包体更小，但演示文稿依赖外部文件在存储的路径或位置保持可用。
- **裁剪** 最初是非破坏性的。隐藏的像素保持嵌入，直到显式删除裁剪区域或在压缩期间移除。
- **压缩** 可显著降低超大光栅图像的文件大小，但会牺牲源分辨率。应在已知幻灯片上实际显示尺寸后再应用。
- **SVG 图像** 在需要保留向量时应保持为 SVG。需要向量资源本身时直接提取嵌入的 SVG。光栅幻灯片导出始终将渲染的幻灯片转换为像素。
- **重复图像** 应尽可能复用已有的 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 资源，而不是在演示文稿工作流中反复加载同一文件。

对于大型演示文稿，图像优化通常在选择性执行时最有效：将标志和图表保留为向量内容，根据实际显示尺寸压缩照片，仅在不需要后期编辑时移除裁剪像素，并且除非部署设计中已考虑依赖管理，否则避免使用外部链接。

## **常见问题解答**

**图片框与图像资源有什么区别？**

[IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 表示与演示文稿关联的图像资源。[IPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/) 是幻灯片上的形状，用于显示图像并存储框级几何和格式信息，如大小、旋转、裁剪值、效果和锁定。

**我应该嵌入还是链接图像？**

当演示文稿必须可移植、归档或在没有外部资源的情况下渲染时请嵌入图像。仅在有意将图像文件保留在 PPTX 之外且能够可靠维护外部位置时才链接图像。

**裁剪会减小 PPTX 文件大小吗？**

单独的裁剪不会。普通裁剪设置会隐藏源图像的部分，但仍保留底层像素。使用 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 或在压缩时删除裁剪区域才能永久丢弃这些像素。

**压缩后能恢复图像质量吗？**

不能。压缩会降低存储的光栅分辨率，删除裁剪区域会丢弃图像数据。如果以后可能需要高分辨率编辑，请在演示文稿之外保留原始源图像。

**SVG 图像应如何处理？**

在向量保真度重要时保持 SVG 为 SVG。可以直接提取嵌入的 [ISvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/)。将幻灯片渲染为 PNG 或 JPEG 等光栅格式会将 SVG 栅格化为幻灯片图像。

**如何避免读取现有幻灯片时的不安全强制转换？**

在使用图片框特定成员之前检查形状类型。使用对 [IPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/) 的模式匹配或按该接口过滤形状集合，可避免无效强制转换，并让代码能够处理不包含图片框的幻灯片。