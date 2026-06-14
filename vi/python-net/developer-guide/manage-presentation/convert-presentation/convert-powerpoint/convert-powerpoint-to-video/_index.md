---
title: Chuyển đổi bản trình chiếu PowerPoint sang video trong Python
linktitle: PowerPoint sang Video
type: docs
weight: 130
url: /vi/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint sang video
- chuyển đổi PowerPoint sang video
- bản trình chiếu sang video
- chuyển đổi bản trình chiếu sang video
- PPT sang video
- chuyển đổi PPT sang video
- PPTX sang video
- chuyển đổi PPTX sang video
- ODP sang video
- chuyển đổi ODP sang video
- PowerPoint sang MP4
- chuyển đổi PowerPoint sang MP4
- bản trình chiếu sang MP4
- chuyển đổi bản trình chiếu sang MP4
- PPT sang MP4
- chuyển đổi PPT sang MP4
- PPTX sang MP4
- chuyển đổi PPTX sang MP4
- chuyển đổi PowerPoint sang video
- chuyển đổi bản trình chiếu sang video
- chuyển đổi PPT sang video
- chuyển đổi PPTX sang video
- chuyển đổi ODP sang video
- chuyển đổi video bằng Python
- PowerPoint
- Python
- Aspose.Slides
description: "Tìm hiểu cách chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang video bằng Python. Khám phá mã mẫu và các kỹ thuật tự động hóa để tối ưu hoá quy trình làm việc của bạn."
---
## **Introduction**

Bằng cách chuyển đổi bản trình chiếu PowerPoint hoặc OpenDocument của bạn sang video, bạn sẽ có được:

**Tăng khả năng tiếp cận:** Tất cả các thiết bị, bất kể nền tảng, đều được trang bị bộ phát video theo mặc định, vì vậy người dùng dễ dàng mở hoặc phát video hơn so với các ứng dụng trình chiếu truyền thống.

**Tiếp cận rộng hơn:** Video cho phép bạn tiếp cận đối tượng lớn hơn và trình bày thông tin theo dạng hấp dẫn hơn. Các khảo sát và thống kê cho thấy mọi người thích xem và tiêu thụ nội dung video hơn các hình thức khác, giúp thông điệp của bạn có tác động mạnh mẽ hơn.

{{% alert color="primary" %}} 
Hãy xem công cụ [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/vi/video) của chúng tôi vì nó cung cấp một triển khai trực tiếp và hiệu quả của quá trình được mô tả ở đây.
{{% /alert %}} 

Trong [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/vi/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/), chúng tôi đã triển khai hỗ trợ chuyển đổi bản trình chiếu sang video.

* Sử dụng Aspose.Slides for Python để tạo khung hình từ các slide của bản trình chiếu với tốc độ khung hình (FPS) được chỉ định.
* Sau đó, sử dụng tiện ích bên thứ ba như ffmpeg để gộp các khung hình này thành một video.

## **Chuyển đổi bản trình chiếu PowerPoint sang Video**

