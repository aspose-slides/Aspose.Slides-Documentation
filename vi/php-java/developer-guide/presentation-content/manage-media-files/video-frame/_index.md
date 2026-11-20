---
title: Quản lý khung video trong bản trình chiếu bằng PHP
linktitle: Khung Video
type: docs
weight: 10
url: /vi/php-java/video-frame/
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
- PHP
- Aspose.Slides
description: "Học cách lập trình để thêm và trích xuất các khung video trong các slide PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho PHP thông qua Java. Hướng dẫn nhanh cách làm."
---
## **Giới thiệu**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides cho PHP thông qua Java cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát lại, quản lý phụ đề và trích xuất dữ liệu video được nhúng.

PowerPoint hỗ trợ video cục bộ và liên kết tới video trực tuyến, chẳng hạn video YouTube.

Để biểu diễn dữ liệu video và khung video, Aspose.Slides cung cấp lớp [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) , lớp [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) và các kiểu liên quan khác.

## **Tạo khung video nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình bày của mình.

Ví dụ này nhúng một video cục bộ vào slide đầu tiên của một bản trình bày hiện có và lưu kết quả. Tọa độ và kích thước khung được tính bằng điểm. Luồng dữ liệu vẫn mở cho đến khi lưu hoàn tất vì [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) giữ nó bị khóa trong khi bản trình bày sử dụng nó.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

