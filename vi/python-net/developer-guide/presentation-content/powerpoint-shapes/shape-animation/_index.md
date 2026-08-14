---
title: Áp dụng Hoạt ảnh Hình dạng trong Bản trình bày với Python
linktitle: Hoạt ảnh Hình dạng
type: docs
weight: 60
url: /vi/python-net/shape-animation/
keywords:
- hình dạng
- hoạt ảnh
- hiệu ứng
- hình dạng hoạt ảnh
- văn bản hoạt ảnh
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
- Aspose.Slides
description: "Tìm hiểu cách thêm, kiểm tra và tùy chỉnh hoạt ảnh hình dạng, thời gian, âm thanh, hành vi sau hoạt ảnh và văn bản hoạt ảnh với Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Aspose.Slides for Python via .NET đại diện cho các hoạt ảnh slide dưới dạng các hiệu ứng trong dòng thời gian của slide. Một hiệu ứng có một hình dạng mục tiêu, một loại và phụ loại hoạt ảnh, một trình kích hoạt, các cài đặt thời gian, và các thuộc tính tùy chọn như âm thanh hoặc hành vi sau hoạt ảnh.

Dòng thời gian chứa hai loại chuỗi:

- **Chuỗi chính** phát khi slide tiến hành.
- Một **chuỗi tương tác** bắt đầu khi hình dạng kích hoạt của nó được nhấp.

Vì các hộp văn bản, hình ảnh, biểu đồ, bảng và các đối tượng slide khác triển khai [IShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ishape/), bạn sử dụng cùng một phương thức [Sequence.add_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/add_effect/) cho phần lớn nội dung slide. Các hiệu ứng có sẵn được liệt kê trong enumeration [EffectType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effecttype/).

## **Thêm Hoạt ảnh Hình dạng**

Để thêm một hoạt ảnh, lấy chuỗi chính của slide và gọi [Sequence.add_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/add_effect/) với hình dạng mục tiêu, loại hiệu ứng, phụ loại và trình kích hoạt. Đối với một hiệu ứng bắt đầu khi một hình dạng khác được nhấp, tạo một chuỗi tương tác mà trình kích hoạt là hình dạng khác đó.

Ví dụ sau tạo cả hai loại hoạt ảnh và lưu kết quả vào `shape-animations.pptx`.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

Trình kích hoạt kiểm soát thời điểm một hiệu ứng bắt đầu:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effecttriggertype/) chờ một cú nhấp trong chuỗi chính, hoặc một cú nhấp vào hình dạng kích hoạt trong chuỗi tương tác.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effecttriggertype/) bắt đầu cùng với hiệu ứng trước đó.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effecttriggertype/) bắt đầu khi hiệu ứng trước đó kết thúc.

Để hoạt ảnh một hình ảnh, biểu đồ, hoặc một loại hình dạng khác, truyền đối tượng đó vào [Sequence.add_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/add_effect/) thay vì `target_shape`. Đối với các tùy chọn nhóm đặc thù của biểu đồ, xem [Animated Charts](/slides/vi/python-net/animated-charts/).

## **Đọc Hoạt ảnh Hình dạng**

Sử dụng [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) khi bạn biết hình dạng mục tiêu. Để kiểm tra mọi hiệu ứng, lặp qua chuỗi chính và mọi chuỗi tương tác. Việc lặp tránh việc giả định rằng một chuỗi chứa hiệu ứng tại chỉ mục `0`.

Ví dụ sau tạo một hình dạng với hiệu ứng chuỗi‑chính và chuỗi‑tương‑tác, lấy các hiệu ứng nhắm vào hình dạng đó, và sau đó lặp qua mọi chuỗi trên slide.

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

Nếu bạn chỉ cần các hiệu ứng cho một hình dạng, trước hết xác định hình dạng bằng tên, loại placeholder, hoặc thuộc tính ổn định khác; sau đó gọi [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/get_effects_by_shape/). Đừng giả định rằng hình dạng tại chỉ mục `0` luôn là đối tượng mong muốn.

## **Làm việc với Hiệu ứng Placeholder Kế thừa**

Một placeholder trên slide bình thường có thể kế thừa hành vi hoạt ảnh từ placeholder tương ứng trên slide bố cục và slide chủ. [Shape.get_base_placeholder](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_base_placeholder/) trả về placeholder cha đó, hoặc `None` khi không có cha.

Trong bản trình bày mẫu dưới đây, phần chân trang có **Random Bars** trên slide bình thường, **Split** trên slide bố cục, và **Fly In** trên slide chủ.

