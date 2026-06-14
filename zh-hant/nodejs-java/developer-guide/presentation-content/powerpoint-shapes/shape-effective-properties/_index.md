---
title: 從簡報中取得形狀的有效屬性（JavaScript）
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/nodejs-java/shape-effective-properties/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "探索 Aspose.Slides for Node.js（透過 Java）如何計算並套用有效的形狀屬性，以實現精確的 PowerPoint 呈現。"
---
## **概觀**

本主題說明 **本機** 與 **有效** 屬性之間的差異。本機值是在特定格式層級直接設定的值，例如：

1. 投影片上文字片段的屬性。  
1. 當文字片段的文字框形狀具備原型形狀文字樣式時，布局或母片上的原型形狀文字樣式。  
1. 簡報中的全域文字設定。

本機值可以在任何層級定義或省略。當 Aspose.Slides 需要最終「如呈現」的格式時，它會解析繼承鏈並回傳 **有效** 值。您可以透過對本機格式物件呼叫 `getEffective` 方法取得這些值。

以下範例示範如何取得有效值。假設第一張投影片上的第一個圖形是具有文字框且至少包含一個文字片段的 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。

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
有效格式資料代表在套用繼承後所計算出的目前格式。在目前的實作中，某些有效資料物件可能會在內部快取。於變更父級或繼承格式後再次呼叫 `getEffective` 可以重新整理快取資料，先前取得的物件可能不再代表先前的狀態。若需要保留有效值以供日後使用，請將必要的屬性（例如字型高度、填色、字型樣式或對齊方式）複製到您自己的資料物件中。
{{% /alert %}}

## **取得相機的有效屬性**

Aspose.Slides 允許您取得相機的有效屬性。有效的相機資料物件包含不可變的相機屬性，並透過 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/) 回傳的有效值予以公開。

以下程式碼範例示範如何取得相機的有效屬性。假設第一張投影片上的第一個圖形具有 3D 格式。

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

## **取得光源裝置的有效屬性**

Aspose.Slides 允許您取得光源裝置的有效屬性。有效的光源裝置資料物件包含不可變的光源裝置屬性，並透過 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/) 回傳的有效值予以公開。

以下程式碼範例示範如何取得光源裝置的有效屬性。假設第一張投影片上的第一個圖形具有 3D 格式。

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

## **取得斜角形狀的有效屬性**

Aspose.Slides 允許您取得形狀斜角的有效屬性。有效的形狀斜角資料物件包含不可變的面部凸起屬性，並透過 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/) 回傳的有效值予以公開。

以下程式碼範例示範如何取得形狀上方斜角的有效屬性。假設第一張投影片上的第一個圖形具有 3D 格式。

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

## **取得文字框的有效屬性**

使用 Aspose.Slides，您可以取得文字框的有效屬性。回傳的有效資料物件包含文字框格式屬性。

以下程式碼範例示範如何取得有效的文字框格式屬性。假設第一張投影片上的第一個圖形是具有文字框的 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。

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

## **取得文字樣式的有效屬性**

使用 Aspose.Slides，您可以取得文字樣式的有效屬性。回傳的有效資料物件包含文字樣式屬性。

以下程式碼範例示範如何取得有效的文字樣式屬性。假設第一張投影片上的第一個圖形是具有文字框的 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。

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

## **取得有效的字型高度值**

使用 Aspose.Slides，您可以取得有效的字型高度。以下程式碼示範在不同簡報結構層級設定本機字型高度後，文字片段的有效字型高度如何變化。

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

## **取得表格的有效填充格式**

使用 Aspose.Slides，您可以取得不同表格部分的有效填充格式。回傳的有效資料物件包含填充格式屬性。儲存格格式的優先度高於列格式，列格式高於欄格式，欄格式高於整表格式。

因此，實際繪製表格儲存格時會使用有效的儲存格格式屬性。以下程式碼範例示範如何取得不同表格部分的有效填充格式。假設第一張投影片上的第一個圖形是 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/table/)。

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

## **常見問答**

**`getEffective` 會回傳快照嗎？**

不一定。有效資料代表在套用繼承後所計算出的格式，但某些有效資料物件可能會在內部快取。隨後的 `getEffective` 呼叫可能會重新計算格式並刷新快取資料，因此先前取得的物件不應被視為永久快照。

**何時需要再次讀取有效屬性？**

在變更本機格式、父樣式、布局格式、母片格式或簡報層級預設值後，請再次呼叫 `getEffective`。下一次呼叫會重新評估格式層級並回傳目前的有效結果。

**變更或移除布局/母片是否會影響已取得的有效屬性？**

會，但變更會在下一次 `getEffective` 呼叫時反映出來。如果父級格式來源被變更或移除，先前取得的有效資料可能已過時。再次呼叫 `getEffective` 後，Aspose.Slides 會重新評估格式樹，導致字型、顏色、大小或其他值可能改變。

**可以透過有效資料物件修改值嗎？**

不能。有效資料物件僅提供計算後的值。請在本機格式物件中進行變更，然後再次取得有效值。

**如果在圖形層級、布局/母片以及全域設定皆未設定某屬性，會發生什麼？**

有效值會由預設機制決定，該機制包括 PowerPoint 與 Aspose.Slides 的預設值。解析後的值會成為目前有效資料的一部份。

**從有效的字型值能否判斷是哪個層級提供的大小或字型？**

不能直接判斷。有效資料只返回最終值。若要找出來源，需檢查文字片段、段落、文字框以及布局、母片和簡報層級的本機值，找出第一個明確定義的層級。

**為什麼有效值有時看起來與本機值相同？**

因為本機值本身已是最終值（不需要更高層級的繼承）。在此情況下，有效值與本機值相同。

**什麼時候應使用有效屬性，什麼時候只使用本機屬性？**

當您需要「如呈現」的最終結果（即所有繼承套用後的結果）時，使用有效資料，例如對齊顏色、縮排或大小。若您需要在後續格式變更後仍保留這些值，請將必要的屬性複製到自己的物件中。若您僅需在特定層級修改格式，請變更本機屬性，然後在需要時再次讀取有效資料以驗證結果。