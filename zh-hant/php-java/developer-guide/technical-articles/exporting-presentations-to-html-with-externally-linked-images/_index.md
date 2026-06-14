---
title: "將簡報匯出為包含外部連結影像的 HTML"
type: docs
weight: 100
url: /zh-hant/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- "匯出 PowerPoint"
- "匯出 OpenDocument"
- "匯出簡報"
- "匯出投影片"
- "匯出 PPT"
- "匯出 PPTX"
- "匯出 ODP"
- "PowerPoint 轉 HTML"
- "OpenDocument 轉 HTML"
- "簡報轉 HTML"
- "投影片轉 HTML"
- "PPT 轉 HTML"
- "PPTX 轉 HTML"
- "ODP 轉 HTML"
- "連結影像"
- "外部連結影像"
- "連結資源"
- "外部資源"
- "PHP"
- "Aspose.Slides"
description: "在 PHP 透過 Java 使用 Aspose.Slides，將 PowerPoint 與 OpenDocument 簡報匯出為 HTML，且影像與其他資源會儲存為外部連結檔案。"
---
## **概觀**

預設情況下，Aspose.Slides 會將簡報匯出為一個自行包含的 HTML 檔案。影像和其他資源會直接寫入 HTML，通常以 Base64 資料的形式呈現。這在需要單一可攜檔案時相當方便，但對於網站、CMS 或伺服器端轉換工作流程並不總是最佳格式。

當您希望：

- 減少 HTML 文件的大小；
- 在瀏覽器或 CDN 中分別快取影像、字型、音訊或影片；
- 在匯出後檢查、取代、壓縮或後處理產生的資源；
- 使輸出結構更貼近 Web 應用程式的預期；

時可使用外部連結資源。

欲了解一般的 HTML 轉換工作流程，請參閱[將 PowerPoint 簡報轉換為 HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/)。本文聚焦於匯出的資源連結部分。

## **外部資源匯出運作方式**

[HtmlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmloptions/) 可在 Aspose.Slides 匯出簡報為 HTML 時使用自訂的連結/嵌入控制器。在 PHP 透過 Java 的情境下，通常會以一個小型 Java 輔助類別來實作。先編譯該輔助類別，將其加入 PHP Java Bridge 的 classpath，然後在 PHP 中以 `new Java(...)` 方式實例化。

此輔助類別會依資源逐一決定匯出器是將資料嵌入 HTML，還是另存為外部檔案並寫入連結。它需要三個回呼方法：

- `ExternalResourceController.getObjectStoringLocation` 決定資源應該被連結或嵌入。
- `ExternalResourceController.getUrl` 回傳將寫入產生的 HTML 或其他連結資源的 URL。
- `ExternalResourceController.saveExternal` 將連結資源的資料寫入磁碟或其他儲存目標。

檔案系統路徑與瀏覽器 URL 是不同的概念。例如，下列範例會把資源檔案寫入磁碟上的 `html-output/assets`，而 HTML 本身包含相對 URL，如 `assets/resource-1.svg`。瀏覽器會以包含連結的檔案所在位置為基礎解析這些 URL。因此，`presentation.html` 指向 SVG 檔案時使用 `assets/resource-1.svg`，而該 SVG 檔案再指向同一 `assets` 資料夾內的圖片時則使用 `resource-4.jpg`。

## **建立 Java 輔助類別**

建立一個 Java 類別，例如 `com.example.slides.ExternalResourceController`，使用 Aspose.Slides for Java 編譯，並確保編譯後的類別或 JAR 可供 PHP Java Bridge 使用。

以下輔助類別會在 Aspose.Slides 提供或可推斷安全的檔案副檔名時，連結常見的影像、字型、音訊、影片與 CSS 資源。未被識別的資源則保持嵌入。

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **匯出含連結資源的 HTML**

以下 PHP 程式碼會建立輸出目錄、將 HTML 檔案儲存於其中，並將連結資源放入 `assets` 子目錄。程式碼同時結合 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmloptions/)、[SVGOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/)、[SlideImageFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideimageformat/)、[SaveFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/) 以完成匯出。

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
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

實際產生的檔案會依簡報內容與匯出選項而異。例如，點陣圖通常會以 JPEG 或 PNG 匯出。Aspose.Slides 可能會選擇不同於原始簡報的影像編碼方式，以產生更小或更適合的檔案。具有透明度的影像則會以 PNG 匯出。

## **部署時的 URL 選擇**

範例使用相對 URL 前綴 `assets/`。若 `presentation.html` 位於 `html-output/presentation.html`，瀏覽器會載入 `html-output/assets/resource-1.svg`。

當一個連結資源需要參照另一個連結資源時，範例會在 `ExternalResourceController.getUrl` 中使用 `referrer` 參數，僅回傳檔名。例如，若 `resource-1.svg` 與 `resource-4.jpg` 同在 `assets` 資料夾，SVG 檔案應該引用 `resource-4.jpg`，而非 `assets/resource-4.jpg`。

若檔案部署於其他位置，可使用不同的 URL 前綴：

- 當資產目錄與 HTML 檔案同層時，使用 `assets/`。
- 當資產目錄位於 HTML 檔案上層時，使用 `../assets/`。
- 當檔案上傳至 CDN 或靜態檔案伺服器時，使用 `https://cdn.example.com/presentations/job-123/assets/`。

`ExternalResourceController.getUrl` 回傳的 URL 必須與 `ExternalResourceController.saveExternal` 寫入的最終部署位置相符。於伺服器應用程式中，請為每次轉換工作使用唯一的輸出目錄或物件儲存前綴，以避免不同匯出之間的檔案互相覆寫。

## **何時仍應使用嵌入方式**

當輸出必須為單一檔案（例如電子郵件附件、離線預覽或需搬移且無資產資料夾支援的文件）時，嵌入 Base64 的 HTML 仍然實用。若 HTML 將由 Web 應用程式提供、儲存於 CMS、經過建置管線優化，或需讓瀏覽器獨立快取資源，則使用連結資源較為合適。

## **常見問答**

**我可以只將影像外部化，而讓其他資源仍保持嵌入嗎？**

可以。於 `ExternalResourceController.getObjectStoringLocation` 中，僅對想要另存為檔案的內容類型回傳 [LinkEmbedDecision](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/linkembeddecision/) 的 `Link` 值，其他則回傳 `Embed`。

**為什麼匯出的影像副檔名與來源簡報不同？**

Aspose.Slides 可能會在 HTML 匯出過程中重新編碼點陣圖，以改善檔案大小或瀏覽器相容性。例如，來源檔案的影像可能會根據最終渲染結果寫入為 JPEG 或 PNG。

**搬移 HTML 檔案後相對 URL 能否正常運作？**

相對 URL 只能在相同的相對資料夾結構被保留時才可正常運作。如果 HTML 參照 `assets/resource-1.png`，則 `assets` 資料夾必須與 HTML 檔案保持相同相對位置，除非您產生了不同的 URL 前綴。

**伺服器應用程式是否應重複使用相同的輸出資料夾？**

不應。請為每一次的轉換工作使用唯一的輸出目錄或儲存前綴，以避免檔名衝突並防止一次匯出覆寫其他匯出的資源。