![Hiệu ứng hoạt ảnh chân trang trên slide bình thường](slide-shape-animation.png)

![Hiệu ứng hoạt ảnh placeholder chân trang trên slide bố cục](layout-shape-animation.png)

![Hiệu ứng hoạt ảnh placeholder chân trang trên slide chủ](master-shape-animation.png)

Ví dụ tiếp theo tự xây dựng cấu trúc placeholder. Nó thêm hiệu ứng vào một placeholder chủ, một placeholder bố cục, và placeholder tương ứng trên một slide bình thường. Mọi lần gọi [Shape.get_base_placeholder](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_base_placeholder/) đều được kiểm tra trước khi sử dụng hình dạng trả về.

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **Thay đổi Thời gian Hoạt ảnh**

Hộp thoại **Timing** của PowerPoint ánh xạ tới các thuộc tính của [Timing](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/).

![Hộp thoại Timing của PowerPoint cho một hiệu ứng hoạt ảnh](shape-animation.png)

- **Bắt đầu** ánh xạ tới [Timing.trigger_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/trigger_type/).
- **Thời lượng** ánh xạ tới [Timing.duration](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/duration/), tính bằng giây.
- **Độ trễ** ánh xạ tới [Timing.trigger_delay_time](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/trigger_delay_time/), tính bằng giây.
- **Lặp lại** ánh xạ tới [Timing.repeat_count](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/repeat_until_next_click/), hoặc [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Quay lại khi phát xong** ánh xạ tới [Timing.rewind](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/rewind/).

Ví dụ độc lập này thêm một hiệu ứng, thay đổi thời gian của nó thông qua đối tượng trả về bởi [Sequence.add_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/add_effect/), và lưu kết quả. Giữ tham chiếu tới [Effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effect/) trả về giúp tránh một chỉ mục bộ sưu tập không cần thiết.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

Sử dụng một chế độ lặp lại duy nhất một cách có chủ đích. Kết hợp số lần lặp lại với cờ “until” có thể tạo ra kết quả gây nhầm lẫn trong các trình xem khác nhau. Khi thay đổi chế độ lặp lại, đặt [Timing.repeat_until_next_click](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/repeat_until_next_click/) và [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) trước [Timing.repeat_count](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/repeat_count/), vì việc đặt bất kỳ cờ nào cũng sẽ thay đổi chế độ lặp lại đang hoạt động.

## **Thêm và Trích xuất Âm thanh Hoạt ảnh**

Một hiệu ứng hoạt ảnh có thể tham chiếu tới âm thanh nhúng thông qua [Effect.sound](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effect/sound/). [Effect.stop_previous_sound](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effect/stop_previous_sound/) chỉ cho một hiệu ứng dừng âm thanh đã được khởi động bởi một hiệu ứng trước đó.

### **Thêm Âm thanh vào Hiệu ứng**

Ví dụ sau yêu cầu một tệp âm thanh cục bộ tên `animation-sound.wav`. Nó tạo hai hiệu ứng, nhúng tệp đó làm âm thanh cho hiệu ứng đầu tiên, và cấu hình hiệu ứng thứ hai để dừng âm thanh. Nó sử dụng các đối tượng trả về bởi [Sequence.add_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/add_effect/), vì vậy không cần chỉ mục chuỗi.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **Trích xuất Âm thanh Hiệu ứng Được nhúng**

Ví dụ sau yêu cầu một bản trình bày cục bộ tên `presentation-with-animation-sounds.pptx`. Nó quét cả chuỗi‑chính và chuỗi‑tương‑tác và ghi mỗi âm thanh hiệu ứng được nhúng vào thư mục `extracted-animation-sounds`. Phần mở rộng được chọn từ MIME type âm thanh được cung cấp bởi [Audio.content_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/audio/content_type/).

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

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
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

Đối với các đối tượng âm thanh lớn, sử dụng [Audio.get_stream](https://reference.aspose.com/slides/vi/python-net/aspose.slides/audio/get_stream/) và sao chép luồng vào tệp thay vì tải toàn bộ đối tượng vào một mảng byte.

## **Đặt Hành vi Sau Hoạt ảnh**

Tùy chọn **After animation** kiểm soát những gì xảy ra với một hình dạng sau khi hiệu ứng của nó kết thúc.

![Hộp thoại Options của PowerPoint hiển thị các cài đặt After animation](shape-after-animation.png)

Enumeration [AfterAnimationType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/afteranimationtype/) hỗ trợ để lại hình dạng không thay đổi, thay đổi màu, ẩn nó sau hoạt ảnh, hoặc ẩn nó ở lần nhấp tiếp theo. Khi loại là [AfterAnimationType.COLOR](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/afteranimationtype/), cũng đặt [Effect.after_animation_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effect/after_animation_color/).

Ví dụ độc lập này tạo một hiệu ứng, đặt hành vi sau hoạt ảnh thông qua đối tượng hiệu ứng trả về, và lưu kết quả.

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

Thay đổi loại khỏi [AfterAnimationType.COLOR](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/afteranimationtype/) sẽ xóa cài đặt màu sau hoạt ảnh.

## **Hoạt ảnh Văn bản**

Hoạt ảnh văn bản có hai điều khiển liên quan:

- [TextAnimation.build_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/textanimation/build_type/) kiểm soát việc các đoạn văn xuất hiện cùng nhau hay theo mức đoạn.
- [Effect.animate_text_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effect/animate_text_type/) kiểm soát việc văn bản xuất hiện một lần, theo từ, hoặc theo ký tự. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effect/delay_between_text_parts/) đặt độ trễ giữa các từ hoặc ký tự. Giá trị dương là phần trăm của thời lượng hiệu ứng; giá trị âm là độ trễ tính bằng giây.

Ví dụ độc lập sau hoạt ảnh các từ trong một hộp văn bản. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/buildtype/) tắt việc xây dựng đoạn theo đoạn, để cài đặt từ áp dụng cho toàn bộ khung văn bản.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

