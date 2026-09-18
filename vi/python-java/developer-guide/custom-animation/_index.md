---
title: Tạo và chỉnh sửa các hành vi hoạt ảnh tùy chỉnh trong Python qua Java
linktitle: Hoạt ảnh tùy chỉnh
type: docs
weight: 151
url: /vi/python-java/custom-animation/
keywords:
- hoạt ảnh tùy chỉnh
- hành vi hoạt ảnh
- đường chuyển động
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tạo, kiểm tra và chỉnh sửa các hành vi hoạt ảnh tùy chỉnh và các đường chuyển động có thể chỉnh sửa trong các bản trình bày PowerPoint bằng Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Các hành vi hoạt ảnh tùy chỉnh cho phép bạn kiểm soát các thao tác cá nhân trong một hiệu ứng hoạt ảnh, chẳng hạn như thay đổi màu, quay một hình, hoặc theo một đường chuyển động có thể chỉnh sửa. Hướng dẫn này trình bày cách tạo và kết hợp các hành vi, cấu hình thời gian của chúng, kiểm tra và sửa đổi các hoạt ảnh hiện có, và xác minh rằng các thuộc tính của chúng vẫn tồn tại sau khi lưu và mở lại bản trình bày.

Đối với các hiệu ứng đã định trước và kích hoạt bằng cú nhấp, xem [Hoạt ảnh Hình dạng](/slides/vi/python-java/shape-animation/).

## **Hiểu mô hình hoạt ảnh**

Một hoạt ảnh được tổ chức theo **Timeline → Sequence → Effect → Behaviors**:

