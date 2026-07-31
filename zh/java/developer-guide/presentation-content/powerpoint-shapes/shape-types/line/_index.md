---
title: 在 Java 中向演示文稿添加线形状
linktitle: 线条
type: docs
weight: 50
url: /zh/java/line/
keywords:
- 线条
- 创建线条
- 添加线条
- 普通线条
- 配置线条
- 自定义线条
- 虚线样式
- 箭头
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 演示文稿中操作线条格式。发现属性、方法和示例。"
---
## **概述**

Aspose.Slides 允许您以编程方式向 PowerPoint 幻灯片添加线形状。本文展示了如何创建一条简单的直线以及如何将直线自定义为箭头。

您将学习如何向幻灯片添加线形状、调整其外观并保存更新后的演示文稿。示例侧重于实用的线条格式设置，如样式、宽度、虚线模式、箭头选项和填充颜色。

## **创建普通直线**

要向演示文稿的选定幻灯片添加一条普通直线，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。
- 使用其索引获取幻灯片的引用。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，添加类型为 Line 的 AutoShape。
- 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们向演示文稿的第一张幻灯片添加了一条直线。

```java
// 实例化表示 PPTX 文件的 PresentationEx 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 添加类型为 line 的 AutoShape
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // 将 PPTX 写入磁盘
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **创建箭头形状的直线**

Aspose.Slides for Java 还允许开发者配置直线的某些属性，使其外观更具吸引力。请按照以下步骤将直线配置为箭头：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。
- 使用其索引获取幻灯片的引用。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，添加类型为 Line 的 AutoShape。
- 将 [Line Style](https://reference.aspose.com/slides/zh/java/com.aspose.slides/LineStyle) 设置为 Aspose.Slides for Java 提供的样式之一。
- 设置直线的宽度。
- 将 [Dash Style](https://reference.aspose.com/slides/zh/java/com.aspose.slides/LineDashStyle) 设置为 Aspose.Slides for Java 提供的样式之一。
- 为直线的起始点设置 [Arrow Head Style](https://reference.aspose.com/slides/zh/java/com.aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/zh/java/com.aspose.slides/LineArrowheadLength)。
- 为直线的结束点设置 [Arrow Head Style](https://reference.aspose.com/slides/zh/java/com.aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/zh/java/com.aspose.slides/LineArrowheadLength)。
- 将修改后的演示文稿写入 PPTX 文件。

```java
// 实例化表示 PPTX 文件的 PresentationEx 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加类型为 line 的 AutoShape
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 对线条应用一些格式设置
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // 将 PPTX 写入磁盘
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常见问题**

**我可以将普通直线转换为连接线，使其能够“捕捉”到形状吗？**

不能。普通直线（类型为 [Line](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/autoshape/)）不会自动成为连接线。若需要捕捉到形状，请使用专用的 [Connector](https://reference.aspose.com/slides/zh/java/com.aspose.slides/connector/) 类型以及用于连接的 [相应 API](/slides/zh/java/connector/)。

**如果直线的属性继承自主题，难以确定最终值，我该怎么办？**

通过 [ILineFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinefillformateffectivedata/) 接口读取 [有效属性](/slides/zh/java/shape-effective-properties/)，这些接口已考虑了继承和主题样式。

**我可以锁定直线，防止编辑（移动、调整大小）吗？**

可以。形状提供了 [锁定对象](https://reference.aspose.com/slides/zh/java/com.aspose.slides/autoshape/#getAutoShapeLock--)，可用于 [禁止编辑操作](/slides/zh/java/applying-protection-to-presentation/)。