---
title: 在 PPTX 中圖表重新調整大小的可行解決方案
type: docs
weight: 60
url: /zh-hant/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- 圖表重新調整大小
- Excel 圖表
- OLE 物件
- 嵌入圖表
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 嵌入 Excel OLE 物件時，修復 PPTX 中意外的圖表重新調整大小問題。了解兩種帶有程式碼的方法，以保持尺寸一致。"
---
## **背景**

已觀察到，通過 Aspose 元件在 PowerPoint 簡報中以 OLE 物件嵌入的 Excel 圖表在第一次啟動後會被重新調整為未指定的比例。此行為導致圖表在啟動前後的簡報中出現顯著的視覺差異。Aspose 團隊已詳細調查此問題並找到了解決方案。本文描述了問題的成因及相應的修復方法。

在[上一篇文章](/slides/zh-hant/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)，我們說明了如何使用 Aspose.Cells for C++ 建立 Excel 圖表，並使用 Aspose.Slides for C++ 將其嵌入 PowerPoint 簡報。為了解決[物件預覽問題](/slides/zh-hant/cpp/object-preview-issue-when-adding-oleobjectframe/)，我們將圖表影像指派給圖表的 OLE 物件框架。在輸出簡報中，當您雙擊顯示圖表影像的 OLE 物件框架時，Excel 圖表會被啟動。最終使用者可以在底層的 Excel 活頁簿中進行任何想要的變更，然後點擊已啟動活頁簿之外的區域返回相應的投影片。使用者返回投影片時，OLE 物件框架的大小會發生變化，且重新調整比例取決於 OLE 物件框架與嵌入的 Excel 活頁簿的原始尺寸。

## **重新調整大小的原因**

因為 Excel 活頁簿有自身的視窗大小，它會在首次啟動時嘗試保留原始大小。而 OLE 物件框架則有自己的尺寸。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，並在嵌入過程中維持正確的比例。根據 Excel 視窗大小與 OLE 物件框架的大小或位置之差異，會發生重新調整大小的情況。

## **可行的解決方案**

使用 Aspose.Slides for C++ 建立 PowerPoint 簡報時，有兩種可能的情境。

**Scenario 1:** 基於現有範本建立簡報。

**Scenario 2:** 從頭開始建立簡報。

我們在此提供的解決方案適用於兩種情境。所有解決方案的基礎相同：**嵌入的 OLE 物件的視窗大小應與 PowerPoint 投影片中的 OLE 物件框架相匹配**。以下將說明此解決方案的兩種方法。

## **第一種方法**

在此方法中，我們將學習如何設定嵌入的 Excel 活頁簿的視窗大小，使其與 PowerPoint 投影片中 OLE 物件框架的大小相匹配。

**Scenario 1** 

假設我們已定義一個範本，並希望基於該範本建立簡報。假設範本中索引為 2 的形狀是我們想放置包含嵌入式 Excel 活頁簿的 OLE 框架的位置。在此情境下，OLE 物件框架的大小已預先定義——它與索引 2 的形狀大小相同。我們只需要將活頁簿的視窗大小設定為該形狀的大小。以下程式碼片段即為此目的：

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// 以視窗方式定義圖表大小。 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// 設定活頁簿視窗寬度（以英吋為單位，除以 72，因 PowerPoint 每英吋使用 72 像素）。
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// 設定活頁簿視窗高度（以英吋為單位）。
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// 將活頁簿儲存至記憶體串流。
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 使用嵌入的 Excel 資料建立 OLE 物件框架。
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**Scenario 2** 

假設我們想從頭開始建立簡報，並加入任意大小的 OLE 物件框架，內含嵌入式 Excel 活頁簿。於下列程式碼片段中，我們在投影片上於 x = 0.5 吋、y = 1 吋的位置建立一個高 4 吋、寬 9.5 吋的 OLE 物件框架。接著將 Excel 活頁簿的視窗設定為相同的大小——高 4 吋、寬 9.5 吋。

