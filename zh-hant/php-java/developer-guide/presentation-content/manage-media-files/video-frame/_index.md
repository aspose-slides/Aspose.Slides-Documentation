---
title: 使用 PHP 於簡報中管理影片框架
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
description: "學習如何使用 Aspose.Slides for PHP via Java，以程式方式在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框架。快速入門指南。"
---
## **簡介**

影片可以協助說明概念並吸引觀眾。Aspose.Slides for PHP via Java 讓您能將影片框架新增至投影片、調整播放設定、管理字幕，並提取嵌入的影片資料。

PowerPoint 支援本機影片以及指向線上影片的連結，例如 YouTube 影片。

要表示影片資料和影片框架，Aspose.Slides 提供 [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) 類別、[VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) 類別，以及其他相關類型。

## **建立嵌入式影片框架**

如果您想加入投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。

此範例將本機影片嵌入現有簡報的第一張投影片，並儲存結果。框架的座標與尺寸以點 (points) 為單位。因為 [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) 在簡報使用時會保持串流鎖定，所以串流會在儲存完成前保持開啟狀態。

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

您也可以直接將本機影片路徑傳遞給 [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame)。此範例將影片嵌入新簡報的第一張投影片。影片必須在簡報儲存前持續可存取。

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

## **使用網路來源的影片建立影片框架**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支援簡報中使用線上影片。您可以建立連結至線上影片（例如 YouTube 影片）的影片框架。

此範例在第一張投影片加入 YouTube 影片連結與縮圖。請替換影片識別碼以使用其他影片。[setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) 方法請求自動播放。下載縮圖與播放影片需要網際網路存取。簡報檢視器也必須支援線上影片播放。

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

## **全螢幕播放影片**

在培訓簡報中，您可以以全螢幕模式播放軟體示範，讓觀眾看到細節。呼叫 [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) 並傳入 `true` 即可在播放期間啟用此行為。

此範例開啟簡報，於第一張投影片找到第一個 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)，並啟用全螢幕播放。輸入的簡報必須至少在第一張投影片包含一個現有的影片框架。

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

全螢幕播放會控制影片的顯示方式。除此之外，[setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) 控制其自動播放或點擊播放，而 [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) 控制是否重複播放。若要選擇開始行為，請將播放模式設定為 [VideoPlayModePreset::Auto 或 VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/)。範例保留了現有的開始與迴圈設定。

## **播放後倒帶影片**

在培訓簡報中，將示範影片倒回起點可讓主持人再次播放。呼叫 [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) 並傳入 `true`，即可在播放結束後將影片返回起始位置。

此範例開啟簡報，於第一張投影片找到第一個 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)，並啟用倒帶。它會停用迴圈以讓播放結束，並將播放設定為點擊開始。輸入的簡報必須至少在第一張投影片包含一個現有的影片框架。

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

倒帶會將影片返回起始位置而不會再次啟動。相反地，呼叫 [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) 並傳入 `true` 會自動重複播放。當您希望影片播放完畢後仍保持可重新播放時，請保持迴圈停用。[setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) 讓主持人自行決定何時開始播放。請如範例所示在設定迴圈之後再設定播放模式。倒帶與 [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) 的功能互不影響。

## **裁剪影片框架**

使用 [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) 與 [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) 可在播放時跳過影片的開頭或結尾部分。兩個數值皆以毫秒為單位。裁剪會變更播放設定，但不會修改嵌入的影片資料。

**設定裁剪參數**

此範例將本機影片嵌入，並在播放時跳過前 2.5 秒與最後 1 秒。請使用長度超過 3.5 秒的影片，以確保仍有可播放的段落。

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

此範例以毫秒為單位輸出第一張投影片上第一個影片框架的裁剪值。簡報必須至少包含一張投影片。若該投影片沒有影片框架，則不會輸出任何內容。前述範例會產生 2500 與 1000 的值。

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

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框架的隱藏字幕。字幕以 WebVTT 格式儲存，並透過 [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) 方法取得。

### **新增字幕至影片框架**

