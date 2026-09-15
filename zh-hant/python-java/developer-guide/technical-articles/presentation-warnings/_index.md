---
title: 在 Python（透過 Java）中處理投影片警告
type: docs
weight: 90
url: /zh-hant/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告回呼
- 警告政策
- 資料遺失
- 來源損毀
- 相容性問題
- 字型置換
- 數位簽章
- 投影片載入
- 投影片呈現
- 投影片轉換
- 投影片儲存
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "了解如何在使用 Aspose.Slides for Python（透過 Java）載入、呈現、轉換與儲存投影片時，收集、分類並處理警告。"
---
## **概觀**

Aspose.Slides 能在載入、呈現、轉換或儲存投影片時回報可復原的問題。例子包括受損的來源記錄、無法保留的內容、字型置換以及目標格式的限制。警告回呼讓應用程式記錄這些情況，並決定目前的操作是否可以繼續。

透過 `jpype.JProxy` 實作 `IWarningCallback` 介面，並檢查由 `IWarningInfo` 提供的 `getWarningType` 與 `getDescription` 值。傳回 [ReturnAction.Continue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/returnaction/#Continue) 以接受警告，或傳回 [ReturnAction.Abort](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/returnaction/#Abort) 以停止操作。

在開啟投影片時，使用 [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setWarningCallback) 來處理警告。呈現與匯出選項類別繼承自 [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveoptions/#setWarningCallback)，可接收來自投影片呈現、轉換與儲存的警告。由於警告本身不會指明應用程式的操作，請在建立合併報告時，將每個回呼實例與相應的操作階段關聯起來。

## **警告與例外**

警告描述了 Aspose.Slides 在回呼傳回 `ReturnAction.Continue` 時可復原的情況。例外表示請求的操作無法正常完成；例外不會被轉換為警告，也無法透過警告政策處理。

傳回 `ReturnAction.Abort` 會請求警告分派器透過拋出例外來終止目前的操作。公開的例外類型取決於操作及投影片格式。例如，載入時可能拋出 [PptxReadException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxreadexception/) 或 [PptReadException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptreadexception/)，而儲存或匯出時可能拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxexception/)。請在操作邊界處處理例外，並使用警告報告來判斷是否因應用程式政策導致終止，而不是僅依賴單一例外子類別或訊息。回呼在傳回 `ReturnAction.Abort` 之前會先記錄警告，確保原因仍可供應用程式使用。

## **警告類別**

[WarningType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/warningtype/) 類別提供以下類別的整數常數：

| 警告類型 | 意義 | 典型政策 |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/warningtype/#SourceFileCorruption) | 來源投影片包含損毀，可能導致以原始格式儲存的文件無法使用。 | 中止。 |
| [DataLoss](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/warningtype/#DataLoss) | 載入或儲存後，文字、圖表、影像或其他資料可能缺失。 | 中止。 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | 投影片可能失去重要的格式。 | 在嚴格驗證模式下中止；否則記錄並繼續。 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | 可能出現有限的格式差異。 | 記錄以供診斷，並繼續。 |
| [CompatibilityIssue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/warningtype/#CompatibilityIssue) | 結果可能無法在某些應用程式或較舊版本中開啟或正確運作。 | 記錄並繼續，除非相容性是必須的。 |
| [UnexpectedContent](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/warningtype/#UnexpectedContent) | 來源包含未支援或未辨識的內容，其影響可能尚未可知。 | 記錄並繼續，或在嚴格政策下視為錯誤。 |

類別應決定政策的判斷。將 `getDescription` 回傳的值儲存以供診斷使用，但不要依賴其文字內容作為應用程式邏輯，因為訊息文字可能在不同警告情境與產品版本間有所變化。

## **收集與分類警告**

以下範例為整個處理流程使用單一應用層級報告。獨立的回呼實例會為載入、呈現、PDF 轉換與 PPTX 儲存的警告加上標記。政策在來源損毀或資料遺失時中止，亦可選擇在重大格式遺失時中止，其餘警告則繼續。

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

在建立 `WarningPolicy` 時，若接受重大格式差異，請將 `abort_on_major_formatting_loss` 設為 `False`。即使操作繼續，報告仍會保留相容性問題、次要格式遺失與未預期內容。若應用程式必須拒絕上述任何類別，請擴充 `WarningPolicy.get_action`。

## **常見警告情境**

警告可能在工作流程的不同階段出現：

- **數位簽章：** 已簽署的投影片在載入時可能產生警告，指出其簽章在處理過程中會遺失。Aspose.Slides 透過 `IPresentationSignedWarningInfo` 報告此 `DataLoss` 情況。載入階段的回呼允許應用程式拒絕此檔案或明確接受報告的遺失。
- **字型置換：** 當投影片呈現或匯出時，若字型不可用，會被替換。字型置換警告會以 `DataLoss` 報告，因此上述嚴格政策會中止，即使應用程式認為特定替換在視覺上可接受。要觀察此行為，請使用包含執行環境無法使用之字型文字的輸入投影片。警告說明會指出置換的細節；請在重試前設定必要的字型或 [字型置換規則](/slides/zh-hant/python-java/font-substitution/)。
- **不支援或未預期的內容：** 載入器可能遇到無法辨識的投影片記錄或功能。此類警告可能使用 `UnexpectedContent`，或在已知資料或格式受影響時使用更嚴重的類別。
- **格式相容性：** 儲存為其他投影片格式可能會遺漏功能，或產生在某些應用程式中表現不同的結果。例如，將包含超過八條水平或八條垂直繪圖參考線的投影片儲存為舊版 PPT 會報告 `CompatibilityIssue`。儲存階段的回呼可以記錄此遺失並繼續，或在必須保留所有參考線時予以拒絕。
- **載入行為：** 載入選項和舊版行為也可能產生警告。例如，`IObsoletePresLockingBehaviorWarningInfo` 會將使用過時的投影片鎖定行為識別為 `CompatibilityIssue`。

警告取決於來源文件、目標格式、操作以及 Aspose.Slides 版本。不要假設每個檔案都會產生警告，或某個情境必一定對應唯一一個類別。

## **安全處理被中止的操作**

當回呼傳回 `ReturnAction.Abort` 時，請勿使用載入失敗的物件，也不要假設呈現或儲存的輸出已完整。操作可能在建立輸出檔案後、完成之前即終止。

將驗證後的結果儲存至不同路徑，例如 `validated-output.pptx`。僅在操作成功完成、警告報告符合應用程式政策且輸出可被開啟與檢查後，才取代既有的投影片。這可避免以部分或被拒絕的結果覆寫有效的來源檔案。

空的警告報告並不保證已保留所有來源特徵。請執行應用程式所需的任何額外內容與視覺檢查。另請參閱 [開啟投影片](/slides/zh-hant/python-java/open-presentation/) 與 [儲存投影片](/slides/zh-hant/python-java/save-presentation/)。

## **常見問題**

**警告回呼能處理每個 Aspose.Slides 錯誤嗎？**

不行。它僅處理以警告形式回報的可復原情況。與回呼無關的例外必須由應用程式在載入、呈現、轉換或儲存呼叫周圍自行處理。

**傳回 `ReturnAction.Continue` 是否保證輸出相同？**

不會。它僅允許處理繼續。回報的情況仍可能造成資料、格式或相容性差異，因此請檢閱收集到的警告類型與說明。

**應用程式如何辨識產生警告的操作？**

為每個操作建立回呼實例，並將應用程式自訂的階段與 `getWarningType`、`getDescription` 回傳的值一同儲存，如範例所示。