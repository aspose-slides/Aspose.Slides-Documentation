---
title: 在 PHP 中將 PPT 轉換為 PPTX
linktitle: PPT 轉 PPTX
type: docs
weight: 20
url: /zh-hant/php-java/convert-ppt-to-pptx/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- PPT 轉 PPTX
- 將 PPT 儲存為 PPTX
- 匯出 PPT 為 PPTX
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中將舊版 PPT 檔案轉換為 PPTX。包括單檔與批次轉換的 PHP 範例、錯誤處理以及忠實度說明。"
---
## **概述**

PPT 是舊版的二進位 PowerPoint 格式，而 PPTX 是較新的 Open XML 格式。Aspose.Slides for PHP via Java 可在不需要 Microsoft PowerPoint 的情況下載入 PPT 檔並將其儲存為 PPTX。本文章說明如何轉換單一檔案或整個目錄，並解釋轉換後需要驗證的項目。

## **將 PPT 檔案轉換為 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別載入來源檔案，然後以 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/#Pptx) 為參數呼叫 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save)。`finally` 區塊會釋放簡報並釋放其資源。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// 載入舊版 PPT 簡報。
$presentation = new Presentation("presentation.ppt");
try {
    // 以 PPTX 格式儲存簡報。
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

檔案副檔名本身不會決定輸出格式；必須使用 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/#Pptx) 參數來指定。若需要保留原始 PPT 檔，請確保輸入與輸出路徑不同。

## **批次轉換多個 PPT 檔案**

以下範例會轉換目錄中所有 `.ppt` 檔案。每個檔案皆獨立處理，單一轉換失敗不會中止整批作業。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

在正式環境中，請記錄完整例外資訊，決定是否允許覆寫已存在的輸出檔，並將失敗的檔案名稱寫入重試或審查佇列。損毀的檔案、未提供正確密碼而開啟的受保護檔案、無法存取的路徑以及不支援的內容，都可能導致轉換失敗。請參閱 [Password-Protected Presentations](/php-java/password-protected-presentation/) 以載入加密檔案。

## **忠實度與舊版功能**

轉換通常會保留投影片、母片、版面配置、文字、圖形、影像、表格與圖表。然而，PPT 與 PPTX 並非以完全相同的方式呈現所有功能。若某舊版功能在 PPTX 中沒有對應項目，或未被程式庫支援，可能會被正規化、省略，或以不同方式顯示。

若轉換後的檔案包含動畫、轉場、內嵌或連結的 OLE 物件、ActiveX 控制項、內嵌媒體、罕見字型或 VBA 巨集，請特別檢查。純 PPTX 檔並非支援巨集的格式，若必須保留 VBA，請使用相應的巨集支援工作流程。同時確認所需字型與外部資源是否存在於開啟或渲染轉換後簡報的環境中。

對於重要文件，請以程式方式重新開啟產生的 PPTX，檢查關鍵投影片數量與內容，然後在目標檢視程式中比較其外觀與投影片放映行為。不要將成功的 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 呼叫視為每個舊版功能都有完全相同的 PPTX 表示之證明。

## **何時使用 PPTX**

當簡報將在最新版 PowerPoint 中編輯、與支援 Open XML 套件的系統交換，或需以較易檢視與還原的格式儲存，請使用 PPTX。保留原始 PPT 作為存檔或回退備份，直至轉換後的簡報通過您的忠實度檢查為止。

若需要 PDF、HTML、影像、XPS 或其他輸出類型，請參考 [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) 中的特定格式說明，而不要假設所有目標都能保留可編輯的 PowerPoint 功能。

## **線上轉換器**

若僅需偶爾轉換單一檔案或快速比較，可使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)。若需重複轉換、批次處理或應用層面的錯誤處理，請使用 PHP API。

## **相關文章**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Save Presentations in PHP](/php-java/save-presentation/)
- [Supported File Formats](/php-java/supported-file-formats/)
- [Open Presentations in PHP](/php-java/open-presentation/)

## **常見問題**

**我可以在未安裝 Microsoft PowerPoint 的情況下將 PPT 轉換為 PPTX 嗎？**

可以。Aspose.Slides for PHP via Java 可在不需要 Microsoft PowerPoint 的情況下載入與儲存簡報檔案。

**PPT 轉換為 PPTX 會完整保留所有內容嗎？**

它會保留常見的簡報內容，但對於每個舊版或未支援的功能，無法保證完全相同的忠實度。若產生的檔案包含巨集、OLE 或 ActiveX 物件、媒體、特殊動畫或罕見字型，請特別檢查。

**我可以轉換受密碼保護的 PPT 檔案嗎？**

可以，只要在載入檔案時提供正確的密碼。若密碼遺失或不正確，載入操作將失敗。

**轉換後我應該刪除 PPT 檔案嗎？**

請保留原始檔，直至您在相關的檢視程式與工作流程中驗證 PPTX 為止。若有舊版功能轉換後不同，原始檔可作為回退備份。