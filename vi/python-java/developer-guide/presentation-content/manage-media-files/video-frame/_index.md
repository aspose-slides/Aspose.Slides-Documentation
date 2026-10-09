---
title: Quản lý khung video trong bài thuyết trình bằng Python
linktitle: Khung video
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
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách thêm và trích xuất khung video trong các slide PowerPoint và OpenDocument một cách lập trình bằng Aspose.Slides cho Python qua Java. Hướng dẫn nhanh chóng."
---
## **Giới thiệu**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides for Python via Java cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát lại, quản lý phụ đề và trích xuất dữ liệu video được nhúng.

PowerPoint hỗ trợ video cục bộ và liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Để mô tả dữ liệu video và khung video, Aspose.Slides cung cấp lớp [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) và lớp [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) cùng các kiểu liên quan khác.

## **Tạo khung video được nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình bày của mình.

Ví dụ này nhúng một video cục bộ vào slide đầu tiên của một bản trình bày hiện có và lưu kết quả. Tọa độ và kích thước khung được tính bằng điểm. Python đọc byte video từ đĩa, và JPype chuyển chúng thành mảng byte Java trước khi video được thêm vào bản trình bày.

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

Bạn cũng có thể truyền trực tiếp đường dẫn video cục bộ vào phương thức [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Ví dụ này nhúng video vào slide đầu tiên của một bản trình bày mới. Video phải vẫn có thể truy cập được cho đến khi bản trình bày được lưu.

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

## **Tạo khung video với video từ nguồn web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong bản trình bày. Bạn có thể tạo một khung video liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Ví dụ này thêm liên kết video YouTube và ảnh thu nhỏ vào slide đầu tiên. Thay thế định danh video để sử dụng video khác. Phương thức [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) yêu cầu tự động phát. Tải ảnh thu nhỏ và phát video cần có kết nối internet. Trình xem bản trình bày cũng phải hỗ trợ phát video trực tuyến.

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

## **Phát video ở chế độ toàn màn hình**

Trong bản trình bày đào tạo, bạn có thể phát một bản demo phần mềm ở chế độ toàn màn hình để khán giả nhìn thấy chi tiết. Gọi [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) với `True` để bật hành vi này khi phát.

Ví dụ này mở một bản trình bày, tìm khung [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) đầu tiên trên slide đầu và bật phát toàn màn hình. Bản trình bày đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu.

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

Phát toàn màn hình quyết định cách video được hiển thị. Riêng biệt, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) kiểm soát việc video tự động phát hay phát khi nhấn, và [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) kiểm soát việc lặp lại. Để chọn cách khởi động, đặt chế độ phát thành [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Ví dụ giữ nguyên các cài đặt khởi động và lặp lại hiện có.

## **Quay lại đầu video sau khi phát**

Trong bản trình bày đào tạo, việc đưa video demo trở về đầu giúp người thuyết trình có thể phát lại nhanh chóng. Gọi [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) với `True` để video quay lại đầu sau khi phát xong.

Ví dụ này mở một bản trình bày, tìm khung [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) đầu tiên trên slide đầu và bật chức năng quay lại. Nó tắt vòng lặp để phát có thể kết thúc và đặt chế độ phát là khi nhấp. Bản trình bày đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu.

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

Quay lại đưa video về đầu mà không khởi động lại. Ngược lại, gọi [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) với `True` sẽ tự động lặp lại phát. Giữ vòng lặp tắt khi bạn muốn video kết thúc và sẵn sàng phát lại. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) độc lập kiểm soát khởi động tự động hay khi nhấp; ví dụ này sử dụng [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) để người thuyết trình kiểm soát thời điểm bắt đầu phát. Đặt chế độ phát sau khi đã thiết lập vòng lặp, như trong ví dụ. Quay lại hoạt động độc lập với [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Cắt ngắn khung video**

Sử dụng [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) và [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) để bỏ qua phần đầu hoặc phần cuối của video khi phát. Cả hai giá trị đều tính bằng mili giây. Việc cắt ngắn thay đổi cài đặt phát mà không sửa đổi dữ liệu video được nhúng.

**Đặt cài đặt cắt ngắn**

Ví dụ này nhúng một video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối khi phát. Sử dụng video dài hơn 3,5 giây để còn lại một đoạn có thể phát được.

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

**Đọc cài đặt cắt ngắn**

Ví dụ này in ra các giá trị cắt ngắn của khung video đầu tiên trên slide đầu, tính bằng mili giây. Bản trình bày phải chứa ít nhất một slide. Nếu slide đó không có khung video, sẽ không in gì. Ví dụ trước tạo ra các giá trị 2500 và 1000.

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

## **Quản lý phụ đề video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bản trình bày PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy cập thông qua phương thức [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

**Thêm phụ đề vào khung video**

Ví dụ này nhúng một video cục bộ và thêm một track phụ đề WebVTT có nhãn English. Các dấu thời gian phụ đề cần khớp với video. Bản trình bày đã lưu sẽ bao gồm cả video và phụ đề của nó.

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

    # Thêm một track phụ đề mới từ tệp WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Lớp [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng dữ liệu.

**Trích xuất phụ đề từ khung video**

Ví dụ này lưu tất cả các track phụ đề từ các khung video trên slide đầu tiên thành các tệp WebVTT riêng biệt. Các số tuần tự giữ cho các tệp đầu ra không trùng nhau. Console báo số lượng track đã trích xuất. Bản trình bày phải chứa ít nhất một slide.

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

Mỗi đối tượng [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

**Xóa phụ đề khỏi khung video**

Ví dụ này xóa tất cả phụ đề khỏi khung video ở vị trí shape đầu tiên trên slide đầu và lưu kết quả. Nó giả định slide và shape tồn tại và shape là một khung video.

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

Nếu bạn chỉ cần xóa một track phụ đề, hãy sử dụng các phương thức [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) hoặc [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) thay vì [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

## **Trích xuất video từ slide**

Bên cạnh việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản trình bày.

Ví dụ này trích xuất các video được nhúng từ mọi slide thành các tệp nhị phân có số thứ tự riêng. Các video liên kết sẽ bị bỏ qua vì chúng không có dữ liệu được nhúng. Console in ra loại MIME của mỗi video và tổng số lượng. Đầu ra sử dụng phần mở rộng chung `.bin`; bạn có thể thay đổi thành phần mở rộng phù hợp với loại media được báo cáo khi cần.

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

## **Câu hỏi thường gặp**

**Các tham số phát lại video nào có thể thay đổi cho một khung video?**

Bạn có thể điều khiển [playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (tự động hoặc khi nhấp) và [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Các tùy chọn này có sẵn qua các phương thức của đối tượng [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**Việc thêm video có làm tăng kích thước tệp PPTX không?**

Có. Khi bạn nhúng một video cục bộ, dữ liệu nhị phân sẽ được bao gồm trong tài liệu, vì vậy kích thước bản trình bày tăng tỷ lệ với kích thước tệp video. Khi bạn liên kết tới video trực tuyến và thêm ảnh thu nhỏ, bản trình bày chỉ lưu link và ảnh preview thay vì dữ liệu video, do đó sự tăng kích thước thường nhỏ hơn.

**Tôi có thể thay thế video trong một khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể thay đổi [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) trong khung trong khi giữ nguyên hình học của shape; đây là kịch bản phổ biến để cập nhật media trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Video được nhúng có một [loại nội dung](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó ra đĩa.