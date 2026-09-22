---
title: 在 Python 中判斷原始簡報格式
linktitle: 來源格式
type: docs
weight: 35
url: /zh-hant/python-net/detect-presentation-source-format/
keywords:
- 來源格式
- 偵測簡報格式
- PowerPoint
- OpenDocument
- 簡報
- PPT
- PPTX
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides for Python via .NET 讀取已載入簡報的原始格式、比較偵測 API，並處理檔案、串流以及舊版格式。"
---
## **概觀**

載入簡報後，讀取唯讀的 [Presentation.source_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/source_format/) 屬性以判斷其原始格式。當後續處理取決於目前實例載入的格式時，請使用它。

來源格式與輸出檔案所選的 [SaveFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/) 不同。儲存為其他格式不會更改現有實例的來源格式。

## **讀取檔案的來源格式**

此範例需要一個現有的 `sample.pptx` 檔案。它載入該檔案並使用 [Presentation.source_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/source_format/) 來選擇應用程式的處理原則，而非檔名。變更輸入路徑即可嘗試其他格式。範例會印出選取的原則；請自行以應用程式邏輯取代這些訊息。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **辨識支援的值**

[SourceFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sourceformat/) 列舉區分以下簡報格式。下列副檔名為慣例性的副檔名，並非原始檔名的復原。

| SourceFormat 值 | 副檔名 | 格式 |
| --- | --- | --- |
| `PPT` | .ppt | PowerPoint 97–2003 簡報 |
| `PPTX` | .pptx | Office Open XML 簡報 |
| `PPTM` | .pptm | 支援巨集的 Office Open XML 簡報 |
| `PPS` | .pps | PowerPoint 97–2003 投影片放映 |
| `PPSX` | .ppsx | Office Open XML 投影片放映 |
| `PPSM` | .ppsm | 支援巨集的 Office Open XML 投影片放映 |
| `POT` | .pot | PowerPoint 97–2003 範本 |
| `POTX` | .potx | Office Open XML 範本 |
| `POTM` | .potm | 支援巨集的 Office Open XML 範本 |
| `ODP` | .odp | OpenDocument 簡報 |
| `OTP` | .otp | OpenDocument 簡報範本 |
| `FODP` | .fodp | Flat XML ODF 簡報 |
| `XML` | .xml | PowerPoint XML 簡報 |

## **讀取串流的來源格式**

此範例需要一個現有的 `sample.pps` 檔案。將其位元組讀入記憶體串流，可模擬沒有檔名的輸入，例如資料庫值或上傳的位元組陣列。[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 建構函式僅接受串流。

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT、PPS 與 POT 使用相同的底層二進位格式。以檔案路徑載入時，副檔名可協助區分投影片放映或範本。若沒有檔名，舊版的 PPS 與 POT 內容可能會被報告為 `SourceFormat.PPT`；上述的 PPS 範例報告 `PPT`。

如果應用程式必須保留此區分，請另行保留原始檔名或子類型的中繼資料。副檔名對於這些舊版子類型是一個有用的提示，但不應成為識別任意簡報內容的唯一依據。

## **比較載入前後的偵測**

當需要在載入完整簡報物件模型之前檢查檔案時，請使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 與 [PresentationInfo.load_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/load_format/)。當實例已存在時，請使用 [Presentation.source_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/source_format/)。

此範例需要 `sample.pptx`，並對兩項檢查皆印出 `PPTX`。在正式環境中，請依據處理階段選擇適當的 API；已載入的簡報不需要再次檢查僅為取得其來源格式。

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

結果具有不同的列舉型別：[LoadFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadformat/) 與 [SourceFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sourceformat/)。請勿透過轉換其數值來比較，亦不要假設每種格式都有相同的偵測結果。在下述的儲存後重新開啟檢查中，PowerPoint XML 在載入前被報告為 `LoadFormat.UNKNOWN`，載入後則為 `SourceFormat.XML`。

## **將來源與輸出格式分開**

此範例需要 `sample.pptx` 並寫入 `converted.odp`。它在儲存原始實例前後皆印出 `PPTX`。只有從 ODP 輸出載入的新實例會報告 `ODP`。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

使用 `slides.Presentation()` 從頭建立的簡報會報告 `SourceFormat.PPTX`。它沒有輸入檔案：這是新建立實例的預設值，並不代表已載入 PPTX 檔案。如需區分此差異，請另行追蹤應用程式是自行建立還是載入實例。

## **將來源格式對映到副檔名**

以下範例需要 `sample.pptx`。它將每個目前支援的 [SourceFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sourceformat/) 值對映到慣例的副檔名，而不解析輸入檔名。此備援機制可避免在未識別的值上默默指派副檔名。

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

此對映不會轉換檔案或復原在串流載入時遺失的舊版 PPS/POT 子類型。實際儲存時，請明確選擇 [SaveFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/)，或使用在 [Save Presentations in Their Original Format](/slides/zh-hant/python-net/save-presentation/#save-presentations-in-their-original-format) 中示範的轉換方式。

## **透過儲存與重新開啟驗證格式**

此獨立範例會建立簡報並在工作目錄寫入三個檔案，若同名檔案已存在則覆寫。它會以路徑與記憶體串流兩種方式重新開啟每個輸出。對於 PPTX 與 ODP，兩種方式皆回報儲存的格式。對於 PPS，透過路徑載入回報 `PPS`，而以無檔名的相同位元組載入則回報 `PPT`。

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

對上述所有列出的格式進行相同檢查，對於具有相符副檔名的產生簡報，得到以下結果：

| 已儲存格式 | 檔案路徑的 SourceFormat | 無檔名串流的 SourceFormat |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` 分別 | 與檔案路徑相同 |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` 分別 | 與檔案路徑相同 |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` 分別 | 與檔案路徑相同 |
| ODP, OTP | `ODP`, `OTP` 分別 | 與檔案路徑相同 |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

在這些檢查中，唯一的來源格式正規化是將無檔名串流的 PPS/POT 轉為 `PPT`。此表說明格式辨識，而非在轉換過程中保留每項簡報功能。

## **FAQ**

**將簡報從 PPTX 儲存為 ODP 會改變其來源格式嗎？**

不會。現有的實例仍報告 `PPTX`。從已儲存的 ODP 檔案載入的實例則報告 `ODP`。

**串流能否永遠區分舊版簡報、投影片放映與範本？**

不能。PPT、PPS 與 POT 共享相同的二進位格式。當需要此區分時，請另行保留檔名或子類型中繼資料。

**如果簡報已經載入，應該使用哪個 API？**

請讀取 [Presentation.source_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/source_format/)。在載入前檢查時，請使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/)。