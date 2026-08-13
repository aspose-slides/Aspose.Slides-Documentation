---
title: 在 .NET 中管理演示文稿的图片框
linktitle: 图片框
type: docs
weight: 10
url: /zh/net/picture-frame/
keywords:
- 图片框
- 添加图片框
- 创建图片框
- 添加图像
- 创建图像
- 提取图像
- 光栅图像
- 矢量图像
- 裁剪图像
- 裁剪区域
- StretchOff 属性
- 图片框格式化
- 图片框属性
- 相对比例
- 图像效果
- 宽高比
- 图像透明度
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将图片框添加到 PowerPoint 和 OpenDocument 演示文稿。简化工作流并提升幻灯片设计。"
---
## **介绍**

图片框是一种包含图像的形状——它类似于装在框中的图片。

您可以通过图片框向幻灯片添加图像。这样，您可以通过格式化图片框来格式化图像。

{{% alert  title="Tip" color="info" %}} 
Aspose 提供免费的转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——帮助人们快速从图像创建演示文稿。 
{{% /alert %}} 

## **创建图片框**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。 
2. 通过索引获取幻灯片的引用。 
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/zh/net/aspose.slides/iimagecollection) 添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage) 对象，用于填充形状。 
4. 指定图像的宽度和高度。 
5. 通过引用的幻灯片关联的形状对象公开的 `AddPictureFrame` 方法，根据图像的宽度和高度创建一个 [PictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/pictureframe) 对象。 
6. 将包含图片的图片框添加到幻灯片。 
7. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C# 代码演示如何创建图片框：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation pres = new Presentation())
{
    // 获取第一张幻灯片
    ISlide slide = pres.Slides[0];

    // 加载图像并将其添加到演示文稿的图像集合
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 添加一个具有相同高度和宽度的图片框
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 对图片框应用一些格式设置
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // 将演示文稿写入 PPTX 文件
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
图片框允许您快速基于图像创建演示幻灯片。当将图片框与 Aspose.Slides 的保存选项结合使用时，您可以操作输入/输出以将图像从一种格式转换为另一种格式。您可能想查看以下页面：转换 [image to JPG](https://products.aspose.com/slides/zh/net/conversion/image-to-jpg/)；转换 [JPG to image](https://products.aspose.com/slides/zh/net/conversion/jpg-to-image/)；转换 [JPG to PNG](https://products.aspose.com/slides/zh/net/conversion/jpg-to-png/)，转换 [PNG to JPG](https://products.aspose.com/slides/zh/net/conversion/png-to-jpg/)；转换 [PNG to SVG](https://products.aspose.com/slides/zh/net/conversion/png-to-svg/)，转换 [SVG to PNG](https://products.aspose.com/slides/zh/net/conversion/svg-to-png/)。 
{{% /alert %}}

## **使用相对比例创建图片框**

通过改变图像的相对缩放，您可以创建更复杂的图片框。 

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。 
2. 通过索引获取幻灯片的引用。 
3. 将图像添加到演示文稿的图像集合中。 
4. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/zh/net/aspose.slides/iimagecollection) 添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage) 对象，用于填充形状。 
5. 在图片框中指定图像的相对宽度和高度。 
6. 将修改后的演示文稿写入为 PPTX 文件。

以下代码示例演示如何使用相对比例创建图片框：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation presentation = new Presentation())
{
    // 加载图像并将其添加到演示文稿的图像集合
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 向幻灯片添加图片框
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 设置相对比例的高度和宽度
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // 保存演示文稿
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **从图片框提取光栅图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/pictureframe) 对象中提取光栅图像，并将其保存为 PNG、JPG 等格式。下面的代码示例演示如何从文档 "sample.pptx" 中提取图像并以 PNG 格式保存。

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **从图片框提取 SVG 图像**

当演示文稿在 [PictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/pictureframe/) 形状中包含 SVG 图形时，Aspose.Slides for .NET 允许您完整保真地检索原始矢量图像。通过遍历幻灯片的形状集合，您可以识别每个 [PictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/pictureframe/)，检查其底层的 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 是否包含 SVG 内容，然后将该图像以原生 SVG 格式保存到磁盘或流中。

