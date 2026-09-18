---
title: Tạo và chỉnh sửa hành vi hoạt ảnh tùy chỉnh trong Python
linktitle: Hoạt ảnh tùy chỉnh
type: docs
weight: 151
url: /vi/python-net/custom-animation/
keywords:
- hoạt ảnh tùy chỉnh
- hành vi hoạt ảnh
- đường chuyển động
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tạo, kiểm tra và chỉnh sửa các hành vi hoạt ảnh tùy chỉnh và các đường chuyển động có thể chỉnh sửa trong các bản trình chiếu PowerPoint với Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Các hành vi hoạt ảnh tùy chỉnh cho phép bạn kiểm soát các thao tác riêng lẻ trong một hiệu ứng hoạt ảnh, chẳng hạn như thay đổi màu, quay một hình dạng, hoặc theo một đường chuyển động có thể chỉnh sửa. Hướng dẫn này cho biết cách tạo và kết hợp các hành vi, cấu hình thời gian của chúng, kiểm tra và sửa đổi các hoạt ảnh hiện có, và xác minh rằng các thuộc tính vẫn tồn tại sau khi lưu và mở lại bản trình chiếu.

Đối với các hiệu ứng đã định trước và kích hoạt bằng nhấp chuột, xem [Hoạt ảnh Hình dạng](/slides/vi/python-net/shape-animation/).

## **Hiểu mô hình hoạt ảnh**

Một hoạt ảnh được tổ chức dưới dạng **Timeline → Sequence → Effect → Behaviors**:

- [timeline](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslide/timeline/) của slide chứa chuỗi chính và các chuỗi tương tác.
- Một [Sequence](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/) chứa các hiệu ứng, có thể nhắm tới các hình dạng khác nhau.
- Một [Effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effect/) xác định hình dạng mục tiêu, preset, subtype và thời gian của hiệu ứng.
- [Effect.behaviors](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effect/behaviors/) chứa các thao tác thực hiện hiệu ứng: thay đổi màu, di chuyển, quay, đặt thuộc tính, v.v.

## **Tạo hành vi cá nhân**

Gọi [Sequence.add_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/sequence/add_effect/) để tạo một hiệu ứng và truy cập bộ sưu tập [behaviors](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effect/behaviors/) của nó. Một preset có thể tự động điền bộ sưu tập này. Giữ các thao tác khi mở rộng preset, hoặc dùng [clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorcollection/clear/) khi muốn thay thế chúng một cách có ý định.

[BehaviorFactory](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorfactory/) tạo tám loại hành vi được minh họa dưới đây. Chuyển động được đề cập trong [Xây dựng Đường chuyển động]#build-a-motion-path. Mỗi ví dụ tạo là một chương trình hoàn chỉnh; các ví dụ chỉnh sửa sau này ghi rõ tệp đầu ra nào được sử dụng.

### **Xoay**

Dùng [create_rotation_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) để tạo một vòng quay. [by](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/rotationeffect/by/) chỉ định góc tương đối tính bằng độ; [from_address](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/rotationeffect/from_address/) và [to](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/rotationeffect/to/) chỉ các điểm cuối.

