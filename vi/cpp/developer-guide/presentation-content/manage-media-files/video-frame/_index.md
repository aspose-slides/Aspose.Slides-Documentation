---
title: Quản lý Khung Video trong Bản Trình Bày bằng C++
linktitle: Khung Video
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
- bản trình bày
- C++
- Aspose.Slides
description: "Tìm hiểu cách thêm và trích xuất khung video một cách lập trình trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho C++. Hướng dẫn nhanh."
---
## **Giới thiệu**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides for C++ cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát, quản lý phụ đề và trích xuất dữ liệu video được nhúng.

PowerPoint hỗ trợ video cục bộ và liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Để biểu diễn dữ liệu video và khung video, Aspose.Slides cung cấp giao diện [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) , giao diện [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) và các kiểu liên quan khác.

## **Tạo Khung Video Được Nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình bày của mình.

Ví dụ này nhúng video cục bộ vào slide đầu tiên của một bản trình bày hiện có và lưu kết quả. Tọa độ và kích thước khung được tính bằng điểm. Luồng vẫn mở cho đến khi lưu hoàn tất vì [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) giữ nó khóa trong khi bản trình bày sử dụng nó.

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

Bạn cũng có thể truyền trực tiếp đường dẫn video cục bộ vào [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/). Ví dụ này nhúng video vào slide đầu tiên của một bản trình bày mới. Video phải vẫn có thể truy cập được cho đến khi bản trình bày được lưu.

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

## **Tạo Khung Video Với Video Từ Nguồn Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong bản trình bày. Bạn có thể tạo một khung video liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Ví dụ này thêm liên kết video YouTube và ảnh thu nhỏ vào slide đầu tiên. Thay thế định danh video để sử dụng video khác. Phương thức [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) yêu cầu phát tự động. Tải ảnh thu nhỏ và phát video yêu cầu có kết nối internet. Trình xem bản trình bày cũng phải hỗ trợ phát video trực tuyến.

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

## **Phát Video Trong Chế Độ Toàn Màn Hình**

Trong một bản trình bày đào tạo, bạn có thể phát bản demo phần mềm trong chế độ toàn màn hình để khán giả có thể xem chi tiết. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) chấp nhận `true` để bật hành vi này khi phát.

Ví dụ này mở một bản trình bày, tìm khung [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) đầu tiên trên slide đầu tiên, và bật phát toàn màn hình. Bản trình bày đầu vào phải có ít nhất một slide với một khung video hiện có trên slide đầu tiên.

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

Phát toàn màn hình kiểm soát cách video được hiển thị. Độc lập với đó, [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) kiểm soát việc video bắt đầu tự động hay khi nhấp, và [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) kiểm soát việc lặp lại. Để chọn hành vi bắt đầu, đặt chế độ phát thành [VideoPlayModePreset::Auto hoặc VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). Ví dụ này giữ nguyên các cài đặt bắt đầu và lặp lại hiện có.

## **Quay Lại Video Sau Khi Phát**

Trong một bản trình bày đào tạo, việc đưa video demo trở về đầu giúp người thuyết trình có thể phát lại. Gọi [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) với `true` để đưa video trở về đầu sau khi phát xong.

Ví dụ này mở một bản trình bày, tìm khung [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) đầu tiên trên slide đầu tiên, và bật tính năng quay lại. Nó tắt lặp lại để phát có thể kết thúc và đặt phát bắt đầu khi nhấp. Bản trình bày đầu vào phải có ít nhất một slide với một khung video hiện có trên slide đầu tiên.

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

Quay lại đưa video trở về đầu mà không phát lại. Ngược lại, bật [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) sẽ tự động lặp lại phát. Giữ lặp lại tắt khi bạn muốn video kết thúc và sẵn sàng phát lại. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) độc lập kiểm soát việc khởi động tự động hay khi nhấp; ví dụ này sử dụng [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) để người thuyết trình kiểm soát thời điểm bắt đầu phát. Đặt chế độ phát sau cài đặt vòng lặp, như trong ví dụ. Quay lại hoạt động độc lập với [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **Cắt Bớt Khung Video**

Sử dụng [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) và [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) để bỏ qua phần đầu hoặc cuối của video khi phát. Cả hai giá trị đều tính bằng mili giây. Cắt bớt thay đổi cài đặt phát mà không thay đổi dữ liệu video được nhúng.

**Đặt Cài Đặt Cắt Bớt**

Ví dụ này nhúng video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối khi phát. Sử dụng video dài hơn 3,5 giây để vẫn còn đoạn có thể phát được.

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

**Đọc Cài Đặt Cắt Bớt**

Ví dụ này in ra các giá trị cắt bớt của khung video đầu tiên trên slide đầu tiên, tính bằng mili giây. Bản trình bày phải có ít nhất một slide. Nếu slide đó không có khung video, sẽ không in gì. Ví dụ trước đưa ra giá trị 2500 và 1000.

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

## **Quản Lý Phụ Đề Video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho khung video trong bản trình bày PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy cập qua phương thức [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Thêm Phụ Đề Vào Khung Video**

Ví dụ này nhúng video cục bộ và thêm một track phụ đề WebVTT có nhãn English. Thời gian phụ đề phải khớp với video. Bản trình bày đã lưu sẽ bao gồm cả video và phụ đề của nó.

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

Giao diện [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng.

**Trích Xuất Phụ Đề Từ Khung Video**

Ví dụ này lưu tất cả các track phụ đề từ các khung video trên slide đầu tiên thành các tệp WebVTT riêng biệt. Các số thứ tự liên tiếp giữ cho các tệp đầu ra không trùng nhau. Console báo cáo số lượng track đã trích xuất. Bản trình bày phải có ít nhất một slide.

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

Mỗi đối tượng [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

**Xóa Phụ Đề Khỏi Khung Video**

Ví dụ này xóa tất cả phụ đề khỏi khung video tại vị trí hình dạng đầu tiên trên slide đầu tiên và lưu kết quả. Giả sử slide và hình dạng tồn tại và hình dạng là một khung video.

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

Nếu bạn chỉ cần xóa một track phụ đề, hãy sử dụng các phương thức [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) hoặc [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) thay vì [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/).

## **Trích Xuất Video Từ Slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản trình bày.

Ví dụ này trích xuất các video được nhúng từ mọi slide thành các tệp nhị phân có số thứ tự riêng biệt. Các video được liên kết sẽ bị bỏ qua vì chúng không có dữ liệu nhúng. Console in ra loại MIME của mỗi video và tổng số lượng. Đầu ra sử dụng phần mở rộng chung `.bin`; bạn có thể đổi thành phần mở rộng phù hợp với loại media đã báo cáo khi cần.

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

## **Câu Hỏi Thường Gặp**

**Các tham số phát video nào có thể thay đổi cho một khung video?**

Bạn có thể điều khiển [chế độ phát](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (tự động hoặc khi nhấp) và [lặp lại](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). Các tùy chọn này khả dụng qua các phương thức của đối tượng [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân được đưa vào tài liệu, vì vậy kích thước bản trình bày tăng tỷ lệ với kích thước tệp video. Khi bạn liên kết tới video trực tuyến và thêm ảnh thu nhỏ, bản trình bày chỉ lưu liên kết và ảnh preview thay vì dữ liệu video, vì vậy tăng kích thước thường ít hơn.

**Tôi có thể thay thế video trong một khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể hoán đổi [nội dung video](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) trong khung trong khi giữ nguyên hình dạng; đây là kịch bản phổ biến để cập nhật media trong bố cục đã tồn tại.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Video được nhúng có một [loại nội dung](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó ra đĩa.