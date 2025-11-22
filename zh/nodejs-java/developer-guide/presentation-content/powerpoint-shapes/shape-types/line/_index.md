---
title: 线条
type: docs
weight: 50
url: /zh/nodejs-java/Line/
---

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java 支持向幻灯片添加不同类型的形状。在本主题中，我们将通过向幻灯片添加线条来开始使用形状。使用 Aspose.Slides for Node.js via Java，开发人员不仅可以创建简单的线条，还可以在幻灯片上绘制一些炫彩的线条。

{{% /alert %}} 

## **创建普通线条**

要在演示文稿的选定幻灯片中添加一条简单的普通线条，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
- 通过其索引获取幻灯片的引用。
- 使用由 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加线类型的 AutoShape。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已在演示文稿的第一张幻灯片上添加了一条线。
```javascript
// 实例化表示 PPTX 文件的 PresentationEx 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加类型为 line 的 AutoShape
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // 将 PPTX 写入磁盘
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **创建箭头形线条**

Aspose.Slides for Node.js via Java 还允许开发人员配置线条的某些属性，使其看起来更具吸引力。让我们尝试配置线条的几个属性，使其呈现为箭头。请按照以下步骤进行操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
- 通过其索引获取幻灯片的引用。
- 使用由 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加线类型的 AutoShape。
- 将 [Line Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineStyle) 设置为 Aspose.Slides for Node.js via Java 提供的样式之一。
- 设置线条的宽度。
- 将线条的 [Dash Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineDashStyle) 设置为 Aspose.Slides for Node.js via Java 提供的样式之一。
- 设置线条起点的 [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength)。
- 设置线条终点的 [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength)。
- 将修改后的演示文稿写入为 PPTX 文件。
```javascript
// 实例化表示 PPTX 文件的 PresentationEx 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加类型为 line 的 AutoShape
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // 对线条应用一些格式设置
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // 将 PPTX 写入磁盘
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**我可以将普通线转换为连接器，使其“捕捉”到形状吗？**

不可以。普通线（类型为 [Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)）不会自动变为连接器。要实现捕捉到形状，请使用专用的 [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) 类型以及用于连接的 [corresponding APIs](/slides/zh/nodejs-java/connector/)。

**如果线条的属性是从主题继承的，且难以确定最终值，我该怎么办？**

通过 `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` 类[读取有效属性](/slides/zh/nodejs-java/shape-effective-properties/)——这些已经考虑了继承和主题样式。

**我可以锁定线条以防止编辑（移动、调整大小）吗？**

可以。形状提供了 [lock objects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/getautoshapelock/)，让您可以[禁止编辑操作](/slides/zh/nodejs-java/applying-protection-to-presentation/)。