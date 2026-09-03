---
title: 在 PHP 中處理簡報警告
type: docs
weight: 90
url: /zh-hant/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告回呼
- 警告政策
- 資料遺失
- 來源損毀
- 相容性問題
- 字型替換
- 數位簽章
- 簡報載入
- 簡報呈現
- 簡報轉換
- 簡報儲存
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "了解如何在使用 Aspose.Slides for PHP via Java 時，於載入、呈現、轉換與儲存簡報的過程中，收集、分類並處理警告。"
---
## **概觀**

Aspose.Slides 在載入、呈現、轉換或儲存簡報時，能夠回報可復原的問題。範例包括受損的來源記錄、無法保留的內容、字型替換，以及目標格式的限制。警告回呼允許應用程式記錄這些狀況，並決定目前的操作是否可以繼續。

建立一個具有 public `warning` 方法的 PHP 類別，並透過 PHP Java Bridge 使用 `java_closure` 將其以 Java [IWarningCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarningcallback/) 介面公開。檢查由 [IWarningInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/) 提供的 [getWarningType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getWarningType--) 和 [getDescription](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getDescription--) 值。回傳 [ReturnAction::Continue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/returnaction/#Continue) 以接受警告，或回傳 [ReturnAction::Abort](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/returnaction/#Abort) 以停止操作。

在開啟簡報時使用 [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setWarningCallback) 以接收警告。渲染與匯出選項類別繼承自 [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveoptions/#setWarningCallback)，可接收來自投影片渲染、轉換與儲存的警告。因為警告本身不會指明是哪個應用程式操作產生，請在建立合併報告時，將每個回呼實例與操作階段關聯起來。

## **警告與例外**

Java 例外會透過 PHP Java Bridge 暴露給 PHP；如下例所示，在操作邊界捕捉它們。本篇文章中的 Java 介面連結說明了橋接使用的回呼合約。

警告描述的是若回呼傳回 `ReturnAction::Continue`，Aspose.Slides 能夠復原的狀況。例外則表示請求的操作無法正常完成；例外不會轉換成警告，也無法透過警告策略處理。

傳回 `ReturnAction::Abort` 會請警告分派器以拋出例外的方式終止目前的操作。公開的例外類型依操作與簡報格式而異。例如，載入時可能拋出 [PptxReadException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxreadexception/) 或 [PptReadException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptreadexception/)，而儲存或匯出時可能拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxexception/)。在操作邊界處理例外，並使用警告報告判斷是否因應用程式策略而終止，而非僅依賴單一例外子類型或訊息。回呼會在回傳 `ReturnAction::Abort` 前記錄警告，確保原因仍可供應用程式取得。

## **警告類別**

[WarningType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/warningtype/) 類別提供以下類別的整數常數：

| 警告類型 | 意義 | 典型策略 |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/warningtype/#SourceFileCorruption) | 來源簡報包含的損毀可能使其以原始格式儲存後無法使用。 | 中止 |
| [DataLoss](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/warningtype/#DataLoss) | 載入或儲存後可能缺少文字、圖表、影像或其他資料。 | 中止 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | 簡報可能遺失重要的格式設定。 | 在嚴格驗證模式下中止；否則記錄後繼續 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | 可能出現有限的格式差異。 | 記錄以作診斷並繼續 |
| [CompatibilityIssue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/warningtype/#CompatibilityIssue) | 結果在某些應用程式或舊版軟體中可能無法正確開啟或運作。 | 記錄並繼續，除非兼容性為必須 |
| [UnexpectedContent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/warningtype/#UnexpectedContent) | 來源包含未支援或未辨識的內容，其影響尚不明朗。 | 記錄並繼續，或在嚴格政策下視為錯誤 |

類別應驅動策略決策。將 [getDescription](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getDescription--) 回傳的值存入診斷資訊即可，但不要將訊息文字作為應用程式邏輯的依據，因為不同警告情境與產品版本的文字可能不同。

## **收集與分類警告**

以下範例使用單一應用程式層級的報告來覆蓋整個處理管線。每個回呼實例會為載入、渲染、PDF 轉換與 PPTX 儲存標記警告來源。策略在來源損毀或資料遺失時中止，選擇性在重大格式遺失時中止，其他警告則繼續。回呼在記錄前先使用 `java_values` 將警告值轉為原生 PHP 值，再進行比較。

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

如果在建構 `WarningPolicy` 時，接受較大的格式差異，請將 `abortOnMajorFormattingLoss` 設為 `false`。即使操作繼續，相容性問題、次要格式遺失與未預期內容仍會保留在報告中。若應用程式必須拒絕這些類別，可擴充 `WarningPolicy::getAction`。

## **常見警告情境**

警告可能出現在工作流程的不同階段：

- **數位簽章：** 已簽署的簡報在載入時可能產生警告，指出其簽章將在處理過程中遺失。Aspose.Slides 透過 [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationsignedwarninginfo/) 回報此 `DataLoss` 狀況。載入階段的回呼可讓應用程式拒絕檔案或明確接受此遺失。
- **字型替換：** 當投影片在渲染或匯出時遇到無法取得的字型，會以 `DataLoss` 形式回報字型替換警告，因此上述嚴格政策會中止，即使應用程式認為該替換在視覺上可接受。若要觀察此行為，請使用含有執行環境中不存在字型的文字的簡報作為輸入。警告描述會指出替換的字型；請在重新嘗試前設定所需字型或[字型替換規則](/slides/zh-hant/php-java/font-substitution/)。
- **未支援或未預期的內容：** 載入器可能遇到無法辨識的簡報記錄或功能。此類警告可能使用 `UnexpectedContent`，或在資料或格式已知受影響時使用更嚴重的類別。
- **格式相容性：** 儲存為其他簡報格式時可能省略功能，或產生在某些應用程式中表現不同的結果。例如，將含有超過八條水平或垂直繪圖指南的簡報儲存為舊版 PPT 時會回報 `CompatibilityIssue`。儲存階段的回呼可記錄遺失並繼續，或在必須保留所有指南時拒絕。
- **載入行為：** 載入選項與舊版行為也可能產生警告。例如，[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) 會將使用過時的簡報鎖定行為標示為 `CompatibilityIssue`。

警告取決於來源文件、目標格式、操作以及 Aspose.Slides 版本。不要假設每個檔案都會產生警告，或每種情境只能對應單一類別。

## **安全處理已中止的操作**

當回呼回傳 `ReturnAction::Abort` 時，請勿使用未成功載入的物件，也不要假設渲染或儲存的輸出已完整。操作可能在建立輸出檔案後、完成之前就已終止。

將驗證過的結果儲存至其他路徑，例如 `validated-output.pptx`。只有在操作成功結束、警告報告符合應用程式策略且輸出可以開啟檢查後，才替換既有的簡報。如此可避免以部分或被拒絕的結果覆寫有效的來源檔案。

空的警告報告並不保證每個來源功能皆已保留。請依應用程式需求執行任何額外的內容與視覺檢查。另請參閱 [Open Presentations](/slides/zh-hant/php-java/open-presentation/) 與 [Save Presentations](/slides/zh-hant/php-java/save-presentation/)。

## **FAQ**

**警告回呼可以處理每個 Aspose.Slides 錯誤嗎？**

不能。它只能處理以警告形式回報的可復原情況。與回呼無關的例外必須在載入、渲染、轉換或儲存呼叫周圍由應用程式自行處理。

**回傳 `ReturnAction::Continue` 是否保證產生相同的輸出？**

不保證。它僅允許繼續處理。回報的情況仍可能導致資料、格式或相容性差異，請檢查收集到的警告類型與描述。

**應用程式如何辨識產生警告的操作？**

為每個操作建立一個回呼實例，並將應用程式自訂的階段資訊與 [getWarningType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getWarningType--) 及 [getDescription](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getDescription--) 回傳的值一起儲存，如範例所示。