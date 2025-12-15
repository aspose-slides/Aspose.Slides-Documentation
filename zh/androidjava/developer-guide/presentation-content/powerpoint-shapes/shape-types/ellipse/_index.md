---
title: 在 Android 上向演示文稿添加椭圆
linktitle: 椭圆
type: docs
weight: 30
url: /zh/androidjava/ellipse/
keywords:
- 椭圆
- 形状
- 添加椭圆
- 创建椭圆
- 绘制椭圆
- 格式化椭圆
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Android 中创建、格式化和操作椭圆形状，适用于 PPT 和 PPTX 演示文稿——包含 Java 代码示例。"
---

{{% alert color="primary" %}}
在本主题中，我们将向开发人员介绍如何使用 Aspose.Slides for Android via Java 在幻灯片中添加椭圆形状。Aspose.Slides for Android via Java 提供了一套更简便的 API，只需几行代码即可绘制各种形状。
{{% /alert %}}

## **创建椭圆**
要向演示文稿的选定幻灯片添加一个简单的椭圆，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
- 使用其 Index 获取幻灯片的引用。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加椭圆类型的 AutoShape。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已在第一张幻灯片上添加了一个椭圆
```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 添加椭圆类型的 AutoShape
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // 将 PPTX 文件写入磁盘
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **创建格式化的椭圆**
要在幻灯片上添加格式更好的椭圆，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
- 使用其 Index 获取幻灯片的引用。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加椭圆类型的 AutoShape。
- 将椭圆的填充类型设置为实心。
- 使用由与 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) 对象关联的 [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) 对象公开的 SolidFillColor.Color 属性设置椭圆的颜色。
- 设置椭圆线条的颜色。
- 设置椭圆线条的宽度。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已在演示文稿的第一张幻灯片上添加了一个格式化的椭圆。
```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加椭圆类型的 AutoShape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 对椭圆形状应用一些格式设置
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // 对椭圆的线条应用一些格式设置
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // 将 PPTX 文件写入磁盘
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**如何根据幻灯片的单位设置椭圆的精确位置和大小？**

坐标和尺寸通常以 **点** 为单位指定。为获得可预测的结果，请基于幻灯片尺寸进行计算，并在赋值前将所需的毫米或英寸转换为点。

**如何将椭圆放置在其他对象之上或之下（控制堆叠顺序）？**

通过将对象置于最前或发送到最背后来调整绘制顺序。这样可以让椭圆覆盖其他对象或显示其下方的对象。

**如何为椭圆添加出现或强调的动画效果？**

[Apply](/slides/zh/androidjava/shape-animation/) 进入、强调或退出效果到形状，并配置触发器和时间，以决定动画何时以及如何播放。