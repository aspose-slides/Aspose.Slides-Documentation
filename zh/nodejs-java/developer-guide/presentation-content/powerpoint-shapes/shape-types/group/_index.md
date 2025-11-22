---
title: 组
type: docs
weight: 40
url: /zh/nodejs-java/group/
---

## **添加组形状**
Aspose.Slides 支持在幻灯片上使用组形状。此功能帮助开发人员创建更丰富的演示文稿。Aspose.Slides for Node.js via Java 支持添加或访问组形状。可以向已添加的组形状中添加形状以填充它或访问组形状的任何属性。要使用 Aspose.Slides for Node.js via Java 将组形状添加到幻灯片：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过使用索引获取幻灯片的引用
3. 向幻灯片添加组形状。
4. 向已添加的组形状中添加形状。
5. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例向幻灯片添加组形状。
```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 访问幻灯片的形状集合
    var slideShapes = sld.getShapes();
    // 向幻灯片添加组形状
    var groupShape = slideShapes.addGroupShape();
    // 向已添加的组形状中添加形状
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // 添加组形状框架
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // 将 PPTX 文件写入磁盘
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **访问 AltText 属性**
本主题展示了简单的步骤，并附有代码示例，用于在幻灯片上添加组形状并访问其 AltText 属性。要使用 Aspose.Slides for Node.js via Java 访问幻灯片中组形状的 AltText：

1. 实例化表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类。
2. 通过使用索引获取幻灯片的引用。
3. 访问幻灯片的形状集合。
4. 访问组形状。
5. 调用 [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) 属性。

下面的示例访问组形状的替代文本。
```javascript
// 实例化表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // 访问幻灯片的形状集合
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // 访问组形状。
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // 访问 AltText 属性
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**是否支持嵌套分组（组内组）？**

是的。[GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) 具有 [getParentGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getparentgroup/) 方法，可直接表明层次结构支持（一个组可以是另一个组的子组）。

**如何控制组在幻灯片上相对于其他对象的 Z 顺序？**

使用 [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) 的 [getZOrderPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getzorderposition/) 方法来检查其在显示堆栈中的位置。

**我能阻止移动/编辑/取消分组吗？**

是的。组的锁定部分可通过 [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/getgroupshapelock/) 访问，您可以使用它限制对该对象的操作。