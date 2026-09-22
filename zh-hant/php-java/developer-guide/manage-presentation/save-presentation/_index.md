---
title: 在 PHP 中儲存簡報
linktitle: 儲存簡報
type: docs
weight: 80
url: /zh-hant/php-java/save-presentation/
keywords:
- 儲存 PowerPoint
- 儲存 OpenDocument
- 儲存簡報
- 儲存投影片
- 儲存 PPT
- 儲存 PPTX
- 儲存 ODP
- 簡報至檔案
- 簡報至串流
- 預定義檢視類型
- Strict Office Open XML 格式
- Zip64 模式
- 刷新縮圖
- 儲存進度
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 將 PowerPoint 與 OpenDocument 簡報儲存為檔案或串流，並設定 PPTX 輸出與進度報告。"
---
## **概觀**

在您建立簡報或[開啟現有簡報](/slides/zh-hant/php-java/open-presentation/)之後，使用[Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save)方法寫入結果。Aspose.Slides for PHP via Java 可以將簡報儲存為檔案或串流，支援 PowerPoint、OpenDocument、PDF 等格式。以下各節說明標準儲存操作以及 PPTX 輸出的相關選項。

## **將簡報儲存為檔案**

要將簡報儲存為檔案，將輸出路徑和[SaveFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/)值傳遞給[Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save)方法。格式值決定 Aspose.Slides 產生的檔案類型。

以下範例建立簡報並將其儲存為 PPTX 檔案：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // 在此新增或修改簡報內容。

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **以原始格式儲存簡報**

有關檔案與串流偵測範例、新建立簡報的行為，以及來源與輸出格式的區別，請參閱[Determine the Original Presentation Format](/slides/zh-hant/php-java/detect-presentation-source-format/)。

