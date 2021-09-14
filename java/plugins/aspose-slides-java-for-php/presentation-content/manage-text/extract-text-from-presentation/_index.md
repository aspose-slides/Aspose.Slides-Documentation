---
title: Extract Text from Presentation
type: docs
weight: 80
url: /java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

It's not uncommon that developers need to extract the text from a presentation. To do so, you need to extract text from all the shapes on all the slides in a presentation. This article explains how to extract text from Microsoft PowerPoint PPTX presentations using Aspose.Slides. 

{{% /alert %}} 
## **Extract Text from Slide**
Aspose.Slides for Java provides the [SlideUtil](https://apireference.aspose.com/slides/java/com.aspose.slides/SlideUtil) class. This class exposes a number of overloaded static methods for extracting the entire text from a presentation or slide. To extract the text from a slide in a PPTX presentation, 
use the [getAllTextBoxes](https://apireference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) overloaded static method exposed by the [SlideUtil](https://apireference.aspose.com/slides/java/com.aspose.slides/SlideUtil) class. This method accepts the Slide object as a parameter.
Upon execution, the Slide method scans the entire text from the slide passed as parameter and returns an array of [TextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/TextFrame) objects. This means that any text formatting associated with the text is available. The following piece of code extracts all the text on the first slide of the presentation:

```php
//Instatiate Presentation class that represents a PPTX file
$pres = new Java("com.aspose.slides.Presentation", "demo.pptx");
try {
    foreach( $pres->getSlides() as $slide ) 
    {
        //Get an Array of ITextFrame objects from all slides in the PPTX
        $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);

        //Loop through the Array of TextFrames
        for ($i = 0; $i < $textFramesPPTX->length; $i++) {
            //Loop through paragraphs in current ITextFrame
            foreach( $textFramesPPTX->get_Item($i)->getParagraphs() as $para ) {
                //Loop through portions in the current IParagraph
                foreach( $para->getPortions() as $port ) {
                    //Display text in the current portion
                    echo($port->getText());

                    //Display font height of the text
                    echo($port->getPortionFormat()->getFontHeight());

                    //Display font name of the text
                    if ($port->getPortionFormat()->getLatinFont() != null)
                        echo($port->getPortionFormat()->getLatinFont()->getFontName());
                }
            }
        }
    }
} finally {
    $pres->dispose();
}
```

## **Extract Text from Presentation**
To scan the text from the whole presentation, use the
 [getAllTextFrames](https://apireference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) static method exposed by the SlideUtil class. It takes two parameters:

1. First, a [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) object that represents the presentation from which the text is being extracted.
1. Second, a boolean value determining whether the master slide is to be included when the text is scanned from the presentation.
   The method returns an array of [TextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/TextFrame) objects, complete with text formatting information. The code below scans the text and formatting information from a presentation, including the master slides.

```php
//Instatiate Presentation class that represents a PPTX file
$pres = new Java("com.aspose.slides.Presentation", "demo.pptx");
try {
    //Get an Array of ITextFrame objects from all slides in the PPTX
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);

    //Loop through the Array of TextFrames
    for ($i = 0; $i < $textFramesPPTX->length; $i++) 
    {
        //Loop through paragraphs in current ITextFrame
        foreach( $textFramesPPTX->get_Item($i)->getParagraphs() as $para )
        {
            //Loop through portions in the current IParagraph
            foreach( $para->getPortions() as $port )
            {
                //Display text in the current portion
                echo($port->getText());

                //Display font height of the text
                echo($port->getPortionFormat()->getFontHeight());

                //Display font name of the text
                if ($port->getPortionFormat()->getLatinFont() != null)
                    echo($port->getPortionFormat()->getLatinFont()->getFontName());
            }
        }
    }
} finally {
    $pres->dispose();
}
```

## **Categorized and Fast Text Extraction**
The new static method getPresentationText has been added to Presentation class. There are three overloads for this method:

```php
public $getPresentationText($file, $mode);
public $getPresentationText($stream, $mode);
public $getPresentationText($stream, $mode, $options);
``` 

The [TextExtractionArrangingMode](https://apireference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://apireference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://apireference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[IPresentationText](https://apireference.aspose.com/slides/java/com.aspose.slides/IPresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://apireference.aspose.com/slides/java/com.aspose.slides/IPresentationText#getSlidesText--) method which returns an array of [ISlideText](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideText) objects. Every object represent the text on the corresponding slide. [ISlideText](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideText) object have the following methods:

- [ISlideText->getText](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideText#getText--) - The text on the slide's shapes
- [ISlideText->getMasterText](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideText#getMasterText--) - The text on the master page's shapes for this slide
- [ISlideText->getLayoutText](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [ISlideText->getNotesText](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideText#getNotesText--) - The text on the notes page's shapes for this slide

There is also a [SlideText](https://apireference.aspose.com/slides/java/com.aspose.slides/SlideText) class which implements the [ISlideText](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlideText) interface.

The new API can be used like this:

```php
$text1 = Java("com.aspose.slides.PresentationFactory")->getInstance()->getPresentationText("presentation.pptx", Java("com.aspose.slides.TextExtractionArrangingMode")->Unarranged);
echo($text1->getSlidesText()[0]->getText());
echo($text1->getSlidesText()[0]->getLayoutText());
echo($text1->getSlidesText()[0]->getMasterText());
echo($text1->getSlidesText()[0]->getNotesText());
```



