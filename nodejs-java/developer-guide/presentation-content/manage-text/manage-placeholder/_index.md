---
title: Manage Placeholder
type: docs
weight: 10
url: /nodejs-java/manage-placeholder/
description: Change Text in a Placeholder in PowerPoint Slides using Java. Set Prompt Text in a Placeholder in PowerPoint Slides using Java.
---

## **Change Text in Placeholder**
Using [Aspose.Slides for Java](/slides/java/), you can find and modify placeholders on slides in presentations. Aspose.Slides allows you to make changes to the text in a placeholder.

**Prerequisite**: You need a presentation that contains a placeholder. You can create such a presentation in the standard Microsoft PowerPoint app.

This is how you use Aspose.Slides to replace the text in the placeholder in that presentation:

1. Instantiate the [`Presentation`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class. and pass the presentation as an argument.
2. Get a slide reference through its index.
3. Iterate through the shapes to find the placeholder.
4. Typecast the placeholder shape to an [`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) and change the text using the [`TextFrame`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) associated with the [`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Save the modified presentation.

This Java code shows how to change the text in a placeholder:

```javascript
    // Instantiates a Presentation class
    var pres = new  aspose.slides.Presentation("ReplacingText.pptx");
    try {
        // Accesses the first slide
        var sld = pres.getSlides().get_Item(0);
        // Iterates through shapes to find the placeholder
        sld.getShapes().forEach(function(shp) {
            if (shp.getPlaceholder() != null) {
                // Changes the text in each placeholder
                shp.getTextFrame().setText("This is Placeholder");
            }
        });
        // Saves the presentation to disk
        pres.save("output_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Set Prompt Text in Placeholder**
Standard and pre-built layouts contain placeholder prompt texts such as ***Click to add a title*** or ***Click to add a subtitle***. Using Aspose.Slides, you can insert your preferred prompt texts into placeholder layouts.

This Java code shows you how to set the prompt text in a placeholder:

```javascript
    var pres = new  aspose.slides.Presentation("Presentation.pptx");
    try {
        var slide = pres.getSlides().get_Item(0);
        // Iterates through the slide
        slide.getSlide().getShapes().forEach(function(shape) {
            if ((shape.getPlaceholder() != null) && (shape instanceof aspose.slides.AutoShape)) {
                var text = "";
                // PowerPoint displays "Click to add title"
                if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                    text = "Add Title";
                } else // Adds subtitle
                if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                    text = "Add Subtitle";
                }
                shape.getTextFrame().setText(text);
                console.log("Placeholder with text: " + text);
            }
        });
        pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Set Placeholder Image Transparency**

Aspose.Slides allows you to set the transparency of the background image in a text placeholder. By adjusting the transparency of the picture in such a frame, you can make the text or the image stand out (depending on the text's and picture's colors).

This Java code shows you how to set the transparency for a picture background (inside a shape):

```javascript
    var presentation = new  aspose.slides.Presentation("example.pptx");
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
    for (var i = 0; i < operationCollection.size(); i++) {
        if (operationCollection.get_Item(i) instanceof aspose.slides.AlphaModulateFixed) {
            var alphaModulate = operationCollection.get_Item(i);
            var currentValue = 100 - alphaModulate.getAmount();
            console.log("Current transparency value: " + currentValue);
            var alphaValue = 40;
            alphaModulate.setAmount(100 - alphaValue);
        }
    }
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

