---
title: 在 .NET 中调整演示文稿幻灯片上的形状大小
type: docs
weight: 130
url: /zh/net/resizing-shapes-on-slide/
aliases:
  - /zh/net/re-sizing-shapes-on-slide/
keywords:
- 调整形状
- 更改形状大小
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "轻松使用 Aspose.Slides for .NET 调整 PowerPoint 和 OpenDocument 幻灯片上的形状大小——自动化幻灯片布局调整并提升生产力。"
---
## **概述**

当您更改演示文稿的幻灯片尺寸时，可能还需要调整形状的大小并重新定位，以适应新的尺寸。本文展示了如何手动缩放形状以及如何处理幻灯片、母版和布局上的表格。

## **调整形状**

为了保持每个形状的相对位置和大小，将其水平坐标和宽度乘以新幻灯片宽度与原始宽度的比例。对其垂直坐标和高度应用相应的高度比例。

第一个示例加载一个幻灯片中不包含表格的演示文稿，将幻灯片尺寸更改为 A4，并保存结果。它使用 [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) 与 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) ，以便后续循环控制缩放。比例是无单位的；形状的位置和尺寸以点为单位。不同的宽度和高度比例会导致形状失真，并且更改形状的尺寸不会缩放其字体大小。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 计算独立的水平和垂直缩放因子。
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
表格需要单独处理：按列宽和行高进行缩放，而不是直接设置表格的整体宽度和高度。如果单元格内容需要更多空间，行高可能会保持大于请求的大小。
{{% /alert %}}

第二个示例支持表格，并在保存调整大小的演示文稿之前处理母版和布局以及单个幻灯片上的形状。它的辅助工具通过缩放每个 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 的 [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) 和 [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) 来处理表格。随后，它会在不单独缩放整体尺寸的情况下缩放表格的位置。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 计算独立的水平和垂直缩放因子。
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// 调整在母版、布局以及各个幻灯片上定义的形状大小。
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // 表格尺寸由列宽和行高控制。
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **常见问题**

**为什么在调整幻灯片大小后形状会失真或被截断？**
如果在更改幻灯片尺寸时未对形状进行缩放，它们会保持原始位置和尺寸，可能会超出幻灯片范围。使用不同的宽度和高度比例进行缩放也会导致形状失真。

**提供的代码适用于所有形状类型吗？**
第一个示例直接更改形状的边界，适用于没有表格的幻灯片。第二个示例单独处理表格。请检查生成的布局，特别是文本和表格，因为这些示例不缩放字体大小，并且表格内容可能会限制行高。

**在调整幻灯片大小时如何调整表格？**
按宽度比例缩放列宽，按高度比例缩放最小行高，然后如第二个示例所示缩放表格的位置。

**此调整大小方法对母版幻灯片和布局幻灯片也适用吗？**
是的。第二个示例遍历 [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) 以及每个母版的 [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/)，并对其形状应用相同的调整大小逻辑。

**我可以在调整大小的同时更改幻灯片的方向（纵向/横向）吗？**
可以。请在更改幻灯片尺寸后、读取目标尺寸之前设置 [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/)，以便缩放系数反映最终的方向。

**我可以设置的幻灯片尺寸是否有限制？**
您可以使用 [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) 指定自定义幻灯片尺寸。支持的尺寸还取决于演示文稿的格式以及用于打开文件的应用程序。

**如何防止具有固定宽高比的形状变形？**
对宽度和高度使用相同的缩放因子。若要使原始布局适配新的幻灯片尺寸，请对宽度和高度以及位置都使用宽高比例中较小的那个。这可以保持比例，但可能在某一边留下未使用的空间。