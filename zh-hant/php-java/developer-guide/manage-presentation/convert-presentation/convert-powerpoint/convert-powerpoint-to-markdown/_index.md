---
title: 在 PHP 中將 PowerPoint 簡報轉換為 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/php-java/convert-powerpoint-to-markdown/
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
- 将投影片儲存為 Markdown
- 將 PPT 儲存為 MD
- 將 PPTX 儲存為 MD
- 匯出 PPT 為 MD
- 匯出 PPTX 為 MD
- Markdown 影像匯出
- CDN 影像連結
- PowerPoint
- 簡報
- Markdown
- PHP
- Aspose.Slides
description: "在 PHP 中將 PPT 與 PPTX 簡報轉換為 Markdown，並控制匯出之點陣圖、圖形檔與 SVG 影像的儲存位置與引用方式。"
---
## **概覽**

Aspose.Slides for PHP via Java 可以將 PPT 和 PPTX 簡報轉換為 Markdown，以用於文件編寫、靜態網站、內容遷移和版本控制工作流程。您可以選擇 Markdown 風格、控制投影片內容的呈現方式，並決定匯出影像的儲存位置以及產生的 Markdown 如何引用它們。

預設情況下，Markdown 匯出僅使用文字輸出。若要匯出視覺內容，請使用 [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 方法將匯出類型設定為 [MarkdownExportType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownexporttype/) 列舉中的 `Sequential` 或 `Visual` 值。`Sequential` 會分別且按順序呈現投影片項目，而 `Visual` 則將分組項目保留在一起，以維持其視覺關係。`TextOnly` 值不會產生影像資源，於是此模式下不會呼叫影像儲存回呼函式。

## **將簡報轉換為 Markdown**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別載入來源檔案，然後以 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 方法，傳入來自 [SaveFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/) 列舉的 `Md` 值來儲存。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **選擇 Markdown 風格**

[MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 方法控制輸出使用的 Markdown 規範。[Flavor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/flavor/) 列舉包含 CommonMark、GitHub Flavored Markdown 以及其他支援的變體。

以下範例將簡報匯出為 CommonMark：

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **使用預設本機儲存行為匯出影像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 類別提供兩個方法，用於設定本機儲存的影像：

- [setBasePath](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 指定 Markdown 文件及其資源的基礎目錄。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 指定影像子目錄。其預設值為 `Images`。

以下範例渲染視覺內容，將影像寫入 `output/assets`，並在 Markdown 文件中建立相對影像引用：

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

當自訂影像儲存回呼函式傳回 `false` 時，此行為亦作為備援。

## **自訂影像儲存與 Markdown 連結**

使用 [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 方法註冊一個回呼，以處理 Markdown 匯出期間產生的非 SVG 位圖和中繪檔資源。其 `MarkdownImageSavingHandler` 回呼會收到 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 物件、其 [ImageFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imageformat/) 值，以及以單元素 Java 字串陣列形式的產生的 Markdown 連結。使用提供的格式儲存或上傳影像，並將 `$link[0]` 替換為必須出現在 Markdown 輸出中的參照。

以 SVG 格式產生的資源會另行處理。請使用 [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 方法註冊回呼。其 `MarkdownSvgImageSavingHandler` 回呼會收到一個 [ISvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/isvgimage/) 物件，以及單元素 Java 字串陣列 `$link`。SVG 不具備 `ImageFormat` 參數；請改從 [ISvgImage::getSvgData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/isvgimage/) 方法取得其 XML 資料後寫入或上傳。根據匯出模式與視覺分組，來源簡報中的 SVG 可能會被光柵化或與其他內容合併；產生的非 SVG 資源隨後會傳遞給影像儲存回呼函式。當每個匯出的視覺資源皆需自訂處理時，請同時註冊兩個回呼。

在 PHP via Java 中，於 PHP 類別中實作每個回呼，並使用 `java_closure` 將該物件公開為相應的 Java 介面。

{{% alert color="info" title="Note" %}}
在載入 `Java.inc` 之前，請以啟用 `JAVA_PREFER_VALUES` 的方式初始化 PHP/Java Bridge。[Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 方法不返回值 (`void`)，且橋接的預設串流模式無法在排隊呼叫期間呼叫 PHP 回呼。以下完整範例已包含所需的初始化。
{{% /alert %}}

回呼的返回值決定誰來處理影像：

- 在回呼完成影像的儲存、上傳、轉換或其他處理，且已為 `$link[0]` 指定有效值之後，回傳 `true`。Aspose.Slides 會將該值寫入 Markdown 文件，且不執行預設的本機儲存。
- 回傳 `false`，讓 Aspose.Slides 依照 [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 與 [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 的設定，於本機儲存影像並產生其連結。

{{% alert color="warning" title="Important" %}}
回傳 `true` 的回呼將承擔影像的責任。若回傳 `true` 卻未為 `$link[0]` 指定有效且非空的連結，則匯出會因 `InvalidOperationException` 而失敗。
{{% /alert %}}

### **將影像儲存至 CDN 原始目錄並使用外部 URL**

以下範例將 `cdn-origin/presentations/quarterly-report` 視為已掛載或同步的 CDN 原始目錄。每個回呼會擷取產生的檔名，將影像儲存至該自訂目錄，並將產生的本機參照替換為公開的 CDN URL。此範例本身不執行網路上傳：只有在目錄被掛載為 CDN 原始端或其檔案已發布至 CDN 後，URL 才會有效。如使用物件儲存，請以儲存 SDK 的上傳作業取代檔案系統寫入，並在上傳成功後才為 `$link[0]` 指定值。

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

位圖回呼故意對小於 128 × 128 像素的影像回傳 `false`，因此 Aspose.Slides 會使用預設行為將這些影像儲存至 `output/fallback-images`。較大的位圖與中繪檔資源，以及 SVG 資源，則由自訂程式碼處理。例如，產生的本機參照 `fallback-images/image1.png` 會變為 `https://cdn.example.com/presentations/quarterly-report/image1.png`。回呼僅在寫入檔案時使用作業系統路徑；寫入 Markdown 的連結則使用正斜線且檔名需 URL 編碼。建立相對連結時亦遵循相同規則：使用 `/`，而非平台特定的目錄分隔符。

## **常見問題**

**是否可以用同一回呼同時處理光柵影像與 SVG 影像？**

不行。請使用 [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 處理匯出的位圖與中繪檔資源，使用 [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 處理以 SVG 匯出的資源。前者會提供 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 物件與 [ImageFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imageformat/) 值；後者會提供 [ISvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/isvgimage/) 物件，可透過 [ISvgImage::getSvgData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/isvgimage/) 讀取其 SVG 資料。在匯出期間被光柵化的來源 SVG 會改由影像儲存回呼處理。

**當影像儲存回呼傳回 `false` 時會發生什麼情況？**

Aspose.Slides 會使用預設的本機儲存行為。影像位置與產生的參照由 [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 與 [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/markdownsaveoptions/) 的設定控制。

**回呼能否在不本機儲存影像的情況下提供 URL？**

可以。回呼可以將影像上傳至物件儲存或傳遞給其他服務，將產生的 URL 指派給 `$link[0]`，並回傳 `true`。回呼必須自行完成處理；回傳 `true` 會阻止預設的本機儲存。

**為何 Markdown 匯出會因回呼拋出 `InvalidOperationException`？**

當回呼回傳 `true` 卻未提供有效連結時，就會拋出此例外。請在回傳 `true` 之前，將應寫入 Markdown 的相對路徑或外部 URL 指派給 `$link[0]`。

**影像連結應使用哪種路徑分隔符？**

在 Markdown 連結與 URL 中使用正斜線。僅在檔案系統路徑中使用 `DIRECTORY_SEPARATOR`，然後另行建立或正規化 Markdown 參照。

**在 Markdown 匯出期間，超連結會被保留嗎？**

會。文字 [hyperlinks](/slides/zh-hant/php-java/manage-hyperlinks/) 會保留為標準的 Markdown 連結。投影片的 [transitions](/slides/zh-hant/php-java/slide-transition/) 與 [animations](/slides/zh-hant/php-java/powerpoint-animation/) 不會被轉換。

**可以平行將多個簡報轉換為 Markdown 嗎？**

可以平行處理不同的簡報檔案，但請勿在執行緒之間共享同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例。請遵循 [multithreading guidelines](/slides/zh-hant/php-java/multithreading/)，為每個檔案使用獨立的實例。