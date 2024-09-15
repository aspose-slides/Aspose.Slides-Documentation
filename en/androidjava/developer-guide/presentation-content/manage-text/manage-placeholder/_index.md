---
title: Manage Placeholder
type: docs
weight: 10
url: /androidjava/manage-placeholder/
description: Change Text in a Placeholder in PowerPoint Slides using Java. Set Prompt Text in a Placeholder in PowerPoint Slides using Java.
---

## **Change Text in Placeholder**
Using [Aspose.Slides for Android via Java](/slides/androidjava/), you can find and modify placeholders on slides in presentations. Aspose.Slides allows you to make changes to the text in a placeholder.

**Prerequisite**: You need a presentation that contains a placeholder. You can create such a presentation in the standard Microsoft PowerPoint app.

This is how you use Aspose.Slides to replace the text in the placeholder in that presentation:

1. Instantiate the [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class. and pass the presentation as an argument.
2. Get a slide reference through its index.
3. Iterate through the shapes to find the placeholder.
4. Typecast the placeholder shape to an [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) and change the text using the [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) associated with the [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. Save the modified presentation.

This Java code shows how to change the text in a placeholder:

```java
// Instantiates a Presentation class
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Accesses the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Iterates through shapes to find the placeholder
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Changes the text in each placeholder
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Saves the presentation to disk
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Prompt Text in Placeholder**
Standard and pre-built layouts contain placeholder prompt texts such as ***Click to add a title*** or ***Click to add a subtitle***. Using Aspose.Slides, you can insert your preferred prompt texts into placeholder layouts.

This Java code shows you how to set the prompt text in a placeholder:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Iterates through the slide
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint displays "Click to add title" 
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Adds subtitle
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Placeholder Image Transparency**

Aspose.Slides allows you to set the transparency of the background image in a text placeholder. By adjusting the transparency of the picture in such a frame, you can make the text or the image stand out (depending on the text's and picture's colors).

This Java code shows you how to set the transparency for a picture background (inside a shape):

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

