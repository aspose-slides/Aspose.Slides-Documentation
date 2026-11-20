---
title: Quản lý Khung Video trong Bài Thuyết Trình bằng Node.js
linktitle: Khung Video
type: docs
weight: 10
url: /vi/nodejs-java/video-frame/
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
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách thêm và trích xuất các khung video một cách lập trình trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js qua Java. Hướng dẫn nhanh chóng."
---
## **Giới thiệu**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides cho Node.js thông qua Java cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát lại, quản lý phụ đề và trích xuất dữ liệu video nhúng.

PowerPoint hỗ trợ video cục bộ và các liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Để biểu diễn dữ liệu video và khung video, Aspose.Slides cung cấp lớp [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) , lớp [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) và các kiểu liên quan khác.

## **Tạo Khung Video Nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình chiếu của mình.

Ví dụ này nhúng một video cục bộ vào slide đầu tiên của bản trình chiếu hiện có và lưu kết quả. Tọa độ và kích thước khung được tính bằng điểm. Luồng vẫn mở cho đến khi lưu hoàn tất vì [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) giữ nó ở trạng thái khóa trong khi bản trình chiếu sử dụng nó.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể truyền đường dẫn video cục bộ trực tiếp tới [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Ví dụ này nhúng video vào slide đầu tiên của một bản trình chiếu mới. Video phải vẫn có thể truy cập được cho đến khi bản trình chiếu được lưu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tạo Khung Video với Video từ Nguồn Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong bản trình chiếu. Bạn có thể tạo một khung video có liên kết đến video trực tuyến, chẳng hạn như video trên YouTube.

Ví dụ này thêm liên kết video YouTube và hình thu nhỏ vào slide đầu tiên. Thay thế định danh video để sử dụng video khác. Phương thức [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) yêu cầu phát tự động. Tải xuống hình thu nhỏ và phát video cần có kết nối internet. Trình xem bản trình chiếu cũng phải hỗ trợ phát video trực tuyến.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Phát Video ở Chế Độ Toàn Màn Hình**

Trong một bản trình chiếu đào tạo, bạn có thể phát một bản trình diễn phần mềm ở chế độ toàn màn hình để khán giả nhìn rõ chi tiết. Gọi [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) với `true` để bật hành vi này trong quá trình phát.

Ví dụ này mở một bản trình chiếu, tìm khung [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) đầu tiên trên slide đầu tiên và bật phát toàn màn hình. Bản trình chiếu đầu vào phải có ít nhất một slide có sẵn khung video trên slide đầu tiên.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Phát toàn màn hình điều khiển cách video được hiển thị. Một cách độc lập, [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) điều khiển việc video bắt đầu tự động hay khi nhấp, và [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) điều khiển việc video lặp lại hay không. Để chọn hành vi khởi động, đặt chế độ phát thành [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). Ví dụ này giữ nguyên các cài đặt bắt đầu và vòng lặp hiện có.

## **Quay Lại Video Sau Khi Phát**

Trong một bản trình chiếu đào tạo, đưa video trình diễn trở lại đầu giúp người trình bày có thể phát lại. Gọi [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) với `true` để đưa video về đầu sau khi phát hoàn tất.

Ví dụ này mở một bản trình chiếu, tìm khung [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) đầu tiên trên slide đầu tiên và bật tính năng quay lại. Nó tắt vòng lặp để phát có thể kết thúc và đặt phát bắt đầu khi nhấp. Bản trình chiếu đầu vào phải có ít nhất một slide có sẵn khung video trên slide đầu tiên.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Quay lại đưa video về đầu mà không khởi động lại. Ngược lại, gọi [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) với `true` sẽ phát lại tự động. Giữ vòng lặp tắt khi bạn muốn video kết thúc và sẵn sàng phát lại. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) độc lập điều khiển khởi động tự động hay khi nhấp; ví dụ này sử dụng [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) để người thuyết trình kiểm soát thời điểm phát. Đặt chế độ phát sau khi cài đặt vòng lặp, như trong ví dụ. Quay lại hoạt động độc lập với [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Cắt Bớt Khung Video**

Sử dụng [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) và [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) để bỏ qua phần đầu hoặc cuối của video trong quá trình phát. Cả hai giá trị đều tính bằng mili giây. Việc cắt bớt thay đổi cài đặt phát mà không sửa đổi dữ liệu video nhúng.

**Đặt Cài Đặt Cắt Bớt**

Ví dụ này nhúng một video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối trong quá trình phát. Sử dụng video dài hơn 3,5 giây để còn lại đoạn có thể phát.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Đọc Cài Đặt Cắt Bớt**

Ví dụ này in ra các giá trị cắt bớt của khung video đầu tiên trên slide đầu tiên tính bằng mili giây. Bản trình chiếu phải có ít nhất một slide. Nếu slide đó không có khung video, sẽ không in gì. Ví dụ trước tạo ra các giá trị 2500 và 1000.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Quản Lý Phụ Đề Video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho khung video trong bản trình chiếu PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy cập thông qua phương thức [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

### **Thêm Phụ Đề vào Khung Video**

Ví dụ này nhúng một video cục bộ và thêm một track phụ đề WebVTT có nhãn English. Các dấu thời gian phụ đề cần khớp với video. Bản trình chiếu đã lưu bao gồm cả video và phụ đề của nó.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lớp [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) cũng cung cấp phương thức [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) để thêm phụ đề từ một luồng.

### **Trích Xuất Phụ Đề từ Khung Video**

Ví dụ này lưu tất cả các track phụ đề từ các khung video trên slide đầu tiên thành các tệp WebVTT riêng biệt. Các số thứ tự giữ cho các tệp đầu ra không trùng nhau. Bảng điều khiển báo số lượng track đã trích xuất. Bản trình chiếu phải có ít nhất một slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Mỗi đối tượng [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) hiển thị định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

### **Xóa Phụ Đề khỏi Khung Video**

Ví dụ này xóa tất cả phụ đề khỏi khung video tại vị trí hình dạng đầu tiên trên slide đầu tiên và lưu kết quả. Nó giả định slide và hình dạng tồn tại và hình dạng là một khung video.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu bạn cần xóa chỉ một track phụ đề, hãy sử dụng các phương thức [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) hoặc [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) thay vì [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

### **Tìm Kiếm Phụ Đề Video**

Phương thức [Captions.getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) trả về toàn bộ track WebVTT, bao gồm tiêu đề, các dòng thời gian và văn bản phụ đề. Bạn có thể tìm kiếm văn bản phụ đề trong bộ nhớ để tìm một cụm từ và dấu thời gian của nó. Ví dụ, một track tiếng Anh trên slide 2 có thể chứa đoạn cue này:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Ví dụ này mở `captioned_media.pptx` và dùng [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) để đọc các track của mỗi khung video cấp cao nhất trên mọi slide. Trong một cue dạng văn bản thuần, dòng thời gian chứa `-->`, và một dòng trống kết thúc cue. Đối với mỗi phụ đề chứa “café” ở bất kỳ dạng chữ nào, ví dụ in ra số slide, nhãn track, dòng thời gian gốc và toàn bộ phụ đề.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("captioned_media.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const shapes = slide.getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                continue;
            }

            const tracks = shape.getCaptionTracks();
            for (let trackIndex = 0; trackIndex < tracks.getCount(); trackIndex++) {
                const track = tracks.get_Item(trackIndex);
                const lines = track.getDataAsString().split(/\r\n|\n|\r/);
                for (let i = 0; i < lines.length; i++) {
                    const timing = lines[i];
                    if (!timing.includes("-->")) {
                        continue;
                    }
                    const start = i + 1;
                    i = start;
                    while (i < lines.length && lines[i] !== "") {
                        i++;
                    }
                    const caption = lines.slice(start, i).join("\n");
                    if (caption.toLowerCase().includes("café")) {
                        console.log(`Slide ${slide.getSlideNumber()} | ${track.getLabel()} | ${timing}`);
                        console.log(caption);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Tìm kiếm “café” tìm thấy một kết quả trong track mẫu. Việc tìm kiếm bỏ qua tiêu đề track và giữ nguyên cài đặt thời gian và dấu ngắt dòng trong đầu ra.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Trích Xuất Video từ Slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video nhúng trong bản trình chiếu.

Ví dụ này trích xuất video nhúng từ mọi slide thành các tệp nhị phân riêng biệt, đánh số. Video liên kết bị bỏ qua vì chúng không có dữ liệu nhúng. Bảng điều khiển in ra loại MIME của mỗi video và tổng số. Đầu ra sử dụng phần mở rộng chung `.bin`; thay đổi nó để khớp với loại phương tiện được báo khi cần.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **Câu Hỏi Thường Gặp**

**Các tham số phát lại video nào có thể thay đổi cho một khung video?**

Bạn có thể kiểm soát [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (tự động hoặc khi nhấp) và [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Các tùy chọn này có sẵn thông qua các phương thức của đối tượng [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân được bao gồm trong tài liệu, do đó kích thước bản trình chiếu tăng tỷ lệ với kích thước tệp. Khi bạn liên kết tới video trực tuyến và thêm hình thu nhỏ, bản trình chiếu chỉ lưu liên kết và hình ảnh xem trước thay vì dữ liệu video, vì vậy tăng kích thước thường nhỏ hơn.

**Tôi có thể thay thế video trong một khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể thay đổi [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) trong khung mà vẫn giữ nguyên hình dạng; đây là kịch bản thường gặp để cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video nhúng không?**

Có. Video nhúng có một [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó ra đĩa.