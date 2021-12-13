---
title: Extract Text from Presentation
type: docs
weight: 90
url: /python-net/extract-text-from-presentation/
keywords: "Extract text from slide, Extract text from PowerPoint, Python, Aspose.Slides for Python via .NET"
description: "Extract text from slide or PowerPoint presentation in Python"
---

{{% alert color="primary" %}} 

It's not uncommon that developers need to extract the text from a presentation. To do so, you need to extract text from all the shapes on all the slides in a presentation. This article explains how to extract text from Microsoft PowerPoint PPTX presentations using Aspose.Slides. Text can be extracted in following ways:

- [Extracting text from one slide](/slides/python-net/extracting-text-from-the-presentation/)
- [Extracting text using GetAllTextBoxes method](/slides/python-net/extracting-text-from-the-presentation/)
- [Categorized and fast extraction of text](/slides/python-net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extract Text from Slide**
Aspose.Slides for Python via .NET provides the Aspose.Slides.Util namespace which includes the SlideUtil class. This class exposes a number of overloaded static methods for extracting the entire text from a presentation or slide. To extract the text from a slide in a PPTX presentation, 
use the [GetAllTextBoxes](https://apireference.aspose.com/slides/python-net/aspose.slides.util/slideutil/methods/getalltextboxes) overloaded static method exposed by the SlideUtil class. This method accepts the Slide object as a parameter.
Upon execution, the Slide method scans the entire text from the slide passed as parameter and returns an array of TextFrame objects. This means that any text formatting associated with the text is available. The following piece of code extracts all the text on the first slide of the presentation:

```py
import aspose.slides as slides

#Instatiate Presentation class that represents a PPTX file
with slides.Presentation("pres.pptx") as pptxPresentation:
    # Get an Array of ITextFrame objects from all slides in the PPTX
    textFramesPPTX = slides.util.SlideUtil.get_all_text_boxes(pptxPresentation.slides[0])
    
    # Loop through the Array of TextFrames
    for i in range(len(textFramesPPTX)):
	    # Loop through paragraphs in current ITextFrame
        for para in textFramesPPTX[i].paragraphs:
            # Loop through portions in the current IParagraph
            for port in para.portions:
			    # Display text in the current portion
                print(port.text)

    			# Display font height of the text
                print(port.portion_format.font_height)

			    # Display font name of the text
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **Extract Text from Presentation**
To scan the text from the whole presentation, use the
 [GetAllTextFrames](https://apireference.aspose.com/slides/python-net/aspose.slides.util/slideutil/methods/getalltextframes) static method exposed by the SlideUtil class. It takes two parameters:

1. First, a Presentation object that represents the PPTX presentation the text is being extracted from.
1. Second, a Boolean value determining whether the master slide is to be included when the text is scanned from the presentation.
   The method returns an array of TextFrame objects, complete with text formatting information. The code below scans the text and formatting information from a presentation, including the master slides.

```py
import aspose.slides as slides

#Instatiate Presentation class that represents a PPTX file
with slides.Presentation("pres.pptx") as pptxPresentation:
    # Get an Array of ITextFrame objects from all slides in the PPTX
    textFramesPPTX = slides.util.SlideUtil.get_all_text_frames(pptxPresentation, True)
    
    # Loop through the Array of TextFrames
    for i in range(len(textFramesPPTX)):
	    # Loop through paragraphs in current ITextFrame
        for para in textFramesPPTX[i].paragraphs:
            # Loop through portions in the current IParagraph
            for port in para.portions:
			    # Display text in the current portion
                print(port.text)

    			# Display font height of the text
                print(port.portion_format.font_height)

			    # Display font name of the text
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **Categorized and Fast Text Extraction**
The new static method GetPresentationText has been added to Presentation class. There are two overloads for this method:

```py
slides.Presentation.get_presentation_text(stream)
slides.Presentation.get_presentation_text(stream, mode)      
```

The ExtractionMode enum argument indicates the mode to organize the output of text result and can be set to the following values:
Unarranged - The raw text with no respect to position on the slide
Arranged - The text is positioned in the same order as on the slide

Unarranged mode can be used when speed is critical, it's faster than Arranged mode.

PresentationText represents the raw text extracted from the presentation. It contains a `slides_text` property from Aspose.Slides.Util namespace which returns an array of SlideText objects. Every object represent the text on the corresponding slide. SlideText object have the following properties:

SlideText.text - The text on the slide's shapes
SlideText.master_text - The text on the master page's shapes for this slide
SlideText.layout_text - The text on the layout page's shapes for this slide
SlideText.notes_text - The text on the notes page's shapes for this slide


The new API can be used like this:

```py
import aspose.slides as slides

text1 = slides.PresentationFactory().get_presentation_text("pres.pptx", slides.TextExtractionArrangingMode.UNARRANGED)
print(text1.slides_text[0].text)
print(text1.slides_text[0].layout_text)
print(text1.slides_text[0].master_text)
print(text1.slides_text[0].notes_text)
```



