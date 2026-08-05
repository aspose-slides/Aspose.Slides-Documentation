---
title: 在 Android 上向演示文稿添加线形状
linktitle: 线
type: docs
weight: 50
url: /zh/androidjava/line/
keywords:
- 线
- 创建线条
- 添加线条
- 普通线条
- 配置线条
- 自定义线条
- 虚线样式
- 箭头
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 操作 PowerPoint 演示文稿中的线条格式。探索属性、方法及 Java 示例。"
---
## **概述**

Aspose.Slides 允许您以编程方式向 PowerPoint 幻灯片添加线形状。本文展示了如何创建一条简单的线以及如何自定义线使其显示为箭头。

您将学习如何向幻灯片添加线形状、调整其外观并保存更新后的演示文稿。示例侧重于实用的线格式设置，如样式、宽度、虚线模式、箭头样式和填充颜色。

## **创建普通线条**

要向演示文稿的选定幻灯片添加一条普通线，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。
- 使用索引获取幻灯片的引用。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加类型为 Line 的 AutoShape。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们在演示文稿的第一张幻灯片上添加了一条线。

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

## **创建箭头形线条**

Aspose.Slides for Android via Java 还允许开发者配置线的属性以使其更具吸引力。让我们尝试配置几个属性，使线看起来像箭头。请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。
- 使用索引获取幻灯片的引用。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加类型为 Line 的 AutoShape。
- 将 [Line Style](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/LineStyle) 设置为 Aspose.Slides for Android via Java 提供的某种样式。
- 设置线的宽度。
- 将线的 [Dash Style](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/LineDashStyle) 设置为 Aspose.Slides for Android via Java 提供的某种样式。
- 设置线起点的 [Arrow Head Style](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/LineArrowheadLength)。
- 设置线终点的 [Arrow Head Style](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/LineArrowheadLength)。
- 将修改后的演示文稿写入为 PPTX 文件。

```java
// 实例化表示 PPTX 文件的 PresentationEx 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加类型为 line 的 AutoShape
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 对线进行一些格式设置
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

## **常见问题解答**

**我可以将普通线转换为连接线以便它“捕捉”到形状吗？**

不能。普通线（类型为 [Line](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/autoshape/)）不会自动变为连接线。要使其捕捉到形状，请使用专用的 [Connector](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/connector/) 类型以及用于连接的 [corresponding APIs](/slides/zh/androidjava/connector/)。

**如果线的属性继承自主题且难以确定最终值，我该怎么办？**

通过 [ILineFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilinefillformateffectivedata/) 接口阅读 [Read the effective properties](/slides/zh/androidjava/shape-effective-properties/)——这些已考虑继承和主题样式。

**我可以锁定线条以防止编辑（移动、大小调整）吗？**

可以。形状提供了 [lock objects](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--)，可阻止编辑操作。