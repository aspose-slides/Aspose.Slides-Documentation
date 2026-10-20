---
title: 工作表調整大小的可行解決方案
type: docs
weight: 130
url: /zh-hant/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽圖像
- 圖像調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- C++
- Aspose.Slides for C++
description: "使用 C++ 在 PowerPoint 簡報中調整工作表大小的可行解決方案"
---
{{% alert color="info" title="Note" %}}
使用 Aspose 元件在 PowerPoint 簡報中嵌入作為 OLE 物件的 Excel 工作表，可能在首次啟用後意外調整大小。此行為會在 OLE 物件啟用前後產生明顯的視覺差異。本文說明此問題並描述兩種解決方式。
{{% /alert %}}

## **背景**

在文章[管理 OLE](/slides/zh-hant/cpp/manage-ole/)中，我們說明了如何使用 Aspose.Slides for C++ 為 PowerPoint 簡報加入 OLE 框。為了解決[物件預覽問題](/slides/zh-hant/cpp/object-preview-issue-when-adding-oleobjectframe/)，我們將所選工作表區域的圖像指定給 OLE 物件框。在輸出簡報中，當您雙擊顯示工作表圖像的 OLE 物件框時，Excel 活頁簿會被啟用。最終使用者可以對實際的 Excel 活頁簿進行任何所需的變更，然後點擊已啟用的 Excel 活頁簿外部返回投影片。使用者返回投影片時，OLE 物件框的大小會發生變化。調整大小的因素會因 OLE 物件框與嵌入的 Excel 活頁簿的大小而異。

## **調整大小的原因**

由於 Excel 活頁簿有其自身的視窗大小，它會在首次啟用時嘗試保留原始大小。另一方面，OLE 物件框也有自己的尺寸。根據 Microsoft 的說法，當 Excel 活頁簿被啟用時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中保持正確的比例。調整大小是根據 Excel 視窗大小與 OLE 物件框的尺寸和位置之差異而發生的。

## **可行的解決方案**

有兩種可能的解決方案可避免此調整大小效果。

- 在 PowerPoint 簡報中縮放 OLE 框，使其匹配所選列與欄的總高度與寬度。
- 保持 OLE 框尺寸不變，並縮放所選列與欄以適應其內部。

### **縮放 OLE 框大小**

此方法將 OLE 框的大小設定為與嵌入的 Excel 工作表中所選列與欄的總高度與寬度相匹配。

範例載入一個現有的 Excel 活頁簿，並使用從零開始的索引選取其第一個工作表的前 10 列與 13 欄。[WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) 定義要顯示的範圍。預覽以 96 DPI 呈現，並使用每英吋 72 點將其像素尺寸轉換為點。 [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) 將修改過的活頁簿嵌入具有該尺寸的框中。透過 [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) 將預覽指派為取代已儲存簡報中「EMBEDDED OLE OBJECT」佔位文字的圖像。

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

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

預覽輔助程式使用 [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) 來選取範圍，並移除頁邊距、頁首與頁尾。啟用 [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) 後， [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) 會將該範圍渲染為 PNG 影像。輔助程式將渲染出的影像資料複製到一個新記憶體串流，並將位置設定在開頭，以供簡報使用。

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

### **縮放儲存格範圍大小**

此方法會縮放所選列的高度和所選欄的寬度，以匹配自訂的 OLE 框尺寸。

範例載入一個現有的 Excel 活頁簿，並使用從零開始的索引選取其第一個工作表的前 10 列與 13 欄。[WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) 定義要顯示的範圍，以下的輔助程式將該範圍縮放以適應寬 400 點、高 100 點的框。將修改過的活頁簿儲存為位元組陣列後， [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) 會以指定的尺寸嵌入它。透過 [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) 指派的預覽，以 96 DPI 渲染，使已儲存的簡報顯示所選儲存格而非預設佔位文字。

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

// 設定工作簿檔案作為 PowerPoint 中 OLE 物件時的顯示大小。
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// 縮放儲存格範圍以符合框架大小。
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// 我們需要使用已修改的工作簿。
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

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

縮放輔助程式會計算所選範圍的寬度與高度比例，保留欄的相對寬度與列的相對高度。它會先將計算出的尺寸從點轉換為英吋，然後使用 [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) 和 [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/) 套用。所選範圍的寬度和高度必須皆非零。

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">預期的儲存格範圍寬度（以點為單位）。</param>
/// <param name="height">預期的儲存格範圍高度（以點為單位）。</param>
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

此預覽輔助程式使用 [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) 來渲染已調整大小的範圍。它使用 [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) 限制列印至該範圍，移除頁邊距、頁首與頁尾，並回傳位於開頭的 PNG 串流。

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

{{% alert color="info" title="Note" %}}
有兩種方法可解決工作表調整大小的問題。請選擇最符合您需求與使用情境的方法。無論簡報是從範本還是從頭建立，兩種方法的運作方式皆相同。此外，此解決方案對 OLE 物件框的大小沒有任何限制。
{{% /alert %}}

## **常見問題**

**為何嵌入的 Excel 工作表在 PowerPoint 中首次啟用時會變更大小？**

這是因為 Excel 在啟用時會嘗試保留原始視窗大小，而 PowerPoint 中的 OLE 物件框則有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持比例，這可能導致調整大小。

**是否能完全防止此調整大小問題？**

是的。透過將 OLE 框縮放以符合 Excel 儲存格範圍的大小，或將儲存格範圍縮放以符合所需的 OLE 框大小，即可防止不必要的調整。

**我應該使用哪種縮放方法，OLE 框縮放還是儲存格範圍縮放？**

如果您希望保留原始的 Excel 列與欄大小，請選擇**OLE 框縮放**。若希望在簡報中 OLE 框具有固定大小，請選擇**儲存格範圍縮放**。

**如果我的簡報是基於範本，這些解決方案仍然適用嗎？**

是的。兩種解決方案皆適用於從範本建立或從頭製作的簡報。

**使用這些方法時，OLE 框的大小有沒有上限？**

沒有。只要適當設定縮放，就可以將 OLE 物件框調整為任何大小。

**有沒有方法避免 PowerPoint 中的「EMBEDDED OLE OBJECT」佔位文字？**

有的。只要將目標 Excel 儲存格範圍截圖並設定為 OLE 框的佔位圖像，即可以自訂的預覽圖像取代預設佔位文字。

## **相關文章**

[建立 Excel 圖表並以 OLE 物件嵌入至簡報中](/slides/zh-hant/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)