---
title: 使用外部連結圖像將簡報匯出為 HTML
type: docs
weight: 100
url: /zh-hant/java/exporting-presentations-to-html-with-externally-linked-images/
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
- 已連結的圖像
- 外部連結圖像
- 已連結的資源
- 外部資源
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中將 PowerPoint 與 OpenDocument 簡報匯出為 HTML，並將圖像及其他資源儲存為外部連結檔案。"
---
## **概覽**

預設情況下，Aspose.Slides 會將投影片匯出為單一的自包含 HTML 檔案。影像與其他資源會直接寫入 HTML 中，通常以 Base64 資料形式呈現。這在需要單一可攜檔案時相當方便，但對於網站、CMS 或伺服器端轉換流程而言，未必是最佳格式。

當您希望：

- 減少 HTML 文件的大小；
- 在瀏覽器或 CDN 中分別快取影像、字型、音訊或影片；
- 在匯出後檢查、取代、壓縮或後處理產生的資源；
- 讓輸出結構更貼近 Web 應用程式的預期；

就應使用外部連結資源。

關於一般的 HTML 轉換工作流程，請參閱 [Convert PowerPoint Presentations to HTML](/slides/zh-hant/java/convert-powerpoint-to-html/)。本文聚焦於匯出時的資源連結部分。

## **連結資源匯出運作方式**

[ILinkEmbedController](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 讓您的應用程式逐一資源決定是將資料嵌入 HTML，還是另存為外部檔案並寫入連結。

此介面有三個方法：

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 決定資源應該是連結還是嵌入。
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 回傳要寫入產生的 HTML 或其他連結資源的 URL。
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 將連結資源資料寫入磁碟或其他儲存目標。

檔案系統路徑與瀏覽器 URL 是分開的考量。例如，下列範例會將資源檔寫入磁碟上的 `html-output/assets`，而 HTML 本身則包含類似 `assets/resource-1.svg` 的相對 URL。瀏覽器會以包含連結的檔案為基準解析這些 URL。因此，`presentation.html` 中指向 SVG 檔的連結會使用 `assets/resource-1.svg`，而該 SVG 檔內指向同一 `assets` 資料夾下圖片的連結則使用 `resource-4.jpg`。

## **匯出帶有連結資源的 HTML**

以下 Java 範例會建立輸出目錄，將 HTML 檔儲存於其中，並將連結資源存放在 `assets` 子目錄。當 Aspose.Slides 提供或能推斷安全的副檔名時，控制器會將常見的影像、字型、音訊、影片與 CSS 資源以連結方式處理；未辨識的資源則保持嵌入。

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void main(String[] args) throws IOException {
        Path inputFilePath = Paths.get("presentation.pptx");
        Path outputDirectory = Paths.get("html-output");
        String assetDirectoryName = "assets";
        Path assetDirectory = outputDirectory.resolve(assetDirectoryName);

        Files.createDirectories(outputDirectory);
        Files.createDirectories(assetDirectory);

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFilePath.toString());
        try {
            Path htmlFilePath = outputDirectory.resolve("presentation.html");
            presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final Path assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

        private ExternalResourceController(Path assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            try {
                Files.createDirectories(assetDirectory);
                Path filePath = assetDirectory.resolve(fileName);
                Files.write(filePath, entityData);
            } catch (IOException exception) {
                throw new IllegalStateException("Failed to save external resource " + resourceId + ".", exception);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().isEmpty()) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.isEmpty()) {
                return null;
            }

            for (int index = 0; index < extensionCharacters.length(); index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
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

具體產生的檔案取決於投影片內容與匯出選項。例如，點陣圖通常會匯出為 JPEG 或 PNG。當產生較小或較適合的檔案時，Aspose.Slides 可能會選擇不同於來源投影片的影像編解碼器。具備透明度的影像則會以 PNG 匯出。

## **部署時的 URL 選擇**

範例使用相對 URL 前綴：`assets/`。若 `presentation.html` 從 `html-output/presentation.html` 開啟，瀏覽器會載入 `html-output/assets/resource-1.svg`。

當一個連結資源引用另一個連結資源時，範例在 [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 中使用 `referrer` 參數，僅回傳檔名。例如，若 `resource-1.svg` 與 `resource-4.jpg` 均位於 `assets` 資料夾，SVG 檔應該引用 `resource-4.jpg`，而不是 `assets/resource-4.jpg`。

若檔案部署於其他位置，請使用不同的 URL 前綴：

- 資產目錄與 HTML 檔案相鄰時，使用 `assets/`。
- 資產目錄位於 HTML 檔案上層一層時，使用 `../assets/`。
- 檔案上傳至 CDN 或靜態檔案伺服器時，使用 `https://cdn.example.com/presentations/job-123/assets/`。

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 回傳的 URL 必須與 [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 寫入的最終部署位置相符。在伺服器應用程式中，請為每個轉換工作使用唯一的輸出目錄或物件儲存前綴，以免覆寫其他匯出的檔案。

## **何時改為嵌入**

當必須將輸出做成單一檔案（例如電子郵件附件、離線預覽，或需在沒有支援資產資料夾的情況下移動的文件）時，仍可使用嵌入的 Base64 HTML。若 HTML 會由 Web 應用程式提供、存放於 CMS、經過建置管線最佳化，或需由瀏覽器獨立快取，則使用連結資源較為適合。

## **常見問答**

**我可以只將影像外部化，而保留其他資源嵌入嗎？**

可以。在 [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinkembedcontroller/) 中，對想要另存為檔案的內容類型回傳 `LinkEmbedDecision.Link`，對其他全部回傳 `LinkEmbedDecision.Embed`。

**為何匯出的影像副檔名與來源投影片不同？**

Aspose.Slides 可能在 HTML 匯出時重新編碼點陣圖，以提升檔案大小或瀏覽器相容性。例如，來源檔案中的影像可能依據最終渲染結果被寫入為 JPEG 或 PNG。

**搬移 HTML 檔後相對 URL 仍然有效嗎？**

相對 URL 只在保留相同的相對資料夾結構時才會有效。若 HTML 參考 `assets/resource-1.png`，則 `assets` 資料夾必須與 HTML 檔案同階層，除非您產生不同的 URL 前綴。

**伺服器應用程式可以重複使用相同的輸出資料夾嗎？**

不能。請為每個轉換工作使用唯一的輸出目錄或儲存前綴，避免檔名衝突並防止一次匯出覆寫其他匯出的資源。