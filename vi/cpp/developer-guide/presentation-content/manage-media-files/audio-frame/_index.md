---
title: Quản lý Khung Âm Thanh trong Bài Trình Bày bằng C++
linktitle: Khung Âm Thanh
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
description: "Nhúng âm thanh vào các slide, thay đổi biểu tượng âm thanh, cấu hình phát lại, quản lý phụ đề WebVTT và trích xuất âm thanh chuyển đổi slide với Aspose.Slides cho C++."
---
## **Tổng quan**

Khung âm thanh cho phép bạn phát âm thanh trên một slide. Với Aspose.Slides for C++, bạn có thể nhúng một đoạn âm thanh, chọn hình ảnh đại diện, điều chỉnh phát lại và đính kèm phụ đề. Bạn cũng có thể lấy âm thanh được gán cho chuyển đổi slide.

## **Tạo Khung Âm Thanh**

Sử dụng [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) để nhúng một đoạn âm thanh cục bộ vào slide đầu tiên. Hai tọa độ đầu tiên đặt vị trí khung trên slide, và hai giá trị tiếp theo thiết lập chiều rộng và chiều cao, tất cả đều tính bằng điểm. Ví dụ này gọi [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) để bắt đầu đoạn âm thanh tự động và gọi [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) để chọn mức âm lượng cao sẵn.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

presentation->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Thay Đổi Hình Thu Nhỏ Khung Âm Thanh**

Mặc định, khung âm thanh hiển thị biểu tượng loa. Để hiển thị hình thu nhỏ tùy chỉnh, thêm một hình ảnh vào bản trình chiếu bằng [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) và đặt nó làm ảnh của khung bằng [set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/). Ví dụ sử dụng một tệp JPEG làm hình thu nhỏ cho đoạn âm thanh được nhúng.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageStream = File::OpenRead(u"eagle.jpeg");
auto thumbnail = presentation->get_Images()->AddImage(imageStream);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

## **Thay Đổi Tùy Chọn Phát Âm Thanh**

Các điều khiển **Audio Options** của PowerPoint xác định thời điểm bắt đầu đoạn âm thanh, mức độ to, và cách nó hoạt động trong khi trình chiếu.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Điều khiển PowerPoint | Phương thức Aspose.Slides for C++ |
| --- | --- |
| Start | [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) |
| Volume preset | [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) |
| Play Across Slides | [set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playacrossslides/) |
| Loop until Stopped | [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playloopmode/) |
| Hide During Show | [set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_hideatshowing/) |
| Rewind after Playing | [set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_rewindaudio/) |
| Fade In | [set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeinduration/) |
| Fade Out | [set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeoutduration/) |
| Trim Audio start time | [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) |
| Trim Audio end time | [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) |
| Volume slider | [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/) |

Ví dụ tìm khung âm thanh đầu tiên trên slide đầu tiên, gọi [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) để bắt đầu phát khi nhấp, và chọn mức âm lượng thấp. Đoạn âm thanh tiếp tục qua các slide với vòng lặp bị tắt. Biểu tượng được ẩn trong khi trình chiếu, và đoạn âm thanh được tua lại sau khi phát.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);
    audioFrame->set_Volume(AudioVolumeMode::Low);
    audioFrame->set_PlayAcrossSlides(true);
    audioFrame->set_PlayLoopMode(false);
    audioFrame->set_HideAtShowing(true);
    audioFrame->set_RewindAudio(true);

    presentation->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

Đối với đoạn âm thanh dài hơn 3,5 giây, ví dụ này bỏ qua 1,5 giây đầu và 2 giây cuối. Tham số truyền vào [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) chỉ định thời lượng loại bỏ ở cuối đoạn. Để có thời gian kết thúc hiển thị trong PowerPoint, lấy tổng thời lượng trừ đi độ lệch này. Đoạn đã cắt sẽ tăng dần âm lượng trong 200 mil giây và giảm dần trong 500 mil giây. Bốn phương thức này đều nhận giá trị tính bằng mil giây.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame->set_TrimFromStart(1500);
audioFrame->set_TrimFromEnd(2000);
audioFrame->set_FadeInDuration(200);
audioFrame->set_FadeOutDuration(500);

