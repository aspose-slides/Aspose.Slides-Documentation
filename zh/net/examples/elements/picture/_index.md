---
title: 图片
type: docs
weight: 50
url: /zh/net/examples/elements/picture/
keywords:
- 图片
- 图片框
- 添加图片
- 访问图片
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中处理图片：插入、裁剪、压缩、重新着色，并使用 C# 示例导出 PPT、PPTX 和 ODP 演示文稿中的图像。"
---
本文演示如何使用 **Aspose.Slides for .NET** 从内存图像中插入和访问图片。下面的示例在内存中创建图像、将其放置在幻灯片上，然后检索该图像。

## **Add a Picture**
此代码生成一个小位图，将其转换为流，并将其作为图片框插入第一张幻灯片。

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 创建一个简单的内存图像。
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // 将位图转换为 MemoryStream。
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // 将图像添加到演示文稿中。
    var image = presentation.Images.AddImage(imageStream);

    // 在第一页幻灯片上插入显示该图像的图片框。
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Access a Picture**
此示例确保幻灯片包含图片框，然后访问找到的第一个图片框。

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 确保至少有一个图片框可供使用。
    using var bitmap = new Bitmap(40, 40);

    // 将位图转换为 MemoryStream。
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // 将图像添加到演示文稿中。
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // 访问幻灯片上的第一个图片框。
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```