Ví dụ bắt đầu với một hiệu ứng Spin, thay thế các thao tác preset của nó bằng một hành vi xoay, và đặt thời lượng cho thao tác này là hai giây. Góc tương đối 90 độ biểu thị một phần tư vòng từ hướng khởi đầu của hình dạng, vì vậy không cần chỉ định góc bắt đầu một cách rõ ràng.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` chứa một hình dạng và một hành vi xoay. Bộ sưu tập, thời gian và các ví dụ chỉnh sửa xoay dưới đây đều sử dụng tệp này.

### **Phóng to**

Dùng [create_scale_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) với tỷ lệ phần trăm X/Y: [from_address](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/scaleeffect/from_address/) và [to](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/scaleeffect/to/) mô tả kích thước bắt đầu và kết thúc, trong khi [by](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/scaleeffect/by/) mô tả thay đổi tương đối. Ở đây, 100 có nghĩa là kích thước gốc.

Ví dụ làm tăng cả hai chiều từ 100% lên 125% trong hai giây. Sử dụng các tỷ lệ phần trăm ngang và dọc bằng nhau giữ tỷ lệ của hình dạng; các tỷ lệ khác nhau sẽ kéo dài một chiều hơn chiều kia.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **Màu**

Dùng [create_color_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) để thay đổi màu nền từ xanh dương sang cam. [from_address](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/coloreffect/from_address/) và [to](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/coloreffect/to/) là các màu; [by](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/coloreffect/by/) là độ lệch màu. [Behavior.properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behavior/properties/) xác định thuộc tính đang được hoạt ảnh.

Nền đặc của hình dạng được khởi tạo là màu xanh dương, khớp với màu bắt đầu của hoạt ảnh. Chọn thuộc tính màu nền cho phép hành vi biết phần nào của hình dạng sẽ thay đổi; các điểm màu cuối cùng tự nó không xác định thuộc tính đó. Hiệu ứng đã lưu mô tả một chuyển đổi hai giây sang màu cam.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **Bộ lọc**

Dùng [create_filter_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) để chọn một dạng xoáy. [type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/filtereffect/subtype/), và [reveal](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/filtereffect/reveal/) chỉ bộ lọc, hướng và việc hiển thị hay ẩn hình dạng.

Ví dụ này cấu hình một hiệu ứng xoáy hai giây bật hiển thị hình dạng bằng subtype hướng phải. Cài đặt bộ lọc thuộc về hành vi bên trong hiệu ứng, vì vậy chúng được cấu hình sau khi các thao tác gốc của preset đã bị xóa.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **Thuộc tính**

Dùng [create_property_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) để hoạt ảnh độ mờ. [from_address](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/propertyeffect/to/), và [by](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/propertyeffect/by/) là các chuỗi được giải thích bằng [value_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/propertyeffect/value_type/) và [calc_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/propertyeffect/calc_mode/). Chọn các điểm cuối hoặc độ lệch tương đối thay vì đặt cả ba một cách ngẫu nhiên.

Ở đây, thuộc tính được chọn là opacity, và các chuỗi số đại diện cho sự thay đổi từ 25% độ mờ lên độ mờ đầy đủ. Nội suy tuyến tính mô tả sự thay đổi dần dần giữa các giá trị đó. Khi áp dụng ví dụ này cho thuộc tính khác, hãy chọn kiểu giá trị và các giá trị đầu cuối phù hợp với thuộc tính đó.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **Đặt**

Dùng [create_set_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) để gán khả năng hiển thị qua [to](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/seteffect/to/). Một hành vi set không nội suy giữa các điểm cuối.

Ví dụ chọn thuộc tính visibility và gán chuỗi `visible` khi hành vi chạy. Hình chữ nhật đã hiển thị trong bản trình chiếu tối thiểu này, vì vậy việc gán có thể không tạo ra thay đổi trực quan rõ ràng một mình. Thao tác như vậy hữu ích khi là một phần của hiệu ứng lớn hơn cũng kiểm soát thời điểm hình dạng ẩn hoặc hiện.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **Lệnh**

Dùng [create_command_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) và cấu hình [type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/commandeffect/command_string/), và [shape_target](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/commandeffect/shape_target/). Đặt một bản ghi âm WAV tên `sample.wav` trong thư mục làm việc. Ví dụ này nhúng nó bằng [add_audio_frame_embedded](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) và gắn một lệnh play vào khung âm thanh.

Khung âm thanh vừa là mục tiêu của hiệu ứng vừa là mục tiêu của lệnh. Điều này kết nối yêu cầu phát với bản ghi nhúng; một chuỗi lệnh đơn giản không xác định đối tượng media nào sẽ được điều khiển. Hiệu ứng được cấu hình để bắt đầu khi nhấp chuột trong slideshow.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

Lưu trữ sẽ ghi lệnh vào `command.pptx`; nó không phát bản ghi. Phát lại yêu cầu một trình chiếu hỗ trợ lệnh và mục tiêu media tương ứng.

## **Quản lý bộ sưu tập hành vi**

[BehaviorCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorcollection/) hỗ trợ [add](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorcollection/remove/), và [remove_at](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorcollection/remove_at/). Ví dụ này mở `rotation.pptx`, thêm scaling, di chuyển nó trước rotation, và loại bỏ rotation. Việc loại bỏ và chèn lại cùng một đối tượng thay đổi vị trí lưu trữ của nó mà không tạo bản sao.

Chuỗi các chỉnh sửa thay đổi bộ sưu tập từ rotation–scale thành scale–rotation, rồi cuối cùng chỉ còn scale. Các chỉ mục tham chiếu đến bộ sưu tập hiện tại, vì vậy việc loại bỏ dùng chỉ mục mới của rotation sau khi đã sắp lại. Đếm cuối cùng xác nhận hành vi nào sẽ được lưu.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả là `ScaleEffect`: chỉ còn scaling. Thứ tự trong bộ sưu tập không tự động lên lịch các hành vi liên tiếp. Chỉ xóa bộ sưu tập khi thay thế toàn bộ các thao tác của nó.

## **Cấu hình thời gian hành vi**

[Behavior.timing](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behavior/timing/) mở rộng [Timing](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/), độc lập với [Effect.timing](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effect/timing/). Thời gian của effect lên lịch cho toàn bộ effect; thời gian của behavior mô tả một thao tác bên trong nó.

### **Đặt thời lượng, độ trễ, lặp lại và tăng tốc**

Mở `rotation.pptx` và đặt [duration](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/duration/) và [trigger_delay_time](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/trigger_delay_time/) tính bằng giây, sau đó cấu hình [repeat_count](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/repeat_count/). [accelerate](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/accelerate/) và [decelerate](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/decelerate/) là các phần của thời lượng; tổng của chúng không được vượt quá 1.

Tệp đầu vào là tệp đã tạo trong ví dụ xoay, trong đó hành vi đầu tiên là một vòng quay. Ví dụ này chỉ thay đổi thời gian của hành vi đó; góc 90 độ vẫn giữ nguyên. Tách góc và thời gian giúp dễ điều chỉnh tốc độ mà không cần xây dựng lại hoạt ảnh.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

Hành vi sử dụng thời lượng hai giây, độ trễ nửa giây, và số lần lặp 3. 20% đầu và cuối thời lượng được dùng cho tăng tốc và giảm tốc.

Các chính sách lặp khác bao gồm [repeat_duration](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), và [repeat_until_next_click](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/repeat_until_next_click/); chọn một chính sách thay vì bật tất cả cùng lúc. [auto_reverse](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/timing/auto_reverse/) phát hoạt ảnh ngược lại sau lượt tiến. Tăng tốc và giảm tốc áp dụng cho các thay đổi liên tục, không phải cho các gán rời rạc hoặc lệnh.

## **Xây dựng Đường chuyển động**

Dùng [create_motion_effect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) để tạo chuyển động. Các trường [from_address](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioneffect/to/), và [by](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioneffect/by/) mô tả tọa độ hoặc độ lệch dựa trên phần trăm. Để có một lộ trình có thể chỉnh sửa, tạo một [MotionPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motionpath/) và gán nó cho [MotionEffect.path](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioneffect/path/). [MotionPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motionpath/) lưu trữ các lệnh đường.

[MotionCommandPathType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioncommandpathtype/) chọn thao tác:

| Lệnh | Điểm | Ý nghĩa |
| --- | --- | --- |
| MOVE_TO | Một | Đặt vị trí bắt đầu. |
| LINE_TO | Một | Di chuyển dọc theo đoạn thẳng tới điểm cuối. |
| CURVE_TO | Ba | Theo đường cong bậc ba được xác định bởi hai điểm điều khiển và một điểm cuối. |
| CLOSE_LOOP | None | Quay lại vị trí bắt đầu. |
| END | None | Kết thúc đường. |

[MotionPathPointsType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motionpathpointstype/) mô tả đặc điểm chỉnh sửa điểm, chẳng hạn điểm góc hoặc mượt. Nó không thay thế kiểu lệnh. Dùng kiểu điểm cong cho ví dụ đường cong dưới đây, và kiểu điểm góc cho các đoạn thẳng.

Tọa độ đường được chuẩn hoá theo kích thước slide: độ dịch X 0.25 biểu thị một phần tư chiều rộng slide, không phải 0.25 điểm. Y dương chạy xuống dưới. Các lệnh tuyệt đối chỉ vị trí trong hệ tọa độ đường; các lệnh tương đối chỉ độ lệch từ vị trí hiện tại. Điều này tách biệt với [origin](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioneffect/origin/), chọn khung tham chiếu của đường, và [path_edit_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioneffect/path_edit_mode/), kiểm soát cách đường di chuyển khi hình dạng di chuyển.

### **Tạo đường thẳng**

Tạo một hành vi chuyển động với điểm bắt đầu, một đoạn thẳng, và lệnh kết thúc. [MotionPath.add](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motionpath/add/) nhận kiểu lệnh, các điểm của nó, kiểu điểm, và cờ tọa độ tương đối.

Lệnh bắt đầu thiết lập (0, 0), và đoạn thẳng kết thúc ở (0.25, 0), tạo ra một dịch chuyển ngang bằng một phần tư chiều rộng slide. Lệnh kết thúc không có điểm tọa độ. Khi đường đã được gán, việc thêm hành vi chuyển động vào hiệu ứng sẽ kết nối lộ trình này với hình chữ nhật.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` chứa một hành vi chuyển động với ba lệnh đường. Các ví dụ chỉnh sửa tệp sau đây sử dụng cấu trúc đã biết này.

