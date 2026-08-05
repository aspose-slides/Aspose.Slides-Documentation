---
title: 使用 C++ 在演示文稿中管理视频帧
linktitle: 视频帧
type: docs
weight: 10
url: /zh/cpp/video-frame/
keywords:
- 添加视频
- 创建视频
- 嵌入视频
- 提取视频
- 检索视频
- 视频帧
- 网络来源
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速实用指南。"
---
## **介绍**

在演示文稿中恰当地放置视频可以使您的信息更具说服力，并提升观众的参与度。

PowerPoint 提供两种方式将视频添加到幻灯片中：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自如 YouTube 的网络来源）。

为使您能够向演示文稿中添加视频（视频对象），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 [IVideo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideo/) 对象并传入视频文件路径，以将视频嵌入演示文稿。  
4. 添加一个 [IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 对象，为视频创建帧。  
5. 保存修改后的演示文稿。  

以下 C++ 代码演示如何将本地存储的视频添加到演示文稿中：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// 加载视频
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// 获取第一张幻灯片并添加视频帧
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// 将演示文稿保存到磁盘
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

或者，您也可以直接将文件路径传递给 [AddVideoFrame()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/addvideoframe/) 方法来添加视频：

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **创建来自网络来源的视频帧**

较新版本的 Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支持在演示文稿中使用在线视频。如果您要使用的视频在线可用（例如 YouTube），可以通过其网络链接将其添加到演示文稿中。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 [IVideo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideo/) 对象并传入视频链接。  
4. 为视频帧设置缩略图。  
5. 保存演示文稿。  

以下 C++ 代码演示如何将网络视频添加到 PowerPoint 幻灯片中：

```c++
// 文档目录的路径。
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// 创建表示演示文稿文件的 Presentation 对象
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 添加视频帧 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// 设置视频的播放模式和音量
vf->set_PlayMode(VideoPlayModePreset::Auto);

//将演示文稿保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **修剪视频帧**

Aspose.Slides 通过 [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/set_trimfromstart/) 和 [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/set_trimfromend/) 设置可以控制视频播放的起始和结束位置。两个值均以毫秒为单位，分别定义从视频开头和结尾跳过的时间长度。此设置仅影响演示文稿中的视频播放行为，不会剪切或修改嵌入视频的二进制数据。

**设置修剪参数**

创建视频帧并设置修剪参数的步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 将一个 [IVideo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideo/) 对象添加到演示文稿。  
3. 将一个 [IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 对象添加到幻灯片。  
4. 通过 [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/set_trimfromstart/) 和 [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/set_trimfromend/) 设置修剪起止值。  
5. 保存修改后的演示文稿。  

下面的代码示例在播放时跳过嵌入视频的前 2.5 秒和最后 1 秒：

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**读取修剪参数**

要检查已有的修剪设置，加载演示文稿，查找第一页中的 [IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 对象，并通过 [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/get_trimfromstart/) 与 [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/get_trimfromend/) 读取相应值。

下面的代码示例定位第一页的首个视频帧并以毫秒为单位报告其修剪设置：

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **管理视频字幕**

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的闭合字幕。字幕采用 WebVTT 格式存储，可通过 [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/get_captiontracks/) 方法获取。

**向视频帧添加字幕**

向视频帧添加字幕的步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 将视频添加到演示文稿。  
3. 将一个 [IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 对象添加到幻灯片。  
4. 使用由 [get_CaptionTracks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/get_captiontracks/) 返回的 [ICaptionsCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icaptionscollection/) 添加 WebVTT 字幕轨道。  
5. 保存修改后的演示文稿。  

以下代码演示如何向视频帧添加字幕：

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// 从 WebVTT 文件添加新的字幕轨道。
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icaptionscollection/) 接口还提供了一个重载，允许您从流中添加字幕。

**从视频帧提取字幕**

从视频帧提取字幕的步骤：

1. 加载包含视频的演示文稿。  
2. 找到目标 [IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 对象。  
3. 遍历由 [get_CaptionTracks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/get_captiontracks/) 返回的字幕轨道。  
4. 将每个字幕轨道保存为 `.vtt` 文件。  

以下代码演示如何从视频帧提取字幕：

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // 将字幕轨道保存为 WebVTT 文件。
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

每个 [ICaptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icaptions/) 对象都公开字幕标识符、标签、二进制数据以及 UTF-8 格式的字幕文本。

**从视频帧移除字幕**

从视频帧移除字幕的步骤：

1. 加载包含视频的演示文稿。  
2. 获取目标 [IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 对象。  
3. 从由 [get_CaptionTracks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/get_captiontracks/) 返回的集合中移除字幕轨道。  
4. 保存修改后的演示文稿。  

以下代码演示如何删除视频帧中的所有字幕：

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// 从视频帧中移除所有字幕。
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

如果只需删除单个字幕轨道，请使用 [Remove](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icaptionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icaptionscollection/removeat/) 方法，而不是 [Clear](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icaptionscollection/clear/)。

## **从幻灯片中提取视频**

除了向幻灯片添加视频，Aspose.Slides 还支持从演示文稿中提取嵌入的视频。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例以加载包含视频的演示文稿。  
2. 遍历所有 [ISlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/) 对象。  
3. 在每个幻灯片的所有 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/) 对象中查找 [VideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/videoframe/)。  
4. 将视频保存到磁盘。  

以下 C++ 代码演示如何从演示文稿幻灯片中提取视频：

```c++
// 文档目录的路径。
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **常见问题解答**

**可以更改 VideoFrame 的哪些视频播放参数？**

您可以通过 [VideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/videoframe/) 对象的属性控制 [播放模式](https://reference.aspose.com/slides/zh/cpp/aspose.slides/videoframe/set_playmode/)（自动或点击）以及 [循环](https://reference.aspose.com/slides/zh/cpp/aspose.slides/videoframe/set_playloopmode/)。  

**添加视频会影响 PPTX 文件大小吗？**

会。嵌入本地视频时，二进制数据会被写入文档，导致演示文稿大小随视频文件大小等比例增长。添加在线视频时，仅嵌入链接和缩略图，文件增幅相对较小。  

**能否在不改变位置和尺寸的情况下替换已有 VideoFrame 中的视频？**

可以。您可以在保持形状几何尺寸不变的前提下，使用 [set_EmbeddedVideo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/videoframe/set_embeddedvideo/) 替换帧内的视频内容，这在更新已有布局的媒体时非常常见。  

**是否可以获取嵌入视频的内容类型（MIME）？**

可以。嵌入视频具有可通过 [get_ContentType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/video/get_contenttype/) 读取的内容类型，您可在保存至磁盘等场景中使用。