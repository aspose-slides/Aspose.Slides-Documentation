---
title: Quản lý âm thanh trong bản trình chiếu bằng C++
linktitle: Khung âm thanh
type: docs
weight: 10
url: /vi/cpp/audio-frame/
keywords:
- âm thanh
- khung âm thanh
- hình thu nhỏ
- thêm âm thanh
- thuộc tính âm thanh
- tùy chọn âm thanh
- trích xuất âm thanh
- C++
- Aspose.Slides
description: "Tạo và điều khiển các khung âm thanh trong Aspose.Slides cho C++ — các ví dụ mã để nhúng, cắt, lặp và cấu hình phát lại trên các bản trình chiếu PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với khung âm thanh trong Aspose.Slides. Nó cho thấy cách thêm âm thanh nhúng vào các slide, tùy chỉnh hình thu nhỏ của khung âm thanh, cấu hình các tùy chọn phát lại như âm lượng, vòng lặp, ẩn, cắt và thời gian làm mờ, và trích xuất âm thanh được sử dụng trong chuyển đổi trình chiếu.

## **Tạo khung âm thanh**

Aspose.Slides cho C++ cho phép bạn thêm tệp âm thanh vào các slide. Các tệp âm thanh được nhúng trong slide dưới dạng khung âm thanh. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Tải luồng tệp âm thanh mà bạn muốn nhúng vào slide.
4. Thêm khung âm thanh nhúng (chứa tệp âm thanh) vào slide.
5. Đặt [PlayMode](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) và `Volume` được công bố bởi đối tượng [IAudioFrame](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_audio_frame).
6. Lưu bản trình chiếu đã sửa đổi.

Đoạn mã C++ này cho bạn thấy cách thêm một khung âm thanh nhúng vào slide:

```cpp
// Tạo một đối tượng lớp Presentation đại diện cho tệp bản trình chiếu
auto pres = System::MakeObject<Presentation>();

// Lấy slide đầu tiên
auto sld = pres->get_Slides()->idx_get(0);

// Tải tệp âm thanh wav vào luồng
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Thêm khung âm thanh
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Đặt chế độ phát và âm lượng cho âm thanh
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Ghi tệp PowerPoint ra đĩa
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Thay đổi hình thu nhỏ của khung âm thanh**

Khi bạn thêm một tệp âm thanh vào bản trình chiếu, âm thanh sẽ hiển thị dưới dạng một khung với hình ảnh mặc định tiêu chuẩn (xem hình ảnh trong phần bên dưới). Bạn có thể thay đổi hình thu nhỏ của khung âm thanh (đặt hình ảnh bạn muốn).

Đoạn mã C++ này cho bạn thấy cách thay đổi hình thu nhỏ hoặc hình ảnh xem trước của khung âm thanh:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Thêm một khung âm thanh vào slide với vị trí và kích thước xác định.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Thêm một hình ảnh vào tài nguyên của bản trình chiếu.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Đặt hình ảnh cho khung âm thanh.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Lưu bản trình chiếu đã chỉnh sửa ra đĩa
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Thay đổi tùy chọn phát âm thanh**

Aspose.Slides cho C++ cho phép bạn thay đổi các tùy chọn kiểm soát việc phát lại hoặc thuộc tính của âm thanh. Ví dụ, bạn có thể điều chỉnh âm lượng của âm thanh, đặt âm thanh phát vòng lặp, hoặc thậm chí ẩn biểu tượng âm thanh.

Bảng **Audio Options** trong Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** của PowerPoint tương ứng với các phương thức của Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/) :

- **Start** danh sách thả xuống tương ứng với phương thức [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/set_playmode/) 
- **Volume** tương ứng với phương thức [AudioFrame::set_Volume](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/set_volume/) 
- **Play Across Slides** tương ứng với phương thức [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/set_playacrossslides/) 
- **Loop until Stopped** tương ứng với phương thức [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/set_playloopmode/) 
- **Hide During Show** tương ứng với phương thức [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/set_hideatshowing/) 
- **Rewind after Playing** tương ứng với phương thức [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/set_rewindaudio/) 

Các tùy chọn **Editing** của PowerPoint tương ứng với các thuộc tính của Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/) :

- **Fade In** tương ứng với phương thức [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/set_fadeinduration/) 
- **Fade Out** tương ứng với phương thức [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/set_fadeoutduration/) 
- **Trim Audio Start Time** tương ứng với phương thức [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/set_trimfromstart/) 
- **Trim Audio End Time** có giá trị bằng độ dài âm thanh trừ đi giá trị của phương thức [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/set_trimfromend/) 

Bộ điều khiển **Volume** trên bảng điều khiển âm thanh của PowerPoint tương ứng với phương thức [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/set_volumevalue/). Nó cho phép bạn thay đổi âm lượng âm thanh dưới dạng phần trăm.

Đây là cách bạn thay đổi các tùy chọn phát âm thanh:

1. [Tạo](#creating-audio-frame) hoặc lấy Khung âm thanh.
2. Đặt các giá trị mới cho các thuộc tính Khung âm thanh mà bạn muốn điều chỉnh.
3. Lưu tệp PowerPoint đã sửa đổi.

Đoạn mã C++ này minh họa một thao tác trong đó các tùy chọn của âm thanh được điều chỉnh:

```cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Lấy một shape
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Ép kiểu shape thành shape AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Đặt chế độ phát để phát khi nhấp
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Đặt âm lượng thành Thấp
audioFrame->set_Volume(AudioVolumeMode::Low);

