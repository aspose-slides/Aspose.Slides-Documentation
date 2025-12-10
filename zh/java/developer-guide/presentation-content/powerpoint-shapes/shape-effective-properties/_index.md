---
title: 在 Java 中获取演示文稿中的形状有效属性
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
description: "了解 Aspose.Slides for Java 如何计算并应用形状的有效属性，以实现精确的 PowerPoint 渲染。"
---

在本主题中，我们将讨论 **effective**（有效）和 **local**（本地）属性。当我们在这些层级上直接设置值时

1. 在该段落所在幻灯片的段落属性中；
1. 在布局或母版幻灯片上的原型形状文本样式中（如果该段落的文本框形状具有此样式）；
1. 在演示文稿的全局文本设置中；

这些值称为 **local**（本地）值。在任何层级，都可以定义或省略 **local** 值。但当应用程序需要了解段落的实际外观时，它会使用 **effective**（有效）值。您可以通过本地格式的 **getEffective()** 方法获取有效值。

以下示例代码演示了如何获取有效值：
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IPortionFormat localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) pres.dispose();
}
```


## **获取摄像机的有效属性**
Aspose.Slides for Java 允许开发者获取摄像机的有效属性。为此，向 Aspose.Slides 添加了 [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) 接口。该 [ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) 接口表示一个不可变对象，包含有效的摄像机属性。[**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) 接口的实例作为 [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) 接口的一部分使用，该接口是针对 [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) 类的 [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) 对。

以下示例代码演示了如何获取摄像机的有效属性：
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```


## **获取光源装置的有效属性**
Aspose.Slides for Java 允许开发者获取光源装置的有效属性。为此，向 Aspose.Slides 添加了 [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) 接口。该 [ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) 接口表示一个不可变对象，包含有效的光源装置属性。[**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) 接口的实例作为 [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) 接口的一部分使用，该接口是针对 [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) 类的 [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) 对。

以下示例代码演示了如何获取光源装置的有效属性：
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```


## **获取斜面形状的有效属性**
Aspose.Slides for Java 允许开发者获取斜面形状的有效属性。为此，向 Aspose.Slides 添加了 [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) 接口。该 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) 接口表示一个不可变对象，包含有效的形状面部浮雕属性。[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) 接口的实例作为 [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData)) 接口的一部分使用，该接口是针对 [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) 类的 [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) 对。

以下示例代码演示了如何获取斜面形状的有效属性：
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```


## **获取文本框的有效属性**
使用 Aspose.Slides for Java，您可以获取文本框的有效属性。为此，向 Aspose.Slides 添加了 [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) 接口。它包含有效的文本框格式化属性。

以下示例代码演示了如何获取文本框的有效格式化属性：
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
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
    if (pres != null) pres.dispose();
}
```


## **获取文本样式的有效属性**
使用 Aspose.Slides for Java，您可以获取文本样式的有效属性。为此，向 Aspose.Slides 添加了 [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) 接口。它包含有效的文本样式属性。

以下示例代码演示了如何获取文本样式的有效属性：
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= Effective paragraph formatting for style level #" + i + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **获取有效的字体高度值**
使用 Aspose.Slides for Java，您可以获取字体高度的有效属性。在此，我们提供一段代码，展示在不同演示文稿结构层级上设置本地字体高度值后，段落的有效字体高度值会发生变化：
```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("Effective font height just after creation:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Effective font height after setting entire presentation default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Effective font height after setting paragraph default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("Effective font height after setting portion #0 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("Effective font height after setting portion #1 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **获取表格的有效填充格式**
使用 Aspose.Slides for Java，您可以获取表格各逻辑部分的有效填充格式。为此，向 Aspose.Slides 添加了 [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) 接口。它包含有效的填充格式属性。请注意：单元格格式始终优先于行格式；行格式优先于列格式；列格式优先于整个表格。
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    ITable tbl = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITableFormatEffectiveData tableFormatEffective = tbl.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**如何判断我得到的是“快照”而不是“实时对象”，以及何时应重新读取有效属性？**  
EffectiveData 对象是调用时计算值的不可变快照。如果您更改了形状的本地或继承设置，需要再次检索有效数据以获取更新后的值。

**更改布局/母版幻灯片会影响已经获取的有效属性吗？**  
会的，但只有在您重新读取后才会生效。已经获取的 EffectiveData 对象不会自行更新——在更改布局或母版后需再次请求获取。

**我可以通过 EffectiveData 修改值吗？**  
不能。EffectiveData 为只读。请在本地格式对象（形状/文本/3D 等）中进行修改，然后再次获取有效值。

**如果属性在形状层级、布局/母版以及全局设置中都未设置，会发生什么？**  
有效值将由默认机制（PowerPoint/Aspose.Slides 默认值）决定。该解析后的值会成为 EffectiveData 快照的一部分。

**从有效的字体值，我能判断是哪个层级提供的大小或字体吗？**  
不能直接。EffectiveData 只返回最终值。若要查找来源，需要检查段落/段/文本框的本地值以及布局/母版/演示文稿的文本样式，找出首次出现显式定义的层级。

**为什么 EffectiveData 的值有时与本地值相同？**  
因为本地值已经是最终值（不需要更高层级的继承）。在这种情况下，有效值与本地值相同。

**何时应使用有效属性，何时只使用本地属性？**  
在需要在所有继承应用后得到“实际渲染”结果时使用 EffectiveData（例如，对齐颜色、缩进或尺寸）。如果需在特定层级修改格式，请修改本地属性，并在需要时重新读取 EffectiveData 以验证结果。