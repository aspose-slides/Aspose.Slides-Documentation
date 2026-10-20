---
title: 工作表大小調整的可行解決方案
type: docs
weight: 20
url: /zh-hant/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽圖像
- 影像調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "在簡報中修正 Excel 工作表 OLE 大小調整問題：提供兩種方法在 PPT 與 PPTX 格式中保持物件框一致——縮放框架或縮放工作表——。"
---
{{% alert color="info" title="Note" %}}
使用 Aspose 元件在 PowerPoint 簡報中嵌入為 OLE 物件的 Excel 工作表，可能會在首次啟動後意外調整大小。此行為會在 OLE 物件啟動前後產生明顯的視覺差異。本文章說明此問題並描述兩種解決方式。
{{% /alert %}}

## **背景**

在文章[管理 OLE](/slides/zh-hant/php-java/manage-ole/)中，我們說明了如何使用 Aspose.Slides for PHP via Java 將 OLE 框新增至 PowerPoint 簡報。為了解決[物件預覽問題](/slides/zh-hant/php-java/object-preview-issue-when-adding-oleobjectframe/)，我們將選取工作表區域的影像指派給 OLE 物件框。在輸出簡報中，當您雙擊顯示工作表圖像的 OLE 物件框時，Excel 活頁簿會被啟動。最終使用者可以對實際的 Excel 活頁簿進行任何所需的變更，然後點擊已啟動的 Excel 活頁簿外部返回投影片。使用者返回投影片時，OLE 物件框的大小會改變。調整大小的比例會因 OLE 物件框與嵌入的 Excel 活頁簿的尺寸而異。

## **調整大小的原因**

由於 Excel 活頁簿有自己的視窗大小，它會在首次啟動時嘗試保持原始尺寸。另一方面，OLE 物件框也有自己的尺寸。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中保持正確的比例。調整大小是根據 Excel 視窗大小與 OLE 物件框的尺寸和位置之差異而產生的。

## **可行的解決方案**

有兩種可行的解決方案可避免此調整大小的效果。

- 將 PowerPoint 簡報中的 OLE 框縮放，使其符合所選列與欄的總高度與寬度。
- 保持 OLE 框尺寸不變，並將所選列與欄縮放至適合於該框內。

### **縮放 OLE 框尺寸**

此方法將 OLE 框尺寸設定為符合嵌入式 Excel 工作表中所選列與欄的總高度與寬度。

此範例載入現有的 Excel 活頁簿，並使用零基索引選取其第一個工作表的前 10 列和 13 欄。[WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) 定義了顯示的範圍。預覽以 96 DPI 呈現，其像素尺寸使用每英吋 72 點轉換為點數。[ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) 將修改過的活頁簿以該尺寸嵌入框中。預覽透過 [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 指派，以取代已儲存簡報中的 "EMBEDDED OLE OBJECT" 佔位符。

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // 嵌入已修改的工作簿，並將二進位資料保留在 Java byte 陣列中。
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

預覽輔助程式將 [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) 設為選取的範圍，並移除邊距、頁首與頁尾。啟用 [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) 後，[SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) 會將範圍渲染為 PNG 影像。輔助程式回傳包含 PNG 影像的新輸入串流，並將位置設定在開頭，以供簡報使用。

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **縮放儲存格範圍尺寸**

此方法將選取列的高度與選取欄的寬度縮放，以符合自訂的 OLE 框尺寸。

此範例載入現有的 Excel 活頁簿，並使用零基索引選取其第一個工作表的前 10 列與 13 欄。[WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) 定義顯示的範圍，下方的輔助程式將該範圍縮放至適合寬度 400 點、高度 100 點的框。將修改過的活頁簿儲存至串流後，[ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) 以指定尺寸將其嵌入。以 96 DPI 呈現的預覽透過 [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 指派，使已儲存的簡報顯示選取的儲存格，而非預設的佔位符。

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // 嵌入已修改的工作簿，並將二進位資料保留在 Java byte 陣列中。
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

縮放輔助程式為選取的範圍計算分別的寬度與高度比例，保留其欄的相對寬度與列的相對高度。它在使用 [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) 與 [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch) 套用之前，先將計算得到的尺寸從點數轉換為英吋。選取的範圍寬度與高度必須皆非零。

```php
use aspose\cells\CellsUnitType;

// 寬度和高度是以點為單位的儲存格範圍的預期尺寸。
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

此預覽輔助程式使用 [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) 來渲染已調整大小的範圍。它將 [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) 限定為該範圍，移除邊距、頁首與頁尾，並回傳位於開頭的 PNG 串流。

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **結論**

{{% alert color="info" title="Note" %}}
有兩種方法可解決工作表調整大小的問題。請選擇最符合您需求與使用情境的方法。兩種方法的運作方式相同，無論簡報是從範本還是從頭建立。此外，此解決方案對 OLE 物件框的大小沒有任何限制。
{{% /alert %}}

## **常見問題**

**為何嵌入的 Excel 工作表在 PowerPoint 中首次啟動時會改變大小？**  
這是因為 Excel 在啟動時會嘗試保持原始視窗大小，而 PowerPoint 中的 OLE 物件框則有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而導致調整大小。

**是否可以徹底防止此調整大小問題？**  
是的。透過將 OLE 框縮放至符合 Excel 儲存格範圍的尺寸，或將儲存格範圍縮放至符合所需的 OLE 框尺寸，即可避免不必要的調整大小。

**我該使用哪種縮放方法，OLE 框縮放還是儲存格範圍縮放？**  
若您希望保留原始的 Excel 列與欄大小，請選擇 **OLE 框縮放**。若您希望在簡報中將 OLE 框固定為特定大小，請選擇 **儲存格範圍縮放**。

**如果我的簡報是基於範本，這些解決方案仍然適用嗎？**  
是的。兩種解決方案皆適用於從範本或從零建立的簡報。

**使用這些方法時，OLE 框的大小有上限嗎？**  
沒有。只要適當設定縮放比例，OLE 物件框的大小皆可任意調整。

**有沒有方法在 PowerPoint 中避免顯示 "EMBEDDED OLE OBJECT" 佔位文字？**  
有的。透過擷取目標 Excel 儲存格範圍的快照，並將其設為 OLE 框的佔位圖像，即可在預設佔位符之處顯示自訂的預覽圖像。

## **相關文章**

[在簡報中建立 Excel 圖表並以 OLE 物件嵌入](/slides/zh-hant/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 外掛程式自動更新 OLE 物件](/slides/zh-hant/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)