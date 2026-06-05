---
title: 在 Android 上从演示文稿获取形状有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/androidjava/shape-effective-properties/
keywords:
- 形状属性
- 摄像机属性
- 灯光装置
- 倒角形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Android via Java 如何计算并应用形状的有效属性，以实现精确的 PowerPoint 渲染。"
---
## **概述**

本主题解释 **本地** 属性和 **有效** 属性之间的区别。本地值是直接在特定格式层级上设置的值，例如：

1. 幻灯片上的段落属性。
1. 当段落的文本框形状有文本样式时，布局或母版幻灯片上的原型形状文本样式。
1. 演示文稿中的全局文本设置。

本地值可以在任何层级上定义或省略。当 Aspose.Slides 需要最终的“渲染后”格式时，它会解析继承链并返回 **有效** 值。可以通过在本地格式对象上调用 `getEffective()` 方法获取它们。

下面的示例演示如何获取有效值。示例假设第一张幻灯片上的第一个形状是一个带有文本框且至少包含一个段落的[IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

有效格式数据表示在应用继承后计算得到的当前格式。在当前实现中，某些有效数据对象（例如[IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportionformateffectivedata/)）可能会在内部缓存。更改父级或继承的格式后再次调用 `getEffective()` 可以刷新缓存数据，先前获得的对象可能不再代表之前的状态。如果需要保留有效值以供后续使用，请将所需属性（如字体高度、填充颜色、字体样式或对齐方式）复制到自己的数据对象中。

{{% /alert %}}

## **获取摄像机的有效属性**

Aspose.Slides 允许获取摄像机的有效属性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icameraeffectivedata/) 接口表示一个不可变对象，包含摄像机的有效属性。通过[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformateffectivedata/) 可以获取[ICameraEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icameraeffectivedata/) 实例，从而为[IThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/) 提供有效值。

下面的代码示例展示如何获取摄像机的有效属性。示例假设第一张幻灯片上的第一个形状具有 3D 格式。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **获取灯光装置的有效属性**

Aspose.Slides 允许获取灯光装置的有效属性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilightrigeffectivedata/) 接口表示一个不可变对象，包含灯光装置的有效属性。通过[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformateffectivedata/) 可以获取[ILightRigEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilightrigeffectivedata/) 实例，为[IThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/) 提供有效值。

下面的代码示例展示如何获取灯光装置的有效属性。示例假设第一张幻灯片上的第一个形状具有 3D 格式。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **获取形状倒角的有效属性**

Aspose.Slides 允许获取形状倒角的有效属性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapebeveleffectivedata/) 接口表示一个不可变对象，包含形状倒角的有效面部特性。通过[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformateffectivedata/) 可以获取[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapebeveleffectivedata/) 实例，为[IThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/) 提供有效值。

下面的代码示例展示如何获取形状顶部倒角的有效属性。示例假设第一张幻灯片上的第一个形状具有 3D 格式。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **获取文本框的有效属性**

使用 Aspose.Slides，您可以获取文本框的有效属性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformateffectivedata/) 接口包含文本框的有效格式属性。

下面的代码示例展示如何获取文本框的有效格式属性。示例假设第一张幻灯片上的第一个形状是一个带有文本框的[IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **获取文本样式的有效属性**

使用 Aspose.Slides，您可以获取文本样式的有效属性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextstyleeffectivedata/) 接口包含文本样式的有效属性。

下面的代码示例展示如何获取文本样式的有效属性。示例假设第一张幻灯片上的第一个形状是一个带有文本框的[IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **获取有效的字体高度值**

使用 Aspose.Slides，您可以获取有效的字体高度。以下代码演示在演示文稿结构的不同层级设置本地字体高度后，段落的有效字体高度如何变化。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **获取表格的有效填充格式**

使用 Aspose.Slides，您可以获取表格不同部位的有效填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifillformateffectivedata/) 接口包含有效的填充格式属性。单元格格式的优先级高于行格式，行格式高于列格式，列格式高于整体表格格式。

因此，使用[ICellFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icellformateffectivedata/) 的属性来绘制表格单元格。下面的代码示例展示如何获取表格不同部位的有效填充格式。示例假设第一张幻灯片上的第一个形状是一个[ITable](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itable/)。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **常见问题**

**`getEffective()` 会返回快照吗？**

不一定。有效数据表示在应用继承后计算得到的格式，但某些有效数据对象可能在内部被缓存。后续调用 `getEffective()` 可能会重新计算格式并刷新缓存数据，因此先前获得的对象不应被视为持久快照。

**何时需要再次读取有效属性？**

在更改本地格式、父级样式、布局格式、母版格式或演示文稿级默认值后，重新调用 `getEffective()`。下一次调用会重新评估格式层级并返回当前的有效结果。

**更改或移除布局/母版幻灯片会影响已经获取的有效属性吗？**

会，但更改会在下一次 `getEffective()` 调用时体现。如果父级格式源被更改或删除，先前获取的有效数据可能已过时。再次调用 `getEffective()` 后，Aspose.Slides 会重新评估格式树，字体、颜色、大小等值可能会改变。

**可以通过有效数据对象修改值吗？**

不能。有效数据对象只暴露计算后的值。应在本地格式对象中进行修改，然后再次获取有效值。

**如果在形状层级、布局/母版层级以及全局设置中都未设置某个属性，会怎样？**

该属性的有效值由默认机制决定，默认机制包括 PowerPoint 和 Aspose.Slides 的默认值。解析得到的值会成为当前有效数据的一部分。

**从有效的字体值能判断出是哪个层级提供的大小或字体吗？**

不能直接判断。有效数据只返回最终值。若需追溯来源，需要检查段落、文本框、布局、母版和演示文稿层级的本地值，查看首次出现显式定义的位置。

**为何有效值有时看起来与本地值相同？**

因为本地值已经是最终值（无需更高层级的继承）。在这种情况下，有效值与本地值相同。

**何时使用有效属性，何时仅使用本地属性？**

在需要获取所有继承后“渲染结果”时使用有效数据，例如对齐颜色、缩进或尺寸。如果希望在后续格式更改时保持这些值，请将所需属性复制到自己的对象中。若要在特定层级修改格式，先修改本地属性，然后在需要时再次读取有效数据以验证结果。