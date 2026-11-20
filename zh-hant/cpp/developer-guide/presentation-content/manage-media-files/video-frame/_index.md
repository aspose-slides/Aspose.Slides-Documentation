---
title: 使用 C++ 在簡報中管理影片框架
linktitle: 影片框架
type: docs
weight: 10
url: /zh-hant/cpp/video-frame/
keywords:
- 添加影片
- 建立影片
- 嵌入影片
- 擷取影片
- 取得影片
- 影片框架
- 網路來源
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "學習使用 Aspose.Slides for C++ 以程式方式在 PowerPoint 與 OpenDocument 投影片中加入與擷取影片框架。快速操作指南。"
---
## **簡介**

影片可以協助說明概念並吸引觀眾。Aspose.Slides for C++ 讓您能在投影片中加入影片框架、調整播放設定、管理字幕，並擷取嵌入的影片資料。

PowerPoint 支援本機影片以及連結至線上影片，例如 YouTube 影片。

為了表示影片資料與影片框架，Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) 介面以及其他相關類型。

## **建立嵌入式影片框架**

如果您想加入投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。

此範例將本機影片嵌入現有簡報的第一張投影片，並儲存結果。框架的座標與尺寸以點 (points) 為單位。因為 [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) 在簡報使用期間保持串流鎖定，所以串流會保持開啟直到儲存完成。

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

您也可以直接將本機影片路徑傳遞給 [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/)。此範例將影片嵌入新簡報的第一張投影片。影片必須在簡報儲存前保持可存取。

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

## **從網路來源建立影片框架**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 在簡報中支援線上影片。您可以建立連結至線上影片的影片框架，例如 YouTube 影片。

此範例在第一張投影片加入 YouTube 影片連結與縮圖。請更換影片識別碼以使用其他影片。[set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) 方法會請求自動播放。下載縮圖與播放影片需要網路存取。簡報檢視器也必須支援線上影片播放。

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

## **以全螢幕模式播放影片**

在培訓簡報中，您可以以全螢幕模式播放軟體示範，讓觀眾看見細節。[set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) 接受 `true` 以在播放期間啟用此行為。

此範例開啟簡報，於第一張投影片找到第一個 [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)，並啟用全螢幕播放。輸入簡報必須至少在第一張投影片上有一個現有的影片框架。

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

全螢幕播放控制影片的顯示方式。另一方面，[set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) 控制影片是自動開始或點擊開始，而 [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) 控制是否重複播放。若要選擇開始行為，將播放模式設為 [VideoPlayModePreset::Auto 或 VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/)。此範例保留了既有的開始與循環設定。

## **播放完畢後倒帶影片**

在培訓簡報中，將示範影片倒回開頭可讓簡報者再度播放。呼叫 [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) 並傳入 `true`，即可在播放結束後將影片倒回開頭。

此範例開啟簡報，於第一張投影片找到第一個 [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)，並啟用倒帶。它會停用循環使播放能完成，並將播放模式設定為點擊開始。輸入簡報必須至少在第一張投影片上有一個現有的影片框架。

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

倒帶會將影片返回開頭而不會再次啟動。相較之下，啟用 [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) 會自動重複播放。若希望影片播放完畢後保持可再播放，請保持循環停用。[set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/)，讓簡報者自行決定何時開始播放。請如範例所示在設定循環之後再設定播放模式。倒帶與 [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) 無關。

## **裁剪影片框架**

使用 [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) 與 [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) 可在播放期間略過影片的開頭或結尾部分。兩個值皆以毫秒為單位。裁剪會變更播放設定，但不會修改嵌入的影片資料。

**設定裁剪參數**

此範例嵌入本機影片，並在播放時略過前 2.5 秒與最後 1 秒。請使用長於 3.5 秒的影片，以保留可播放的片段。

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

**讀取裁剪設定**

此範例以毫秒為單位印出第一張投影片上第一個影片框架的裁剪值。簡報必須至少包含一張投影片；若該投影片沒有影片框架，則不會印出任何內容。前述範例會產生 2500 與 1000 的值。

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

## **管理影片字幕**

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框架的隱藏字幕。字幕以 WebVTT 格式儲存，並可透過 [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) 方法取得。

