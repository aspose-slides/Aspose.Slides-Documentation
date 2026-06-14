---
title: 將簡報匯出為含外部連結影像的 HTML
type: docs
weight: 100
url: /zh-hant/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出簡報
- 匯出投影片
- 匯出 PPT
- 匯出 PPTX
- 匯出 ODP
- PowerPoint 轉 HTML
- OpenDocument 轉 HTML
- 簡報轉 HTML
- 投影片轉 HTML
- PPT 轉 HTML
- PPTX 轉 HTML
- ODP 轉 HTML
- 連結影像
- 外部連結影像
- 連結資源
- 外部資源
- JavaScript
- Node.js
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 搭配 Java，於 JavaScript 中將 PowerPoint 與 OpenDocument 簡報匯出為 HTML，並將影像與其他資源存為外部連結檔案。"
---
## **概觀**

預設情況下，Aspose.Slides 會將簡報匯出為一個自包含的 HTML 檔案。影像和其他資源會直接寫入 HTML，通常以 Base64 資料形式呈現。這在需要單一可攜檔案時相當方便，但對於網站、CMS 或伺服器端轉換管線來說，並不總是最佳格式。

當您想要：

- 減少 HTML 文件的大小；
- 在瀏覽器或 CDN 中分別快取圖像、字型、音訊或影片；
- 在匯出後檢查、取代、壓縮或後處理產生的資源；
- 使輸出結構更接近 Web 應用程式的預期；

請使用外部連結資源。

如需一般的 HTML 轉換工作流程，請參閱 [Convert PowerPoint Presentations to HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/)。本文聚焦於匯出時的資源連結部分。

## **連結資源匯出的工作方式**

[ILinkEmbedController](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 的 Java 代理讓您的應用程式能夠逐一資源決定匯出程式是將資料嵌入 HTML，還是另存為外部檔案並寫入連結。

此控制項有三個方法：

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 決定資源應該被連結還是嵌入。
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 回傳將寫入產生的 HTML 或其他連結資源的 URL。
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 將連結資源資料寫入磁碟或其他儲存目標。

檔案系統路徑與瀏覽器 URL 是分開考慮的。例如，下方範例會將資源檔寫入磁碟上的 `html-output/assets`，而 HTML 內則包含類似 `assets/resource-1.svg` 的相對 URL。瀏覽器會根據包含連結的檔案來解析這些 URL。因此，從 `presentation.html` 連結到 SVG 檔時使用 `assets/resource-1.svg`，而該 SVG 檔再連結同一 `assets` 資料夾內的圖像時則使用 `resource-4.jpg`。

## **匯出含連結資源的 HTML**

以下 JavaScript 範例會建立輸出目錄、在該目錄保存 HTML 檔，並將連結資源存放於 `assets` 子目錄。當 Aspose.Slides 能提供或推斷安全的副檔名時，控制項會連結常見的圖像、字型、音訊、影片與 CSS 資源。未被辨識的資源則保持嵌入。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

匯出完成後，輸出資料夾的結構如下：

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

實際產生的檔案取決於簡報內容與匯出選項。例如，點陣圖通常會匯出為 JPEG 或 PNG。Aspose.Slides 可能會選擇與原簡報不同的影像編碼，以產生較小或較適合的檔案。具有透明度的影像則會匯出為 PNG。

## **為部署選擇 URL**

範例使用相對 URL 前置詞：`assets/`。如果從 `html-output/presentation.html` 開啟 `presentation.html`，瀏覽器會載入 `html-output/assets/resource-1.svg`。

當一個連結資源引用另一個連結資源時，範例會在 [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 中使用 `referrer` 參數，並僅回傳檔名。例如，若 `resource-1.svg` 與 `resource-4.jpg` 都位於 `assets` 資料夾，SVG 檔應引用 `resource-4.jpg`，而非 `assets/resource-4.jpg`。

若檔案部署於其他位置，請使用不同的 URL 前置詞：

- 當資產目錄與 HTML 檔案相鄰時，使用 `assets/`。
- 當資產目錄位於 HTML 檔案上一層時，使用 `../assets/`。
- 當檔案上傳至 CDN 或靜態檔案伺服器時，使用 `https://cdn.example.com/presentations/job-123/assets/`。

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 回傳的 URL 必須與 [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 所寫入檔案的最終部署位置相符。於伺服器應用程式中，請為每個轉換工作使用唯一的輸出目錄或物件儲存前置詞，以避免覆寫其他匯出的檔案。

## **何時改為嵌入**

當輸出必須為單一檔案（例如電子郵件附件、離線預覽或需要在沒有資產資料夾支援的情況下移動的文件）時，嵌入的 Base64 HTML 仍然有用。若 HTML 會由 Web 應用程式提供、存放於 CMS、經過建置管線最佳化，或由瀏覽器獨立快取，則使用連結資源較為合適。

## **常見問題**

**我可以只將圖像外部化，而保留其他資源嵌入嗎？**

可以。於 [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 中，僅對想要另存為獨立檔案的內容類型回傳 `LinkEmbedDecision.Link`，其餘則回傳 `LinkEmbedDecision.Embed`。

**為什麼匯出的圖像副檔名與來源簡報不同？**

Aspose.Slides 可能會在 HTML 匯出過程中重新編碼點陣圖，以改善檔案大小或瀏覽器相容性。例如，來源檔案中的圖像可能依照渲染結果被寫入為 JPEG 或 PNG。

**移動 HTML 檔案後相對 URL 仍然有效嗎？**

相對 URL 僅在保持相同的相對資料夾結構時有效。若 HTML 仍然引用 `assets/resource-1.png`，則 `assets` 資料夾必須與 HTML 檔案保持相鄰，除非您產生不同的 URL 前置詞。

**伺服器應用程式可以重複使用同一輸出資料夾嗎？**

不能。請為每個轉換工作使用唯一的輸出目錄或儲存前置詞，以避免檔名衝突，防止一個匯出覆寫另一個匯出的資源。