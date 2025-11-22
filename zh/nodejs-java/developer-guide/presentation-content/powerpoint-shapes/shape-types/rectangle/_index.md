---
title: 矩形
type: docs
weight: 80
url: /zh/nodejs-java/rectangle/
---

{{% alert color="primary" %}} 

像前面的主题一样，这一节同样是关于添加形状的，这次我们将讨论的形状是 **矩形**。在本主题中，我们描述了开发人员如何使用 Aspose.Slides for Node.js via Java 向幻灯片添加简单或格式化的矩形。

{{% /alert %}} 

## **向幻灯片添加矩形**
要向演示文稿的选定幻灯片添加一个简单矩形，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
- 通过使用其 Index 获取幻灯片的引用。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 方法，添加类型为 Rectangle 的 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们向演示文稿的第一张幻灯片添加了一个简单的矩形。
```javascript
// 实例化表示 PPTX 的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加椭圆类型的 AutoShape
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // 将 PPTX 文件写入磁盘
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **向幻灯片添加格式化矩形**
要向幻灯片添加格式化矩形，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
- 通过使用其 Index 获取幻灯片的引用。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 方法，添加类型为 Rectangle 的 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。
- 将矩形的 [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) 设置为 Solid。
- 使用 [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) 对象关联的 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) 对象公开的 [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) 方法，设置矩形的颜色。
- 设置矩形线条的颜色。
- 设置矩形线条的宽度。
- 将修改后的演示文稿写入为 PPTX 文件。

上述步骤在下面的示例中实现。
```javascript
// 实例化表示 PPTX 的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加椭圆类型的 AutoShape
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // 对椭圆形状应用一些格式设置
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // 对椭圆的线条应用一些格式设置
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // 将 PPTX 文件写入磁盘
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**如何为矩形添加圆角？**

使用圆角 [形状类型](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) 并在形状属性中调整角半径；也可以通过几何调整对每个角单独进行圆角处理。

**如何使用图像（纹理）填充矩形？**

选择图片 [填充类型](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)，提供图像来源，并配置 [拉伸/平铺模式](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/)。

**矩形可以拥有阴影和发光效果吗？**

可以。[外部/内部阴影、发光和柔和边缘](/slides/zh/nodejs-java/shape-effect/) 可以使用可调参数。

**我可以把矩形变成带超链接的按钮吗？**

可以。通过在形状点击时 [分配超链接](/slides/zh/nodejs-java/manage-hyperlinks/)（跳转到幻灯片、文件、网页地址或电子邮件）来实现。

**如何防止矩形被移动或更改？**

[使用形状锁](/slides/zh/nodejs-java/applying-protection-to-presentation/)：可以禁止移动、调整大小、选择或编辑文本，以保持布局。

**我可以将矩形转换为光栅图像或 SVG 吗？**

可以。您可以将形状 [渲染形状](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) 为指定尺寸/比例的图像，或将其 [导出为 SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) 为 SVG 以供矢量使用。

**如何快速获取矩形的实际（有效）属性，考虑主题和继承？**

[使用形状的有效属性](/slides/zh/nodejs-java/shape-effective-properties/)：API 返回考虑主题样式、布局和本地设置的计算值，简化格式分析。