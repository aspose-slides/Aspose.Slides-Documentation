---
title: Quản lý âm thanh trong bài thuyết trình trên Android
linktitle: Khung Âm Thanh
type: docs
weight: 10
url: /vi/androidjava/audio-frame/
keywords:
- âm thanh
- khung âm thanh
- hình thu nhỏ
- thêm âm thanh
- thuộc tính âm thanh
- tùy chọn âm thanh
- trích xuất âm thanh
- Android
- Java
- Aspose.Slides
description: "Tạo và điều khiển khung âm thanh trong Aspose.Slides cho Android—các ví dụ Java để nhúng, cắt, lặp và cấu hình phát lại trong các bài thuyết trình PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với khung âm thanh trong Aspose.Slides. Nó cho thấy cách thêm âm thanh nhúng vào các slide, tùy chỉnh hình thu nhỏ của khung âm thanh, cấu hình các tùy chọn phát như âm lượng, phát vòng, ẩn, cắt và thời gian mờ, và trích xuất âm thanh được sử dụng trong chuyển đổi trình chiếu.

## **Tạo Khung Âm Thanh**
Aspose.Slides cho Android qua Java cho phép bạn thêm tệp âm thanh vào các slide. Các tệp âm thanh được nhúng trong slide dưới dạng khung âm thanh.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ số của nó.
3. Tải luồng tệp âm thanh mà bạn muốn nhúng vào slide.
4. Thêm khung âm thanh nhúng (chứa tệp âm thanh) vào slide.
5. Đặt [PlayMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/AudioPlayModePreset) và `Volume` được cung cấp bởi đối tượng [IAudioFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAudioFrame).
6. Lưu bản trình bày đã chỉnh sửa.

Đoạn mã Java này cho bạn thấy cách thêm một khung âm thanh nhúng vào slide:

```java
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Tải tệp âm thanh wav vào luồng
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Thêm Khung Âm Thanh
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Đặt Chế độ Phát và Âm lượng cho Âm thanh
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Ghi tệp PowerPoint ra đĩa
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay Đổi Hình Thu Nhỏ Khung Âm Thanh**

Khi bạn thêm một tệp âm thanh vào bản trình bày, âm thanh sẽ hiển thị dưới dạng khung với hình ảnh mặc định tiêu chuẩn (xem hình ảnh trong phần bên dưới). Bạn có thể thay đổi hình ảnh xem trước của khung âm thanh (đặt hình ảnh ưa thích của mình).

Đoạn mã Java này cho bạn thấy cách thay đổi hình thu nhỏ hoặc hình xem trước của một khung âm thanh:

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

    //Lưu bản trình chiếu đã chỉnh sửa vào đĩa
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Thay Đổi Tùy Chọn Phát Âm Thanh**

Aspose.Slides cho Android qua Java cho phép bạn thay đổi các tùy chọn kiểm soát việc phát âm thanh hoặc các thuộc tính của nó. Ví dụ, bạn có thể điều chỉnh âm lượng, đặt âm thanh phát vòng, hoặc thậm chí ẩn biểu tượng âm thanh.

Bảng **Audio Options** trong Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Các **Audio Options** của PowerPoint tương ứng với các thuộc tính [AudioFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/AudioFrame) của Aspose.Slides:

- **Start** danh sách thả xuống khớp với thuộc tính [AudioFrame.PlayMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Volume** khớp với thuộc tính [AudioFrame.Volume](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Play Across Slides** khớp với thuộc tính [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Loop until Stopped** khớp với thuộc tính [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Hide During Show** khớp với thuộc tính [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Rewind after Playing** khớp với thuộc tính [AudioFrame.RewindAudio](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

Các tùy chọn **Editing** của PowerPoint tương ứng với các thuộc tính [AudioFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/audioframe/) của Aspose.Slides:

- **Fade In** khớp với thuộc tính [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Fade Out** khớp với thuộc tính [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Trim Audio Start Time** khớp với thuộc tính [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- **Trim Audio End Time** có giá trị bằng độ dài âm thanh trừ giá trị của [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

Bộ **Volume control** trên bảng điều khiển âm thanh của PowerPoint tương ứng với thuộc tính [AudioFrame.VolumeValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) . Nó cho phép bạn thay đổi âm lượng âm thanh dưới dạng phần trăm.

Đây là cách bạn thay đổi các tùy chọn phát âm thanh:

1. [Tạo](#create-audio-frame) hoặc lấy Khung Âm Thanh.
2. Đặt các giá trị mới cho các thuộc tính Khung Âm Thanh mà bạn muốn điều chỉnh.
3. Lưu tệp PowerPoint đã chỉnh sửa.

Đoạn mã Java này minh họa một thao tác điều chỉnh các tùy chọn của âm thanh:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Lấy hình dạng AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Đặt chế độ phát để phát khi nhấp
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Đặt âm lượng thành Thấp
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Đặt âm thanh phát xuyên suốt các slide
    audioFrame.setPlayAcrossSlides(true);

    // Tắt vòng lặp cho âm thanh
    audioFrame.setPlayLoopMode(false);

    // Ẩn AudioFrame trong suốt trình chiếu
    audioFrame.setHideAtShowing(true);

    // Quay lại đầu âm thanh sau khi phát
    audioFrame.setRewindAudio(true);

    // Lưu tệp PowerPoint vào đĩa
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ví dụ Java này cho thấy cách thêm một khung âm thanh mới với âm thanh nhúng, cắt nó và đặt thời gian mờ:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Đặt độ lệch bắt đầu cắt thành 1.5 giây
    audioFrame.setTrimFromStart(1500f);
    // Đặt độ lệch kết thúc cắt thành 2 giây
    audioFrame.setTrimFromEnd(2000f);

    // Đặt thời lượng mờ vào thành 200 ms
    audioFrame.setFadeInDuration(200f);
    // Đặt thời lượng mờ ra thành 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Mẫu mã sau đây cho thấy cách lấy một khung âm thanh có âm thanh nhúng và đặt âm lượng thành 85%:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Lấy hình dạng khung âm thanh
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Đặt âm lượng âm thanh thành 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Quản Lý Phụ Đề Âm Thanh**

Aspose.Slides cho phép bạn thêm phụ đề đóng vào một khung âm thanh thông qua phương thức [getCaptionTracks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) . Phương thức này trả về một [ICaptionsCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icaptionscollection/) , cho phép bạn thêm các track phụ đề WebVTT, duyệt qua các track hiện có và xóa chúng khi cần.

**Thêm Phụ Đề Âm Thanh**

Sử dụng phương thức [getCaptionTracks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) để gắn một hoặc nhiều track phụ đề vào khung âm thanh. Trong ví dụ sau, một tệp âm thanh được thêm vào slide, sau đó một track phụ đề mới được tải từ tệp `.vtt` .

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

**Trích Xuất Phụ Đề Âm Thanh**

Bạn có thể duyệt qua các track phụ đề liên kết với khung âm thanh và lưu chúng dưới dạng tệp `.vtt`. Mỗi track phụ đề cung cấp dữ liệu nhị phân và định danh duy nhất, có thể dùng khi xuất phụ đề.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Lưu track phụ đề dưới dạng tệp .vtt.
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

**Xóa Phụ Đề Âm Thanh**

Để xóa phụ đề khỏi khung âm thanh, sử dụng các phương thức do [ICaptionsCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icaptionscollection/) cung cấp, chẳng hạn [clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), hoặc [removeAt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-). Ví dụ dưới đây xóa tất cả các track phụ đề khỏi một khung âm thanh.

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

## **Trích Xuất Âm Thanh**

Aspose.Slides cho Android qua Java cho phép bạn trích xuất âm thanh được sử dụng trong chuyển đổi trình chiếu. Ví dụ, bạn có thể trích xuất âm thanh được dùng trong một slide cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) và tải bản trình bày chứa âm thanh.
2. Lấy tham chiếu của slide liên quan thông qua chỉ số của nó.
3. Truy cập các [slideshow transitions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) của slide.
4. Trích xuất âm thanh dưới dạng dữ liệu byte.

Đoạn mã Java này cho bạn thấy cách trích xuất âm thanh được sử dụng trong một slide:

```java
// Khởi tạo một lớp Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Truy cập slide mong muốn
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lấy các hiệu ứng chuyển đổi trình chiếu cho slide
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Trích xuất âm thanh dưới dạng mảng byte
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu Hỏi Thường Gặp**

**Tôi có thể tái sử dụng cùng một tài nguyên âm thanh trên nhiều slide mà không làm tăng kích thước tệp không?**

Có. Thêm âm thanh một lần vào [audio collection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getAudios--) chung của bản trình bày và tạo thêm các khung âm thanh tham chiếu tới tài nguyên đã tồn tại. Điều này tránh sao chép dữ liệu media và giữ kích thước bản trình bày trong mức kiểm soát.

**Tôi có thể thay thế âm thanh trong một khung âm thanh hiện có mà không cần tạo lại shape không?**

Có. Đối với âm thanh được liên kết, cập nhật [link path](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) để trỏ tới tệp mới. Đối với âm thanh được nhúng, thay thế đối tượng [embedded audio](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) bằng một âm thanh khác từ [audio collection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getAudios--) của bản trình bày. Định dạng khung và hầu hết cài đặt phát vẫn nguyên vẹn.

**Việc cắt âm thanh có thay đổi dữ liệu âm thanh gốc lưu trong bản trình bày không?**

Không. Việc cắt chỉ điều chỉnh giới hạn phát. Dữ liệu âm thanh gốc vẫn không bị thay đổi và có thể truy cập qua audio nhúng hoặc bộ sưu tập âm thanh của bản trình bày.