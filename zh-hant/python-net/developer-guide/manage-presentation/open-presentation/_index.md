---
title: 在 Python 中開啟簡報
linktitle: 開啟簡報
type: docs
weight: 20
url: /zh-hant/python-net/open-presentation/
keywords:
- 開啟 PowerPoint
- 開啟簡報
- 開啟 PPTX
- 開啟 PPT
- 開啟 ODP
- 載入簡報
- 載入 PPTX
- 載入 PPT
- 載入 ODP
- 受保護的簡報
- 大型簡報
- 外部資源
- 二進位物件
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 輕鬆開啟 PowerPoint (.pptx, .ppt) 與 OpenDocument (.odp) 簡報——快速、可靠、功能完整。"
---
## **簡介**

除了從頭建立 PowerPoint 簡報之外，Aspose.Slides 也允許您開啟現有的簡報。載入簡報後，您可以取得其資訊、編輯投影片內容、添加新投影片、移除現有投影片，以及其他操作。

## **開啟簡報**

若要開啟現有簡報，請實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別，並將檔案路徑傳遞給其建構函式。

以下 Python 範例示範如何開啟簡報並取得投影片數量：

```python
import aspose.slides as slides

# 實例化 Presentation 類別並將檔案路徑傳遞給其建構函式。
with slides.Presentation("sample.pptx") as presentation:
    # 印出簡報中投影片的總數。
    print(presentation.slides.length)
```

## **開啟受密碼保護的簡報**

當您需要開啟受密碼保護的簡報時，請透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/) 類別的 [password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/password/) 屬性傳入密碼，以進行解密並載入。以下 Python 程式碼示範此操作：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # 在已解密的簡報上執行操作。
```

## **開啟大型簡報**

Aspose.Slides 提供選項—尤其是位於 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/) 類別中的 [blob_management_options](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/blob_management_options/) 屬性——協助您載入大型簡報。

以下 Python 程式碼示範載入大型簡報（例如 2 GB）：

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# 選擇 KeepLocked 行為——簡報檔案在其生命週期內將保持鎖定
# 簡報實例，但不需要載入至記憶體或複製至暫存檔案。
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # 已載入大型簡報，可供使用，且記憶體使用量仍保持低位。

    # 對簡報進行變更。
    presentation.slides[0].name = "Large presentation"

    # 將簡報儲存至另一個檔案。此操作期間記憶體使用量仍保持低位。
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # 切勿這麼做！會拋出 I/O 例外，因為檔案會被鎖定直到釋放簡報物件。
    os.remove(file_path)

# 在此處執行即可。來源檔案已不再被簡報物件鎖定。
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
為了解決使用串流時的某些限制，Aspose.Slides 可能會複製串流的內容。從串流載入大型簡報會導致簡報被複製，進而降低載入速度。因此，當您需要載入大型簡報時，我們強烈建議使用簡報檔案路徑而非串流。

在建立包含大型物件（影片、音訊、高解析度影像等）的簡報時，您可以使用 [BLOB management](/slides/zh-hant/python-net/manage-blob/) 以減少記憶體使用量。
{{%/alert %}}

## **在不載入嵌入式二進位物件的情況下載入簡報**

PowerPoint 簡報可能包含以下類型的嵌入式二進位物件：

- VBA 專案（可透過 [Presentation.vba_project](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/vba_project/) 存取）；
- OLE 物件嵌入資料（可透過 [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) 存取）；
- ActiveX 控制項二進位資料（可透過 [Control.active_x_control_binary](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/control/active_x_control_binary/) 存取）。

使用 [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) 屬性，您可以載入不含任何嵌入式二進位物件的簡報。

此屬性對於移除可能具惡意的二進位內容很有用。以下 Python 程式碼示範如何載入不含任何嵌入式二進位內容的簡報：

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # 對簡報執行操作。
```

## **常見問題**

**如何判斷檔案已損毀且無法開啟？**

載入時會拋出解析／格式驗證例外。此類錯誤通常會提及 ZIP 結構無效或 PowerPoint 記錄損毀。

**開啟時若缺少必要字型會發生什麼？**

檔案仍會開啟，但之後的 [rendering/export](/slides/zh-hant/python-net/convert-presentation/) 可能會替換字型。請在執行環境中[設定字型替換](/slides/zh-hant/python-net/font-substitution/)或[加入必要字型](/slides/zh-hant/python-net/custom-font/)。

**開啟時嵌入式媒體（影片/音訊）如何處理？**

它們會作為簡報資源可供使用。若媒體是透過外部路徑引用，請確保該路徑在您的環境中可存取；否則在 [rendering/export](/slides/zh-hant/python-net/convert-presentation/) 時可能會省略媒體。