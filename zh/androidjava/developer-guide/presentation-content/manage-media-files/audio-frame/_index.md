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
description: "在 Aspose.Slides for Android 中创建和控制音频帧——嵌入、剪辑、循环以及在 PPT、PPTX 和 ODP 演示文稿中配置播放的 Java 示例。"
---
## **创建音频帧**
Aspose.Slides for Android via Java 允许您向幻灯片添加音频文件。音频文件以音频帧的形式嵌入到幻灯片中。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载要嵌入到幻灯片中的音频文件流。
4. 将嵌入的音频帧（包含音频文件）添加到幻灯片。
5. 设置由 [IAudioFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IAudioFrame) 对象公开的 [PlayMode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/AudioPlayModePreset) 和 `Volume`。
6. 保存修改后的演示文稿。

下面的 Java 代码展示了如何向幻灯片添加嵌入的音频帧：

```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 将 wav 声音文件加载到流中
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

当您向演示文稿添加音频文件时，音频会以带有标准默认图片的帧形式出现（请参见下节中的图片）。您可以更改音频帧的预览图像（设置您喜欢的图像）。

下面的 Java 代码展示了如何更改音频帧的缩略图或预览图像：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 向幻灯片添加音频帧，指定位置和大小。
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

Aspose.Slides for Android via Java 允许您更改控制音频播放或属性的选项。例如，您可以调节音频音量、设置音频循环播放，甚至隐藏音频图标。

Microsoft PowerPoint 中的 **音频选项** 面板：

![example1_image](audio_frame_0.png)

PowerPoint **音频选项** 对应 Aspose.Slides 的 [AudioFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/AudioFrame) 属性：

- **Start** 下拉列表对应 [AudioFrame.PlayMode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 属性
- **Volume** 对应 [AudioFrame.Volume](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/AudioFrame#getVolume--) 属性
- **Play Across Slides** 对应 [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 属性
- **Loop until Stopped** 对应 [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 属性
- **Hide During Show** 对应 [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 属性
- **Rewind after Playing** 对应 [AudioFrame.RewindAudio](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 属性

PowerPoint **编辑** 选项对应 Aspose.Slides 的 [AudioFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/audioframe/) 属性：

- **Fade In** 对应 [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 属性 
- **Fade Out** 对应 [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 属性 
- **Trim Audio Start Time** 对应 [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 属性 
- **Trim Audio End Time** 的值等于音频时长减去 [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 属性的值

PowerPoint **音量控制** 在音频控制面板上对应 [AudioFrame.VolumeValue](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) 属性。它允许您以百分比方式更改音频音量。

以下是更改音频播放选项的方法：

1. [创建](#create-audio-frame) 或获取音频帧。
2. 为需要调整的音频帧属性设置新值。
3. 保存修改后的 PowerPoint 文件。

以下 Java 代码演示了调整音频选项的操作：

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // 获取 AudioFrame 形状
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 将播放模式设置为单击播放
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

以下 Java 示例展示了如何添加带嵌入音频的新音频帧、剪辑它并设置淡入淡出持续时间：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // 将修剪开始偏移设置为 1.5 秒
    audioFrame.setTrimFromStart(1500f);
    // 将修剪结束偏移设置为 2 秒
    audioFrame.setTrimFromEnd(2000f);

    // 将淡入时长设置为 200 毫秒
    audioFrame.setFadeInDuration(200f);
    // 将淡出时长设置为 500 毫秒
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

以下代码示例展示了如何获取带嵌入音频的音频帧并将其音量设置为 85%：

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

## **管理音频字幕**

Aspose.Slides 允许您通过 [getCaptionTracks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) 方法向音频帧添加闭合字幕。该方法返回一个 [ICaptionsCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/)，您可以使用它添加 WebVTT 字幕轨道、遍历现有轨道并在需要时将其移除。

**添加音频字幕**

使用 [getCaptionTracks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) 方法将一个或多个字幕轨道附加到音频帧。在下例中，向幻灯片添加音频文件后，从 `.vtt` 文件加载新的字幕轨道。

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // 从 WebVTT 文件添加新字幕轨道。
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**提取音频字幕**

您可以遍历音频帧关联的字幕轨道并将其保存为 `.vtt` 文件。每个字幕轨道都提供其二进制数据和唯一标识符，可在导出字幕时使用。

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // 将字幕轨道保存为 .vtt 文件。
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

**移除音频字幕**

要从音频帧中移除字幕，可使用 [ICaptionsCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/) 提供的方法，如 [clear](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/#clear--)、[remove](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-)。下面的示例移除音频帧的所有字幕轨道。

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // 移除音频帧中的所有字幕轨道。
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **提取音频**

Aspose.Slides for Android via Java 允许您提取幻灯片放映转换中使用的声音。例如，您可以提取特定幻灯片使用的声音。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问该幻灯片的 [slideshow transitions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--)。
4. 以字节数据形式提取声音。

以下 Java 代码展示了如何提取幻灯片中使用的音频：

```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 访问所需的幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 获取幻灯片的放映过渡效果
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //提取声音为字节数组
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常见问题**

**我可以在多个幻灯片中重复使用相同的音频资源而不会导致文件大小增加吗？**

可以。将音频一次性添加到演示文稿的共享 [audio collection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getAudios--) 中，然后创建引用该已有资源的其他音频帧。这样可避免媒体数据重复，保持演示文稿大小受控。

**我可以在不重新创建形状的情况下替换现有音频帧中的声音吗？**

可以。对于链接的声音，更新 [link path](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) 以指向新文件。对于嵌入的声音，用演示文稿的另一个 [audio collection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getAudios--) 中的音频替换 [embedded audio](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) 对象。帧的格式和大多数播放设置保持不变。

**剪辑会更改保存在演示文稿中的底层音频数据吗？**

不会。剪辑仅调整播放边界。原始音频字节保持不变，可通过嵌入音频或演示文稿的音频集合访问。