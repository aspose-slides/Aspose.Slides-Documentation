---
title: 在 PHP 中管理簡報 BLOB 以有效使用記憶體
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh-hant/php-java/manage-blob/
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
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 中管理 BLOB 資料，以簡化 PowerPoint 與 OpenDocument 檔案操作，提升簡報處理效率。"
---
## **概述**

Aspose.Slides 提供基於 BLOB 的大型二進位資料處理，能在簡報中處理大型影像、音訊、視訊與簡報檔案時減少記憶體消耗。

本篇說明如何使用 BLOB 處理程序將大型媒體加入簡報、從簡報匯出大型媒體，以及更有效率地載入大型簡報。也說明在處理過程中如何使用暫存檔案，以及如何變更儲存暫存檔案的資料夾。

## **關於 BLOB**

**BLOB** (**Binary Large Object**) 通常是以二進位格式儲存的大型項目（照片、簡報、文件或媒體）。

Aspose.Slides for PHP via Java 讓您在涉及大型檔案時，以降低記憶體消耗的方式使用 BLOB。

{{% alert title="Info" color="info" %}}
為了繞過與串流互動時的某些限制，Aspose.Slides 可能會複製串流的內容。透過串流載入大型簡報會導致簡報內容被複製，從而造成載入緩慢。因此，當您打算載入大型簡報時，我們強烈建議使用簡報檔案路徑而非串流。
{{% /alert %}}

## **使用 BLOB 減少記憶體消耗**

### **透過 BLOB 將大型檔案加入簡報**

[Aspose.Slides](/slides/zh-hant/php-java/) for Java 允許您透過 BLOB 程序將大型檔案（此處為大型影片檔）加入簡報，以降低記憶體消耗。

此 Java 範例說明如何透過 BLOB 程序將大型影片檔加入簡報：

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # 建立一個新簡報，將影片加入其中
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # 讓我們將影片加入簡報 - 我們選擇 KeepLocked 行為，因為我們
      # 不打算存取 "veryLargeVideo.avi" 檔案。
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # 儲存簡報。當大型簡報輸出時，記憶體消耗
      # 在整個 pres 物件的生命週期中保持低水平
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **透過 BLOB 從簡報匯出大型檔案**
Aspose.Slides for PHP via Java 允許您透過 BLOB 程序從簡報匯出大型檔案（例如音訊或視訊檔）。舉例來說，您可能需要從簡報中擷取大型媒體檔案，但不想將檔案載入電腦記憶體。透過 BLOB 程序匯出檔案，可保持低記憶體消耗。

以下程式碼示範上述操作：

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # 鎖定來源檔案且不將其載入記憶體
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # 建立 Presentation 實例，鎖定 "hugePresentationWithAudiosAndVideos.pptx" 檔案。
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # 讓我們將每個影片儲存為檔案。為了避免大量記憶體使用，我們需要使用緩衝區
    # 將簡報中影片串流的資料傳輸到新建立的影片檔案的串流。
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # 遍歷所有影片
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # 開啟簡報影片串流。請注意，我們特意避免存取屬性
      # 如 video.BinaryData —— 因為此屬性會返回包含完整影片的位元組陣列，進而
      # 導致位元組被載入記憶體。我們使用 video.GetStream，它會返回 Stream —— 且不會
      # 要求我們將整個影片載入記憶體。
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # 無論影片或簡報的大小，記憶體消耗都會保持低。
    }
    # 如有需要，您也可以對音訊檔案套用相同步驟。
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **將影像以 BLOB 方式加入簡報**
使用 [ImageCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagecollection/) 類別的方法，您可以將大型影像以串流方式加入，讓它被視為 BLOB。

此 PHP 程式碼說明如何透過 BLOB 程序加入大型影像：

```php
  $pathToLargeImage = "large_image.jpg";
  # 建立一個新的簡報，將影像加入其中。
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # 讓我們將影像加入簡報 - 我們選擇 KeepLocked 行為，因為我們
      # 並不打算存取 "largeImage.png" 檔案。
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # 儲存簡報。當大型簡報輸出時，記憶體消耗
      # 在整個 pres 物件的生命週期中保持低水平
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **記憶體與大型簡報**

通常，載入大型簡報需要大量暫存記憶體。整個簡報的內容會被載入記憶體，而載入來源的檔案則不再使用。

以包含 1.5 GB 影片檔案的大型 PowerPoint 簡報 (large.pptx) 為例，以下 PHP 程式碼描述了標準載入方式：

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

但此方法會消耗約 1.6 GB 的暫存記憶體。

### **以 BLOB 載入大型簡報**
透過 BLOB 程序，您可以在使用極少記憶體的情況下載入大型簡報。以下 PHP 程式碼說明了使用 BLOB 程序載入 large.pptx 的實作方式：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **變更暫存檔案的資料夾**
使用 BLOB 程序時，電腦會在預設的暫存資料夾中建立暫存檔。如果您希望將暫存檔放置於其他資料夾，可透過 `setTempFilesRootPath` 變更儲存設定：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
使用 `setTempFilesRootPath` 時，Aspose.Slides 不會自動建立儲存暫存檔的資料夾，您必須自行手動建立該資料夾。
{{% /alert %}}

### **釋放簡報物件以釋放記憶體**
處理大型簡報時，請確保正確釋放 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例，以釋放其佔用的記憶體。完成簡報使用後，呼叫 `dispose()` 以釋放非受管理資源。

```php
$presentation = new Presentation("large.pptx");

# ...處理簡報...
$presentation->save("large.pdf", SaveFormat::Pdf);

# 明確釋放資源。
$presentation->dispose();
```

## **常見問題**

**什麼資料在 Aspose.Slides 簡報中會被視為 BLOB 並受 BLOB 選項控制？**  
大型二進位物件，如影像、音訊與視訊，都會被視為 BLOB。整個簡報檔案在載入或儲存時亦涉及 BLOB 處理。這些物件受 BLOB 原則管理，可讓您在需要時將記憶體使用量轉移至暫存檔。

**在載入簡報時，我該在哪裡設定 BLOB 處理規則？**  
使用 [LoadOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/) 搭配 [BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/blobmanagementoptions/)。在此處您可設定 BLOB 的記憶體上限、是否允許暫存檔、暫存檔根目錄，以及來源鎖定行為。

**BLOB 設定會影響效能嗎？該如何在速度與記憶體之間取得平衡？**  
會的。將 BLOB 完全保留在記憶體中可提升速度，但會增加 RAM 使用量；降低記憶體上限會將更多工作轉移至暫存檔，降低 RAM 消耗，但會產生額外 I/O。可使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) 取得適合您的工作負載與環境的平衡。

**在開啟極大簡報（如數 GB）時，BLOB 選項有幫助嗎？**  
有。[BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/blobmanagementoptions/) 專為此類情境設計：啟用暫存檔並使用來源鎖定可顯著降低峰值 RAM 使用量，讓處理極大簡報更加穩定。

**我可以在從串流而非磁碟檔載入時使用 BLOB 原則嗎？**  
可以。相同的規則同樣適用於串流：簡報實例可以擁有並鎖定輸入串流（取決於選擇的鎖定模式），且在允許的情況下會使用暫存檔，以在處理期間保持可預測的記憶體使用量。