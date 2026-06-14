---
title: 匯出簡報為 HTML 並使用外部連結圖片
type: docs
weight: 100
url: /zh-hant/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- 連結圖片
- 外部連結圖片
- 連結資源
- 外部資源
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Java 及 Aspose.Slides，將 PowerPoint 與 OpenDocument 簡報匯出為 HTML，圖片與其他資源會儲存為外部連結檔案。"
---
## **概觀**

預設情況下，Aspose.Slides 會將簡報匯出為單一的 HTML 檔案。圖片與其他資源會直接寫入 HTML，通常以 Base64 資料形式呈現。當您需要一個可攜帶的檔案時這很方便，但對於 Web 檢視、CMS 或之後發布輸出的伺服器端轉換流程而言，未必是最佳格式。

在以下情況下請使用外部連結資源：

- 減少 HTML 文件的大小；
- 在瀏覽器或 CDN 中單獨快取圖片、字型、音訊或影片；
- 匯出後檢查、取代、壓縮或後處理產生的資源；
- 讓輸出結構更接近 Web 應用程式的預期。

一般的 HTML 轉換工作流程，請參閱[Convert PowerPoint Presentations to HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/)。本文聚焦於匯出的資源連結部分。

## **連結資源匯出的運作方式**

[ILinkEmbedController](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilinkembedcontroller/) 讓您的應用程式逐一決定每個資源是嵌入於 HTML，還是另存為外部檔案並寫入連結。

此介面包含三個方法：

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilinkembedcontroller/) 決定資源應該被連結或嵌入。
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilinkembedcontroller/) 回傳要寫入產生的 HTML 或其他連結資源的 URL。
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilinkembedcontroller/) 將連結資源的資料寫入磁碟或其他儲存目標。

檔案系統路徑與瀏覽器 URL 是不同的概念。例如，下列示範會將資源檔案寫入應用程式檔案儲存區的 `html-output/assets`，而 HTML 內則包含 `assets/resource-1.svg` 等相對 URL。瀏覽器會以包含連結的檔案為基準解析這些 URL。因此，`presentation.html` 到 SVG 檔案的連結使用 `assets/resource-1.svg`，而該 SVG 檔案再連結同一 `assets` 資料夾內的圖片時，則使用 `resource-4.jpg`。

## **使用連結資源匯出 HTML**

以下 Android Java 範例會建立輸出目錄、將 HTML 檔案儲存在該目錄，並將連結資源存放於 `assets` 子目錄。請將 `context.getFilesDir()` 等應用程式擁有的目錄傳入 `applicationFilesDirectory`。程式碼避免使用 `java.nio.file` API，以維持 Android `minSdk` 19 的相容性。

控制器會在 Aspose.Slides 提供或能推斷安全副檔名時，連結常見的圖片、字型、音訊、影片與 CSS 資源。未被辨識的資源仍會以嵌入方式處理。

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
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
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
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

實際產生的檔案會依簡報內容與匯出選項而異。例如，點陣圖通常會匯出為 JPEG 或 PNG。Aspose.Slides 可能會選擇不同於來源簡報的影像編解碼方式，以獲得較小或較適合的檔案。具有透明度的圖片會匯出為 PNG。

## **部署時的 URL 選擇**

範例使用相對 URL 前置字串 `assets/`。若 `presentation.html` 位於 `html-output/presentation.html`，瀏覽器會載入 `html-output/assets/resource-1.svg`。

當一個連結資源引用另一個連結資源時，範例在[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilinkembedcontroller/) 中使用 `referrer` 參數，僅回傳檔名。例如，若 `resource-1.svg` 與 `resource-4.jpg` 同在 `assets` 資料夾，SVG 檔案應該引用 `resource-4.jpg`，而非 `assets/resource-4.jpg`。

若檔案部署於其他位置，請使用不同的 URL 前置字串：

- 資產目錄與 HTML 檔案相鄰時使用 `assets/`。
- 資產目錄位於 HTML 檔案上一層時使用 `../assets/`。
- 若檔案上傳至 CDN 或靜態檔案伺服器，使用 `https://cdn.example.com/presentations/job-123/assets/`。

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilinkembedcontroller/) 回傳的 URL 必須與 [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilinkembedcontroller/) 所寫入檔案的最終部署位置相符。於 Android 應用程式中，可使用應用程式專屬儲存、快取目錄，或依發佈工作流程透過儲存存取框架取得的目錄。於伺服器應用程式中，請為每一次轉換工作使用唯一的輸出目錄或物件儲存前置字串，以避免覆寫其他匯出的檔案。

## **何時應改為嵌入**

當輸出必須為單一檔案時（例如電子郵件附件、離線預覽，或需在沒有資產資料夾的情況下移動的文件），仍可使用嵌入 Base64 的 HTML。若 HTML 將由 Web 應用程式提供、儲存在 CMS、經過建置管線最佳化，或希望瀏覽器獨立快取資源，則連結資源較為合適。

## **常見問題集**

**我可以只將圖片外部化，而保留其他資源嵌入嗎？**

可以。於[ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilinkembedcontroller/) 中，對想要另存為獨立檔案的內容類型回傳 `Link`（屬於 [LinkEmbedDecision](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/linkembeddecision/)），其餘則回傳 `Embed`。

**為什麼匯出的圖片副檔名與來源簡報不同？**

Aspose.Slides 可能在 HTML 匯出過程中重新編碼點陣圖，以縮小尺寸或提升瀏覽器相容性。例如，來源檔案中的圖片可能會依最終渲染結果寫入為 JPEG 或 PNG。

**搬移 HTML 檔案後相對 URL 仍然有效嗎？**

相對 URL 僅在相同的相對資料夾結構被保留時有效。若 HTML 仍引用 `assets/resource-1.png`，則 `assets` 資料夾必須保持在 HTML 檔案旁，除非您產生了不同的 URL 前置字串。

**我可以在 Android 上將資源寫入公共外部儲存嗎？**

可以，只要您的應用程式對目標 Android 版本具備有效的目的地與權限模型。對於僅供應用程式使用的產生 HTML，使用應用程式專屬檔案或快取目錄通常較為簡易。若是供使用者可見的輸出，請使用使用者選取的位置或其他符合您應用程式的儲存方式。

**伺服器應用程式應該重複使用相同的輸出資料夾嗎？**

不應。請為每一次轉換工作使用唯一的輸出目錄或儲存前置字串。這可避免檔名衝突，並防止一個匯出覆寫另一個匯出的資源。