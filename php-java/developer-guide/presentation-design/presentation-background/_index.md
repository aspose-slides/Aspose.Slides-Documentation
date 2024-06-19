---
title: Presentation Background
type: docs
weight: 20
url: /php-java/presentation-background/
keywords: "PowerPoint background, set background "
description: "Set background in PowerPoint presentation "
---

Solid colors, gradient colors, and pictures are often used as background images for slides. You can set the background either for a **normal slide** (single slide) or **master slide** (several slides at once)

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Set Solid Color as Background for Normal Slide**

Aspose.Slides allows you to set a solid color as the background for a specific slide in a presentation (even if that presentation contains a master slide). The background change affects only the selected slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Set the [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) enum for the slide to `OwnBackground`.
3. Set the [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) enum for the slide background to `Solid`.
4. Use the [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) property exposed by [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) to specify a solid color for the background.
5. Save the modified presentation.

This PHP code shows you how to set a solid color (blue) as the background for a normal slide:

```php
  // Creates an instance of the Presentation class
  $pres = new Presentation("MasterBG.pptx");
  try {
    // Sets the background color for the first ISlide to Blue
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType->OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType->Solid);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    // Writes the presentation to disk
    $pres->save("ContentBG.pptx", SaveFormat->Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set Solid Color as Background for Master Slide**

Aspose.Slides allows you to set a solid color as the background for the master slide in a presentation. The master slide acts as a template that contains and controls formatting settings for all slides. Therefore, when you select a solid color as the background for the master slide, that new background will be used for all slides.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Set the  [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) enum for the master slide (`Masters`) to `OwnBackground`.
3. Set the [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) enum for the master slide background to `Solid`.
4. Use the [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) property exposed by [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) to specify a solid color for the background.
5. Save the modified presentation.

This PHP code shows you how to set a solid color (forest green) as the background for a master slide in a presentation:

```php
  // Creates an instance of the Presentation class
  $pres = new Presentation();
  try {
    // Sets the background color for the Master ISlide to Forest Green
    $pres->getMasters()->get_Item(0)->getBackground()->setType(BackgroundType->OwnBackground);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType->Solid);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    // Writes the presentation to disk
    $pres->save("MasterBG.pptx", SaveFormat->Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set Gradient Color as Background for Slide**

A gradient is a graphical effect based on a gradual change in color. Gradient colors, when used as backgrounds for slides, make presentations looks artistic and professional. Aspose.Slides allows you to set a gradient color as the background for slides in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Set the [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) enum for the slide to `OwnBackground`.
3. Set the [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) enum for the master slide background to `Gradient`.
4. Use the [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat--) property exposed by [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) to specify your preferred gradient setting.
5. Save the modified presentation.

This PHP code shows you how to set a gradient color as the background for a slide:

```php
  // Creates an instance of the Presentation class
  $pres = new Presentation("MasterBG.pptx");
  try {
    // Apply Gradient effect to the Background
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType->OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType->Gradient);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip->FlipBoth);
    // Writes the presentation to disk
    $pres->save("ContentBG_Grad.pptx", SaveFormat->Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set Image as Background for Slide**

Besides solid colors and gradient colors, Aspose.Slides also allows you to set images as the background for slides in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Set the [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) enum for the slide to `OwnBackground`.
3. Set the  [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) enum for the master slide background to `Picture`.
4. Load the image you want to use as the slide background.
5. Add the image to the presentation's image collection.
6. Use the [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat--) property exposed by [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) to set the image as the background.
7. Save the modified presentation.

This PHP code shows you how to set an image as the background for a slide:

```php
  // Creates an instance of the Presentation class
  $pres = new Presentation();
  try {
    // Sets conditions for background image
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType->OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType->Picture);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    // Loads the image
    $imgx;
    $image = Images->fromFile("Desert.jpg");
    try {
      $imgx = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    // Adds image to presentation's images collection
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($imgx);
    // Writes the presentation to disk
    $pres->save("ContentBG_Img.pptx", SaveFormat->Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Change Transparency of Background Image**

You may want to adjust the transparency of a slide's background image to make the contents of the slide stand out. This PHP code shows you how to change the transparency for a slide background image:

```php
  $transparencyValue = 30;// for example

  // Gets a collection of picture transform operations
  $imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  // Finds a transparency effect with fixed percentage.
  $transparencyOperation = null;
  foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $transparencyOperation = $operation;
      break;
    }
  }
  // Sets the new transparency value.
  if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
  } else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
  }
```

## **Get Value of Slide Background**

Aspose.Slides provides the [IBackgroundEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/) interface to allow you to get the effective values of slide backgrounds. This interface contains information on the effective [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getFillFormat--) and effective [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Using the [Background](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getBackground--) property from the [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/) class, you can get the effective value for a slide background.

This PHP code shows you how to get a slide's effective background value:

```php
  // Creates an instance of the Presentation class
  $pres = new Presentation("SamplePresentation.pptx");
  try {
    $effBackground = $pres->getSlides()->get_Item(0)->getBackground()->getEffective();
    if ($effBackground->getFillFormat()->getFillType() == FillType->Solid) {
      echo("Fill color: " . $effBackground->getFillFormat()->getSolidFillColor());
    } else {
      echo("Fill type: " . $effBackground->getFillFormat()->getFillType());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



