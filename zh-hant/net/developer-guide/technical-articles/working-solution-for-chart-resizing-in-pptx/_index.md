---
title: 在 PPTX 中圖表調整大小的可行解決方案
type: docs
weight: 60
url: /zh-hant/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- 圖表調整大小
- Excel 圖表
- OLE 物件
- 嵌入圖表
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 嵌入的 Excel OLE 物件時，解決 PPTX 中意外的圖表調整大小問題。了解兩種帶程式碼的方法以保持尺寸一致。"
---
## **背景**

已觀察到，透過 Aspose 元件將 Excel 圖表作為 OLE 物件嵌入 PowerPoint 簡報後，圖表在首次啟動後會被調整為未指定的比例。此行為導致圖表在啟動前後的外觀有明顯差異。Aspose 團隊深入調查此問題並找到了對策。本文說明問題產生的原因以及相應的解決方案。

在[前一篇文章](/slides/zh-hant/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)，我們說明了如何使用 Aspose.Cells for .NET 建立 Excel 圖表，並使用 Aspose.Slides for .NET 將其嵌入 PowerPoint 簡報。為了解決[物件預覽問題](/slides/zh-hant/net/object-preview-issue-when-adding-oleobjectframe/)，我們將圖表影像指定給圖表的 OLE 物件框架。於輸出簡報中，當您雙擊顯示圖表影像的 OLE 物件框架時，Excel 圖表即會被啟動。最終使用者可以在底層的 Excel 活頁簿中進行任何想要的變更，然後點擊已啟動活頁簿之外的區域返回相應投影片。使用者返回投影片時，OLE 物件框架的大小會發生變化，而調整比例則取決於 OLE 物件框架與嵌入的 Excel 活頁簿原始大小的差異。

## **調整大小的原因**

由於 Excel 活頁簿本身具有視窗大小，它會在首次啟動時嘗試保留原始大小。而 OLE 物件框架則有自己的尺寸。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，並在嵌入過程中維持正確的比例。Excel 視窗大小與 OLE 物件框架的大小或位置之間的差異會導致調整大小的產生。

## **可行的解決方案**

使用 Aspose.Slides for .NET 建立 PowerPoint 簡報時，可能會有兩種情境。

**情境 1：** 基於現有範本建立簡報。

**情境 2：** 從頭建立簡報。

本解決方案同時適用於兩種情境。所有解決方法的核心相同：**嵌入的 OLE 物件視窗大小必須與 PowerPoint 投影片中的 OLE 物件框架相符**。以下將說明兩種實作方式。

## **第一種做法**

此做法說明如何設定嵌入的 Excel 活頁簿視窗大小，使其與 PowerPoint 投影片中 OLE 物件框架的大小相同。

**情境 1**

假設我們已定義範本，並想基於該範本建立簡報。假設範本中索引為 2 的圖形將放置一個包含嵌入式 Excel 活頁簿的 OLE 框架。在此情境下，OLE 物件框架的大小已預先定義——與索引 2 的圖形大小相同。我們只需要將活頁簿的視窗大小設為該圖形的大小。以下程式碼片段即可達成此目的：

```cs
// 定義圖表大小使用視窗。 
chart.SizeWithWindow = true;

// 設定活頁簿視窗寬度（單位為英吋，除以 72 因 PowerPoint 使用每英吋 72 像素）。
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// 設定活頁簿視窗高度（單位為英吋）。
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// 將活頁簿儲存至記憶體串流。
MemoryStream workbookStream = workbook.SaveToStream();

// 建立包含嵌入 Excel 資料的 OLE 物件框架。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**情境 2**

假設我們要從頭建立簡報，並在投影片上加入任意大小的 OLE 物件框架與嵌入的 Excel 活頁簿。以下程式碼片段會在投影片上建立一個高 4 吋、寬 9.5 吋、左上座標為 x = 0.5 吋、y = 1 吋的 OLE 物件框架，然後將 Excel 活頁簿視窗設為相同的大小——高 4 吋、寬 9.5 吋。

```cs
// 我們期望的高度。
int desiredHeight = 288; // 4 吋 (4 * 72)

// 我們期望的寬度。
int desiredWidth = 684;//9.5 吋 (9.5 * 72)

