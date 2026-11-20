---
title: 使用 PHP 管理演示文稿中的视频帧
linktitle: 视频帧
type: docs
weight: 10
url: /zh/php-java/video-frame/
keywords:
- 添加视频
- 创建视频
- 嵌入视频
- 提取视频
- 检索视频
- 视频帧
- 网络来源
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "学习使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速入门指南。"
---
## **介绍**

视频可以帮助解释理念并吸引观众。Aspose.Slides for PHP via Java 允许您向幻灯片添加视频帧、调整播放设置、管理字幕并提取嵌入的视频数据。

PowerPoint 支持本地视频和指向在线视频（例如 YouTube 视频）的链接。

为了表示视频数据和视频帧，Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) 类、[VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) 类以及其他相关类型。

## **创建嵌入式视频帧**

如果您要添加到幻灯片中的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

此示例将在现有演示文稿的第一张幻灯片上嵌入本地视频并保存结果。帧的坐标和尺寸以点为单位。由于 [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) 在演示文稿使用期间保持流锁定，流会一直保持打开状态直至保存完成。

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

您还可以直接将本地视频路径传递给 [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame)。此示例将在新演示文稿的第一张幻灯片上嵌入视频。视频必须在演示文稿保存之前保持可访问。

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

## **创建来自网络源的视频帧**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 在演示文稿中支持在线视频。您可以创建链接到在线视频（例如 YouTube 视频）的视频帧。

此示例将 YouTube 视频链接和缩略图添加到第一张幻灯片。替换视频标识符即可使用其他视频。[setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) 方法请求自动播放。下载缩略图和播放视频需要互联网访问。演示文稿查看器还必须支持在线视频播放。

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

## **全屏播放视频**

在培训演示文稿中，您可以以全屏模式播放软件演示，以便观众看到细节。调用 [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) 并传入 `true` 可在播放期间启用此行为。

此示例打开演示文稿，查找第一张幻灯片上的第一个 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)，并启用全屏播放。输入演示文稿必须至少包含一张幻灯片，并在第一张幻灯片上已有视频帧。

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

全屏播放控制视频的显示方式。与此同时，[setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) 控制视频是自动开始还是点击开始，而 [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) 控制是否循环播放。若要选择启动行为，请将播放模式设置为 [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/)。示例保留了现有的启动和循环设置。

## **播放后倒退视频**

在培训演示文稿中，将演示视频倒回起点可使演示者再次播放。调用 [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) 并传入 `true` 可以在播放结束后将视频返回到起始位置。

此示例打开演示文稿，查找第一张幻灯片上的第一个 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)，并启用倒退。它禁用循环以便播放可以结束，并将播放设置为点击开始。输入演示文稿必须至少包含一张幻灯片，并在第一张幻灯片上已有视频帧。

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

倒退将视频返回到起点但不会再次启动。而调用 [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) 并传入 `true` 则会自动循环播放。当您希望视频播放完毕并保持可重复播放时，请保持循环关闭。[setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) 独立控制自动或点击启动；本示例使用 [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/)，因此演示者自行决定何时开始播放。正如示例所示，先设置循环后再设置播放模式。倒退独立于 [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) 工作。

## **裁剪视频帧**

使用 [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) 和 [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) 可以在播放时跳过视频开头或结尾的部分。两个值的单位为毫秒。裁剪仅修改播放设置，而不更改嵌入的视频数据。

**设置裁剪参数**

此示例嵌入本地视频，并在播放时跳过前 2.5 秒和最后 1 秒。请使用时长超过 3.5 秒的视频，以保留可播放的片段。

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

**读取裁剪参数**

此示例以毫秒为单位打印第一张幻灯片上第一个视频帧的裁剪值。演示文稿必须至少包含一张幻灯片。如果该幻灯片没有视频帧，则不输出任何内容。前面的示例产生的值为 2500 和 1000。

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

## **管理视频字幕**

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的隐藏字幕。字幕以 WebVTT 格式存储，并可通过 [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) 方法获取。

### **向视频帧添加字幕**

此示例嵌入本地视频并添加一个标记为 English 的 WebVTT 字幕轨道。字幕时间戳应与视频匹配。保存的演示文稿同时包含视频及其字幕。

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

[CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) 类还提供了一个重载，允许您从流中添加字幕。

### **从视频帧提取字幕**

此示例将第一张幻灯片上视频帧的所有字幕轨道保存为单独的 WebVTT 文件。使用顺序编号以保持输出文件唯一。控制台报告提取的轨道数量。演示文稿必须至少包含一张幻灯片。

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

每个 [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) 对象公开字幕标识、标签、二进制数据以及以 UTF-8 字符串形式的字幕文本。

### **从视频帧移除字幕**

此示例移除第一张幻灯片上第一个形状位置的视频帧的所有字幕并保存结果。它假设幻灯片和形状均存在且该形状为视频帧。

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

如果只需移除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) 方法，而不是 [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear)。

### **搜索视频字幕**

[Captions::getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) 返回完整的 WebVTT 轨道，包括其标题、时间线和字幕文本。您可以在内存中搜索提示，以查找口语短语及其时间戳。例如，幻灯片 2 上的英文轨道可能包含以下文本。

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

示例打开 `captioned_media.pptx` 并使用 [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) 读取每张幻灯片上每个顶层视频帧的轨道。在纯文本提示中，时间线包含 `-->`，空行结束提示。当字幕中出现任意大小写的 “café” 时，示例会打印幻灯片编号、轨道标签、原始时间线以及完整字幕。

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

搜索 “café” 在示例轨道中产生一次匹配。搜索会排除轨道标题并在输出中保留时间设置。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **从幻灯片提取视频**

除了向幻灯片添加视频，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

此示例将每张幻灯片中嵌入的视频提取为单独的、带编号的二进制文件。链接视频会被跳过，因为它们没有嵌入数据。控制台打印每个视频的 MIME 类型以及总数。输出使用通用的 `.bin` 扩展名；如有需要，可将其更改为相应的媒体类型。

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

## **常见问题**

**可以更改视频帧的哪些播放参数？**

您可以通过 [playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode)（自动或点击）和 [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) 来控制。可通过 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) 对象的方法使用这些选项。

**添加视频会影响 PPTX 文件大小吗？**

会。嵌入本地视频时，二进制数据会被写入文档，导致演示文稿大小按视频文件大小比例增长。若链接到在线视频并添加缩略图，演示文稿只存储链接和预览图像，而不是视频数据，因而大小增幅通常更小。

**我能在不更改位置和尺寸的情况下替换现有视频帧中的视频吗？**

可以。您可以在保持形状几何不变的情况下交换帧内的 [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo)，这在更新现有布局中的媒体时很常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入视频拥有一个可以读取的 [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType)，例如在将其保存到磁盘时使用。