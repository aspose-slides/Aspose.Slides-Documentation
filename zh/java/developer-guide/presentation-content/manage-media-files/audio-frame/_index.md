---
title: 使用 Java 管理演示文稿中的音频
linktitle: 音频帧
type: docs
weight: 10
url: /zh/java/audio-frame/
keywords:
- 音频
- 音频帧
- 缩略图
- 添加音频
- 音频属性
- 音频选项
- 提取音频
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中创建和控制音频帧——提供嵌入、剪辑、循环以及跨 PPT、PPTX 和 ODP 演示文稿的播放配置示例代码。"
---

## **创建音频帧**

Aspose.Slides for Java 允许您向幻灯片添加音频文件。这些音频文件以音频帧的形式嵌入幻灯片中。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载要嵌入幻灯片的音频文件流。
4. 将嵌入的音频帧（包含音频文件）添加到幻灯片。
5. 设置由 [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame) 对象公开的 [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) 和 `Volume`。
6. 保存修改后的演示文稿。

下面的 Java 代码展示了如何向幻灯片添加嵌入的音频帧：
```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 将 wav 音频文件加载为流
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // 添加音频帧
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


## **更改音频帧缩略图**

当您向演示文稿添加音频文件时，音频会以带有标准默认图像的帧形式出现（请参见下节中的图像）。您可以更改音频帧的预览图像（设置您喜欢的图像）。

下面的 Java 代码展示了如何更改音频帧的缩略图或预览图像：
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 向幻灯片添加一个指定位置和大小的音频帧。
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // 向演示文稿资源添加图像。
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 为音频帧设置图像。
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //保存修改后的演示文稿到磁盘
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **更改音频播放选项**

Aspose.Slides for Java 允许您更改控制音频播放或属性的选项。例如，您可以调节音频音量，将音频设置为循环播放，甚至隐藏音频图标。

Microsoft PowerPoint 中的 **Audio Options** 窗格：

![example1_image](audio_frame_0.png)

PowerPoint 中的 **Audio Options** 与 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) 属性对应：

- **Start** 下拉列表对应 [AudioFrame.setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayMode-int-) 方法
- **Volume** 对应 [AudioFrame.setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolume-int-) 方法
- **Play Across Slides** 对应 [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-) 方法
- **Loop until Stopped** 对应 [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-) 方法
- **Hide During Show** 对应 [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-) 方法
- **Rewind after Playing** 对应 [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-) 方法

PowerPoint 中的 **Editing** 选项与 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) 属性对应：

- **Fade In** 对应 [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeInDuration-float-) 方法
- **Fade Out** 对应 [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-) 方法
- **Trim Audio Start Time** 对应 [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromStart-float-) 方法
- **Trim Audio End Time** 值等于音频时长减去 [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-) 方法的值

PowerPoint 音频控制面板上的 **Volume controll** 对应 [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolumeValue-float-) 方法。它允许您以百分比方式更改音频音量。

以下是更改音频播放选项的方法：

1. [创建](#create-audio-frame) 或获取 Audio Frame。
2. 为需要调整的 Audio Frame 属性设置新值。
3. 保存修改后的 PowerPoint 文件。

下面的 Java 代码演示了调整音频选项的操作：
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // 获取 AudioFrame 形状
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 将播放模式设置为点击播放
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // 将音量设置为低
    audioFrame.setVolume(AudioVolumeMode.Low);

    // 将音频设置为跨幻灯片播放
    audioFrame.setPlayAcrossSlides(true);

    // 禁用音频循环
    audioFrame.setPlayLoopMode(false);

    // 在幻灯片放映期间隐藏 AudioFrame
    audioFrame.setHideAtShowing(true);

    // 播放后将音频倒回到开始
    audioFrame.setRewindAudio(true);

    // 将 PowerPoint 文件保存到磁盘
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


下面的 Java 示例展示了如何添加带嵌入音频的新音频帧、截取它并设置淡入淡出持续时间：
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // 将修剪起始偏移设置为 1.5 秒
    audioFrame.setTrimFromStart(1500f);
    // 将修剪结束偏移设置为 2 秒
    audioFrame.setTrimFromEnd(2000f);

    // 将淡入持续时间设置为 200 毫秒
    audioFrame.setFadeInDuration(200f);
    // 将淡出持续时间设置为 500 毫秒
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


以下代码示例展示了如何检索带嵌入音频的音频帧并将其音量设置为 85%：
```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // 获取音频帧形状
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // 将音频音量设置为85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```


## **提取音频**

Aspose.Slides for Java 允许您提取幻灯片放映过渡中使用的声音。例如，您可以提取特定幻灯片中使用的声音。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问该幻灯片的 [slideshow transitions](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--)。
4. 提取音频的字节数据。

下面的 Java 代码展示了如何提取幻灯片中使用的音频：
```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 访问所需的幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 获取幻灯片的放映过渡效果
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //提取音频为字节数组
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**我能在多个幻灯片中重复使用相同的音频资产而不增加文件大小吗？**

是的。将音频一次性添加到演示文稿的共享 [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) 中，并创建引用该现有资产的其他音频帧。这样可避免媒体数据重复，并保持演示文稿的大小受控。

**我能在不重新创建形状的情况下替换现有音频帧中的声音吗？**

是的。对于链接的声音，更新 [link path](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) 以指向新文件。对于嵌入的声音，将 [embedded audio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) 对象换成演示文稿的另一个 [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) 中的对象。帧的格式和大多数播放设置保持不变。

**裁剪会改变演示文稿中存储的底层音频数据吗？**

不会。裁剪仅调整播放边界。原始音频字节保持不变，可通过嵌入音频或演示文稿的音频集合访问。