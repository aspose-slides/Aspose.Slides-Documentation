---
title: 图片
type: docs
weight: 50
url: /zh/net/examples/elements/picture/
keywords:
- 图片 示例
- 图片 框
- 添加 图片
- 访问 图片
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中处理图片：插入、替换、裁剪、压缩、调整透明度和效果、填充形状，并导出为 PPT、PPTX 和 ODP。"
---

展示如何使用 **Aspose.Slides for .NET** 将内存中的图像插入并访问图片。下面的示例创建一个内存中的图像，将其放置在幻灯片上，然后检索它。

## Add a Picture

此代码生成一个小位图，将其转换为流，并将其作为图片框插入到第一张幻灯片上。
```csharp
public static void Add_Picture()
{
    using var pres = new Presentation();

    // 创建一个简单的内存图像
    using var bmp = new Bitmap(width: 100, height: 100);
    using (var g = Graphics.FromImage(bmp))
    {
        g.Clear(Color.LightGreen);
    }

    // 将 Bitmap 转换为 MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // 将图像添加到演示文稿
    var ppImage = pres.Images.AddImage(imageStream);

    // 在第一页幻灯片上插入显示图像的图片框
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bmp.Width, height: bmp.Height, ppImage);

    pres.Save(@"c:\_tmp\xxx.pptx", SaveFormat.Pptx);
}
```


## Access a Picture

此示例确保幻灯片包含图片框，然后访问它找到的第一个图片框。
```csharp
public static void Access_Picture()
{
    using var pres = new Presentation();

    // 确保至少有一个图片框可供使用
    using var bmp = new Bitmap(40, 40);

    // 将 Bitmap 转换为 MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // 将图像添加到演示文稿
    var ppImage = pres.Images.AddImage(imageStream);
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, ppImage);

    // 访问幻灯片上的第一个图片框
    var pictureFrame = pres.Slides[0].Shapes.OfType<PictureFrame>().First();
}
```
