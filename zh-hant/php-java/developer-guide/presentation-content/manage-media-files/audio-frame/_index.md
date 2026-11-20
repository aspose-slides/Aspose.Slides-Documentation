---
title: 使用 PHP 管理簡報中的音訊框架
linktitle: 音訊框架
type: docs
weight: 10
url: /zh-hant/php-java/audio-frame/
keywords:
- 音訊
- 音訊框架
- 縮圖
- 新增音訊
- 音訊屬性
- 音訊選項
- 擷取音訊
- PHP
- Aspose.Slides
description: "在投影片中嵌入音訊、變更音訊圖示、設定播放方式、管理 WebVTT 字幕，並使用 Aspose.Slides for PHP via Java 擷取投影片轉場聲音。"
---
## **概觀**

音訊框架讓您在投影片上播放聲音。使用 Aspose.Slides for PHP via Java，您可以嵌入音訊剪輯、選擇代表它的圖像、調整播放設定，並附加字幕。您亦可取得指派給投影片轉場的聲音。

## **建立音訊框架**

使用 [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) 將本機音訊剪輯嵌入至第一張投影片。前兩個座標定位框架於投影片上，接下來的兩個數值設定其寬度與高度，單位皆為點。此範例呼叫 [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) 以自動開始剪輯，並呼叫 [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) 以選取大音量預設。

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
## **變更音訊框架縮圖**

預設情況下，音訊框架會顯示揚聲器圖示。若要顯示自訂縮圖，請使用 [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) 將圖像加入簡報，並用 [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/) 設定於框架的圖片上。此範例使用 JPEG 作為嵌入音訊剪輯的縮圖。

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
## **變更音訊播放選項**

PowerPoint 的 **Audio Options** 控制項決定剪輯何時開始、音量大小，以及在簡報播放期間的行為。

![音訊框架的 PowerPoint 音訊選項控制項](audio_frame_0.png)

| PowerPoint 控制項 | Aspose.Slides for PHP via Java 方法 |
| --- | --- |
| 開始 | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| 音量預設 | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| 跨投影片播放 | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| 循環直至停止 | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| 播放時隱藏 | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| 播放後倒回 | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| 淡入 | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| 淡出 | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| 修剪音訊開始時間 | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| 修剪音訊結束時間 | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| 音量滑桿 | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

此範例在第一張投影片上尋找第一個音訊框架，呼叫 [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) 以在點擊時開始播放，並選取低音量預設。剪輯會跨投影片持續播放，且未啟用循環。圖示在播放期間保持隱藏，且剪輯在播放後會倒回。

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
針對長度超過 3.5 秒的剪輯，此範例跳過前 1.5 秒與最後 2 秒。[setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) 接受要從剪輯尾端省略的時間長度。若要取得 PowerPoint 中顯示的結束時間，請將該偏移量從完整剪輯時長中減去。修剪後的剪輯以 200 毫秒淡入、以 500 毫秒淡出。所有這四個方法的參數單位皆為毫秒。

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
若要將播放音量設定為特定百分比，請使用 [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue)。此範例將第一張投影片的第一個音訊框架的音量設定為 85%。

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
## **管理音訊字幕**

每個音訊框架皆可透過 [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks) 取得其字幕軌道。使用此集合可將 WebVTT 字幕附加至剪輯、匯出現有軌道，或將其移除。

### **新增音訊字幕**

此範例將音訊剪輯嵌入第一張投影片，並使用 [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) 附加本機 WebVTT 軌道。第一個參數提供軌道標籤，第二個參數則指定包含時間字幕的檔案。

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
### **擷取音訊字幕**

此範例匯出附加於第一張投影片音訊框架的每個字幕軌道。它將 [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) 回傳的位元組寫入 WebVTT 檔案，並使用 [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) 回傳的識別碼作為檔名，使每個軌道都有獨立的輸出。

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
### **移除音訊字幕**

使用 [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) 刪除單一軌道。此範例使用 [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) 從第一張投影片的第一個音訊框架移除所有字幕，同時保留剪輯。

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
### **在音訊字幕中尋找行**

若要在第一張投影片的音訊字幕中尋找特定行，請在記憶體中搜尋 [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) 回傳的文字。於純文字 WebVTT 提示中，時間行包含 `-->`，字幕行緊接其後，空白行則結束該提示。此範例印出軌道標籤以及含有「café」的每一行字幕。

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
## **擷取音訊**

投影片轉場可以有自己的聲音。若要取得它，請在投影片轉場上呼叫 [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/)。此範例取得 [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) 回傳的位元組，並印出其位元組數量。如果第一張投影片沒有轉場聲音，則印出訊息。

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
## **常見問題**

**我可以在多張投影片間重複使用相同的音訊剪輯而不必重複複製嗎？**

可以。先將剪輯加入簡報的 [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) 中，然後在每張投影片呼叫 [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) 時傳入相同的音訊物件。

**我可以取代現有音訊框架中的聲音嗎？**

可以。若為連結聲音，請使用 [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) 指向取代的檔案。若為嵌入聲音，則可使用 [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) 從簡報的音訊集合中選取另一個剪輯。兩種方式皆保留現有的框架。

**修剪會改變簡報中儲存的音訊資料嗎？**

不會。[setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) 與 [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) 只設定播放範圍。您仍可透過 [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/) 取得完整的剪輯。