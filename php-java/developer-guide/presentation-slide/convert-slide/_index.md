---
title: Convert Slide
type: docs
weight: 35
url: /php-java/convert-slide/
keywords: "Convert slide to image, export slide as image, save slide as image, slide to image, slide to PNG, slide to JPEG, slide to Bitmap, Java, java, Aspose.Slides"
description: "Convert PowerPoint slide to image (Bitmap, PNG, or JPG) in Java"
---

Aspose.Slides for PHP via Java allows you to convert slides (in presentations) to images. These are the supported image formats: BMP, PNG, JPG (JPEG), GIF, and others.

To convert a slide to an image, do this: 

1. First,
   * convert the slide to a Images first by using the [getImage](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) method or

2. Second, set additional options for conversion and convertible slide objects through
   * the [ITiffOptions](https://reference.aspose.com/slides/php-java/com.aspose.slides/ITiffOptions) interface or
   * the [IRenderingOptions](https://reference.aspose.com/slides/php-java/com.aspose.slides/IRenderingOptions) interface.

## **About Bitmap and Other Image Formats**

In Java, a [Images](https://reference.aspose.com/slides/php-java/com.aspose.slides/Images)  is an object that allows you to work with images defined by pixel data. You can use an instance of this class to save images in a wide range of formats (JPG, PNG, etc.).

{{% alert title="Info" color="info" %}}

Aspose recently developed an online [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter. 

{{% /alert %}}

## **Converting Slides to Bitmap and Saving the Images in PNG**

This Java code shows you how to convert the first slide of a presentation to a bitmap object and then how to then save the image in the PNG format:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    // Converts the first slide in the presentation to a Images object
    $slideImage = $pres->getSlides()->get_Item(0)->getImage();
    // Saves the image in the PNG format
    try {
      // save the image on the disk.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if ($slideImage != null) {
        $slideImage->dispose();
      }
    }
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

This sample code shows you how to convert the first slide of a presentation to a bitmap object using the [getImage](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) method:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    // Gets the presentation slide size
    $slideSize = new Dimension($slideSize->getWidth(), $slideSize->getHeight());
    // Creates a Images with the slide size
    $slideImage = $sld->getImage(new RenderingOptions(), $slideSize);
    try {
      // save the image on the disk.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if ($slideImage != null) {
        $slideImage->dispose();
      }
    }
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

{{% alert title="Tip" color="primary" %}} 

You can convert a slide to a Images object and then use the object directly somewhere. Or you can convert a slide to a Images and then save the image in JPEG or any other format you prefer.

{{% /alert %}}  

## **Converting Slides to Images with Custom Sizes**

You may need to get an image of a certain size. Using an overload from the [getImage](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-) method, you can convert a slide to an image with specific dimensions (length and width).

This sample code demonstrates the proposed conversion using the [getImage](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) method in Java:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    // Converts the first slide in the presentation to a Bitmap with the specified size
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Dimension(1820, 1040));
    // Saves the image in the JPEG format
    try {
      // save the image on the disk.
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if ($slideImage != null) {
        $slideImage->dispose();
      }
    }
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

## **Converting Slides With Notes and Comments to Images**

Some slides contain notes and comments. 

Aspose.Slides provides two interfaces—[ITiffOptions](https://reference.aspose.com/slides/php-java/com.aspose.slides/ITiffOptions) and [IRenderingOptions](https://reference.aspose.com/slides/php-java/com.aspose.slides/IRenderingOptions)—that allow you to control the rendering of presentation slides to images. Both interfaces house the [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/com.aspose.slides/INotesCommentsLayoutingOptions) interface that allows you to add notes and comments on a slide when you are converting that slide to an image.

{{% alert title="Info" color="info" %}} 

With the [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/com.aspose.slides/INotesCommentsLayoutingOptions) interface, you get to specify your preferred position for notes and comments in the resulting image.

{{% /alert %}} 

This Java code demonstrates the conversion process for a slide with notes and comments:

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    // Creates the rendering options
    $options = new RenderingOptions();
    // Sets the position of the notes on the page
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    // Sets the position of the comments on the page
    $options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);
    // Sets the width of the comment output area
    $options->getNotesCommentsLayouting()->setCommentsAreaWidth(500);
    // Sets the color for the comments area
    $options->getNotesCommentsLayouting()->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);
    // Converts the first slide of the presentation to a Bitmap object
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, 2.0, 2.0);
    // Saves the image in the GIF format
    try {
      $slideImage->save("Slide_Notes_Comments_0.gif", ImageFormat::Gif);
    } finally {
      if ($slideImage != null) {
        $slideImage->dispose();
      }
    }
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

