---
title: 在 Android 上從簡報取得形狀有效屬性
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/androidjava/shape-effective-properties/
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
- Android
- Java
- Aspose.Slides
description: 探索 Aspose.Slides for Android（透過 Java）如何計算並套用形狀的有效屬性，以實現精確的 PowerPoint 呈現。
---
## **概述**

此主題說明 **本地** 與 **有效** 屬性的差異。本地值是直接在特定格式層級設定的值，例如：

1. 投影片上的文字片段屬性。
1. 版面或母片投影片上的原型形狀文字樣式，當文字片段的文字框形狀具有此樣式時。
1. 投影片中全域文字設定。

本地值可以在任何層級定義或省略。當 Aspose.Slides 需要最終「呈現」的格式時，它會解析繼承鏈並返回 **有效** 值。您可以透過在本地格式物件上呼叫 `getEffective()` 方法來取得它們。

以下範例說明如何取得有效值。假設第一張投影片上的第一個形狀是帶有文字框且至少有一個文字片段的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。

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
有效的格式資料代表套用繼承後目前計算出的格式。在目前的實作中，某些有效資料物件，例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportionformateffectivedata/)，可能會在內部快取。於變更父層或繼承的格式後再次呼叫 `getEffective()` 可以重新整理快取的資料，先前取得的物件可能不再代表之前的狀態。若需要保留有效值以便之後重複使用，請將需要的屬性（如字型高度、填色、字型樣式或對齊方式）複製到您自己的資料物件中。
{{% /alert %}}

## **取得相機的有效屬性**

Aspose.Slides 允許您取得相機的有效屬性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icameraeffectivedata/) 介面代表一個不可變的物件，內含相機的有效屬性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icameraeffectivedata/) 實例透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformateffectivedata/) 取得，該介面提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/) 的有效值。

以下程式碼範例示範如何取得相機的有效屬性。假設第一張投影片上的第一個形狀具備 3D 格式設定。

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

## **取得光源組的有效屬性**

Aspose.Slides 允許您取得光源組的有效屬性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilightrigeffectivedata/) 介面代表一個不可變的物件，內含光源組的有效屬性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilightrigeffectivedata/) 實例透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformateffectivedata/) 取得，該介面提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/) 的有效值。

以下程式碼範例示範如何取得光源組的有效屬性。假設第一張投影片上的第一個形狀具備 3D 格式設定。

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

## **取得形狀斜角的有效屬性**

Aspose.Slides 允許您取得形狀斜角的有效屬性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapebeveleffectivedata/) 介面代表一個不可變的物件，內含形狀的面部浮雕屬性。 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapebeveleffectivedata/) 實例透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformateffectivedata/) 取得，該介面提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/) 的有效值。

以下程式碼範例示範如何取得形狀上斜角的有效屬性。假設第一張投影片上的第一個形狀具備 3D 格式設定。

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

## **取得文字框的有效屬性**

使用 Aspose.Slides，您可以取得文字框的有效屬性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformateffectivedata/) 介面包含文字框的有效格式屬性。

以下程式碼範例示範如何取得文字框的有效格式屬性。假設第一張投影片上的第一個形狀是帶有文字框的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。

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

## **取得文字樣式的有效屬性**

使用 Aspose.Slides，您可以取得文字樣式的有效屬性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextstyleeffectivedata/) 介面包含文字樣式的有效屬性。

以下程式碼範例示範如何取得文字樣式的有效屬性。假設第一張投影片上的第一個形狀是帶有文字框的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。

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

## **取得有效字型高度值**

使用 Aspose.Slides，您可以取得有效的字型高度。以下程式碼示範在投影片結構的不同層級設定本地字型高度後，文字片段的有效字型高度如何變化。

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

## **取得表格的有效填充格式**

使用 Aspose.Slides，您可以取得表格各部分的有效填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifillformateffectivedata/) 介面包含有效的填充格式屬性。儲存格格式的優先權高於列格式，列格式高於欄格式，欄格式高於整表格式。

因此，會使用 [ICellFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icellformateffectivedata/) 的屬性來繪製表格儲存格。以下程式碼範例示範如何取得表格各部分的有效填充格式。假設第一張投影片上的第一個形狀是 [ITable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itable/)。

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

## **常見問題**

**`getEffective()` 會回傳快照嗎？**

不一定。有效資料代表套用繼承後計算出的格式，但某些有效資料物件可能在內部被快取。之後再次呼叫 `getEffective()` 可能會重新計算格式並刷新快取的資料，因此先前取得的物件不應被視為永久的快照。

**何時需要再次讀取有效屬性？**

在變更本地格式、父樣式、版面格式、母片格式或投影片層級的預設值後，再次呼叫 `getEffective()`。下一次呼叫會重新評估格式階層並回傳目前的有效結果。

**變更或移除版面/母片投影片會影響已取得的有效屬性嗎？**

會，但變更會在下一次呼叫 `getEffective()` 時顯示。若父層格式來源被變更或移除，先前取得的有效資料可能已過時。再次呼叫 `getEffective()` 後，Aspose.Slides 會重新評估格式樹，導致字型、顏色、大小或其他值發生變化。

**我可以透過有效資料物件修改值嗎？**

不能。有效資料物件僅提供計算出的值。請在本地格式物件中進行變更，然後再次取得有效值。

**如果屬性在形狀層級、版面/母片或全域設定皆未設定，會發生什麼？**

有效值會由預設機制決定，包含 PowerPoint 與 Aspose.Slides 的預設值。解析後的值會成為目前有效資料的一部份。

**從有效的字型值，我能判斷是哪個層級提供的尺寸或字型嗎？**

無法直接判斷。有效資料僅回傳最終值。若要找出來源，請檢查文字片段、段落、文字框，以及版面、母片與投影片層級的文字樣式的本地值，找出第一個明確定義的地方。

**為何有效值有時看起來與本地值相同？**

因為本地值已是最終值（不需要更高層級的繼承）。在此情況下，有效值與本地值相同。

**何時該使用有效屬性，何時只使用本地屬性？**

當您需要在套用所有繼承後的「實際呈現」結果時（例如對齊顏色、縮排或尺寸），應使用有效資料。若需保留這些值以免後續格式變更影響，請將必要的屬性複製到自己的物件中。若要在特定層級變更格式，請修改本地屬性，必要時再讀取有效資料以驗證結果。