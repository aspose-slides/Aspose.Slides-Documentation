---
title: 使用 C++ 管理演示文稿中的视频帧
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
description: "学习如何使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速实用指南。"
---
在演示文稿中恰当地放置视频可以使您的信息更具说服力，并提升观众的参与度。 

PowerPoint 允许您以两种方式向演示文稿中的幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自 YouTube 等网络来源）。 

为方便向演示文稿添加视频（视频对象），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 接口以及其他相关类型。 

## **创建嵌入式视频帧**

如果您要添加到幻灯片的视频文件是本地存储的，您可以创建视频帧以将视频嵌入演示文稿中。 

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [IVideo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideo/) 对象，并传入视频文件路径以将视频嵌入演示文稿中。  
1. 添加一个 [IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 对象以创建视频帧。  
1. 保存修改后的演示文稿。 

以下 C++ 代码演示如何将本地存储的视频添加到演示文稿中：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

或者，您可以直接将文件路径传递给 [AddVideoFrame()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/addvideoframe/) 方法来添加视频：

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **使用网络来源视频创建视频帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中使用 YouTube 视频。如果您要使用的视频可在网上获取（例如 YouTube），可以通过其网络链接将其添加到演示文稿中。 

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [IVideo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideo/) 对象，并传入视频链接。  
1. 为视频帧设置缩略图。  
1. 保存演示文稿。 

以下 C++ 代码演示如何从网络向 PowerPoint 幻灯片添加视频：

```c++
// 文档目录的路径。
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// 实例化一个表示演示文稿文件的 Presentation 对象
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

## **管理视频字幕**

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的隐藏字幕。字幕以 WebVTT 格式存储，可通过 [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/get_captiontracks/) 方法获取。 

**向视频帧添加字幕**

向视频帧添加字幕的方法如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
1. 向演示文稿添加视频。  
1. 向幻灯片添加一个 [IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 对象。  
1. 使用由 [get_CaptionTracks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/get_captiontracks/) 返回的 [ICaptionsCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icaptionscollection/) 来添加 WebVTT 字幕轨道。  
1. 保存修改后的演示文稿。  

以下代码演示如何向视频帧添加字幕：

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Adds a new captions track from a WebVTT file.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icaptionscollection/) 接口还提供了一个重载，允许您从流中添加字幕。  

**从视频帧中提取字幕**

从视频帧中提取字幕的步骤如下：

1. 加载包含该视频的演示文稿。  
1. 找到目标 [IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 对象。  
1. 遍历 [get_CaptionTracks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/get_captiontracks/) 返回的字幕轨道。  
1. 将每个字幕轨道保存为 `.vtt` 文件。  

以下代码演示如何从视频帧中提取字幕：

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
            // 保存字幕轨道到 WebVTT 文件。
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

每个 [ICaptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icaptions/) 对象都公开字幕标识符、标签、二进制数据以及以 UTF-8 字符串形式的字幕内容。  

**从视频帧中删除字幕**

删除视频帧字幕的步骤如下：

1. 加载包含该视频的演示文稿。  
1. 获取目标 [IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 对象。  
1. 从 [get_CaptionTracks](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/get_captiontracks/) 返回的集合中移除字幕轨道。  
1. 保存修改后的演示文稿。  

以下代码演示如何删除视频帧中的全部字幕：

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// 移除视频帧中的所有字幕。
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

如果只需要删除单个字幕轨道，请使用 [Remove](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icaptionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icaptionscollection/removeat/) 方法，而不是 [Clear](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icaptionscollection/clear/)。  

## **从幻灯片中提取视频**

除了向幻灯片添加视频外，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。  

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例以加载包含视频的演示文稿。  
2. 遍历所有 [ISlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/) 对象。  
3. 遍历所有 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/) 对象以找到 [VideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/videoframe/)。  
4. 将视频保存到磁盘。  

以下 C++ 代码演示如何提取演示文稿幻灯片中的视频：

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

## **常见问题**

**可以更改 VideoFrame 的哪些视频播放参数？**

您可以控制 [playback mode](https://reference.aspose.com/slides/zh/cpp/aspose.slides/videoframe/set_playmode/)（自动或单击）以及 [looping](https://reference.aspose.com/slides/zh/cpp/aspose.slides/videoframe/set_playloopmode/) 。这些选项可通过 [VideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/videoframe/) 对象的属性进行设置。  

**添加视频会影响 PPTX 文件大小吗？**

会。嵌入本地视频时，二进制数据会写入文档，导致演示文稿大小按视频文件大小比例增长。添加在线视频时，仅嵌入链接和缩略图，文件增量相对较小。  

**是否可以在不改变位置和大小的情况下替换现有 VideoFrame 中的视频？**

可以。您可以在保持形状几何不变的前提下，替换帧内的 [video content](https://reference.aspose.com/slides/zh/cpp/aspose.slides/videoframe/set_embeddedvideo/)，这在更新已有布局中的媒体时非常常见。  

**能否确定嵌入视频的内容类型（MIME）？**

可以。嵌入视频具有可读取的 [content type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/video/get_contenttype/)，例如在保存到磁盘时可使用该信息。