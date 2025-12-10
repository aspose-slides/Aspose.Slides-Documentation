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
- 纵横比
- 图像透明度
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将图片框添加到 PowerPoint 和 OpenDocument 演示文稿。简化工作流程并提升幻灯片设计。"
---

图片框是包含图像的形状——它就像装在框中的图片。

您可以通过图片框向幻灯片添加图像。通过这种方式，您可以通过格式化图片框来格式化图像。

{{% alert  title="Tip" color="primary" %}} 

Aspose 提供免费转换器——[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——帮助用户快速从图像创建演示文稿。

{{% /alert %}} 

## **创建图片框**

1. 创建 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。 
2. 通过索引获取幻灯片的引用。 
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) 添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，用于填充形状。 
4. 指定图像的宽度和高度。 
5. 通过关联的幻灯片的形状对象公开的 `AddPictureFrame` 方法，基于图像的宽度和高度创建一个 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe)。 
6. 将包含图片的图片框添加到幻灯片中。 
7. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C# 代码演示如何创建图片框：
```c#
// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation pres = new Presentation())
{
    // 获取第一张幻灯片
    ISlide slide = pres.Slides[0];

    // 加载图像并将其添加到演示文稿的图像集合中
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

图片框让您能够快速基于图像创建演示文稿幻灯片。当您将图片框与 Aspose.Slides 的保存选项结合使用时，您可以操作输入/输出以将图像从一种格式转换为另一种格式。您可能想浏览以下页面：将 [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/) 转换；将 [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/) 转换；将 [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/) 转换， 将 [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/) 转换；将 [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/) 转换， 将 [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/) 转换。

{{% /alert %}}

## **创建带相对比例的图片框**

通过更改图像的相对缩放，您可以创建更复杂的图片框。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。 
2. 通过索引获取幻灯片的引用。 
3. 将图像添加到演示文稿的图像集合中。 
4. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) 添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，用于填充形状。 
5. 在图片框中指定图像的相对宽度和高度。 
6. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C# 代码演示如何创建带相对比例的图片框：
```c#
// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation presentation = new Presentation())
{
    // 加载图像并将其添加到演示文稿的图像集合中
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 向幻灯片添加图片框
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 设置相对缩放宽度和高度
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // 保存演示文稿
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```


## **从图片框中提取光栅图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) 对象中提取光栅图像，并将其保存为 PNG、JPG 等格式。下面的代码示例演示如何从文档 "sample.pptx" 中提取图像并保存为 PNG 格式。
```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```


## **从图片框中提取 SVG 图像**

当演示文稿包含放置在 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) 形状中的 SVG 图形时，Aspose.Slides for .NET 允许您以完整保真度检索原始矢量图像。通过遍历幻灯片的形状集合，您可以识别每个 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/)，检查底层的 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) 是否包含 SVG 内容，然后以原生 SVG 格式将该图像保存到磁盘或流中。

下面的代码示例演示如何从图片框中提取 SVG 图像：
```cs
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


{{% alert color="primary" %}} 
所有应用于图像的效果可在 [Aspose.Slides.Effects](https://reference.aspose.com/slides/net/aspose.slides.effects/) 中找到。
{{% /alert %}}

## **图片框格式化**

Aspose.Slides 提供了许多可应用于图片框的格式化选项。使用这些选项，您可以更改图片框以满足特定需求。

1. 创建 [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) 类的实例。 
2. 通过索引获取幻灯片的引用。 
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) 添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，用于填充形状。 
4. 指定图像的宽度和高度。 
5. 通过关联的幻灯片的形状对象公开的 [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) 方法，基于图像的宽度和高度创建一个 `PictureFrame`。 
6. 将包含图片的图片框添加到幻灯片中。 
7. 设置图片框的线条颜色。 
8. 设置图片框的线条宽度。 
9. 通过给定正值或负值来旋转图片框。 
   * 正值会顺时针旋转图像。 
   * 负值会逆时针旋转图像。 
10. 将包含图片的图片框添加到幻灯片中。 
11. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C# 代码演示图片框格式化过程：
```c#
// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片
    ISlide slide = presentation.Slides[0];

    // 加载图像并将其添加到演示文稿的图像集合中
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 添加一个与图片等高宽的图片框
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


{{% alert color="primary" %}}

Aspose 最近开发了一个 [free Collage Maker](https://products.aspose.app/slides/collage)。如果您需要 [merge JPG/JPEG](https://products.aspose.app/slides/collage/jpg) 或 PNG 图像，[create grids from photos](https://products.aspose.app/slides/collage/photo-grid)，可以使用此服务。 

{{% /alert %}}

## **将图像添加为链接**

为避免演示文稿体积过大，您可以通过链接方式添加图像（或视频），而不是将文件直接嵌入演示文稿。下面的 C# 代码演示如何在占位符中添加图像和视频：
```c#
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

下面的 C# 代码演示如何裁剪幻灯片上已有的图像：
```c#
using (Presentation presentation = new Presentation())
{
    // 创建一个新的图像对象
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 向幻灯片添加一个 PictureFrame
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

如果您想删除框中图像的裁剪区域，可以使用 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法。如果不需要裁剪，该方法会返回原始图像。

下面的 C# 代码演示该操作：
```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 从第一张幻灯片获取 PictureFrame
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // 删除 PictureFrame 图像的裁剪区域并返回裁剪后的图像
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // 保存结果
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```


{{% alert title="NOTE" color="warning" %}} 

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法会将裁剪后的图像添加到演示文稿的图像集合中。如果该图像仅在处理后的 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) 中使用，此设置可以减小演示文稿的体积。否则，生成的演示文稿中的图像数量会增加。

此方法在裁剪操作中将 WMF/EMF 元文件转换为光栅 PNG 图像。 

{{% /alert %}}

## **压缩图像**

您可以使用 [`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/) 方法压缩演示文稿中的图片。该方法通过根据形状大小和指定分辨率降低图像尺寸来压缩图像，并可选择删除裁剪区域。

