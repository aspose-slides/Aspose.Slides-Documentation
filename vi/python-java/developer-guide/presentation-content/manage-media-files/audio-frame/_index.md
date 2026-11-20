---
title: Quản lý khung âm thanh trong bài thuyết trình bằng Python
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
description: "Nhúng âm thanh vào các slide, thay đổi biểu tượng âm thanh, cấu hình phát lại, quản lý phụ đề WebVTT, và trích xuất âm thanh chuyển slide với Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Một khung âm thanh cho phép bạn phát âm thanh trên một slide. Với Aspose.Slides for Python via Java, bạn có thể nhúng một clip âm thanh, chọn hình ảnh đại diện cho nó, điều chỉnh phát lại và gắn phụ đề. Bạn cũng có thể lấy âm thanh được gán cho hiệu ứng chuyển slide.

## **Tạo Khung Âm Thanh**

Thêm các byte từ `audio.wav` vào bộ sưu tập âm thanh của bản trình chiếu, sau đó sử dụng [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) để nhúng một clip âm thanh cục bộ vào slide đầu tiên. Hai tọa độ đầu tiên xác định vị trí khung trên slide, và hai giá trị tiếp theo đặt chiều rộng và chiều cao của nó, tất cả bằng đơn vị point. Ví dụ này gọi [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) để bắt đầu clip tự động và gọi [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) để chọn mức âm lượng cao.

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

Mặc định, một khung âm thanh hiển thị biểu tượng loa. Để hiển thị hình thu nhỏ tùy chỉnh, thêm một hình ảnh vào bản trình chiếu bằng [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) và đặt nó vào ảnh của khung bằng [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage). Ví dụ sử dụng một file JPEG làm hình thu nhỏ cho clip âm thanh được nhúng.

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

    audio_data = Path("audio.wav").read_bytes()
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

## **Thay Đổi Tùy Chọn Phát Âm Thanh**

Bộ điều khiển **Audio Options** của PowerPoint xác định thời điểm một clip bắt đầu, mức âm lượng, và cách nó hoạt động trong buổi trình chiếu.

![Bộ điều khiển Audio Options của PowerPoint cho một khung âm thanh](audio_frame_0.png)

| Điều khiển PowerPoint | Phương thức Aspose.Slides for Python via Java |
| --- | --- |
| Bắt đầu | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Mẫu âm lượng | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Phát xuyên suốt các slide | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Lặp lại cho đến khi dừng | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Ẩn trong khi trình chiếu | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Tua lại sau khi phát | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| Mờ dần vào | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Mờ dần ra | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Cắt thời gian bắt đầu âm thanh | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Cắt thời gian kết thúc âm thanh | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Thanh trượt âm lượng | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

Ví dụ này tìm khung âm thanh đầu tiên trên slide đầu tiên, gọi [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) để bắt đầu phát khi nhấp, và chọn mẫu âm lượng thấp. Clip tiếp tục phát xuyên suốt các slide với vòng lặp bị tắt. Biểu tượng được ẩn trong khi trình chiếu, và clip được tua lại sau khi phát.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # Phát khi nhấp với âm lượng thấp, xuyên suốt các slide, không lặp lại.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Ẩn khung trong khi trình chiếu và tua lại sau khi phát.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

Đối với một clip dài hơn 3,5 giây, ví dụ này bỏ qua 1,5 giây đầu và 2 giây cuối. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) nhận thời lượng cần bỏ ở cuối clip. Để lấy thời gian kết thúc hiển thị trong PowerPoint, trừ offset này khỏi thời lượng đầy đủ của clip. Clip đã cắt sẽ mờ dần vào trong 200 mil giây và mờ dần ra trong 500 mil giây. Tất cả bốn phương thức này nhận giá trị bằng mil giây.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Cắt 1,5 giây từ phần đầu và 2 giây từ phần cuối.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Đặt thời gian mờ dần vào là 200 ms và mờ dần ra là 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Để đặt âm lượng phát lại ở một phần trăm cụ thể, sử dụng [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue). Ví dụ này đặt khung âm thanh đầu tiên trên slide đầu tiên ở mức 85%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **Quản Lý Phụ Đề Âm Thanh**

Mỗi khung âm thanh cung cấp quyền truy cập vào các track phụ đề của nó thông qua [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks). Sử dụng bộ sưu tập này để gắn phụ đề WebVTT vào clip, xuất các track hiện có, hoặc xóa chúng.

### **Thêm Phụ Đề Âm Thanh**

Ví dụ này nhúng một clip âm thanh vào slide đầu tiên và sử dụng [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) để gắn một track WebVTT cục bộ. Đối số đầu tiên cung cấp nhãn track, và đối số thứ hai xác định tệp chứa phụ đề có thời gian.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Thêm một track phụ đề mới từ tệp WebVTT.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Trích Xuất Phụ Đề Âm Thanh**

Ví dụ này xuất mỗi track phụ đề được gắn vào một khung âm thanh trên slide đầu tiên. Nó ghi các byte trả về bởi [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) vào một tệp WebVTT và sử dụng định danh trả về bởi [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) làm tên tệp sao cho mỗi track có một tệp xuất riêng.

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
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Xóa Phụ Đề Âm Thanh**

Sử dụng [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) hoặc [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) để xóa một track riêng lẻ. Ví dụ này sử dụng [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) để xóa tất cả phụ đề khỏi khung âm thanh đầu tiên trên slide đầu tiên mà vẫn giữ lại clip.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **Tìm Dòng trong Phụ Đề Âm Thanh**

Để tìm một dòng trong phụ đề âm thanh trên slide đầu tiên, tìm kiếm văn bản trả về bởi [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) trong bộ nhớ. Trong một cue WebVTT dạng văn bản thuần, dòng thời gian chứa `-->`, các dòng phụ đề theo sau, và một dòng trống kết thúc cue. Ví dụ này in nhãn track và mỗi dòng phụ đề chứa “café”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **Trích Xuất Âm Thanh**

Một hiệu ứng chuyển slide có thể có âm thanh riêng. Để lấy nó, gọi [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) trên hiệu ứng chuyển slide. Ví dụ truy cập các byte trả về bởi [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) và in ra số byte. Nếu slide đầu tiên không có âm thanh chuyển, nó sẽ in một thông báo thay thế.

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
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Có thể tái sử dụng cùng một clip âm thanh trên nhiều slide mà không sao chép lại không?**

Đúng. Thêm clip một lần vào [bộ sưu tập âm thanh](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) của bản trình chiếu và truyền cùng một đối tượng âm thanh vào [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) cho mỗi slide.

**Có thể thay thế âm thanh trong một khung âm thanh hiện có không?**

Đúng. Đối với âm thanh được liên kết, sử dụng [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) để chỉ tới tệp thay thế. Đối với âm thanh được nhúng, chọn một clip khác từ [bộ sưu tập âm thanh] của bản trình chiếu bằng [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio). Cả hai cách đều giữ nguyên khung hiện tại.

**Việc cắt âm thanh có thay đổi dữ liệu âm thanh được lưu trong bản trình chiếu không?**

Không. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) và [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) chỉ đặt giới hạn phát lại. Bạn vẫn có thể lấy lại clip đầy đủ từ [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio).