---
title: 處理 .NET 中的簡報警告
type: docs
weight: 120
url: /zh-hant/net/presentation-warnings/
aliases:
- /net/取得-警告-回呼-字型-取代-於-aspose-slides/
keywords:
- 警告回呼
- 警告政策
- 資料遺失
- 來源損毀
- 相容性問題
- 字型取代
- 數位簽章
- 簡報載入
- 簡報呈現
- 簡報轉換
- 簡報儲存
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "了解如何在使用 Aspose.Slides for .NET 載入、呈現、轉換及儲存簡報時，收集、分類並處理警告。"
---
## **概觀**

Aspose.Slides 在載入、呈現、轉換或儲存簡報時，會回報可復原的問題。範例包括受損的來源記錄、無法保留的內容、字型取代以及目標格式的限制。警告回呼允許應用程式記錄這些情況，並決定目前的操作是否可繼續。

實作 [IWarningCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.warnings/iwarningcallback/) 介面，並檢查透過 [IWarningInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.warnings/iwarninginfo/) 提供的 [WarningType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.warnings/iwarninginfo/warningtype/) 與 [Description](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.warnings/iwarninginfo/description/) 屬性。傳回 [ReturnAction.Continue](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.warnings/returnaction/) 以接受警告，或使用 `ReturnAction.Abort` 以停止操作。

在開啟簡報時發生的警告，請使用 [LoadOptions.WarningCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/warningcallback/)。呈現與匯出選項類別會繼承 [SaveOptions.WarningCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveoptions/warningcallback/)，接收來自投影片呈現、轉換與儲存的警告。由於警告本身不會指明應用程式的操作，請在建立統合報告時，將每個回呼實例與操作階段關聯起來。

## **警告與例外**

警告描述了 Aspose.Slides 在回呼傳回 `ReturnAction.Continue` 時可復原的情況。例外則表示請求的操作無法正常完成；例外不會轉換成警告，亦無法以警告政策處理。

傳回 `ReturnAction.Abort` 會請求警告分派器透過拋出例外來終止目前的操作。公開的例外類型取決於操作與簡報格式。例如，載入時可能拋出 [PptxReadException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxreadexception/) 或 [PptReadException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptreadexception/)，而儲存或匯出時可能拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxexception/)。在操作的邊界處處理例外，並使用警告報告來判斷是否因應用程式政策導致終止，而不是僅依賴單一例外子類型或訊息。回呼在傳回 `ReturnAction.Abort` 前先記錄警告，確保原因仍可供應用程式使用。

## **警告類別**

[WarningType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.warnings/warningtype/) 列舉提供以下類別：

| 警告類型 | 含義 | 常見政策 |
| --- | --- | --- |
| `SourceFileCorruption` | 來源簡報包含損毀，可能使以原始格式儲存的文件無法使用。 | 中止。 |
| `DataLoss` | 載入或儲存後，文字、圖表、影像或其他資料可能遺失。 | 中止。 |
| `MajorFormattingLoss` | 簡報可能失去重要的格式設定。 | 在嚴格驗證模式下中止；否則記錄並繼續。 |
| `MinorFormattingLoss` | 可能發生有限的格式差異。 | 記錄以供診斷，並繼續。 |
| `CompatibilityIssue` | 結果可能在某些應用程式或舊版中無法開啟或正確運作。 | 記錄並繼續，除非相容性為必需。 |
| `UnexpectedContent` | 來源包含未支援或未識別的內容，其影響尚未可知。 | 記錄並繼續，或在嚴格政策下視為錯誤。 |

類別應用於決策政策。將 `Description` 儲存以供診斷，但不要依賴其文字內容作為應用程式邏輯，因為訊息文字在不同警告情境與產品版本間可能會變化。

## **收集與分類警告**

以下範例使用單一應用程式層級的報告，涵蓋整個處理管線。個別的回呼實例會標記來自載入、呈現、PDF 轉換與 PPTX 儲存的警告。政策在來源損毀或資料遺失時中止，亦可選擇在重大格式遺失時中止，其他警告則繼續。

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

當可接受重大格式差異時，將 `abortOnMajorFormattingLoss` 設為 `false`。即使操作繼續，報告仍會保留相容性問題、輕微格式遺失與未預期內容。若應用程式必須拒絕其中任何類別，請擴充 `WarningPolicy.GetAction`。

## **常見警告情境**

警告可能出現在工作流程的不同階段：

- **數位簽章：** 簽署的簡報在載入時可能產生警告，指出其簽章在處理過程中會遺失。Aspose.Slides 透過 [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.warnings/ipresentationsignedwarninginfo/) 回報此 `DataLoss` 情況。載入階段的回呼允許應用程式拒絕該檔案或明確接受已回報的遺失。
- **字型取代：** 當投影片呈現或匯出時，若遇到無法使用的字型，會以替換方式處理。字型取代警告會以 `DataLoss` 回報，因此上述嚴格政策即使在應用程式認為特定替代在視覺上可接受時也會中止。若要觀察此行為，請使用包含執行環境中不存在字型的文字之輸入簡報。警告說明會指出取代的字型；請在重試前設定必要的字型或 [font substitution rules](/slides/zh-hant/net/font-substitution/)。
- **不支援或未預期的內容：** 載入器可能遇到無法辨識的簡報記錄或功能。此類警告可能使用 `UnexpectedContent`，或在已知資料或格式受影響時使用更高嚴重度的類別。
- **格式相容性：** 儲存為其他簡報格式時，可能會遺漏功能或產生在某些應用程式中行為不同的結果。例如，將包含超過八條水平或垂直繪圖參考線的簡報儲存為舊版 PPT 時，會回報 `CompatibilityIssue`。儲存階段的回呼可以記錄遺失並繼續，或在必須保留所有參考線時予以拒絕。
- **載入行為：** 載入選項與舊版行為也可能產生警告。例如，[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) 將使用已過時的簡報鎖定行為辨識為 `CompatibilityIssue`。

警告取決於來源文件、目標格式、操作以及 Aspose.Slides 版本。不要假設每個檔案都會產生警告，或某個情境只能對應單一類別。

## **安全處理已中止的操作**

當回呼傳回 `ReturnAction.Abort` 時，請勿使用載入失敗的物件，也不要假設呈現或儲存的輸出已完成。操作可能在建立輸出檔案後、完成之前即終止。

將驗證過的結果儲存至其他路徑，例如 `validated-output.pptx`。僅在操作成功完成、警告報告符合應用程式政策且輸出可開啟並檢查後，才取代既有的簡報。此做法可避免以部分或被拒的結果覆寫有效的來源檔案。

空的警告報告並不保證已保留每個來源功能。請執行應用程式所需的其他內容與視覺檢查。另請參閱 [Open Presentations](/slides/zh-hant/net/open-presentation/) 與 [Save Presentations](/slides/zh-hant/net/save-presentation/)。

## **常見問與答**

**警告回呼能處理每個 Aspose.Slides 錯誤嗎？**

不能。它僅處理以警告方式回報的可復原情況。獨立於回呼發生的例外必須由應用程式在載入、呈現、轉換或儲存的呼叫周圍自行處理。

**傳回 `ReturnAction.Continue` 是否保證輸出相同？**

不能。它僅允許處理繼續。回報的情況仍可能導致資料、格式或相容性差異，因此請檢查收集到的警告類型與說明。

**應用程式如何識別產生警告的操作？**

為每個操作建立回呼實例，並將應用程式自訂的階段與 `WarningType` 及 `Description` 一同儲存，如範例所示。