---
title: Manage Placeholder
type: docs
weight: 10
url: /php-java/manage-placeholder/
description: Change Text in a Placeholder in PowerPoint Slides using PHP. Set Prompt Text in a Placeholder in PowerPoint Slides using PHP.
---

## **Change Text in Placeholder**
Using [Aspose.Slides for PHP via Java](/slides/php-java/), you can find and modify placeholders on slides in presentations. Aspose.Slides allows you to make changes to the text in a placeholder.

**Prerequisite**: You need a presentation that contains a placeholder. You can create such a presentation in the standard Microsoft PowerPoint app.

This is how you use Aspose.Slides to replace the text in the placeholder in that presentation:

1. Instantiate the [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class. and pass the presentation as an argument.
2. Get a slide reference through its index.
3. Iterate through the shapes to find the placeholder.
4. Typecast the placeholder shape to an [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) and change the text using the [`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) associated with the [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. Save the modified presentation.

This PHP code shows how to change the text in a placeholder:

```php
  # Instantiates a Presentation class
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Accesses the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Iterates through shapes to find the placeholder
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Changes the text in each placeholder
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Saves the presentation to disk
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set Prompt Text in Placeholder**
Standard and pre-built layouts contain placeholder prompt texts such as ***Click to add a title*** or ***Click to add a subtitle***. Using Aspose.Slides, you can insert your preferred prompt texts into placeholder layouts.

This PHP code shows you how to set the prompt text in a placeholder:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Iterates through the slide
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint displays "Click to add title"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Adds subtitle
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set Placeholder Image Transparency**

Aspose.Slides allows you to set the transparency of the background image in a text placeholder. By adjusting the transparency of the picture in such a frame, you can make the text or the image stand out (depending on the text's and picture's colors).

This PHP code shows you how to set the transparency for a picture background (inside a shape):

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);

```

