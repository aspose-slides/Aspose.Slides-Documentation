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
- 簡報儲存為檔案
- 簡報儲存為串流
- 預先定義的檢視類型
- 嚴格 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP（透過 Java）儲存簡報 — 匯出為 PowerPoint 或 OpenDocument，同時保留版面配置、字型與效果。"
---
## **概述**

[在 PHP 中開啟簡報](/slides/zh-hant/php-java/open-presentation/) 介紹了如何使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別開啟簡報。本篇說明如何建立與儲存簡報。[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別包含簡報的內容。無論是從頭建立簡報或是修改現有簡報，完成後都需要將其儲存。使用 Aspose.Slides for PHP，您可以儲存至 **檔案** 或 **串流**。本篇說明儲存簡報的不同方式。

## **將簡報儲存為檔案**

透過呼叫 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的 `save` 方法，將簡報儲存為檔案。將檔名與儲存格式傳遞給此方法。以下範例示範如何使用 Aspose.Slides 儲存簡報。

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 在此執行一些工作...

    // 將簡報儲存至檔案。
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **將簡報儲存為串流**

您可以將輸出串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的 `save` 方法，以將簡報儲存至串流。簡報可以寫入多種串流類型。以下範例建立新簡報並將其儲存至檔案串流。

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

Aspose.Slides 讓您透過 [ViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/) 類別設定 PowerPoint 開啟產生的簡報時的初始檢視。使用 [setLastView](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/#setLastView) 方法，並傳入 [ViewType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewtype/) 列舉中的值。

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **以嚴格 Office Open XML 格式儲存簡報**

Aspose.Slides 允許您以嚴格的 Office Open XML 格式儲存簡報。使用 [PptxOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxoptions/) 類別，並在儲存時設定其 `conformance` 屬性。如果設定 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/conformance/#Iso29500_2008_Strict)，輸出檔案即會以嚴格 Office Open XML 格式儲存。

以下範例建立簡報並以嚴格 Office Open XML 格式儲存。

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 以嚴格 Office Open XML 格式儲存簡報。
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **以 Zip64 模式儲存 Office Open XML 格式的簡報**

Office Open XML 檔案是 ZIP 壓縮檔，對未壓縮檔案大小、壓縮後檔案大小以及壓縮檔總大小皆有限制為 4 GB（2^32 位元組），且檔案數量上限為 65 535（2^16‑1）個。ZIP64 格式擴充可將這些限制提升至 2^64。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxoptions/#setZip64Mode) 方法讓您在儲存 Office Open XML 檔案時選擇是否使用 ZIP64 格式擴充。

此方法可使用以下模式：

- [IfNecessary](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/zip64mode/#IfNecessary) 只在簡報超過上述限制時使用 ZIP64 格式擴充。這是預設模式。
- [Never](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/zip64mode/#Never) 永不使用 ZIP64 格式擴充。
- [Always](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/zip64mode/#Always) 總是使用 ZIP64 格式擴充。

以下程式碼示範如何以啟用 ZIP64 格式擴充的方式將簡報儲存為 PPTX 檔案：

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
當您使用 [Zip64Mode.Never](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/zip64mode/#Never) 儲存時，若簡報無法以 ZIP32 格式儲存，將拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以不同壓縮等級儲存 Office Open XML 格式的簡報**

處理大型簡報時，您可以調整壓縮等級以在檔案大小與處理速度之間取得平衡。根據需求，您可能會偏好較快的處理或較小的輸出檔案。

Aspose.Slides 提供 [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxoptions/#setCompressionLevel) 方法，允許您在以 Office Open XML 格式儲存簡報時指定壓縮等級。

可用的壓縮等級如下：

- [**None**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#None)：不進行壓縮。檔案以原始形式儲存。
- [**Level1**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level1)：最快的壓縮速度，但壓縮率最低。
- [**Level2**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level2)：較快的壓縮速度，壓縮率略高於 **Level1**。
- [**Level3**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level3)：相較 **Level2** 具更好壓縮率，處理時間適中。
- [**Level4**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level4)：比 **Level3** 更佳的壓縮率。
- [**Level5**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level5)：在 **Level4** 基礎上進一步提升壓縮率，需額外的處理時間。
- [**Level6**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level6)：標準壓縮，提供速度與檔案大小的良好平衡。這是 *預設壓縮等級*。
- [**Level7**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level7)：較 **Level6** 更佳的壓縮率，但處理較慢。
- [**Level8**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level8)：較 **Level7** 更佳的壓縮率。
- [**Level9**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compressionlevel/#Level9)：最高壓縮率。可產生最小檔案大小，但需最長的處理時間。

以下範例示範如何以 *未壓縮* 的方式將簡報儲存為 PPTX 檔案：

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

此範例示範如何以 *最高壓縮* 的方式將簡報儲存為 PPTX 檔案：

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **儲存簡報時不重新整理縮圖**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 方法控制儲存為 PPTX 時是否重新產生縮圖：

- 設為 `true` 時，儲存過程會重新整理縮圖（預設值）。
- 設為 `false` 時，保留現有縮圖。若簡報本身沒有縮圖，則不會產生任何縮圖。

以下程式碼示範將簡報儲存為 PPTX 且不重新整理縮圖。

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
此選項可減少將簡報儲存為 PPTX 格式所需的時間。
{{% /alert %}}

## **以百分比顯示儲存進度更新**

儲存進度回報透過在 [SaveOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveoptions/) 及其子類別上使用 [setProgressCallback](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveoptions/#setProgressCallback) 方法設定。提供實作 [IProgressCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprogresscallback/) 介面的 Java 代理；在匯出過程中，回呼會定期收到百分比更新。

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
Aspose 開發了免費的 PowerPoint 分割工具 (<https://products.aspose.app/slides/zh-hant/splitter>)，使用其 API。此應用程式可將簡報分割為多個檔案，透過將選取的投影片儲存為新 PPTX 或 PPT 檔案。
{{% /alert %}}

## **FAQ**

**是否支援「快速儲存」(增量儲存) 只寫入變更部分？**

不支援。每次儲存都會重新產生完整目標檔案，未提供增量「快速儲存」功能。

**從多個執行緒同時儲存同一個 Presentation 實例是否安全？**

不安全。`Presentation` 實例**不是執行緒安全**的；請在單一執行緒中執行儲存。

**儲存時會發生什麼事於超連結與外部連結檔案？**

[超連結](/slides/zh-hant/php-java/manage-hyperlinks/) 會被保留。外部連結檔案（例如以相對路徑引用的影片）不會自動複製——請確保相關路徑仍可存取。

**我可以設定/儲存文件中繼資料（作者、標題、公司、日期）嗎？**

可以。支援標準的[文件屬性](/slides/zh-hant/php-java/presentation-properties/)，在儲存時會寫入檔案。