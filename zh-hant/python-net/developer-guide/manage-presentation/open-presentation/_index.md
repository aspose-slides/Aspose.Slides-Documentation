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
description: "了解如何在 Python 中開啟 PowerPoint 與 OpenDocument 簡報、提供開啟密碼，並使用 Aspose.Slides for Python via .NET 減少記憶體使用量。"
---
## **簡介**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/zh-hant/python-net/) 可以從檔案和串流載入 PowerPoint 與 OpenDocument 簡報。載入簡報後，您可以檢查其結構、編輯投影片、管理資源，並以原始或其他支援的格式儲存。

載入行為可透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/) 類別自訂。例如，您可以提供開啟密碼、將大型二進位物件保留在記憶體之外，或省略嵌入的二進位資料。

## **開啟簡報**

若要開啟現有簡報，將其檔案路徑傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 建構子。使用 `with` 陳述式，以便即時釋放檔案句柄、暫存資料及其他資源。

以下 Python 範例示範如何開啟簡報並取得投影片數量：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **開啟受密碼保護的簡報**

開啟密碼會加密簡報內容。若要載入完整簡報，請將正確的密碼指定給 [LoadOptions.password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/password/) 並將選項傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 建構子。若未提供密碼或密碼不正確，載入將失敗。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

有關密碼偵測、驗證與加密工作流程，請參閱 [Password-Protect Presentations](/slides/zh-hant/python-net/password-protected-presentation/)。如果加密的簡報刻意以公開的文件屬性儲存，則可在不提供密碼的情況下讀取這些屬性；請參閱 [Manage Presentation Properties](/slides/zh-hant/python-net/presentation-properties/)。

## **開啟大型簡報**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/blob_management_options/) 控制 Aspose.Slides 處理影像、音訊與視訊等大型二進位物件的方式。您可以保持來源檔案被鎖定、允許使用暫存檔，並限制保留在記憶體中的 BLOB 資料量。

以下 Python 程式碼示範載入大型簡報（例如 2 GB）：

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="注意" %}}
使用 `PresentationLockingBehavior.KEEP_LOCKED` 時，來源檔案會保持鎖定，直至 `Presentation` 物件被釋放。在該物件存活期間，請勿移動、覆寫或刪除來源檔案。

Aspose.Slides 在載入時可能會複製輸入串流的內容。對於大型簡報，檔案路徑通常比串流更有效率。請參閱 [Manage BLOBs](/slides/zh-hant/python-net/manage-blob/) 以取得其他儲存與記憶體管理選項。
{{% /alert %}}

## **載入不含嵌入二進位物件的簡報**

簡報可能包含應用程式不需要或不想保留的嵌入二進位資料。例子包括：

- VBA 專案，可透過 [Presentation.vba_project](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/vba_project/) 取得；
- 嵌入的 OLE 資料，可透過 [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) 取得；
- ActiveX 控制項資料，可透過 [Control.active_x_control_binary](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/control/active_x_control_binary/) 取得。

將 [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) 設為 `True` 即可在載入時移除這些二進位資料。將載入的簡報儲存以保留已淨化的結果。

此選項可降低不必要的嵌入載荷風險，但它並非完整的惡意程式偵測或內容淨化系統。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**如何判斷檔案已損壞且無法開啟？**

Aspose.Slides 於載入時會拋出解析或格式例外。請將此失敗與密碼錯誤的例外分開處理，以使應用程式能正確回報原因。

**如果缺少必要的字型會發生什麼情況？**

簡報仍可載入，但呈現與匯出時可能會替代字型。您可以 [設定字型替代](/slides/zh-hant/python-net/font-substitution/) 或 [提供自訂字型](/slides/zh-hant/python-net/custom-font/) 以讓輸出更可預測。

**載入簡報時也會載入其嵌入的媒體嗎？**

嵌入的音訊與視訊可透過簡報物件模型取得。外部資源會依照預設的資源載入行為解析，若無法存取其位置，則可能無法取得。