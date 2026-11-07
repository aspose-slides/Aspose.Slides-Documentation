---
title: Quản lý Khung Video trong Bản Trình Bày trên .NET
linktitle: Khung Video
type: docs
weight: 10
url: /vi/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Học cách thêm và trích xuất khung video trong các slide PowerPoint và OpenDocument bằng cách lập trình sử dụng Aspose.Slides cho .NET. Hướng dẫn nhanh chóng."
---
## **Giới thiệu**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides for .NET cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát lại, quản lý phụ đề, và trích xuất dữ liệu video được nhúng.

PowerPoint hỗ trợ video cục bộ và liên kết đến video trực tuyến, chẳng hạn như video trên YouTube.

Để biểu diễn dữ liệu video và khung video, Aspose.Slides cung cấp giao diện [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) , giao diện [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) , và các kiểu liên quan khác.

## **Tạo khung video nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình bày của mình.

Ví dụ này nhúng video cục bộ vào slide đầu tiên của bản trình bày hiện có và lưu kết quả. Tọa độ và kích thước khung tính bằng điểm. Luồng dữ liệu vẫn mở cho đến khi lưu hoàn tất vì [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) giữ nó khóa trong khi bản trình bày sử dụng.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

Bạn cũng có thể truyền trực tiếp đường dẫn video cục bộ vào [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Ví dụ này nhúng video vào slide đầu tiên của một bản trình bày mới. Video phải vẫn khả dụng cho đến khi bản trình bày được lưu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Đặt âm lượng video một cách chính xác**

Trong Aspose.Slides for .NET 26.11 trở lên, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) đặt một phần trăm kiểu floating‑point từ 0 tới 100. Sử dụng nó khi các cài đặt [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) quá thô. Ví dụ, `75.5f` yêu cầu âm lượng 75.5%.

Ví dụ này yêu cầu [Aspose.Slides for .NET](/slides/vi/net/installation/) 26.11 trở lên và một tệp `video.mp4` cục bộ. Nó nhúng video, khởi tạo phát lại một cách rõ ràng, lưu bản trình bày và đọc lại phần trăm đã lưu.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

Xác thực đầu vào của bạn; không dựa vào setter để từ chối các giá trị ngoài phạm vi được ghi trong tài liệu. Các cài đặt Low, Medium và Loud tương ứng với 20, 50 và 80 trong phiên bản 26.11. Đặt một cài đặt sẵn có có thể thay thế phần trăm trước đó, vì vậy hãy gán phần trăm cuối cùng khi bạn cần giá trị chính xác. Sử dụng [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) để tắt tiếng một cách rõ ràng; số không và enum preset không phải là các trạng thái thay thế nhau.

Cài đặt rõ ràng [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) khi cấu hình video liên kết cũng vậy, và giữ tệp media của nó có sẵn cho người xem. Lưu và mở lại xác nhận cài đặt đã lưu; việc phát thực tế và độ lớn âm thanh phụ thuộc vào trình phát bản trình bày và cài đặt âm thanh của nó.

## **Tạo khung video với video từ nguồn web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong các bản trình bày. Bạn có thể tạo một khung video liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Ví dụ này thêm liên kết và hình thu nhỏ video YouTube vào slide đầu tiên. Thay thế định danh video để sử dụng video khác. Cài đặt [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) yêu cầu phát tự động. Tải xuống hình thu nhỏ và phát video yêu cầu có kết nối internet. Trình xem bản trình bày cũng phải hỗ trợ phát video trực tuyến.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Phát video ở chế độ toàn màn hình**

Trong bản trình bày đào tạo, bạn có thể phát bản demo phần mềm ở chế độ toàn màn hình để khán giả nhìn thấy chi tiết. Đặt [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) thành `true` để bật hành vi này khi phát.

Ví dụ này mở một bản trình bày, tìm [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) đầu tiên trên slide đầu tiên, và bật phát toàn màn hình. Bản trình bày đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

