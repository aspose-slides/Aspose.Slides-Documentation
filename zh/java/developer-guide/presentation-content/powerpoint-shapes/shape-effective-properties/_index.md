---
title: 在 Java 中从演示文稿获取形状 Effective 属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/java/shape-effective-properties/
keywords:
- 形状属性
- 摄像机属性
- 灯光装置
- 斜角形状
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

本主题解释了 **local** 和 **effective** 属性之间的区别。局部值是直接在特定格式级别设置的值，例如：

1. 幻灯片上的文本段属性。  
1. 布局或母版幻灯片上的原型形状文本样式（当该段的文本框形状具有此样式时）。  
1. 演示文稿中的全局文本设置。

局部值可以在任何级别定义或省略。当 Aspose.Slides 需要最终“呈现后”的格式时，它会解析继承链并返回 **effective** 值。可以通过在局部格式对象上调用 `getEffective` 方法来获取这些值。

下面的示例展示了如何获取 effective 值。示例假设第一张幻灯片上的第一个形状是带有文本框且至少包含一个段的 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IAutoShape)。

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
Effective 格式数据表示在应用继承后当前计算得到的格式。在当前实现中，某些 effective 数据对象，例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPortionFormatEffectiveData)，可能会在内部被缓存。更改父级或继承的格式后再次调用 `getEffective` 可以刷新缓存的数据，先前获取的对象可能不再代表之前的状态。如果需要保留 effective 值以供后续使用，请将所需的属性（例如字体高度、填充颜色、字体样式或对齐方式）复制到您自己的数据对象中。
{{% /alert %}}

## **获取摄像机的 Effective 属性**

Aspose.Slides 允许您获取摄像机的 effective 属性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ICameraEffectiveData) 接口表示一个不可变对象，包含 effective 摄像机属性。通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IThreeDFormatEffectiveData) 可以获取 [ICameraEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ICameraEffectiveData) 实例，该实例为 [IThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IThreeDFormat) 提供 effective 值。

下面的代码示例展示了如何获取摄像机的 effective 属性。示例假设第一张幻灯片上的第一个形状具有 3D 格式。

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

## **获取灯光装置的 Effective 属性**

Aspose.Slides 允许您获取灯光装置的 effective 属性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ILightRigEffectiveData) 接口表示一个不可变对象，包含 effective 灯光装置属性。通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IThreeDFormatEffectiveData) 可以获取 [ILightRigEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ILightRigEffectiveData) 实例，该实例为 [IThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IThreeDFormat) 提供 effective 值。

下面的代码示例展示了如何获取灯光装置的 effective 属性。示例假设第一张幻灯片上的第一个形状具有 3D 格式。

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

## **获取斜角形状的 Effective 属性**

Aspose.Slides 允许您获取形状斜角的 effective 属性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShapeBevelEffectiveData) 接口表示一个不可变对象，包含形状斜角的 effective 面部属性。通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IThreeDFormatEffectiveData) 可以获取 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShapeBevelEffectiveData) 实例，该实例为 [IThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IThreeDFormat) 提供 effective 值。

下面的代码示例展示了如何获取形状顶部斜角的 effective 属性。示例假设第一张幻灯片上的第一个形状具有 3D 格式。

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

## **获取文本框的 Effective 属性**

使用 Aspose.Slides，您可以获取文本框的 effective 属性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ITextFrameFormatEffectiveData) 接口包含 effective 文本框格式属性。

下面的代码示例展示了如何获取 effective 文本框格式属性。示例假设第一张幻灯片上的第一个形状是带有文本框的 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IAutoShape)。

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

## **获取文本样式的 Effective 属性**

使用 Aspose.Slides，您可以获取文本样式的 effective 属性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ITextStyleEffectiveData) 接口包含 effective 文本样式属性。

下面的代码示例展示了如何获取 effective 文本样式属性。示例假设第一张幻灯片上的第一个形状是带有文本框的 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IAutoShape)。

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

## **获取 Effective 字体高度值**

使用 Aspose.Slides，您可以获取 effective 字体高度。下面的代码演示了在演示文稿结构的不同层级设置局部字体高度后，段的 effective 字体高度如何变化。

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

## **获取表格的 Effective 填充格式**

使用 Aspose.Slides，您可以获取不同表格部分的 effective 填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IFillFormatEffectiveData) 接口包含 effective 填充格式属性。单元格格式的优先级高于行格式，行格式高于列格式，列格式高于整表格式。

因此，绘制表格单元格时使用 [ICellFormatEffectiveData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ICellFormatEffectiveData) 的属性。下面的代码示例展示了如何获取不同表格部分的 effective 填充格式。示例假设第一张幻灯片上的第一个形状是一个 [ITable](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ITable)。

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

**`getEffective` 会返回快照吗？**

并非总是如此。Effective 数据表示在应用继承后计算得到的格式，但某些 effective 数据对象可能在内部被缓存。后续调用 `getEffective` 可能会重新计算格式并刷新缓存的数据，因此先前获取的对象不应被视为持久的快照。

**何时应再次读取 effective 属性？**

在更改局部格式、父级样式、布局格式、母版格式或演示文稿级别的默认设置后，请再次调用 `getEffective`。下一次调用会重新评估格式层次结构并返回当前的 effective 结果。

**更改或删除布局/母版幻灯片会影响已检索到的 effective 属性吗？**

会，但更改会在下次调用 `getEffective` 时体现。如果父级格式源被更改或移除，先前获取的 effective 数据可能已过期。再次调用 `getEffective` 后，Aspose.Slides 会重新评估格式树， resulting 的字体、颜色、大小或其他值可能会改变。

**我可以通过 effective 数据对象修改值吗？**

不能。Effective 数据对象只暴露计算后的值。请在局部格式对象中进行修改，然后再次获取 effective 值。

**如果属性既未在形状级别设置，也未在布局/母版或全局设置中设置，会怎样？**

effective 值由默认机制决定，包括 PowerPoint 和 Aspose.Slides 的默认值。该解析后的值会成为当前 effective 数据的一部分。

**从 effective 字体值能判断是哪个级别提供的大小或字体吗？**

不能直接判断。Effective 数据只返回最终值。若要查找来源，需要检查段、段落、文本框以及布局、母版和演示文稿级别的文本样式中的局部值，找出首次出现显式定义的层级。

**为什么 effective 值有时与局部值相同？**

因为局部值本身已经是最终值（无需更高级别的继承）。在这种情况下，effective 值与局部值相同。

**何时应使用 effective 属性，何时仅使用局部属性？**

在需要获取所有继承应用后的“呈现后”结果时（例如对齐颜色、缩进或尺寸），使用 effective 数据。如果需要在后续格式更改后仍保留这些值，请将所需属性复制到自己的对象中。如果要在特定层级修改格式，请修改局部属性，然后在需要时再次读取 effective 数据以验证结果。