---
title: Quản lý các khung video trong bản trình bày bằng Python
linktitle: Khung Video
type: docs
weight: 10
url: /vi/python-java/video-frame/
keywords:
- thêm video
- tạo video
- nhúng video
- trích xuất video
- lấy video
- khung video
- nguồn web
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Học cách thêm và trích xuất các khung video một cách lập trình trong các slide PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho Python qua Java. Hướng dẫn nhanh cách thực hiện."
---
## **Giới thiệu**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides for Python via Java cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát lại, quản lý phụ đề và trích xuất dữ liệu video được nhúng.

PowerPoint hỗ trợ video cục bộ và liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Để đại diện cho dữ liệu video và khung video, Aspose.Slides cung cấp lớp [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) lớp [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) và các kiểu liên quan khác.

## **Tạo Khung Video Nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình bày của mình.

Ví dụ này nhúng video cục bộ vào slide đầu tiên của một bản trình bày hiện có và lưu kết quả. Tọa độ và kích thước khung được tính bằng điểm. Python đọc các byte video từ đĩa, và JPype chuyển đổi chúng thành mảng byte Java trước khi video được thêm vào bản trình bày.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bạn cũng có thể truyền đường dẫn video cục bộ trực tiếp tới [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Ví dụ này nhúng video vào slide đầu tiên của một bản trình bày mới. Video phải vẫn có thể truy cập được cho đến khi bản trình bày được lưu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tạo Khung Video với Video từ Nguồn Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong các bản trình bày. Bạn có thể tạo một khung video liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Ví dụ này thêm liên kết video YouTube và ảnh thu nhỏ vào slide đầu tiên. Thay thế định danh video để sử dụng video khác. Phương thức [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) yêu cầu phát lại tự động. Tải ảnh thu nhỏ và phát video cần có kết nối internet. Trình xem bản trình bày cũng phải hỗ trợ phát video trực tuyến.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Phát Video ở Chế Độ Toàn Màn Hình**

Trong một bản trình bày đào tạo, bạn có thể phát một bản trình diễn phần mềm ở chế độ toàn màn hình để khán giả xem chi tiết. Gọi [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) với `True` để bật hành vi này trong quá trình phát lại.

Ví dụ này mở một bản trình bày, tìm khung [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) đầu tiên trên slide đầu tiên, và bật phát lại toàn màn hình. Bản trình bày đầu vào phải chứa ít nhất một slide với một khung video hiện có trên slide đầu tiên.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Phát lại toàn màn hình kiểm soát cách video được hiển thị. Riêng biệt, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) kiểm soát việc video bắt đầu tự động hay khi nhấp, và [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) kiểm soát việc lặp lại. Để chọn hành vi khởi động, đặt chế độ phát lại thành [VideoPlayModePreset.Auto hoặc VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Ví dụ giữ nguyên các cài đặt khởi động và vòng lặp hiện có.

## **Quay Lại Video Sau Khi Phát**

Trong một bản trình bày đào tạo, đưa video trình diễn về đầu lại giúp người thuyết trình có thể phát lại. Gọi [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) với `True` để đưa video về đầu sau khi phát xong.

Ví dụ này mở một bản trình bày, tìm khung [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) đầu tiên trên slide đầu tiên, và bật chức năng quay lại. Nó tắt vòng lặp để phát được hoàn thành và đặt phát lại bắt đầu khi nhấp. Bản trình bày đầu vào phải chứa ít nhất một slide với một khung video hiện có trên slide đầu tiên.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Quay lại đưa video về đầu mà không khởi động lại. Ngược lại, gọi [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) với `True` sẽ lặp lại phát lại tự động. Giữ vòng lặp tắt khi bạn muốn video kết thúc và sẵn sàng phát lại. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) riêng biệt kiểm soát khởi động tự động hay khi nhấp; ví dụ này sử dụng [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) nên người thuyết trình kiểm soát thời điểm bắt đầu phát. Đặt chế độ phát lại sau cài đặt vòng lặp, như trong ví dụ. Quay lại hoạt động độc lập với [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Cắt Ngắn Khung Video**

Sử dụng [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) và [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) để bỏ qua một phần đầu hoặc cuối của video trong quá trình phát lại. Cả hai giá trị đều tính bằng mili giây. Việc cắt ngắn thay đổi các cài đặt phát lại mà không sửa đổi dữ liệu video được nhúng.

**Đặt Cài Đặt Cắt**

Ví dụ này nhúng video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối trong quá trình phát lại. Sử dụng video dài hơn 3,5 giây để còn lại một đoạn có thể phát.

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Đọc Cài Đặt Cắt**

Ví dụ này in ra các giá trị cắt của khung video đầu tiên trên slide đầu tiên tính bằng mili giây. Bản trình bày phải chứa ít nhất một slide. Nếu slide đó không có khung video, sẽ không in gì. Ví dụ trước đưa ra giá trị 2500 và 1000.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **Quản Lý Phụ Đề Video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bản trình bày PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy cập thông qua phương thức [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

### **Thêm Phụ Đề vào Khung Video**

Ví dụ này nhúng video cục bộ và thêm một dải phụ đề WebVTT với nhãn English. Các dấu thời gian phụ đề cần khớp với video. Bản trình bày đã lưu bao gồm cả video và phụ đề của nó.

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Thêm một dải phụ đề mới từ tệp WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Lớp [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) cũng cung cấp một phương thức overload cho phép bạn thêm phụ đề từ một luồng.

### **Trích Xuất Phụ Đề từ Khung Video**

Ví dụ này lưu tất cả dải phụ đề từ các khung video trên slide đầu tiên thành các tệp WebVTT riêng biệt. Các số thứ tự giữ cho các tệp đầu ra khác nhau. Bảng điều khiển báo cáo số lượng dải đã trích xuất. Bản trình bày phải chứa ít nhất một slide.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

Mỗi đối tượng [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) hiển thị định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

### **Xóa Phụ Đề khỏi Khung Video**

Ví dụ này xóa tất cả phụ đề khỏi khung video ở vị trí hình dạng đầu tiên trên slide đầu tiên và lưu kết quả. Nó giả định rằng slide và hình dạng tồn tại và hình dạng là một khung video.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # Xóa tất cả phụ đề khỏi khung video.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Nếu bạn cần xóa chỉ một dải phụ đề, sử dụng các phương thức [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) hoặc [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) thay vì [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

### **Tìm Kiếm Phụ Đề Video**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) trả về toàn bộ dải WebVTT, bao gồm tiêu đề, các dòng thời gian và văn bản phụ đề. Bạn có thể tìm kiếm phụ đề trong bộ nhớ để tìm một cụm từ và dấu thời gian của nó. Ví dụ, một dải tiếng Anh trên slide 2 có thể chứa văn bản sau.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Ví dụ này mở `captioned_media.pptx` và sử dụng [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) để đọc các dải của mỗi khung video cấp cao nhất trên mọi slide. Trong một cue dạng văn bản thuần, dòng thời gian chứa `-->`, và một dòng trống kết thúc cue. Đối với mỗi phụ đề chứa “café” bất kể chữ hoa hay thường, ví dụ này in ra số slide, nhãn dải, dòng thời gian gốc và toàn bộ phụ đề.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue
                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)
                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

Tìm kiếm “café” tạo ra một kết quả khớp cho dải mẫu. Việc tìm kiếm loại trừ tiêu đề dải và giữ nguyên cài đặt thời gian và xuống dòng trong kết quả.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Trích Xuất Video từ Slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản trình bày.

Ví dụ này trích xuất video nhúng từ mọi slide thành các tệp nhị phân riêng biệt, có số thứ tự. Video được liên kết bị bỏ qua vì không có dữ liệu nhúng. Bảng điều khiển in ra MIME type của mỗi video và tổng số. Đầu ra sử dụng phần mở rộng chung `.bin`; thay đổi nó để phù hợp với loại phương tiện được báo cáo khi cần.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **FAQ**

**Tham số phát lại video nào có thể thay đổi cho khung video?**

Bạn có thể kiểm soát [chế độ phát lại](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (tự động hoặc khi nhấp) và [vòng lặp](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Các tùy chọn này có sẵn thông qua các phương thức của đối tượng [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**Thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân được bao gồm trong tài liệu, vì vậy kích thước bản trình bày tăng tỷ lệ với kích thước tệp. Khi bạn liên kết tới video trực tuyến và thêm ảnh thu nhỏ, bản trình bày lưu trữ liên kết và hình ảnh xem trước thay vì dữ liệu video, do đó tăng kích thước thường nhỏ hơn.

**Tôi có thể thay thế video trong một khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể thay đổi [nội dung video](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) trong khung mà vẫn giữ nguyên hình dạng; đây là kịch bản phổ biến để cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Video được nhúng có một [loại nội dung](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó vào đĩa.