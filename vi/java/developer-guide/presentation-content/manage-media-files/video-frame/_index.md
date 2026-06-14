---
title: Quản lý các khung video trong bản thuyết trình bằng Java
linktitle: Khung Video
type: docs
weight: 10
url: /vi/java/video-frame/
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
- bản thuyết trình
- Java
- Aspose.Slides
description: "Học cách thêm và trích xuất các khung video trong slide PowerPoint và OpenDocument một cách lập trình bằng Aspose.Slides cho Java. Hướng dẫn nhanh chóng."
---
## **Giới thiệu**

Một video được đặt đúng chỗ trong bản thuyết trình có thể làm cho thông điệp của bạn hấp dẫn hơn và tăng mức độ tương tác với khán giả. 

PowerPoint cho phép bạn thêm video vào một slide trong bản thuyết trình theo hai cách:

* Thêm hoặc nhúng video cục bộ (được lưu trên máy của bạn)
* Thêm video trực tuyến (từ nguồn web như YouTube).

Để cho phép bạn thêm video (đối tượng video) vào bản thuyết trình, Aspose.Slides cung cấp giao diện [IVideo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideo/) , giao diện [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) và các kiểu liên quan khác. 

## **Tạo Khung Video Nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu cục bộ, bạn có thể tạo một khung video để nhúng video vào bản thuyết trình. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm đối tượng [IVideo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideo/) và truyền đường dẫn tệp video để nhúng video vào bản thuyết trình. 
4. Thêm đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) để tạo một khung cho video.  
5. Lưu bản thuyết trình đã sửa đổi. 

Đoạn mã Java này cho bạn thấy cách thêm video được lưu cục bộ vào bản thuyết trình:

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Tải video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Lấy slide đầu tiên và thêm một khung video
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Lưu bản thuyết trình vào ổ đĩa
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

Microsoft [PowerPoint 2013 và các phiên bản mới hơn](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) hỗ trợ video YouTube trong bản thuyết trình. Nếu video bạn muốn sử dụng có sẵn trực tuyến (ví dụ trên YouTube), bạn có thể thêm nó vào bản thuyết trình thông qua liên kết web của nó. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation)
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm đối tượng [IVideo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideo/) và truyền liên kết tới video.
4. Đặt ảnh thu nhỏ cho khung video. 
5. Lưu bản thuyết trình. 

Đoạn mã Java này cho bạn thấy cách thêm video từ web vào một slide trong bản thuyết trình PowerPoint:

```java
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bản thuyết trình 
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

## **Quản lý phụ đề video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bản thuyết trình PowerPoint. Các phụ đề được lưu ở định dạng WebVTT và được truy cập qua phương thức [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Thêm phụ đề vào khung video**

Để thêm phụ đề vào khung video:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Thêm video vào bản thuyết trình.
3. Thêm đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) vào slide.
4. Sử dụng [ICaptionsCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/) trả về bởi [getCaptionTracks](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) để thêm một track phụ đề WebVTT.
5. Lưu bản thuyết trình đã sửa đổi.

Đoạn mã sau cho bạn thấy cách thêm phụ đề vào khung video:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Thêm một track phụ đề mới từ tệp WebVTT.
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Giao diện [ICaptionsCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng.

**Trích xuất phụ đề từ khung video**

Để trích xuất phụ đề từ khung video:

1. Tải bản thuyết trình chứa video.
2. Tìm đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) mục tiêu.
3. Duyệt qua các track phụ đề trong [ICaptionsCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/) .
4. Lưu mỗi track phụ đề thành tệp `.vtt` .

Đoạn mã sau cho bạn thấy cách trích xuất phụ đề từ khung video:

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

Mỗi đối tượng [ICaptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

**Xóa phụ đề khỏi khung video**

Để xóa phụ đề khỏi khung video:

1. Tải bản thuyết trình chứa video.
2. Lấy đối tượng [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) mục tiêu.
3. Xóa các track phụ đề khỏi [ICaptionsCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/) .
4. Lưu bản thuyết trình đã sửa đổi.

Đoạn mã sau cho bạn thấy cách xóa tất cả phụ đề khỏi khung video:

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

Nếu bạn chỉ cần xóa một track phụ đề, hãy sử dụng phương thức [remove](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) hoặc [removeAt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/#removeAt-int-) thay vì [clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/#clear--) .

## **Trích xuất video từ slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản thuyết trình.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) để tải bản thuyết trình chứa video. 
2. Duyệt qua tất cả các đối tượng [ISlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/) .
3. Duyệt qua tất cả các đối tượng [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) để tìm một [VideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/videoframe/) . 
4. Lưu video vào ổ đĩa.

Đoạn mã Java này cho bạn thấy cách trích xuất video trên slide của bản thuyết trình:

```java
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bản thuyết trình 
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

## **Câu hỏi thường gặp**

**Tham số phát lại video nào có thể thay đổi cho VideoFrame?**

Bạn có thể điều khiển [playback mode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/videoframe/#setPlayMode-int-) (tự động hoặc khi nhấp) và [looping](https://reference.aspose.com/slides/vi/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) . Những tùy chọn này có sẵn qua các thuộc tính của đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/videoframe/) .

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân được đưa vào tài liệu, do đó kích thước bản thuyết trình tăng tỷ lệ với kích thước tệp. Khi bạn thêm video trực tuyến, một liên kết và ảnh thu nhỏ được nhúng, vì vậy mức tăng kích thước nhỏ hơn.

**Tôi có thể thay thế video trong VideoFrame hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể thay đổi nội dung [video](https://reference.aspose.com/slides/vi/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) trong khung mà vẫn giữ nguyên hình dạng; đây là một kịch bản phổ biến để cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Video được nhúng có một [content type](https://reference.aspose.com/slides/vi/java/com.aspose.slides/video/#getContentType--) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó vào ổ đĩa.