此範例將本機影片嵌入，並加入標記為 English 的 WebVTT 字幕軌。字幕的時間戳記應與影片相符。儲存的簡報會同時包含影片與其字幕。

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

[CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) 類別亦提供一個重載，允許您從串流新增字幕。

### **從影片框架擷取字幕**

此範例將第一張投影片上所有影片框架的字幕軌保存為個別的 WebVTT 檔案。以連續編號保持輸出檔案的唯一性。主控台會回報擷取的軌道數量。簡報必須至少包含一張投影片。

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

每個 [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) 物件會公開字幕的識別碼、標籤、二進位資料，以及作為 UTF-8 字串的字幕文字。

### **從影片框架移除字幕**

此範例移除第一張投影片上第一個圖形位置之影片框架的所有字幕，並儲存結果。假設該投影片與圖形皆存在且圖形為影片框架。

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

如果您只需要移除單一字幕軌，請使用 [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) 方法，而非 [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear)。

### **搜尋影片字幕**

[Captions::getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) 會回傳完整的 WebVTT 軌道，包括其標頭、時間線以及字幕文字。您可以在記憶體中搜尋提示，以找出口語片段及其時間戳記。例如，第二張投影片的英文軌道可能包含以下文字。

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

此範例開啟 `captioned_media.pptx`，並使用 [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) 讀取每張投影片上每個最上層影片框架的軌道。在純文字提示中，時間線包含 `-->`，空白行表示提示結束。當字幕中以任何大小寫出現 “café” 時，範例會輸出投影片編號、軌道標籤、原始時間線與完整字幕。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("captioned_media.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                continue;
            }
            $trackCount = java_values($shape->getCaptionTracks()->getCount());
            for ($index = 0; $index < $trackCount; $index++) {
                $track = $shape->getCaptionTracks()->get_Item($index);
                $lines = preg_split('/\r\n|\n|\r/', java_values($track->getDataAsString()));
                $lineCount = count($lines);
                for ($i = 0; $i < $lineCount; $i++) {
                    $timing = $lines[$i];
                    if (strpos($timing, "-->") === false) {
                        continue;
                    }
                    $captionLines = [];
                    while (++$i < $lineCount && $lines[$i] !== "") {
                        $captionLines[] = $lines[$i];
                    }
                    $caption = implode("\n", $captionLines);
                    if (preg_match('/café/iu', $caption)) {
                        printf("Slide %d | %s | %s\n", java_values($slide->getSlideNumber()), java_values($track->getLabel()), $timing);
                        echo $caption, "\n";
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

搜尋 “café” 為此示例軌道產生一筆匹配。搜尋會排除軌道標頭，並在輸出中保留時間設定。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **從投影片擷取影片**

除了將影片新增至投影片外，Aspose.Slides 也允許您從簡報中擷取嵌入的影片。

此範例將每張投影片的嵌入影片擷取為分別編號的二進位檔案。連結影片會被略過，因為它們沒有嵌入資料。主控台會列印每支影片的 MIME 類型以及總數量。輸出使用通用的 `.bin` 副檔名；如有需要，可更改為符合報告的媒體類型。

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

## **FAQ**

**哪種影片播放參數可以變更於影片框架？**

您可以控制 [playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode)（自動或點擊）和 [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode)。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) 物件的方法取得。

**加入影片會影響 PPTX 檔案大小嗎？**

會。當您嵌入本機影片時，二進位資料會包含在文件中，導致簡報大小按檔案大小成比例增加。當您連結至線上影片並加入縮圖時，簡報只儲存連結與預覽圖片而非影片資料，故大小的增加通常較少。

**我可以在不更改位置與大小的情況下，替換現有影片框架中的影片嗎？**

可以。您可以在框架內交換 [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo)，同時保留形狀的幾何尺寸；這是更新既有版面媒體的常見情境。

**可否判斷嵌入影片的內容類型 (MIME)？**

可以。嵌入的影片具有可讀取的 [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType)，您可使用它，例如在儲存至磁碟時。