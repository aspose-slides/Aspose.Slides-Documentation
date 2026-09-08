---
title: 管理 Python via Java 中的簡報 BLOB 以提升記憶體使用效率
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh-hant/python-java/manage-blob/
keywords:
- 大型物件
- 大型項目
- 大型檔案
- 新增 BLOB
- 匯出 BLOB
- 以 BLOB 形式新增影像
- 減少記憶體
- 記憶體消耗
- 大型簡報
- 暫存檔
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中管理 BLOB 資料，以簡化 PowerPoint 與 OpenDocument 檔案操作，提升簡報處理效率。"
---
## **概述**

Aspose.Slides 提供基於 BLOB 的大型二進位資料處理，旨在減少處理大型影像、音訊、影片及簡報檔案時的記憶體消耗。本文說明如何使用基於 BLOB 的處理方式將大型媒體加入簡報、從簡報匯出大型媒體，以及更有效率地載入大型簡報。同時也闡述在處理過程中如何使用暫存檔，以及如何變更用於儲存暫存檔的資料夾。

## **關於 BLOB**

**BLOB**（**Binary Large Object**）通常是以二進位格式儲存的大型項目（照片、簡報、文件或媒體）。Aspose.Slides for Python via Java 允許您以降低記憶體消耗的方式在處理大型檔案時使用 BLOB 物件。

{{% alert color="info" title="Note" %}}
為了繞過與串流互動時的某些限制，Aspose.Slides 可能會複製串流內容。透過串流載入大型簡報會導致簡報內容被複製，從而造成載入緩慢。因此，當您打算載入大型簡報時，我們強烈建議使用簡報檔案路徑而非串流。
{{% /alert %}}

## **使用 BLOB 以降低記憶體消耗**

### **透過 BLOB 將大型檔案加入簡報**

[Aspose.Slides](/slides/zh-hant/python-java/) for Python via Java 允許您透過 BLOB 處理程序將大型檔案（此處為大型影片檔案）加入簡報，以降低記憶體消耗。以下 Python 程式碼示範如何透過 BLOB 程序將大型影片檔案加入簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# 建立一個新的簡報，將會在其中加入影片。
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # 保持串流鎖定，因為我們不打算存取影片檔案。
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # 保存簡報，同時保持低記憶體消耗。
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **從簡報透過 BLOB 匯出大型檔案**

Aspose.Slides for Python via Java 允許您透過 BLOB 程序從簡報匯出大型檔案（此處為音訊或影片檔案）。舉例而言，您可能需要從簡報中擷取大型媒體檔案，但不希望該檔案被載入電腦記憶體。透過 BLOB 程序匯出檔案，可維持低記憶體消耗。以下 Python 程式碼示範上述操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# 鎖定來源檔案，而非將其載入記憶體。
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # 透過緩衝區傳輸影片資料，以維持低記憶體消耗。
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # 使用串流，而非將整個影片載入位元組陣列。
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # 如有需要，對音訊檔案執行相同步驟。
finally:
    presentation.dispose()
```

### **將影像以 BLOB 加入簡報**

使用 [ImageCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagecollection/) 類別的方法，您可以將大型影像以串流形式加入，讓其被視為 BLOB。以下 Python 程式碼示範如何透過 BLOB 程序加入大型影像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# 建立一個新的簡報，將會在其中加入影像。
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # 保持串流鎖定，因為我們不打算存取影像檔案。
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # 保存簡報，同時保持低記憶體消耗。
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **記憶體與大型簡報**

通常，載入大型簡報時，電腦需要大量暫存記憶體。全部簡報內容會被載入記憶體，且原始檔案（載入簡報的檔案）不再使用。以包含 1.5 GB 影片檔案的大型 PowerPoint 簡報 (large.pptx) 為例。以下 Python 程式碼說明載入該簡報的標準方法：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

然而，此方法會佔用約 1.6 GB 的暫存記憶體。

### **以 BLOB 載入大型簡報**

透過 BLOB 程序，您可以在使用極少記憶體的情況下載入大型簡報。以下 Python 程式碼說明如何使用 BLOB 程序載入大型簡報檔案 (large.pptx)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **變更暫存檔的資料夾**

使用 BLOB 程序時，電腦會在預設的暫存檔資料夾中建立暫存檔。若希望將暫存檔保存於其他資料夾，可使用 [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) 變更儲存設定：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}
使用 [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) 時，Aspose.Slides 不會自動建立用於儲存暫存檔的資料夾，必須自行手動建立。
{{% /alert %}}

### **釋放簡報物件以釋放記憶體**

在處理大型簡報時，請確保正確釋放 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例，以釋放其佔用的記憶體。完成簡報使用後，呼叫 [Presentation.dispose](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#dispose) 以釋放未受管理的資源。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...處理簡報...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # 明確釋放資源。
    presentation.dispose()
```

## **常見問題**

**在 Aspose.Slides 簡報中，哪些資料會被視為 BLOB 並受 BLOB 選項控制？**  
大型二進位物件（如影像、音訊與影片）會被視為 BLOB。整個簡報檔案在載入或儲存時亦會涉及 BLOB 處理。這些物件受 BLOB 原則管理，讓您在需要時調整記憶體使用量並寫入暫存檔。

**在載入簡報時，我該如何設定 BLOB 處理規則？**  
使用 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/) 搭配 [BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/blobmanagementoptions/)。在此您可設定 BLOB 的記憶體上限、允許或禁止暫存檔、選擇暫存檔根目錄路徑，並決定來源鎖定行為。

**BLOB 設定會影響效能嗎？我該如何在速度與記憶體之間取得平衡？**  
會的。將 BLOB 保持在記憶體中可提升速度，但會增加 RAM 消耗；降低記憶體上限會將更多工作轉移至暫存檔，降低 RAM 使用但會產生額外 I/O。可使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) 方法，依工作負載與環境取得適當平衡。

**在開啟極大型簡報（例如以 GB 計）時，BLOB 選項有幫助嗎？**  
會的。[BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/blobmanagementoptions/) 就是針對此類情境設計：開啟暫存檔並使用來源鎖定，可顯著降低峰值 RAM 使用量，並使處理極大型簡報更為穩定。

**在從串流（而非磁碟檔案）載入時，我能使用 BLOB 原則嗎？**  
會的。相同的規則同樣適用於串流：簡報實例可以擁有並鎖定輸入串流（取決於所選的鎖定模式），且在允許的情況下會使用暫存檔，使處理過程中的記憶體使用保持可預測。