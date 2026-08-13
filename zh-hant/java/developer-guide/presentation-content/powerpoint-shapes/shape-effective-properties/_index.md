---
title: 從 Java 簡報取得形狀有效屬性
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/java/shape-effective-properties/
keywords:
- 形狀屬性
- 相機屬性
- 光源裝置
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
## **概觀**

本主題說明 **local** 與 **effective** 屬性的差異。Local 值是直接在特定格式層級設定的值，例如：

1. 投影片上文字片段的屬性。
1. 當文字片段的文字框形狀具有樣式時，版面或母片上原型形狀的文字樣式。
1. 簡報中的全域文字設定。

Local 值可以在任何層級定義或省略。當 Aspose.Slides 需要最終「呈現」的格式時，它會解析繼承鏈並返回 **effective** 值。您可以透過在本機格式物件上呼叫 `getEffective` 方法取得這些值。

以下範例說明如何取得 effective 值。假設第一張投影片的第一個形狀是一個具有文字框且至少包含一個文字片段的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)。

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
Effective formatting data 代表在套用繼承後目前計算出的格式。於目前的實作中，某些 effective data 物件（例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPortionFormatEffectiveData)）可能會在內部快取。於變更父層或繼承的格式後再次呼叫 `getEffective` 可以重新整理快取的資料，先前取得的物件可能不再代表先前的狀態。若需要保留 effective 值以供之後重複使用，請將必要的屬性（例如字型高度、填色、字型樣式或對齊方式）複製到自己的資料物件中。
{{% /alert %}}

## **取得相機的 Effective 屬性**

Aspose.Slides 允許您取得相機的 effective 屬性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICameraEffectiveData) 介面表示一個不可變的物件，內含 effective 相機屬性。透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IThreeDFormatEffectiveData) 可取得 [ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICameraEffectiveData) 實例，該介面提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IThreeDFormat) 的 effective 值。

以下程式碼範例示範如何取得相機的 effective 屬性。假設第一張投影片的第一個形狀具有 3D 格式。

```java
import com.aspose.slides.*;

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

## **取得光源裝置的 Effective 屬性**

Aspose.Slides 允許您取得光源裝置的 effective 屬性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ILightRigEffectiveData) 介面表示一個不可變的物件，內含 effective 光源裝置屬性。透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IThreeDFormatEffectiveData) 可取得 [ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ILightRigEffectiveData) 實例，該介面提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IThreeDFormat) 的 effective 值。

以下程式碼範例示範如何取得光源裝置的 effective 屬性。假設第一張投影片的第一個形狀具有 3D 格式。

```java
import com.aspose.slides.*;

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

## **取得斜角形狀的 Effective 屬性**

Aspose.Slides 允許您取得斜角形狀的 effective 屬性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeBevelEffectiveData) 介面表示一個不可變的物件，內含形狀面部浮雕的 effective 屬性。透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IThreeDFormatEffectiveData) 可取得 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeBevelEffectiveData) 實例，該介面提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IThreeDFormat) 的 effective 值。

以下程式碼範例示範如何取得形狀上斜角 (top bevel) 的 effective 屬性。假設第一張投影片的第一個形狀具有 3D 格式。

```java
import com.aspose.slides.*;

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

## **取得文字框的 Effective 屬性**

使用 Aspose.Slides，您可以取得文字框的 effective 屬性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrameFormatEffectiveData) 介面包含文字框的 effective 格式屬性。

以下程式碼範例示範如何取得文字框的 effective 格式屬性。假設第一張投影片的第一個形狀是具有文字框的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)。

```java
import com.aspose.slides.*;

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

## **取得文字樣式的 Effective 屬性**

使用 Aspose.Slides，您可以取得文字樣式的 effective 屬性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextStyleEffectiveData) 介面包含文字樣式的 effective 屬性。

以下程式碼範例示範如何取得文字樣式的 effective 屬性。假設第一張投影片的第一個形狀是具有文字框的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)。

```java
import com.aspose.slides.*;

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

使用 Aspose.Slides，您可以取得 effective 字型高度。以下程式碼示範在不同簡報結構層級設定本機字型高度後，文字片段的 effective 字型高度如何變化。

```java
import com.aspose.slides.*;

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

因此，繪製表格儲存格時會使用 [ICellFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICellFormatEffectiveData) 的屬性。以下程式碼範例示範如何取得不同表格部分的 effective 填充格式。假設第一張投影片的第一個形狀是一個 [ITable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITable)。

```java
import com.aspose.slides.*;

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

## **常見問題**

### `getEffective` 會返回快照嗎？

不一定。Effective data 代表套用繼承後計算出的格式，但某些 effective data 物件可能在內部被快取。之後再次呼叫 `getEffective` 可能會重新計算格式並刷新快取的資料，因此先前取得的物件不應被視為永久的快照。

### 什麼時候應該重新讀取 effective 屬性？

在變更本機格式、父層樣式、版面格式、母片格式或簡報層級的預設值之後，請再次呼叫 `getEffective`。下一次呼叫會重新評估格式階層，並返回目前的 effective 結果。

### 更改或移除版面/母片是否會影響已取得的 effective 屬性？

會，然而變更會在下一次 `getEffective` 呼叫時顯現。如果父層格式來源被變更或移除，先前取得的 effective data 可能已過時。再次呼叫 `getEffective` 後，Aspose.Slides 會重新評估格式樹，導致字型、顏色、大小或其他值可能改變。

### 我可以透過 effective data 物件修改值嗎？

不能。Effective data 物件僅提供計算後的值。請在本機格式物件中進行變更，然後再次取得 effective 值。

### 如果屬性在形狀層級、版面/母片或全域設定皆未設定，會發生什麼？

effective 值將由預設機制決定，該機制包含 PowerPoint 與 Aspose.Slides 的預設值。解析出的值會成為目前 effective data 的一部份。

### 從 effective 的字型值，我能判斷是哪個層級提供的大小或字型嗎？

不能直接得知。Effective data 只回傳最終值。若要找出來源，必須檢查文字片段、段落、文字框以及版面、母片與簡報層級的文字樣式的本機值，找出首次明確定義的層級。

### 為什麼 effective 值有時與本機值相同？

因為本機值最終即為最終值（不需要更高層級的繼承）。在此情況下，effective 值與本機值相同。

### 什麼時候應使用 effective 屬性，什麼時候只使用本機屬性？

當您需要在套用所有繼承後的「實際呈現」結果時，請使用 effective data，例如對齊顏色、縮排或尺寸。若需在之後的格式變更中保留這些值，請將必要的屬性複製到自己的物件中。若要在特定層級變更格式，請修改本機屬性，然後在需要時再次讀取 effective data 以驗證結果。