---
title: 工作表調整大小的可行解決方案
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
description: "使用 C++ 在 PowerPoint 簡報中調整工作表大小的可行解決方案"
---
{{% alert color="primary" %}}

已觀察到，透過 Aspose 元件在 PowerPoint 簡報中以 OLE 物件嵌入的 Excel 工作表，在第一次啟動後會被調整至未知的比例。此行為會在 OLE 物件的啟動前後造成明顯的視覺差異。我們已深入調查此問題並提供了解決方案，詳情請見本文。

{{% /alert %}}

## **背景**

在文章[管理 OLE](/slides/zh-hant/cpp/manage-ole/)中，我們說明了如何使用 Aspose.Slides for C++ 將 OLE 框架新增到 PowerPoint 簡報。為了解決[物件預覽問題](/slides/zh-hant/cpp/object-preview-issue-when-adding-oleobjectframe/)，我們將選取的工作表區域影像指派給 OLE 物件框架。於輸出簡報中，當您雙擊顯示工作表影像的 OLE 物件框架時，Excel 活頁簿會被啟動。最終使用者可以對實際的 Excel 活頁簿進行任意變更，然後點擊啟動的 Excel 活頁簿外部返回投影片。使用者返回投影片時，OLE 物件框架的大小會發生變化。調整比例會因 OLE 物件框架的大小與嵌入的 Excel 活頁簿的大小而異。

## **調整大小的原因**

由於 Excel 活頁簿本身有視窗大小，第一次啟動時會嘗試保留其原始大小。另一方面，OLE 物件框架也有自己的尺寸。根據 Microsoft 的說明，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中維持正確的比例。調整大小的發生是基於 Excel 視窗大小與 OLE 物件框架大小與位置之間的差異。

## **可行的解決方案**

有兩種可能的解決方案可避免此調整效果。

- 將 PowerPoint 簡報中的 OLE 框架大小縮放至與 OLE 框架中所需的列數與欄數的高度與寬度相匹配。
- 保持 OLE 框架大小不變，並將參與的列與欄的大小縮放以適應選定的 OLE 框架尺寸。

### **縮放 OLE 框架大小**

在此方法中，我們將學習如何將嵌入的 Excel 活頁簿的 OLE 框架大小設定為與 Excel 工作表中參與列與欄的累計大小相匹配。

假設我們有一個範本 Excel 工作表，並希望將其以 OLE 框架的形式加入簡報。在此情境下，OLE 物件框架的大小將先根據工作簿中參與列的列高與欄的欄寬累計計算。接著，我們會將 OLE 框架的大小設為此計算值。為了避免 PowerPoint 中 OLE 框架顯示紅色的「EMBEDDED OLE OBJECT」訊息，我們還會擷取工作簿中所需列與欄的影像，並將其設定為 OLE 框架的影像。

```cpp
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

```cpp
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

在此方法中，我們將學習如何將參與列的高度與參與欄的寬度縮放，以匹配自訂的 OLE 框架大小。

假設我們有一個範本 Excel 工作表，並希望將其以 OLE 框架的形式加入簡報。在此情境下，我們會設定 OLE 框架的大小，並將參與 OLE 框架區域的列與欄的大小進行縮放。之後，我們將工作簿儲存至串流以套用變更，並轉換成位元組陣列以加入 OLE 框架。為了避免 PowerPoint 中 OLE 框架顯示紅色的「EMBEDDED OLE OBJECT」訊息，我們同樣會擷取工作簿中所需列與欄的影像，並將其設定為 OLE 框架的影像。

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// 設定當工作簿檔案在 PowerPoint 中作為 OLE 物件使用時的顯示大小。
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
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// 將 OLE 影像加入簡報資源。
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
/// <param name="width">儲存格範圍預期的寬度（單位為點）</param>
/// <param name="height">儲存格範圍預期的高度（單位為點）</param>
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

{{% alert color="primary" %}}

有兩種方法可解決工作表調整大小的問題。選擇合適的方法取決於具體需求與使用情境。兩種方法在從範本或從頭建立簡報時皆以相同方式運作。此外，此解決方案對 OLE 物件框架的大小沒有任何限制。

{{% /alert %}}

## **常見問題**

**為什麼嵌入的 Excel 工作表在 PowerPoint 中首次啟動時會改變大小？**

這是因為 Excel 嘗試在啟動時維持原始視窗大小，而 PowerPoint 中的 OLE 物件框架則有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，因而導致調整大小。

**是否可以完全防止此調整問題？**

可以。透過將 OLE 框架縮放至符合 Excel 儲存格範圍大小，或將儲存格範圍縮放至符合欲使用的 OLE 框架大小，即可防止不必要的調整。

**應該使用哪種縮放方式：OLE 框架縮放或儲存格範圍縮放？**

如果您想保留原始的 Excel 列與欄大小，請選擇 **OLE 框架縮放**。若您希望在簡報中維持固定的 OLE 框架尺寸，請選擇 **儲存格範圍縮放**。

**這些解決方案在基於範本的簡報中也可行嗎？**

可以。兩種解決方案均適用於由範本建立的簡報以及從頭建立的簡報。

**使用這些方法時，OLE 框架的大小是否有上限？**

沒有。只要適當設定縮放比例，您可以將 OLE 物件框架調整為任意大小。

**有沒有方法避免 PowerPoint 中出現「EMBEDDED OLE OBJECT」佔位文字？**

有。透過擷取目標 Excel 儲存格範圍的快照，並將其設定為 OLE 框架的佔位影像，即可在預設佔位文字位置顯示自訂的預覽影像。

## **相關文章**

[在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)