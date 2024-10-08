---
title: 矩形
type: docs
weight: 80
url: /zh/androidjava/rectangle/
---

{{% alert color="primary" %}} 

和之前的主题一样，这个主题也涉及到添加形状，这次我们讨论的形状是**矩形**。在本主题中，我们描述了开发人员如何通过Java使用Aspose.Slides for Android将简单或格式化的矩形添加到他们的幻灯片中。

{{% /alert %}} 

## **向幻灯片添加矩形**
要向选定的演示文稿幻灯片添加简单矩形，请按照以下步骤操作：

- 创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例。
- 使用索引获取幻灯片的引用。
- 使用[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)对象暴露的[addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)方法添加一个矩形类型的[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)。
- 将修改后的演示文稿写入PPTX文件。

在下面的示例中，我们向演示文稿的第一张幻灯片添加了一个简单的矩形。

```java
// 实例化表示PPTX的Presentation类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加椭圆形的AutoShape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 将PPTX文件保存到磁盘
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **向幻灯片添加格式化矩形**
要向幻灯片添加格式化的矩形，请按照以下步骤操作：

- 创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例。
- 使用索引获取幻灯片的引用。
- 使用[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)对象暴露的[addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)方法添加一个矩形类型的[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)。
- 将矩形的[填充类型](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType)设置为实心。
- 使用[SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-)方法设置矩形的颜色，该方法由与[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)对象相关的[IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat)对象暴露。
- 设置矩形的线条颜色。
- 设置矩形的线条宽度。
- 将修改后的演示文稿写入PPTX文件。

上述步骤在下面的示例中得以实现。

```java
// 实例化表示PPTX的Presentation类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加椭圆形的AutoShape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 对椭圆形应用一些格式
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // 对椭圆形的线条应用一些格式
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // 将PPTX文件保存到磁盘
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```