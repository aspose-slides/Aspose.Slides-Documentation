---
title: 创建或管理 PowerPoint SmartArt 形状节点
linktitle: 管理 SmartArt 形状节点
type: docs
weight: 30
url: /zh/php-java/manage-smartart-shape-node/
keywords: smartart powerpoint, smartart 节点, smartart 位置, 删除 smartart, smartart 节点添加, powerpoint 演示文稿, powerpoint java, powerpoint java api
description: 管理 PowerPoint 演示文稿中的智能艺术节点和子节点
---

## **使用 PHP 在 PowerPoint 演示文稿中添加 SmartArt 节点**
Aspose.Slides for PHP via Java 提供了最简单的 API，以最简单的方式管理 SmartArt 形状。以下示例代码将帮助您在 SmartArt 形状中添加节点和子节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例，并加载包含 SmartArt 形状的演示文稿。
1. 通过使用其索引获取第一页幻灯片的引用。
1. 遍历第一页幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 类型，如果是 SmartArt，则将选定形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)。
1. 在 SmartArt 形状的 [**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#getAllNodes--) 中 [添加一个新节点](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) 并在 TextFrame 中设置文本。
1. 现在，在新添加的 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 节点中 [添加](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) 一个 [**子节点**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) 并在 TextFrame 中设置文本。
1. 保存演示文稿。

```php
  # 加载所需的演示文稿
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 遍历第一页幻灯片中的每个形状
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArt
        $smart = $shape;
        # 添加新的 SmartArt 节点
        $TemNode = $smart->getAllNodes()->addNode();
        # 添加文本
        $TemNode->getTextFrame()->setText("测试");
        # 在父节点中添加新的子节点。它将添加到集合的末尾
        $newNode = $TemNode->getChildNodes()->addNode();
        # 添加文本
        $newNode->getTextFrame()->setText("新节点已添加");
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
在以下示例代码中，我们解释了如何在特定位置添加属于相应 SmartArt 形状的子节点。

1. 创建一个 Presentation 类的实例。
1. 通过使用其索引获取第一页幻灯片的引用。
1. 在访问的幻灯片中添加一个 [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) 类型的 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 形状。
1. 访问添加的 SmartArt 形状中的第一个节点。
1. 现在，在位置 2 为选定的 [**节点**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) 添加 [**子节点**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) 并设置其文本。
1. 保存演示文稿。

```php
  # 创建演示文稿实例
  $pres = new Presentation();
  try {
    # 访问演示文稿幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加 SmartArt IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # 访问添加的 SmartArt 中的节点
    $node = $smart->getAllNodes()->get_Item(0);
    # 在父节点中位置 2 添加新的子节点
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # 添加文本
    $chNode->getTextFrame()->setText("添加的示例文本");
    # 保存演示文稿
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **使用 PHP 访问 PowerPoint 演示文稿中的 SmartArt 节点**
以下示例代码将帮助您访问 SmartArt 形状内的节点。请注意，您无法更改 SmartArt 的 LayoutType，因为它是只读的，仅在添加 SmartArt 形状时设置。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例，并加载包含 SmartArt 形状的演示文稿。
1. 通过使用其索引获取第一页幻灯片的引用。
1. 遍历第一页幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 类型，如果是 SmartArt，则将选定形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)。
1. 遍历 SmartArt 形状内的所有 [**节点**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--)。
1. 访问并显示信息，如 SmartArt 节点位置、级别和文本。

```php
  # 实例化 Presentation 类
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # 获取第一页幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 遍历第一页幻灯片中的每个形状
    foreach($slide->getShapes() as $shape) {
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArt
        $smart = $shape;
        # 遍历 SmartArt 内的所有节点
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # 访问索引为 i 的 SmartArt 节点
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
以下示例代码将帮助您访问与 SmartArt 形状的相应节点相关的子节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例，并加载包含 SmartArt 形状的演示文稿。
1. 通过使用其索引获取第一页幻灯片的引用。
1. 遍历第一页幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 类型，如果是 SmartArt，则将选定形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)。
1. 遍历 SmartArt 形状内部的所有 [**节点**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--)。
1. 对于每个选定的 SmartArt 形状 [**节点**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode)，遍历特定节点内的所有 [**子节点**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--)。
1. 访问并显示信息，如 [**子节点**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) 的位置、级别和文本。

```php
  # 实例化 Presentation 类
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # 获取第一页幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 遍历第一页幻灯片中的每个形状
    foreach($slide->getShapes() as $shape) {
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArt
        $smart = $shape;
        # 遍历 SmartArt 内的所有节点
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # 访问索引为 i 的 SmartArt 节点
          $node0 = $smart->getAllNodes()->get_Item($i);
          # 遍历索引为 i 的 SmartArt 节点中的子节点
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # 访问 SmartArt 节点中的子节点
            $node = $node0->getChildNodes()->get_Item($j);
            # 打印 SmartArt 子节点参数
            System->out->print("j = " . $j . ", 文本 = " . $node->getTextFrame()->getText() . ",  级别 = " . $node->getLevel() . ", 位置 = " . $node->getPosition());
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
在此示例中，我们将学习如何访问属于相应 nodes 的特定位置处的子节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 通过使用其索引获取第一页幻灯片的引用。
1. 添加一个 [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) 类型的 SmartArt 形状。
1. 访问添加的 SmartArt 形状。
1. 访问索引为 0 的访问到的 SmartArt 形状的节点。
1. 现在，通过 **get_Item()** 方法访问访问的 SmartArt 节点中的位置 1 的 [**子节点**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--)。
1. 访问并显示信息，如 [**子节点**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) 的位置、级别和文本。

```php
  # 实例化演示文稿
  $pres = new Presentation();
  try {
    # 访问第一页幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 在第一页幻灯片中添加 SmartArt 形状
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # 访问索引为 0 的 SmartArt 节点
    $node = $smart->getAllNodes()->get_Item(0);
    # 访问父节点中位置 1 的子节点
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # 打印 SmartArt 子节点参数
    System->out->print("文本 = " . $chNode->getTextFrame()->getText() . ",  级别 = " . $chNode->getLevel() . ", 位置 = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **使用 PHP 删除 PowerPoint 演示文稿中的 SmartArt 节点**
在此示例中，我们将学习如何删除 SmartArt 形状内的节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例，并加载包含 SmartArt 形状的演示文稿。
1. 通过使用其索引获取第一页幻灯片的引用。
1. 遍历第一页幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 类型，如果是 SmartArt，则将选定形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)。
1. 检查 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 是否有超过 0 个节点。
1. 选择要删除的 SmartArt 节点。
1. 现在，通过 [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) 方法删除选定节点。
1. 保存演示文稿。

```php
  # 加载所需的演示文稿
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # 遍历第一页幻灯片中的每个形状
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # 访问索引为 0 的 SmartArt 节点
          $node = $smart->getAllNodes()->get_Item(0);
          # 删除选定节点
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

## **在特定位置删除 SmartArt 节点**
在此示例中，我们将学习如何在特定位置删除 SmartArt 形状内的节点。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例，并加载包含 SmartArt 形状的演示文稿。
1. 通过使用其索引获取第一页幻灯片的引用。
1. 遍历第一页幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 类型，如果是 SmartArt，则将选定形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)。
1. 选择索引为 0 的 SmartArt 形状节点。
1. 现在，检查选定的 SmartArt 节点是否有超过 2 个子节点。
1. 现在，使用 [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-int-) 方法删除位置为 **1** 的节点。
1. 保存演示文稿。

```php
  # 加载所需的演示文稿
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # 遍历第一页幻灯片中的每个形状
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # 访问索引为 0 的 SmartArt 节点
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # 删除位置为 1 的子节点
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

## **为 SmartArt 中的子节点设置自定义位置**
现在 Aspose.Slides for PHP via Java 支持设置 [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) 的 [X](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setX-float-) 和 [Y](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setY-float-) 属性。下方的代码片段展示如何设置自定义 SmartArtShape 的位置、大小和旋转，请注意，添加新节点会导致重新计算所有节点的位置和大小。通过自定义位置设置，用户可以根据需求设置节点。

```php
  # 实例化 Presentation 类
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # 将 SmartArt 形状移动到新位置
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() + $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # 更改 SmartArt 形状的宽度
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() * 2);
    # 更改 SmartArt 形状的高度
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() * 2);
    # 更改 SmartArt 形状的旋转
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **检查助手节点**
{{% alert color="primary" %}} 

