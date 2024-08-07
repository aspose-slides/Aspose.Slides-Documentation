---
title: Watermark
type: docs
weight: 40
url: /php-java/watermark/
keywords: "watermark in presentation"
description: "Use watermark in PowerPoint with Aspose.Slides. Add watermark in ppt presentation or remove watermark. Insert image watermark or text watermark."
---


## **About Watermark**
**Watermark** in presentation is a text or image stamp, used upon a slide or all presentation slides. Usually, watermark is used to indicate that the presentation is a draft (e.g. "Draft" watermark); that it contains confidential information (e.g. "Confidential" watermak); specify which company it belongs to (e.g. "Company name" watermark); identify presentation author, etc. Watermark helps to prevent presentation copyrights violation, indicating that the presentation should not be copied. Watermarks are used with both PowerPoint and OpenOffice presentation formats. In Aspose.Slides you can add watermark to PowerPoint PPT, PPTX and OpenOffice ODP file formats.

In [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) there are various ways you can create watermark in PowerPoint or OpenOffice, to wrap it into different shapes, to change the design and behavior., etc  The common things is, that to add text watermarks you should use [**TextFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) class and to add image watermark - [**PictureFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame/). [PictureFrame]((https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame/)) implements [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) interface and can use all the power of flexible settings of shape object. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) is not a shape and its settings are limited. Therefore, it is advised to wrap [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) into [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) object.

There are two ways watermark can be applied: to a single slide and to all presentation slides. Slide Master is used to apply watermark to all presentation slides - watermark is added into Slide Master, completely designed there and applied to all slides without modifying a permission to modify watermark on slides.

Watermark is usually considered not to be available for editing by other users. To prevent editing watermark (or rather watermark parent shape), Aspose.Slides provides shape locking functionality. A certain shape can be locked on a normal slide or on a Slide Master. When locking watermark shape on a Slide Master - it will be locked on all presentation slides.

You can set the name of watermark, so in future, if you want to delete the watermark, you may find it in slide shapes by name.

You can design watermark in any way however there are usually attend common features within watermarks, like: center alignment, rotation, front position, etc. We will consider how to use them in the examples below.
## **Text Watermark**
### **Add Text Watermark to Slide**
To add text watermark in PPT, PPTX or ODP you can first add a shape into the slide, then add a text frame into this shape. Text frame is represented with [**TextFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) type. This type is not inherited from [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape), which has a wide set of properties to settle the watermark in a flexible way. Therefore, it is advised to wrap [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) object into [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) object. To add watermark into the shape, use [**addTextFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-) method with watermark text passed into it:

```php
  # Open presentation
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 0, 0, 0, 0);
    $watermarkTextFrame = $watermarkShape->addTextFrame("Watermark");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```



{{% alert color="primary" title="See also" %}} 
- [How to use ](/slides/php-java/slide-master/)[TextFrame](/slides/php-java/adding-and-formatting-text/)
{{% /alert %}}

### **Add Text Watermark to Presentation**
If you want to add watermark in presentation (means, all slides at once), 
add it into [**MasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide).
All the other logic is the same as in adding watermark into a single slide - create an [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) object and then add watermark into it with [**addTextFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-) method:

```php
  # Open presentation
  $pres = new Presentation();
  try {
    $master = $pres->getMasters()->get_Item(0);
    $watermarkShape = $master->getShapes()->addAutoShape(ShapeType::Triangle, 0, 0, 0, 0);
    $watermarkTextFrame = $watermarkShape->addTextFrame("Watermark");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="See also" %}} 
- [How to use ](/slides/php-java/slide-master/)[Slide Master](/slides/php-java/slide-master/)
{{% /alert %}}

### **Set Font of Text Watermark**
You can change the font of text watermark:

```php
  $watermarkPortion = $watermarkTextFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
  $watermarkPortion->getPortionFormat()->setFontBold(NullableBool::True);
  $watermarkPortion->getPortionFormat()->setFontHeight(52);

