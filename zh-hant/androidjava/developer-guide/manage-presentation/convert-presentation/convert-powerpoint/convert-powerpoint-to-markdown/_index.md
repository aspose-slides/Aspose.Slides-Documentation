---
title: 在 Android 上將 PowerPoint 簡報轉換為 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/androidjava/convert-powerpoint-to-markdown/
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
- Android
- Java
- Aspose.Slides
description: "在 Android 上透過 Java 將 PPT 與 PPTX 簡報轉換為 Markdown，並控制匯出之點陣圖、圖形檔與 SVG 影像的儲存位置與引用方式。"
---
## **概述**

Aspose.Slides for Android via Java 能夠將 PPT 與 PPTX 簡報轉換為 Markdown，以用於文件編寫、靜態網站、內容遷移與版本控制的工作流程。您可以選擇 Markdown 的風格、控制投影片內容的呈現方式，並決定匯出影像的儲存位置以及產生的 Markdown 如何引用它們。

預設情況下，Markdown 匯出僅產生文字輸出。若要匯出視覺內容，請使用 [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 方法將匯出類型設定為 [MarkdownExportType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownexporttype/) 列舉中的 `Sequential` 或 `Visual` 值。`Sequential` 會將投影片項目分別且依序渲染，而 `Visual` 則會將分組的項目保持在一起，以保留它們的視覺關係。`TextOnly` 值不會產生影像資源，因而在此模式下不會呼叫影像儲存回呼。

## **將簡報轉換為 Markdown**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別載入來源檔案，然後呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 方法，傳入 [SaveFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/) 列舉中的 `Md` 值。

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

## **選擇 Markdown 風格**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 方法可控制輸出所使用的 Markdown 規範。[Flavor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/flavor/) 列舉包含 CommonMark、GitHub Flavored Markdown 以及其他支援的變體。

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

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 類別提供兩個方法，用於設定本機儲存的影像：

- [setBasePath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 指定 Markdown 文件及其資源的基礎目錄。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 指定影像子目錄。其預設值為 `Images`。

以下範例會渲染視覺內容，將影像寫入 `output/assets`，並在 Markdown 文件中建立相對影像引用：

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

當自訂的影像儲存回呼傳回 `false` 時，此行為亦會作為備援使用。

## **自訂影像儲存與 Markdown 連結**

使用 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 方法註冊回呼，以處理 Markdown 匯出期間產生的非 SVG 位圖與中繼檔資源。其 `MarkdownImageSavingHandler` 回呼會收到 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 物件、其 [ImageFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imageformat/) 值，以及以單一元素 `String[]` 參數形式提供的產生之 Markdown 連結。請以給定的格式儲存或上傳影像，並將 `link[0]` 替換為必須寫入 Markdown 輸出的參照。

以 SVG 格式產生的資源會另外處理。請使用 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 方法註冊回呼。其 `MarkdownSvgImageSavingHandler` 回呼會收到 [ISvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/) 物件以及單一元素 `String[] link` 參數。SVG 不具備 `ImageFormat` 參數；請改由 [ISvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/) 方法取得其 XML 資料並寫入或上傳。視匯出模式與視覺分組情況而定，來源簡報中的 SVG 可能會在匯出時被點陣化或與其他內容合併；產生的非 SVG 資源將傳遞給影像儲存回呼。當每個匯出的視覺資源皆需要自訂處理時，請同時註冊這兩個回呼。

回呼的返回值決定由誰處理影像：

- 在回呼已儲存、上傳、轉換或以其他方式處理影像，並將有效值指派給 `link[0]` 後，返回 `true`。Aspose.Slides 會將該值寫入 Markdown 文件，且不執行預設的本機儲存。
- 返回 `false`，則讓 Aspose.Slides 依照 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 與 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 設定的值，將影像本機儲存並產生其連結。

{{% alert color="warning" title="重要" %}}
回呼若返回 `true`，即代表它負責處理該影像。若返回 `true` 卻未指派有效且非空的連結，匯出將因 `InvalidOperationException` 而失敗。
{{% /alert %}}

### **將影像儲存至 CDN 原始目錄並使用外部 URL**

以下範例將 `cdn-origin/presentations/quarterly-report` 視為已掛載或同步的 CDN 原始目錄。每個回呼會擷取產生的檔名，將影像儲存至該自訂目錄，並將產生的本機參照替換為公用 CDN URL。此範例本身不會執行網路上傳：該 URL 只有在目錄已掛載為 CDN 原始點或其檔案已發布至 CDN 後才會有效。若使用物件儲存，請以儲存 SDK 的上傳操作取代檔案系統寫入，並在上傳成功後才指派 `link[0]`。

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

此位圖回呼會刻意對小於 128 × 128 像素的影像返回 `false`，因此 Aspose.Slides 會依預設行為將這些影像儲存至 `output/fallback-images`。較大的位圖與中繼檔資源，以及 SVG 資源，則交由自訂程式碼處理。例如，產生的本機參照 `fallback-images/image1.png` 會變成 `https://cdn.example.com/presentations/quarterly-report/image1.png`。回呼在寫入檔案時僅使用作業系統的路徑；寫入 Markdown 的連結則使用正斜線與 URL 編碼的檔名。建立相對連結時亦遵循相同規則：使用 `/`，而非平台特定的目錄分隔符。

## **常見問題**

**Can one handler process both raster images and SVG images?**

否。請使用 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 來處理匯出時產生的位圖與中繼檔資源，使用 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 來處理以 SVG 形式產生的資源。前者會提供 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 物件與 [ImageFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imageformat/) 值；後者會提供 [ISvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/) 物件，其 SVG 資料可透過 [ISvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/) 讀取。於匯出過程中被點陣化的來源 SVG 會改由影像儲存回呼處理。

**What happens when an image-saving handler returns `false`?**

Aspose.Slides 會使用預設的本機儲存行為。影像的儲存位置與產生的參照由 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 與 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/markdownsaveoptions/) 設定的值所控制。

**Can a handler provide a URL without saving the image locally?**

可以。回呼可以將影像上傳至物件儲存或傳遞給其他服務，將取得的 URL 指派給 `link[0]`，並返回 `true`。回呼必須自行完成處理；返回 `true` 會阻止預設的本機儲存。

**Why does Markdown export throw an `InvalidOperationException` from a handler?**

當回呼返回 `true` 卻未提供有效的連結時，就會拋出此例外。請在返回 `true` 前指派應寫入 Markdown 的相對路徑或外部 URL。

**Which path separator should image links use?**

在 Markdown 連結與 URL 中請使用正斜線。`Path.resolve` 僅用於檔案系統路徑，Markdown 參照則需另行建構或正規化。

**Are hyperlinks preserved during Markdown export?**

會。文字 [hyperlinks](/slides/zh-hant/androidjava/manage-hyperlinks/) 會保留為標準的 Markdown 連結。投影片的 [transitions](/slides/zh-hant/androidjava/slide-transition/) 與 [animations](/slides/zh-hant/androidjava/powerpoint-animation/) 則不會被轉換。

**Can presentations be converted to Markdown in parallel?**

可以同時處理多個不同的簡報檔案，但請勿在執行緒間共用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 實例。請遵循 [multithreading guidelines](/slides/zh-hant/androidjava/multithreading/)，為每個檔案使用獨立的實例。