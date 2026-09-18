---
title: Tạo và Chỉnh sửa Hành vi Hoạt ảnh Tùy chỉnh trong JavaScript
linktitle: Hoạt ảnh Tùy chỉnh
type: docs
weight: 151
url: /vi/nodejs-java/custom-animation/
keywords:
- hoạt ảnh tùy chỉnh
- hành vi hoạt ảnh
- đường chuyển động
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo, kiểm tra và chỉnh sửa các hành vi hoạt ảnh tùy chỉnh và các đường chuyển động có thể chỉnh sửa trong bản trình chiếu PowerPoint với Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Các hành vi hoạt ảnh tùy chỉnh cho phép bạn kiểm soát các thao tác riêng lẻ trong một hiệu ứng hoạt ảnh, chẳng hạn như thay đổi màu, quay một hình dạng, hoặc theo một đường chuyển động có thể chỉnh sửa. Hướng dẫn này chỉ ra cách tạo và kết hợp các hành vi, cấu hình thời gian của chúng, kiểm tra và sửa đổi các hoạt ảnh hiện có, và xác minh rằng các thuộc tính của chúng vẫn tồn tại sau khi lưu và mở lại một bản trình chiếu.

Đối với các hiệu ứng có sẵn và các trình kích hoạt nhấp chuột, xem [Hoạt ảnh Hình dạng](/slides/vi/nodejs-java/shape-animation/).

## **Hiểu mô hình hoạt ảnh**

Một hoạt ảnh được tổ chức theo **Timeline → Sequence → Effect → Behaviors**:

