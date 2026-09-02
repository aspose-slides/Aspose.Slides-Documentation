---
title: Quản lý khung video trong các bài thuyết trình trên .NET
linktitle: Khung Video
type: docs
weight: 10
url: /vi/net/video-frame/
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
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Học cách lập trình thêm và trích xuất khung video trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Hướng dẫn nhanh cách thực hiện."
---
## **Giới thiệu**

Một video được đặt đúng chỗ trong bài thuyết trình có thể làm thông điệp của bạn trở nên thuyết phục hơn và tăng mức độ tương tác với khán giả. 

PowerPoint cho phép bạn thêm video vào một slide trong bài thuyết trình theo hai cách:

* Thêm hoặc nhúng video cục bộ (lưu trên máy của bạn)
* Thêm video trực tuyến (từ nguồn web như YouTube).

Để cho phép bạn thêm video (đối tượng video) vào bài thuyết trình, Aspose.Slides cung cấp giao diện [IVideo](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideo/) , giao diện [IVideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/) , và các kiểu liên quan khác. 

## **Tạo Khung Video Nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu cục bộ, bạn có thể tạo một khung video để nhúng video vào bài thuyết trình. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm một đối tượng [IVideo](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideo/) và truyền đường dẫn tệp video để nhúng video vào bài thuyết trình. 
4. Thêm một đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/) để tạo khung cho video.  
5. Lưu bài thuyết trình đã chỉnh sửa. 

Đoạn mã C# sau cho bạn thấy cách thêm video được lưu cục bộ vào bài thuyết trình:

```c#
// Khởi tạo lớp Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Tải video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Lấy slide đầu tiên và thêm một khung video
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Lưu bài thuyết trình vào đĩa
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Ngoài ra, bạn có thể thêm video bằng cách truyền trực tiếp đường dẫn tệp vào phương thức [AddVideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addvideoframe/) :

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Tạo Khung Video với Video từ Nguồn Web**
Các phiên bản mới hơn của Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong bài thuyết trình. Nếu video bạn muốn sử dụng có sẵn trên mạng (ví dụ trên YouTube), bạn có thể thêm nó vào bài thuyết trình thông qua liên kết web.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm một đối tượng [IVideo](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideo/) và truyền liên kết tới video.
4. Đặt hình thu nhỏ cho khung video. 
5. Lưu bài thuyết trình. 

Đoạn mã C# sau cho bạn thấy cách thêm video từ web vào một slide trong bài thuyết trình PowerPoint:

```c#
public static void Run()
{
    // Khởi tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Thêm một VideoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Tải hình thu nhỏ
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Cắt Bớt Khung Video**

Aspose.Slides cho phép bạn kiểm soát phần nào của video sẽ được phát bằng cách đặt giá trị trim-from-start và trim-from-end thông qua [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/trimfromstart/) và [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/trimfromend/). Cả hai giá trị đều được chỉ định bằng mili giây và xác định thời lượng bỏ qua từ đầu và cuối video, tương ứng. Các cài đặt này thay đổi cách phát video trong bài thuyết trình; chúng không cắt hay thay đổi dữ liệu nhị phân của video đã nhúng.

**Đặt Cài Đặt Cắt Bớt**

Để tạo một khung video và đặt cài đặt cắt bớt:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Thêm một đối tượng [IVideo](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideo/) vào bài thuyết trình.
3. Thêm một đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/) vào một slide.
4. Đặt giá trị trim-from-start và trim-from-end thông qua [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/trimfromstart/) và [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/trimfromend/) .
5. Lưu bài thuyết trình đã chỉnh sửa.

Đoạn mã mẫu dưới đây bỏ qua 2,5 giây đầu và 1 giây cuối của video đã nhúng khi phát:

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Đọc Cài Đặt Cắt Bớt**

Để kiểm tra cài đặt cắt bớt hiện có, tải một bài thuyết trình, tìm đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/) trong các hình dạng trên slide đầu tiên, và đọc các giá trị thông qua [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/trimfromstart/) và [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/trimfromend/) .

Đoạn mã mẫu dưới đây tìm khung video đầu tiên trên slide đầu tiên và báo cáo cài đặt cắt bớt của nó bằng mili giây:

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **Quản Lý Phụ Đề Video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bài thuyết trình PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy cập thông qua thuộc tính [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/captiontracks/) .