Phát toàn màn hình kiểm soát cách video được hiển thị. Một cách độc lập, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) kiểm soát việc video bắt đầu tự động hay khi nhấn, và [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) kiểm soát việc lặp lại. Để chọn hành vi khởi động, đặt chế độ phát thành [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Ví dụ này giữ nguyên các cài đặt bắt đầu và vòng lặp hiện có.

## **Quay lại video sau khi phát**

Trong bản trình bày đào tạo, việc đưa video demo trở lại đầu giúp người thuyết trình có thể phát lại nhanh chóng. Đặt [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) thành `true` để video trở lại đầu sau khi phát xong.

Ví dụ này mở một bản trình bày, tìm [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) đầu tiên trên slide đầu tiên, và bật chức năng quay lại. Nó tắt vòng lặp để phát có thể kết thúc và đặt phát bắt đầu khi nhấn. Bản trình bày đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

Quay lại video đưa video về đầu mà không tự động phát lại. Ngược lại, bật [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) sẽ lặp lại phát tự động. Hãy giữ vòng lặp tắt khi bạn muốn video kết thúc và sẵn sàng để phát lại. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) độc lập điều khiển khởi động tự động hay khi nhấn; ví dụ này sử dụng [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) để người thuyết trình kiểm soát thời điểm phát. Đặt chế độ phát sau khi đã đặt vòng lặp, như trong ví dụ. Quay lại hoạt động độc lập với [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Cắt khung video**

Sử dụng [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) và [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) để bỏ qua phần đầu hoặc cuối của video khi phát. Cả hai giá trị tính bằng mili giây. Cắt thay đổi cài đặt phát mà không thay đổi dữ liệu video được nhúng.

**Đặt cài đặt cắt**

Ví dụ này nhúng video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối khi phát. Hãy sử dụng video dài hơn 3,5 giây để còn lại một đoạn có thể phát.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Đọc cài đặt cắt**

Ví dụ này in giá trị cắt của khung video đầu tiên trên slide đầu tiên tính bằng mili giây. Bản trình bày phải chứa ít nhất một slide. Nếu slide đó không có khung video, sẽ không có gì được in. Ví dụ trước tạo ra các giá trị 2500 và 1000.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Quản lý phụ đề video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho khung video trong bản trình bày PowerPoint. Phụ đề được lưu dưới định dạng WebVTT và được truy cập qua thuộc tính [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**Thêm phụ đề vào khung video**

Ví dụ này nhúng video cục bộ và thêm một track phụ đề WebVTT có nhãn English. Các dấu thời gian phụ đề phải khớp với video. Bản trình bày đã lưu bao gồm cả video và phụ đề của nó.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

Giao diện [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng.

**Trích xuất phụ đề từ khung video**

Ví dụ này lưu tất cả các track phụ đề từ các khung video trên slide đầu tiên dưới dạng các tệp WebVTT riêng biệt. Các số thứ tự giữ cho các tệp đầu ra không trùng nhau. Console báo số lượng track đã được trích xuất. Bản trình bày phải chứa ít nhất một slide.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Mỗi đối tượng [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) tiết lộ định danh phụ đề, nhãn, dữ liệu nhị phân và nội dung phụ đề dưới dạng chuỗi UTF‑8.

**Xóa phụ đề khỏi khung video**

Ví dụ này xóa tất cả phụ đề khỏi khung video ở vị trí shape đầu tiên trên slide đầu tiên và lưu kết quả. Giả định slide và shape tồn tại và shape là một khung video.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

Nếu bạn chỉ cần xóa một track phụ đề, sử dụng các phương thức [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) hoặc [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) thay vì [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Trích xuất video từ slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong các bản trình bày.

Ví dụ này trích xuất video được nhúng từ mọi slide thành các tệp nhị phân có số thứ tự riêng. Video liên kết bị bỏ qua vì chúng không có dữ liệu nhúng. Console in ra loại MIME của mỗi video và tổng số. Đầu ra sử dụng phần mở rộng `.bin` chung; thay đổi nó để phù hợp với loại media được báo cáo khi cần.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **Câu hỏi thường gặp**

**Tham số phát lại video nào có thể được thay đổi cho khung video?**

Bạn có thể kiểm soát [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (tự động hoặc khi nhấn) và [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Các tùy chọn này có sẵn thông qua các thuộc tính của đối tượng [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân được bao gồm trong tài liệu, do đó kích thước bản trình bày tăng tỷ lệ với kích thước tệp. Khi bạn liên kết tới video trực tuyến và thêm hình thu nhỏ, bản trình bày chỉ lưu liên kết và ảnh preview thay vì dữ liệu video, nên tăng kích thước thường ít hơn.

**Tôi có thể thay thế video trong khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể hoán đổi [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) trong khung trong khi giữ nguyên hình học của shape; đây là kịch bản phổ biến để cập nhật media trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Video được nhúng có một [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó ra đĩa.