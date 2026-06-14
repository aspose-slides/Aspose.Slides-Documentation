---
title: 在 JavaScript 中將 PowerPoint 簡報轉換為 XPS
linktitle: PowerPoint 轉 XPS
type: docs
weight: 70
url: /zh-hant/nodejs-java/convert-powerpoint-to-xps/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 XPS
- 簡報 轉 XPS
- 投影片 轉 XPS
- PPT 轉 XPS
- PPTX 轉 XPS
- 將 PPT 儲存為 XPS
- 將 PPTX 儲存為 XPS
- 匯出 PPT 為 XPS
- 匯出 PPTX 為 XPS
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中將 PowerPoint PPT/PPTX 轉換為高品質、跨平台的 XPS。獲取逐步指南與範例程式碼。"
---
## **概觀**

Aspose.Slides 允許您透過將 PPT 或 PPTX 檔案儲存為 XPS 格式，將 PowerPoint 簡報轉換為 XPS。本篇文章說明 XPS 格式何時可能有用，並展示如何使用 Aspose.Slides 以預設設定或自訂 [XpsOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xpsoptions/) 設定執行轉換。

## **關於 XPS**

Microsoft 開發了 [XPS](https://docs.fileformat.com/page-description-language/xps/) 作為 [PDF](https://docs.fileformat.com/pdf/) 的替代方案。它允許您透過輸出與 PDF 十分相似的檔案來列印內容。XPS 格式基於 XML。XPS 檔案的版面或結構在所有作業系統與印表機上皆保持一致。

## **何時使用 Microsoft XPS 格式**

{{% alert color="primary" %}} 

欲了解 Aspose.Slides 如何將 PPT 或 PPTX 簡報轉換為 XPS 格式，您可以查看 [此免費線上轉換應用程式](https://products.aspose.app/slides/zh-hant/conversion)。 

{{% /alert %}} 

如果您想降低儲存成本，可以將 Microsoft PowerPoint 簡報轉換為 XPS 格式。如此一來，儲存、分享與列印文件都會更方便。

Microsoft 持續在 Windows 中（甚至在 Windows 10）實作對 XPS 的強力支援，您可以考慮將檔案儲存為此格式。如果您使用 Windows 8.1、Windows 8、Windows 7 或 Windows Vista，XPS 可能是某些操作的最佳選擇。

- **Windows 8** 使用 OXPS（Open XPS）格式作為 XPS 檔案。OXPS 是原始 XPS 格式的標準化版本。Windows 8 對 XPS 檔案的支援優於對 PDF 檔案的支援。  
  - **XPS**：內建 XPS 檢視器/閱讀器，且提供列印至 XPS 功能。  
  - **PDF**：提供 PDF 閱讀器，但沒有列印至 PDF 的功能。  

- **Windows 7** 與 **Windows Vista** 使用原始 XPS 格式。這些作業系統對 XPS 檔案的支援也優於對 PDF 的支援。  
  - **XPS**：內建 XPS 檢視器，且提供列印至 XPS 功能。  
  - **PDF**：沒有 PDF 閱讀器，也沒有列印至 PDF 的功能。  

|<p>**輸入 PPT(X)：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**輸出 XPS：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft 最終在 Windows 10 中透過「列印至 PDF」功能實作了 PDF 的列印支援。先前，使用者只能透過 XPS 格式列印文件。

## **使用 Aspose.Slides 進行 XPS 轉換**

在 [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/zh-hant/nodejs-java/)，您可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別所提供的 [**save**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) 方法，將整個簡報轉換為 XPS 檔案。

在將簡報轉換為 XPS 時，必須使用以下任一設定儲存簡報：

- 預設設定（不使用 [**XPSOptions**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xpsoptions)）
- 自訂設定（使用 [**XPSOptions**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xpsoptions)）

### **使用預設設定將簡報轉換為 XPS**

以下 JavaScript 範例程式碼示範如何使用標準設定將簡報轉換為 XPS 文件：

```javascript
// 建立一個代表簡報檔案的 Presentation 物件
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // 將簡報儲存為 XPS 文件
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **使用自訂設定將簡報轉換為 XPS**

以下範例程式碼示範如何在 JavaScript 中使用自訂設定將簡報轉換為 XPS 文件：

```javascript
// 建立一個代表簡報檔案的 Presentation 物件
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // 建立 TiffOptions 類別的實例
    var options = new aspose.slides.XpsOptions();
    // 將 MetaFiles 儲存為 PNG
    options.setSaveMetafilesAsPng(true);
    // 將簡報儲存為 XPS 文件
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以將 XPS 儲存至串流而非檔案嗎？**

是的 — Aspose.Slides 允許您直接匯出至串流，這對於 Web API、伺服器端管線，或任何希望在不觸碰檔案系統的情況下傳送 XPS 的情境都非常理想。

**隱藏投影片會被轉換為 XPS 嗎？我可以排除它們嗎？**

預設情況下，只會呈現一般（可見）投影片。您可以在儲存為 XPS 前透過 [export settings](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xpsoptions/) 以及 [include or exclude hidden slides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) 來決定是否包含隱藏投影片，確保輸出僅包含您所需的頁面。