---
title: Quản lý Khung Video trong Bản Trình Chiếu bằng .NET
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
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thêm và trích xuất khung video một cách lập trình trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Hướng dẫn nhanh chóng."
---
## **Giới thiệu**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides for .NET cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát lại, quản lý phụ đề và trích xuất dữ liệu video được nhúng.

PowerPoint hỗ trợ video cục bộ và liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Để đại diện cho dữ liệu video và khung video, Aspose.Slides cung cấp giao diện [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) giao diện [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) và các kiểu liên quan khác.

## **Tạo Khung Video Được Nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình chiếu của mình.

Ví dụ này nhúng video cục bộ vào slide đầu tiên của một bản trình chiếu hiện có và lưu kết quả. Tọa độ và kích thước của khung tính bằng điểm. Luồng vẫn mở cho đến khi lưu hoàn tất vì [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) giữ nó bị khóa trong khi bản trình chiếu đang sử dụng.

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

Bạn cũng có thể truyền đường dẫn video cục bộ trực tiếp vào [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Ví dụ này nhúng video vào slide đầu tiên của một bản trình chiếu mới. Video phải vẫn có thể truy cập được cho tới khi bản trình chiếu được lưu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Đặt Âm Lượng Video Một Cách Chính Xác**

Trong Aspose.Slides for .NET 26.11 trở lên, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) đặt phần trăm dạng số thực từ 0 đến 100. Sử dụng nó khi các cài đặt sẵn [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) quá thô. Ví dụ, `75.5f` yêu cầu âm lượng 75,5%.

Ví dụ này yêu cầu [Aspose.Slides for .NET](/slides/vi/net/installation/) 26.11 trở lên và một tệp `video.mp4` cục bộ. Nó nhúng video, khởi tạo phát lại một cách rõ ràng, lưu bản trình chiếu và đọc lại phần trăm đã lưu.

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

Hãy tự kiểm tra đầu vào; không dựa vào setter để từ chối các giá trị ngoài phạm vi được tài liệu mô tả. Các cài đặt sẵn Low, Medium và Loud tương ứng với 20, 50 và 80 trong phiên bản 26.11. Đặt một cài đặt sẵn có thể ghi đè phần trăm trước đó, vì vậy hãy gán phần trăm cuối cùng khi bạn cần giá trị chính xác. Sử dụng [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) cho chế độ tắt tiếng rõ ràng; số không và enum cài đặt sẵn không thể hoán đổi cho nhau.

Hãy thiết lập rõ ràng [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) khi cấu hình video được liên kết, và giữ cho tệp media của nó có sẵn cho người xem. Lưu và mở lại xác nhận cài đặt đã lưu; việc phát lại thực tế và độ lớn âm thanh phụ thuộc vào trình phát bản trình chiếu và cài đặt âm thanh của nó.

## **Tạo Khung Video Với Video Từ Nguồn Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong bản trình chiếu. Bạn có thể tạo một khung video liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Ví dụ này thêm liên kết video YouTube và hình thu nhỏ vào slide đầu tiên. Thay thế định danh video để dùng video khác. Cài đặt [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) yêu cầu phát lại tự động. Tải hình thu nhỏ và phát video cần có kết nối internet. Trình xem bản trình chiếu cũng phải hỗ trợ phát video trực tuyến.

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

## **Phát Video ở Chế Độ Toàn Màn Hình**

Trong một bản trình chiếu đào tạo, bạn có thể phát bản trình diễn phần mềm ở chế độ toàn màn hình để khán giả có thể xem chi tiết. Đặt [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) thành `true` để kích hoạt hành vi này trong quá trình phát.

Ví dụ này mở một bản trình chiếu, tìm [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) đầu tiên trên slide đầu tiên, và bật phát toàn màn hình. Bản trình chiếu đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

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