以下代码示例演示如何从图片框中提取 SVG 图像：

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **获取图像的透明度**

Aspose.Slides 允许您获取应用于图像的透明度效果。下面的 C# 代码演示此操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **获取图像的亮度和对比度**

Aspose.Slides 允许您获取应用于图像的亮度和对比度效果。[ILuminance](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iluminance/) 接口表示此图像变换效果。

下面的 C# 代码演示如何从图片框获取亮度和对比度设置：

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="info" %}} 
所有应用于图像的效果均可在 [Aspose.Slides.Effects](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/) 中找到。 
{{% /alert %}}

## **图片框格式化**

Aspose.Slides 提供了许多可应用于图片框的格式化选项。使用这些选项，您可以更改图片框以满足特定需求。

1. 创建 [Presentation](http://www.aspose.com/api/net/slides/zh/aspose.slides/) 类的实例。 
2. 通过索引获取幻灯片的引用。 
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/zh/net/aspose.slides/iimagecollection) 添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage) 对象，用于填充形状。 
4. 指定图像的宽度和高度。 
5. 通过引用的幻灯片关联的 [IShapes](http://www.aspose.com/api/net/slides/zh/aspose.slides/ishapecollection) 对象公开的 [AddPictureFrame](http://www.aspose.com/api/net/slides/zh/aspose.slides/ishapecollection/methods/addpictureframe) 方法，根据图像的宽度和高度创建 `PictureFrame`。 
6. 将包含图片的图片框添加到幻灯片中。 
7. 设置图片框的线条颜色。 
8. 设置图片框的线条宽度。 
9. 通过提供正值或负值来旋转图片框。 
   * 正值使图像顺时针旋转。 
   * 负值使图像逆时针旋转。 
10. 将包含图片的图片框添加到幻灯片中。 
11. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C# 代码演示图片框格式化过程：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片
    ISlide slide = presentation.Slides[0];

    // 加载图像并将其添加到演示文稿的图像集合
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 添加一个具有相同高度和宽度的图片框
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 对图片框应用一些格式设置
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // 将演示文稿写入 PPTX 文件
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}

