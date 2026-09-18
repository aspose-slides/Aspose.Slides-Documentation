---
title: Tạo và chỉnh sửa hành vi hoạt ảnh tùy chỉnh trong Java
linktitle: Hoạt ảnh tùy chỉnh
type: docs
weight: 151
url: /vi/java/custom-animation/
keywords:
- hoạt ảnh tùy chỉnh
- hành vi hoạt ảnh
- đường chuyển động
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tạo, kiểm tra và chỉnh sửa các hành vi hoạt ảnh tùy chỉnh và các đường chuyển động có thể chỉnh sửa trong các bản trình chiếu PowerPoint bằng Aspose.Slides cho Java."
---
## **Tổng quan**

Các hành vi hoạt ảnh tùy chỉnh cho phép bạn kiểm soát các thao tác riêng lẻ trong một hiệu ứng hoạt ảnh, chẳng hạn như thay đổi màu, xoay hình dạng hoặc theo một đường chuyển động có thể chỉnh sửa. Hướng dẫn này chỉ ra cách tạo và kết hợp các hành vi, cấu hình thời gian của chúng, kiểm tra và sửa đổi các hoạt ảnh hiện có, và xác nhận rằng các thuộc tính của chúng vẫn tồn tại sau khi lưu và mở lại bản trình chiếu.

Đối với các hiệu ứng đã được định sẵn và kích hoạt bằng cú nhấp, xem [Shape Animation](/slides/vi/java/shape-animation/).

## **Hiểu mô hình hoạt ảnh**

Một hoạt ảnh được tổ chức dưới dạng **Timeline → Sequence → Effect → Behaviors**:

