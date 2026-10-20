---
title: 在 PPTX 中圖表調整大小的可行解決方案
type: docs
weight: 40
url: /zh-hant/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 圖表調整大小
- Excel 圖表
- OLE 物件
- 嵌入圖表
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "在使用 Aspose.Slides for PHP via Java 嵌入的 Excel OLE 物件時，修復 PPTX 中意外的圖表調整大小問題。設定固定圖表尺寸，以保持圖表與 OLE 框的大小一致。"
---
## **概觀**

使用 Aspose 元件在 PowerPoint 簡報中嵌入為 OLE 物件的 Excel 圖表，在第一次啟用後可能會改變大小。這會導致圖表在啟用前後的外觀產生明顯差異。本文說明產生調整大小的原因，並示範如何透過將固定圖表尺寸與 OLE 框匹配來避免此問題。

在[在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)，我們說明了如何使用 Aspose.Cells for PHP via Java 建立 Excel 圖表，並使用 Aspose.Slides for PHP via Java 將其嵌入 PowerPoint 簡報。為了解決[物件預覽問題](/slides/zh-hant/php-java/object-preview-issue-when-adding-oleobjectframe/)，我們將圖表影像指派給圖表的 OLE 物件框。

在輸出簡報中，當您雙擊顯示圖表影像的 OLE 物件框時，Excel 圖表會被啟用。使用者可以編輯嵌入的 Excel 活頁簿，然後透過點擊已啟用工作簿外部返回投影片。使用者返回投影片時，OLE 物件框的大小會變更，且調整比例會根據 OLE 物件框與嵌入的 Excel 活頁簿的原始尺寸而不同。

## **調整大小的原因**

嵌入的 Excel 活頁簿擁有自己的視窗尺寸，Excel 會嘗試在首次啟用物件時保留該尺寸。投影片上的 OLE 框則自行定義了尺寸。當 Excel 活頁簿被啟用時，Excel 與 PowerPoint 會協商物件的大小，以在嵌入過程中保持其比例。因此，活頁簿視窗與 OLE 框之間的差異可能導致物件重新調整大小。

## **可行的解決方案**

將圖表尺寸與投影片上的 OLE 框相匹配，且使圖表尺寸獨立於活頁簿視窗。此解決方案適用於新簡報或現有範本。

此範例需要 Aspose.Cells for PHP via Java 與 Aspose.Slides for PHP via Java。將兩個產品以相同的 PHP/Java Bridge 實例進行配置，載入兩個 PHP 包裝器，並使兩個 Java 程式庫可供 Bridge 使用。此範例不需要輸入檔案。它會在作用中的圖表工作表上建立簡單的柱狀圖，並以 XLS 格式嵌入活頁簿。未指派圖表預覽圖像；圖表會在 PowerPoint 中啟用 OLE 物件時顯示。

此範例建立一個新的簡報，使用 9.5 × 4 吋的 OLE 框，框位於左邊緣 0.5 吋、上方 1 吋處。投影片座標與尺寸以點 (每吋 72 點) 表示。若是現有簡報，請參閱[使用範本](#use-a-template)。

## **設定固定圖表大小**

將[Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow)設定為 false，使圖表尺寸與活頁簿視窗無關。透過[Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width)與[Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height)設定[Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject)的尺寸，並以每吋 96 像素將點轉換為像素：寬 684 × 288 點的框相當於寬 912 × 384 像素的圖表。將[Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize)設定為[PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/)的 CUSTOM 值。範例使用[ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame)嵌入活頁簿，並儲存一個帶有 9.5 × 4 吋 OLE 框的簡報。

Java 數值結果在用作 PHP 索引之前會透過 `java_values` 轉換。將活頁簿位元組傳遞給[OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/)時，仍保持在 Java 位元組陣列中。

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 投影片座標與尺寸以點為單位（每英吋 72 點）。
        $width = 684; // 9.5 吋。
        $height = 288; // 4 吋。

        $chart->setSizeWithWindow(false);
        // 使用每英吋 96 像素將點轉換為圖表像素。
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **使用範本**

對於現有簡報，尺寸邏輯相同。若要調整範例：

1. 載入範本簡報，而非建立空白簡報。
1. 檢查第一張投影片是否至少包含三個形狀，然後使用索引為 2 的形狀作為佔位符。
1. 從該形狀取得框的寬度與高度，而非使用固定值 684 與 288。保持尺寸計算不變。
1. 在佔位符的位置加入 OLE 框，而非使用固定座標 36 與 72。
1. 在儲存簡報前移除佔位符。

## **常見問題**

**為何嵌入的 Excel 圖表在 PowerPoint 中啟用後會改變大小？**

這是因為 Excel 在首次啟用時會嘗試還原原始視窗大小，而 PowerPoint 中的 OLE 物件框則有其自行的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，導致調整大小的情形。

**如何保持圖表與 OLE 框的尺寸一致？**

設定與 OLE 框相匹配的固定圖表尺寸，並在嵌入活頁簿前使用自訂的圖表列印大小。上述範例展示了所需的設定與單位換算。

**僅匹配活頁簿視窗大小是否足夠？**

僅匹配活頁簿視窗大小無法可靠地防止 OLE 框在啟用後改變尺寸。請使用如範例所示的固定圖表尺寸。

**此解決方案同時適用於基於範本的簡報與新簡報嗎？**

是的。對於範本，使用佔位符的尺寸與位置。對於新簡報，直接指定框的尺寸與位置。

**我能將此範例用於其他試算表程式建立的圖表嗎？**

此範例使用由 Aspose.Cells 建立的 Excel 活頁簿，未示範其他試算表程式的啟用行為。

## **相關章節**

- [在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)