---
title: 從 JavaScript 中的簡報取得圖形實際屬性
linktitle: 實際屬性
type: docs
weight: 50
url: /zh-hant/nodejs-java/shape-effective-properties/
keywords:
- 圖形屬性
- 攝影機屬性
- 光源裝置
- 斜角圖形
- 文字框
- 文字樣式
- 字型高度
- 填充格式
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 來區分 PowerPoint 簡報中圖形格式的本機、繼承與實際屬性。"
---
## **了解本機、繼承及實際屬性**

PowerPoint 格式化可能來自多個來源。直接儲存在物件上的值稱為 **本機值**。如果未設定本機值，PowerPoint 會檢查父層的格式來源，例如段落預設、文字樣式、版面或母片投影片、佈景主題，或整份簡報的預設值。這些值稱為 **繼承值**。在整個層級解析完成後剩餘的值即為 **實際值**——用來呈現物件的最終值。

例如，文字片段可能未自行定義字型高度。其本機 [getFontHeight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/#getFontHeight) 值會是 `NaN`，表示「此處未設定」。該片段可以從其段落、簡報的預設文字樣式或其他適用來源繼承高度。對片段格式呼叫 [getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/#getEffective) 會返回最終解析後的高度。

針對不同需求使用兩種格式資料：

- 讀取或變更本機格式物件，例如 [PortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/)，當您需要控制值的定義位置時。
- 讀取由 PortionFormat.getEffective 返回的 **實際資料**，當您需要最終渲染結果時。實際資料為唯讀。

在執行範例之前，請先[安裝 Aspose.Slides for Node.js via Java](/slides/zh-hant/nodejs-java/installation/)。

## **比較本機、繼承及實際值**

以下完整範例會建立一個圖形，並在簡報、段落與片段層級設定字型高度。每個步驟都會列印出在這些層級所定義的值以及同一文字片段的最終實際值。它同時說明為何在格式變更後必須再次讀取實際資料。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // 在前一步變更後讀取實際資料。
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // 在兩個不同層級定義繼承值。
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // 片段上的本機值會覆寫兩個繼承值。
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // 變更繼承值不會覆寫已存在的本機值。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // 清除本機值。片段現在再次從段落繼承。
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // 清除段落值。簡報的預設值現在提供結果。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

本例的優先順序為：片段本機格式 → 段落格式 → 簡報預設。其他物件可能有不同的繼承鏈，但原理相同：較具體的明確值會取代較廣的值，而 [getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/#getEffective) 會返回最終結果。

## **取得實際文字屬性**

文字格式分散在多個物件中：

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#getEffective) 解析文字框屬性，例如邊距、錨點、自動調整與垂直文字方向。
- [TextStyle.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textstyle/#getEffective) 解析每個文字樣式層級的段落格式。
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#getEffective) 解析段落屬性，例如對齊、縮排與項目符號。
- [PortionFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/#getEffective) 解析字元屬性，例如字型高度、字型、顏色、粗體與斜體。

接下來的範例需要 `text-formatting.pptx` 至少包含一張投影片與一個帶有非空文字框的 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。AutoShape 可以位於圖形集合中的任何位置；程式碼會搜尋符合條件的物件並在使用前驗證它。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **取得實際 3D 屬性**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getEffective) 會返回一個實際資料物件，將所有已解析的 3D 設定彙總。其 [getCamera](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getCamera)、[getLightRig](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getLightRig)、[getBevelTop](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getBevelTop) 與 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getBevelBottom) 方法會公開相對應的實際資料。一起讀取這些相關設定，可更容易了解形狀最終的 3D 外觀。

此範例的 `shape-3d.pptx` 必須在第一張投影片上至少包含一個形狀。若要看到非預設值，請對該形狀套用 3D 攝影機、光源或斜角設定。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **取得實際表格格式**

表格格式可能來源於表格樣式，也可能來源於套用於整個表格、欄、列或單一儲存格的格式。若明確定義的填充發生衝突，優先順序為：儲存格 → 列 → 欄 → 整個表格。儲存格的實際格式即為繪製該儲存格時使用的最終格式。

此範例的 `table-formatting.pptx` 必須在第一張投影片上至少包含一個表格，且表格至少有一列與一欄。程式碼會搜尋 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/table/)，而不是假設 `getShapes().get_Item(0)` 為表格。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

如果您需要取得顏色而不只填充類型，請先檢查實際的 [getFillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/#getFillType)，然後讀取對應類型的方法——例如針對實心填充使用 [getSolidFillColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/#getSolidFillColor)。

## **變更後重新讀取實際資料**

實際資料描述了解析當時的格式層級。於任何可能參與該層級的項目變更後，都應再次呼叫 `getEffective`，包括：

- 物件的本機格式；
- 段落或文字框的預設值；
- 表格樣式、表格、欄、列或儲存格的格式；
- 版面或母片投影片的格式；
- 佈景主題或簡報層級的預設值；
- 指派給投影片的版面或母片。

請勿將實際資料物件當作永久快照保存。Aspose.Slides 可能在內部快取某些實際資料，稍後再呼叫 `getEffective` 時會刷新該資料。若需比較變更前後的值，請在變更前將所需的標量值（例如字型高度、顏色、對齊方式或斜角寬度）複製到自己的變數中。

若要變更值，請更新相應的本機格式物件，然後呼叫 `getEffective` 以驗證結果。實際資料物件本身為唯讀。

## **常見問答**

**我如何判斷是哪個層級提供了實際值？**

實際資料只包含最終值，並不指示來源。請從最具體的層級向外檢查相關的本機物件。對於文字，可能包括片段、段落、文字框、版面、母片、佈景主題以及簡報預設。`NaN` 或 `null` 等未定義值表示會繼續向上搜尋。

**若沒有任何層級定義屬性會發生什麼？**

Aspose.Slides 會解析出適當的 PowerPoint 或程式庫預設值。即使本機物件未明確定義，解析後的預設值仍會出現在實際資料中。

**為什麼實際值有時會等於本機值？**

本機值在繼承計算中獲勝。當屬性在物件上明確設定且沒有更具體的規則覆蓋時，就會出現此情況，這是預期的行為。

**什麼時候應該使用本機資料而非實際資料？**

在需要檢查或編輯特定層級的格式時使用本機資料。當需要在繼承、主題規則與相關樣式解析後的最終外觀時，則使用實際資料。[完整比較範例](#compare-local-inherited-and-effective-values) 同時示範了兩者的使用情境。