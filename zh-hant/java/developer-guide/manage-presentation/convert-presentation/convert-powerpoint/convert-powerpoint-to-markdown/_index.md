---
title: 在 Java 中將 PowerPoint 簡報轉換為 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/java/convert-powerpoint-to-markdown/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 MD
- 簡報轉 MD
- 投影片轉 MD
- PPT 轉 MD
- PPTX 轉 MD
- 將 PowerPoint 儲存為 Markdown
- 將簡報儲存為 Markdown
- 將投影片儲存為 Markdown
- 將 PPT 儲存為 MD
- 將 PPTX 儲存為 MD
- 匯出 PPT 為 MD
- 匯出 PPTX 為 MD
- Markdown 影像匯出
- CDN 影像連結
- PowerPoint
- 簡報
- Markdown
- Java
- Aspose.Slides
description: "在 Java 中將 PPT 與 PPTX 簡報轉換為 Markdown，並控制匯出之點陣圖、圖形檔與 SVG 影像的儲存位置與引用方式。"
---
## **概覽**

Aspose.Slides for Java 可以將 PPT 與 PPTX 簡報轉換為 Markdown，以支援文件編寫、靜態網站、內容遷移以及版本控制工作流程。您可以選擇 Markdown 風格、控制投影片內容的呈現方式，並決定匯出影像的儲存位置以及產生的 Markdown 如何引用它們。