Bạn cũng có thể truyền trực tiếp đường dẫn video cục bộ vào [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Ví dụ này nhúng video vào slide đầu tiên của một bản trình bày mới. Video phải còn truy cập được cho đến khi bản trình bày được lưu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tạo khung video với video từ nguồn web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong các bản trình bày. Bạn có thể tạo một khung video liên kết tới video trực tuyến, chẳng hạn video YouTube.

Ví dụ này thêm liên kết video YouTube và hình thu nhỏ vào slide đầu tiên. Thay thế định danh video để sử dụng video khác. Phương thức [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) yêu cầu phát tự động. Tải hình thu nhỏ và phát video cần có kết nối internet. Trình xem bản trình bày cũng phải hỗ trợ phát video trực tuyến.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Phát video ở chế độ toàn màn hình**

Trong bản trình bày đào tạo, bạn có thể phát bản demo phần mềm ở chế độ toàn màn hình để khán giả nhìn thấy chi tiết. Gọi [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) với `true` để bật hành vi này trong quá trình phát.

Ví dụ này mở một bản trình bày, tìm khung [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) đầu tiên trên slide đầu tiên, và bật phát toàn màn hình. Bản trình bày đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Phát toàn màn hình kiểm soát cách video được hiển thị. Độc lập với đó, [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) kiểm soát việc video bắt đầu tự động hay khi nhấp, và [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) kiểm soát việc lặp lại. Để chọn hành vi khởi động, đặt chế độ phát thành [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). Ví dụ giữ nguyên các thiết lập khởi động và vòng lặp hiện có.

## **Quay lại video sau khi phát**

Trong bản trình bày đào tạo, trả lại video demo về đầu giúp người thuyết trình có thể phát lại. Gọi [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) với `true` để đưa video về đầu sau khi phát xong.

Ví dụ này mở một bản trình bày, tìm khung [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) đầu tiên trên slide đầu tiên, và bật tính năng quay lại. Nó tắt vòng lặp để phát có thể kết thúc và đặt phát bắt đầu khi nhấp. Bản trình bày đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Quay lại đưa video về đầu mà không khởi động lại. Ngược lại, gọi [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) với `true` sẽ lặp lại phát tự động. Giữ vòng lặp tắt khi bạn muốn video kết thúc và sẵn sàng phát lại. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) độc lập kiểm soát khởi động tự động hay khi nhấp; ví dụ này sử dụng [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) để người thuyết trình kiểm soát thời điểm bắt đầu. Đặt chế độ phát sau khi thiết lập vòng lặp, như trong ví dụ. Quay lại hoạt động độc lập với [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Cắt khung video**

Sử dụng [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) và [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) để bỏ qua một phần đầu hoặc cuối của video khi phát. Cả hai giá trị tính bằng milliseconds. Việc cắt thay đổi cài đặt phát mà không thay đổi dữ liệu video được nhúng.

**Thiết lập cắt**

Ví dụ này nhúng một video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối khi phát. Sử dụng video dài hơn 3,5 giây để còn lại một đoạn có thể phát được.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Đọc cài đặt cắt**

Ví dụ này in ra các giá trị cắt của khung video đầu tiên trên slide đầu tiên tính bằng milliseconds. Bản trình bày phải chứa ít nhất một slide. Nếu slide đó không có khung video, sẽ không in gì. Ví dụ trước đó tạo ra các giá trị 2500 và 1000.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Quản lý phụ đề video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bản trình bày PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy xuất thông qua phương thức [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

### **Thêm phụ đề vào khung video**

Ví dụ này nhúng một video cục bộ và thêm một track phụ đề WebVTT mang nhãn English. Các dấu thời gian phụ đề phải khớp với video. Bản trình bày đã lưu sẽ bao gồm cả video và phụ đề của nó.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Lớp [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một stream.

### **Trích xuất phụ đề từ khung video**

Ví dụ này lưu tất cả các track phụ đề từ các khung video trên slide đầu tiên thành các tệp WebVTT riêng biệt. Các số thứ tự liên tiếp giữ cho các tệp đầu ra không trùng nhau. Console báo cáo số lượng track đã trích xuất. Bản trình bày phải chứa ít nhất một slide.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

Mỗi đối tượng [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) hiển thị định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

### **Xóa phụ đề khỏi khung video**

Ví dụ này xóa tất cả phụ đề khỏi khung video ở vị trí shape đầu tiên trên slide đầu tiên và lưu kết quả. Giả sử slide và shape tồn tại và shape là một khung video.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nếu bạn chỉ cần xóa một track phụ đề, hãy sử dụng các phương thức [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) hoặc [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) thay vì [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

### **Tìm kiếm phụ đề video**

[Captions::getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) trả về toàn bộ track WebVTT, bao gồm tiêu đề, các dòng thời gian và văn bản phụ đề. Bạn có thể tìm kiếm các cue trong bộ nhớ để tìm cụm từ nói và thời gian của nó. Ví dụ, một track tiếng Anh trên slide 2 có thể chứa văn bản sau.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Ví dụ mở `captioned_media.pptx` và sử dụng [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) để đọc các track của mỗi khung video cấp cao nhất trên mọi slide. Trong một cue dạng plain‑text, dòng thời gian chứa `-->`, và một dòng trống kết thúc cue. Khi phụ đề chứa “café” ở bất kỳ dạng chữ nào, ví dụ in ra số slide, nhãn track, dòng thời gian gốc và toàn bộ phụ đề.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("captioned_media.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                continue;
            }
            $trackCount = java_values($shape->getCaptionTracks()->getCount());
            for ($index = 0; $index < $trackCount; $index++) {
                $track = $shape->getCaptionTracks()->get_Item($index);
                $lines = preg_split('/\r\n|\n|\r/', java_values($track->getDataAsString()));
                $lineCount = count($lines);
                for ($i = 0; $i < $lineCount; $i++) {
                    $timing = $lines[$i];
                    if (strpos($timing, "-->") === false) {
                        continue;
                    }
                    $captionLines = [];
                    while (++$i < $lineCount && $lines[$i] !== "") {
                        $captionLines[] = $lines[$i];
                    }
                    $caption = implode("\n", $captionLines);
                    if (preg_match('/café/iu', $caption)) {
                        printf("Slide %d | %s | %s\n", java_values($slide->getSlideNumber()), java_values($track->getLabel()), $timing);
                        echo $caption, "\n";
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Tìm kiếm “café” cho ra một kết quả cho track mẫu. Việc tìm kiếm loại bỏ tiêu đề track và giữ nguyên cài đặt thời gian trong đầu ra.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Trích xuất video từ slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong các bản trình bày.

Ví dụ này trích xuất các video được nhúng từ mọi slide thành các tệp nhị phân riêng biệt, được đánh số. Các video được liên kết sẽ bị bỏ qua vì chúng không có dữ liệu nhúng. Console in ra MIME type của mỗi video và tổng số lượng. Đầu ra sử dụng phần mở rộng chung `.bin`; thay đổi nó để phù hợp với loại media được báo cáo khi cần.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Tham số phát lại video nào có thể được thay đổi cho một khung video?**

Bạn có thể kiểm soát [playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (tự động hoặc khi nhấp) và [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Các tùy chọn này có sẵn qua các phương thức của đối tượng [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng một video cục bộ, dữ liệu nhị phân được bao gồm trong tài liệu, do đó kích thước bản trình bày tăng tỷ lệ với kích thước tệp. Khi bạn liên kết tới video trực tuyến và thêm hình thu nhỏ, bản trình bày chỉ lưu liên kết và ảnh preview chứ không phải dữ liệu video, vì vậy tăng kích thước thường nhỏ hơn.

**Tôi có thể thay thế video trong một khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể thay đổi [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) bên trong khung trong khi giữ nguyên hình học của shape; đây là kịch bản phổ biến để cập nhật media trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Một video được nhúng có [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó ra đĩa.