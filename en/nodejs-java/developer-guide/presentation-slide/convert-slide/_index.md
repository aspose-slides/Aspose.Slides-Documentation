---
title: Convert Slide
type: docs
weight: 35
url: /nodejs-java/convert-slide/
keywords: "Convert slide to image, export slide as image, save slide as image, slide to image, slide to PNG, slide to JPEG, slide to Bitmap, Java, java, Aspose.Slides"
description: "Convert PowerPoint slide to image (Bitmap, PNG, or JPG) in Javascript"
---

Aspose.Slides for Node.js via Java allows you to convert slides (in presentations) to images. These are the supported image formats: BMP, PNG, JPG (JPEG), GIF, and others.

To convert a slide to an image, do this: 

1. First,
   * convert the slide to a Images first by using the [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-java.awt.Dimension-) method or

2. Second, set additional options for conversion and convertible slide objects through
   * the [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TiffOptions) class or
   * the [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/RenderingOptions) class.

## **About Bitmap and Other Image Formats**

In Java, a [Imagess](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images)  is an object that allows you to work with images defined by pixel data. You can use an instance of this class to save images in a wide range of formats (JPG, PNG, etc.).

{{% alert title="Info" color="info" %}}

Aspose recently developed an online [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter. 

{{% /alert %}}

## **Converting Slides to Bitmap and Saving the Images in PNG**

This Javascript code shows you how to convert the first slide of a presentation to a bitmap object and then how to then save the image in the PNG format:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Converts the first slide in the presentation to a Images object
    var slideImage = pres.getSlides().get_Item(0).getImage();
    // Saves the image in the PNG format
    try {
        // save the image on the disk.
        slideImage.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

This sample code shows you how to convert the first slide of a presentation to a bitmap object using the [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-java.awt.Dimension-) method:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Gets the presentation slide size
    var slideSize = java.newInstanceSync("java.awt.Dimension", slideSize.getWidth(), slideSize.getHeight());
    // Creates a Images with the slide size
    var slideImage = sld.getImage(new aspose.slides.RenderingOptions(), slideSize);
    try {
        // save the image on the disk.
        slideImage.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}} 

You can convert a slide to a Images object and then use the object directly somewhere. Or you can convert a slide to a Images and then save the image in JPEG or any other format you prefer.

{{% /alert %}}  

## **Converting Slides to Images with Custom Sizes**

You may need to get an image of a certain size. Using an overload from the [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-) method, you can convert a slide to an image with specific dimensions (length and width).

This sample code demonstrates the proposed conversion using the [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-java.awt.Dimension-) method in Java:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Converts the first slide in the presentation to a Bitmap with the specified size
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 1820, 1040));
    // Saves the image in the JPEG format
    try {
        // save the image on the disk.
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Converting Slides With Notes and Comments to Images**

Some slides contain notes and comments. 

Aspose.Slides provides two classs—[TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TiffOptions) and [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/RenderingOptions)—that allow you to control the rendering of presentation slides to images. Both classs house the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) class that allows you to add notes and comments on a slide when you are converting that slide to an image.

{{% alert title="Info" color="info" %}} 

With the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) class, you get to specify your preferred position for notes and comments in the resulting image.

{{% /alert %}} 

This Javascript code demonstrates the conversion process for a slide with notes and comments:

```javascript
var pres = new aspose.slides.Presentation("PresentationNotesComments.pptx");
try {
    // Creates the rendering options
    var options = new aspose.slides.RenderingOptions();
    // Sets the position of the notes on the page
    options.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    // Sets the position of the comments on the page
    options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);
    // Sets the width of the comment output area
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);
    // Sets the color for the comments area
    options.getNotesCommentsLayouting().setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    // Converts the first slide of the presentation to a Bitmap object
    var slideImage = pres.getSlides().get_Item(0).getImage(options, 2.0, 2.0);
    // Saves the image in the GIF format
    try {
        slideImage.save("Slide_Notes_Comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

This Javascript code demonstrates the conversion process for a slide with notes using the [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-java.awt.Dimension-) method:

```javascript
var pres = new aspose.slides.Presentation("PresentationNotes.pptx");
try {
    // Gets the presentation notes size
    var notesSize = pres.getNotesSize().getSize();
    // Creates the rendering options
    var options = new aspose.slides.RenderingOptions();
    // Sets the position of the notes
    options.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    // Creates a Images with the notes' size
    var slideImage = pres.getSlides().get_Item(0).getImage(options, notesSize);
    // Saves the image in PNG format
    try {
        // save the image on the disk.
        slideImage.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 

In any slide to image conversion process, the [NotesPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions#setNotesPosition-int-) property cannot be set to BottomFull (to specify the position for notes) because a note's text may be large, which means it might not fit into the specified image size.

{{% /alert %}} 

## **Converting Slides to Images Using ITiffOptions**

The [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TiffOptions) class gives you more control (in terms of parameters) over the resulting image. Using this class, you get to specify the size, resolution, color palette, and other parameters for the resulting image.

This Javascript code demonstrates a conversion process where ITiffOptions is used to output a black and white image with a 300dpi resolution and 2160 × 2800 size:

```javascript
var pres = new aspose.slides.Presentation("PresentationNotesComments.pptx");
try {
    // Gets a slide by its index
    var slide = pres.getSlides().get_Item(0);
    // Creates a TiffOptions object
    var options = new aspose.slides.TiffOptions();
    options.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));
    // Set the font used in case source font is not found
    options.setDefaultRegularFont("Arial Black");
    // Set the position of the notes on the page
    options.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    // Sets the pixel format (black and white)
    options.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);
    // Sets the resolution
    options.setDpiX(300);
    options.setDpiY(300);
    // Converts the slide to a Bitmap object
    var slideImage = slide.getImage(options);
    // Saves the image in TIFF format
    try {
        slideImage.save("PresentationNotesComments.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 

Tiff support is not guaranteed in versions earlier than JDK 9.

{{% /alert %}} 

## **Converting All Slides to Images**

Aspose.Slides allows you to convert all slides in a single presentation to images. Essentially, you get to convert the presentation (in its entirety) to images. 

This sample code shows you how to convert all slides in a presentation to images in Java:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Render presentation to images array slide by slide
    for (var i = 0; i < pres.getSlides().size(); i++) {
        // Control hidden slides (do not render hidden slides)
        if (pres.getSlides().get_Item(i).getHidden()) {
            continue;
        }
        // Convert slide to a Bitmap object
        var slideImage = pres.getSlides().get_Item(i).getImage(2.0, 2.0);
        // Save the image in PNG format
        try {
            slideImage.save(("Slide_" + i) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

