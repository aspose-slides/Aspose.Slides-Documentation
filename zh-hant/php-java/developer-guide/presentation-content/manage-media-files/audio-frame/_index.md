---
title: 使用 PHP 管理簡報中的音訊
linktitle: 音訊框
type: docs
weight: 10
url: /zh-hant/php-java/audio-frame/
keywords:
- 音訊
- 音訊框
- 縮圖
- 新增音訊
- 音訊屬性
- 音訊選項
- 擷取音訊
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP 中建立與控制音訊框─提供嵌入、剪輯、循環及設定 PPT、PPTX 與 ODP 簡報播放的程式碼範例。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用音訊框架。它展示了如何將嵌入式音訊加入投影片、客製化音訊框縮圖、設定播放選項（例如音量、循環、隱藏、剪輯與淡入淡出時間），以及擷取投影片放映過渡時使用的音訊。

## **建立音訊框架**

Aspose.Slides for PHP via Java 允許您將音訊檔案加入投影片。音訊檔案會以音訊框的形式嵌入投影片中。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 載入您想嵌入投影片的音訊檔案串流。
4. 將嵌入式音訊框（包含音訊檔案）加入投影片。
5. 設定由 [AudioFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/) 物件所提供的 [PlayMode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/AudioPlayModePreset) 和 `Volume`。
6. 儲存已修改的簡報。

以下 PHP 程式碼示範如何將嵌入式音訊框新增至投影片：

