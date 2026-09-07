---
title: Chuyển đổi bản thuyết trình PowerPoint sang video trong Python
linktitle: PowerPoint sang Video
type: docs
weight: 130
url: /vi/python-java/convert-powerpoint-to-video/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản thuyết trình
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang video
- bản thuyết trình sang video
- PPT sang video
- PPTX sang video
- PowerPoint sang MP4
- bản thuyết trình sang MP4
- PPT sang MP4
- PPTX sang MP4
- lưu PPT dưới dạng MP4
- lưu PPTX dưới dạng MP4
- xuất PPT sang MP4
- xuất PPTX sang MP4
- chuyển đổi video
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi bản thuyết trình PowerPoint sang video MP4 trong Python thông qua Java. Tạo khung hình với Aspose.Slides và mã hoá chúng bằng FFmpeg, bao gồm các hoạt ảnh và chuyển tiếp."
---
## **Tổng quan**

Chuyển đổi một bản thuyết trình PowerPoint hoặc OpenDocument sang video cho phép người xem xem nội dung trong một trình phát video mà không cần mở ứng dụng thuyết trình. Aspose.Slides for Python via Java chuyển đổi các hoạt ảnh và chuyển tiếp của bản thuyết trình thành các khung hình ảnh. Một bộ mã hoá riêng, chẳng hạn FFmpeg, sẽ ghép các khung này lại thành một tệp video.

