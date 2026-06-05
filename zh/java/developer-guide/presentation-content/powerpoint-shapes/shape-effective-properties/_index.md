---
title: 在 Java 中从演示文稿获取形状的有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/java/shape-effective-properties/
keywords:
- 形状属性
- 摄像机属性
- 灯光装置
- 斜面形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 如何计算并应用有效的形状属性，以实现精确的 PowerPoint 渲染。"
---
## **概述**

本主题解释 **本地** 与 **有效** 属性之间的区别。本地值是直接在特定格式级别设置的值，例如：

1. 幻灯片上的段落属性。
1. 布局或母版幻灯片上的原型形状文本样式，当该段落的文本框形状具有该样式时。
1. 演示文稿中的全局文本设置。

本地值可以在任何级别定义或省略。当 Aspose.Slides 需要最终的“渲染后”格式时，它会解析继承链并返回 **有效** 值。可以通过在本地格式对象上调用 `getEffective` 方法获取这些值。

以下示例演示如何获取有效值。示例假设第一张幻灯片上的第一个形状是一个带有文本框且至少包含一个段落的 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IAutoShape)。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
有效格式数据表示在应用继承后计算得到的当前格式。在当前实现中，某些有效数据对象（例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPortionFormatEffectiveData)）可能会在内部缓存。更改父级或继承的格式后再次调用 `getEffective` 可以刷新缓存的数据，先前获取的对象可能不再代表之前的状态。如果需要保留有效值以供后续使用，请将所需属性（如字体高度、填充颜色、字体样式或对齐方式）复制到自己的数据对象中。
{{% /alert %}}

## **获取摄像机的有效属性**

Aspose.Slides 允许您获取摄像机的有效属性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ICameraEffectiveData) 接口表示一个不可变对象，其中包含有效的摄像机属性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ICameraEffectiveData) 实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IThreeDFormatEffectiveData) 暴露，后者提供 [IThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IThreeDFormat) 的有效值。

以下代码示例展示如何获取摄像机的有效属性。示例假设第一张幻灯片上的第一个形状具有 3D 格式。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **获取灯光装置的有效属性**

Aspose.Slides 允许您获取灯光装置的有效属性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ILightRigEffectiveData) 接口表示一个不可变对象，其中包含有效的灯光装置属性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ILightRigEffectiveData) 实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IThreeDFormatEffectiveData) 暴露，后者提供 [IThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IThreeDFormat) 的有效值。

以下代码示例展示如何获取灯光装置的有效属性。示例假设第一张幻灯片上的第一个形状具有 3D 格式。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **获取斜面形状的有效属性**

Aspose.Slides 允许您获取形状斜面的有效属性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShapeBevelEffectiveData) 接口表示一个不可变对象，其中包含形状的有效面部凹凸属性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShapeBevelEffectiveData) 实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IThreeDFormatEffectiveData) 暴露，后者提供 [IThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IThreeDFormat) 的有效值。

以下代码示例展示如何获取形状顶部斜面的有效属性。示例假设第一张幻灯片上的第一个形状具有 3D 格式。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **获取文本框的有效属性**

使用 Aspose.Slides，您可以获取文本框的有效属性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ITextFrameFormatEffectiveData) 接口包含有效的文本框格式属性。

以下代码示例展示如何获取文本框的有效格式属性。示例假设第一张幻灯片上的第一个形状是一个带有文本框的 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IAutoShape)。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **获取文本样式的有效属性**

使用 Aspose.Slides，您可以获取文本样式的有效属性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ITextStyleEffectiveData) 接口包含有效的文本样式属性。

以下代码示例展示如何获取文本样式的有效属性。示例假设第一张幻灯片上的第一个形状是一个带有文本框的 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IAutoShape)。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **获取有效字体高度值**

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

使用 Aspose.Slides，您可以获取表格不同部分的有效填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IFillFormatEffectiveData) 接口包含有效的填充格式属性。单元格格式的优先级高于行格式，行格式高于列格式，列格式高于整体表格格式。

因此，绘制表格单元格时使用的是 [ICellFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ICellFormatEffectiveData) 的属性。以下代码示例展示如何获取表格不同部分的有效填充格式。示例假设第一张幻灯片上的第一个形状是一个 [ITable](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ITable)。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **常见问题**

**`getEffective` 是否返回快照？**

并非总是如此。有效数据表示在应用继承后计算得到的格式，但某些有效数据对象可能会在内部被缓存。随后再次调用 `getEffective` 可能会重新计算格式并刷新缓存的数据，因此先前获取的对象不应视为持久的快照。

**我何时应该重新读取有效属性？**

在更改本地格式、父级样式、布局格式、母版格式或演示文稿级默认设置后，请再次调用 `getEffective`。下一次调用会重新评估格式层次结构并返回当前的有效结果。

**更改或删除布局/母版幻灯片会影响已经检索到的有效属性吗？**

会，但更改会在下次 `getEffective` 调用时体现。如果父级格式源被更改或删除，之前获取的有效数据可能已经过时。再次调用 `getEffective` 后，Aspose.Slides 会重新评估格式树，导致字体、颜色、大小或其他值发生变化。

**我可以通过有效数据对象修改值吗？**

不能。有效数据对象只暴露计算后的值。请在本地格式对象中进行修改，然后再次获取有效值。

**如果属性在形状级别、布局/母版以及全局设置中都未设置，会发生什么？**

有效值由默认机制决定，其中包括 PowerPoint 和 Aspose.Slides 的默认值。解析得到的值会成为当前有效数据的一部分。

**从有效的字体值，我能判断出是哪一级提供的大小或字体吗？**

不能直接判断。有效数据只返回最终值。若想找出来源，需要检查段落、文本框、布局、母版以及演示文稿级别的本地值，查看首次出现显式定义的层级。

**为什么有效值有时看起来与本地值相同？**

因为本地值最终成为了最终值（不需要更高级别的继承）。在这种情况下，有效值与本地值相匹配。

**何时应使用有效属性，何时仅使用本地属性？**

当您需要在所有继承应用后得到“渲染后”的结果时（例如对齐颜色、缩进或尺寸），应使用有效数据。如果需要在后续格式更改后仍保留这些值，请将必需的属性复制到自己的对象中。如果需要在特定层级修改格式，请先更改本地属性，然后在需要时再次读取有效数据以验证结果。