---
title: Quản lý khung video trong bản thuyết trình bằng Python
linktitle: Khung video
type: docs
weight: 10
url: /vi/python-net/video-frame/
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
- bản thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách thêm và trích xuất khung video một cách lập trình trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET. Hướng dẫn nhanh chóng."
---
## **Giới thiệu**

Video có thể giúp giải thích ý tưởng và thu hút khán giả. Aspose.Slides for Python via .NET cho phép bạn thêm khung video vào các slide, điều chỉnh cài đặt phát lại, quản lý phụ đề và trích xuất dữ liệu video được nhúng.

PowerPoint hỗ trợ video cục bộ và liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Để đại diện cho dữ liệu video và khung video, Aspose.Slides cung cấp lớp [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/), lớp [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) và các kiểu liên quan khác.

## **Tạo khung video nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu trữ cục bộ, bạn có thể tạo một khung video để nhúng video vào bản thuyết trình.

Ví dụ này nhúng video cục bộ vào slide đầu tiên của một bản thuyết trình hiện có và lưu kết quả. Tọa độ và kích thước khung được tính bằng điểm. Luồng vẫn mở cho đến khi lưu hoàn tất vì [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) giữ nó khóa trong khi bản thuyết trình đang sử dụng.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Bạn cũng có thể truyền đường dẫn video cục bộ trực tiếp cho [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Ví dụ này nhúng video vào slide đầu tiên của một bản thuyết trình mới. Video phải vẫn có thể truy cập được cho đến khi bản thuyết trình được lưu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Tạo khung video với video từ nguồn web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) hỗ trợ video trực tuyến trong bản thuyết trình. Bạn có thể tạo một khung video liên kết tới video trực tuyến, chẳng hạn như video trên YouTube.

Ví dụ này thêm liên kết và hình thu nhỏ của video YouTube vào slide đầu tiên. Thay đổi định danh video để sử dụng video khác. Cài đặt [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) yêu cầu phát tự động. Tải hình thu nhỏ và phát video yêu cầu truy cập internet. Trình xem bản thuyết trình cũng phải hỗ trợ phát video trực tuyến.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **Phát video ở chế độ toàn màn hình**

Trong một bản thuyết trình đào tạo, bạn có thể phát một bản demo phần mềm ở chế độ toàn màn hình để khán giả có thể thấy chi tiết. Đặt [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) thành `True` để bật hành vi này trong quá trình phát.

Ví dụ này mở một bản thuyết trình, tìm khung [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) đầu tiên trên slide đầu tiên, và bật phát toàn màn hình. Bản thuyết trình đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

Chế độ phát toàn màn hình kiểm soát cách video được hiển thị. Riêng biệt, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) kiểm soát video có bắt đầu tự động hay khi nhấp, và [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) kiểm soát việc lặp lại. Để chọn hành vi khởi động, đặt chế độ phát thành [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). Ví dụ giữ nguyên các cài đặt khởi động và vòng lặp hiện có.

## **Quay lại video sau khi phát**

Trong một bản thuyết trình đào tạo, việc đưa video demo trở lại đầu giúp người thuyết trình có thể phát lại lần nữa. Đặt [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) thành `True` để trả video về đầu sau khi phát xong.

Ví dụ này mở một bản thuyết trình, tìm khung [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) đầu tiên trên slide đầu tiên, và bật tính năng quay lại. Nó tắt vòng lặp để phát có thể kết thúc và đặt chế độ phát bắt đầu khi nhấp. Bản thuyết trình đầu vào phải chứa ít nhất một slide có khung video hiện có trên slide đầu tiên.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