// 定義圖表大小使用視窗。
chart.SizeWithWindow = true;

// 設定活頁簿視窗寬度（單位為英吋）。
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// 設定活頁簿視窗高度（單位為英吋）。
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// 將活頁簿儲存至記憶體串流。
MemoryStream workbookStream = workbook.SaveToStream();

// 建立包含嵌入 Excel 資料的 OLE 物件框架。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **第二種做法**

此做法說明如何將嵌入的 Excel 活頁簿中圖表的大小設為與 PowerPoint 投影片中 OLE 物件框架相同。此做法適用於預先知道圖表尺寸且不會變更的情況。

**情境 1**

假設我們已定義範本，並想基於該範本建立簡報。假設範本中索引為 2 的圖形將放置一個包含嵌入式 Excel 活頁簿的 OLE 框架。在此情境下，OLE 框架的大小已預先定義——與索引 2 的圖形大小相同。我們只需要將活頁簿中圖表的大小設為該圖形的大小。以下程式碼片段即可完成此設定：

```cs
// 定義圖表大小且不使用視窗。 
chart.SizeWithWindow = false;

// 設定圖表寬度（單位為像素，乘以 96 因為 Excel 使用每英吋 96 像素）。    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// 設定圖表高度（像素）。
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// 定義圖表列印尺寸。
chart.PrintSize = PrintSizeType.Custom;

// 將活頁簿儲存至記憶體串流。
MemoryStream workbookStream = workbook.SaveToStream();

// 建立包含嵌入 Excel 資料的 OLE 物件框架。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**情境 2**

假設我們要從頭建立簡報，並在投影片上加入任意大小的 OLE 物件框架與嵌入的 Excel 活頁簿。以下程式碼片段會在投影片上建立一個高 4 吋、寬 9.5 吋、左上座標為 x = 0.5 吋、y = 1 吋的 OLE 物件框架，並將相應的圖表大小設為相同的尺寸：高 4 吋、寬 9.5 吋。

```cs
 // 我們期望的高度.
int desiredHeight = 288; // 4 吋 (4 * 576)

 // 我們期望的寬度.
int desiredWidth = 684; // 9.5 吋 (9.5 * 576)

// 定義圖表大小且不使用視窗。 
chart.SizeWithWindow = false;

// 設定圖表寬度（像素）。   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// 設定圖表高度（像素）。    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// 將活頁簿儲存至記憶體串流。
MemoryStream workbookStream = workbook.SaveToStream();

// 建立包含嵌入 Excel 資料的 OLE 物件框架。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **結論**

解決圖表調整大小問題有兩種方法。選擇哪種方法取決於需求與使用情境。無論是從範本還是從頭建立簡報，兩種方法的運作方式相同。此外，此解決方案對 OLE 物件框架的大小沒有限制。

## **常見問題**

**為什麼嵌入的 Excel 圖表在 PowerPoint 中啟動後會改變大小？**  
這是因為 Excel 在首次啟動時會嘗試還原原始視窗大小，而 PowerPoint 中的 OLE 物件框架有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而導致調整大小。

**是否可以完全避免此調整大小問題？**  
可以。若在嵌入前將 Excel 活頁簿視窗大小或圖表大小與 OLE 物件框架大小對齊，即可保持圖表大小一致。

**應該選擇設定活頁簿視窗大小還是設定圖表大小？**  
若希望保留活頁簿的長寬比並可能在之後調整，請使用**方法 1（視窗大小）**。  
若圖表尺寸固定且不會變更，請使用**方法 2（圖表大小）**。

**這兩種方法是否同樣適用於基於範本的簡報與全新簡報？**  
是的。兩種方法對於從範本建立或從頭建立的簡報皆適用。

**OLE 物件框架的大小是否有限制？**  
沒有。只要相應調整活頁簿或圖表的尺寸，即可將 OLE 框架設為任何大小。

**這些方法能否用於其他試算表程式產生的圖表？**  
範例是針對使用 Aspose.Cells 產生的 Excel 圖表，但原理同樣適用於其他支援 OLE 且具備類似尺寸設定選項的試算表程式。

## **相關章節**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/zh-hant/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/zh-hant/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)