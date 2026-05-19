---
title: 使用 PHP 在 PowerPoint 演示文稿中管理 SmartArt
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
description: "学习使用 Aspose.Slides for PHP via Java 构建和编辑 PowerPoint SmartArt，通过清晰的代码示例加快幻灯片设计和自动化。"
---
## **概述**

SmartArt 是由节点、节点形状和布局组成的 PowerPoint 图表。使用 Aspose.Slides for PHP via Java，您可以创建 SmartArt、读取其节点中的文本、更改布局、检查隐藏节点、配置组织结构图布局，以及创建图片组织结构图。

## **从 SmartArt 对象获取文本**

SmartArt 节点可以包含一个或多个形状。要读取可见文本，请遍历 [SmartArt::getAllNodes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartart/#getAllNodes)，然后读取由 [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartartshape/#getTextFrame) 返回的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```
## **更改 SmartArt 对象的布局类型**

SmartArt 布局控制节点的排列和连接方式。下面的示例创建一个使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 值的 SmartArt 对象，将其更改为 `BasicProcess` 值，并保存演示文稿。

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **检查 SmartArt 节点是否隐藏**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartartnode/ishidden/) 指示节点在 SmartArt 数据模型中是否被隐藏。即使所选布局未将隐藏节点显示为可见图表元素，隐藏节点仍可能存在于结构中。

下面的示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` 值的 SmartArt 对象添加一个节点，并检查该节点的隐藏状态。

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **获取或设置组织结构图布局**

对于使用组织结构图布局的 SmartArt 图表，[SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) 和 [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) 定义子节点在父节点下的排列方式。例如，您可以根据所选的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/organizationchartlayouttype/) 将子节点挂在左侧、右侧或两侧。

下面的示例创建一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 值。

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **创建图片组织结构图**

图片组织结构图是一种为包含图像占位符的层级图表设计的 SmartArt 布局。在向幻灯片添加 SmartArt 对象时，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 值。

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **常见问题**

**SmartArt 是否支持 RTL 语言的镜像或反转？**

是的。当所选 SmartArt 布局支持反转时，[SmartArt::setReversed](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartart/setreversed/) 方法可将图表方向从从左到右切换为从右到左，或反之。

**如何在同一幻灯片或另一份演示文稿中复制 SmartArt 并保留格式？**

您可以使用 [ShapeCollection::addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addclone/) [克隆 SmartArt 形状](/slides/zh/php-java/shape-manipulations/)，或 [克隆包含 SmartArt 的整张幻灯片](/slides/zh/php-java/clone-slides/)。两种方法都能保留大小、位置和格式。

**如何将 SmartArt 渲染为栅格图像以供预览或网页导出？**

[渲染幻灯片](/slides/zh/php-java/convert-powerpoint-to-png/) 或将整个演示文稿导出为 PNG 或 JPEG。SmartArt 将作为幻灯片的一部分进行渲染。

**如果幻灯片上有多个 SmartArt 对象，如何找到特定的对象？**

在 SmartArt 形状上设置唯一的 [Shape::getAlternativeText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getalternativetext/) 或 [Shape::getName](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getname/) 值，在 [BaseSlide::getShapes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslide/#getShapes) 中搜索该值，然后检查匹配的形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartart/)。