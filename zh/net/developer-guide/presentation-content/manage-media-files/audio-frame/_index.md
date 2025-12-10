---
title: 在 .NET 中管理演示文稿的音频帧
linktitle: 音频帧
type: docs
weight: 10
url: /zh/net/audio-frame/
keywords:
- 音频
- 音频帧
- 缩略图
- 添加音频
- 音频属性
- 音频选项
- 提取音频
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中创建和控制音频帧——提供 C# 示例，实现嵌入、剪辑、循环以及在 PPT、PPTX 和 ODP 演示文稿中的播放配置。"
---

## **创建音频帧**

Aspose.Slides for .NET 允许您将音频文件添加到幻灯片中。音频文件被嵌入到幻灯片中作为音频帧。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载要嵌入到幻灯片中的音频文件流。
4. 将嵌入的音频帧（包含音频文件）添加到幻灯片。
5. 设置由 [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) 对象公开的 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) 和 `Volume`。
6. 保存修改后的演示文稿。

以下 C# 代码演示如何向幻灯片添加嵌入的音频帧：
```c#
 // 实例化表示演示文稿文件的 Presentation 类
 using (Presentation pres = new Presentation())
 {
     // 获取第一张幻灯片
     ISlide sld = pres.Slides[0];
     
     // 加载 wav 声音文件到流
     FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

     // 添加音频帧
     IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

     // 设置音频的播放模式和音量
     audioFrame.PlayMode = AudioPlayModePreset.Auto;
     audioFrame.Volume = AudioVolumeMode.Loud;

     // 将 PowerPoint 文件写入磁盘
     pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
 }
```


## **更改音频帧缩略图**

当您向演示文稿添加音频文件时，音频会显示为带有标准默认图像的帧（请参见下节中的图像）。您可以更改音频帧的缩略图（设置您喜欢的图像）。

以下 C# 代码演示如何更改音频帧的缩略图或预览图像：
```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // 在幻灯片上添加音频帧，指定位置和大小。
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // 向演示文稿资源添加图像。
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // 设置音频帧的图像。
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	// 将修改后的演示文稿保存到磁盘
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


## **更改音频播放选项**

Aspose.Slides for .NET 允许您更改控制音频播放或属性的选项。例如，您可以调节音频音量、设置音频循环播放，甚至隐藏音频图标。

Microsoft PowerPoint 中的 **Audio Options** 面板：

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** 对应 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) 属性：

- **Start** 下拉菜单对应 [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) 属性
- **Volume** 对应 [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) 属性
- **Play Across Slides** 对应 [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) 属性
- **Loop until Stopped** 对应 [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) 属性
- **Hide During Show** 对应 [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) 属性
- **Rewind after Playing** 对应 [AudioFrame.RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) 属性

PowerPoint **Editing** 选项对应 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) 属性：

- **Fade In** 对应 [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/) 属性
- **Fade Out** 对应 [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/) 属性
- **Trim Audio Start Time** 对应 [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/) 属性
- **Trim Audio End Time** 的值等于音频时长减去 [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/) 属性的值

PowerPoint 音频控制面板上的 **Volume controll** 对应 [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/) 属性。它允许您以百分比方式更改音频音量。

以下是更改音频播放选项的方法：

1. [创建](#create-audio-frame) 或获取音频帧。
2. 为要调整的音频帧属性设置新值。
3. 保存修改后的 PowerPoint 文件。

以下 C# 代码演示了调整音频选项的操作：
``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // 获取 AudioFrame 形状
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // 将播放模式设置为点击播放
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // 将音量设置为低
    audioFrame.Volume = AudioVolumeMode.Low;

    // 设置音频跨幻灯片播放
    audioFrame.PlayAcrossSlides = true;

    // 禁用音频循环
    audioFrame.PlayLoopMode = false;

    // 在幻灯片放映期间隐藏 AudioFrame
    audioFrame.HideAtShowing = true;

    // 播放后将音频倒回起点
    audioFrame.RewindAudio = true;

    // 将 PowerPoint 文件保存到磁盘
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```


以下 C# 示例展示了如何添加带嵌入音频的新音频帧、对其进行剪辑并设置淡入淡出持续时间：
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // 将剪辑起始偏移设置为 1.5 秒
    audioFrame.TrimFromStart = 1500f;
    // 将剪辑结束偏移设置为 2 秒
    audioFrame.TrimFromEnd = 2000f;

    // 将淡入持续时间设置为 200 毫秒
    audioFrame.FadeInDuration = 200f;
    // 将淡出持续时间设置为 500 毫秒
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```


下面的代码示例展示了如何检索带嵌入音频的音频帧并将其音量设置为 85%：
```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // 获取音频帧形状
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // 将音频音量设置为 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```


## **提取音频**

Aspose.Slides for .NET 允许您提取幻灯片放映过渡中使用的声音。例如，您可以提取特定幻灯片使用的声音。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问该幻灯片的放映过渡。
4. 以字节数据形式提取声音。

以下 C# 代码演示如何提取幻灯片中使用的音频：
```c#
string presName = "AudioSlide.pptx";

// Instantiates a Presentation class that represents a presentation file
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation(presName);

// Accesses the slide
// 访问幻灯片
ISlide slide = pres.Slides[0];

// Gets the slideshow transition effects for the slide
// 获取幻灯片的幻灯片放映转换效果
ISlideShowTransition transition = slide.SlideShowTransition;

//Extracts the sound in byte array
//提取声音的字节数组
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```


## **常见问题**

**我可以在多个幻灯片之间重复使用相同的音频资源而不会增大文件大小吗？**

是的。只需将音频一次添加到演示文稿的共享 [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) 中，然后创建引用该已有资源的额外音频帧。这样可避免媒体数据重复，保持演示文稿大小受控。

**我可以在不重新创建形状的情况下替换现有音频帧中的声音吗？**

是的。对于链接的声音，更新 [link path](https://reference.aspose.com/slides/net/aspose.slides/audioframe/linkpathlong/) 以指向新文件。对于嵌入的声音，将 [embedded audio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/embeddedaudio/) 对象替换为演示文稿的另一个 [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) 中的音频。帧的格式和大多数播放设置保持不变。

**剪辑会更改演示文稿中存储的底层音频数据吗？**

不会。剪辑仅调整播放边界。原始音频字节保持不变，可通过嵌入音频或演示文稿的音频集合访问。