預設情況下，Markdown 匯出僅產生文字輸出。若要匯出視覺內容，請使用 [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 方法將匯出類型設定為 [MarkdownExportType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownexporttype/) 列舉中的 `Sequential` 或 `Visual` 值。`Sequential` 會依序分開呈現投影片項目，而 `Visual` 則會將分組的項目保留在一起，以維持其視覺關係。`TextOnly` 值不會產生影像資源，因而不會呼叫影像儲存回呼。

## **將簡報轉換為 Markdown**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別載入來源檔案，然後呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 方法，並以 [SaveFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/) 列舉中的 `Md` 值指定輸出格式。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **選取 Markdown 風格**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 方法控制輸出所使用的 Markdown 規範。[Flavor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/flavor/) 列舉包含 CommonMark、GitHub Flavored Markdown 與其他受支援的變體。

以下範例將簡報匯出為 CommonMark：

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **使用預設本機儲存行為匯出影像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 類別提供兩個方法以配置本機儲存的影像：

- [setBasePath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 指定 Markdown 文件與其資源的基礎目錄。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 指定影像子目錄，其預設值為 `Images`。

以下範例會渲染視覺內容、將影像寫入 `output/assets`，並在 Markdown 文件中建立相對影像引用：

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

當自訂的影像儲存處理常式回傳 `false` 時，亦會使用此行為作為備援。

## **自訂影像儲存與 Markdown 連結**

使用 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 方法註冊回呼，以處理在 Markdown 匯出期間產生的非 SVG 點陣圖與圖形檔資源。其 `MarkdownImageSavingHandler` 回呼會收到 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 物件、其 [ImageFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imageformat/) 值，以及以單一元素 `String[]` 參數傳遞的產生的 Markdown 連結。您可以使用提供的格式儲存或上傳影像，並以 `link[0]` 取代必須寫入 Markdown 輸出的參照。

以 SVG 格式產生的資源會單獨處理。請使用 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 方法註冊回呼。其 `MarkdownSvgImageSavingHandler` 回呼會收到一個 [ISvgImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/) 物件與單一元素的 `String[] link` 參數。SVG 沒有 `ImageFormat` 參數；請改從 [ISvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/) 方法取得 XML 資料並寫入或上傳。根據匯出模式與視覺分組，來源簡報中的 SVG 可能會被光柵化或與其他內容合併；最終的非 SVG 資源會傳遞給影像儲存回呼。當每個匯出的視覺資源都需要自訂處理時，請同時註冊這兩個回呼。

處理常式的回傳值決定由誰處理影像：

- 回傳 `true` 表示處理常式已完成儲存、上傳、轉換或其他處理，且已為 `link[0]` 指定有效值。Aspose.Slides 會將該值寫入 Markdown 文件，且不會執行預設的本機儲存。
- 回傳 `false` 讓 Aspose.Slides 依照 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 與 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 的設定，於本機儲存影像並產生其連結。

{{% alert color="warning" title="Important" %}}
回傳 `true` 的處理常式必須負責影像。如果它回傳 `true` 卻未為 `link[0]` 指定有效且非空的連結，匯出將拋出 `InvalidOperationException`。
{{% /alert %}}

### **將影像儲存至 CDN 原始目錄並使用外部 URL**

以下範例將 `cdn-origin/presentations/quarterly-report` 視為已掛載或同步的 CDN 原始目錄。每個處理常式會擷取產生的檔名，將影像儲存至該自訂目錄，並以公開的 CDN URL 取代產生的本機參照。範例本身不會執行網路上傳：只有在目錄實際掛載為 CDN 原始端或檔案已發布至 CDN 後，該 URL 才會生效。若使用物件儲存，請以儲存 SDK 的上傳操作取代檔案系統寫入，並在上傳成功後才為 `link[0]` 指定值。

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

點陣圖處理常式會對小於 128 × 128 像素的影像刻意回傳 `false`，因此 Aspose.Slides 會使用預設行為將這些影像儲存於 `output/fallback-images`。較大的點陣圖、圖形檔資源以及 SVG 資源則由自訂程式碼處理。例如，產生的本機參照 `fallback-images/image1.png` 會變為 `https://cdn.example.com/presentations/quarterly-report/image1.png`。處理常式僅在寫入檔案時使用作業系統路徑；寫入 Markdown 的連結使用正斜線 `/` 以及 URL 編碼的檔名。建立相對連結時亦遵循此規則：使用 `/`，而非平台特定的目錄分隔符。

## **常見問題**

**是否可以使用同一個處理常式同時處理點陣圖與 SVG 影像？**

不行。請使用 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 處理產生的點陣圖與圖形檔資源，並使用 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 處理以 SVG 產生的資源。前者會提供 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 物件與 [ImageFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imageformat/) 值；後者會提供 [ISvgImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/) 物件，可透過 [ISvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/) 讀取 SVG 資料。若來源 SVG 在匯出時被光柵化，則會交由影像儲存回呼處理。

**當影像儲存處理常式回傳 `false` 時會發生什麼事？**

Aspose.Slides 會採用預設的本機儲存行為。影像的存放位置與產生的參照由 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 與 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/markdownsaveoptions/) 的設定決定。

**處理常式可以只提供 URL 而不在本機儲存影像嗎？**

可以。處理常式可以將影像上傳至物件儲存或傳遞給其他服務，將得到的 URL 指派給 `link[0]`，然後回傳 `true`。回傳 `true` 表示處理常式已完成所有處理，預設的本機儲存將不會執行。

**為什麼 Markdown 匯出會因處理常式拋出 `InvalidOperationException`？**

當處理常式回傳 `true` 但未提供有效的連結時就會拋出此例外。請在回傳 `true` 之前，先將應寫入 Markdown 的相對路徑或外部 URL 指派給 `link[0]`。

**影像連結應使用哪種路徑分隔符？**

在 Markdown 連結與 URL 中使用正斜線 `/`。僅在檔案系統路徑上使用 `Path.resolve` 等方法，然後再自行建立或正規化 Markdown 參照。

**在 Markdown 匯出時超連結會被保留嗎？**

會。文字 [hyperlinks](/slides/zh-hant/java/manage-hyperlinks/) 會保留為標準的 Markdown 連結。投影片的 [transitions](/slides/zh-hant/java/slide-transition/) 與 [animations](/slides/zh-hant/java/powerpoint-animation/) 則不會被轉換。

**可以平行轉換多個簡報為 Markdown 嗎？**

可以同時處理多個簡報檔案，但不要在執行緒間共用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 實例。請遵循 [multithreading guidelines](/slides/zh-hant/java/multithreading/) 並為每個檔案使用獨立的實例。