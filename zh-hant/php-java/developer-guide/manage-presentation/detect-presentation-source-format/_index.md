---
title: 在 PHP 中判斷原始簡報格式
linktitle: 來源格式
type: docs
weight: 35
url: /zh-hant/php-java/detect-presentation-source-format/
keywords:
- 來源格式
- 偵測簡報格式
- PowerPoint
- OpenDocument
- 簡報
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PHP 中讀取已載入簡報的原始格式，比較偵測 API，並處理檔案、串流與舊版格式。"
---
## **概覽**

載入簡報後，呼叫 Presentation::getSourceFormat 方法以判斷其原始格式。當後續處理取決於目前實例載入時的格式時，請使用此方法。

來源格式與為輸出檔案所選擇的 SaveFormat 不同。將檔案另存為其他格式不會更改現有實例的來源格式。

## **讀取檔案的來源格式**

此範例需要一個已存在的 `sample.pptx` 檔案。它載入該檔案，並使用 Presentation::getSourceFormat 來選擇應用程式的處理原則，而非依賴檔名。變更輸入路徑即可測試其他格式。範例會列印所選的原則；請將訊息替換為您的應用程式邏輯。

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **辨識支援的值**

SourceFormat 類別定義了可區分以下簡報格式的整數常數。下列副檔名為慣用副檔名，並非原始檔名的還原。

| SourceFormat 值 | 副檔名 | 格式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 簡報 |
| `Pptx` | `.pptx` | Office Open XML 簡報 |
| `Pptm` | `.pptm` | 支援巨集的 Office Open XML 簡報 |
| `Pps` | `.pps` | PowerPoint 97–2003 投影片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 投影片放映 |
| `Ppsm` | `.ppsm` | 支援巨集的 Office Open XML 投影片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 範本 |
| `Potx` | `.potx` | Office Open XML 範本 |
| `Potm` | `.potm` | 支援巨集的 Office Open XML 範本 |
| `Odp` | `.odp` | OpenDocument 簡報 |
| `Otp` | `.otp` | OpenDocument 簡報範本 |
| `Fodp` | `.fodp` | Flat XML ODF 簡報 |
| `Xml` | `.xml` | PowerPoint XML 簡報 |

## **讀取串流的來源格式**

此範例需要一個已存在的 `sample.pps` 檔案。將其位元組讀入記憶體串流，以模擬未提供檔名的輸入，例如資料庫值或上傳的位元組陣列。Presentation 建構函式只接受串流作為參數。

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT、PPS 與 POT 使用相同的底層二進位格式。以檔案路徑載入時，副檔名可協助區分投影片放映或範本。若未提供檔名，舊版的 PPS 與 POT 內容可能會被報告為 `SourceFormat::Ppt`；上述 PPS 範例會列印 `SourceFormat::Ppt` 的整數值。

如果您的應用程式必須保留此區分，請另行保存原始檔名或子類型中繼資料。副檔名對於這些舊版子類型是一個有用的提示，但不應成為辨識任意簡報內容的唯一依據。

## **比較載入前後的偵測**

當需要在載入完整簡報物件模型之前檢查檔案時，請使用 PresentationFactory::getPresentationInfo 與 PresentationInfo::getLoadFormat。當實例已存在時，使用 Presentation::getSourceFormat。

此範例需要 `sample.pptx`，分別列印 `LoadFormat::Pptx` 與 `SourceFormat::Pptx` 的整數值。於正式環境中，請依據處理階段選擇適當的 API；已載入的簡報無需再次檢查即可取得其來源格式。

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

結果使用來自不同類別的常數：LoadFormat 與 SourceFormat。請勿比較它們的數值，或假設每種格式皆有相同的偵測結果。PowerPoint XML 在載入前可能會被報告為 `LoadFormat::Unknown`，而載入後則為 `SourceFormat::Xml`。

## **將來源與輸出格式分開**

此範例需要 `sample.pptx`，並寫入 `converted.odp`。它在儲存原始實例前後都列印 `SourceFormat::Pptx` 的整數值。唯一會報告 `Odp` 的是從 ODP 輸出載入的新實例。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

使用 `new Presentation()` 從頭建立的簡報會報告 `SourceFormat::Pptx`。它沒有輸入檔案：這是新建立實例的預設值，並不表示已載入 PPTX 檔案。若此區分重要，請在應用程式中分別追蹤是建立還是載入了實例。

## **將來源格式對映至副檔名**

以下範例需要 `sample.pptx`。它將每個目前支援的 SourceFormat 值對映到慣用的副檔名，無需解析輸入檔名。此備援機制可避免對未識別的值默默指派副檔名。

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

此對映不會轉換檔案，也不會在串流載入時復原遺失的舊版 PPS/POT 子類型。實際儲存時，請明確選擇 SaveFormat，或使用「Save Presentations in Their Original Format」中示範的轉換方式。

## **透過儲存與重新開啟驗證格式**

此獨立範例會建立一個簡報，並在工作目錄寫入三個檔案，會覆寫同名檔案。它會以路徑與記憶體串流兩種方式重新開啟每個輸出。對於 PPTX 與 ODP，兩種方式皆報告已儲存的格式。對於 PPS，使用路徑載入會報告 `Pps`，而在沒有檔名的情況下載入相同位元組則報告 `Ppt`。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

下表彙總了具有相同副檔名之簡報的來源格式辨識。名稱代表常數；PHP 範例會列印其整數值：

| 儲存格式 | 由檔案路徑取得的 SourceFormat | 由無檔名串流取得的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` | 與檔案路徑相同 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` | 與檔案路徑相同 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` | 與檔案路徑相同 |
| ODP, OTP | `Odp`, `Otp` | 與檔案路徑相同 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT 內容在無檔名串流中會被識別為 `Ppt`。此表說明格式辨識，而非轉換過程中所有簡報功能的保留情況。

## **常見問題**

**將簡報從 PPTX 儲存為 ODP 會改變其來源格式嗎？**

不會。現有的實例仍會報告 `Pptx`。從已儲存的 ODP 檔案載入的實例則會報告 `Odp`。

**串流能否始終區分舊版簡報、投影片放映與範本？**

不能。PPT、PPS 與 POT 使用相同的二進位格式。若需要此區分，請另行保存檔名或子類型中繼資料。

**如果簡報已經載入，我該使用哪個 API？**

請使用 Presentation::getSourceFormat。若在載入之前需要檢查，則使用 PresentationFactory::getPresentationInfo。