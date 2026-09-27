---
title: API Reference
type: docs
weight: 50
url: /nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET is documented by the Aspose.Slides for .NET API reference. See how .NET class and member names map to JavaScript."
---

## **Overview**

Aspose.Slides for Node.js via .NET has no API reference of its own. The package exposes the classes of Aspose.Slides for .NET to JavaScript under the same names, with camelCase member names, so the [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) documents its classes, members and enumerations.

## **Map .NET Names to JavaScript**

To use a member that you find in the .NET API reference, apply these rules:

- **Classes and enumerations keep their .NET names**, and so do enumeration values: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Import them from the package: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Properties and methods start with a lower-case letter.** `Presentation.Slides` becomes `presentation.slides`, and `ShapeCollection.AddAutoShape` becomes `shapes.addAutoShape`. Properties stay properties: you read and assign them without parentheses.
- **Collection items are read with `get(index)`**, and the number of items with `count`: `presentation.slides.get(0)` instead of `presentation.Slides[0]`.
- **Some overloads get separate names.** For example, the `Slide.GetImage(Size)` overload is `slide.getImageWithImageSize({ width, height })`. Others share one method with optional trailing arguments: `presentation.save(path, format, options, slides)` covers several `Presentation.Save` overloads, and `new Presentation(null, buffer)` opens a presentation from a `Buffer`. Each class is one file under the package's `lib` folder (for example, `node_modules/aspose.slides.via.net/lib/Slide.js`), where you can look up the exact names.
- **Release presentations with `dispose`** when you are done with them; JavaScript has no `using` statement.

The package does not wrap every .NET member. If a member from the .NET API reference is missing from the class file, it is not available in JavaScript.

## **Example**

The following script uses the rules above. Each comment shows the .NET call that the next line corresponds to. It adds a rectangle with text to the first slide, renders the slide as a 960 × 540 pixel PNG image, and saves the presentation as PDF. Run it from a project folder where the package is installed as described in [Installation](/slides/nodejs-net/installation/).

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

The script writes `slide.png` and `slide.pdf` to the current folder. Both show the rectangle with its text. Without a license, they also show an evaluation watermark; see [Licensing](/slides/nodejs-net/licensing/).

For details on the members used here, see [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) and [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) in the Aspose.Slides for .NET API reference.