### **So sánh tọa độ tuyệt đối và tương đối**

Hai đối tượng đường này mô tả cùng một lộ trình. Lệnh tuyệt đối kết thúc ở (0.3, 0.1); lệnh tương đối cộng (0.1, 0.1) vào vị trí hiện tại, (0.2, 0).

Cả hai đường đều bắt đầu ở cùng vị trí. Đối với đoạn thẳng tương đối, cộng các độ lệch X và Y vào vị trí hiện tại để có điểm cuối; đối với đoạn thẳng tuyệt đối, đọc điểm cuối trực tiếp. Đổi cờ mà không chuyển đổi tọa độ sẽ mô tả một lộ trình khác.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

Gán bất kỳ đường nào cho một hành vi chuyển động để sử dụng trong bản trình chiếu. Tham số Boolean cuối cùng chọn tọa độ tương đối cho lệnh đó.

### **Thay thế đoạn thẳng bằng đường cong**

Mở `motion.pptx` và thay thế lệnh đoạn thẳng bằng một đường cong bậc ba. Đầu tiên cung cấp hai điểm điều khiển, sau đó là điểm cuối.

Vị trí bắt đầu được cung cấp bởi lệnh trước đó. Hai điểm đầu hình thành đường cong, trong khi điểm thứ ba là điểm đến; chúng không phải là ba điểm đích liên tiếp. Cập nhật đồng thời loại lệnh, kiểu chỉnh sửa điểm và mảng điểm giữ cho đoạn nhất quán với hình học mới.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

