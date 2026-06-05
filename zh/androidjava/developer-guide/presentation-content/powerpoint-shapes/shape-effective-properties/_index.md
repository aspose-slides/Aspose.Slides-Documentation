---
title: 在 Android 上从演示文稿获取形状的有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/androidjava/shape-effective-properties/
keywords:
- 形状属性
- 相机属性
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
description: "了解 Aspose.Slides for Android（Java 版）如何计算并应用有效的形状属性，以实现精确的 PowerPoint 渲染。"
---
## **概述**

本主题解释 **本地** 属性与 **有效** 属性之间的区别。本地值是直接在特定格式级别设置的值，例如：

1. 幻灯片上的文本段属性。
1. 布局或母版幻灯片上的原型形状文本样式（当该段的文本框形状拥有此样式时）。
1. 演示文稿中的全局文本设置。

本地值可以在任何级别定义或省略。当 Aspose.Slides 需要最终的“渲染后”格式时，它会解析继承链并返回 **有效** 值。可以通过在本地格式对象上调用 `getEffective()` 方法来获取这些值。

下面的示例演示如何获取有效值。示例假设第一张幻灯片上的第一个形状是一个带有文本框且包含至少一个段的 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。

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
有效格式数据表示在应用继承后计算得到的当前格式。在当前实现中，某些有效数据对象（例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportionformateffectivedata/)）可能会在内部被缓存。更改父级或继承的格式后再次调用 `getEffective()` 可以刷新缓存数据，先前获取的对象可能不再表示之前的状态。如果需要在以后重用有效值，请将所需的属性（如字体高度、填充颜色、字体样式或对齐方式）复制到自己的数据对象中。

{{% /alert %}}

## **获取相机的有效属性**

Aspose.Slides 允许您获取相机的有效属性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icameraeffectivedata/) 接口表示一个不可变对象，包含相机的有效属性。通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformateffectivedata/) 可以访问 [ICameraEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icameraeffectivedata/)，后者为 [IThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/) 提供有效值。

下面的代码示例展示如何获取相机的有效属性。示例假设第一张幻灯片上的第一个形状具有 3D 格式。

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

Aspose.Slides 允许您获取灯光装置的有效属性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilightrigeffectivedata/) 接口表示一个不可变对象，包含灯光装置的有效属性。通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformateffectivedata/) 可以访问 [ILightRigEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilightrigeffectivedata/)，后者为 [IThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/) 提供有效值。

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

## **获取形状斜面（Bevel）的有效属性**

Aspose.Slides 允许您获取形状斜面的有效属性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapebeveleffectivedata/) 接口表示一个不可变对象，包含形状斜面的有效面部属性。通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformateffectivedata/) 可以访问 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapebeveleffectivedata/)，后者为 [IThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/) 提供有效值。

下面的代码示例展示如何获取形状顶部斜面的有效属性。示例假设第一张幻灯片上的第一个形状具有 3D 格式。

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

使用 Aspose.Slides，您可以获取文本框的有效属性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformateffectivedata/) 接口包含有效的文本框格式属性。

下面的代码示例展示如何获取文本框的有效格式属性。示例假设第一张幻灯片上的第一个形状是一个带有文本框的 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。

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

使用 Aspose.Slides，您可以获取文本样式的有效属性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextstyleeffectivedata/) 接口包含有效的文本样式属性。

下面的代码示例展示如何获取文本样式的有效属性。示例假设第一张幻灯片上的第一个形状是一个带有文本框的 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。

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

使用 Aspose.Slides，您可以获取有效的字体高度。下面的代码演示在演示文稿结构的不同级别设置本地字体高度后，段的有效字体高度如何变化。

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

使用 Aspose.Slides，您可以获取不同表格部分的有效填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifillformateffectivedata/) 接口包含有效的填充格式属性。单元格格式的优先级高于行格式，行格式高于列格式，列格式高于整表格式。

因此，绘制表格单元格时会使用 [ICellFormatEffectiveData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icellformateffectivedata/) 的属性。下面的代码示例展示如何获取不同表格部分的有效填充格式。示例假设第一张幻灯片上的第一个形状是一个 [ITable](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itable/)。

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

## **常见问题解答**

**`getEffective()` 会返回快照吗？**

不一定。有效数据表示在应用继承后计算得到的格式，但某些有效数据对象可能在内部被缓存。随后调用 `getEffective()` 可能会重新计算格式并刷新缓存数据，因此之前获取的对象不应被视为持久快照。

**何时需要再次读取有效属性？**

在更改本地格式、父级样式、布局格式、母版格式或演示文稿级默认值后，重新调用 `getEffective()`。下次调用会重新评估格式层次并返回当前的有效结果。

**更改或删除布局/母版幻灯片会影响已经获取的有效属性吗？**

会，但这种变化会在下次 `getEffective()` 调用时体现。如果父级格式来源被更改或删除，之前获取的有效数据可能已过时。再次调用 `getEffective()` 后，Aspose.Slides 会重新评估格式树，字体、颜色、大小等值可能会改变。

**可以通过有效数据对象修改值吗？**

不能。有效数据对象只提供计算后的值。请在本地格式对象上进行修改，然后再次获取有效值。

**如果在形状层、布局/母版层以及全局设置中都未设置某属性，会怎样？**

有效值由默认机制决定，包括 PowerPoint 和 Aspose.Slides 的默认值。解析得到的值会成为当前有效数据的一部分。

**从有效的字体值能否判断是哪个层级提供的大小或字体？**

不能直接判断。有效数据只返回最终值。若要查找来源，需要检查段、段落、文本框以及布局、母版和演示文稿级别的本地值，找出首次出现显式定义的层级。

**为什么有效值有时看起来与本地值相同？**

因为本地值已经是最终值（不需要更高层级的继承）。在这种情况下，有效值与本地值相同。

**何时应该使用有效属性，何时只使用本地属性？**

当需要在所有继承应用后得到“渲染后”的结果时（例如对齐颜色、缩进或尺寸），使用有效数据。如果需要在后续格式更改后仍保留这些值，请将所需属性复制到自己的对象中。如果只需在特定层级修改格式，请更改本地属性，并在需要时再次读取有效数据以验证结果。