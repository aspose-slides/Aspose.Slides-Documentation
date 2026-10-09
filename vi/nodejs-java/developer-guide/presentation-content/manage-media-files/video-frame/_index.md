---
title: Quản lý khung video trong bản trình chiếu bằng Node.js
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
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Học cách lập trình để thêm và trích xuất khung video trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js qua Java. Hướng dẫn nhanh chóng."
---
## **Giới thiệu**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides cho Node.js qua Java cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát lại, quản lý phụ đề, và trích xuất dữ liệu video được nhúng.

PowerPoint hỗ trợ video cục bộ và liên kết tới video trực tuyến, chẳng hạn video trên YouTube.

Để biểu diễn dữ liệu video và khung video, Aspose.Slides cung cấp lớp [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) , lớp [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) , và các kiểu liên quan khác.

## **Tạo khung video được nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình chiếu của mình.

Ví dụ này nhúng video cục bộ vào slide đầu tiên của bản trình chiếu hiện có và lưu kết quả. Tọa độ và kích thước của khung được tính bằng điểm. Luồng dữ liệu vẫn mở cho đến khi lưu xong vì [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) giữ nó khóa trong khi bản trình chiếu sử dụng.

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

Bạn cũng có thể truyền đường dẫn video cục bộ trực tiếp tới [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Ví dụ này nhúng video vào slide đầu tiên của một bản trình chiếu mới. Video phải vẫn khả dụng cho đến khi bản trình chiếu được lưu.

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

## **Tạo khung video với video từ nguồn web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong bản trình chiếu. Bạn có thể tạo một khung video liên kết tới video trực tuyến, chẳng hạn video trên YouTube.

Ví dụ này thêm liên kết video YouTube và hình thu nhỏ vào slide đầu tiên. Thay thế định danh video để sử dụng video khác. Phương thức [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) yêu cầu phát lại tự động. Tải hình thu nhỏ và phát video yêu cầu kết nối internet. Trình xem bản trình chiếu cũng phải hỗ trợ phát video trực tuyến.

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

## **Phát video ở chế độ toàn màn hình**

Trong bản trình chiếu đào tạo, bạn có thể phát bản demo phần mềm ở chế độ toàn màn hình để khán giả nhìn rõ chi tiết. Gọi [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) với `true` để bật hành vi này khi phát.

Ví dụ này mở một bản trình chiếu, tìm [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) đầu tiên trên slide đầu tiên, và bật phát toàn màn hình. Bản trình chiếu đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

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

Phát toàn màn hình kiểm soát cách video được hiển thị. Riêng biệt, [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) kiểm soát việc video bắt đầu tự động hay khi nhấp, và [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) kiểm soát việc lặp lại. Để chọn hành vi khởi đầu, đặt chế độ phát thành [VideoPlayModePreset.Auto hoặc VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). Ví dụ này giữ nguyên các cài đặt khởi đầu và vòng lặp hiện có.

## **Quay lại video sau khi phát**

Trong bản trình chiếu đào tạo, đưa video demo trở lại đầu giúp người thuyết trình có thể phát lại. Gọi [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) với `true` để đưa video về đầu sau khi phát xong.

Ví dụ này mở một bản trình chiếu, tìm [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) đầu tiên trên slide đầu tiên, và bật tính năng quay lại. Nó tắt vòng lặp để phát có thể kết thúc và đặt phát bắt đầu khi nhấp. Bản trình chiếu đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

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

Quay lại đưa video về đầu mà không khởi động lại. Ngược lại, gọi [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) với `true` sẽ lặp lại phát tự động. Giữ vòng lặp tắt khi bạn muốn video kết thúc và sẵn sàng để phát lại. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) độc lập kiểm soát khởi động tự động hay khi nhấp; ví dụ này sử dụng [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) để người thuyết trình kiểm soát thời điểm bắt đầu phát. Đặt chế độ phát sau khi thiết lập vòng lặp, như trong ví dụ. Quay lại hoạt động độc lập với [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Cắt một khung video**

Sử dụng [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) và [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) để bỏ qua phần đầu hoặc cuối của video khi phát. Cả hai giá trị tính bằng mili giây. Việc cắt thay đổi cài đặt phát mà không sửa đổi dữ liệu video được nhúng.

**Cài đặt cắt**

Ví dụ này nhúng một video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối khi phát. Sử dụng video dài hơn 3,5 giây để còn lại một đoạn có thể phát được.

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

**Đọc cài đặt cắt**

Ví dụ này in ra các giá trị cắt của khung video đầu tiên trên slide đầu tiên tính bằng mili giây. Bản trình chiếu phải có ít nhất một slide. Nếu slide đó không có khung video, không có gì được in. Ví dụ trước tạo ra các giá trị 2500 và 1000.

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

## **Quản lý phụ đề video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho khung video trong bản trình chiếu PowerPoint. Phụ đề được lưu dưới định dạng WebVTT và được truy cập qua phương thức [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Thêm phụ đề vào khung video**

Ví dụ này nhúng một video cục bộ và thêm một track phụ đề WebVTT mang nhãn English. Các thời gian phụ đề nên khớp với video. Bản trình chiếu đã lưu bao gồm cả video và phụ đề của nó.

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

**Trích xuất phụ đề từ khung video**

Ví dụ này lưu tất cả các track phụ đề từ các khung video trên slide đầu tiên thành các tệp WebVTT riêng biệt. Các số thứ tự liên tiếp giúp các tệp đầu ra được phân biệt. Console báo số lượng track đã trích xuất. Bản trình chiếu phải có ít nhất một slide.

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

Mỗi đối tượng [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

**Xóa phụ đề khỏi khung video**

Ví dụ này xóa tất cả phụ đề khỏi khung video ở vị trí hình dạng đầu tiên trên slide đầu tiên và lưu kết quả. Nó giả định slide và hình dạng tồn tại và hình dạng là khung video.

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

Nếu bạn chỉ cần xóa một track phụ đề, hãy sử dụng các phương thức [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) hoặc [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) thay vì [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

## **Trích xuất video từ slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản trình chiếu.

Ví dụ này trích xuất video được nhúng từ mỗi slide thành các tệp nhị phân riêng biệt, được đánh số. Các video được liên kết sẽ bị bỏ qua vì không có dữ liệu nhúng. Console in ra loại MIME của mỗi video và tổng số. Đầu ra sử dụng phần mở rộng `.bin` chung; có thể đổi sang phần mở rộng phù hợp với loại media được báo cáo khi cần.

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

## **Câu hỏi thường gặp**

**Các tham số phát lại video nào có thể thay đổi cho một khung video?**

Bạn có thể kiểm soát [chế độ phát lại](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (tự động hoặc khi nhấp) và [vòng lặp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Các tùy chọn này có sẵn qua các phương thức của đối tượng [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân được bao gồm trong tài liệu, vì vậy kích thước bản trình chiếu tăng tương ứng với kích thước tệp. Khi bạn liên kết tới video trực tuyến và thêm hình thu nhỏ, bản trình chiếu chỉ lưu liên kết và ảnh xem trước thay vì dữ liệu video, do đó tăng kích thước thường ít hơn.

**Tôi có thể thay thế video trong một khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể hoán đổi [nội dung video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) trong khung đồng thời giữ nguyên hình dạng; đây là kịch bản phổ biến để cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Video được nhúng có một [loại nội dung](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó vào đĩa.