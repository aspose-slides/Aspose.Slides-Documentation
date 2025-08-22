---
title: Resize Shapes on Presentation Slides
type: docs
weight: 130
url: /net/re-sizing-shapes-on-slide/
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

One of the most common questions from Aspose.Slides for .NET customers is how to resize shapes so that, when the slide size changes, the data isn’t cut off. This short technical article shows how to do that.

## **Resize Shapes**

To prevent shapes from becoming misaligned when the slide size changes, update each shape’s position and dimensions so they conform to the new slide layout.

```c#
// Load the presentation file.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Get the original slide size.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Change the slide size without scaling existing shapes.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Get the new slide size.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Resize and reposition shapes on every slide.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Scale the shape size.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Scale the shape position.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

If a slide contains a table, the code above will not work correctly. In that case, each cell in the table must be resized.

{{% /alert %}}

Use the following code on your end to resize slides that contain tables. For tables, setting the width or height is a special case: you must adjust individual row heights and column widths to change the table’s overall size.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Get the original slide size.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Change the slide size without scaling existing shapes.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Get the new slide size.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Scale the shape size.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Scale the shape position.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Scale the shape size.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Scale the shape position.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Scale the shape size.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Scale the shape position.
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

## **FAQ**

**Q: Why are shapes distorted or cut off after resizing a slide?**

When resizing a slide, shapes retain their original position and size unless the scale is explicitly changed. This can result in content being cropped or shapes being misaligned.

**Q: Does the provided code work for all shape types?**

The basic example works for most shape types (text boxes, images, charts, etc.). However, for tables, you need to handle rows and columns separately, since the height and width of a table are determined by the dimensions of individual cells.

**Q: How do I resize tables when resizing a slide?**

You need to loop through all the rows and columns of the table and resize their height and width proportionally, as shown in the second code example.

**Q: Will this resizing work for master slides and layout slides?**

Yes, but you should also loop through [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) and [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) and apply the same scaling logic to their shapes to ensure consistency across the presentation.

**Q: Can I change the orientation of a slide (portrait/landscape) along with the resizing?**

Yes. You can set [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/) to change the orientation. Make sure you set the scaling logic accordingly to preserve the layout.

**Q: Is there a limit to the slide size I can set?**

Aspose.Slides supports custom sizes, but very large sizes may affect performance or compatibility with some versions of PowerPoint.

**Q: How can I prevent fixed aspect ratio shapes from becoming distorted?**

You can check the `LockAspectRatio` property of the shape before scaling. If it is locked, adjust the width or height proportionally rather than scaling them individually.
