---
title: Manage Text Boxes in Presentations Using PHP
linktitle: Manage Text Box
type: docs
weight: 20
url: /php-java/manage-textbox/
keywords:
- text box
- text frame
- add text
- update text
- create text box
- check text box
- add text column
- add hyperlink
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP makes it easy to create, edit, and clone text boxes in PowerPoint and OpenDocument files, enhancing your presentation automation."
---


Texts on slides typically exist in text boxes or shapes. Therefore, to add a text to a slide, you have to add a text box and then put some text inside the textbox. Aspose.Slides for PHP via Java provides the [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) class that allows you to add a shape containing some text.

{{% alert title="Info" color="info" %}}

Aspose.Slides also provides the [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) class that allows you to add shapes to slides. However, not all shapes added through the `Shape` class can hold text. But shapes added through the [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) class may contain text.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Therefore, when dealing with a shape to which you want to add text, you may want to check and confirm that it was cast through the `AutoShape` class. Only then will you be able to work with [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), which is a property under `AutoShape`. See the [Update Text](/slides/php-java/manage-textbox/#update-text) section on this page.

{{% /alert %}}

## **Create a Text Box on a Slide**

To create a textbox on a slide, go through these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Obtain a reference for the first slide in the newly created presentation. 
3. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) object with shape type set as [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/#Rectangle) at a specified position on the slide and obtain the reference for the newly added `AutoShape` object.
4. Add a `TextFrame` to the `AutoShape` object that will contain a text. In the example below, we added this text: *Aspose TextBox*
5. Finally, write the PPTX file through the `Presentation` object. 

This PHP code—an implementation of the steps above—shows you how to add text to a slide:

```php
  # Instantiates Presentation
  $pres = new Presentation();
  try {
    # Gets the first slide in the presentation
    $sld = $pres->getSlides()->get_Item(0);
    # Adds an AutoShape with type set as Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Adds TextFrame to the Rectangle
    $ashp->addTextFrame(" ");
    # Accesses the text frame
    $txtFrame = $ashp->getTextFrame();
    # Creates the Paragraph object for text frame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Creates a Portion object for paragraph
    $portion = $para->getPortions()->get_Item(0);
    # Sets Text
    $portion->setText("Aspose TextBox");
    # Saves the presentation to disk
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Check for a Text Box Shape**

Aspose.Slides provides the [isTextBox](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/istextbox/) method from the [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) class, allowing you to examine shapes and identify text boxes.

![Text box and shape](istextbox.png)

This PHP code shows you how to check whether a shape was created as a text box:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Note that if you simply add an autoshape using the `addAutoShape` method from the [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) class, the `isTextBox` method of the autoshape will return `false`. However, after you add text to the autoshape using the `addTextFrame` method or the `setText` method, the `isTextBox` property returns `true`.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() returns false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() returns true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() returns false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() returns true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() returns false
$shape3->addTextFrame("");
// shape3->isTextBox() returns false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() returns false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() returns false
```

## **Add Columns to a Text Box**

Aspose.Slides provides the [setColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumncount/) and [setColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumnspacing/) methods from the [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/) class that allow you to add columns to textboxes. You get to specify the number of columns in a text box and set the amount spacing in points between columns.

This code  demonstrates the described operation:

```php
  $pres = new Presentation();
  try {
    # Gets the first slide in the presentation
    $slide = $pres->getSlides()->get_Item(0);
    # Add an AutoShape with type set as Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Add TextFrame to the Rectangle
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Gets the text format of TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Specifies the number of columns in TextFrame
    $format->setColumnCount(3);
    # Specifies the spacing between columns
    $format->setColumnSpacing(10);
    # Saves the presentation
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Add Columns to a Text Frame**
Aspose.Slides for PHP via Java provides the [setColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumncount/) method from the [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/) class that allows you to add columns in text frames. Through this property, you can specify your preferred number of columns in a text frame.

This PHP code shows you how to add a column inside a text frame:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Update Text**

Aspose.Slides allows you to change or update the text contained in a text box or all the texts contained in a presentation. 

This PHP code demonstrates an operation where all the texts in a presentation are updated or changed:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Checks if shape supports text frame (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Iterates through paragraphs in text frame
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Iterates through each portion in paragraph
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Changes text

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Changes formatting

            }
          }
        }
      }
    }
    # Saves modified presentation
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Add a Text Box with a Hyperlink** 

You can insert a link inside a text box. When the text box is clicked, users are directed to open the link. 

 To add a text box containing a link, go through these steps:

1. Create an instance of the `Presentation` class. 
2. Obtain a reference for the first slide in the newly created presentation. 
3. Add an `AutoShape` object with `ShapeType` set as `Rectangle` at a specified position on the slide and obtain a reference of the newly added AutoShape object.
4. Add a `TextFrame` to the `AutoShape` object that contains *Aspose TextBox* as its default text. 
5. Instantiate the `HyperlinkManager` class. 
6. Assign a hyperlink using the [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) method associated with your preferred portion of the `TextFrame`.
7. Finally, write the PPTX file through the `Presentation` object. 

This PHP code—an implementation of the steps above—shows you how to add a text box with a hyperlink to a slide:

```php
  # Instantiates a Presentation class that represents a PPTX
  $pres = new Presentation();
  try {
    # Gets the first slide in the presentation
    $slide = $pres->getSlides()->get_Item(0);
    # Adds an AutoShape object with type set as Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Casts the shape to AutoShape
    $pptxAutoShape = $shape;
    # Accesses the ITextFrame property associated with the AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Adds some text to the frame
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Sets the Hyperlink for the portion text
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Saves the PPTX Presentation
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**What’s the difference between a text box and a text placeholder when working with master slides?**

A [placeholder](/slides/php-java/manage-placeholder/) inherits style/position from the [master](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) and can be overridden on [layouts](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/), whereas a regular text box is an independent object on a specific slide and doesn’t change when you switch layouts.

**How can I perform a bulk text replacement across the presentation without touching text inside charts, tables, and SmartArt?**

Limit your iteration to auto-shapes that have text frames and exclude embedded objects ([charts](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)) by traversing their collections separately or skipping those object types.
