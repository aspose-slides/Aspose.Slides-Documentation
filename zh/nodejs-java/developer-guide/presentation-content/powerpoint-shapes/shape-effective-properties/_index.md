---
title: 在 JavaScript 中从演示文稿获取形状的有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/nodejs-java/shape-effective-properties/
keywords:
- 形状属性
- 相机属性
- 灯光设备
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
description: "了解 Aspose.Slides for Node.js（通过 Java）如何计算并应用有效的形状属性，以实现精准的 PowerPoint 渲染。"
---
## **概述**

本主题解释 **本地** 与 **有效** 属性之间的区别。本地值是直接在特定格式层级设置的值，例如：

1. 幻灯片上的段落属性。
1. 布局或母版幻灯片上的原型形状文本样式（当段落的文本框形状具有该样式时）。
1. 演示文稿中的全局文本设置。

本地值可以在任何层级定义或省略。当 Aspose.Slides 需要最终的“渲染后”格式时，它会解析继承链并返回 **有效** 值。可以通过在本地格式对象上调用 `getEffective` 方法来获取这些值。

以下示例演示如何获取有效值。假设第一张幻灯片上的第一个形状是一个带有文本框且至少包含一个段落的 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
有效格式数据表示在应用继承后当前计算得到的格式。在当前实现中，某些有效数据对象可能会在内部被缓存。更改父级或继承的格式后再次调用 `getEffective` 可以刷新缓存数据，之前获得的对象可能不再代表之前的状态。如果需要保留有效值以供后续使用，请将所需的属性（例如字体高度、填充颜色、字体样式或对齐方式）复制到您自己的数据对象中。
{{% /alert %}}

## **获取相机的有效属性**

Aspose.Slides 允许您获取相机的有效属性。有效相机数据对象包含不可变的相机属性，并通过对 [ThreeDFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/) 返回的有效值公开。

以下代码示例展示如何获取相机的有效属性。假设第一张幻灯片上的第一个形状具有 3D 格式。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **获取灯光设备的有效属性**

Aspose.Slides 允许您获取灯光设备的有效属性。有效灯光设备数据对象包含不可变的灯光设备属性，并通过对 [ThreeDFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/) 返回的有效值公开。

以下代码示例展示如何获取灯光设备的有效属性。假设第一张幻灯片上的第一个形状具有 3D 格式。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **获取斜角形状的有效属性**

Aspose.Slides 允许您获取形状斜角的有效属性。有效形状斜角数据对象包含形状的不可变面部浮雕属性，并通过对 [ThreeDFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/) 返回的有效值公开。

以下代码示例展示如何获取形状顶部斜角的有效属性。假设第一张幻灯片上的第一个形状具有 3D 格式。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **获取文本框的有效属性**

使用 Aspose.Slides，您可以获取文本框的有效属性。返回的有效数据对象包含文本框的格式属性。

以下代码示例展示如何获取文本框的有效格式属性。假设第一张幻灯片上的第一个形状是一个带有文本框的 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **获取文本样式的有效属性**

使用 Aspose.Slides，您可以获取文本样式的有效属性。返回的有效数据对象包含文本样式的属性。

以下代码示例展示如何获取文本样式的有效属性。假设第一张幻灯片上的第一个形状是一个带有文本框的 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **获取有效字体高度值**

使用 Aspose.Slides，您可以获取有效字体高度。以下代码演示在演示文稿结构的不同层级设置本地字体高度后，段落的有效字体高度如何变化。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **获取表格的有效填充格式**

使用 Aspose.Slides，您可以获取不同表格部件的有效填充格式。返回的有效数据对象包含填充格式属性。单元格格式的优先级高于行格式，行格式高于列格式，列格式高于整个表格的格式。

因此，使用有效的单元格格式属性来绘制表格单元格。以下代码示例展示如何获取不同表格部件的有效填充格式。假设第一张幻灯片上的第一个形状是一个 [Table](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/table/)。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **常见问题**

**`getEffective` 是否返回快照？**

并非总是如此。有效数据表示在应用继承后计算得到的格式，但某些有效数据对象可能会在内部被缓存。随后调用 `getEffective` 可能会重新计算格式并刷新缓存数据，因此先前获得的对象不应视为持久快照。

**何时应再次读取有效属性？**

在更改本地格式、父样式、布局格式、母版格式或演示文稿级默认值后再次调用 `getEffective`。下一次调用会重新评估格式层级并返回当前的有效结果。

**更改或删除布局/母版幻灯片会影响已经检索到的有效属性吗？**

会，但更改会在下次 `getEffective` 调用时体现。如果父级格式源被更改或删除，先前获取的有效数据可能已过时。再次调用 `getEffective` 后，Aspose.Slides 会重新评估格式树，结果的字体、颜色、大小等值可能会改变。

**我可以通过有效数据对象修改值吗？**

不能。有效数据对象仅暴露计算后的值。请在本地格式对象中进行修改，然后再次获取有效值。

**如果属性在形状级别、布局/母版或全局设置中均未设置，会怎样？**

有效值由默认机制决定，包括 PowerPoint 和 Aspose.Slides 的默认设置。解析后的值成为当前有效数据的一部分。

**从有效字体值能判断是哪个层级提供的大小或字形吗？**

不能直接判断。有效数据返回最终值。若要查找来源，需要检查段落、段落、文本框以及布局、母版和演示文稿层级的本地值，以确定首次出现显式定义的层级。

**为什么有效值有时看起来与本地值相同？**

因为本地值已经是最终值（无需更高级别的继承）。在这种情况下，有效值与本地值相同。

**何时应使用有效属性，何时只使用本地属性？**

当需要在所有继承应用后的“渲染后”结果时使用有效数据，例如对齐颜色、缩进或尺寸。如果需要在后续格式更改后仍保留这些值，请将所需属性复制到自己的对象中。如果需要在特定层级修改格式，请修改本地属性，然后（如有需要）再次读取有效数据以验证结果。