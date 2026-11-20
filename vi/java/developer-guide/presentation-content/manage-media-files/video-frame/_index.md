---
title: Quản lý khung video trong bản trình chiếu bằng Java
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
- bản trình chiếu
- Java
- Aspose.Slides
description: "Học cách thêm và trích xuất khung video một cách lập trình trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho Java. Hướng dẫn nhanh và thực tiễn."
---
## **Giới thiệu**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides for Java cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát lại, quản lý phụ đề và trích xuất dữ liệu video được nhúng.

PowerPoint hỗ trợ video cục bộ và liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Để đại diện cho dữ liệu video và khung video, Aspose.Slides cung cấp giao diện [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/), giao diện [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) và các kiểu liên quan khác.

## **Tạo Khung Video Được Nhúng**

Nếu tệp video mà bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bản thuyết trình.

Ví dụ này nhúng một video cục bộ vào slide đầu tiên của một bản thuyết trình hiện có và lưu kết quả. Tọa độ và kích thước khung được tính bằng điểm. Luồng (stream) vẫn mở cho đến khi lưu hoàn tất vì [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) giữ nó ở trạng thái khóa trong khi bản thuyết trình đang sử dụng.

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

Bạn cũng có thể truyền trực tiếp đường dẫn video cục bộ vào [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Ví dụ này nhúng video vào slide đầu tiên của một bản thuyết trình mới. Video phải vẫn khả dụng cho tới khi bản thuyết trình được lưu.

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

## **Tạo Khung Video Với Video Từ Nguồn Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong bản thuyết trình. Bạn có thể tạo một khung video liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Ví dụ này thêm liên kết và hình thu nhỏ của video YouTube vào slide đầu tiên. Thay đổi định danh video để sử dụng video khác. Phương thức [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) yêu cầu phát tự động. Tải hình thu nhỏ và phát video yêu cầu kết nối internet. Trình xem bản thuyết trình cũng phải hỗ trợ phát video trực tuyến.

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

Trong một bản thuyết trình đào tạo, bạn có thể phát bản demo phần mềm ở chế độ toàn màn hình để khán giả nhìn thấy chi tiết. Gọi [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) với `true` để bật hành vi này trong quá trình phát.

Ví dụ này mở một bản thuyết trình, tìm khung [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) đầu tiên trên slide đầu và bật phát toàn màn hình. Bản thuyết trình đầu vào phải có ít nhất một slide chứa khung video hiện có trên slide đầu.

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

Phát toàn màn hình quyết định cách video được hiển thị. Riêng biệt, [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) kiểm soát việc video bắt đầu tự động hay khi nhấp, và [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) kiểm soát việc lặp lại. Để chọn hành vi khởi đầu, đặt chế độ phát thành [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). Ví dụ này giữ nguyên các thiết lập khởi đầu và vòng lặp hiện có.

## **Quay Lại Video Sau Khi Phát Xong**

Trong một bản thuyết trình đào tạo, việc đưa video demo trở lại đầu giúp người thuyết trình phát lại dễ dàng. Gọi [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) với `true` để đưa video về đầu sau khi phát xong.

Ví dụ này mở một bản thuyết trình, tìm khung [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) đầu tiên trên slide đầu và bật tính năng quay lại. Nó tắt vòng lặp để phát có thể kết thúc và đặt chế độ phát là khi nhấp. Bản thuyết trình đầu vào phải có ít nhất một slide chứa khung video hiện có trên slide đầu.

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

Quay lại đưa video về đầu mà không khởi động lại. Ngược lại, gọi [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) với `true` sẽ lặp lại phát tự động. Giữ vòng lặp tắt khi bạn muốn video kết thúc và sẵn sàng phát lại. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) độc lập kiểm soát khởi động tự động hay khi nhấp; ví dụ này sử dụng [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) để người thuyết trình kiểm soát thời điểm phát. Đặt chế độ phát sau khi thiết lập vòng lặp, như trong ví dụ. Quay lại hoạt động độc lập với [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Cắt Bớt Khung Video**

Sử dụng [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) và [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) để bỏ qua phần đầu hoặc cuối của video trong khi phát. Cả hai giá trị đều tính bằng mili giây. Cắt bớt thay đổi cài đặt phát mà không sửa đổi dữ liệu video được nhúng.

**Đặt Cài Đặt Cắt Bớt**

Ví dụ này nhúng một video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối trong quá trình phát. Sử dụng video dài hơn 3,5 giây để phần có thể phát còn lại.

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

Ví dụ này in ra các giá trị cắt bớt của khung video đầu tiên trên slide đầu, đơn vị là mili giây. Bản thuyết trình phải có ít nhất một slide. Nếu slide đó không có khung video, sẽ không in gì. Ví dụ ở trên tạo ra các giá trị 2500 và 1000.

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

Aspose.Slides cho phép bạn quản lý phụ đề đóng (closed captions) cho các khung video trong bản thuyết trình PowerPoint. Các phụ đề được lưu ở định dạng WebVTT và có thể truy cập thông qua phương thức [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

### **Thêm Phụ Đề Vào Khung Video**

Ví dụ này nhúng một video cục bộ và thêm một track phụ đề WebVTT mang nhãn English. Các dấu thời gian phụ đề phải khớp với video. Bản thuyết trình đã lưu sẽ bao gồm cả video và phụ đề của nó.

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

Giao diện [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng.

### **Trích Xuất Phụ Đề Từ Khung Video**

Ví dụ này lưu tất cả các track phụ đề từ các khung video trên slide đầu tiên thành các tệp WebVTT riêng biệt. Các số thứ tự liên tiếp giúp tệp đầu ra không trùng lặp. Bảng điều khiển console báo số lượng track đã trích xuất. Bản thuyết trình phải có ít nhất một slide.

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

Mỗi đối tượng [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và nội dung phụ đề dưới dạng chuỗi UTF-8.

### **Xóa Phụ Đề Khỏi Khung Video**

Ví dụ này xóa tất cả phụ đề khỏi khung video ở vị trí shape đầu tiên trên slide đầu và lưu kết quả. Nó giả định slide và shape tồn tại và shape là một khung video.

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

Nếu bạn chỉ muốn xóa một track phụ đề, hãy sử dụng các phương thức [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) hoặc [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) thay vì [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--) .

### **Tìm Kiếm Phụ Đề Video**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) trả về toàn bộ track WebVTT, bao gồm tiêu đề, các dòng thời gian và nội dung phụ đề. Bạn có thể tìm kiếm các cue trong bộ nhớ để tìm một cụm từ đã nói và thời gian của nó. Ví dụ, một track tiếng Anh trên slide 2 có thể chứa văn bản sau.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Ví dụ này mở `captioned_media.pptx` và sử dụng [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) để đọc các track của mỗi khung video cấp cao nhất trên mọi slide. Trong một cue dạng văn bản thuần, dòng thời gian chứa `-->`, và một dòng trống kết thúc cue. Khi phụ đề chứa “café” ở bất kỳ chữ cái nào, ví dụ sẽ in ra số slide, nhãn track, dòng thời gian gốc và toàn bộ phụ đề.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;
import java.util.StringJoiner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringJoiner caption = new StringJoiner(System.lineSeparator());
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            caption.add(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Tìm kiếm “café” cho ra một kết quả khớp cho track mẫu. Tìm kiếm bỏ qua tiêu đề track và giữ nguyên cài đặt thời gian trong kết quả.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Trích Xuất Video Từ Slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản thuyết trình.

Ví dụ này trích xuất các video được nhúng từ mọi slide thành các tệp nhị phân có số thứ tự riêng. Các video được liên kết sẽ bị bỏ qua vì chúng không có dữ liệu nhúng. Console in ra loại MIME của mỗi video và tổng số lượng. Đầu ra sử dụng phần mở rộng chung `.bin`; bạn có thể thay đổi nó để tương ứng với loại media khi cần.

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

## **FAQ**

**Tham số phát lại video nào có thể thay đổi cho một khung video?**

Bạn có thể kiểm soát [chế độ phát lại](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (tự động hoặc khi nhấp) và [việc lặp lại](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Các tùy chọn này có sẵn qua các phương thức của đối tượng [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) .

**Việc thêm video có ảnh hưởng đến kích thước file PPTX không?**

Có. Khi bạn nhúng một video cục bộ, dữ liệu nhị phân của video sẽ được đưa vào tài liệu, vì vậy kích thước bản thuyết trình tăng tỷ lệ với kích thước file video. Khi bạn liên kết tới video trực tuyến và thêm hình thu nhỏ, bản thuyết trình chỉ lưu liên kết và hình preview chứ không phải dữ liệu video, vì vậy kích thước tăng thường nhỏ hơn.

**Tôi có thể thay thế video trong một khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể hoán đổi [nội dung video](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) trong khung mà vẫn giữ nguyên hình dạng; đây là kịch bản phổ biến để cập nhật media trong bố cục đã có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Video được nhúng có một [loại nội dung](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó ra đĩa.