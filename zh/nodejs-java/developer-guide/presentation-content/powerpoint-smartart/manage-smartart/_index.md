---
title: 使用 JavaScript 管理 PowerPoint 演示文稿中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt 文本
- 布局类型
- 隐藏属性
- 组织结构图
- 图片组织结构图
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "学习使用 Aspose.Slides for Node.js，通过清晰的 JavaScript 代码示例构建和编辑 PowerPoint SmartArt，加快幻灯片设计和自动化。"
---
## **概述**

SmartArt 是由节点、节点形状和布局组成的 PowerPoint 图表。使用 Aspose.Slides for Node.js via Java，您可以创建 SmartArt、读取其节点中的文本、更改其布局、检查隐藏节点、配置组织结构图布局以及创建图片组织结构图。

## **获取 SmartArt 对象的文本**

SmartArt 节点可以包含一个或多个形状。要读取节点形状中的文本，请遍历 [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/)，然后读取由 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/) 返回的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)。

示例需要一个至少包含一张幻灯片且在该幻灯片上第一个形状为 SmartArt 对象的演示文稿。它会将每个可用的文本框打印到控制台。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **更改 SmartArt 对象的布局类型**

SmartArt 布局控制节点的排列和连接方式。下面的示例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 值创建一个 SmartArt 对象，将其更改为 `BasicProcess` 值，并保存演示文稿。传递给 [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) 的位置和大小以点为单位。使用 [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) 可更改布局。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **检查 SmartArt 节点是否隐藏**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) 指示该节点在 SmartArt 数据模型中是否隐藏。即使所选布局未将其显示为可见的图表元素，隐藏节点仍可能存在于结构中。

下面的示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` 值的 SmartArt 对象添加一个节点，并检查添加的节点的隐藏状态。如果节点被隐藏，则打印一条消息并保存图表。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **获取或设置组织结构图布局**

对于使用组织结构图布局的 SmartArt 图表，[SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) 和 [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) 定义子节点在父节点下的排列方式。例如，您可以根据所选的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) 将子节点挂在左侧、右侧或两侧。

下面的示例创建一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 值。零基索引 `0` 选择第一个顶层节点；其子节点使用所选的排列方式。随后保存修改后的演示文稿。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **创建图片组织结构图**

图片组织结构图是一种针对包含图像占位符的层级图设计的 SmartArt 布局。在将 SmartArt 对象添加到幻灯片时使用 [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 值。此示例保存了带有图像占位符的图表，但不为占位符填充图像。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **将旧版图表转换为形状组**

在对现有演示文稿进行现代化改造时，可能需要更新最初在 PowerPoint 97–2003 中创建的组织结构图。Aspose.Slides 将这些旧版图表表示为 [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) 对象。使用 [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) 可将图表转换为形状组，以便编辑各个可视元素。有关详细信息，请参阅 [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/)。

转换会在形状集合中添加一个新组，而不删除原始图表。成功转换后，使用 [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) 删除原始图表，以避免内容重复。在转换之前先将旧版图表收集到列表中，以防在添加和删除形状时中断迭代。

下面的示例打开一个演示文稿，遍历每张幻灯片，将图表转换为形状组，并将更新后的演示文稿保存为 PPTX。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存的演示文稿中，已转换的旧版图表被可编辑的形状组取代，原始图表不再与之共存。使用 PowerPoint 打开该 PPTX，即可编辑每个组内的各个元素，例如其文本、填充或位置。

## **常见问题**

**SmartArt 是否支持 RTL 语言的镜像或反转？**  
是的。当所选 SmartArt 布局支持反转时，[SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) 方法可将图表方向从从左到右切换为从右到左，或反之。

**如何在保留格式的情况下将 SmartArt 复制到同一幻灯片或其他演示文稿？**  
您可以使用 [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) [克隆 SmartArt 形状](/slides/zh/nodejs-java/shape-manipulations/)，或 [克隆包含 SmartArt 的整张幻灯片](/slides/zh/nodejs-java/clone-slides/)。这两种方法均可保留大小、位置和格式。

**如何将 SmartArt 渲染为栅格图像以进行预览或网页导出？**  
[渲染幻灯片](/slides/zh/nodejs-java/convert-powerpoint-to-png/) 或将整个演示文稿渲染为 PNG 或 JPEG，SmartArt 将作为幻灯片的一部分进行渲染。

**如果幻灯片上有多个 SmartArt 对象，如何找到特定的对象？**  
使用 [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) 或 [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) 为 SmartArt 形状分配唯一的替代文本或名称，在 [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) 中搜索该值，然后检查匹配的形状是否为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)。