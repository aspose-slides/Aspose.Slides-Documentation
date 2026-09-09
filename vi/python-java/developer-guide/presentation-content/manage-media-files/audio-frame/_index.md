---
title: Quản lý âm thanh trong bản trình chiếu bằng Python
linktitle: Khung âm thanh
type: docs
weight: 10
url: /vi/python-java/audio-frame/
keywords:
- âm thanh
- khung âm thanh
- hình thu nhỏ
- thêm âm thanh
- thuộc tính âm thanh
- tùy chọn âm thanh
- trích xuất âm thanh
- Python
- Aspose.Slides
description: "Tạo và điều khiển khung âm thanh trong Aspose.Slides for Python via Java—các ví dụ mã để nhúng, cắt, vòng lặp và cấu hình phát trên các bản trình chiếu PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với khung âm thanh trong Aspose.Slides. Nó chỉ ra cách thêm âm thanh nhúng vào các slide, tùy chỉnh hình thu nhỏ của khung âm thanh, cấu hình các tùy chọn phát như âm lượng, vòng lặp, ẩn, cắt và thời gian làm mờ, và trích xuất âm thanh được sử dụng trong các chuyển đổi trình chiếu.

## **Tạo khung âm thanh**

Aspose.Slides for Python via Java cho phép bạn thêm tệp âm thanh vào các slide. Các tệp âm thanh được nhúng trong slide dưới dạng khung âm thanh. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Đọc tệp âm thanh mà bạn muốn nhúng vào slide.
4. Thêm khung âm thanh nhúng (chứa tệp âm thanh) vào slide.
5. Sử dụng [setPlayMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setPlayMode) và [setVolume](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setVolume) được cung cấp bởi đối tượng [AudioFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/).
6. Lưu bản trình chiếu đã sửa đổi.

Đoạn mã Python này cho bạn thấy cách thêm một khung âm thanh nhúng vào slide:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)
    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thay đổi hình thu nhỏ của khung âm thanh**

Khi bạn thêm một tệp âm thanh vào bản trình chiếu, âm thanh sẽ hiển thị dưới dạng một khung với hình ảnh mặc định tiêu chuẩn (xem hình ảnh trong phần dưới đây). Bạn có thể thay đổi hình ảnh preview của khung âm thanh thành bất kỳ hình ảnh nào bạn muốn.

Đoạn mã Python này cho bạn thấy cách thay đổi hình thu nhỏ hoặc hình preview của khung âm thanh:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thay đổi tùy chọn phát âm thanh**

Aspose.Slides for Python via Java cho phép bạn thay đổi các tùy chọn điều khiển việc phát âm thanh hoặc các thuộc tính. Ví dụ, bạn có thể điều chỉnh âm lượng, thiết lập vòng lặp, hoặc thậm chí ẩn biểu tượng âm thanh.

Bảng **Audio Options** trong Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** tương ứng với các thuộc tính [AudioFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/) của Aspose.Slides:

- **Start** danh sách thả xuống khớp với phương thức [setPlayMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** khớp với phương thức [setVolume](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** khớp với phương thức [setPlayAcrossSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** khớp với phương thức [setPlayLoopMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** khớp với phương thức [setHideAtShowing](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** khớp với phương thức [setRewindAudio](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setRewindAudio)

PowerPoint **Editing** tùy chọn tương ứng với các thuộc tính [AudioFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/) của Aspose.Slides:

- **Fade In** khớp với phương thức [setFadeInDuration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** khớp với phương thức [setFadeOutDuration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** khớp với phương thức [setTrimFromStart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** giá trị bằng tổng thời lượng âm thanh trừ đi giá trị được đặt bởi phương thức [setTrimFromEnd](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setTrimFromEnd)

Điều khiển **Volume** trên bảng điều khiển âm thanh của PowerPoint tương ứng với phương thức [setVolumeValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setVolumeValue). Nó cho phép bạn thay đổi âm lượng dưới dạng phần trăm.

Đây là cách bạn thay đổi các tùy chọn phát âm thanh:

1. [Create](#create-audio-frames) hoặc lấy khung âm thanh.
2. Đặt các giá trị mới cho các thuộc tính khung âm thanh mà bạn muốn điều chỉnh.
3. Lưu tệp PowerPoint đã sửa đổi.

Đoạn mã Python này trình bày một thao tác trong đó các tùy chọn âm thanh được điều chỉnh:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # Phát khi nhấp chuột ở âm lượng thấp, trên toàn bộ slide, không vòng lặp.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Ẩn khung trong khi trình chiếu và tua lại sau khi phát.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Ví dụ Python này cho thấy cách thêm một khung âm thanh mới với âm thanh nhúng, cắt nó và đặt thời gian làm mờ:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Cắt 1.5 giây từ đầu và 2 giây từ cuối.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Đặt thời gian fade-in thành 200 ms và fade-out thành 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mẫu mã sau đây cho thấy cách lấy một khung âm thanh có âm thanh nhúng và đặt âm lượng thành 85%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Quản lý phụ đề âm thanh**

Aspose.Slides cho phép bạn thêm phụ đề đóng vào một khung âm thanh thông qua phương thức [getCaptionTracks](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#getCaptionTracks). Phương thức này trả về một [CaptionsCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/captionscollection/), cho phép bạn thêm các track phụ đề WebVTT, duyệt qua các track hiện có và xóa chúng khi cần.

**Thêm phụ đề âm thanh**

Sử dụng phương thức [getCaptionTracks](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#getCaptionTracks) để gắn một hoặc nhiều track phụ đề vào khung âm thanh. Trong ví dụ sau, một tệp âm thanh được thêm vào slide, sau đó một track phụ đề mới được tải từ tệp `.vtt`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Thêm một track phụ đề mới từ tệp WebVTT.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Trích xuất phụ đề âm thanh**

Bạn có thể duyệt qua các track phụ đề gắn với khung âm thanh và lưu chúng dưới dạng tệp `.vtt`. Mỗi track phụ đề cung cấp dữ liệu nhị phân và định danh duy nhất, có thể dùng khi xuất phụ đề.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Lưu track phụ đề dưới dạng tệp .vtt.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Xóa phụ đề âm thanh**

Để xóa phụ đề khỏi khung âm thanh, sử dụng các phương thức do [CaptionsCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/captionscollection/) cung cấp, chẳng hạn như [clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/vi/python-java/aspose.slides/captionscollection/#remove) hoặc [removeAt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/captionscollection/#removeAt). Ví dụ dưới đây xóa tất cả các track phụ đề khỏi khung âm thanh.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Trích xuất âm thanh**

Aspose.Slides for Python via Java cho phép bạn trích xuất âm thanh được sử dụng trong các chuyển đổi trình chiếu. Ví dụ, bạn có thể trích xuất âm thanh được dùng trong một slide cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu chứa âm thanh.
2. Lấy một tham chiếu tới slide liên quan theo chỉ mục của nó.
3. Truy cập vào [slideshow transitions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getSlideShowTransition) cho slide đó.
4. Trích xuất âm thanh dưới dạng dữ liệu byte.

Mã Python này cho bạn thấy cách trích xuất âm thanh được sử dụng trong một slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể tái sử dụng cùng một tài nguyên âm thanh trên nhiều slide mà không làm tăng kích thước tệp không?**

Có. Thêm âm thanh một lần vào [audio collection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getAudios) chia sẻ của bản trình chiếu và tạo thêm các khung âm thanh tham chiếu tới tài nguyên hiện có. Điều này tránh việc sao chép dữ liệu media và giữ kích thước bản trình chiếu trong kiểm soát.

**Tôi có thể thay thế âm thanh trong một khung âm thanh hiện có mà không cần tạo lại hình dạng không?**

Có. Đối với âm thanh liên kết, cập nhật [link path](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setLinkPathLong) để trỏ tới tệp mới. Đối với âm thanh nhúng, thay thế đối tượng [embedded audio](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setEmbeddedAudio) bằng một đối tượng khác từ [audio collection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getAudios) của bản trình chiếu. Định dạng của khung và hầu hết các thiết lập phát vẫn giữ nguyên.

**Việc cắt bỏ có thay đổi dữ liệu âm thanh nền được lưu trong bản trình chiếu không?**

Không. Việc cắt chỉ điều chỉnh ranh giới phát. Các byte âm thanh gốc vẫn không bị thay đổi và có thể truy cập thông qua âm thanh nhúng hoặc collection âm thanh của bản trình chiếu.