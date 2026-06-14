---
title: Quản lý âm thanh trong bản trình chiếu bằng PHP
linktitle: Khung Âm Thanh
type: docs
weight: 10
url: /vi/php-java/audio-frame/
keywords:
- âm thanh
- khung âm thanh
- ảnh thu nhỏ
- thêm âm thanh
- thuộc tính âm thanh
- tùy chọn âm thanh
- trích xuất âm thanh
- PHP
- Aspose.Slides
description: "Tạo và điều khiển các khung âm thanh trong Aspose.Slides cho PHP—các ví dụ mã để nhúng, cắt, lặp lại và cấu hình phát lại trong các bản trình chiếu PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với khung âm thanh trong Aspose.Slides. Nó cho thấy cách thêm âm thanh nhúng vào slide, tùy chỉnh ảnh thu nhỏ của khung âm thanh, cấu hình các tùy chọn phát như âm lượng, lặp lại, ẩn, cắt và thời gian làm mờ, và trích xuất âm thanh được sử dụng trong các chuyển đổi trình chiếu.

## **Tạo Khung Âm Thanh**

Aspose.Slides for PHP qua Java cho phép bạn thêm tệp âm thanh vào các slide. Các tệp âm thanh được nhúng vào slide dưới dạng khung âm thanh.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.
3. Tải luồng tệp âm thanh bạn muốn nhúng vào slide.
4. Thêm khung âm thanh nhúng (chứa tệp âm thanh) vào slide.
5. Đặt [PlayMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/AudioPlayModePreset) và `Volume` được cung cấp bởi đối tượng [AudioFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/).
6. Lưu bản trình chiếu đã sửa đổi.

Mã PHP này cho bạn thấy cách thêm một khung âm thanh nhúng vào slide:

