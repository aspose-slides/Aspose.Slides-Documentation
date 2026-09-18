---
title: Tạo và Sửa đổi Các Hành vi Hoạt ảnh Tùy chỉnh trong PHP
linktitle: Hoạt ảnh Tùy chỉnh
type: docs
weight: 151
url: /vi/php-java/custom-animation/
keywords:
- hoạt ảnh tùy chỉnh
- hành vi hoạt ảnh
- đường chuyển động
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tạo, kiểm tra và sửa đổi các hành vi hoạt ảnh tùy chỉnh cũng như các đường chuyển động có thể chỉnh sửa trong bản trình bày PowerPoint bằng Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Hành vi hoạt ảnh tùy chỉnh cho phép bạn kiểm soát các thao tác cá nhân trong một hiệu ứng hoạt ảnh, chẳng hạn như thay đổi màu, xoay hình dạng hoặc theo một đường chuyển động có thể chỉnh sửa. Hướng dẫn này cho thấy cách tạo và kết hợp các hành vi, cấu hình thời gian của chúng, kiểm tra và sửa đổi các hoạt ảnh hiện có, và xác minh rằng các thuộc tính của chúng vẫn tồn tại sau khi lưu và mở lại một bản trình bày.

Đối với các hiệu ứng định trước và kích hoạt click, xem [Hoạt ảnh Hình dạng](/slides/vi/php-java/shape-animation/).

## **Hiểu mô hình hoạt ảnh**

Một hoạt ảnh được tổ chức dưới dạng **Timeline → Sequence → Effect → Behaviors**:

- Mỗi slide có một timeline chứa chuỗi chính và các chuỗi tương tác.
- Một [Sequence](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sequence/) chứa các hiệu ứng, có thể nhắm mục tiêu các hình dạng khác nhau.
- Một [Effect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/) xác định hình dạng mục tiêu, preset, subtype và thời gian hiệu ứng.
- Bộ sưu tập trả về bởi [Effect::getBehaviors](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/getbehaviors/) chứa các thao tác thực thi hiệu ứng: thay đổi màu, di chuyển, xoay, đặt thuộc tính, v.v.

## **Tạo các hành vi riêng lẻ**

Gọi [Sequence::addEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sequence/addeffect/) để tạo một hiệu ứng và truy cập bộ sưu tập [getBehaviors](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/getbehaviors/). Một preset có thể tự động điền bộ sưu tập này. Giữ các thao tác của nó khi mở rộng preset, hoặc dùng [clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorcollection/clear/) khi bạn muốn thay thế chúng một cách cố ý.

