---
title: Quản lý Khung Video trong Bài Thuyết Trình bằng Java
linktitle: Khung Video
type: docs
weight: 10
url: /vi/java/video-frame/
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
- Java
- Aspose.Slides
description: "Học cách thêm và trích xuất khung video một cách lập trình trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho Java. Hướng dẫn nhanh."
---
## **Giới thiệu**

Một video được đặt hợp lý trong bài thuyết trình có thể làm cho thông điệp của bạn trở nên thuyết phục hơn và tăng mức độ tương tác với khán giả.

PowerPoint cho phép bạn thêm video vào một slide trong bài thuyết trình theo hai cách:

* Thêm hoặc nhúng video cục bộ (được lưu trên máy của bạn)
* Thêm video trực tuyến (từ nguồn web như YouTube).

Để cho phép bạn thêm video (đối tượng video) vào bài thuyết trình, Aspose.Slides cung cấp giao diện [IVideo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideo/) , giao diện [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) và các kiểu liên quan khác. 

## **Tạo Khung Video Nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu cục bộ, bạn có thể tạo một khung video để nhúng video vào bài thuyết trình của mình. 

1. Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation)class.
1. Lấy tham chiếu tới slide thông qua chỉ mục của nó. 
1. Thêm một đối tượng [IVideo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideo/) và truyền đường dẫn tệp video để nhúng video vào bài thuyết trình. 
1. Thêm một đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) để tạo một khung cho video.  
1. Lưu bài thuyết trình đã chỉnh sửa. 

Đoạn mã Java này cho bạn thấy cách thêm video được lưu cục bộ vào một bài thuyết trình:

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Tải video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Lấy slide đầu tiên và thêm một khung video
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Lưu bài thuyết trình vào đĩa
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Ngoài ra, bạn có thể thêm video bằng cách truyền trực tiếp đường dẫn tệp của nó vào phương thức [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Tạo Khung Video với Video từ Nguồn Web**

Microsoft [PowerPoint 2013 và các phiên bản mới hơn](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) hỗ trợ video YouTube trong bài thuyết trình. Nếu video bạn muốn sử dụng có sẵn trực tuyến (ví dụ trên YouTube), bạn có thể thêm nó vào bài thuyết trình bằng liên kết web của nó. 

1. Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation)class
1. Lấy tham chiếu tới slide thông qua chỉ mục của nó. 
1. Thêm một đối tượng [IVideo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideo/) và truyền liên kết tới video.
1. Đặt ảnh thu nhỏ cho khung video. 
1. Lưu bài thuyết trình. 

Đoạn mã Java này cho bạn thấy cách thêm video từ web vào một slide trong bài thuyết trình PowerPoint:

