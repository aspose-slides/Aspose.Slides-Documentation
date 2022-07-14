---
title: Create Shape Thumbnails
type: docs
weight: 70
url: /net/create-shape-thumbnails/
keywords: "Shape thumbnail. PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Shape thumbnail in PowerPoint presentation in C# or .NET"
---

Aspose.Slides for .NET is used to create presentation files where each page is a slides. These slides can be viewed by opening the presentation files using Microsoft PowerPoint. But sometimes, developers may need to view the images of the shapes separately in an image viewer. In such cases, Aspose.Slides for .NET helps you generate thumbnail images of the slide shapes. How to use this feature is described in this article.
This article explains how to generate slide thumbnails in different ways:

- Generating a shape thumbnail inside a slide.
- Generating a shape thumbnail for a slide shape with user defined dimensions.
- Generating a shape thumbnail in the bounds of a shape's appearance.
- Generating a thumbnail of SmartArt child node.
## **Generate Shape Thumbnail from Slide**
To generate a shape thumbnail from any slide using Aspose.Slides for .NET:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the shape thumbnail image of the referenced slide on default scale.
1. Save the thumbnail image to any desired image format.

The example below generating shape thumbnail.

```c#
// Instantiate a Presentation class that represents the presentation file
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Create a full scale image
    using (Bitmap bitmap = presentation.Slides[0].Shapes[0].GetThumbnail())
    {
        // Save the image to disk in PNG format
        bitmap.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```


## **Generate User Defined Scaling Factor Thumbnail**
To generate the shape thumbnail of any slide shape using Aspose.Slides for .NET:

1. Create an instance of the `Presentation` class.
1. Obtain the reference of any slide using its ID or index.
1. Get the thumbnail image of the referenced slide with shape bounds.
1. Save the thumbnail image in any desired image format.

The example below generate a thumbnail with generating a thumbnail with user defined scaling factor.

```c#
// Instantiate a Presentation class that represents the presentation file
using (Presentation p = new Presentation("HelloWorld.pptx"))
{
    // Create a full scale image
    using (Bitmap bitmap = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Shape, 1, 1))
    {
        // Save the image to disk in PNG format
        bitmap.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```


## **Create Bounds Shape's Appearance Thumbnail**
This method for creating thumbnails of shapes allows developers to generate a thumbnail in the bounds of the shape's appearance. It takes into account all the shape effects. The generated shape thumbnail is restricted by the slide bounds. To generate a thumbnail of any slide shape in bound of its appearance, use following sample code:

1. Create an instance of the `Presentation` class.
1. Obtain the reference of any slide using its ID or index.
1. Get the thumbnail image of the referenced slide with shape bounds as appearance.
1. Save the thumbnail image in any desired image format.

The example below create a thumbnail with generating a thumbnail with user defined scaling factor.

```c#
// Instantiate a Presentation class that represents the presentation file
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Create a Appearance bound shape image
    using (Bitmap bitmap = presentation.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        // Save the image to disk in PNG format
        bitmap.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

