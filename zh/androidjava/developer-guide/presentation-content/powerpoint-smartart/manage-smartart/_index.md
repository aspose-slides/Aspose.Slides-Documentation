---
title: 管理 SmartArt
type: docs
weight: 10
url: /zh/androidjava/manage-smartart/
---

## **从 SmartArt 中获取文本**
现在已分别将 TextFrame 方法添加到 [ISmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtShape) 接口和 [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) 类中。此属性允许您获取 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) 中的所有文本，前提是它不仅包含节点文本。以下示例代码将帮助您从 SmartArt 节点中获取文本。

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

## **更改 SmartArt 的布局类型**
为了更改 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) 的布局类型，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 添加 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)  基本块列表。
- 将 [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setLayout-int-) 更改为基本流程。
- 将演示文稿写入 PPTX 文件。
  在下面给出的示例中，我们在两个形状之间添加了连接器。

```java
Presentation pres = new Presentation();
try {
    // 添加 SmartArt 基本流程
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // 将 LayoutType 更改为基本流程
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // 保存演示文稿
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **检查 SmartArt 的隐藏属性**
请注意：方法 [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--)) 如果此节点是数据模型中的隐藏节点，则返回 true。为了检查任何 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) 的节点的隐藏属性，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
- 添加 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) 循环。
- 在 SmartArt 上添加节点。
- 检查 [isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--) 属性。
- 将演示文稿写入 PPTX 文件。

在下面给出的示例中，我们在两个形状之间添加了连接器。

```java
Presentation pres = new Presentation();
try {
    // 添加 SmartArt 基本流程 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // 在 SmartArt 上添加节点 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // 检查 isHidden 属性
    boolean hidden = node.isHidden(); // 返回 true

    if (hidden)
    {
        // 执行一些操作或通知
    }
    // 保存演示文稿
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **获取或设置组织结构图类型**
方法 [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) 允许获取或设置与当前节点关联的组织结构图类型。为了获取或设置组织结构图类型，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
- 在幻灯片上添加 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)。
- 获取或 [设置组织结构图类型](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-)。
- 将演示文稿写入 PPTX 文件。
  在下面给出的示例中，我们在两个形状之间添加了连接器。

```java
Presentation pres = new Presentation();
try {
    // 添加 SmartArt 基本流程
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
Aspose.Slides for Android via Java 提供了一个简单的 API，用于轻松创建 PictureOrganization 图表。要在幻灯片上创建图表：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加带有默认数据的图表以及所需的类型 (ChartType.PictureOrganizationChart)。
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
为了更改 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) 的布局类型，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 在幻灯片上添加 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)。
1. [获取](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#isReversed--) 或 [设置](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setReversed-boolean-) SmartArt 图表的状态。
1. 将演示文稿写入 PPTX 文件。

以下代码用于创建图表。

```java
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 添加 SmartArt 基本流程
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