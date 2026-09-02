---
title: 在 JavaScript 中管理演示文稿形状
linktitle: 形状操作
type: docs
weight: 40
url: /zh/nodejs-java/shape-manipulations/
keywords:
- PowerPoint 形状
- 演示文稿形状
- 幻灯片上的形状
- 查找形状
- 克隆形状
- 删除形状
- 隐藏形状
- 更改形状顺序
- 获取互操作形状 ID
- 形状替代文本
- 形状调整点
- 预设形状调整
- 形状几何
- 形状布局格式
- 形状为 SVG
- 形状转 SVG
- 对齐形状
- 翻转形状
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 对演示文稿形状进行识别、调整、克隆、删除、隐藏、重新排序、导出、对齐和翻转。"
---
## **概述**

Aspose.Slides for Node.js via Java 将幻灯片上的形状表示为有序的[ShapeCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/)。该集合既是查找和修改形状的场所，也是它们堆叠顺序的来源：索引 `0` 为最底层形状，最后一个索引为最上层形状。

本文遵循该模型。首先说明如何可靠地识别形状并修改预设的形状调整点，然后展示如何克隆、删除、隐藏和重新排序形状。最后几节覆盖布局层级的格式化、SVG 导出、对齐和翻转设置。每个示例都是独立的，您可以只使用工作流所需的操作。

## **识别并查找形状**

在处理已知文件时集合索引很方便，但它们不是稳定的标识符。添加、删除或重新排序形状都会改变其索引。根据演示文稿的创建和维护方式选择标识符：

- [Name](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/getname/) 对于开发者控制的模板有用，并且可以在 PowerPoint 的“选择窗格”中查看。名称可以编辑，但不保证唯一，如代码依赖名称请制定命名约定。
- [AlternativeText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/getalternativetext/) 在已经有可访问性描述或作者提供的标签标识形状时有用。它对用户可见，可能会本地化或为可访问性重写，并且不保证唯一。不要将有意义的可访问性文本悄悄用作数据库键。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) 是只读标识符，在同一幻灯片内唯一，对应 PowerPoint 互操作使用的形状 ID。将其用于与 PowerPoint 集成或在形状生命周期内需要明确引用的场景。克隆或重新创建的形状是不同的形状，会获得自己的 ID。

相关的[getUniqueId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/getuniqueid/) 方法返回演示文稿范围的标识符，但该标识符面向插件，可能会被重新分配，不应视为永久的外部键。如果长期身份至关重要，请在应用程序数据中保持映射并验证预期形状仍然存在。

下面的示例使用精确比较按名称搜索，并报告幻灯片范围的互操作 ID。当模板不包含预期形状时，代码会报告该结果而不是继续使用错误对象。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

当操作特定于某种形状类型时，请在使用特定成员前检查运行时类。此示例仅在命名对象是[AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)时更新文本和替代文本。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **识别并修改预设形状调整**

预设几何形状可以暴露控制圆角大小、箭头比例或弧度等特性的调整点。通过只读的[GeometryShape.getAdjustments](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/geometryshape/)集合访问它们。集合本身由形状提供，但每个[AdjustValue](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/adjustvalue/)包含一个可以更改的值。

不要仅依赖固定的集合索引。遍历所有调整并检查只读的[getType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/adjustvalue/) 方法，其[ShapeAdjustmentType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapeadjustmenttype/) 值描述了该调整控制的内容。只读的[getName](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/adjustvalue/getname/) 方法提供额外的识别信息，尤其在同一预设包含多个相同语义类型的调整时非常有用。

使用与调整含义相匹配的方法：

