---
title: 椭圆
type: docs
weight: 30
url: /zh/nodejs-java/ellipse/
---

{{% alert color="primary" %}} 

在本主题中，我们将向开发人员介绍如何使用 Aspose.Slides for Node.js via Java 向幻灯片中添加椭圆形。Aspose.Slides for Node.js via Java 提供了一套更简便的 API，只需几行代码即可绘制各种形状。

{{% /alert %}} 

## **创建椭圆**
要向演示文稿的选定幻灯片添加一个简单的椭圆，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
- 通过使用其 Index 获取幻灯片的引用。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加 Ellipse 类型的 AutoShape。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已向第一张幻灯片添加了一个椭圆
```javascript
// 实例化表示 PPTX 的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加椭圆类型的 AutoShape
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // 将 PPTX 文件写入磁盘
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **创建格式化椭圆**
要向幻灯片添加格式更好的椭圆，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
- 通过使用其 Index 获取幻灯片的引用。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加 Ellipse 类型的 AutoShape。
- 将椭圆的填充类型设置为 Solid。
- 使用与 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) 对象关联的 [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) 对象公开的 SolidFillColor.Color 属性设置椭圆的颜色。
- 设置椭圆线条的颜色。
- 设置椭圆线条的宽度。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已向演示文稿的第一张幻灯片添加了一个格式化的椭圆。
```javascript
// 实例化表示 PPTX 的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加椭圆类型的 AutoShape
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // 对椭圆形状应用一些格式设置
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // 对椭圆的线条应用一些格式设置
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // 将 PPTX 文件写入磁盘
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

 
## **常见问题**

**如何针对幻灯片的单位设置椭圆的精确位置和大小？**

坐标和尺寸通常以 **点** 为单位指定。为了获得可预测的结果，请基于幻灯片大小进行计算，并在赋值前将所需的毫米或英寸转换为点。

**如何将椭圆放置在其他对象的上方或下方（控制堆叠顺序）？**

通过将对象置于前面或发送到后面来调整绘制顺序。这可以让椭圆覆盖其他对象或显示其下方的对象。

**如何为椭圆添加出现或强调的动画？**

对形状应用 [Apply](/slides/zh/nodejs-java/shape-animation/) 进入、强调或退出效果，并配置触发器和时间，以安排动画的播放时机和方式。