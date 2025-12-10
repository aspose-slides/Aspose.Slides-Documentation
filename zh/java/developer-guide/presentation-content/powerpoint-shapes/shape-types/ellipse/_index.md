---
title: 在 Java 中向演示文稿添加椭圆
linktitle: 椭圆
type: docs
weight: 30
url: /zh/java/ellipse/
keywords:
- 椭圆
- 形状
- 添加椭圆
- 创建椭圆
- 绘制椭圆
- 格式化椭圆
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中创建、格式化和操作 PPT 与 PPTX 演示文稿中的椭圆形状——附带 Java 代码示例。"
---

{{% alert color="primary" %}}

在本主题中，我们将向开发者介绍如何使用 Aspose.Slides for Java 向幻灯片添加椭圆形。Aspose.Slides for Java 提供了一套更简便的 API，只需几行代码即可绘制各种形状。

{{% /alert %}}

## **创建椭圆**
要在演示文稿的选定幻灯片上添加一个简单的椭圆，请按以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
- 使用索引获取幻灯片的引用。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，添加椭圆类型的 AutoShape。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已在第一张幻灯片添加了一个椭圆
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


## **创建格式化椭圆**
要向幻灯片添加格式更好的椭圆，请按以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
- 使用索引获取幻灯片的引用。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，添加椭圆类型的 AutoShape。
- 将椭圆的填充类型设置为实心。
- 使用与 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) 对象关联的 [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) 对象公开的 SolidFillColor.Color 属性来设置椭圆的颜色。
- 设置椭圆线条的颜色。
- 设置椭圆线条的宽度。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已在演示文稿的第一张幻灯片添加了一个格式化的椭圆。
```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加椭圆类型的 AutoShape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 对椭圆形状应用一些格式化
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // 对椭圆线条应用一些格式化
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

**如何相对于幻灯片的单位设置椭圆的精确位置和大小？**

坐标和尺寸通常以 **点** 为单位指定。为获得可预期的结果，请以幻灯片大小为基准，在赋值前将所需的毫米或英寸转换为点。

**如何将椭圆放置在其他对象之上或之下（控制堆叠顺序）？**

通过将对象置于前面或发送到后面来调整绘制顺序。这样可使椭圆覆盖其他对象或显示其下方的对象。

**如何为椭圆添加出现或强调的动画效果？**

[Apply](/slides/zh/java/shape-animation/) 进入、强调或退出效果到形状，并配置触发器和时间，以编排动画的播放时机和方式。