---
title: Quản lý khung video trong bài thuyết trình bằng JavaScript
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
description: "Học cách thêm và trích xuất khung video trong các slide PowerPoint và OpenDocument một cách lập trình bằng Aspose.Slides cho Node.js thông qua Java. Hướng dẫn nhanh chóng."
---
## **Giới thiệu**

Một video được đặt hợp lý trong bài thuyết trình có thể làm cho thông điệp của bạn hấp dẫn hơn và tăng mức độ tương tác với khán giả. 

PowerPoint cho phép bạn thêm video vào một slide trong bài thuyết trình theo hai cách:

* Thêm hoặc nhúng một video cục bộ (được lưu trên máy của bạn)
* Thêm một video trực tuyến (từ nguồn web như YouTube).

Để cho phép bạn thêm video (đối tượng video) vào bài thuyết trình, Aspose.Slides cung cấp lớp [Video](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/video/), lớp [VideoFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/) và các kiểu liên quan khác.

## **Tạo Khung Video Nhúng**

Nếu tệp video mà bạn muốn thêm vào slide được lưu cục bộ, bạn có thể tạo một khung video để nhúng video vào bài thuyết trình. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Lấy tham chiếu của một slide thông qua chỉ số của nó. 
1. Thêm một đối tượng [Video](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/video/) và truyền đường dẫn tệp video để nhúng video vào bài thuyết trình. 
1. Thêm một đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/) để tạo khung cho video. 
1. Lưu bài thuyết trình đã sửa đổi. 

Mã JavaScript sau đây cho bạn thấy cách thêm video được lưu cục bộ vào bài thuyết trình:

```javascript
// Khởi tạo lớp Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Tải video
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Lấy slide đầu tiên và thêm khung video
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Lưu bài thuyết trình ra đĩa
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Hoặc, bạn có thể thêm video bằng cách truyền trực tiếp đường dẫn tệp vào phương thức [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tạo Khung Video với Video từ Nguồn Web**

Microsoft [PowerPoint 2013 trở lên](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) hỗ trợ video YouTube trong các bài thuyết trình. Nếu video bạn muốn sử dụng có sẵn trực tuyến (ví dụ trên YouTube), bạn có thể thêm nó vào bài thuyết trình bằng liên kết web. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation)
1. Lấy tham chiếu của một slide thông qua chỉ số của nó. 
1. Thêm một đối tượng [Video](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/video/) và truyền liên kết tới video. 
1. Đặt ảnh thu nhỏ cho khung video. 
1. Lưu bài thuyết trình. 

Mã JavaScript dưới đây cho bạn thấy cách thêm video từ web vào một slide trong PowerPoint:

```javascript
// Khởi tạo một đối tượng Presentation đại diện cho một tệp trình chiếu
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **Cắt Một Khung Video**

Aspose.Slides cho phép bạn kiểm soát phần nào của video được phát bằng cách đặt giá trị trim-from-start và trim-from-end thông qua [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/settrimfromstart/) và [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/settrimfromend/). Cả hai giá trị đều được xác định bằng mili giây và xác định thời gian bị bỏ qua từ đầu và cuối video tương ứng. Các cài đặt này thay đổi cách phát video trong bài thuyết trình; chúng không cắt hay thay đổi dữ liệu nhị phân của video đã nhúng.

**Cài Đặt Cắt**

Để tạo một khung video và thiết lập các cài đặt cắt:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Thêm một đối tượng [Video](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/video/) vào bài thuyết trình.
1. Thêm một đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/) vào một slide.
1. Đặt giá trị trim-from-start và trim-from-end thông qua [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/settrimfromstart/) và [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/settrimfromend/).
1. Lưu bài thuyết trình đã sửa đổi.

Đoạn mã ví dụ dưới đây bỏ qua 2,5 giây đầu và 1 giây cuối của video được nhúng khi phát:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Đọc Cài Đặt Cắt**

