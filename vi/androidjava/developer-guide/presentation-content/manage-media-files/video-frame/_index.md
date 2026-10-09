---
title: Quản lý các khung video trong bản trình bày trên Android
linktitle: Khung Video
type: docs
weight: 10
url: /vi/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Học cách thêm và trích xuất các khung video trong slide PowerPoint và OpenDocument một cách lập trình bằng Aspose.Slides cho Android qua Java. Hướng dẫn nhanh chóng."
---
## **Introduction**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides for Android qua Java cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát lại, quản lý phụ đề và trích xuất dữ liệu video được nhúng.

PowerPoint hỗ trợ video cục bộ và liên kết tới video trực tuyến, chẳng hạn video trên YouTube.

Để biểu diễn dữ liệu video và khung video, Aspose.Slides cung cấp giao diện [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) , giao diện [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) và các kiểu liên quan khác.

## **Create an Embedded Video Frame**

Nếu tệp video bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình bày của mình.

Ví dụ này nhúng một video cục bộ vào slide đầu tiên của bản trình bày hiện có và lưu kết quả. Tọa độ và kích thước của khung được tính bằng điểm. Luồng dữ liệu vẫn mở cho đến khi lưu hoàn tất vì [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) giữ nó khóa trong khi bản trình bày sử dụng nó.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể truyền đường dẫn video cục bộ trực tiếp vào [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Ví dụ này nhúng video vào slide đầu tiên của một bản trình bày mới. Video phải vẫn có thể truy cập được cho đến khi bản trình bày được lưu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Create a Video Frame with Video from a Web Source**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong bản trình bày. Bạn có thể tạo một khung video liên kết tới video trực tuyến, chẳng hạn video trên YouTube.

Ví dụ này thêm liên kết video YouTube và hình thu nhỏ vào slide đầu tiên. Thay thế định danh video để sử dụng video khác. Phương thức [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) yêu cầu phát tự động. Tải hình thu nhỏ và phát video yêu cầu có kết nối internet. Trình xem bản trình bày cũng phải hỗ trợ phát video trực tuyến.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Play a Video in Full-Screen Mode**

Trong bản trình bày đào tạo, bạn có thể phát bản demo phần mềm ở chế độ toàn màn hình để khán giả nhìn thấy chi tiết. Gọi [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) với `true` để bật hành vi này trong quá trình phát.

Ví dụ này mở một bản trình bày, tìm khung [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) đầu tiên trên slide đầu tiên và bật phát toàn màn hình. Bản trình bày đầu vào phải chứa ít nhất một slide có khung video tồn tại trên slide đầu tiên.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Phát toàn màn hình kiểm soát cách video được hiển thị. Riêng biệt, [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) kiểm soát việc video bắt đầu tự động hay khi nhấp, và [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) kiểm soát việc lặp lại. Để chọn hành vi bắt đầu, đặt chế độ phát thành [VideoPlayModePreset.Auto hoặc VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). Ví dụ này giữ nguyên các cài đặt bắt đầu và lặp lại hiện có.

## **Rewind a Video After Playback**

Trong bản trình bày đào tạo, đưa video demo trở lại đầu video giúp người thuyết trình có thể phát lại. Gọi [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) với `true` để đưa video về đầu sau khi phát xong.

Ví dụ này mở một bản trình bày, tìm khung [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) đầu tiên trên slide đầu tiên và bật tính năng quay lại. Nó tắt vòng lặp để phát có thể kết thúc và đặt chế độ phát bắt đầu khi nhấp. Bản trình bày đầu vào phải chứa ít nhất một slide có khung video tồn tại trên slide đầu tiên.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Quay lại đưa video về đầu mà không khởi động lại. Ngược lại, gọi [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) với `true` sẽ tự động lặp lại phát. Giữ vòng lặp tắt khi bạn muốn video kết thúc và sẵn sàng phát lại. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) độc lập kiểm soát khởi động tự động hoặc khi nhấp; ví dụ này sử dụng [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) để người thuyết trình kiểm soát thời điểm bắt đầu phát. Đặt chế độ phát sau khi cài đặt vòng lặp, như trong ví dụ. Quay lại hoạt động độc lập với [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Trim a Video Frame**

Sử dụng [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) và [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) để bỏ qua một phần đầu hoặc cuối của video trong khi phát. Cả hai giá trị đều tính bằng mili giây. Việc cắt bớt thay đổi cài đặt phát mà không sửa đổi dữ liệu video được nhúng.

**Đặt Cài Đặt Cắt**

Ví dụ này nhúng một video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối trong khi phát. Sử dụng video dài hơn 3,5 giây để còn lại đoạn có thể phát.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Đọc Cài Đặt Cắt**

Ví dụ này in ra các giá trị cắt của khung video đầu tiên trên slide đầu tiên tính bằng mili giây. Bản trình bày phải chứa ít nhất một slide. Nếu slide đó không có khung video, sẽ không in gì. Ví dụ trước tạo ra các giá trị 2500 và 1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Manage Video Captions**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bản trình bày PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy cập qua phương thức [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Thêm Phụ Đề vào Khung Video**

Ví dụ này nhúng một video cục bộ và thêm một track phụ đề WebVTT mang nhãn English. Các dấu thời gian phụ đề cần khớp với video. Bản trình bày đã lưu sẽ bao gồm cả video và phụ đề.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Giao diện [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng.

**Trích Xuất Phụ Đề từ Khung Video**

Ví dụ này lưu tất cả các track phụ đề từ các khung video trên slide đầu tiên thành các tệp WebVTT riêng biệt. Các số thứ tự giữ cho các tệp đầu ra khác nhau. Console báo cáo số lượng track đã trích xuất. Bản trình bày phải chứa ít nhất một slide.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Mỗi đối tượng [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

**Xóa Phụ Đề khỏi Khung Video**

Ví dụ này xóa tất cả phụ đề khỏi khung video ở vị trí shape đầu tiên trên slide đầu tiên và lưu kết quả. Nó giả định slide và shape tồn tại và shape là một khung video.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu bạn cần xóa chỉ một track phụ đề, hãy sử dụng các phương thức [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) hoặc [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) thay vì [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--).

## **Extract Video from a Slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản trình bày.

Ví dụ này trích xuất các video được nhúng từ mọi slide thành các tệp nhị phân riêng, được đánh số. Các video liên kết bị bỏ qua vì chúng không có dữ liệu nhúng. Console in ra MIME type của mỗi video và tổng số. Đầu ra sử dụng phần mở rộng `.bin` chung; thay đổi nó để phù hợp với loại phương tiện được báo cáo khi cần.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **Câu Hỏi Thường Gặp**

**Các tham số phát lại video nào có thể thay đổi cho một khung video?**

Bạn có thể kiểm soát [chế độ phát lại](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (tự động hoặc khi nhấp) và [việc lặp lại](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Các tùy chọn này có sẵn thông qua các phương thức của đối tượng [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng một video cục bộ, dữ liệu nhị phân được bao gồm trong tài liệu, do đó kích thước bản trình bày tăng tỷ lệ với kích thước tệp. Khi bạn liên kết tới video trực tuyến và thêm hình thu nhỏ, bản trình bày chỉ lưu liên kết và hình ảnh preview thay vì dữ liệu video, vì vậy mức tăng kích thước thường nhỏ hơn.

**Tôi có thể thay thế video trong một khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể thay đổi [nội dung video](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) bên trong khung trong khi giữ nguyên hình học của shape; đây là tình huống phổ biến để cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Video được nhúng có một [loại nội dung](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó vào đĩa.