This Java code demonstrates the conversion process for a slide with notes using the [getImage](https://reference.aspose.com/slides/php-java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) method:

```php
  $pres = new Presentation("PresentationNotes.pptx");
  try {
    // Gets the presentation notes size
    $notesSize = $pres->getNotesSize()->getSize();
    // Creates the rendering options
    $options = new RenderingOptions();
    // Sets the position of the notes
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    // Creates a Images with the notes' size
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, $notesSize);
    // Saves the image in PNG format
    try {
      // save the image on the disk.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if ($slideImage != null) {
        $slideImage->dispose();
      }
    }
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

{{% alert title="Note" color="warning" %}} 

In any slide to image conversion process, the [NotesPositions](https://reference.aspose.com/slides/php-java/com.aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) property cannot be set to BottomFull (to specify the position for notes) because a note's text may be large, which means it might not fit into the specified image size.

{{% /alert %}} 

## **Converting Slides to Images Using ITiffOptions**

The [ITiffOptions](https://reference.aspose.com/slides/php-java/com.aspose.slides/ITiffOptions) interface gives you more control (in terms of parameters) over the resulting image. Using this interface, you get to specify the size, resolution, color palette, and other parameters for the resulting image.

This Java code demonstrates a conversion process where ITiffOptions is used to output a black and white image with a 300dpi resolution and 2160 × 2800 size:

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    // Gets a slide by its index
    $slide = $pres->getSlides()->get_Item(0);
    // Creates a TiffOptions object
    $options = new TiffOptions();
    $options->setImageSize(new Dimension(2160, 2880));
    // Set the font used in case source font is not found
    $options->setDefaultRegularFont("Arial Black");
    // Set the position of the notes on the page
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    // Sets the pixel format (black and white)
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);
    // Sets the resolution
    $options->setDpiX(300);
    $options->setDpiY(300);
    // Converts the slide to a Bitmap object
    $slideImage = $slide->getImage($options);
    // Saves the image in TIFF format
    try {
      $slideImage->save("PresentationNotesComments.tiff", ImageFormat::Tiff);
    } finally {
      if ($slideImage != null) {
        $slideImage->dispose();
      }
    }
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

{{% alert title="Note" color="warning" %}} 

Tiff support is not guaranteed in versions earlier than JDK 9.

{{% /alert %}} 

## **Converting All Slides to Images**

Aspose.Slides allows you to convert all slides in a single presentation to images. Essentially, you get to convert the presentation (in its entirety) to images. 

This sample code shows you how to convert all slides in a presentation to images in Java:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    // Render presentation to images array slide by slide
    for ($i = 0; $i < $pres->getSlides()->size(); $i++) {
      // Control hidden slides (do not render hidden slides)
      if ($pres->getSlides()->get_Item($i)->getHidden()) {
        continue;
      }
      // Convert slide to a Bitmap object
      $slideImage = $pres->getSlides()->get_Item($i)->getImage(2.0, 2.0);
      // Save the image in PNG format
      try {
        $slideImage->save("Slide_" . $i . ".png", ImageFormat::Png);
      } finally {
        if ($slideImage != null) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

