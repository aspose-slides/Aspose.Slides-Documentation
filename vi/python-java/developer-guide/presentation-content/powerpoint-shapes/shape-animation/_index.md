---
title: Áp dụng hoạt ảnh hình dạng trong bản trình bày bằng Python qua Java
linktitle: Hoạt ảnh Hình dạng
type: docs
weight: 60
url: /vi/python-java/shape-animation/
keywords:
- hình dạng
- hoạt ảnh
- hiệu ứng
- hình dạng động
- văn bản động
- thêm hoạt ảnh
- lấy hoạt ảnh
- trích xuất hoạt ảnh
- thêm hiệu ứng
- lấy hiệu ứng
- trích xuất hiệu ứng
- âm thanh hiệu ứng
- áp dụng hoạt ảnh
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm, kiểm tra và tùy chỉnh hoạt ảnh hình dạng, thời gian, âm thanh, hành vi sau hoạt ảnh và văn bản động với Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Aspose.Slides for Python via Java biểu diễn hoạt ảnh slide dưới dạng các hiệu ứng trong một dòng thời gian slide. Mỗi hiệu ứng có hình dạng mục tiêu, kiểu và phụ hiệu ứng, bộ kích hoạt, cài đặt thời gian và các thuộc tính tùy chọn như âm thanh hoặc hành vi sau khi hiệu ứng kết thúc.

Dòng thời gian chứa hai loại chuỗi:

- **Chuỗi chính** phát khi slide được chuyển tiếp.
- **Chuỗi tương tác** bắt đầu khi hình dạng kích hoạt của nó được nhấp.

