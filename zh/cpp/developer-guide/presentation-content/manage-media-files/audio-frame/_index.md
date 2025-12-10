---
title: 使用 C++ 管理演示文稿中的音频
linktitle: 音频帧
type: docs
weight: 10
url: /zh/cpp/audio-frame/
keywords:
- 音频
- 音频帧
- 缩略图
- 添加音频
- 音频属性
- 音频选项
- 提取音频
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中创建和控制音频帧——代码示例涵盖嵌入、修剪、循环以及在 PPT、PPTX 和 ODP 演示文稿中的播放配置。"
---

## **创建音频帧**

Aspose.Slides for C++ 允许您将音频文件添加到幻灯片中。音频文件以音频帧的形式嵌入到幻灯片中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载您想要嵌入到幻灯片中的音频文件流。
4. 将嵌入的音频帧（包含音频文件）添加到幻灯片中。
5. 设置由 [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame) 对象公开的 [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) 和 `Volume`。
6. 保存修改后的演示文稿。

下面的 C++ 代码演示如何向幻灯片添加嵌入的音频帧：
``` cpp
// 实例化一个表示演示文稿文件的 Presentation 类
auto pres = System::MakeObject<Presentation>();

// 获取第一张幻灯片
auto sld = pres->get_Slides()->idx_get(0);

// 加载 wav 音频文件到流
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// 添加音频帧
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// 设置音频的播放模式和音量
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// 将 PowerPoint 文件写入磁盘
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```


## **更改音频帧缩略图**

当您向演示文稿添加音频文件时，音频会以带有标准默认图像的帧形式出现（请参见下节中的图像）。您可以更改音频帧的缩略图（设置您喜欢的图像）。

下面的 C++ 代码演示如何更改音频帧的缩略图或预览图像：
```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// 向幻灯片添加音频帧，并指定位置和大小。
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// 向演示文稿资源添加图像。
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// 为音频帧设置图像。
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
// 将修改后的演示文稿保存到磁盘
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **更改音频播放选项**

Aspose.Slides for C++ 允许您更改控制音频播放或属性的选项。例如，您可以调节音频音量，将音频设置为循环播放，甚至隐藏音频图标。

Microsoft PowerPoint 中的 **Audio Options** 面板：

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** 与 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/) 方法对应：

- **Start** 下拉列表对应 [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playmode/) 方法
- **Volume** 对应 [AudioFrame::set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volume/) 方法
- **Play Across Slides** 对应 [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playacrossslides/) 方法
- **Loop until Stopped** 对应 [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playloopmode/) 方法
- **Hide During Show** 对应 [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_hideatshowing/) 方法
- **Rewind after Playing** 对应 [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_rewindaudio/) 方法

PowerPoint **Editing** 选项对应 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/) 属性：

- **Fade In** 对应 [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeinduration/) 方法
- **Fade Out** 对应 [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeoutduration/) 方法
- **Trim Audio Start Time** 对应 [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromstart/) 方法
- **Trim Audio End Time** 的值等于音频时长减去 [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromend/) 方法的值

PowerPoint 音频控制面板上的 **Volume controll** 对应 [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volumevalue/) 方法。它允许您以百分比的形式更改音频音量。

以下是更改音频播放选项的方法：

1. [创建](#creating-audio-frame) 或获取音频帧。
2. 为您想要调整的音频帧属性设置新值。
3. 保存修改后的 PowerPoint 文件。

下面的 C++ 代码演示调整音频选项的操作：
``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// 获取一个形状
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// 将形状转换为 AudioFrame 形状
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// 将播放模式设置为单击播放
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// 将音量设置为低
audioFrame->set_Volume(AudioVolumeMode::Low);

// 将音频设置为跨幻灯片播放
audioFrame->set_PlayAcrossSlides(true);

// 禁用音频循环
audioFrame->set_PlayLoopMode(false);

// 在幻灯片放映期间隐藏 AudioFrame
audioFrame->set_HideAtShowing(true);

// 播放后将音频倒回到开始
audioFrame->set_RewindAudio(true);

// 将 PowerPoint 文件保存到磁盘
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```


下面的 C++ 示例展示如何添加带有嵌入音频的新音频帧、对其进行修剪并设置淡入淡出时长：
```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// 将修剪起始偏移设置为 1.5 秒
audioFrame->set_TrimFromStart(1500);
// 将修剪结束偏移设置为 2 秒
audioFrame->set_TrimFromEnd(2000);

// 将淡入时长设置为 200 毫秒
audioFrame->set_FadeInDuration(200);
// 将淡出时长设置为 500 毫秒
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```


以下代码示例展示如何检索带有嵌入音频的音频帧并将其音量设置为 85%：
```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// 获取音频帧形状
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// 将音频音量设置为 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```


## **提取音频**

Aspose.Slides 允许您提取幻灯片放映切换时使用的声音。例如，您可以提取特定幻灯片使用的声音。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例，并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问该幻灯片的幻灯片放映切换。
4. 以字节数据形式提取声音。

下面的 C++ 代码展示如何提取幻灯片中使用的音频：
``` cpp
String presName = u"AudioSlide.pptx";

// 实例化一个表示演示文稿文件的 Presentation 类
auto pres = System::MakeObject<Presentation>(presName);

// 访问所需的幻灯片
auto slide = pres->get_Slides()->idx_get(0);

// 获取该幻灯片的幻灯片放映过渡效果
auto transition = slide->get_SlideShowTransition();

// 提取声音的字节数组
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```


## **常见问题**

**我可以在多个幻灯片之间复用相同的音频资源而不增大文件大小吗？**

是的。只需将音频一次性添加到演示文稿的共享 [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) 中，并创建引用该已有资产的额外音频帧。这可以避免媒体数据的重复，保持演示文稿大小受控。

**我可以在不重新创建形状的情况下替换现有音频帧中的声音吗？**

是的。对于链接的声音，更新 [link path](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_linkpathlong/) 使其指向新文件。对于嵌入的声音，将 [embedded audio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_embeddedaudio/) 对象替换为演示文稿的另一个 [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) 中的音频。帧的格式和大多数播放设置保持不变。

**修剪会更改存储在演示文稿中的底层音频数据吗？**

不会。修剪仅调整播放边界。原始音频字节保持不变，可通过嵌入音频或演示文稿的音频集合访问。