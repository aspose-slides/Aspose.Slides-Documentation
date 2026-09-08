---
title: Quản lý âm thanh trong bản trình bày bằng Python
linktitle: Khung Âm Thanh
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
description: "Tạo và điều khiển các khung âm thanh trong Aspose.Slides cho Python qua Java—các ví dụ mã để nhúng, cắt, lặp và cấu hình việc phát trên các bản trình bày PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với khung âm thanh trong Aspose.Slides. Nó chỉ ra cách thêm âm thanh nhúng vào các slide, tùy chỉnh hình thu nhỏ của khung âm thanh, cấu hình các tùy chọn phát như âm lượng, lặp lại, ẩn, cắt và thời gian mờ, và trích xuất âm thanh được sử dụng trong chuyển đổi trình chiếu.

## **Tạo Khung Âm Thanh**

Aspose.Slides cho Python thông qua Java cho phép bạn thêm các tệp âm thanh vào slide. Các tệp âm thanh được nhúng trong slide dưới dạng khung âm thanh. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Đọc tệp âm thanh bạn muốn nhúng vào slide.
4. Thêm khung âm thanh nhúng (chứa tệp âm thanh) vào slide.
5. Đặt [setPlayMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setPlayMode) và [setVolume](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setVolume) được cung cấp bởi đối tượng [AudioFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/).
6. Lưu bản trình bày đã chỉnh sửa.

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

## **Thay Đổi Hình Thu Nhỏ Khung Âm Thanh**

Khi bạn thêm một tệp âm thanh vào bản trình bày, âm thanh sẽ hiển thị dưới dạng một khung với hình ảnh mặc định tiêu chuẩn (xem hình ảnh trong phần dưới đây). Bạn có thể thay đổi hình ảnh xem trước của khung âm thanh (đặt hình ảnh ưa thích của bạn).

Đoạn mã Python này cho bạn thấy cách thay đổi hình thu nhỏ hoặc hình ảnh xem trước của khung âm thanh:

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

## **Thay Đổi Các Tùy Chọn Phát Âm Thanh**

Aspose.Slides cho Python thông qua Java cho phép bạn thay đổi các tùy chọn kiểm soát việc phát âm thanh hoặc các thuộc tính của nó. Ví dụ, bạn có thể điều chỉnh âm lượng, đặt âm thanh để phát vòng lặp, hoặc thậm chí ẩn biểu tượng âm thanh.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/) properties:

- **Start** danh sách thả xuống khớp với phương thức [setPlayMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** khớp với phương thức [setVolume](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** khớp với phương thức [setPlayAcrossSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** khớp với phương thức [setPlayLoopMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** khớp với phương thức [setHideAtShowing](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** khớp với phương thức [setRewindAudio](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setRewindAudio)

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/) properties:

- **Fade In** khớp với phương thức [setFadeInDuration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setFadeInDuration)
- **Fade Out** khớp với phương thức [setFadeOutDuration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setFadeOutDuration)
- **Trim Audio Start Time** khớp với phương thức [setTrimFromStart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setTrimFromStart)
- **Trim Audio End Time** giá trị bằng độ dài âm thanh trừ đi giá trị của phương thức [setTrimFromEnd](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setTrimFromEnd)

Điều khiển **Volume** của PowerPoint trên bảng điều khiển âm thanh tương ứng với phương thức [setVolumeValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/#setVolumeValue). Nó cho phép bạn thay đổi âm lượng âm thanh dưới dạng phần trăm.

Đây là cách bạn thay đổi các tùy chọn Phát âm thanh:

1. [Сreate](#create-audio-frames) hoặc lấy Audio Frame.
2. Đặt các giá trị mới cho các thuộc tính Audio Frame mà bạn muốn điều chỉnh.
3. Lưu tệp PowerPoint đã chỉnh sửa.

Đoạn mã Python này minh họa một thao tác trong đó các tùy chọn của âm thanh được điều chỉnh:

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
        # Phát khi nhấp chuột ở âm lượng thấp, trên toàn bộ slide, không lặp lại.
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

Ví dụ Python này cho thấy cách thêm một khung âm thanh mới với âm thanh nhúng, cắt nó, và đặt thời gian mờ:

```python
from pathlib import Path

import jpide
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

    # Cắt 1,5 giây từ phần đầu và 2 giây từ phần cuối.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Đặt thời gian mờ vào 200 ms và mờ ra 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mẫu mã sau đây cho thấy cách lấy một khung âm thanh có âm thanh nhúng và đặt âm lượng của nó thành 85%:

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

## **Quản Lý Phụ Đề Âm Thanh**

Aspose.Slides cho phép bạn thêm phụ đề đóng vào một khung âm thanh thông qua phương thức [getCaptionTracks]. Phương thức này trả về một [CaptionsCollection], cho phép bạn thêm các track phụ đề WebVTT, duyệt qua các track hiện có, và xóa chúng khi cần.

**Thêm Phụ Đề Âm Thanh**

Sử dụng phương thức [getCaptionTracks] để gắn một hoặc nhiều track phụ đề vào một khung âm thanh. Trong ví dụ dưới đây, một tệp âm thanh được thêm vào slide, sau đó một track phụ đề mới được tải từ tệp `.vtt`.

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

**Trích Xuất Phụ Đề Âm Thanh**

Bạn có thể duyệt qua các track phụ đề liên kết với một khung âm thanh và lưu chúng dưới dạng tệp `.vtt`. Mỗi track phụ đề cung cấp dữ liệu nhị phân và định danh duy nhất, có thể dùng khi xuất phụ đề.

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

**Xóa Phụ Đề Âm Thanh**

Để xóa phụ đề khỏi một khung âm thanh, sử dụng các phương thức do [CaptionsCollection] cung cấp, như [clear], [remove] hoặc [removeAt]. Ví dụ sau xóa tất cả các track phụ đề khỏi một khung âm thanh.

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

## **Trích Xuất Âm Thanh**

Aspose.Slides cho Python thông qua Java cho phép bạn trích xuất âm thanh được sử dụng trong chuyển đổi trình chiếu. Ví dụ, bạn có thể trích xuất âm thanh được sử dụng trong một slide cụ thể.

1. Tạo một thể hiện của lớp [Presentation] và tải bản trình bày chứa âm thanh.
2. Lấy tham chiếu của slide liên quan thông qua chỉ mục của nó.
3. Truy cập vào [slideshow transitions] của slide.
4. Trích xuất âm thanh dưới dạng dữ liệu byte.

Đoạn mã Python này cho bạn thấy cách trích xuất âm thanh được sử dụng trong một slide:

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

## **FAQ**

**Tôi có thể tái sử dụng cùng một tài nguyên âm thanh trên nhiều slide mà không làm tăng kích thước tệp không?**

Có. Thêm âm thanh một lần vào [audio collection] chung của bản trình bày và tạo các khung âm thanh bổ sung tham chiếu tới tài nguyên hiện có. Điều này tránh việc sao chép dữ liệu media và giữ kích thước bản trình bày trong tầm kiểm soát.

**Tôi có thể thay thế âm thanh trong một khung âm thanh hiện có mà không cần tạo lại hình dạng không?**

Có. Đối với âm thanh liên kết, cập nhật [link path] để trỏ tới tệp mới. Đối với âm thanh nhúng, thay thế đối tượng [embedded audio] bằng một đối tượng khác từ [audio collection] của bản trình bày. Định dạng của khung và hầu hết các cài đặt phát vẫn giữ nguyên.

**Việc cắt bỏ có làm thay đổi dữ liệu âm thanh gốc được lưu trong bản trình bày không?**

Không. Việc cắt chỉ điều chỉnh phạm vi phát. Các byte âm thanh gốc vẫn không bị thay đổi và có thể truy cập qua âm thanh nhúng hoặc [audio collection] của bản trình bày.