在本文中，我们将进一步研究通过 Aspose.Slides for PHP via Java 程序化添加到演示文稿幻灯片中的 SmartArt 形状的功能。

{{% /alert %}} 

我们将使用以下 source SmartArt 形状进行研究。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**图：幻灯片中的源 SmartArt 形状**|

在以下示例代码中，我们将研究如何识别 SmartArt 节点集合中的 **助手节点** 并更改它们。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例，并加载包含 SmartArt 形状的演示文稿。
1. 通过使用其索引获取第二页幻灯片的引用。
1. 遍历第一页幻灯片中的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 类型，如果是 SmartArt，则将选定形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt)。
1. 遍历 SmartArt 形状内的所有节点，并检查它们是否为 [**助手节点**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--)。
1. 将助手节点的状态更改为普通节点。
1. 保存演示文稿。

```php
  # 创建演示文稿实例
  $pres = new Presentation("AddNodes.pptx");
  try {
    # 遍历第一页幻灯片中的每个形状
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArt
        $smart = $shape;
        # 遍历 SmartArt 形状的所有节点
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # 检查节点是否为助手节点
          if ($node->isAssistant()) {
            # 将助手节点设置为 false，并使其成为普通节点
            $node->isAssistant(false);
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
|**图：幻灯片中 SmartArt 形状的助手节点已更改**|

## **设置节点的填充格式**
Aspose.Slides for PHP via Java 使添加自定义 SmartArt 形状并设置其填充格式成为可能。本文解释了如何创建和访问 SmartArt 形状并使用 Aspose.Slides for PHP via Java 设置其填充格式。

请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 添加一个 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) 形状，并设置其 [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess)。
1. 设置 SmartArt 形状节点的 [**FillFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getFillFormat--)。
1. 将修改后的演示文稿写入 PPTX 文件。

```php
  # 实例化演示文稿
  $pres = new Presentation();
  try {
    # 访问幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加 SmartArt 形状和节点
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("一些文本");
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

## **生成 SmartArt 子节点缩略图**
开发人员可以通过以下步骤生成 SmartArt 的子节点缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. [添加 SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--)。
1. 通过使用其索引获取节点的引用。
1. 获取缩略图图像。
1. 将缩略图图像保存为任何所需的图像格式。

```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 添加 SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # 通过使用其索引获取节点的引用
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