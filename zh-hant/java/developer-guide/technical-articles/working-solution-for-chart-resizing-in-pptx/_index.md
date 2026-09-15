---
title: 在 PPTX 中圖表重新調整大小的可行解決方案
type: docs
weight: 40
url: /zh-hant/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 圖表重新調整大小
- Excel 圖表
- OLE 物件
- 嵌入圖表
- PowerPoint
- OpenDocument
- 投影片
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 嵌入 Excel OLE 物件時，修復 PPTX 中意外的圖表重新調整大小問題。了解兩種程式碼方法以保持尺寸一致。"
---
## **背景**

已觀察到，透過 Aspose 元件在 PowerPoint 投影片中作為 OLE 物件嵌入的 Excel 圖表，在首次啟動後會被重新調整為未指定的比例。此行為導致圖表在啟動前後的投影片視覺上出現明顯差異。Aspose 團隊已詳細調查此問題並找到解決方案。本文說明問題的成因與相應的修復方法。

在[previous article](/slides/zh-hant/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我們說明了如何使用 Aspose.Cells for Java 建立 Excel 圖表，並使用 Aspose.Slides for Java 將其嵌入 PowerPoint 投影片。為了解決[object preview issue](/slides/zh-hant/java/object-preview-issue-when-adding-oleobjectframe/)，我們將圖表影像指派給圖表的 OLE 物件框架。於輸出投影片中，當您雙擊顯示圖表影像的 OLE 物件框架時，Excel 圖表會被啟動。最終使用者可以在底層的 Excel 活頁簿中進行任何所需的修改，然後點擊已啟動活頁簿之外的區域返回相應的投影片。使用者返回投影片時，OLE 物件框架的大小會改變，且重新調整的比例因 OLE 物件框架與嵌入的 Excel 活頁簿的原始大小而異。

## **調整大小的原因**

由於 Excel 活頁簿有其自身的視窗大小，它會在首次啟動時嘗試保留原始大小。而 OLE 物件框架則有自己的尺寸。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，並在嵌入過程中保持正確的比例。根據 Excel 視窗大小與 OLE 物件框架的尺寸或位置差異，會產生重新調整大小的情況。

## **可行的解決方案**

建立 PowerPoint 投影片時，使用 Aspose.Slides for Java 有兩種可能的情境。

**Scenario 1:** 建立基於現有範本的投影片。

**Scenario 2:** 從頭開始建立投影片。

我們在此提供的解決方案適用於兩種情境。所有解決方案的基礎相同：**嵌入的 OLE 物件的視窗大小必須與 PowerPoint 投影片中的 OLE 物件框架相匹配**。接下來我們將討論這兩種解決方式。

## **第一種方法**

在此方法中，我們將學習如何設定嵌入的 Excel 活頁簿視窗大小，使其與 PowerPoint 投影片中 OLE 物件框架的大小相匹配。

**Scenario 1**

假設我們已定義一個範本，並希望以此建立投影片。假設範本中索引為 2 的圖形是我們要放置包含嵌入式 Excel 活頁簿的 OLE 框架的位置。在此情境下，OLE 物件框架的尺寸已預先定義——與索引 2 的圖形尺寸相同。我們只需將活頁簿的視窗大小設為該圖形的大小。以下程式碼片段即為示範：

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 設定活頁簿的視窗寬度（以英吋為單位），除以 72 因為 PowerPoint 使用每英吋 72 點。
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// 設定活頁簿的視窗高度（以英吋為單位）。
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// 將活頁簿儲存至記憶體串流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 建立包含嵌入式 Excel 資料的 OLE 物件框架。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**

假設我們要從頭建立投影片，並在其中加入任意大小的 OLE 物件框架，內含嵌入的 Excel 活頁簿。以下程式碼片段會在投影片上於 x = 0.5 吋、y = 1 吋的位置建立一個高度 4 吋、寬度 9.5 吋的 OLE 物件框架，然後將 Excel 活頁簿的視窗設定為相同的尺寸——高度 4 吋、寬度 9.5 吋。

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 我們期望的高度。
int desiredHeight = 288; // 4 吋 (4 * 72)
 
// 我們期望的寬度。
int desiredWidth = 684; // 9.5 吋 (9.5 * 72)
 
// 使用視窗定義圖表大小。
chart.setSizeWithWindow(true);
 
// 設定活頁簿的視窗寬度（以英吋為單位），除以 72 因為 PowerPoint 使用每英吋 72 點。
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// 設定活頁簿的視窗高度（以英吋為單位）。
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// 將活頁簿儲存至記憶體串流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 建立包含嵌入式 Excel 資料的 OLE 物件框架。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 吋 (0.5 * 72)
    72,  // y = 1 吋 (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **第二種方法**

在此方法中，我們將學習如何設定嵌入的 Excel 活頁簿中圖表的大小，使其與 PowerPoint 投影片中 OLE 物件框架的大小相匹配。當圖表尺寸事先已知且不會變動時，此方法特別有用。

**Scenario 1**

假設我們已定義一個範本，並希望以此建立投影片。假設範本中索引為 2 的圖形是我們打算放置包含嵌入式 Excel 活頁簿的 OLE 框架的位置。在此情境下，OLE 框架的尺寸已預先定義——與索引 2 的圖形尺寸相同。我們只需將活頁簿中圖表的大小設為該圖形的大小。以下程式碼片段即為示範：

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 定義圖表大小，且不使用視窗。
chart.setSizeWithWindow(false);
 
// 設定圖表寬度（單位為像素），乘以 96 因為 Excel 使用每英吋 96 像素。
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// 設定圖表高度（單位為像素）。
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// 定義圖表列印尺寸。
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// 將活頁簿儲存至記憶體串流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 建立包含嵌入式 Excel 資料的 OLE 物件框架。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**:

假設我們要從頭建立投影片，並加入任意大小的 OLE 物件框架，內含嵌入的 Excel 活頁簿。以下程式碼片段會在投影片上於 x = 0.5 吋、y = 1 吋的位置建立一個高度 4 吋、寬度 9.5 吋的 OLE 物件框架，並將相應的圖表大小設定為相同的尺寸：高度 4 吋、寬度 9.5 吋。

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 我們期望的高度。
int desiredHeight = 288; // 4 吋 (4 * 72)
 
// 我們期望的寬度。
int desiredWidth = 684; // 9.5 吋 (9.5 * 72)
 
// 定義圖表大小，且不使用視窗。
chart.setSizeWithWindow(false);
 
// 設定圖表寬度（單位為像素），先除以 72 取得英吋，再乘以 96 因為 Excel 使用每英吋 96 像素。
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// 設定圖表高度（單位為像素）。
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// 將活頁簿儲存至記憶體串流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 建立包含嵌入式 Excel 資料的 OLE 物件框架。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 吋 (0.5 * 72)
    72,  // y = 1 吋 (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **結論**

針對圖表重新調整大小的問題，有兩種解決方法。選擇哪種方法取決於需求與使用情境。無論是從範本建立投影片或是全新建立，兩種方法的運作方式相同。另外，此解決方案對 OLE 物件框架的大小沒有限制。

## **FAQ**

### 為什麼我的嵌入式 Excel 圖表在 PowerPoint 中啟動後會改變大小？

這是因為 Excel 在首次啟動時嘗試還原原始視窗大小，而 PowerPoint 中的 OLE 物件框架則有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，導致重新調整大小。

### 是否可以完全防止此重新調整大小的問題？

可以。透過在嵌入前將 Excel 活頁簿的視窗大小或圖表大小與 OLE 物件框架的尺寸匹配，即可保持圖表尺寸一致。

### 我應該採用哪種方法：設定活頁簿視窗大小或設定圖表大小？

使用 **方法 1（視窗大小）** 若您想保留活頁簿的長寬比，且可能之後允許調整大小。使用 **方法 2（圖表大小）** 若圖表尺寸已固定且嵌入後不會變更。

### 這些方法是否同時適用於基於範本的投影片與全新投影片？

是的。兩種方法對於由範本建立的投影片以及全新建立的投影片皆以相同方式運作。

### OLE 物件框架的大小是否有限制？

沒有。只要 OLE 框架能適當地對應活頁簿或圖表的大小，您即可將其設定為任意尺寸。

### 我可以將這些方法套用於其他試算表程式所建立的圖表嗎？

這些範例是針對使用 Aspose.Cells 建立的 Excel 圖表設計，但只要其他支援 OLE 的試算表程式具有類似的尺寸設定功能，原理同樣適用。

## **相關章節**

- [建立 Excel 圖表並以 OLE 物件嵌入投影片](/slides/zh-hant/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)