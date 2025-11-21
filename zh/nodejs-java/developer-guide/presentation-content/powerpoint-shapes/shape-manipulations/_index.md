---
title: 形状操作
type: docs
weight: 40
url: /zh/nodejs-java/shape-manipulations/
---

## **在幻灯片中查找形状**
本主题将描述一种简便方法，帮助开发人员在幻灯片上查找特定形状，而无需使用其内部 Id。需要了解的是，PowerPoint 演示文稿文件没有除内部唯一 Id 之外的方式来标识幻灯片上的形状。开发人员使用内部唯一 Id 查找形状往往较为困难。所有添加到幻灯片的形状都有一些备用文本。我们建议开发人员使用备用文本来查找特定形状。您可以使用 Microsoft PowerPoint 为计划以后更改的对象定义备用文本。

在为任意所需形状设置备用文本后，您即可使用 Aspose.Slides for Node.js via Java 打开该演示文稿，并遍历幻灯片中添加的所有形状。在每次遍历时，检查形状的备用文本，匹配的备用文本即为您需要的形状。为更好地演示此技术，我们创建了一个方法，[findShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-)，可实现查找幻灯片中指定形状并返回该形状。
```javascript
// 实例化一个表示演示文稿文件的 Presentation 类
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // 要查找的形状的备用文本
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```


## **克隆形状**
使用 Aspose.Slides for Node.js via Java 将形状克隆到幻灯片的步骤：

1. 创建 [演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问源幻灯片的形状集合。
1. 向演示文稿中添加新幻灯片。
1. 将形状从源幻灯片的形状集合克隆到新幻灯片。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例向幻灯片添加了一个组形状。
```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // 将 PPTX 文件写入磁盘
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **删除形状**
Aspose.Slides for Node.js via Java 允许开发人员删除任意形状。要从幻灯片中删除形状，请按以下步骤操作：

1. 创建 [演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定 AlternativeText 的形状。
1. 删除该形状。
1. 将文件保存到磁盘。
```javascript
// 创建 Presentation 对象
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加矩形类型的自动形状
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // 将演示文稿保存到磁盘
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **隐藏形状**
Aspose.Slides for Node.js via Java 允许开发人员隐藏任意形状。要隐藏幻灯片中的形状，请按以下步骤操作：

1. 创建 [演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定 AlternativeText 的形状。
1. 隐藏该形状。
1. 将文件保存到磁盘。
```javascript
// 实例化表示 PPTX 的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加矩形类型的自动形状
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // 将演示文稿保存到磁盘
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **更改形状顺序**
Aspose.Slides for Node.js via Java 允许开发人员重新排列形状。重新排列可指定哪个形状位于前面，哪个位于后面。要重新排列幻灯片中的形状，请按以下步骤操作：

1. 创建 [演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个形状。
1. 在形状的文本框中添加一些文本。
1. 添加另一个具有相同坐标的形状。
1. 重新排列这些形状。
1. 将文件保存到磁盘。
```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **获取互操作形状 ID**
Aspose.Slides for Node.js via Java 允许开发人员获取幻灯片范围内的唯一形状标识符，这与 [getUniqueId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getUniqueId--) 方法（获取演示文稿范围内的唯一标识符）不同。方法 [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) 已被添加到 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) 类中。该方法返回的值对应 Microsoft.Office.Interop.PowerPoint.Shape 对象的 Id。下面给出示例代码。
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 获取幻灯片范围内唯一的形状标识符
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **为形状设置备用文本**
Aspose.Slides for Node.js via Java 允许开发人员设置任意形状的 AlternateText。演示文稿中的形状可以通过 [AlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) 或 [Shape Name](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setName-java.lang.String-) 方法加以区分。可以使用 Aspose.Slides 以及 Microsoft PowerPoint 读取或设置 [setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) 和 [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) 方法。通过此方法，您可以标记形状，并执行删除形状、隐藏形状或重新排列形状等不同操作。设置形状的 AlternateText 请按以下步骤操作：

1. 创建 [演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 向幻灯片添加任意形状。
1. 对新添加的形状进行一些操作。
1. 遍历形状以查找目标形状。
1. 设置 AlternativeText。
1. 将文件保存到磁盘。
```javascript
// 实例化表示 PPTX 的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加矩形类型的自动形状
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // 将演示文稿保存到磁盘
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **访问形状的布局格式**
Aspose.Slides for Node.js via Java 提供了简易的 API 来访问形状的布局格式。本文演示如何访问布局格式。

下面给出示例代码。
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将形状渲染为 SVG**
现在 Aspose.Slides for Node.js via Java 支持将形状渲染为 SVG。已经在 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) 类中添加了方法 [writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-)（及其重载），该方法可将形状内容保存为 SVG 文件。下面的代码片段展示如何将幻灯片的形状导出为 SVG 文件。
```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **形状对齐**
Aspose.Slides 允许将形状相对于幻灯片边距或相互之间进行对齐。为此，已添加重载方法 [SlidesUtil.alignShape()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-)。枚举 [ShapesAlignmentType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapesAlignmentType) 定义了可能的对齐选项。

**示例 1**

下面的源代码将索引为 1、2 和 4 的形状对齐到幻灯片顶部边界。
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**示例 2**

下面的示例展示如何将整个形状集合相对于集合中最底部的形状进行对齐。
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **翻转属性**

在 Aspose.Slides 中，类 [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) 通过其 `flipH` 和 `flipV` 属性提供对形状水平和垂直镜像的控制。这两个属性的类型为 `byte`，取值为 `1` 表示翻转，`0` 表示不翻转，`-1` 表示使用默认行为。这些值可通过形状的 [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) 访问。

要修改翻转设置，可使用形状当前的位置和大小、期望的 `flipH`、`flipV` 值以及旋转角度构造一个新的 [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) 实例。将该实例分配给形状的 [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) 并保存演示文稿，即可应用镜像变换并写入输出文件。

假设我们有一个 sample.pptx 文件，其中第一页包含一个默认翻转设置的单一形状，如下所示。

![要翻转的形状](shape_to_be_flipped.png)

下面的代码示例获取形状的当前翻转属性，并同时进行水平和垂直翻转。
```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // 检索形状的水平翻转属性。
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // 检索形状的垂直翻转属性。
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // 水平翻转。
    var flipV = java.newByte(asposeSlides.NullableBool.True); // 垂直翻转。
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


结果：

![已翻转的形状](flipped_shape.png)

## **常见问题**

**我可以像桌面编辑器那样在幻灯片上对形状进行合并（联合/相交/相减）吗？**

目前没有内置的布尔运算 API。您可以通过自行构建所需轮廓来近似实现——例如，计算结果几何形状（使用 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)），然后使用该轮廓创建新形状，必要时删除原始形状。

**如何控制层叠顺序（z 顺序），使形状始终位于“顶部”？**

更改幻灯片的 [shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) 集合中的插入/移动顺序。为获得可预测的结果，请在完成所有其他幻灯片修改后最终确定 z 顺序。

**我能“锁定”形状，以防止用户在 PowerPoint 中编辑它吗？**

可以。设置 [shape-level protection flags](/slides/zh/nodejs-java/applying-protection-to-presentation/)（例如锁定选择、移动、大小调整、文本编辑）。如有需要，可在母版或布局上镜像这些限制。请注意，这是一种 UI 级别的保护，而非安全特性；若需更强的保护，可结合文件级别的限制，如 [只读建议或密码](/slides/zh/nodejs-java/password-protected-presentation/)。