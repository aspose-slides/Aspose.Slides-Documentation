---
title: Picture Frame
type: docs
weight: 10
url: /php-java/picture-frame/
keywords: "Add picture frame, create picture frame, add image, create image, extract image, StretchOff property, picture frame formatting, picture frame properties, PowerPoint presentation, Java, Aspose.Slides for PHP via Java"
description: "Add picture frame to PowerPoint presentation "

---

A picture frame is a shape that contains an image—it is like a picture in a frame. 

You can add an image to a slide through a picture frame. This way, you get to format the image by formatting the picture frame.

{{% alert  title="Tip" color="primary" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow people to create presentations quickly from images. 

{{% /alert %}} 

## **Create Picture Frame**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Create an [IPPImage]() object by adding an image to the [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) associated with the presentation object that will be used to fill the shape.
4. Specify the image's width and height.
5. Create a [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) based on the image's width and height through the `AddPictureFrame` method exposed by the shape object associated with the referenced slide.
6. Add a picture frame (containing the picture) to the slide.
7. Write the modified presentation as a PPTX file.

This PHP code shows you how to create a picture frame:

```php
  // Instantiates the Presentation class that represents a PPTX file
  $pres = new Presentation();
  try {
    // Gets the first slide
    $sld = $pres->getSlides()->get_Item(0);
    // Instantiates the Image class
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    // Adds a picture frame with the picture's equivalent height and width
    $sld->getShapes()->addPictureFrame(ShapeType->Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    // Write the PPTX file to disk
    $pres->save("RectPicFrame.pptx", SaveFormat->Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

Picture frames allow you to quickly create presentation slides based on images. When you combine picture frame with the save options Aspose.Slides, you can manipulate input/output operations to convert images from one format to another. You may want to see these pages: convert [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Create Picture Frame with Relative Scale**

By altering an image's relative scaling, you can create a more complicated picture frame. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an image to the presentation image collection.
4. Create an [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) object by adding an image to the [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) associated with the presentation object that will be used to fill the shape.
5. Specify the image's relative width and height in the picture frame.
6. Write the modified presentation as a PPTX file.

This PHP code shows you how to create a picture frame with relative scale:

```php
  // Instantiate Presentation class that represents the PPTX
  $pres = new Presentation();
  try {
    // Get the first slide
    $sld = $pres->getSlides()->get_Item(0);
    // Instantiate the Image class
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    // Add Picture Frame with height and width equivalent of Picture
    $pf = $sld->getShapes()->addPictureFrame(ShapeType->Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    // Setting relative scale width and height
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    // Write the PPTX file to disk
    $pres->save("RectPicFrame.pptx", SaveFormat->Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extract Image from Picture Frame**

You can extract images from [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) objects and save them in PNG, JPG, and other formats. The code example below demonstrates how to extract an image from the document "sample.pptx" and save it in PNG format.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat->Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **Get Transparency of Image**

Aspose.Slides allows you to get the transparency of an image. This PHP code demonstrates the operation:

```php
  $presentation = new Presentation($folderPath . "Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **Picture Frame Formatting**

Aspose.Slides provides many formatting options that can be applied to a picture frame. Using those options, you can alter a picture frame to make it match specific requirements.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Create an [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) object by adding an image to the [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) associated with the presentation object that will be used to fill the shape.
4. Specify the image's width and height.
5. Create a `PictureFrame` based on the image's width and height through the [AddPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) method exposed by the [IShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) object associated with the referenced slide.
6. Add the picture frame (containing the picture) to the slide.
7. Set the picture frame's line color.
8. Set the picture frame's line width.
9. Rotate the picture frame by giving it either a positive or negative value.
   * A positive value rotates the image clockwise. 
   * A negative value rotates the image anti-clockwise.
10. Add the picture frame (containing the picture) to the slide.
11. Write the modified presentation as a PPTX file.

This PHP code demonstrates the picture frame formatting process:

```php
  // Instantiates the Presentation class that represents the PPTX
  $pres = new Presentation();
  try {
    // Gets the first slide
    $sld = $pres->getSlides()->get_Item(0);
    // Instantiates the Image class
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    // Adds Picture Frame with height and width equivalent of Picture
    $pf = $sld->getShapes()->addPictureFrame(ShapeType->Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    // Applies some formatting to PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType->Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    // Writes the PPTX file to disk
    $pres->save("RectPicFrame.pptx", SaveFormat->Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}

Aspose recently developed a [free Collage Maker](https://products.aspose.app/slides/collage). If you ever need to [merge JPG/JPEG](https://products.aspose.app/slides/collage/jpg) or PNG images, [create grids from photos](https://products.aspose.app/slides/collage/photo-grid), you can use this service. 

{{% /alert %}}

## **Add Image as Link**

To avoid large presentation sizes, you can add images (or videos) through links instead of embedding the files directly into presentations. This PHP code shows you how to add an image and video into a placeholder:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType->Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType->Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType->Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat->Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Crop Image**

This PHP code shows you how to crop an existing image on a slide:

```php
  $pres = new Presentation();
  // Creates new image object
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    // Adds a PictureFrame to a Slide
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType->Rectangle, 100, 100, 420, 250, $picture);
    // Crops the image (percentage values)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    // Saves the result
    $pres->save($outPptxFile, SaveFormat->Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Delete Cropped Areas of Picture

If you want to delete the cropped areas of an image contained in a frame, you can use the [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) method. This method returns the cropped image or the origin image if cropping is unnecessary.

This PHP code demonstrates the operation:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    // Gets the PictureFrame from the first slide
    $picFrame = $slide->getShapes()->get_Item(0);
    // Deletes cropped areas of the PictureFrame image and returns the cropped image
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    // Saves the result
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat->Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

The [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) method adds the cropped image to the presentation image collection. If the image is only used in the processed [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), this setup can reduce the presentation size. Otherwise, the number of images in the resulting presentation will increase.

This method converts WMF/EMF metafiles to raster PNG image in the cropping operation. 

{{% /alert %}}

## **Lock Aspect Ratio**

If you want a shape containing an image to retain its aspect ratio even after you change the image dimensions, you can use the [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) method to set the *Lock Aspect Ratio* setting.

This PHP code shows you how to lock a shape's aspect ratio:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType->Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType->Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    // set shape to have to preserve aspect ratio on resizing
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

This *Lock Aspect Ratio* setting preserves only the aspect ratio of the shape and not the image it contains.

{{% /alert %}}

## **Use StretchOff Property**

Using the [StretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetRight--) and [StretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) properties from the [IPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat) interface and [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat) class, you can specify a fill rectangle.

When stretching is specified for an image, a source rectangle is scaled to fit the specified fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape's bounding box. A positive percentage specifies an inset while a negative percentage specifies an outset.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentatio) class.
2. Get a slide's reference through its index.
3. Add a rectangle `AutoShape`. 
4. Create an image.
5. Set the shape's fill type.
6. Set the shape's picture fill mode.
7. Add a set image to fill the shape.
8. Specify image offsets from the corresponding edge of the shape's bounding box
9. Write the modified presentation as a PPTX file.

This PHP code demonstrates a process in which a StretchOff property is used:

```php
  // Instantiates the Prseetation class that represents a PPTX file
  $pres = new Presentation();
  try {
    // Gets the first slide
    $slide = $pres->getSlides()->get_Item(0);
    // Instantiates the ImageEx class
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    // Adds an AutoShape set to Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType->Rectangle, 100, 100, 300, 300);
    // Sets the shape's fill type
    $aShape->getFillFormat()->setFillType(FillType->Picture);
    // Sets the shape's picture fill mode
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    // Sets the image to fill the shape
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    // Specifies the image offsets from the corresponding edge of the shape's bounding box
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    // Writes the PPTX file to disk
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat->Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