// Đặt âm thanh phát xuyên suốt các slide
audioFrame->set_PlayAcrossSlides(true);

// Tắt vòng lặp cho âm thanh
audioFrame->set_PlayLoopMode(false);

// Ẩn AudioFrame trong khi trình chiếu
audioFrame->set_HideAtShowing(true);

// Quay lại âm thanh về đầu sau khi phát
audioFrame->set_RewindAudio(true);

// Lưu tệp PowerPoint ra đĩa
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

Ví dụ C++ này cho bạn thấy cách thêm một khung âm thanh mới với âm thanh nhúng, cắt nó và đặt thời gian làm mờ:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

Đoạn mã mẫu dưới đây cho bạn thấy cách lấy một khung âm thanh có âm thanh nhúng và đặt âm lượng thành 85%:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Lấy một shape khung âm thanh
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Đặt âm lượng âm thanh thành 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Quản lý phụ đề âm thanh**

Aspose.Slides cho phép bạn thêm phụ đề đóng vào một khung âm thanh thông qua phương thức [get_CaptionTracks](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iaudioframe/get_captiontracks/). Phương thức này trả về một [ICaptionsCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icaptionscollection/), cho phép bạn thêm các track phụ đề WebVTT, duyệt qua các track hiện có và xóa chúng khi cần.

**Thêm phụ đề âm thanh**

Sử dụng phương thức [get_CaptionTracks](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iaudioframe/get_captiontracks/) để gắn một hoặc nhiều track phụ đề vào khung âm thanh. Trong ví dụ sau, một tệp âm thanh được thêm vào slide, sau đó một track phụ đề mới được tải từ tệp `.vtt`.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Add a new caption track from a WebVTT file.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Trích xuất phụ đề âm thanh**

Bạn có thể duyệt qua các track phụ đề gắn với khung âm thanh và lưu chúng dưới dạng tệp `.vtt`. Mỗi track phụ đề cung cấp dữ liệu nhị phân và định danh duy nhất, có thể dùng khi xuất phụ đề.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // Lưu mỗi track phụ đề dưới dạng tệp .vtt.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**Xóa phụ đề âm thanh**

Để xóa phụ đề khỏi khung âm thanh, sử dụng các phương thức của [ICaptionsCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icaptionscollection/), chẳng hạn như [Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icaptionscollection/remove/), hoặc [RemoveAt](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icaptionscollection/removeat/). Ví dụ sau xóa tất cả các track phụ đề khỏi một khung âm thanh.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Xóa tất cả các track phụ đề khỏi khung âm thanh.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Trích xuất âm thanh**
Aspose.Slides cho phép bạn trích xuất âm thanh được sử dụng trong chuyển đổi trình chiếu. Ví dụ, bạn có thể trích xuất âm thanh được dùng trong một slide cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) và tải bản trình chiếu chứa âm thanh.
2. Lấy tham chiếu của slide liên quan thông qua chỉ mục của nó.
3. Truy cập các chuyển đổi slideshow cho slide đó.
4. Trích xuất âm thanh dưới dạng dữ liệu byte.

Đoạn mã C++ này cho bạn thấy cách trích xuất âm thanh được sử dụng trong một slide:

```cpp
String presName = u"AudioSlide.pptx";

// Tạo một đối tượng lớp Presentation đại diện cho tệp bản trình chiếu
auto pres = System::MakeObject<Presentation>(presName);

// Truy cập slide mong muốn
auto slide = pres->get_Slides()->idx_get(0);

// Lấy hiệu ứng chuyển đổi slideshow cho slide
auto transition = slide->get_SlideShowTransition();

// Trích xuất âm thanh dưới dạng mảng byte
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**Tôi có thể tái sử dụng cùng một tài nguyên âm thanh cho nhiều slide mà không làm tăng kích thước tệp không?**

Có. Thêm âm thanh một lần vào [audio collection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_audios/) chung của bản trình chiếu và tạo các khung âm thanh bổ sung tham chiếu tới tài nguyên đã tồn tại. Điều này tránh việc sao chép dữ liệu media và giữ kích thước bản trình chiếu trong tầm kiểm soát.

**Tôi có thể thay thế âm thanh trong một khung âm thanh hiện có mà không phải tạo lại hình dạng không?**

Có. Đối với âm thanh liên kết, cập nhật [link path](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/set_linkpathlong/) để trỏ tới tệp mới. Đối với âm thanh nhúng, thay thế đối tượng [embedded audio](https://reference.aspose.com/slides/vi/cpp/aspose.slides/audioframe/set_embeddedaudio/) bằng một đối tượng khác từ [audio collection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_audios/) của bản trình chiếu. Định dạng khung và hầu hết các cài đặt phát lại vẫn giữ nguyên.

**Việc cắt giảm có thay đổi dữ liệu âm thanh nền được lưu trong bản trình chiếu không?**

Không. Việc cắt chỉ điều chỉnh ranh giới phát lại. Các byte âm thanh gốc vẫn không thay đổi và có thể truy cập thông qua âm thanh nhúng hoặc audio collection của bản trình chiếu.