---
title: 使用 PHP 在演示文稿中管理 SmartArt 形状节点
linktitle: SmartArt 形状节点
type: docs
weight: 30
url: /zh/php-java/manage-smartart-shape-node/
keywords:
- SmartArt 节点
- 子节点
- 添加节点
- 节点位置
- 访问节点
- 移除节点
- 自定义位置
- 助理节点
- 填充格式
- 渲染节点
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 管理 PPT 和 PPTX 中的 SmartArt 形状节点。获取清晰的代码示例和技巧，以简化您的演示文稿。"
---

## **添加 SmartArt 节点**
Aspose.Slides for PHP via Java 提供了最简便的 API 来管理 SmartArt 形状。以下示例代码演示了如何在 SmartArt 形状中添加节点和子节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 通过索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 类型，并在是 SmartArt 时将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)。
1. 在 SmartArt 形状的 **NodeCollection** [https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#getAllNodes--](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#getAllNodes--) 中 [添加新节点](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) 并在 TextFrame 中设置文本。
1. 现在，在新添加的 SmartArt 节点中 [添加](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) **子节点** [https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) 并在 TextFrame 中设置文本。
1. 保存演示文稿。
```php
  # 加载所需的演示文稿
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 遍历第一张幻灯片中的所有形状
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArt
        $smart = $shape;
        # 添加新的 SmartArt 节点
        $TemNode = $smart->getAllNodes()->addNode();
        # 添加文本
        $TemNode->getTextFrame()->setText("Test");
        # 在父节点中添加新的子节点。它将被添加到集合的末尾
        $newNode = $TemNode->getChildNodes()->addNode();
        # 添加文本
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # 保存演示文稿
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **在特定位置添加 SmartArt 节点**
在下面的示例代码中，我们说明了如何在特定位置向 SmartArt 形状的相应节点添加子节点。

1. 创建 Presentation 类的实例。
1. 通过索引获取第一张幻灯片的引用。
1. 在该幻灯片中添加一种 [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) 类型的 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 形状。
1. 访问已添加 SmartArt 形状中的第一个节点。
1. 现在，为选定的 **节点** 在位置 2 添加 **子节点** [https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) 并设置其文本。
1. 保存演示文稿。
```php
  # 创建演示文稿实例
  $pres = new Presentation();
  try {
    # 访问演示文稿幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加 Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # 访问索引 0 处的 SmartArt 节点
    $node = $smart->getAllNodes()->get_Item(0);
    # 在父节点中在位置 2 添加新的子节点
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # 添加文本
    $chNode->getTextFrame()->setText("Sample Text Added");
    # 保存演示文稿
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **访问 SmartArt 节点**
以下示例代码帮助访问 SmartArt 形状中的节点。请注意，SmartArt 的 LayoutType 为只读，且仅在添加 SmartArt 形状时设置。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 通过索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 类型，并在是 SmartArt 时将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)。
1. 遍历 SmartArt 形状内部的所有 **节点** [https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--)。
1. 访问并显示诸如 SmartArt 节点位置、层级和文本等信息。
```php
  # 实例化 Presentation 类
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 遍历第一张幻灯片中的所有形状
    foreach($slide->getShapes() as $shape) {
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArt
        $smart = $shape;
        # 遍历 SmartArt 中的所有节点
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # 访问索引 i 处的 SmartArt 节点
          $node = $smart->getAllNodes()->get_Item($i);
          # 打印 SmartArt 节点参数
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **访问 SmartArt 子节点**
以下示例代码帮助访问 SmartArt 形状中各节点的子节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 通过索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 类型，并在是 SmartArt 时将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)。
1. 遍历 SmartArt 形状内部的所有 **节点** [https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--)。
1. 对于每个选定的 SmartArt **节点**，遍历该节点内部的所有 **子节点** [https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--)。
1. 访问并显示诸如 **子节点** 位置、层级和文本等信息。
```php
  # 实例化 Presentation 类
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 遍历第一张幻灯片中的所有形状
    foreach($slide->getShapes() as $shape) {
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArt
        $smart = $shape;
        # 遍历 SmartArt 中的所有节点
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # 访问索引 i 处的 SmartArt 节点
          $node0 = $smart->getAllNodes()->get_Item($i);
          # 遍历索引 i 处的 SmartArt 节点的子节点
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # 访问 SmartArt 节点中的子节点
            $node = $node0->getChildNodes()->get_Item($j);
            # 打印 SmartArt 子节点参数
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **在特定位置访问 SmartArt 子节点**
本示例演示如何在特定位置访问 SmartArt 形状中各节点的子节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 通过索引获取第一张幻灯片的引用。
1. 添加一种 [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) 类型的 SmartArt 形状。
1. 访问已添加的 SmartArt 形状。
1. 访问该 SmartArt 形状中索引为 0 的节点。
1. 现在，使用 **get_Item()** 方法访问该节点的第 1 个 **子节点** [https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--)。
1. 访问并显示诸如 **子节点** 位置、层级和文本等信息。
```php
  # 实例化演示文稿
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 在第一张幻灯片中添加 SmartArt 形状
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # 访问索引 0 处的 SmartArt 节点
    $node = $smart->getAllNodes()->get_Item(0);
    # 在父节点中访问位置 1 的子节点
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # 打印 SmartArt 子节点参数
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **移除 SmartArt 节点**
本示例演示如何删除 SmartArt 形状中的节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 通过索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 类型，并在是 SmartArt 时将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)。
1. 检查该 SmartArt 是否拥有大于 0 的节点。
1. 选中要删除的 SmartArt 节点。
1. 现在，使用 [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) 方法删除选中的节点。
1. 保存演示文稿。
```php
  # 加载所需的演示文稿
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # 遍历第一张幻灯片中的所有形状
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # 访问索引 0 处的 SmartArt 节点
          $node = $smart->getAllNodes()->get_Item(0);
          # 删除选中的节点
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # 保存演示文稿
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **从特定位置移除 SmartArt 节点**
本示例演示如何在特定位置删除 SmartArt 形状中的节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 通过索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 类型，并在是 SmartArt 时将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)。
1. 选中索引为 0 的 SmartArt 形状节点。
1. 现在，检查选中节点是否拥有超过 2 个子节点。
1. 现在，使用 [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-int-) 方法移除 **位置 1** 的节点。
1. 保存演示文稿。
```php
  # 加载所需的演示文稿
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # 遍历第一张幻灯片中的所有形状
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # 访问索引 0 处的 SmartArt 节点
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # 删除位置 1 处的子节点
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # 保存演示文稿
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **为 SmartArt 对象的子节点设置自定义位置**
现在 Aspose.Slides for PHP via Java 支持设置 [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) 的 [X](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setX-float-) 和 [Y](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setY-float-) 属性。下面的代码片段演示了如何设置自定义的 SmartArtShape 位置、大小和旋转，并请注意，添加新节点会重新计算所有节点的位置和大小。通过自定义位置设置，用户可以根据需求布置节点。
```php
  # 实例化 Presentation 类
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # 将 SmartArt 形状移动到新位置
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # 更改 SmartArt 形状的宽度
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # 更改 SmartArt 形状的高度
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # 更改 SmartArt 形状的旋转
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **检查助理节点**
{{% alert color="primary" %}} 

在本文中，我们将进一步探讨使用 Aspose.Slides for PHP via Java 以编程方式向演示文稿幻灯片添加的 SmartArt 形状的功能。

{{% /alert %}} 

我们将在本文的不同章节使用以下源 SmartArt 形状进行演示。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**图 1：幻灯片中的源 SmartArt 形状**|

在下面的示例代码中，我们将研究如何在 SmartArt 节点集合中识别 **助理节点** 并对其进行更改。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 通过索引获取第二张幻灯片的引用。
1. 遍历第一张幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 类型，并在是 SmartArt 时将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)。
1. 遍历 SmartArt 形状中的所有节点，并检查它们是否为 [**Assistant Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--)。
1. 将助理节点的状态更改为普通节点。
1. 保存演示文稿。
```php
  # 创建演示文稿实例
  $pres = new Presentation("AddNodes.pptx");
  try {
    # 遍历第一张幻灯片中的所有形状
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArt
        $smart = $shape;
        # 遍历 SmartArt 形状的所有节点
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # 检查节点是否为助理节点
          if ($node->isAssistant()) {
            # 将助理节点设为 false 并将其设为普通节点
            $node->isAssistant();
          }
        }
      }
    }
    # 保存演示文稿
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**图 2：幻灯片中 SmartArt 形状的助理节点已修改**|

## **设置节点的填充格式**
Aspose.Slides for PHP via Java 使得添加自定义 SmartArt 形状并设置其填充格式成为可能。本文说明如何创建和访问 SmartArt 形状以及使用 Aspose.Slides for PHP via Java 为其节点设置填充格式。

请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 通过设置其 **LayoutType** [https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) 添加一个 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 形状。
1. 为 SmartArt 形状的节点设置 [**FillFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getFillFormat--)。
1. 将修改后的演示文稿写入为 PPTX 文件。
```php
  # 实例化演示文稿
  $pres = new Presentation();
  try {
    # 访问幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加 SmartArt 形状和节点
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # 设置节点填充颜色
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # 保存演示文稿
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **生成 SmartArt 子节点的缩略图**
开发者可以按以下步骤生成 SmartArt 子节点的缩略图：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. [添加 SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--)。
1. 使用索引获取节点的引用。
1. 获取缩略图图像。
1. 将缩略图以任意所需的图像格式保存。
```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 添加 SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # 通过索引获取节点的引用
    $node = $smart->getNodes()->get_Item(1);
    # 获取缩略图
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # 保存缩略图
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**是否支持 SmartArt 动画？**

是的。SmartArt 被视为普通形状，您可以使用[标准动画](/slides/zh/php-java/shape-animation/)（进入、退出、强调、运动路径）并调整时间。必要时也可以为 SmartArt 节点内部的形状添加动画。

**如果不知道内部 ID，如何可靠地定位幻灯片上的特定 SmartArt？**

通过为 SmartArt 设置并搜索[替代文本](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/)。在 SmartArt 上设置唯一的 AltText，可在无需内部标识符的情况下以编程方式查找它。

**将演示文稿转换为 PDF 时，SmartArt 的外观会被保留吗？**

会。Aspose.Slides 在[PDF 导出](/slides/zh/php-java/convert-powerpoint-to-pdf/)期间高保真渲染 SmartArt，保持布局、颜色和效果。

**我可以提取整个 SmartArt 的图像用于预览或报告吗？**

可以。您可以将 SmartArt 形状渲染为[光栅格式](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage)或[SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/)，以获取可缩放的矢量输出，适用于缩略图、报告或网页使用。