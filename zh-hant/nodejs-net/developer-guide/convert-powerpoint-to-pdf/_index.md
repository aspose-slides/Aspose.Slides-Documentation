---
title: 在 Node.js via .NET 中將 PowerPoint 轉換為 PDF
linktitle: PowerPoint 轉 PDF
type: docs
weight: 30
url: /zh-hant/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint 轉 PDF
- 將 PowerPoint 轉換為 PDF
- PPTX 轉 PDF
- PPT 轉 PDF
- ODP 轉 PDF
- 將簡報儲存為 PDF
- PDF/A
- PdfOptions
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via .NET 在 JavaScript 中將 PPTX、PPT 和 ODP 簡報轉換為 PDF，並使用 PdfOptions 產生可存檔的 PDF/A 檔案。"
---
## **概觀**

Aspose.Slides for Node.js via .NET 將 PowerPoint 與 OpenDocument 簡報轉換為 PDF，無需 Microsoft PowerPoint。每個可見的投影片會成為與投影片相同尺寸的 PDF 頁面，且文字保持可選取與可搜尋。本文展示了預設轉換以及使用 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 轉換為 PDF/A 的方式。

範例假設專案資料夾中有一個名為 `sample.pptx` 的簡報，該資料夾可於 [Installation](/slides/zh-hant/nodejs-net/installation/) 中設定。任何 PowerPoint 簡報皆可使用。將每個範例儲存為 `.js` 檔案於專案資料夾，並使用 `node` 從該資料夾執行。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET 沒有自己的 API 參考文件。它以 camelCase 名稱鏡像 Aspose.Slides for .NET API，故本文中的 API 連結會指向 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) 中相對應的類別與成員。
{{% /alert %}}

## **將簡報轉換為 PDF**

要將簡報轉換為 PDF，請依照以下步驟：

1. 將簡報路徑傳遞給 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) 建構函式以開啟簡報。相同程式碼適用於 PPTX、PPT 與 ODP 檔案。  
2. 使用輸出路徑和 `SaveFormat.Pdf` 呼叫 [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法。  
3. 在 `finally` 區塊中呼叫 `dispose`，釋放支援簡報的 .NET 資源。

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

此腳本會將 `sample.pdf` 寫入專案資料夾。轉換使用預設設定：每張未隱藏的投影片會依投影片順序變成一頁。若未取得授權，所有頁面會顯示評估水印；詳見 [Licensing](/slides/zh-hant/nodejs-net/licensing/)。

## **將簡報轉換為 PDF/A**

若要控制輸出，請在 `save` 的第三個參數傳入 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 物件。以下範例將 [compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) 屬性設為 `PdfCompliance.PdfA2b`，產生 PDF/A-2b 檔案。PDF/A 為長期保存的 ISO 標準：其中一項規定是必須將文件使用的所有字型嵌入檔案中。

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

此腳本會將 `sample-pdfa.pdf` 以與預設轉換相同的頁面寫出。若要確認檔案符合標準，可使用如 [veraPDF](https://verapdf.org/) 等 PDF/A 驗證工具檢查。其他 [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) 值可選擇其他標準，例如 `PdfA1b`、`PdfA2a` 或 `PdfUa`（無障礙）等。

## **常見問題**

**如何在 PDF 中包含隱藏的投影片？**

預設會略過隱藏的投影片。將 `PdfOptions` 的 [showHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 屬性設為 `true`，並將選項傳給 `save` 即可。

**我可以使用密碼保護 PDF 嗎？**

可以。於呼叫 `save` 前，將 `PdfOptions` 的 [password](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/password/) 屬性設定為密碼。PDF 閱讀器會在開啟檔案前要求輸入該密碼。

**我可以只轉換部分投影片嗎？**

可以。將投影片位置的陣列作為 `save` 的第四個參數傳入。位置從 1 開始，若不需要選項，第三個參數可為 `null`：`presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` 會產生僅包含第一與第三張投影片的 PDF。

**為什麼在 Linux 上轉換時文字會顯示不同？**

Aspose.Slides 只能使用執行轉換的機器上已安裝的字型。若簡報使用的字型缺失（例如在一般 Linux 伺服器上缺少 Calibri），Aspose.Slides 會改用已安裝的其他字型，導致文字外觀與斷行方式改變。請安裝簡報所使用的字型，以在 Windows 上取得相同的結果。

**我可以將 PDF 取得為 Buffer 而非檔案嗎？**

可以。`presentation.saveToBuffer(SaveFormat.Pdf)` 會回傳 PDF 的 Node.js `Buffer`，在將結果回傳給 HTTP 回應時相當方便。它也接受 `PdfOptions` 作為第二個參數。