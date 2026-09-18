---
title: Tạo và Chỉnh sửa Hành vi Hoạt ảnh Tùy chỉnh trên Android
linktitle: Hoạt ảnh Tùy chỉnh
type: docs
weight: 151
url: /vi/androidjava/custom-animation/
keywords:
- hoạt ảnh tùy chỉnh
- hành vi hoạt ảnh
- đường chuyển động
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tạo, kiểm tra và chỉnh sửa các hành vi hoạt ảnh tùy chỉnh và các đường chuyển động có thể chỉnh sửa trong bản trình chiếu PowerPoint bằng Aspose.Slides cho Android thông qua Java."
---
## **Tổng quan**

Các hành vi hoạt ảnh tùy chỉnh cho phép bạn kiểm soát các thao tác riêng lẻ trong một hiệu ứng hoạt ảnh, chẳng hạn như thay đổi màu, quay hình dạng hoặc theo một đường chuyển động có thể chỉnh sửa. Hướng dẫn này trình bày cách tạo và kết hợp các hành vi, cấu hình thời gian của chúng, kiểm tra và sửa đổi các hoạt ảnh hiện có, và xác minh các thuộc tính của chúng vẫn tồn tại sau khi lưu và mở lại bản trình chiếu.

Đối với các hiệu ứng được định trước và kích hoạt bằng cú nhấp, xem [Shape Animation](/slides/vi/androidjava/shape-animation/).

## **Hiểu mô hình hoạt ảnh**

Một hoạt ảnh được tổ chức theo **Timeline → Sequence → Effect → Behaviors**:

