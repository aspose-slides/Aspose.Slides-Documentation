---
title: Manage Fonts in Presentations Using PHP
linktitle: Manage Fonts
type: docs
weight: 10
url: /php-java/manage-fonts/
keywords:
- manage fonts
- font properties
- paragraph
- text formatting
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Control fonts in PHP with Aspose.Slides: embed, substitute, and load custom fonts to keep PPT, PPTX and ODP presentations clear, brand-safe, and consistent."
---

## **Manage Font Related Properties**
{{% alert color="primary" %}} 

Presentations usually contain both text and images. The text can be formatted in a various way, either to highlight specific sections and words or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for PHP via Java to configure the font properties of paragraphs of text on slides.

{{% /alert %}} 

To manage font properties of a paragraph using Aspose.Slides for PHP via Java:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. Obtain a slide's reference by using its index.
1. Access the [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Placeholder) shapes in the slide and typecast them to [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. Get the [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Paragraph) from the [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) exposed by [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. Justify the paragraph.
1. Access a [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Paragraph)'s text [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion).
1. Define the font using [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FontData) and set the **Font** of the text [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FillFormat) exposed by the [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) object.
1. Save the modified presentation to a PPTX file.

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides. The screenshots that follow show the input file and how the code snippets change it. The code changes the font, the color, and the font style.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: The text in the input file**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: The same text with updated formatting**|

```php
  # Instantiate a Presentation object that represents a PPTX file
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Accessing a slide using its slide position
    $slide = $pres->getSlides()->get_Item(0);
    # Accessing the first and second placeholder in the slide and typecasting it as AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Accessing the first Paragraph
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Justify the paragraph
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Accessing the first portion
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Define new fonts
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Assign new fonts to portion
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Set font to Bold
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Set font to Italic
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Set font color
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Save the PPTX to disk
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set Text Font Properties**
{{% alert color="primary" %}} 

As mentioned in **Managing Font Related Properties**, a [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for PHP via Java to create a textbox with some text and then define a particular font, and various other properties of the font family category.

{{% /alert %}} 

To create a textbox and set font properties of the text in it:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape) of the type **Rectangle** to the slide.
1. Remove the fill style associated with the [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. Access the of the [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape)'s [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame).
1. Add some text to the [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame).
1. Access the [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) object associated with the [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame).
1. Define the font to be used for the [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion).
1. Set other font properties like bold, italic, underline, color and height using the relevant properties as exposed by the [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) object.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: Text with some font properties set by Aspose.Slides for PHP via Java**|

```php
  # Instantiate a Presentation object that represents a PPTX file
  $pres = new Presentation();
  try {
    # Get first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Add an AutoShape of Rectangle type
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Remove any fill style associated with the AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Access the TextFrame associated with the AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Access the Portion associated with the TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Set the Font for the Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Set Bold property of the Font
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Set Italic property of the Font
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Set Underline property of the Font
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Set the Height of the Font
    $port->getPortionFormat()->setFontHeight(25);
    # Set the color of the Font
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Save the presentation to disk
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```




