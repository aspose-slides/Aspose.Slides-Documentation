---
title: 在 C# 中创建演示查看器
linktitle: 演示查看器
type: docs
weight: 50
url: /zh/net/presentation-viewer/
keywords:
- 查看演示文稿
- 演示查看器
- 创建演示查看器
- 查看 PPT
- 查看 PPTX
- 查看 ODP
- PowerPoint
- OpenDocument
- C#
- Csharp
- Aspose.Slides for .NET
description: "了解如何使用 Aspose.Slides 在 .NET 中创建自定义演示查看器。无需 Microsoft PowerPoint 或其他办公软件，即可轻松显示 PowerPoint（PPTX、PPT）和 OpenDocument（ODP）文件。"
---

## **概述**

Aspose.Slides for .NET 用于创建包含幻灯片的演示文稿文件。这些幻灯片可以通过打开 Microsoft PowerPoint 等程序进行查看。但是，开发人员有时需要在首选的图像查看器中将幻灯片视为图像，或在自定义演示查看器中使用它们。在这种情况下，Aspose.Slides 允许将单个幻灯片导出为图像。本文说明了如何操作。

## **从幻灯片生成 SVG 图像**

使用 Aspose.Slides 从演示文稿幻灯片生成 SVG 图像，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 按索引获取幻灯片引用。
1. 打开文件流。
1. 将幻灯片保存为 SVG 图像到文件流。
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```


## **生成带自定义形状 ID 的 SVG**

Aspose.Slides 可用于从幻灯片生成带自定义形状 `ID` 的 [SVG](https://docs.fileformat.com/page-description-language/svg/)。为此，请使用 [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape) 接口的 Id 属性。`CustomSvgShapeFormattingController` 类可用于设置形状 ID。
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```


## **创建幻灯片缩略图**

Aspose.Slides 帮助您生成幻灯片的缩略图。要使用 Aspose.Slides 生成幻灯片缩略图，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 按索引获取幻灯片引用。
1. 按所需比例为引用的幻灯片创建缩略图。
1. 将缩略图保存为您首选的图像格式。
```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **创建具有用户定义尺寸的幻灯片缩略图**

要创建具有用户定义尺寸的幻灯片缩略图，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 按索引获取幻灯片引用。
1. 使用指定的尺寸生成引用幻灯片的缩略图。
1. 将缩略图保存为您首选的图像格式。
```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **创建带备注的幻灯片缩略图**

要使用 Aspose.Slides 生成带有演讲者备注的幻灯片缩略图，请按以下步骤操作：

1. 创建 [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) 类的实例。
1. 使用 `RenderingOptions.SlidesLayoutOptions` 属性设置演讲者备注的位置。
1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 按索引获取幻灯片引用。
1. 使用渲染选项生成引用幻灯片的缩略图。
1. 将缩略图保存为您首选的图像格式。
```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```


## **实时示例**

尝试使用免费应用程序 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) 查看您可以使用 Aspose.Slides API 实现的功能：

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **常见问题**

**我可以在 ASP.NET Web 应用程序中嵌入演示查看器吗？**

可以。您可以在服务器端使用 Aspose.Slides 将幻灯片渲染为图像或 HTML，并在浏览器中显示。可以使用 JavaScript 实现导航和缩放功能，以获得交互式体验。

**在自定义 .NET 查看器中显示幻灯片的最佳方式是什么？**

推荐的方法是将每张幻灯片渲染为图像（例如 PNG 或 SVG），或使用 Aspose.Slides 将其转换为 HTML，然后在图片框（桌面）或 HTML 容器（Web）中显示输出。

**我该如何处理包含大量幻灯片的演示文稿？**

对于大型文稿，建议采用惰性加载或按需渲染幻灯片的方式。这意味着仅在用户导航到相应幻灯片时生成其内容，从而降低内存占用和加载时间。