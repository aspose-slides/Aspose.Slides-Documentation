---
title: Thêm Video vào Bài Thuyết Trình bằng Python
linktitle: Khung Video
type: docs
weight: 10
url: /vi/python-net/video-frame/
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
description: "Học cách thêm và trích xuất khung video một cách lập trình trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET. Hướng dẫn nhanh."
---
## **Giới thiệu**

Một video được đặt hợp lý trong bài thuyết trình có thể làm cho thông điệp của bạn thuyết phục hơn và tăng mức độ tương tác với khán giả. 

PowerPoint cho phép bạn thêm video vào một slide trong bài thuyết trình theo hai cách:

* Thêm hoặc nhúng video cục bộ (được lưu trên máy của bạn)
* Thêm video trực tuyến (từ nguồn web như YouTube).

Để cho phép bạn thêm video (đối tượng video) vào bài thuyết trình, Aspose.Slides cung cấp lớp [Video](https://reference.aspose.com/slides/vi/python-net/aspose.slides/video/) , lớp [VideoFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/) và các kiểu liên quan khác. 

## **Tạo Khung Video Nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu cục bộ, bạn có thể tạo một khung video để nhúng video vào bài thuyết trình của mình. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm một đối tượng [Video](https://reference.aspose.com/slides/vi/python-net/aspose.slides/video/) và truyền đường dẫn tệp video để nhúng video vào bài thuyết trình. 
4. Thêm một đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/) để tạo khung cho video.  
5. Lưu bài thuyết trình đã chỉnh sửa. 

Mã Python sau cho bạn thấy cách thêm video được lưu cục bộ vào bài thuyết trình:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Lấy slide đầu tiên và thêm khung video
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Lưu bài thuyết trình vào đĩa
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Ngoài ra, bạn có thể thêm video bằng cách truyền trực tiếp đường dẫn tệp vào phương thức `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Tạo Khung Video với Video từ Nguồn Web**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) hỗ trợ video YouTube trong bài thuyết trình. Nếu video bạn muốn sử dụng có sẵn trực tuyến (ví dụ trên YouTube), bạn có thể thêm nó vào bài thuyết trình thông qua liên kết web của nó. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) 
1. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
1. Thêm một đối tượng [Video](https://reference.aspose.com/slides/vi/python-net/aspose.slides/video/) và truyền liên kết tới video.
1. Đặt hình thu nhỏ cho khung video. 
1. Lưu bài thuyết trình. 

Mã Python sau cho bạn thấy cách thêm video từ web vào một slide trong bài thuyết trình PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Thêm một VideoFrame
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Tải ảnh thu nhỏ
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Quản Lý Phụ Đề Video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bài thuyết trình PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được mở qua thuộc tính [VideoFrame.caption_tracks](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/caption_tracks/) .

**Thêm Phụ Đề vào Khung Video**

Để thêm phụ đề vào khung video:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Thêm một video vào bài thuyết trình.
3. Thêm một đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/) vào một slide.
4. Sử dụng [CaptionsCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/captionscollection/) được trả về bởi [caption_tracks](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/caption_tracks/) để thêm một track phụ đề WebVTT.
5. Lưu bài thuyết trình đã chỉnh sửa.

Mã sau cho bạn thấy cách thêm phụ đề vào khung video:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Thêm một track phụ đề mới từ tệp WebVTT.
    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Lớp [CaptionsCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/captionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng.

**Trích Xuất Phụ Đề từ Khung Video**

Để trích xuất phụ đề từ khung video:

1. Tải bài thuyết trình chứa video.
1. Tìm đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/) mục tiêu.
1. Lặp qua bộ sưu tập [caption_tracks](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/caption_tracks/) .
1. Lưu mỗi track phụ đề vào tệp `.vtt` .

Mã sau cho bạn thấy cách trích xuất phụ đề từ khung video:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Lưu track phụ đề thành tệp WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Mỗi đối tượng [Captions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/captions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và văn bản phụ đề dưới dạng chuỗi UTF-8.

**Xóa Phụ Đề khỏi Khung Video**

Để xóa phụ đề khỏi khung video:

1. Tải bài thuyết trình chứa video.
1. Lấy đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/) mục tiêu.
1. Xóa các track phụ đề khỏi [CaptionsCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/captionscollection/) .
1. Lưu bài thuyết trình đã chỉnh sửa.

Mã sau cho bạn thấy cách xóa tất cả phụ đề khỏi khung video:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # kiểu: slides.VideoFrame

    # Xóa tất cả phụ đề khỏi khung video.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Nếu bạn chỉ cần xóa một track phụ đề, hãy sử dụng phương thức [remove](https://reference.aspose.com/slides/vi/python-net/aspose.slides/captionscollection/remove/) hoặc [remove_at](https://reference.aspose.com/slides/vi/python-net/aspose.slides/captionscollection/remove_at/) thay vì [clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides/captionscollection/clear/) .

## **Trích Xuất Video Từ Slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong các bài thuyết trình.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) để tải bài thuyết trình chứa video. 
2. Lặp qua tất cả các đối tượng [Slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/) .
3. Lặp qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) để tìm một [VideoFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/) . 
4. Lưu video vào đĩa.

Mã Python sau cho bạn thấy cách trích xuất video trên một slide của bài thuyết trình:

```python
import aspose.slides as slides

# Khởi tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **Câu Hỏi Thường Gặp**

**Các tham số phát video nào có thể thay đổi cho VideoFrame?**

Bạn có thể kiểm soát [playback mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/play_mode/) (tự động hoặc khi nhấp) và [looping](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/play_loop_mode/). Các tùy chọn này có sẵn qua các thuộc tính của đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/) .

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng một video cục bộ, dữ liệu nhị phân được bao gồm trong tài liệu, do đó kích thước bài thuyết trình tăng tỉ lệ với kích thước tệp. Khi bạn thêm video trực tuyến, một liên kết và hình thu nhỏ được nhúng, vì vậy mức tăng kích thước nhỏ hơn.

**Tôi có thể thay thế video trong VideoFrame hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể hoán đổi [video content](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/embedded_video/) bên trong khung đồng thời giữ nguyên hình học của shape; đây là một kịch bản thường gặp khi cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Một video được nhúng có [content type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/video/content_type/) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó vào đĩa.