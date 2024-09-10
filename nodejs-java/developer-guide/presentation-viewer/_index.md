---
title: Presentation Viewer
type: docs
weight: 50
url: /nodejs-java/presentation-viewer/
keywords: "PowerPoint PPT Viewer"
description: "PowerPoint PPT Viewer in Javascript"
---

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java is used to create presentation files, complete with slides. These slides can be viewed by opening presentations using Microsoft PowerPoint. But sometimes, developers may also need to view slides as images in their favorite image viewer or create their own presentation viewer. In such cases, Aspose.Slides for Node.js via Java lets you export an individual slide to an image. This article describes how to do it.

{{% /alert %}} 

## **Live Example**
You can try [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) free app to see what you can implement with Aspose.Slides API:

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **Generate SVG Image from Slide**
To generate an SVG image from any desired slide with Aspose.Slides for Node.js via Java, please follow the steps below:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
- Obtain the desired slide's reference by using its ID or index.
- Get the SVG image in a memory stream.
- Save the memory stream to file.

```javascript
    // Instantiate a Presentation class that represents the presentation file
    var pres = new  aspose.slides.Presentation("CreateSlidesSVGImage.pptx");
    try {
        // Access the first slide
        var sld = pres.getSlides().get_Item(0);
        // Create a memory stream object
        var svgStream = java.newInstanceSync("java.io.FileOutputStream", "Aspose_out.svg");
        // Generate SVG image of slide and save in memory stream
        sld.writeAsSvg(svgStream);
        svgStream.close();
    } catch (e) {
    } finally {
        pres.dispose();
    }
```

## **Generate SVG with Custom Shape IDS**
Aspose.Slides for Node.js via Java can be used to generate [SVG](https://docs.fileformat.com/page-description-language/svg/) from slide with custom shape ID. For that, use ID property from [ISvgShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ISvgShape), which represents custom ID of shapes in generated SVG. CustomSvgShapeFormattingController can be used to set shape ID.

```javascript
    var pres = new  aspose.slides.Presentation("pptxFileName.pptx");
    try {
        var stream = java.newInstanceSync("java.io.FileOutputStream", "Aspose_out.svg");
        try {
            var svgOptions = new  aspose.slides.SVGOptions();
            svgOptions.setShapeFormattingController(java.newInstanceSync("CustomSvgShapeFormattingController"));
            pres.getSlides().get_Item(0).writeAsSvg(stream, svgOptions);
        } finally {
            if (stream != null) {
                stream.close();
            }
        }
    } catch (e) {
    } finally {
        pres.dispose();
    }
```
```javascript
    class CustomSvgShapeFormattingController implements aspose.slides.ISvgShapeFormattingController {
        private var m_shapeIndex;
        public CustomSvgShapeFormattingController() {
            m_shapeIndex = 0;
        }
        public CustomSvgShapeFormattingController(int shapeStartIndex) {
            m_shapeIndex = shapeStartIndex;
        }
        public void formatShape(aspose.slides.ISvgShape svgShape, aspose.slides.IShape shape) {
            svgShape.setId(java.callStaticMethodSync("java.lang.String", "format", "shape-%d", m_shapeIndex++));
        }
    }
```

## **Create Slides Thumbnail Image**
Aspose.Slides for Node.js via Java help you generate thumbnail images of the slides. To generate the thumbnail of any desired slide using Aspose.Slides for Node.js via Java:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

```javascript
    // Instantiate a Presentation class that represents the presentation file
    var pres = new  aspose.slides.Presentation("ThumbnailFromSlide.pptx");
    try {
        // Access the first slide
        var sld = pres.getSlides().get_Item(0);
        // Create a full scale image
        var slideImage = sld.getImage(1.0, 1.0);
        // Save the image to disk in JPEG format
        try {
            slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    } finally {
        pres.dispose();
    }
```

## **Create Thumbnail with User Defined Dimensions**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

```javascript
    // Instantiate a Presentation class that represents the presentation file
    var pres = new  aspose.slides.Presentation("ThumbnailWithUserDefinedDimensions.pptx");
    try {
        // Access the first slide
        var sld = pres.getSlides().get_Item(0);
        // User defined dimension
        var desiredX = 1200;
        var desiredY = 800;
        // Getting scaled value  of X and Y
        var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
        var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
        // Create a full scale image
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Save the image to disk in JPEG format
        try {
            slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    } finally {
        pres.dispose();
    }
```

## **Create Thumbnail from Slide in Notes Slides View**
To generate the thumbnail of any desired slide in Notes Slide View using Aspose.Slides for Node.js via Java:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale in Notes Slide view.
1. Save the thumbnail image in any desired image format.

The code snippet below produces a thumbnail of the first slide of a presentation in Notes Slide View.

```javascript
    // Instantiate a Presentation class that represents the presentation file
    var pres = new  aspose.slides.Presentation("ThumbnailWithUserDefinedDimensions.pptx");
    try {
        // Access the first slide
        var sld = pres.getSlides().get_Item(0);
        // User defined dimension
        var desiredX = 1200;
        var desiredY = 800;
        // Getting scaled value  of X and Y
        var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
        var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
        var opts = new  aspose.slides.RenderingOptions();
        opts.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
        // Create a full scale image
        var slideImage = sld.getImage(opts, ScaleX, ScaleY);
        // Save the image to disk in JPEG format
        try {
            slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    } finally {
        pres.dispose();
    }
```