[BehaviorFactory](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorfactory/) tạo tám loại hành vi được minh họa bên dưới. Động chuyển được đề cập trong [Xây dựng Đường chuyển động](#build-a-motion-path). Mỗi đoạn mã bao gồm các import và giả định rằng PHP/Java Bridge và thư viện Aspose.Slides PHP đã được nạp. Các ví dụ chỉnh sửa sau này chỉ ra tệp đầu ra nào được sử dụng.

### **Xoay**

Dùng [createRotationEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorfactory/createrotationeffect/) để tạo một xoay. [getBy](https://reference.aspose.com/slides/vi/php-java/aspose.slides/rotationeffect/getby/) xác định góc tương đối tính bằng độ; [getFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/rotationeffect/getfrom/) và [getTo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/rotationeffect/getto/) xác định các điểm cuối.

Ví dụ bắt đầu bằng hiệu ứng Spin, thay thế các thao tác preset của nó bằng một hành vi xoay, và đặt thời lượng cho thao tác này là hai giây. Góc tương đối 90 độ biểu thị một vòng tư từ hướng ban đầu của hình dạng, vì vậy không cần chỉ định góc bắt đầu cụ thể.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` chứa một hình và một hành vi xoay. Bộ sưu tập, thời gian và các ví dụ chỉnh sửa xoay dưới đây sử dụng tệp này.

### **Thu phóng**

Dùng [createScaleEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorfactory/createscaleeffect/) với phần trăm X/Y: [getFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/scaleeffect/getfrom/) và [getTo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/scaleeffect/getto/) mô tả kích thước bắt đầu và kết thúc, trong khi [getBy](https://reference.aspose.com/slides/vi/php-java/aspose.slides/scaleeffect/getby/) mô tả thay đổi tương đối. Ở đây, 100 có nghĩa là kích thước gốc.

Ví dụ tăng cả hai chiều từ 100% lên 125% trong hai giây. Sử dụng cùng một phần trăm chiều ngang và chiều dọc giữ tỷ lệ hình dạng; các phần trăm khác nhau sẽ kéo giãn một chiều hơn chiều còn lại.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Màu sắc**

Dùng [createColorEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorfactory/createcoloreffect/) để thay đổi màu nền từ xanh dương sang cam. [getFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/coloreffect/getfrom/) và [getTo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/coloreffect/getto/) là các màu; [getBy](https://reference.aspose.com/slides/vi/php-java/aspose.slides/coloreffect/getby/) là một độ lệch màu. [BehaviorPropertyCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorpropertycollection/) của hành vi xác định thuộc tính đang được hoạt ảnh.

Nền đặc của hình được khởi tạo thành màu xanh dương, khớp với màu bắt đầu của hoạt ảnh. Việc chọn thuộc tính màu nền cho biết hành vi phần nào của hình sẽ thay đổi; các điểm cuối màu chỉ không xác định thuộc tính đó. Hiệu ứng đã lưu mô tả một chuyển đổi hai giây sang màu cam.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Bộ lọc**

Dùng [createFilterEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorfactory/createfiltereffect/) để chọn một loại wipe. [getType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filtereffect/getsubtype/), và [getReveal](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filtereffect/getreveal/) xác định bộ lọc, hướng và việc hiển thị hay ẩn hình.

Ví dụ này cấu hình một wipe hai giây hiển thị hình bằng subtype hướng phải. Cài đặt bộ lọc thuộc về hành vi bên trong hiệu ứng, vì vậy chúng được cấu hình sau khi các thao tác gốc của preset đã bị loại bỏ.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Thuộc tính**

Dùng [createPropertyEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) để hoạt ảnh độ trong suốt. [getFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/propertyeffect/getto/), và [getBy](https://reference.aspose.com/slides/vi/php-java/aspose.slides/propertyeffect/getby/) là các chuỗi được diễn giải bằng [getValueType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/propertyeffect/getvaluetype/) và [getCalcMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/propertyeffect/getcalcmode/). Chọn các điểm cuối hoặc một độ lệch tương đối thay vì đặt cả ba một cách tùy tiện.

Ở đây, thuộc tính được chọn là opacity, và các chuỗi số biểu thị sự thay đổi từ 25% độ trong suốt lên độ trong suốt đầy đủ. Nội suy tuyến tính mô tả sự thay đổi dần dần giữa các giá trị này. Khi áp dụng ví dụ này cho thuộc tính khác, hãy chọn kiểu giá trị và các giá trị điểm cuối phù hợp với thuộc tính đó.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Đặt**

Dùng [createSetEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorfactory/createseteffect/) để gán tính khả dụng thông qua [getTo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/seteffect/getto/). Một hành vi đặt không nội suy giữa các điểm cuối.

Ví dụ chọn thuộc tính visibility và gán chuỗi `visible` khi hành vi chạy. Hình chữ nhật đã hiển thị trong bản trình bày tối thiểu này, vì vậy việc gán có thể không tạo ra thay đổi hình ảnh rõ ràng. Một thao tác như vậy hữu ích khi là một phần của hiệu ứng lớn hơn cũng kiểm soát thời điểm hình ẩn hoặc hiện.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Lệnh**

Dùng [createCommandEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorfactory/createcommandeffect/) và cấu hình [getType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commandeffect/getcommandstring/), và [getShapeTarget](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commandeffect/getshapetarget/). Đặt một bản ghi âm WAV có tên `sample.wav` trong thư mục làm việc. Ví dụ này nhúng nó bằng [addAudioFrameEmbedded](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addaudioframeembedded/) và gắn một lệnh phát vào khung âm thanh.

Khung âm thanh vừa là mục tiêu của hiệu ứng vừa là mục tiêu của lệnh. Điều này kết nối yêu cầu phát với bản ghi âm đã nhúng; một chuỗi lệnh tự thân không xác định đối tượng truyền thông nào sẽ được điều khiển. Hiệu ứng được cấu hình để bắt đầu khi click trong khi trình chiếu.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Lưu trữ lưu lệnh trong `command.pptx`; nó không phát bản ghi. Phát lại yêu cầu một trình chiếu hỗ trợ lệnh và mục tiêu truyền thông của nó.

## **Quản lý Bộ sưu tập Hành vi**

[BehaviorCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorcollection/) hỗ trợ [add](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorcollection/remove/), và [removeAt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorcollection/removeat/). Ví dụ này mở `rotation.pptx`, thêm thu phóng, di chuyển nó trước khi xoay, và loại bỏ hành vi xoay. Việc loại bỏ và chèn lại cùng một đối tượng thay đổi vị trí lưu trữ của nó mà không tạo bản sao.

Chuỗi chỉnh sửa thay đổi bộ sưu tập từ rotation–scale sang scale–rotation, rồi sang chỉ scale. Các chỉ mục đề cập đến bộ sưu tập hiện tại, vì vậy việc loại bỏ dùng chỉ mục mới của hành vi xoay sau khi sắp lại. Đếm cuối cùng xác nhận hành vi nào sẽ được lưu.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả là `ScaleEffect`: chỉ còn thu phóng. Thứ tự trong bộ sưu tập không tự động lên lịch các hành vi liên tiếp. Xóa toàn bộ bộ sưu tập chỉ khi bạn muốn thay thế mọi thao tác.

## **Cấu hình Thời gian Hành vi**

Một hành vi có [Timing](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/) riêng, độc lập với thời gian trả về bởi [Effect::getTiming](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/gettiming/). Thời gian hiệu ứng lên lịch cho toàn bộ hiệu ứng; thời gian hành vi mô tả một thao tác bên trong nó.

### **Đặt Thời lượng, Độ trễ, Lặp lại và Tăng tốc**

Mở `rotation.pptx` và đặt thời lượng ([getDuration](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/getduration/)) và độ trễ kích hoạt ([getTriggerDelayTime](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/gettriggerdelaytime/)) tính bằng giây, sau đó cấu hình số lần lặp qua [setRepeatCount](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/getaccelerate/) và [getDecelerate](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/getdecelerate/) là các phần của thời lượng; giữ tổng của chúng không vượt quá 1.

Tệp đầu vào là tệp được tạo trong ví dụ xoay, trong đó hành vi đầu tiên biết là một xoay. Ví dụ này chỉ thay đổi thời gian của hành vi đó; góc 90 độ vẫn giữ nguyên. Tách góc và thời gian giúp dễ điều chỉnh tốc độ mà không cần xây dựng lại hoạt ảnh.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hành vi này dùng thời lượng hai giây, độ trễ nửa giây, và số lần lặp 3. 20% đầu và 20% cuối của thời lượng được dùng cho tăng tốc và giảm tốc.

Các chính sách lặp khác bao gồm [getRepeatDuration](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/getrepeatuntilendslide/), và [getRepeatUntilNextClick](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/getrepeatuntilnextclick/); chọn một chính sách thay vì bật chúng đồng thời. [getAutoReverse](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/getautoreverse/) phát lại hoạt ảnh ngược lại sau lần chạy xuôi. Tăng tốc và giảm tốc áp dụng cho các thay đổi liên tục, không phải cho các gán rời rạc hay lệnh.

## **Xây dựng Đường chuyển động**

Dùng [createMotionEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorfactory/createmotioneffect/) để tạo chuyển động. Các phương thức [getFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motioneffect/getto/), và [getBy](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motioneffect/getby/) mô tả tọa độ hoặc độ lệch dựa trên phần trăm. Để có một tuyến đường có thể chỉnh sửa, tạo một [MotionPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motionpath/) và gán nó bằng [MotionEffect::setPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motioneffect/setpath/). [MotionPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motionpath/) lưu các lệnh đường.

[MotionCommandPathType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motioncommandpathtype/) chọn loại thao tác:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Đặt vị trí bắt đầu. |
| LineTo | One | Di chuyển theo đoạn thẳng tới điểm cuối. |
| CurveTo | Three | Theo một đường cong bậc ba được xác định bởi hai điểm điều khiển và một điểm cuối. |
| CloseLoop | None | Quay lại vị trí bắt đầu. |
| End | None | Kết thúc đường. |

[MotionPathPointsType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motionpathpointstype/) mô tả đặc tính chỉnh sửa điểm, chẳng hạn góc hoặc điểm mượt. Nó không thay thế loại lệnh. Dùng kiểu điểm curve cho ví dụ đường cong dưới đây, và kiểu điểm corner cho các đoạn thẳng.

Tọa độ đường được chuẩn hoá theo kích thước slide: một dịch chuyển X 0.25 đại diện cho một phần tư chiều rộng slide, không phải 0.25 điểm. Y dương chạy xuống phía dưới. Các lệnh tuyệt đối xác định vị trí trong hệ tọa độ đường; các lệnh tương đối xác định độ lệch so với vị trí hiện tại. Điều này tách biệt với [getOrigin](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motioneffect/getorigin/), lựa chọn khung tham chiếu của đường, và [getPathEditMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motioneffect/getpatheditmode/), kiểm soát cách đường di chuyển khi hình được di chuyển.

### **Tạo Đường Thẳng**

Tạo một hành vi chuyển động với điểm bắt đầu, một đoạn thẳng, và một lệnh kết thúc. [MotionPath::add](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motionpath/add/) nhận loại lệnh, các điểm của nó, kiểu điểm, và cờ tọa độ tương đối.

Lệnh bắt đầu thiết lập (0, 0), và đoạn thẳng kết thúc tại (0.25, 0), tạo dịch chuyển ngang bằng một phần tư chiều rộng slide. Lệnh kết thúc không có điểm tọa độ. Khi đường đã được gán, việc thêm hành vi chuyển động vào hiệu ứng sẽ nối tuyến đường này với hình chữ nhật.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` chứa một hành vi chuyển động với ba lệnh đường. Các ví dụ chỉnh sửa tệp phía dưới sử dụng cấu trúc đã biết này.

### **So sánh Tọa độ Tuyệt đối và Tương đối**

Hai đối tượng đường này mô tả cùng một tuyến đường. Lệnh tuyệt đối kết thúc tại (0.3, 0.1); lệnh tương đối cộng thêm (0.1, 0.1) vào vị trí hiện tại, (0.2, 0).

Cả hai đường đều bắt đầu tại cùng một vị trí. Đối với đoạn thẳng tương đối, cộng các độ lệch X và Y vào vị trí hiện tại để có điểm cuối; đối với đoạn thẳng tuyệt đối, đọc điểm cuối trực tiếp. Thay đổi cờ mà không chuyển đổi tọa độ sẽ mô tả một tuyến đường khác.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

Gán bất kỳ đường nào cho một hành vi chuyển động để sử dụng trong bản trình bày. Tham số Boolean cuối cùng chọn tọa độ tương đối cho lệnh đó.

### **Thay Thế Đoạn Thẳng Bằng Đường Cong**

Mở `motion.pptx` và thay thế lệnh line bằng một đường cong bậc ba. Đầu tiên cung cấp hai điểm điều khiển, sau đó cung cấp điểm cuối.

Vị trí bắt đầu được cung cấp bởi lệnh trước. Hai điểm đầu tiên tạo hình cong, trong khi điểm thứ ba là đích đến; chúng không phải là ba đích liên tiếp. Cập nhật đồng thời loại lệnh, kiểu chỉnh sửa điểm và mảng điểm giữ cho đoạn duy trì tính nhất quán với hình học mới.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Đường trong `curve.pptx` vẫn có ba lệnh; lệnh ở giữa giờ định nghĩa một đường cong.

## **Kiểm tra và Chỉnh sửa Đường đã Lưu**

Mỗi [MotionCmdPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motioncmdpath/) cung cấp [getPoints](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motioncmdpath/getpointstype/), và [isRelative](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motioncmdpath/isrelative/). Các ví dụ sau dùng đường ba lệnh đã biết trong `motion.pptx`. Đối với đầu vào tùy ý, xác định hiệu ứng mong muốn và kiểm tra loại lệnh và số lượng điểm trước khi chỉnh sửa theo chỉ mục.

### **Đọc Lệnh và Tọa độ**

Đọc đường mà không thay đổi nó. Các lệnh End và CloseLoop không cần điểm, vì vậy cho phép mảng điểm null.

Kết quả ghép mỗi loại lệnh số với cờ tọa độ tương đối trước khi liệt kê các điểm. Điều này giúp bạn phân biệt một điểm cuối với một độ lệch trước khi sửa đổi đường. Một đường cong sẽ liệt kê ba điểm, trong khi đường thẳng trong tệp này chỉ liệt kê một điểm.

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Danh sách chứa một điểm bắt đầu, một đoạn line tuyệt đối kết thúc tại (0.25, 0), và một lệnh End.

### **Thay Đổi Điểm Cuối**

Mở `motion.pptx` và thay thế mảng điểm của line để di chuyển điểm cuối của nó.

Trong tệp đầu vào, chỉ mục 0 là lệnh bắt đầu và chỉ mục 1 là line. Thay thế điểm đơn của line thay đổi đích đến mà không thay đổi loại lệnh, thời gian hoặc vị trí trong bộ sưu tập. Vì lệnh sử dụng tọa độ tuyệt đối, cặp mới chỉ định một vị trí chứ không phải một độ lệch cộng thêm.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Đoạn line trong `motion-endpoint.pptx` kết thúc tại (0.4, 0.1); tệp gốc không thay đổi.

### **Thay Thế Đoạn**

Sử dụng [insert](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motionpath/insert/) và [removeAt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/motionpath/removeat/) để thay thế line trong `motion.pptx`. Việc chèn đẩy line cũ sang chỉ mục 2.

Điều này minh họa việc thay thế một đối tượng lệnh thay vì chỉnh sửa tọa độ hiện có. Sau khi chèn, bộ sưu tập tạm thời chứa lệnh bắt đầu, line mới, line cũ, và lệnh End. Loại bỏ chỉ mục 2 xoá line cũ và giữ lại tuyến đường mới.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Đường đã lưu vẫn có ba lệnh, với line mới kết thúc tại (0.2, 0.1) và lệnh End ở cuối.

## **Sửa đổi và Xác minh Hành vi Đã Có**

Khi không biết chỉ mục của hành vi, chọn nó theo loại. Ví dụ này mở `rotation.pptx`, tìm [RotationEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/rotationeffect/), thay đổi góc và kiểm tra giá trị đã lưu sau khi mở lại.

Kiểm tra loại cho phép vòng lặp bỏ qua các hành vi không phải xoay. Lần nạp thứ hai đọc tệp đã lưu vào một đối tượng bản trình bày riêng, vì vậy việc so sánh kiểm tra dữ liệu đã lưu thay vì giá trị vẫn còn trong bộ nhớ. Ví dụ này vẫn giả định hiệu ứng đã biết là thứ nhất trong chuỗi chính; việc chọn hành vi theo loại không xác định đúng hiệu ứng trong một bản trình bày tùy ý.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Kết quả là `Rotation preserved: true`. Áp dụng mẫu kiểm tra loại tương tự cho các hành vi khác. Để kiểm tra toàn diện, so sánh hình mục tiêu, hiệu ứng, loại và thứ tự hành vi, thời gian, và lệnh đường. Dùng độ sai số số cho các giá trị dấu chấm động. Đối với bản trình bày có bố cục hoạt ảnh không xác định, xem [Đọc Hoạt ảnh Hình dạng](/slides/vi/php-java/shape-animation/#read-shape-animations) để duyệt chuỗi chính và chuỗi tương tác.

## **Thứ tự Hành vi, Preset và Phát lại**

Thứ tự trong [BehaviorCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behaviorcollection/) là thứ tự lưu trữ các thao tác của một hiệu ứng. Nó không phải là một playlist mà mỗi hành vi tự động đợi hành vi trước. Thời gian và hiệu ứng bao quanh quyết định lịch trình. Các hành vi có thể chồng lên nhau, và các thao tác trên cùng một thuộc tính có thể tương tác thông qua cài đặt [additive](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behavioradditivetype/) và [accumulation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/behavioraccumulatetype/). Đừng chỉ dùng sắp xếp lại bộ sưu tập để lên lịch “di chuyển, rồi xoay”; hãy dùng thời gian rõ ràng hoặc các hiệu ứng riêng như mô tả trong [Hoạt ảnh Hình dạng](/slides/vi/php-java/shape-animation/).

[getType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/gettype/) và [getSubtype](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/getsubtype/) của hiệu ứng mô tả preset của nó. Chúng không phải là mô tả đầy đủ của cây hành vi đã chỉnh sửa. Chọn preset và subtype trước khi tùy chỉnh hành vi: việc thay đổi preset có thể xây dựng lại bộ sưu tập và loại bỏ các thao tác tùy chỉnh của bạn. Ví dụ, đổi một hiệu ứng Spin đã tùy chỉnh thành Fade có thể thay thế hành vi xoay bằng các hành vi set và filter. Kiểm tra lại bộ sưu tập sau khi thay đổi preset hoặc subtype. Xóa các hành vi preset cũng có thể loại bỏ các thao tác hiển thị hoặc khởi tạo mà preset cần. Các ví dụ cố ý sử dụng các hình hiển thị và thay thế hành vi; chúng không tái tạo toàn bộ thực thi của mỗi preset.

## **Tương thích Định dạng**

Cây hành vi được bảo tồn không đảm bảo phát lại giống hệt trong mọi trình xem hoặc bộ xuất. Kiểm tra dữ liệu đã lưu và đầu ra được render riêng biệt.

| Định dạng hoặc đầu ra | Cần kiểm tra |
| --- | --- |
| PPTX | Sử dụng làm định dạng chính cho các ví dụ này. Mở lại để xác nhận cây hành vi có thể chỉnh sửa, sau đó kiểm tra phát lại trong phiên bản PowerPoint mong muốn. |
| PPT | Đại diện nhị phân kế thừa có thể khác với PPTX. Thực hiện một chu trình lưu‑mở‑lại và kiểm tra phát lại; không suy ra hỗ trợ mọi tổ hợp tùy chỉnh chỉ từ kết quả PPTX thành công. |
| PDF, PNG, JPEG và các hình ảnh slide tĩnh khác | Chứa đại diện slide tĩnh, không phải một dòng thời gian hành vi có thể phát hoặc khung cuối cùng được đảm bảo. |
| [HTML5](/slides/vi/php-java/export-to-html5/) | Có thể phát các hoạt ảnh được hỗ trợ khi bật hoạt ảnh hình dạng trong tùy chọn xuất. Kiểm tra các tổ hợp tùy chỉnh trong trình duyệt. |
| [Animated GIF](/slides/vi/php-java/convert-powerpoint-to-animated-gif/) | Lưu các khung đã render, không phải các hành vi có thể chỉnh sửa hay tương tác click‑trigger. Kiểm tra chuyển động được render thực tế. |
| [Video](/slides/vi/php-java/convert-powerpoint-to-video/) | Render các khung hoạt ảnh và mã hoá chúng thành video. Hỗ trợ chỉ giới hạn ở các [hoạt ảnh và hiệu ứng được hỗ trợ](/slides/vi/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) của bộ render; các lệnh và sự kiện tương tác không trở thành một dòng thời gian có thể chỉnh sửa. |

## **Câu hỏi thường gặp**

**Tại sao hiệu ứng của tôi có các hành vi trước khi tôi thêm bất kỳ gì?**

Tạo một hiệu ứng định trước có thể tạo ra các thao tác nền tảng của nó. Kiểm tra chúng trước khi quyết định mở rộng preset hoặc thay thế các hành vi.

**Việc di chuyển một hành vi lên đầu có làm nó phát trước không?**

Không nhất thiết. Thứ tự trong bộ sưu tập không thay thế cho thời gian. Kiểm tra độ trễ, thời lượng và tương tác giữa các thao tác trên cùng một thuộc tính.

**Tại sao lệnh End không có điểm?**

Nó đánh dấu kết thúc đường và không cần tọa độ. Khi kiểm tra đường đọc từ tệp, hãy kiểm tra mảng điểm null.

**Liên kết vòng tròn thành công có đủ để xác nhận phát lại không?**

Không. Mở lại chỉ xác nhận các thuộc tính bạn đã kiểm tra được bảo tồn. Phải thử trình chiếu hoặc xuất hoạt ảnh riêng biệt để xác nhận hành vi hình ảnh.