Để xây dựng một hộp văn bản theo đoạn, đặt [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/buildtype/) (hoặc mức đoạn khác). Để nhắm mục tiêu một đoạn riêng với hiệu ứng riêng, sử dụng overload của [Sequence.add_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/add_effect/) chấp nhận một [IParagraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iparagraph/). Xem [Animated Text](/slides/vi/python-net/animated-text/) để biết các ví dụ mức đoạn.

## **Xuất và Ghi chú Tương thích**

- Lưu dưới dạng PPT hoặc PPTX giữ nguyên mô hình hoạt ảnh, nhưng việc phát cuối cùng được điều khiển bởi trình xem bản trình bày.
- PDF và hình ảnh tĩnh không phát hoạt ảnh. Sử dụng [HTML5 export](/slides/vi/python-net/export-to-html5/), GIF hoạt ảnh, hoặc [video conversion](/slides/vi/python-net/convert-powerpoint-to-video/) khi đầu ra phải hiển thị chuyển động.
- Đối với HTML5, bật [Html5Options.animate_shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/html5options/animate_shapes/) và, khi cần, [Html5Options.animate_transitions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/html5options/animate_transitions/).
- Kết xuất video hỗ trợ nhiều hiệu ứng nhập cảnh, nhấn mạnh, thoát và đường chuyển động thông thường, nhưng không phải mọi hiệu ứng PowerPoint đều được hỗ trợ. Kiểm tra bảng [supported animations and effects](/slides/vi/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) hiện tại và thử nghiệm các bản trình bày quan trọng với phiên bản Aspose.Slides mục tiêu của bạn.
- Các hiệu ứng tùy chỉnh cao cấp và các hiệu ứng được nhập từ định dạng bản trình bày khác có thể được giữ trong tệp nhưng hiển thị khác nhau trong PowerPoint, HTML5 hoặc video. Xác thực kết quả xuất thay vì chỉ dựa vào tên hiệu ứng.

## **Câu hỏi thường gặp**

**Tại sao một hoạt ảnh xuất hiện trong PowerPoint nhưng không trong PDF?**

PDF là định dạng tĩnh, vì vậy hoạt ảnh và chuyển đổi slide không được phát. Xuất sang HTML5, GIF hoạt ảnh, hoặc video khi cần giữ chuyển động.

**Tại sao một hiệu ứng phát khác nhau trong video?**

Xuất video render hoạt ảnh thay vì lưu hành vi gốc của PowerPoint. Một số hiệu ứng nâng cao không được hỗ trợ hoặc chỉ được xấp xỉ. Xem bảng hiệu ứng được hỗ trợ và thử nghiệm bản trình bày thực tế trước khi sử dụng trong sản xuất.

**Di chuyển một hình dạng lên trước hoặc xuống sau có thay đổi thứ tự hoạt ảnh của nó không?**

Không. Thứ tự z-order của hình dạng kiểm soát sự chồng lấp, trong khi thứ tự chuỗi và trình kích hoạt kiểm soát việc phát hoạt ảnh. Thay đổi dòng thời gian nếu bạn cần một thứ tự phát khác.