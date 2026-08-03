---
title: Create Thumbnails of Presentation Shapes in C++
linktitle: Shape Thumbnails
type: docs
weight: 70
url: /cpp/shape-thumbnails/
keywords:
- shape thumbnail
- shape image
- render shape
- shape rendering
- visual bounds
- shape bounds
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Generate high-quality shape thumbnails from PowerPoint slides with Aspose.Slides for C++ – easily create and export presentation thumbnails."
---

## **Introduction**

Aspose.Slides is used to create presentation files where each page is a slides. These slides can be viewed by opening the presentation files using Microsoft PowerPoint. But sometimes, developers may need to view the images of the shapes separately in an image viewer. In such cases, Aspose.Slides helps you generate thumbnail images of the slide shapes. How to use this feature is described in this article.
This article explains how to generate slide thumbnails in different ways:

- Generating a shape thumbnail inside a slide.
- Generating a shape thumbnail for a slide shape with user defined dimensions.
- Generating a shape thumbnail in the bounds of a shape's appearance.

## **Generate a Shape Thumbnail from a Slide**
To generate a shape thumbnail from any slide using Aspose.Slides for C++:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the shape thumbnail image of the referenced slide on default scale.
1. Save the thumbnail image to any desired image format.

The example below generating shape thumbnail.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Generate a User-Defined Scaling Factor Thumbnail**
To generate the shape thumbnail of any slide shape using Aspose.Slides for C++:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the thumbnail image of the referenced slide with shape bounds.
1. Save the thumbnail image in any desired image format.

The example below generate a thumbnail with generating a thumbnail with user defined scaling factor.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Scaling along X and Y axes.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Create a Bounds-Based Shape Appearance Thumbnail**
This method for creating thumbnails of shapes allows developers to generate a thumbnail in the bounds of the shape's appearance. It takes into account all the shape effects. The generated shape thumbnail is restricted by the slide bounds. To generate a thumbnail of any slide shape in bound of its appearance, use following sample code:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the thumbnail image of the referenced slide with shape bounds as appearance.
1. Save the thumbnail image in any desired image format.

The example below create a thumbnail with generating a thumbnail with user defined scaling factor.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Scaling along X and Y axes.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Get the Actual Visual Bounds of a Shape**

The frame properties of [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)—`IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()`, and `IShape::get_Height()`—describe the rectangle stored in the presentation model. The content that is actually rendered can extend beyond that frame or occupy a different axis-aligned rectangle. Rotation, outlines, arrowheads, text layout and overflow, generated SmartArt geometry, and other rendering effects can all change the occupied area.

Use [Shape::GetVisualBounds](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getvisualbounds/) to calculate that occupied area without creating an image. The method returns a [RectangleF](https://reference.aspose.com/slides/cpp/system.drawing/rectanglef/) in slide coordinates. The returned rectangle is not clipped to the slide, so its coordinates can be negative when content extends beyond the slide origin.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getvisualbounds/) is not currently declared by the [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) interface. Therefore, keep the shape obtained from the slide's shape collection as an interface value and cast it only when calling the method.

The following example gets and compares the frame and visual bounds:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

The same [RectangleF](https://reference.aspose.com/slides/cpp/system.drawing/rectanglef/) can be used to align nearby shapes to its `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()`, or `RectangleF::get_Bottom()` edge; reserve enough space in a generated layout; or detect content outside a permitted region. Visual bounds are especially useful for SmartArt, text boxes, arrows, pictures, rotated shapes, and group shapes, where the stored frame may not represent the full rendered result.

Use [Shape::GetVisualBounds](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getvisualbounds/) when you need coordinates for layout or validation and do not need a bitmap. Use [IShape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getimage/) when you need to render the shape. With [ShapeThumbnailBounds](https://reference.aspose.com/slides/cpp/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` sizes the image from the shape bounds, including outline settings, while `ShapeThumbnailBounds::Appearance` sizes it from the shape's appearance and restricts the result to the slide bounds. In contrast, [Shape::GetVisualBounds](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getvisualbounds/) returns only the calculated rectangle and does not clip it to the slide.

## **FAQ**

**What image formats can be used when saving shape thumbnails?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/), and others. Shapes can also be [exported as vector SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) by saving the shape’s content as SVG.

**What is the difference between Shape and Appearance bounds when rendering a thumbnail?**

`Shape` uses the shape’s geometry; `Appearance` takes [visual effects](/slides/cpp/shape-effect/) (shadows, glows, etc.) into account.

**What happens if a shape is marked as hidden? Will it still render as a thumbnail?**

A hidden shape remains part of the model and can be rendered; the hidden flag affects slideshow display but does not prevent generating the shape’s image.

**Are group shapes, charts, SmartArt, and other complex objects supported?**

Yes. Any object represented as [Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/) (including [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), and [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)) can be saved as a thumbnail or as SVG.

**Do system-installed fonts affect the quality of thumbnails for text shapes?**

Yes. You should [provide the required fonts](/slides/cpp/custom-font/) (or [configure font substitutions](/slides/cpp/font-substitution/)) to avoid unwanted fallbacks and text reflow.
