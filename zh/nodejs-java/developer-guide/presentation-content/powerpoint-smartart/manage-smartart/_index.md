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
description: "学习使用 Aspose.Slides for Node.js，通过清晰的 JavaScript 代码示例构建和编辑 PowerPoint SmartArt，以加快幻灯片设计和自动化。"
---
## **概述**

SmartArt 是由节点、节点形状和布局构成的 PowerPoint 图表。使用 Aspose.Slides for Node.js via Java，您可以创建 SmartArt、读取其节点中的文本、更改布局、检查隐藏节点、配置组织结构图布局以及创建图片组织结构图。

## **从 SmartArt 对象获取文本**

SmartArt 节点可以包含一个或多个形状。要读取可见文本，请遍历 [SmartArt.getAllNodes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartart/#getAllNodes--)，然后读取由 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) 返回的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。

```javascript
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
    }
} finally {
    presentation.dispose();
}
```

## **更改 SmartArt 对象的布局类型**

SmartArt 布局决定节点的排列和连接方式。以下示例创建一个使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 值的 SmartArt 对象，将其更改为 `BasicProcess` 值，并保存演示文稿。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **检查 SmartArt 节点是否隐藏**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartartnode/ishidden/) 表示节点在 SmartArt 数据模型中是否隐藏。即使所选布局未将它们显示为可见图表元素，隐藏节点仍可能存在于结构中。

以下示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` 值的 SmartArt 对象添加一个节点，并检查该节点的隐藏状态。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **获取或设置组织结构图布局**

对于使用组织结构图布局的 SmartArt 图表，[SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) 和 [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) 定义子节点在父节点下的排列方式。例如，您可以根据选择的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/organizationchartlayouttype/) 将子节点挂在左侧、右侧或两侧。

以下示例创建一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 值。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **创建图片组织结构图**

图片组织结构图是一种专为包含图像占位符的层级图表设计的 SmartArt 布局。在将 SmartArt 对象添加到幻灯片时使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 值。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**SmartArt 是否支持针对 RTL 语言的镜像或反转？**

是的。当所选 SmartArt 布局支持反转时，[SmartArt.setReversed](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartart/setreversed/) 方法可将图表方向从从左到右切换为从右到左，或恢复原状。

**如何在同一幻灯片或其他演示文稿中复制 SmartArt 并保留格式？**

您可以使用 [ShapeCollection.addClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/addclone/) [克隆 SmartArt 形状](/slides/zh/nodejs-java/shape-manipulations/)，或 [克隆包含 SmartArt 的整个幻灯片](/slides/zh/nodejs-java/clone-slides/)。两种方法都会保留大小、位置和格式。

**如何将 SmartArt 渲染为栅格图像以进行预览或网页导出？**

[将幻灯片](/slides/zh/nodejs-java/convert-powerpoint-to-png/) 或整个演示文稿渲染为 PNG 或 JPEG。SmartArt 会作为幻灯片的一部分进行渲染。

**如果幻灯片上有多个 SmartArt 对象，如何查找特定的对象？**

在 SmartArt 形状上设置唯一的 [Shape.setAlternativeText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/setalternativetext/) 或 [Shape.setName](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/setname/) 值，然后在 [BaseSlide.getShapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslide/#getShapes) 中搜索该值，并检查匹配的形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartart/)。