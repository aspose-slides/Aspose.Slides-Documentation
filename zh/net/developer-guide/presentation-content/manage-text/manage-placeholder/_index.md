---
title: 管理占位符
type: docs
weight: 10
url: /zh/net/manage-placeholder/
keywords: "占位符, 占位符文本, 提示文本, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中更改 PowerPoint 演示文稿中的占位符文本和提示文本"
---

## **在占位符中更改文本**
使用 [Aspose.Slides for .NET](/slides/zh/net/)，您可以在演示文稿的幻灯片上查找和修改占位符。Aspose.Slides 允许您更改占位符中的文本。

**前提条件**：您需要一个包含占位符的演示文稿。您可以在标准的 Microsoft PowerPoint 应用中创建这样的演示文稿。

以下是您如何使用 Aspose.Slides 替换演示文稿中占位符的文本：

1. 实例化 [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类，并将演示文稿作为参数传递。
2. 通过索引获取幻灯片引用。
3. 迭代形状以找到占位符。
4. 将占位符形状强制转换为 [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)，并使用与 [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) 相关联的 [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/) 更改文本。
5. 保存修改后的演示文稿。

以下 C# 代码演示了如何更改占位符中的文本：

```c#
// 实例化一个 Presentation 类
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // 访问第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 迭代形状以查找占位符
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // 更改每个占位符中的文本
            ((IAutoShape)shp).TextFrame.Text = "这是一个占位符";
        }

    // 将演示文稿保存到磁盘
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **设置占位符中的提示文本**
标准和预建布局包含占位符提示文本，例如 ***单击添加标题*** 或 ***单击添加副标题***。使用 Aspose.Slides，您可以将首选提示文本插入到占位符布局中。

以下 C# 代码演示了如何设置占位符中的提示文本：

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // 迭代幻灯片
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint 显示 "单击添加标题"
            {
                text = "添加标题";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // 添加副标题
            {
                text = "添加副标题";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"占位符文本: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **设置占位符图像透明度**

Aspose.Slides 允许您设置文本占位符中背景图像的透明度。通过调整此框中图片的透明度，您可以使文本或图像更突出（具体取决于文本和图片的颜色）。

以下 C# 代码演示了如何设置图像背景的透明度（在形状内部）：

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```