```


### **Set Text Watermark Transparency**
To set the transparency of text watermark use this code:

```php
  $alpha = 150;
  $red = 200;
  $green = 200;
  $blue = 200;
  $watermarkPortion = $watermarkTextFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
  $watermarkPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $watermarkPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", $red, $green, $blue, $alpha));

```


### **Center Text Watermark**
It is possible to center watermark on a slide and for that you can do the following:



```php
  $center = new Point2DFloat($pres->getSlideSize()->getSize()->getWidth() / 2, $pres->getSlideSize()->getSize()->getHeight() / 2);
  $width = 300;
  $height = 300;
  $x = $center->getX() - $width / 2;
  $y = $center->getY() - $height / 2;
  # ...
  $watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, $x, $y, $width, $height);

```


## **Image Watermark**
### **Add Image Watermark to Presentation**
To add image watermark into all presentation slides, you may do the following:

```php
  $picture;
  $image = Images->fromFile("watermark.png");
  try {
    $picture = $pres->getImages()->addImage($image);
  } finally {
    if (!java_is_null($image)) {
      $image->dispose();
    }
  }
  # ...
  $watermarkShape->getFillFormat()->setFillType(FillType::Picture);
  $watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
  $watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);

```




## **Lock Watermark from Editing**
If its needed to prevent watermark from editing, use [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape#getShapeLock--) method on the shape, that wraps its. With this method you can protect shape from selection, resize, change position, grouping with other elements, lock its text from editing and many others:

```php
  # Lock Shapes from modifying
  $watermarkShape->getShapeLock()->setSelectLocked(true);
  $watermarkShape->getShapeLock()->setSizeLocked(true);
  $watermarkShape->getShapeLock()->setTextLocked(true);
  $watermarkShape->getShapeLock()->setPositionLocked(true);
  $watermarkShape->getShapeLock()->setGroupingLocked(true);

```

{{% alert color="primary" title="See also" %}} 
- [How to Lock Shapes from Editing](/slides/php-java/presentation-locking/)
{{% /alert %}}

## **Bring Watermark to Front**
In Aspose.Slides the Z-Order of shapes can be set via [**SlideCollection.reorder**](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#reorder-int-com.aspose.slides.ISlide...-) method. For that, you need to call this method from presentation slides list and pass shape reference and its order number into the method. This way its possible to put shape to the front or back of the slide. This feature is especially useful if you need to place watermark on front of presentation:

```php
  $slide->getShapes()->reorder($slide->getShapes()->size() - 1, $watermarkShape);

```


## **Set Watermark Rotation**
Here is an example how to set the rotation of watermark (and its parent shape):

```php
  $h = $pres->getSlideSize()->getSize()->getHeight();
  $w = $pres->getSlideSize()->getSize()->getWidth();
  $watermarkShape->setX($w - $watermarkShape->getWidth() / 2);
  $watermarkShape->setY($h - $watermarkShape->getHeight() / 2);
  $watermarkShape->setRotation(calculateRotation($h, $w));

```

```php

```


## **Set Name to Watermark**
Aspose.Slides allows to set the name of shape. By shape name you can access it in future to modify or delete. To set the name of watermark parent shape - set it into [**AutoShape.getName**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getName--) method:



```php
  $watermarkShape->setName("watermark");

```


## **Remove Watermark**
To remove watermark shape and its child controls from slide, use [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getName--) method to find it in slide shapes. Then pass watermark shape into [**ShapeCollection.remove**](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeCollection#remove-com.aspose.slides.IShape-) method:

```php
  for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
    $shape = $slide->getShapes()->get_Item($i);
    if ("watermark"->equals($shape->getName())) {
      $slide->getShapes()->remove($watermarkShape);
    }
  }
```


## **Live Example**
You may want to check out **Aspose.Slides** **free** [**Add Watermark** ](https://products.aspose.app/slides/watermark) and [**Remove Watermark**](https://products.aspose.app/slides/watermark/remove-watermark) online tools. 

![todo:image_alt_text](slides-watermark.png)