**Thêm Phụ Đề vào Khung Video**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Thêm một video vào bài thuyết trình.
3. Thêm một đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/) vào một slide.
4. Sử dụng bộ sưu tập [CaptionTracks](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/captiontracks/) để thêm một track phụ đề WebVTT.
5. Lưu bài thuyết trình đã chỉnh sửa.

Đoạn mã sau cho bạn thấy cách thêm phụ đề vào khung video:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Thêm một track phụ đề mới từ tệp WebVTT.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

Giao diện [ICaptionsCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/icaptionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng.

**Trích Xuất Phụ Đề từ Khung Video**

1. Tải bài thuyết trình chứa video.
2. Tìm đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/) mục tiêu.
3. Duyệt qua bộ sưu tập [CaptionTracks](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/captiontracks/) .
4. Lưu mỗi track phụ đề vào tệp `.vtt` .

Đoạn mã sau cho bạn thấy cách trích xuất phụ đề từ khung video:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // Lưu track phụ đề vào tệp WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Mỗi đối tượng [ICaptions](https://reference.aspose.com/slides/vi/net/aspose.slides/icaptions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

**Xóa Phụ Đề khỏi Khung Video**

1. Tải bài thuyết trình chứa video.
2. Lấy đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/) mục tiêu.
3. Xóa các track phụ đề khỏi bộ sưu tập [CaptionTracks](https://reference.aspose.com/slides/vi/net/aspose.slides/ivideoframe/captiontracks/) .
4. Lưu bài thuyết trình đã chỉnh sửa.

Đoạn mã sau cho bạn thấy cách xóa tất cả phụ đề khỏi khung video:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Xóa toàn bộ phụ đề khỏi khung video.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Nếu bạn cần xóa chỉ một track phụ đề, hãy sử dụng phương thức [Remove](https://reference.aspose.com/slides/vi/net/aspose.slides/captionscollection/remove/) hoặc [RemoveAt](https://reference.aspose.com/slides/vi/net/aspose.slides/captionscollection/removeat/) thay vì [Clear](https://reference.aspose.com/slides/vi/net/aspose.slides/captionscollection/clear/) .

## **Trích Xuất Video từ Slide**
Bên cạnh việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video đã nhúng trong bài thuyết trình.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) để tải bài thuyết trình chứa video. 
2. Duyệt qua tất cả các đối tượng [ISlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide) .
3. Duyệt qua tất cả các đối tượng [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape) để tìm một [VideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/videoframe) . 
4. Lưu video vào đĩa.

Đoạn mã C# sau cho bạn thấy cách trích xuất video trên một slide của bài thuyết trình:

```c#
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình 
Presentation presentation = new Presentation("Video.pptx");

// Duyệt qua các slide
foreach (ISlide slide in presentation.Slides)
{
    // Duyệt qua các shape
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Lưu video vào đĩa khi tìm thấy VideoFrame chứa video
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

## **Câu hỏi thường gặp**

**Các tham số phát video nào có thể thay đổi cho VideoFrame?**

Bạn có thể kiểm soát [chế độ phát](https://reference.aspose.com/slides/vi/net/aspose.slides/videoframe/playmode/) (tự động hoặc khi nhấp) và [lặp lại](https://reference.aspose.com/slides/vi/net/aspose.slides/videoframe/playloopmode/) . Các tùy chọn này có sẵn qua các thuộc tính của đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/videoframe/) .

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân sẽ được bao gồm trong tài liệu, do đó kích thước bài thuyết trình tăng tỉ lệ với kích thước tệp. Khi bạn thêm video trực tuyến, một liên kết và hình thu nhỏ được nhúng, vì vậy mức tăng kích thước sẽ nhỏ hơn.

**Tôi có thể thay thế video trong VideoFrame hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể thay thế [nội dung video](https://reference.aspose.com/slides/vi/net/aspose.slides/videoframe/embeddedvideo/) trong khung mà vẫn giữ nguyên hình dạng; đây là trường hợp phổ biến để cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video đã nhúng không?**

Có. Video đã nhúng có một [loại nội dung](https://reference.aspose.com/slides/vi/net/aspose.slides/video/contenttype/) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó vào đĩa.