Phát toàn màn hình kiểm soát cách video được hiển thị. Một cách độc lập, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) kiểm soát việc video bắt đầu tự động hay khi nhấp, và [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) kiểm soát việc lặp lại. Để chọn hành vi khởi động, đặt chế độ phát lại thành [VideoPlayModePreset.Auto hoặc VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Ví dụ giữ lại các cài đặt khởi động và vòng lặp hiện có.

## **Quay Lại Video Sau Khi Phát**

Trong một bản trình chiếu đào tạo, đưa video trình diễn trở lại đầu giúp người thuyết trình có thể phát lại. Đặt [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) thành `true` để trả video về đầu sau khi phát xong.

Ví dụ này mở một bản trình chiếu, tìm [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) đầu tiên trên slide đầu tiên, và bật tính năng quay lại. Nó tắt vòng lặp để phát có thể kết thúc và đặt phát lại bắt đầu khi nhấp. Bản trình chiếu đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

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

Quay lại trả video về đầu mà không khởi động lại. Ngược lại, bật [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) sẽ tự động lặp phát lại. Giữ vòng lặp tắt khi bạn muốn video kết thúc và sẵn sàng phát lại. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) độc lập kiểm soát khởi động tự động hay khi nhấp; ví dụ này sử dụng [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) để người thuyết trình kiểm soát thời điểm bắt đầu phát. Đặt chế độ phát sau khi đã thiết lập vòng lặp, như trong ví dụ. Quay lại hoạt động độc lập với [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Cắt Bớt Khung Video**

Sử dụng [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) và [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) để bỏ qua phần đầu hoặc cuối của video khi phát. Cả hai giá trị đều tính bằng miligiây. Việc cắt bớt thay đổi cài đặt phát lại mà không thay đổi dữ liệu video được nhúng.

**Cài Đặt Cắt Bớt**

Ví dụ này nhúng video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối khi phát. Sử dụng video dài hơn 3,5 giây để còn lại một đoạn có thể phát được.

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

**Đọc Cài Đặt Cắt Bớt**

Ví dụ này in ra các giá trị cắt bớt của khung video đầu tiên trên slide đầu tiên tính bằng miligiây. Bản trình chiếu phải chứa ít nhất một slide. Nếu slide đó không có khung video, sẽ không có gì được in. Ví dụ trước đó tạo ra các giá trị 2500 và 1000.

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

## **Quản Lý Phụ Đề Video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bản trình chiếu PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy cập qua thuộc tính [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

### **Thêm Phụ Đề Vào Khung Video**

Ví dụ này nhúng video cục bộ và thêm một track phụ đề WebVTT có nhãn English. Các dấu thời gian phụ đề nên khớp với video. Bản trình chiếu đã lưu bao gồm cả video và phụ đề của nó.

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

### **Trích Xuất Phụ Đề Từ Khung Video**

Ví dụ này lưu tất cả các track phụ đề từ các khung video trên slide đầu tiên thành các tệp WebVTT riêng biệt. Các số thứ tự liên tiếp giữ các tệp đầu ra riêng biệt. Console báo cáo số track đã được trích xuất. Bản trình chiếu phải chứa ít nhất một slide.

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

Mỗi đối tượng [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

### **Xóa Phụ Đề Khỏi Khung Video**

Ví dụ này xóa tất cả phụ đề khỏi khung video ở vị trí hình dạng đầu tiên trên slide đầu tiên và lưu kết quả. Nó giả định slide và hình dạng tồn tại và hình dạng đó là một khung video.

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

Nếu bạn chỉ cần xóa một track phụ đề, hãy sử dụng phương thức [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) hoặc [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) thay vì [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

### **Tìm Kiếm Phụ Đề Video**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) trả về toàn bộ track WebVTT, bao gồm phần đầu, các dòng thời gian và văn bản phụ đề. Để tìm một cụm từ được nói và dấu thời gian của nó, đọc các cue trong bộ nhớ. Ví dụ, một track tiếng Anh trên slide 2 có thể chứa văn bản sau:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Ví dụ duyệt từng slide và đọc các track của các khung video cấp cao nhất thông qua [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/). Trong một cue dạng văn bản thuần, dòng thời gian chứa `-->` và một dòng trống kết thúc cue. Khi văn bản phụ đề chứa “café”, ví dụ in ra số slide, nhãn track, dòng thời gian gốc và toàn bộ phụ đề.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

Tìm kiếm “café” tạo ra một kết quả trùng khớp cho track mẫu. Phần đầu và cài đặt thời gian nằm ngoài văn bản cue.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Trích Xuất Video Từ Slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản trình chiếu.

Ví dụ này trích xuất video được nhúng từ mọi slide vào các tệp nhị phân riêng biệt, đánh số. Các video được liên kết sẽ bị bỏ qua vì chúng không có dữ liệu nhúng. Console in ra loại MIME của mỗi video và tổng số. Đầu ra sử dụng phần mở rộng `.bin` chung; thay đổi nó để phù hợp với loại media được báo cáo khi cần.

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

## **FAQ**

**Các tham số phát lại video nào có thể được thay đổi cho một khung video?**

Bạn có thể kiểm soát [chế độ phát lại](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (tự động hoặc khi nhấp) và [vòng lặp](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Các tùy chọn này có sẵn thông qua thuộc tính của đối tượng [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân được đưa vào tài liệu, vì vậy kích thước bản trình chiếu tăng tỉ lệ với kích thước tệp. Khi bạn liên kết tới video trực tuyến và thêm hình thu nhỏ, bản trình chiếu lưu trữ liên kết và ảnh xem trước thay vì dữ liệu video, do đó tăng kích thước thường ít hơn.

**Tôi có thể thay thế video trong khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể hoán đổi [nội dung video](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) trong khung trong khi giữ nguyên hình học của shape; đây là một trường hợp phổ biến để cập nhật media trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Video được nhúng có một [loại nội dung](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó xuống đĩa.