---
title: Quản lý Khung Âm Thanh trong Bài Trình Bày trên Android
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
description: "Nhúng âm thanh vào slide, thay đổi biểu tượng âm thanh, cấu hình phát lại, quản lý phụ đề WebVTT và trích xuất âm thanh chuyển tiếp slide với Aspose.Slides for Android qua Java."
---
## **Tổng quan**

Một khung âm thanh cho phép bạn phát âm thanh trên một slide. Với Aspose.Slides for Android qua Java, bạn có thể nhúng một đoạn audio, chọn hình ảnh đại diện, điều chỉnh phát lại và đính kèm phụ đề. Bạn cũng có thể lấy âm thanh được gán cho chuyển tiếp slide.

## **Tạo Khung Âm Thanh**

Sử dụng [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) để nhúng một đoạn audio cục bộ vào slide đầu tiên. Hai tọa độ đầu tiên xác định vị trí khung trên slide, và hai giá trị tiếp theo đặt chiều rộng và chiều cao, tất cả tính bằng point. Ví dụ này gọi [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) để tự động bắt đầu phát và gọi [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) để chọn mức âm lượng lớn.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thay Đổi Hình Thu Nhỏ Khung Âm Thanh**

Mặc định, một khung âm thanh hiển thị biểu tượng loa. Để hiển thị hình thu nhỏ tùy chỉnh, thêm một hình ảnh vào bản trình bày bằng [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) và đặt nó vào hình ảnh của khung bằng [setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). Ví dụ sử dụng một JPEG làm hình thu nhỏ cho đoạn audio nhúng.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thay Đổi Tùy Chọn Phát Âm Thanh**

Các **Điều khiển Tuỳ chọn Âm thanh** của PowerPoint quyết định khi nào một đoạn bắt đầu, âm lượng, và cách nó hoạt động trong buổi trình chiếu.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Điều khiển PowerPoint | Phương thức Aspose.Slides for Android qua Java |
| --- | --- |
| Bắt đầu | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Cài đặt âm lượng | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Phát xuyên suốt các slide | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Lặp lại cho tới khi dừng | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Ẩn khi đang trình chiếu | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Quay lại sau khi phát | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Mờ dần vào | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Mờ dần ra | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Cắt thời gian bắt đầu | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Cắt thời gian kết thúc | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Thanh trượt âm lượng | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

Ví dụ tìm khung âm thanh đầu tiên trên slide đầu, gọi [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) để phát khi nhấp và chọn cài đặt âm lượng thấp. Đoạn âm sẽ tiếp tục qua các slide với vòng lặp bị tắt. Biểu tượng sẽ ẩn trong suốt buổi chiếu và đoạn âm sẽ quay lại sau khi phát xong.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Đối với đoạn dài hơn 3,5 giây, ví dụ này bỏ qua 1,5 giây đầu và 2 giây cuối. [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) nhận thời lượng cần loại bỏ ở cuối đoạn. Để lấy thời gian kết thúc hiển thị trong PowerPoint, lấy tổng thời lượng trừ đi phần bù này. Đoạn đã cắt sẽ mờ vào trong 200 ms và mờ ra trong 500 ms. Bốn phương thức này đều nhận giá trị tính bằng mili giây.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để đặt âm lượng phát lại ở một phần trăm cụ thể, sử dụng [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-). Ví dụ này đặt khung âm thanh đầu tiên trên slide đầu thành 85 %.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Quản Lý Phụ Đề Âm Thanh**

Mỗi khung âm thanh cung cấp quyền truy cập vào các track phụ đề của nó qua [getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). Dùng collection này để đính kèm phụ đề WebVTT cho đoạn, xuất các track hiện có, hoặc xóa chúng.

### **Thêm Phụ Đề Âm Thanh**

Ví dụ nhúng một đoạn audio vào slide đầu và dùng [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) để đính kèm một track WebVTT cục bộ. Đối số đầu cung cấp nhãn track, đối số thứ hai chỉ định tệp chứa phụ đề có thời gian.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Trích Xuất Phụ Đề Âm Thanh**

Ví dụ này xuất mỗi track phụ đề gắn vào khung âm thanh trên slide đầu. Nó ghi byte trả về bởi [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--) vào tệp WebVTT và dùng định danh trả về bởi [getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--) làm tên tệp để mỗi track có một tệp đầu ra riêng.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            try (FileOutputStream output = new FileOutputStream(track.getCaptionId() + ".vtt")) {
                output.write(track.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **Xóa Phụ Đề Âm Thanh**

Sử dụng [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) hoặc [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) để xóa một track riêng lẻ. Ví dụ dùng [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--) để xóa tất cả phụ đề khỏi khung âm thanh đầu tiên trên slide đầu trong khi vẫn giữ đoạn audio.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Tìm Dòng Trong Phụ Đề Âm Thanh**

Để tìm một dòng trong phụ đề âm thanh trên slide đầu, tìm kiếm trong chuỗi trả về bởi [getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) trong bộ nhớ. Trong một cue WebVTT dạng văn bản thuần, dòng thời gian chứa `-->`, các dòng phụ đề nằm sau đó, và một dòng trống kết thúc cue. Ví dụ này in nhãn track và mỗi dòng phụ đề chứa “café”.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\r\\n|\\r|\\n")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Trích Xuất Audio**

Một chuyển tiếp slide có thể có âm thanh riêng. Để lấy nó, gọi [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--) trên chuyển tiếp slide. Ví dụ truy cập byte trả về bởi [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) và in số byte. Nếu slide đầu không có âm thanh chuyển tiếp, nó sẽ in thông báo thay thế.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Tôi có thể tái sử dụng cùng một đoạn audio trên nhiều slide mà không sao chép lại không?**

Có. Thêm đoạn audio một lần vào [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) của bản trình bày và truyền cùng một đối tượng audio vào [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) cho mỗi slide.

**Tôi có thể thay thế âm thanh trong một khung audio hiện có không?**

Có. Đối với âm thanh liên kết, dùng [setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) để chỉ tới tệp thay thế. Đối với âm thanh nhúng, chọn một đoạn khác từ audio collection của bản trình bày bằng [setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). Cả hai cách đều giữ nguyên khung hiện tại.

**Việc cắt đoạn có thay đổi dữ liệu audio được lưu trong bản trình bày không?**

Không. [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) và [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) chỉ thiết lập ranh giới phát lại. Bạn vẫn có thể lấy đoạn đầy đủ từ [getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--).