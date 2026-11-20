---
title: Quản lý các khung video trong bản trình chiếu bằng C++
linktitle: Khung video
type: docs
weight: 10
url: /vi/cpp/video-frame/
keywords:
- thêm video
- tạo video
- nhúng video
- trích xuất video
- lấy video
- khung video
- nguồn web
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách thêm và trích xuất các khung video một cách lập trình trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho C++. Hướng dẫn nhanh."
---
## **Introduction**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides cho C++ cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát lại, quản lý phụ đề và trích xuất dữ liệu video được nhúng.

PowerPoint hỗ trợ video cục bộ và liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Để đại diện cho dữ liệu video và khung video, Aspose.Slides cung cấp giao diện [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) giao diện [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) và các kiểu liên quan khác.

## **Create an Embedded Video Frame**

Nếu tệp video bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình chiếu của mình.

Ví dụ này nhúng một video cục bộ vào slide đầu tiên của bản trình chiếu hiện có và lưu kết quả. Tọa độ và kích thước của khung được tính bằng điểm. Luồng dữ liệu vẫn mở cho đến khi quá trình lưu hoàn tất vì [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) giữ nó bị khóa trong khi bản trình chiếu sử dụng.

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

Bạn cũng có thể truyền trực tiếp đường dẫn video cục bộ tới [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/). Ví dụ này nhúng video vào slide đầu tiên của một bản trình chiếu mới. Video phải vẫn có thể truy cập được cho đến khi bản trình chiếu được lưu.

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

## **Create a Video Frame with Video from a Web Source**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong bản trình chiếu. Bạn có thể tạo một khung video liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Ví dụ này thêm liên kết và hình thu nhỏ video YouTube vào slide đầu tiên. Thay thế định danh video để dùng video khác. Phương thức [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) yêu cầu phát tự động. Tải hình thu nhỏ và phát video yêu cầu kết nối internet. Trình xem bản trình chiếu cũng phải hỗ trợ phát video trực tuyến.

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

## **Play a Video in Full-Screen Mode**

Trong một bản trình chiếu đào tạo, bạn có thể phát một buổi trình diễn phần mềm ở chế độ toàn màn hình để khán giả có thể nhìn thấy chi tiết. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) chấp nhận giá trị `true` để bật hành vi này trong quá trình phát.

Ví dụ này mở một bản trình chiếu, tìm khung video đầu tiên [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) trên slide đầu tiên và bật phát toàn màn hình. Bản trình chiếu đầu vào phải chứa ít nhất một slide có khung video tồn tại trên slide đầu tiên.

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

Phát toàn màn hình điều khiển cách video được hiển thị. Một cách độc lập, [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) kiểm soát việc video bắt đầu tự động hay khi nhấp, và [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) kiểm soát việc lặp lại. Để chọn hành vi khởi đầu, đặt chế độ phát thành [VideoPlayModePreset::Auto hoặc VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). Ví dụ này giữ nguyên các thiết lập khởi đầu và vòng lặp hiện có.

## **Rewind a Video After Playback**

Trong một bản trình chiếu đào tạo, đưa video trình diễn trở lại đầu giúp người thuyết trình sẵn sàng phát lại. Gọi [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) với giá trị `true` để đưa video về đầu sau khi phát xong.

Ví dụ này mở một bản trình chiếu, tìm khung video đầu tiên [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) trên slide đầu tiên và bật chức năng tua lại. Nó tắt vòng lặp để phát có thể kết thúc và đặt phát bắt đầu khi nhấp. Bản trình chiếu đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

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

