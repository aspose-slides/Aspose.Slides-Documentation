---
title: 從 PHP 簡報中取得形狀的有效屬性
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/php-java/shape-effective-properties/
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
- PHP
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for PHP via Java 來辨別 PowerPoint 簡報中形狀的本機、繼承與有效格式設定。"
---
## **了解本機、繼承與有效屬性**

PowerPoint 的格式化可能來自多個來源。直接儲存在物件上的值稱為**本機值**。如果未設定該值，PowerPoint 會檢查父層的格式來源，例如段落預設、文字樣式、版面或母片、佈景主題，或簡報層級的預設。這些值稱為**繼承值**。在整個層級解析完成後剩餘的值即為**有效值**——用來呈現物件的值。

例如，文字片段可能未定義自己的字型高度。其本機 [getFontHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/) 值會是 `NAN`，表示「此處未設定」。該片段可以從其段落、簡報的預設文字樣式或其他適用來源繼承高度。對片段格式呼叫 [getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/geteffective/) 會返回最終解析的高度。

針對不同目的使用兩種格式化資料：

- 在需要控制值定義位置時，讀取或變更本機格式物件，例如 [PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/)。
- 在需要最終呈現結果時，讀取有效資料物件，例如 [PortionFormat.getEffective 回傳的資料](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/geteffective/)。有效資料為唯讀。

在執行範例之前，請[安裝 Aspose.Slides for PHP via Java](/slides/zh-hant/php-java/installation/).

## **比較本機、繼承與有效值**

以下完整範例會建立一個圖形，並在簡報、段落與片段層級套用字型高度。每個步驟都會列印出該層級定義的值以及同一文字片段的最終有效值。它同時說明為何在格式變更後必須重新讀取有效資料。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // 在先前的變更之後讀取有效資料。
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // 在兩個不同層級定義繼承值。
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // 片段上的本機值會覆寫兩個繼承值。
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // 變更繼承值不會覆寫已存在的本機值。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // 清除本機值。片段現在再次繼承自段落。
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // 清除段落值。簡報預設現在提供結果。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

此範例的優先順序為片段本機格式、接著段落格式，最後是簡報預設。其他物件可能有不同的繼承鏈，但原則相同：較具體的明確值會取代較一般的值，而 [getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/geteffective/) 會返回最終結果。

## **取得有效文字屬性**

文字格式化分散在多個物件中：

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/geteffective/) 解析文字框屬性，如邊距、錨點、自動調整以及垂直文字方向。
- [TextStyle.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textstyle/geteffective/) 解析每個文字樣式層級的段落格式。
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/geteffective/) 解析段落屬性，如對齊、縮排與項目符號。
- [PortionFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/geteffective/) 解析字元屬性，如字型高度、字型、顏色、粗體與斜體。

對於下一個範例，`text-formatting.pptx` 必須至少包含一張投影片以及一個具有非空文字框的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。AutoShape 可以位於圖形集合中的任意位置；程式碼會搜尋合適的物件並在使用前驗證它。

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **取得有效 3D 屬性**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/geteffective/) 回傳一個有效資料物件，將所有解析後的 3D 設定彙總。其 [getCamera](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/geteffective/)、[getLightRig](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/geteffective/)、[getBevelTop](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/geteffective/) 與 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/geteffective/) 方法會公開對應的有效資料。一起閱讀這些相關設定能更容易理解形狀的最終 3D 外觀。

此範例的 `shape-3d.pptx` 必須在第一張投影片上至少包含一個圖形。若希望輸出包含非預設值，請對該圖形套用 3D 相機、光線或斜角設定。

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **取得有效表格格式化**

表格格式化可能來自表格樣式，也可能來自套用於整個表格、欄、列或單一儲存格的格式。對於明確定義的填滿衝突，其優先順序為儲存格、列、欄，最後是整個表格。儲存格的有效格式即為繪製該儲存格時使用的最終格式。

此範例的 `table-formatting.pptx` 必須在第一張投影片上至少包含一個表格。該表格必須至少有一列和一欄。程式碼會搜尋 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/table/)，而不會假設 `getShapes()->get_Item(0)` 為表格。

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

如果需要顏色而不僅是填滿類型，請先檢查有效的 [getFillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/geteffective/) 值，然後讀取對應類型的方法——例如，對於實心填滿使用 [getSolidFillColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/geteffective/)。

## **變更後重新讀取有效資料**

有效資料描述解析時的格式層級。於變更任何可能參與該層級的項目後，請再次呼叫 `getEffective`，包括：

- 物件的本機格式；
- 段落或文字框的預設值；
- 表格樣式、表格、欄、列或儲存格的格式；
- 版面或母片的格式；
- 佈景主題資料或簡報層級的預設值；
- 指派給投影片的版面或母片。

不要將有效資料物件作為永久快照保存。Aspose.Slides 可能在內部快取部分有效資料，而之後的 `getEffective` 呼叫可刷新該資料。若需比較變更前後的值，請在變更前將所需的標量值（例如字型高度、顏色、對齊或斜角寬度）複製到自己的變數中。

若要變更值，請更新相應的本機格式物件，然後呼叫 `getEffective` 以驗證結果。有效資料物件本身是唯讀的。

## **常見問題**

**如何判斷是哪個層級提供的有效值？**

有效資料只包含最終值，並未指示其來源。請從最具體的層級向外檢查相關的本機物件。對於文字，可能包含片段、段落、文字框、版面、母片、佈景主題與簡報預設。`NAN` 或 `null` 等未定義值表示搜尋會繼續至更上層。

**當沒有任何層級定義屬性時會發生什麼情況？**

Aspose.Slides 會解析出相應的 PowerPoint 或函式庫預設值。即使沒有本機物件明確定義，該解析後的值仍會出現在有效資料中。

**為何有效值有時會等於本機值？**

本機值在繼承計算中取得優先權。當屬性在物件上明確設定且沒有更具體的規則覆蓋時，這是預期的結果。

**何時應使用本機資料而非有效資料？**

在檢查或編輯特定的格式層級時使用本機資料。當需要在繼承、主題規則與適用樣式解析後的最終外觀時，則使用有效資料。[完整比較範例](#compare-local-inherited-and-effective-values) 在同一工作流程中示範兩者的使用。