---
title: 在 PHP 中從簡報取得形狀的有效屬性
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/php-java/shape-effective-properties/
keywords:
- 形狀屬性
- 相機屬性
- 燈光設備
- 斜角形狀
- 文字框
- 文字樣式
- 字型高度
- 填充格式
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP（透過 Java）如何計算並套用形狀的有效屬性，以實現精確的 PowerPoint 呈現。"
---
## **概述**

本主題說明 **local** 與 **effective** 屬性之間的差異。Local 值是直接在特定格式層級設定的值，例如：

1. 投影片上的區段屬性。  
1. 版面或母片投影片上原型形狀的文字樣式，當區段的文字框形狀具有該樣式時。  
1. 簡報中的全域文字設定。

Local 值可以在任何層級定義或省略。當 Aspose.Slides 需要最終「呈現後」的格式時，它會解析繼承鏈並回傳 **effective** 值。您可以透過呼叫本地格式物件的 `getEffective` 方法取得它們。

以下範例說明如何取得 effective 值。假設第一張投影片的第一個形狀是一個具備文字框且至少有一個區段的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Effective 格式資料代表在套用繼承後的當前計算格式。在目前的實作中，透過 [PortionFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/geteffective/) 等方法返回的某些 effective 資料物件可能會在內部快取。於變更父層或繼承格式後再次呼叫 `getEffective` 可以重新整理快取資料，而先前取得的物件可能不再代表先前的狀態。如果您需要保留 effective 值以供稍後重複使用，請將所需的屬性（例如字型高度、填色、字型樣式或對齊方式）複製到您自己的資料物件中。
{{% /alert %}}

## **取得相機的 Effective 屬性**

Aspose.Slides 允許您取得相機的 effective 屬性。由 [ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/geteffective/) 返回的 effective 資料包含針對 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/) 的最終相機屬性。

以下程式碼範例示範如何取得相機的 effective 屬性。假設第一張投影片的第一個形狀具有 3D 格式設定。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **取得燈光設備的 Effective 屬性**

Aspose.Slides 允許您取得燈光設備的 effective 屬性。由 [ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/geteffective/) 返回的 effective 資料包含針對 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/) 的最終燈光設備屬性。

以下程式碼範例示範如何取得燈光設備的 effective 屬性。假設第一張投影片的第一個形狀具有 3D 格式設定。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **取得斜角形狀的 Effective 屬性**

Aspose.Slides 允許您取得形狀斜角的 effective 屬性。由 [ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/geteffective/) 返回的 effective 資料包含針對 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/) 的最終表面凹凸屬性。

以下程式碼範例示範如何取得形狀上方斜角的 effective 屬性。假設第一張投影片的第一個形狀具有 3D 格式設定。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **取得文字框的 Effective 屬性**

使用 Aspose.Slides，您可以取得文字框的 effective 屬性。由 [TextFrameFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/geteffective/) 返回的 effective 資料包含文字框的格式屬性。

以下程式碼範例示範如何取得文字框的 effective 格式屬性。假設第一張投影片的第一個形狀是一個具備文字框的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **取得文字樣式的 Effective 屬性**

使用 Aspose.Slides，您可以取得文字樣式的 effective 屬性。由 [TextStyle.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textstyle/geteffective/) 返回的 effective 資料包含文字樣式的屬性。

以下程式碼範例示範如何取得文字樣式的 effective 屬性。假設第一張投影片的第一個形狀是一個具備文字框的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **取得 Effective 字型高度值**

使用 Aspose.Slides，您可以取得 effective 字型高度。以下程式碼示範在簡報結構的不同層級設定本地字型高度後，區段的 effective 字型高度如何變化。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **取得表格的 Effective 填充格式**

使用 Aspose.Slides，您可以取得不同表格部分的 effective 填充格式。由格式物件返回的 effective 資料包含 [FillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/) 屬性。儲存格格式的優先權高於列格式，列格式高於欄格式，欄格式高於整表格格式。

因此，繪製表格儲存格時會使用 effective 的 [CellFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellformat/) 屬性。以下程式碼範例示範如何取得不同表格部分的 effective 填充格式。假設第一張投影片的第一個形狀是一個 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/table/)。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**`getEffective` 會返回快照嗎？**

不一定。Effective 資料代表在套用繼承後計算出的格式，但某些 effective 資料物件可能會在內部快取。隨後呼叫 `getEffective` 可能會重新計算格式並刷新快取資料，因此先前取得的物件不應被視為永久的快照。

**什麼時候需要再次讀取 effective 屬性？**

在變更本地格式、父層樣式、版面格式、母片格式或簡報級別的預設值後，請再次呼叫 `getEffective`。下一次呼叫會重新評估格式階層，返回當前的 effective 結果。

**變更或移除版面/母片投影片會影響已取得的 effective 屬性嗎？**

會，但變更會在下一次 `getEffective` 呼叫時顯現。若父層格式來源被變更或移除，先前取得的 effective 資料可能已過時。再次呼叫 `getEffective` 後，Aspose.Slides 會重新評估格式樹，字型、顏色、大小或其他值可能會改變。

**可以透過 effective 資料物件修改值嗎？**

不能。Effective 資料物件僅提供計算出的值。請在本地格式物件中進行變更，然後再取得 effective 值。

**如果屬性在形狀層級、版面/母片層級以及全域設定中皆未設定，會發生什麼？**

effective 值會由預設機制決定，該機制包括 PowerPoint 與 Aspose.Slides 的預設值。解析出的值將成為當前 effective 資料的一部份。

**從 effective 字型值能否判斷是哪個層級提供了尺寸或字型？**

不能直接。Effective 資料僅返回最終值。若要找出來源，必須檢查區段、段落、文字框以及版面、母片、簡報層級的本地值，找出第一個明確定義的層級。

**為何 effective 值有時看起來與本地值相同？**

因為本地值最終成為了最終值（不需要更高層級的繼承）。在此情況下，effective 值與本地值相同。

**什麼情況下應使用 effective 屬性，什麼情況下只使用本地屬性？**

當您需要在所有繼承套用後的「實際呈現」結果時，請使用 effective 資料，例如對齊顏色、縮排或大小。如果您需要在之後的格式變更中保留這些值，請將所需屬性複製到自己的物件中。若您只想在特定層級修改格式，請變更本地屬性，然後如有需要再次讀取 effective 資料以驗證結果。