Vì các hộp văn bản, hình ảnh, biểu đồ, bảng và các đối tượng slide khác kế thừa từ [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/), bạn sử dụng cùng một phương thức [Sequence.addEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/#addEffect) cho hầu hết nội dung slide. Các hiệu ứng có sẵn được liệt kê trong lớp [EffectType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effecttype/).

## **Thêm hoạt ảnh cho hình dạng**

Để thêm một hoạt ảnh, lấy chuỗi chính của slide và gọi [Sequence.addEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/#addEffect) với hình dạng mục tiêu, kiểu hiệu ứng, phụ hiệu ứng và bộ kích hoạt. Đối với hiệu ứng bắt đầu khi một hình dạng khác được nhấp, tạo một chuỗi tương tác có bộ kích hoạt là hình dạng đó.

Ví dụ dưới đây tạo cả hai loại hoạt ảnh và lưu kết quả vào `shape-animations.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bộ kích hoạt xác định thời điểm một hiệu ứng bắt đầu:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effecttriggertype/#OnClick) chờ một cú nhấp trong chuỗi chính, hoặc một cú nhấp vào hình dạng kích hoạt trong chuỗi tương tác.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effecttriggertype/#WithPrevious) bắt đầu cùng với hiệu ứng trước.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effecttriggertype/#AfterPrevious) bắt đầu khi hiệu ứng trước kết thúc.

Để tạo hoạt ảnh cho hình ảnh, biểu đồ hoặc loại hình dạng khác, truyền đối tượng đó vào [Sequence.addEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/#addEffect) thay vì `target_shape`. Đối với các tùy chọn nhóm đặc thù của biểu đồ, xem [Animated Charts](/slides/vi/python-java/animated-charts/).

## **Đọc hoạt ảnh của hình dạng**

Sử dụng [Sequence.getEffectsByShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/#getEffectsByShape) khi bạn biết hình dạng mục tiêu. Để kiểm tra mọi hiệu ứng, duyệt chuỗi chính và mọi chuỗi tương tác. Việc duyệt giúp tránh giả định rằng một chuỗi có hiệu ứng ở chỉ mục `0`.

Ví dụ dưới đây tạo một hình dạng có hiệu ứng chuỗi chính và chuỗi tương tác, lấy các hiệu ứng mục tiêu hình dạng, và sau đó duyệt mọi chuỗi trên slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

Nếu bạn chỉ cần các hiệu ứng cho một hình dạng, trước tiên xác định hình dạng bằng tên, loại placeholder hoặc thuộc tính ổn định khác; sau đó gọi [Sequence.getEffectsByShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/#getEffectsByShape). Đừng giả định rằng [ShapeCollection.get_Item](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#get_Item) ở chỉ mục `0` luôn là đối tượng mong muốn.

## **Làm việc với hiệu ứng Placeholder kế thừa**

Một placeholder trên slide bình thường có thể kế thừa hành vi hoạt ảnh từ placeholder tương ứng trên slide bố cục và slide master. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getBasePlaceholder) trả về placeholder cha đó, hoặc `None` khi không có cha.

Trong bản trình bày mẫu dưới đây, phần chân trang có **Random Bars** trên slide bình thường, **Split** trên slide bố cục và **Fly In** trên slide master.

![Hiệu ứng hoạt ảnh chân trang trên slide bình thường](slide-shape-animation.png)

![Hiệu ứng hoạt ảnh placeholder chân trang trên slide bố cục](layout-shape-animation.png)

![Hiệu ứng hoạt ảnh placeholder chân trang trên slide master](master-shape-animation.png)

Ví dụ tiếp theo sử dụng một cấu trúc placeholder từ một bản trình bày mới. Nó thêm hiệu ứng vào placeholder master, placeholder layout và placeholder tương ứng trên slide bình thường. Mọi lần gọi [Shape.getBasePlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getBasePlaceholder) đều được kiểm tra trước khi sử dụng shape trả về.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thay đổi thời gian hoạt ảnh**

Hộp thoại **Timing** của PowerPoint ánh xạ tới các thuộc tính của [Timing](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/).

![Hộp thoại Timing của PowerPoint cho một hiệu ứng hoạt ảnh](shape-animation.png)

- **Start** ánh xạ tới [Timing.getTriggerType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getTriggerType).
- **Duration** ánh xạ tới [Timing.getDuration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getDuration), tính bằng giây.
- **Delay** ánh xạ tới [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getTriggerDelayTime), tính bằng giây.
- **Repeat** ánh xạ tới [Timing.getRepeatCount](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getRepeatUntilNextClick) hoặc [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** ánh xạ tới [Timing.getRewind](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getRewind).

Ví dụ độc lập này thêm một hiệu ứng, thay đổi thời gian của nó thông qua đối tượng trả về bởi [Sequence.addEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/#addEffect), và lưu kết quả. Giữ tham chiếu tới [Effect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effect/) trả về tránh việc phải truy cập chỉ mục bộ sưu tập không cần thiết.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sử dụng một chế độ lặp duy nhất. Kết hợp số lần lặp với cờ “until” có thể gây ra kết quả khó hiểu trên các trình xem khác nhau. Khi thay đổi chế độ lặp, hãy gọi [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#setRepeatUntilNextClick) và [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) trước [Timing.setRepeatCount](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#setRepeatCount), vì việc đặt bất kỳ cờ nào cũng sẽ thay đổi chế độ lặp đang hoạt động.

## **Thêm và trích xuất âm thanh cho hoạt ảnh**

Một hiệu ứng hoạt ảnh có thể tham chiếu tới âm thanh nhúng thông qua [Effect.getSound](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effect/#setStopPreviousSound) chỉ định hiệu ứng dừng âm thanh đã được khởi động bởi hiệu ứng trước đó.

### **Thêm âm thanh vào một hiệu ứng**

Ví dụ dưới đây yêu cầu một tệp âm thanh cục bộ có tên `animation-sound.wav`. Nó tạo hai hiệu ứng, nhúng tệp này làm âm thanh cho hiệu ứng đầu tiên, và cấu hình hiệu ứng thứ hai để dừng âm thanh. Nó sử dụng các đối tượng trả về bởi [Sequence.addEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/#addEffect), vì vậy không cần chỉ mục chuỗi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Trích xuất âm thanh hiệu ứng nhúng**

Ví dụ dưới đây yêu cầu một bản trình bày cục bộ có tên `presentation-with-animation-sounds.pptx`. Nó quét cả chuỗi chính và chuỗi tương tác và ghi mọi âm thanh hiệu ứng nhúng vào thư mục `extracted-animation-sounds`. Phần mở rộng được chọn dựa trên MIME type của âm thanh được trả về bởi [Audio.getContentType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audio/#getContentType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"
    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

Đối với các đối tượng âm thanh lớn, sử dụng [Audio.getStream](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audio/#getStream) và sao chép luồng vào tệp thay vì tải toàn bộ đối tượng vào mảng byte.

## **Đặt hành vi sau hoạt ảnh**

Tùy chọn **After animation** điều khiển điều gì sẽ xảy ra với một hình dạng sau khi hiệu ứng của nó kết thúc.

![Hộp thoại Options của PowerPoint hiển thị cài đặt After animation](shape-after-animation.png)

Lớp [AfterAnimationType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/afteranimationtype/) hỗ trợ giữ nguyên hình dạng, thay đổi màu, ẩn nó sau hoạt ảnh, hoặc ẩn nó ở lần nhấp tiếp theo. Khi loại là [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/python-java/aspose.slides/afteranimationtype/#Color), cũng phải đặt [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effect/#getAfterAnimationColor).

Ví dụ độc lập này tạo một hiệu ứng, đặt hành vi sau hoạt ảnh thông qua đối tượng hiệu ứng trả về, và lưu kết quả.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Thay đổi loại khỏi [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/python-java/aspose.slides/afteranimationtype/#Color) sẽ xóa cài đặt màu sau hoạt ảnh.

## **Hoạt ảnh văn bản**

Hoạt ảnh văn bản có hai điều khiển liên quan:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textanimation/#getBuildType) kiểm soát việc các đoạn văn xuất hiện cùng nhau hay theo mức độ đoạn.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effect/#getAnimateTextType) kiểm soát việc văn bản xuất hiện toàn bộ, theo từ hoặc theo ký tự. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effect/#getDelayBetweenTextParts) đặt độ trễ giữa các từ hoặc ký tự. Giá trị dương là phần trăm của thời lượng hiệu ứng; giá trị âm là độ trễ tính bằng giây.

Ví dụ độc lập dưới đây hoạt ảnh các từ trong một hộp văn bản. [BuildType.AsOneObject](https://reference.aspose.com/slides/vi/python-java/aspose.slides/buildtype/#AsOneObject) tắt việc xây dựng từng đoạn, để cài đặt từ áp dụng cho toàn bộ khung văn bản.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Để xây dựng một hộp văn bản theo đoạn, đặt [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/vi/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (hoặc mức độ đoạn khác). Để mục tiêu một đoạn riêng với hiệu ứng riêng, sử dụng phương thức overload của [Sequence.addEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/#addEffect) nhận một [Paragraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/). Xem [Animated Text](/slides/vi/python-java/animated-text/) để có các ví dụ cấp đoạn.

## **Xuất và ghi chú về khả năng tương thích**

- Lưu thành PPT hoặc PPTX giữ lại mô hình hoạt ảnh, nhưng việc phát lại cuối cùng phụ thuộc vào trình xem bản trình bày.
- PDF và hình ảnh tĩnh không phát hoạt ảnh. Sử dụng [HTML5 export](/slides/vi/python-java/export-to-html5/), GIF động, hoặc [video conversion](/slides/vi/python-java/convert-powerpoint-to-video/) khi đầu ra cần hiển thị chuyển động.
- Đối với HTML5, bật [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setAnimateShapes) và, khi cần, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/html5options/#setAnimateTransitions).
- Kết xuất video hỗ trợ nhiều hiệu ứng vào, nhấn mạnh, thoát và đường di chuyển phổ biến, nhưng không phải mọi hiệu ứng PowerPoint đều được hỗ trợ. Kiểm tra bảng [supported animations and effects](/slides/vi/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) hiện tại và thử nghiệm các bản trình bày quan trọng với phiên bản Aspose.Slides bạn đang dùng.
- Các hiệu ứng tùy chỉnh nâng cao và các hiệu ứng nhập khẩu từ định dạng bản trình bày khác có thể được giữ trong tệp nhưng sẽ hiển thị khác nhau trong PowerPoint, HTML5 hoặc video. Xác nhận kết quả xuất thay vì chỉ dựa vào tên hiệu ứng.

## **Câu hỏi thường gặp**

**Tại sao một hoạt ảnh xuất hiện trong PowerPoint mà không xuất hiện trong PDF?**

PDF là định dạng tĩnh, vì vậy hoạt ảnh và chuyển đổi slide không được phát. Xuất sang HTML5, GIF động hoặc video khi cần duy trì chuyển động.

**Tại sao một hiệu ứng phát khác nhau trong video?**

Xuất video thực hiện render hoạt ảnh thay vì lưu hành vi gốc của PowerPoint. Một số hiệu ứng nâng cao không được hỗ trợ hoặc chỉ được ước tính. Xem bảng hiệu ứng được hỗ trợ và thử nghiệm bản trình bày thực tế trước khi sử dụng trong sản xuất.

**Di chuyển một hình dạng lên phía trước hoặc phía sau có thay đổi thứ tự hoạt ảnh không?**

Không. Z‑order của hình dạng chỉ điều khiển chồng chập, trong khi thứ tự chuỗi và bộ kích hoạt điều khiển việc phát hoạt ảnh. Thay đổi dòng thời gian nếu bạn cần một thứ tự phát khác.