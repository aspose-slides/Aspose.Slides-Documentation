---
title: 音频框架
type: docs
weight: 10
url: /java/audio-frame/
keywords: "添加音频, 音频框架, 音频属性, 提取音频, Java, Aspose.Slides for Java"
description: "在Java中向PowerPoint演示文稿添加音频"
---

## **创建音频框架**
Aspose.Slides for Java允许您将音频文件添加到幻灯片中。音频文件作为音频框架嵌入幻灯片中。

1. 创建[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载您想要嵌入幻灯片的音频文件流。
4. 将嵌入的音频框架（包含音频文件）添加到幻灯片中。
5. 设置[PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset)和[IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame)对象暴露的`Volume`。
6. 保存修改后的演示文稿。

以下Java代码演示如何将嵌入的音频框架添加到幻灯片中：

```Java
// 实例化一个表示演示文稿文件的Presentation类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 将wav音频文件加载到流中
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // 添加音频框架
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // 设置音频的播放模式和音量
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // 将PowerPoint文件写入磁盘
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **更改音频框架缩略图**

当您将音频文件添加到演示文稿时，音频会作为带有标准默认图像的框架出现（请参见下面部分的图像）。您可以更改音频框架的预览图像（设置您喜欢的图像）。

以下Java代码演示如何更改音频框架的缩略图或预览图像：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 在幻灯片上添加具有指定位置和大小的音频框架。
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

    // 为音频框架设置图像。
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //将修改后的演示文稿保存到磁盘
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **更改音频播放选项**

Aspose.Slides for Java允许您更改控制音频播放或属性的选项。例如，您可以调整音频的音量，设置音频循环播放，甚至隐藏音频图标。

Microsoft PowerPoint中的**音频选项**面板：

![example1_image](audio_frame_0.png)

与Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) 属性对应的PowerPoint音频选项：
- 音频选项**开始**下拉列表匹配[AudioFrame.PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayMode--)属性
- 音频选项**音量**匹配[AudioFrame.Volume](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getVolume--)属性
- 音频选项**跨幻灯片播放**匹配[AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayAcrossSlides--)属性
- 音频选项**循环播放直到停止**匹配[AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayLoopMode--)属性
- 音频选项**在放映期间隐藏**匹配[AudioFrame.HideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getHideAtShowing--)属性
- 音频选项**播放后倒带**匹配[AudioFrame.RewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getRewindAudio--)属性

以下是更改音频播放选项的方法：

1. [创建](#create-audio-frame)或获取音频框架。
2. 设置您要调整的音频框架属性的新值。
3. 保存修改后的PowerPoint文件。

以下Java代码演示了调整音频选项的操作：

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // 获取音频框架形状
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 设置播放模式为点击时播放
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // 设置音量为低
    audioFrame.setVolume(AudioVolumeMode.Low);

    // 设置音频跨幻灯片播放
    audioFrame.setPlayAcrossSlides(true);

    // 禁用音频循环
    audioFrame.setPlayLoopMode(false);

    // 在幻灯片放映期间隐藏音频框架
    audioFrame.setHideAtShowing(true);

    // 播放后将音频倒带到开始
    audioFrame.setRewindAudio(true);

    // 将PowerPoint文件保存到磁盘
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **提取音频**

Aspose.Slides for Java允许您提取用于幻灯片放映过渡的声音。例如，您可以提取特定幻灯片中使用的声音。

1. 创建[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问幻灯片的[幻灯片过渡](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--)。
4. 提取字节数据中的声音。

以下Java代码演示如何提取幻灯片中使用的音频：

```java
// 实例化一个表示演示文稿文件的Presentation类
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 访问所需的幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 获取幻灯片的幻灯片过渡效果
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // 在字节数组中提取声音
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("长度: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```