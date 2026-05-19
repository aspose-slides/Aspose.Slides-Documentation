---
title: 在 Android 上管理 PowerPoint 演示文稿中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt 文本
- 布局类型
- 隐藏属性
- 组织结构图
- 图片组织结构图
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "学习使用 Aspose.Slides for Android 的清晰 Java 示例代码，构建和编辑 PowerPoint SmartArt，从而加快幻灯片设计和自动化。"
---
## **概述**

SmartArt 是由节点、节点形状和布局组成的 PowerPoint 图表。借助 Aspose.Slides for Android via Java，您可以创建 SmartArt、读取其节点中的文本、更改其布局、检查隐藏节点、配置组织结构图布局以及创建图片组织结构图。

## **获取 SmartArt 对象的文本**

A SmartArt node can contain one or more shapes. To read the visible text, iterate through [ISmartArt.getAllNodes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ismartart/#getAllNodes--), then read the [ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/) returned by [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **更改 SmartArt 对象的布局类型**

The SmartArt layout controls how nodes are arranged and connected. The following example creates a SmartArt object with the [SmartArtLayoutType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList` value, changes it to the `BasicProcess` value, and saves the presentation.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **检查 SmartArt 节点是否隐藏**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ismartartnode/#isHidden--) indicates whether the node is hidden in the SmartArt data model. Hidden nodes can exist in the structure even when the selected layout does not display them as visible diagram elements.

The following example adds a node to a SmartArt object that uses the [SmartArtLayoutType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle` value and checks the node's hidden state.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **获取或设置组织结构图布局**

For SmartArt diagrams that use an organization chart layout, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) and [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) define how child nodes are arranged under a parent node. For example, you can set child nodes to hang from the left, right, or both sides, depending on the selected [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/OrganizationChartLayoutType).

The following example creates an organization chart and sets the layout for the first node to the [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging` value.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **创建图片组织结构图**

A picture organization chart is a SmartArt layout designed for hierarchy diagrams that include image placeholders. Use the [SmartArtLayoutType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` value when adding the SmartArt object to a slide.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**SmartArt 是否支持 RTL（从右到左）语言的镜像或反转？**

Yes. The [ISmartArt.setReversed](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) method switches the diagram direction from left-to-right to right-to-left, or back, when the selected SmartArt layout supports reversal.

**如何在保持格式的情况下将 SmartArt 复制到同一幻灯片或另一个演示文稿？**

You can [clone the SmartArt shape](/slides/zh/androidjava/shape-manipulations/) with [ShapeCollection.addClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) or [clone the whole slide](/slides/zh/androidjava/clone-slides/) that contains the SmartArt. Both approaches preserve size, position, and formatting.

**如何将 SmartArt 渲染为光栅图像以进行预览或网页导出？**

[Render the slide](/slides/zh/androidjava/convert-powerpoint-to-png/) or the whole presentation to PNG or JPEG. SmartArt is rendered as part of the slide.

**如果幻灯片上有多个 SmartArt 对象，如何找到特定的对象？**

Set a distinctive [Shape.getAlternativeText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#getAlternativeText--) or [Shape.getName](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#getName--) value on the SmartArt shape, search for that value in [BaseSlide.getShapes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/baseslide/#getShapes--), and then check that the matching shape is an [ISmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ismartart/).