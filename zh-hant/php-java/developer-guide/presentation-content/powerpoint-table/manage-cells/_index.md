---
title: 使用 PHP 管理簡報中的表格儲存格
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
description: "使用 PHP 管理 PowerPoint 表格儲存格：識別合併儲存格、移除邊框、拆分儲存格，並使用 Aspose.Slides for PHP via Java 設定背景顏色與影像。"
---
## **概覽**

Aspose.Slides 允許您在 PowerPoint 簡報中存取和修改表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景顏色，以及在表格儲存格內加入影像。範例展示如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報另存為 PPTX 檔案。  
Aspose.Slides 使用零基索引，以 `(column, row)` 的順序存取表格儲存格。

## **識別合併的表格儲存格**

此範例開啟現有簡報，並將第一張投影片上的第一個圖案當作表格存取。它假設投影片與圖案皆存在且該圖案為表格。接著遍歷所有列與欄，並使用 [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) 來識別位於合併區域的儲存格。對每個符合的儲存格，會以 `row;column` 的順序列印儲存格座標、[getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)、[getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/)，以及該區域的起始座標 [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) 和 [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/)。

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

建立一個 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 並使用 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) 在其第一張投影片上加入表格。欄寬、列高以及表格位置均以點 (point) 為單位指定。此範例將四條儲存格邊框皆設定為 [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)，使其不可見。

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

## **加入對角線儲存格邊框**

使用 [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) 在左上角至右下角繪製線條，並使用 [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) 在左下角至右上角繪製線條。對角線可用於標示角落標題；兩條對角線一起可形成 X，將儲存格標示為不適用。  
每條對角線都有其自己的 [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/)。在其 [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) 中，使用 [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) 來選取 [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 並透過 [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) 取得顏色。使用 [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) 設定線條寬度（以點為單位）。  
此範例在同一列建立三個儲存格：紅色向下的對角線、藍色向上的對角線，以及兩條對角線同時存在。它保留上、下、左、右四側邊框不變。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

對角線僅會變更儲存格格式。每個儲存格保留單一文字框，可透過 [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) 存取。對角線兩側的區域無法獨立編輯。  

已儲存的表格，於 Microsoft PowerPoint 中呈現：

![三個表格儲存格顯示左上至右下的紅色對角線、左下至右上的藍色對角線，以及兩條對角線形成 X。](diagonal-cell-borders.png)

*從左至右：向下對角線（紅色，3 pt）、向上對角線（藍色，5 pt）以及兩條對角線。*

## **合併表格儲存格**

使用 [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) 將矩形範圍的表格儲存格合併為單一儲存格。指定範圍左上角與右下角的儲存格。最後一個參數控制合併是否可包含範圍外的儲存格；`false` 會將合併限制在該範圍內。  
此範例建立一個 4x4 的表格，欄寬與列高皆為 70 點，然後合併位於 `(1, 1)` 至 `(2, 2)` 的四個中心儲存格。合併後的儲存格跨兩個欄位與兩列，而表格的底層格線仍保留四欄四列。若要存取合併儲存格的內容或格式，請使用其左上位置：本例中為 `$table->get_Item(1, 1)`。合併範圍內的其他位置仍屬於表格格線，因此範圍外儲存格的索引不會改變。

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

在前一個範例中合併儲存格會保留表格的格線。拆分儲存格可能會新增一個格線欄位，並變更其右側儲存格的欄位索引。Aspose.Slides 遵循 PowerPoint 的表格格線模型。  
此範例建立一個 4x4 的表格，欄寬與列高皆為 70 點，並對儲存格 `(1, 1)` 呼叫 [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/)。將該儲存格 70 點寬度的一半傳入，以建立兩個等寬的儲存格。  
拆分後，兩個半部可分別以 `$table->get_Item(1, 1)` 與 `$table->get_Item(2, 1)` 取得。表格格線現在有五個欄位：原本位於第 2 與第 3 欄的儲存格分別移至第 3 與第 4 欄。列索引保持不變。拆分後存取儲存格時，請使用這些更新後的欄位索引。

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

<!-- visual-explanation:manage-cells:start -->
[![未合併的 70 點儲存格被拆分為兩個 35 點儲存格，新增第五個格線欄位，且將右側的索引向右移動。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*寬度拆分影響儲存格 (1, 1)，使用零基 (column, row) 索引。其他列保留跨越兩個新欄位位置的儲存格。*
<!-- visual-explanation:manage-cells:end -->

### **依列或欄跨距拆分合併儲存格**

若要為資料填入準備合併的範本儲存格，可使用 [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) 沿現有的列邊界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) 沿欄位邊界拆分。  
`index` 參數計算拆分上部的列數或左側的欄數；它是相對於合併區域的：

- 列拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)。
- 欄拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/)。

