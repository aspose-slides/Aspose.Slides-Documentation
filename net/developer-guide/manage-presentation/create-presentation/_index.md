---
title: Create Presentation
type: docs
weight: 10
url: /net/create-presentation/
---

## **Create PowerPoint Presentation**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

1. Create an instance of Presentation class.
1. Obtain the reference of a slide by using its Index.
1. Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation())
{
    // Get the first slide
    ISlide slide = presentation.Slides[0];

    // Add an autoshape of type line
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

