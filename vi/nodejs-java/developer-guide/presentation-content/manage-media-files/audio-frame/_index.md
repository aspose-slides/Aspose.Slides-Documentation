---
title: Quản lý âm thanh trong bản trình chiếu bằng JavaScript
linktitle: Khung Âm Thanh
type: docs
weight: 10
url: /vi/nodejs-java/audio-frame/
keywords:
- âm thanh
- khung âm thanh
- ảnh thu nhỏ
- thêm âm thanh
- thuộc tính âm thanh
- tùy chọn âm thanh
- trích xuất âm thanh
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo và kiểm soát các khung âm thanh trong Aspose.Slides cho Node.js—ví dụ về nhúng, cắt, lặp và cấu hình phát lại cho các bản trình chiếu PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các khung âm thanh trong Aspose.Slides. Nó trình bày cách thêm âm thanh nhúng vào các slide, tùy chỉnh ảnh thu nhỏ của khung âm thanh, cấu hình các tùy chọn phát như âm lượng, lặp lại, ẩn, cắt và thời gian làm mờ, và trích xuất âm thanh được sử dụng trong chuyển đổi trình chiếu.

## **Tạo Khung Âm Thanh**

Aspose.Slides for Node.js via Java cho phép bạn thêm tệp âm thanh vào các slide. Các tệp âm thanh được nhúng vào slide dưới dạng khung âm thanh.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu đến một slide thông qua chỉ mục của nó.
3. Tải luồng tệp âm thanh mà bạn muốn nhúng vào slide.
4. Thêm khung âm thanh nhúng (chứa tệp âm thanh) vào slide.
5. Đặt [PlayMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AudioPlayModePreset) và `Volume` được cung cấp bởi đối tượng [AudioFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AudioFrame).
6. Lưu bản trình chiếu đã chỉnh sửa.

Mã JavaScript này cho bạn thấy cách thêm một khung âm thanh nhúng vào slide:

