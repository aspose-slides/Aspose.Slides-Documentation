---
title: 在 JavaScript 中从演示文稿获取形状有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/nodejs-java/shape-effective-properties/
keywords:
- 形状属性
- 相机属性
- 光源装置
- 斜角形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解 Aspose.Slides for Node.js via Java 如何计算并应用形状的有效属性，以实现精确的 PowerPoint 渲染。"
---

在本主题中，我们将讨论 **effective** 和 **local** 属性。当我们在这些层级直接设置值时

1. 在片段所在幻灯片的片段属性上；
1. 在布局或母版幻灯片上的原型形状文本样式中（如果片段的文本框形状具有该样式）；
1. 在演示文稿的全局文本设置中；

这些值称为 **local** 值。在任何层级，**local** 值都可以被定义或省略。但当应用程序需要了解片段应该呈现怎样的外观时，它会使用 **effective** 值。您可以通过对本地格式调用 **getEffective()** 方法来获取 **effective** 值。

此示例代码演示如何获取 **effective** 值：
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


## **获取相机的 Effective 属性**
Aspose.Slides for Node.js via Java 允许开发人员获取相机的 Effective 属性。为此，Aspose.Slides 中添加了 **CameraEffectiveData** 类。**CameraEffectiveData** 类表示一个包含 Effective 相机属性的不可变对象。**CameraEffectiveData** 类的实例被用作 **ThreeDFormatEffectiveData** 类的一部分，该类是 [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) 与 [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) 类的配对。

此示例代码演示如何获取相机的 Effective 属性：
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


## **获取 Light Rig 的 Effective 属性**
Aspose.Slides for Node.js via Java 允许开发人员获取 Light Rig 的 Effective 属性。为此，Aspose.Slides 中添加了 **LightRigEffectiveData** 类。**LightRigEffectiveData** 类表示一个包含 Effective Light Rig 属性的不可变对象。**LightRigEffectiveData** 类的实例被用作 **ThreeDFormatEffectiveData** 类的一部分，该类是 [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) 与 [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) 类的配对。

此示例代码演示如何获取 Light Rig 的 Effective 属性：
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


## **获取 Bevel Shape 的 Effective 属性**
Aspose.Slides for Node.js via Java 允许开发人员获取 Bevel Shape 的 Effective 属性。为此，Aspose.Slides 中添加了 **ShapeBevelEffectiveData** 类。**ShapeBevelEffectiveData** 类表示一个包含形状面部凸起的 Effective 属性的不可变对象。**ShapeBevelEffectiveData** 类的实例被用作 **ThreeDFormatEffectiveData** 类的一部分，该类是 [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) 与 [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) 类的配对。

此示例代码演示如何获取 Bevel Shape 的 Effective 属性：
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


## **获取文本框的 Effective 属性**
使用 Aspose.Slides for Node.js via Java，您可以获取文本框的 Effective 属性。为此，Aspose.Slides 中添加了 **TextFrameFormatEffectiveData** 类。它包含文本框的 Effective 格式属性。

此示例代码演示如何获取文本框的 Effective 格式属性：
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


## **获取文本样式的 Effective 属性**
使用 Aspose.Slides for Node.js via Java，您可以获取文本样式的 Effective 属性。为此，Aspose.Slides 中添加了 **TextStyleEffectiveData** 类。它包含 Effective 文本样式属性。

此示例代码演示如何获取文本样式的 Effective 属性：
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


## **获取 Effective 字体高度值**
使用 Aspose.Slides for Node.js via Java，您可以获取字体高度的 Effective 属性。在此我们提供一段代码，展示在演示文稿的不同结构层级上设置本地字体高度后，片段的 Effective 字体高度值如何变化：
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


## **获取表格的 Effective 填充格式**
使用 Aspose.Slides for Node.js via Java，您可以获取不同表格逻辑部分的 Effective 填充格式。为此，Aspose.Slides 中添加了 **CellFormatEffectiveData** 类。它包含 Effective 填充格式属性。请注意：单元格格式始终优先于行格式；行格式优先于列格式；列格式优先于整个表格。
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

**我如何判断得到的是“快照”而不是“实时对象”，以及何时应重新读取 Effective 属性？**  
EffectiveData 对象是调用时计算值的不可变快照。如果您更改形状的本地或继承设置，需要再次检索 EffectiveData 以获取更新后的值。

**更改布局/母版幻灯片会影响已检索的 Effective 属性吗？**  
会，但只有在您再次读取时才会生效。已获取的 EffectiveData 对象不会自行更新——在更改布局或母版后需要再次请求获取。

**我可以通过 EffectiveData 修改值吗？**  
不能。EffectiveData 是只读的。请在本地格式对象（形状/文本/3D 等）中进行更改，然后再次获取 Effective 值。

**如果属性既未在形状层级设置，也未在布局/母版或全局设置中定义，会怎样？**  
Effective 值将由默认机制（PowerPoint/Aspose.Slides 的默认设置）决定。该解析后的值将成为 EffectiveData 快照的一部分。

**从 Effective 字体值，我能判断是哪一级提供了大小或字体吗？**  
不能直接。EffectiveData 只返回最终值。若要找出来源，需要检查片段、段落、文本框的本地值以及布局、母版或演示文稿的文本样式，查看首次出现显式定义的位置。

**为什么 EffectiveData 值有时看起来与本地值相同？**  
因为本地值最终成为了最终值（无需更高层级的继承）。在这种情况下，Effective 值与本地值相同。

**何时应使用 Effective 属性，何时仅使用本地属性？**  
当您需要在所有继承应用后得到“实际渲染”结果时（例如对齐颜色、缩进或大小），应使用 EffectiveData。如果您只需在特定层级修改格式，则更改本地属性，然后在需要时重新读取 EffectiveData 以验证结果。