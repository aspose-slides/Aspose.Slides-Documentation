---
title: 在 Android 上處理簡報警告
type: docs
weight: 90
url: /zh-hant/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告回呼
- 警告政策
- 資料遺失
- 來源損壞
- 相容性問題
- 字型替換
- 數位簽章
- 簡報載入
- 簡報呈現
- 簡報轉換
- 簡報儲存
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "了解如何在使用 Aspose.Slides for Android（Java）時，於載入、呈現、轉換與儲存簡報的過程中收集、分類並處理警告。"
---
## **概覽**

Aspose.Slides 在載入、呈現、轉換或儲存簡報時，可能會回報可復原的問題。例子包括受損的來源記錄、無法保留的內容、字型替換，以及目標格式的限制。警告回呼讓應用程式記錄這些狀況，並決定目前的操作是否可以繼續。

實作[IWarningCallback](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iwarningcallback/) 介面，並檢查透過[IWarningInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iwarninginfo/) 提供的[getWarningType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) 和[getDescription](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) 值。回傳[ReturnAction.Continue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/returnaction/#Continue) 以接受警告，或回傳[ReturnAction.Abort](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/returnaction/#Abort) 以停止操作。

使用[LoadOptions.setWarningCallback](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 來接收開啟簡報時所拋出的警告。呈現與匯出選項類別繼承[SaveOptions.setWarningCallback](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)，可接收來自投影片呈現、轉換與儲存的警告。由於警告本身不會指明是哪個應用程式操作產生，請在建立綜合報告時，將每個回呼實例與操作階段關聯起來。

## **警告與例外**

警告描述的是 Aspose.Slides 在回呼傳回`ReturnAction.Continue` 時可復原的狀況。例外則表示請求的操作無法正常完成；例外不會被轉換為警告，也無法透過警告政策處理。

回傳`ReturnAction.Abort` 會請求警告調度器透過拋出例外來終止目前的操作。公開的例外類型依操作與簡報格式而異。例如，載入時可能拋出[PptxReadException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxreadexception/)或[PptReadException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptreadexception/)，而儲存或匯出時可能拋出[PptxException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxexception/)。請在操作的邊界處處理例外，並使用警告報告判斷是否因為應用程式政策而終止，而不是僅依賴單一例外子類別或訊息。回呼在回傳`ReturnAction.Abort` 前會先記錄警告，確保原因仍可供應用程式取得。

## **警告類別**

[WarningType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/warningtype/) 類別為以下類別提供整數常數：

| 警告類型 | 含義 | 典型策略 |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | 原始簡報包含的損壞可能導致以其原始格式儲存的文件無法使用。 | 中止。 |
| [DataLoss](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/warningtype/#DataLoss) | 載入或儲存後，文字、圖表、影像或其他資料可能遺失。 | 中止。 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | 簡報可能失去重要的格式設定。 | 嚴格驗證模式下中止；否則記錄後繼續。 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | 可能出現有限的格式差異。 | 記錄以作診斷，然後繼續。 |
| [CompatibilityIssue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | 結果在某些應用程式或較舊版本中可能無法正確開啟或運作。 | 除非相容性為必須，否則記錄並繼續。 |
| [UnexpectedContent](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | 來源包含未支援或未識別的內容，其影響尚未可知。 | 記錄並繼續；在嚴格政策下可視為錯誤。 |

類別應驅動政策決策。請將[getDescription](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) 回傳的值儲存以供診斷，但不要將其文字內容作為應用程式邏輯的依據，因為訊息文字會因警告情境與產品版本而異。

## **收集與分類警告**

以下範例使用單一應用程式層級的報告，涵蓋整個處理管線。不同的回呼實例為載入、呈現、PDF 轉換與 PPTX 儲存分別標記警告。政策在來源損壞或資料遺失時中止，選擇性在重大格式遺失時中止，其他警告則繼續。

將 `input.pptx` 放在可寫入的應用程式目錄中，並將該目錄傳遞給 `PresentationWarningExample.run`。範例會將輸出儲存在同一目錄。請在背景執行緒上執行簡報處理，以保持 Android 使用者介面回應。

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

在建構 `WarningPolicy` 時，若接受較大的格式差異，請將 `abortOnMajorFormattingLoss` 設為 `false`。相容性問題、輕微格式遺失與未預期內容仍會保留在報告中，即使操作繼續。若應用程式必須拒絕任何這些類別，可擴充 `WarningPolicy.getAction`。

## **常見警告情境**

警告可能出現在工作流程的不同階段：

- **數位簽章**：已簽署的簡報在載入時可能產生警告，指出簽章將於處理過程中遺失。Aspose.Slides 透過[IPresentationSignedWarningInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/) 回報此 `DataLoss` 狀況。載入階段的回呼讓應用程式拒絕檔案或明確接受此遺失。
- **字型替換**：當投影片呈現或匯出時，若找不到字型會被替換。字型替換警告會以 `DataLoss` 回報，因此上述嚴格政策會中止，即使應用程式認為特定替換在視覺上可接受。要觀察此行為，請使用包含執行環境未安裝字型的文字的簡報作為輸入。警告描述會指出替換的字型；請在重試前配置必要的字型或[字型替換規則](/slides/zh-hant/androidjava/font-substitution/)。
- **未支援或未預期的內容**：載入器可能遇到未識別的簡報記錄或功能。此類警告可能使用 `UnexpectedContent`，或在資料或格式已知受影響時使用較嚴重的類別。
- **格式相容性**：儲存為其他簡報格式時可能會遺失功能，或產生在某些應用程式中行為不同的結果。例如，將包含超過八條水平或垂直繪圖指南的簡報儲存為舊版 PPT，會回報 `CompatibilityIssue`。儲存階段的回呼可以記錄此遺失並繼續，或在必須保留所有指南時拒絕。
- **載入行為**：載入選項與舊版行為也可能產生警告。例如，[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) 會將使用過時的簡報鎖定行為標記為 `CompatibilityIssue`。

警告取決於來源文件、目標格式、操作以及 Aspose.Slides 版本。不要假設每個檔案都會產生警告，或情境只能對應單一類別。

## **安全處理中止的操作**

當回呼回傳 `ReturnAction.Abort` 時，請勿使用未成功載入的物件，也不要假設呈現或儲存的輸出已完整。操作可能在建立輸出檔案後、完成之前即被終止。

請將驗證過的結果儲存至例如 `validated-output.pptx` 的獨立路徑。僅在操作成功結束、警告報告符合應用程式政策，且輸出可開啟檢查後，才取代既有的簡報。這可避免以部份或被拒絕的結果覆寫有效的來源檔。

空的警告報告並不保證每個來源功能皆被保留。請依應用程式需求執行任何額外的內容與視覺檢查。另請參閱[開啟簡報](/slides/zh-hant/androidjava/open-presentation/)與[儲存簡報](/slides/zh-hant/androidjava/save-presentation/)。

## **FAQ**

**警告回呼能處理每個 Aspose.Slides 錯誤嗎？**

不能。它只能處理以警告形式回報的可復原條件。獨立於回呼發生的例外必須在載入、呈現、轉換或儲存呼叫的外圍由應用程式處理。

**回傳 `ReturnAction.Continue` 是否保證輸出相同？**

不能。它只允許處理繼續。回報的條件仍可能導致資料、格式或相容性差異，請檢查收集到的警告類型與描述。

**應用程式如何辨識產生警告的操作？**

為每個操作建立一個回呼實例，並在儲存由[getWarningType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) 與[getDescription](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) 回傳的值時，一併保存應用程式自訂的階段，如範例所示。