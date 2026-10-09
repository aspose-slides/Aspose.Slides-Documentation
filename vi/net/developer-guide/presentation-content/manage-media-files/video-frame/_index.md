---
title: Quản lý khung video trong bản trình chiếu bằng .NET
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
description: "Tìm hiểu cách thêm và trích xuất khung video một cách lập trình trong các slide PowerPoint và OpenDocument sử dụng Aspose.Slides cho .NET. Hướng dẫn nhanh."
---
## **Giới thiệu**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides for .NET cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát lại, quản lý phụ đề và trích xuất dữ liệu video được nhúng.

PowerPoint hỗ trợ video cục bộ và liên kết tới video trực tuyến, chẳng hạn như video YouTube.

Để biểu diễn dữ liệu video và khung video, Aspose.Slides cung cấp giao diện [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) , giao diện [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) và các kiểu liên quan khác.

## **Tạo Khung Video Nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình chiếu của mình.

Ví dụ này nhúng một video cục bộ vào slide đầu tiên của một bản trình chiếu hiện có và lưu kết quả. Tọa độ và kích thước của khung tính bằng điểm. Luồng vẫn mở cho đến khi lưu xong vì [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) giữ nó khóa trong khi bản trình chiếu sử dụng.

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

Bạn cũng có thể truyền đường dẫn video cục bộ trực tiếp cho [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Ví dụ này nhúng video vào slide đầu tiên của một bản trình chiếu mới. Video phải vẫn có thể truy cập được cho đến khi bản trình chiếu được lưu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Tạo Khung Video với Video từ Nguồn Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong bản trình chiếu. Bạn có thể tạo một khung video liên kết tới video trực tuyến, chẳng hạn như video YouTube.

Ví dụ này thêm liên kết video YouTube và ảnh thu nhỏ vào slide đầu tiên. Thay thế định danh video để sử dụng video khác. Cài đặt [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) yêu cầu phát tự động. Tải ảnh thu nhỏ và phát video cần có kết nối internet. Trình xem bản trình chiếu cũng phải hỗ trợ phát video trực tuyến.

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

Trong một bản trình chiếu đào tạo, bạn có thể phát bản demo phần mềm ở chế độ toàn màn hình để khán giả xem chi tiết. Đặt [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) thành `true` để bật hành vi này khi phát lại.

Ví dụ này mở một bản trình chiếu, tìm khung [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) đầu tiên trên slide đầu tiên, và bật phát toàn màn hình. Bản trình chiếu đầu vào phải có ít nhất một slide có khung video hiện có trên slide đầu tiên.

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

Phát toàn màn hình kiểm soát cách video được hiển thị. Tùy độc lập, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) điều khiển video có bắt đầu tự động hay khi nhấp, và [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) điều khiển việc video có lặp lại hay không. Để chọn hành vi khởi đầu, đặt chế độ phát thành [VideoPlayModePreset.Auto hoặc VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Ví dụ giữ nguyên các cài đặt khởi đầu và vòng lặp hiện có.

## **Quay Lại Video Sau Khi Phát**

Trong bản trình chiếu đào tạo, đưa video demo trở lại đầu giúp người thuyết trình có thể phát lại. Đặt [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) thành `true` để đưa video về đầu sau khi phát xong.

Ví dụ này mở một bản trình chiếu, tìm khung [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) đầu tiên trên slide đầu tiên, và bật tính năng quay lại. Nó tắt vòng lặp để phát có thể kết thúc và đặt phát bắt đầu khi nhấp. Bản trình chiếu đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

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

Quay lại đưa video về đầu mà không bắt đầu lại. Ngược lại, bật [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) sẽ tự động lặp lại phát. Giữ vòng lặp bị tắt khi bạn muốn video kết thúc và sẵn sàng phát lại. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) kiểm soát độc lập việc khởi động tự động hoặc khi nhấp; ví dụ này sử dụng [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) để người thuyết trình kiểm soát thời điểm bắt đầu phát. Đặt chế độ phát sau khi cài đặt vòng lặp, như trong ví dụ. Quay lại hoạt động độc lập với [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Cắt Đoạn Khung Video**

Sử dụng [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) và [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) để bỏ qua phần đầu hoặc cuối của video khi phát. Cả hai giá trị đều tính bằng mili giây. Việc cắt bớt thay đổi cài đặt phát lại mà không thay đổi dữ liệu video được nhúng.

**Đặt Cài Đặt Cắt**

Ví dụ này nhúng một video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối khi phát. Sử dụng video dài hơn 3,5 giây để còn lại một đoạn có thể phát được.

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

**Đọc Cài Đặt Cắt**

Ví dụ này in ra các giá trị cắt của khung video đầu tiên trên slide đầu tiên, tính bằng mili giây. Bản trình chiếu phải có ít nhất một slide. Nếu slide đó không có khung video, không có gì được in. Ví dụ trước đưa ra các giá trị 2500 và 1000.

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

**Thêm Phụ Đề vào Khung Video**

Ví dụ này nhúng một video cục bộ và thêm một track phụ đề WebVTT có nhãn English. Các dấu thời gian phụ đề nên khớp với video. Bản trình chiếu đã lưu bao gồm cả video và phụ đề.

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

**Trích Xuất Phụ Đề từ Khung Video**

Ví dụ này lưu tất cả các track phụ đề từ các khung video trên slide đầu tiên thành các tệp WebVTT riêng biệt. Các số thứ tự liên tiếp giữ cho các tệp đầu ra không trùng nhau. Console báo số lượng track đã trích xuất. Bản trình chiếu phải có ít nhất một slide.

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

Mỗi đối tượng [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và nội dung phụ đề dưới dạng chuỗi UTF-8.

**Xóa Phụ Đề khỏi Khung Video**

Ví dụ này xóa tất cả phụ đề khỏi khung video tại vị trí shape đầu tiên trên slide đầu tiên và lưu kết quả. Nó giả định rằng slide và shape tồn tại và shape đó là một khung video.

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

Nếu bạn chỉ cần xóa một track phụ đề, sử dụng phương thức [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) hoặc [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) thay vì [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Trích Xuất Video từ Slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản trình chiếu.

Ví dụ này trích xuất các video được nhúng từ mọi slide thành các tệp nhị phân riêng biệt, được đánh số. Các video liên kết bị bỏ qua vì không có dữ liệu nhúng. Console in ra MIME type của mỗi video và tổng số. Đầu ra sử dụng phần mở rộng `.bin` chung; thay đổi nó để phù hợp với loại phương tiện được báo cáo khi cần.

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

## **Câu Hỏi Thường Gặp**

**Các tham số phát lại video nào có thể thay đổi cho một khung video?**

Bạn có thể kiểm soát [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (tự động hoặc khi nhấp) và [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Các tùy chọn này khả dụng thông qua các thuộc tính của đối tượng [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Việc thêm video có làm tăng kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân sẽ được đưa vào tài liệu, vì vậy kích thước bản trình chiếu tăng tỷ lệ với kích thước tệp. Khi bạn liên kết tới video trực tuyến và thêm ảnh thu nhỏ, bản trình chiếu chỉ lưu liên kết và ảnh xem trước thay vì dữ liệu video, vì vậy mức tăng kích thước thường nhỏ hơn.

**Tôi có thể thay thế video trong một khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể thay thế [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) trong khung mà không thay đổi vị trí và kích thước của shape; đây là trường hợp thường gặp khi cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Video được nhúng có một [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó lên đĩa.