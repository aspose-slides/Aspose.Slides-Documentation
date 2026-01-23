---
title: 使用 PHP 管理演示文稿中的 SmartArt 形状节点
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
- 删除节点
- 自定义位置
- 辅助节点
- 填充格式
- 渲染节点
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 管理 PPT 和 PPTX 中的 SmartArt 形状节点。获取清晰的代码示例和技巧，以简化您的演示文稿。"
---

## **添加 SmartArt 节点**
Aspose.Slides for PHP via Java 提供了最简洁的 API，以最容易的方式管理 SmartArt 形状。下面的示例代码将帮助在 SmartArt 形状中添加节点和子节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
2. 通过索引获取第一张幻灯片的引用。
3. 遍历第一张幻灯片中的所有形状。
4. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) 类型，如果是 SmartArt，则将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)。
5. 在 SmartArt 形状的 [**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/#getAllNodes) 中 [添加新节点](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode) 并在 TextFrame 中设置文本。
6. 现在，在新添加的 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) 节点中 [添加](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode) 一个 [**Child Node**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes) 并在 TextFrame 中设置文本。
7. 保存演示文稿。

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
        # 在父节点中添加新的子节点。它将添加到集合的末尾
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
2. 通过索引获取第一张幻灯片的引用。
3. 在访问的幻灯片中添加一种 [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) 类型的 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 形状。
4. 访问已添加 SmartArt 形状中的第一个节点。
5. 现在，在位置 2 为选定的 [**Node**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) 添加 [**Child Node**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes) 并设置其文本。
6. 保存演示文稿。

```php
  # 创建演示文稿实例
  $pres = new Presentation();
  try {
    # 访问演示文稿幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加 Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # 访问索引为 0 的 SmartArt 节点
    $node = $smart->getAllNodes()->get_Item(0);
    # 在父节点的第 2 位置添加新的子节点
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
下面的示例代码将帮助访问 SmartArt 形状中的节点。请注意，SmartArt 的 LayoutType 为只读，且只能在添加 SmartArt 形状时设置，无法更改。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
2. 通过索引获取第一张幻灯片的引用。
3. 遍历第一张幻灯片中的所有形状。
4. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) 类型，如果是 SmartArt，则将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)。
5. 遍历 SmartArt 形状中的所有 [**Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--)。
6. 访问并显示信息，如 SmartArt 节点的位置、级别和文本。

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
          # 访问索引 i 的 SmartArt 节点
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
下面的示例代码将帮助访问 SmartArt 形状中相应节点的子节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
2. 通过索引获取第一张幻灯片的引用。
3. 遍历第一张幻灯片中的所有形状。
4. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) 类型，如果是 SmartArt，则将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)。
5. 遍历 SmartArt 形状中的所有 [**Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--)。
6. 对每个选定的 SmartArt [**Node**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode)，遍历该节点内所有 [**Child Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--)。
7. 访问并显示信息，如 [**Child Node**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes) 的位置、级别和文本。

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
          # 访问索引 i 的 SmartArt 节点
          $node0 = $smart->getAllNodes()->get_Item($i);
          # 遍历索引 i 的 SmartArt 节点中的子节点
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
在本示例中，我们将学习如何在特定位置访问 SmartArt 形状中相应节点的子节点。

1. 创建 Presentation 类的实例。
2. 通过索引获取第一张幻灯片的引用。
3. 添加一种 [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) 类型的 SmartArt 形状。
4. 访问已添加的 SmartArt 形状。
5. 访问已访问 SmartArt 形状中索引为 0 的节点。
6. 现在，使用 **get_Item()** 方法访问该 SmartArt 节点位置 1 的 [**Child Node**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes)。
7. 访问并显示信息，如 [**Child Node**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes) 的位置、级别和文本。

```php
  # 实例化演示文稿
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 在第一张幻灯片中添加 SmartArt 形状
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # 访问索引为 0 的 SmartArt 节点
    $node = $smart->getAllNodes()->get_Item(0);
    # 访问父节点中位置为 1 的子节点
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


