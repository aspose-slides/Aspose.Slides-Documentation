---
title: 在 Android 上管理簡報 BLOB 以提升記憶體使用效率
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh-hant/androidjava/manage-blob/
keywords:
- 大型物件
- 大型項目
- 大型檔案
- 新增 BLOB
- 匯出 BLOB
- 將影像新增為 BLOB
- 降低記憶體使用
- 記憶體消耗
- 大型簡報
- 暫存檔
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上透過 Java 管理 Aspose.Slides 的 BLOB 資料，以簡化 PowerPoint 與 OpenDocument 檔案操作，提升簡報處理效率。"
---
## **概觀**

Aspose.Slides 提供基於 BLOB 的大型二進位資料處理，以在處理大型圖像、音訊、影片與簡報檔案時減少記憶體使用量。

本文說明如何使用基於 BLOB 的處理方式將大型媒體加入簡報、從簡報匯出大型媒體，以及更有效率地載入大型簡報。也會說明在處理過程中如何使用暫存檔，以及如何變更用來存放暫存檔的資料夾。

## **關於 BLOB**

**BLOB**（**Binary Large Object**）通常指以二進位格式儲存的大型項目（照片、簡報、文件或媒體）。

Aspose.Slides for Android via Java 讓您以降低記憶體消耗的方式在涉及大型檔案時使用 BLOB。

{{% alert title="Info" color="info" %}}
為了繞過與串流互動時的某些限制，Aspose.Slides 可能會複製串流的內容。透過串流載入大型簡報會導致簡報內容被複製，進而造成載入緩慢。因此，當您打算載入大型簡報時，我們強烈建議使用簡報檔案路徑，而非其串流。
{{% /alert %}}

## **使用 BLOB 減少記憶體消耗**

### **透過 BLOB 將大型檔案新增至簡報**

[Aspose.Slides](/slides/zh-hant/androidjava/) for Java 允許您透過 BLOB 流程新增大型檔案（本例為大型影片檔）以減少記憶體使用量。

以下 Java 範例示範如何透過 BLOB 流程將大型影片檔新增至簡報：

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// 建立一個新的簡報，將要將影片加入其中
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // 讓我們將影片加入簡報 - 我們選擇 KeepLocked 行為，因為我們
        //不打算存取「veryLargeVideo.avi」檔案。
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // 儲存簡報。雖然輸出大型簡報，記憶體消耗
        // 在整個 pres 物件生命週期中仍保持低水平 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **透過 BLOB 從簡報匯出大型檔案**
Aspose.Slides for Android via Java 允許您透過 BLOB 流程從簡報匯出大型檔案（例如音訊或影片檔）。例如，您可能需要從簡報中提取大型媒體檔案，但不希望該檔案被載入電腦記憶體。透過 BLOB 流程匯出檔案，可保持低記憶體消耗。

以下 Java 程式碼展示上述操作：

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// 鎖定來源檔案且不將其載入記憶體
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// 建立 Presentation 實例，鎖定 "hugePresentationWithAudiosAndVideos.pptx" 檔案。
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 將每個影片保存為檔案。為避免高記憶體使用，我們需要一個緩衝區，用於
    // 將簡報影片串流的資料轉移至新建立的影片檔案的串流。
    byte[] buffer = new byte[8 * 1024];

    // 遍歷所有影片
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // 開啟簡報的影片串流。請注意，我們刻意避免存取屬性
        // 如 video.BinaryData ——因為此屬性會回傳包含完整影片的位元組陣列，進而
        // 導致位元組載入記憶體。我們使用 video.GetStream，會回傳 Stream，且不會
        //  需要我們將整個影片載入記憶體。
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
        // 無論影片或簡報大小，記憶體消耗都會保持低水平。
    }
    // 如有需要，您也可以對音訊檔案套用相同步驟。 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **將影像作為 BLOB 新增至簡報**
使用 [**IImageCollection**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IImageCollection) 介面與 [**ImageCollection**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ImageCollection) 類別的方法，您可以將大型影像以串流方式新增，讓它被視為 BLOB。

以下 Java 程式碼說明如何透過 BLOB 流程新增大型影像：

```java
String pathToLargeImage = "large_image.jpg";

// 建立一個新的簡報，將要將影像加入其中。
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// 讓我們將影像加入簡報 - 我們選擇 KeepLocked 行為，因為我們
		// 不打算存取 "largeImage.png" 檔案。
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// 儲存簡報。當輸出大型簡報時，記憶體消耗
		// 在整個 pres 物件生命週期中仍保持低水平
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

通常，載入大型簡報時電腦需要大量暫存記憶體。整個簡報的內容會被載入記憶體，而載入來源的檔案則不再被使用。

以包含 1.5 GB 影片檔案的大型 PowerPoint 簡報（large.pptx）為例，以下 Java 程式碼說明標準載入方式：

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

透過 BLOB 流程，您可以在使用極少記憶體的情況下載入大型簡報。以下 Java 程式碼描述使用 BLOB 流程載入大型簡報檔案（large.pptx）的實作：

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

### **變更暫存檔資料夾**

使用 BLOB 流程時，系統會在預設的暫存檔資料夾中建立暫存檔。如需將暫存檔保存於其他資料夾，可使用 `TempFilesRootPath` 變更儲存設定：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
使用 `TempFilesRootPath` 時，Aspose.Slides 不會自動建立用於儲存暫存檔的資料夾，您必須自行建立該資料夾。
{{% /alert %}}

### **釋放 Presentation 物件以釋放記憶體**

在處理大型簡報時，務必確保正確釋放 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 實例，以釋放其佔用的記憶體。使用完簡報後呼叫 `dispose()` 以釋放非受管理資源。

```java
Presentation presentation = new Presentation("large.pptx");

// ...處理簡報...
presentation.save("large.pdf", SaveFormat.Pdf);

// 明確釋放資源。
presentation.dispose();
```

## **常見問題**

**在 Aspose.Slides 簡報中，哪些資料會被視為 BLOB 並受 BLOB 選項控制？**

影像、音訊、影片等大型二進位物件會被視為 BLOB。整個簡報檔案在載入或儲存時也會涉及 BLOB 處理。這些物件受 BLOB 原則管控，讓您在需要時管理記憶體使用量並寫入暫存檔。

**在哪裡設定載入簡報時的 BLOB 處理規則？**

使用 [LoadOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/) 搭配 [BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/blobmanagementoptions/)。於此處設定 BLOB 的記憶體上限、是否允許暫存檔、暫存檔根路徑，以及來源鎖定行為。

**BLOB 設定會影響效能嗎？如何在速度與記憶體之間取得平衡？**

會。將 BLOB 保留於記憶體可提升速度，但會增加 RAM 用量；降低記憶體上限會將更多工作轉移至暫存檔，減少 RAM 使用但會產生額外 I/O。可使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) 方法調整至適合的平衡點。

**在開啟極大型簡報（例如數十 GB）時，BLOB 選項有幫助嗎？**

有。[BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/blobmanagementoptions/) 為此類情境設計：啟用暫存檔與來源鎖定可顯著降低峰值 RAM 使用量，並提升大型簡報的處理穩定性。

**可否在從串流而非磁碟檔案載入時使用 BLOB 原則？**

可以。相同的規則適用於串流：簡報實例可擁有並鎖定輸入串流（取決於所選的鎖定模式），且在允許的情況下會使用暫存檔，以在處理過程中保持可預測的記憶體使用量。