{{% alert color="info" title="Lưu ý" %}}
Thử công cụ trực tuyến [PowerPoint to Video converter](https://products.aspose.app/slides/vi/video) để xem quá trình chuyển đổi bản thuyết trình sang video hoạt động như thế nào.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang Video**

Quá trình chuyển đổi có hai giai đoạn: tạo các khung PNG ở tốc độ khung được chọn, sau đó mã hoá chuỗi hình ảnh thành MP4. Sử dụng cùng một tốc độ khung ở cả hai giai đoạn để giữ nguyên thời gian hoạt ảnh.

Trước khi chạy ví dụ:

1. Cài đặt [Aspose.Slides for Python via Java](/slides/vi/python-java/installation/).
2. Tải xuống [FFmpeg](https://ffmpeg.org/download.html) và đưa tệp thực thi của nó vào `PATH`. Ví dụ sử dụng bản dựng có bộ mã hoá `libx264`.
3. Chạy đoạn mã Python sau trong một thư mục có quyền ghi.

Ví dụ tạo một hình dạng cười với hoạt ảnh nhập và xuất, tạo khung ở 30 FPS và gọi FFmpeg để tạo `output.mp4`. Thư mục khung mới ngăn các khung từ các lần chạy trước bị đưa vào video.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

Để chuyển đổi một tệp hiện có, khởi tạo [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) bằng đường dẫn của nó và bỏ qua các câu lệnh tạo hình dạng và tạo hoạt ảnh.

Lệnh FFmpeg đọc một [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2) được đánh số, bổ sung các kích thước lẻ thành chẵn và ghi video H.264 với định dạng pixel `yuv420p`. Tùy chọn `-n` ngăn ghi đè lên tệp đầu ra đã tồn tại. Các tệp PNG được tạo sẽ vẫn còn trong thư mục khung; hãy xóa chúng khi không còn cần thiết.

{{% alert color="info" title="Lưu ý" %}}
Ví dụ này chỉ mã hoá các khung hình ảnh. Nó không thêm lời thoại hay âm thanh bản thuyết trình được nhúng vào video đầu ra.
{{% /alert %}}

## **Hiệu ứng Video**

Hoạt ảnh điều khiển cách các đối tượng trên slide xuất hiện, di chuyển hoặc biến mất. Chuyển tiếp điều khiển sự thay đổi giữa các slide. Thêm các hiệu ứng này trước khi tạo khung video.

Xem [PowerPoint Animation](/slides/vi/python-java/powerpoint-animation/), [Shape Animation](/slides/vi/python-java/shape-animation/), [Shape Effects](/slides/vi/python-java/shape-effect/), và [Slide Transitions](/slides/vi/python-java/slide-transition/).

### **Thêm Chuyển tiếp Slide**

Ví dụ tự chứa sau tạo một bản thuyết trình với hai slide. Slide thứ hai có nền màu hồng tươi và chuyển tiếp kiểu đẩy. Lưu bản thuyết trình, sau đó dùng nó làm đầu vào cho ví dụ tạo khung ở trên.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Hoạt ảnh Đoạn Văn**

Văn bản có thể xuất hiện từng đoạn một. Ví dụ này tạo ba đoạn văn với hiệu ứng nhập mờ dần tuần tự, mỗi đoạn trì hoãn một giây sau hiệu ứng trước. Sử dụng tệp `paragraphs.pptx` đã lưu làm đầu vào cho ví dụ chuyển đổi video.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Các lớp Chuyển đổi Video**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationanimationsgenerator/) tạo các sự kiện hoạt ảnh cho các slide. Khi khởi tạo từ một bản thuyết trình, nó sử dụng kích thước slide của bản thuyết trình để xác định kích thước khung. Sử dụng [setDefaultDelay](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) để cấu hình độ trễ mặc định tính bằng mili giây.

[PresentationPlayer](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationplayer/) lấy mẫu các hoạt ảnh đã tạo ở tốc độ khung được cung cấp cho hàm khởi tạo. Đăng ký một callback Python qua JPype bằng [setFrameTick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationplayer/#setFrameTick), sau đó gọi [run](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationanimationsgenerator/#run) để tạo các khung. Ví dụ đầu tiên dùng bộ đếm bắt đầu từ 0 riêng của nó để tên tệp khớp với chuỗi đầu vào của FFmpeg.

Đối với các trạng thái hoạt ảnh riêng lẻ, đăng ký một callback bằng [setNewAnimation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). Callback nhận một trình phát hoạt ảnh có thể được đặt tại thời điểm đã chọn. Ví dụ dưới đây lưu khung đầu và cuối của mỗi hoạt ảnh đã tạo với tên tệp duy nhất:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **Các Hoạt ảnh và Hiệu ứng được Hỗ trợ**

Các bảng sau tóm tắt mức độ hỗ trợ render được mô tả trong bài viết chuyển đổi Java. Xem trước các khung đã tạo khi bản thuyết trình sử dụng các hiệu ứng chưa được hỗ trợ.

**Entrance**:

| Loại Hoạt ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | Không | Có |
| **Fade** | Có | Có |
| **Fly In** | Có | Có |
| **Float In** | Có | Có |
| **Split** | Có | Có |
| **Wipe** | Có | Có |
| **Shape** | Có | Có |
| **Wheel** | Có | Có |
| **Random Bars** | Có | Có |
| **Grow & Turn** | Không | Có |
| **Zoom** | Có | Có |
| **Swivel** | Có | Có |
| **Bounce** | Có | Có |

**Emphasis**:

| Loại Hoạt ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | Không | Có |
| **Color Pulse** | Không | Có |
| **Teeter** | Có | Có |
| **Spin** | Có | Có |
| **Grow/Shrink** | Không | Có |
| **Desaturate** | Không | Có |
| **Darken** | Không | Có |
| **Lighten** | Không | Có |
| **Transparency** | Không | Có |
| **Object Color** | Không | Có |
| **Complementary Color** | Không | Có |
| **Line Color** | Không | Có |
| **Fill Color** | Không | Có |

**Exit**:

| Loại Hoạt ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | Không | Có |
| **Fade** | Có | Có |
| **Fly Out** | Có | Có |
| **Float Out** | Có | Có |
| **Split** | Có | Có |
| **Wipe** | Có | Có |
| **Shape** | Có | Có |
| **Random Bars** | Có | Có |
| **Shrink & Turn** | Không | Có |
| **Zoom** | Có | Có |
| **Swivel** | Có | Có |
| **Bounce** | Có | Có |

**Motion Paths**:

| Loại Hoạt ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Có | Có |
| **Arcs** | Có | Có |
| **Turns** | Có | Có |
| **Shapes** | Có | Có |
| **Loops** | Có | Có |
| **Custom Path** | Có | Có |

## **Câu hỏi thường gặp**

**Aspose.Slides có tạo tệp MP4 trực tiếp không?**

Không. Aspose.Slides tạo các khung của bản thuyết trình. Sử dụng bộ mã hoá video như FFmpeg để ghép chúng thành tệp MP4.

**Tại sao video phát nhanh hoặc chậm hơn mong đợi?**

Sử dụng cùng FPS cho việc tạo khung và tốc độ khung đầu vào của bộ mã hoá. Sự không khớp sẽ làm thay đổi thời lượng phát lại của chuỗi hình ảnh.

**Tôi có thể chuyển đổi bản thuyết trình được bảo vệ bằng mật khẩu không?**

Có. Cung cấp mật khẩu đúng khi [loading the protected presentation](/slides/vi/python-java/password-protected-presentation/), sau đó tạo khung từ nội dung đã tải.

**Quy trình này có bảo lưu âm thanh của bản thuyết trình không?**

Các ví dụ xuất các khung hình ảnh, vì vậy video tạo ra sẽ không có âm thanh. Để bao gồm âm thanh, bạn cần cung cấp một track âm thanh riêng trong quá trình mã hoá video.

**Làm sao giảm việc sử dụng đĩa tạm?**

Sử dụng kích thước khung nhỏ hơn hoặc FPS thấp hơn, và xóa các tệp PNG tạm sau khi mã hoá thành công. Kiểm tra chất lượng video kết quả khi giảm bất kỳ cài đặt nào.