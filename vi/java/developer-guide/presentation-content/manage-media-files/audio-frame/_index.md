---
title: Quản lý âm thanh trong bản trình chiếu bằng Java
linktitle: Khung Âm Thanh
type: docs
weight: 10
url: /vi/java/audio-frame/
keywords:
- âm thanh
- khung âm thanh
- hình thu nhỏ
- thêm âm thanh
- thuộc tính âm thanh
- tùy chọn âm thanh
- trích xuất âm thanh
- Java
- Aspose.Slides
description: "Tạo và điều khiển các khung âm thanh trong Aspose.Slides cho Java—các ví dụ mã để nhúng, cắt, lặp và cấu hình phát lại trên các bản trình chiếu PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với khung âm thanh trong Aspose.Slides. Nó cho thấy cách thêm âm thanh nhúng vào các trang trình chiếu, tùy chỉnh hình thu nhỏ của khung âm thanh, cấu hình các tùy chọn phát như âm lượng, lặp lại, ẩn, cắt và thời gian làm mờ, và trích xuất âm thanh được sử dụng trong các chuyển đổi trình chiếu.

## **Tạo khung âm thanh**

Aspose.Slides for Java cho phép bạn thêm các tệp âm thanh vào các trang trình chiếu. Các tệp âm thanh được nhúng vào các trang dưới dạng khung âm thanh. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một trang thông qua chỉ mục của nó.
3. Tải luồng tệp âm thanh mà bạn muốn nhúng vào trang.
4. Thêm khung âm thanh nhúng (chứa tệp âm thanh) vào trang.
5. Đặt [PlayMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/AudioPlayModePreset) và `Volume` được cung cấp bởi đối tượng [IAudioFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAudioFrame).
6. Lưu bản trình chiếu đã được chỉnh sửa.

Mã Java này cho bạn thấy cách thêm một khung âm thanh nhúng vào một trang:

```java
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Tải tệp âm thanh wav vào luồng
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Thêm Khung Âm Thanh
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Đặt chế độ phát và âm lượng cho âm thanh
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Ghi tệp PowerPoint ra đĩa
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay đổi hình thu nhỏ của khung âm thanh**

Khi bạn thêm một tệp âm thanh vào bản trình chiếu, âm thanh sẽ xuất hiện dưới dạng khung với hình ảnh mặc định tiêu chuẩn (xem hình ảnh trong phần dưới). Bạn có thể thay đổi hình ảnh xem trước của khung âm thanh (đặt hình ảnh ưa thích của mình).

Mã Java này cho bạn thấy cách thay đổi hình thu nhỏ hoặc hình ảnh xem trước của một khung âm thanh:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một khung âm thanh vào slide với vị trí và kích thước được chỉ định.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Thêm một hình ảnh vào tài nguyên của bản trình chiếu.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Đặt hình ảnh cho khung âm thanh.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // Lưu bản trình chiếu đã chỉnh sửa vào đĩa
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Thay đổi tùy chọn phát âm thanh**

Aspose.Slides for Java cho phép bạn thay đổi các tùy chọn kiểm soát việc phát hoặc thuộc tính của âm thanh. Ví dụ, bạn có thể điều chỉnh âm lượng của âm thanh, đặt âm thanh phát theo vòng lặp, hoặc thậm chí ẩn biểu tượng âm thanh.

Bảng **Audio Options** trong Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** trong PowerPoint tương ứng với các thuộc tính [AudioFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/AudioFrame) của Aspose.Slides:

- **Start** danh sách thả xuống tương ứng với phương thức [AudioFrame.setPlayMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/audioframe/#setPlayMode-int-)
- **Volume** tương ứng với phương thức [AudioFrame.setVolume](https://reference.aspose.com/slides/vi/java/com.aspose.slides/audioframe/#setVolume-int-)
- **Play Across Slides** tương ứng với phương thức [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-)
- **Loop until Stopped** tương ứng với phương thức [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-)
- **Hide During Show** tương ứng với phương thức [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-)
- **Rewind after Playing** tương ứng với phương thức [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/vi/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-)

Các tùy chọn **Editing** trong PowerPoint tương ứng với các thuộc tính [AudioFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/AudioFrame) của Aspose.Slides:

- **Fade In** tương ứng với phương thức [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/audioframe/#setFadeInDuration-float-) 
- **Fade Out** tương ứng với phương thức [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-) 
- **Trim Audio Start Time** tương ứng với phương thức [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/audioframe/#setTrimFromStart-float-) 
- **Trim Audio End Time** có giá trị bằng tổng thời lượng âm thanh trừ giá trị của phương thức [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/vi/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-)

Bộ điều khiển **Volume** trong PowerPoint trên bảng điều khiển âm thanh tương ứng với phương thức [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Nó cho phép bạn thay đổi âm lượng âm thanh dưới dạng phần trăm.

Cách thay đổi các tùy chọn phát âm thanh:

1. [Сreate](#create-audio-frame) hoặc lấy khung âm thanh.
2. Đặt các giá trị mới cho các thuộc tính khung âm thanh mà bạn muốn điều chỉnh.
3. Lưu tệp PowerPoint đã được chỉnh sửa.

Mã Java này minh họa một thao tác trong đó các tùy chọn của âm thanh được điều chỉnh:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Lấy đối tượng AudioFrame shape
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Đặt chế độ phát thành phát khi nhấp
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Đặt âm lượng thành Low
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Đặt âm thanh phát trên toàn bộ các slide
    audioFrame.setPlayAcrossSlides(true);

    // Vô hiệu hoá vòng lặp cho âm thanh
    audioFrame.setPlayLoopMode(false);

    // Ẩn AudioFrame trong lúc trình chiếu
    audioFrame.setHideAtShowing(true);

    // Quay lại đầu âm thanh sau khi phát
    audioFrame.setRewindAudio(true);

    // Lưu tệp PowerPoint ra đĩa
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ví dụ Java này cho bạn thấy cách thêm một khung âm thanh mới với âm thanh nhúng, cắt nó và đặt thời gian làm mờ:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Đặt độ lệch bắt đầu cắt thành 1.5 giây
    audioFrame.setTrimFromStart(1500f);
    // Đặt độ lệch kết thúc cắt thành 2 giây
    audioFrame.setTrimFromEnd(2000f);

    // Đặt thời gian làm mờ vào thành 200 ms
    audioFrame.setFadeInDuration(200f);
    // Đặt thời gian làm mờ ra thành 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Mã mẫu dưới đây cho bạn thấy cách lấy một khung âm thanh có âm thanh nhúng và đặt âm lượng thành 85%:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Lấy một shape khung âm thanh
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Đặt âm lượng âm thanh thành 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Quản lý phụ đề âm thanh**

Aspose.Slides cho phép bạn thêm phụ đề đóng vào một khung âm thanh thông qua phương thức [getCaptionTracks](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Phương thức này trả về một [ICaptionsCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/), cho phép bạn thêm các track phụ đề WebVTT, duyệt qua các track hiện có và xóa chúng khi cần.

**Thêm phụ đề âm thanh**

Sử dụng phương thức [getCaptionTracks](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) để gắn một hoặc nhiều track phụ đề vào một khung âm thanh. Trong ví dụ sau, một tệp âm thanh được thêm vào một trang, sau đó một track phụ đề mới được tải từ tệp `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Thêm một track phụ đề mới từ tệp WebVTT.
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Trích xuất phụ đề âm thanh**

