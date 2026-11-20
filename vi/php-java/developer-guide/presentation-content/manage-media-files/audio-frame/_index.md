---
title: Quản lý khung âm thanh trong bài thuyết trình bằng PHP
linktitle: Khung Âm Thanh
type: docs
weight: 10
url: /vi/php-java/audio-frame/
keywords:
- âm thanh
- khung âm thanh
- hình thu nhỏ
- thêm âm thanh
- thuộc tính âm thanh
- tùy chọn âm thanh
- trích xuất âm thanh
- PHP
- Aspose.Slides
description: "Nhúng âm thanh vào slide, thay đổi biểu tượng âm thanh, cấu hình phát lại, quản lý phụ đề WebVTT, và trích xuất âm thanh chuyển đổi slide với Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Một khung âm thanh cho phép bạn phát âm thanh trên một slide. Với Aspose.Slides cho PHP qua Java, bạn có thể nhúng một đoạn âm thanh cục bộ, chọn hình ảnh đại diện cho nó, điều chỉnh phát lại và đính kèm phụ đề. Bạn cũng có thể lấy âm thanh được gán cho chuyển đổi slide.

## **Tạo Khung Âm Thanh**

Sử dụng [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) để nhúng một đoạn âm thanh cục bộ trên slide đầu tiên. Hai tọa độ đầu tiên định vị khung trên slide, và hai giá trị tiếp theo đặt chiều rộng và chiều cao, tất cả tính bằng điểm. Ví dụ này gọi [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) để bắt đầu đoạn âm thanh tự động và gọi [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) để chọn cài đặt âm lượng lớn.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setPlayMode(AudioPlayModePreset::Auto);
    $audioFrame->setVolume(AudioVolumeMode::Loud);

    $presentation->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Thay Đổi Hình Thu Nhỏ Khung Âm Thanh**

Mặc định, một khung âm thanh hiển thị biểu tượng loa. Để hiển thị hình thu nhỏ tùy chỉnh, thêm một hình ảnh vào bản trình chiếu bằng [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) và đặt nó vào ảnh của khung bằng [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/). Ví dụ sử dụng một tệp JPEG làm hình thu nhỏ cho đoạn âm thanh được nhúng.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }

    $imageStream = new Java("java.io.FileInputStream", "eagle.jpeg");
    try {
        $thumbnail = $presentation->getImages()->addImage($imageStream);
    } finally {
        $imageStream->close();
    }
    $audioFrame->getPictureFormat()->getPicture()->setImage($thumbnail);

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Thay Đổi Tùy Chọn Phát Âm Thanh**

Các điều khiển **Audio Options** của PowerPoint xác định thời điểm bắt đầu một đoạn âm thanh, mức độ âm lượng và cách nó hoạt động trong suốt buổi trình chiếu.

![Các điều khiển Audio Options của PowerPoint cho một khung âm thanh](audio_frame_0.png)

| Điều khiển PowerPoint | Phương thức Aspose.Slides cho PHP qua Java |
| --- | --- |
| Bắt đầu | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| Cài đặt âm lượng | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| Phát xuyên suốt các slide | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| Lặp lại cho đến khi dừng | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| Ẩn trong khi trình chiếu | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| Tua lại sau khi phát | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| Mờ dần vào | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| Mờ dần ra | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Cắt thời gian bắt đầu âm thanh | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| Cắt thời gian kết thúc âm thanh | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Thanh trượt âm lượng | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

Ví dụ tìm khung âm thanh đầu tiên trên slide đầu tiên, gọi [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) để bắt đầu phát khi nhấp, và chọn cài đặt âm lượng thấp. Đoạn âm thanh tiếp tục qua các slide với tính năng lặp được tắt. Biểu tượng được ẩn trong suốt buổi trình chiếu, và đoạn âm thanh được tua lại sau khi phát.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setPlayAcrossSlides(true);
        $audioFrame->setPlayLoopMode(false);
        $audioFrame->setPlayMode(AudioPlayModePreset::OnClick);
        $audioFrame->setVolume(AudioVolumeMode::Low);
        $audioFrame->setHideAtShowing(true);
        $audioFrame->setRewindAudio(true);

        $presentation->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

