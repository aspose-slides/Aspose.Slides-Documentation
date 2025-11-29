---
title: Manage Superscript and Subscript in Presentations Using PHP
linktitle: Superscript and Subscript
type: docs
weight: 80
url: /php-java/superscript-and-subscript/
keywords:
- superscript
- subscript
- add superscript
- add subscript
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Master superscript and subscript in Aspose.Slides for PHP via Java and elevate your presentations with professional text formatting for maximum impact."
---

## **Manage Super Script and Sub Script Text**
You can add superscript and subscript text inside any paragraph portion. For adding Superscript or Subscript text in Aspose.Slides text frame one must use the [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setEscapement-float-) method of [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat) class.

This property returns or sets the superscript or subscript text (value from -100% (subscript) to 100% (superscript). For example:

- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) of [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) type to the slide.
- Access the [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) associated with the [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
- Clear existing Paragraphs
- Create a new paragraph object for holding superscript text and add it to the [IParagraphs collection](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getParagraphs--) of the [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame).
- Create a new portion object
- Set Escapement property for the portion between 0 to 100 for adding superscript. (0 mean no superscript)
- Set some text for [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) and then add that in portion collection of paragraph.
- Create a new paragraph object for holding subscript text and add it to the IParagraphs collection of the ITextFrame.
- Create a new portion object
- Set Escapement property for portion between 0 to -100 for adding superscript. (0 mean no subscript)
- Set some text for [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) and then add that in portion collection of paragraph.
- Save the presentation as a PPTX file.

The implementation of the above steps is given below.

```php
  # Instantiate a Presentation class that represents a PPTX
  $pres = new Presentation();
  try {
    # Get slide
    $slide = $pres->getSlides()->get_Item(0);
    # Create text box
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Create paragraph for superscript text
    $superPar = new Paragraph();
    # Create portion with usual text
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Create portion with superscript text
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Create paragraph for subscript text
    $paragraph2 = new Paragraph();
    # Create portion with usual text
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Create portion with subscript text
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Add paragraphs to text box
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

