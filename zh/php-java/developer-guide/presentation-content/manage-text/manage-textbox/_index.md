---
title: 在演示文稿中使用 PHP 管理文本框
linktitle: 管理文本框
type: docs
weight: 20
url: /zh/php-java/manage-textbox/
keywords:
- 文本框
- 文本框架
- 添加文本
- 更新文本
- 创建文本框
- 检查文本框
- 添加文本列
- 添加超链接
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP 让您轻松在 PowerPoint 和 OpenDocument 文件中创建、编辑和克隆文本框，提升演示文稿自动化功能。"
---

幻灯片上的文本通常存在于文本框或形状中。因此，要在幻灯片上添加文本，必须先添加一个文本框，然后在文本框内放入一些文本。Aspose.Slides for PHP via Java 提供了 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 类，允许您添加包含文本的形状。

{{% alert title="Info" color="info" %}}
Aspose.Slides 还提供了 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类，允许您向幻灯片添加形状。不过，并非所有通过 `Shape` 类添加的形状都能容纳文本。但通过 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 类添加的形状可以包含文本。
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
因此，在处理希望添加文本的形状时，您可能需要检查并确认它是通过 `AutoShape` 类转换的。只有这样，您才能使用 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)，它是 `AutoShape` 下的属性。请参阅本页的 [Update Text](/slides/zh/php-java/manage-textbox/#update-text) 部分。
{{% /alert %}}

## **在幻灯片上创建文本框**

要在幻灯片上创建文本框，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
2. 获取新创建的演示文稿中第一张幻灯片的引用。  
3. 在幻灯片的指定位置添加一个形状类型为 [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/#Rectangle) 的 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 对象，并获取新添加的 `AutoShape` 对象的引用。  
4. 向 `AutoShape` 对象添加一个 `TextFrame`，其中将包含文本。在下面的示例中，我们添加了以下文本：*Aspose TextBox*  
5. 最后，通过 `Presentation` 对象写入 PPTX 文件。  

以下 PHP 代码实现了上述步骤，演示了如何向幻灯片添加文本：
```php
  # 实例化 Presentation
  $pres = new Presentation();
  try {
    # 获取演示文稿中的第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加类型为 Rectangle 的 AutoShape
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # 向矩形添加 TextFrame
    $ashp->addTextFrame(" ");
    # 访问文本框架
    $txtFrame = $ashp->getTextFrame();
    # 为文本框架创建 Paragraph 对象
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 为段落创建 Portion 对象
    $portion = $para->getPortions()->get_Item(0);
    # 设置文本
    $portion->setText("Aspose TextBox");
    # 将演示文稿保存到磁盘
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **检查文本框形状**

Aspose.Slides 提供了来自 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 类的 [isTextBox](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/istextbox/) 方法，允许您检查形状并识别文本框。

![Text box and shape](istextbox.png)

以下 PHP 代码展示了如何检查形状是否被创建为文本框：
```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```


请注意，如果仅使用来自 [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) 类的 `addAutoShape` 方法添加自动形状，则该自动形状的 `isTextBox` 方法将返回 `false`。然而，在使用 `addTextFrame` 方法或 `setText` 方法向自动形状添加文本后，`isTextBox` 属性将返回 `true`。
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() 返回 false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() 返回 true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() 返回 false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() 返回 true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() 返回 false
$shape3->addTextFrame("");
// shape3->isTextBox() 返回 false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() 返回 false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() 返回 false
```


## **向文本框添加列**

Aspose.Slides 提供了来自 [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/) 类的 [setColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumncount/) 和 [setColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumnspacing/) 方法，允许您向文本框添加列。您可以指定文本框中的列数并以点为单位设置列间间距。

以下代码演示了上述操作：
```php
  $pres = new Presentation();
  try {
    # 获取演示文稿中的第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加类型为 Rectangle 的 AutoShape
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # 向矩形添加 TextFrame
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # 获取 TextFrame 的文本格式
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # 指定 TextFrame 中的列数
    $format->setColumnCount(3);
    # 指定列间间距
    $format->setColumnSpacing(10);
    # 保存演示文稿
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **向文本框架添加列**

Aspose.Slides for PHP via Java 提供了来自 [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/) 类的 [setColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumncount/) 方法，允许您在文本框架中添加列。通过此属性，您可以指定文本框架中希望的列数。

以下 PHP 代码展示了如何在文本框架中添加列：
```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **更新文本**

Aspose.Slides 允许您更改或更新文本框中的文本或演示文稿中所有文本。

以下 PHP 代码演示了对演示文稿中所有文本进行更新或更改的操作：
```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # 检查形状是否支持文本框 (IAutoShape)。
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # 遍历文本框中的段落
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # 遍历段落中的每个文本片段
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// 更改文本

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// 更改格式

            }
          }
        }
      }
    }
    # 保存修改后的演示文稿
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **向文本框添加超链接**

您可以在文本框内插入链接。单击文本框时，用户将被引导打开该链接。

要添加包含链接的文本框，请按照以下步骤操作：

1. 创建 `Presentation` 类的实例。  
2. 获取新创建的演示文稿中第一张幻灯片的引用。  
3. 在幻灯片的指定位置添加一个 `ShapeType` 为 `Rectangle` 的 `AutoShape` 对象，并获取新添加的 AutoShape 对象的引用。  
4. 向 `AutoShape` 对象添加一个 `TextFrame`，其默认文本为 *Aspose TextBox*。  
5. 实例化 `HyperlinkManager` 类。  
6. 使用与 `TextFrame` 中所选部分关联的 [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) 方法分配超链接。  
7. 最后，通过 `Presentation` 对象写入 PPTX 文件。  

以下 PHP 代码实现了上述步骤，演示了如何向幻灯片添加带有超链接的文本框：
```php
  # 实例化一个表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取演示文稿中的第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加一个类型为 Rectangle 的 AutoShape 对象
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # 将形状强制转换为 AutoShape
    $pptxAutoShape = $shape;
    # 访问与 AutoShape 关联的 ITextFrame 属性
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # 向框架添加一些文本
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # 为该段文本设置超链接
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # 保存 PPTX 演示文稿
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**在使用母版幻灯片时，文本框和文本占位符有什么区别？**  
一个 [placeholder](/slides/zh/php-java/manage-placeholder/) 会继承来自 [master](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) 的样式/位置，并且可以在 [layouts](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) 上进行覆盖，而普通文本框是特定幻灯片上的独立对象，切换布局时不会改变。

**如何在整个演示文稿中批量替换文本而不影响图表、表格和 SmartArt 中的文本？**  
将遍历限定在具有文本框架的自动形状上，并通过分别遍历其集合或跳过这些对象类型，排除嵌入对象（如 [charts](https://reference.aspose.com/slides/php-java/aspose.slides/chart/)、[tables](https://reference.aspose.com/slides/php-java/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)）。