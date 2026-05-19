---
title: 使用 Java 管理 PowerPoint 演示文稿中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh/java/manage-smartart/
keywords:
- SmartArt
- SmartArt 文本
- 布局类型
- 隐藏属性
- 组织结构图
- 图片组织结构图
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "学习使用 Aspose.Slides for Java 构建和编辑 PowerPoint SmartArt，通过清晰的代码示例加快幻灯片设计和自动化。"
---
## **概述**

SmartArt 是由节点、节点形状和布局组成的 PowerPoint 图表。使用 Aspose.Slides for Java，您可以创建 SmartArt、读取其节点中的文本、更改布局、检查隐藏节点、配置组织结构图布局，以及创建图片组织结构图。

## **获取 SmartArt 对象的文本**

SmartArt 节点可以包含一个或多个形状。要读取可见文本，请遍历 [ISmartArt.getAllNodes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ismartart/#getAllNodes--)，然后读取由 [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ismartartshape/#getTextFrame--) 返回的 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/)。

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

SmartArt 布局决定节点的排列和连接方式。下面的示例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList` 值创建 SmartArt 对象，将其更改为 `BasicProcess` 值，并保存演示文稿。

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ismartartnode/#isHidden--) 指示节点在 SmartArt 数据模型中是否隐藏。即使所选布局未将它们显示为可见的图表元素，隐藏节点仍可能存在于结构中。

下面的示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle` 值的 SmartArt 对象添加一个节点，并检查该节点的隐藏状态。

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

对于使用组织结构图布局的 SmartArt 图表，[ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) 和 [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) 定义子节点在父节点下的排列方式。例如，您可以根据所选的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/OrganizationChartLayoutType) 将子节点挂在左侧、右侧或两侧。

下面的示例创建一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging` 值。

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

图片组织结构图是一种针对包含图像占位符的层次结构图表设计的 SmartArt 布局。在将 SmartArt 对象添加到幻灯片时，请使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` 值。

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

**SmartArt 是否支持 RTL 语言的镜像或反转？**  
是的。当所选 SmartArt 布局支持反转时，[ISmartArt.setReversed](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ismartart/#setReversed-boolean-) 方法可将图表方向从从左到右切换为从右到左，或反之。

**如何在保留格式的情况下将 SmartArt 复制到同一幻灯片或另一个演示文稿？**  
您可以使用 [ShapeCollection.addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) 克隆 SmartArt 形状（参见[克隆 SmartArt 形状](/slides/zh/java/shape-manipulations/)），或克隆包含 SmartArt 的整个幻灯片（参见[克隆整个幻灯片](/slides/zh/java/clone-slides/)）。这两种方法都会保留大小、位置和格式。

**如何将 SmartArt 渲染为光栅图像以进行预览或网页导出？**  
可以将幻灯片（参见[渲染幻灯片](/slides/zh/java/convert-powerpoint-to-png/)）或整个演示文稿渲染为 PNG 或 JPEG。SmartArt 会作为幻灯片的一部分进行渲染。

**如果幻灯片上有多个 SmartArt 对象，如何找到特定的对象？**  
在 SmartArt 形状上设置唯一的 [Shape.getAlternativeText](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#getAlternativeText--) 或 [Shape.getName](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#getName--) 值，在 [BaseSlide.getShapes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseslide/#getShapes--) 中搜索该值，然后确认匹配的形状是 [ISmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ismartart/)。