在批次處理應用程式中，輸入格式可能事先未知。載入檔案後，從[Presentation::getSourceFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getSourceFormat)方法讀取其原始格式。將取得的[SourceFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sourceformat/)值傳遞給[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideutil/#toSaveFormat)以取得對應的[SaveFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/)值，然後使用[Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save)寫入已修改的簡報。

以下完整範例會處理輸入目錄中的每個檔案，更新其標題，並以載入時的格式儲存至輸出目錄：

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideutil/#toSaveFormat) 將 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 及 PowerPoint XML 對映到相應的簡報儲存格式。它僅對簡報來源格式進行對映；不適用於選取如 PDF、HTML、TIFF 或影像等匯出格式。傳遞不支援或無效的[SourceFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sourceformat/)值會導致[IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html)。

舊版 PPT、PPS 與 POT 檔案使用相同的二進位容器。若此類簡報從沒有副檔名的串流載入，PPS 或 POT 檔可能會被識別為 PPT。若需要保留這些舊版子類型，請另行保留原始檔名或格式中繼資料，並在選擇輸出檔名與格式時使用它。

## **將簡報儲存至串流**

要在不依賴最終檔案路徑的情況下寫入簡報，將可寫入的串流和[SaveFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/)值傳遞給[Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save)方法。此方法在需要從 Web 服務返回輸出、儲存至資料庫或在記憶體中處理時很有用。

以下範例將新簡報儲存至檔案串流：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **以預先定義的檢視類型儲存簡報**

您可以指定 PowerPoint 開啟已儲存簡報時的檢視。於儲存前，使用[ViewProperties::setLastView](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/#setLastView)方法搭配[ViewType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewtype/)值。

以下範例將投影片母片檢視設定為初始檢視：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **以 Strict Office Open XML 格式儲存簡報**

若要建立符合 Office Open XML Strict 檔案描述（Strict）設定檔的 PPTX 檔，建立[PptxOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxoptions/)實例，並使用其[PptxOptions::setConformance](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxoptions/#setConformance)方法搭配[Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/conformance/#Iso29500-2008-Strict)。然後將選項傳遞給[Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save)方法。

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **以 Zip64 模式在 Office Open XML 格式中儲存簡報**

標準 ZIP 壓縮檔對每個條目的壓縮與未壓縮大小、整個壓縮檔總大小及條目數量都有上限。由於 PPTX 檔即為 ZIP 壓縮檔，極大型簡報可能會超過這些上限。ZIP64 延伸可提升相關大小與條目數限制。

使用[PptxOptions::setZip64Mode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxoptions/#setZip64Mode)方法可控制 Aspose.Slides 是否寫入 ZIP64 延伸：

- [IfNecessary](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/zip64mode/#IfNecessary) 只在簡報超出標準 ZIP 限制時使用 ZIP64。這是預設模式。
- [Never](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/zip64mode/#Never) 停用 ZIP64 延伸。
- [Always](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/zip64mode/#Always) 總是寫入 ZIP64 延伸。

以下範例總是為輸出簡報啟用 ZIP64 延伸：

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
如果使用[Zip64Mode::Never](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/zip64mode/#Never)且簡報無法適應標準 ZIP 限制，儲存作業會拋出[PptxException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以壓縮等級在 Office Open XML 格式中儲存簡報**

對於 PPTX 輸出，您可以透過使用[PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxoptions/#setCompressionLevel)方法，在儲存速度與檔案大小之間取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/)類別提供以下值：

- [None](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#None) 不使用壓縮儲存資料。
- [Level1](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level1) 提供最快的壓縮與最大的壓縮後檔案。
- [Level2](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level2) 至 [Level5](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level5) 逐步偏好較小的輸出而犧牲儲存速度。
- [Level6](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level6) 在儲存速度與檔案大小之間取得平衡。這是預設等級。
- [Level7](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level7) 與 [Level8](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level8) 進一步偏好較小的輸出而犧牲儲存速度。
- [Level9](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level9) 提供最強的壓縮，且需要最長的處理時間。

以下範例以不壓縮的方式儲存簡報：

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

以下範例使用最高壓縮等級：

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **儲存簡報時不重新整理縮圖**

當簡報以 PPTX 儲存時，[PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 方法控制其文件縮圖：

- `true` 在儲存過程中重新產生縮圖。這是預設值。
- `false` 保留現有縮圖。若簡報沒有縮圖，Aspose.Slides 不會產生。

以下範例將簡報儲存時不重新整理縮圖：

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
停用縮圖刷新可以縮短儲存 PPTX 檔所需的時間。
{{% /alert %}}

## **以百分比方式儲存進度更新**

若要監控儲存作業，提供實作[IProgressCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprogresscallback/) 介面的 Java 代理，並將代理傳遞給[SaveOptions::setProgressCallback](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveoptions/#setProgressCallback) 方法。Aspose.Slides 隨後會在匯出期間呼叫[IProgressCallback::reporting](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprogresscallback/#reporting-double-) 方法，傳遞進度值。

以下範例將 PDF 匯出的進度報告至主控台：

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose 提供一個免費的[PowerPoint Splitter](https://products.aspose.app/slides/zh-hant/splitter) ，使用 Aspose.Slides API 建置。它可將簡報中的選取投影片另存為單獨的 PPT 或 PPTX 檔案。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援增量或「快速儲存」嗎？**

不支援。每次儲存作業都會寫入完整的輸出檔案，而非僅更新變更的部分。

**多執行緒能儲存同一個 Presentation 實例嗎？**

不行。`[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)` 實例 **未具備執行緒安全**。每次只能由單一執行緒存取與儲存該實例。

**儲存簡報時，超連結與外部連結檔案會發生什麼情況？**

[超連結](/slides/zh-hant/php-java/manage-hyperlinks/) 仍保留在簡報中。Aspose.Slides 不會複製外部連結的檔案，因此儲存後的簡報仍必須能夠存取其原始位置。

**我能儲存文件的中繼資料（例如作者、標題、公司與建立日期）嗎？**

可以。在儲存前設定適當的[文件屬性](/slides/zh-hant/php-java/presentation-properties/)，Aspose.Slides 會將它們寫入輸出檔案。