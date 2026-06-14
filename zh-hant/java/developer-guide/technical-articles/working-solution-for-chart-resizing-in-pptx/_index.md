---
title: 在 PPTX 中圖表調整大小的可行解決方案
type: docs
weight: 40
url: /zh-hant/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 圖表調整大小
- Excel 圖表
- OLE 物件
- 嵌入圖表
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 嵌入 Excel OLE 物件時，修復 PPTX 中意外的圖表調整大小問題。了解兩種帶程式碼的方法，以保持尺寸一致。"
---
## **背景**

已觀察到，透過 Aspose 元件將 Excel 圖表以 OLE 物件嵌入 PowerPoint 簡報後，第一次啟動時會被調整為未指定的比例。此行為會造成圖表在啟動前後的視覺差異。Aspose 團隊已詳細調查此問題並找到了解決方案。本文說明問題的成因以及相應的修正方法。

在[前一篇文章](/slides/zh-hant/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我們說明了如何使用 Aspose.Cells for Java 建立 Excel 圖表，並透過 Aspose.Slides for Java 將其嵌入 PowerPoint 簡報。為了解決[加入 OLE 物件框時的物件預覽問題](/slides/zh-hant/java/object-preview-issue-when-adding-oleobjectframe/)，我們將圖表圖像指派給圖表的 OLE 物件框。於輸出的簡報中，雙擊顯示圖表圖像的 OLE 物件框時，Excel 圖表會被啟動。最終使用者可以在底層的 Excel 工作簿中進行任意變更，然後點擊工作簿外部返回對應的投影片。使用者返回投影片時，OLE 物件框的大小會改變，而調整比例取決於 OLE 物件框與嵌入的 Excel 工作簿原始大小的差異。

## **調整大小的原因**

由於 Excel 工作簿本身有視窗大小，它會在首次啟動時嘗試保留原始大小。另一方面，OLE 物件框也有自己的尺寸。根據 Microsoft 的說法，當 Excel 工作簿被啟動時，Excel 與 PowerPoint 會協商尺寸，並在嵌入過程中維持正確的比例。根據 Excel 視窗大小與 OLE 物件框尺寸或位置的差異，會產生調整大小的情況。

## **可行的解決方案**

建立 PowerPoint 簡報時有兩種可能的情境：

**情境 1：** 以既有範本建立簡報。

**情境 2：** 從頭開始建立簡報。

本解決方案適用於上述兩種情境。所有解決方式的核心相同：**嵌入的 OLE 物件視窗大小必須與 PowerPoint 投影片中的 OLE 物件框相匹配**。以下說明兩種實作方式。

## **第一種方法**

此方法說明如何設定嵌入的 Excel 工作簿視窗大小，使其與 PowerPoint 投影片中 OLE 物件框的尺寸相同。

**情境 1**

假設我們已定義一個範本，並欲以此建立簡報。範本中第 2 個索引的形狀將放置包含嵌入 Excel 工作簿的 OLE 框。此情境下，OLE 物件框的大小已預先定義——與第 2 個索引的形狀大小相同。只需要將工作簿的視窗大小設定為該形狀的大小即可。以下程式碼片段即為示範：

```java
// 設定工作簿視窗寬度（以英吋為單位，除以 576，因為 PowerPoint 每英吋使用 576 像素）。
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// 設定工作簿視窗高度（單位為英吋）。
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// 將工作簿儲存至記憶體串流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 建立包含嵌入 Excel 資料的 OLE 物件框。
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**情境 2**

如果要從頭建立簡報，並在投影片上放置任意大小的 OLE 物件框，內含嵌入的 Excel 工作簿。以下程式碼片段會在投影片上建立一個高 4 吋、寬 9.5 吋、X 座標 0.5 吋、Y 座標 1 吋的 OLE 物件框，然後將 Excel 工作簿視窗設定為相同的尺寸（高 4 吋、寬 9.5 吋）。

```java
// 我們期望的高度。
int desiredHeight = 288; // 4 吋 (4 * 72)
 
// 我們期望的寬度。
int desiredWidth = 684; // 9.5 吋 (9.5 * 72)
 
// 以視窗定義圖表尺寸。
chart.setSizeWithWindow(true);
 
// 設定工作簿視窗寬度（單位為英吋，除以 576，因 PowerPoint 每英吋使用 576 像素）。
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// 設定工作簿視窗高度（單位為英吋）。
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// 將工作簿儲存至記憶體串流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 建立包含嵌入 Excel 資料的 OLE 物件框。
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **第二種方法**

此方法說明如何將嵌入的 Excel 工作簿中圖表的大小設定為與 PowerPoint 投影片中 OLE 物件框相同。當圖表尺寸事先已知且不會變動時，此方法特別有用。

**情境 1**

同樣假設已有範本，且第 2 個索引的形狀將放置 OLE 框。此情境下 OLE 框的大小已預先定義——與該形狀大小相同。只需要將工作簿中圖表的大小設定為該形狀的大小即可。以下程式碼片段示範了這一做法：

```java
// 定義圖表尺寸，且不使用視窗。
chart.setSizeWithWindow(false);
 
// 設定圖表寬度（單位為像素），乘以 96 因為 Excel 每英吋使用 96 像素。
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// 設定圖表高度（單位為像素）。
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// 定義圖表列印尺寸。
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// 將工作簿儲存至記憶體串流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 建立包含嵌入 Excel 資料的 OLE 物件框。
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**情境 2**：

若要從頭建立簡報，並在投影片上放置任意大小的 OLE 物件框，內含嵌入的 Excel 工作簿。以下程式碼片段會在投影片上建立一個高 4 吋、寬 9.5 吋、X 座標 0.5 吋、Y 座標 1 吋的 OLE 物件框，並將圖表大小設定為相同的尺寸：高 4 吋、寬 9.5 吋。

```java
// 我們期望的高度。
int desiredHeight = 288; // 4 吋 (4 * 72)
 
// 我們期望的寬度。
int desiredWidth = 684; // 9.5 吋 (9.5 * 72)
 
// 定義圖表尺寸，且不使用視窗。
chart.setSizeWithWindow(false);
 
// 設定圖表寬度（單位為像素），乘以 96 因為 Excel 每英吋使用 96 像素。
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// 設定圖表高度（單位為像素）。
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// 將工作簿儲存至記憶體串流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 建立包含嵌入 Excel 資料的 OLE 物件框。
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **結論**

針對圖表調整大小的問題，有兩種解決方式。選擇哪種方式取決於需求與使用情境。無論是基於範本建立簡報，或是全新建立，兩種方式的運作方式相同。此外，此解決方案對 OLE 物件框的尺寸沒有任何限制。

## **常見問題**

**為什麼嵌入的 Excel 圖表在 PowerPoint 中啟動後會改變大小？**

這是因為 Excel 在首次啟動時會嘗試還原原始視窗大小，而 PowerPoint 中的 OLE 物件框則有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而導致調整大小。

**是否可以完全防止此調整大小問題？**

可以。只要在嵌入前將 Excel 工作簿視窗大小或圖表大小與 OLE 物件框大小對齊，即可保持圖表尺寸一致。

**應該使用哪種方式：設定工作簿視窗大小或設定圖表大小？**

- 若希望保留工作簿的長寬比例，且可能在之後調整大小，請使用**方法 1（視窗大小）**。  
- 若圖表尺寸固定且不會變動，請使用**方法 2（圖表大小）**。

**這兩種方法是否同時適用於範本式簡報與全新簡報？**

是的。兩種方法對於基於範本建立的簡報以及全新建立的簡報皆可使用，效果相同。

**OLE 物件框的大小是否有限制？**

沒有。只要 OLE 框的尺寸與工作簿或圖表的大小相匹配，即可設定任何尺寸。

**我可以將這些方法套用在其他試算表程式所建立的圖表嗎？**

範例是針對使用 Aspose.Cells 建立的 Excel 圖表，但只要其他 OLE 相容的試算表程式支援類似的尺寸設定，原理亦同樣適用。

## **相關章節**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/zh-hant/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/zh-hant/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)