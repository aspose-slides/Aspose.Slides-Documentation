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
description: "在幻灯片中嵌入音频，更改音频图标，配置播放，管理 WebVTT 字幕，并使用 Aspose.Slides for .NET 提取幻灯片切换声音。"
---
## **概览**

音频帧可让您在幻灯片上播放声音。使用 Aspose.Slides for .NET，您可以嵌入音频剪辑，选择代表它的图像，调整播放方式，并附加字幕。您还可以检索分配给幻灯片切换的声音。

## **创建音频帧**

使用 [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) 将本地音频剪辑嵌入第一张幻灯片。前两个坐标决定帧在幻灯片上的位置，接下来的两个值以点为单位设置宽度和高度。此示例将 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) 设置为自动播放剪辑，并将 [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) 设置为响亮预设。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **更改音频帧缩略图**

默认情况下，音频帧显示扬声器图标。若要显示自定义缩略图，请使用 [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) 将图像添加到演示文稿中，并将其分配给帧的 [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) 属性。示例使用 JPEG 作为嵌入音频剪辑的缩略图。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **更改音频播放选项**

PowerPoint 的 **音频选项** 控件决定剪辑何时开始、音量大小以及在幻灯片放映期间的行为。

![PowerPoint 音频帧的音频选项控件](audio_frame_0.png)

| PowerPoint 控件 | Aspose.Slides 属性 |
| --- | --- |
| 开始 | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| 音量预设 | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| 跨幻灯片播放 | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| 循环直到停止 | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| 演示期间隐藏 | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| 播放后倒回 | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| 淡入 | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| 淡出 | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| 修剪音频开始时间 | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| 修剪音频结束时间 | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| 音量滑块 | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

示例在第一张幻灯片上找到第一个音频帧，将 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) 设置为单击时播放，并选择低音量预设。剪辑在跨幻灯片时继续播放，且循环已禁用。图标在放映期间保持隐藏，播放结束后剪辑会倒回。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

对于时长超过 3.5 秒的剪辑，示例跳过前 1.5 秒和后 2 秒。 [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) 用于测量要从剪辑末尾省略的时长。要获取 PowerPoint 中显示的结束时间，只需从完整剪辑时长中减去该偏移量。剪辑在 200 毫秒内淡入，500 毫秒内淡出。所有四个属性的取值均为毫秒。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

要将播放音量设置为特定百分比，请使用 [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/)。此示例将第一张幻灯片上的第一个音频帧音量设为 85%。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **管理音频字幕**

每个音频帧都有一个 [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/) 集合。使用它可以为剪辑附加 WebVTT 字幕、导出现有轨道或删除它们。

### **添加音频字幕**

示例在第一张幻灯片上嵌入音频剪辑，并使用 [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) 将本地 WebVTT 轨道附加到剪辑。第一个参数提供轨道标签，第二个参数指定包含时间字幕的文件。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **提取音频字幕**

此示例导出附加到第一张幻灯片上音频帧的每个字幕轨道。它将轨道的 [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) 写入 WebVTT 文件，并使用其 [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) 作为文件名，以便每个轨道产生独立的输出。

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **删除音频字幕**

使用 [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) 删除单个轨道。示例使用 [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) 删除第一张幻灯片上第一个音频帧的所有字幕，同时保留音频剪辑本身。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **在音频字幕中查找行**

要在第一张幻灯片的音频字幕中查找某行，请将每个轨道的 [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) 读取到内存中。在纯文本 WebVTT 提示中，时间行包含 `-->`，字幕行紧随其后，空行标记提示结束。示例打印轨道标签以及包含 “café” 的每行字幕。

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **提取音频**

幻灯片切换可以拥有自己的声音。要检索它，请读取切换的 [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) 属性。示例访问声音的 [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) 并打印其字节大小。如果第一张幻灯片没有切换声音，则会打印一条提示信息。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **常见问题**

**我可以在多张幻灯片中重复使用相同的音频剪辑而无需复制吗？**

可以。将剪辑一次添加到演示文稿的 [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) 中，并在每张幻灯片上将相同的音频对象传递给 [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/)。

**我可以替换现有音频帧中的声音吗？**

可以。对于链接的声音，更新 [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) 以指向替换文件。对于嵌入的声音，将演示文稿的音频集合中的另一剪辑分配给 [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/)。两种方法都保留现有帧。

**修剪会更改存储在演示文稿中的音频数据吗？**

不会。[TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) 和 [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) 仅设置播放边界。您仍然可以从 [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/) 中检索完整剪辑。