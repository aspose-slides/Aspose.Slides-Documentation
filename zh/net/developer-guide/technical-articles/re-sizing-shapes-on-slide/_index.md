---
title: 在 .NET 中调整演示文稿幻灯片上的形状大小
type: docs
weight: 130
url: /zh/net/re-sizing-shapes-on-slide/
keywords:
- 调整形状大小
- 更改形状尺寸
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 轻松调整 PowerPoint 和 OpenDocument 幻灯片上的形状大小——自动化幻灯片布局调整，提高生产力。"
---

## **概述**

Aspose.Slides for .NET 客户最常问的问题之一是如何在幻灯片尺寸变化时调整形状大小，以避免数据被截断。本文简短技术文章展示了实现方法。

## **调整形状大小**

为了防止幻灯片尺寸变化后形状错位，需要更新每个形状的位置和尺寸，使其符合新的幻灯片布局。
```c#
// 加载演示文稿文件。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 获取原始幻灯片尺寸。
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // 更改幻灯片尺寸但不缩放现有形状。
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // 获取新的幻灯片尺寸。
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // 对每张幻灯片上的形状进行大小调整和重新定位。
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // 缩放形状大小。
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
如果幻灯片中包含表格，上述代码将无法正常工作。此时必须对表格中的每个单元格进行大小调整。
{{% /alert %}}

使用下面的代码来调整包含表格的幻灯片。对于表格，设置宽度或高度属于特殊情况：必须分别调整行高和列宽，以改变表格的整体尺寸。
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
            // 缩放形状大小。
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
                // 缩放形状大小。
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
            // 缩放形状大小。
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

在调整幻灯片大小时，除非显式更改比例，否则形状会保持原来的位置和尺寸，这可能导致内容被裁剪或形状错位。

**提供的代码适用于所有形状类型吗？**

基本示例适用于多数形状类型（文本框、图像、图表等）。但对于表格，需要单独处理行和列，因为表格的高度和宽度由各单元格的尺寸决定。

**在调整幻灯片大小时如何调整表格大小？**

需要遍历表格的所有行和列，并按比例调整它们的高度和宽度，正如第二段代码示例所示。

**此调整适用于母版幻灯片和布局幻灯片吗？**

是的，但还应遍历[母版]（https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/）和[布局幻灯片]（https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/），对它们的形状应用相同的缩放逻辑，以确保整个演示文稿的一致性。

**我可以在调整大小的同时更改幻灯片的方向（纵向/横向）吗？**

可以。可以设置[presentation.SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/)来更改方向。请相应地调整缩放逻辑，以保持布局不变。

**我可以设置的幻灯片尺寸有上限吗？**

Aspose.Slides 支持自定义尺寸，但极大的尺寸可能会影响性能或与某些 PowerPoint 版本的兼容性。

**如何防止固定宽高比的形状被拉伸失真？**

在缩放之前，可以检查形状的 `AspectRatioLocked` 属性。如果已锁定，则应按比例调整宽度或高度，而不是分别单独缩放。