1. Sử dụng lệnh pip install để thêm Aspose.Slides for Python vào dự án của bạn: `pip install aspose-slides==24.4.0`
2. Tải ffmpeg từ [here](https://ffmpeg.org/download.html) hoặc cài đặt nó qua trình quản lý gói.
3. Đảm bảo ffmpeg có trong `PATH`. Nếu không, khởi chạy ffmpeg bằng đường dẫn đầy đủ tới tệp thực thi (ví dụ: `C:\ffmpeg\ffmpeg.exe` trên Windows hoặc `/opt/ffmpeg/ffmpeg` trên Linux).
4. Chạy mã chuyển đổi PowerPoint‑to‑video.

Đoạn mã Python này minh họa cách chuyển đổi một bản trình chiếu (chứa một hình dạng và hai hiệu ứng hoạt ảnh) thành video:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```

## **Hiệu ứng video**

Khi chuyển đổi bản trình chiếu PowerPoint sang video bằng Aspose.Slides for Python, bạn có thể áp dụng các hiệu ứng video khác nhau để nâng cao chất lượng hình ảnh của đầu ra. Các hiệu ứng này cho phép bạn kiểm soát cách hiển thị các slide trong video cuối cùng bằng cách thêm chuyển đổi mượt mà, hoạt ảnh và các yếu tố hình ảnh khác. Phần này giải thích các tùy chọn hiệu ứng video có sẵn và cách áp dụng chúng.

{{% alert color="primary" %}} 
Xem [PowerPoint Animation](https://docs.aspose.com/slides/vi/python-net/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/vi/python-net/shape-animation/), và [Shape Effect](https://docs.aspose.com/slides/vi/python-net/shape-effect/).
{{% /alert %}} 

Hoạt ảnh và chuyển đổi làm cho slideshow trở nên sinh động và thú vị — và chúng cũng làm tương tự cho video. Hãy thêm một slide và chuyển đổi khác vào mã cho bản trình chiếu trước:

```python
import aspose.pydrawing as drawing

# Thêm hình cười và tạo hoạt ảnh cho nó.
# ...

# Thêm một slide mới và một chuyển đổi có hoạt ảnh.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python cũng hỗ trợ hoạt ảnh văn bản. Trong ví dụ này, chúng tôi hoạt họa các đoạn văn trên các đối tượng sao cho chúng xuất hiện lần lượt, mỗi đoạn cách nhau một giây:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Thêm văn bản và hoạt ảnh.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Chuyển khung hình sang video.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Các lớp chuyển đổi video**

Để thực hiện các tác vụ chuyển đổi PowerPoint sang video, Aspose.Slides for Python cung cấp [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/presentationenumerableframesgenerator/).

`PresentationEnumerableFramesGenerator` cho phép bạn đặt kích thước khung cho video (sẽ được tạo sau) và giá trị FPS (khung hình mỗi giây) thông qua hàm khởi tạo của nó. Nếu bạn truyền một thể hiện của bản trình chiếu, `Presentation.SlideSize` của nó sẽ được sử dụng.

Để làm cho tất cả hoạt ảnh trong một bản trình chiếu phát đồng thời, sử dụng phương thức `PresentationEnumerableFramesGenerator.enumerate_frames`. Phương thức này nhận một bộ sưu tập các slide và trả về tuần tự các [EnumerableFrameArgs](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/enumerableframeargs/). Sau đó, sử dụng `EnumerableFrameArgs.get_frame()` để lấy từng khung video.

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

Sau đó các khung đã tạo có thể được gộp lại thành video. Để biết chi tiết hơn, xem phần [Convert PowerPoint to Video](https://docs.aspose.com/slides/vi/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Các hoạt ảnh và hiệu ứng được hỗ trợ**

Khi chuyển đổi bản trình chiếu PowerPoint sang video bằng Aspose.Slides for Python, việc hiểu các hoạt ảnh và hiệu ứng nào được hỗ trợ trong đầu ra là rất quan trọng. Aspose.Slides hỗ trợ nhiều loại hiệu ứng vào, ra và nhấn mạnh thông thường như mờ dần, bay vào, thu phóng và xoay. Tuy nhiên, một số hoạt ảnh nâng cao hoặc tùy chỉnh có thể không được bảo toàn hoàn toàn hoặc có thể xuất hiện khác biệt trong video cuối cùng. Phần này liệt kê các hoạt ảnh và hiệu ứng được hỗ trợ.

**Vào**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Nhấn mạnh**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Thoát**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Đường chuyển động**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Các hiệu ứng chuyển đổi slide được hỗ trợ**

Hiệu ứng chuyển đổi slide đóng vai trò quan trọng trong việc tạo ra các chuyển đổi mượt mà và hấp dẫn giữa các slide trong video. Aspose.Slides for Python hỗ trợ nhiều hiệu ứng chuyển đổi phổ biến để giúp duy trì luồng và phong cách của bản trình chiếu gốc. Phần này nêu bật các hiệu ứng chuyển đổi được hỗ trợ trong quá trình chuyển đổi.

**Nhẹ nhàng**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Sôi động**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Nội dung động**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Có thể chuyển đổi các bản trình chiếu được bảo vệ bằng mật khẩu không?**

Có, Aspose.Slides for Python cho phép làm việc với các bản trình chiếu được bảo vệ bằng mật khẩu. Khi xử lý các tệp này, bạn cần cung cấp mật khẩu đúng để thư viện có thể truy cập nội dung của bản trình chiếu.

**Aspose.Slides for Python có hỗ trợ sử dụng trong các giải pháp đám mây không?**

Có, Aspose.Slides for Python có thể được tích hợp vào các ứng dụng và dịch vụ đám mây. Thư viện được thiết kế để hoạt động trong môi trường máy chủ, đảm bảo hiệu năng cao và khả năng mở rộng cho việc xử lý hàng loạt các tệp.

**Có giới hạn về kích thước của bản trình chiếu khi chuyển đổi không?**

Aspose.Slides for Python có khả năng xử lý các bản trình chiếu với kích thước hầu như bất kỳ. Tuy nhiên, khi làm việc với các tệp rất lớn, có thể cần thêm tài nguyên hệ thống và đôi khi nên tối ưu hóa bản trình chiếu để cải thiện hiệu suất.