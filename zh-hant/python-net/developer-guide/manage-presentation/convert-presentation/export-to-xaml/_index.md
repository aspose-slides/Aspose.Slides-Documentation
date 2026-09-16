---
title: 使用 Python 匯出簡報為 XAML
linktitle: 簡報匯出至 XAML
type: docs
weight: 30
url: /zh-hant/python-net/export-to-xaml/
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
- Aspose.Slides
description: "使用 Aspose.Slides 以 Python 將 PowerPoint 與 OpenDocument 投影片轉換為 XAML——快速、無需 Office 的解決方案，保留您的版面配置。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報匯出為 XAML。內容包括 XAML 的簡要介紹、示範使用預設設定將簡報儲存為 XAML，以及透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/) 自訂匯出（包括匯出隱藏投影片）的方式。還會回答有關備援字型、XAML 堆疊相容性以及隱藏投影片匯出行為的常見問題。

## **關於 XAML**

XAML 是一種基於 XML 的標記語言，用於描述 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin.Forms 等框架中的使用者介面。

您可以在視覺設計師中使用 XAML 檔案，或直接編寫與編輯標記。

## **使用預設選項將簡報匯出為 XAML**

以下 Python 範例示範如何使用預設設定將簡報匯出為 XAML：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

預設情況下，匯出的投影片會儲存在處理程序目前工作目錄的 `pres` 子資料夾中，該目錄由 [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd) 取得。資料夾會自動建立，所需的圖片也會儲存於同處。

輸出資料夾的名稱取自來源檔案名稱（不含副檔名）。以 `pres.pptx` 為例，輸出檔案會命名為 `pres/Slide_1.xaml`、`pres/Slide_2.xaml`，以此類推。即使您傳入絕對路徑的輸入簡報，輸出資料夾仍會相對於目前工作目錄建立，而不是與輸入檔案同層。

## **使用自訂選項將簡報匯出為 XAML**

使用 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/) 類別來控制 Aspose.Slides 如何將簡報匯出為 XAML。

若要在 XAML 輸出中包含隱藏投影片，請將 [export_hidden_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) 屬性設為 `True`，如下 Python 範例所示：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **擷取所有產生的 XAML 產物**

XAML 匯出可能為每張匯出的投影片產生一個 XAML 文件，並另外產生圖片與支援資源。儲存或傳輸匯出結果時，請保留全部檔案。

以下範例使用預設的檔案系統儲存程式於暫存目錄中，然後收集產生的檔案。

### **了解匯出生命週期**

- 使用接受 XAML 選項的 XAML 專屬 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 方法啟動匯出。只有在它成功返回後才讀取產生的檔案。
- 保留每個產物的相對路徑，因為 XAML 可能會使用相對路徑參照資源。
- 以位元組方式讀取產物。圖片及其他二進位資源不可解碼為文字。
- 僅在完成收集及後續儲存操作後才回報整體成功。讓儲存錯誤傳回呼叫端，若持久化失敗則清除部分輸出。

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) 之預設值為 `False`，會排除隱藏投影片的 XAML 文件。將其設為 `True` 即會包含這些文件以及匯出所需的資源。資源數量取決於簡報本身，請勿假設每張投影片只會產生一個檔案。

{{% alert color="warning" title="Warning" %}}
The examples temporarily change the process's current working directory, which affects all threads. Run each export in a dedicated worker process, or ensure that no other work in the process depends on the current directory during export. A unique temporary directory alone does not make concurrent exports in the same process safe.
{{% /alert %}}

### **匯出至記憶體並檢查產物**

此完整範例載入 `pres.pptx`，將其匯出至暫存目錄，將每個產物以相對名稱與位元組儲存於字典，並列印名稱、類型與位元組數。它會保留產生的目錄結構，並在收集後移除暫存檔案。輸入路徑會在變更工作目錄前先行解析。

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # 只解碼 XAML，且僅在需要文字檢查時才執行。
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

擴充名檢查對檢查很有幫助；請保留所有產物，即使是未知類型的資源。儲存或傳輸時請保持位元組不變。僅對需要文字處理的 XAML 進行解碼。此做法同時使用暫存磁碟空間與記憶體來收集匯出結果。

### **將收集的產物打包成 ZIP 壓縮檔**

此獨立範例收集匯出結果、驗證名稱，並將原始位元組寫入 ZIP 壓縮檔。唯一的壓縮檔名稱可區分不同的匯出作業。ZIP 條目使用正斜線並保留相對目錄。若名稱在正規化後衝突或不安全，則在寫入前拒絕整個套件。

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # ZIP 目錄已在回報成功之前完成。
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

範例使用 [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) 在收集完暫存匯出後寫入單一本地壓縮檔。若改為遠端儲存，請將寫入階段取代為上傳收集到的位元組。使用匯出作業識別碼加上完整相對產物名稱作為物件鍵，或將作業識別碼、相對名稱與二進位資料存入資料庫列。僅在所有上傳完成或資料庫交易提交後才發布作業，若持久化失敗則清除部分輸出。

對於大型簡報，請在匯出後一次處理一個暫存檔案，而不是將全部位元組收集至字典。這可避免額外的整體匯出記憶體拷貝，但不會減少匯出程式本身的記憶體需求。

### **保留資源名稱並驗證參照**

- 目的地若有需求請正規化路徑分隔符，但仍保留相對目錄。除非所有產生的名稱皆唯一且資源參照仍然有效，否則不要僅保存最終檔名。
- 套用目的地特定的名稱驗證。寫入鬆散檔案時，請拒絕絕對路徑與遍歷段落，解析目的地後確認仍位於預期的匯出目錄之下。使用未包含可能重導寫入的符號連結的受控目錄。
- 為每個匯出作業使用獨立的儲存命名空間。依照分隔符正規化結果與目的地的大小寫敏感規則偵測衝突。
- 發布前，將每個 XAML 文件作為 XML 解析，檢查其基於檔案的資源參照，例如圖片的 `Source` 或 `ImageSource` 屬性。將每個相對 URI 以包含該 XAML 產物的目錄為基礎解析，正規化產生的儲存名稱，並確認字典鍵、ZIP 條目或已存物件確實存在。將外部 URI 與 XAML 標記表達式與相對檔名分開處理。

例如，若 `pres/Slide_1.xaml` 參照 `images/image1.png`，則必須以 `pres/images/image1.png` 形式儲存該資源。僅保留 `image1.png` 會導致關聯失效。若使用物件儲存，請在作業前置詞下保持相同的目錄結構，並讓這些資源 URL 可供 XAML 使用者存取。重新打開完成的 ZIP 以驗證條目名稱與資源位元組，並在目標 XAML 環境中載入代表性投影片，以確認圖片正確解析。

## **常見問題**

**如果原始字型在機器上不存在，如何確保字型的可預測性？**

在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/) 中設定 [default_regular_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/)。匯出時若缺少原始字型，會使用此備援字型。此設定並不保證產生的 XAML 一定會引用備援字型，或該字型在目標機器上可用。請確保 XAML 所參照的字型在顯示環境中可取得。

**匯出的 XAML 只適用於 WPF 嗎？還是可以在其他 XAML 堆疊中使用？**

Aspose.Slides 透過公開 API 匯出 WPF XAML。對其他 XAML 堆疊（如 UWP 與 Xamarin.Forms）的相容性不保證。請在目標環境中測試產生的標記。

**是否支援隱藏投影片？預設如何防止它們被匯出？**

預設情況下不會包含隱藏投影片。您可以透過在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/) 中的 [export_hidden_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) 屬性控制此行為——如果不需要匯出隱藏投影片，請保持其為關閉狀態。