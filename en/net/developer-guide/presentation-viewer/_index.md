---
title: Create a Presentation Viewer in .NET
linktitle: Presentation Viewer
type: docs
weight: 50
url: /net/presentation-viewer/
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
- .NET
- C#
- Aspose.Slides
description: "Create a custom presentation viewer in .NET using Aspose.Slides. Easily display PowerPoint and OpenDocument files without Microsoft PowerPoint."
---

## **Overview**

Aspose.Slides for .NET is used to create presentation files with slides. These slides can be viewed by opening the presentations in Microsoft PowerPoint, for example. However, developers may sometimes need to view slides as images in their preferred image viewer or use them in a custom presentation viewer. In such cases, Aspose.Slides allows you to export individual slides as images. This article explains how to do that.

## **Generate an SVG Image from a Slide**

To generate an SVG image from a presentation slide using Aspose.Slides, follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Get a reference to the slide by its index.
1. Open a file stream.
1. Save the slide as an SVG image to the file stream.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **Generate an SVG with a Custom Shape ID**

Aspose.Slides can be used to generate an [SVG](https://docs.fileformat.com/page-description-language/svg/) from a slide with a custom shape `ID`. To achieve this, use the Id property from the [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape) interface. The `CustomSvgShapeFormattingController` class can be used to set the shape ID.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **Create a Slide Thumbnail Image**

Aspose.Slides helps you generate thumbnail images of slides. To generate a thumbnail of a slide using Aspose.Slides, follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Get a reference to the slide by its index.
1. Create a thumbnail image of the referenced slide at the desired scale.
1. Save the thumbnail image in your preferred image format.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Create a Slide Thumbnail with User Defined Dimensions**

To create a slide thumbnail image with user-defined dimensions, follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Get a reference to the slide by its index.
1. Generate a thumbnail image of the referenced slide with the specified dimensions.
1. Save the thumbnail image in your preferred image format.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Create a Slide Thumbnail with Speaker Notes**

To generate a thumbnail of a slide with speaker notes using Aspose.Slides, follow the steps below:

1. Create an instance of the [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) class.
1. Use the `RenderingOptions.SlidesLayoutOptions` property to set the position of the speaker notes.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Get a reference to the slide by its index.
1. Generate a thumbnail image of the referenced slide using the rendering options.
1. Save the thumbnail image in your preferred image format.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **Live Example**

Try [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) free app to see what you can implement with Aspose.Slides API:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**Can I embed a presentation viewer in an ASP.NET web application?**

Yes. You can use Aspose.Slides on the server side to render slides as images or HTML and display them in the browser. Navigation and zoom features can be implemented with JavaScript for an interactive experience.

**What is the best way to display slides inside a custom .NET viewer?**

The recommended approach is to render each slide as an image (e.g., PNG or SVG) or convert it to HTML using Aspose.Slides, then display the output inside a picture box (for desktop) or HTML container (for web).

**How do I handle large presentations with many slides?**

For large decks, consider lazy-loading or on-demand rendering of slides. This means generating a slide's content only when the user navigates to it, reducing memory and load time.
