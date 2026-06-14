---
title: 在 JavaScript 中管理簡報 BLOB 以提升記憶體使用效率
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh-hant/nodejs-java/manage-blob/
keywords:
- 大型物件
- 大型項目
- 大型檔案
- 新增 BLOB
- 匯出 BLOB
- 以 BLOB 方式新增影像
- 減少記憶體
- 記憶體消耗
- 大型簡報
- 暫存檔
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中管理 BLOB 資料，以簡化 PowerPoint 與 OpenDocument 檔案操作，提升簡報處理效能。"
---
## **概覽**

Aspose.Slides 提供基於 BLOB 的大型二進位資料處理，可協助在處理大型圖像、音訊、影片和簡報檔案時減少記憶體消耗。

本文章說明如何使用基於 BLOB 的處理將大型媒體加入簡報、從簡報匯出大型媒體，以及更有效率地載入大型簡報。亦說明在處理期間如何使用暫存檔，以及如何變更儲存暫存檔的資料夾。

## **關於 BLOB**

**BLOB**（**Binary Large Object**）通常是以二進位格式儲存的大型項目（照片、簡報、文件或媒體）。

Aspose.Slides for Node.js via Java 允許您以降低記憶體消耗的方式，對大型檔案使用 BLOB。

{{% alert title="資訊" color="info" %}}

為了規避與串流互動時的某些限制，Aspose.Slides 可能會複製串流的內容。透過串流載入大型簡報會導致簡報內容被複製，造成載入緩慢。因此，當您打算載入大型簡報時，我們強烈建議使用簡報檔案路徑，而非其串流。

{{% /alert %}}

## **使用 BLOB 減少記憶體消耗**

### **透過 BLOB 將大型檔案新增至簡報**

[Aspose.Slides](/slides/zh-hant/nodejs-java/) for Node.js via Java 允許您透過 BLOB 流程將大型檔案（此處為大型影片檔）加入簡報，以減少記憶體消耗。

以下 JavaScript 示範如何透過 BLOB 流程將大型影片檔加入簡報：

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// 建立一個將加入影片的新簡報
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // 讓我們將影片加入簡報 - 我們選擇 KeepLocked 行為，因為我們
        // 不打算存取 "veryLargeVideo.avi" 檔案。
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // 儲存簡報。即使輸出大型簡報，記憶體消耗
        // 在 pres 物件的生命週期中仍保持低消耗
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **透過 BLOB 從簡報匯出大型檔案**

Aspose.Slides for Node.js via Java 允許您透過 BLOB 流程，從簡報中匯出大型檔案（例如音訊或影片檔）。例如，您可能需要從簡報中提取大型媒體檔案，但不希望將檔案載入電腦記憶體。透過 BLOB 流程匯出檔案，可保持低記憶體消耗。

以下 JavaScript 程式碼示範上述操作：

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// 鎖定來源檔案且不將其載入記憶體
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// 建立 Presentation 實例，鎖定 "hugePresentationWithAudiosAndVideos.pptx" 檔案。
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 讓我們將每個影片儲存為檔案。為了防止記憶體使用過高，我們需要一個緩衝區來使用
    // 將簡報的影片串流資料傳輸到新建立的影片檔案的串流。
    var buffer = new byte[8 * 1024];
    // 遍歷所有影片
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // 開啟簡報的影片串流。請注意，我們特意避免存取屬性
        // 例如 video.BinaryData - 因為此屬性會回傳包含完整影片的位元組陣列，進而
        // 導致位元組載入記憶體。我們使用 video.GetStream，會回傳 Stream，且不會
        // 需要我們將整個影片載入記憶體。
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // 記憶體消耗將保持低水平，無論影片或簡報的大小如何。
    }
    // 如有需要，您可以對音訊檔案套用相同的步驟。
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **在簡報中以 BLOB 方式加入圖片**

使用 [**ImageCollection**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ImageCollection) 類別和 [**ImageCollection**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ImageCollection) 類別的方法，您可以將大型圖片以串流方式加入，並視為 BLOB。

以下 JavaScript 程式碼示範如何透過 BLOB 流程加入大型圖片：

```javascript
var pathToLargeImage = "large_image.jpg";
// 建立一個將加入影像的新簡報。
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // 讓我們將影像加入簡報 - 我們選擇 KeepLocked 行為，因為我們
        // 不打算存取 "largeImage.png" 檔案。
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // 儲存簡報。當輸出大型簡報時，記憶體消耗
        // 在 pres 物件的生命週期中保持低水平
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **記憶體與大型簡報**

通常載入大型簡報時，電腦需要大量暫存記憶體。所有簡報內容會載入記憶體，且載入來源的檔案不再被使用。

假設有一個大型 PowerPoint 簡報（large.pptx），其中包含 1.5 GB 影片檔。以下 JavaScript 程式碼示範標準載入方式：

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

但此方法會佔用約 1.6 GB 暫存記憶體。

### **以 BLOB 載入大型簡報**

透過 BLOB 流程，您可以在使用極少記憶體的情況下載入大型簡報。以下 JavaScript 程式碼說明了使用 BLOB 流程載入大型簡報檔（large.pptx）的實作：

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **變更暫存檔的資料夾**

使用 BLOB 流程時，電腦會在預設的暫存檔資料夾中建立暫存檔。若希望將暫存檔儲存於其他資料夾，可使用 `setTempFilesRootPath` 變更儲存設定：

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="資訊" color="info" %}}

使用 `setTempFilesRootPath` 時，Aspose.Slides 不會自動建立暫存檔資料夾，您必須自行建立該資料夾。

{{% /alert %}}

### **釋放 Presentation 物件以釋放記憶體**

處理大型簡報時，請確保正確釋放 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例，以釋放其佔用的記憶體。使用完簡報後呼叫 `dispose()` 以釋放非受控資源。

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...處理簡報...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// 明確釋放資源。
presentation.dispose();
```

## **常見問題**

**在 Aspose.Slides 簡報中，哪些資料會被視為 BLOB 並受 BLOB 選項控制？**

圖像、音訊、影片等大型二進位物件會被視為 BLOB。整個簡報檔案在載入或儲存時也涉及 BLOB 處理。這些物件受 BLOB 原則管理，讓您在需要時控制記憶體使用與暫存檔寫入。

**在哪裡設定載入簡報時的 BLOB 處理規則？**

使用 [LoadOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/) 搭配 [BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/blobmanagementoptions/)。在此可設定 BLOB 的記憶體上限、是否允許暫存檔、暫存檔根目錄路徑，以及來源鎖定行為。

**BLOB 設定會影響效能嗎？如何在速度與記憶體之間取得平衡？**

會。將 BLOB 完全保留在記憶體中可提升速度，但會增加 RAM 使用量；降低記憶體上限會將更多工作交給暫存檔，減少 RAM 使用但會產生額外 I/O。使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) 方法可根據工作負載與環境取得適當平衡。

**在開啟極大型簡報（例如數十 GB）時，BLOB 選項是否有幫助？**

有。[BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/blobmanagementoptions/) 為此類情境設計：啟用暫存檔並使用來源鎖定可顯著降低峰值 RAM 使用量，並讓處理大型簡報更為穩定。

**是否可以在從串流而非磁碟檔案載入時使用 BLOB 原則？**

可以。相同的規則適用於串流：簡報實例可擁有並鎖定輸入串流（取決於所選的鎖定模式），且在允許的情況下會使用暫存檔，使記憶體使用在處理期間保持可預測。