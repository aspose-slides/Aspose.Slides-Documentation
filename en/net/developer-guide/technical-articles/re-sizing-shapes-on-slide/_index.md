---
title: Resize Shapes on Presentation Slides in .NET
type: docs
weight: 130
url: /net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
keywords:
- resize shape
- change shape size
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Easily resize shapes on PowerPoint and OpenDocument slides with Aspose.Slides for .NET—automate slide layout adjustments and boost productivity."
---

## **Overview**

When you change a presentation's slide size, you may also need to resize and reposition its shapes to fit the new dimensions. This article shows how to scale shapes manually and how to handle tables on slides, masters, and layouts.

## **Resize Shapes**

To preserve each shape's relative position and size, multiply its horizontal coordinates and width by the ratio of the new slide width to the original width. Apply the corresponding height ratio to its vertical coordinates and height.

The first example loads a presentation whose slides contain no tables, changes the slide size to A4, and saves the result. It uses [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) with [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) so that the subsequent loop controls the scaling. The ratios are unitless; shape positions and dimensions are measured in points. Different width and height ratios can distort shapes, and changing a shape's dimensions does not scale its font sizes.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Calculate independent horizontal and vertical scale factors.
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

Tables require separate handling: scale their column widths and row heights instead of assigning the table's overall width and height. Row heights may remain larger than requested if the cell content requires more space.

{{% /alert %}}

The second example supports tables and processes shapes on masters and layouts as well as individual slides before saving the resized presentation. Its helper handles each [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) by scaling [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) and [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). It then scales the table's position without separately scaling its overall dimensions.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Calculate independent horizontal and vertical scale factors.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Resize shapes defined on masters and layouts as well as individual slides.
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
            // Table dimensions are controlled by column widths and row heights.
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

## **FAQ**

**Why are shapes distorted or cut off after resizing a slide?**

If you change the slide size without scaling the shapes, they keep their original positions and dimensions and may extend beyond the slide. Scaling width and height by different ratios can also distort shapes.

**Does the provided code work for all shape types?**

The first example changes shape bounds directly and is intended for slides without tables. The second example handles tables separately. Check the resulting layout, particularly text and tables, because these examples do not scale font sizes and table content can constrain row heights.

**How do I resize tables when resizing a slide?**

Scale column widths by the width ratio and minimum row heights by the height ratio, then scale the table's position, as shown in the second example.

**Will this resizing work for master slides and layout slides?**

Yes. The second example iterates through [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) and each master's [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) and applies the same resizing logic to their shapes.

**Can I change the orientation of a slide (portrait/landscape) along with the resizing?**

Yes. Set [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) after changing the slide size and before reading the target dimensions, so the scale factors reflect the final orientation.

**Is there a limit to the slide size I can set?**

You can specify custom slide dimensions with [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). The supported dimensions also depend on the presentation format and the application used to open the file.

**How can I prevent shapes with a fixed aspect ratio from becoming distorted?**

Use the same scale factor for width and height. To fit the original layout within the new slide dimensions, use the smaller of the width and height ratios for both dimensions and positions. This preserves proportions but may leave unused space along one edge.
