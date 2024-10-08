---
title: 管理 SmartArt
type: docs
weight: 10
url: /php-java/manage-smartart/
---

## **从 SmartArt 中获取文本**
现在，在 [ISmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtShape) 接口和 [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) 类中分别添加了 TextFrame 方法。此属性允许您从 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 获取所有文本，如果它不仅包含节点文本。以下示例代码将帮助您从 SmartArt 节点中获取文本。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $smartArt = $slide->getShapes()->get_Item(0);
    $smartArtNodes = $smartArt->getAllNodes();
    foreach($smartArtNodes as $smartArtNode) {
      foreach($smartArtNode->getShapes() as $nodeShape) {
        if (!java_is_null($nodeShape->getTextFrame())) {
          echo($nodeShape->getTextFrame()->getText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **更改 SmartArt 的布局类型**
为了更改 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 的布局类型，请遵循以下步骤：

- 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 添加 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) 基本块列表。
- 将 [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setLayout-int-) 更改为基本流程。
- 将演示文稿保存为 PPTX 文件。
  在下面给出的示例中，我们在两个形状之间添加了一个连接器。

```php
  $pres = new Presentation();
  try {
    # 添加 SmartArt 基本流程
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    # 将 LayoutType 更改为基本流程
    $smart->setLayout(SmartArtLayoutType::BasicProcess);
    # 保存演示文稿
    $pres->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **检查 SmartArt 的隐藏属性**
请注意：方法 [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--)) 如果此节点在数据模型中是一个隐藏节点，则返回 true。为了检查 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 中任何节点的隐藏属性，请遵循以下步骤：

- 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 添加 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) 辐射循环。
- 在 SmartArt 上添加节点。
- 检查 [isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--) 属性。
- 将演示文稿保存为 PPTX 文件。

在下面给出的示例中，我们在两个形状之间添加了一个连接器。

```php
  $pres = new Presentation();
  try {
    # 添加 SmartArt 基本流程
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # 在 SmartArt 上添加节点
    $node = $smart->getAllNodes()->addNode();
    # 检查 isHidden 属性
    $hidden = $node->isHidden();// 返回 true

    if ($hidden) {
      # 执行一些操作或通知
    }
    # 保存演示文稿
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **获取或设置组织结构图类型**
方法 [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) 允许获取或设置与当前节点关联的组织结构图类型。为了获取或设置组织结构图类型，请遵循以下步骤：

- 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 在幻灯片上添加 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)。
- 获取或 [设置组织结构图类型](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-)。
- 将演示文稿保存为 PPTX 文件。
  在下面给出的示例中，我们在两个形状之间添加了一个连接器。

```php
  $pres = new Presentation();
  try {
    # 添加 SmartArt 基本流程
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # 获取或设置组织结构图类型
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # 保存演示文稿
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **创建图片组织结构图**
Aspose.Slides for PHP via Java 提供了一个简单的 API，用于以简单的方式创建 PictureOrganization 图表。若要在幻灯片上创建图表：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加具有默认数据的图表以及所需类型（ChartType::PictureOrganizationChart）。
1. 将修改后的演示文稿写入 PPTX 文件。

以下代码用于创建图表。

```php
  $pres = new Presentation("test.pptx");
  try {
    $smartArt = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);
    $pres->save("OrganizationChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **获取或设置 SmartArt 状态**
为了更改 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 的布局类型，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 在幻灯片上添加 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)。
1. [获取](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#isReversed--) 或 [设置](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setReversed-boolean-) SmartArt 图表的状态。
1. 将演示文稿保存为 PPTX 文件。

以下代码用于创建图表。

```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 添加 SmartArt 基本流程
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # 获取或设置 SmartArt 图表的状态
    $smart->setReversed(true);
    $flag = $smart->isReversed();
    # 保存演示文稿
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```