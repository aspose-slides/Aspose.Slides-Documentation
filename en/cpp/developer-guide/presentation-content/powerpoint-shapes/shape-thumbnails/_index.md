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
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Generate high-quality shape thumbnails from PowerPoint slides with Aspose.Slides for C++ – easily create and export presentation thumbnails."
---


## **Create Shape Thumbnail**
Aspose.Slides for C++ is used to create presentation files where each page is a slides. These slides can be viewed by opening the presentation files using Microsoft PowerPoint. But sometimes, developers may need to view the images of the shapes separately in an image viewer. In such cases, Aspose.Slides for C++ helps you generate thumbnail images of the slide shapes. How to use this feature is described in this article.
This article explains how to generate slide thumbnails in different ways:

- Generating a shape thumbnail inside a slide.
- Generating a shape thumbnail for a slide shape with user defined dimensions.
- Generating a shape thumbnail in the bounds of a shape's appearance.
- Generating a thumbnail of SmartArt child node.

## **Generate Shape Thumbnail from Slide**
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


## **Generate User Defined Scaling Factor Thumbnail**
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

## **Create Bounds Shape's Appearance Thumbnail**
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
