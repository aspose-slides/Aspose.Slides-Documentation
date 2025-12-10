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
description: "学习使用 Aspose.Slides for Java 构建和编辑 PowerPoint SmartArt，借助清晰的代码示例加速幻灯片设计和自动化。"
---

## **获取 SmartArt 对象的文本**
现在已向 [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) 接口和 [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) 类分别添加了 TextFrame 方法。此属性允许您获取 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 中的所有文本，即使它不仅仅是节点文本。以下示例代码将帮助您获取 SmartArt 节点的文本。
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    ISmartArt smartArt = (ISmartArt)slide.getShapes().get_Item(0);

    ISmartArtNodeCollection smartArtNodes = smartArt.getAllNodes();
    for (ISmartArtNode smartArtNode : smartArtNodes)
    {
        for (ISmartArtShape nodeShape : smartArtNode.getShapes())
        {
            if (nodeShape.getTextFrame() != null)
                System.out.println(nodeShape.getTextFrame().getText());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **更改 SmartArt 对象的布局类型**
为了更改 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 的布局类型，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
- 使用其索引获取幻灯片的引用。
- 添加 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList。
- 将 [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) 更改为 BasicProcess。
- 将演示文稿写入为 PPTX 文件。  
  在下面的示例中，我们在两个形状之间添加了一个连接线。
```java
Presentation pres = new Presentation();
try {
    // 添加 SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // 将 LayoutType 更改为 BasicProcess
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // 保存演示文稿
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **检查 SmartArt 对象的隐藏属性**
请注意：方法 [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--)) 如果此节点在数据模型中是隐藏节点则返回 true。为了检查任何 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 节点的隐藏属性，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
- 添加 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle。
- 在 SmartArt 上添加节点。
- 检查 [isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--) 属性。
- 将演示文稿写入为 PPTX 文件。

在下面的示例中，我们在两个形状之间添加了一个连接线。
```java
Presentation pres = new Presentation();
try {
    // 添加 SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // 在 SmartArt 上添加节点 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // Check isHidden property
    boolean hidden = node.isHidden(); // 返回 true

    if (hidden)
    {
        // 执行某些操作或通知
    }
    // 保存演示文稿
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **获取或设置组织结构图类型**
方法 [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--)、[setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) 允许获取或设置与当前节点关联的组织结构图类型。要获取或设置组织结构图类型，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
- 在幻灯片上添加 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)。
- 获取或[设置组织结构图类型](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-)。
- 将演示文稿写入为 PPTX 文件。  
  在下面的示例中，我们在两个形状之间添加了一个连接线。
```java
Presentation pres = new Presentation();
try {
    // 添加 SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // 获取或设置组织结构图类型
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // 保存演示文稿
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **创建图片组织结构图**
Aspose.Slides for Java 提供了一个简单的 API，轻松创建 PictureOrganization 图表。要在幻灯片上创建图表：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有默认数据且类型为 ChartType.PictureOrganizationChart 的图表。
1. 将修改后的演示文稿写入 PPTX 文件。

以下代码用于创建图表。
```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **获取或设置 SmartArt 状态**
为了更改 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 的布局类型，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 在幻灯片上添加 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)。
1. [获取](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--)或[设置](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) SmartArt 图表的状态。
1. 将演示文稿写入为 PPTX 文件。

以下代码用于创建图表。
```java
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 添加 SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // 获取或设置 SmartArt 图表的状态
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // 保存演示文稿
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**SmartArt 是否支持 RTL 语言的镜像/反转？**

是的。如果所选 SmartArt 类型支持反转，[setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/#setReversed-boolean-) 方法会切换图表方向（LTR/RTL）。

**如何在保持格式的情况下将 SmartArt 复制到同一幻灯片或另一演示文稿？**

您可以通过形状集合[克隆 SmartArt 形状](/slides/zh/java/shape-manipulations/)（[ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)）或[克隆包含该形状的整个幻灯片](/slides/zh/java/clone-slides/)。两种方式都能保留大小、位置和样式。

**如何将 SmartArt 渲染为栅格图像以进行预览或网络导出？**

[渲染幻灯片](/slides/zh/java/convert-powerpoint-to-png/)（或整个演示文稿）为 PNG/JPEG，通过将幻灯片/演示文稿转换为图像的 API——SmartArt 将作为幻灯片的一部分绘制。

**如果有多个 SmartArt，我该如何在代码中选择特定的 SmartArt？**

常用做法是使用[替代文本](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--)（Alt Text）或[名称](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getName--)，并在[幻灯片形状](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--)中按该属性搜索形状，然后检查类型以确认它是[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/)。文档描述了查找和操作形状的典型技术。