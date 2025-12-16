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
description: "了解如何使用 Aspose.Slides for Android 操作 PowerPoint 演示文稿中的线条格式。探索属性、方法和 Java 示例。"
---

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 支持向幻灯片添加各种形状。在本主题中，我们将通过向幻灯片添加线条开始使用形状。使用 Aspose.Slides for Android via Java，开发人员不仅可以创建简单的线条，还可以在幻灯片上绘制一些精美的线条。

{{% /alert %}} 

## **创建普通线条**

要向演示文稿的选定幻灯片添加一条简单的普通线，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。  
- 通过使用其 Index 获取幻灯片的引用。  
- 使用 [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加 Line 类型的 AutoShape。  
- 将修改后的演示文稿写入 PPTX 文件。  

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


## **创建箭头形状的线条**

Aspose.Slides for Android via Java 还允许开发人员配置线条的某些属性，使其外观更具吸引力。让我们尝试配置几项属性，使线条看起来像箭头。请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。  
- 通过使用其 Index 获取幻灯片的引用。  
- 使用 [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加 Line 类型的 AutoShape。  
- 将 [Line Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) 设置为 Aspose.Slides for Android via Java 提供的样式之一。  
- 设置线条的宽度。  
- 将线条的 [Dash Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) 设置为 Aspose.Slides for Android via Java 提供的样式之一。  
- 设置线条起点的 [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength)。  
- 设置线条终点的 [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength)。  
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

**我可以将普通线条转换为连接器，使其“捕捉”到形状吗？**

不。普通线条（类型为 [Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/)）不会自动变为连接器。要使其捕捉到形状，请使用专用的 [Connector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/) 类型以及用于连接的 [corresponding APIs](/slides/zh/androidjava/connector/)。

**如果线条的属性从主题继承，且难以确定最终值，我该怎么办？**

通过 [阅读有效属性](/slides/zh/androidjava/shape-effective-properties/) 使用 [ILineFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinefillformateffectivedata/) 接口——这些已经考虑了继承和主题样式。

**我可以锁定线条，以防止编辑（移动、调整大小）吗？**

是的。形状提供了 [锁定对象](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--)，可让您 [禁止编辑操作](/slides/zh/androidjava/applying-protection-to-presentation/)。