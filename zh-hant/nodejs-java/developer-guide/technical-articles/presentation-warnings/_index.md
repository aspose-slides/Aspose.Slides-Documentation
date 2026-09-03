---
title: 在 Node.js 中處理簡報警告
type: docs
weight: 90
url: /zh-hant/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告回呼
- 警告政策
- 資料遺失
- 來源損壞
- 相容性問題
- 字型置換
- 數位簽章
- 簡報載入
- 簡報呈現
- 簡報轉換
- 簡報儲存
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "了解如何在使用 Aspose.Slides for Node.js via Java 時，收集、分類並對載入、呈現、轉換和儲存簡報過程中的警告採取行動。"
---
## **概觀**

Aspose.Slides 可以在載入、呈現、轉換或儲存簡報時回報可復原的問題。範例包括損壞的來源記錄、無法保留的內容、字型置換以及目標格式的限制。警告回呼讓應用程式記錄這些狀況，並決定目前的操作是否可以繼續。

使用 `java.newProxy` 在 JavaScript 中實作 [IWarningCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarningcallback/) Java 介面，並檢查透過 [IWarningInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/) 提供的 [getWarningType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getWarningType--) 和 [getDescription](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getDescription--) 值。傳回 [ReturnAction.Continue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/returnaction/#Continue) 以接受警告，或傳回 [ReturnAction.Abort](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/returnaction/#Abort) 以停止操作。

使用 [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) 以在開啟簡報時接收警告。呈現與匯出選項類別繼承自 [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveoptions/#setWarningCallback)，可接收來自投影片呈現、轉換與儲存的警告。因為警告本身不會指明應用程式的操作，請在建立合併報告時，將每個回呼實例與操作階段關聯起來。

## **警告與例外**

警告描述了 Aspose.Slides 在回呼傳回 `ReturnAction.Continue` 時可復原的狀況。例外表示請求的操作無法正常完成；例外不會轉換成警告，也無法由警告政策處理。

傳回 `ReturnAction.Abort` 會要求警告分派器透過拋出例外來終止目前的操作。公開的例外類型取決於操作與簡報格式。例如，載入時可能拋出 [PptxReadException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxreadexception/) 或 [PptReadException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptreadexception/)，而儲存或匯出時可能拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxexception/)。在操作的邊界處從 Java 橋接捕捉錯誤，並使用警告報告判斷應用程式政策是否導致終止，而不是僅依賴單一例外子類別或訊息。回呼在傳回 `ReturnAction.Abort` 前先記錄警告，確保原因仍可供應用程式使用。

## **警告類別**

[WarningType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/warningtype/) 類別提供以下類別的整數常數：

| 警告類型 | 含義 | 典型政策 |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | 原始簡報包含損壞，可能導致以原始格式儲存的文件無法使用。 | 中止。 |
| [DataLoss](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/warningtype/#DataLoss) | 載入或儲存後可能缺少文字、圖表、影像或其他資料。 | 中止。 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | 簡報可能失去重要的格式設定。 | 在嚴格驗證模式下中止；否則記錄並繼續。 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | 可能出現有限的格式差異。 | 記錄以供診斷，然後繼續。 |
| [CompatibilityIssue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | 結果可能在某些應用程式或較舊版本中無法開啟或行為不正確。 | 記錄並繼續，除非相容性是必須的。 |
| [UnexpectedContent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | 來源包含未支援或未辨識的內容，尚不清楚其影響。 | 記錄並繼續，或在嚴格政策下視為錯誤。 |

類別應驅動政策決策。將 [getDescription](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getDescription--) 回傳的值儲存起來供診斷使用，但不要在應用程式邏輯上依賴其文字描述，因為訊息文字可能會因警告情境和產品版本而異。

## **收集與分類警告**

以下 JavaScript 範例使用單一應用程式層級的報告來處理完整的處理管線。不同的回呼實例為載入、呈現、PDF 轉換與 PPTX 儲存的警告加上標籤。政策在來源損壞或資料遺失時中止，選擇性在重大格式遺失時中止，其他警告則繼續。

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

在建立 `WarningPolicy` 時，若接受較大的格式差異，請將 `abortOnMajorFormattingLoss` 設為 `false`。相容性問題、次要格式遺失與未預期內容即使在操作繼續時仍會保留在報告中。若應用程式必須拒絕上述任何類別，可延伸 `WarningPolicy.getAction`。

## **常見警告情境**

警告可能出現在工作流程的不同階段：

- **數位簽章**：已簽署的簡報在載入時可能產生警告，指出簽章在處理過程中將遺失。Aspose.Slides 透過 [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationsignedwarninginfo/) 報告此 `DataLoss` 狀況。載入階段的回呼讓應用程式拒絕檔案或明確接受報告的遺失。
- **字型置換**：在投影片呈現或匯出時，若字型不可用則會被替換。字型置換警告以 `DataLoss` 報告，因此上述嚴格政策會中止，即使應用程式認為特定替換在視覺上可接受。要觀察此行為，請使用包含執行環境中不存在字型的文字的簡報作為輸入。警告描述會指出置換的字型；請在重試前配置所需字型或 [字型置換規則](/slides/zh-hant/nodejs-java/font-substitution/)。
- **未支援或未預期的內容**：載入器可能遇到簡報記錄或功能未被辨識。此類警告可能使用 `UnexpectedContent`，或在資料或格式確定受影響時使用更嚴重的類別。
- **格式相容性**：儲存為其他簡報格式時可能省略功能，或產生在某些應用程式中行為不同的結果。例如，將含有超過八條水平或垂直繪圖指引的簡報儲存為舊版 PPT 時，會回報 `CompatibilityIssue`。儲存階段的回呼可以記錄此遺失並繼續，或在必須保留所有指引時拒絕。
- **載入行為**：載入選項與舊版行為亦可能產生警告。例如，[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) 會將使用過時的簡報鎖定行為標記為 `CompatibilityIssue`。

警告取決於來源文件、目標格式、操作以及 Aspose.Slides 版本。不要假設每個檔案都會產生警告，或情境永遠只對應單一類別。

## **安全處理已中止的操作**

當回呼傳回 `ReturnAction.Abort` 時，請勿使用未成功載入的物件，也不要假設呈現或儲存的輸出已完成。操作可能在建立輸出檔案後、完成之前就終止。

將驗證過的結果儲存至其他路徑，例如 `validated-output.pptx`。僅在操作成功完成、警告報告符合應用程式政策且輸出可開啟檢查後，才替換現有簡報。這可避免以部分或被拒絕的結果覆寫有效的來源檔案。

空的警告報告並不保證每個來源特徵皆已保留。請執行應用程式所需的任何額外內容與視覺檢查。另請參閱 [Open Presentations](/slides/zh-hant/nodejs-java/open-presentation/) 與 [Save Presentations](/slides/zh-hant/nodejs-java/save-presentation/)。

## **常見問答**

**警告回呼能處理每個 Aspose.Slides 錯誤嗎？**

不能。它僅處理以警告形式回報的可復原狀況。與回呼無關的例外必須由應用程式在載入、呈現、轉換或儲存呼叫周圍自行處理。

**傳回 `ReturnAction.Continue` 是否保證輸出相同？**

不保證。它只允許繼續處理。報告的狀況仍可能導致資料、格式或相容性差異，請檢查收集的警告類型與描述。

**應用程式如何辨識產生警告的操作？**

為每個操作建立一個回呼實例，並將應用程式自訂的階段與 [getWarningType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getWarningType--) 及 [getDescription](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getDescription--) 回傳的值一併儲存，如範例所示。