### **為影片框架新增字幕**

此範例嵌入本機影片，並新增一條標記為 English 的 WebVTT 字幕軌。字幕時間戳記應與影片相符。儲存的簡報同時包含影片與其字幕。

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

[ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) 介面亦提供重載，可讓您從串流加入字幕。

### **從影片框架擷取字幕**

此範例將第一張投影片上所有影片框架的字幕軌儲存為獨立的 WebVTT 檔案。使用連續編號可區分輸出檔案。主控台會回報擷取的軌道數量。簡報必須至少包含一張投影片。

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

每個 [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) 物件會公開字幕的識別碼、標籤、二進位資料，以及以 UTF-8 字串表示的字幕文字。

### **從影片框架移除字幕**

此範例移除第一張投影片第一個圖形位置的影片框架中的所有字幕，並儲存結果。它假設投影片與圖形皆存在且該圖形為影片框架。

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

若只需移除單一字幕軌，請使用 [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) 方法，而非 [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/)。

### **搜尋影片字幕**

[ICaptions::get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) 會回傳完整的 WebVTT 軌道，包含標頭、時間線以及字幕文字。若要找出特定口語片段及其時間戳記，可在記憶體中讀取 cue。例如，投影片 2 上的英文軌道可能包含以下文字：

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

此範例開啟 `captioned_media.pptx`，並使用 [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) 讀取每張投影片上每個頂層影片框架的字幕軌。於純文字 cue 中，時間線包含 `-->`，空白行表示 cue 結束。當字幕包含 “café” 時，範例會印出投影片編號、軌道標籤、原始時間線與完整字幕。搜尋不區分大小寫。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"captioned_media.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        auto videoFrame = AsCast<IVideoFrame>(shape);
        if (!videoFrame)
            continue;

        for (auto&& track : IterateOver(videoFrame->get_CaptionTracks()))
        {
            auto reader = MakeObject<StringReader>(track->get_DataAsString());
            for (auto timing = reader->ReadLine(); !timing.IsNull(); timing = reader->ReadLine())
            {
                if (!timing.Contains(u"-->"))
                    continue;

                String caption;
                for (auto line = reader->ReadLine(); !String::IsNullOrEmpty(line); line = reader->ReadLine())
                {
                    if (!String::IsNullOrEmpty(caption))
                        caption += u"\n";
                    caption += line;
                }

                if (caption.IndexOf(u"caf\u00E9", StringComparison::OrdinalIgnoreCase) >= 0)
                {
                    Console::WriteLine(String::Format(u"Slide {0} | {1} | {2}", slide->get_SlideNumber(), track->get_Label(), timing));
                    Console::WriteLine(caption);
                }
            }
        }
    }
}
presentation->Dispose();
```

搜尋 “café” 會在範例軌道中產生一筆匹配。搜尋會略過標頭，並在輸出中保留時間設定。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **從投影片擷取影片**

除了將影片加入投影片外，Aspose.Slides 也允許您擷取簡報中嵌入的影片。

此範例將每張投影片中的嵌入影片擷取為獨立的編號二進位檔案。連結影片會被略過，因為它們沒有嵌入資料。主控台會列印每段影片的 MIME 類型與總數。輸出使用通用的 `.bin` 副檔名；如有需要可依報告的媒體類型更改副檔名。

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

## **常見問題**

**可以更改影片框架的哪些播放參數？**

您可以透過 [playback mode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/)（自動或點擊）以及 [looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) 來控制。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) 物件的方法取得。

**加入影片會影響 PPTX 檔案大小嗎？**

會。當您嵌入本機影片時，二進位資料會納入文件中，簡報大小會隨檔案大小成比例增加。若您連結至線上影片並加入縮圖，簡報只會儲存連結與預覽圖片，而非影片資料，故大小增加通常較小。

**我能在不變更位置與尺寸的情況下，取代現有影片框架中的影片嗎？**

可以。您可以在保持圖形幾何形狀不變的情況下，交換框架內的 [video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/)；這是更新既有版面中媒體的常見情境。

**能否判斷嵌入影片的內容類型（MIME）？**

可以。嵌入的影片具有可讀取的 [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/)，您可加以使用，例如保存至磁碟時。