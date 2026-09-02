---
title: 在 JavaScript 中將 PowerPoint 簡報轉換為 XML
linktitle: PowerPoint 轉 XML
type: docs
weight: 145
url: /zh-hant/nodejs-java/convert-powerpoint-to-xml/
keywords:
- 將 PowerPoint 轉換為 XML
- 將簡報轉換為 XML
- PPT 轉 XML
- PPTX 轉 XML
- ODP 轉 XML
- PowerPoint XML 簡報
- SaveFormat.Xml
- 將簡報儲存為 XML
- 匯出簡報為 XML
- XML 串流
- Node.js
- JavaScript
- Aspose.Slides
description: 在 JavaScript 中使用 Aspose.Slides for Node.js via Java，將 PowerPoint 與 OpenDocument 簡報轉換為 PowerPoint XML 檔案或串流。
---
## **概覽**

Aspose.Slides for Node.js via Java 可以將 PowerPoint 簡報轉換為 PowerPoint XML 簡報格式。XML 輸出在需要以文字為基礎的表示方式來檢查簡報結構、排除產生文件的錯誤、在自動化測試中比較輸出，或整合需要 XML 而非簡報套件的工作流程時，非常有用。

使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save) 方法，搭配 [SaveFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/) 列舉中的 `Xml` 值。您可以直接將結果寫入檔案或寫入串流。

{{% alert color="info" title="注意" %}}
`SaveFormat.Xml` 會產生 PowerPoint XML 簡報。它不會抽取儲存在 PPTX 套件中的個別 Office Open XML 部件。若您需要精確的 PPTX 套件部件，例如 `ppt/presentation.xml` 或單獨的投影片 XML 檔案，請直接檢查 PPTX 套件本身。
{{% /alert %}}

## **將簡報轉換為 XML 檔案**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別載入來源簡報，然後將輸出路徑與 `SaveFormat.Xml` 傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save)。來源簡報可以是任何支援載入的格式，例如 PPT、PPTX 或 ODP。

以下範例將 PPTX 簡報轉換為 XML 檔案：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **將 XML 輸出寫入串流**

當 XML 必須保留在記憶體中或傳遞給其他元件（例如 Web 服務、儲存提供者或 XML 處理管線）時，請使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save) 的串流重載。以下範例將結果寫入 Java `ByteArrayOutputStream`，並將產生的資料複製到 Node.js `Buffer`：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // 將 xmlBuffer 傳遞給工作流程中的下一個組件。
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **比較 XML 與簡報及匯出格式**

根據結果的使用方式選擇輸出格式：

| 格式 | 輸出 | 典型用途 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 簡報 | 檢查結構、排除錯誤、比較產生的輸出以及基於 XML 的整合 |
| PPT (`.ppt`) | 傳統二進位簡報檔案 | 與較舊 PowerPoint 工作流程的相容性 |
| PPTX (`.pptx`) | 包含多個部件的 Office Open XML 套件 | 常規 PowerPoint 編輯與簡報交換 |
| PDF 或 TIFF | 固定版面的頁面或多頁影像 | 檢視、列印與存檔 |
| PNG、JPEG 或 SVG | 單張投影片的渲染表示 | 縮圖、預覽與影像資產 |
| HTML 或 HTML5 | 以 Web 為導向的簡報輸出 | 瀏覽器檢視與網頁發布 |

與 PPT 和 PPTX 不同，XML 輸出主要用於檢查和資料導向的工作流程。與 PDF、TIFF、HTML 以及投影片影像格式不同，XML 代表的是簡報資料，而非將投影片渲染為頁面或視覺資產。[支援的檔案格式](/slides/zh-hant/nodejs-java/supported-file-formats/) 表格將 PowerPoint XML 簡報列為僅供儲存的格式，因此在工作流程需要將匯出的檔案再次載入 Aspose.Slides 以持續編輯時，請勿使用它。

## **常見問題**

**`SaveFormat.Xml` 與儲存 PPTX 檔案相同嗎？**

不是。PPTX 是包含多個 Office Open XML 部件的套件，而 `SaveFormat.Xml` 會產生 PowerPoint XML 簡報檔案。

**我可以在不在磁碟上建立檔案的情況下儲存 XML 輸出嗎？**

可以。將可寫入的串流傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save)。例如，使用 Java `ByteArrayOutputStream`，並將其資料複製到 Node.js `Buffer` 以進行記憶體內處理。

**Aspose.Slides 能再次載入匯出的 XML 檔案嗎？**

不能。PowerPoint XML 簡報目前僅支援儲存，不支援載入。若需要往返編輯，請使用 PPTX 或其他支援的簡報格式。

**XML 轉換會將每張投影片呈現為頁面或影像嗎？**

不會。XML 轉換會寫入結構化的簡報資料。若需要頁面導向的輸出，請使用 PDF 或 TIFF；若需要單張投影片的影像，請使用 PNG、JPEG 或 SVG。