Aspose 最近开发了一个 [free Collage Maker](https://products.aspose.app/slides/zh/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/zh/collage/jpg) 或 PNG 图像，或 [从照片创建网格](https://products.aspose.app/slides/zh/collage/photo-grid)，可以使用此服务。 

{{% /alert %}}

## **将图像添加为链接**

为避免演示文稿体积过大，您可以通过链接而不是直接嵌入文件的方式添加图像（或视频）。下面的 C# 代码演示如何在占位符中添加图像和视频：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **裁剪图像**

下面的 C# 代码演示如何裁剪幻灯片上的现有图像：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // 创建一个新的图像对象
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 向幻灯片添加 PictureFrame
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // 裁剪图像（百分比值）
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // 保存结果
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **删除图片的裁剪区域**

如果您想删除框中图像的裁剪区域，可以使用 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法。若无需裁剪，此方法返回原始图像。

下面的 C# 代码演示此操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 获取第一张幻灯片上的 PictureFrame
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // 删除 PictureFrame 图像的裁剪区域并返回裁剪后的图像
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // 保存结果
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法会将裁剪后的图像添加到演示文稿的图像集合中。如果该图像仅在处理后的 [PictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/pictureframe/) 中使用，此设置可以减小演示文稿的大小。否则，生成的演示文稿中的图像数量会增加。

此方法在裁剪操作中会将 WMF/EMF 元文件转换为光栅 PNG 图像。 

{{% /alert %}}

## **压缩图像**

您可以使用 [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/compressimage/) 方法压缩演示文稿中的图片。此方法通过根据形状大小和指定的分辨率降低图像尺寸来压缩图像，并可选择删除裁剪区域。

它调整图片的尺寸和分辨率，类似于 PowerPoint 的 **图片格式 → 压缩图片 → 分辨率** 功能。

以下 C# 示例演示如何通过指定目标分辨率并可选择删除裁剪区域来压缩演示文稿中的图像：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 使用目标分辨率 150 DPI（网页分辨率）压缩图像并删除裁剪区域。
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // 检查压缩结果。
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

或直接使用自定义 DPI 值：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 压缩图像至 150 DPI（网页分辨率），并删除裁剪区域。
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

该方法根据形状的大小和提供的 DPI 将图像转换为更低的分辨率。裁剪区域也可以被删除以优化文件大小。  
如果图像是元文件（WMF/EMF）或 SVG，则不会进行压缩。此外，JPEG 的质量会根据分辨率保持或略有下降，类似于 PowerPoint 处理高分辨率 JPEG 的方式。 

{{% /alert %}}

## **锁定宽高比**

如果您希望包含图像的形状在更改图像尺寸后仍保持宽高比，可以使用 [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframelock/aspectratiolocked/) 属性设置 *锁定宽高比*。

下面的 C# 代码演示如何锁定形状的宽高比：

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // 设置形状在调整大小时保持宽高比
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

*锁定宽高比* 设置仅保留形状的宽高比，而不影响其所包含的图像。 
{{% /alert %}}

## **使用 StretchOff 属性**

使用 [StretchOffsetLeft](https://reference.aspose.com/slides/zh/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)、[StretchOffsetTop](https://reference.aspose.com/slides/zh/net/aspose.slides/picturefillformat/properties/stretchoffsettop)、[StretchOffsetRight](https://reference.aspose.com/slides/zh/net/aspose.slides/picturefillformat/properties/stretchoffsetright) 和 [StretchOffsetBottom](https://reference.aspose.com/slides/zh/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) 属性（来自 [IPictureFillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/picturefillformat) 类），您可以指定填充矩形。

当对图像指定拉伸时，源矩形将按比例缩放以适应指定的填充矩形。填充矩形的每条边均由相对于形状边界框相应边缘的百分比偏移定义。正百分比表示向内缩进，负百分比表示向外延伸。

1. 创建 [Presentation](http://www.aspose.com/api/net/slides/zh/aspose.slides/) 类的实例。 
2. 通过索引获取幻灯片的引用。 
3. 添加一个矩形 `AutoShape`。 
4. 创建图像。 
5. 设置形状的填充类型。 
6. 设置形状的图片填充模式。 
7. 添加已设置的图像以填充形状。 
8. 指定图像相对于形状边界框相应边缘的偏移量 
9. 将修改后的演示文稿写入为 PPTX 文件。 

下面的 C# 代码演示使用 StretchOff 属性的过程：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // 设置图像在形状主体内从各侧拉伸
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **常见问题**

### 如何了解 PictureFrame 支持的图像格式？

Aspose.Slides 通过分配给 [PictureFrame] 的图像对象支持光栅图像（PNG、JPEG、BMP、GIF 等）和矢量图像（例如 SVG）。支持的格式列表通常与幻灯片及图像转换引擎的功能相吻合。

### 添加大量大图像会如何影响 PPTX 大小和性能？

嵌入大图像会增加文件大小和内存占用；链接图像有助于保持演示文稿体积较小，但需要外部文件保持可访问。Aspose.Slides 提供通过链接添加图像的功能，以减小文件大小。

### 如何锁定图像对象以防止意外移动/缩放？

可使用针对 [PictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/pictureframe/pictureframelock/) 的 [shape locks](https://reference.aspose.com/slides/zh/net/aspose.slides/pictureframe/pictureframelock/)（例如，禁用移动或缩放）。此锁定机制在针对形状的单独 [保护文章](/slides/zh/net/applying-protection-to-presentation/) 中有描述，适用于包括 [PictureFrame] 在内的多种形状类型。

### 将演示文稿导出为 PDF/图像时，SVG 矢量保真度是否得到保留？

Aspose.Slides 允许从 [PictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/pictureframe/) 中提取原始矢量的 SVG。导出为 PDF[/slides/zh/net/convert-powerpoint-to-pdf/] 或光栅格式[/slides/zh/net/convert-powerpoint-to-png/] 时，结果可能会根据导出设置进行栅格化；提取行为证实原始 SVG 仍以矢量形式存储。