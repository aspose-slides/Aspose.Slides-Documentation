---
title: 管理 PHP 中的演示文稿缩放
linktitle: 管理缩放
type: docs
weight: 60
url: /zh/php-java/manage-zoom/
keywords:
- 缩放
- 缩放框架
- 幻灯片缩放
- 章节缩放
- 摘要缩放
- 添加缩放
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 创建和自定义缩放 —— 在章节之间跳转，在 PPT、PPTX 和 ODP 演示文稿中添加缩略图和过渡效果。"
---

## **概述**
PowerPoint 中的缩放功能允许您在演示文稿的特定幻灯片、章节和部分之间跳转。当您进行演示时，这种快速跨内容导航的能力可能非常有用。

![overview_image](overview.png)

* 要在单张幻灯片上概括整个演示文稿，请使用[Summary Zoom](#Summary-Zoom)。
* 只显示选定的幻灯片，请使用[Slide Zoom](#Slide-Zoom)。
* 只显示单个章节，请使用[Section Zoom](#Section-Zoom)。

## **幻灯片缩放**
幻灯片缩放可以使您的演示更加生动，允许您在任意顺序自由地在幻灯片之间跳转，而不会中断演示的流程。幻灯片缩放非常适合章节不多的短篇演示，但您仍可在各种演示场景中使用它们。

幻灯片缩放帮助您深入多个信息块，同时保持在同一画布上的感觉。

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了 [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/zoomimagetype/) 枚举、[ZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) 类以及 [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) 类下的一些方法。

### **创建缩放框架**
您可以按照以下方式在幻灯片上添加缩放框架：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 创建您打算链接缩放框架的新幻灯片。
3. 为创建的幻灯片添加标识文本和背景。
4. 向第一张幻灯片添加缩放框架（包含对已创建幻灯片的引用）。
5. 将修改后的演示文稿写入为 PPTX 文件。

下面的 PHP 代码展示了如何在幻灯片上创建缩放框架：
```php
  $pres = new Presentation();
  try {
    # 添加新的幻灯片到演示文稿
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


### **使用自定义图像创建缩放框架**
使用 Aspose.Slides for PHP via Java，您可以按以下方式创建具有不同幻灯片预览图像的缩放框架：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 创建一个您打算链接缩放框架的新幻灯片。 
3. 为幻灯片添加标识文本和背景。
4. 通过向与 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 对象关联的 Images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 对象，以用于填充框架。
5. 向第一张幻灯片添加缩放框架（包含对已创建幻灯片的引用）。
6. 将修改后的演示文稿写入为 PPTX 文件。

下面的 PHP 代码展示了如何使用不同的图像创建缩放框架：
```php
  $pres = new Presentation();
  try {
    # 添加一个新的幻灯片到演示文稿
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


### **格式化缩放框架**
在前面的章节中，我们展示了如何创建简单的缩放框架。要创建更复杂的缩放框架，您必须更改简单框架的格式。您可以对缩放框架应用多种格式选项。

您可以按照以下方式在幻灯片上控制缩放框架的格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 创建您打算链接缩放框架的新幻灯片。
3. 为创建的幻灯片添加一些标识文本和背景。
4. 向第一张幻灯片添加缩放框架（包含对已创建幻灯片的引用）。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 对象关联的 Images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 对象，以用于填充框架。
6. 为第一个缩放框架对象设置自定义图像。
7. 更改第二个缩放框架对象的线条格式。
8. 移除第二个缩放框架对象图像的背景。
9. 将修改后的演示文稿写入为 PPTX 文件。

下面的 PHP 代码展示了如何在幻灯片上更改缩放框架的格式：
```php
  $pres = new Presentation();
  try {
    # 添加新幻灯片到演示文稿
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
    # 为 zoomFrame2 对象设置缩放框架格式
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # 设置 zoomFrame2 对象不显示背景
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
章节缩放是指向您演示文稿中某个章节的链接。您可以使用章节缩放返回到您想特别强调的章节，或用来突出演示文稿中某些部分之间的关联。

![overview_image](seczoomsel.png)

对于章节缩放对象，Aspose.Slides 提供了 [SectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) 类以及 [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) 类下的一些方法。

### **创建章节缩放框架**
您可以按照以下方式向幻灯片添加章节缩放框架：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 创建一个新幻灯片。 
3. 为创建的幻灯片添加标识背景。
4. 创建一个您打算链接缩放框架的新章节。 
5. 向第一张幻灯片添加章节缩放框架（包含对已创建章节的引用）。
6. 将修改后的演示文稿写入为 PPTX 文件。

下面的 PHP 代码展示了如何在幻灯片上创建缩放框架：
```php
  $pres = new Presentation();
  try {
    # 添加一个新的幻灯片到演示文稿
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加一个新章节
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


### **使用自定义图像创建章节缩放框架**
使用 Aspose.Slides for PHP via Java，您可以按以下方式创建具有不同幻灯片预览图像的章节缩放框架：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 创建一个新幻灯片。
3. 为创建的幻灯片添加标识背景。
4. 创建一个您打算链接缩放框架的新章节。 
5. 通过向与 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 对象关联的 Images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 对象，以用于填充框架。
6. 向第一张幻灯片添加章节缩放框架（包含对已创建章节的引用）。
7. 将修改后的演示文稿写入为 PPTX 文件。

下面的 PHP 代码展示了如何使用不同的图像创建缩放框架：
```php
  $pres = new Presentation();
  try {
    # 添加新的幻灯片到演示文稿
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 添加一个新章节到演示文稿
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


### **格式化章节缩放框架**
要创建更复杂的章节缩放框架，您必须更改简单框架的格式。您可以对章节缩放框架应用多种格式选项。

您可以按照以下方式在幻灯片上控制章节缩放框架的格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 创建一个新幻灯片。
3. 为创建的幻灯片添加标识背景。
4. 创建一个您打算链接缩放框架的新章节。 
5. 向第一张幻灯片添加章节缩放框架（包含对已创建章节的引用）。
6. 更改已创建章节缩放对象的大小和位置。
7. 通过向与 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 对象关联的 images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 对象，以用于填充框架。
8. 为已创建的章节缩放框架对象设置自定义图像。
9. 设置*从链接章节返回原始幻灯片*的功能。
10. 移除章节缩放框架对象图像的背景。
11. 更改第二个缩放框架对象的线条格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿写入为 PPTX 文件。

下面的 PHP 代码展示了如何更改章节缩放框架的格式：
```php
  $pres = new Presentation();
  try {
    # 添加一个新幻灯片到演示文稿
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加一个新章节
    $pres->getSections()->addSection("Section 1", $slide);
    # 添加 SectionZoomFrame 对象
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # SectionZoomFrame 的格式设置
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


## **摘要缩放**
摘要缩放类似于一个着陆页，展示您演示文稿的所有部分。当您进行演示时，可以使用缩放在演示的任意位置之间跳转，顺序随意。您可以发挥创意，提前跳过或重新访问幻灯片的各个部分，而不会中断演示的流程。

![overview_image](sumzoomsel.png)

对于摘要缩放对象，Aspose.Slides 提供了 [SummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/), [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) 类以及 [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) 类下的一些方法。

### **创建摘要缩放**
您可以按照以下方式向幻灯片添加摘要缩放框架：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 为创建的幻灯片创建带有标识背景和新章节的幻灯片。
3. 将摘要缩放框架添加到第一张幻灯片。
4. 将修改后的演示文稿写入为 PPTX 文件。

下面的 PHP 代码展示了如何在幻灯片上创建摘要缩放框架：
```php
  $pres = new Presentation();
  try {
    # 添加一个新幻灯片到演示文稿
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加一个新章节
    $pres->getSections()->addSection("Section 1", $slide);
    # 添加一个新幻灯片到演示文稿
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加一个新章节
    $pres->getSections()->addSection("Section 2", $slide);
    # 添加一个新幻灯片到演示文稿
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加一个新章节
    $pres->getSections()->addSection("Section 3", $slide);
    # 添加一个新幻灯片到演示文稿
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加一个新章节
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


### **添加和移除摘要缩放章节**
摘要缩放框架中的所有章节均由 [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) 对象表示，这些对象存储在 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) 中。您可以通过以下方式使用 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) 类添加或移除摘要缩放章节对象：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 为创建的幻灯片创建带有标识背景和新章节的幻灯片。
3. 将摘要缩放框架添加到第一张幻灯片中。
4. 向演示文稿中添加新的幻灯片和章节。
5. 将已创建的章节添加到摘要缩放框架中。
6. 从摘要缩放框架中移除第一章节。
7. 将修改后的演示文稿写入为 PPTX 文件。

下面的 PHP 代码展示了如何在摘要缩放框架中添加和移除章节：
```php
  $pres = new Presentation();
  try {
    # 添加一个新幻灯片到演示文稿
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 添加一个新章节到演示文稿
    $pres->getSections()->addSection("Section 1", $slide);
    # 添加一个新幻灯片到演示文稿
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 添加一个新章节到演示文稿
    $pres->getSections()->addSection("Section 2", $slide);
    # 添加 SummaryZoomFrame 对象
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # 添加一个新幻灯片到演示文稿
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 添加一个新章节到演示文稿
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


### **格式化摘要缩放章节**
要创建更复杂的摘要缩放章节对象，您必须更改简单框架的格式。您可以对摘要缩放章节对象应用多种格式选项。

您可以按照以下方式在摘要缩放框架中控制摘要缩放章节对象的格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 为创建的幻灯片创建带有标识背景和新章节的幻灯片。
3. 将摘要缩放框架添加到第一张幻灯片。
4. 从 `SummaryZoomSectionCollection` 中获取第一个对象的摘要缩放章节对象。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 对象关联的 images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 对象，以用于填充框架。
6. 为已创建的章节缩放框架对象设置自定义图像。
7. 设置*从链接章节返回原始幻灯片*的功能。
8. 更改第二个缩放框架对象的线条格式。
9. 更改过渡持续时间。
10. 将修改后的演示文稿写入为 PPTX 文件。

下面的 PHP 代码展示了如何更改摘要缩放章节对象的格式：
```php
  $pres = new Presentation();
  try {
    # 添加一个新幻灯片到演示文稿
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 添加一个新章节到演示文稿
    $pres->getSections()->addSection("Section 1", $slide);
    # 添加一个新幻灯片到演示文稿
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 添加一个新章节到演示文稿
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

是的。[Zoom frame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) 或 [section](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) 具有 `ReturnToParent` 行为，启用后会在观看者浏览目标内容后将其返回到原始幻灯片。

**我可以调整缩放过渡的“速度”或持续时间吗？**

是的。Zoom 支持设置 `TransitionDuration`，您可以控制跳转动画的时长。

**演示文稿中可以包含的 Zoom 对象数量有限制吗？**

文档中未列出硬性 API 限制。实际限制取决于整体演示的复杂度和观看者的性能。您可以添加大量 Zoom 框，但需要考虑文件大小和渲染时间。