| 调整类型 | 用途 | 要更改的值 |
|---|---|---|
| `CornerSize` | 圆角的大小 | [setRawValue](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | 箭尾的粗细 | `setRawValue` |
| `ArrowheadLength` | 箭头的长度 | `setRawValue` |
| `ArrowheadWidth` | 箭头的宽度 | `setRawValue` |
| `StartAngle` | 饼图或弧的起始角度 | [setAngleValue](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | 饼图或弧的结束角度 | `setAngleValue` |

`getType` 和 `getName` 返回只读信息。`getRawValue` 与 `setRawValue` 使用预设本身的几何单位整数，而 `getAngleValue` 与 `setAngleValue` 使用度数。调整的数量、顺序、含义以及有效范围取决于预设的[GeometryShape.getShapeType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/geometryshape/)。对一种预设有效的值在另一种预设中可能无效或产生不同效果。

当 `getType` 返回 `ShapeAdjustmentType.Custom` 时，API 未识别标准语义含义。检查 `getName`、预设类型和现有值，除非已知预期含义和范围，否则保持调整不变。即使是已识别的类型，在选择值之前也要检查同一类型是否出现多次。关于连接线弯曲调整的情况，请参阅[Connector](/slides/zh/nodejs-java/connector/)文章。

下面的完整示例创建了三个预设形状的默认和修改版本。它遍历每个调整，报告其名称和类型，通过 `setRawValue` 更改尺寸相关的值，通过 `setAngleValue` 更改角度，并保存结果。左列保留默认几何，右列显示调整后的圆角矩形、四向箭头和饼形。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // 为默认和调整后的形状列添加标题。
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在更改值之前检查语义类型，使代码意图明确，并避免假设不同预设形状的同一集合索引具有相同含义。

## **修改形状集合**

添加、克隆、删除和重新排序方法会立即作用于集合。如果操作改变了形状数量或顺序，请不要继续依赖该操作之前捕获的索引。

### **克隆形状**

[addClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/addclone/) 创建独立副本并追加到目标集合。[insertClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/insertclone/) 也创建副本，但将其放在指定的 Z 顺序索引。接受坐标的重载在不改变大小的情况下移动克隆；带宽高参数的重载还能对其进行缩放。

示例创建目标幻灯片，将标记矩形克隆到最前面，并在最底部插入第二个克隆。对任一克隆的更改都不会影响源形状。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

克隆会复制形状的内容和格式，包括名称和替代文本。当这些值必须唯一时，请为克隆分配新的逻辑标识符。复杂形状使用的资源由演示文稿管理，但克隆仍是集合中的新项目，拥有新的形状标识。

### **删除形状**

[remove](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/remove/) 从其集合中删除特定形状对象。若在索引遍历期间删除多个匹配项，请从末尾向前遍历，以确保每个剩余索引仍有效。

该示例删除所有具有指定名称的形状。它读取当前索引处的形状，并不假设特定形状类型。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

删除后，形状计数以及后续形状的索引会改变。对未受影响形状的引用比保存的索引更可靠。同时考虑连接线、动画以及可能引用已删除对象的其他演示功能；删除可见形状可能会影响幻灯片的外观以外的内容。

### **隐藏形状**

将[Hidden](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/sethidden/) 设置为 `true` 会保留形状在集合中，但阻止其在普通幻灯片放映中出现。其索引、格式和内容仍可供代码使用，因此隐藏适用于以后可能恢复的可选元素。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

隐藏并非删除或安全措施。用户或代码仍可发现并取消隐藏该对象，它仍是演示文件的一部分。

### **更改 Z 顺序**

重叠形状按照集合顺序绘制。[reorder](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/reorder/) 将已有形状移动到目标索引而不克隆。索引 `0` 为最底层，`size() - 1` 为最顶层。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

矩形最先创建，最初位于椭圆后面。将其移动到最后索引后位于前面。添加或克隆所有相关形状后再确定 Z 顺序，因为这些操作会追加或插入新集合项，可能改变预期的堆叠。

## **检查布局幻灯片上的形状**

普通幻灯片、布局幻灯片和母版幻灯片拥有各自的形状集合。布局集合中的形状并非普通幻灯片上同位置形状的同一对象。需要了解或修改布局提供的格式时，请检查布局形状。

下面的示例读取每个布局形状的[FillFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/getfillformat/)和[LineFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/getlineformat/)，并且不假设每个形状都是 `AutoShape`。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

编辑布局可能影响使用该布局的多个幻灯片。更改布局形状前，请确定普通幻灯片是继承该对象还是包含本地覆盖，并测试使用该布局的每个幻灯片。

## **将形状导出为 SVG**

[writeAsSvg](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/writeassvg/) 将单个形状的渲染内容写入流。结果仅包含该形状，不包含整个幻灯片背景或相邻形状。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

渲染时请保持演示文稿打开。输出取决于形状的格式以及字体、图像等资源。如果需要完整的组合，请导出幻灯片而不是单个形状。调用方拥有流的所有权，必须关闭它。

## **对齐形状**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideutil/alignshapes/) 重载可以对所有形状或选定的集合索引进行对齐。[ShapesAlignmentType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapesalignmenttype/) 指定边缘、中心线或分布模式。将 `alignToSlide` 设置为 `true` 使用幻灯片边缘；设为 `false` 则相对选定形状之间对齐。

该示例将三个形状对齐到幻灯片顶部边缘。对齐前会立即将返回的形状引用转换为其当前索引。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

对齐会改变位置，而不是 Z 顺序。相对对齐通常需要至少两个形状，而水平或垂直分布则需要足够的形状来定义间距。如果在调用方法前修改了集合，请重新计算索引。

## **翻转形状**

[ShapeFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapeframe/) 类存储位置、大小、水平和垂直翻转设置以及旋转。其 `getFlipH` 和 `getFlipV` 值使用[NullableBool](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/nullablebool/)：`True` 启用翻转，`False` 禁用，`NotDefined` 保持未指定/默认状态。

下面的输入演示文稿包含一个未翻转的形状。

![The shape before flipping](shape_to_be_flipped.png)

示例保留其他所有帧值，仅替换两个翻转设置。这一点很重要，因为为[Frame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/setframe/) 赋新值会替换完整帧。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存后的形状在水平和垂直方向上均已镜像，同时保持位置、大小和旋转。

![The shape after flipping](flipped_shape.png)

## **常见问题**

**是否应该使用集合索引作为形状标识符？**

仅在集合在使用索引前不会改变的短期处理场景下使用。对作者模板建议使用经验证的 `Name` 或 `AlternativeText` 约定，对幻灯片范围的互操作工作则使用 `OfficeInteropShapeId`。

**隐藏形状会从 Z 顺序中移除吗？**

不会。隐藏的形状仍然位于相同索引的集合中。它仍可被查找、重新排序、编辑或再次显示。

**为什么克隆的形状出现在另一形状之前？**

`addClone` 将克隆追加到集合末尾，即 Z 顺序的最前面。使用 `insertClone` 可以选择初始索引，或在所有形状添加完毕后调用 `reorder`。

**可以使用固定索引来识别预设形状调整吗？**

仅在验证了确切的预设和集合布局后才可以。更推荐遍历 `GeometryShape.getAdjustments` 并检查 `AdjustValue.getType`；当同一语义类型出现多次时，使用 `AdjustValue.getName` 作为补充信息。