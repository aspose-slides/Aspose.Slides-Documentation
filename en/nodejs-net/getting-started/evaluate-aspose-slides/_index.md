---
title: Evaluate Aspose.Slides
type: docs
weight: 120
url: /nodejs-net/evaluate-aspose-slides/
keywords:
- evaluate Aspose.Slides
- evaluation version
- evaluation watermark
- trial limitations
- temporary license
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "What the evaluation version of Aspose.Slides for Node.js via .NET limits, with a script that shows both limitations and how to remove them with a license."
---

## **Overview**

The evaluation version of Aspose.Slides for Node.js via .NET is the same npm package as the licensed version. Without a license, it runs in evaluation mode: every feature works, but saved presentations and most exports carry a watermark, and text that your code reads back is truncated. This article describes both limitations and shows how to remove them.

## **Evaluation Limitations**

**An evaluation watermark on every slide.** When you save a presentation without a license, Aspose.Slides adds a text box to the middle of every slide of the saved file. The text box is locked and reads "Evaluation only." followed by a product line and a copyright line. The watermark goes into the saved file, not into the presentation in memory, and opening a presentation does not add one. A file that was saved in evaluation mode already contains the text box, however, so opening and saving it again adds a second watermark to each slide.

The same watermark is drawn on the output when you export to PDF, XPS or HTML, or render slides as images. If you render a presentation that was already saved in evaluation mode, the image shows both the saved watermark and the rendered one.

**Truncated text when your code reads it.** Text that your code reads through the `text` property of a text frame, paragraph or portion is cut to its first five characters, followed by the notice "... text has been truncated due to evaluation version limitation." Text of five characters or fewer is returned in full. This applies on every slide, and even to text your code has just assigned. Markdown and HTML5 exports are truncated the same way.

The text that your code writes is saved in full: PPTX files, PDF pages and slide images contain the complete text.


## **See the Limitations in a Script**

The following script shows both limitations. It assumes that you have installed the package as described in [Installation](/slides/nodejs-net/installation/) and that you run it from the project folder. It adds a rectangle with a sentence to the first slide, reads the sentence back, saves the presentation as `evaluation.pptx`, and then reopens the file to count the shapes on the slide.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Without a license, only the first five characters are returned.
    console.log("Text read back:", rectangle.textFrame.text);

    // Saving adds the evaluation watermark to every slide of the file.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // The slide now holds the rectangle and the watermark text box.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Without a license, the script prints:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

The second shape is the watermark text box. Open `evaluation.pptx` to see the full sentence in the rectangle and the watermark in the middle of the slide.

## **Remove the Limitations**

To remove both limitations, apply a license before you create any `Presentation` object. [Licensing](/slides/nodejs-net/licensing/) shows how to apply a license file.

{{% alert color="success" title="Tip" %}}

To test Aspose.Slides without the evaluation limitations before you buy, request a free **30-day temporary license**. See [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) for details.

{{% /alert %}}

## **FAQ**

**Does evaluation mode limit the number of slides?**

No. Presentations are created, opened and saved with all their slides. The watermark and the text truncation apply to every slide alike.

**Why do my exported slide images show the watermark twice?**

The presentation was saved in evaluation mode before you rendered it, so it already contains a watermark text box, and rendering without a license draws another one on top of it.

**Can I check that my code produces the right text while in evaluation mode?**

Yes. Open the saved file or the exported PDF: they contain the complete text. Only the text that your code reads back, and Markdown or HTML5 output, is truncated.
