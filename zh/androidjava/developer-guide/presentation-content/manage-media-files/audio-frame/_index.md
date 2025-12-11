---
title: 在 Android 上管理演示文稿中的音频
linktitle: 音频帧
type: docs
weight: 10
url: /zh/androidjava/audio-frame/
keywords:
- 音频
- 音频帧
- 缩略图
- 添加音频
- 音频属性
- 音频选项
- 提取音频
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中创建和控制音频帧——示例展示如何嵌入、剪辑、循环以及在 PPT、PPTX 和 ODP 演示文稿中配置播放。"
---

## **创建音频帧**
Aspose.Slides for Android via Java 允许您向幻灯片添加音频文件。音频文件以音频帧的形式嵌入幻灯片中。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载要嵌入到幻灯片中的音频文件流。
4. 将嵌入的音频帧（包含音频文件）添加到幻灯片中。
5. 设置由 [IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame) 对象公开的 [PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset) 和 `Volume`。
6. 保存修改后的演示文稿。

下面的 Java 代码示例演示如何向幻灯片添加嵌入的音频帧：
```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 将 wav 声音文件加载为流
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
当您将音频文件添加到演示文稿时，音频会以带有标准默认图像的帧形式出现（见下节图像）。您可以更改音频帧的预览图像（设置您喜欢的图像）。

下面的 Java 代码示例演示如何更改音频帧的缩略图或预览图像：
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 向幻灯片添加音频帧，并指定位置和大小。
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

    // 为音频帧设置图像。
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //将修改后的演示文稿保存到磁盘
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **更改音频播放选项**
Aspose.Slides for Android via Java 允许您更改控制音频播放或属性的选项。例如，您可以调节音频音量、设置音频循环播放，或甚至隐藏音频图标。

Microsoft PowerPoint 中的 **音频选项** 窗格：

![example1_image](audio_frame_0.png)

PowerPoint **音频选项** 对应 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame) 属性：

- **开始** 下拉列表对应 [AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 属性
- **音量** 对应 [AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--) 属性
- **跨幻灯片播放** 对应 [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 属性
- **循环播放直到停止** 对应 [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 属性
- **在放映期间隐藏** 对应 [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 属性
- **播放后倒回** 对应 [AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 属性

PowerPoint **编辑** 选项对应 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/) 属性：

- **淡入** 对应 [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 属性 
- **淡出** 对应 [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 属性 
- **剪辑音频开始时间** 对应 [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 属性 
- **剪辑音频结束时间** 的值等于音频时长减去 [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 属性的值

PowerPoint 音频控制面板上的 **音量控制** 对应 [AudioFrame.VolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) 属性。它允许您以百分比方式调节音频音量。

以下是更改音频播放选项的方法：

1. [创建](#create-audio-frame) 或获取音频帧。
2. 为要调整的音频帧属性设置新值。
3. 保存修改后的 PowerPoint 文件。

下面的 Java 代码演示了调整音频选项的操作：
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // 获取 AudioFrame 形状
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 将播放模式设置为单击播放
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // 将音量设置为低
    audioFrame.setVolume(AudioVolumeMode.Low);

    // 设置音频跨幻灯片播放
    audioFrame.setPlayAcrossSlides(true);

    // 禁用音频循环
    audioFrame.setPlayLoopMode(false);

    // 幻灯片放映期间隐藏 AudioFrame
    audioFrame.setHideAtShowing(true);

    // 播放后倒回音频到开始位置
    audioFrame.setRewindAudio(true);

    // 将 PowerPoint 文件保存到磁盘
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


下面的 Java 示例展示了如何添加带嵌入音频的新音频帧、剪辑它并设置淡入淡出时长：
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // 设置剪辑起始偏移为 1.5 秒
    audioFrame.setTrimFromStart(1500f);
    // 设置剪辑结束偏移为 2 秒
    audioFrame.setTrimFromEnd(2000f);

    // 设置淡入时长为 200 毫秒
    audioFrame.setFadeInDuration(200f);
    // 设置淡出时长为 500 毫秒
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

    // 将音频音量设置为 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```


## **提取音频**
Aspose.Slides for Android via Java 允许您提取幻灯片放映过渡中使用的声音。例如，您可以提取特定幻灯片使用的声音。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问该幻灯片的 [slideshow transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--)。
4. 提取音频的字节数据。

下面的 Java 代码示例演示如何提取幻灯片使用的音频：
```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 访问所需的幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 获取幻灯片的幻灯片放映过渡效果
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //提取声音的字节数组
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**我可以在多张幻灯片中复用相同的音频资源而不增加文件大小吗？**

可以。将音频一次添加到演示文稿的共享 [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) 中，然后创建引用该已有资源的额外音频帧。这避免了媒体数据的重复，保持演示文稿大小受控。

**我可以在不重新创建形状的情况下替换现有音频帧中的声音吗？**

可以。对于链接的声音，更新 [link path](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) 指向新文件。对于嵌入的声音，用演示文稿的 [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) 中的另一个音频替换 [embedded audio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) 对象。帧的格式和大多数播放设置保持不变。

**剪辑会改变演示文稿中存储的底层音频数据吗？**

不会。剪辑仅调整播放边界。原始音频字节保持不变，仍可通过嵌入音频或演示文稿的音频集合访问。