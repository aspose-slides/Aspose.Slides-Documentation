---
title: 在 PHP 中將簡報匯出為 XAML
linktitle: 簡報轉 XAML
type: docs
weight: 30
url: /zh-hant/php-java/export-to-xaml/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出簡報
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換簡報
- PowerPoint 轉 XAML
- OpenDocument 轉 XAML
- 簡報轉 XAML
- PPT 轉 XAML
- PPTX 轉 XAML
- ODP 轉 XAML
- 將 PPT 儲存為 XAML
- 將 PPTX 儲存為 XAML
- 將 ODP 儲存為 XAML
- 匯出 PPT 為 XAML
- 匯出 PPTX 為 XAML
- 匯出 ODP 為 XAML
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 透過 Java 將 PowerPoint 與 OpenDocument 投影片轉換為 XAML — 快速、無需 Office 的解決方案，保持版面完整。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報匯出為 XAML。內容包含 XAML 的簡要介紹、示範使用預設設定將簡報儲存為 XAML 的方式，以及透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xamloptions/) 自訂匯出（包括匯出隱藏投影片）的範例。文章亦回答了關於備援字型、XAML 堆疊相容性以及隱藏投影片匯出行為的常見問題。

## **關於 XAML**

XAML 是一種基於 XML 的標記語言，用於描述 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）與 Xamarin.Forms 等框架中的使用者介面。

您可以在視覺設計師中處理 XAML 檔案，或直接編寫與編輯標記。

## **使用預設選項將簡報匯出為 XAML**

以下 PHP 範例示範如何以預設設定將簡報匯出為 XAML。執行本章節的範例前，請先初始化 PHP Java Bridge 並載入 `aspose.slides.php`。將 `pres.pptx` 放置於 Java Bridge 伺服器的工作目錄，或提供該伺服器可存取的絕對路徑。

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

預設情況下，匯出的投影片會儲存在 Java Bridge 伺服器目前工作目錄的 `pres` 子資料夾中。資料夾會自動建立，所需的圖片亦會儲存於其中。

輸出資料夾名稱取自來源檔名（不含副檔名）。對於 `pres.pptx`，輸出檔案分別為 `pres/Slide_1.xaml`、`pres/Slide_2.xaml` 等。即使您傳入的是簡報的絕對路徑，輸出資料夾仍會相對於 Java Bridge 伺服器的目前工作目錄建立，而非與輸入檔案同階層。

## **使用自訂選項將簡報匯出為 XAML**

使用 [IXamlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ixamloptions/) 介面可控制 Aspose.Slides 如何將簡報匯出為 XAML。

