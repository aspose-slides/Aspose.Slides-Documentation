---
title: 使用 PHP 管理簡報中的影片框架
linktitle: 影片框架
type: docs
weight: 10
url: /zh-hant/php-java/video-frame/
keywords:
- 新增影片
- 建立影片
- 嵌入影片
- 擷取影片
- 取得影片
- 影片框架
- 網路來源
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for PHP（透過 Java）以程式方式在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框架。快速上手指南。"
---
## **簡介**

在簡報中恰當地放置影片可以使您的訊息更具說服力，並提升觀眾的參與度。

PowerPoint 允許您以兩種方式將影片加入簡報投影片：

* 新增或嵌入本機影片（儲存在您的電腦上）
* 新增線上影片（來自 YouTube 等網路來源）

為了讓您能在簡報中加入影片（video objects），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/video/) 類別、[VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 類別以及其他相關型別。

## **建立嵌入式影片框架**

如果您要加入投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。
1. 新增 [Video](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/video/) 物件，並傳入影片檔案路徑以將影片嵌入簡報。
1. 新增 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 物件以為影片建立框架。
1. 儲存已修改的簡報。

以下 PHP 程式碼示範如何將本機儲存的影片加入簡報：

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation("pres.pptx");
  try {
    # 載入影片
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # 取得第一張投影片並新增影片框架
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # 將簡報儲存至磁碟
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

此外，您也可以直接將檔案路徑傳遞給 [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addvideoframe/) 方法來新增影片：

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

## **建立來自網路來源的影片框架**

Microsoft [PowerPoint 2013 及更新版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支援在簡報中使用 YouTube 影片。若您欲使用的影片已上線（例如 YouTube），即可透過其網路連結將其加入簡報。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。
1. 新增 [Video](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/video/) 物件，並傳入影片的連結。
1. 為影片框架設定縮圖。
1. 儲存簡報。

以下 PHP 程式碼示範如何將網路影片加入 PowerPoint 投影片：

```php
  # 建立一個代表簡報檔案的 Presentation 物件
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

## **管理影片字幕**

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框架的隱藏字幕。字幕以 WebVTT 格式儲存，並可透過 [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#getCaptionTracks) 方法取得。

**將字幕新增至影片框架**

將字幕加入影片框架的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 為簡報新增影片。
1. 為投影片新增 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 物件。
1. 使用由 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#getCaptionTracks) 回傳的 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/) 集合，新增 WebVTT 字幕軌道。
1. 儲存已修改的簡報。

以下程式碼示範如何將字幕加入影片框架：

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // 從 WebVTT 檔案新增一條字幕軌道。
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/) 類別亦提供可從串流新增字幕的重載方法。

**從影片框架擷取字幕**

從影片框架擷取字幕的步驟：

1. 載入包含影片的簡報。
1. 找到目標 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 物件。
1. 迭代 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#getCaptionTracks) 集合。
1. 將每個字幕軌道儲存為 `.vtt` 檔案。

以下程式碼示範如何從影片框架擷取字幕：

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
                // 將字幕軌道儲存為 WebVTT 檔案。
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

每個 [Captions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captions/) 物件會公開字幕識別碼、標籤、二進位資料以及以 UTF-8 字串表示的字幕文字。

**從影片框架移除字幕**

從影片框架移除字幕的步驟：

1. 載入包含影片的簡報。
1. 取得目標 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 物件。
1. 從 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/#getCaptionTracks) 集合中移除字幕軌道。
1. 儲存已修改的簡報。

以下程式碼示範如何移除影片框架中的所有字幕：

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // 類型: VideoFrame

    // 移除影片框架中的所有字幕。
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

如果您只需移除單一字幕軌道，請改用 [remove](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/#removeAt) 方法，而非 [clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/#clear)。

## **從投影片中擷取影片**

除了將影片加入投影片外，Aspose.Slides 也允許您從簡報中擷取嵌入的影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例以載入包含影片的簡報。
2. 迭代所有 [Slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/) 物件。
3. 迭代所有 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 物件以尋找 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/)。
4. 將影片儲存至磁碟。

以下 PHP 程式碼示範如何擷取簡報投影片上的影片：

```php
  # 建立一個代表簡報檔案的 Presentation 物件
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

## **FAQ**

**可以變更 VideoFrame 哪些影片播放參數？**

您可以控制 [playback mode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/setplaymode/)（自動或點擊）以及 [looping](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/setplayloopmode/)。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/) 物件的屬性取得。

**加入影片會影響 PPTX 檔案大小嗎？**

會。當您嵌入本機影片時，二進位資料會寫入文件，因而使簡報大小按檔案大小比例增加。若加入線上影片，僅嵌入連結與縮圖，大小增幅較小。

**能否在不變更位置與尺寸的情況下取代既有 VideoFrame 中的影片？**

能。您可以使用 [video content](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoframe/setembeddedvideo/) 交換框架內的影片，同時保留形狀的幾何屬性；這在更新既有佈局的媒體時相當常見。

**是否能判斷嵌入影片的內容類型 (MIME)？**

能。嵌入的影片具有可讀取的 [content type](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/video/getcontenttype/)，可用於例如儲存至磁碟時的判斷。