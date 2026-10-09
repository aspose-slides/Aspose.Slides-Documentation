---
title: 使用 C++ 管理簡報中的影片框架
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
description: "學習使用 Aspose.Slides for C++ 在 PowerPoint 與 OpenDocument 投影片中以程式方式添加與擷取影片框架。快速上手指南。"
---
## **簡介**

影片能協助說明概念並吸引觀眾。Aspose.Slides for C++ 讓您能將影片框架添加至投影片、調整播放設定、管理字幕，並擷取嵌入的影片資料。  
PowerPoint 支援本機影片以及連結至線上影片，例如 YouTube 影片。  
為了表示影片資料與影片框架，Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) 介面以及其他相關類型。

## **建立嵌入式影片框架**

如果您想要加入投影片的影片檔案儲存在本機，您可以建立影片框架以將影片嵌入簡報中。  
此範例在現有簡報的第一張投影片嵌入本機影片，並儲存結果。框架的座標與尺寸以點 (points) 為單位。因為 [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) 在簡報使用時保持串流鎖定，串流會持續開啟直到儲存完成為止。

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

您也可以直接將本機影片路徑傳遞給 [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/)。此範例在新簡報的第一張投影片嵌入影片。影片必須保持可存取，直到簡報儲存完成為止。

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

## **使用來自網路來源的影片建立影片框架**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 在簡報中支援線上影片。您可以建立一個連結至線上影片（例如 YouTube 影片）的影片框架。  
此範例在第一張投影片加入 YouTube 影片連結與縮圖。請更換影片識別碼以使用其他影片。[set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) 方法請求自動播放。下載縮圖與播放影片需要網際網路存取。簡報檢視器亦必須支援線上影片播放。

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

## **全螢幕播放影片**

在訓練簡報中，您可以在全螢幕模式下播放軟體示範，讓觀眾看到細節。[set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) 接受 `true` 以在播放期間啟用此行為。  
此範例開啟簡報，於第一張投影片尋找第一個 [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)，並啟用全螢幕播放。輸入的簡報必須至少在第一張投影片上有一個已存在的影片框架。

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

全螢幕播放會控制影片的顯示方式。除此之外，[set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) 決定影片是自動播放或點擊播放，[set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) 決定是否重複播放。若要選擇啟動行為，請將播放模式設為 [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/)。此範例保留現有的啟動與迴圈設定。

## **在播放後倒帶影片**

在訓練簡報中，將示範影片倒回開頭可讓講者再次播放。呼叫 [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) 並傳入 `true`，即可在播放結束後將影片返回起始位置。  
此範例開啟簡報，於第一張投影片找到第一個 [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)，並啟用倒帶。它會停用迴圈以允許播放完成，並將播放設為點擊啟動。輸入的簡報必須在第一張投影片上至少有一個已存在的影片框架。

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

倒帶會將影片返回開頭而不會重新開始。相反地，啟用 [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) 會自動重複播放。當您希望影片播放完畢並保持可再次播放的狀態時，請保持迴圈停用。[set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) 讓講者自行決定何時開始播放。如範例所示，請在設定迴圈後再設定播放模式。倒帶與 [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) 無關。

## **剪裁影片框架**

使用 [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) 與 [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) 可在播放時跳過影片開頭或結尾的部分。兩個數值皆以毫秒為單位。剪裁會變更播放設定，但不會修改嵌入的影片資料。

**設定剪裁參數**

此範例嵌入本機影片，於播放時跳過前 2.5 秒與最後 1 秒。請使用長度超過 3.5 秒的影片，以確保仍有可播放的片段。

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

**讀取剪裁參數**

此範例以毫秒為單位輸出第一張投影片上第一個影片框架的剪裁值。簡報必須至少包含一張投影片；若該投影片沒有影片框架，則不會輸出任何內容。前一個範例會產生 2500 與 1000 的數值。

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

Aspose.Slides 允許您在 PowerPoint 簡報中管理影片框架的隱藏字幕。字幕以 WebVTT 格式儲存，並可透過 [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) 方法取得。

**為影片框架新增字幕**

此範例嵌入本機影片，並新增一條標記為 English 的 WebVTT 字幕軌。字幕的時間戳記應與影片相符。儲存後的簡報同時包含影片與其字幕。

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

[ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) 介面也提供一個重載，允許您從串流加入字幕。

**從影片框架擷取字幕**

此範例將第一張投影片上所有影片框架的字幕軌保存為個別的 WebVTT 檔案。以連續編號確保輸出檔案互不相同。主控台會回報擷取的軌道數量。簡報必須至少包含一張投影片。

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

**從影片框架移除字幕**

此範例移除第一張投影片上第一個形狀位置的影片框架中的所有字幕，並儲存結果。它假設投影片與形狀皆已存在，且該形狀為影片框架。

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

如果您只需移除單一字幕軌，請使用 [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) 方法，而非 [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/)。

## **從投影片擷取影片**

除了向投影片加入影片之外，Aspose.Slides 也允許您擷取簡報中嵌入的影片。  
此範例將每張投影片中嵌入的影片擷取為獨立的、編號的二進位檔案。連結的影片會被略過，因為它們沒有嵌入資料。主控台會列印每支影片的 MIME 類型與總數量。輸出使用通用的 `.bin` 副檔名；如有需要，可依回報的媒體類型更改副檔名。

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

**可以變更影片框架的哪些播放參數？**  
您可以透過 [playback mode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/)（自動或點擊）與 [looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) 來控制。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) 物件的方法存取。

**加入影片會影響 PPTX 檔案大小嗎？**  
會。當您嵌入本機影片時，二進位資料會被寫入文件，簡報的大小會隨影片檔案大小成比例增長。當您連結至線上影片並加入縮圖時，簡報僅儲存連結與預覽影像，而非影片資料，因而大小的增加通常較小。

**我可以在不更改位置與大小的情況下，替換既有影片框架中的影片嗎？**  
可以。您可以在保持形狀幾何的同時，交換框架內的 [video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/)；這是更新既有版面中媒體的常見情境。

**可以判斷嵌入影片的內容類型 (MIME) 嗎？**  
會。嵌入的影片具有可透過 [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) 取得的 MIME 類型，您可以讀取並使用，例如在將其儲存至磁碟時。