```php
// Khởi tạo một lớp Presentation đại diện cho tệp bản trình chiếu
$pres = new Presentation();
try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Tải tệp âm thanh wav vào stream
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Thêm Khung Âm Thanh
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Đặt chế độ phát và âm lượng cho âm thanh
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Ghi tệp PowerPoint ra đĩa
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Thay Đổi Ảnh Thu Nhỏ Khung Âm Thanh**

Khi bạn thêm một tệp âm thanh vào bản trình chiếu, âm thanh sẽ hiển thị dưới dạng một khung với hình ảnh mặc định tiêu chuẩn (xem hình ảnh trong phần bên dưới). Bạn có thể thay đổi hình ảnh xem trước của khung âm thanh (đặt hình ảnh bạn muốn).

Mã PHP này cho bạn thấy cách thay đổi ảnh thu nhỏ hoặc hình ảnh xem trước của khung âm thanh:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Thêm một khung âm thanh vào slide với vị trí và kích thước xác định.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Thêm một hình ảnh vào tài nguyên của bản trình chiếu.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Đặt hình ảnh cho khung âm thanh.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# Lưu bản trình chiếu đã chỉnh sửa vào đĩa
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Thay Đổi Các Tùy Chọn Phát Âm Thanh**

Aspose.Slides cho PHP qua Java cho phép bạn thay đổi các tùy chọn kiểm soát việc phát hoặc thuộc tính của âm thanh. Ví dụ, bạn có thể điều chỉnh âm lượng của âm thanh, đặt âm thanh phát vòng lặp, hoặc thậm chí ẩn biểu tượng âm thanh.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** trong PowerPoint tương ứng với các thuộc tính [AudioFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/) của Aspose.Slides:

- **Start** danh sách thả xuống tương ứng với phương thức [AudioFrame::setPlayMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** tương ứng với phương thức [AudioFrame::setVolume](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** tương ứng với phương thức [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** tương ứng với phương thức [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** tương ứng với phương thức [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** tương ứng với phương thức [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/#setRewindAudio)

Các tùy chọn **Editing** trong PowerPoint tương ứng với các thuộc tính [AudioFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/) của Aspose.Slides:

- **Fade In** tương ứng với phương thức [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/#setFadeInDuration)
- **Fade Out** tương ứng với phương thức [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/#setFadeOutDuration)
- **Trim Audio Start Time** tương ứng với phương thức [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/#setTrimFromStart)
- **Trim Audio End Time** giá trị bằng tổng thời lượng của âm thanh trừ giá trị của phương thức [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/#setTrimFromEnd)

Thanh **Volume controll** trong PowerPoint trên bảng điều khiển âm thanh tương ứng với phương thức [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/#setVolumeValue). Nó cho phép bạn thay đổi âm lượng âm thanh dưới dạng phần trăm.

Đây là cách bạn thay đổi các tùy chọn phát âm thanh:

1. [Tạo](#create-audio-frame) hoặc lấy Audio Frame.
2. Đặt giá trị mới cho các thuộc tính Audio Frame mà bạn muốn điều chỉnh.
3. Lưu tệp PowerPoint đã sửa đổi.

Mã PHP này minh họa một thao tác trong đó các tùy chọn của âm thanh được điều chỉnh:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Lấy hình dạng AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Đặt chế độ phát thành phát khi nhấp
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Đặt âm lượng thành Thấp
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Đặt âm thanh để phát xuyên suốt các slide
    $audioFrame->setPlayAcrossSlides(true);
    # Vô hiệu hoá vòng lặp cho âm thanh
    $audioFrame->setPlayLoopMode(false);
    # Ẩn AudioFrame trong khi trình chiếu
    $audioFrame->setHideAtShowing(true);
    # Quay lại âm thanh về đầu sau khi phát
    $audioFrame->setRewindAudio(true);
    # Lưu tệp PowerPoint vào đĩa
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

Mã PHP này cho thấy cách thêm một khung âm thanh mới với âm thanh nhúng, cắt nó và đặt thời gian làm mờ:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Đặt độ dịch bắt đầu cắt thành 1.5 giây
    $audioFrame->setTrimFromStart(1500);
    // Đặt độ dịch kết thúc cắt thành 2 giây
    $audioFrame->setTrimFromEnd(2000);

    // Đặt thời lượng fade-in thành 200 ms
    $audioFrame->setFadeInDuration(200);
    // Đặt thời lượng fade-out thành 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

Đoạn mã sau đây cho thấy cách lấy một khung âm thanh có âm thanh nhúng và đặt âm lượng của nó thành 85%:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Lấy hình dạng khung âm thanh
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Đặt âm lượng âm thanh thành 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Quản Lý Phụ Đề Âm Thanh**

Aspose.Slides cho phép bạn thêm phụ đề đóng vào một khung âm thanh thông qua phương thức [getCaptionTracks](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/#getCaptionTracks). Phương thức này trả về một [CaptionsCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/captionscollection/), cho phép bạn thêm các track phụ đề WebVTT, duyệt qua các track hiện có và xóa chúng khi cần.

**Thêm Phụ Đề Âm Thanh**

Sử dụng phương thức [getCaptionTracks](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/#getCaptionTracks) để gắn một hoặc nhiều track phụ đề vào một khung âm thanh. Trong ví dụ dưới đây, một tệp âm thanh được thêm vào slide, sau đó một track phụ đề mới được tải từ tệp `.vtt`.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // Thêm một track phụ đề mới từ tệp WebVTT.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Trích Xuất Phụ Đề Âm Thanh**

Bạn có thể duyệt qua các track phụ đề liên kết với một khung âm thanh và lưu chúng dưới dạng tệp `.vtt`. Mỗi track phụ đề cung cấp dữ liệu nhị phân và định danh duy nhất, có thể dùng khi xuất phụ đề.

```php
$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
            $audioFrame = $shape;
            $trackCount = java_values($audioFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $audioFrame->getCaptionTracks()->get_Item($trackIndex);
                // Lưu mỗi track phụ đề dưới dạng tệp .vtt.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Xóa Phụ Đề Âm Thanh**

Để xóa phụ đề khỏi một khung âm thanh, sử dụng các phương thức do [CaptionsCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/captionscollection/) cung cấp, như [clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/vi/php-java/aspose.slides/captionscollection/#remove), hoặc [removeAt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/captionscollection/#removeAt). Ví dụ sau đây xóa tất cả các track phụ đề khỏi một khung âm thanh.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // loại: AudioFrame

    // Xóa tất cả các track phụ đề khỏi khung âm thanh.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Trích Xuất Âm Thanh**

Aspose.Slides cho PHP qua Java cho phép bạn trích xuất âm thanh được sử dụng trong các chuyển đổi của trình chiếu. Ví dụ, bạn có thể trích xuất âm thanh được dùng trong một slide cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) và tải bản trình chiếu chứa âm thanh.
2. Lấy tham chiếu của slide liên quan thông qua chỉ số của nó.
3. Truy cập các [slideshow transitions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslide/#getSlideShowTransition) của slide.
4. Trích xuất âm thanh dưới dạng dữ liệu byte.

Mã này cho bạn thấy cách trích xuất âm thanh được sử dụng trong một slide:

```php
# Khởi tạo một lớp Presentation đại diện cho tệp bản trình chiếu
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Truy cập slide mong muốn
	$slide = $pres->getSlides()->get_Item(0);
	# Lấy hiệu ứng chuyển đổi trình chiếu cho slide
	$transition = $slide->getSlideShowTransition();
	# Trích xuất âm thanh dưới dạng mảng byte
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**Tôi có thể tái sử dụng cùng một tài nguyên âm thanh trên nhiều slide mà không làm tăng kích thước tệp không?**

Đúng. Thêm âm thanh một lần vào [audio collection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getaudios/) chia sẻ của bản trình chiếu và tạo các khung âm thanh bổ sung tham chiếu tới tài nguyên đã tồn tại. Điều này tránh trùng lặp dữ liệu media và giữ kích thước bản trình chiếu trong mức kiểm soát.

**Tôi có thể thay thế âm thanh trong một khung âm thanh hiện có mà không phải tạo lại hình dạng không?**

Đúng. Đối với âm thanh liên kết, cập nhật [link path](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/setlinkpathlong/) để trỏ tới tệp mới. Đối với âm thanh nhúng, thay thế đối tượng [embedded audio](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audioframe/setembeddedaudio/) bằng một âm thanh khác từ [audio collection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getaudios/) của bản trình chiếu. Định dạng khung và hầu hết các cài đặt phát vẫn giữ nguyên.

**Việc cắt âm có thay đổi dữ liệu âm thanh gốc được lưu trong bản trình chiếu không?**

Không. Việc cắt chỉ điều chỉnh ranh giới phát. Dữ liệu âm thanh gốc vẫn không bị thay đổi và có thể truy cập thông qua âm thanh nhúng hoặc [audio collection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getaudios/) của bản trình chiếu.