---
title: 工作表尺寸調整的可行解決方案
type: docs
weight: 130
url: /zh-hant/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽影像
- 影像調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- C++
- Aspose.Slides for C++
description: "在 PowerPoint 簡報中使用 C++ 進行工作表調整大小的可行解決方案"
---
{{% alert color="info" %}}

已觀察到，透過 Aspose 元件將 Excel 工作表以 OLE 物件嵌入 PowerPoint 簡報時，首次啟用後會被重新調整為未知的比例。此行為會在 OLE 物件的啟用前後產生明顯的視覺差異。我們已深入調查此問題，並提供了解決方案，詳情請見本文。

{{% /alert %}}

## **背景**

在文章[管理 OLE](/slides/zh-hant/cpp/manage-ole/)中，我們說明了如何使用 Aspose.Slides for C++ 為 PowerPoint 簡報加入 OLE 框。為了解決[加入 OLE 物件框時的物件預覽問題](/slides/zh-hant/cpp/object-preview-issue-when-adding-oleobjectframe/)，我們將選取工作表區域的圖像指定給 OLE 物件框。於輸出簡報中，當您雙擊顯示工作表圖像的 OLE 物件框時，Excel 活頁簿會被啟動。最終使用者可以對實際的 Excel 活頁簿進行任意修改，然後點擊已啟動的 Excel 活頁簿之外的區域返回投影片。使用者返回投影片時，OLE 物件框的大小會改變。調整比例會因 OLE 物件框與嵌入的 Excel 活頁簿的大小而異。

## **調整大小的原因**

Excel 活頁簿本身具有視窗大小，首次啟用時會嘗試保留其原始尺寸。另一方面，OLE 物件框也有自己的大小。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中維持正確的比例。調整大小的發生是基於 Excel 視窗大小與 OLE 物件框的尺寸與位置之間的差異。

## **可行的解決方案**

有兩種可能的解決方案可避免此調整效果。

- 在 PowerPoint 簡報中將 OLE 框的尺寸調整至與 OLE 框內所需的行數與列數的高度與寬度相匹配。
- 讓 OLE 框尺寸保持不變，並將參與的行與列的大小縮放至符合選定的 OLE 框尺寸。

### **縮放 OLE 框尺寸**

在此方法中，我們將學習如何將嵌入的 Excel 活頁簿的 OLE 框尺寸設定為與 Excel 工作表中參與的行與列的累計尺寸相匹配。

假設我們有一個範本 Excel 工作表，想將其作為 OLE 框加入簡報。此情況下，OLE 物件框的尺寸將首先根據活頁簿中參與的行高與列寬的累計值計算。接著，我們會將 OLE 框的尺寸設定為該計算值。為了避免 PowerPoint 中 OLE 框顯示紅色「EMBEDDED OLE OBJECT」訊息，我們還會擷取工作表中所需行與列的圖像，並將其設定為 OLE 框的影像。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// 設定工作簿檔案作為 OLE 物件在 PowerPoint 中使用時的顯示尺寸。
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// 取得 OLE 圖像的寬度與高度（單位為點）。
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// 我們需要使用已修改的工作簿。
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// 將 OLE 圖像加入簡報資源。
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// 建立 OLE 物件框。
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"
using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **縮放儲存格範圍尺寸**

在此方法中，我們將學習如何將參與的行高與列寬縮放至符合自訂的 OLE 框尺寸。

假設我們有一個範本 Excel 工作表，想將其作為 OLE 框加入簡報。此情況下，我們會先設定 OLE 框的尺寸，並將參與 OLE 框區域的行與列的大小縮放至符合該尺寸。然後，我們會將活頁簿儲存至串流以套用變更，並轉換為位元組陣列以加入 OLE 框。為了避免 PowerPoint 中 OLE 框顯示紅色「EMBEDDED OLE OBJECT」訊息，我們還會擷取工作表中所需行與列的圖像，並將其設定為 OLE 框的影像。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// 設定工作簿檔案作為 OLE 物件在 PowerPoint 中使用時的顯示尺寸。
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// 將儲存格範圍縮放以符合框架大小。
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// 我們需要使用已修改的工作簿。
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// 將 OLE 圖像加入簡報資源。
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// 建立 OLE 物件框。
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">儲存格範圍預期的寬度（單位：點）。</param>
/// <param name="height">儲存格範圍預期的高度（單位：點）。</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"
using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **結論**

{{% alert color="info" %}}

有兩種方法可解決工作表調整大小的問題。選擇哪種方法取決於具體需求與使用情境。無論是從範本還是從頭建立簡報，兩種方法皆可同樣運作。此外，此解決方案對 OLE 物件框的大小沒有限制。

{{% /alert %}}

## **常見問題**

### 為什麼嵌入的 Excel 工作表在 PowerPoint 中首次啟用時會改變大小？

這是因為 Excel 在啟用時會嘗試保留原始視窗大小，而 PowerPoint 中的 OLE 物件框自有尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，導致調整大小。

### 是否可以完全防止此調整問題？

可以。透過將 OLE 框縮放以符合 Excel 儲存格範圍尺寸，或將儲存格範圍縮放以符合所需的 OLE 框尺寸，皆可避免不必要的調整。

### 我應該使用哪種縮放方式，OLE 框縮放或儲存格範圍縮放？

若希望保留原始 Excel 行列大小，請選擇 **OLE 框縮放**。若希望在簡報中固定 OLE 框的大小，請選擇 **儲存格範圍縮放**。

### 這些解決方案在以範本為基礎的簡報中也有效嗎？

有效。兩種解決方案皆適用於從範本建立的簡報以及從頭開始建立的簡報。

### 使用這些方法時，OLE 框的大小是否有限制？

沒有。只要適當設定縮放比例，即可將 OLE 物件框調整為任意大小。

### 是否有方法避免 PowerPoint 中的「EMBEDDED OLE OBJECT」佔位文字？

有。將目標 Excel 儲存格範圍的快照擷取下來，並設定為 OLE 框的佔位圖像，即可在預設佔位文字位置顯示自訂預覽圖。

## **相關文章**

[在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)