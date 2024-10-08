---
title: 管理缩放
type: docs
weight: 60
url: /php-java/manage-zoom/
keywords: "缩放, 缩放框, 添加缩放, 格式化缩放框, 概要缩放, PowerPoint演示文稿, Java, Aspose.Slides for PHP via Java"
description: "向PowerPoint演示文稿中添加缩放或缩放框"
---

## **概述**
PowerPoint中的缩放功能允许您跳转到特定的幻灯片、部分和演示文稿片段。在演示时，这种快速导航内容的能力可能会非常有用。

![overview_image](overview.png)

* 要在单个幻灯片上总结整个演示文稿，请使用[概要缩放](#Summary-Zoom)。
* 要仅显示选定的幻灯片，请使用[幻灯片缩放](#Slide-Zoom)。
* 要仅显示单个部分，请使用[部分缩放](#Section-Zoom)。

## **幻灯片缩放**
幻灯片缩放可以使您的演示文稿更加动态，使您能够在任何选择的顺序中自由导航幻灯片，而不会中断演示的流畅度。幻灯片缩放非常适合于没有很多部分的短演示，但您仍然可以在不同的演示场景中使用它们。

幻灯片缩放帮助您深入多个信息片段，同时让您感觉您是在单一画布上。

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides提供了[ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/ZoomImageType)枚举、[IZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IZoomFrame)接口以及一些在[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)接口下的方法。

### **创建缩放框**

您可以按以下方式在幻灯片上添加缩放框：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 创建您打算链接缩放框的新幻灯片。
3. 向创建的幻灯片添加标识文本和背景。
4. 将包含对所创建幻灯片的引用的缩放框添加到第一张幻灯片上。
5. 将修改后的演示文稿写入PPTX文件。

以下PHP代码向您展示了如何在幻灯片上创建缩放框：

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
    $autoshape->getTextFrame()->setText("第二张幻灯片");
    # 为第三张幻灯片创建背景
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # 为第三张幻灯片创建文本框
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("第三张幻灯片");
    # 添加ZoomFrame对象
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
### **使用自定义图像创建缩放框**
使用Aspose.Slides for PHP via Java，您可以按以下方式使用不同的幻灯片预览图像创建缩放框：
1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 创建您打算链接到缩放框的新幻灯片。
3. 向幻灯片添加标识文本和背景。
4. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)对象关联的图像集合中，创建[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)对象，该对象将用于填充框。
5. 将包含对所创建幻灯片的引用的缩放框添加到第一张幻灯片上。
6. 将修改后的演示文稿写入PPTX文件。

以下PHP代码向您展示了如何用不同的图像创建缩放框：

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
    $autoshape->getTextFrame()->setText("第二张幻灯片");
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
    # 添加ZoomFrame对象
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
### **格式化缩放框**
在前面的部分中，我们向您展示了如何创建简单的缩放框。要创建更复杂的缩放框，您必须改变简单框架的格式。您可以对缩放框应用多种格式化选项。

您可以按以下方式控制幻灯片上缩放框的格式：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 创建新的幻灯片与您打算链接的缩放框。
3. 向创建的幻灯片添加一些标识文本和背景。
4. 将包含对所创建幻灯片的引用的缩放框添加到第一张幻灯片上。
5. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)对象关联的图像集合中，创建[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)对象，该对象将用于填充框。
6. 为第一个缩放框对象设置自定义图像。
7. 更改第二个缩放框对象的线格式。
8. 从第二个缩放框对象的图像中移除背景。
5. 将修改后的演示文稿写入PPTX文件。

以下PHP代码向您展示了如何更改幻灯片上的缩放框格式：

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
    $autoshape->getTextFrame()->setText("第二张幻灯片");
    # 为第三张幻灯片创建背景
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # 为第三张幻灯片创建文本框
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("第三张幻灯片");
    # 添加ZoomFrame对象
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
    # 为zoomFrame1对象设置自定义图像
    $zoomFrame1->setImage($picture);
    # 为zoomFrame2对象设置缩放框格式
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # 设置不显示zoomFrame2对象的背景
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

## **部分缩放**

部分缩放是指向您演示文稿中某个部分的链接。您可以使用部分缩放返回到您想要真正强调的部分。或者，您可以使用它们来突出显示您演示的某些部分之间的连接。

![overview_image](seczoomsel.png)

对于部分缩放对象，Aspose.Slides提供了[ISectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionZoomFrame)接口和一些在[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)接口下的方法。

### **创建部分缩放框**

您可以按以下方式在幻灯片上添加部分缩放框：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 创建一张新幻灯片。
3. 向创建的幻灯片添加标识背景。
4. 创建您打算链接到缩放框的新部分。
5. 将包含对所创建部分的引用的部分缩放框添加到第一张幻灯片上。
6. 将修改后的演示文稿写入PPTX文件。

以下PHP代码向您展示了如何在幻灯片上创建一个缩放框：

```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新部分
    $pres->getSections()->addSection("部分 1", $slide);
    # 添加SectionZoomFrame对象
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # 保存演示文稿
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **使用自定义图像创建部分缩放框**

使用Aspose.Slides for PHP via Java，您可以按以下方式使用不同的幻灯片预览图像创建部分缩放框：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 创建一张新幻灯片。
3. 向创建的幻灯片添加标识背景。
4. 创建您打算链接到缩放框的新部分。
5. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)对象关联的图像集合中，创建[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)对象，该对象将用于填充框。
5. 将包含对所创建部分的引用的部分缩放框添加到第一张幻灯片上。
6. 将修改后的演示文稿写入PPTX文件。

以下PHP代码向您展示了如何用不同的图像创建部分缩放框：

```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新部分
    $pres->getSections()->addSection("部分 1", $slide);
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
    # 添加SectionZoomFrame对象
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
### **格式化部分缩放框**

要创建更复杂的部分缩放框，您必须改变简单框架的格式。您可以对部分缩放框应用多种格式化选项。

您可以按以下方式控制幻灯片上部分缩放框的格式：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 创建一张新幻灯片。
3. 向创建的幻灯片添加标识背景。
4. 创建您打算链接到缩放框的新部分。
5. 将包含对所创建部分的引用的部分缩放框添加到第一张幻灯片上。
6. 更改创建的部分缩放对象的大小和位置。
7. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)对象关联的图像集合中，创建[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)对象，该对象将用于填充框。
8. 为创建的部分缩放框对象设置自定义图像。
9. 设置*从链接部分返回到原始幻灯片*的能力。
10. 从部分缩放框对象的图像中移除背景。
11. 更改第二个缩放框对象的线格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿写入PPTX文件。