- Phương thức [getTimeline](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/#getTimeline) trả về thời gian biểu của slide, bao gồm chuỗi chính và các chuỗi tương tác.
- Một [Sequence](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sequence/) chứa các hiệu ứng, có thể nhắm đến các hình dạng khác nhau.
- Một [Effect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/) xác định hình dạng mục tiêu, preset, subtype và thời gian của hiệu ứng.
- Bộ sưu tập trả về bởi [Effect.getBehaviors](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#getBehaviors) chứa các thao tác thực hiện hiệu ứng: thay đổi màu, di chuyển, quay, đặt thuộc tính, v.v.

## **Tạo các hành vi riêng lẻ**

Gọi [Sequence.addEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sequence/#addEffect) để tạo một hiệu ứng và truy cập bộ sưu tập [getBehaviors](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#getBehaviors). Một preset có thể tự động điền bộ sưu tập này. Giữ lại các thao tác của nó khi mở rộng preset, hoặc dùng [clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorcollection/#clear) khi muốn thay thế chúng một cách có chủ ý.

[BehaviorFactory](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorfactory/) tạo ra tám loại hành vi được minh họa bên dưới. Động chuyển được trình bày trong phần [Xây dựng Đường chuyển động] (#build-a-motion-path). Mỗi đoạn mã bao gồm việc nhập module và có thể chạy như một script Node.js khi đã cài đặt các package `aspose.slides.via.java` và `java`. Chạy các ví dụ tạo tệp trước các ví dụ đọc kết quả của chúng. Các ví dụ chỉnh sửa sau này cho biết tệp đầu ra nào được sử dụng.

### **Xoay**

Sử dụng [createRotationEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) để tạo một hành vi xoay. [getBy](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/rotationeffect/#getBy) chỉ định góc tương đối tính bằng độ; [getFrom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/rotationeffect/#getFrom) và [getTo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/rotationeffect/#getTo) chỉ định các điểm đầu và cuối.

Ví dụ bắt đầu bằng một hiệu ứng Spin, thay thế các thao tác preset của nó bằng một hành vi xoay, và đặt thời lượng cho hành vi này là hai giây. Góc tương đối 90 độ biểu thị một phần tư vòng quay so với hướng ban đầu của hình, vì vậy không cần chỉ định góc bắt đầu một cách rõ ràng.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` chứa một hình và một hành vi xoay. Bộ sưu tập, thời gian và các ví dụ chỉnh sửa xoay dưới đây sử dụng tệp này.

### **Thu phóng**

Sử dụng [createScaleEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) với phần trăm X/Y: [getFrom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/scaleeffect/#getFrom) và [getTo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/scaleeffect/#getTo) mô tả kích thước ban đầu và kích thước cuối, trong khi [getBy](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/scaleeffect/#getBy) mô tả thay đổi tương đối. Ở đây, 100 có nghĩa là kích thước gốc.

Ví dụ tăng cả hai chiều từ 100 % lên 125 % trong hai giây. Sử dụng các phần trăm ngang và dọc bằng nhau sẽ giữ tỷ lệ của hình; các phần trăm khác nhau sẽ kéo giãn một chiều hơn chiều còn lại.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Màu**

Sử dụng [createColorEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) để thay đổi màu nền từ xanh dương sang cam. [getFrom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/coloreffect/#getFrom) và [getTo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/coloreffect/#getTo) là các màu; [getBy](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/coloreffect/#getBy) là độ dịch màu. [Behavior.getProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behavior/#getProperties) xác định thuộc tính đang được hoạt ảnh.

Nền hình dạng được khởi tạo là màu xanh dương, khớp với màu bắt đầu của hoạt ảnh. Việc chọn thuộc tính màu nền cho biết hành vi sẽ thay đổi phần nào của hình; chỉ có các điểm màu cuối không xác định thuộc tính này. Hiệu ứng đã lưu mô tả một chuyển đổi hai giây sang màu cam.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bộ lọc**

Sử dụng [createFilterEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) để chọn một kiểu quét. [getType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filtereffect/#getSubtype) và [getReveal](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filtereffect/#getReveal) chỉ định bộ lọc, hướng và việc hiển thị hay ẩn hình.

Ví dụ này cấu hình một hiệu ứng quét hai giây hiển thị hình bằng kiểu con phụ hướng phải. Các cài đặt bộ lọc thuộc về hành vi bên trong hiệu ứng, vì vậy chúng được cấu hình sau khi các thao tác gốc của preset đã bị xóa.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Thuộc tính**

Sử dụng [createPropertyEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) để hoạt ảnh độ mờ. [getFrom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/propertyeffect/#getTo) và [getBy](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/propertyeffect/#getBy) là các chuỗi được diễn giải bằng [getValueType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/propertyeffect/#getValueType) và [getCalcMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). Hãy chọn các điểm cuối hoặc một độ dịch tương đối thay vì đặt cả ba một cách ngẫu nhiên.

Ở đây, thuộc tính được chọn là độ mờ, và các chuỗi số đại diện cho sự thay đổi từ 25 % độ mờ lên độ mờ đầy đủ. Nội suy tuyến tính mô tả sự thay đổi dần dần giữa các giá trị đó. Khi áp dụng ví dụ này cho thuộc tính khác, hãy chọn kiểu giá trị và các giá trị điểm cuối phù hợp với thuộc tính đó.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Đặt**

Sử dụng [createSetEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) để gán tính năng hiển thị qua [getTo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/seteffect/#getTo). Một hành vi “set” không nội suy giữa các điểm cuối.

Ví dụ chọn thuộc tính hiển thị và gán chuỗi `visible` khi hành vi chạy. Hình chữ nhật đã hiển thị trong bản trình chiếu tối thiểu này, vì vậy việc gán có thể không tạo ra sự thay đổi hình ảnh rõ ràng. Kiểu thao tác này hữu ích khi là một phần của một hiệu ứng lớn hơn cũng kiểm soát thời điểm hình dạng được ẩn hoặc hiển thị.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Lệnh**

Sử dụng [createCommandEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) và cấu hình [getType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/commandeffect/#getCommandString) và [getShapeTarget](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Đặt một file ghi âm WAV tên `sample.wav` trong thư mục làm việc. Ví dụ này nhúng nó bằng [addAudioFrameEmbedded](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) và gắn một lệnh phát cho khung audio.

Khung audio vừa là mục tiêu của hiệu ứng vừa là mục tiêu của lệnh. Điều này nối yêu cầu phát với bản ghi đã nhúng; một chuỗi lệnh đơn độc không xác định đối tượng media nào sẽ được điều khiển. Hiệu ứng được cấu hình để bắt đầu khi người dùng nhấp trong khi trình chiếu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

Lưu lại sẽ lưu lệnh trong `command.pptx`; nó không phát bản ghi. Để phát, cần một trình chiếu hỗ trợ lệnh và đối tượng media của nó.

## **Quản lý Bộ sưu tập Hành vi**

[BehaviorCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorcollection/) hỗ trợ [add](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorcollection/#remove) và [removeAt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorcollection/#removeAt). Ví dụ này mở `rotation.pptx`, thêm thu phóng, di chuyển nó lên trước hành vi xoay, và xóa hành vi xoay. Việc xóa và chèn lại cùng một đối tượng sẽ thay đổi vị trí lưu trữ của nó mà không tạo bản sao.

Chuỗi các chỉnh sửa chuyển bộ sưu tập từ xoay‑thu phóng sang thu phóng‑xoay, rồi cuối cùng chỉ còn thu phóng. Các chỉ mục luôn tham chiếu tới bộ sưu tập hiện tại, vì vậy việc xóa dùng chỉ mục mới của hành vi xoay sau khi đã sắp lại. Đếm lại cuối cùng xác nhận hành vi nào sẽ được lưu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả là `ScaleEffect`: chỉ còn thu phóng. Thứ tự trong bộ sưu tập tự nó không lên lịch các hành vi theo thứ tự liên tiếp. Chỉ xóa bộ sưu tập khi muốn thay thế toàn bộ các thao tác của nó.

## **Cấu hình Thời gian Hành vi**

[Behavior.getTiming](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behavior/#getTiming) cung cấp [Timing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/), độc lập với [Effect.getTiming](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#getTiming). Thời gian hiệu ứng lên lịch cho toàn bộ hiệu ứng; thời gian hành vi mô tả một thao tác bên trong nó.

### **Đặt Thời lượng, Độ trễ, Lặp lại và Tăng tốc**

Mở `rotation.pptx` và đặt thời lượng ([getDuration](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getDuration)) và độ trễ kích hoạt ([getTriggerDelayTime](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) tính bằng giây, sau đó cấu hình số lần lặp qua [setRepeatCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getAccelerate) và [getDecelerate](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getDecelerate) là các phần của thời lượng; giữ tổng của chúng không vượt quá 1.

Tệp đầu vào là tệp được tạo trong ví dụ xoay, trong đó hành vi đầu tiên đã biết là một hành vi xoay. Ví dụ này chỉ thay đổi thời gian của hành vi đó; góc 90 độ vẫn giữ nguyên. Việc tách góc và thời gian giúp dễ điều chỉnh tốc độ mà không cần xây dựng lại hoạt ảnh.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hành vi này dùng thời lượng hai giây, độ trễ nửa giây và lặp lại 3 lần. 20 % đầu và 20 % cuối của thời lượng được dùng cho tăng tốc và giảm tốc.

Các chính sách lặp lại khác bao gồm [getRepeatDuration](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) và [getRepeatUntilNextClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); hãy chọn một chính sách thay vì bật chúng đồng thời. [getAutoReverse](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getAutoReverse) sẽ phát hoạt ảnh ngược lại sau lần chạy xuôi. Tăng tốc và giảm tốc chỉ áp dụng cho các thay đổi liên tục, không phải cho các gán rời rạc hay lệnh.

## **Xây dựng Đường chuyển động**

Sử dụng [createMotionEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) để tạo chuyển động. Các phương thức [getFrom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motioneffect/#getTo) và [getBy](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motioneffect/#getBy) mô tả các tọa độ hoặc độ dịch dựa trên phần trăm. Để tạo một lộ trình có thể chỉnh sửa, tạo một [MotionPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motionpath/) và gán nó bằng [MotionEffect.setPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motionpath/) lưu trữ các lệnh đường.

[MotionCommandPathType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motioncommandpathtype/) chọn loại thao tác:

| Lệnh | Điểm | Ý nghĩa |
| --- | --- | --- |
| MoveTo | One | Đặt vị trí bắt đầu. |
| LineTo | One | Di chuyển dọc một đoạn thẳng tới điểm cuối. |
| CurveTo | Three | Theo một đường cong bậc ba được xác định bởi hai điểm điều khiển và một điểm cuối. |
| CloseLoop | None | Quay trở lại vị trí bắt đầu. |
| End | None | Kết thúc đường. |

[MotionPathPointsType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motionpathpointstype/) mô tả đặc tính chỉnh sửa điểm, chẳng hạn như điểm góc hoặc điểm mượt. Nó không thay thế loại lệnh. Dùng kiểu điểm cong cho ví dụ đường cong dưới đây, và kiểu điểm góc cho các đoạn thẳng.

Các tọa độ đường được chuẩn hoá theo kích thước slide: một độ dịch X bằng 0.25 đại diện cho một phần tư chiều rộng slide, không phải 0.25 điểm. Trục Y dương chạy xuống dưới. Các lệnh tuyệt đối chỉ định vị trí trong hệ tọa độ đường; các lệnh tương đối chỉ định độ dịch so với vị trí hiện tại. Điều này tách biệt với [getOrigin](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motioneffect/#getOrigin), lựa chọn khung tham chiếu của đường, và [getPathEditMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), kiểm soát cách đường di chuyển khi hình dạng di chuyển.

### **Tạo Đường Thẳng**

Tạo một hành vi chuyển động với một điểm bắt đầu, một đoạn thẳng và một lệnh kết thúc. [MotionPath.add](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motionpath/#add) nhận loại lệnh, các điểm của nó, kiểu điểm và cờ tọa độ tương đối.

Lệnh bắt đầu thiết lập (0, 0), và đoạn thẳng kết thúc tại (0.25, 0), tạo ra một độ dịch ngang bằng một phần tư chiều rộng slide. Lệnh kết thúc không có điểm tọa độ. Khi đường được gán, việc thêm hành vi chuyển động vào hiệu ứng sẽ kết nối lộ trình này với hình chữ nhật.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` chứa một hành vi chuyển động với ba lệnh đường. Các ví dụ chỉnh sửa tệp dưới đây sử dụng cấu trúc đã biết này.

### **So sánh Tọa độ Tuyệt đối và Tương đối**

Hai đối tượng đường này mô tả cùng một lộ trình. Lệnh tuyệt đối kết thúc ở (0.3, 0.1); lệnh tương đối cộng (0.1, 0.1) vào vị trí hiện tại (0.2, 0).

Cả hai đường đều bắt đầu ở cùng một vị trí. Đối với đoạn thẳng tương đối, cộng các độ dịch X và Y vào vị trí hiện tại để lấy điểm cuối; đối với đoạn thẳng tuyệt đối, đọc điểm cuối trực tiếp. Chuyển đổi cờ mà không chuyển đổi các tọa độ sẽ mô tả một lộ trình khác.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

Gán bất kỳ đường nào trong hai cách trên cho một hành vi chuyển động để sử dụng trong bản trình chiếu. Đối số Boolean cuối cùng chọn tọa độ tương đối cho lệnh đó.

### **Thay Thế Đoạn Thẳng Bằng Đường Cong**

Mở `motion.pptx` và thay thế lệnh đoạn thẳng bằng một đường cong bậc ba. Đầu tiên cung cấp hai điểm điều khiển, sau đó là điểm cuối.

Vị trí bắt đầu được cung cấp bởi lệnh trước đó. Hai điểm đầu tiên tạo hình cong, trong khi điểm thứ ba là điểm đến; chúng không phải là ba điểm đích liên tiếp. Cập nhật đồng thời loại lệnh, kiểu chỉnh sửa điểm và mảng điểm sẽ giữ cho đoạn luôn nhất quán với hình học mới.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đường trong `curve.pptx` vẫn có ba lệnh; lệnh ở giữa hiện giờ xác định một đường cong.

## **Kiểm tra và Chỉnh sửa Đường đã Lưu**

Mỗi [MotionCmdPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motioncmdpath/) cung cấp [getPoints](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) và [isRelative](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motioncmdpath/#isRelative). Các ví dụ sau sử dụng đường ba lệnh đã biết trong `motion.pptx`. Đối với đầu vào tùy ý, hãy tìm hiệu ứng mong muốn và kiểm tra loại lệnh cũng như số lượng điểm trước khi chỉnh sửa theo chỉ mục.

### **Đọc Lệnh và Tọa độ**

Đọc đường mà không thay đổi nó. Các lệnh end và close-loop không cần điểm, vì vậy hãy cho phép mảng điểm null.

Kết quả liệt kê mỗi loại lệnh số cùng với cờ tọa độ tương đối trước khi liệt kê các điểm. Điều này cho phép bạn phân biệt một điểm cuối với một độ dịch trước khi sửa đổi đường. Đường cong sẽ liệt kê ba điểm, trong khi đoạn thẳng trong tệp này chỉ có một điểm.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Danh sách chứa một điểm bắt đầu, một đoạn thẳng tuyệt đối kết thúc tại (0.25, 0), và một lệnh end.

### **Thay Đổi Điểm Cuối**

Mở `motion.pptx` và thay thế mảng điểm của đoạn thẳng để di chuyển điểm cuối của nó.

Trong tệp đầu vào, chỉ mục 0 là lệnh bắt đầu và chỉ mục 1 là đoạn thẳng. Thay thế điểm duy nhất của đoạn thẳng sẽ thay đổi điểm đến mà không thay đổi loại lệnh, thời gian hay vị trí trong bộ sưu tập. Vì lệnh sử dụng tọa độ tuyệt đối, cặp mới chỉ định một vị trí thay vì một độ dịch cộng thêm.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đoạn thẳng trong `motion-endpoint.pptx` kết thúc tại (0.4, 0.1); tệp gốc không bị thay đổi.

### **Thay Thế Một Đoạn**

Sử dụng [insert](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motionpath/#insert) và [removeAt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/motionpath/#removeAt) để thay thế đoạn thẳng trong `motion.pptx`. Việc chèn sẽ làm đoạn thẳng cũ dịch sang chỉ mục 2.

Điều này minh họa việc thay thế một đối tượng lệnh thay vì chỉnh sửa các tọa độ hiện có của nó. Sau khi chèn, bộ sưu tập tạm thời chứa lệnh bắt đầu, đoạn thẳng mới, đoạn thẳng cũ và lệnh end. Xóa chỉ mục 2 sẽ loại bỏ đoạn thẳng cũ và để lại lộ trình mới tại chỗ.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đường đã lưu vẫn có ba lệnh, với đoạn thẳng mới kết thúc tại (0.2, 0.1) và lệnh end ở cuối.

## **Sửa đổi và Xác minh Hành vi hiện có**

Khi không biết chỉ mục của hành vi, hãy chọn nó theo loại. Ví dụ này mở `rotation.pptx`, tìm [RotationEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/rotationeffect/), thay đổi góc và kiểm tra giá trị đã lưu sau khi mở lại.

Kiểm tra loại cho phép vòng lặp bỏ qua các hành vi không phải là xoay. Lần tải thứ hai đọc tệp đã lưu vào một đối tượng trình chiếu riêng, vì vậy việc so sánh kiểm tra dữ liệu đã lưu chứ không phải giá trị còn nằm trong bộ nhớ. Ví dụ này vẫn giả định hiệu ứng đã biết là thứ nhất trong chuỗi chính; việc chọn hành vi theo loại không đảm bảo tìm đúng hiệu ứng trong một bản trình chiếu bất kỳ.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Kết quả là `Rotation preserved: true`. Áp dụng cùng một mẫu kiểm tra loại cho các hành vi khác. Đối với một kiểm tra bảo toàn toàn diện, so sánh hình mục tiêu, hiệu ứng, loại và thứ tự hành vi, thời gian và các lệnh đường. Sử dụng độ sai số số cho các giá trị dấu chấm động. Đối với bản trình chiếu có bố cục hoạt ảnh không xác định, xem [Đọc Hoạt ảnh Hình dạng](/slides/vi/nodejs-java/shape-animation/#read-shape-animations) để duyệt qua chuỗi chính và chuỗi tương tác.

## **Thứ tự Hành vi, Preset và Phát lại**

Thứ tự trong [BehaviorCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behaviorcollection/) là thứ tự lưu trữ của các thao tác trong một hiệu ứng. Nó không phải là một danh sách phát mà mỗi hành vi tự động chờ hành vi trước. Thời gian và hiệu ứng bao quanh quyết định lịch trình. Các hành vi có thể chồng lên nhau, và các thao tác trên cùng một thuộc tính có thể tương tác thông qua [getAdditive](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behavior/#getAdditive) và [getAccumulate](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behavior/#getAccumulate). Không nên chỉ dùng việc sắp lại bộ sưu tập để lên lịch “di chuyển, rồi quay”; hãy dùng thời gian rõ ràng hoặc tách thành các hiệu ứng riêng như mô tả trong [Hoạt ảnh Hình dạng](/slides/vi/nodejs-java/shape-animation/).

[getType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#getType) và [getSubtype](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#getSubtype) của hiệu ứng mô tả preset. Chúng không phải là mô tả đầy đủ của một cây hành vi đã chỉnh sửa. Hãy chọn preset và subtype trước khi tùy chỉnh các hành vi: việc thay đổi preset có thể xây dựng lại bộ sưu tập và xóa bỏ các thao tác tùy chỉnh của bạn. Ví dụ, đổi một hiệu ứng Spin đã tùy chỉnh sang Fade có thể thay thế hành vi xoay bằng các hành vi set và filter. Kiểm tra lại bộ sưu tập sau khi thay đổi preset hoặc subtype. Xóa các hành vi preset cũng có thể loại bỏ các thao tác hiển thị hoặc khởi tạo mà preset cần. Các ví dụ ở đây cố ý sử dụng các hình hiển thị và thay thế các hành vi; chúng không tái tạo toàn bộ cách preset được triển khai.

## **Tương thích Định dạng**

Một cây hành vi được bảo toàn không đảm bảo việc phát lại giống hệt trong mọi trình xem hoặc bộ xuất bản. Hãy kiểm tra dữ liệu đã lưu và đầu ra được render một cách riêng biệt.

| Định dạng hoặc đầu ra | Những gì cần kiểm tra |
| --- | --- |
| PPTX | Dùng làm định dạng chính cho các ví dụ này. Mở lại để xác minh cây hành vi có thể chỉnh sửa, sau đó kiểm tra phát lại trong phiên bản PowerPoint mục tiêu. |
| PPT | Đại diện nhị phân cũ có thể khác so với PPTX. Thử một chu trình lưu‑mở‑phát lại riêng và kiểm tra phát lại; đừng suy ra hỗ trợ cho mọi kết hợp tùy chỉnh chỉ dựa trên kết quả PPTX thành công. |
| PDF, PNG, JPEG và các hình ảnh slide tĩnh khác | Chứa một hình ảnh slide tĩnh, không phải một dòng thời gian hành vi có thể phát hoặc một khung ảnh hoạt ảnh cuối cùng được đảm bảo. |
| [HTML5](/slides/vi/nodejs-java/export-to-html5/) | Có thể phát các hoạt ảnh được hỗ trợ khi bật tùy chọn hoạt ảnh hình dạng trong quá trình xuất. Kiểm tra các kết hợp tùy chỉnh trong trình duyệt. |
| [Animated GIF](/slides/vi/nodejs-java/convert-powerpoint-to-animated-gif/) | Lưu các khung đã render, không phải các hành vi có thể chỉnh sửa hay tương tác khi nhấp. Kiểm tra chuyển động thực tế đã render. |
| [Video](/slides/vi/nodejs-java/convert-powerpoint-to-video/) | Render các khung hoạt ảnh và mã hoá chúng thành video. Hỗ trợ bị giới hạn bởi danh sách [các hoạt ảnh và hiệu ứng được hỗ trợ](/slides/vi/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) của bộ render; các lệnh và sự kiện tương tác không trở thành một dòng thời gian có thể chỉnh sửa. |

## **Câu hỏi thường gặp**

**Tại sao hiệu ứng của tôi lại chứa các hành vi ngay cả khi tôi chưa thêm gì?**

Tạo một hiệu ứng preset có thể tạo ra các thao tác nền tảng của nó. Kiểm tra chúng trước khi quyết định mở rộng preset hoặc thay thế các hành vi.

**Việc di chuyển một hành vi lên đầu có làm nó phát trước không?**

Không nhất thiết. Thứ tự trong bộ sưu tập không thay thế cho thời gian. Kiểm tra độ trễ, thời lượng và tương tác giữa các thao tác trên cùng một thuộc tính.

**Tại sao lệnh end không có điểm?**

Nó đánh dấu kết thúc đường và không cần tọa độ. Kiểm tra mảng điểm null khi kiểm tra một đường được đọc từ tệp.

**Một vòng quay thành công có đủ để xác nhận phát lại không?**

Không. Mở lại chỉ xác nhận việc bảo tồn các thuộc tính bạn đã kiểm tra. Hãy thử trình chiếu hoặc xuất bản động riêng để xác nhận hành vi hình ảnh thực tế.