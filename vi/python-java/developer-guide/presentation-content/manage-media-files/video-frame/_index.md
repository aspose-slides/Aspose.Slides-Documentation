---
title: Quản lý Khung Video trong Bài Thuyết Trình bằng Python
linktitle: Khung Video
type: docs
weight: 10
url: /vi/python-java/video-frame/
keywords:
- thêm video
- tạo video
- nhúng video
- trích xuất video
- lấy lại video
- khung video
- nguồn web
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách thêm và trích xuất khung video một cách lập trình trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua Java. Hướng dẫn nhanh."
---
## **Giới thiệu**

Một video được đặt hợp lý trong bài thuyết trình có thể làm cho thông điệp của bạn hấp dẫn hơn và tăng mức độ tương tác với khán giả.

PowerPoint cho phép bạn thêm video vào một slide trong bài thuyết trình theo hai cách:

* Thêm hoặc nhúng video cục bộ (được lưu trên máy của bạn)
* Thêm video trực tuyến (từ nguồn web như YouTube).

Để cho phép bạn thêm video (đối tượng video) vào bài thuyết trình, Aspose.Slides cung cấp lớp [Video](https://reference.aspose.com/slides/vi/python-java/aspose.slides/video/) , lớp [VideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/) và các kiểu liên quan khác.

## **Tạo Khung Video Nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bài thuyết trình.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide qua chỉ mục của nó.
3. Thêm một đối tượng [Video](https://reference.aspose.com/slides/vi/python-java/aspose.slides/video/) và truyền dữ liệu tệp video để nhúng video vào bài thuyết trình.
4. Thêm một đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/) để tạo khung cho video.
5. Lưu bài thuyết trình đã chỉnh sửa.

Mã Python này cho bạn thấy cách thêm video được lưu trữ cục bộ vào một bài thuyết trình:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ngoài ra, bạn có thể thêm video bằng cách truyền trực tiếp đường dẫn tệp tới phương thức [addVideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addVideoFrame) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Tạo Khung Video với Video từ Nguồn Web**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) hỗ trợ video YouTube trong bài thuyết trình. Nếu video bạn muốn sử dụng có sẵn trực tuyến (ví dụ trên YouTube), bạn có thể thêm nó vào bài thuyết trình thông qua liên kết web của nó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide qua chỉ mục của nó.
3. Thêm một đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/) và truyền liên kết tới video.
4. Đặt ảnh thu nhỏ cho khung video.
5. Lưu bài thuyết trình.

Mã Python này cho bạn thấy cách thêm video từ web vào một slide trong bài thuyết trình PowerPoint:

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Tải ảnh thu nhỏ.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cắt Một Khung Video**

Aspose.Slides cho phép bạn kiểm soát phần nào của video sẽ được phát bằng cách thiết lập các giá trị trim‑from‑start và trim‑from‑end thông qua [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/#setTrimFromStart) và [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/#setTrimFromEnd). Cả hai giá trị đều được chỉ định bằng mili giây và xác định thời gian bỏ qua từ đầu và cuối video tương ứng. Các cài đặt này thay đổi cách phát video trong bài thuyết trình; chúng không cắt hay sửa đổi dữ liệu nhị phân video đã nhúng.

**Đặt Cài Đặt Cắt**

Để tạo một khung video và đặt cài đặt cắt:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Thêm một đối tượng [Video](https://reference.aspose.com/slides/vi/python-java/aspose.slides/video/) vào bài thuyết trình.
3. Thêm một đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/) vào một slide.
4. Đặt các giá trị trim‑from‑start và trim‑from‑end thông qua [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/#setTrimFromStart) và [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/#setTrimFromEnd) .
5. Lưu bài thuyết trình đã chỉnh sửa.

Đoạn mã sau bỏ qua 2,5 giây đầu và 1 giây cuối của video đã nhúng khi phát:

```python
from pathlib import Path

import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Đọc Cài Đặt Cắt**

Để kiểm tra các cài đặt cắt hiện có, tải một bài thuyết trình, tìm một đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/) trong các shape trên slide đầu tiên, và đọc các giá trị qua [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/#getTrimFromStart) và [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/#getTrimFromEnd) .

Đoạn mã sau tìm khung video đầu tiên trên slide đầu tiên và báo cáo các cài đặt cắt của nó bằng mili giây:

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

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bài thuyết trình PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy cập qua phương thức [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/#getCaptionTracks) .

**Thêm Phụ Đề vào Khung Video**

Để thêm phụ đề vào một khung video:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Thêm một video vào bài thuyết trình.
3. Thêm một đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/) vào một slide.
4. Sử dụng [CaptionsCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/captionscollection/) trả về bởi [getCaptionTracks](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/#getCaptionTracks) để thêm một track phụ đề WebVTT.
5. Lưu bài thuyết trình đã chỉnh sửa.

Đoạn mã sau cho bạn thấy cách thêm phụ đề vào một khung video:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Thêm một track phụ đề mới từ tệp WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Lớp [CaptionsCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/captionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng dữ liệu.

**Trích Xuất Phụ Đề từ Khung Video**

Để trích xuất phụ đề từ một khung video:

1. Tải bài thuyết trình chứa video.
2. Tìm đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/) mục tiêu.
3. Duyệt qua các track phụ đề trong [CaptionsCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/captionscollection/) .
4. Lưu mỗi track phụ đề vào tệp `.vtt` .

Đoạn mã sau cho bạn thấy cách trích xuất phụ đề từ một khung video:

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
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # Lưu track phụ đề vào tệp WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Mỗi đối tượng [Captions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/captions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF‑8.

**Xóa Phụ Đề khỏi Khung Video**

Để xóa phụ đề khỏi một khung video:

1. Tải bài thuyết trình chứa video.
2. Lấy đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/) mục tiêu.
3. Xóa các track phụ đề khỏi [CaptionsCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/captionscollection/) .
4. Lưu bài thuyết trình đã chỉnh sửa.

Đoạn mã sau cho bạn thấy cách xóa tất cả phụ đề khỏi một khung video:

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

Nếu bạn cần xóa chỉ một track phụ đề, hãy sử dụng phương thức [remove](https://reference.aspose.com/slides/vi/python-java/aspose.slides/captionscollection/#remove) hoặc [removeAt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/captionscollection/#removeAt) thay vì [clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/captionscollection/#clear) .

## **Trích Xuất Video từ Các Slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video đã nhúng trong bài thuyết trình.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) để tải bài thuyết trình chứa video.
2. Duyệt qua tất cả các đối tượng [Slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/) .
3. Duyệt qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/) để tìm một [VideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/) .
4. Lưu video vào đĩa.

Đoạn mã Python này cho bạn thấy cách trích xuất video trên một slide của bài thuyết trình:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **FAQ**

**Tham số phát lại video nào có thể được thay đổi cho một VideoFrame?**

Bạn có thể kiểm soát [playback mode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/#setPlayMode) (tự động hoặc khi nhấp) và [looping](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/#setPlayLoopMode). Các tùy chọn này có sẵn qua các thuộc tính của đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/) .

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân sẽ được bao gồm trong tài liệu, vì vậy kích thước bài thuyết trình tăng tỉ lệ với kích thước tệp. Khi bạn thêm video trực tuyến, một liên kết và ảnh thu nhỏ được nhúng, vì vậy mức tăng kích thước sẽ nhỏ hơn.

**Tôi có thể thay thế video trong một VideoFrame hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể hoán đổi [video content](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/#setEmbeddedVideo) bên trong khung trong khi giữ nguyên hình học của shape; đây là kịch bản phổ biến để cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video đã nhúng không?**

Có. Một video đã nhúng có [content type](https://reference.aspose.com/slides/vi/python-java/aspose.slides/video/#getContentType) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó vào đĩa.