```javascript
// Khởi tạo một lớp Presentation đại diện cho tệp bản trình chiếu
const pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    const sld = pres.getSlides().get_Item(0);
    // Tải tệp âm thanh wav vào luồng
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Thêm Khung Âm Thanh
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Đặt Chế độ Phát và Âm lượng cho Âm thanh
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Ghi tệp PowerPoint ra đĩa
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thay Đổi Hình Thu Nhỏ Khung Âm Thanh**

Khi bạn thêm tệp âm thanh vào bản trình chiếu, âm thanh sẽ hiển thị dưới dạng một khung với hình ảnh mặc định tiêu chuẩn (xem hình ảnh trong phần bên dưới). Bạn có thể thay đổi hình ảnh trước xem của khung âm thanh (đặt hình ảnh bạn ưa thích).

Mã JavaScript này cho bạn thấy cách thay đổi ảnh thu nhỏ hoặc ảnh preview của khung âm thanh:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Thêm một khung âm thanh vào slide với vị trí và kích thước xác định.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Thêm một hình ảnh vào tài nguyên của bản trình chiếu.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Đặt hình ảnh cho khung âm thanh.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Lưu bản trình chiếu đã chỉnh sửa vào đĩa
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Thay Đổi Các Tùy Chọn Phát Âm Thanh**

Aspose.Slides for Node.js via Java cho phép bạn thay đổi các tùy chọn kiểm soát việc phát hoặc thuộc tính của âm thanh. Ví dụ, bạn có thể điều chỉnh âm lượng, đặt âm thanh phát theo vòng lặp, hoặc thậm chí ẩn biểu tượng âm thanh.

Bảng **Audio Options** trong Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Các **Audio Options** của PowerPoint tương ứng với các thuộc tính [AudioFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/) của Aspose.Slides:
- **Start**: danh sách thả xuống tương ứng với phương thức [AudioFrame.setPlayMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/#setPlayMode)
- **Volume**: tương ứng với phương thức [AudioFrame.setVolume](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides**: tương ứng với phương thức [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped**: tương ứng với phương thức [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show**: tương ứng với phương thức [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing**: tương ứng với phương thức [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/#setRewindAudio)

Các tùy chọn **Editing** của PowerPoint tương ứng với các thuộc tính [AudioFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/) của Aspose.Slides:

- **Fade In**: tương ứng với phương thức [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out**: tương ứng với phương thức [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time**: tương ứng với phương thức [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time**: giá trị bằng thời lượng âm thanh trừ đi giá trị của phương thức [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

Thanh điều khiển **Volume** trên bảng điều khiển âm thanh của PowerPoint tương ứng với phương thức [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Nó cho phép bạn thay đổi âm lượng âm thanh dưới dạng phần trăm.

Đây là cách bạn thay đổi các tùy chọn phát âm thanh:

1. [Create](#create-audio-frame) hoặc lấy Khung Âm Thanh.
2. Đặt các giá trị mới cho các thuộc tính Khung Âm Thanh mà bạn muốn điều chỉnh.
3. Lưu tệp PowerPoint đã chỉnh sửa.

Mã JavaScript này minh họa một thao tác trong đó các tùy chọn của âm thanh được điều chỉnh:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Lấy hình dạng AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Đặt chế độ phát là khi nhấp chuột
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Đặt âm lượng là Thấp
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Đặt âm thanh phát qua các slide
    audioFrame.setPlayAcrossSlides(true);
    // Vô hiệu hoá vòng lặp cho âm thanh
    audioFrame.setPlayLoopMode(false);
    // Ẩn AudioFrame trong khi trình chiếu
    audioFrame.setHideAtShowing(true);
    // Cuộn lại âm thanh về đầu sau khi phát
    audioFrame.setRewindAudio(true);
    // Lưu tệp PowerPoint vào đĩa
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ví dụ JavaScript này cho thấy cách thêm một khung âm thanh mới với âm thanh nhúng, cắt nó và đặt thời gian làm mờ:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Đặt thời gian bắt đầu cắt là 1.5 giây
    audioFrame.setTrimFromStart(1500);
    // Đặt thời gian kết thúc cắt là 2 giây
    audioFrame.setTrimFromEnd(2000);

    // Đặt thời lượng làm mờ vào là 200 ms
    audioFrame.setFadeInDuration(200);
    // Đặt thời lượng làm mờ ra là 500 ms
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Mẫu mã sau cho thấy cách lấy một khung âm thanh có âm thanh nhúng và đặt âm lượng thành 85%:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Lấy hình dạng khung âm thanh
    const audioFrame = slide.getShapes().get_Item(0);

    // Đặt âm lượng âm thanh thành 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Quản Lý Phụ Đề Âm Thanh**

Aspose.Slides cho phép bạn thêm phụ đề đóng vào khung âm thanh thông qua phương thức [getCaptionTracks](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Phương thức này trả về một [CaptionsCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captionscollection/), cho phép bạn thêm các track phụ đề WebVTT, duyệt qua các track hiện có và xóa chúng khi cần.

**Thêm Phụ Đề Âm Thanh**

Sử dụng phương thức [getCaptionTracks](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) để gắn một hoặc nhiều track phụ đề vào khung âm thanh. Trong ví dụ sau, một tệp âm thanh được thêm vào slide, sau đó một track phụ đề mới được tải từ tệp `.vtt`.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Thêm một track phụ đề mới từ tệp WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Trích Xuất Phụ Đề Âm Thanh**

Bạn có thể duyệt qua các track phụ đề liên kết với khung âm thanh và lưu chúng dưới dạng tệp `.vtt`. Mỗi track phụ đề cung cấp dữ liệu nhị phân và định danh duy nhất, có thể dùng khi xuất phụ đề.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // Lưu track phụ đề thành tệp .vtt.
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

**Xóa Phụ Đề Âm Thanh**

Để xóa phụ đề khỏi khung âm thanh, sử dụng các phương thức do [CaptionsCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captionscollection/) cung cấp, chẳng hạn như [clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captionscollection/#remove) hoặc [removeAt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/captionscollection/#removeAt). Ví dụ dưới đây xóa tất cả các track phụ đề khỏi khung âm thanh.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // loại: aspose.slides.AudioFrame

    // Xóa tất cả các track phụ đề khỏi khung âm thanh.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trích Xuất Âm Thanh**

Aspose.Slides for Node.js via Java cho phép bạn trích xuất âm thanh được sử dụng trong chuyển đổi trình chiếu. Ví dụ, bạn có thể trích xuất âm thanh được dùng trong một slide cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) và tải bản trình chiếu chứa âm thanh.
2. Lấy tham chiếu đến slide liên quan thông qua chỉ mục của nó.
3. Truy cập đến [slideshow transitions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) của slide.
4. Trích xuất âm thanh dưới dạng dữ liệu byte.

Mã JavaScript này cho bạn thấy cách trích xuất âm thanh được sử dụng trong một slide:

```javascript
// Khởi tạo một lớp Presentation đại diện cho tệp bản trình chiếu
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Truy cập slide mong muốn
    const slide = pres.getSlides().get_Item(0);
    // Lấy hiệu ứng chuyển đổi trình chiếu cho slide
    const transition = slide.getSlideShowTransition();
    // Trích xuất âm thanh dưới dạng mảng byte
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Tôi có thể tái sử dụng cùng một tài nguyên âm thanh trên nhiều slide mà không làm tăng kích thước tệp không?**

Có. Thêm âm thanh một lần vào [audio collection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getaudios/) chung của bản trình chiếu và tạo các khung âm thanh bổ sung tham chiếu tới tài nguyên đã tồn tại. Điều này tránh việc sao chép dữ liệu media và giữ kích thước bản trình chiếu trong mức kiểm soát.

**Tôi có thể thay thế âm thanh trong một khung âm thanh hiện có mà không cần tạo lại shape không?**

Có. Đối với âm thanh liên kết, cập nhật [link path](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) để trỏ tới tệp mới. Đối với âm thanh nhúng, hoán đổi đối tượng [embedded audio](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) bằng một đối tượng khác từ [audio collection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getaudios/) của bản trình chiếu. Định dạng khung và hầu hết các cài đặt phát vẫn được giữ nguyên.

**Việc cắt giảm (trimming) có thay đổi dữ liệu âm thanh gốc được lưu trong bản trình chiếu không?**

Không. Việc cắt giảm chỉ điều chỉnh ranh giới phát. Các byte âm thanh gốc vẫn không bị thay đổi và có thể truy cập thông qua âm thanh nhúng hoặc audio collection của bản trình chiếu.