---
title: 使用 Python 管理簡報中的 BLOB 以提升記憶體使用效率
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh-hant/python-net/manage-blob/
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
- 暫存檔
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中管理 BLOB 資料，以簡化 PowerPoint 與 OpenDocument 檔案的操作，提升簡報處理效率。"
---
## **概述**

Aspose.Slides 提供基於 BLOB 的處理方式，用於簡報中大型二進位資料，協助在處理大型圖像、音訊、影片以及簡報檔案時降低記憶體消耗。

本文說明如何使用基於 BLOB 的處理將大型媒體新增至簡報、從簡報匯出大型媒體，以及更有效率地載入大型簡報。亦說明如何在處理過程中使用暫存檔，以及如何變更用來儲存這些檔案的資料夾。

## **關於 BLOB**

**BLOB**（**Binary Large Object**）通常指以二進位格式儲存的大型項目（照片、簡報、文件或媒體）。

Aspose.Slides for Python via .NET 讓您能以減少記憶體消耗的方式，對大型檔案使用 BLOB 物件。

## **使用 BLOB 減少記憶體消耗**

### **透過 BLOB 將大型檔案新增至簡報**

[Aspose.Slides](/slides/zh-hant/python-net/) for .NET 允許您透過 BLOB 流程將大型檔案（此例為大型影片檔）新增至簡報，以降低記憶體消耗。

以下 Python 程式示範如何透過 BLOB 流程將大型影片檔新增至簡報：

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# 建立一個新的簡報，將把影片新增至其中
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # 讓我們將影片新增至簡報 - 我們選擇 KeepLocked 行為，因為我們
        # 不打算存取 "veryLargeVideo.avi" 檔案。
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # 儲存簡報。雖然輸出的是大型簡報，記憶體使用量
        # 在 pres 物件的生命週期內保持低水平 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **透過 BLOB 從簡報匯出大型檔案**

Aspose.Slides for Python via .NET 允許您透過 BLOB 流程從簡報匯出大型檔案（此例為音訊或影片檔）。例如，您可能需要從簡報中擷取大型媒體檔案，但不想將該檔案載入電腦記憶體。透過 BLOB 流程匯出檔案，可保持低記憶體使用量。

以下 Python 程式碼示範上述操作：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# 讓我們將每個影片儲存為檔案。為了防止高記憶體使用，我們需要一個緩衝區來使用
	# 將簡報影片串流的資料傳輸到新建立的影片檔案的串流。
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# 逐一處理影片
    index = 0
    # 如有需要，您可以對音訊檔案套用相同的步驟。 
    for video in pres.videos:
		# 開啟簡報的影片串流。請注意，我們刻意避免存取屬性
		# 如 video.BinaryData - 因為此屬性會回傳包含完整影片的位元組陣列，接著
		# 會導致位元組載入記憶體。我們使用 video.GetStream，它會回傳 Stream，而且不會
		#  需要我們將整個影片載入記憶體。
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **在簡報中以 BLOB 新增影像**

使用 [**ImageCollection**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/) 類別的方法，您可以將大型影像以資料流方式新增，使其被視為 BLOB。

以下 Python 程式碼示範如何透過 BLOB 流程新增大型影像：

```py
import aspose.slides as slides

# 建立一個新的簡報，將在其中新增影像。
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **記憶體與大型簡報**

通常，載入大型簡報時，電腦需要大量暫存記憶體。簡報的所有內容會被載入記憶體，且載入來源的檔案不再被使用。

以包含 1.5 GB 影片檔的大型 PowerPoint 簡報 (large.pptx) 為例。載入此簡報的標準方法如以下 Python 程式碼所示：

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

但此方法會消耗約 1.6 GB 的暫存記憶體。

### **以 BLOB 載入大型簡報**

透過 BLOB 流程，您可以在使用極少記憶體的情況下載入大型簡報。以下 Python 程式碼示範使用 BLOB 流程載入大型簡報檔案 (large.pptx)：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **變更暫存檔的資料夾**

當使用 BLOB 流程時，電腦會在預設的暫存檔資料夾中建立暫存檔。若您希望將暫存檔儲存於其他資料夾，可使用 `temp_files_root_path` 變更儲存設定：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
當您使用 `temp_files_root_path` 時，Aspose.Slides 不會自動建立用來儲存暫存檔的資料夾。您必須自行手動建立該資料夾。
{{% /alert %}}

### **釋放簡報物件以釋放記憶體**

在處理大型簡報時，請確保正確釋放 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 例項，以釋放其佔用的記憶體。建議使用上下文管理器（`with slides.Presentation(...) as presentation:`）如上述範例所示；區塊結束時會自動關閉簡報並釋放非受管理資源。

若未使用 `with` 區塊建立簡報，請在使用完畢後明確呼叫 `presentation.dispose()`，並移除任何剩餘的參考，以讓 Python 的垃圾回收機制回收記憶體。

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...處理簡報...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# 明確釋放資源。
presentation.dispose()
```

## **常見問題**

**在 Aspose.Slides 簡報中，哪些資料會被視為 BLOB 並受 BLOB 選項控制？**

大型二進位物件（如影像、音訊與影片）會被視為 BLOB。整個簡報檔案在載入或儲存時也會涉及 BLOB 處理。這些物件受 BLOB 政策管理，可讓您在需要時控制記憶體使用量並將資料寫入暫存檔。

**在載入簡報時，我該如何設定 BLOB 處理規則？**

使用 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/) 搭配 [BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/blobmanagementoptions/)。在此您可以設定 BLOB 的記憶體上限、是否允許暫存檔、暫存檔的根目錄路徑，以及來源鎖定行為。

**BLOB 設定會影響效能嗎？我要如何在速度與記憶體之間取得平衡？**

會的。將 BLOB 保持於記憶體中可提升速度，但會增加 RAM 使用量；降低記憶體上限會將更多工作轉移至暫存檔，減少 RAM 需求但會產生額外 I/O。可調整 [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) 閾值，以在您的工作負載與環境中取得適當的平衡。

**在開啟極大型簡報（例如數 GB）時，BLOB 選項是否有幫助？**

會的。[BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/blobmanagementoptions/) 正是為此類情境設計：啟用暫存檔與使用來源鎖定可顯著降低峰值 RAM 使用量，並使處理極大型簡報更為穩定。

**我能在從串流而非磁碟檔案載入時使用 BLOB 政策嗎？**

會的。相同的規則亦適用於串流：簡報例項可以擁有並鎖定輸入串流（視所選的鎖定模式而定），允許時會使用暫存檔，以在處理過程中維持可預測的記憶體使用量。