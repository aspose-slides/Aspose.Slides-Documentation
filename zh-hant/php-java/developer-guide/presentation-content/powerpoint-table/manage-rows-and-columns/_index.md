---
title: 使用 PHP 管理 PowerPoint 表格中的列與欄
linktitle: 列與欄
type: docs
weight: 20
url: /zh-hant/php-java/manage-rows-and-columns/
keywords:
- 表格列
- 表格欄
- 首列
- 表格標題列
- 複製列
- 複製欄
- 拷貝列
- 拷貝欄
- 移除列
- 移除欄
- 列文字格式
- 欄文字格式
- 表格樣式
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 中管理表格列與欄，並加速簡報編輯與資料更新。"
---
## **簡介**

Aspose.Slides for PHP via Java 讓您透過 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 類別在 PowerPoint 簡報中管理表格結構與格式。您可以指定標題列、複製或移除列與欄，並對整個列或欄套用文字格式。

本篇說明如何使用 PHP 範例執行這些操作。也示範如何取得表格的樣式預設，以便在其他表格重複使用。表格列與欄的索引從 0 開始。

## **控制列高度**

使用 [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) 以點為單位設定列的最小高度。這只是下限，並非固定高度。[Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) 會回傳實際高度。可透過 [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/) 取得列物件。

範例載入 [row-height-input.pptx](row-height-input.pptx)，該簡報在第一張投影片的第一個圖形中有一個表格。其第一列起始高度為 70 點。儲存格使用 18 點 Arial 文字、換行，且上下邊距為 6 點；第二欄較長的文字會換成多行。範例將最小高度提升至 100 點，然後降低至 20 點，並在每次變更後列印實際高度，最後將兩個結果儲存。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

使用提供的簡報時，提升最小高度會在列中增加空間。降低最小高度會移除這些額外空間，但實際高度仍大於 20 點，因為文字與儲存格邊距需要更多空間。僅降低最小高度無法將列的高度壓低於內容所需的空間。

影響實際高度的因素包括：

- **文字與字型大小**：較長的文字、明確的換行或較大的字型會需要更多垂直空間。  
- **換行與欄寬**：開啟換行時，使用 [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) 縮小欄寬會產生更多行。較寬的欄位則可降低垂直需求。  
- **儲存格邊距**： [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) 與 [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) 會增加垂直空間。 [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) 與 [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) 會減少文字可用寬度，可能導致額外換行。

對於此不含合併儲存格的表格而言，需要最多垂直空間的儲存格會決定整列的內容驅動下限。若要讓列變短，可能也需要縮短文字、減小字型或邊距，或是擴寬欄位。

下方圖片顯示相同表格在相同比例下的結果。實際高度分別為 70、100 與 55.2 點：最後一列仍高於 20 點的最小值。文字測量會因環境中可用字型而異。下載儲存結果：[increased minimum](row-height-increased.pptx) 與 [decreased minimum](row-height-decreased.pptx)。

| 原始：最小 70 pt，實際 70 pt | 增加：最小 100 pt，實際 100 pt | 減少：最小 20 pt，實際 55.2 pt |
| --- | --- | --- |
| ![原始表格，第一列高度為 70 點。](row-height-before.png) | ![將第一列最小高度提升至 100 點後的表格。](row-height-increased.png) | ![將第一列最小高度降低至 20 點後的表格；換行文字使列仍高於最小值。](row-height-decreased.png) |

## **將第一列設定為標題列**

使用 [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) 方法將第一列標記為標題格式。其外觀取決於套用於表格的樣式。

1. 使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別載入簡報。  
2. 取得第一張投影片。  
3. 取得投影片上第一個圖形所儲存的表格。  
4. 為其第一列啟用標題格式。  
5. 儲存修改後的簡報。

此範例需要 `table.pptx`（第一張投影片的第一個圖形為表格），它會為第一列啟用標題格式，並儲存為 `First_row_header.pptx`。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **複製表格列或欄**

