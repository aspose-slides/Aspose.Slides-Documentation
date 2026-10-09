---
title: Quản lý các khung video trong bản trình bày bằng Java
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
- bản trình bày
- Java
- Aspose.Slides
description: "Học cách lập trình để thêm và trích xuất các khung video trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho Java. Hướng dẫn nhanh cách thực hiện."
---
## **Giới thiệu**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides for Java cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát lại, quản lý phụ đề và trích xuất dữ liệu video được nhúng.

PowerPoint hỗ trợ video cục bộ và liên kết đến video trực tuyến, chẳng hạn video YouTube.

Để đại diện cho dữ liệu video và khung video, Aspose.Slides cung cấp giao diện [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) , giao diện [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) và các kiểu liên quan khác.

## **Tạo một Khung Video Được Nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình bày của mình.

Ví dụ này nhúng video cục bộ vào slide đầu tiên của một bản trình bày hiện có và lưu kết quả. Tọa độ và kích thước khung tính bằng điểm. Luồng dữ liệu vẫn mở cho tới khi lưu xong vì [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) giữ nó bị khóa trong khi bản trình bày sử dụng nó.

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

Bạn cũng có thể truyền trực tiếp đường dẫn video cục bộ vào [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Ví dụ này nhúng video vào slide đầu tiên của một bản trình bày mới. Video phải vẫn khả dụng cho tới khi bản trình bày được lưu.

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

## **Tạo một Khung Video với Video từ Nguồn Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong các bản trình bày. Bạn có thể tạo một khung video liên kết tới video trực tuyến, chẳng hạn video YouTube.

Ví dụ này thêm liên kết video YouTube và hình thu nhỏ vào slide đầu tiên. Thay thế định danh video để sử dụng video khác. Phương pháp [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) yêu cầu phát tự động. Tải hình thu nhỏ và phát video đòi hỏi có kết nối internet. Trình xem bản trình bày cũng phải hỗ trợ phát video trực tuyến.

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

## **Phát Video ở Chế Độ Toàn Màn Hình**

Trong bản trình bày đào tạo, bạn có thể phát một bản demo phần mềm ở chế độ toàn màn hình để khán giả nhìn rõ chi tiết. Gọi [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) với `true` để bật hành vi này trong quá trình phát.

Ví dụ này mở một bản trình bày, tìm khung [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) đầu tiên trên slide đầu tiên, và bật phát toàn màn hình. Bản trình bày đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

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

Phát toàn màn hình kiểm soát cách video được hiển thị. Riêng biệt, [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) kiểm soát việc video bắt đầu tự động hay khi nhấp, và [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) kiểm soát việc lặp lại. Để chọn hành vi bắt đầu, đặt chế độ phát thành [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). Ví dụ giữ nguyên các cài đặt bắt đầu và lặp lại hiện có.

## **Quay Lại Video Sau Khi Phát**

Trong bản trình bày đào tạo, việc đưa video demo trở lại đầu giúp người thuyết trình có thể phát lại. Gọi [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) với `true` để đưa video về đầu sau khi phát xong.

Ví dụ này mở một bản trình bày, tìm khung [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) đầu tiên trên slide đầu tiên, và bật tính năng quay lại. Nó tắt vòng lặp để phát có thể kết thúc và đặt phát bắt đầu khi nhấp. Bản trình bày đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

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

Quay lại đưa video về đầu mà không khởi động lại. Ngược lại, gọi [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) với `true` sẽ lặp lại phát tự động. Giữ vòng lặp tắt khi bạn muốn video kết thúc và sẵn sàng phát lại. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) độc lập kiểm soát khởi động tự động hay khi nhấp; ví dụ này sử dụng [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) để người thuyết trình kiểm soát thời điểm bắt đầu phát. Đặt chế độ phát sau cài đặt vòng lặp, như trong ví dụ. Quay lại hoạt động độc lập với [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Cắt Bớt Khung Video**

Sử dụng [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) và [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) để bỏ qua phần đầu hoặc cuối của video trong khi phát. Cả hai giá trị đều tính bằng miligiây. Cắt bớt thay đổi cài đặt phát mà không thay đổi dữ liệu video được nhúng.

**Đặt Cài Đặt Cắt Bớt**

Ví dụ này nhúng video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối trong khi phát. Sử dụng video dài hơn 3,5 giây để còn lại đoạn có thể phát được.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Đọc Cài Đặt Cắt Bớt**

Ví dụ này in ra các giá trị cắt bớt của khung video đầu tiên trên slide đầu tiên tính bằng miligiây. Bản trình bày phải chứa ít nhất một slide. Nếu slide đó không có khung video, sẽ không in gì. Ví dụ trước tạo ra các giá trị 2500 và 1000.

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

## **Quản Lý Phụ Đề Video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho khung video trong các bản trình bày PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy cập qua phương pháp [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Thêm Phụ Đề vào Khung Video**

Ví dụ này nhúng video cục bộ và thêm một track phụ đề WebVTT có nhãn English. Các dấu thời gian phụ đề cần khớp với video. Bản trình bày đã lưu sẽ bao gồm cả video và phụ đề.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Giao diện [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ luồng dữ liệu.

**Trích Xuất Phụ Đề từ Khung Video**

Ví dụ này lưu tất cả các track phụ đề từ các khung video trên slide đầu tiên thành các tệp WebVTT riêng biệt. Các số thứ tự liên tiếp giữ cho các tệp đầu ra không trùng nhau. Bảng điều khiển hiển thị số lượng track đã trích xuất. Bản trình bày phải chứa ít nhất một slide.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Mỗi đối tượng [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) hiển thị định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

**Xóa Phụ Đề khỏi Khung Video**

Ví dụ này xóa tất cả phụ đề khỏi khung video ở vị trí hình dạng đầu tiên trên slide đầu tiên và lưu kết quả. Giả sử slide và hình dạng tồn tại và hình dạng là một khung video.

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

Nếu bạn chỉ cần xóa một track phụ đề, hãy sử dụng các phương pháp [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) hoặc [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) thay vì [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--) .

## **Trích Xuất Video từ Slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản trình bày.

Ví dụ này trích xuất các video nhúng từ mọi slide thành các tệp nhị phân riêng biệt, được đánh số. Video được liên kết sẽ bị bỏ qua vì không có dữ liệu nhúng. Bảng điều khiển in ra MIME type của mỗi video và tổng số. Đầu ra sử dụng phần mở rộng chung `.bin`; bạn có thể đổi thành phần mở rộng phù hợp với loại phương tiện được báo cáo khi cần.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
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

Bạn có thể kiểm soát [chế độ phát lại](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (tự động hoặc khi nhấp) và [vòng lặp](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Các tùy chọn này có sẵn qua các phương pháp của đối tượng [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) .

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân sẽ được đưa vào tài liệu, do đó kích thước bản trình bày tăng tỷ lệ với kích thước tệp video. Khi bạn liên kết đến video trực tuyến và thêm hình thu nhỏ, bản trình bày chỉ lưu liên kết và ảnh xem trước thay vì dữ liệu video, vì vậy mức tăng kích thước thường nhỏ hơn.

**Tôi có thể thay thế video trong một khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể hoán đổi [nội dung video](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) trong khung mà vẫn giữ nguyên hình dạng của nó; đây là kịch bản phổ biến để cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Video được nhúng có một [loại nội dung](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó vào đĩa.