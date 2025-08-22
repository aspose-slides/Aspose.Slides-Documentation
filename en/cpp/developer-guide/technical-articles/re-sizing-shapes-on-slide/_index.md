---
title: Resize Shapes on Presentation Slides
type: docs
weight: 100
url: /cpp/re-sizing-shapes-on-slide/
keywords:
- resize shape
- change shape size
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Easily resize shapes on PowerPoint and OpenDocument slides with Aspose.Slides for C++—automate slide layout adjustments and boost productivity."
---

## **Overview**

One of the most common questions from Aspose.Slides for C++ customers is how to resize shapes so that, when the slide size changes, the data isn’t cut off. This short technical article shows how to do that.

## **Resize Shapes**

To prevent shapes from becoming misaligned when the slide size changes, update each shape’s position and dimensions so they conform to the new slide layout.

```cpp
// Load the presentation file.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Get the original slide size.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Change the slide size without scaling existing shapes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Get the new slide size.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Scale the shape size.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Scale the shape position.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 

If a slide contains a table, the code above will not work correctly. In that case, each cell in the table must be resized.

{{% /alert %}} 

Use the following code on your end to resize slides that contain tables. For tables, setting the width or height is a special case: you must adjust individual row heights and column widths to change the table’s overall size.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Get the original slide size.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Change the slide size without scaling existing shapes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Get the new slide size.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Scale the shape size.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Scale the shape position.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Scale the shape size.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Scale the shape position.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Scale the shape size.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Scale the shape position.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Q: Why are shapes distorted or cut off after resizing a slide?**

When resizing a slide, shapes retain their original position and size unless the scale is explicitly changed. This can result in content being cropped or shapes being misaligned.

**Q: Does the provided code work for all shape types?**

The basic example works for most shape types (text boxes, images, charts, etc.). However, for tables, you need to handle rows and columns separately, since the height and width of a table are determined by the dimensions of individual cells.

**Q: How do I resize tables when resizing a slide?**

You need to loop through all the rows and columns of the table and resize their height and width proportionally, as shown in the second code example.

**Q: Will this resizing work for master slides and layout slides?**

Yes, but you should also loop through [Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) and [Layout slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) and apply the same scaling logic to their shapes to ensure consistency across the presentation.

**Q: Can I change the orientation of a slide (portrait/landscape) along with the resizing?**

Yes. You can use [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/islidesize/set_orientation/) to change the orientation. Make sure you set the scaling logic accordingly to preserve the layout.

**Q: Is there a limit to the slide size I can set?**

Aspose.Slides supports custom sizes, but very large sizes may affect performance or compatibility with some versions of PowerPoint.

**Q: How can I prevent fixed aspect ratio shapes from becoming distorted?**

You can check the `LockAspectRatio` property of the shape before scaling. If it is locked, adjust the width or height proportionally rather than scaling them individually.
