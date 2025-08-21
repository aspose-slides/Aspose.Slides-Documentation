---
title: Get Warning Callbacks for Font Substitution
type: docs
weight: 90
url: /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- warning callback
- font substitution
- rendering process
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Learn to get warning callbacks for font substitution in Aspose.Slides for Java and display PowerPoint and OpenDocument presentations accurately."
---

## **Overview**

Aspose.Slides for Java allows you to receive warning callbacks for font substitution when a required font isn’t available on the machine during rendering. These callbacks help diagnose issues with missing or inaccessible fonts.

## **Enable Warning Callbacks**

Aspose.Slides for Java provides straightforward APIs for receiving warning callbacks when rendering presentation slides. Follow these steps to configure warning callbacks:

1. Create a custom callback class that implements the [IWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iwarningcallback/) interface to handle warnings.
1. Set the warning callback using option classes such as [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/htmloptions/), and others.
1. Load a presentation that uses a font not available on the target machine.
1. Generate a slide thumbnail or export the presentation to observe the effect.

**Custom Warning Callback Class:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// Example output:
//
// Font will be substituted from XYZ to {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Generate a Slide Thumbnail:**

```java
// Set up a warning callback to handle font-related warnings during slide rendering.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// Load the presentation from the specified file path.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Generate a thumbnail image for each slide in the presentation.
    for (ISlide slide : presentation.getSlides()) {
        // Get the slide thumbnail image using the specified rendering options.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**Export to PDF Format:**

```java
// Set up a warning callback to handle font-related warnings during PDF export.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// Load the presentation from the specified file path.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Export the presentation as PDF.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**Export to HTML Format:**

```java
// Set up a warning callback to handle font-related warnings during HTML export.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// Load the presentation from the specified file path.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Export the presentation in HTML format.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```