若要將輸出儲存至自訂位置，請提供實作了 [IXamlOutputSaver](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ixamloutputsaver/) 的 Java 代理，並將該實例傳遞給 [XamlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xamloptions/) 的 [setOutputSaver](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xamloptions/#setOutputSaver) 方法。

若要在 XAML 輸出中包含隱藏投影片，請如以下 PHP 範例所示，將 `true` 傳入 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xamloptions/#setExportHiddenSlides)：

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **擷取所有產生的 XAML 產出物**

XAML 匯出可能為每張投影片產生一個 XAML 文件，並額外產生圖片與支援資源。將自訂的 [IXamlOutputSaver](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ixamloutputsaver/) 指派給 [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xamloptions/#setOutputSaver)，即可取得這些產出物，而非使用預設的檔案系統儲存器。使用接受 XAML 選項的 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 重載開始匯出。

PHP Java Bridge 的 `java_closure` 函式會將 PHP 物件映射為 Java 介面。請在匯出完成前保持 PHP 儲存器與其代理的存活。介面連結指向由代理實作的 Java API。

### **了解回呼生命週期**

匯出器會針對每個產生的產出物分別呼叫 [IXamlOutputSaver::save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-)：

- `path` 表示產出物的路徑，可包含相對目錄。請保留此資訊，因為 XAML 可能會使用相對路徑參照資源。
- `data` 為產出物的位元組。圖片與其他二進位資源絕不可被解碼為文字。
- 儲存器必須在返回前保留或持久化這些資料。範例會將每個 Java 位元組陣列轉換為應用程式擁有的 PHP 二進位字串。
- 只有當簡報的儲存操作返回且每個回呼皆成功完成時，才視匯出為成功。切勿吞掉儲存錯誤或啟動未觀察的背景寫入。若持久化於之後發生，僅在該步驟也成功後才報告整體成功。

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) 同樣適用於自訂儲存器。預設值 `false` 會排除隱藏投影片的 XAML 文件。傳入 `true` 則會包含它們以及匯出所需的所有資源。資源數量取決於簡報本身；勿假設每張投影片僅有一次回呼或回呼順序固定。

### **匯出至記憶體並檢視產出物**

以下完整範例載入 `pres.pptx`，將每個產出物收集於 PHP 關聯陣列的二進位字串中，並印出其名稱、類型與位元組數。名稱會完整保留。若出現重複名稱，集合會被標記為無效，而不是悄悄覆寫產出物。範例在使用結果前會先檢查此情形。

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // 僅將 XAML 視為 UTF-8 文字以供選擇性檢查。
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

檔案類型檢查對於檢驗非常有用；請保留所有產出物，包括不熟悉的資源類型。儲存或傳輸時請保持位元組不變。PHP 字串能保留二進位資料，包括零位元組。僅在檢查 XAML 時才將字串視為 UTF-8 文字；不要對圖片或資源位元組進行轉碼。

### **將收集的產出物打包為 ZIP 壓縮檔**

此獨立範例會收集匯出結果、驗證名稱，並將原始位元組寫入 ZIP 壓縮檔。專屬建立的工作目錄可將同時執行的匯出工作隔離。此範例需要支援 ZIP 的 PHP Phar 擴充套件。ZIP 條目使用正斜線並保留相對目錄。若名稱不安全或正規化後發生衝突，將在寫入前拒絕整個封包。

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

範例使用 [PharData](https://www.php.net/manual/en/class.phardata.php) 在 PHP 行程的工作目錄寫入本機 ZIP 壓縮檔；匯出器本身不會寫入散落的 XAML 或圖片檔案。若需遠端儲存，請將封包寫入階段換成上傳收集到的二進位字串。可使用匯出工作識別碼加上完整相對產出物名稱作為 Blob 鍵，或將工作識別碼、相對名稱與二進位資料存入資料庫列。僅在所有上傳完成或資料庫交易提交後才發佈工作。若持久化失敗，請清除部分輸出。

對於大型簡報，可使用自訂儲存器直接將每個產出物寫入應用程式儲存，以避免在記憶體中保留整個匯出的副本。從匯出器的觀點看，確保每個回呼是同步的：僅在目的端接受位元組後返回，並允許失敗傳回呼叫端。

### **保留資源名稱並驗證參照**

- 若目的端需要，正規化路徑分隔符，但仍保留相對目錄。除非每個產生的名稱皆唯一且資源參照仍有效，否則不要僅使用 [basename](https://www.php.net/manual/en/function.basename.php)。
- 依目的端套用名稱驗證。寫入散檔時，拒絕根目錄路徑與目錄遍歷段落，將目的端解析為絕對路徑，並驗證其仍位於預期的匯出目錄之下（包含目錄分隔符的包含檢查）。使用無符號連結的受控目錄以防寫入被重新導向。
- 為每個匯出工作使用獨立的儲存器與命名空間。根據分隔符正規化與目的端大小寫規則檢測衝突。
- 發佈前，將每個 XAML 文件解析為 XML，檢查其基於檔案的資源參照，例如圖片 `Source` 或 `ImageSource` 屬性。將每個相對 URI 以包含該 XAML 產出物目錄的方式解析，正規化得到的儲存名稱，並確認對應的映射鍵、ZIP 條目或儲存物件存在。將外部 URI 與 XAML 標記運算式與相對檔名分開處理。

舉例來說，若 `pres/Slide_1.xaml` 參照 `images/image1.png`，則必須以 `pres/images/image1.png` 形式儲存該資源。僅保留 `image1.png` 會破壞關聯。若使用物件儲存，請在工作前置詞之下保留相同的佈局，並讓這些資源 URL 可供 XAML 消費者存取。重新開啟完成的 ZIP 以驗證條目名稱與資源位元組，並在目標 XAML 環境中載入代表性投影片以確保圖片正確解析。

## **常見問題**

**如果原始字型在機器上不存在，如何確保字型的可預測性？**

在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xamloptions/) 中呼叫 [setDefaultRegularFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveoptions/#setDefaultRegularFont)——匯出時若原始字型缺失，會使用此作為備援字型。這並不保證產生的 XAML 會參照備援字型或該字型在目標機器上可用。請確保 XAML 所參照的字型已安裝於顯示環境中。

**匯出的 XAML 是否只適用於 WPF，還是也能用於其他 XAML 堆疊？**

Aspose.Slides 透過其公開 API 匯出 WPF XAML。對其他 XAML 堆疊（例如 UWP 與 Xamarin.Forms）的相容性不保證。請在目標環境中測試產生的標記。

**是否支援隱藏投影片，且如何防止預設匯出它們？**

預設情況下不會包含隱藏投影片。您可透過在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xamloptions/) 中使用 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) 來控制此行為——若不需要匯出，請保持其關閉。