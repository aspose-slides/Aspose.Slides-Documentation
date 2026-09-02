---
title: 在 Node.js 中將 PPT 轉換為 PPTX
linktitle: PPT 轉 PPTX
type: docs
weight: 20
url: /zh-hant/nodejs-java/convert-ppt-to-pptx/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- PPT 轉 PPTX
- 將 PPT 儲存為 PPTX
- 匯出 PPT 為 PPTX
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 Node.js 中將舊版 PPT 檔案轉換為 PPTX。包含單檔與批次轉換、錯誤處理以及相容性說明的 JavaScript 範例。"
---
## **概述**

PPT 是舊版二進位 PowerPoint 格式，PPTX 則是較新的 Open XML 格式。Aspose.Slides for Node.js via Java 可以在不使用 Microsoft PowerPoint 的情況下載入 PPT 檔案並將其儲存為 PPTX。本篇說明如何轉換單一檔案或整個目錄的檔案，並解釋轉換後需要檢查的項目。

## **將 PPT 檔案轉換為 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別載入來源檔案，然後呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save) 並傳入 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/)。`finally` 區塊會釋放 Presentation 並清除其資源。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 載入舊版 PPT 簡報。
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // 以 PPTX 格式儲存簡報。
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

副檔名本身不會決定輸出格式；是 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/) 參數決定。如果需要保留原始 PPT 檔案，請確保輸入與輸出路徑不同。

## **一次轉換多個 PPT 檔案**

以下範例會將指定目錄內的每個 `.ppt` 檔案逐一轉換。每個檔案獨立處理，單一失敗不會中斷整批轉換。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

在正式工作負載中，請記錄完整錯誤資訊、決定是否允許覆寫已存在的輸出檔案，並將失敗的檔名寫入重試或審查佇列。檔案損毀、未提供正確密碼的受保護檔案、路徑無法存取，以及不支援的內容，都可能導致轉換失敗。請參閱 [Password-Protected Presentations](/nodejs-java/password-protected-presentation/) 以載入加密檔案。

## **相容性與舊版功能**

轉換通常會保留投影片、母片、版面配置、文字、圖形、影像、表格與圖表。然而，PPT 與 PPTX 並未以完全相同的方式呈現所有功能。若某項舊版功能在 PPTX 中沒有對應或未被函式庫支援，可能會被正規化、略過或以不同方式顯示。

當檔案包含動畫、轉場、內嵌或連結的 OLE 物件、ActiveX 控制項、內嵌媒體、罕見字型或 VBA 巨集時，請特別檢查轉換後的檔案。純 PPTX 檔案不是巨集啟用格式，若必須保留 VBA，請使用相應的巨集啟用工作流程。同時也要確認必要的字型與外部資源在開啟或轉譯轉換後投影片的環境中可用。

對於重要文件，建議以程式方式重新開啟產生的 PPTX，檢查關鍵投影片數量與內容，然後在目標檢視器中比較外觀與投影片放映行為。不要僅以成功呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save) 為證明所有舊版功能都有精確的 PPTX 表現。

## **何時使用 PPTX**

當投影片需要在最新的 PowerPoint 版本中編輯、與支援 Open XML 套件的系統交換，或需要比舊版二進位 PPT 更易於檢視與復原的儲存格式時，請使用 PPTX。將原始 PPT 保留為存檔或回滾副本，直到轉換後的投影片通過您的相容性檢查為止。

如果您需要 PDF、HTML、影像、XPS 或其他輸出類型，請參考 [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) 中針對特定格式的說明，而不是假設所有目標都能保留可編輯的 PowerPoint 功能。

## **線上轉換工具**

若只需要偶爾轉換單一檔案或快速比較，可以使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)。若需可重複執行的轉換、批次處理或應用程式層級的錯誤處理，請使用 Node.js via Java API。

## **相關文章**

- [PPT vs PPTX](/nodejs-java/ppt-vs-pptx/)
- [Save Presentations in Node.js](/nodejs-java/save-presentation/)
- [Supported File Formats](/nodejs-java/supported-file-formats/)
- [Open Presentations in Node.js](/nodejs-java/open-presentation/)

## **常見問題**

**我可以在未安裝 Microsoft PowerPoint 的情況下將 PPT 轉換為 PPTX 嗎？**

可以。Aspose.Slides for Node.js via Java 能在不需要 Microsoft PowerPoint 的情況下載入與儲存投影片檔案。

**PPT 轉 PPTX 會完整保留所有內容嗎？**

會保留常見的投影片內容，但對於每個舊版或未支援的功能，無法保證完全相同的相容性。當檔案包含巨集、OLE 或 ActiveX 物件、媒體、特殊動畫或罕見字型時，請仔細檢查產生的檔案。

**我可以轉換受密碼保護的 PPT 檔案嗎？**

可以，只要在載入檔案時提供正確的密碼。缺少或錯誤的密碼會導致載入失敗。

**轉換完成後我應該刪除 PPT 檔案嗎？**

請保留原始檔案，直到您已在相關檢視器與工作流程中驗證 PPTX 為止。這樣可以在舊版功能轉換結果不同時提供回滾依據。