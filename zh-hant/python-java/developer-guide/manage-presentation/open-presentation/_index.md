---
title: 在 Python 透過 Java 開啟簡報
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
description: "了解如何在 Python 透過 Java 開啟 PowerPoint 與 OpenDocument 簡報、提供開啟密碼、控制資源載入，並使用 Aspose.Slides for Python via Java 減少記憶體使用量。"
---
## **簡介**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/zh-hant/python-java/) 可以從檔案和串流載入 PowerPoint 與 OpenDocument 簡報。載入簡報後，您可以檢查其結構、編輯投影片、管理資源，並以原始或其他支援格式儲存。

載入行為可以透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/) 類別自訂。例如，您可以提供開啟密碼、將大型二進位物件保留在 Java 堆外記憶體、控制外部資源，或省略嵌入的二進位資料。

## **開啟簡報**

要開啟現有簡報，只需將檔案路徑傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 建構函式。使用完畢後請釋放簡報，以便及時釋放檔案句柄、暫存資料及其他資源。

以下 Python 範例示範如何開啟簡報並取得投影片數量：

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

開啟密碼會加密簡報內容。若要完整載入簡報，請將正確的密碼傳遞給 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setPassword) 並將此選項提供給 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 建構函式。若密碼遺失或不正確，載入將失敗。

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

有關密碼偵測、驗證與加密工作流程，請參閱 [Password-Protect Presentations](/slides/zh-hant/python-java/password-protected-presentation/)。如果已加密的簡報故意以公開文件屬性儲存，這些屬性可在未提供密碼的情況下讀取；請參閱 [Manage Presentation Properties](/slides/zh-hant/python-java/presentation-properties/)。

## **開啟大型簡報**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) 會回傳控制 Aspose.Slides 如何處理圖像、音訊與視訊等大型二進位物件的選項。您可以保持來源檔案鎖定、允許暫存檔，並限制保留於記憶體中的 BLOB 資料量。

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

使用 [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) 時，來源檔案會保持鎖定，直到釋放簡報實例為止。在實例存活期間，請勿移動、覆寫或刪除來源檔案。

Aspose.Slides 可能在載入時複製輸入串流的內容。對於大型簡報而言，使用檔案路徑通常較使用串流更有效。更多儲存與記憶體管理選項，請參閱 [Manage BLOBs](/slides/zh-hant/python-java/manage-blob/)。

{{% /alert %}}

## **控制外部資源**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) 接受實作 Java 資源載入回呼介面的 JPype 代理。回呼可以提供替代資料、重新導向資源、使用預設載入器，或跳過資源。這在簡報包含必須依照應用程式特定安全或儲存規則解析的外部影像時特別有用。

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

## **載入不含嵌入式二進位物件的簡報**

簡報可能包含應用程式不需要或不想保留的嵌入式二進位資料。範例包括：

- 透過 [Presentation.getVbaProject](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getVbaProject) 取得的 VBA 專案；
- 透過 [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) 取得的嵌入 OLE 資料；
- 透過 [Control.getActiveXControlBinary](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/control/#getActiveXControlBinary) 取得的 ActiveX 控制項資料。

將 [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) 設為 `True`，即可在載入時移除這些二進位資料。將載入的簡報儲存以保留清理後的結果。

此選項可減少不必要的嵌入式負載，但它並非完整的惡意程式偵測或內容清理系統。

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

**如何判斷檔案已損毀且無法開啟？**

Aspose.Slides 會在載入期間拋出解析或格式例外。請將此失敗與密碼錯誤分開處理，以便應用程式正確回報原因。

**如果缺少必要的字型會發生什麼事？**

簡報仍可載入，但渲染與匯出可能會使用字型替代。您可以 [configure font substitution](/slides/zh-hant/python-java/font-substitution/) 或 [provide custom fonts](/slides/zh-hant/python-java/custom-font/) 以使輸出更可預測。

**載入簡報時是否同時載入其嵌入的媒體？**

嵌入的音訊與視訊會透過簡報物件模型提供。外部資源會依照已設定的資源載入行為解析；若其位置無法存取，則可能不可用。