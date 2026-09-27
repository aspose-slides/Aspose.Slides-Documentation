---
title: 在 Node.js via .NET 中開啟簡報
linktitle: 開啟簡報
type: docs
weight: 20
url: /zh-hant/nodejs-net/open-presentation/
keywords:
- 開啟簡報
- 開啟 PowerPoint
- 開啟 PPTX
- 開啟 PPT
- 開啟 ODP
- 載入簡報
- 從緩衝區載入簡報
- 投影片數量
- 轉換簡報
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides for Node.js via .NET 開啟 PPTX、PPT 與 ODP 簡報：可從檔案路徑或 Buffer 載入，讀取投影片數量，並另存為其他格式。"
---
## **概觀**

Aspose.Slides for Node.js via .NET 可以從檔案路徑或 Node.js `Buffer` 開啟 PowerPoint 與 OpenDocument 簡報，如 PPTX、PPT 和 ODP 檔案。本文示範兩種方式，讀取投影片數量，並將開啟的簡報另存為其他格式。

範例假設專案資料夾中有一個名為 `sample.pptx` 的簡報，該資料夾已在[安裝](/slides/zh-hant/nodejs-net/installation/)中設定。任何 PowerPoint 簡報皆可使用。將每個範例存為 `.js` 檔案於專案資料夾，並以 `node` 從該資料夾執行。

{{% alert color="info" title="注意" %}}
Aspose.Slides for Node.js via .NET 沒有自己的 API 參考文件。它以 camelCase 名稱鏡像 Aspose.Slides for .NET API，因此本文中的 API 連結會指向[Aspose.Slides for .NET API 參考](https://reference.aspose.com/slides/net/) 中相對應的類別與成員。
{{% /alert %}}

## **從檔案開啟簡報**

要開啟簡報，只需將其路徑傳遞給 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) 建構函式。Aspose.Slides 會根據檔案內容而非副檔名偵測格式，因此相同程式碼可開啟 PPTX、PPT 與 ODP 檔案。相對路徑會以目前工作目錄為基礎解析，當您在專案資料夾執行腳本時，工作目錄即為該資料夾。

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

腳本會印出 `sample.pptx` 的投影片數，例如 `Slide count: 9`。[slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 集合的 `count` 屬性會包含隱藏投影片。請如範例所示在 `finally` 區塊中呼叫 `dispose`，以確保即使程式碼發生錯誤，簡報背後的 .NET 資源也會被釋放。

## **從緩衝區開啟簡報**

當簡報來源於資料庫、HTTP 上傳或其他以位元組形式提供的來源時，請將 Node.js `Buffer` 作為第二個建構函式參數，第一個參數傳入 `null`。以下範例將 `sample.pptx` 讀入緩衝區，以模擬此類來源：

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

腳本會印出與前一個範例相同的投影片數。第二個參數必須是 `Buffer`。若傳入其他類型（例如 `Uint8Array`），建構函式不會拋出錯誤，而是建立一個僅含空白投影片的新簡報。請先使用 `Buffer.from` 轉換其他二進位類型。

## **將簡報另存為其他格式**

若要將簡報轉換為其他簡報格式，只需開啟它並以不同的 [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) 值儲存。以下範例會印出 Aspose.Slides 偵測到的格式（由 `sourceFormat` 屬性返回），並將簡報儲存為 OpenDocument 簡報：

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

腳本會印出 `Source format: Pptx`，並寫入 `sample.odp`，其內容與原簡報相同。`sourceFormat` 會返回 `Ppt`、`Pptx` 或 `Odp`。若想改為儲存為 PDF 或影像，請參閱[將 PowerPoint 轉換為 PDF](/slides/zh-hant/nodejs-net/convert-powerpoint-to-pdf/)與[將投影片轉換為影像](/slides/zh-hant/nodejs-net/convert-slide/)。

## **常見問題**

**如何開啟受密碼保護的簡報？**

建立一個 [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) 物件，設定其 `password` 屬性，並將該物件作為第三個建構函式參數傳入：`new Presentation("protected.pptx", null, loadOptions)`。若密碼不正確，建構函式會拋出錯誤。

**為何建構函式會拋出訊息為空的 `Error`？**

當 .NET 中的 `Presentation` 建構函式失敗時（例如檔案不存在、不是簡報，或需要其他密碼），JavaScript 會收到訊息為空的 `Error`。在開啟檔案前，請先確認檔案相對於工作目錄是否存在，例如使用 `fs.existsSync`。

**我可以開啟哪些格式？**

PowerPoint 與 OpenDocument 簡報格式，包括 PPT、PPTX、PPS、POT、POTX、PPTM、ODP、OTP 及 FODP。