- Phương thức [getTimeline](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseslide/#getTimeline--) trả về timeline của slide, chứa chuỗi chính và các chuỗi tương tác.
- Một [ISequence](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isequence/) chứa các hiệu ứng, có thể nhắm tới các hình dạng khác nhau.
- Một [IEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/) xác định hình dạng mục tiêu, preset, subtype và thời gian hiệu ứng.
- Bộ sưu tập được trả về bởi [IEffect.getBehaviors](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#getBehaviors--) chứa các thao tác thực hiện hiệu ứng: thay đổi màu, di chuyển, xoay, đặt thuộc tính, v.v.

## **Tạo các hành vi riêng lẻ**

Gọi [ISequence.addEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) để tạo một hiệu ứng và truy cập bộ [getBehaviors](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#getBehaviors--) . Một preset có thể tự động điền bộ sưu tập này. Giữ lại các thao tác khi mở rộng preset, hoặc dùng [clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorcollection/#clear--) khi muốn thay thế chúng một cách có chủ ý.

[IBehaviorFactory](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorfactory/) tạo tám loại hành vi được minh họa bên dưới. Động tác được trình bày trong [Build a Motion Path](#build-a-motion-path). Mỗi đoạn mã bao gồm các import của nó; đặt các câu lệnh thực thi bên trong một phương thức. Các ví dụ chỉnh sửa sau này ghi rõ tệp đầu ra mà chúng sử dụng.

### **Xoay**

Dùng [createRotationEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) để tạo một hành vi xoay. [getBy](https://reference.aspose.com/slides/vi/java/com.aspose.slides/irotationeffect/#getBy--) chỉ định góc tương đối theo độ; [getFrom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/irotationeffect/#getFrom--) và [getTo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/irotationeffect/#getTo--) xác định các điểm đầu và cuối.

Ví dụ bắt đầu với một hiệu ứng Spin, thay thế các thao tác preset bằng một hành vi xoay, và cho hành vi này thời lượng hai giây. Góc tương đối 90 độ biểu thị một phần tư vòng quay so với hướng khởi đầu của hình dạng, vì vậy không cần góc khởi đầu rõ ràng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` chứa một hình dạng và một hành vi xoay. Bộ sưu tập, thời gian và các ví dụ chỉnh sửa xoay dưới đây sử dụng tệp này.

### **Thu phóng**

Dùng [createScaleEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) với phần trăm X/Y: [getFrom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iscaleeffect/#getFrom--) và [getTo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iscaleeffect/#getTo--) mô tả kích thước ban đầu và cuối cùng, trong khi [getBy](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iscaleeffect/#getBy--) mô tả thay đổi tương đối. Ở đây, 100 có nghĩa là kích thước gốc.

Ví dụ mở rộng cả hai chiều từ 100 % lên 125 % trong hai giây. Sử dụng cùng tỷ lệ phần trăm ngang và dọc giữ nguyên tỷ lệ hình dạng; các tỷ lệ phần trăm khác nhau sẽ kéo dài một chiều hơn chiều kia.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Màu**

Dùng [createColorEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) để đổi màu nền từ xanh lam sang cam. [getFrom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icoloreffect/#getFrom--) và [getTo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icoloreffect/#getTo--) là các màu; [getBy](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icoloreffect/#getBy--) là độ lệch màu. [IBehavior.getProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehavior/#getProperties--) xác định thuộc tính đang được hoạt ảnh.

Màu nền đặc của hình dạng được khởi tạo thành xanh lam, khớp với màu bắt đầu của hoạt ảnh. Việc chọn thuộc tính màu nền cho hành vi cho biết phần nào của hình dạng sẽ thay đổi; chỉ các màu đầu cuối không xác định thuộc tính đó. Hiệu ứng đã lưu mô tả một chuyển đổi hai giây sang màu cam.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bộ lọc**

Dùng [createFilterEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) để chọn một kiểu xoáy. [getType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifiltereffect/#getSubtype--), và [getReveal](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifiltereffect/#getReveal--) xác định bộ lọc, hướng và việc hiển thị hay ẩn hình dạng.

Ví dụ này cấu hình một chuyển động xoáy hai giây, hiển thị hình dạng theo hướng phải. Các thiết lập bộ lọc thuộc về hành vi trong hiệu ứng, vì vậy chúng được cấu hình sau khi các thao tác gốc của preset đã bị xóa.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Thuộc tính**

Dùng [createPropertyEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) để hoạt ảnh độ trong suốt. [getFrom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipropertyeffect/#getTo--), và [getBy](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipropertyeffect/#getBy--) là các chuỗi được diễn giải bằng [getValueType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipropertyeffect/#getValueType--) và [getCalcMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipropertyeffect/#getCalcMode--). Chọn các điểm cuối hoặc một độ lệch tương đối thay vì đặt cả ba đồng thời một cách vô tội vạ.

Ở đây, thuộc tính được chọn là opacity, và các chuỗi số đại diện cho sự thay đổi từ 25 % tới độ trong suốt đầy đủ. Nội suy tuyến tính mô tả sự thay đổi dần dần giữa các giá trị. Khi áp dụng ví dụ này cho thuộc tính khác, hãy chọn kiểu giá trị và các giá trị đầu cuối phù hợp với thuộc tính đó.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Đặt**

Dùng [createSetEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) để gán trạng thái hiển thị qua [getTo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iseteffect/#getTo--). Một hành vi set không nội suy giữa các điểm cuối.

Ví dụ chọn thuộc tính visibility và gán chuỗi `visible` khi hành vi chạy. Hình chữ nhật đã hiển thị trong bản trình chiếu tối thiểu này, vì vậy việc gán có thể không tạo ra thay đổi trực quan rõ ràng. Một thao tác như vậy hữu ích khi là một phần của hiệu ứng lớn hơn cũng điều khiển thời điểm hình dạng ẩn hoặc hiển thị.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Lệnh**

Dùng [createCommandEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) và cấu hình [getType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icommandeffect/#getCommandString--), và [getShapeTarget](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icommandeffect/#getShapeTarget--). Đặt một tệp âm thanh WAV có tên `sample.wav` vào thư mục làm việc. Ví dụ này nhúng nó bằng [addAudioFrameEmbedded](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) và gắn lệnh phát cho khung âm thanh.

Khung âm thanh vừa là mục tiêu của hiệu ứng vừa là mục tiêu của lệnh. Điều này nối yêu cầu phát tới bản ghi đã nhúng; một chuỗi lệnh đơn độc không xác định đối tượng đa phương tiện nào sẽ được điều khiển. Hiệu ứng được cấu hình để bắt đầu khi người dùng nhấp trong khi trình chiếu.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

Lưu trữ sẽ ghi lệnh vào `command.pptx`; nó sẽ không phát bản ghi. Để phát, cần một trình chiếu hỗ trợ lệnh và mục tiêu đa phương tiện của nó.

## **Quản lý bộ sưu tập hành vi**

[IBehaviorCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorcollection/) hỗ trợ [add](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), và [removeAt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Ví dụ này mở `rotation.pptx`, thêm thu phóng, di chuyển nó trước khi xoay, và xóa hành vi xoay. Việc xóa và chèn lại cùng một đối tượng thay đổi vị trí lưu trữ của nó mà không tạo bản sao.

Chuỗi các chỉnh sửa đổi bộ sưu tập từ rotation–scale sang scale–rotation, rồi chỉ còn scale. Các chỉ số tham chiếu tới bộ sưu tập hiện tại, vì vậy việc xóa sử dụng chỉ số mới của hành vi xoay sau khi đã sắp lại. Đếm cuối cùng xác nhận hành vi nào sẽ được lưu.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả là `ScaleEffect`: chỉ còn thu phóng. Thứ tự trong bộ sưu tập không tự động lên lịch các hành vi liên tiếp nhau. Hãy xóa bộ sưu tập chỉ khi thay thế toàn bộ các thao tác của nó.

## **Cấu hình thời gian hành vi**

[IBehavior.getTiming](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehavior/#getTiming--) công khai [ITiming](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/), độc lập với [IEffect.getTiming](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#getTiming--). Thời gian của hiệu ứng lên lịch cho toàn bộ hiệu ứng; thời gian của hành vi mô tả một thao tác bên trong nó.

### **Đặt thời lượng, độ trễ, lặp lại và tăng tốc**

Mở `rotation.pptx` và đặt thời lượng ([getDuration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getDuration--)) và độ trễ kích hoạt ([getTriggerDelayTime](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) tính bằng giây, sau đó cấu hình số lần lặp qua [setRepeatCount](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getAccelerate--) và [getDecelerate](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getDecelerate--) là các phần của thời lượng; tổng của chúng không được vượt quá 1.

Tệp đầu vào là tệp được tạo trong ví dụ xoay, trong đó hành vi đầu tiên là một xoay. Ví dụ này chỉ thay đổi thời gian của hành vi đó; góc 90 độ vẫn giữ nguyên. Giữ góc và thời gian riêng biệt giúp dễ dàng điều chỉnh tốc độ mà không cần xây dựng lại hoạt ảnh.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hành vi sử dụng thời lượng hai giây, độ trễ nửa giây và số lần lặp 3. 20 % đầu và cuối thời lượng được dùng cho tăng tốc và giảm tốc.

Các chính sách lặp khác bao gồm [getRepeatDuration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), và [getRepeatUntilNextClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--); chọn một chính sách thay vì bật chúng đồng thời. [getAutoReverse](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getAutoReverse--) phát hoạt ảnh ngược lại sau lần chạy xuôi. Tăng tốc và giảm tốc áp dụng cho các thay đổi liên tục, không phải cho các gán hoặc lệnh rời rạc.

## **Xây dựng đường chuyển động**

Dùng [createMotionEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) để tạo chuyển động. Các phương thức [getFrom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotioneffect/#getTo--), và [getBy](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotioneffect/#getBy--) mô tả tọa độ hoặc độ lệch dựa trên phần trăm. Đối với một lộ trình có thể chỉnh sửa, tạo một [MotionPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/motionpath/) và gán nó bằng [IMotionEffect.setPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotionpath/) lưu trữ các lệnh đường dẫn.

[MotionCommandPathType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/motioncommandpathtype/) chọn thao tác:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Đặt vị trí bắt đầu. |
| LineTo | One | Di chuyển theo đoạn thẳng tới điểm cuối. |
| CurveTo | Three | Theo một đường cong bậc ba được định nghĩa bởi hai điểm điều khiển và một điểm cuối. |
| CloseLoop | None | Trở lại vị trí bắt đầu. |
| End | None | Kết thúc đường dẫn. |

[MotionPathPointsType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/motionpathpointstype/) mô tả đặc tính chỉnh sửa điểm, chẳng hạn điểm góc hoặc mượt. Nó không thay thế loại lệnh. Dùng loại điểm curve cho ví dụ đường cong dưới đây, và loại điểm corner cho các đoạn thẳng.

Các tọa độ đường dẫn được chuẩn hoá theo kích thước slide: độ dịch X 0.25 đại diện cho một phần tư chiều rộng slide, không phải 0.25 điểm. Trục Y dương chạy xuống dưới. Các lệnh tuyệt đối chỉ định vị trí trong hệ tọa độ đường dẫn; các lệnh tương đối chỉ định độ lệch từ vị trí hiện tại. Điều này tách biệt với [getOrigin](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotioneffect/#getOrigin--), chọn khung tham chiếu của đường dẫn, và [getPathEditMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotioneffect/#getPathEditMode--), kiểm soát cách đường dẫn di chuyển khi hình dạng di chuyển.

### **Tạo đường thẳng**

Tạo một hành vi chuyển động với điểm bắt đầu, một đoạn thẳng, và một lệnh kết thúc. [IMotionPath.add](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) nhận loại lệnh, các điểm của nó, loại điểm và cờ tọa độ tương đối.

Lệnh bắt đầu thiết lập (0, 0), và đoạn thẳng kết thúc tại (0.25, 0), tạo ra một độ dịch ngang bằng một phần tư chiều rộng slide. Lệnh kết thúc không có điểm tọa độ. Khi đường dẫn được gán, việc thêm hành vi chuyển động vào hiệu ứng sẽ nối đường này với hình chữ nhật.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` chứa một hành vi chuyển động với ba lệnh đường dẫn. Các ví dụ chỉnh sửa tệp dưới đây sử dụng cấu trúc đã biết này.

### **So sánh tọa độ tuyệt đối và tương đối**

Hai đối tượng đường dẫn này mô tả cùng một lộ trình. Lệnh tuyệt đối kết thúc tại (0.3, 0.1); lệnh tương đối cộng (0.1, 0.1) vào vị trí hiện tại, tức (0.2, 0).

Cả hai đường đều bắt đầu ở cùng vị trí. Đối với đoạn thẳng tương đối, cộng các độ dịch X và Y vào vị trí hiện tại để có điểm cuối; đối với đoạn thẳng tuyệt đối, đọc trực tiếp điểm cuối. Chuyển đổi cờ mà không chuyển đổi tọa độ sẽ mô tả một lộ trình khác.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Gán bất kỳ đường nào cho một hành vi chuyển động để sử dụng trong bản trình chiếu. Tham số Boolean cuối cùng chọn tọa độ tương đối cho lệnh đó.

### **Thay thế một đoạn thẳng bằng một đường cong**

Mở `motion.pptx` và thay thế lệnh đoạn thẳng bằng một đường cong bậc ba. Đầu tiên cung cấp hai điểm điều khiển, sau đó là điểm cuối.

Vị trí bắt đầu được cung cấp bởi lệnh trước đó. Hai điểm đầu định hình đường cong, trong khi điểm thứ ba là điểm đến; chúng không phải là ba điểm đích liên tiếp. Cập nhật đồng thời loại lệnh, loại chỉnh sửa điểm và mảng điểm giữ cho đoạn đường nhất quán với hình học mới.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đường trong `curve.pptx` vẫn có ba lệnh; lệnh ở giữa hiện đã định nghĩa một đường cong.

## **Kiểm tra và chỉnh sửa đường đã lưu**

Mỗi [IMotionCmdPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotioncmdpath/) cung cấp [getPoints](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotioncmdPath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotioncmdpath/#getPointsType--), và [isRelative](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotioncmdpath/#isRelative--). Các ví dụ dưới đây dùng đường ba lệnh đã biết trong `motion.pptx`. Đối với đầu vào bất kỳ, xác định hiệu ứng mong muốn và kiểm tra loại lệnh cùng số điểm trước khi chỉnh sửa theo chỉ số.

### **Đọc lệnh và tọa độ**

Đọc đường mà không thay đổi. Các lệnh end và close-loop không cần điểm, vì vậy cho phép mảng điểm null.

Kết quả liệt kê mỗi loại lệnh số với cờ tọa độ tương đối trước khi liệt kê các điểm của nó. Điều này giúp bạn phân biệt một điểm cuối với một độ lệch trước khi sửa đổi đường. Đường cong sẽ liệt kê ba điểm, trong khi đường thẳng trong tệp này chỉ có một điểm.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Danh sách chứa một điểm bắt đầu, một đoạn thẳng tuyệt đối kết thúc tại (0.25, 0), và một lệnh end.

### **Thay đổi điểm cuối**

Mở `motion.pptx` và thay thế mảng điểm của đoạn thẳng để di chuyển điểm cuối của nó.

Trong tệp đầu vào, chỉ số 0 là lệnh bắt đầu và chỉ số 1 là đoạn thẳng. Thay thế điểm duy nhất của đoạn thẳng thay đổi đích mà không thay đổi loại lệnh, thời gian hoặc vị trí trong bộ sưu tập. Vì lệnh sử dụng tọa độ tuyệt đối, cặp mới chỉ định một vị trí chứ không phải một độ lệch được cộng thêm.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đoạn thẳng trong `motion-endpoint.pptx` kết thúc tại (0.4, 0.1); tệp gốc không thay đổi.

### **Thay thế một đoạn**

Dùng [insert](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) và [removeAt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imotionpath/#removeAt-int-) để thay thế đoạn thẳng trong `motion.pptx`. Việc chèn dịch đoạn thẳng cũ sang chỉ số 2.

Điều này minh họa việc thay thế một đối tượng lệnh thay vì chỉnh sửa các tọa độ hiện có của nó. Sau khi chèn, bộ sưu tập tạm thời chứa lệnh bắt đầu, đoạn thẳng mới, đoạn thẳng cũ, và lệnh end. Xóa chỉ số 2 loại bỏ đoạn thẳng cũ và để lại lộ trình mới.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đường đã lưu vẫn có ba lệnh, với đoạn thẳng mới kết thúc tại (0.2, 0.1) và lệnh end ở cuối.

## **Sửa đổi và xác nhận hành vi đã tồn tại**

Khi không biết chỉ số của hành vi, hãy chọn nó theo kiểu. Ví dụ này mở `rotation.pptx`, tìm [IRotationEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/irotationeffect/), thay đổi góc và kiểm tra giá trị đã lưu sau khi mở lại.

Kiểm tra kiểu cho phép vòng lặp bỏ qua các hành vi không phải xoay. Lần tải thứ hai đọc tệp đã lưu vào một đối tượng trình chiếu riêng, vì vậy việc so sánh kiểm tra dữ liệu đã được lưu chứ không phải giá trị còn trong bộ nhớ. Ví dụ này vẫn giả định hiệu ứng đã biết là đầu tiên trong chuỗi chính; việc chọn hành vi theo kiểu không xác định hiệu ứng chính xác trong một bản trình chiếu bất kỳ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Kết quả là `Rotation preserved: true`. Áp dụng cùng mẫu kiểm tra kiểu cho các hành vi khác. Đối với việc kiểm tra bảo toàn toàn diện, so sánh hình dạng mục tiêu, hiệu ứng, loại và thứ tự hành vi, thời gian và các lệnh đường dẫn. Sử dụng dung sai số cho các giá trị dấu phẩy động. Đối với bản trình chiếu có bố cục hoạt ảnh không xác định, xem [Read Shape Animations](/slides/vi/java/shape-animation/#read-shape-animations) để duyệt qua chuỗi chính và chuỗi tương tác.

## **Thứ tự hành vi, preset và phát lại**

Thứ tự trong [IBehaviorCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehaviorcollection/) là thứ tự được lưu của các thao tác trong một hiệu ứng. Nó không phải là một danh sách phát mà mỗi hành vi tự động chờ hành vi trước. Thời gian và hiệu ứng bao quanh quyết định lên lịch. Các hành vi có thể chồng lên nhau, và các thao tác trên cùng một thuộc tính có thể tương tác qua [getAdditive](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehavior/#getAdditive--) và [getAccumulate](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibehavior/#getAccumulate--). Đừng chỉ dùng việc sắp lại thứ tự bộ sưu tập để lên lịch “di chuyển, rồi xoay”; hãy dùng thời gian rõ ràng hoặc các hiệu ứng riêng như mô tả trong [Shape Animation](/slides/vi/java/shape-animation/).

[GetType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#getType--) và [getSubtype](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#getSubtype--) của hiệu ứng mô tả preset của nó. Chúng không phải là mô tả đầy đủ của cây hành vi đã chỉnh sửa. Chọn preset và subtype trước khi tùy chỉnh hành vi: việc thay đổi preset có thể xây dựng lại bộ sưu tập và loại bỏ các thao tác tùy chỉnh của bạn. Ví dụ, chuyển một hiệu ứng Spin đã tùy chỉnh sang Fade có thể thay thế hành vi xoay bằng các hành vi set và filter. Kiểm tra lại bộ sưu tập sau khi thay đổi preset hoặc subtype. Xóa các hành vi preset cũng có thể loại bỏ các thao tác hiển thị hoặc khởi tạo mà preset cần. Các ví dụ sử dụng các hình hiển thị và thay thế các hành vi; chúng không tái tạo toàn bộ triển khai của mỗi preset.

## **Tương thích định dạng**

Một cây hành vi được bảo toàn không đảm bảo phát lại giống nhau trong mọi trình xem hoặc bộ xuất bản. Kiểm tra dữ liệu đã lưu và đầu ra được render riêng biệt.

| Định dạng hoặc đầu ra | Điều cần kiểm tra |
| --- | --- |
| PPTX | Sử dụng làm định dạng chính cho các ví dụ này. Mở lại để xác nhận cây hành vi có thể chỉnh sửa, sau đó kiểm tra phát lại trong phiên bản PowerPoint mong muốn. |
| PPT | Đại diện nhị phân cũ có thể khác so với PPTX. Thực hiện một vòng lưu‑mở‑lại và kiểm tra phát lại; đừng suy ra hỗ trợ mọi sự kết hợp tùy chỉnh chỉ dựa trên kết quả PPTX thành công. |
| PDF, PNG, JPEG và các hình ảnh tĩnh khác | Chứa hình ảnh tĩnh của slide, không phải timeline hành vi có thể phát hoặc khung cuối hoạt ảnh bảo đảm. |
| [HTML5](/slides/vi/java/export-to-html5/) | Có thể phát các hoạt ảnh được hỗ trợ khi bật animation shape trong tùy chọn xuất. Kiểm tra các kết hợp tùy chỉnh trong trình duyệt. |
| [Animated GIF](/slides/vi/java/convert-powerpoint-to-animated-gif/) | Lưu các khung đã render, không phải hành vi có thể chỉnh sửa hoặc tương tác kích hoạt bằng click. Kiểm tra chuyển động đã render thực tế. |
| [Video](/slides/vi/java/convert-powerpoint-to-video/) | Render các khung hoạt ảnh và mã hoá chúng thành video. Hỗ trợ chỉ giới hạn ở các [hoạt ảnh và hiệu ứng được hỗ trợ](/slides/vi/java/convert-powerpoint-to-video/#supported-animations-and-effects); các lệnh và sự kiện tương tác không trở thành một timeline có thể chỉnh sửa. |

## **Câu hỏi thường gặp**

**Tại sao hiệu ứng của tôi lại chứa các hành vi ngay cả khi tôi chưa thêm gì?**

Tạo một hiệu ứng đã định trước có thể tạo ra các thao tác nền của nó. Kiểm tra chúng trước khi quyết định mở rộng preset hoặc thay thế các hành vi.

**Việc di chuyển một hành vi lên đầu có làm nó phát trước không?**

Không nhất thiết. Thứ tự trong bộ sưu tập không thay thế thời gian. Kiểm tra độ trễ, thời lượng và tương tác giữa các thao tác trên cùng một thuộc tính.

**Tại sao lệnh end không có điểm?**

Nó đánh dấu kết thúc đường dẫn và không cần tọa độ. Kiểm tra mảng điểm null khi kiểm tra một đường được đọc từ tệp.

**Một vòng quay thành công có đủ để xác nhận phát lại không?**

Không. Mở lại xác nhận việc bảo toàn các thuộc tính bạn đã kiểm tra. Hãy thử trình chiếu hoặc xuất động ảnh riêng để xác nhận hành vi trực quan.