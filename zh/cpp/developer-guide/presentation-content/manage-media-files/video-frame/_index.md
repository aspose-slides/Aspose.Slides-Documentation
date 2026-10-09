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
description: "学习使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速入门指南。"
---
## **简介**

视频可以帮助解释概念并吸引受众。Aspose.Slides for C++ 让您可以向幻灯片添加视频帧、调整播放设置、管理字幕并提取嵌入的视频数据。

PowerPoint 支持本地视频以及指向在线视频（例如 YouTube 视频）的链接。

为了表示视频数据和视频帧，Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件存放在本地，您可以创建视频帧将视频嵌入到演示文稿中。

此示例在现有演示文稿的第一张幻灯片上嵌入本地视频并保存结果。帧的坐标和尺寸使用点为单位。流会保持打开状态直至保存完成，因为 [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) 在演示文稿使用流时会保持其锁定。

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

您也可以将本地视频路径直接传递给 [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/)。此示例在新演示文稿的第一张幻灯片上嵌入视频。视频必须在演示文稿保存之前保持可访问。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **使用来自网络来源的视频创建视频帧**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支持在演示文稿中使用在线视频。您可以创建一个链接到在线视频（例如 YouTube 视频）的视频帧。

此示例向第一张幻灯片添加 YouTube 视频链接和缩略图。请替换视频标识符以使用其他视频。[set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) 方法请求自动播放。下载缩略图和播放视频需要网络访问。演示文稿查看器还必须支持在线视频播放。

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **在全屏模式下播放视频**

在培训演示中，您可以在全屏模式下播放软件演示，以便观众看到细节。[set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) 接受 `true` 来在播放期间启用此行为。

此示例打开演示文稿，查找第一张幻灯片上的第一个 [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)，并启用全屏播放。输入演示文稿必须至少包含一张幻灯片，其中第一张幻灯片已有视频帧。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

全屏播放控制视频的显示方式。除此之外，[set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) 控制是自动播放还是点击播放，[set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) 控制是否循环。要选择启动行为，请将播放模式设置为 [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/)。示例保留了现有的启动和循环设置。

## **在播放后倒回视频**

在培训演示中，将演示视频倒回到开头可以让演讲者再次播放。将 `true` 传递给 [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) 可在播放结束后将视频倒回到开头。

此示例打开演示文稿，查找第一张幻灯片上的第一个 [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)，并启用倒回。它禁用循环，以便播放可以结束，并将播放模式设置为点击启动。输入演示文稿必须至少包含一张幻灯片，其中第一张幻灯片已有视频帧。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

倒回会将视频返回到开头而不会重新启动。相反，启用 [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) 会自动重复播放。希望视频结束后保持就绪以便重新播放时，请保持循环关闭。[set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) 独立控制自动或点击启动；本例使用 [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/)，以让演讲者自行决定何时启动播放。示例中先设置循环，再设置播放模式。倒回与 [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) 的设置相互独立。

## **修剪视频帧**

使用 [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) 和 [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) 可以在播放期间跳过视频的开头或结尾部分。两个值的单位为毫秒。修剪会更改播放设置，而不修改嵌入的视频数据。

**设置修剪参数**

此示例嵌入本地视频并在播放时跳过前 2.5 秒和后 1 秒。请使用时长超过 3.5 秒的视频，以确保仍有可播放的片段。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**读取修剪参数**

此示例以毫秒为单位打印第一张幻灯片上第一个视频帧的修剪值。演示文稿必须至少包含一张幻灯片。如果该幻灯片没有视频帧，则不会打印任何内容。前面的示例会产生 2500 和 1000 两个值。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **管理视频字幕**

Aspose.Slides 允许您在 PowerPoint 演示文稿中管理视频帧的闭合字幕。字幕以 WebVTT 格式存储，并通过 [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) 方法公开。

**向视频帧添加字幕**

此示例嵌入本地视频并添加标记为 English 的 WebVTT 字幕轨道。字幕时间戳应与视频匹配。保存的演示文稿同时包含视频和其字幕。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) 接口还提供了一个重载，允许您从流中添加字幕。

**从视频帧提取字幕**

此示例将第一张幻灯片上所有视频帧的字幕轨道保存为单独的 WebVTT 文件。使用顺序编号以保持输出文件的唯一性。控制台会报告提取的轨道数量。演示文稿必须至少包含一张幻灯片。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

每个 [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) 对象都会公开字幕标识符、标签、二进制数据以及 UTF-8 字符串形式的字幕文本。

**从视频帧删除字幕**

此示例删除第一张幻灯片上第一个形状位置的视频帧的所有字幕并保存结果。它假设幻灯片和形状存在且该形状是视频帧。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

如果只需要删除单个字幕轨道，请使用 [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) 方法，而不是 [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/)。

## **从幻灯片中提取视频**

除了向幻灯片添加视频之外，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

此示例从每张幻灯片提取嵌入式视频并保存为单独的、编号的二进制文件。链接的视频会被跳过，因为它们没有嵌入数据。控制台会打印每个视频的 MIME 类型以及总计数。输出使用通用的 `.bin` 扩展名；如有需要，可根据报告的媒体类型进行更改。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **常见问题**

**可以更改视频帧的哪些播放参数？**

您可以控制[播放模式](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/)（自动或点击）和[循环](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/)。这些选项通过 [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) 对象的方法提供。

**添加视频会影响 PPTX 文件大小吗？**

会。当您嵌入本地视频时，二进制数据会包含在文档中，演示文稿的大小会随视频文件大小成比例增长。当您链接到在线视频并添加缩略图时，演示文稿只存储链接和预览图像，而不是视频数据，通常导致的大小增加较小。

**可以在不更改位置和大小的情况下替换已有视频帧中的视频吗？**

可以。您可以在保持形状几何不变的情况下替换帧内的[视频内容](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/)，这在更新已有布局中的媒体时非常常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入视频具有[内容类型](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/)，您可以读取并使用，例如在保存到磁盘时。