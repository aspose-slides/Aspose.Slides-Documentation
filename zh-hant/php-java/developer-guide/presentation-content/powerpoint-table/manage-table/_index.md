---
title: 管理 PHP 中的簡報表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh-hant/php-java/manage-table/
keywords:
- 新增表格
- 建立表格
- 存取表格
- 長寬比
- 文字對齊
- 文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 投影片中建立與編輯表格。探索簡易程式碼範例，簡化您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格將資訊組織成行與列，讓讀取和比較數值更加容易。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 類別、[Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) 類別以及其他類型，讓您能在簡報中建立、更新與管理表格。

## **從頭建立表格**

透過指定位置、欄寬與列高來建立表格。將其加入投影片後，您可以設定儲存格邊框、合併儲存格，並插入文字。

1. 建立 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別的實例。
2. 根據索引取得投影片參考。
3. 定義以點為單位的欄寬陣列。
4. 定義以點為單位的列高陣列。
5. 透過 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) 方法，將 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 物件加入投影片。
6. 遍歷每個 [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) 以套用上、下、左、右邊框的格式。
7. 合併表格第一列的前兩個儲存格。
8. 透過其 [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) 方法存取合併後的儲存格。
9. 設定合併儲存格內的文字。
10. 儲存已修改的簡報。

以下範例在 (100, 50) 點處建立一個具有三欄五列的表格。它套用寬度為 5 點的紅色邊框，合併第一列的前兩個儲存格，並將結果儲存為 `table.pptx`。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **標準表格的編號方式**

在標準表格中，儲存格索引為從零開始，且使用 (欄, 列) 的順序。第一個儲存格的索引為 (0, 0)。

例如，具有 4 欄 4 列的表格其儲存格編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此範例建立上述示意的 4 × 4 表格，欄寬與列高皆為 70 點，且套用寬度為 5 點的紅色儲存格邊框。座標說明了儲存格索引；此範例保持儲存格為空，並將表格儲存為 `StandardTables_out.pptx`。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **存取現有表格**

表格儲存在投影片的形狀集合中。遍歷形狀以找到表格，然後使用 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 類別讀取或更新其儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別載入簡報。
2. 根據索引取得包含表格的投影片參考。
3. 遍歷 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 物件，當找到表格時即停止。如果投影片包含多個表格，請使用 [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) 來辨識所需的表格。
4. 更新目標儲存格中的文字。
5. 儲存已修改的簡報。

以下範例開啟 `UpdateExistingTable.pptx`，並在第一張投影片上找到第一個表格。它將第 0 欄第 1 列的儲存格設為 `New`，並將結果儲存為 `table1_out.pptx`。輸入檔必須至少包含一張投影片，且該投影片上的第一個表格必須至少有一欄兩列。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

要在現有表格中調整列高，並了解其實際高度為何可能超過要求的最小值，請參閱[控制列高](/slides/zh-hant/php-java/manage-rows-and-columns/#control-row-height)。

## **找出擁有文字框的儲存格**

當一般文字處理程式碼從表格取得 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 時，請使用 [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) 方法取得其擁有的 [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)。對於表格儲存格的文字框，[TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) 會回傳擁有者，而 [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) 會回傳 `null`，即使表格本身也是形狀。

儲存格座標可透過唯讀的 [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) 與 [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) 方法取得。[TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) 亦提供唯讀的導覽：它回傳擁有者但不會改變所有權。使用前務必以 `java_is_null` 檢查返回的儲存格是否為 null。

欲取得包含 SmartArt 節點之形狀的完整範例，請參閱[搜尋與取代文字](/slides/zh-hant/php-java/search-and-replace-text/)。

## **對齊表格內文字**

您可以控制個別表格儲存格的垂直錨定與文字方向。本節範例將文字置中於第一個儲存格，並旋轉 270 度。

1. 建立 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別的實例。
2. 根據索引取得投影片參考。
3. 將 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 物件加入投影片。
4. 從表格取得 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 物件。
5. 取得第一個 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)，並設定其文字與顏色。
6. 使用 [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) 與 [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/) 設定儲存格的垂直錨定與文字方向。
7. 儲存已修改的簡報。

此範例建立一個 4 × 4 表格，欄寬為 120 點、列高為 100 點。它格式化儲存格 (0, 0) 的文字，並在第一列的其餘儲存格加入值，最後將結果儲存為 `Vertical_Align_Text_out.pptx`。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在表格層級設定文字格式**

使用 [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) 將文字格式套用至表格中的所有儲存格。其多載接受區塊、段落與文字框格式，讓您無需遍歷個別儲存格即可設定這些屬性。

1. 使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別載入簡報。
2. 根據索引取得投影片參考。
3. 從投影片取得 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 物件。
4. 使用 [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) 設定文字的字型大小。
5. 使用 [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) 與 [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) 設定段落對齊方式及右側邊距。
6. 使用 [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) 設定文字方向。
7. 儲存已修改的簡報。

以下範例開啟 `table.pptx`（該檔案必須至少包含一張投影片，且其第一個形狀為表格）。它將字型大小設定為 25 點，段落右對齊且右側邊距為 20 點，並將文字設定為垂直。格式化後的簡報儲存為 `result.pptx`。

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **取得表格樣式屬性**

使用 [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) 讀取表格的預設樣式，使用 [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) 指定樣式。本範例將 [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) 套用於一個表格，列印預設值，並將相同的預設套用於第二個表格。兩個表格皆儲存於 `table-style.pptx`。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **鎖定表格的長寬比**

表格的長寬比是其寬度與高度的比例。使用 [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) 可以鎖定表格的長寬比。

以下範例開啟 `pres.pptx`（該檔案必須至少包含一張投影片，且其第一個形狀為表格）。它列印目前的鎖定狀態，啟用長寬比鎖定，列印更新後的狀態（`true`），最後將結果儲存為 `pres-out.pptx`。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**我可以為整個表格及其儲存格內的文字啟用從右至左 (RTL) 閱讀方向嗎？**

可以。表格提供了 [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) 方法，段落則有 [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/)。同時使用可確保儲存格內的 RTL 順序與呈現正確。

**我該如何防止使用者在最終檔案中移動或調整表格大小？**

使用 [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) 可停用移動、調整大小、選取等功能。這些鎖定同樣適用於表格。

**是否支援在儲存格內插入圖片作為背景？**

可以。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/)；圖片會依所選模式（拉伸或平鋪）覆蓋儲存格區域。