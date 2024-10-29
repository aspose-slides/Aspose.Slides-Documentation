---
title: 图片框
type: docs
weight: 10
url: /zh/net/picture-frame/
keywords: 
- 添加图片框
- 创建图片框
- 添加图片
- 创建图片
- 提取图片
- StretchOff 属性
- 图片框格式
- 图片框属性
- PowerPoint 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中向 PowerPoint 演示文稿添加图片框"
---

图片框是包含图像的形状——它就像框中的一张图片。

您可以通过图片框向幻灯片添加图像。通过这种方式，您可以通过格式化图片框来格式化图像。

{{% alert  title="提示" color="primary" %}} 

Aspose 提供免费的转换器——[JPEG 到 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt)和[PNG 到 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——允许人们快速从图像创建演示文稿。

{{% /alert %}} 

## **创建图片框**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 通过其索引获取幻灯片的引用。
3. 通过将图像添加到与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection)中来创建 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，该对象将用于填充形状。
4. 指定图像的宽度和高度。
5. 通过与引用的幻灯片关联的形状对象暴露的 `AddPictureFrame` 方法，根据图像的宽度和高度创建 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe)。
6. 将图片框（包含图片）添加到幻灯片中。
7. 将修改后的演示文稿写入 PPTX 文件。

以下 C# 代码展示了如何创建一个图片框：

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

    // 添加与高度和宽度相同的图片框
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 对图片框应用一些格式
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // 将演示文稿写入 PPTX 文件
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

图片框允许您迅速基于图像创建演示文稿幻灯片。当您将图片框与 Aspose.Slides 的保存选项结合使用时，您可以操作输入/输出操作以将图像从一种格式转换为另一种格式。您可能想查看这些页面：转换 [图像到 JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/)；转换 [JPG 到图像](https://products.aspose.com/slides/net/conversion/jpg-to-image/)；转换 [JPG 到 PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)，转换 [PNG 到 JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/)；转换 [PNG 到 SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)，转换 [SVG 到 PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/)。

{{% /alert %}}

## **通过相对缩放创建图片框**

通过改变图像的相对缩放，您可以创建一个更复杂的图片框。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 将图像添加到演示文稿图像集合中。
4. 通过将图像添加到与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) 中创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，该对象将用于填充形状。
5. 在图片框中指定图像的相对宽度和高度。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 C# 代码展示了如何通过相对缩放创建图片框：

```c#
// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation presentation = new Presentation())
{
    // 加载图像并将其添加到演示文稿图像集合中
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 将图片框添加到幻灯片
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 设置相对缩放宽度和高度
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // 保存演示文稿
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **从图片框提取图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) 对象中提取图像，并将其保存为 PNG、JPG 和其他格式。下面的代码示例演示了如何从文档 "sample.pptx" 中提取图像并将其保存为 PNG 格式。

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

## **获取图像的透明度**

Aspose.Slides 允许您获取图像的透明度。以下 C# 代码演示了此操作：

```c#
using (var presentation = new Presentation(folderPath + "Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("图片透明度: " + transparencyValue);
        }
    }
}
```

## **图片框格式**

Aspose.Slides 提供了许多可以应用于图片框的格式选项。使用这些选项，您可以更改图片框以使其符合特定要求。

1. 创建一个 [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 通过将图像添加到与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) 中创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，该对象将用于填充形状。
4. 指定图像的宽度和高度。
5. 通过与引用的幻灯片关联的 [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) 对象暴露的 [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) 方法，根据图像的宽度和高度创建一个 `PictureFrame`。
6. 将图片框（包含图片）添加到幻灯片中。
7. 设置图片框的线条颜色。
8. 设置图片框的线条宽度。
9. 通过给定正值或负值旋转图片框。
   * 正值使图像顺时针旋转。
   * 负值使图像逆时针旋转。
10. 将图片框（包含图片）添加到幻灯片中。
11. 将修改后的演示文稿写入 PPTX 文件。

以下 C# 代码演示了图片框格式处理过程：

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

    // 添加与图片的高度和宽度相等的图片框
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 对图片框应用一些格式
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // 将演示文稿写入 PPTX 文件
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose 最近开发了一个 [免费的拼贴制作工具](https://products.aspose.app/slides/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/collage/jpg) 或 PNG 图像，或者 [从照片创建网格](https://products.aspose.app/slides/collage/photo-grid)，您可以使用此服务。

{{% /alert %}}

## **作为链接添加图像**

为避免演示文稿大小过大，您可以通过链接添加图像（或视频），而不是直接将文件嵌入到演示文稿中。以下 C# 代码展示了如何向占位符中添加图像和视频：

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

以下 C# 代码展示了如何裁剪幻灯片上现有的图像：

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

## 删除图片的裁剪区域

如果您想要删除位于框中的图像的裁剪区域，您可以使用 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法。此方法返回裁剪后的图像，或者在裁剪不必要时返回原始图像。

以下 C# 代码演示了此操作：

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 获取第一张幻灯片的 PictureFrame
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // 删除 PictureFrame 图像的裁剪区域并返回裁剪后的图像
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // 保存结果
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="注意" color="warning" %}} 

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法将裁剪后的图像添加到演示文稿图像集合中。如果图像仅在处理的 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) 中使用，此设置可以减少演示文稿的大小。否则，生成的演示文稿中的图像数量将增加。

该方法在裁剪操作中将 WMF/EMF 元文件转换为栅格 PNG 图像。

{{% /alert %}}

## **锁定纵横比**

如果您希望包含图像的形状在更改图像尺寸后保持其纵横比，可以使用 [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) 属性设置 *锁定纵横比* 设置。

以下 C# 代码展示了如何锁定形状的纵横比：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // 设置形状在调整大小时保持纵横比
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="注意" color="warning" %}} 

这个 *锁定纵横比* 设置仅保留形状的纵横比，而不保留其包含的图像的纵横比。

{{% /alert %}}

## **使用 StretchOff 属性**

通过使用 [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)、[StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop)、[StretchOffsetRight,](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) 和 [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) 属性，您可以指定填充矩形。

当为图像指定拉伸时，源矩形会按比例缩放以适应指定的填充矩形。填充矩形的每条边由形状边界框相应边缘的百分比偏移量定义。正百分比指定内缩，而负百分比指定外缩。

1. 创建一个 [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加一个矩形的 `AutoShape`。
4. 创建一张图像。
5. 设置形状的填充类型。
6. 设置形状的图片填充模式。
7. 添加一个图像以填充形状。
8. 指定图像从形状边框相应边缘的偏移量。
9. 将修改后的演示文稿写入 PPTX 文件。

以下 C# 代码演示了使用 StretchOff 属性的过程：

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // 设置从形状主体各边拉伸的图像
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```