它调整图片的大小和分辨率方式类似于 PowerPoint 的 **图片格式 → 压缩图片 → 分辨率** 功能。

以下 C# 示例演示如何通过指定目标分辨率并可选删除裁剪区域来压缩演示文稿中的图像：
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 从幻灯片获取 PictureFrame
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // 使用 150 DPI（网页分辨率）目标分辨率压缩图像并删除裁剪区域
    bool result = picFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // 检查压缩结果
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }
}
```


或直接使用自定义 DPI 值：
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // 压缩图像至 150 DPI（网页分辨率），并删除裁剪区域
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```


{{% alert title="NOTE" color="warning" %}} 

该方法根据形状大小和提供的 DPI 将图像转换为更低的分辨率。裁剪区域也可被删除以优化文件大小。  
如果图像是 WMF/EMF 元文件或 SVG，则不会进行压缩。JPEG 的质量会根据分辨率保持或略有降低，方式与 PowerPoint 处理高分辨率 JPEG 时相同。

{{% /alert %}}

## **锁定纵横比**

如果您希望包含图像的形状在更改图像尺寸后仍保持其纵横比，可使用 [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) 属性来设置 *锁定纵横比*。

下面的 C# 代码演示如何锁定形状的纵横比：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // 将形状设置为在调整大小时保持纵横比
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```


{{% alert title="NOTE" color="warning" %}} 

*锁定纵横比* 设置仅保留形状的纵横比，而不影响其包含的图像。

{{% /alert %}}

## **使用 StretchOff 属性**

使用 [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)、[StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop)、[StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) 和 [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) 属性，从 [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat) 类中，您可以指定填充矩形。

当对图像指定拉伸时，源矩形会缩放以适应指定的填充矩形。填充矩形的每条边由相对于形状边界框相应边缘的百分比偏移定义。正百分比表示向内收缩，负百分比表示向外扩展。

1. 创建 [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) 类的实例。 
2. 通过索引获取幻灯片的引用。 
3. 添加一个矩形 `AutoShape`。 
4. 创建图像。 
5. 设置形状的填充类型。 
6. 设置形状的图片填充模式。 
7. 添加已设置的图像以填充形状。 
8. 指定图像相对于形状边界框相应边缘的偏移量。 
9. 将修改后的演示文稿写入为 PPTX 文件。

下面的 C# 代码演示使用 StretchOff 属性的过程：
```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // 将图像在形状主体中从每一侧拉伸
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**如何了解 PictureFrame 支持哪些图像格式？**

Aspose.Slides 通过分配给 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) 的图像对象，支持光栅图像（PNG、JPEG、BMP、GIF 等）和矢量图像（例如 SVG）。支持的格式列表通常与幻灯片和图像转换引擎的功能相重叠。

**添加大量大图像会如何影响 PPTX 的大小和性能？**

嵌入大图像会增加文件大小和内存使用；使用链接方式添加图像可以减小演示文稿体积，但需确保外部文件仍可访问。Aspose.Slides 提供通过链接方式添加图像以降低文件体积的功能。

**如何防止图像对象意外移动/调整大小？**

对 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/)（例如禁用移动或缩放）。锁定机制在单独的 [protection article](/slides/zh/net/applying-protection-to-presentation/) 中有说明，适用于包括 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) 在内的多种形状类型。

**将演示文稿导出为 PDF/图像时，SVG 向量的保真度是否得到保持？**

Aspose.Slides 允许从 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) 中提取 SVG 作为原始矢量。导出为 PDF（/slides/net/convert-powerpoint-to-pdf/）或光栅格式（/slides/net/convert-powerpoint-to-png/）时，结果可能会根据导出设置被光栅化；提取行为确认了原始 SVG 仍以矢量形式保存。