## **删除 SmartArt 节点**
在本示例中，我们将学习如何删除 SmartArt 形状中的节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
2. 通过索引获取第一张幻灯片的引用。
3. 遍历第一张幻灯片中的所有形状。
4. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) 类型，如果是 SmartArt，则将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)。
5. 检查 SmartArt 是否拥有大于 0 的节点。
6. 选择要删除的 SmartArt 节点。
7. 现在，使用 [**removeNode**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#removeNode) 方法删除所选节点。
8. 保存演示文稿。

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
          # 访问索引为 0 的 SmartArt 节点
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


## **从特定位置删除 SmartArt 节点**
在本示例中，我们将学习如何从特定位置删除 SmartArt 形状中的节点。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
2. 通过索引获取第一张幻灯片的引用。
3. 遍历第一张幻灯片中的所有形状。
4. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) 类型，如果是 SmartArt，则将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)。
5. 选择索引为 0 的 SmartArt 形状节点。
6. 现在，检查所选 SmartArt 节点是否拥有超过 2 个子节点。
7. 现在，使用 [**removeNode**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#removeNode) 方法删除 **Position 1** 的节点。
8. 保存演示文稿。

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


## **为 SmartArt 对象的子节点设置自定义位置**
Aspose.Slides for PHP via Java 支持设置 [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) 的 [X](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setX) 和 [Y](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setY) 属性。下面的代码片段展示了如何设置自定义的 SmartArtShape 位置、大小和旋转，请注意，添加新节点会导致所有节点的位置和大小重新计算。通过自定义位置设置，用户可以根据需求设置节点。

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


## **检查辅助节点**
{{% alert color="primary" %}} 

在本文中，我们将进一步研究使用 Aspose.Slides for PHP via Java 以编程方式在演示文稿幻灯片中添加的 SmartArt 形状的功能。

{{% /alert %}} 

我们将在本文的不同章节中使用以下源 SmartArt 形状进行研究。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**图：幻灯片中的源 SmartArt 形状**|

在下面的示例代码中，我们将探讨如何在 SmartArt 节点集合中识别 **Assistant Nodes** 并对其进行更改。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
2. 通过索引获取第二张幻灯片的引用。
3. 遍历第一张幻灯片中的所有形状。
4. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) 类型，如果是 SmartArt，则将选定的形状强制转换为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)。
5. 遍历 SmartArt 形状中的所有节点，并检查它们是否为 [**Assistant Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--)。
6. 将 Assistant Node 的状态更改为普通节点。
7. 保存演示文稿。

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
          # 检查节点是否为 Assistant 节点
          if ($node->isAssistant()) {
            # 将 Assistant 节点设置为 false 并使其成为普通节点
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
|**图：幻灯片中 SmartArt 形状的辅助节点已更改**|

## **设置节点的填充格式**
Aspose.Slides for PHP via Java 使得添加自定义 SmartArt 形状并设置其填充格式成为可能。本文说明了如何使用 Aspose.Slides for PHP via Java 创建和访问 SmartArt 形状并设置其填充格式。

请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 通过设置其 [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) 添加一个 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) 形状。
4. 为 SmartArt 形状节点设置 [**Fill Format**](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFillFormat)。
5. 将修改后的演示文稿写入为 PPTX 文件。

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
开发者可以通过以下步骤生成 SmartArt 子节点的缩略图：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. [添加 SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode)。
3. 通过索引获取节点的引用。
4. 获取缩略图图像。
5. 将缩略图图像保存为任意所需的图像格式。

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

是的。SmartArt 被视为普通形状，您可以[应用标准动画](/slides/zh/php-java/shape-animation/)（进入、退出、强调、运动路径）并调整时间。如果需要，还可以对 SmartArt 节点内部的形状进行动画设置。

**如果不知道内部 ID，如何可靠地定位幻灯片上的特定 SmartArt？**

通过[替代文本](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/)进行标记并搜索。为 SmartArt 设置唯一的 AltText，可在程序中无需依赖内部标识符即可定位。

**将演示文稿转换为 PDF 时，SmartArt 外观会被保留吗？**

会的。Aspose.Slides 在[PDF 导出](/slides/zh/php-java/convert-powerpoint-to-pdf/)期间以高保真度渲染 SmartArt，保持布局、颜色和效果。

**我可以提取整个 SmartArt 的图像吗（用于预览或报告）？**

可以。您可以将 SmartArt 形状渲染为[光栅格式](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage)或[SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/)，以生成缩略图、报告或网页使用的图像。