複製列或欄以重複使用其內容與格式。您可以將副本附加至表格尾端，或插入至特定位置。

1. 使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別載入簡報。  
2. 取得第一張投影片。  
3. 定義欄寬與列高。  
4. 使用 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) 方法新增表格。  
5. 複製所需的列。  
6. 複製所需的欄。  
7. 儲存修改後的簡報。

此範例需要 `Test.pptx`（至少包含一張投影片）。它建立一個三欄五列的表格，尺寸以點為單位。範例會在表格末端加入第一列與第一欄的副本，然後在索引 3（第四個位置）插入第二列與第二欄的副本。最終表格變為七列五欄。`false` 參數會停用對相鄰合併列或欄的複製；此表格沒有合併儲存格。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **從表格移除列或欄**

移除表格中不再需要的列或欄。移除項目會使其後面的列或欄的索引向前移動。

1. 使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別建立簡報。  
2. 取得第一張投影片。  
3. 定義欄寬與列高。  
4. 使用 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) 方法新增表格。  
5. 移除第二列與第二欄。  
6. 儲存修改後的簡報。

此範例會建立一個 3×3 的表格，然後移除索引為 1 的列與欄，留下 2×2 的表格，結果儲存為 `TestTable_out.pptx`。尺寸以點為單位。`false` 參數會停用對相鄰合併列或欄的移除；此表格沒有合併儲存格。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在表格列層級設定文字格式**

對整列套用文字格式，可讓其儲存格保持一致。您可以設定字型屬性、段落格式與文字方向，而無需逐一調整每個儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別載入簡報。  
2. 取得第一張投影片上的表格。  
3. 使用 [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) 為第一列設定字型高度。  
4. 使用 [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) 與 [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) 為第一列設定對齊與右側段落邊距。  
5. 使用 [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) 為第二列設定垂直文字。  
6. 儲存修改後的簡報。

此範例需要 `table.pptx`（第一張投影片的第一個圖形為表格，且至少有兩列）。它會將第一列的文字高度設為 25 點、右對齊，並設定 20 點的右段落邊距，接著將第二列的文字方向改為垂直。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在表格欄層級設定文字格式**

對整欄套用文字格式，可讓其儲存格保持一致。您可以設定字型屬性、段落格式與文字方向，而無需逐一調整每個儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別載入簡報。  
2. 取得第一張投影片上的表格。  
3. 使用 [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) 為第一欄設定字型高度。  
4. 使用 [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) 與 [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) 為第一欄設定對齊與右側段落邊距。  
5. 使用 [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) 為第二欄設定垂直文字。  
6. 儲存修改後的簡報。

此範例需要 `table.pptx`（第一張投影片的第一個圖形為表格，且至少有兩欄）。它會將第一欄的文字高度設為 25 點、右對齊，並設定 20 點的右段落邊距，接著將第二欄的文字方向改為垂直。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **取得表格樣式屬性**

使用 [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) 方法取得套用於表格的樣式預設，並可在其他表格上重新使用。此方法會返回樣式預設本身，而非個別儲存格的格式覆寫。

範例會建立一個表格，套用 [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1)，然後讀回該預設。它會列印對應於 `DarkStyle1` 的整數值，並將表格儲存為 `table.pptx`。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**我可以對已建立的表格套用 PowerPoint 主題/樣式嗎？**

可以。表格會繼承投影片/版面/母片的主題，同時您仍可在此基礎上覆寫填色、邊框與文字顏色。

**我能像 Excel 那樣對表格列進行排序嗎？**

不能，Aspose.Slides 的表格沒有內建的排序或篩選功能。請先在記憶體中排序資料，然後依排序後的順序重新填入表格列。

**我可以在保持特定儲存格自訂顏色的同時，使用條紋（banded）欄位嗎？**

可以。啟用條紋欄位後，仍可對個別儲存格套用局部格式；儲存格層級的格式會優先於表格樣式。