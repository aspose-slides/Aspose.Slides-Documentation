---
title: 在 Node.js 中將 PPT 轉換為 PPTX
linktitle: PPT 轉 PPTX
type: docs
weight: 20
url: /zh-hant/nodejs-java/convert-ppt-to-pptx/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- PPT 轉 PPTX
- 儲存 PPT 為 PPTX
- 匯出 PPT 為 PPTX
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 Node.js 中將傳統 PPT 檔案轉換為 PPTX。包含單檔與批次轉換的 JavaScript 範例、錯誤處理與忠實度說明。"
---
## **概覽**

PPT 是舊版的二進位 PowerPoint 格式，而 PPTX 是較新的 Open XML 格式。Aspose.Slides for Node.js via Java 可以在不需要 Microsoft PowerPoint 的情況下載入 PPT 檔案並將其儲存為 PPTX。本文說明如何轉換單一檔案或整個目錄的檔案，並解釋轉換後需要檢查的項目。

## **將 PPT 檔案轉換為 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別載入來源檔案，然後呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save) 並傳入 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/)。`finally` 區塊會釋放 presentation 並釋放其資源。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 載入舊版 PPT 簡報。
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // 將簡報儲存為 PPTX 格式。
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

副檔名本身不會決定輸出格式；是 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/) 參數決定。如果需要保留原始 PPT 檔案，請確保輸入路徑與輸出路徑不同。

## **轉換多個 PPT 檔案**

下列範例會將一個目錄中的每個 `.ppt` 檔案轉換。每個檔案都是獨立處理，單一轉換失敗不會中止其餘批次。

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

對於正式環境，請記錄完整錯誤資訊，判斷是否允許覆寫已存在的輸出檔案，並將失敗的檔名寫入重試或審查佇列。損毀的檔案、未提供正確密碼而開啟的受保護檔案、無法存取的路徑以及不支援的內容都可能導致轉換失敗。請參閱 [Password-Protected Presentations](/slides/zh-hant/nodejs-java/password-protected-presentation/) 了解如何載入加密檔案。

## **忠實度與舊版功能**

轉換通常會保留投影片、母片、版面配置、文字、圖形、影像、表格與圖表。然而，PPT 與 PPTX 並不以完全相同的方式表達所有功能。若某個舊版功能在 PPTX 中沒有對應，或是程式庫未支援，可能會被正規化、略過或以不同方式顯示。

當檔案包含動畫、轉場、內嵌或連結的 OLE 物件、ActiveX 控制項、內嵌媒體、非一般字型或 VBA 巨集時，請檢查轉換後的檔案。純 PPTX 檔案不是巨集啟用格式，因此若必須保留 VBA，請使用適當的巨集啟用工作流程。同時也要確認所需字型與外部資源是否已在將要開啟或渲染轉換後簡報的環境中存在。

對於重要文件，請以程式方式重新開啟產生的 PPTX，檢查關鍵投影片數量與內容，然後在目標檢視器中比較其外觀與投影片放映行為。不要將成功的 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save) 呼叫視為所有舊版功能都有精確 PPTX 對應的證明。

## **何時使用 PPTX**

當簡報將在最新的 PowerPoint 版本中編輯、需要與支援 Open XML 套件的系統交換，或想以較易檢查與復原的格式儲存時，請使用 PPTX。保留原始 PPT 作為存檔或回滾副本，直到轉換後的簡報通過您的忠實度檢查為止。

如果您需要 PDF、HTML、影像、XPS 或其他輸出類型，請參考 [Convert Presentations to Multiple Formats](/slides/zh-hant/nodejs-java/convert-presentation/) 中針對各格式的說明，而不要假設所有目標都能保留可編輯的 PowerPoint 功能。

## **線上轉換器**

若僅偶爾需要轉換單一檔案或快速比較，可使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)。若需可重複執行的轉換、批次處理或應用程式層級的錯誤處理，請使用 Node.js via Java API。

## **相關文章**

- [PPT vs PPTX](/slides/zh-hant/nodejs-java/ppt-vs-pptx/)
- [Save Presentations in Node.js](/slides/zh-hant/nodejs-java/save-presentation/)
- [Supported File Formats](/slides/zh-hant/nodejs-java/supported-file-formats/)
- [Open Presentations in Node.js](/slides/zh-hant/nodejs-java/open-presentation/)

## **FAQ**

**我可以在未安裝 Microsoft PowerPoint 的情況下將 PPT 轉換為 PPTX 嗎？**

可以。Aspose.Slides for Node.js via Java 能在不需 Microsoft PowerPoint 的情況下載入與儲存簡報檔案。

**PPT 轉 PPTX 會完整保留所有內容嗎？**

會保留常見的簡報內容，但無法保證每個舊版或未支援的功能都有完全相同的忠實度。當檔案包含巨集、OLE 或 ActiveX 物件、媒體、特殊動畫或非一般字型時，請檢查產生的檔案。

**我可以轉換受密碼保護的 PPT 檔案嗎？**

可以，只要在載入檔案時提供正確的密碼。缺少或錯誤的密碼會導致載入失敗。

**轉換完成後我應該刪除 PPT 檔案嗎？**

請保留原始檔案，直到您在相關檢視器與工作流程中驗證過 PPTX 為止。這樣可以在舊版功能轉換異常時提供回滾的副本。