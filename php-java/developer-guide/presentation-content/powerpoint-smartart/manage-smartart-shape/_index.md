---
title: Manage SmartArt Shape
type: docs
weight: 20
url: /php-java/manage-smartart-shape/
---


## **Create SmartArt Shape**
Aspose.Slides for PHP via Java has provided an API to create SmartArt shapes. To create a SmartArt shape in a slide, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. [Add a SmartArt shape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) by setting it [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
1. Save the modified presentation as a PPTX file.

```php
  # Instantiate Presentation Class
  $pres = new Presentation();
  try {
    # Get first slide
    $slide = $pres->getSlides()->get_Item(0);
    # Add Smart Art Shape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Saving presentation
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape added to the slide**|

## **Access SmartArt Shape in Slide**
The following code will be used to access the SmartArt shapes added in presentation slide. In sample code we will traverse through every shape inside the slide and check if it is a [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) shape. If shape is of SmartArt type then we will typecast that to [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) instance.

```php
  # Load the desired the presentation
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Traverse through every shape inside first slide
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Check if shape is of SmartArt type
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typecast shape to SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Access SmartArt Shape with Particular Layout Type**
The following sample code will help to access the [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) shape with particular LayoutType:: Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) shape is added.

1. Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) type and Typecast selected shape to SmartArt if it is SmartArt.
1. Check the SmartArt shape with particular LayoutType and perform what is required to be done afterwards.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Traverse through every shape inside first slide
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Check if shape is of SmartArt type
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typecast shape to SmartArtEx
        $smart = $shape;
        # Checking SmartArt Layout
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Change SmartArt Shape Style**
In this example, we will learn to change the quick style for any SmartArt shape.

1. Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) type and Typecast selected shape to SmartArt if it is SmartArt.
1. Find the SmartArt shape with particular Style.
1. Set the new Style for the SmartArt shape.
1. Save the Presentation.

```php
  # Instantiate Presentation Class
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Get first slide
    $slide = $pres->getSlides()->get_Item(0);
    # Traverse through every shape inside first slide
    foreach($slide->getShapes() as $shape) {
      # Check if shape is of SmartArt type
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typecast shape to SmartArtEx
        $smart = $shape;
        # Checking SmartArt style
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Changing SmartArt Style
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Saving presentation
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape with changed Style**|

## **Change SmartArt Shape Color Style**
In this example, we will learn to change the color style for any SmartArt shape. In the following sample code will access the SmartArt shape with particular color style and will change its style.

1. Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) type and Typecast selected shape to SmartArt if it is SmartArt.
1. Find the SmartArt shape with particular Color Style.
1. Set the new Color Style for the SmartArt shape.
1. Save the Presentation.

```php
  # Instantiate Presentation Class
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Get first slide
    $slide = $pres->getSlides()->get_Item(0);
    # Traverse through every shape inside first slide
    foreach($slide->getShapes() as $shape) {
      # Check if shape is of SmartArt type
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typecast shape to SmartArtEx
        $smart = $shape;
        # Checking SmartArt color type
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Changing SmartArt color type
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Saving presentation
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure: SmartArt shape with changed Color Style**|