此範例假設簡報的第一張投影片第一個圖案為表格，且 `(1, 2)` 與 `(1, 3)` 兩儲存格垂直合併。從較低的位置開始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) 與 [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) 取得起始點，並檢查兩個跨距。`splitByRowSpan(1)` 會將第 2 與第 3 列分開，以放置產品名稱。若為水平的雙欄合併，則使用 `splitByColSpan(1)`。

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

        // 從分割後的表格中取得產生的儲存格。
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

表格格線與其周圍的儲存格索引保持不變。可依座標取得結果儲存格；此處兩者的跨距皆為 1，且 [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) 會回傳 `false`。較大的區域在一次拆分後仍可保留部分合併狀態。  
原始文字及其格式保留在上方（或左側）儲存格；新儲存格為空，但會繼承儲存格格式，例如填色、邊框與邊距。拆分後再填入資料，並明確設定任何所需的文字格式。  
已儲存的簡報包含分開的「Product A」與「Product B」儲存格，且保留了範本的儲存格格式。詳情請參閱 [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)。

### **依特定高度拆分儲存格**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) 以點為單位取得上部的高度。 [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) 則以列數取得上部現有格線的列數。若要將 40 點的儲存格置於右側欄位的中心，先從儲存格實際高度減去 40 點，然後將剩餘空間平均分配於上方與下方。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

第一次拆分會新增一列格線，留下儲存格 `(1, 1)` 的下部 90 點。第二次拆分將該儲存格分為 40 點的中間儲存格與 50 點的底部儲存格。右側欄位現在由三個儲存格組成，從上至下的高度分別為 50、40、50 點。左側儲存格跨越所有三列，且保留原始的 140 點高度。

![左側儲存格跨越整個表格高度，旁邊有三個儲存格，中間為 Middle。](split-by-height.png)

## **變更表格儲存格背景顏色**

此範例建立一個欄寬 150 點、列高 50 點的表格。它使用 [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) 選取實心填色，並將 [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) 回傳的顏色設定為紅色，套用於儲存格 `(2, 3)`（第 3 欄第 4 列）。

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

在執行此範例前，請將輸入影像放置於工作目錄中。程式使用 [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) 載入影像，並以 [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) 加入簡報的影像集合。接著把影像指派給儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填色。  
[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) 會拉伸影像以填滿儲存格，可能會改變其長寬比。欄寬與列高以點為單位。載入的影像在加入簡報後於 `finally` 區塊中釋放。

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

**是否可以為單一儲存格的不同側設定不同的線條粗細與樣式？**  
是的。[top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) 邊框各有獨立屬性，因此每一側的粗細與樣式皆可不同。

**如果在將圖片設定為儲存格背景後，變更欄位/列的大小，影像會如何變化？**  
行為取決於 [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/)（stretch/tile）。使用 stretch 時，影像會依新儲存格調整；使用 tile 時，圖塊會重新計算。

**是否可以為儲存格的全部內容指派超連結？**  
[Hyperlinks](/slides/zh-hant/php-java/manage-hyperlinks/) 會在儲存格文字框（段落）層級或整個表格/圖形層級設定。實務上，您會將連結指派給文字的某個段落或整個儲存格內的所有文字。

**是否可以在單一儲存格內設定不同的字型？**  
是的。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)（文字段落），可對每段文字設定獨立的格式——包括字型族、樣式、大小與顏色。