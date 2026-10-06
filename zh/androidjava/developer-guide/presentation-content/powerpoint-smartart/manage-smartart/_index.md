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
description: "学习使用 Aspose.Slides for Android，通过清晰的 Java 示例代码构建和编辑 PowerPoint SmartArt，从而加快幻灯片设计和自动化。"
---
## **概述**

SmartArt 是一种由节点、节点形状和布局组成的 PowerPoint 图表。使用 Aspose.Slides for Android via Java，您可以创建 SmartArt、读取其节点中的文本、更改其布局、检查隐藏节点、配置组织结构图布局以及创建图片组织结构图。

## **获取 SmartArt 对象的文本**

SmartArt 节点可以包含一个或多个形状。要读取节点形状中的文本，请遍历 [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--)，然后读取由 [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) 返回的 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)。

该示例需要一个至少包含一张幻灯片且在该幻灯片上第一形状为 SmartArt 对象的演示文稿。它会将每个可用的文本框打印到控制台。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **更改 SmartArt 对象的布局类型**

SmartArt 布局控制节点的排列和连接方式。下面的示例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `BasicBlockList` 值创建一个 SmartArt 对象，将其更改为 `BasicProcess` 值，并保存演示文稿。传递给 [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) 的位置和大小以点为单位。使用 [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) 更改布局。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **检查 SmartArt 节点是否隐藏**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) 指示节点在 SmartArt 数据模型中是否被隐藏。即使所选布局未将其显示为可见的图表元素，隐藏节点仍可能存在于结构中。

下面的示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle` 值的 SmartArt 对象添加一个节点，并检查该添加节点的隐藏状态。如果节点被隐藏，则打印一条消息并保存图表。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **获取或设置组织结构图布局**

对于使用组织结构图布局的 SmartArt 图表， [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) 和 [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) 定义子节点在父节点下的排列方式。例如，您可以根据所选的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) 将子节点挂在左侧、右侧或两侧。

下面的示例创建一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging` 值。零基索引 `0` 选中第一个顶层节点；其子节点使用所选的排列方式。随后保存修改后的演示文稿。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **创建图片组织结构图**

图片组织结构图是一种针对包含图像占位符的层次结构图设计的 SmartArt 布局。在向幻灯片添加 SmartArt 对象时使用 [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 值。此示例保存了带有图像占位符的图表，但不会为占位符填充图像。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **将旧版图表转换为形状组**

在现代化现有演示文稿时，您可能需要更新最初在 PowerPoint 97–2003 中创建的组织结构图。Aspose.Slides 将这些旧版图表表示为 [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/) 对象。使用 [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) 将图表转换为形状组，以便编辑各个可视元素。有关详细信息，请参阅 [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/)。

转换会向形状集合中添加一个新组，而不会删除原始图表。转换成功后，使用 [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 删除原始图表，以避免内容重复。在转换之前将旧版图表收集到列表中，以防添加和删除形状时中断迭代。

下面的示例打开一个演示文稿，遍历每张幻灯片，将图表转换为形状组，并将更新后的演示文稿另存为 PPTX。

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存的演示文稿包含可编辑的形状组，代替已转换的旧版图表，不再保留原始图表。使用 PowerPoint 打开 PPTX，即可编辑每个组内的各个元素，如文本、填充或位置。

## **常见问题**

**SmartArt 是否支持 RTL（从右到左）语言的镜像或反转？**

是的。当所选 SmartArt 布局支持反转时，[ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) 方法可将图表方向从从左到右切换为从右到左，或反向切换。

**如何在保持格式的情况下将 SmartArt 复制到同一幻灯片或另一个演示文稿？**

您可以使用 [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) 对 [克隆 SmartArt 形状](/slides/zh/androidjava/shape-manipulations/) 进行克隆，或对包含 SmartArt 的整个幻灯片进行克隆 [克隆整个幻灯片](/slides/zh/androidjava/clone-slides/)。两种方法都能保留大小、位置和格式。

**如何将 SmartArt 渲染为光栅图像以进行预览或网页导出？**

将幻灯片 [渲染幻灯片](/slides/zh/androidjava/convert-powerpoint-to-png/) 或整个演示文稿渲染为 PNG 或 JPEG。SmartArt 会作为幻灯片的一部分进行渲染。

**如果幻灯片上有多个 SmartArt 对象，如何查找特定的对象？**

使用 [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) 或 [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) 为 SmartArt 形状分配唯一的替代文本或名称，在 [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) 中搜索该值，然后确认匹配的形状是 [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/)。