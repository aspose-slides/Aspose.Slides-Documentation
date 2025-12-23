---
title: 使用 PHP 管理演示文稿中的音频
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
description: "在 Aspose.Slides for PHP 中创建和控制音频帧——提供嵌入、剪辑、循环以及在 PPT、PPTX 和 ODP 演示文稿中配置播放的代码示例。"
---

## **创建音频帧**

Aspose.Slides for PHP via Java 允许您向幻灯片添加音频文件。音频文件以音频帧的形式嵌入到幻灯片中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载要嵌入到幻灯片中的音频文件流。
4. 将嵌入的音频帧（包含音频文件）添加到幻灯片中。
5. 设置由 [IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame) 对象公开的 [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) 和 `Volume`。
6. 保存修改后的演示文稿。

下面的 PHP 代码演示了如何向幻灯片添加嵌入的音频帧：
```php
// 实例化表示演示文稿文件的 Presentation 类
$pres = new Presentation();
try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 将 wav 声音文件加载为流
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # 添加音频帧
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # 设置音频的播放模式和音量
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # 将 PowerPoint 文件写入磁盘
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


## **更改音频帧缩略图**

当您向演示文稿添加音频文件时，音频会显示为带有标准默认图片的帧（见下文图像）。您可以更改音频帧的预览图像（设置您喜欢的图片）。

下面的 PHP 代码演示了如何更改音频帧的缩略图或预览图像：
```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# 在幻灯片上添加音频帧，并指定位置和大小。
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# 向演示文稿资源添加图像。
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# 为音频帧设置图像。
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# 将修改后的演示文稿保存到磁盘
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```


## **更改音频播放选项**

Aspose.Slides for PHP via Java 允许您更改控制音频播放的选项或属性。例如，您可以调整音频音量、设置音频循环播放，甚至隐藏音频图标。

Microsoft PowerPoint 中的 **Audio Options** 面板：

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** 对应 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) 属性：

- **Start** 下拉列表对应 [AudioFrame.setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayMode) 方法
- **Volume** 对应 [AudioFrame.setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolume) 方法
- **Play Across Slides** 对应 [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayAcrossSlides) 方法
- **Loop until Stopped** 对应 [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayLoopMode) 方法
- **Hide During Show** 对应 [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setHideAtShowing) 方法
- **Rewind after Playing** 对应 [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setRewindAudio) 方法

PowerPoint **Editing** 选项对应 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) 属性：

- **Fade In** 对应 [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) 方法
- **Fade Out** 对应 [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) 方法
- **Trim Audio Start Time** 对应 [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) 方法
- **Trim Audio End Time** 的数值等于音频时长减去 [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) 方法的值

PowerPoint 音频控制面板上的 **Volume controll** 对应 [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) 方法。它允许您以百分比形式更改音频音量。

以下是更改音频播放选项的步骤：

1. [Сreate](#create-audio-frame) 或获取音频帧。
2. 为要调整的音频帧属性设置新值。
3. 保存修改后的 PowerPoint 文件。

下面的 PHP 代码演示了调整音频选项的操作：
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # 获取 AudioFrame 形状
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 将播放模式设置为单击播放
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # 将音量设置为低
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # 将音频设置为跨幻灯片播放
    $audioFrame->setPlayAcrossSlides(true);
    # 禁用音频循环
    $audioFrame->setPlayLoopMode(false);
    # 在幻灯片放映期间隐藏 AudioFrame
    $audioFrame->setHideAtShowing(true);
    # 播放后将音频倒回到开始
    $audioFrame->setRewindAudio(true);
    # 将 PowerPoint 文件保存到磁盘
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


下面的 PHP 示例展示了如何添加带嵌入音频的新音频帧、剪辑它并设置淡入淡出时长：
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // 将修剪起始偏移设置为 1.5 秒
    $audioFrame->setTrimFromStart(1500);
    // 将修剪结束偏移设置为 2 秒
    $audioFrame->setTrimFromEnd(2000);

    // 将淡入时长设置为 200 毫秒
    $audioFrame->setFadeInDuration(200);
    // 将淡出时长设置为 500 毫秒
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```


下面的代码示例演示了如何检索带嵌入音频的音频帧并将其音量设置为 85%：
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // 获取音频帧形状
    $audioFrame = $slide->getShapes()->get_Item(0);

    // 将音频音量设置为 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```


## **提取音频**

Aspose.Slides for PHP via Java 允许您提取幻灯片放映过渡中使用的声音。例如，您可以提取特定幻灯片使用的声音。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问该幻灯片的 [slideshow transitions](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--)。
4. 提取音频的字节数据。

下面的代码展示了如何提取幻灯片中使用的音频：
```php
# 实例化表示演示文稿文件的 Presentation 类
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# 访问所需的幻灯片
	$slide = $pres->getSlides()->get_Item(0);
	# 获取幻灯片的放映过渡效果
	$transition = $slide->getSlideShowTransition();
	# 提取声音的字节数组
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


## **常见问题**

**我可以在多个幻灯片之间重复使用同一个音频资源而不导致文件大小膨胀吗？**

可以。将音频一次添加到演示文稿的共享 [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/)，然后创建引用该现有资源的额外音频帧。这样可避免重复媒体数据，保持演示文稿体积受控。

**我可以在不重新创建形状的情况下替换现有音频帧中的声音吗？**

可以。对于链接的声音，更新 [link path](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) 指向新文件。对于嵌入的声音，将 [embedded audio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) 对象替换为演示文稿的另一个 [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) 中的对象。帧的格式和大多数播放设置保持不变。

**剪辑会更改演示文稿中存储的底层音频数据吗？**

不会。剪辑仅调整播放边界。原始音频字节保持不变，可通过嵌入音频或演示文稿的音频集合访问。