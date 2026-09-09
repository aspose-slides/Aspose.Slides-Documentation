---
title: 在 Python via Java 中管理簡報 BLOB 以提升記憶體使用效率
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
- 將影像新增為 BLOB
- 降低記憶體
- 記憶體消耗
- 大型簡報
- 暫存檔案
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中管理 BLOB 資料，以簡化 PowerPoint 和 OpenDocument 檔案操作，提升簡報處理效能。"
---
## **概述**

Aspose.Slides 提供基於 BLOB 的大型二進位資料處理，能在簡報中處理大型圖像、音訊、影片及簡報檔案時降低記憶體使用量。  
本文說明如何使用基於 BLOB 的處理將大型媒體加入簡報、將大型媒體從簡報匯出，以及更有效率地載入大型簡報。還會說明在處理過程中如何使用暫存檔案，以及如何變更儲存暫存檔的資料夾。

## **關於 BLOB**

**BLOB**（**Binary Large Object**）通常是以二進位格式儲存的大型項目（照片、簡報、文件或媒體）。  
透過 Java 的 Aspose.Slides for Python 允許您在處理大型檔案時，使用 BLOB 來降低記憶體使用量。

{{% alert color="info" title="注意" %}}
為了避免在與串流互動時的某些限制，Aspose.Slides 可能會複製串流內容。透過串流載入大型簡報會導致簡報內容被複製，進而造成載入緩慢。因此，當您打算載入大型簡報時，我們強烈建議使用簡報檔案路徑而非串流。
{{% /alert %}}

## **使用 BLOB 減少記憶體使用量**

### **使用 BLOB 將大型檔案加入簡報**

[Aspose.Slides](/slides/zh-hant/python-java/) 透過 Java 的 Python 版本允許您透過 BLOB 流程加入大型檔案（此範例為大型影片檔），以降低記憶體使用量。  
以下 Python 程式碼示範如何透過 BLOB 流程將大型影片檔加入簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# 建立一個新簡報，以加入影片。
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # 鎖定串流，因為我們不打算存取影片檔案。
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # 儲存簡報，同時保持低記憶體消耗。
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **使用 BLOB 從簡報匯出大型檔案**

透過 Java 的 Aspose.Slides for Python 允許您透過 BLOB 流程從簡報匯出大型檔案（此範例為音訊或影片檔）。例如，您可能需要從簡報中擷取大型媒體檔案，但不希望該檔案載入電腦記憶體。透過 BLOB 流程匯出檔案即可保持低記憶體使用量。  
以下 Python 程式碼示範上述操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# 鎖定來源檔案，而不是將其載入記憶體。
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # 透過緩衝區傳輸影片資料以保持低記憶體消耗。
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # 使用串流而非將整個影片載入位元組陣列。
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

### **將影像以 BLOB 形式加入簡報**

使用 [ImageCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagecollection/) 類別的方法，您可以將大型影像以串流方式加入，讓其被視為 BLOB。  
以下 Python 程式碼示範如何透過 BLOB 流程加入大型影像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# 建立一個新簡報，以加入影像。
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # 鎖定串流，因為我們不打算存取影像檔案。
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # 儲存簡報，同時保持低記憶體消耗。
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **記憶體與大型簡報**

通常，要載入大型簡報時，電腦需要大量暫存記憶體。簡報的所有內容會被載入記憶體，且載入簡報的檔案會停止使用。  
以一個包含 1.5 GB 影片檔案的大型 PowerPoint 簡報 (large.pptx) 為例。載入簡報的標準方法如下 Python 程式碼所示：

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

但此方法會消耗約 1.6 GB 的暫存記憶體。

### **以 BLOB 載入大型簡報**

使用 BLOB 處理可在佔用極少記憶體的情況下載入大型簡報。以下 Python 程式碼示範如何使用 BLOB 處理載入大型簡報檔案 (large.pptx)：

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

### **變更暫存檔案資料夾**

使用 BLOB 流程時，電腦會在預設的暫存檔資料夾建立暫存檔案。若希望將暫存檔案保存於其他資料夾，可使用 [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) 變更儲存設定：

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

{{% alert color="info" title="注意" %}}
使用 [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) 時，Aspose.Slides 不會自動建立用於儲存暫存檔的資料夾，必須自行手動建立該資料夾。
{{% /alert %}}

### **釋放簡報物件以釋放記憶體**

在處理大型簡報時，請確保正確釋放 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例，以釋放其佔用的記憶體。完成簡報使用後，呼叫 [Presentation.dispose](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#dispose) 以釋放非受控資源。

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
圖像、音訊、影片等大型二進位物件會被視為 BLOB。整個簡報檔案在載入或儲存時亦會涉及 BLOB 處理。這些物件受 BLOB 原則管轄，讓您能管理記憶體使用，並在需要時將資料寫入暫存檔。

**在載入簡報時，在哪裡設定 BLOB 處理規則？**  
使用 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/) 搭配 [BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/blobmanagementoptions/)。您可以在此設定 BLOB 的記憶體上限、是否允許暫存檔、暫存檔根資料夾路徑，以及來源鎖定行為。

**BLOB 設定會影響效能嗎？該如何在速度與記憶體之間取得平衡？**  
會的。將 BLOB 保持於記憶體中可提升速度，但會增加 RAM 用量；降低記憶體上限會將更多工作轉至暫存檔，減少 RAM 使用，但會增加 I/O。可使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) 方法調整，以取得適合工作負載與環境的平衡。

**在開啟極大型簡報（例如數十 GB）時，BLOB 選項有幫助嗎？**  
會的。[BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/blobmanagementoptions/) 即為此類情境設計：啟用暫存檔並使用來源鎖定，可顯著降低最高 RAM 使用量，並使處理極大型簡報更加穩定。

**在從串流而非磁碟檔案載入時，是否也能使用 BLOB 原則？**  
會的。同樣的規則適用於串流：簡報實例可根據所選的鎖定模式擁有並鎖定輸入串流，且在允許的情況下會使用暫存檔，使處理過程中的記憶體使用保持可預測。