presentation->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
```

Để đặt mức âm lượng phát lại theo phần trăm cụ thể, sử dụng [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/). Ví dụ này đặt khung âm thanh đầu tiên trên slide đầu tiên thành 85%.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_VolumeValue(85);

    presentation->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

## **Quản Lý Phụ Đề Âm Thanh**

Mỗi khung âm thanh mở ra bộ sưu tập phụ đề thông qua [get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_captiontracks/). Sử dụng nó để đính kèm phụ đề WebVTT cho đoạn, xuất các track hiện có, hoặc xóa chúng.

### **Thêm Phụ Đề Âm Thanh**

Ví dụ nhúng một đoạn âm thanh vào slide đầu tiên và sử dụng [ICaptionsCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/add/) để đính kèm một track WebVTT cục bộ. Tham số đầu tiên cung cấp nhãn track, và tham số thứ hai xác định tệp chứa phụ đề có thời gian.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
```

### **Trích Xuất Phụ Đề Âm Thanh**

Ví dụ này xuất mỗi track phụ đề được gắn vào khung âm thanh trên slide đầu tiên. Nó ghi các byte trả về bởi [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_binarydata/) vào một tệp WebVTT và sử dụng giá trị trả về bởi [get_CaptionId](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_captionid/) làm tên tệp để mỗi track có đầu ra riêng.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto fileName = track->get_CaptionId().ToString() + u".vtt";
        File::WriteAllBytes(fileName, track->get_BinaryData());
    }
}
```

### **Xóa Phụ Đề Âm Thanh**

Sử dụng [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/remove/) hoặc [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/removeat/) để xóa một track riêng lẻ. Ví dụ này sử dụng [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/clear/) để xóa tất cả phụ đề khỏi khung âm thanh đầu tiên trên slide đầu tiên trong khi vẫn giữ lại đoạn âm thanh.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->get_CaptionTracks()->Clear();

    presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

### **Tìm Dòng Trong Phụ Đề Âm Thanh**

Để tìm một dòng trong phụ đề âm thanh trên slide đầu tiên, gọi [get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) trên mỗi track để đọc văn bản WebVTT trong bộ nhớ. Trong một cue WebVTT dạng văn bản thuần, dòng thời gian chứa `-->`, các dòng phụ đề nằm sau, và một dòng trống kết thúc cue. Ví dụ này in nhãn track và mỗi dòng phụ đề chứa “café”.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto reader = MakeObject<StringReader>(track->get_DataAsString());
        auto inCue = false;
        for (auto line = reader->ReadLine(); !line.IsNull(); line = reader->ReadLine())
        {
            if (line.get_Length() == 0)
                inCue = false;
            else if (line.Contains(u"-->"))
                inCue = true;
            else if (inCue && line.IndexOf(u"caf\u00e9", StringComparison::OrdinalIgnoreCase) >= 0)
                Console::WriteLine(track->get_Label() + u": " + line);
        }
    }
}
```

## **Trích Xuất Âm Thanh**

Một chuyển đổi slide có thể có âm thanh riêng. Để lấy nó, gọi [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_sound/) trên chuyển đổi. Ví dụ này lấy các byte âm thanh bằng [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/) và in số lượng byte. Nếu slide đầu tiên không có âm thanh chuyển đổi, nó sẽ in một thông báo thay thế.

```cpp
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioSlide.pptx");
auto slide = presentation->get_Slide(0);

auto sound = slide->get_SlideShowTransition()->get_Sound();
if (sound)
{
    auto audioData = sound->get_BinaryData();
    Console::WriteLine(u"Transition sound: {0} bytes.", audioData->get_Length());
}
else
{
    Console::WriteLine(u"The first slide has no transition sound.");
}
```

## **Câu hỏi thường gặp**

**Tôi có thể tái sử dụng cùng một đoạn âm thanh trên nhiều slide mà không sao chép lại không?**

Có. Thêm đoạn âm thanh một lần vào [bộ sưu tập âm thanh](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) và truyền cùng một đối tượng âm thanh vào [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) cho mỗi slide.

**Tôi có thể thay thế âm thanh trong một khung âm thanh hiện có không?**

Có. Đối với âm thanh liên kết, gọi [set_LinkPathLong](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_linkpathlong/) với đường dẫn đến tệp thay thế. Đối với âm thanh nhúng, truyền một đoạn khác từ bộ sưu tập âm thanh của bản trình chiếu vào [set_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_embeddedaudio/). Cả hai cách đều giữ lại khung hiện tại.

**Việc cắt đoạn có thay đổi dữ liệu âm thanh được lưu trong bản trình chiếu không?**

Không. [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) và [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) chỉ thiết lập giới hạn phát lại. Bạn vẫn có thể lấy toàn bộ đoạn âm thanh bằng [get_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_embeddedaudio/).