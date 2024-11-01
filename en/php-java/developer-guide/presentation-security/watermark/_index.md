---
title: Watermark
type: docs
weight: 40
url: /php-java/watermark/
keywords:
- watermark
- add watermark
- text watermark
- image watermark
- PowerPoint
- presentation
- PHP
- Java
- Aspose.Slides for PHP via Java
description: "Add text and image watermarks to PowerPoint presentations in PHP"
---

## **About Watermarks**

**A watermark** in a presentation is a text or image stamp used on a slide or throughout all presentation slides. Usually, a watermark is used to indicate that the presentation is a draft (e.g., a "Draft" watermark), that it contains confidential information (e.g., a "Confidential" watermark), to specify which company it belongs to (e.g., a "Company Name" watermark), to identify the presentation author, etc. A watermark helps to prevent copyright violations by indicating that the presentation should not be copied. Watermarks are used in both PowerPoint and OpenOffice presentation formats. In Aspose.Slides, you can add a watermark to PowerPoint PPT, PPTX, and OpenOffice ODP file formats.

In [**Aspose.Slides**](https://products.aspose.com/slides/php-java/), there are various ways you can create watermarks in PowerPoint or OpenOffice documents and modify their design and behavior. The common aspect is that to add text watermarks, you should use the [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) class, and to add image watermarks, use the [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) class or fill a watermark shape with an image. `PictureFrame` implements the [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) class, allowing you to use all the flexible settings of the shape object. Since `ITextFrame` is not a shape and its settings are limited, it is wrapped into an [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) object.

There are two ways a watermark can be applied: to a single slide or to all presentation slides. The Slide Master is used to apply a watermark to all presentation slides — the watermark is added to the Slide Master, fully designed there, and applied to all slides without affecting the permission to modify the watermark on individual slides.

A watermark is usually considered to be unavailable for editing by other users. To prevent the watermark (or rather the watermark's parent shape) from being edited, Aspose.Slides provides shape locking functionality. A specific shape can be locked on a normal slide or on a Slide Master. When the watermark shape is locked on the Slide Master, it will be locked on all presentation slides.

You can set a name for the watermark so that in the future, if you want to delete it, you can find it in the slide's shapes by name.

You can design the watermark in any way; however, there are usually common features in watermarks, such as center alignment, rotation, front position, etc. We will consider how to use these in the examples below.

## **Text Watermark**

### **Add a Text Watermark to a Slide**

To add a text watermark in PPT, PPTX, or ODP, you can first add a shape to the slide, then add a text frame to this shape. The text frame is represented by the [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) class. This type is not inherited from [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), which has a wide set of properties for positioning the watermark in a flexible way. Therefore, the [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) object is wrapped in an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) object. To add watermark text to the shape, use the [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) method as shown below.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/php-java/text-formatting/)
{{% /alert %}}

### **Add a Text Watermark to a Presentation**

If you want to add a text watermark to the entire presentation (i.e., all slides at once), add it to the [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). The rest of the logic is the same as when adding a watermark to a single slide — create an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) object and then add the watermark to it using the [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) method.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/php-java/slide-master/)
{{% /alert %}}

### **Set Watermark Shape Transparency**

By default, the rectangle shape is styled with fill and line colors. The following lines of code make the shape transparent.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Set the Font for a Text Watermark**

You can change the font of the text watermark as shown below.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Set the Watermark Text Color**

To set the color of the watermark text, use this code:

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **Center a Text Watermark**

It is possible to center the watermark on a slide, and for that, you can do the following:

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

The image below shows the final result.

![The text watermark](text_watermark.png)

## **Image Watermark**

### **Add an Image Watermark to a Presentation**

To add an image watermark to a presentation slide, you can do the following:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **Lock a Watermark from Editing**

If it is necessary to prevent a watermark from being edited, use the [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) method on the shape. With this property, you can protect the shape from being selected, resized, repositioned, grouped with other elements, lock its text from editing, and much more:

```php
// Lock the watermark shape from modifying
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **Bring a Watermark to Front**

In Aspose.Slides, the Z-order of shapes can be set via the [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder) method. To do this, you need to call this method from the presentation slides list and pass the shape reference and its order number into the method. This way, it is possible to bring a shape to the front or send it to the back of the slide. This feature is especially useful if you need to place a watermark in front of the presentation:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **Set Watermark Rotation**

Here is a code example of how to adjust the rotation of the watermark so that it is positioned diagonally across the slide:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **Set a Name for a Watermark**

Aspose.Slides allows you to set the name of a shape. By using the shape name, you can access it in the future to modify or delete it. To set the name of the watermark shape, assign it to the [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName) method:

```php
$watermarkShape->setName("watermark");
```

### **Remove a Watermark**

To remove the watermark shape, use the [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName) method to find it in the slide shapes. Then, pass the watermark shape into the [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove) method:

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```
