---
title: 在 Android 上向演示文稿添加线形状
linktitle: 线条
type: docs
weight: 50
url: /zh/androidjava/Line/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 在 PowerPoint 演示文稿中操作线条格式。发现属性、方法和 Java 示例。"
---

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 支持向幻灯片添加各种形状。在本主题中，我们将通过向幻灯片添加线条来开始使用形状。使用 Aspose.Slides for Android via Java，开发人员不仅可以创建简单的线条，还可以在幻灯片上绘制一些华丽的线条。

{{% /alert %}} 

## **创建普通直线**

要在演示文稿的选定幻灯片上添加一条简单的普通直线，请按照以下步骤操作：

- 创建 Presentation 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 使用 IShapeCollection 对象提供的 [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加 Line 类型的 AutoShape。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已在演示文稿的第一张幻灯片上添加了一条线。
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


## **创建带箭头的直线**

Aspose.Slides for Android via Java 还允许开发人员配置线条的某些属性，使其更具吸引力。让我们尝试配置线条的几个属性，使其看起来像箭头。请按照以下步骤操作：

- 创建 Presentation 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 使用 IShapeCollection 对象提供的 [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加 Line 类型的 AutoShape。
- 将 [Line Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) 设置为 Aspose.Slides for Android via Java 提供的样式之一。
- 设置线条的宽度。
- 将线条的 [Dash Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) 设置为 Aspose.Slides for Android via Java 提供的样式之一。
- 设置线条起点的 [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength)。
- 设置线条终点的 [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength)。
- 将修改后的演示文稿写入为 PPTX 文件。
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

**我可以将普通线条转换为连接线，使其“捕捉”到形状吗？**

不可以。普通线条（类型为 [Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/)）不会自动变为连接线。要使其捕捉到形状，请使用专用的 [Connector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/) 类型以及用于连接的 [corresponding APIs](/slides/zh/androidjava/connector/)。

**如果线条的属性是从主题继承的，且难以确定最终值，我该怎么办？**

通过 [ILineFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinefillformateffectivedata/) 接口读取 [有效属性](/slides/zh/androidjava/shape-effective-properties/)，这些接口已经考虑了继承和主题样式。

**我可以锁定线条以防止编辑（移动、调整大小）吗？**

可以。形状提供 [lock objects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) 使您能够禁止编辑操作。