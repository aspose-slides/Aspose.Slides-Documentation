---
title: Quản lý khung âm thanh trong bản trình bày bằng JavaScript
linktitle: Khung âm thanh
type: docs
weight: 10
url: /vi/nodejs-java/audio-frame/
keywords:
- âm thanh
- khung âm thanh
- hình thu nhỏ
- thêm âm thanh
- thuộc tính âm thanh
- tùy chọn âm thanh
- trích xuất âm thanh
- Node.js
- JavaScript
- Aspose.Slides
description: "Nhúng âm thanh vào các slide, thay đổi biểu tượng âm thanh, cấu hình phát lại, quản lý phụ đề WebVTT và trích xuất âm thanh chuyển tiếp slide với Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Khung âm thanh cho phép bạn phát một âm thanh trên slide. Với Aspose.Slides for Node.js via Java, bạn có thể nhúng một đoạn âm thanh, chọn hình ảnh đại diện, điều chỉnh phát lại và đính kèm phụ đề. Bạn cũng có thể lấy âm thanh được gán cho chuyển tiếp slide.

## **Tạo khung âm thanh**

Sử dụng [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) để nhúng một đoạn âm thanh cục bộ vào slide đầu tiên. Hai tọa độ đầu tiên định vị khung trên slide, và hai giá trị tiếp theo đặt chiều rộng và chiều cao, tất cả tính bằng điểm. Ví dụ này gọi [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) để bắt đầu tự động và gọi [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) để chọn mức âm lớn.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
        audioFrame.setPlayMode(slides.AudioPlayModePreset.Auto);
        audioFrame.setVolume(slides.AudioVolumeMode.Loud);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameEmbed_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thay đổi hình thu nhỏ của khung âm thanh**

