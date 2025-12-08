---
title: Create a Presentation Viewer in Java
linktitle: Presentation Viewer
type: docs
weight: 50
url: /java/presentation-viewer/
keywords: 
- view presentation
- presentation viewer
- create presentation viewer
- view PPT
- view PPTX
- view ODP
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Create a custom presentation viewer in Java using Aspose.Slides. Easily display PowerPoint and OpenDocument files without Microsoft PowerPoint."
---

Aspose.Slides for Java is used to create presentation files with slides. These slides can be viewed by opening presentations in Microsoft PowerPoint, for example. However, sometimes developers may need to view slides as images in their preferred image viewer or create their own presentation viewer. In such cases, Aspose.Slides allows you to export an individual slide as an image. This article describes how to do it.

## **Generate an SVG Image from a Slide**

To generate an SVG image from a presentation slide with Aspose.Slides, please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get the slide reference by its index.
1. Open a file stream.
1. Save the slide as an SVG image to the file stream.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Generate an SVG with a Custom Shape ID**

Aspose.Slides can be used to generate an [SVG](https://docs.fileformat.com/page-description-language/svg/) from a slide with a custom shape ID. To do this, use the `setId` method from [ISvgShape](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` can be used to set the shape ID.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Create a Slide Thumbnail Image**

Aspose.Slides helps you generate thumbnail images of slides. To generate a thumbnail of a slide using Aspose.Slides, please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get the slide reference by its index.
1. Get the thumbnail image of the referenced slide at a defined scale.
1. Save the thumbnail image in any desired image format.

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Create a Slide Thumbnail with User Defined Dimensions**

To create a slide thumbnail image with user defined dimensions, please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get the slide reference by its index.
1. Get the thumbnail image of the referenced slide with the defined dimensions.
1. Save the thumbnail image in any desired image format.

```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Create a Slide Thumbnail with Speaker Notes**

To generate the thumbnail of a slide with speaker notes using Aspose.Slides, please follow the steps below:

1. Create an instance of the [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) class.
1. Use the `RenderingOptions.setSlidesLayoutOptions` method to set the position of speaker notes.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get the slide reference by its index.
1. Get the thumbnail image of the referenced slide with the rendering options.
1. Save the thumbnail image in any desired image format.

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Live Example**

You can try [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) free app to see what you can implement with Aspose.Slides API:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Can I embed a presentation viewer in a web application?**

Yes. You can use Aspose.Slides on the server side to render slides as images or HTML and display them in the browser. Navigation and zoom features can be implemented with JavaScript for an interactive experience.

**What is the best way to display slides inside a custom viewer?**

The recommended approach is to render each slide as an image (e.g., PNG or SVG) or convert it to HTML using Aspose.Slides, then display the output inside a picture box (for desktop) or HTML container (for web).

**How do I handle large presentations with many slides?**

For large decks, consider lazy-loading or on-demand rendering of slides. This means generating a slide's content only when the user navigates to it, reducing memory and load time.
