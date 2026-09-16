---
title: 在 Python via Java 中將簡報匯出為 XAML
linktitle: 簡報匯出為 XAML
type: docs
weight: 30
url: /zh-hant/python-java/export-to-xaml/
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
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 將 PowerPoint 與 OpenDocument 簡報匯出為 XAML。可使用預設選項或包含隱藏投影片。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Python via Java 將 PowerPoint 簡報匯出為 XAML。內容包括 XAML 的簡短介紹、展示如何使用預設設定將簡報儲存為 XAML，以及說明如何透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/) 自訂匯出行為，包括匯出隱藏投影片。本文亦回答有關備用字型、XAML 堆疊相容性以及隱藏投影片匯出行為的常見問題。

範例需要 Aspose.Slides for Python via Java 與相容的 Java 執行環境。請將 `pres.pptx` 放在目前的工作目錄。每個範例僅在 JVM 尚未啟動時才會啟動 JVM。

## **關於 XAML**

XAML 是一種基於 XML 的標記語言，用於描述 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）以及 Xamarin.Forms 等框架中的使用者介面。

您可以在視覺設計器中使用 XAML 檔案，或直接編寫與編輯標記。

## **使用預設選項將簡報匯出為 XAML**

以下 Python 範例示範如何使用預設設定將簡報匯出為 XAML：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

預設情況下，匯出的投影片會儲存在處理程序目前工作目錄的 `pres` 子資料夾中。資料夾會自動建立，任何必要的圖像也會儲存在該資料夾內。

輸出資料夾名稱取自來源檔案名稱（不含副檔名）。對於 `pres.pptx`，輸出檔案會命名為 `pres/Slide_1.xaml`、`pres/Slide_2.xaml` 等。即使您傳入絕對路徑作為輸入簡報，輸出資料夾仍相對於目前工作目錄建立，而不是與輸入檔案共置。

## **使用自訂選項將簡報匯出為 XAML**

使用 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/) 類別來控制 Aspose.Slides 如何將簡報匯出為 XAML。

