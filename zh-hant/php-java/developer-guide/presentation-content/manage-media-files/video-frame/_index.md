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
description: "學習如何使用 Aspose.Slides for PHP via Java 以程式方式在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框架。快速操作指南。"
---
## **簡介**

影片可以幫助說明概念並吸引觀眾。Aspose.Slides for PHP via Java 讓您能將影片框架添加到投影片、調整播放設定、管理字幕，並提取嵌入的影片資料。

PowerPoint 支援本機影片以及指向線上影片的連結，例如 YouTube 影片。

為了表示影片資料與影片框架，Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) 類別、[VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) 類別，以及其他相關型別。

## **建立嵌入式影片框架**

如果您想加入投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。

此範例將本機影片嵌入現有簡報的第一張投影片，並儲存結果。框架座標與尺寸以點為單位。因為 [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) 會在簡報使用期間保持鎖定，所以串流會一直開啟直到儲存完成。

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

您也可以直接將本機影片路徑傳遞給 [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame)。此範例將影片嵌入新簡報的第一張投影片。影片必須在簡報儲存之前保持可存取。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **建立來自網路來源的影片框架**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 在簡報中支援線上影片。您可以建立影片框架，將其連結至線上影片，例如 YouTube 影片。

此範例將 YouTube 影片連結與縮圖加入第一張投影片。將影片識別碼替換為其他影片即可使用另一支影片。[setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) 方法請求自動播放。下載縮圖與播放影片需要網路存取。簡報檢視器也必須支援線上影片播放。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在全螢幕模式下播放影片**

在訓練簡報中，您可以在全螢幕模式下播放軟體示範，讓觀眾看到細節。以 `true` 呼叫 [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) 即可於播放期間啟用此行為。

此範例開啟簡報，於第一張投影片上找到第一個 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)，並啟用全螢幕播放。輸入簡報必須至少包含一張投影片，且在第一張投影片上有已存在的影片框架。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

全螢幕播放控制影片的顯示方式。另一方面，[setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) 控制是自動開始或點擊開始，[setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) 控制是否重複播放。若要選擇開始行為，請將播放模式設定為 [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/)。此範例保留了現有的開始與迴圈設定。

## **回倒影片於播放後**

在訓練簡報中，將示範影片回到開頭可讓簡報者再次播放。以 `true` 呼叫 [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) 即可在播放結束後將影片回到開頭。

此範例開啟簡報，於第一張投影片上找到第一個 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)，並啟用回倒。它會停用迴圈讓播放能結束，並將播放設定為點擊開始。輸入簡報必須至少包含一張投影片，且在第一張投影片上有已存在的影片框架。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

回倒會將影片返回開頭而不會再次啟動。相較之下，將 [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) 設為 `true` 會自動重複播放。想讓影片結束後保持可再次播放時，請將迴圈關閉。[setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/)，讓簡報者自行決定何時開始播放。請如範例所示在設定迴圈之後再設定播放模式。回倒的行為與 [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) 無關。

## **裁剪影片框架**

使用 [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) 與 [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) 可在播放時略過影片的開頭或結尾部分。兩個值皆以毫秒為單位。裁剪會變更播放設定，卻不會修改嵌入的影片資料。

**設定裁剪參數**

此範例將本機影片嵌入，並於播放時略過前 2.5 秒與最後 1 秒。請使用長度超過 3.5 秒的影片，以保留可播放的片段。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**讀取裁剪設定**

此範例以毫秒為單位列印第一張投影片上第一個影片框架的裁剪值。簡報必須至少包含一張投影片。如果該投影片沒有影片框架，則不會輸出任何內容。前述範例會產生 2500 與 1000 兩個值。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **管理影片字幕**

Aspose.Slides 允許您在 PowerPoint 簡報中管理影片框架的隱藏字幕。字幕以 WebVTT 格式儲存，並可透過 [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) 方法取得。

**為影片框架新增字幕**

此範例將本機影片嵌入，並新增一條標示為 English 的 WebVTT 字幕軌。字幕時間戳記應與影片相符。儲存的簡報會同時包含影片與其字幕。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) 類別也提供一個重載方法，允許您從串流加入字幕。

**從影片框架擷取字幕**

此範例將第一張投影片上所有影片框架的字幕軌另存為個別的 WebVTT 檔案。使用連續編號以保持輸出檔案的唯一性。主控台會回報擷取到的字幕軌數量。簡報必須至少包含一張投影片。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

每個 [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) 物件會揭露字幕識別碼、標籤、二進位資料，以及以 UTF-8 字串表示的字幕文字。

**從影片框架移除字幕**

此範例移除第一張投影片上第一個形狀位置的影片框架中所有的字幕，並儲存結果。假設該投影片與形狀均存在，且該形狀為影片框架。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

如果只需要移除單一字幕軌，請使用 [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) 方法，而非 [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear)。

## **從投影片擷取影片**

除了將影片加入投影片外，Aspose.Slides 亦可從簡報中擷取已嵌入的影片。

此範例將每張投影片中嵌入的影片擷取為獨立的編號二進位檔案。連結的影片會被略過，因為它們沒有嵌入資料。主控台會列印每支影片的 MIME 類型及總計數量。輸出使用通用的 `.bin` 副檔名；如有需要，可依回報的媒體類型自行更改副檔名。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**可以變更影片框架的哪些播放參數？**

您可以控制 [playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode)（自動或點擊）與 [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode)。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) 物件的方法取得。

**加入影片會影響 PPTX 檔案大小嗎？**

會的。若您嵌入本機影片，二進位資料會被納入文件中，簡報大小會隨影片檔案大小成比例增長。若您連結到線上影片並加入縮圖，簡報只會儲存連結與預覽圖，而非影片本身，通常會較少增加檔案大小。

**我可以在不變更位置與尺寸的前提下，取代已存在影片框架中的影片嗎？**

可以。您可以在保持形狀幾何尺寸不變的情況下，交換影片框架內的 [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo)，這在更新已佈局媒體時相當常見。

**能否判斷嵌入影片的內容類型 (MIME)？**

能。嵌入的影片具有可透過 [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) 取得的 MIME 類型，您可在儲存至磁碟或其他用途時使用。