- Phương thức [getTimeline](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) trả về thời gian biểu của slide, trong đó chứa chuỗi chính và các chuỗi tương tác.
- Một [ISequence](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isequence/) chứa các hiệu ứng, có thể nhắm đến các hình dạng khác nhau.
- Một [IEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ieffect/) xác định hình dạng mục tiêu, preset, subtype và thời gian của hiệu ứng.
- Bộ sưu tập trả về bởi [IEffect.getBehaviors](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ieffect/#getBehaviors--) chứa các thao tác thực thi hiệu ứng: thay đổi màu, di chuyển, quay, thiết lập thuộc tính, v.v.

## **Tạo các hành vi riêng lẻ**

Gọi [ISequence.addEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) để tạo một hiệu ứng và truy cập bộ sưu tập [getBehaviors](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ieffect/#getBehaviors--). Một preset có thể tự động điền bộ sưu tập này. Giữ lại các thao tác của nó khi mở rộng preset, hoặc dùng [clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) khi cố ý thay thế chúng.

[IBehaviorFactory](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorfactory/) tạo tám loại hành vi được minh họa dưới đây. Motion được giải thích trong [Build a Motion Path](#build-a-motion-path). Mỗi đoạn mã bao gồm các import; đặt các câu lệnh thực thi của nó trong một phương thức. Các ví dụ chỉnh sửa sau này cho biết tệp đầu ra nào được sử dụng. Trên Android, thay thế tên tệp mẫu bằng các đường dẫn đầy đủ trong thư mục mà ứng dụng có thể truy cập, chẳng hạn như thư mục file của ứng dụng.

### **Rotation**

Sử dụng [createRotationEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) để tạo một phép quay. [getBy](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/irotationeffect/#getBy--) xác định góc tương đối tính bằng độ; [getFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/irotationeffect/#getFrom--) và [getTo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/irotationeffect/#getTo--) xác định các điểm cuối.

Ví dụ bắt đầu với một hiệu ứng Spin, thay thế các thao tác preset của nó bằng một hành vi quay, và đặt thời lượng cho hành vi đó là hai giây. Góc tương đối 90 độ thể hiện một phần tư vòng quay so với hướng ban đầu của hình dạng, do đó không cần góc bắt đầu rõ ràng.

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

`rotation.pptx` chứa một hình và một hành vi quay. Bộ sưu tập, thời gian và các ví dụ chỉnh sửa quay bên dưới đều dùng tệp này.

### **Scale**

Sử dụng [createScaleEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) với tỷ lệ phần trăm X/Y: [getFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) và [getTo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iscaleeffect/#getTo--) mô tả kích thước bắt đầu và kết thúc, trong khi [getBy](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iscaleeffect/#getBy--) mô tả sự thay đổi tương đối. Ở đây, 100 nghĩa là kích thước gốc.

Ví dụ tăng cả hai chiều từ 100% lên 125% trong hai giây. Sử dụng các tỷ lệ phần trăm ngang và dọc bằng nhau giữ nguyên tỉ lệ hình, các tỷ lệ khác sẽ kéo giãn một chiều hơn chiều kia.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Color**

Sử dụng [createColorEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) để thay đổi màu nền từ xanh dương sang cam. [getFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icoloreffect/#getFrom--) và [getTo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icoloreffect/#getTo--) là các màu; [getBy](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icoloreffect/#getBy--) là độ dịch màu. [IBehavior.getProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehavior/#getProperties--) xác định thuộc tính đang được hoạt ảnh.

Màu nền đặc của hình được khởi tạo thành màu xanh dương, trùng với màu bắt đầu của hoạt ảnh. Chọn thuộc tính fill-color cho hành vi sẽ cho biết phần nào của hình cần thay đổi; các màu đầu và cuối một mình không xác định thuộc tính đó. Hiệu ứng đã lưu mô tả một chuyển đổi trong hai giây sang màu cam.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filter**

Sử dụng [createFilterEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) để chọn một bộ lọc wipe. [getType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--), và [getReveal](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) xác định bộ lọc, hướng và việc hiển thị hay ẩn hình.

Ví dụ này cấu hình một wipe hai giây hiển thị hình theo subtype hướng phải. Cài đặt bộ lọc thuộc về hành vi bên trong hiệu ứng, vì vậy chúng được cấu hình sau khi các thao tác gốc của preset đã bị xóa.

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

### **Property**

Sử dụng [createPropertyEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) để hoạt ảnh độ mờ. [getFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipropertyeffect/#getTo--), và [getBy](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) là các chuỗi được diễn giải bằng [getValueType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) và [getCalcMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--). Chọn các điểm cuối hoặc độ dịch tương đối thay vì đặt cả ba một cách vô điều kiện.

Ở đây, thuộc tính được chọn là opacity, và các chuỗi số đại diện cho sự thay đổi từ 25% opacity lên opacity đầy đủ. Nội suy tuyến tính mô tả một thay đổi dần dần giữa các giá trị đó. Khi áp dụng ví dụ này cho thuộc tính khác, hãy chọn kiểu giá trị và các giá trị đầu cuối phù hợp với thuộc tính đó.

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

### **Set**

Sử dụng [createSetEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) để gán tính năng hiển thị qua [getTo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iseteffect/#getTo--). Một hành vi set không nội suy giữa các điểm cuối.

Ví dụ chọn thuộc tính visibility và gán chuỗi `visible` khi hành vi chạy. Hình chữ nhật đã hiển thị trong bản trình chiếu tối thiểu này, do đó việc gán có thể không tạo ra sự thay đổi trực quan rõ ràng. Một thao tác như vậy hữu ích khi là một phần của hiệu ứng lớn hơn cũng điều khiển thời điểm hình ẩn hoặc hiện.

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

### **Command**

Sử dụng [createCommandEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) và cấu hình [getType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icommandeffect/#getCommandString--), và [getShapeTarget](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--). Đặt một file ghi âm WAV tên `sample.wav` vào thư mục làm việc. Ví dụ này nhúng nó bằng [addAudioFrameEmbedded](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) và đính kèm lệnh phát cho khung âm thanh.

Khung âm thanh vừa là mục tiêu của hiệu ứng vừa là mục tiêu của lệnh. Điều này kết nối yêu cầu phát với bản ghi đã nhúng; một chuỗi lệnh riêng lẻ không xác định đối tượng media nào sẽ được điều khiển. Hiệu ứng được cấu hình để bắt đầu khi nhấp trong quá trình chiếu slide.

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

Lưu trữ sẽ ghi lệnh vào `command.pptx`; nó không phát bản ghi. Phát lại yêu cầu một trình chiếu hỗ trợ lệnh và đối tượng media mục tiêu.

## **Quản lý bộ sưu tập hành vi**

[IBehaviorCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorcollection/) hỗ trợ [add](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), và [removeAt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Ví dụ này mở `rotation.pptx`, thêm scaling, di chuyển nó trước rotation, và loại bỏ rotation. Việc loại bỏ và chèn lại cùng một đối tượng thay đổi vị trí lưu trữ của nó mà không tạo bản sao.

Chuỗi các chỉnh sửa thay đổi bộ sưu tập từ rotation–scale thành scale–rotation, rồi cuối cùng chỉ còn scale. Các chỉ mục tham chiếu tới bộ sưu tập hiện tại, vì vậy việc loại bỏ dùng chỉ mục mới của rotation sau khi sắp xếp lại. Đếm cuối cùng xác nhận hành vi nào sẽ được lưu.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
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

Kết quả là `ScaleEffect`: chỉ còn scaling. Thứ tự trong bộ sưu tập không tự động lên lịch các hành vi liên tiếp. Chỉ xóa bộ sưu tập khi thay thế toàn bộ các thao tác của nó.

## **Cấu hình thời gian hành vi**

[IBehavior.getTiming](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehavior/#getTiming--) cung cấp [ITiming](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiming/), độc lập với [IEffect.getTiming](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ieffect/#getTiming--). Thời gian của hiệu ứng lên lịch cho toàn bộ hiệu ứng; thời gian của hành vi mô tả một thao tác bên trong nó.

### **Đặt thời lượng, độ trễ, lặp lại và tăng tốc**

Mở `rotation.pptx` và đặt thời lượng ([getDuration](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiming/#getDuration--)) và độ trễ kích hoạt ([getTriggerDelayTime](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) tính bằng giây, sau đó cấu hình số lần lặp qua [setRepeatCount](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiming/#getAccelerate--) và [getDecelerate](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiming/#getDecelerate--) là các phần của thời lượng; giữ tổng của chúng không quá 1.

Tệp đầu vào là tệp được tạo trong ví dụ quay, trong đó hành vi đầu tiên được biết là một rotation. Ví dụ này chỉ thay đổi thời gian của hành vi đó; góc 90 độ vẫn giữ nguyên. Giữ góc và thời gian riêng biệt giúp dễ điều chỉnh tốc độ mà không cần xây dựng lại hoạt ảnh.

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

Hành vi sử dụng thời lượng hai giây, độ trễ nửa giây, và số lần lặp là 3. 20% đầu và 20% cuối của thời lượng được dùng cho tăng tốc và giảm tốc.

Các chính sách lặp khác bao gồm [getRepeatDuration](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), và [getRepeatUntilNextClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--); chọn một chính sách thay vì bật chúng đồng thời. [getAutoReverse](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiming/#getAutoReverse--) phát hoạt ảnh ngược lại sau lần chạy xuôi. Tăng tốc và giảm tốc áp dụng cho các thay đổi liên tục, không phải cho các gán rời rạc hoặc lệnh.

## **Xây dựng một đường chuyển động**

Sử dụng [createMotionEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) để tạo chuyển động. Các phương thức [getFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotioneffect/#getTo--), và [getBy](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotioneffect/#getBy--) mô tả tọa độ hoặc độ dịch dựa trên phần trăm. Để có một tuyến đường có thể chỉnh sửa, tạo một [MotionPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/motionpath/) và gán nó bằng [IMotionEffect.setPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotionpath/) lưu các lệnh đường.

[MotionCommandPathType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/motioncommandpathtype/) chọn thao tác:

| Lệnh | Điểm | Ý nghĩa |
| --- | --- | --- |
| MoveTo | Một | Đặt vị trí bắt đầu. |
| LineTo | Một | Di chuyển dọc một đoạn thẳng tới điểm cuối. |
| CurveTo | Ba | Theo một đường cong bậc ba được xác định bởi hai điểm điều khiển và một điểm cuối. |
| CloseLoop | Không có | Quay lại vị trí bắt đầu. |
| End | Không có | Kết thúc đường. |

[MotionPathPointsType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/motionpathpointstype/) mô tả đặc điểm chỉnh sửa điểm, chẳng hạn như điểm góc hoặc mượt. Nó không thay thế loại lệnh. Dùng loại điểm curve cho ví dụ đường cong dưới đây, và loại điểm corner cho các đoạn thẳng.

Tọa độ đường được chuẩn hoá theo kích thước slide: một độ dịch X = 0.25 tương đương một phần tư chiều rộng slide, không phải 0.25 điểm. Y dương chạy xuống dưới. Các lệnh absolute xác định vị trí trong hệ tọa độ đường; các lệnh relative xác định độ dịch so với vị trí hiện tại. Điều này tách biệt với [getOrigin](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotioneffect/#getOrigin--), chọn khung tham chiếu của đường, và [getPathEditMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--), điều khiển cách đường di chuyển khi hình dịch chuyển.

### **Tạo một đường thẳng**

Tạo một hành vi motion với điểm bắt đầu, một đoạn thẳng, và một lệnh kết thúc. [IMotionPath.add](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) nhận loại lệnh, các điểm của nó, loại điểm, và cờ tọa độ tương đối.

Lệnh bắt đầu thiết lập (0, 0), và đoạn thẳng kết thúc tại (0.25, 0), tạo ra dịch chuyển ngang một phần tư chiều rộng slide. Lệnh kết thúc không có điểm tọa độ. Khi đường được gán, việc thêm hành vi motion vào hiệu ứng sẽ kết nối tuyến đường này với hình chữ nhật.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` chứa một hành vi motion với ba lệnh đường. Các ví dụ chỉnh sửa file dưới đây dùng cấu trúc đã biết này.

### **So sánh tọa độ Absolute và Relative**

Hai đối tượng đường này mô tả cùng một tuyến đường. Lệnh absolute kết thúc tại (0.3, 0.1); lệnh relative thêm (0.1, 0.1) vào vị trí hiện tại, (0.2, 0).

Cả hai đường đều bắt đầu ở cùng vị trí. Đối với đường relative, cộng các độ dịch X và Y vào vị trí hiện tại để có điểm cuối; đối với đường absolute, đọc trực tiếp điểm cuối. Chuyển cờ mà không chuyển đổi tọa độ sẽ tạo ra một tuyến đường khác.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Gán bất kỳ đường nào cho một hành vi motion để sử dụng trong bản trình chiếu. Đối số Boolean cuối cùng chọn tọa độ relative cho lệnh đó.

### **Thay thế một đoạn thẳng bằng một đường cong**

Mở `motion.pptx` và thay thế lệnh line bằng một đường cong bậc ba. Đầu tiên cung cấp hai điểm điều khiển, sau đó là điểm cuối.

Vị trí bắt đầu được cung cấp bởi lệnh trước đó. Hai điểm đầu tiên định hình đường cong, trong khi điểm thứ ba là điểm đến; chúng không phải là ba điểm đích liên tiếp. Cập nhật đồng thời loại lệnh, loại chỉnh sửa điểm, và mảng điểm giữ cho đoạn phù hợp với hình học mới.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đường trong `curve.pptx` vẫn có ba lệnh; lệnh giữa giờ định nghĩa một đường cong.

## **Kiểm tra và chỉnh sửa một đường đã lưu**

Mỗi [IMotionCmdPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotioncmdpath/) cung cấp [getPoints](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), và [isRelative](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--). Các ví dụ sau dùng đường ba lệnh đã biết trong `motion.pptx`. Đối với đầu vào tùy ý, xác định hiệu ứng mong muốn và kiểm tra loại lệnh và số điểm trước khi chỉnh sửa theo chỉ mục.

### **Đọc các lệnh và tọa độ**

Đọc đường mà không thay đổi nó. Các lệnh end và close-loop không cần điểm, vì vậy cần chuẩn bị cho mảng điểm null.

Kết quả liệt kê mỗi loại lệnh số với cờ tọa độ relative trước khi liệt kê các điểm của nó. Điều này giúp bạn phân biệt điểm cuối và độ dịch trước khi sửa đường. Một đường cong sẽ liệt kê ba điểm, trong khi đoạn thẳng trong file này chỉ liệt kê một điểm.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Danh sách chứa một điểm bắt đầu, một đoạn thẳng absolute kết thúc tại (0.25, 0), và một lệnh end.

### **Thay đổi điểm cuối**

Mở `motion.pptx` và thay thế mảng điểm của line để di chuyển điểm cuối của nó.

Trong tệp input, chỉ mục 0 là lệnh bắt đầu và chỉ mục 1 là line. Thay thế điểm duy nhất của line thay đổi đích mà không thay đổi loại lệnh, thời gian hoặc vị trí trong bộ sưu tập. Vì lệnh dùng tọa độ absolute, cặp mới xác định một vị trí chứ không phải một độ dịch thêm.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đường trong `motion-endpoint.pptx` kết thúc tại (0.4, 0.1); tệp gốc không bị thay đổi.

### **Thay thế một đoạn**

Sử dụng [insert](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) và [removeAt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) để thay thế line trong `motion.pptx`. Việc chèn dịch line cũ sang chỉ mục 2.

Điều này minh họa việc thay thế một đối tượng lệnh thay vì chỉnh sửa tọa độ hiện có của nó. Sau khi chèn, bộ sưu tập tạm thời chứa lệnh bắt đầu, line mới, line cũ, và lệnh end. Loại bỏ chỉ mục 2 loại bỏ line cũ và giữ lại tuyến đường mới.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đường đã lưu vẫn có ba lệnh, với line mới kết thúc tại (0.2, 0.1) và lệnh end ở cuối.

## **Chỉnh sửa và xác nhận một hành vi hiện có**

Khi không biết chỉ mục của hành vi, chọn nó theo kiểu. Ví dụ này mở `rotation.pptx`, tìm [IRotationEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/irotationeffect/), thay đổi góc, và kiểm tra giá trị đã lưu sau khi mở lại.

Kiểm tra kiểu cho phép vòng lặp bỏ qua những hành vi không phải là rotation. Lần tải thứ hai đọc tệp đã lưu vào một đối tượng bản trình chiếu riêng, vì vậy so sánh kiểm tra dữ liệu đã lưu chứ không phải giá trị còn trong bộ nhớ. Ví dụ này vẫn giả định hiệu ứng đã biết là đầu tiên trong chuỗi chính; chọn hành vi theo kiểu không xác định đúng hiệu ứng trong một bản trình chiếu tùy ý.

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

Kết quả là `Rotation preserved: true`. Áp dụng cùng mẫu kiểm tra kiểu cho các hành vi khác. Để kiểm tra đầy đủ việc bảo tồn, so sánh hình mục tiêu, hiệu ứng, kiểu và thứ tự hành vi, thời gian, và các lệnh đường. Dùng dung sai số cho các giá trị dấu phẩy động. Đối với bản trình chiếu có bố cục hoạt ảnh không xác định, xem [Read Shape Animations](/slides/vi/androidjava/shape-animation/#read-shape-animations) để duyệt qua chuỗi chính và chuỗi tương tác.

## **Thứ tự hành vi, Preset và phát lại**

Thứ tự trong [IBehaviorCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehaviorcollection/) là thứ tự lưu trữ các thao tác của một hiệu ứng. Nó không phải là một playlist mà mỗi hành vi tự động chờ hành vi trước. Thời gian và hiệu ứng bao quanh quyết định lịch trình. Các hành vi có thể chồng lên nhau, và các thao tác trên cùng một thuộc tính có thể tương tác qua [getAdditive](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehavior/#getAdditive--) và [getAccumulate](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibehavior/#getAccumulate--). Không sử dụng việc sắp xếp lại bộ sưu tập một mình để lên lịch “di chuyển, rồi quay”; hãy dùng thời gian rõ ràng hoặc các hiệu ứng riêng như mô tả trong [Shape Animation](/slides/vi/androidjava/shape-animation/).

[getType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ieffect/#getType--) và [getSubtype](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ieffect/#getSubtype--) của hiệu ứng mô tả preset của nó. Chúng không phải là mô tả đầy đủ của một cây hành vi đã chỉnh sửa. Chọn preset và subtype trước khi tùy chỉnh các hành vi: việc thay đổi preset có thể xây dựng lại bộ sưu tập và loại bỏ các thao tác tùy chỉnh của bạn. Ví dụ, đổi một hiệu ứng Spin đã tùy chỉnh sang Fade có thể thay thế hành vi quay bằng các hành vi set và filter. Kiểm tra lại bộ sưu tập sau khi đổi preset hoặc subtype. Xóa các hành vi preset cũng có thể loại bỏ các thao tác visibility hoặc khởi tạo mà preset cần. Các ví dụ này cố ý dùng các hình hiển thị và thay thế các hành vi; chúng không xây dựng lại toàn bộ triển khai của mỗi preset.

## **Tương thích định dạng**

Một cây hành vi được bảo tồn không đảm bảo phát lại giống nhau trong mọi trình xem hoặc trình render xuất. Kiểm tra dữ liệu đã lưu và đầu ra render riêng biệt.

| Định dạng hoặc đầu ra | Cần xác minh |
| --- | --- |
| PPTX | Dùng làm định dạng chính cho các ví dụ này. Mở lại để xác minh cây hành vi có thể chỉnh sửa, sau đó kiểm tra phát lại trong phiên bản PowerPoint mong muốn. |
| PPT | Đại diện nhị phân cũ có thể khác với PPTX. Thử vòng lưu-mở lại riêng và phát lại; đừng suy ra hỗ trợ mọi kết hợp tùy chỉnh chỉ từ kết quả PPTX thành công. |
| PDF, PNG, JPEG và các ảnh slide tĩnh khác | Chứa một hình ảnh slide tĩnh, không phải một timeline hành vi có thể phát hoặc một khung hoạt ảnh cuối cùng được đảm bảo. |
| [HTML5](/slides/vi/androidjava/export-to-html5/) | Có thể phát các hoạt ảnh được hỗ trợ khi animation shape được bật trong tùy chọn xuất. Kiểm tra các kết hợp tùy chỉnh trong trình duyệt. |
| [Animated GIF](/slides/vi/androidjava/convert-powerpoint-to-animated-gif/) | Lưu các khung đã render, không phải các hành vi có thể chỉnh sửa hay tương tác click-trigger. Kiểm tra chuyển động đã render thực tế. |
| [Video](/slides/vi/androidjava/convert-powerpoint-to-video/) | Render các khung hoạt ảnh và mã hoá chúng thành video. Hỗ trợ bị giới hạn bởi các [hoạt ảnh và hiệu ứng được hỗ trợ](/slides/vi/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) của renderer; các lệnh và sự kiện tương tác không trở thành một timeline có thể chỉnh sửa. |

## **FAQ**

**Tại sao hiệu ứng của tôi lại có các hành vi trước khi tôi thêm bất kỳ hành vi nào?**

Tạo một hiệu ứng preset có thể tạo các thao tác nền tảng của nó. Kiểm tra chúng trước khi quyết định mở rộng preset hoặc thay thế các hành vi.

**Việc di chuyển một hành vi lên đầu có làm nó chạy trước không?**

Không nhất thiết. Thứ tự trong bộ sưu tập không thay thế cho thời gian. Kiểm tra độ trễ, thời lượng và tương tác giữa các thao tác trên cùng một thuộc tính.

**Tại sao lệnh end không có điểm?**

Nó đánh dấu kết thúc đường và không cần tọa độ. Khi kiểm tra một đường đọc từ file, hãy kiểm tra mảng điểm null.

**Một vòng mở‑lưu‑mở lại thành công có đủ để xác nhận phát lại không?**

Không. Mở lại chỉ xác nhận bảo tồn các thuộc tính bạn đã kiểm tra. Hãy thử trình chiếu hoặc xuất động ảnh riêng để xác nhận hành vi trực quan của nó.