以下PHP代码向您展示了如何更改部分缩放框的格式：

```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新部分
    $pres->getSections()->addSection("部分 1", $slide);
    # 添加SectionZoomFrame对象
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # 对SectionZoomFrame格式进行设置
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

概要缩放就像一个着陆页，所有演示文稿的部分都被一次性显示。当您演示时，您可以使用缩放功能从演示文稿中的一个地方转移到另一个地方，按照您喜欢的任何顺序。您可以进行创意跳跃，提前，或重新访问幻灯片秀的某些部分，而不会中断演示的流畅度。

![overview_image](sumzoomsel.png)

对于概要缩放对象，Aspose.Slides提供了[ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomFrame)、[ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection)和[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection)接口，以及[IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection)接口下的一些方法。

### **创建概要缩放**

您可以按以下方式向幻灯片添加概要缩放框：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 创建带有标识背景的新幻灯片，并为创建的幻灯片创建新部分。
3. 将概要缩放框添加到第一张幻灯片上。
4. 将修改后的演示文稿写入PPTX文件。

以下PHP代码向您展示了如何在幻灯片上创建概要缩放框：

```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新部分
    $pres->getSections()->addSection("部分 1", $slide);
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新部分
    $pres->getSections()->addSection("部分 2", $slide);
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新部分
    $pres->getSections()->addSection("部分 3", $slide);
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新部分
    $pres->getSections()->addSection("部分 4", $slide);
    # 添加SummaryZoomFrame对象
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # 保存演示文稿
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **添加和移除概要缩放部分**

概要缩放框中的所有部分由[ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection)对象表示，这些对象存储在[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection)对象中。您可以通过[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection)接口添加或移除概要缩放部分对象，方法如下：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 创建带有标识背景的新幻灯片，并为创建的幻灯片创建新部分。
3. 将概要缩放框放入第一张幻灯片中。
4. 添加新幻灯片和新部分到演示文稿。
5. 将创建的部分添加到概要缩放框中。
6. 从概要缩放框中移除第一部分。
7. 将修改后的演示文稿写入PPTX文件。

以下PHP代码向您展示了如何在概要缩放框中添加和移除部分：

```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新部分
    $pres->getSections()->addSection("部分 1", $slide);
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新部分
    $pres->getSections()->addSection("部分 2", $slide);
    # 添加SummaryZoomFrame对象
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新部分
    $section3 = $pres->getSections()->addSection("部分 3", $slide);
    # 向概要缩放中添加部分
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # 从概要缩放中移除部分
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # 保存演示文稿
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **格式化概要缩放部分**

要创建更复杂的概要缩放部分对象，您必须改变简单框架的格式。您可以对概要缩放部分对象应用多种格式化选项。

您可以按以下方式控制概要缩放框中概要缩放部分对象的格式：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 创建带有标识背景的新幻灯片，并为创建的幻灯片创建新部分。
3. 将概要缩放框添加到第一张幻灯片。
4. 从`ISummaryZoomSectionCollection`中获取第一个概要缩放部分对象。
7. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)对象关联的图像集合中，创建[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage)对象，该对象将用于填充框。
8. 为创建的部分缩放框对象设置自定义图像。
9. 设置*从链接部分返回到原始幻灯片*的能力。
11. 更改第二个缩放框对象的线格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿写入PPTX文件。

以下PHP代码向您展示了如何更改概要缩放部分对象的格式：

```php
  $pres = new Presentation();
  try {
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新部分
    $pres->getSections()->addSection("部分 1", $slide);
    # 向演示文稿添加新幻灯片
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # 向演示文稿添加新部分
    $pres->getSections()->addSection("部分 2", $slide);
    # 添加SummaryZoomFrame对象
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # 获取第一个SummaryZoomSection对象
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # 对SummaryZoomSection对象的格式进行设置
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