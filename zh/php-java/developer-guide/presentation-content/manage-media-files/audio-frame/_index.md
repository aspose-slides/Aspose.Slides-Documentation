---
title: 使用 PHP 在演示文稿中管理音频帧
linktitle: 音频帧
type: docs
weight: 10
url: /zh/php-java/audio-frame/
keywords:
- 音频
- 音频帧
- 缩略图
- 添加音频
- 音频属性
- 音频选项
- 提取音频
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在幻灯片中嵌入音频、更改音频图标、配置播放、管理 WebVTT 字幕，并提取幻灯片切换声音。"
---
## **概述**

音频帧可让您在幻灯片上播放声音。使用 Aspose.Slides for PHP via Java，您可以嵌入音频剪辑、选择代表该音频的图像、调整播放并附加字幕。您还可以检索分配给幻灯片切换的声音。

## **创建音频帧**

使用 [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) 将本地音频剪辑嵌入第一张幻灯片。前两个坐标决定帧在幻灯片上的位置，后两个数值设置其宽度和高度，单位均为点。本例调用 [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) 使剪辑自动开始播放，并调用 [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) 选择大声预设。

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setPlayMode(AudioPlayModePreset::Auto);
    $audioFrame->setVolume(AudioVolumeMode::Loud);

    $presentation->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **更改音频帧缩略图**

默认情况下，音频帧显示扬声器图标。若要显示自定义缩略图，可使用 [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) 将图像添加到演示文稿，并使用 [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/) 将其设置为帧的图片。本例使用 JPEG 作为嵌入音频剪辑的缩略图。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }

    $imageStream = new Java("java.io.FileInputStream", "eagle.jpeg");
    try {
        $thumbnail = $presentation->getImages()->addImage($imageStream);
    } finally {
        $imageStream->close();
    }
    $audioFrame->getPictureFormat()->getPicture()->setImage($thumbnail);

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **更改音频播放选项**

PowerPoint 的 **音频选项** 控件决定剪辑何时开始、音量大小以及在幻灯片放映期间的行为。

![PowerPoint 音频选项控件（用于音频帧）](audio_frame_0.png)

| PowerPoint 控件 | Aspose.Slides for PHP via Java 方法 |
| --- | --- |
| 开始 | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| 音量预设 | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| 跨幻灯片播放 | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| 循环直到停止 | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| 放映期间隐藏 | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| 播放后倒回 | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| 淡入 | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| 淡出 | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| 修剪音频开始时间 | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| 修剪音频结束时间 | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| 音量滑块 | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

示例在第一张幻灯片上找到第一个音频帧，调用 [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) 以点击后开始播放，并选择低音量预设。剪辑在跨幻灯片播放时循环已禁用。图标在放映期间保持隐藏，剪辑在播放后会倒回。

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setPlayAcrossSlides(true);
        $audioFrame->setPlayLoopMode(false);
        $audioFrame->setPlayMode(AudioPlayModePreset::OnClick);
        $audioFrame->setVolume(AudioVolumeMode::Low);
        $audioFrame->setHideAtShowing(true);
        $audioFrame->setRewindAudio(true);

        $presentation->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

对于时长超过 3.5 秒的剪辑，本示例跳过前 1.5 秒和后 2 秒。[setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) 接受要从剪辑末尾省略的时长。要获取 PowerPoint 中显示的结束时间，需要用完整剪辑时长减去该偏移量。修剪后的剪辑在 200 毫秒内淡入，在 500 毫秒内淡出。所有四个方法的参数均以毫秒为单位。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setTrimFromStart(1500);
    $audioFrame->setTrimFromEnd(2000);
    $audioFrame->setFadeInDuration(200);
    $audioFrame->setFadeOutDuration(500);

    $presentation->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

要将播放音量设置为特定百分比，请使用 [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue)。本例将第一张幻灯片上的第一个音频帧音量设置为 85%。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setVolumeValue(85);
        $presentation->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **管理音频字幕**

每个音频帧可通过 [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks) 访问其字幕轨道。使用该集合可为剪辑附加 WebVTT 字幕、导出现有轨道或将其删除。

### **添加音频字幕**

示例在第一张幻灯片上嵌入音频剪辑，并使用 [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) 附加本地 WebVTT 轨道。第一个参数提供轨道标签，第二个参数指定包含时间字幕的文件。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **提取音频字幕**

本示例导出附加在第一张幻灯片的音频帧上的每个字幕轨道。它将 [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) 返回的字节写入 WebVTT 文件，并使用 [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) 返回的标识符作为文件名，使每个轨道拥有单独的输出。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $fileName = $track->getCaptionId() . ".vtt";
            $audioCaptions = $track->getBinaryData();
            $output = new Java("java.io.FileOutputStream", $fileName);
            try {
                $output->write($audioCaptions);
            } finally {
                $output->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

### **移除音频字幕**

使用 [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) 删除单个轨道。示例使用 [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) 从第一张幻灯片的第一个音频帧中移除所有字幕，同时保留剪辑。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->getCaptionTracks()->clear();
        $presentation->save("audio_without_captions.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

### **在音频字幕中查找行**

要在第一张幻灯片的音频字幕中查找某行，可在内存中搜索 [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) 返回的文本。在纯文本 WebVTT 提示中，时间行包含 `-->`，字幕行随后出现，空行标志提示结束。本示例打印轨道标签以及包含 “café” 的每条字幕行。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $inCue = false;
            $captions = (string) $track->getDataAsString();
            foreach (preg_split('/\R/u', $captions) as $line) {
                if ($line === "") {
                    $inCue = false;
                } elseif (strpos($line, "-->") !== false) {
                    $inCue = true;
                } elseif ($inCue && preg_match('/café/iu', $line)) {
                    echo $track->getLabel() . ": " . $line . "\n";
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **提取音频**

幻灯片切换可以拥有其自己的声音。要检索它，请在幻灯片切换上调用 [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/)。示例访问 [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) 返回的字节并打印字节数。如果第一张幻灯片没有切换声音，则会打印一条提示信息。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AudioSlide.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $sound = $slide->getSlideShowTransition()->getSound();
    if (java_is_null($sound)) {
        echo "The first slide has no transition sound.\n";
    } else {
        $audioData = $sound->getBinaryData();
        $array = new JavaClass("java.lang.reflect.Array");
        echo "Transition sound: " . $array->getLength($audioData) . " bytes.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **常见问题**

**我可以在多个幻灯片之间复用相同的音频剪辑而不进行复制吗？**

可以。先将剪辑一次添加到演示文稿的 [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/)，然后在每张幻灯片上将同一音频对象传递给 [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/)。

**我可以替换已有音频帧中的声音吗？**

可以。对于链接的声音，使用 [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) 指向替换文件。对于嵌入的声音，使用 [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) 从演示文稿的音频集合中选择另一个剪辑。两种方式均保留原有帧。

**修剪会改变演示文稿中存储的音频数据吗？**

不会。[setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) 和 [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) 仅设置播放边界。仍然可以通过 [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/) 获取完整剪辑。