```php
// 建立一個代表簡報檔案的 Presentation 類別實例
$pres = new Presentation();
try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 載入 wav 音訊檔案為串流
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # 加入音訊框
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # 設定音訊的播放模式與音量
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # 將 PowerPoint 檔案寫入磁碟
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **變更音訊框縮圖**

當您將音訊檔案加入簡報時，音訊會以帶有標準預設圖像的框架顯示（請參閱下節的圖像）。您可以變更音訊框的預覽圖像（設定您偏好的圖像）。

以下 PHP 程式碼示範如何變更音訊框的縮圖或預覽圖像：

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# 新增音訊框至投影片，使用指定的位置與大小。
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# 新增影像至簡報資源。
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# 為音訊框設定影像。
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# 將修改後的簡報儲存至磁碟
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **變更音訊播放選項**

Aspose.Slides for PHP via Java 允許您變更控制音訊播放或屬性的選項。例如，您可以調整音量、設定音訊循環播放，甚至隱藏音訊圖示。

Microsoft PowerPoint 中的 **Audio Options** 面板：

![example1_image](audio_frame_0.png)

PowerPoint 的 **Audio Options** 對應到 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/) 屬性：

- **Start** 下拉式清單對應到 [AudioFrame::setPlayMode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/#setPlayMode) 方法
- **Volume** 對應到 [AudioFrame::setVolume](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/#setVolume) 方法
- **Play Across Slides** 對應到 [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/#setPlayAcrossSlides) 方法
- **Loop until Stopped** 對應到 [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/#setPlayLoopMode) 方法
- **Hide During Show** 對應到 [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/#setHideAtShowing) 方法
- **Rewind after Playing** 對應到 [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/#setRewindAudio) 方法

PowerPoint 的 **Editing** 選項對應到 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/) 屬性：

- **Fade In** 對應到 [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/#setFadeInDuration) 方法 
- **Fade Out** 對應到 [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/#setFadeOutDuration) 方法 
- **Trim Audio Start Time** 對應到 [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/#setTrimFromStart) 方法 
- **Trim Audio End Time** 值等於音訊總長度減去 [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/#setTrimFromEnd) 方法的值

PowerPoint 音訊控制面板上的 **Volume controll**（音量控制）對應到 [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/#setVolumeValue) 方法。它允許您以百分比調整音訊音量。

以下說明如何變更音訊播放選項：

1. [建立](#create-audio-frame) 或取得音訊框。
2. 為您想調整的音訊框屬性設定新值。
3. 儲存已修改的 PowerPoint 檔案。

以下 PHP 程式碼示範調整音訊選項的操作：

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # 取得 AudioFrame 形狀
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 設定播放模式為點擊播放
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # 設定音量為低
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # 設定音訊跨投影片播放
    $audioFrame->setPlayAcrossSlides(true);
    # 停用音訊循環
    $audioFrame->setPlayLoopMode(false);
    # 在投影片放映期間隱藏 AudioFrame
    $audioFrame->setHideAtShowing(true);
    # 於播放完畢後將音訊倒回開始
    $audioFrame->setRewindAudio(true);
    # 將 PowerPoint 檔案寫入磁碟
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

以下 PHP 範例展示如何新增帶嵌入音訊的音訊框、剪輯它，並設定淡入淡出持續時間：

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // 設定剪輯起始偏移為 1.5 秒
    $audioFrame->setTrimFromStart(1500);
    // 設定剪輯結束偏移為 2 秒
    $audioFrame->setTrimFromEnd(2000);

    // 設定淡入持續時間為 200 毫秒
    $audioFrame->setFadeInDuration(200);
    // 設定淡出持續時間為 500 毫秒
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

以下程式碼範例說明如何取得帶嵌入音訊的音訊框，並將其音量設為 85%：

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // 取得音訊框形狀
    $audioFrame = $slide->getShapes()->get_Item(0);

    // 設定音訊音量為 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **管理音訊字幕**

Aspose.Slides 允許您透過 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/#getCaptionTracks) 方法為音訊框新增閉合字幕。此方法會回傳一個 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/)，您可以在其中新增 WebVTT 字幕軌、遍歷現有軌道，並在需要時將其移除。

**新增音訊字幕**

使用 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/#getCaptionTracks) 方法將一個或多個字幕軌附加到音訊框。以下範例中，先將音訊檔案加入投影片，然後從 `.vtt` 檔案載入新的字幕軌。

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // 從 WebVTT 檔案新增一條字幕軌道。
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**擷取音訊字幕**

您可以遍歷與音訊框相關的字幕軌，並將它們儲存為 `.vtt` 檔案。每個字幕軌都會提供其二進位資料與唯一識別碼，可在匯出字幕時使用。

```php
$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
            $audioFrame = $shape;
            $trackCount = java_values($audioFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $audioFrame->getCaptionTracks()->get_Item($trackIndex);
                // 將每個字幕軌道儲存為 .vtt 檔案。
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**移除音訊字幕**

若要從音訊框移除字幕，請使用 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/) 提供的方法，例如 [clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/#clear)、[remove](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/captionscollection/#removeAt)。以下範例會移除音訊框中的所有字幕軌。

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // 類型: AudioFrame

    // 移除音訊框的所有字幕軌道。
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **擷取音訊**

Aspose.Slides for PHP via Java 允許您擷取投影片放映過渡時使用的聲音。例如，您可以擷取特定投影片中使用的聲音。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例，並載入包含音訊的簡報。
2. 透過索引取得相關投影片的參考。
3. 取得該投影片的 [slideshow transitions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/#getSlideShowTransition)。
4. 以位元組資料的形式擷取聲音。

以下程式碼示範如何擷取投影片中使用的音訊：

```php
# 建立一個代表簡報檔案的 Presentation 類別實例
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# 取得欲使用的投影片
	$slide = $pres->getSlides()->get_Item(0);
	# 取得該投影片的投影片放映過渡效果
	$transition = $slide->getSlideShowTransition();
	# 將聲音以位元組陣列形式擷取
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**我可以在多個投影片間重複使用相同的音訊資產而不會使檔案大小增加嗎？**

可以。先將音訊一次加入簡報的共同 [audio collection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getaudios/)，然後建立參照該資產的其他音訊框。這樣可避免多次複製媒體資料，並保持簡報大小在可控範圍內。

**我可以在不重新建立形狀的情況下替換現有音訊框的聲音嗎？**

可以。對於連結的聲音，只需更新 [link path](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/setlinkpathlong/) 使其指向新檔案。對於嵌入式聲音，將 [embedded audio](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audioframe/setembeddedaudio/) 物件換成簡報 [audio collection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getaudios/) 中的其他音訊。音訊框的格式與大多數播放設定將保持不變。

**剪輯會改變簡報中儲存的音訊資料嗎？**

不會。剪輯僅調整播放區間，原始音訊位元組保持不變，仍可透過嵌入音訊或簡報的 audio collection 取得。