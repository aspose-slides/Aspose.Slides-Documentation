---
title: 使用 PHP 自訂簡報中的圖表資料表格
linktitle: 資料表格
type: docs
url: /zh-hant/php-java/chart-data-table/
keywords:
- 圖表資料
- 資料表格
- 字型屬性
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 於 PowerPoint 簡報中自訂圖表資料表格的字型、邊框與圖例鍵。"
---
## **概觀**

Aspose.Slides for PHP via Java 讓您能顯示圖表的資料表格，並自訂文字格式、邊框與圖例鍵。本文章說明如何啟用表格、格式化文字、控制各種邊框，以及顯示或隱藏圖例鍵。範例會將設定好的圖表儲存為 PPTX 檔案。

## **設定字型屬性**

若要顯示圖表的資料表格，請將 `true` 傳遞給 [setDataTable](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/setdatatable/)。使用 [getChartDataTable](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/getchartdatatable/) 取得表格，並設定文字格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別載入簡報。
1. 在第一張投影片新增叢集柱狀圖。
1. 啟用圖表的資料表格。
1. 使用 [setFontBold](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setFontBold) 使文字加粗，並將 `20` 傳遞給 [setFontHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setFontHeight) 以設定 20 點字型。
1. 儲存已修改的簡報。

以下範例需要工作目錄中有 `test.pptx` 並至少包含一張投影片。它會在位置 (50, 50) 加入一個預設資料的圖表，寬度 600 點，高度 400 點。儲存的 `output.pptx` 會包含已啟用資料表格且套用指定字型設定的圖表。

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **自訂資料表格邊框**

使用 [Chart::setDataTable](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/setdatatable/) 啟用表格，並透過 [Chart::getChartDataTable](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/getchartdatatable/) 取得。您可以獨立控制三種邊框：

- [setBorderHorizontal](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/datatable/setborderhorizontal/) 控制水平儲存格邊框。
- [setBorderVertical](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/datatable/setbordervertical/) 控制垂直儲存格邊框。
- [setBorderOutline](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/datatable/setborderoutline/) 控制表格的外部邊框。

將 `true` 傳遞給每個方法即可顯示其邊框，傳遞 `false` 則隱藏。以下範例建立一個預設資料的叢集柱狀圖，顯示水平邊框與外部邊框，隱藏垂直邊框。此範例不需要輸入檔案，圖表的位置與大小以點為單位指定。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

下表比較了四種情況下相同的圖表資料與圖例鍵設定。從全部邊框啟用開始，每個變體僅關閉一種邊框。左下角的變體與範例的邊框設定相同。

![圖表資料表格：全部邊框啟用、無水平邊框、無垂直邊框、無外部邊框](data-table-borders.png)

## **顯示或隱藏圖例鍵**

圖例鍵是位於資料表格中系列名稱旁的小彩色標記，可協助讀者將每一行對應到圖表系列。將 `true` 傳遞給 [setShowLegendKey](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/datatable/setshowlegendkey/) 以顯示這些標記，傳遞 `false` 則隱藏。

圖表的獨立圖例由 [Chart::setLegend](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/setlegend/) 控制。這兩套設定彼此獨立：隱藏獨立圖例不會隱藏資料表格內的鍵，隱藏表格鍵亦不會隱藏獨立圖例。

以下範例建立一個預設資料的圖表，啟用資料表格並在表格內顯示圖例鍵，同時隱藏獨立圖例。所有表格邊框皆明確啟用。此範例不需要輸入簡報。若僅想隱藏表格的鍵，將 `false` 傳遞給 [setShowLegendKey](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/datatable/setshowlegendkey/)。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

下圖比較了相同表格在圖例鍵顯示與隱藏兩種狀態。所有邊框仍保持啟用，且兩種情況下獨立圖例皆被隱藏。

![圖表資料表格：左側顯示圖例鍵，右側隱藏圖例鍵](data-table-legend-keys.png)

## **FAQ**

**我可以在圖表的資料表格中顯示圖例鍵嗎？**

可以。將 `true` 傳遞給 [setShowLegendKey](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/datatable/setshowlegendkey/) 以顯示圖例鍵，傳遞 `false` 則隱藏。

**在將簡報匯出為 PDF、HTML 或影像時，資料表格會被保留下來嗎？**

會。Aspose.Slides 在匯出至 [PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)、[HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/) 或 [images](/slides/zh-hant/php-java/convert-powerpoint-to-png/) 時，會將圖表及其顯示的資料表格作為投影片的一部份渲染。

**我可以在從範本載入的圖表中使用資料表格嗎？**

可以。對於從既有簡報或範本載入的圖表，使用 [hasDataTable](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/hasdatatable/) 和 [setDataTable](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/setdatatable/) 來檢查或變更是否顯示資料表格。

**我要如何找出已啟用資料表格的圖表？**

遍歷每張投影片上的所有圖形，識別圖表，並呼叫其 [hasDataTable](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/hasdatatable/) 方法。返回值為 `true` 時，即表示該圖表的資料表格已啟用。