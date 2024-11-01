---
title: Group
type: docs
weight: 40
url: /nodejs-java/group/
---

## **Add Group Shape**
Aspose.Slides support working with group shapes on slides. This feature helps developers support richer presentations. Aspose.Slides for Node.js via Java supports adding or accessing group shapes. It is possible to add shapes to an added group shape to populate it or access any property of group shape. To add a group shape to a slide using Aspose.Slides for Node.js via Java:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Index
1. Add a group shape to the slide.
1. Add the shapes to the added group shape.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

```javascript
// Instantiate Presentation class
var pres = new aspose.slides.Presentation();
try {
    // Get the first slide
    var sld = pres.getSlides().get_Item(0);
    // Accessing the shape collection of slides
    var slideShapes = sld.getShapes();
    // Adding a group shape to the slide
    var groupShape = slideShapes.addGroupShape();
    // Adding shapes inside Added group shape
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Adding group shape frame
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Write the PPTX file to disk
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Access AltText Property**
This topic shows simple steps, complete with code examples, for adding a group shape and accessing AltText property of group shapes on slides. To access AltText of a group shape in a slide using Aspose.Slides for Node.js via Java:

1. Instantiate [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class that represents PPTX file.
1. Obtain the reference of a slide by using its Index.
1. Accessing the shape collection of slides.
1. Accessing the group shape.
1. Call the [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) property.

The example below accesses alternative text of group shape.

```javascript
// Instantiate Presentation class that represents PPTX file
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Get the first slide
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Accessing the shape collection of slides
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Accessing the group shape.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Accessing the AltText property
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
