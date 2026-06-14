---
title: 在 Java 中管理簡報 BLOB 以提升記憶體效能
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh-hant/java/manage-blob/
keywords:
- 大型物件
- 大型項目
- 大型檔案
- 新增 BLOB
- 匯出 BLOB
- 以 BLOB 新增影像
- 減少記憶體
- 記憶體消耗
- 大型簡報
- 暫存檔案
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中管理 BLOB 資料，以簡化 PowerPoint 與 OpenDocument 檔案操作，提升簡報處理效能。"
---
## **概述**

Aspose.Slides 提供基於 BLOB 的處理方式，以在簡報中處理大型二進位資料，從而在處理大型影像、音訊、影片和簡報檔案時減少記憶體消耗。

本文說明如何使用基於 BLOB 的處理將大型媒體新增至簡報、從簡報匯出大型媒體，以及更有效率地載入大型簡報。它還說明了如何在處理過程中使用暫存檔案以及如何變更儲存這些檔案的資料夾。

## **關於 BLOB**

**BLOB**（**Binary Large Object**）通常是以二進位格式保存的大型項目（照片、簡報、文件或媒體）。

Aspose.Slides for Java 允許您以減少記憶體消耗的方式，對涉及大型檔案的物件使用 BLOB。

{{% alert title="Info" color="info" %}}
為了繞過與串流互動時的某些限制，Aspose.Slides 可能會複製串流的內容。透過串流載入大型簡報會導致簡報內容被複製，進而造成載入緩慢。因此，當您打算載入大型簡報時，我們強烈建議使用簡報檔案路徑而非其串流。
{{% /alert %}}

## **使用 BLOB 減少記憶體消耗**

### **將大型檔案透過 BLOB 新增至簡報**

[Aspose.Slides](/slides/zh-hant/java/) for Java 允許您透過 BLOB 處理程序新增大型檔案（此例為大型影片檔），以減少記憶體消耗。

以下 Java 範例示範如何透過 BLOB 程序將大型影片檔新增至簡報：

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// 建立一個新的簡報，將影片新增至其中
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // 讓我們將影片新增至簡報 - 我們選擇 KeepLocked 行為，因為我們
        // 不打算存取 "veryLargeVideo.avi" 檔案.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // 儲存簡報。當大型簡報被輸出時，記憶體消耗
        // 在 pres 物件的生命週期中保持低水平 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **從簡報透過 BLOB 匯出大型檔案**

Aspose.Slides for Java 允許您透過 BLOB 程序從簡報匯出大型檔案（此例為音訊或影片檔）。例如，您可能需要從簡報中擷取大型媒體檔案，但不希望該檔案載入電腦記憶體。透過 BLOB 程序匯出檔案即可保持低記憶體消耗。

以下 Java 程式碼示範上述操作：

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// 鎖定來源檔案且不將其載入記憶體
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// 建立 Presentation 實例，並鎖定 "hugePresentationWithAudiosAndVideos.pptx" 檔案。
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 讓我們將每個影片儲存為檔案。為防止記憶體使用過高，我們需要一個緩衝區來
    // 用於將簡報的影片串流資料傳輸到新建立的影片檔案的串流。
    byte[] buffer = new byte[8 * 1024];

    // 逐一遍歷影片
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // 開啟簡報的影片串流。請注意，我們刻意避免存取屬性
        // 如 video.BinaryData —— 因為此屬性能回傳包含完整影片的位元組陣列，進而
        // 使位元組載入記憶體。我們使用 video.GetStream，會回傳 Stream，且不會
        //  不需要我們將整個影片載入記憶體。
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // 無論影片或簡報的大小，記憶體消耗都會保持低。
    }
    // 如有需要，您可以對音訊檔案套用相同的步驟。 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **將影像以 BLOB 新增至簡報**

使用 [**IImageCollection**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IImageCollection) 介面與 [**ImageCollection**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ImageCollection) 類別的方法，您可以將大型影像以串流方式新增，使其被視為 BLOB。

以下 Java 程式碼示範如何透過 BLOB 程序將大型影像新增：

```java
String pathToLargeImage = "large_image.jpg";

// 建立一個新的簡報，將影像新增至其中。
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// 讓我們將影像新增至簡報 - 我們選擇 KeepLocked 行為，因為我們
		// 不打算存取 "largeImage.png" 檔案.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// 儲存簡報。當大型簡報被輸出時，記憶體消耗
		// 在 pres 物件的生命週期中保持低水平
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **記憶體與大型簡報**

通常，要載入大型簡報，電腦需要大量暫存記憶體。簡報的所有內容會被載入記憶體，而載入簡報的檔案則不再被使用。

以包含 1.5 GB 影片檔案的大型 PowerPoint 簡報 (large.pptx) 為例。此 Java 程式碼描述了載入該簡報的標準方法：

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

但此方法會消耗約 1.6 GB 的暫存記憶體。

### **以 BLOB 載入大型簡報**

透過 BLOB 程序，您可以在使用極少記憶體的情況下載入大型簡報。以下 Java 程式碼說明了使用 BLOB 程序載入大型簡報檔案 (large.pptx) 的實作：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **變更暫存檔案的資料夾**

使用 BLOB 程序時，電腦會在預設的暫存檔案資料夾中建立暫存檔案。若您希望將暫存檔案保留在其他資料夾，可透過 `TempFilesRootPath` 變更儲存設定：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
當您使用 `TempFilesRootPath` 時，Aspose.Slides 不會自動建立暫存檔案資料夾。您必須自行手動建立該資料夾。
{{% /alert %}}

### **釋放簡報物件以釋放記憶體**

在處理大型簡報時，請確保正確釋放 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 實例，以釋放其佔用的記憶體。完成簡報使用後，呼叫 `dispose()` 以釋放未受管理的資源。

```java
Presentation presentation = new Presentation("large.pptx");

// ...處理簡報...
presentation.save("large.pdf", SaveFormat.Pdf);

// 明確釋放資源。
presentation.dispose();
```

## **常見問題**

**什麼資料在 Aspose.Slides 簡報中被視為 BLOB 並受 BLOB 選項控制？**

大型二進位物件，例如影像、音訊與影片，都會被視為 BLOB。整個簡報檔案在載入或儲存時亦涉及 BLOB 處理。這些物件受 BLOB 政策管控，讓您得以管理記憶體使用，並根據需要寫入暫存檔案。

**在哪裡可以在載入簡報時配置 BLOB 處理規則？**

使用 [LoadOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/) 搭配 [BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/blobmanagementoptions/)。在此您可設定 BLOB 在記憶體中的上限、是否允許暫存檔案、暫存檔案的根路徑，以及來源鎖定行為。

**BLOB 設定會影響效能嗎？該如何在速度與記憶體之間取得平衡？**

會的。將 BLOB 保持在記憶體中可最大化速度，但會增加 RAM 使用量；降低記憶體上限會將更多工作轉移至暫存檔案，減少 RAM 使用，但會產生額外的 I/O。使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) 方法，以根據您的工作負載與環境取得適當的平衡。

**在開啟極大型簡報（例如數十億位元組）時，BLOB 選項是否有幫助？**

會的。[BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/blobmanagementoptions/) 為此類情境設計：啟用暫存檔案並使用來源鎖定，可顯著降低峰值 RAM 使用量，並使處理極大型簡報更加穩定。

**在從串流而非磁碟檔案載入時，我可以使用 BLOB 政策嗎？**

會的。同樣的規則套用於串流：簡報實例可以擁有並鎖定輸入串流（視所選的鎖定模式而定），且在允許的情況下會使用暫存檔案，從而在處理過程中保持可預測的記憶體使用量。