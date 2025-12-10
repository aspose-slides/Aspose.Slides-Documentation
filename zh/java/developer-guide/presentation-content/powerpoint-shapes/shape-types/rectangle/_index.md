---
title: 在 Java 中向演示文稿添加矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh/java/rectangle/
keywords:
- 添加矩形
- 创建矩形
- 矩形形状
- 简单矩形
- 格式化矩形
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 添加矩形，提升您的 PowerPoint 演示文稿—轻松以编程方式设计和修改形状。"
---

{{% alert color="primary" %}} 

和之前的主题一样，本章节也讨论添加形状，这次我们将讨论的形状是 **矩形**。在本章节中，我们描述了开发人员如何使用 Aspose.Slides for Java 向幻灯片添加简单或格式化的矩形。

{{% /alert %}} 

## **向幻灯片添加矩形**
要向演示文稿的选定幻灯片添加一个简单的矩形，请按以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
- 通过其索引获取幻灯片的引用。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，添加类型为矩形的 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)。
- 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们已向演示文稿的第一张幻灯片添加了一个简单的矩形。
```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加椭圆类型的 AutoShape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 将 PPTX 文件写入磁盘
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **向幻灯片添加格式化矩形**
要向幻灯片添加格式化矩形，请按以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
- 通过其索引获取幻灯片的引用。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，添加类型为矩形的 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)。
- 将矩形的 [Fill Type](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) 设置为 Solid。
- 使用与 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) 对象关联的 [IFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) 对象公开的 [SolidFillColor.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) 方法设置矩形的填充颜色。
- 设置矩形线条的颜色。
- 设置矩形线条的宽度。
- 将修改后的演示文稿写入 PPTX 文件。

上述步骤在下面的示例中实现。
```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加椭圆类型的 AutoShape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 对椭圆形状应用一些格式设置
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // 对椭圆的线条应用一些格式设置
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // 将 PPTX 文件写入磁盘
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**如何添加带圆角的矩形？**

使用圆角的 [shape type](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/)，并在形状属性中调整角半径；也可以通过几何调整对每个角单独进行圆角处理。

**如何用图像（纹理）填充矩形？**

选择图片 [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)，提供图像源，并配置 [stretching/tiling modes](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/)。

**矩形可以有阴影和发光效果吗？**

可以。外部/内部阴影、发光以及柔和边缘 [/slides/java/shape-effect/] 均可使用，并可调节参数。

**我可以把矩形设为带超链接的按钮吗？**

可以。将超链接 [/slides/java/manage-hyperlinks/] 赋给形状的点击事件（跳转到幻灯片、文件、网页地址或电子邮件）。

**如何保护矩形不被移动或修改？**

使用形状锁 [/slides/java/applying-protection-to-presentation/]：可以禁止移动、调整大小、选择或文本编辑，以保持布局不变。

**我可以将矩形转换为光栅图像或 SVG 吗？**

可以。您可以使用 [render the shape](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) 将形状渲染为指定大小/比例的图像，或使用 [export it as SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) 导出为 SVG 供矢量使用。

**如何快速获取考虑主题和继承后的矩形实际（有效）属性？**

使用形状的有效属性 [/slides/java/shape-effective-properties/]：API 返回已计算的值，包含主题样式、布局和本地设置的影响，简化格式分析。