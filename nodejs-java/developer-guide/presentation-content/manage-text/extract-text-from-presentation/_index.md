---
title: Extract Text from Presentation
type: docs
weight: 90
url: /nodejs-java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

It's not uncommon that developers need to extract the text from a presentation. To do so, you need to extract text from all the shapes on all the slides in a presentation. This article explains how to extract text from Microsoft PowerPoint PPTX presentations using Aspose.Slides. 

{{% /alert %}} 
## **Extract Text from Slide**
Aspose.Slides for Node.js via Java provides the [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil) class. This class exposes a number of overloaded static methods for extracting the entire text from a presentation or slide. To extract the text from a slide in a PPTX presentation,
use the [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextBoxes-aspose.slides.IBaseSlide-) overloaded static method exposed by the [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil) class. This method accepts the Slide object as a parameter.
Upon execution, the Slide method scans the entire text from the slide passed as parameter and returns an array of [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) objects. This means that any text formatting associated with the text is available. The following piece of code extracts all the text on the first slide of the presentation:

```javascript
// Instatiate Presentation class that represents a PPTX file
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    pres.getSlides().forEach(function(slide) {
        // Get an Array of ITextFrame objects from all slides in the PPTX
        var textFramesPPTX = aspose.slides.SlideUtil.getAllTextBoxes(slide);
        // Loop through the Array of TextFrames
        for (var i = 0; i < textFramesPPTX.length; i++) {
            // Loop through paragraphs in current ITextFrame
            for (var para : textFramesPPTX[i].getParagraphs()) {
                // Loop through portions in the current IParagraph
                para.getPortions().forEach(function(port) {
                    // Display text in the current portion
                    console.log(port.getText());
                    // Display font height of the text
                    console.log(port.getPortionFormat().getFontHeight());
                    // Display font name of the text
                    if (port.getPortionFormat().getLatinFont() != null) {
                        console.log(port.getPortionFormat().getLatinFont().getFontName());
                    }
                });
            }
        }
    });
} finally {
    pres.dispose();
}
```

## **Extract Text from Presentation**
To scan the text from the whole presentation, use the
 [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) static method exposed by the SlideUtil class. It takes two parameters:

1. First, a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) object that represents the presentation from which the text is being extracted.
1. Second, a boolean value determining whether the master slide is to be included when the text is scanned from the presentation.
   The method returns an array of [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) objects, complete with text formatting information. The code below scans the text and formatting information from a presentation, including the master slides.

```javascript
// Instatiate Presentation class that represents a PPTX file
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Get an Array of ITextFrame objects from all slides in the PPTX
    var textFramesPPTX = aspose.slides.SlideUtil.getAllTextFrames(pres, true);
    // Loop through the Array of TextFrames
    for (var i = 0; i < textFramesPPTX.length; i++) {
        // Loop through paragraphs in current ITextFrame
        for (var para : textFramesPPTX[i].getParagraphs()) {
            // Loop through portions in the current IParagraph
            para.getPortions().forEach(function(port) {
                // Display text in the current portion
                console.log(port.getText());
                // Display font height of the text
                console.log(port.getPortionFormat().getFontHeight());
                // Display font name of the text
                if (port.getPortionFormat().getLatinFont() != null) {
                    console.log(port.getPortionFormat().getLatinFont().getFontName());
                }
            });
        }
    }
} finally {
    pres.dispose();
}
```

## **Categorized and Fast Text Extraction**
The new static method getPresentationText has been added to Presentation class. There are three overloads for this method:

```javascript
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[PresentationText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText#getSlidesText--) method which returns an array of [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) objects. Every object represent the text on the corresponding slide. [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) object have the following methods:

- [SlideText.getText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getText--) - The text on the slide's shapes
- [SlideText.getMasterText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getMasterText--) - The text on the master page's shapes for this slide
- [SlideText.getLayoutText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [SlideText.getNotesText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getNotesText--) - The text on the notes page's shapes for this slide

There is also a [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) class which implements the [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) class.

The new API can be used like this:

```javascript
var text1 = aspose.slides.PresentationFactory.getInstance().getPresentationText("presentation.pptx", aspose.slides.TextExtractionArrangingMode.Unarranged);
console.log(text1.getSlidesText()[0].getText());
console.log(text1.getSlidesText()[0].getLayoutText());
console.log(text1.getSlidesText()[0].getMasterText());
console.log(text1.getSlidesText()[0].getNotesText());
```