Đường trong `curve.pptx` vẫn có ba lệnh; lệnh ở giữa giờ định nghĩa một đường cong.

## **Kiểm tra và chỉnh sửa đường đã lưu**

Mỗi [MotionCmdPath](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioncmdpath/) cung cấp [points](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioncmdpath/points_type/), và [is_relative](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motioncmdpath/is_relative/). Các ví dụ dưới đây sử dụng đường ba lệnh đã biết trong `motion.pptx`. Đối với đầu vào tùy ý, hãy xác định hiệu ứng mong muốn và kiểm tra loại lệnh và số lượng điểm trước khi chỉnh sửa theo chỉ mục.

### **Đọc lệnh và tọa độ**

Đọc đường mà không thay đổi nó. Các lệnh end và close-loop không cần điểm, vì vậy cho phép một mảng điểm `None`.

Kết quả liệt kê mỗi lệnh cùng cờ tọa độ tương đối trước khi liệt kê các điểm của nó. Điều này cho phép bạn phân biệt một điểm cuối với một độ lệch trước khi sửa đường. Đường cong sẽ liệt kê ba điểm, trong khi đoạn thẳng trong tệp này chỉ liệt kê một điểm.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

Danh sách chứa một điểm bắt đầu, một đoạn thẳng tuyệt đối kết thúc ở (0.25, 0), và một lệnh end.