Quay lại trả video về đầu mà không khởi động lại. Ngược lại, bật [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) sẽ lặp lại phát tự động. Giữ vòng lặp tắt khi bạn muốn video kết thúc và sẵn sàng phát lại. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) độc lập kiểm soát khởi động tự động hay khi nhấp; ví dụ này sử dụng [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) để người thuyết trình kiểm soát thời điểm bắt đầu phát. Đặt chế độ phát sau khi thiết lập vòng lặp, như trong ví dụ. Quay lại hoạt động độc lập với [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Cắt khung video**

Sử dụng [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) và [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) để bỏ qua phần đầu hoặc cuối của video trong quá trình phát. Cả hai giá trị đều tính bằng mili giây. Cắt thay đổi cài đặt phát lại mà không sửa đổi dữ liệu video được nhúng.

**Đặt cài đặt cắt**

Ví dụ này nhúng video cục bộ và bỏ qua 2,5 giây đầu và 1 giây cuối trong quá trình phát. Sử dụng video dài hơn 3,5 giây để còn lại phần có thể phát.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Đọc cài đặt cắt**

Ví dụ này in ra các giá trị cắt của khung video đầu tiên trên slide đầu tiên tính bằng mili giây. Bản thuyết trình phải chứa ít nhất một slide. Nếu slide đó không có khung video, sẽ không in gì. Ví dụ trước đưa ra các giá trị 2500 và 1000.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **Quản lý phụ đề video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bản thuyết trình PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được truy cập qua thuộc tính [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

**Thêm phụ đề vào khung video**

Ví dụ này nhúng video cục bộ và thêm một track phụ đề WebVTT có nhãn English. Các dấu thời gian phụ đề phải khớp với video. Bản thuyết trình đã lưu bao gồm cả video và phụ đề của nó.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Lớp [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng.

**Trích xuất phụ đề từ khung video**

Ví dụ này lưu tất cả track phụ đề từ các khung video trên slide đầu tiên dưới dạng các tệp WebVTT riêng biệt. Các số thứ tự liên tiếp giữ cho các tệp đầu ra không trùng nhau. Console báo cáo số lượng track đã trích xuất. Bản thuyết trình phải chứa ít nhất một slide.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

Mỗi đối tượng [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) cung cấp mã định danh phụ đề, nhãn, dữ liệu nhị phân và nội dung phụ đề dưới dạng chuỗi UTF-8.

**Xóa phụ đề khỏi khung video**

Ví dụ này xóa tất cả phụ đề khỏi khung video ở vị trí shape đầu tiên trên slide đầu tiên và lưu kết quả. Nó giả định slide và shape tồn tại và shape là một khung video.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Nếu bạn chỉ cần xóa một track phụ đề, hãy sử dụng phương thức [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) hoặc [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) thay vì [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

## **Trích xuất video từ một slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản thuyết trình.

Ví dụ này trích xuất video nhúng từ mọi slide vào các tệp nhị phân đánh số riêng biệt. Video liên kết bị bỏ qua vì chúng không có dữ liệu được nhúng. Console in ra loại MIME của mỗi video và tổng số. Đầu ra sử dụng phần mở rộng `.bin` chung; hãy thay đổi nó để khớp với loại phương tiện được báo cáo khi cần.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **FAQ**

**Tham số phát lại video nào có thể được thay đổi cho một khung video?**

Bạn có thể kiểm soát [chế độ phát lại](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (tự động hoặc khi nhấp) và [việc lặp lại](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Những tùy chọn này có sẵn qua các thuộc tính của đối tượng [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân được bao gồm trong tài liệu, vì vậy kích thước bản thuyết trình tăng tỷ lệ với kích thước tệp. Khi bạn liên kết tới video trực tuyến và thêm hình thu nhỏ, bản thuyết trình chỉ lưu liên kết và ảnh xem trước thay vì dữ liệu video, do đó mức tăng kích thước thường nhỏ hơn.

**Tôi có thể thay thế video trong một khung video hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể hoán đổi [nội dung video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) trong khung mà vẫn giữ nguyên hình dạng của shape; đây là kịch bản thường gặp để cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video được nhúng không?**

Có. Một video được nhúng có [loại nội dung](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó ra đĩa.