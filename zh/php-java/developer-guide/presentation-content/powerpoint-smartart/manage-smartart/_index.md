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
description: "了解如何使用 Aspose.Slides for PHP via Java 构建和编辑 PowerPoint SmartArt，借助清晰的代码示例加快幻灯片设计和自动化。"
---
## **概述**

SmartArt 是一种由节点、节点形状和布局组成的 PowerPoint 图表。使用 Aspose.Slides for PHP via Java，您可以创建 SmartArt、读取其节点中的文本、更改其布局、检查隐藏节点、配置组织结构图布局以及创建图片组织结构图。

## **从 SmartArt 对象获取文本**

SmartArt 节点可以包含一个或多个形状。要读取节点形状中的文本，请遍历 [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/)，然后读取由 [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/) 返回的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。

示例需要一个包含至少一张幻灯片且在该幻灯片上第一形状为 SmartArt 对象的演示文稿。它会将每个可用的文本框打印到控制台。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **更改 SmartArt 对象的布局类型**

SmartArt 布局控制节点的排列和连接方式。下面的示例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 值创建一个 SmartArt 对象，将其更改为 `BasicProcess` 值，然后保存演示文稿。传递给 [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) 的位置和大小以点为单位。使用 [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) 可以更改布局。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **检查 SmartArt 节点是否隐藏**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) 表示节点在 SmartArt 数据模型中是否隐藏。即使所选布局未将隐藏节点显示为可见的图表元素，隐藏节点仍可能存在于结构中。

下面的示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` 值的 SmartArt 对象添加一个节点，并检查该添加节点的隐藏状态。如果节点隐藏，则打印一条消息并保存图表。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **获取或设置组织结构图布局**

对于使用组织结构图布局的 SmartArt 图表，[SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) 和 [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) 定义子节点在父节点下的排列方式。例如，您可以根据所选的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) 将子节点挂在左侧、右侧或两侧。

下面的示例创建一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 值。零基索引 `0` 选中第一个顶层节点；其子节点采用所选的排列方式。随后保存已修改的演示文稿。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **创建图片组织结构图**

图片组织结构图是一种为包含图像占位符的层级图而设计的 SmartArt 布局。在将 SmartArt 对象添加到幻灯片时使用 [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 值。此示例保存了带有图像占位符的图表，但未向占位符填充图像。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **将旧版图表转换为形状组**

在现代化现有演示文稿时，您可能需要更新最初在 PowerPoint 97–2003 中创建的组织结构图。Aspose.Slides 将这些旧版图表表示为 [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) 对象。使用 [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) 可将图表转换为形状组，以便编辑各个可视元素。有关详细信息，请参阅 [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/)。

转换会在形状集合中添加一个新组，而不删除原始图表。转换成功后，使用 [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) 删除原始图表，以避免重复内容。在转换之前将旧版图表收集到列表中，这样添加和删除形状就不会干扰迭代。

下面的示例打开一个演示文稿，遍历每张幻灯片，将图表转换为形状组，并将更新后的演示文稿保存为 PPTX。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

保存的演示文稿中，已转换的旧版图表被可编辑的形状组取代，不会保留原始图表。使用 PowerPoint 打开该 PPTX，可编辑每个组内的各个元素，例如文本、填充或位置。

## **常见问题**

**SmartArt 是否支持 RTL 语言的镜像或反转？**

是的。当所选 SmartArt 布局支持反转时，[SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) 方法可将图表方向从从左到右切换为从右到左，或反向切换。

**如何在保持格式的情况下将 SmartArt 复制到同一幻灯片或另一个演示文稿？**

您可以使用 [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) [克隆 SmartArt 形状](/slides/zh/php-java/shape-manipulations/)，或 [克隆包含 SmartArt 的整张幻灯片](/slides/zh/php-java/clone-slides/)。这两种方法都能保留大小、位置和格式。

**如何将 SmartArt 渲染为栅格图像以进行预览或网页导出？**

[渲染幻灯片](/slides/zh/php-java/convert-powerpoint-to-png/) 或将整个演示文稿渲染为 PNG 或 JPEG。SmartArt 作为幻灯片的一部分进行渲染。

**如果幻灯片上有多个 SmartArt 对象，我该如何找到特定的对象？**

使用 [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) 或 [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) 为 SmartArt 形状分配唯一的替代文本或名称，在 [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) 中搜索该值，然后检查匹配的形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)。