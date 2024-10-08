---
title: 椭圆
type: docs
weight: 30
url: /androidjava/ellipse/
---


{{% alert color="primary" %}} 

在本主题中，我们将向开发人员介绍如何使用 Aspose.Slides for Android via Java 将椭圆形添加到幻灯片中。Aspose.Slides for Android via Java 提供了一组更简单的 API，只需几行代码即可绘制不同类型的形状。

{{% /alert %}} 

## **创建椭圆**
要将简单的椭圆添加到演示文稿的选定幻灯片中，请按照以下步骤进行：

- 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) 对象暴露的 [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加一个椭圆类型的 AutoShape。
- 将修改后的演示文稿写入 PPTX 文件。

在下面给出的示例中，我们已将椭圆添加到第一页幻灯片。

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
要向幻灯片添加更好的格式化椭圆，请遵循以下步骤：

- 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) 对象暴露的 [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加一个椭圆类型的 AutoShape。
- 将椭圆的填充类型设置为实心。
- 使用 [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) 对象中与 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) 对象关联的 SolidFillColor.Color 属性设置椭圆的颜色。
- 设置椭圆的线条颜色。
- 设置椭圆的线条宽度。
- 将修改后的演示文稿写入 PPTX 文件。

在下面给出的示例中，我们已将格式化的椭圆添加到演示文稿的第一张幻灯片。

```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加椭圆类型的 AutoShape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 对椭圆形应用一些格式化
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // 对椭圆的线条应用一些格式化
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // 将 PPTX 文件写入磁盘
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```