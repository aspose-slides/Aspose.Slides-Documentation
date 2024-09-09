---
title: Create PowerPoint Presentation using Java
linktitle: Create Presentation
type: docs
weight: 10
url: /java/create-presentation/
keywords: create ppt java, create ppt presentation, create pptx java
description: Learn how to create PowerPoint Presentations e.g. PPT, PPTX using Java from scratch.
---

## **Create PowerPoint Presentation**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

1. Create an instance of Presentation class.
1. Obtain the reference of a slide by using its Index.
1. Add an AutoShape of Line type using addAutoShape method exposed by Shapes object.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

```javascript
    // Instantiate a Presentation object that represents a presentation file
    var pres = new  aspose.slides.Presentation();
    try {
        // Get the first slide
        var slide = pres.getSlides().get_Item(0);
        // Add an autoshape of type line
        slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
        pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
