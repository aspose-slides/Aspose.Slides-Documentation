---
title: 在簡報中使用 PHP 管理表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/php-java/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 拆分儲存格
- 儲存格內的影像
- 背景顏色
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中管理 PowerPoint 表格儲存格：識別合併儲存格、移除邊框、拆分儲存格，並使用 Aspose.Slides for PHP via Java 設定背景顏色與影像。"
---
## **概觀**

Aspose.Slides 讓您能在 PowerPoint 簡報中存取與修改表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景色彩，以及在表格儲存格內加入影像。範例展示如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

Aspose.Slides 使用從零開始的索引，以 `(column, row)` 的順序存取表格儲存格。

## **識別合併的表格儲存格**

此範例開啟現有的簡報，並將第一投影片上的第一個圖形作為表格存取。它假設投影片與圖形皆存在且該圖形為表格。接著遍歷所有列與欄，並使用 [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) 來識別合併區域中的儲存格。對於每個符合的儲存格，會以 `row;column` 的順序輸出座標，並顯示 [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)、[getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/)，以及區域的起始座標 [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) 和 [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/)。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **移除表格儲存格邊框**

建立一個 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 並使用 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) 將表格加入其第一張投影片。欄寬、列高以及表格位置皆以點 (points) 為單位指定。此範例將四個儲存格邊框皆設定為 [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)，使其不可見。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **合併表格儲存格**

使用 [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) 將矩形範圍的表格儲存格合併為一個儲存格。指定範圍左上角與右下角的儲存格。最後一個參數控制合併是否可包含指定範圍外的儲存格；`false` 會將合併限制在該範圍內。

此範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，然後合併位於 `(1, 1)` 至 `(2, 2)` 的四個中心儲存格。合併後的儲存格跨兩個欄與兩個列，而表格的底層格線仍保留四個欄與四個列。若要存取合併儲存格的內容或格式，請使用其左上角位置：本例中的 `$table->get_Item(1, 1)`。合併範圍內的其他位置仍屬於表格格線，因此範圍外的儲存格索引不會變化。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **拆分表格儲存格**

在前述範例中合併儲存格會保留表格的格線。拆分儲存格可能會新增一個格線欄，並變更其右側儲存格的欄索引。Aspose.Slides 遵循 PowerPoint 的表格格線模型。

此範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，並對儲存格 `(1, 1)` 呼叫 [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/)。將該儲存格 70 點寬度的一半傳入，以建立兩個等寬的儲存格。

拆分後，兩個子儲存格分別以 `$table->get_Item(1, 1)` 與 `$table->get_Item(2, 1)` 取用。表格格線現在有五個欄：原本位於第 2 與第 3 欄的儲存格分別移至第 3 與第 4 欄。列索引保持不變。拆分後存取儲存格時請使用這些更新後的欄索引。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **依列或欄跨距拆分合併儲存格**

為了在資料填入前準備合併的範本儲存格，可使用 [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) 沿現有列邊界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) 沿欄邊界拆分。

`index` 參數計算的是分割上方部分的列或左側部分的欄；它是相對於合併區域的：

- Row split: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Column split: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

此範例假設簡報的第一張投影片第一個圖形為表格，且 `(1, 2)` 與 `(1, 3)` 垂直合併。從較低的位置開始，它使用 [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) 與 [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) 來定位起點，並檢查兩個跨距。接著 `splitByRowSpan(1)` 將第 2、3 列分開以放置商品名稱。若為水平的兩欄合併，則改用 `splitByColSpan(1)`。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // 從表格中取得拆分後的儲存格。
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

表格格線和周圍儲存格的索引保持不變。可依座標取得產生的儲存格；此處兩個儲存格的跨距皆為 1，且 [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) 會回傳 `false`。較大的區域在一次拆分後仍可能保留部分合併。

原始文字與其格式保留在上方（或左側）儲存格中；新儲存格則為空白，但會繼承儲存格的格式，例如填色、邊框與邊距。拆分後填入資料，並明確設定任何必要的文字格式。

儲存的簡報中會有分別的「Product A」與「Product B」儲存格，且保留了範本的儲存格格式。請參考 [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) 取得詳細資訊。

## **變更表格儲存格背景顏色**

此範例建立一個欄寬 150 點、列高 50 點的表格。它使用 [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) 選取實心填色，並將 [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) 回傳的顏色設定為紅色，套用於第 3 欄第 4 列的儲存格 `(2, 3)`。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在表格儲存格內加入影像**

在執行此範例前，請將輸入影像放置於工作目錄中。程式使用 [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) 載入影像，並以 [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) 加入至簡報的影像集合。之後將該影像指派給儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填充。

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) 會將影像拉伸以填滿儲存格，可能會改變其長寬比。欄寬與列高皆以點為單位。載入的影像在加入簡報後於 `finally` 區塊中釋放。

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**我可以為單一儲存格的不同邊設定不同的線條粗細和樣式嗎？**

可以。[top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) 邊框皆有獨立的屬性，因此每一側的粗細與樣式可以不同。

**如果在將圖片設定為儲存格背景後，我變更欄或列的尺寸，影像會發生什麼情況？**

行為取決於 [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/)。使用 stretch 時，影像會調整以符合新儲存格；使用 tile 時，圖塊會重新計算。

**我可以為儲存格的全部內容指派超連結嗎？**

[Hyperlinks](/slides/zh-hant/php-java/manage-hyperlinks/) 會在儲存格文字框內的文字（portion）層級或整個表格/圖形層級設定。實際上，您可以將連結指派給文字的一部分或整個儲存格的文字。

**我可以在單一儲存格內設定不同的字型嗎？**

可以。儲存格的文字框支援具有獨立格式（字型族、樣式、大小與顏色）的 [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)（文字片段）。