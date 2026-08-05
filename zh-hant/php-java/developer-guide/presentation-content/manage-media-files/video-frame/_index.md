---
title: 使用 PHP 管理簡報中的影片框格
linktitle: 影片框格
type: docs
weight: 10
url: /zh-hant/php-java/video-frame/
keywords:
- 新增影片
- 建立影片
- 嵌入影片
- 擷取影片
- 檢索影片
- 影片框格
- 網路來源
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "學習使用 Aspose.Slides for PHP via Java 以程式方式在 PowerPoint 和 OpenDocument 投影片中新增與擷取影片框格。快速上手指南。"
---
## **簡介**

在簡報中恰當放置的影片可以讓您的訊息更具說服力，並提升觀眾的參與度。 

PowerPoint 允許您以兩種方式向簡報的投影片添加影片：

* 新增或嵌入本機影片（儲存在您的電腦上）
* 新增線上影片（來自 YouTube 等網路來源）。

為了讓您能向簡報添加影片（video 物件），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/video/) 類別、[VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 類別以及其他相關型別。

## **建立嵌入式影片框格**

如果您要添加到投影片的影片檔案儲存在本機，您可以建立影片框格將影片嵌入簡報中。 

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。 
1. 加入一個 [Video](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/video/) 物件，並傳入影片檔案路徑以將影片嵌入簡報中。
1. 加入一個 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 物件，以為影片建立框格。
1. 儲存已修改的簡報。 

以下 PHP 程式碼示範如何將本機儲存的影片添加至簡報：

```php
  # 實例化 Presentation 類別
  $pres = new Presentation("pres.pptx");
  try {
    # 載入影片
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # 取得第一張投影片並加入影片框格
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # 將簡報儲存到磁碟
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

或者，您也可以直接將檔案路徑傳遞給 [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addvideoframe/) 方法來加入影片：

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **使用網路來源影片建立影片框格**

Microsoft [PowerPoint 2013 及更新版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支援在簡報中使用 YouTube 影片。如果您要使用的影片可於線上取得（例如 YouTube），可以透過其網路連結將其添加到簡報中。 

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例
1. 透過索引取得投影片的參考。 
1. 加入一個 [Video](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/video/) 物件，並傳入影片的連結。
1. 為影片框格設定縮圖。 
1. 儲存簡報。 

以下 PHP 程式碼示範如何將網路影片添加至 PowerPoint 簡報的投影片中：

```php
  # 實例化一個代表簡報檔案的 Presentation 物件
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **裁剪影片框格**

Aspose.Slides 允許您透過 [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#setTrimFromStart) 與 [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#setTrimFromEnd) 設定 trim-from-start 與 trim-from-end 之值，以控制影片播放的部分。兩個值皆以毫秒為單位，分別定義從影片開頭與結尾略過的時間長度。這些設定會變更簡報中影片的播放設定；不會裁切或以其他方式修改嵌入之影片二進位資料。

**設定裁剪參數**

建立影片框格並設定其裁剪參數的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 將 [Video](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/video/) 物件加入簡報。
1. 將 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 物件加入投影片。
1. 透過 [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#setTrimFromStart) 與 [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#setTrimFromEnd) 設定 trim-from-start 與 trim-from-end 的值。
1. 儲存已修改的簡報。

以下程式碼範例會在播放時跳過嵌入式影片的前 2.5 秒與最後 1 秒：

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**讀取裁剪參數**

若要檢查現有的裁剪參數，請載入簡報、在第一張投影片的圖形中找出 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 物件，並透過 [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#getTrimFromStart) 與 [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#getTrimFromEnd) 讀取其值。

以下程式碼範例會找出第一張投影片上的第一個影片框格，並以毫秒為單位回報其裁剪參數：

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **管理影片字幕**

Aspose.Slides 允許您在 PowerPoint 簡報的影片框格中管理隱藏式字幕。字幕以 WebVTT 格式儲存，並透過 [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#getCaptionTracks) 方法取得。

**為影片框格新增字幕**

將字幕新增至影片框格的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 將影片加入簡報。
1. 將 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 物件加入投影片。
1. 使用 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#getCaptionTracks) 回傳的 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/) 集合，新增 WebVTT 字幕軌。
1. 儲存已修改的簡報。

以下程式碼示範如何為影片框格新增字幕：

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // 從 WebVTT 檔案新增一個字幕軌道。
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/) 類別亦提供一個重載，可讓您從串流新增字幕。

**從影片框格擷取字幕**

從影片框格擷取字幕的步驟：

1. 載入含有影片的簡報。
1. 找出目標的 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 物件。
1. 遍歷 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#getCaptionTracks) 集合。
1. 將每個字幕軌儲存為 `.vtt` 檔案。

以下程式碼示範如何從影片框格擷取字幕：

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // 保存字幕軌道到 WebVTT 檔案。
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

每個 [Captions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captions/) 物件會公開字幕識別碼、標籤、二進位資料，以及作為 UTF-8 字串的字幕文字。

**從影片框格移除字幕**

從影片框格移除字幕的步驟：

1. 載入含有影片的簡報。
1. 取得目標的 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 物件。
1. 從 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#getCaptionTracks) 集合中移除字幕軌。
1. 儲存已修改的簡報。

以下程式碼示範如何從影片框格中移除全部字幕：

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // 類型: VideoFrame

    // 從影片框格中移除所有字幕。
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

如果您只需要移除單一字幕軌，請使用 [remove](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/#removeAt) 方法，而非 [clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/#clear)。

## **從投影片擷取影片**

除了向投影片添加影片之外，Aspose.Slides 也允許您擷取嵌入於簡報中的影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例以載入含有影片的簡報。
2. 遍歷所有 [Slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/) 物件。
3. 遍歷所有 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 物件以尋找 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/)。
4. 將影片儲存至磁碟。

以下 PHP 程式碼示範如何擷取簡報投影片中的影片：

```php
  # 實例化一個代表簡報檔案的 Presentation 物件
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # 取得檔案副檔名
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**可以變更 VideoFrame 的哪些影片播放參數？**

您可以透過 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 物件的屬性，控制 [playback mode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/setplaymode/)（自動或點擊播放）以及 [looping](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/setplayloopmode/)（循環播放）。

**新增影片會影響 PPTX 檔案大小嗎？**

會。當您嵌入本機影片時，二進位資料會被納入文件中，導致簡報大小隨檔案大小成比例增加。當您新增線上影片時，僅嵌入連結與縮圖，大小增加較少。

**我能在不變更位置和大小的情況下，取代現有 VideoFrame 中的影片嗎？**

可以。您可以在保留形狀幾何的前提下，交換框格內的 [video content](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/setembeddedvideo/)，這在現有布局中更新媒體時是常見的情況。

**可以判斷嵌入影片的內容類型（MIME）嗎？**

會。嵌入的影片具有可讀取的 [content type](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/video/getcontenttype/)，您可以利用它，例如在儲存至磁碟時使用。