---
title: 形状有效属性
type: docs
weight: 50
url: /zh/nodejs-java/shape-effective-properties/
---

在本主题中，我们将讨论 **effective**（有效）和 **local**（本地）属性。当我们在以下层级直接设置值时

1. 在部分所在幻灯片的部分属性；
1. 在布局或母版幻灯片上的原型形状文本样式（如果该部分的文本框形状有的话）；
1. 在演示文稿的全局文本设置；

这些值称为 **local**（本地）值。 在任意层级，都可以定义或省略 **local**（本地）值。但当应用程序需要了解该部分应如何呈现时，它会使用 **effective**（有效）值。您可以通过从本地格式调用 **getEffective()** 方法获取有效值。

以下示例代码展示如何获取有效值：
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    var effectiveTextFrameFormat = localTextFrameFormat.getEffective();
    var localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    var effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **获取相机的有效属性**
Aspose.Slides for Node.js via Java 允许开发人员获取相机的有效属性。为此，已在 Aspose.Slides 中添加了 [**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) 类。该 [CameraEffectiveData] 类表示一个不可变对象，包含有效的相机属性。[**CameraEffectiveData**] 类的实例作为 [**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData) 类的一部分使用，该类是 [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) 类的 [有效值](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) 对。

以下示例代码展示如何获取相机的有效属性：
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective camera properties =");
    console.log("Type: " + threeDEffectiveData.getCamera().getCameraType());
    console.log("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    console.log("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **获取灯光装置的有效属性**
Aspose.Slides for Node.js via Java 允许开发人员获取灯光装置的有效属性。为此，已在 Aspose.Slides 中添加了 [**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) 类。该 [LightRigEffectiveData] 类表示一个不可变对象，包含有效的灯光装置属性。[**LightRigEffectiveData**] 类的实例作为 [**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData) 类的一部分使用，该类是 [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) 类的 [有效值](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) 对。

以下示例代码展示如何获取灯光装置的有效属性：
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective light rig properties =");
    console.log("Type: " + threeDEffectiveData.getLightRig().getLightType());
    console.log("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **获取斜面形状的有效属性**
Aspose.Slides for Node.js via Java 允许开发人员获取斜面形状的有效属性。为此，已在 Aspose.Slides 中添加了 [**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) 类。该 [ShapeBevelEffectiveData] 类表示一个不可变对象，包含有效的形状面部斜坡属性。[**ShapeBevelEffectiveData**] 类的实例作为 [**ThreeDFormatEffectiveData**]([**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData)) 类的一部分使用，该类是 [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) 类的 [有效值](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) 对。

以下示例代码展示如何获取斜面形状的有效属性：
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    console.log("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    console.log("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **获取文本框的有效属性**
使用 Aspose.Slides for Node.js via Java，您可以获取文本框的有效属性。为此，已在 Aspose.Slides 中添加了 [**TextFrameFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormatEffectiveData) 类。它包含有效的文本框格式属性。

以下示例代码展示如何获取有效的文本框格式属性：
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();
    console.log("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    console.log("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    console.log("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    console.log("Margins");
    console.log("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    console.log("   Top: " + effectiveTextFrameFormat.getMarginTop());
    console.log("   Right: " + effectiveTextFrameFormat.getMarginRight());
    console.log("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **获取文本样式的有效属性**
使用 Aspose.Slides for Node.js via Java，您可以获取文本样式的有效属性。为此，已在 Aspose.Slides 中添加了 [**TextStyleEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextStyleEffectiveData) 类。它包含有效的文本样式属性。

以下示例代码展示如何获取有效的文本样式属性：
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    for (var i = 0; i <= 8; i++) {
        var effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        console.log(("= Effective paragraph formatting for style level #" + i) + " =");
        console.log("Depth: " + effectiveStyleLevel.getDepth());
        console.log("Indent: " + effectiveStyleLevel.getIndent());
        console.log("Alignment: " + effectiveStyleLevel.getAlignment());
        console.log("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **获取有效的字体高度值**
使用 Aspose.Slides for Node.js via Java，您可以获取字体高度的有效属性。下面提供的代码演示了在不同演示文稿结构层级上设置本地字体高度后，部分的有效字体高度值如何变化：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();
    var portion0 = new aspose.slides.Portion("Sample text with first portion");
    var portion1 = new aspose.slides.Portion(" and second portion.");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    console.log("Effective font height after setting entire presentation default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.save("SetLocalFontHeightValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **获取表格的有效填充格式**
使用 Aspose.Slides for Node.js via Java，您可以获取不同表格逻辑部分的有效填充格式。为此，已在 Aspose.Slides 中添加了 [**CellFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CellFormatEffectiveData) 类。它包含有效的填充格式属性。请注意：单元格格式始终优先于行格式；行格式优先于列格式；列格式优先于整个表格。
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var tableFormatEffective = tbl.getTableFormat().getEffective();
    var rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    var columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    var cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();
    var tableFillFormatEffective = tableFormatEffective.getFillFormat();
    var rowFillFormatEffective = rowFormatEffective.getFillFormat();
    var columnFillFormatEffective = columnFormatEffective.getFillFormat();
    var cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**如何判断我得到的是“快照”而不是“实时对象”，以及何时需要重新读取有效属性？**

EffectiveData 对象是调用时计算值的不可变快照。如果您更改了形状的本地或继承设置，请重新获取有效数据以获得更新后的值。

**更改布局/母版幻灯片会影响已经获取的有效属性吗？**

会，但只有在您再次读取时才会生效。已经获取的 EffectiveData 对象不会自动更新——在更改布局或母版后请再次请求。

**我可以通过 EffectiveData 修改值吗？**

不能。EffectiveData 是只读的。请在本地格式对象（形状/文本/3D 等）中进行更改，然后再次获取有效值。

**如果在形状层级、布局/母版以及全局设置中都未设置某属性，会怎样？**

有效值将由默认机制（PowerPoint/Aspose.Slides 默认值）决定。该解析后的值会成为 EffectiveData 快照的一部分。

**从有效的字体值中，我能判断是哪个层级提供了大小或字体吗？**

不能直接判断。EffectiveData 只返回最终值。若要找出来源，请检查部分/段落/文本框的本地值以及布局/母版/演示文稿的文本样式，查看首次出现的显式定义。

**为什么 EffectiveData 值有时看起来与本地值相同？**

因为本地值最终成为了最终值（不需要更高层级的继承）。在这种情况下，有效值与本地值相匹配。

**何时应该使用有效属性，何时仅使用本地属性？**

当您需要在所有继承应用后获得“渲染后”结果时（例如对齐颜色、缩进或大小），请使用 EffectiveData。如果您只需在特定层级修改格式，请修改本地属性，然后在需要时重新读取 EffectiveData 以验证结果。