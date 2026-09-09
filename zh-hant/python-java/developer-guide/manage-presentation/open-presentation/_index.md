---
title: 在 Python（透過 Java）中開啟簡報
linktitle: 開啟簡報
type: docs
weight: 20
url: /zh-hant/python-java/open-presentation/
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
- Java
- Aspose.Slides
description: "瞭解如何在 Python（透過 Java）中開啟 PowerPoint 與 OpenDocument 簡報、提供開啟密碼、控制資源載入，並使用 Aspose.Slides for Python via Java 減少記憶體使用。"
---
## **簡介**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/zh-hant/python-java/) 能從檔案與串流載入 PowerPoint 與 OpenDocument 簡報。載入簡報後，您可以檢查其結構、編輯投影片、管理資源，並以原始或其他支援的格式儲存。

透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/) 類別可以自訂載入行為。例如，您可以提供開啟密碼、將大型二進位物件保留在 Java 堆外、控制外部資源，或省略內嵌二進位資料。

## **開啟簡報**

若要開啟現有簡報，將其檔案路徑傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 建構子。使用完畢後請釋放簡報，以便即時關閉檔案句柄、暫存資料與其他資源。

下列 Python 範例示範如何開啟簡報並取得投影片數量：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **開啟受密碼保護的簡報**

開啟密碼會加密簡報內容。若要載入完整簡報，請將正確的密碼傳給 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setPassword)，並將此選項提供給 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 建構子。若密碼缺失或不正確，載入將失敗。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

關於密碼偵測、驗證與加密工作流程，請參閱 [Password-Protect Presentations](/slides/zh-hant/python-java/password-protected-presentation/)。若加密的簡報故意以公開的文件屬性儲存，這些屬性可在不提供密碼的情況下讀取；請參考 [Manage Presentation Properties](/slides/zh-hant/python-java/presentation-properties/)。

## **開啟大型簡報**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) 會傳回控制 Aspose.Slides 如何處理二進位大型物件（例如影像、音訊與視訊）的選項。您可以保持來源檔案鎖定、允許暫存檔案，以及限制記憶體中保留的 BLOB 資料量。

以下 Python 程式碼示範載入大型簡報（例如 2 GB）：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
使用 [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) 時，來源檔案會保持鎖定，直到釋放簡報實例為止。請勿在該實例仍存活時移動、覆寫或刪除來源檔案。

Aspose.Slides 可能在載入時複製輸入串流的內容。對於大型簡報，使用檔案路徑通常較使用串流更有效率。另請參閱 [Manage BLOBs](/slides/zh-hant/python-java/manage-blob/)，了解其他儲存與記憶體管理選項。
{{% /alert %}}

## **控制外部資源**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) 接受實作 Java 資源載入回呼介面的 JPype 代理。回呼可提供替代資料、重新導向資源、使用預設載入器，或跳過該資源。當簡報包含必須根據應用程式特定安全或儲存規則解析的外部影像時，此功能相當有用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **載入不含內嵌二進位物件的簡報**

簡報可能包含應用程式不需要或不想保留的內嵌二進位資料。例如：

- VBA 專案，可透過 [Presentation.getVbaProject](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getVbaProject) 取得；
- 內嵌 OLE 資料，可透過 [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) 取得；
- ActiveX 控制項資料，可透過 [Control.getActiveXControlBinary](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/control/#getActiveXControlBinary) 取得。

將 [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) 設為 `True`，即可在載入時移除這些二進位資料。之後儲存載入的簡報，以保留已清理的結果。

此選項可減少不需要的內嵌負載風險，但它並非完整的惡意軟體偵測或內容清理系統。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**如何判斷檔案已損毀而無法開啟？**

Aspose.Slides 會在載入時拋出解析或格式例外。請將此失敗與密碼錯誤分開處理，以便應用程式能正確回報原因。

**若缺少必要字型會發生什麼情況？**

簡報仍可載入，但在呈現與匯出時可能會替換字型。您可以 [configure font substitution](/slides/zh-hant/python-java/font-substitution/) 或 [provide custom fonts](/slides/zh-hant/python-java/custom-font/) 以使輸出更可預測。

**載入簡報時是否也會載入其內嵌媒體？**

內嵌的音訊與視訊會透過簡報物件模型提供。外部資源則依照已設定的資源載入行為解析，若其位置無法存取，則可能無法取得。