### **Thay đổi điểm cuối**

Mở `motion.pptx` và thay thế mảng điểm của đoạn thẳng để di chuyển điểm cuối của nó.

Trong tệp đầu vào, chỉ mục 0 là lệnh bắt đầu và chỉ mục 1 là đoạn thẳng. Thay thế điểm duy nhất của đoạn thẳng sẽ thay đổi điểm đến mà không thay đổi loại lệnh, thời gian hoặc vị trí trong bộ sưu tập. Vì lệnh sử dụng tọa độ tuyệt đối, cặp mới chỉ định một vị trí thay vì một độ lệch cộng thêm.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

Đoạn thẳng trong `motion-endpoint.pptx` kết thúc ở (0.4, 0.1); tệp gốc không thay đổi.

### **Thay thế một đoạn**

Dùng [insert](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motionpath/insert/) và [remove_at](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/motionpath/remove_at/) để thay thế đoạn thẳng trong `motion.pptx`. Việc chèn đẩy đoạn thẳng cũ sang chỉ mục 2.

Điều này minh họa việc thay thế một đối tượng lệnh thay vì chỉnh sửa các tọa độ hiện có của nó. Sau khi chèn, bộ sưu tập tạm thời chứa lệnh bắt đầu, đoạn thẳng mới, đoạn thẳng cũ, và lệnh end. Loại bỏ chỉ mục 2 sẽ bỏ đoạn thẳng cũ và để lại lộ trình mới.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

Đường đã lưu vẫn có ba lệnh, với đoạn thẳng mới kết thúc ở (0.2, 0.1) và lệnh end ở cuối.

## **Sửa đổi và xác minh hành vi hiện có**

Khi không biết chỉ mục của hành vi, hãy chọn nó theo loại. Ví dụ này mở `rotation.pptx`, tìm [RotationEffect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/rotationeffect/), thay đổi góc và kiểm tra giá trị đã lưu sau khi mở lại.

Kiểm tra loại cho phép vòng lặp bỏ qua các hành vi không phải là xoay. Lần tải thứ hai đọc tệp đã lưu vào một đối tượng trình chiếu riêng, vì vậy việc so sánh kiểm tra dữ liệu đã lưu thay vì giá trị còn trong bộ nhớ. Ví dụ này vẫn giả định hiệu ứng đã biết là đầu tiên trong chuỗi chính; chọn hành vi theo loại không xác định hiệu ứng đúng trong một bản trình chiếu bất kỳ.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

