---
title: 音频帧 - 使用 C# 在 PowerPoint 中插入和提取音频
linktitle: 音频帧
type: docs
weight: 10
url: /net/audio-frame/
keywords: "音频缩略图, 添加音频, 音频框, 音频属性, 提取音频, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中向 PowerPoint 演示文稿添加音频"
---

## **创建音频帧**
Aspose.Slides for .NET 允许您将音频文件添加到幻灯片中。音频文件以音频框的形式嵌入幻灯片中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载要嵌入幻灯片的音频文件流。
4. 将嵌入的音频框（包含音频文件）添加到幻灯片。
5. 设置 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) 和 [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) 对象公开的 `Volume`。
6. 保存修改后的演示文稿。

以下 C# 代码演示了如何将嵌入的音频框添加到幻灯片中：

```c#
// 实例化一个表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation())
{
    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];
    
    // 加载 wav 音频文件到流
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // 添加音频框
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // 设置音频的播放模式和音量
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // 将 PowerPoint 文件写入磁盘
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **更改音频框缩略图**

当您将音频文件添加到演示文稿时，音频会以带有标准默认图像的框出现（见下方部分中的图像）。您可以更改音频框的缩略图（设置您喜欢的图像）。

以下 C# 代码演示了如何更改音频框的缩略图或预览图像：

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // 添加带有指定位置和大小的音频框到幻灯片。
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // 将图像添加到演示文稿资源中。
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // 为音频框设置图像。
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	// 将修改后的演示文稿保存到磁盘
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **更改音频播放选项**

Aspose.Slides for .NET 允许您更改控制音频播放或属性的选项。例如，您可以调整音频的音量，将音频设置为循环播放，甚至隐藏音频图标。

在 Microsoft PowerPoint 中的 **音频选项** 窗格：

![example1_image](audio_frame_0.png)

PowerPoint 音频选项对应于 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) 属性：

- 音频选项 **开始** 下拉菜单与 [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) 属性相匹配 
- 音频选项 **音量** 与 [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) 属性相匹配 
- 音频选项 **跨幻灯片播放** 与 [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) 属性相匹配 
- 音频选项 **循环播放直到停止** 与 [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) 属性相匹配 
- 音频选项 **在演示时隐藏** 与 [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) 属性相匹配 
- 音频选项 **播放后倒带** 与 [AudioFrame.RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) 属性相匹配 

以下是更改音频播放选项的步骤：

1. [创建](#create-audio-frame)或获取音频框。
2. 设置要调整的音频框属性的新值。
3. 保存修改后的 PowerPoint 文件。

以下 C# 代码演示了调整音频选项的操作：

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // 获取音频框形状
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // 设置播放模式为单击播放
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // 设置音量为低
    audioFrame.Volume = AudioVolumeMode.Low;

    // 设置音频跨幻灯片播放
    audioFrame.PlayAcrossSlides = true;

    // 禁用音频循环
    audioFrame.PlayLoopMode = false;

    // 在幻灯片放映期间隐藏音频框
    audioFrame.HideAtShowing = true;

    // 播放后倒带音频
    audioFrame.RewindAudio = true;

    // 将 PowerPoint 文件保存到磁盘
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

## **提取音频**
Aspose.Slides for .NET 允许您提取用于幻灯片放映过渡的声音。例如，您可以提取特定幻灯片中使用的声音。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问幻灯片的幻灯片放映过渡。
4. 提取声音的字节数据。

以下 C# 代码演示了如何提取幻灯片中使用的音频：

```c#
string presName = "AudioSlide.pptx";

// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation(presName);

// 访问幻灯片
ISlide slide = pres.Slides[0];

// 获取幻灯片的幻灯片放映过渡效果
ISlideShowTransition transition = slide.SlideShowTransition;

// 提取音频的字节数组
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("长度: " + audio.Length);
```