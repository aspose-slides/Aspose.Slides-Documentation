---
title: 形状有效属性
type: docs
weight: 50
url: /zh/androidjava/shape-effective-properties/
---

在本主题中，我们将讨论**有效**和**本地**属性。当我们在这些级别直接设置值时

1. 在部分属性于部分的幻灯片上;
1. 在布局或母版幻灯片上的原型形状文本样式（如果部分的文本框形状有一个）;
1. 在演示文稿全局文本设置中;

这些值被称为**本地**值。在任何级别上，**本地**值可以被定义或省略。但是当应用程序需要知道部分应该是什么样子时，它使用**有效**值。您可以通过使用本地格式中的**getEffective()**方法来获取有效值。

此示例代码向您展示如何获取有效值：

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

## **获取相机的有效属性**
Aspose.Slides for Android via Java 允许开发人员获取相机的有效属性。为此，添加了 [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) 接口到 Aspose.Slides。 [ICameraEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) 接口表示一个不可变对象，包含有效的相机属性。 [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) 接口的实例作为 [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData) 接口的一部分使用，该接口是 [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) 类的 [有效值](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) 对。

此示例代码展示了如何获取相机的有效属性：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= 有效相机属性 =");
    System.out.println("类型: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("视场: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("缩放: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **获取光源的有效属性**
Aspose.Slides for Android via Java 允许开发人员获取光源的有效属性。为此，添加了 [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) 接口到 Aspose.Slides。 [ILightRigEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) 接口表示一个不可变对象，包含有效的光源属性。 [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) 接口的实例作为 [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData) 接口的一部分使用，该接口是 [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) 类的 [有效值](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) 对。

此示例代码展示了如何获取光源的有效属性：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= 有效光源属性 =");
    System.out.println("类型: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("方向: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```

## **获取斜角形状的有效属性**
Aspose.Slides for Android via Java 允许开发人员获取斜角形状的有效属性。为此，添加了 [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) 接口到 Aspose.Slides。 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) 接口表示一个不可变对象，包含有效形状的面部浮雕属性。 [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) 接口的实例作为 [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData)) 接口的一部分使用，该接口是 [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) 类的 [有效值](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) 对。

此示例代码展示了如何获取斜角形状的有效属性：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= 有效形状的顶部面浮雕属性 =");
    System.out.println("类型: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("宽度: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("高度: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```

## **获取文本框的有效属性**
使用 Aspose.Slides for Android via Java，您可以获取文本框的有效属性。为此，添加了 [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormatEffectiveData) 接口到 Aspose.Slides。它包含有效的文本框格式属性。

此示例代码展示了如何获取有效的文本框格式属性：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("锚定类型: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("自适应类型: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("文本垂直类型: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("边距");
    System.out.println("   左: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   上: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   右: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   下: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **获取文本样式的有效属性**
使用 Aspose.Slides for Android via Java，您可以获取文本样式的有效属性。为此，添加了 [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextStyleEffectiveData) 接口到 Aspose.Slides。它包含有效的文本样式属性。

此示例代码展示了如何获取有效的文本样式属性：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= 风格级别 #" + i + " 的有效段落格式 =");

        System.out.println("深度: " + effectiveStyleLevel.getDepth());
        System.out.println("缩进: " + effectiveStyleLevel.getIndent());
        System.out.println("对齐: " + effectiveStyleLevel.getAlignment());
        System.out.println("字体对齐: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **获取有效字体高度值**
使用 Aspose.Slides for Android via Java，您可以获取字体高度的有效属性。这里，我们提供了一段代码，展示在不同演示文稿结构级别上设置本地字体高度值后，部分的有效字体高度值如何变化：

```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("第一部分的样本文本");
    IPortion portion1 = new Portion(" 和第二部分。");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("新建后有效字体高度:");
    System.out.println("部分 #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("部分 #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("设置整个演示文稿默认字体高度后有效字体高度:");
    System.out.println("部分 #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("部分 #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("设置段落默认字体高度后有效字体高度:");
    System.out.println("部分 #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("部分 #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("设置部分 #0 字体高度后有效字体高度:");
    System.out.println("部分 #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("部分 #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("设置部分 #1 字体高度后有效字体高度:");
    System.out.println("部分 #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("部分 #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **获取表格的有效填充格式**
使用 Aspose.Slides for Android via Java，您可以获取不同表格逻辑部分的有效填充格式。为此，Aspose.Slides 中添加了 [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICellFormatEffectiveData) 接口。它包含有效的填充格式属性。请注意这一点：单元格格式始终优先于行格式；行优先于列；列优先于整个表格。

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