Tua lại đưa video về đầu mà không khởi động lại. Ngược lại, bật [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) sẽ lặp lại phát một cách tự động. Giữ vòng lặp tắt khi bạn muốn video kết thúc và sẵn sàng để phát lại. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) độc lập kiểm soát việc khởi động tự động hay khi nhấp; ví dụ này sử dụng [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) để người thuyết trình kiểm soát thời điểm phát. Đặt chế độ phát sau khi đã thiết lập vòng lặp, như trong ví dụ. Tua lại hoạt động độc lập với [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **Trim a Video Frame**

Sử dụng [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) và [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) để bỏ qua phần đầu hoặc cuối của video trong quá trình phát. Cả hai giá trị đều tính bằng mili giây. Việc cắt giảm thay đổi cài đặt phát mà không sửa đổi dữ liệu video được nhúng.

**Set Trim Settings**

Ví dụ này nhúng một video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối trong quá trình phát. Sử dụng video dài hơn 3,5 giây để còn lại một đoạn có thể phát được.

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

**Read Trim Settings**

Ví dụ này in ra các giá trị cắt giảm của khung video đầu tiên trên slide đầu tiên tính bằng mili giây. Bản trình chiếu phải chứa ít nhất một slide. Nếu slide đó không có khung video, sẽ không in gì. Ví dụ trước đó tạo ra các giá trị 2500 và 1000.

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

## **Manage Video Captions**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bản trình chiếu PowerPoint. Các phụ đề được lưu ở định dạng WebVTT và được truy xuất thông qua phương thức [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/).

### **Add Captions to a Video Frame**

Ví dụ này nhúng một video cục bộ và thêm một track phụ đề WebVTT mang nhãn English. Các dấu thời gian phụ đề cần khớp với video. Bản trình chiếu được lưu bao gồm cả video và phụ đề của nó.

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

Giao diện [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng dữ liệu.

### **Extract Captions from a Video Frame**

Ví dụ này lưu tất cả các track phụ đề từ các khung video trên slide đầu tiên thành các tệp WebVTT riêng biệt. Các số thứ tự liên tiếp giúp tệp đầu ra không trùng nhau. Bảng điều khiển báo cáo số lượng track đã trích xuất. Bản trình chiếu phải chứa ít nhất một slide.

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

Mỗi đối tượng [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) hiển thị định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

### **Remove Captions from a Video Frame**

Ví dụ này xóa tất cả phụ đề khỏi khung video tại vị trí hình dạng đầu tiên trên slide đầu tiên và lưu kết quả. Nó giả định rằng slide và hình dạng tồn tại và hình dạng là một khung video.

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

Nếu bạn cần xóa chỉ một track phụ đề, hãy sử dụng các phương thức [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) hoặc [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) thay vì [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/).

### **Search Video Captions**

[ICaptions::get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) trả về toàn bộ track WebVTT, bao gồm tiêu đề, các dòng thời gian và văn bản phụ đề. Để tìm một cụm từ được nói và dấu thời gian của nó, đọc các cue trong bộ nhớ. Ví dụ, một track tiếng Anh trên slide 2 có thể chứa văn bản sau:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Ví dụ mở file `captioned_media.pptx` và đọc các track phụ đề của mỗi khung video cấp cao nhất trên mọi slide bằng [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/). Trong một cue dạng văn bản thuần, dòng thời gian chứa `-->` và một dòng trống kết thúc cue. Khi phụ đề chứa “café”, ví dụ in ra số slide, nhãn track, dòng thời gian gốc và toàn bộ phụ đề. Việc tìm kiếm không phân biệt chữ hoa/thường.

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

Tìm kiếm “café” tạo ra một kết quả khớp cho track mẫu. Việc tìm kiếm bỏ qua tiêu đề và giữ nguyên cài đặt thời gian trong kết quả.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extract Video from a Slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản trình chiếu.

Ví dụ này trích xuất video được nhúng từ mọi slide thành các tệp nhị phân riêng biệt, có số thứ tự. Các video được liên kết sẽ bị bỏ qua vì chúng không có dữ liệu nhúng. Bảng điều khiển in ra loại MIME của mỗi video và tổng số lượng. Đầu ra sử dụng phần mở rộng `.bin` chung; thay đổi nó để phù hợp với loại phương tiện đã báo cáo khi cần.

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

## **FAQ**

**Tham số phát video nào có thể thay đổi cho một khung video?**

Bạn có thể kiểm soát [chế độ phát](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (tự động hoặc khi nhấp) và [việc lặp lại](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). Các tùy chọn này có sẵn qua các phương thức của đối tượng [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).

**Việc thêm video có làm tăng kích thước tệp PPTX không?**

Có. Khi bạn nhúng một video cục bộ, dữ liệu nhị phân sẽ được đưa vào tài liệu, do đó kích thước bản trình chiếu tăng tỉ lệ với kích thước tệp. Khi bạn liên kết tới video trực tuyến và thêm hình thu nhỏ, bản trình chiếu chỉ lưu liên kết và ảnh preview thay vì dữ liệu video, vì vậy tăng kích thước thường nhỏ hơn.

**Tôi có thể thay thế video trong một khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể thay đổi [nội dung video](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) bên trong khung trong khi giữ nguyên hình học của hình dạng; đây là một trường hợp phổ biến để cập nhật media trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Một video được nhúng có [loại nội dung](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó vào đĩa.