若要將輸出儲存至自訂位置，請實作 `IXamlOutputSaver`，並將您的實作實例傳遞給 [setOutputSaver](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/#setOutputSaver) 方法（屬於 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/)）。

若要在 XAML 輸出中包含隱藏投影片，請如以下 Python 範例所示，以 `True` 呼叫 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/#setExportHiddenSlides)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **捕獲所有產生的 XAML 輸出項目**

XAML 匯出可能為每張匯出的投影片產生一個 XAML 文件，外加獨立的圖像與支援資源。將自訂 `IXamlOutputSaver` 指派給 [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/#setOutputSaver) 以取得這些產出，而非使用預設的檔案系統儲存器。使用接受 XAML 選項的 XAML 專用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 重載來開始匯出。

在 Python 中，使用 `jpype.JProxy` 來實作 Java 的 `IXamlOutputSaver` 介面。將回呼路徑轉換為 `str`，並在返回之前將 Java 位元組陣列複製為 Python `bytes`，如下所示。

### **了解回呼生命週期**

匯出程式會對每個產生的產出個別呼叫 `IXamlOutputSaver.save`：

- `path` 用於識別產出，可能包含相對目錄。請保留此資訊，因為 XAML 可能使用相對路徑參照資源。
- `data` 包含產出的位元組。圖像與其他二進位資源不得被解碼為文字。
- 儲存器必須在返回前保留或持久化資料。範例會將每個位元組陣列複製到應用程式擁有的記憶體中。
- 只有當簡報的儲存操作返回且每個回呼皆成功完成時，才視為匯出成功。不要吞掉儲存錯誤或啟動未觀察的背景寫入。如果持久化在之後發生，僅在該步驟也成功後才報告整體成功。

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) 亦適用於自訂儲存器。預設為 `False`，會排除隱藏投影片的 XAML 文件。傳入 `True` 則會包含它們以及匯出所需的任何資源。資源數量取決於簡報內容；不要假設每張投影片只有一個回呼或回呼順序固定。

### **匯出至記憶體並檢查輸出項目**

此完整範例載入 `pres.pptx`，將每個產出收集於 Python 字典（鍵為名稱，值為不可變的 `bytes`），並列印其名稱、類型與位元組數。名稱會完整保留。若出現重複名稱，會將集合標記為無效而非靜默覆寫。範例在使用結果前會先檢查此情況。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # 僅解碼 XAML，且僅在需要文字檢查時。
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

副檔名檢查對於檢查很有幫助；保留所有產出，包括不熟悉的資源類型。存取或傳輸時請保持位元組不變。僅在需要文字處理的 XAML 上使用 `bytes.decode` 且使用 UTF-8 編碼。

### **將收集的輸出項目打包成 ZIP 壓縮檔**

此獨立範例收集匯出結果、驗證名稱，並將原始位元組寫入 ZIP 壓縮檔。唯一的壓縮檔名稱可區分同時進行的匯出工作。ZIP 條目使用正斜線並保留相對目錄。若名稱不安全或正規化後發生衝突，會在寫入前拒絕整個封包。

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # 關閉會在報告成功之前完成 ZIP 目錄的最終寫入。
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

範例使用 Python 的 `zipfile.ZipFile` 寫入本機壓縮檔；匯出程式本身不會寫入分散的 XAML 或圖像檔。若需遠端儲存，請將寫入壓縮檔的階段改為上傳已收集的位元組陣列。可使用匯出工作識別碼加上完整相對產出名稱作為 Blob 鍵，或將工作識別碼、相對名稱與二進位資料存入資料庫列。只有在所有上傳完成或資料庫交易提交後才發布工作。若持久化失敗，請清除部分輸出。

對於大型簡報，自訂儲存器可直接將每個產出持久化至應用程式儲存，以避免在記憶體中保留整個匯出的額外副本。從匯出程式的觀點來看，請保持每個回呼同步：僅在目標已接受位元組後返回，並允許失敗傳遞給呼叫端。

### **保留資源名稱並驗證參照**

- 正規化路徑分隔符（如果目的地需要），但仍保留相對目錄。除非每個產生的名稱已知唯一且資源參照仍然有效，否則請不要僅使用 `pathlib.Path.name`。
- 套用目的地特定的名稱驗證。寫入分散檔案時，拒絕根路徑與目錄遍歷段，使用 `pathlib.Path.resolve` 解析目的地，並驗證其仍位於預期的匯出目錄之下（包含目錄分隔符的包含檢查）。使用不含符號連結且不會重新導向寫入的應用程式受控目錄。
- 為每個匯出工作使用獨立的儲存器與命名空間。在分隔符正規化後以及依據目的地的大小寫敏感規則偵測衝突。
- 發佈前，將每個 XAML 文件以 XML 方式解析，並檢查檔案型資源參照，例如圖像的 `Source` 或 `ImageSource` 屬性。將每個相對 URI 以包含該 XAML 產出之目錄為基礎解析，正規化得到的儲存名稱，並確認相應的字典鍵、ZIP 條目或已儲存的物件是否存在。外部 URI 與 XAML 標記表達式應與相對檔名分開處理。

例如，若 `pres/Slide_1.xaml` 參照 `images/image1.png`，則必須以 `pres/images/image1.png` 的形式提供該資源。僅保留 `image1.png` 會破壞此關係。若使用物件儲存，請在工作前綴之下保留相同的目錄結構，並讓這些資源 URL 可供 XAML 消費者存取。重新開啟完成的 ZIP 以驗證條目名稱與資源位元組，並在目標 XAML 環境中載入代表性投影片，以確認圖像能正確解析。

## **常見問題**

**如果原始字型在機器上不可用，如何確保字型的可預測性？**

在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/) 中呼叫 [setDefaultRegularFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveoptions/#setDefaultRegularFont)——匯出時缺少原始字型時會使用此字型作為備用。這並不保證產生的 XAML 會引用備用字型，或該字型在目標機器上可用。請確保 XAML 所參照的字型在顯示環境中可取得。

**匯出的 XAML 僅適用於 WPF，還是可以在其他 XAML 堆疊中使用？**

Aspose.Slides 透過公開 API 匯出 WPF XAML。與其他 XAML 堆疊（例如 UWP 與 Xamarin.Forms）的相容性未保證。請在目標環境中測試產生的標記。

**是否支援隱藏投影片，且如何防止它們預設被匯出？**

預設情況下不會包含隱藏投影片。您可以透過在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/) 中的 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) 來控制此行為——若不需要匯出，請保持其關閉。