---
title: Quản lý Khung Âm Thanh trong Bản Trình Chiếu bằng .NET
linktitle: Khung Âm Thanh
type: docs
weight: 10
url: /vi/net/audio-frame/
keywords:
- âm thanh
- khung âm thanh
- hình thu nhỏ
- thêm âm thanh
- thuộc tính âm thanh
- tùy chọn âm thanh
- trích xuất âm thanh
- .NET
- C#
- Aspose.Slides
description: "Tạo và điều khiển khung âm thanh trong Aspose.Slides cho .NET—ví dụ C# để nhúng, cắt, lặp và cấu hình phát lại trên các bản trình chiếu PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với khung âm thanh trong Aspose.Slides. Nó cho thấy cách thêm âm thanh nhúng vào slide, tùy chỉnh hình thu nhỏ của khung âm thanh, cấu hình các tùy chọn phát như âm lượng, vòng lặp, ẩn, cắt và thời gian làm mờ, và trích xuất âm thanh được sử dụng trong các chuyển đổi trình chiếu.

## **Tạo Khung Âm Thanh**

Aspose.Slides for .NET cho phép bạn thêm tệp âm thanh vào slide. Các tệp âm thanh được nhúng trong slide dưới dạng khung âm thanh. 

1. Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Tải luồng tệp âm thanh mà bạn muốn nhúng vào slide.
4. Thêm khung âm thanh nhúng (chứa tệp âm thanh) vào slide.
5. Đặt [PlayMode](https://reference.aspose.com/slides/vi/net/aspose.slides/audioplaymodepreset) và `Volume` được cung cấp bởi đối tượng [IAudioFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe).
6. Lưu bản trình chiếu đã sửa đổi.

Mã C# này cho bạn thấy cách thêm một khung âm thanh nhúng vào slide:

```c#
// Khởi tạo một lớp Presentation đại diện cho tệp bản trình chiếu
using (Presentation pres = new Presentation())
{
    // Lấy slide đầu tiên
    ISlide sld = pres.Slides[0];
    
    // Tải tệp âm thanh wav vào luồng
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Thêm khung âm thanh
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Đặt chế độ phát và âm lượng của âm thanh
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Ghi tệp PowerPoint ra đĩa
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Thay Đổi Hình Thu Nhỏ Khung Âm Thanh**

Khi bạn thêm một tệp âm thanh vào bản trình chiếu, âm thanh sẽ hiển thị dưới dạng khung với hình ảnh mặc định tiêu chuẩn (xem hình trong phần dưới đây). Bạn có thể thay đổi hình thu nhỏ của khung âm thanh (đặt hình ảnh bạn ưa thích).

Mã C# này cho bạn thấy cách thay đổi hình thu nhỏ hoặc hình ảnh xem trước của khung âm thanh:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Thêm một khung âm thanh vào slide với vị trí và kích thước xác định.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Thêm một hình ảnh vào tài nguyên của bản trình chiếu.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Đặt hình ảnh cho khung âm thanh.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
	
	//Lưu bản trình chiếu đã sửa đổi vào đĩa
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Thay Đổi Các Tùy Chọn Phát Âm Thanh**

Aspose.Slides for .NET cho phép bạn thay đổi các tùy chọn kiểm soát việc phát âm thanh hoặc các thuộc tính của nó. Ví dụ, bạn có thể điều chỉnh âm lượng, đặt âm thanh phát vòng lặp, hoặc thậm chí ẩn biểu tượng âm thanh.

Bảng **Audio Options** trong Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** của PowerPoint tương ứng với các thuộc tính [AudioFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe) của Aspose.Slides:

- **Start** (bắt đầu) phù hợp với thuộc tính [AudioFrame.PlayMode](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe/properties/playmode)  
- **Volume** (âm lượng) phù hợp với thuộc tính [AudioFrame.Volume](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe/properties/volume)  
- **Play Across Slides** (phát xuyên suốt các slide) phù hợp với thuộc tính [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe/properties/playacrossslides)  
- **Loop until Stopped** (lặp lại cho đến khi dừng) phù hợp với thuộc tính [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe/properties/playloopmode)  
- **Hide During Show** (ẩn khi trình chiếu) phù hợp với thuộc tính [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe/properties/hideatshowing)  
- **Rewind after Playing** (tua lại sau khi phát) phù hợp với thuộc tính [AudioFrame.RewindAudio](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe/properties/rewindaudio)  

Các tùy chọn **Editing** của PowerPoint tương ứng với các thuộc tính [AudioFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe) của Aspose.Slides:

- **Fade In** (từ từ lên) phù hợp với thuộc tính [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe/fadeinduration/)  
- **Fade Out** (từ từ tắt) phù hợp với thuộc tính [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe/fadeoutduration/)  
- **Trim Audio Start Time** (cắt thời gian bắt đầu) phù hợp với thuộc tính [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe/trimfromstart/)  
- **Trim Audio End Time** (cắt thời gian kết thúc) có giá trị bằng độ dài âm thanh trừ giá trị của thuộc tính [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe/trimfromend/)  

Bảng điều khiển **Volume controll** (điều khiển âm lượng) trên bảng điều khiển âm thanh của PowerPoint tương ứng với thuộc tính [AudioFrame.VolumeValue](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe/volumevalue/). Nó cho phép bạn thay đổi âm lượng âm thanh dưới dạng phần trăm.

Đây là cách thay đổi các tùy chọn phát âm thanh:

1. [Сreate](#create-audio-frame) hoặc lấy Khung Âm Thanh.
2. Đặt các giá trị mới cho các thuộc tính Khung Âm Thanh mà bạn muốn điều chỉnh.
3. Lưu tệp PowerPoint đã sửa đổi.

Mã C# này minh họa một thao tác trong đó các tùy chọn của âm thanh được điều chỉnh:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Lấy hình dạng AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Đặt chế độ phát để phát khi nhấp
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Đặt âm lượng thành Thấp
    audioFrame.Volume = AudioVolumeMode.Low;

    // Đặt âm thanh phát xuyên suốt các slide
    audioFrame.PlayAcrossSlides = true;

    // Tắt vòng lặp cho âm thanh
    audioFrame.PlayLoopMode = false;

    // Ẩn AudioFrame trong khi trình chiếu
    audioFrame.HideAtShowing = true;

    // Tua lại âm thanh về đầu sau khi phát
    audioFrame.RewindAudio = true;

    // Lưu tệp PowerPoint vào đĩa
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Ví dụ C# này cho thấy cách thêm một khung âm thanh mới với âm thanh nhúng, cắt nó và đặt thời gian làm mờ:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Đặt độ lệch bắt đầu cắt thành 1.5 giây
    audioFrame.TrimFromStart = 1500f;
    // Đặt độ lệch kết thúc cắt thành 2 giây
    audioFrame.TrimFromEnd = 2000f;

    // Đặt thời lượng fade-in thành 200 ms
    audioFrame.FadeInDuration = 200f;
    // Đặt thời lượng fade-out thành 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

Mẫu mã sau đây cho thấy cách truy xuất một khung âm thanh có âm thanh nhúng và đặt âm lượng thành 85%:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Lấy một hình dạng audio frame
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Đặt âm lượng audio thành 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Quản Lý Phụ Đề Âm Thanh**

Aspose.Slides cho phép bạn thêm phụ đề đóng cho khung âm thanh thông qua thuộc tính [CaptionTracks](https://reference.aspose.com/slides/vi/net/aspose.slides/iaudioframe/captiontracks/). Thuộc tính này trả về một [ICaptionsCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/icaptionscollection/), cho phép bạn thêm các track phụ đề WebVTT, duyệt qua các track hiện có và xóa chúng khi cần.

**Thêm Phụ Đề Âm Thanh**

Sử dụng thuộc tính [CaptionTracks](https://reference.aspose.com/slides/vi/net/aspose.slides/iaudioframe/captiontracks/) để gắn một hoặc nhiều track phụ đề vào khung âm thanh. Trong ví dụ sau, một tệp âm thanh được thêm vào slide, sau đó một track phụ đề mới được tải từ tệp `.vtt`.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Thêm một track phụ đề mới từ tệp WebVTT.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Trích Xuất Phụ Đề Âm Thanh**

Bạn có thể duyệt qua các track phụ đề gắn với khung âm thanh và lưu chúng dưới dạng tệp `.vtt`. Mỗi track phụ đề cung cấp dữ liệu nhị phân và định danh duy nhất, có thể dùng khi xuất phụ đề.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // Lưu track phụ đề dưới dạng tệp .vtt.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Xóa Phụ Đề Âm Thanh**

Để xóa phụ đề khỏi khung âm thanh, sử dụng các phương thức do [ICaptionsCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/icaptionscollection/) cung cấp, chẳng hạn như [Clear](https://reference.aspose.com/slides/vi/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/vi/net/aspose.slides/icaptionscollection/remove/), hoặc [RemoveAt](https://reference.aspose.com/slides/vi/net/aspose.slides/icaptionscollection/removeat/). Ví dụ sau xóa tất cả các track phụ đề khỏi một khung âm thanh.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Xóa tất cả các track phụ đề khỏi khung âm thanh.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Trích Xuất Âm Thanh**
Aspose.Slides for .NET cho phép bạn trích xuất âm thanh được sử dụng trong các chuyển đổi trình chiếu. Ví dụ, bạn có thể trích xuất âm thanh được dùng trong một slide cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) và tải bản trình chiếu chứa âm thanh.
2. Lấy tham chiếu của slide liên quan thông qua chỉ mục của nó.
3. Truy cập các chuyển đổi slideshow cho slide đó.
4. Trích xuất âm thanh dưới dạng dữ liệu byte.

Mã C# này cho bạn thấy cách trích xuất âm thanh được sử dụng trong một slide:

```c#
string presName = "AudioSlide.pptx";

// Khởi tạo một lớp Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation(presName);

// Truy cập slide
ISlide slide = pres.Slides[0];

// Lấy các hiệu ứng chuyển đổi slideshow cho slide
ISlideShowTransition transition = slide.SlideShowTransition;

// Trích xuất âm thanh thành mảng byte
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**Tôi có thể tái sử dụng cùng một tài nguyên âm thanh trên nhiều slide mà không làm tăng kích thước tệp không?**

Có. Thêm âm thanh một lần vào [audio collection](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/audios/) chung của bản trình chiếu và tạo các khung âm thanh bổ sung tham chiếu tới tài nguyên hiện có. Điều này tránh việc sao chép dữ liệu phương tiện và giữ kích thước bản trình chiếu trong tầm kiểm soát.

**Tôi có thể thay thế âm thanh trong một khung âm thanh hiện có mà không cần tạo lại shape không?**

Có. Đối với âm thanh liên kết, cập nhật [link path](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe/linkpathlong/) để trỏ tới tệp mới. Đối với âm thanh nhúng, hoán đổi đối tượng [embedded audio](https://reference.aspose.com/slides/vi/net/aspose.slides/audioframe/embeddedaudio/) bằng một đối tượng khác từ [audio collection](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/audios/) của bản trình chiếu. Định dạng khung và hầu hết các cài đặt phát sẽ vẫn giữ nguyên.

**Việc cắt âm thanh có làm thay đổi dữ liệu âm thanh nền tảng được lưu trong bản trình chiếu không?**

Không. Việc cắt chỉ điều chỉnh ranh giới phát. Các byte âm thanh gốc vẫn không bị thay đổi và có thể truy cập thông qua âm thanh nhúng hoặc audio collection của bản trình chiếu.