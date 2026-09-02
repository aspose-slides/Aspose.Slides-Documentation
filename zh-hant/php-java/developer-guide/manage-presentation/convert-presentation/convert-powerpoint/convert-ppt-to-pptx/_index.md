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
description: "使用 Aspose.Slides 在 PHP 中將舊版 PPT 檔案轉換為 PPTX。包括單檔案與批次轉換、錯誤處理以及保真度說明的 PHP 範例。"
---
## **概觀**

PPT 是舊式的二進位 PowerPoint 格式，而 PPTX 是較新的 Open XML 格式。Aspose.Slides for PHP via Java 能在不安裝 Microsoft PowerPoint 的情況下載入 PPT 檔並將其儲存為 PPTX。本文說明如何轉換單一檔案或整個目錄的檔案，並說明轉換後需檢查的項目。

## **將 PPT 檔案轉換為 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別載入來源檔案，然後呼叫 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 並傳入 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/#Pptx)。`finally` 區塊會釋放簡報並釋放其資源。

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

副檔名本身不會決定輸出格式；由 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/#Pptx) 參數決定。如果需要保留原始 PPT 檔，請將輸入與輸出路徑設定為不同位置。

## **一次轉換多個 PPT 檔案**

以下範例會轉換目錄中所有 `.ppt` 檔案。每個檔案會獨立處理，單一轉換失敗不會阻止其他批次作業。

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

對於正式環境，請記錄完整例外資訊，決定是否允許覆寫已存在的輸出檔，並將失敗的檔案名稱寫入重試或審查佇列。損毀的檔案、未提供正確密碼的受保護檔案、無法存取的路徑以及不支援的內容，都可能導致轉換失敗。請參閱 [Password-Protected Presentations](/slides/zh-hant/php-java/password-protected-presentation/) 以了解如何載入加密檔案。

## **保真度與舊版功能**

轉換通常會保留投影片、母片、版面配置、文字、圖形、影像、表格與圖表。但 PPT 與 PPTX 並非以完全相同的方式呈現每項功能。沒有 PPTX 等價項目、或是程式庫不支援的舊版功能，可能會被正規化、略過，或以不同方式顯示。

當轉換的檔案包含動畫、過場、內嵌或連結的 OLE 物件、ActiveX 控制項、內嵌媒體、罕見字型或 VBA 巨集時，請仔細檢查轉換結果。純 PPTX 檔案不是巨集啟用格式，若必須保留 VBA，請使用相應的巨集啟用工作流程。亦需確認所需字型與外部資源已存在於將要開啟或渲染該簡報的環境中。

對於重要文件，建議以程式方式重新開啟產生的 PPTX，檢查關鍵投影片數量與內容，然後在目標檢視器中比較其外觀與投影片放映行為。不要僅因成功呼叫 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 就認為每個舊版功能都有完全對應的 PPTX 表示。

## **何時使用 PPTX**

當簡報需在最新的 PowerPoint 版本中編輯、與支援 Open XML 套件的系統交換，或需以較易檢查與復原的格式保存時，請使用 PPTX。保留原始 PPT 作為存檔或回滾副本，直到轉換後的簡報通過您的保真度檢查為止。

如果您需要 PDF、HTML、影像、XPS 或其他輸出類型，請參考 [Convert Presentations to Multiple Formats](/slides/zh-hant/php-java/convert-presentation/) 中的特定格式說明，而不要假設所有目標皆能保留可編輯的 PowerPoint 功能。

## **線上轉換器**

若僅需偶爾轉換單一檔案或快速比較，可使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)。若需批次處理、可重複執行的轉換或應用程式層級的錯誤處理，請使用 PHP API。

## **相關文章**

- [PPT vs PPTX](/slides/zh-hant/php-java/ppt-vs-pptx/)
- [在 PHP 中儲存簡報](/slides/zh-hant/php-java/save-presentation/)
- [支援的檔案格式](/slides/zh-hant/php-java/supported-file-formats/)
- [在 PHP 中開啟簡報](/slides/zh-hant/php-java/open-presentation/)

## **常見問題**

**我能在未安裝 Microsoft PowerPoint 的情況下將 PPT 轉換為 PPTX 嗎？**

可以。Aspose.Slides for PHP via Java 能在不需要 Microsoft PowerPoint 的環境下載入與儲存簡報檔案。

**PPT 轉 PPTX 會完整保留所有內容嗎？**

會保留一般的簡報內容，但對於每個舊版或不支援的功能，無法保證完全相同的保真度。當檔案包含巨集、OLE 或 ActiveX 物件、媒體、特殊動畫或罕見字型時，請自行檢查產生的檔案。

**我可以轉換受密碼保護的 PPT 檔案嗎？**

可以，只要在載入檔案時提供正確的密碼。若密碼遺失或錯誤，載入操作會失敗。

**轉換後是否應該刪除 PPT 檔案？**

請保留原始檔案，直到您在所有相關檢視器與工作流程中驗證 PPTX 為止。這樣可在需要時作為回滾備份。