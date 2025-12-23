---
title: 在 PHP 中管理演示文稿缩放
linktitle: 管理缩放
type: docs
weight: 60
url: /zh/php-java/manage-zoom/
keywords:
- 缩放
- 缩放帧
- 幻灯片缩放
- 章节缩放
- 概要缩放
- 添加缩放
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 创建并自定义缩放——在各章节之间跳转，添加缩略图和过渡效果，适用于 PPT、PPTX 和 ODP 演示文稿。"
---

## **概览**
PowerPoint 中的缩放功能允许您在演示文稿的特定幻灯片、章节和内容块之间跳转。当您进行演示时，这种快速导航的能力可能非常有用。

![overview_image](overview.png)

* 要在单个幻灯片上概括整个演示文稿，请使用[概要缩放](#Summary-Zoom)。
* 若只显示选定的幻灯片，请使用[幻灯片缩放](#Slide-Zoom)。
* 若只显示单个章节，请使用[章节缩放](#Section-Zoom)。

## **幻灯片缩放**
幻灯片缩放可以让您的演示更具动态性，允许您以任意顺序在幻灯片之间自由切换，而不会中断演示的节奏。幻灯片缩放非常适合章节不多的短篇演示，但在不同的演示场景中同样可以使用。

幻灯片缩放帮助您在单一画布上深入查看多个信息片段。

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了[ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/ZoomImageType)枚举、[IZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IZoomFrame)接口以及[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)接口下的若干方法。

### **创建缩放帧**

您可以按以下方式在幻灯片上添加缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 创建您打算链接到缩放帧的新幻灯片。  
3. 为创建的幻灯片添加标识文字和背景。  
4. 将缩放帧（包含对创建幻灯片的引用）添加到第一张幻灯片。  
5. 将修改后的演示文稿写入为 PPTX 文件。

以下 PHP 代码演示了如何在幻灯片上创建缩放帧：
```php
  $pres = new Presentation();
  try {
    # 为演示文稿添加新幻灯片
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # 为第二张幻灯片创建背景
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # 为第二张幻灯片创建文本框
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # 为第三张幻灯片创建背景
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # 为第三张幻灯片创建文本框
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # 添加 ZoomFrame 对象
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # 保存演示文稿
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **使用自定义图像创建缩放帧**
使用 Aspose.Slides for PHP via Java，您可以按以下方式创建带有不同幻灯片预览图像的缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 创建您打算链接到缩放帧的新幻灯片。  
3. 为该幻灯片添加标识文字和背景。  
4. 通过向与 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) 对象，用于填充帧。  
5. 将缩放帧（包含对创建幻灯片的引用）添加到第一张幻灯片。  
6. 将修改后的演示文稿写入为 PPTX 文件。

以下 PHP 代码演示了如何使用不同图像创建缩放帧：
```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # 为第二张幻灯片创建背景
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # 为第三张幻灯片创建文本框
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # 为缩放对象创建新图像
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 添加 ZoomFrame 对象
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # 保存演示文稿
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **格式化缩放帧**
在前面的章节中，我们展示了如何创建简单的缩放帧。若要创建更复杂的缩放帧，您需要更改普通帧的格式。可以对缩放帧应用多种格式设置。

您可以按以下方式控制幻灯片上缩放帧的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 创建您打算链接到缩放帧的新幻灯片。  
3. 为创建的幻灯片添加一些标识文字和背景。  
4. 将缩放帧（包含对创建幻灯片的引用）添加到第一张幻灯片。  
5. 通过向与 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) 对象，用于填充帧。  
6. 为第一个缩放帧对象设置自定义图像。  
7. 更改第二个缩放帧对象的线条格式。  
8. 删除第二个缩放帧对象图像的背景。  
9. 将修改后的演示文稿写入为 PPTX 文件。

以下 PHP 代码演示了如何在幻灯片上更改缩放帧的格式：
```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # 为第二张幻灯片创建背景
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # 为第二张幻灯片创建文本框
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # 为第三张幻灯片创建背景
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # 为第三张幻灯片创建文本框
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # 添加 ZoomFrame 对象
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # 为缩放对象创建新图像
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 为 zoomFrame1 对象设置自定义图像
    $zoomFrame1->setImage($picture);
    # 为 zoomFrame2 对象设置缩放帧格式
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # 为 zoomFrame2 对象设置不显示背景
    $zoomFrame2->setShowBackground(false);
    # 保存演示文稿
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **章节缩放**

章节缩放是指向演示文稿中某个章节的链接。您可以使用章节缩放返回您希望特别强调的章节，或者用于突出展示演示文稿中各部分之间的关联。

![overview_image](seczoomsel.png)

对于章节缩放对象，Aspose.Slides 提供了[ISectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionZoomFrame)接口以及[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)接口下的若干方法。

### **创建章节缩放帧**

您可以按以下方式在幻灯片上添加章节缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 创建一张新幻灯片。  
3. 为创建的幻灯片添加标识背景。  
4. 创建您打算链接到缩放帧的新章节。  
5. 将章节缩放帧（包含对创建章节的引用）添加到第一张幻灯片。  
6. 将修改后的演示文稿写入为 PPTX 文件。

以下 PHP 代码演示了如何在幻灯片上创建缩放帧：
```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新章节
    $pres->getSections()->addSection("Section 1", $slide);
    # 添加 SectionZoomFrame 对象
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # 保存演示文稿
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **使用自定义图像创建章节缩放帧**

使用 Aspose.Slides for PHP via Java，您可以按以下方式创建带有不同幻灯片预览图像的章节缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 创建一张新幻灯片。  
3. 为创建的幻灯片添加标识背景。  
4. 创建您打算链接到缩放帧的新章节。  
5. 通过向与 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) 对象，用于填充帧。  
6. 将章节缩放帧（包含对创建章节的引用）添加到第一张幻灯片。  
7. 将修改后的演示文稿写入为 PPTX 文件。

以下 PHP 代码演示了如何使用不同图像创建章节缩放帧：
```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新章节
    $pres->getSections()->addSection("Section 1", $slide);
    # 为缩放对象创建新图像
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 添加 SectionZoomFrame 对象
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # 保存演示文稿
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **格式化章节缩放帧**

要创建更复杂的章节缩放帧，您需要更改普通帧的格式。可以对章节缩放帧应用多种格式设置。

您可以按以下方式控制幻灯片上章节缩放帧的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 创建一张新幻灯片。  
3. 为创建的幻灯片添加标识背景。  
4. 创建您打算链接到缩放帧的新章节。  
5. 将章节缩放帧（包含对创建章节的引用）添加到第一张幻灯片。  
6. 更改创建的章节缩放对象的大小和位置。  
7. 通过向与 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) 对象，用于填充帧。  
8. 为创建的章节缩放帧对象设置自定义图像。  
9. 设置*从链接章节返回原始幻灯片*的功能。  
10. 删除章节缩放帧对象图像的背景。  
11. 更改第二个缩放帧对象的线条格式。  
12. 更改切换持续时间。  
13. 将修改后的演示文稿写入为 PPTX 文件。

以下 PHP 代码演示了如何更改章节缩放帧的格式：
```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新章节
    $pres->getSections()->addSection("Section 1", $slide);
    # 添加 SectionZoomFrame 对象
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # 为 SectionZoomFrame 设置格式
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # 保存演示文稿
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **概要缩放**

概要缩放类似于一个登录页，所有演示文稿的片段一次性展示。当您进行演示时，可以使用概要缩放从演示文稿的任意位置跳转到其他位置，顺序完全由您决定。您可以随意创意跳转、快进或回顾幻灯片内容，而不会中断演示的流畅性。

![overview_image](sumzoomsel.png)

对于概要缩放对象，Aspose.Slides 提供了[ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomFrame)、[ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection)以及[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection)接口，并在[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)接口下提供了若干方法。

### **创建概要缩放**

您可以按以下方式在幻灯片上添加概要缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 为新创建的幻灯片添加标识背景，并为其创建新章节。  
3. 将概要缩放帧添加到第一张幻灯片。  
4. 将修改后的演示文稿写入为 PPTX 文件。

以下 PHP 代码演示了如何在幻灯片上创建概要缩放帧：
```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新章节
    $pres->getSections()->addSection("Section 1", $slide);
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新章节
    $pres->getSections()->addSection("Section 2", $slide);
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新章节
    $pres->getSections()->addSection("Section 3", $slide);
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新章节
    $pres->getSections()->addSection("Section 4", $slide);
    # 添加 SummaryZoomFrame 对象
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # 保存演示文稿
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **添加和移除概要缩放章节**

概要缩放帧中的所有章节都由[ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection)对象表示，这些对象存储在[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection)对象中。您可以通过[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection)接口按以下方式添加或移除章节对象：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 为新创建的幻灯片添加标识背景，并为其创建新章节。  
3. 将概要缩放帧添加到第一张幻灯片。  
4. 向演示文稿中添加新幻灯片和章节。  
5. 将创建的章节添加到概要缩放帧中。  
6. 从概要缩放帧中移除第一章节。  
7. 将修改后的演示文稿写入为 PPTX 文件。

以下 PHP 代码演示了如何在概要缩放帧中添加和移除章节：
```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新章节
    $pres->getSections()->addSection("Section 1", $slide);
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新章节
    $pres->getSections()->addSection("Section 2", $slide);
    # 添加 SummaryZoomFrame 对象
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新章节
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # 向 Summary Zoom 添加章节
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # 从 Summary Zoom 移除章节
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # 保存演示文稿
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **格式化概要缩放章节**

要创建更复杂的概要缩放章节对象，您需要更改普通帧的格式。可以对概要缩放章节对象应用多种格式设置。

您可以按以下方式控制概要缩放帧中章节对象的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 为新创建的幻灯片添加标识背景，并为其创建新章节。  
3. 将概要缩放帧添加到第一张幻灯片。  
4. 从 `ISummaryZoomSectionCollection` 中获取第一对象的概要缩放章节对象。  
5. 通过向与 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象关联的 images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) 对象，用于填充帧。  
6. 为创建的章节缩放帧对象设置自定义图像。  
7. 设置*从链接章节返回原始幻灯片*的功能。  
8. 更改第二个缩放帧对象的线条格式。  
9. 更改切换持续时间。  
10. 将修改后的演示文稿写入为 PPTX 文件。

以下 PHP 代码演示了如何更改概要缩放章节对象的格式：
```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新章节
    $pres->getSections()->addSection("Section 1", $slide);
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新章节
    $pres->getSections()->addSection("Section 2", $slide);
    # 添加 SummaryZoomFrame 对象
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # 获取第一个 SummaryZoomSection 对象
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # 为 SummaryZoomSection 对象设置格式
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # 保存演示文稿
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**我可以控制在显示目标后返回“父”幻灯片吗？**

可以。[Zoom frame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/)或[section](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/)具有 `ReturnToParent` 行为，启用后会在观看者访问目标内容后返回到源幻灯片。

**我可以调整缩放切换的“速度”或持续时间吗？**

可以。Zoom 支持设置 `TransitionDuration`，以便您控制跳转动画的时长。

**演示文稿中可以包含多少个 Zoom 对象有上限吗？**

官方文档未记录硬性 API 限制。实际限制取决于演示文稿的整体复杂度以及观看者的性能。您可以添加很多 Zoom 帧，但需考虑文件大小和渲染时间。