Để kiểm tra các cài đặt cắt hiện có, tải một bài thuyết trình, tìm một đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/) trong các shape trên slide đầu tiên, và đọc giá trị thông qua [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) và [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/gettrimfromend/).

Đoạn mã ví dụ dưới đây tìm khung video đầu tiên trên slide đầu tiên và báo cáo các cài đặt cắt của nó bằng mili giây:

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Quản Lý Phụ Đề Video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bài thuyết trình PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy cập thông qua phương thức [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Thêm Phụ Đề vào Khung Video**

Để thêm phụ đề vào khung video:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Thêm một video vào bài thuyết trình.
1. Thêm một đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/) vào một slide.
1. Sử dụng bộ sưu tập [CaptionsCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captionscollection/) để thêm một track phụ đề WebVTT.
1. Lưu bài thuyết trình đã sửa đổi.

Mã sau đây cho bạn thấy cách thêm phụ đề vào khung video:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Thêm một track phụ đề mới từ tệp WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lớp [CaptionsCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captionscollection/) cũng cung cấp phương thức [addFromStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captionscollection/#addFromStream) cho phép bạn thêm phụ đề từ một luồng.

**Trích Xuất Phụ Đề từ Khung Video**

Để trích xuất phụ đề từ khung video:

1. Tải bài thuyết trình chứa video.
1. Tìm đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/) mục tiêu.
1. Duyệt qua bộ sưu tập [CaptionsCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captionscollection/).
1. Lưu mỗi track phụ đề vào tệp `.vtt`.

Mã dưới đây cho bạn thấy cách trích xuất phụ đề từ khung video:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // Lưu track phụ đề vào tệp WebVTT.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Mỗi đối tượng [Captions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

**Xóa Phụ Đề khỏi Khung Video**

Để xóa phụ đề khỏi khung video:

1. Tải bài thuyết trình chứa video.
1. Lấy đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/) mục tiêu.
1. Xóa các track phụ đề khỏi bộ sưu tập [CaptionsCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captionscollection/).
1. Lưu bài thuyết trình đã sửa đổi.

Mã dưới đây cho bạn thấy cách xóa tất cả phụ đề khỏi khung video:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // kiểu: com.aspose.slides.VideoFrame

    // Xóa tất cả phụ đề khỏi khung video.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu bạn chỉ cần xóa một track phụ đề, hãy sử dụng các phương thức [remove](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captionscollection/#remove) hoặc [removeAt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captionscollection/#removeAt) thay vì [clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captionscollection/#clear).

## **Trích Xuất Video Từ Slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bài thuyết trình.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) để tải bài thuyết trình chứa video.
2. Duyệt qua tất cả các đối tượng [Slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/).
3. Duyệt qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) để tìm một [VideoFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/).
4. Lưu video ra đĩa.

Mã JavaScript dưới đây cho bạn thấy cách trích xuất video trên một slide trong bài thuyết trình:

```javascript
// Khởi tạo một đối tượng Presentation đại diện cho một tệp trình chiếu
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // Lấy phần mở rộng tệp
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu Hỏi Thường Gặp**

**Các tham số phát video nào có thể được thay đổi cho VideoFrame?**

Bạn có thể kiểm soát [playback mode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/setplaymode/) (tự động hoặc khi click) và [looping](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Các tùy chọn này có sẵn qua các thuộc tính của đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/).

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng một video cục bộ, dữ liệu nhị phân được bao gồm trong tài liệu, vì vậy kích thước bài thuyết trình tăng tỷ lệ với kích thước tệp. Khi bạn thêm video trực tuyến, một liên kết và ảnh thu nhỏ được nhúng, nên tăng kích thước nhỏ hơn.

**Tôi có thể thay thế video trong VideoFrame hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể thay thế [video content](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) trong khung mà không thay đổi hình học của shape; đây là kịch bản phổ biến để cập nhật media trong bố cục hiện có.

**Có thể xác định kiểu nội dung (MIME) của video được nhúng không?**

Có. Một video được nhúng có [content type](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/video/getcontenttype/) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó ra đĩa.