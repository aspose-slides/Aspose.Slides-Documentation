---
title: 在 Java 中從簡報取得形狀的有效屬性
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/java/shape-effective-properties/
keywords:
- 形狀屬性
- 相機屬性
- 光源組
- 斜角形狀
- 文字框
- 文字樣式
- 字型高度
- 填充格式
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 如何計算並套用有效的形狀屬性，以實現精確的 PowerPoint 呈現。"
---
## **概述**

本主題說明 **local** 與 **effective** 屬性之間的差異。Local 值是直接在特定格式層級設定的值，例如：

1. 投影片上的文字段屬性。
1. 佈局或母片投影片中原型圖形的文字樣式（當文字段的文字框圖形具有此樣式時）。
1. 簡報中的全域文字設定。

Local 值可以在任何層級定義或省略。當 Aspose.Slides 需要最終的「as rendered」格式時，它會解析繼承鏈並返回 **effective** 值。您可以透過在本地格式物件上呼叫 `getEffective` 方法來取得它們。

以下範例示範如何取得 effective 值。假設第一張投影片上的第一個圖形是具有文字框且至少包含一個文字段的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)。

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
Effective 格式資料表示在套用繼承後目前計算出的格式。在目前的實作中，某些 effective 資料物件（例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPortionFormatEffectiveData)）可能會在內部快取。於變更父層或繼承的格式後再次呼叫 `getEffective` 可以重新整理快取的資料，先前取得的物件可能不再代表先前的狀態。如果需要保留 effective 值以供稍後重複使用，請將所需的屬性（例如字型高度、填色、字型樣式或對齊方式）複製到您自己的資料物件中。
{{% /alert %}}

## **取得相機的有效屬性**

Aspose.Slides 允許您取得相機的 effective 屬性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICameraEffectiveData) 介面代表一個不可變物件，包含 effective 的相機屬性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICameraEffectiveData) 實例透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IThreeDFormatEffectiveData) 取得，後者提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IThreeDFormat) 的 effective 值。

以下程式碼範例示範如何取得相機的 effective 屬性。假設第一張投影片上的第一個圖形具有 3D 格式設定。

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

## **取得光源組的有效屬性**

Aspose.Slides 允許您取得光源組的 effective 屬性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ILightRigEffectiveData) 介面代表一個不可變物件，包含 effective 的光源組屬性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ILightRigEffectiveData) 實例透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IThreeDFormatEffectiveData) 取得，後者提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IThreeDFormat) 的 effective 值。

以下程式碼範例示範如何取得光源組的 effective 屬性。假設第一張投影片上的第一個圖形具有 3D 格式設定。

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

## **取得形狀斜角的有效屬性**

Aspose.Slides 允許您取得形狀斜角的 effective 屬性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeBevelEffectiveData) 介面代表一個不可變物件，包含形狀斜角的 effective 面部凹凸屬性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeBevelEffectiveData) 實例透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IThreeDFormatEffectiveData) 取得，後者提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IThreeDFormat) 的 effective 值。

以下程式碼範例示範如何取得形狀上方斜角的 effective 屬性。假設第一張投影片上的第一個圖形具有 3D 格式設定。

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

## **取得文字框的有效屬性**

使用 Aspose.Slides，您可以取得文字框的 effective 屬性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrameFormatEffectiveData) 介面包含文字框的 effective 格式屬性。

以下程式碼範例示範如何取得文字框的 effective 格式屬性。假設第一張投影片上的第一個圖形是具有文字框的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)。

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

## **取得文字樣式的有效屬性**

使用 Aspose.Slides，您可以取得文字樣式的 effective 屬性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextStyleEffectiveData) 介面包含文字樣式的 effective 屬性。

以下程式碼範例示範如何取得文字樣式的 effective 屬性。假設第一張投影片上的第一個圖形是具有文字框的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)。

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

## **取得 Effective 字型高度值**

使用 Aspose.Slides，您可以取得 effective 的字型高度。以下程式碼示範在簡報不同層級設定本地字型高度後，文字段的 effective 字型高度如何變化。

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

## **取得表格的 Effective 填充格式**

使用 Aspose.Slides，您可以取得不同表格部分的 effective 填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IFillFormatEffectiveData) 介面包含 effective 填充格式屬性。儲存格格式的優先權高於列格式，列格式高於欄格式，欄格式高於整表格式。

因此，會使用 [ICellFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICellFormatEffectiveData) 的屬性來繪製表格儲存格。以下程式碼範例示範如何取得不同表格部分的 effective 填充格式。假設第一張投影片上的第一個圖形是 [ITable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITable)。

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

## **FAQ**

**`getEffective` 會回傳快照嗎？**

不一定。Effective 資料代表套用繼承後計算出的格式，但某些 effective 資料物件可能會在內部被快取。隨後的 `getEffective` 呼叫可能會重新計算格式並刷新快取的資料，因此先前取得的物件不應視為持久的快照。

**什麼時候需要再次讀取 effective 屬性？**

在變更本地格式、父層樣式、佈局格式、母片格式或簡報層級的預設值之後，再次呼叫 `getEffective`。下一次呼叫會重新評估格式階層，並返回目前的 effective 結果。

**變更或移除佈局/母片投影片會影響已取得的 effective 屬性嗎？**

會，但變更會在下次 `getEffective` 呼叫時才顯現。若父層格式來源被變更或移除，先前取得的 effective 資料可能已過時。再次呼叫 `getEffective` 後，Aspose.Slides 會重新評估格式樹，字型、顏色、大小或其他值可能會改變。

**我能透過 effective 資料物件修改值嗎？**

不能。Effective 資料物件僅提供計算出的值。請在本地格式物件上進行變更，然後再次取得 effective 值。

**如果屬性在形狀層級、佈局/母片或全域設定都未設定，會發生什麼？**

effective 值由預設機制決定，該機制包含 PowerPoint 與 Aspose.Slides 的預設值。解析出的值會成為目前的 effective 資料的一部份。

**從 effective 字型值，我能判斷是哪個層級提供的大小或字型嗎？**

不能直接判斷。Effective 資料只返回最終值。若要找出來源，需檢查文字段、段落、文字框以及佈局、母片與簡報層級的文字樣式的本地值，找出第一個明確定義的層級。

**為什麼 effective 值有時看起來和本地值相同？**

因為本地值最終即為最終值（未需更高層級的繼承）。在此情況下，effective 值與本地值相同。

**什麼時候使用 effective 屬性，什麼時候只使用本地屬性？**

當您需要在所有繼承套用後的「實際呈現」結果時，使用 effective 資料，例如對齊顏色、縮排或大小。如果需要在後續格式變更後仍保留這些值，請將所需屬性複製到自己的物件中。若您只想在特定層級修改格式，請變更本地屬性，必要時再讀取 effective 資料以驗證結果。