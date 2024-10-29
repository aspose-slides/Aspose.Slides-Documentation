---
title: 线
type: docs
weight: 50
url: /zh/java/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides for Java 支持向幻灯片添加不同类型的形状。在本主题中，我们将通过向幻灯片添加线条来开始处理形状。使用 Aspose.Slides for Java，开发人员不仅可以创建简单的线条，还可以在幻灯片上绘制一些花式线条。

{{% /alert %}} 

## **创建简单线条**

要将简单的线条添加到演示文稿的选定幻灯片中，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
- 使用其索引获取幻灯片的引用。
- 使用 [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加一个线型的 AutoShape，通过 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 对象提供。
- 将修改后的演示文稿写入 PPTX 文件。

在下面给出的示例中，我们已向演示文稿的第一张幻灯片添加了一条线。

```java
// 实例化表示 PPTX 文件的 PresentationEx 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 添加一个类型为线的 AutoShape
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // 将 PPTX 写入磁盘
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **创建箭头形状线段**

Aspose.Slides for Java 还允许开发人员配置线条的一些属性，使其看起来更具吸引力。让我们尝试配置几种线条的属性，使其看起来像箭头。请按照以下步骤进行：

- 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
- 使用其索引获取幻灯片的引用。
- 使用 [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加一个线型的 AutoShape，通过 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 对象提供。
- 将 [线条样式](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) 设置为 Aspose.Slides for Java 提供的样式之一。
- 设置线条的宽度。
- 将 [虚线样式](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) 设置为 Aspose.Slides for Java 提供的样式之一。
- 设置线条起点的 [箭头头样式](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) 和 [长度](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength)。
- 设置线条终点的 [箭头头样式](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) 和 [长度](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength)。
- 将修改后的演示文稿写入 PPTX 文件。

```java
// 实例化表示 PPTX 文件的 PresentationEx 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加一个类型为线的 AutoShape
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 对线条应用一些格式
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