Bạn có thể duyệt qua các track phụ đề liên quan đến một khung âm thanh và lưu chúng dưới dạng tệp `.vtt`. Mỗi track phụ đề cung cấp dữ liệu nhị phân và định danh duy nhất, có thể dùng khi xuất phụ đề.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Lưu track phụ đề dưới dạng tệp .vtt.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Xóa phụ đề âm thanh**

Để xóa phụ đề khỏi một khung âm thanh, sử dụng các phương thức được cung cấp bởi [ICaptionsCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/), như [clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), hoặc [removeAt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icaptionscollection/#removeAt-int-). Ví dụ dưới đây xóa tất cả các track phụ đề khỏi một khung âm thanh.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Xóa tất cả các track phụ đề khỏi khung âm thanh.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trích xuất âm thanh**

Aspose.Slides for Java cho phép bạn trích xuất âm thanh được dùng trong các chuyển đổi trình chiếu. Ví dụ, bạn có thể trích xuất âm thanh được dùng trong một slide cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) và tải bản trình chiếu chứa âm thanh.
2. Lấy tham chiếu của slide liên quan thông qua chỉ mục của nó.
3. Truy cập các [slideshow transitions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) cho slide đó.
4. Trích xuất âm thanh dưới dạng dữ liệu byte.

Mã Java này cho bạn thấy cách trích xuất âm thanh được dùng trong một slide:

```java
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Truy cập slide mong muốn
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lấy hiệu ứng chuyển đổi trình chiếu cho slide
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // Trích xuất âm thanh dưới dạng mảng byte
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể tái sử dụng cùng một tài nguyên âm thanh trên nhiều slide mà không làm tăng kích thước tệp không?**

Có. Thêm âm thanh một lần vào [audio collection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getAudios--) chung của bản trình chiếu và tạo các khung âm thanh bổ sung tham chiếu tới tài nguyên hiện có. Điều này tránh việc sao chép dữ liệu phương tiện và giữ kích thước bản trình chiếu trong tầm kiểm soát.

**Tôi có thể thay thế âm thanh trong một khung âm thanh hiện có mà không cần tạo lại shape không?**

Có. Đối với âm thanh liên kết, cập nhật [link path](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) để trỏ tới tệp mới. Đối với âm thanh nhúng, thay thế đối tượng [embedded audio](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) bằng một âm thanh khác từ [audio collection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getAudios--) của bản trình chiếu. Định dạng của khung và hầu hết các cài đặt phát vẫn giữ nguyên.

**Việc cắt bỏ có thay đổi dữ liệu âm thanh gốc được lưu trong bản trình chiếu không?**

Không. Việc cắt chỉ điều chỉnh giới hạn phát. Các byte âm thanh gốc vẫn không bị thay đổi và vẫn có thể truy cập thông qua âm thanh nhúng hoặc qua [audio collection] của bản trình chiếu.