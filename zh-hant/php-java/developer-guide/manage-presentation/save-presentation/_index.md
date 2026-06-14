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
- 預先定義的檢視類型
- Strict Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- PHP
- Aspose.Slides
description: "探索如何使用 Aspose.Slides for PHP（透過 Java）儲存簡報 — 匯出為 PowerPoint 或 OpenDocument，同時保留版面配置、字型與效果。"
---
## **概覽**

[在 PHP 中開啟簡報](/slides/zh-hant/php-java/open-presentation/) 描述了如何使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別開啟簡報。本文說明如何建立與儲存簡報。[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別包含簡報的內容。無論是從頭建立簡報或是修改現有簡報，完成後都需要將其儲存。使用 Aspose.Slides for PHP，您可以儲存為 **檔案** 或 **串流**。本文說明儲存簡報的不同方式。

## **將簡報儲存為檔案**

透過呼叫 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的 `save` 方法將簡報儲存為檔案。將檔名與儲存格式傳遞給該方法。以下範例示範如何使用 Aspose.Slides 儲存簡報。

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 在此執行一些工作...

    // 將簡報儲存到檔案。
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **將簡報儲存為串流**

您可以將輸出串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的 `save` 方法，以將簡報儲存為串流。簡報可以寫入多種串流類型。以下範例建立新的簡報並將其儲存為檔案串流。

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // 將簡報儲存至串流。
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **以預先定義的檢視類型儲存簡報**

Aspose.Slides 讓您透過 [ViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/) 類別設定產生的簡報開啟時 PowerPoint 使用的初始檢視。使用 [setLastView](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/#setLastView) 方法，傳入 [ViewType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewtype/) 列舉中的值。

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **以 Strict Office Open XML 格式儲存簡報**

Aspose.Slides 允許您以 Strict Office Open XML 格式儲存簡報。儲存時使用 [PptxOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxoptions/) 類別並設定其 conformance 屬性。若設定為 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/conformance/#Iso29500_2008_Strict)，輸出檔案將以 Strict Office Open XML 格式儲存。

以下範例建立簡報並以 Strict Office Open XML 格式儲存。

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 將簡報儲存為 Strict Office Open XML 格式。
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **以 Zip64 模式儲存 Office Open XML 格式的簡報**

Office Open XML 檔案是一個 ZIP 壓縮檔，對任何檔案的未壓縮大小、壓縮後大小以及整個封存檔的總大小皆限制在 4 GB (2^32 位元組)，且檔案數量上限為 65,535 (2^16‑1) 個。ZIP64 格式擴充可將這些限制提升至 2^64。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxoptions/#setZip64Mode) 方法讓您在儲存 Office Open XML 檔案時選擇是否使用 ZIP64 格式擴充。

此方法可搭配以下模式使用：

- [IfNecessary](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/zip64mode/#IfNecessary) 僅在簡報超過上述限制時使用 ZIP64 格式擴充。這是預設模式。
- [Never](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/zip64mode/#Never) 永不使用 ZIP64 格式擴充。
- [Always](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/zip64mode/#Always) 總是使用 ZIP64 格式擴充。

以下程式碼示範如何以啟用 ZIP64 格式擴充的方式儲存 PPTX 簡報：

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
當使用 [Zip64Mode.Never](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/zip64mode/#Never) 儲存時，如果簡報無法以 ZIP32 格式儲存，將拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **儲存簡報時不重新整理縮圖**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 方法控制儲存簡報為 PPTX 時縮圖的產生方式：

- 若設定為 `true`，儲存期間將重新整理縮圖。這是預設值。
- 若設定為 `false`，保留目前的縮圖。若簡報沒有縮圖，則不會產生。

以下程式碼將簡報儲存為 PPTX，且不重新整理縮圖。

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
此選項有助於減少儲存 PPTX 格式簡報所需的時間。
{{% /alert %}}

## **以百分比形式儲存進度更新**

儲存進度報告可透過在 [SaveOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveoptions/) 及其子類別上使用 [setProgressCallback](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveoptions/#setProgressCallback) 方法來設定。提供實作 [IProgressCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprogresscallback/) 介面的 Java 代理；匯出過程中，回呼會定期收到百分比更新。

以下程式碼片段示範如何使用 `IProgressCallback`。

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // 在此使用進度百分比值。
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose 已開發一款使用其 API 的 [免費 PowerPoint Splitter 應用程式](https://products.aspose.app/slides/zh-hant/splitter)。此應用程式可透過將選取的投影片另存為新的 PPTX 或 PPT 檔案，將簡報分割成多個檔案。
{{% /alert %}}

## **常見問題**

**是否支援「快速儲存」（增量儲存）僅寫入變更？**

否。每次儲存皆會產生完整的目標檔案，未支援增量的「快速儲存」。

**從多個執行緒同時儲存相同的 Presentation 實例是否為執行緒安全？**

否。`[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)` 實例 **不是執行緒安全** 的；請於單一執行緒中進行儲存。

**儲存時超連結與外部連結的檔案會發生什麼情況？**

`[Hyperlinks](/slides/zh-hant/php-java/manage-hyperlinks/)` 會被保留。外部連結的檔案（例如使用相對路徑的影片）不會自動複製——請確保所引用的路徑仍可存取。

**我可以設定/儲存文件中繼資料（作者、標題、公司、日期）嗎？**

可以。支援標準的 `[document properties](/slides/zh-hant/php-java/presentation-properties/)`，且在儲存時會寫入檔案。