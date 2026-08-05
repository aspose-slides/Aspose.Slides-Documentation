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
- lấy lại video
- khung video
- nguồn web
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Học cách lập trình để thêm và trích xuất khung video trong slide PowerPoint và OpenDocument bằng Aspose.Slides cho C++. Hướng dẫn nhanh chóng."
---
## **Giới thiệu**

Một video được đặt đúng chỗ trong bản trình bày có thể làm cho thông điệp của bạn thuyết phục hơn và tăng mức độ tương tác với khán giả.

PowerPoint cho phép bạn thêm video vào một slide trong bản trình bày theo hai cách:

* Thêm hoặc nhúng video cục bộ (lưu trên máy tính của bạn)
* Thêm video trực tuyến (từ nguồn web như YouTube).

Để cho phép bạn thêm video (đối tượng video) vào bản trình bày, Aspose.Slides cung cấp giao diện [IVideo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideo/), giao diện [IVideoFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/) và các kiểu liên quan khác. 

## **Tạo Khung Video Nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình bày.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide thông qua chỉ mục của nó. 
3. Thêm một đối tượng [IVideo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideo/) và truyền đường dẫn tệp video để nhúng video vào bản trình bày. 
4. Thêm một đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/) để tạo khung cho video.  
5. Lưu bản trình bày đã chỉnh sửa. 

Đoạn mã C++ dưới đây cho bạn thấy cách thêm video được lưu cục bộ vào bản trình bày:

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

Ngoài ra, bạn có thể thêm video bằng cách truyền trực tiếp đường dẫn tệp vào phương thức [AddVideoFrame()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addvideoframe/) :

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Tạo Khung Video với Video Từ Nguồn Web**

Các phiên bản mới hơn của Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong bản trình bày. Nếu video bạn muốn sử dụng có sẵn trên mạng (ví dụ trên YouTube), bạn có thể thêm nó vào bản trình bày thông qua liên kết web.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) 
2. Lấy tham chiếu đến slide thông qua chỉ mục của nó. 
3. Thêm một đối tượng [IVideo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideo/) và truyền liên kết đến video. 
4. Đặt hình thu nhỏ cho khung video. 
5. Lưu bản trình bày. 

Đoạn mã C++ dưới đây cho bạn thấy cách thêm video từ web vào một slide trong bản trình bày PowerPoint:

```c++
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Tạo một đối tượng Presentation đại diện cho tệp bản trình bày
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Thêm một Khung Video 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Đặt chế độ phát và âm lượng của video
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Lưu bản trình bày ra đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Cắt Bớt Khung Video**

Aspose.Slides cho phép bạn kiểm soát phần nào của video sẽ được phát bằng cách đặt giá trị trim-from-start và trim-from-end thông qua [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/set_trimfromstart/) và [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/set_trimfromend/). Cả hai giá trị đều được chỉ định bằng mili giây và xác định thời gian bỏ qua từ đầu và cuối video tương ứng. Các cài đặt này thay đổi cách phát video trong bản trình bày; chúng không cắt hoặc sửa đổi dữ liệu nhị phân video đã nhúng.

**Đặt Cài Đặt Cắt**

Để tạo một khung video và thiết lập cài đặt cắt:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Thêm một đối tượng [IVideo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideo/) vào bản trình bày. 
3. Thêm một đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/) vào một slide. 
4. Đặt giá trị trim-from-start và trim-from-end qua [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/set_trimfromstart/) và [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/set_trimfromend/). 
5. Lưu bản trình bày đã chỉnh sửa.

Đoạn mã dưới đây bỏ qua 2,5 giây đầu và 1 giây cuối của video đã nhúng khi phát:

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

**Đọc Cài Đặt Cắt**

Để kiểm tra các cài đặt cắt hiện có, tải một bản trình bày, tìm đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/) trong các hình trên slide đầu tiên, và đọc các giá trị qua [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/get_trimfromstart/) và [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/get_trimfromend/).

Đoạn mã dưới đây tìm khung video đầu tiên trên slide đầu tiên và báo cáo các cài đặt cắt bằng mili giây:

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

## **Quản Lý Phụ Đề Video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bản trình bày PowerPoint. Phụ đề được lưu dưới định dạng WebVTT và được truy cập qua phương thức [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Thêm Phụ Đề Vào Khung Video**

Để thêm phụ đề vào một khung video:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Thêm một video vào bản trình bày. 
3. Thêm một đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/) vào một slide. 
4. Sử dụng [ICaptionsCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icaptionscollection/) trả về bởi [get_CaptionTracks](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/get_captiontracks/) để thêm một track phụ đề WebVTT. 
5. Lưu bản trình bày đã chỉnh sửa.

Đoạn mã dưới đây cho bạn thấy cách thêm phụ đề vào khung video:

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

Giao diện [ICaptionsCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icaptionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng dữ liệu.

**Trích Xuất Phụ Đề Từ Khung Video**

Để trích xuất phụ đề từ khung video:

1. Tải bản trình bày chứa video. 
2. Tìm đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/) mục tiêu. 
3. Duyệt qua các track phụ đề trả về bởi [get_CaptionTracks](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/get_captiontracks/). 
4. Lưu mỗi track phụ đề vào tệp `.vtt`.

Đoạn mã dưới đây cho bạn thấy cách trích xuất phụ đề từ khung video:

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
            // Lưu track phụ đề vào tệp WebVTT.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Mỗi đối tượng [ICaptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icaptions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và dữ liệu phụ đề dưới dạng chuỗi UTF-8.

**Xóa Phụ Đề Khỏi Khung Video**

Để xóa phụ đề khỏi khung video:

1. Tải bản trình bày chứa video. 
2. Lấy đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/) mục tiêu. 
3. Xóa các track phụ đề khỏi bộ sưu tập trả về bởi [get_CaptionTracks](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/get_captiontracks/). 
4. Lưu bản trình bày đã chỉnh sửa.

Đoạn mã dưới đây cho bạn thấy cách xóa tất cả phụ đề khỏi khung video:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Xóa tất cả phụ đề khỏi khung video.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Nếu bạn chỉ cần xóa một track phụ đề, hãy sử dụng phương thức [Remove](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icaptionscollection/remove/) hoặc [RemoveAt](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icaptionscollection/removeat/) thay vì [Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icaptionscollection/clear/).

## **Trích Xuất Video Từ Slide**

Bên cạnh việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video đã nhúng trong bản trình bày.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) để tải bản trình bày chứa video. 
2. Duyệt qua tất cả các đối tượng [ISlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/). 
3. Duyệt qua tất cả các đối tượng [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) để tìm một [VideoFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/videoframe/). 
4. Lưu video ra đĩa.

Đoạn mã C++ dưới đây cho bạn thấy cách trích xuất video trên một slide của bản trình bày:

```c++
// Đường dẫn tới thư mục tài liệu.
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

## **Câu Hỏi Thường Gặp**

**Tham số phát video nào có thể thay đổi cho một VideoFrame?**

Bạn có thể kiểm soát [chế độ phát](https://reference.aspose.com/slides/vi/cpp/aspose.slides/videoframe/set_playmode/) (tự động hoặc khi nhấp) và [vòng lặp](https://reference.aspose.com/slides/vi/cpp/aspose.slides/videoframe/set_playloopmode/). Các tùy chọn này có sẵn qua các thuộc tính của đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/videoframe/).

**Việc thêm video có làm tăng kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân được bao gồm trong tài liệu, do đó kích thước bản trình bày sẽ tăng tỷ lệ với kích thước tệp. Khi bạn thêm video trực tuyến, một liên kết và hình thu nhỏ được nhúng, vì vậy mức tăng kích thước sẽ nhỏ hơn.

**Tôi có thể thay thế video trong một VideoFrame hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể hoán đổi [nội dung video](https://reference.aspose.com/slides/vi/cpp/aspose.slides/videoframe/set_embeddedvideo/) trong khung trong khi giữ nguyên hình dạng; đây là trường hợp phổ biến khi cập nhật phương tiện trong bố cục đã có.

**Có thể xác định loại nội dung (MIME) của video đã nhúng không?**

Có. Một video đã nhúng có một [loại nội dung](https://reference.aspose.com/slides/vi/cpp/aspose.slides/video/get_contenttype/) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó ra đĩa.