Đối với đoạn âm thanh dài hơn 3,5 giây, ví dụ này bỏ qua 1,5 giây đầu tiên và 2 giây cuối cùng. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) nhận thời lượng cần loại bỏ ở cuối đoạn. Để lấy thời gian kết thúc hiển thị trong PowerPoint, trừ offset này khỏi thời lượng đầy đủ của đoạn. Đoạn âm thanh đã cắt sẽ mờ dần vào trong 200 mili giây và mờ dần ra trong 500 mili giây. Bốn phương thức đều nhận giá trị bằng mili giây.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setTrimFromStart(1500);
    $audioFrame->setTrimFromEnd(2000);
    $audioFrame->setFadeInDuration(200);
    $audioFrame->setFadeOutDuration(500);

    $presentation->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Để đặt âm lượng phát lại ở một phần trăm cụ thể, sử dụng [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Ví dụ này đặt khung âm thanh đầu tiên trên slide đầu tiên ở mức 85%.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setVolumeValue(85);
        $presentation->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **Quản Lý Phụ Đề Âm Thanh**

Mỗi khung âm thanh cung cấp quyền truy cập vào các track phụ đề của nó thông qua [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks). Sử dụng bộ sưu tập để đính kèm phụ đề WebVTT vào đoạn, xuất các track hiện có, hoặc xóa chúng.

### **Thêm Phụ Đề Âm Thanh**

Ví dụ nhúng một đoạn âm thanh trên slide đầu tiên và sử dụng [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) để đính kèm một track WebVTT cục bộ. Đối số đầu tiên cung cấp nhãn track, và đối số thứ hai chỉ định tệp chứa các phụ đề có thời gian.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Trích Xuất Phụ Đề Âm Thanh**

Ví dụ này xuất mỗi track phụ đề được đính kèm vào một khung âm thanh trên slide đầu tiên. Nó ghi các byte trả về bởi [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) vào một tệp WebVTT và sử dụng định danh trả về bởi [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) làm tên tệp để mỗi track có một file riêng.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $fileName = $track->getCaptionId() . ".vtt";
            $audioCaptions = $track->getBinaryData();
            $output = new Java("java.io.FileOutputStream", $fileName);
            try {
                $output->write($audioCaptions);
            } finally {
                $output->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

### **Xóa Phụ Đề Âm Thanh**

Sử dụng [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) hoặc [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) để xóa một track riêng lẻ. Ví dụ này sử dụng [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) để xóa tất cả phụ đề khỏi khung âm thanh đầu tiên trên slide đầu tiên trong khi vẫn giữ lại đoạn âm thanh.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->getCaptionTracks()->clear();
        $presentation->save("audio_without_captions.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

### **Tìm Dòng Trong Phụ Đề Âm Thanh**

Để tìm một dòng trong phụ đề âm thanh trên slide đầu tiên, tìm kiếm văn bản trả về bởi [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) trong bộ nhớ. Trong một cue WebVTT dạng văn bản thuần, dòng thời gian chứa `-->`, các dòng phụ đề nằm sau đó, và một dòng trống kết thúc cue. Ví dụ này in nhãn track và mỗi dòng phụ đề chứa “café”.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $inCue = false;
            $captions = (string) $track->getDataAsString();
            foreach (preg_split('/\R/u', $captions) as $line) {
                if ($line === "") {
                    $inCue = false;
                } elseif (strpos($line, "-->") !== false) {
                    $inCue = true;
                } elseif ($inCue && preg_match('/café/iu', $line)) {
                    echo $track->getLabel() . ": " . $line . "\n";
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Trích Xuất Âm Thanh**

Một chuyển đổi slide có thể có âm thanh riêng. Để lấy nó, gọi [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) trên chuyển đổi slide. Ví dụ này truy cập các byte trả về bởi [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) và in số lượng byte. Nếu slide đầu tiên không có âm thanh chuyển đổi, nó sẽ in một thông báo thay thế.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AudioSlide.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $sound = $slide->getSlideShowTransition()->getSound();
    if (java_is_null($sound)) {
        echo "The first slide has no transition sound.\n";
    } else {
        $audioData = $sound->getBinaryData();
        $array = new JavaClass("java.lang.reflect.Array");
        echo "Transition sound: " . $array->getLength($audioData) . " bytes.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **Câu Hỏi Thường Gặp**

**Tôi có thể sử dụng lại cùng một đoạn âm thanh trên nhiều slide mà không sao chép nó không?**

Có. Thêm đoạn âm thanh một lần vào bản trình chiếu’s [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) và truyền cùng một đối tượng âm thanh tới [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) cho mỗi slide.

**Tôi có thể thay thế âm thanh trong một khung âm thanh hiện có không?**

Có. Đối với âm thanh liên kết, sử dụng [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) để chỉ đến tệp thay thế. Đối với âm thanh nhúng, chọn một đoạn khác từ [audio collection] của bản trình chiếu bằng [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/). Cả hai cách đều giữ lại khung hiện có.

**Việc cắt đoạn có thay đổi dữ liệu âm thanh lưu trong bản trình chiếu không?**

Không. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) và [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) chỉ đặt giới hạn phát lại. Bạn vẫn có thể lấy lại đoạn âm thanh đầy đủ từ [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/).