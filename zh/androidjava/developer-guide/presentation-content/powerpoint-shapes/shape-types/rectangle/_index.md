---
title: 在 Android 上向演示文稿添加矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh/androidjava/rectangle/
keywords:
- 添加矩形
- 创建矩形
- 矩形形状
- 简单矩形
- 格式化矩形
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "通过使用 Aspose.Slides for Android via Java 添加矩形，提升您的 PowerPoint 演示文稿——轻松以编程方式设计和修改形状。"
---

{{% alert color="primary" %}} 

和之前的主题一样，本主题也关于添加形状，这次我们讨论的形状是 **矩形**。在本主题中，我们描述了开发者如何使用 Aspose.Slides for Android via Java 将简单或格式化的矩形添加到幻灯片。

{{% /alert %}} 

## **向幻灯片添加矩形**
要向演示文稿中选定的幻灯片添加一个简单矩形，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
- 通过使用索引获取幻灯片的引用。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，添加类型为 Rectangle 的 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)。
- 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们已在演示文稿的第一张幻灯片上添加了一个简单矩形。
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
要向幻灯片添加格式化矩形，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
- 通过使用索引获取幻灯片的引用。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，添加类型为 Rectangle 的 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)。
- 将矩形的 [Fill Type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) 设置为 Solid。
- 使用由关联的 [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) 对象公开的 [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) 方法设置矩形的颜色。
- 设置矩形线条的颜色。
- 设置矩形线条的宽度。
- 将修改后的演示文稿写入 PPTX 文件。

上述步骤已在下面的示例中实现。
```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加椭圆类型的 AutoShape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 为椭圆形状应用一些格式设置
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // 为椭圆的线条应用一些格式设置
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // 将 PPTX 文件写入磁盘
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**如何添加带圆角的矩形？**

使用圆角 [shape type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) 并在形状属性中调整角半径；也可以通过几何调整对每个角单独进行圆化。

**如何使用图像（纹理）填充矩形？**

选择图片 [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/)，提供图像源，并配置 [stretching/tiling modes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/)。

**矩形可以具有阴影和发光效果吗？**

可以。[Outer/inner shadow, glow, and soft edges](/slides/zh/androidjava/shape-effect/) 均可使用，并提供可调参数。

**我可以将矩形变成带超链接的按钮吗？**

可以。为形状点击分配超链接 [Assign a hyperlink](/slides/zh/androidjava/manage-hyperlinks/)（跳转到幻灯片、文件、网页地址或电子邮件）。

**如何防止矩形被移动或修改？**

[Use shape locks](/slides/zh/androidjava/applying-protection-to-presentation/)：可以禁止移动、调整大小、选择或文本编辑，以保持布局不变。

**我能将矩形转换为光栅图像或 SVG 吗？**

可以。您可以使用 [render the shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) 将形状渲染为指定大小/比例的图像，或使用 [export it as SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) 导出为 SVG 以供矢量使用。

**如何快速获取矩形在考虑主题和继承情况下的实际（有效）属性？**

[Use the shape’s effective properties](/slides/zh/androidjava/shape-effective-properties/)：API 返回计算后的值，已考虑主题样式、布局和本地设置，简化格式分析。