Mặc định, khung âm thanh hiển thị biểu tượng loa. Để hiển thị một hình thu nhỏ tùy chỉnh, thêm một hình ảnh vào bản trình bày bằng [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) và đặt nó cho ảnh của khung bằng [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage). Ví dụ sử dụng `eagle.jpeg` làm hình thu nhỏ cho đoạn âm thanh nhúng.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
        const imageStream = java.newInstanceSync("java.io.FileInputStream", "eagle.jpeg");
        try {
            const thumbnail = presentation.getImages().addImage(imageStream);
            audioFrame.getPictureFormat().getPicture().setImage(thumbnail);
        } finally {
            imageStream.close();
        }
    } finally {
        audioStream.close();
    }
    presentation.save("example_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thay đổi tùy chọn phát âm thanh**

Các điều khiển **Audio Options** của PowerPoint xác định khi nào một đoạn âm thanh bắt đầu, âm lượng của nó và cách nó hoạt động trong buổi trình chiếu.

![Điều khiển Audio Options của PowerPoint cho một khung âm thanh](audio_frame_0.png)

| Điều khiển PowerPoint | Phương thức Aspose.Slides for Node.js via Java |
| --- | --- |
| Bắt đầu | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Cài đặt âm lượng | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Phát trên các slide | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Lặp lại cho đến khi dừng | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Ẩn trong khi trình chiếu | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Quay lại sau khi phát | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| Mờ dần vào | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Mờ dần ra | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Cắt thời gian bắt đầu âm thanh | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Cắt thời gian kết thúc âm thanh | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Thanh trượt âm lượng | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

Ví dụ tìm khung âm thanh đầu tiên trên slide đầu tiên, gọi [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) để bắt đầu phát khi nhấp và chọn cài đặt âm lượng thấp. Đoạn âm thanh tiếp tục qua các slide với vòng lặp bị tắt. Biểu tượng được ẩn trong buổi trình chiếu và đoạn âm thanh quay lại sau khi phát.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setPlayMode(slides.AudioPlayModePreset.OnClick);
        audioFrame.setVolume(slides.AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Đối với đoạn âm thanh dài hơn 3,5 giây, ví dụ này bỏ qua 1,5 giây đầu và 2 giây cuối. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) nhận thời lượng cần loại bỏ ở cuối đoạn. Để lấy thời gian kết thúc hiển thị trong PowerPoint, lấy tổng thời lượng trừ đi độ lệch này. Đoạn âm thanh đã cắt sẽ mờ dần vào trong 200 ms và mờ dần ra trong 500 ms. Bốn phương thức này đều nhận giá trị tính bằng mili giây.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
        audioFrame.setTrimFromStart(1500);
        audioFrame.setTrimFromEnd(2000);
        audioFrame.setFadeInDuration(200);
        audioFrame.setFadeOutDuration(500);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameTrimFade_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để đặt âm lượng phát lại ở một phần trăm cụ thể, sử dụng [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Ví dụ này đặt khung âm thanh đầu tiên trên slide đầu tiên ở mức 85 %.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setVolumeValue(85);
        presentation.save("AudioFrameValue_out.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Quản lý phụ đề âm thanh**

Mỗi khung âm thanh cung cấp quyền truy cập vào các track phụ đề của nó thông qua [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Sử dụng collection này để đính kèm phụ đề WebVTT vào đoạn, xuất các track hiện có hoặc xóa chúng.

### **Thêm phụ đề âm thanh**

Ví dụ nhúng một đoạn âm thanh vào slide đầu tiên và sử dụng [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) để đính kèm một track WebVTT cục bộ. Đối số đầu tiên cung cấp nhãn track, đối số thứ hai xác định tệp chứa phụ đề có thời gian.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
        audioFrame.getCaptionTracks().add("English", "track.vtt");
    } finally {
        audioStream.close();
    }
    presentation.save("audio_with_captions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Trích xuất phụ đề âm thanh**

Ví dụ này xuất mỗi track phụ đề được gắn vào khung âm thanh trên slide đầu tiên. Nó ghi các byte trả về bởi [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) vào một tệp WebVTT và sử dụng định danh trả về bởi [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) làm tên tệp để mỗi track có một file đầu ra riêng.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("node:fs");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            const fileName = track.getCaptionId() + ".vtt";
            const bytes = track.getBinaryData();
            const data = Buffer.from(bytes);
            fs.writeFileSync(fileName, data);
        }
    }
} finally {
    presentation.dispose();
}
```

### **Xóa phụ đề âm thanh**

Sử dụng [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) hoặc [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) để xóa một track riêng lẻ. Ví dụ này dùng [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) để xóa tất cả phụ đề khỏi khung âm thanh đầu tiên trên slide đầu tiên trong khi vẫn giữ đoạn âm thanh.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Tìm một dòng trong phụ đề âm thanh**

Để tìm một dòng trong phụ đề âm thanh trên slide đầu tiên, tìm kiếm văn bản trả về bởi [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) trong bộ nhớ. Trong một cue WebVTT dạng text thuần, dòng thời gian chứa `-->`, các dòng phụ đề nằm sau nó và một dòng trống kết thúc cue. Ví dụ này in nhãn track và mỗi dòng phụ đề chứa “café”.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            let inCue = false;
            const captions = track.getDataAsString();
            for (const line of captions.split(/\r\n|\n|\r/)) {
                if (line === "") {
                    inCue = false;
                } else if (line.includes("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase().includes("café")) {
                    console.log(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Trích xuất âm thanh**

Một chuyển tiếp slide có thể có âm thanh riêng. Để lấy nó, gọi [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) trên chuyển tiếp slide. Ví dụ truy cập các byte trả về bởi [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) và in số byte. Nếu slide đầu tiên không có âm thanh chuyển tiếp, nó sẽ in một thông báo thay thế.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AudioSlide.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const sound = slide.getSlideShowTransition().getSound();
    if (sound) {
        const audioData = sound.getBinaryData();
        console.log("Transition sound: " + audioData.length + " bytes.");
    } else {
        console.log("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Tôi có thể sử dụng lại cùng một đoạn âm thanh trên nhiều slide mà không sao chép lại không?**

Có. Thêm đoạn âm thanh một lần vào [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) của bản trình bày và truyền cùng một đối tượng âm thanh vào [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) cho mỗi slide.

**Tôi có thể thay thế âm thanh trong một khung âm thanh hiện có không?**

Có. Đối với âm thanh liên kết, dùng [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) để chỉ tới tệp thay thế. Đối với âm thanh nhúng, chọn một đoạn khác từ audio collection của bản trình bày bằng [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio). Cả hai cách đều bảo toàn khung hiện có.

**Việc cắt đoạn có thay đổi dữ liệu âm thanh được lưu trong bản trình bày không?**

Không. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) và [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) chỉ đặt giới hạn phát lại. Bạn vẫn có thể lấy đoạn âm thanh đầy đủ bằng [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio).