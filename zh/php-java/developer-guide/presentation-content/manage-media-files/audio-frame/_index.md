---
title: 音频帧
type: docs
weight: 10
url: /zh/php-java/audio-frame/
keywords: "添加音频, 音频帧, 音频属性, 提取音频, Java, Aspose.Slides for PHP via Java"
description: "向 PowerPoint 演示文稿添加音频"
---

## **创建音频帧**
Aspose.Slides for PHP via Java 允许您将音频文件添加到幻灯片中。音频文件以音频帧的形式嵌入到幻灯片中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载要嵌入幻灯片的音频文件流。
4. 将嵌入的音频帧（包含音频文件）添加到幻灯片中。
5. 设置 [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) 和 [IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame) 对象公开的 `Volume`。
6. 保存修改后的演示文稿。

以下 PHP 代码展示了如何将嵌入的音频帧添加到幻灯片中：

```php
// 实例化代表演示文稿文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 加载 wav 音频文件流
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
    if (!java_is_null($pres)) $pres->dispose();
}
```

## **更改音频帧缩略图**

当您将音频文件添加到演示文稿时，音频会作为具有标准默认图像的框架出现（请参阅以下部分中的图像）。您可以更改音频帧的预览图像（设置您喜欢的图像）。

以下 PHP 代码展示了如何更改音频帧的缩略图或预览图像：

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 在幻灯片上添加具有指定位置和大小的音频帧。
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

Aspose.Slides for PHP via Java 允许您更改控制音频播放或属性的选项。例如，您可以调整音频的音量、设置音频循环播放，甚至隐藏音频图标。

Microsoft PowerPoint 中的 **音频选项** 面板：

![example1_image](audio_frame_0.png)

与 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame) 属性相对应的 PowerPoint 音频选项：
- 音频选项 **开始** 下拉列表与 [AudioFrame.PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayMode--) 属性相匹配
- 音频选项 **音量** 与 [AudioFrame.Volume](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getVolume--) 属性相匹配
- 音频选项 **跨幻灯片播放** 与 [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayAcrossSlides--) 属性相匹配
- 音频选项 **循环播放直到停止** 与 [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayLoopMode--) 属性相匹配
- 音频选项 **在放映期间隐藏** 与 [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getHideAtShowing--) 属性相匹配
- 音频选项 **播放后倒带** 与 [AudioFrame.RewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getRewindAudio--) 属性相匹配

以下是如何更改音频播放选项：

1. [创建](#create-audio-frame) 或获取音频帧。
2. 为要调整的音频帧属性设置新值。
3. 保存修改后的 PowerPoint 文件。

以下 PHP 代码演示了如何调整音频选项的操作：

```php
  $pres = new Presentation("AudioFrameEmbed_out.pptx");
  try {
    # 获取音频帧形状
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 将播放模式设置为点击播放
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # 将音量设置为低
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # 设置音频跨幻灯片播放
    $audioFrame->setPlayAcrossSlides(true);
    # 禁用音频的循环
    $audioFrame->setPlayLoopMode(false);
    # 在幻灯片放映期间隐藏音频帧
    $audioFrame->setHideAtShowing(true);
    # 在播放后倒带音频
    $audioFrame->setRewindAudio(true);
    # 将 PowerPoint 文件保存到磁盘
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **提取音频**

Aspose.Slides for PHP via Java 允许您提取用于幻灯片放映过渡的声音。例如，您可以提取特定幻灯片使用的声音。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问该幻灯片的 [幻灯片放映过渡](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--)。
4. 提取字节数据中的声音。

以下代码展示了如何提取幻灯片中使用的音频：

```php
  # 实例化代表演示文稿文件的 Presentation 类
  $pres = new Presentation("AudioSlide.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 访问所需的幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 获取幻灯片的幻灯片放映过渡效果
    $transition = $slide->getSlideShowTransition();
    # 提取字节数组中的声音
    $audio = $transition->getSound()->getBinaryData();
    echo("长度: " . $Array->getLength($audio));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```