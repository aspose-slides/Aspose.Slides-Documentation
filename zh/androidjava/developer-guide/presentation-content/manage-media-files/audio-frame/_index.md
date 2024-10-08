---
title: 音频框架
type: docs
weight: 10
url: /androidjava/audio-frame/
keywords: "添加音频, 音频框架, 音频属性, 提取音频, Java, Aspose.Slides for Android via Java"
description: "在 Java 中向 PowerPoint 演示文稿添加音频"
---

## **创建音频框架**
Aspose.Slides for Android via Java 允许您将音频文件添加到幻灯片中。音频文件以音频框架的形式嵌入到幻灯片中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2.通过其索引获取幻灯片的引用。
3. 加载您想要嵌入幻灯片的音频文件流。
4. 将嵌入的音频框架（包含音频文件）添加到幻灯片。
5. 设置 [PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset) 和 [IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame) 对象所暴露的 `Volume`。
6. 保存修改后的演示文稿。

以下 Java 代码演示了如何向幻灯片添加嵌入的音频框架：

```Java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 加载 wav 音频文件到流
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // 添加音频框架
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // 设置音频的播放模式和音量
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // 将 PowerPoint 文件写入磁盘
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **更改音频框架缩略图**

当您向演示文稿添加音频文件时，音频显示为带有标准默认图像的框架（请参见下面的部分中的图像）。您可以更改音频框架的预览图像（设置您喜欢的图像）。

以下 Java 代码演示了如何更改音频框架的缩略图或预览图像：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 在指定位置和大小向幻灯片添加音频框架。
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // 将图像添加到演示文稿资源中。
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 设置音频框架的图像。
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // 将修改后的演示文稿保存到磁盘
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **更改音频播放选项**

Aspose.Slides for Android via Java 允许您更改控制音频播放或属性的选项。例如，您可以调整音频的音量，设置音频循环播放，甚至隐藏音频图标。

Microsoft PowerPoint 中的 **音频选项** 窗格：

![example1_image](audio_frame_0.png)

PowerPoint 音频选项与 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame) 属性对应：
- 音频选项 **开始** 下拉列表与 [AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 属性匹配
- 音频选项 **音量** 与 [AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--) 属性匹配
- 音频选项 **跨幻灯片播放** 与 [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 属性匹配
- 音频选项 **循环直到停止** 与 [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 属性匹配
- 音频选项 **放映期间隐藏** 与 [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 属性匹配
- 音频选项 **播放后倒带** 与 [AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 属性匹配

这就是您如何更改音频播放选项：

1. [创建](#create-audio-frame)或获取音频框架。
2. 为您想要调整的音频框架属性设置新值。
3. 保存修改后的 PowerPoint 文件。

以下 Java 代码演示了调整音频选项的操作：

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // 获取音频框架形状
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 设置播放模式为单击播放
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // 设置音量为低
    audioFrame.setVolume(AudioVolumeMode.Low);

    // 设置音频跨幻灯片播放
    audioFrame.setPlayAcrossSlides(true);

    // 禁用音频的循环播放
    audioFrame.setPlayLoopMode(false);

    // 在幻灯片放映期间隐藏音频框架
    audioFrame.setHideAtShowing(true);

    // 播放后将音频倒带到开始
    audioFrame.setRewindAudio(true);

    // 将 PowerPoint 文件保存到磁盘
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **提取音频**

Aspose.Slides for Android via Java 允许您提取用于幻灯片放映过渡的声音。例如，您可以提取特定幻灯片中使用的声音。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例并加载包含音频的演示文稿。
2. 通过其索引获取相关幻灯片的引用。
3. 访问幻灯片的 [幻灯片放映过渡](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--)。
4. 提取字节数据中的声音。

以下 Java 代码演示了如何提取幻灯片中使用的音频：

```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 访问所需的幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 获取幻灯片的幻灯片放映过渡效果
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // 提取字节数组中的声音
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("长度: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```