```java
// Tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình 
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Thêm một khung video
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Tải ảnh thu nhỏ
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **Cắt một Khung Video**

Aspose.Slides cho phép bạn kiểm soát phần nào của video sẽ được phát bằng cách thiết lập các giá trị trim-from-start và trim-from-end thông qua [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) và [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Cả hai giá trị được chỉ định bằng mili giây và xác định khoảng thời gian bị bỏ qua ở đầu và cuối video, tương ứng. Các thiết lập này thay đổi cài đặt phát video trong bài thuyết trình; chúng không cắt hay sửa đổi dữ liệu nhị phân video đã nhúng.

**Đặt Cài Đặt Cắt**

Để tạo một khung video và thiết lập các cài đặt cắt:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Thêm một đối tượng [IVideo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideo/) vào bài thuyết trình.
1. Thêm một đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) vào một slide.
1. Thiết lập các giá trị trim-from-start và trim-from-end thông qua [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) và [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. Lưu bài thuyết trình đã chỉnh sửa.

Đoạn mã sau bỏ qua 2,5 giây đầu và 1 giây cuối của video đã nhúng khi phát:

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Đọc Cài Đặt Cắt**

Để kiểm tra các cài đặt cắt hiện có, tải một bài thuyết trình, tìm một đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) trong các hình trên slide đầu tiên, và đọc các giá trị thông qua [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) và [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

Đoạn mã sau tìm khung video đầu tiên trên slide đầu tiên và báo cáo cài đặt cắt của nó bằng mili giây:

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Quản Lý Phụ Đề Video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bài thuyết trình PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy cập thông qua phương thức [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Thêm Phụ Đề vào Khung Video**

Để thêm phụ đề vào khung video:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Thêm một video vào bài thuyết trình.
1. Thêm một đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) vào một slide.
1. Sử dụng [ICaptionsCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/) trả về bởi [getCaptionTracks](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) để thêm một track phụ đề WebVTT.
1. Lưu bài thuyết trình đã chỉnh sửa.

Đoạn mã dưới đây cho bạn thấy cách thêm phụ đề vào một khung video:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Thêm một track phụ đề mới từ tệp WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Giao diện [ICaptionsCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng.

**Trích Xuất Phụ Đề từ Khung Video**

Để trích xuất phụ đề từ một khung video:

1. Tải bài thuyết trình chứa video.
1. Tìm đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) mục tiêu.
1. Duyệt qua các track phụ đề trong [ICaptionsCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/).
1. Lưu mỗi track phụ đề vào tệp `.vtt`.

Đoạn mã dưới đây cho bạn thấy cách trích xuất phụ đề từ một khung video:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Lưu track phụ đề vào tệp WebVTT.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Mỗi đối tượng [ICaptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và nội dung phụ đề dưới dạng chuỗi UTF-8.

**Xóa Phụ Đề khỏi Khung Video**

Để xóa phụ đề khỏi một khung video:

1. Tải bài thuyết trình chứa video.
1. Lấy đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) mục tiêu.
1. Xóa các track phụ đề khỏi [ICaptionsCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/) .
1. Lưu bài thuyết trình đã chỉnh sửa.

Đoạn mã dưới đây cho bạn thấy cách xóa tất cả phụ đề khỏi một khung video:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Xóa tất cả phụ đề khỏi khung video.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu bạn chỉ cần xóa một track phụ đề, hãy sử dụng các phương thức [remove](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) hoặc [removeAt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/#removeAt-int-) thay vì [clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/#clear--) .

## **Trích Xuất Video từ Slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong các bài thuyết trình.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) để tải bài thuyết trình chứa video. 
2. Duyệt qua tất cả các đối tượng [ISlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/) .
3. Duyệt qua tất cả các đối tượng [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) để tìm một [VideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/videoframe/) . 
4. Lưu video vào đĩa.

Đoạn mã Java này cho bạn thấy cách trích xuất video trên một slide của bài thuyết trình:

```java
// Tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                //Lấy phần mở rộng của tệp
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu Hỏi Thường Gặp**

**Tham số phát video nào có thể thay đổi cho VideoFrame?**

Bạn có thể kiểm soát [chế độ phát](https://reference.aspose.com/slides/vi/java/com.aspose.slides/videoframe/#setPlayMode-int-) (tự động hoặc khi nhấp) và [vòng lặp](https://reference.aspose.com/slides/vi/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Những tùy chọn này có sẵn qua các thuộc tính của đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/videoframe/) .

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng một video cục bộ, dữ liệu nhị phân được bao gồm trong tài liệu, vì vậy kích thước bài thuyết trình tăng tỷ lệ với kích thước tệp. Khi bạn thêm một video trực tuyến, một liên kết và ảnh thu nhỏ được nhúng, vì vậy mức tăng kích thước là nhỏ hơn.

**Tôi có thể thay thế video trong một VideoFrame hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể hoán đổi [nội dung video](https://reference.aspose.com/slides/vi/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) trong khung mà vẫn giữ nguyên hình học của shape; đây là kịch bản thường gặp để cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video đã nhúng không?**

Có. Một video đã nhúng có một [loại nội dung](https://reference.aspose.com/slides/vi/java/com.aspose.slides/video/#getContentType--) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó vào đĩa.