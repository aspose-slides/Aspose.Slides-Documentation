---
title: 在 Java 中處理簡報警告
type: docs
weight: 90
url: /zh-hant/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告回呼
- 警告政策
- 資料遺失
- 來源損壞
- 相容性問題
- 字型替代
- 數位簽章
- 簡報載入
- 簡報轉譯
- 簡報轉換
- 簡報儲存
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "了解如何在使用 Aspose.Slides for Java 時，於載入、轉譯、轉換與儲存簡報的過程中收集、分類並處理警告。"
---
## **概覽**

Aspose.Slides 可以在載入、轉譯、轉換或儲存簡報時回報可恢復的問題。範例包括受損的來源記錄、無法保留的內容、字型替代以及目標格式的限制。警告回呼允許應用程式記錄這些情況，並決定目前的操作是否可以繼續。

實作 [IWarningCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarningcallback/) 介面，並檢查透過 [IWarningInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/) 提供的 [getWarningType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getWarningType--) 與 [getDescription](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getDescription--) 值。傳回 [ReturnAction.Continue](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/returnaction/#Continue) 以接受警告，或傳回 [ReturnAction.Abort](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/returnaction/#Abort) 以停止操作。

使用 [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 處理開啟簡報時產生的警告。轉譯與匯出選項類別繼承自 [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)，它會接收來自投影片轉譯、轉換與儲存的警告。由於警告本身不會標示應用程式的操作，請在建立合併報告時將每個回呼實例與操作階段關聯起來。

## **警告與例外**

警告描述了一種狀況，只要回呼傳回 `ReturnAction.Continue`，Aspose.Slides 即可從中恢復。例外則表示請求的操作無法正常完成；例外不會轉換為警告，也無法透過警告策略處理。

傳回 `ReturnAction.Abort` 會要求警告分派器透過拋出例外來終止目前的操作。公開的例外類型取決於操作與簡報格式。例如，載入時可能會拋出 [PptxReadException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxreadexception/) 或 [PptReadException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptreadexception/)，而儲存或匯出時可能會拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxexception/)。在操作邊界處處理例外，並使用警告報告來判斷是否因應用程式政策導致終止，而不是僅依賴單一例外子類別或訊息。回呼會在傳回 `ReturnAction.Abort` 之前記錄警告，確保原因仍可供應用程式使用。

## **警告類別**

[WarningType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/warningtype/) 類別提供以下類別的整數常數：

| 警告類型 | 含義 | 常見策略 |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/warningtype/#SourceFileCorruption) | 來源簡報包含損壞，可能導致以原始格式儲存的文件無法使用。 | 中止。 |
| [DataLoss](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/warningtype/#DataLoss) | 載入或儲存後，文字、圖表、影像或其他資料可能遺失。 | 中止。 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | 簡報可能失去重要的格式設定。 | 在嚴格驗證模式下中止；否則記錄並繼續。 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | 可能會出現有限的格式差異。 | 記錄以供診斷，然後繼續。 |
| [CompatibilityIssue](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/warningtype/#CompatibilityIssue) | 結果可能無法在某些應用程式或舊版中開啟或正確運作。 | 記錄並繼續，除非相容性是必須的。 |
| [UnexpectedContent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/warningtype/#UnexpectedContent) | 來源包含未支援或未辨識的內容，其影響尚不明確。 | 記錄並繼續，或在嚴格政策下視為錯誤。 |

類別應該驅動策略決策。將 [getDescription](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getDescription--) 回傳的值存起來作為診斷依據，但不要在應用程式邏輯上依賴其文字描述，因為訊息文字可能因警告情境和產品版本而異。

## **收集與分類警告**

以下範例使用單一應用程式層級的報告來覆蓋完整的處理管線。每個回呼實例分別為載入、轉譯、PDF 轉換與 PPTX 儲存的警告標記。策略在來源損壞或資料遺失時中止，選擇性在主要格式遺失時中止，其他警告則繼續。

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

在建立 `WarningPolicy` 時，若主要格式差異是可接受的，請將 `abortOnMajorFormattingLoss` 設為 `false`。即使操作繼續，報告中仍會保留相容性問題、次要格式遺失及未預期內容。若應用程式必須拒絕其中任一類別，請擴充 `WarningPolicy.getAction`。

## **常見警告情境**

警告可能在工作流程的不同階段出現：

- **數位簽章：** 已簽名的簡報在載入時可能產生警告，指出其簽章在處理過程中將遺失。Aspose.Slides 透過 [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationsignedwarninginfo/) 回報此 `DataLoss` 狀況。載入階段的回呼允許應用程式拒絕檔案或明確接受此遺失。
- **字型替代：** 當投影片轉譯或匯出時，若字型不在系統中，會被替換。字型替代警告以 `DataLoss` 回報，因此上述嚴格政策會中止，即使應用程式認為某個替代在視覺上可接受。要觀察此行為，請使用包含執行環境中不存在之字型文字的輸入簡報。警告描述會指出替代的字型；請在重試前設定所需字型或 [font substitution rules](/slides/zh-hant/java/font-substitution/)。
- **不支援或未預期的內容：** 載入器可能遇到它無法辨識的簡報記錄或功能。此類警告可能使用 `UnexpectedContent`，或在已知資料或格式受到影響時使用更嚴重的類別。
- **格式相容性：** 儲存為其他簡報格式可能會遺漏功能，或產生在某些應用程式中行為不同的結果。例如，將含有超過八條水平或八條垂直繪圖參考線的簡報儲存為舊版 PPT，會回報 `CompatibilityIssue`。儲存階段的回呼可以記錄此遺失並繼續，或在必須保留所有參考線時予以拒絕。
- **載入行為：** 載入選項與舊版行為也可能產生警告。例如，[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) 會將使用過時的簡報鎖定行為識別為 `CompatibilityIssue`。

警告取決於來源文件、目標格式、操作以及 Aspose.Slides 版本。不要假設每個檔案都會產生警告，或某個情境必定僅對應單一類別。

## **安全處理中止的操作**

當回呼傳回 `ReturnAction.Abort` 時，不要使用載入失敗的物件，也不要假設轉譯或儲存的輸出已完成。操作可能在建立輸出檔案後、完成之前即被終止。

將驗證後的結果儲存至例如 `validated-output.pptx` 的不同路徑。僅在操作成功完成、警告報告符合應用程式政策且輸出能開啟並檢查後，才取代已存在的簡報。此做法可避免以部分或被拒絕的結果覆寫有效的來源檔案。

空的警告報告並不保證已保留每個來源特性。請執行應用程式所需的任何額外內容與視覺檢查。另請參閱 [Open Presentations](/slides/zh-hant/java/open-presentation/) 與 [Save Presentations](/slides/zh-hant/java/save-presentation/)。

## **常見問題**

**警告回呼能處理每一個 Aspose.Slides 錯誤嗎？**

否。它僅處理以警告形式回報的可恢復狀況。與回呼無關的例外必須由應用程式在載入、轉譯、轉換或儲存呼叫周圍自行處理。

**傳回 `ReturnAction.Continue` 能保證輸出完全相同嗎？**

否。它僅允許處理繼續。回報的狀況仍可能導致資料、格式或相容性差異，請檢閱收集到的警告類型與描述。

**應用程式如何辨識產生警告的操作？**

如範例所示，為每個操作建立回呼實例，並將應用程式自訂的階段與 [getWarningType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getWarningType--) 與 [getDescription](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarninginfo/#getDescription--) 回傳的值一起儲存。