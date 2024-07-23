---
title: Access Slide in Presentation
type: docs
weight: 20
url: /php-java/access-slide-in-presentation/
keywords: "Access PowerPoint Presentation, Access slide, Edit slide properties, Change slide position, Set slide number, index, ID, position  Java, Aspose.Slides"
description: "Access PowerPoint slide by index, ID, or position . Edit slide properties"
---

Aspose.Slides allows you to access slides in two ways: by index and by ID.

## **Access Slide by Index**

All slides in a presentation are arranged numerically based on the slide position starting from 0. The first slide is accessible through index 0; the second slide is accessed through index 1; etc.

The Presentation class, representing a presentation file, exposes all slides as an [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/) collection (collection of [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/) objects). This PHP code shows you how to access a slide through its index:

```php
  # Instantiates a Presentation object that represents a presentation file
  $pres = new Presentation("demo.pptx");
  try {
    # Accesses a slide using its slide index
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **Access Slide by ID**

Each slide in a presentation has a unique ID associated with it. You can use the [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) method (exposed by the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class) to target that ID. This PHP code shows you how to provide a valid slide ID and access that slide through the [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) method:

```php
  # Instantiates a Presentation object that represents a presentation file
  $pres = new Presentation("demo.pptx");
  try {
    # Gets a slide ID
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # Accesses the slide through its ID
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **Change Slide Position**

Aspose.Slides allow you to change a slide position. For example, you can specify that the first slide should become the second slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Get the slide's reference (whose position you want to change) through its index
1. Set a new position for the slide through the [setSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/islide/#setSlideNumber-int-) property.
1. Save the modified presentation.

This PHP code demonstrates an operation in which the slide in position 1 is moved to position 2:

```php
  # Instantiates a Presentation object that represents a presentation file
  $pres = new Presentation("Presentation.pptx");
  try {
    # Gets the slide whose position will be changed
    $sld = $pres->getSlides()->get_Item(0);
    # Sets the new position for the slide
    $sld->setSlideNumber(2);
    # Saves the modified presentation
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

The first slide became the second; the second slide became the first. When you change a slide's position, other slides are automatically adjusted.


## **Set Slide Number**

Using the [setFirstSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) property (exposed by the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class), you can specify a new number for the first slide in a presentation. This operation causes other slide numbers to be recalculated.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Get the slide number.
1. Set the slide number.
1. Save the modified presentation.

This PHP code demonstrates an operation where the first slide number is set to 10:

```php
  # Instantiates a Presentation object that represents a presentation file
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # Gets the slide number
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # Sets the slide number
    $pres->setFirstSlideNumber(10);
    # Saves the modified presentation
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

If you prefer to skip the first slide, you can start the numbering from the second slide (and hide the numbering for the first slide) this way:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # Sets the number for the first presentation slide
    $presentation->setFirstSlideNumber(0);
    # Shows slide numbers for all slides
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # Hides the slide number for the first slide
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # Saves the modified presentation
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```
