---
title: 建立 Excel 圖表並將其作為 OLE 物件嵌入簡報
type: docs
weight: 30
url: /zh-hant/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 圖表
- 嵌入圖表
- OLE 物件
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Cells for PHP via Java 建立 Excel 圖表，並使用 Aspose.Slides for PHP via Java 將活頁簿嵌入 PowerPoint 簡報，包含圖表預覽。"
---
## **概觀**

本文說明如何使用 Aspose.Cells for PHP via Java 建立 Excel 長條圖，並將其活頁簿嵌入至使用 Aspose.Slides for PHP via Java 的 PowerPoint 簡報中。嵌入的活頁簿同時包含來源資料與圖表。單獨的 PNG 預覽會在 OLE 物件啟動前於投影片上顯示圖表。

結果是一個嵌入的 Excel 物件，而非原生的 PowerPoint 圖表。透過 OLE 編輯活頁簿需要支援 OLE 啟動且安裝相容 Excel 的桌面應用程式。

## **先決條件**

使用相同的 PHP/Java Bridge 實例設定 Aspose.Cells for PHP via Java 與 Aspose.Slides for PHP via Java。載入兩個 PHP 包裝器，並讓兩個產品的 Java 程式庫可供 Bridge 存取。使用這些程式庫產生簡報不需要安裝 Microsoft Office。

不需要任何輸入檔案：範例在記憶體中建立資料與圖表，然後將 `OutputChart.pptx` 寫入目前工作目錄。於非評估模式執行時，請為兩個產品套用授權。

## **嵌入工作方式**

1. 建立包含資料工作表與圖表工作表的活頁簿。  
2. 將圖表工作表設為作用中，使活頁簿開啟時直接顯示圖表。  
3. 設定活頁簿的 OLE 顯示範圍並將圖表渲染為 PNG。  
4. 以 XLSX 格式將活頁簿儲存於記憶體，並將其位元組嵌入投影片。  
5. 將 PNG 設為 OLE 物件的預覽，最後將簡報儲存為 PPTX。

活頁簿顯示範圍與投影片框的作用不同。[WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) 需要零基礎的起始/結束列與欄索引。[ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) 則使用頂端列、左側欄、底端列與右側欄。範例使用第 55 行與第 25 欄作為右下邊界；這些值屬於版面配置選擇，而非資料列或欄的數量。

投影片框使用點作為單位。範例將其置於投影片內部並置中，同時保留 PNG 的長寬比例，而不是將預覽圖拉伸至填滿投影片。

## **建立並嵌入圖表**

以下完整範例會在 `DataSheet` 中填入四列五欄的數值。每一列會成為圖表中的一個序列。在儲存活頁簿之前，會將 `ChartSheet` 設為作用中的工作表。

活頁簿明確以 XLSX 格式儲存，符合傳遞給 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) 的 `xlsx` 副檔名。Java 數值結果在 PHP 執行算術運算前會先以 `java_values` 轉換，而二進位資料則保留在 Java 位元組陣列中。PNG 直接從位元組載入，無需中介位圖轉換。透過 [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 指定後，會取代預設的 OLE 佔位圖。

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // 在將 PNG 和 XLSX 傳遞給 Slides 時，保留為 Java 位元組陣列。
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // 在保持長寬比例的同時，調整並置中預覽圖。
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **預期結果**

`OutputChart.pptx` 內含一張投影片，嵌入 Excel 活頁簿並顯示圖表預覽。活頁簿保留原始資料與包含四個序列的長條圖。預覽圖置中於投影片且保持其比例。

![Excel 長條圖作為嵌入活頁簿的預覽顯示](excel-chart-ole-preview.png)

在具備 Excel 的相容桌面 PowerPoint 環境中，雙擊物件即可啟動並編輯嵌入的活頁簿。啟動與編輯取決於主機應用程式的 OLE 支援與安全性設定。

## **常見問題**

**為什麼需要預覽圖片？**  
嵌入的活頁簿與投影片的預覽是分開的內容。提供圖表圖像可讓投影片顯示圖表本身，而非預設的「EMBEDDED OLE OBJECT」佔位圖。請參閱[加入 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/php-java/object-preview-issue-when-adding-oleobjectframe/)。

**當我在程式碼中更改活頁簿時，預覽會自動更新嗎？**  
將預覽視為快照。若以程式方式更新活頁簿資料，需要重新產生圖表圖像，並同時取代預覽與嵌入的活頁簿資料。

**我可以使用 XLS 而非 XLSX 嗎？**  
可以。將活頁簿儲存為 XLS 格式，並使用 `xls` 作為嵌入資料的副檔名。副檔名必須與實際的活頁簿格式相符，僅更改副檔名不會轉換資料。

**為什麼物件在啟動後會改變大小？**  
主機應用程式在啟動活頁簿時可能會更新 OLE 物件的顯示方式。活頁簿的 OLE 顯示範圍與投影片框的尺寸皆會影響結果。請參閱[ PPTX 中圖表調整大小的可行解決方案](/slides/zh-hant/java/working-solution-for-chart-resizing-in-pptx/)。

## **相關章節**

- [PPTX 中圖表調整大小的可行解決方案](/slides/zh-hant/java/working-solution-for-chart-resizing-in-pptx/)
- [加入 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [管理 OLE 物件](/slides/zh-hant/php-java/manage-ole/)