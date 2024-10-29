---
title: 音频帧
type: docs
weight: 10
url: /zh/cpp/audio-frame/
keywords: "添加音频, 音频帧, 音频属性, 提取音频, C++, CPP, Aspose.Slides for C++"
description: "在 C++ 中向 PowerPoint 演示文稿添加音频"
---

## **创建音频帧**
Aspose.Slides for C++ 允许您将音频文件添加到幻灯片中。音频文件作为音频帧嵌入幻灯片中。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载您想要嵌入幻灯片中的音频文件流。
4. 将嵌入的音频帧（包含音频文件）添加到幻灯片。
5. 设置 [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) 和 [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame) 对象暴露的 `Volume`。
6. 保存修改后的演示文稿。

以下 C++ 代码演示如何将嵌入的音频帧添加到幻灯片中：

``` cpp
// 实例化表示演示文稿文件的 Presentation 类
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

当您向演示文稿添加音频文件时，音频会显示为带有标准默认图像的框架（请参见下面部分的图像）。您可以更改音频帧的缩略图（设置您喜欢的图像）。

以下 C++ 代码演示如何更改音频帧的缩略图或预览图像：

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// 在指定位置和大小的幻灯片上添加音频帧。
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// 将图像添加到演示文稿资源。
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// 设置音频帧的图像。
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
// 将修改后的演示文稿保存到磁盘
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **更改音频播放选项**

Aspose.Slides for C++ 允许您更改控制音频播放或属性的选项。例如，您可以调整音频音量、设置音频循环播放，甚至隐藏音频图标。

Microsoft PowerPoint 中的 **音频选项** 面板：

![example1_image](audio_frame_0.png)

与 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame) 方法对应的 PowerPoint 音频选项：
- 音频选项 **开始** 下拉列表与 [AudioFrame::get_PlayMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a5379c1a9c1166234d674b32413215a2b) 方法相匹配
- 音频选项 **音量** 与 [AudioFrame::get_Volume()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#af06a3176684b6a13326bc8526747d9f3) 方法相匹配 
- 音频选项 **跨幻灯片播放** 与 [AudioFrame::get_PlayAcrossSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a3c6ffc45b319ce127384fc37e188f7b0) 方法相匹配 
- 音频选项 **循环播放直到停止** 与 [AudioFrame::get_PlayLoopMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a99b5b9cc650e93eba813bd8b2371315b) 方法相匹配 
- 音频选项 **在放映期间隐藏** 与  [AudioFrame::get_HideAtShowing() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#abd008322e6a3d7d06bed527e329a9082) 方法相匹配 
- 音频选项 **播放后回放** 与 [AudioFrame::get_RewindAudio() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a4900e1df6477db16e8cdd859ad54e637) 方法相匹配 

以下是如何更改音频播放选项：

1. [创建](#creating-audio-frame) 或获取音频帧。
2. 为您希望调整的音频帧属性设置新值。
3. 保存修改后的 PowerPoint 文件。

以下 C++ 代码演示了一项操作，其中调整了音频的选项：

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// 获取形状
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// 将形状转换为 AudioFrame 形状
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// 将播放模式设置为单击播放
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// 将音量设置为低
audioFrame->set_Volume(AudioVolumeMode::Low);

// 设置音频跨幻灯片播放
audioFrame->set_PlayAcrossSlides(true);

// 禁用音频循环
audioFrame->set_PlayLoopMode(false);

// 在幻灯片放映期间隐藏音频帧
audioFrame->set_HideAtShowing(true);

// 播放后将音频回放到开始
audioFrame->set_RewindAudio(true);

// 将 PowerPoint 文件保存到磁盘
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

## **提取音频**
Aspose.Slides for .NET 允许您提取用于幻灯片放映过渡的声音。例如，您可以提取在特定幻灯片中使用的声音。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问幻灯片的幻灯片放映过渡。
4. 提取以字节数据表示的声音。

以下 C++ 代码演示如何提取幻灯片中使用的音频：

``` cpp
String presName = u"AudioSlide.pptx";

// 实例化表示演示文稿文件的 Presentation 类
auto pres = System::MakeObject<Presentation>(presName);

// 访问所需的幻灯片
auto slide = pres->get_Slides()->idx_get(0);

// 获取幻灯片的放映转换特效
auto transition = slide->get_SlideShowTransition();

// 提取以字节数组表示的声音
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"长度: ") + audio->get_Length());
```