- Phương thức [getTimeline](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getTimeline) trả về dòng thời gian của slide, bao gồm chuỗi chính và các chuỗi tương tác.
- Một [Sequence](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/) chứa các hiệu ứng, có thể nhắm mục tiêu các hình khác nhau.
- Một [Effect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effect/) xác định hình mục tiêu, preset, subtype và thời gian hiệu ứng.
- Bộ sưu tập trả về bởi [Effect.getBehaviors](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effect/#getBehaviors) chứa các thao tác thực hiện hiệu ứng: thay đổi màu, di chuyển, quay, đặt thuộc tính, v.v.

## **Tạo các hành vi riêng lẻ**

Gọi [Sequence.addEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sequence/#addEffect) để tạo một hiệu ứng và truy cập bộ sưu tập [getBehaviors](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effect/#getBehaviors). Một preset có thể tự động điền bộ sưu tập này. Giữ các thao tác của nó khi mở rộng preset, hoặc sử dụng [clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorcollection/#clear) khi thay thế chúng một cách có chủ đích.

[BehaviorFactory](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorfactory/) tạo tám loại hành vi được minh họa bên dưới. Chuyển động được đề cập trong [Xây dựng Đường chuyển động](#build-a-motion-path). Mỗi đoạn mã bao gồm các import và khởi động JVM nếu cần. Các đối tượng và mảng điểm Java được tạo thông qua JPype khi API yêu cầu. Các ví dụ chỉnh sửa sau này chỉ ra tệp đầu ra nào được sử dụng.

### **Rotation**

Sử dụng [createRotationEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorfactory/#createRotationEffect) để tạo một phép quay. [getBy](https://reference.aspose.com/slides/vi/python-java/aspose.slides/rotationeffect/#getBy) xác định góc tương đối theo độ; [getFrom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/rotationeffect/#getFrom) và [getTo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/rotationeffect/#getTo) xác định các điểm cuối.

Ví dụ bắt đầu với một hiệu ứng Spin, thay thế các thao tác preset của nó bằng một hành vi quay, và đặt thời lượng cho hành vi này là hai giây. Góc tương đối 90 độ biểu thị một phần tư vòng quanh hướng ban đầu của hình, vì vậy không cần góc bắt đầu rõ ràng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` chứa một hình và một hành vi quay. Bộ sưu tập, thời gian và các ví dụ chỉnh sửa quay bên dưới sử dụng tệp này.

### **Scale**

Sử dụng [createScaleEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorfactory/#createScaleEffect) với tỷ lệ phần trăm X/Y: [getFrom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/scaleeffect/#getFrom) và [getTo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/scaleeffect/#getTo) mô tả kích thước bắt đầu và kết thúc, trong khi [getBy](https://reference.aspose.com/slides/vi/python-java/aspose.slides/scaleeffect/#getBy) mô tả sự thay đổi tương đối. Ở đây, 100 có nghĩa là kích thước gốc.

Ví dụ tăng cả hai kích thước từ 100% lên 125% trong hai giây. Sử dụng tỷ lệ phần trăm ngang và dọc bằng nhau giữ tỉ lệ của hình; các tỷ lệ khác nhau sẽ kéo dài một chiều hơn chiều còn lại.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Color**

Sử dụng [createColorEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorfactory/#createColorEffect) để thay đổi màu nền từ xanh dương sang cam. [getFrom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/coloreffect/#getFrom) và [getTo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/coloreffect/#getTo) là màu; [getBy](https://reference.aspose.com/slides/vi/python-java/aspose.slides/coloreffect/#getBy) là độ chênh lệch màu. [Behavior.getProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behavior/#getProperties) xác định thuộc tính đang được hoạt ảnh.

Màu nền rắn của hình được khởi tạo là xanh dương, khớp với màu bắt đầu của hoạt ảnh. Chọn thuộc tính màu nền cho phép hành vi biết phần nào của hình sẽ bị thay đổi; chỉ các điểm cuối màu không xác định thuộc tính đó. Hiệu ứng đã lưu mô tả một chuyển đổi hai giây sang màu cam.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Filter**

Sử dụng [createFilterEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorfactory/#createFilterEffect) để chọn một dạng vuốt. [getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filtereffect/#getSubtype) và [getReveal](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filtereffect/#getReveal) xác định bộ lọc, hướng và việc hiển thị hay ẩn hình.

Ví dụ này cấu hình một vuốt hai giây hiển thị hình bằng subtype hướng phải. Các cài đặt bộ lọc thuộc về hành vi bên trong hiệu ứng, vì vậy chúng được cấu hình sau khi các thao tác gốc của preset đã bị xóa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Property**

Sử dụng [createPropertyEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) để hoạt ảnh độ mờ. [getFrom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/propertyeffect/#getTo) và [getBy](https://reference.aspose.com/slides/vi/python-java/aspose.slides/propertyeffect/#getBy) là các chuỗi được diễn giải bằng [getValueType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/propertyeffect/#getValueType) và [getCalcMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/propertyeffect/#getCalcMode). Hãy chọn các điểm cuối hoặc độ lệch tương đối thay vì đặt cả ba một cách tùy tiện.

Ở đây, thuộc tính được chọn là opacity, và các chuỗi số đại diện cho sự thay đổi từ độ mờ 25% lên độ mờ đầy đủ. Nội suy tuyến tính mô tả sự thay đổi dần dần giữa các giá trị đó. Khi áp dụng ví dụ này cho thuộc tính khác, hãy chọn kiểu giá trị và các giá trị điểm cuối phù hợp với thuộc tính đó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Set**

Sử dụng [createSetEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorfactory/#createSetEffect) để gán tính năng hiển thị qua [getTo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/seteffect/#getTo). Một hành vi đặt không nội suy giữa các điểm cuối.

Ví dụ chọn thuộc tính visibility và gán chuỗi `visible` khi hành vi chạy. Hình chữ nhật đã hiển thị trong bản trình bày tối thiểu này, vì vậy việc gán có thể không tạo ra thay đổi trực quan rõ ràng. Thao tác như vậy hữu ích khi là một phần của hiệu ứng lớn hơn cũng kiểm soát thời điểm hình ẩn hoặc hiện.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Command**

Sử dụng [createCommandEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorfactory/#createCommandEffect) và cấu hình [getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/vi/python-java/aspose.slides/commandeffect/#getCommandString) và [getShapeTarget](https://reference.aspose.com/slides/vi/python-java/aspose.slides/commandeffect/#getShapeTarget). Đặt một tệp ghi âm WAV có tên `sample.wav` trong thư mục làm việc. Ví dụ này nhúng nó bằng [addAudioFrameEmbedded](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) và gắn lệnh phát vào khung âm thanh.

Khung âm thanh vừa là mục tiêu của hiệu ứng vừa là mục tiêu của lệnh. Điều này kết nối yêu cầu phát với bản ghi đã nhúng; một chuỗi lệnh riêng biệt không xác định đối tượng media nào sẽ được điều khiển. Hiệu ứng được cấu hình để bắt đầu khi nhấp trong khi trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Lưu trữ sẽ lưu lệnh trong `command.pptx`; nó không phát bản ghi. Phát lại yêu cầu một trình chiếu hỗ trợ lệnh và đối tượng media mục tiêu.

## **Quản lý Bộ sưu tập Hành vi**

[BehaviorCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorcollection/) hỗ trợ [add](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorcollection/#remove) và [removeAt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorcollection/#removeAt). Ví dụ này mở `rotation.pptx`, thêm scaling, di chuyển nó trước rotation và loại bỏ rotation. Việc loại bỏ và chèn lại cùng một đối tượng sẽ thay đổi vị trí lưu trữ của nó mà không tạo bản sao.

Chuỗi các chỉnh sửa thay đổi bộ sưu tập từ rotation–scale thành scale–rotation, rồi thành chỉ scale. Các chỉ mục tham chiếu tới bộ sưu tập hiện tại, vì vậy việc loại bỏ sử dụng chỉ mục mới của rotation sau khi sắp xếp lại. Đếm cuối cùng xác nhận hành vi nào sẽ được lưu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả là `ScaleEffect`: chỉ còn scaling. Thứ tự trong bộ sưu tập không tự động lên lịch các hành vi liên tiếp. Xóa bộ sưu tập chỉ khi thay thế tất cả các thao tác của nó.

## **Cấu hình Thời gian Hành vi**

[Behavior.getTiming](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behavior/#getTiming) cung cấp [Timing](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/), độc lập với [Effect.getTiming](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effect/#getTiming). Thời gian hiệu ứng lên lịch cho toàn bộ hiệu ứng; thời gian hành vi mô tả một thao tác bên trong nó.

### **Đặt Thời lượng, Độ trễ, Lặp lại và Tăng tốc**

Mở `rotation.pptx` và đặt thời lượng ([getDuration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getDuration)) và độ trễ kích hoạt ([getTriggerDelayTime](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getTriggerDelayTime)) tính bằng giây, sau đó cấu hình số lần lặp qua [setRepeatCount](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getAccelerate) và [getDecelerate](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getDecelerate) là phần của thời lượng; giữ tổng của chúng không vượt quá 1.

Tệp đầu vào là tệp được tạo trong ví dụ quay, trong đó hành vi đầu tiên được biết là một rotation. Ví dụ này chỉ thay đổi thời gian của hành vi đó; góc 90 độ vẫn giữ nguyên. Giữ góc và thời gian riêng biệt giúp dễ điều chỉnh tốc độ mà không cần xây dựng lại hoạt ảnh.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hành vi sử dụng thời lượng hai giây, độ trễ nửa giây và số lần lặp 3. 20% đầu và cuối thời lượng được dùng cho tăng tốc và giảm tốc.

Các chính sách lặp lại khác bao gồm [getRepeatDuration](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) và [getRepeatUntilNextClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getRepeatUntilNextClick); chọn một chính sách thay vì bật tất cả cùng lúc. [getAutoReverse](https://reference.aspose.com/slides/vi/python-java/aspose.slides/timing/#getAutoReverse) phát hoạt ảnh ngược lại sau lần chạy tiến. Tăng tốc và giảm tốc áp dụng cho các thay đổi liên tục, không phải cho các gán rời rạc hay lệnh.

## **Xây dựng Đường chuyển động**

Sử dụng [createMotionEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorfactory/#createMotionEffect) để tạo chuyển động. Các phương thức [getFrom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motioneffect/#getTo) và [getBy](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motioneffect/#getBy) mô tả tọa độ hoặc độ lệch dựa trên phần trăm. Đối với một lộ trình có thể chỉnh sửa, tạo một [MotionPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motionpath/) và gán nó bằng [MotionEffect.setPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motionpath/) lưu các lệnh đường.

[MotionCommandPathType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motioncommandpathtype/) chọn thao tác:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Đặt vị trí bắt đầu. |
| LineTo | One | Di chuyển theo đoạn thẳng tới điểm cuối. |
| CurveTo | Three | Theo một đường cong bậc ba được xác định bởi hai điểm điều khiển và một điểm cuối. |
| CloseLoop | None | Trở về vị trí bắt đầu. |
| End | None | Kết thúc đường. |

[MotionPathPointsType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motionpathpointstype/) mô tả đặc tính chỉnh sửa điểm, chẳng hạn điểm góc hoặc mịn. Nó không thay thế kiểu lệnh. Sử dụng kiểu điểm curve cho ví dụ đường cong bên dưới, và kiểu điểm corner cho các đoạn thẳng.

Các tọa độ đường được chuẩn hoá theo kích thước slide: độ dịch X 0.25 đại diện cho một phần tư chiều rộng slide, không phải 0.25 điểm. Y dương chạy xuống dưới. Các lệnh absolute xác định vị trí trong hệ tọa độ đường, các lệnh relative xác định độ lệch từ vị trí hiện tại. Điều này tách biệt với [getOrigin](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motioneffect/#getOrigin), chọn khung tham chiếu của đường, và [getPathEditMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motioneffect/#getPathEditMode), điều khiển cách đường di chuyển khi hình di chuyển.

### **Tạo Đường Thẳng**

Tạo một hành vi chuyển động với điểm bắt đầu, một đoạn thẳng và lệnh kết thúc. [MotionPath.add](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motionpath/#add) nhận kiểu lệnh, các điểm của nó, kiểu điểm và cờ tọa độ tương đối.

Lệnh bắt đầu thiết lập (0, 0), và đoạn thẳng kết thúc tại (0.25, 0), tạo ra một dịch chuyển ngang bằng một phần tư chiều rộng slide. Lệnh kết thúc không có điểm tọa độ. Khi đường được gán, việc thêm hành vi chuyển động vào hiệu ứng sẽ kết nối đường này với hình chữ nhật.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` chứa một hành vi chuyển động với ba lệnh đường. Các ví dụ chỉnh sửa tệp sau đây sử dụng cấu trúc đã biết này.

### **So sánh Tọa độ Absolute và Relative**

Hai đối tượng đường này mô tả cùng một lộ trình. Lệnh absolute kết thúc tại (0.3, 0.1); lệnh relative cộng (0.1, 0.1) vào vị trí hiện tại, (0.2, 0).

Cả hai đường đều bắt đầu tại cùng một vị trí. Đối với đường relative, cộng các độ lệch X và Y vào vị trí hiện tại để có được điểm cuối; đối với đường absolute, đọc điểm cuối trực tiếp. Chuyển đổi cờ mà không chuyển đổi tọa độ sẽ tạo ra một lộ trình khác.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

Gán bất kỳ đường nào cho hành vi chuyển động để sử dụng trong bản trình bày. Đối số Boolean cuối cùng chọn tọa độ relative cho lệnh đó.

### **Thay thế Đoạn Thẳng bằng Đường Cong**

Mở `motion.pptx` và thay thế lệnh đường thẳng bằng một đường cong bậc ba. Cung cấp hai điểm điều khiển trước, sau đó là điểm cuối.

Vị trí bắt đầu được cung cấp bởi lệnh trước. Hai điểm đầu tiên tạo hình cong, trong khi điểm thứ ba là đích cuối; chúng không phải là ba đích liên tiếp. Cập nhật đồng thời kiểu lệnh, kiểu chỉnh sửa điểm và mảng điểm giữ cho đoạn phù hợp với hình học mới.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đường trong `curve.pptx` vẫn có ba lệnh; lệnh ở giữa giờ định nghĩa một đường cong.

## **Kiểm tra và Chỉnh sửa Đường đã Lưu**

Mỗi [MotionCmdPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motioncmdpath/) cung cấp [getPoints](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motioncmdpath/#getPointsType) và [isRelative](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motioncmdpath/#isRelative). Các ví dụ sau sử dụng đường ba lệnh đã biết trong `motion.pptx`. Đối với đầu vào tùy ý, xác định hiệu ứng mong muốn và kiểm tra kiểu lệnh và số lượng điểm trước khi chỉnh sửa theo chỉ mục.

### **Đọc Lệnh và Tọa độ**

Đọc đường mà không thay đổi nó. Các lệnh end và close-loop không cần điểm, vì vậy cho phép mảng điểm null.

Đầu ra liệt kê mỗi kiểu lệnh số với cờ tọa độ relative trước khi liệt kê các điểm. Điều này cho phép bạn phân biệt điểm cuối với độ lệch trước khi sửa đường. Một đường cong sẽ liệt kê ba điểm, trong khi đường thẳng trong tệp này chỉ liệt kê một điểm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

Danh sách chứa một điểm bắt đầu, một đường thẳng absolute kết thúc tại (0.25, 0), và một lệnh end.

### **Thay đổi Điểm cuối**

Mở `motion.pptx` và thay thế mảng điểm của đường thẳng để di chuyển điểm cuối của nó.

Trong tệp đầu vào, chỉ mục 0 là lệnh bắt đầu và chỉ mục 1 là đường thẳng. Thay thế điểm duy nhất của đường thẳng sẽ thay đổi đích mà không thay đổi kiểu lệnh, thời gian hoặc vị trí trong bộ sưu tập. Vì lệnh sử dụng tọa độ absolute, cặp mới xác định một vị trí thay vì một độ lệch được cộng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đường trong `motion-endpoint.pptx` kết thúc tại (0.4, 0.1); tệp gốc không thay đổi.

### **Thay thế Đoạn**

Sử dụng [insert](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motionpath/#insert) và [removeAt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/motionpath/#removeAt) để thay thế đường thẳng trong `motion.pptx`. Việc chèn đẩy đường cũ sang chỉ mục 2.

Điều này minh họa việc thay thế một đối tượng lệnh thay vì chỉnh sửa các tọa độ hiện có của nó. Sau khi chèn, bộ sưu tập tạm thời chứa lệnh bắt đầu, đường mới, đường cũ và lệnh end. Xóa chỉ mục 2 loại bỏ đường cũ và để lại lộ trình mới.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đường đã lưu vẫn có ba lệnh, với đường mới kết thúc tại (0.2, 0.1) và lệnh end ở cuối.

## **Sửa đổi và Xác minh Hành vi hiện có**

Khi không biết chỉ mục của hành vi, chọn nó theo kiểu. Ví dụ này mở `rotation.pptx`, tìm [RotationEffect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/rotationeffect/), thay đổi góc và kiểm tra giá trị đã lưu sau khi mở lại.

Kiểm tra kiểu cho phép vòng lặp bỏ qua các hành vi không phải là rotation. Lần tải thứ hai đọc tệp đã lưu vào một đối tượng bản trình bày riêng, vì vậy việc so sánh kiểm tra dữ liệu đã được lưu thay vì giá trị còn trong bộ nhớ. Ví dụ này vẫn giả định hiệu ứng đã biết là đầu tiên trong chuỗi chính; việc chọn hành vi theo kiểu không xác định đúng hiệu ứng trong bản trình bày tùy ý.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Kết quả là `Rotation preserved: True`. Áp dụng cùng mẫu kiểm tra kiểu cho các hành vi khác. Để kiểm tra bảo toàn đầy đủ, so sánh hình mục tiêu, hiệu ứng, kiểu và thứ tự hành vi, thời gian, và các lệnh đường. Sử dụng độ sai số số cho các giá trị dấu phẩy động. Đối với bản trình bày có bố cục hoạt ảnh không xác định, xem [Read Shape Animations](/slides/vi/python-java/shape-animation/#read-shape-animations) để duyệt qua chuỗi chính và chuỗi tương tác.

## **Thứ tự Hành vi, Presets và Phát**

Thứ tự trong [BehaviorCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behaviorcollection/) là thứ tự lưu trữ các thao tác của một hiệu ứng. Nó không phải là một danh sách phát mà mỗi hành vi tự động chờ hành vi trước. Thời gian và hiệu ứng bao bọc quyết định lịch trình. Các hành vi có thể chồng lên nhau, và các thao tác trên cùng một thuộc tính có thể tương tác qua [getAdditive](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behavior/#getAdditive) và [getAccumulate](https://reference.aspose.com/slides/vi/python-java/aspose.slides/behavior/#getAccumulate). Đừng chỉ thay đổi thứ tự bộ sưu tập để lên lịch “di chuyển, rồi quay”; hãy dùng thời gian rõ ràng hoặc các hiệu ứng riêng như mô tả trong [Hoạt ảnh Hình dạng](/slides/vi/python-java/shape-animation/).

Kiểu [getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effect/#getType) và [getSubtype](https://reference.aspose.com/slides/vi/python-java/aspose.slides/effect/#getSubtype) của hiệu ứng mô tả preset của nó. Chúng không phải là mô tả đầy đủ của cây hành vi đã chỉnh sửa. Chọn preset và subtype trước khi tùy chỉnh hành vi: thay đổi preset có thể xây dựng lại bộ sưu tập và loại bỏ các thao tác tùy chỉnh của bạn. Ví dụ, thay đổi một hiệu ứng Spin đã tùy chỉnh thành Fade có thể thay thế hành vi quay bằng hành vi set và filter. Kiểm tra lại bộ sưu tập sau khi thay đổi preset hoặc subtype. Xóa các hành vi preset cũng có thể loại bỏ các thao tác hiển thị hoặc khởi tạo mà preset cần. Các ví dụ cố tình sử dụng hình hiển thị và thay thế các hành vi; chúng không tái tạo toàn bộ triển khai của mỗi preset.

## **Tương thích Định dạng**

Một cây hành vi được bảo tồn không đảm bảo phát lại giống hệt trong mọi trình xem hoặc bộ xuất. Kiểm tra dữ liệu đã lưu và đầu ra được render riêng biệt.

| Format or output | What to verify |
| --- | --- |
| PPTX | Sử dụng làm định dạng chính cho các ví dụ này. Mở lại để xác nhận cây hành vi có thể chỉnh sửa, sau đó kiểm tra phát trong phiên bản PowerPoint mong muốn. |
| PPT | Đại diện nhị phân legacy có thể khác với PPTX. Thử chu trình lưu‑mở‑lại và phát; đừng suy ra hỗ trợ mọi tổ hợp tùy chỉnh chỉ từ kết quả PPTX thành công. |
| PDF, PNG, JPEG, and other static slide images | Chứa một hình ảnh tĩnh của slide, không phải một timeline hành vi có thể phát hoặc khung ảnh cuối cùng được đảm bảo. |
| [HTML5](/slides/vi/python-java/export-to-html5/) | Có thể phát các hoạt ảnh được hỗ trợ khi hoạt ảnh hình được bật trong tùy chọn xuất. Kiểm tra các tổ hợp tùy chỉnh trong trình duyệt. |
| [Animated GIF](/slides/vi/python-java/convert-powerpoint-to-animated-gif/) | Lưu các khung đã render, không phải hành vi có thể chỉnh sửa hoặc tương tác click‑triggered. Kiểm tra chuyển động đã render thực tế. |
| [Video](/slides/vi/python-java/convert-powerpoint-to-video/) | Render các khung hoạt ảnh và mã hoá chúng thành video. Hỗ trợ giới hạn ở [supported animations and effects](/slides/vi/python-java/convert-powerpoint-to-video/#supported-animations-and-effects); lệnh và sự kiện tương tác không trở thành một timeline có thể chỉnh sửa. |

## **FAQ**

**Tại sao hiệu ứng của tôi có hành vi trước khi tôi thêm bất kỳ?**

Tạo một hiệu ứng được định trước có thể tạo các thao tác nền tảng của nó. Kiểm tra chúng trước khi quyết định mở rộng preset hoặc thay thế các hành vi.

**Việc di chuyển một hành vi lên đầu có làm nó phát trước không?**

Không nhất thiết. Thứ tự trong bộ sưu tập không thay thế thời gian. Kiểm tra độ trễ, thời lượng và tương tác giữa các thao tác trên cùng một thuộc tính.

**Tại sao lệnh end có không có điểm?**

Nó đánh dấu kết thúc đường và không cần tọa độ. Kiểm tra mảng điểm null khi kiểm tra đường đọc từ tệp.

**Một vòng tròn hoàn thiện thành công có đủ để xác nhận phát lại?**

Không. Mở lại xác nhận việc bảo tồn các thuộc tính bạn đã kiểm tra. Kiểm tra trình chiếu hoặc xuất hoạt ảnh riêng biệt để xác nhận hành vi hình ảnh của nó.