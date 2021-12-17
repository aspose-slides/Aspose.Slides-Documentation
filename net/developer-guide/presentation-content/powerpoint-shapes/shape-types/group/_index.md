---
title: Group
type: docs
weight: 40
url: /net/group/
keywords: "Group shape, PowerPoint shape, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Add group shape to PowerPoint presentation in C# or .NET"
---

## **Add Group Shape**
Aspose.Slides support working with group shapes on slides. This feature helps developers support richer presentations. Aspose.Slides for .NET supports adding or accessing group shapes. It is possible to add shapes to an added group shape to populate it or access any property of group shape. To add a group shape to a slide using Aspose.Slides for .NET:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index
1. Add a group shape to the slide.
1. Add the shapes to the added group shape.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

```c#
// Instantiate Prseetation class 
using (Presentation pres = new Presentation())
{
    // Get the first slide 
    ISlide sld = pres.Slides[0];

    // Accessing the shape collection of slides 
    IShapeCollection slideShapes = sld.Shapes;

    // Adding a group shape to the slide 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Adding shapes inside added group shape 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Adding group shape frame 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Write the PPTX file to disk 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```



## **Access AltText Property**
This topic shows simple steps, complete with code examples, for adding a group shape and accessing AltText property of group shapes on slides. To access AltText of a group shape in a slide using Aspose.Slides for .NET:

1. Instantiate `Presentation` class that represents PPTX file.
1. Obtain the reference of a slide by using its Index.
1. Accessing the shape collection of slides.
1. Accessing the group shape.
1. Accessing the AltText property.

The example below accesses alternative text of group shape.

```c#
// Instantiate Presentation class that represents PPTX file
Presentation pres = new Presentation("AltText.pptx");

// Get the first slide
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Accessing the shape collection of slides
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Accessing the group shape.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Accessing the AltText property
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