Kết quả là `Rotation preserved: True`. Áp dụng mẫu kiểm tra loại tương tự cho các hành vi khác. Đối với kiểm tra bảo tồn toàn diện, so sánh hình dạng mục tiêu, hiệu ứng, loại và thứ tự hành vi, thời gian và lệnh đường. Sử dụng độ sai số số cho các giá trị dấu phẩy động. Đối với bản trình chiếu có bố cục hoạt ảnh không xác định, xem [Đọc Hoạt ảnh Hình dạng](/slides/vi/python-net/shape-animation/#read-shape-animations) để duyệt các chuỗi chính và tương tác.

## **Thứ tự hành vi, cài đặt trước và phát lại**

Thứ tự trong [BehaviorCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behaviorcollection/) là thứ tự lưu của các thao tác trong một hiệu ứng. Nó không phải là một danh sách phát mà mỗi hành vi tự động chờ hành vi trước. Thời gian và hiệu ứng bao quanh quyết định lịch trình. Các hành vi có thể chồng lên nhau, và các thao tác trên cùng thuộc tính có thể tương tác thông qua [additive](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behavior/additive/) và [accumulate](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/behavior/accumulate/). Không nên chỉ dùng việc sắp lại bộ sưu tập để lên lịch “di chuyển, rồi xoay”; hãy dùng thời gian rõ ràng hoặc các hiệu ứng riêng như mô tả trong [Hoạt ảnh Hình dạng](/slides/vi/python-net/shape-animation/).

[Effect.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effect/type/) và [Effect.subtype](https://reference.aspose.com/slides/vi/python-net/aspose.slides.animation/effect/subtype/) mô tả preset của nó. Chúng không phải là mô tả đầy đủ của cây hành vi đã chỉnh sửa. Chọn preset và subtype trước khi tùy chỉnh các hành vi: việc thay đổi preset có thể xây dựng lại bộ sưu tập và xóa bỏ các thao tác tùy chỉnh của bạn. Ví dụ, chuyển một hiệu ứng Spin đã tùy chỉnh sang Fade có thể thay thế hành vi xoay bằng các hành vi set và filter. Kiểm tra lại bộ sưu tập sau khi thay đổi preset hoặc subtype. Xóa các hành vi preset cũng có thể loại bỏ các thao tác hiển thị hoặc khởi tạo mà preset cần. Các ví dụ cố ý sử dụng các hình dạng hiển thị và thay thế các hành vi; chúng không tái tạo toàn bộ triển khai của mỗi preset.

## **Tương thích định dạng**

Một cây hành vi được bảo tồn không đảm bảo việc phát lại giống hệt trong mọi trình xem hoặc bộ xuất khẩu. Kiểm tra dữ liệu đã lưu và kết quả render riêng biệt.

| Định dạng hoặc đầu ra | Cần kiểm tra |
| --- | --- |
| PPTX | Sử dụng làm định dạng chính cho các ví dụ này. Mở lại để xác minh cây hành vi có thể chỉnh sửa, sau đó kiểm tra phát lại trong phiên bản PowerPoint mong muốn. |
| PPT | Định dạng nhị phân cũ có thể khác với PPTX. Thử một chu kỳ lưu‑mở‑lại và phát lại riêng; không suy ra hỗ trợ cho mọi tổ hợp tùy chỉnh chỉ dựa trên kết quả PPTX thành công. |
| PDF, PNG, JPEG và các ảnh slide tĩnh khác | Chứa một biểu diễn slide tĩnh, không phải một timeline hoạt ảnh có thể phát hoặc khung hình cuối cùng được đảm bảo. |
| [HTML5](/slides/vi/python-net/export-to-html5/) | Có thể phát các hoạt ảnh được hỗ trợ khi bật hoạt ảnh hình dạng trong tùy chọn xuất khẩu. Kiểm tra các tổ hợp tùy chỉnh trong trình duyệt. |
| [Animated GIF](/slides/vi/python-net/convert-powerpoint-to-animated-gif/) | Lưu các khung render, không phải các hành vi có thể chỉnh sửa hay tương tác khi nhấp. Kiểm tra chuyển động đã render thực tế. |
| [Video](/slides/vi/python-net/convert-powerpoint-to-video/) | Render các khung hoạt ảnh và mã hoá chúng thành video. Hỗ trợ chỉ giới hạn ở các [hoạt ảnh và hiệu ứng được hỗ trợ](/slides/vi/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) của bộ render; các lệnh và sự kiện tương tác không trở thành một timeline có thể chỉnh sửa. |

## **FAQ**

**Tại sao hiệu ứng của tôi chứa các hành vi trước khi tôi thêm bất kỳ hành vi nào?**

Tạo một hiệu ứng preset có thể tạo ra các thao tác nền tảng của nó. Kiểm tra chúng trước khi quyết định mở rộng preset hoặc thay thế các hành vi.

**Việc di chuyển một hành vi lên đầu có làm nó phát đầu tiên không?**

Không nhất thiết. Thứ tự trong bộ sưu tập không thay thế thời gian. Kiểm tra độ trễ, thời lượng và tương tác giữa các thao tác trên cùng thuộc tính.

**Tại sao lệnh end không có điểm?**

Nó đánh dấu kết thúc đường và không cần tọa độ. Khi kiểm tra một đường đọc từ tệp, hãy kiểm tra mảng điểm `None`.

**Một vòng chuyền thành công có đủ để xác nhận việc phát lại không?**

Không. Mở lại chỉ xác nhận việc bảo tồn các thuộc tính bạn đã kiểm tra. Cần thử trình chiếu hoặc xuất khẩu hoạt ảnh riêng biệt để xác nhận hành vi trực quan.