```cpp
// 我們期望的高度。
int32_t desiredHeight = 288; // 4 吋 (4 * 72)

// 我們期望的寬度。
int32_t desiredWidth = 684; // 9.5 吋 (9.5 * 72)

// 以視窗方式定義圖表大小。 
chart->SetSizeWithWindow(true);

// 設定活頁簿視窗寬度（以英吋為單位）。
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// 設定活頁簿視窗高度（以英吋為單位）。
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// 將活頁簿儲存至記憶體串流。
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 使用嵌入的 Excel 資料建立 OLE 物件框架。
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **第二種方法**

在此方法中，我們將學習如何設定嵌入的 Excel 活頁簿中圖表的大小，使其與 PowerPoint 投影片中 OLE 物件框架的大小相匹配。當圖表尺寸事先已知且不會變動時，此方法非常實用。

**Scenario 1** 

假設我們已定義一個範本，並希望基於該範本建立簡報。假設範本中索引為 2 的形狀是我們打算放置包含嵌入式 Excel 活頁簿的 OLE 框架的位置。在此情境下，OLE 框架的大小已預先定義——與索引 2 的形狀大小相符。我們只需要將活頁簿中圖表的大小設定為該形狀的大小。以下程式碼片段即為此目的：

```cpp
// 定義圖表大小且不使用視窗。 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// 設定圖表寬度（以像素為單位，乘以 96 因為 Excel 使用每英吋 96 像素）。    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// 設定圖表高度（以像素為單位）。
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// 定義圖表列印大小。
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// 將活頁簿儲存至記憶體串流。
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 使用嵌入的 Excel 資料建立 OLE 物件框架。
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**Scenario 2** 

假設我們想從頭開始建立簡報，並加入任意大小的 OLE 物件框架，內含嵌入式 Excel 活頁簿。於下列程式碼片段中，我們在投影片上於 x = 0.5 吋、y = 1 吋的位置建立一個高 4 吋、寬 9.5 吋的 OLE 物件框架。我們也將相應的圖表大小設定為相同的尺寸：高 4 吋、寬 9.5 吋。

```cpp
// 我們期望的高度。
int32_t desiredHeight = 288; // 4 吋 (4 * 576)

// 我們期望的寬度。
int32_t desiredWidth = 684; // 9.5 吋(9.5 * 576)

// 定義圖表大小且不使用視窗。 
chart->SetSizeWithWindow(false);

// 設定圖表寬度（以像素為單位）。    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// 設定圖表高度（以像素為單位）。
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// 將活頁簿儲存至記憶體串流。
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 使用嵌入的 Excel 資料建立 OLE 物件框架。
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **結論**

針對圖表重新調整大小的問題有兩種解決方法。選擇哪種方法取決於需求與使用情境。無論是從範本建立簡報或是全新建立簡報，兩種方法皆以相同方式運作。另外，此解決方案對 OLE 物件框架的大小沒有任何限制。

## **常見問題**

**為什麼我的嵌入式 Excel 圖表在 PowerPoint 中啟動後會改變大小？**

這是因為 Excel 在首次啟動時會嘗試還原原始視窗大小，而 PowerPoint 中的 OLE 物件框架則有其自身的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而可能導致重新調整大小。

**是否可以完全防止此重新調整大小的問題？**

可以。透過在嵌入之前將 Excel 活頁簿的視窗大小或圖表大小與 OLE 物件框架的大小相匹配，即可保持圖表大小一致。

**我應該選擇哪種方法，設定活頁簿視窗大小還是設定圖表大小？**

若您想保留活頁簿的長寬比且可能在之後允許調整大小，請使用 **Approach 1 (window size)**。若圖表尺寸是固定的且在嵌入後不會變動，請使用 **Approach 2 (chart size)**。

**這些方法是否適用於基於範本的簡報以及全新簡報？**

會。兩種方法對於從範本建立的簡報以及從頭建立的簡報皆以相同方式運作。

**OLE 物件框架的大小是否有限制？**

沒有。只要能適當對應活頁簿或圖表的大小，OLE 框架可以設定為任意尺寸。

**我可以將這些方法用於其他試算表程式所建立的圖表嗎？**

這些範例是針對使用 Aspose.Cells 建立的 Excel 圖表設計的，但只要其他 OLE 相容的試算表程式支援類似的大小設定選項，原則亦適用。

## **相關章節**

- [建立 Excel 圖表並將其以 OLE 物件嵌入簡報](/slides/zh-hant/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)