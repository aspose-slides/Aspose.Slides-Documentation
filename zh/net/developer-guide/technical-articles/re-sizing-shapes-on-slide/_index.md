---
title: 在演示文稿幻灯片上调整形状大小
type: docs
weight: 130
url: /zh/net/re-sizing-shapes-on-slide/
keywords:
- 调整形状
- 更改形状大小
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 轻松调整 PowerPoint 和 OpenDocument 幻灯片上的形状大小——自动化幻灯片布局调整并提升工作效率。"
---

## **概述**

Aspose.Slides for .NET 的客户最常问的问题之一是如何调整形状大小，以便在幻灯片尺寸更改时，数据不会被截断。本文简短的技术文章展示了如何做到这一点。

## **调整形状大小**

为防止幻灯片尺寸更改时形状错位，需要更新每个形状的位置和尺寸，使其符合新的幻灯片布局。
```c#
// 加载演示文稿文件。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 获取原始幻灯片尺寸。
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // 在不缩放现有形状的情况下更改幻灯片尺寸。
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // 获取新的幻灯片尺寸。
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // 在每张幻灯片上调整形状大小并重新定位。
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // 缩放形状尺寸。
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // 缩放形状位置。
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}
如果幻灯片包含表格，上面的代码将无法正常工作。在这种情况下，必须调整表格中每个单元格的大小。
{{% /alert %}}

在你的代码中使用以下示例来调整包含表格的幻灯片。对于表格，设置宽度或高度属于特殊情况：必须调整各行的高度和各列的宽度，以改变表格的整体大小。
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 获取原始幻灯片尺寸。
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // 在不缩放现有形状的情况下更改幻灯片尺寸。
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // 获取新的幻灯片尺寸。
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // 缩放形状尺寸。
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // 缩放形状位置。
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // 缩放形状尺寸。
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // 缩放形状位置。
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // 缩放形状尺寸。
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // 缩放形状位置。
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**为什么在调整幻灯片大小后形状会失真或被截断？**

在调整幻灯片大小时，形状会保留原始的位置和尺寸，除非显式更改比例。这可能导致内容被裁剪或形状错位。

**提供的代码适用于所有形状类型吗？**

基本示例适用于大多数形状类型（文本框、图像、图表等）。但对于表格，需要单独处理行和列，因为表格的高宽取决于各个单元格的尺寸。

**在调整幻灯片大小时，如何调整表格？**

需要遍历表格的所有行和列，并按比例调整它们的高度和宽度，如第二个代码示例所示。

**此调整是否适用于母版幻灯片和布局幻灯片？**

是的，但还应遍历 [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) 和 [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) 并对它们的形状应用相同的缩放逻辑，以确保整个演示文稿的一致性。

**我可以在调整大小的同时更改幻灯片的方向（纵向/横向）吗？**

可以。可以设置 [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/) 来更改方向。请确保相应地设置缩放逻辑以保持布局。

**我可以设置的幻灯片尺寸是否有限制？**

Aspose.Slides 支持自定义尺寸，但极大的尺寸可能会影响性能或与某些 PowerPoint 版本的兼容性。

**如何防止固定宽高比的形状变形？**

可以在缩放前检查形状的 `AspectRatioLocked` 属性。如果已锁定，请按比例调整宽度或高度，而不是单独缩放它们。