---
title: 在 Python via Java 中確定原始簡報格式
linktitle: 來源格式
type: docs
weight: 35
url: /zh-hant/python-java/detect-presentation-source-format/
keywords:
- 來源格式
- 偵測簡報格式
- PowerPoint
- OpenDocument
- 簡報
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，在 Python via Java 中讀取已載入簡報的原始格式、比較偵測 API，並處理檔案、串流及傳統格式。"
---
## **概覽**

載入簡報後，呼叫 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSourceFormat) 方法以判斷其原始格式。當後續處理取決於載入此實例的格式時，請使用它。

來源格式不同於為輸出檔案所選取的 [SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/)。將檔案另存為其他格式不會變更現有實例的來源格式。

此範例需要 Aspose.Slides for Python via Java 以及相容的 Java 執行環境。若 JVM 尚未啟動，每個範例都會啟動它。

## **讀取檔案的來源格式**

此範例需要一個已存在的 `sample.pptx` 檔案。它會載入該檔案，並使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSourceFormat) 來選取應用程式的處理原則，而非依檔名。變更輸入路徑即可測試其他格式。範例會印出所選的原則；您可以將訊息替換為自己的應用程式邏輯。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **辨識支援的值**

[SourceFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sourceformat/) 類別定義了用於區分以下簡報格式的整數常數。下方的副檔名為慣用副檔名，並非重新建構原始檔名。

| SourceFormat 值 | 副檔名 | 格式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 簡報 |
| `Pptx` | `.pptx` | Office Open XML 簡報 |
| `Pptm` | `.pptm` | 可啟用巨集的 Office Open XML 簡報 |
| `Pps` | `.pps` | PowerPoint 97–2003 投影片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 投影片放映 |
| `Ppsm` | `.ppsm` | 可啟用巨集的 Office Open XML 投影片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 範本 |
| `Potx` | `.potx` | Office Open XML 範本 |
| `Potm` | `.potm` | 可啟用巨集的 Office Open XML 範本 |
| `Odp` | `.odp` | OpenDocument 簡報 |
| `Otp` | `.otp` | OpenDocument 簡報範本 |
| `Fodp` | `.fodp` | Flat XML ODF 簡報 |
| `Xml` | `.xml` | PowerPoint XML 簡報 |

## **讀取串流的來源格式**

此範例需要一個已存在的 `sample.pps` 檔案。將其位元組讀入記憶體串流可模擬未提供檔名的輸入，例如資料庫值或上傳的位元組陣列。[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 建構函式僅接受串流。Python 讀取檔案位元組，而 JPype 會將其轉換為 Java 位元組陣列，以供 Java 記憶體串流使用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT、PPS 與 POT 使用相同的底層二進位格式。透過檔案路徑載入時，副檔名可協助區分投影片放映或範本。若無檔名，傳統的 PPS 與 POT 內容可能會被報告為 `SourceFormat.Ppt`；上述 PPS 範例會印出 `SourceFormat.Ppt` 的整數值。

若您的應用程式必須保留此區分，請另行保存原始檔名或子類型中繼資料。副檔名對於這些傳統子類型是一個有用的提示，但不應成為識別任意簡報內容的唯一依據。

## **比較載入前後的偵測**

當需要在載入完整簡報物件模型之前檢查檔案時，使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 和 [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#getLoadFormat)。當實例已存在時，請使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSourceFormat)。

此範例需要 `sample.pptx`，分別印出 `LoadFormat.Pptx` 與 `SourceFormat.Pptx` 的整數值。於正式環境中，請依處理階段選擇適當的 API；已載入的簡報不需要為取得來源格式而再次檢查。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

結果使用不同類別的常數：[LoadFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadformat/) 與 [SourceFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sourceformat/)。請勿比較它們的數值或假設每種格式的偵測結果相同。PowerPoint XML 在載入前可能被報告為 `LoadFormat.Unknown`，載入後則為 `SourceFormat.Xml`。

## **分開來源與輸出格式**

此範例需要 `sample.pptx`，並寫入 `converted.odp`。它在儲存原始實例前後皆印出 `SourceFormat.Pptx` 的整數值。只有從 ODP 輸出載入的新實例會報告 `Odp`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

使用 `Presentation()` 從頭建立的簡報會報告 `SourceFormat.Pptx`。它沒有輸入檔案：這是新建立實例的預設值，並非已載入 PPTX 檔案的證據。若此區分重要，請另行追蹤您的應用程式是建立還是載入了實例。

## **將來源格式映射至副檔名**

以下範例需要 `sample.pptx`。它將目前支援的每個 [SourceFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sourceformat/) 值映射至慣用副檔名，且不解析輸入檔名。備援機制可避免悄悄將副檔名指派給未識別的值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

此映射不會轉換檔案，也不會復原在串流載入時遺失的傳統 PPS/POT 子類型。實際儲存時，請明確選取 [SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/)，或使用在 [Save Presentations in Their Original Format](/slides/zh-hant/python-java/save-presentation/#save-presentations-in-their-original-format) 中示範的轉換方式。

## **透過儲存與重新開啟驗證格式**

此獨立範例會建立簡報，並在工作目錄寫入三個檔案，若同名檔案存在則會覆寫。它會同時以路徑及記憶體串流重新開啟每個輸出。對於 PPTX 與 ODP，兩種方式皆報告儲存的格式。對於 PPS，透過路徑載入會報告 `Pps`，而在無檔名的情況下載入相同位元組則會報告 `Ppt`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

下表彙總了具有相同副檔名的簡報之來源格式辨識。名稱代表常數；Python 範例會印出其整數值：

| 已儲存格式 | 檔案路徑的 SourceFormat | 無檔名串流的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` 分別 | 同檔案路徑相同 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` 分別 | 同檔案路徑相同 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` 分別 | 同檔案路徑相同 |
| ODP, OTP | `Odp`, `Otp` 分別 | 同檔案路徑相同 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS / POT 內容在無檔名的串流中會被辨識為 `Ppt`。此表說明的是格式辨識，而非在轉換過程中保留每項簡報功能。

## **常見問題**

**將已從 PPTX 載入的簡報儲存為 ODP 會改變其來源格式嗎？**

不會。現有的實例仍會報告 `Pptx`。從已儲存的 ODP 檔案載入的實例則會報告 `Odp`。

**串流是否總能區分傳統簡報、投影片放映與範本？**

不會。PPT、PPS 與 POT 共享相同的二進位格式。若需要此區分，請另行保存檔名或子類型中繼資料。

**如果簡報已載入，我應該使用哪個 API？**

請閱讀 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSourceFormat)。若在載入之前需要檢查，請使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/#getPresentationInfo)。