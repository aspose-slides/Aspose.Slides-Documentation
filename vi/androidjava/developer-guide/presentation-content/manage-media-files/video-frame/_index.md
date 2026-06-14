---
title: Quản lý Khung Video trong Bản trình chiếu trên Android
linktitle: Khung Video
type: docs
weight: 10
url: /vi/androidjava/video-frame/
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
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm và trích xuất khung video một cách lập trình trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho Android qua Java. Hướng dẫn nhanh gọn."
---
## **Giới thiệu**

Một video được đặt đúng chỗ trong bài thuyết trình có thể làm cho thông điệp của bạn hấp dẫn hơn và tăng mức độ tương tác với khán giả.

PowerPoint cho phép bạn thêm video vào một slide trong bản trình chiếu theo hai cách:

* Thêm hoặc nhúng video cục bộ (được lưu trên máy của bạn)
* Thêm video trực tuyến (từ nguồn web như YouTube).

Để cho phép bạn thêm video (đối tượng video) vào bản trình chiếu, Aspose.Slides cung cấp giao diện [IVideo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivideo/) , giao diện [IVideoFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivideoframe/) và các kiểu liên quan khác.

## **Tạo Khung Video Nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình chiếu.

1. Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation)class.
1. Lấy tham chiếu đến slide thông qua chỉ số của nó.
1. Thêm một đối tượng [IVideo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivideo/) và truyền đường dẫn tệp video để nhúng video vào bản trình chiếu.
1. Thêm một đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivideoframe/) để tạo khung cho video.
1. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã Java này cho bạn thấy cách thêm video được lưu cục bộ vào bản trình chiếu:

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Tải video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Lấy slide đầu tiên và thêm một khung video
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Lưu bản trình chiếu vào đĩa
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Ngoài ra, bạn có thể thêm video bằng cách truyền đường dẫn tệp của nó trực tiếp vào phương thức [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) method:

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

Microsoft [PowerPoint 2013 và các phiên bản mới hơn](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) hỗ trợ video YouTube trong bản trình chiếu. Nếu video bạn muốn sử dụng có sẵn trực tuyến (ví dụ trên YouTube), bạn có thể thêm nó vào bản trình chiếu qua liên kết web.

1. Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation)class
1. Lấy tham chiếu đến slide thông qua chỉ số của nó.
1. Thêm một đối tượng [IVideo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivideo/) và truyền liên kết tới video.
1. Đặt hình thu nhỏ cho khung video.
1. Lưu bản trình chiếu.

Đoạn mã Java này cho bạn thấy cách thêm video từ web vào một slide trong bản trình chiếu PowerPoint:

```java
// Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
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

## **Quản Lý Phụ Đề Video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bản trình chiếu PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy cập thông qua phương thức [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Thêm Phụ Đề vào Khung Video**

Để thêm phụ đề vào khung video:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) class.
1. Thêm một video vào bản trình chiếu.
1. Thêm một đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivideoframe/) vào slide.
1. Sử dụng [ICaptionsCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icaptionscollection/) trả về bởi [getCaptionTracks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) để thêm một track phụ đề WebVTT.
1. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã sau cho bạn thấy cách thêm phụ đề vào khung video:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
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

Giao diện [ICaptionsCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icaptionscollection/) cũng cung cấp một phương thức overload cho phép bạn thêm phụ đề từ một luồng.

**Trích Xuất Phụ Đề từ Khung Video**

Để trích xuất phụ đề từ khung video:

1. Tải bản trình chiếu chứa video.
2. Tìm đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivideoframe/) mục tiêu.
3. Duyệt qua các track phụ đề trả về bởi [getCaptionTracks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
4. Lưu mỗi track phụ đề vào tệp `.vtt`.

Đoạn mã sau cho bạn thấy cách trích xuất phụ đề từ khung video:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Lưu track phụ đề vào tệp WebVTT.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Mỗi đối tượng [ICaptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icaptions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và dữ liệu phụ đề dưới dạng chuỗi UTF-8.

**Xóa Phụ Đề khỏi Khung Video**

Để xóa phụ đề khỏi khung video:

1. Tải bản trình chiếu chứa video.
2. Lấy đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivideoframe/) mục tiêu.
3. Xóa các track phụ đề khỏi bộ sưu tập trả về bởi [getCaptionTracks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
4. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã sau cho bạn thấy cách xóa tất cả phụ đề khỏi khung video:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Xóa tất cả phụ đề khỏi khung video.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu bạn cần xóa chỉ một track phụ đề, sử dụng các phương thức [remove](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) hoặc [removeAt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) thay vì [clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icaptionscollection/#clear--) .

## **Trích Xuất Video từ Slide**

Bên cạnh việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản trình chiếu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) class để tải bản trình chiếu chứa video.
2. Duyệt qua tất cả các đối tượng [ISlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/).
3. Duyệt qua tất cả các đối tượng [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/) để tìm một [VideoFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/videoframe/).
4. Lưu video vào đĩa.

Đoạn mã Java này cho bạn thấy cách trích xuất video trên một slide của bản trình chiếu:

```java
// Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu 
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

                //Lấy phần mở rộng tệp
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

**Tham số phát lại video nào có thể được thay đổi cho VideoFrame?**

Bạn có thể kiểm soát [chế độ phát lại](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (tự động hoặc khi nhấp) và [lặp lại](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Các tùy chọn này có sẵn thông qua các thuộc tính của đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/videoframe/) .

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân sẽ được bao gồm trong tài liệu, do đó kích thước bản trình chiếu tăng tỷ lệ với kích thước tệp. Khi bạn thêm video trực tuyến, chỉ một liên kết và hình thu nhỏ được nhúng, vì vậy mức tăng kích thước sẽ nhỏ hơn.

**Tôi có thể thay thế video trong VideoFrame hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể thay đổi nội dung [video](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) trong khung mà vẫn giữ nguyên hình học của hình dạng; đây là một kịch bản phổ biến để cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video nhúng không?**

Có. Video được nhúng có một [loại nội dung](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/video/#getContentType--) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó vào đĩa.