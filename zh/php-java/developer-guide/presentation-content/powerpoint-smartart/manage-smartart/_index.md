---
title: 使用 PHP 管理 PowerPoint 演示文稿中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt 文本
- 布局类型
- 隐藏属性
- 组织结构图
- 图片组织结构图
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "学习使用 Aspose.Slides for PHP via Java，通过清晰的代码示例构建和编辑 PowerPoint SmartArt，以加快幻灯片设计和自动化。"
---

## **从 SmartArt 对象获取文本**
现在在 [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) 类中新增了 TextFrame 方法。此属性允许您获取 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 的所有文本，即使它不仅仅是节点文本。以下示例代码将帮助您从 SmartArt 节点获取文本。
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


## **更改 SmartArt 对象的布局类型**
为了更改 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 的布局类型，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 通过索引获取幻灯片的引用。
- 添加 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) BasicBlockList。
- 将 [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) 更改为 BasicProcess。
- 将演示文稿写入为 PPTX 文件。

在下面的示例中，我们在两个形状之间添加了一个连接线。
```php
  $pres = new Presentation();
  try {
    # 添加 SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    # 更改 LayoutType 为 BasicProcess
    $smart->setLayout(SmartArtLayoutType::BasicProcess);
    # 保存演示文稿
    $pres->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **检查 SmartArt 对象的隐藏属性**
请注意：如果该节点在数据模型中是隐藏节点，方法 [SmartArtNode::isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) 返回 `true`。为了检查 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 任意节点的隐藏属性，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 添加 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) RadialCycle。
- 在 SmartArt 上添加节点。
- 检查 [visibility](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) 属性。
- 将演示文稿写入为 PPTX 文件。

在下面的示例中，我们在两个形状之间添加了一个连接线。
```php
  $pres = new Presentation();
  try {
    # 添加 SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # 在 SmartArt 上添加节点
    $node = $smart->getAllNodes()->addNode();
    # 检查 isHidden 属性
    $hidden = $node->isHidden();// 返回 true

    if ($hidden) {
      # 执行某些操作或通知
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
方法 [SmartArtNode::getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) 和 [SmartArtNode::setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) 允许获取或设置当前节点关联的组织结构图类型。要获取或设置组织结构图类型，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 在幻灯片上添加 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/)。
- 获取或[设置组织结构图类型](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/)。
- 将演示文稿写入为 PPTX 文件。

在下面的示例中，我们在两个形状之间添加了一个连接线。
```php
  $pres = new Presentation();
  try {
    # 添加 SmartArt BasicProcess
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
Aspose.Slides for PHP via Java 提供了一个简易的 API，用于轻松创建 PictureOrganization 图表。要在幻灯片上创建图表：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加一个带有默认数据且类型为 (ChartType::PictureOrganizationChart) 的图表。
4. 将修改后的演示文稿写入 PPTX 文件。

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
为了更改 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 的布局类型，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 在幻灯片上添加 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/)。
3. [获取](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/isreversed/) 或 [设置](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) SmartArt 图表的状态。
4. 将演示文稿写入为 PPTX 文件。

以下代码用于创建图表。
```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 添加 SmartArt BasicProcess
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


## **常见问题**

**SmartArt 支持 RTL（从右到左）语言的镜像/反转吗？**

是的。如果所选 SmartArt 类型支持反转，[setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) 方法会切换图表方向（LTR/RTL）。

**如何在保持格式的情况下将 SmartArt 复制到同一幻灯片或其他演示文稿？**

您可以通过形状集合 ([ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)) [克隆 SmartArt 形状](/slides/zh/php-java/shape-manipulations/)，或[克隆包含该形状的整个幻灯片](/slides/zh/php-java/clone-slides/)。两种方法都能保留大小、位置和样式。

**如何将 SmartArt 渲染为栅格图像以进行预览或网页导出？**

[渲染幻灯片](/slides/zh/php-java/convert-powerpoint-to-png/)（或整个演示文稿）为 PNG/JPEG，通过将幻灯片/演示文稿转换为图像的 API——SmartArt 将作为幻灯片的一部分绘制。

**如果幻灯片上有多个 SmartArt，如何在代码中选择特定的 SmartArt？**

常用的做法是使用[替代文本](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/)（Alt Text）或[名称](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getname/)，在 [slide shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) 中按该属性搜索形状，然后检查其类型以确认是 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)。文档描述了查找和操作形状的典型技术。