---
title: Áp dụng Hoạt ảnh Hình dạng trong Bản trình bày bằng PHP
linktitle: Hoạt ảnh Hình dạng
type: docs
weight: 60
url: /vi/php-java/shape-animation/
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
- PHP
- Aspose.Slides
description: "Tìm hiểu cách thêm, kiểm tra và tùy chỉnh hoạt ảnh hình dạng, thời gian, âm thanh, hành vi sau hoạt ảnh và văn bản hoạt ảnh với Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Để làm việc với các hành vi riêng lẻ bên trong một hiệu ứng hoặc chỉnh sửa các đoạn đường chuyển động, xem [Hoạt ảnh tùy chỉnh](/slides/vi/php-java/custom-animation/).

Aspose.Slides cho PHP qua Java biểu diễn các hoạt ảnh slide dưới dạng các hiệu ứng trong một dòng thời gian slide. Một hiệu ứng có hình dạng mục tiêu, loại và phụ loại hoạt ảnh, một trình kích hoạt, các cài đặt thời gian, và các thuộc tính tùy chọn như âm thanh hoặc hành vi sau khi hoạt ảnh kết thúc.

Dòng thời gian chứa hai loại trình tự:

- **Trình tự chính** chạy khi slide tiến lên.
- **Trình tự tương tác** bắt đầu khi hình dạng trình kích hoạt của nó được nhấp.

Vì các hộp văn bản, hình ảnh, biểu đồ, bảng và các đối tượng slide khác là các hình dạng, bạn sử dụng cùng một phương thức [Sequence::addEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sequence/addeffect/) cho hầu hết nội dung slide. Các hiệu ứng khả dụng được liệt kê trong lớp [EffectType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effecttype/).

## **Thêm Hoạt ảnh Cho Hình Dạng**

Để thêm một hoạt ảnh, lấy trình tự chính của slide và gọi [Sequence::addEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sequence/addeffect/) với hình dạng mục tiêu, loại hiệu ứng, phụ loại và trình kích hoạt. Đối với một hiệu ứng bắt đầu khi một hình dạng khác được nhấp, tạo một trình tự tương tác mà trình kích hoạt là hình dạng khác đó.

Ví dụ sau tạo cả hai loại hoạt ảnh và lưu kết quả thành `shape-animations.pptx`.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Click to animate this shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $entranceEffect = $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $entranceEffect->getTiming()->setDuration(1.5);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $presentation->save("shape-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Trình kích hoạt điều khiển khi nào một hiệu ứng bắt đầu:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effecttriggertype/) chờ một cú nhấp trong trình tự chính, hoặc chờ một cú nhấp trên hình dạng trình kích hoạt trong một trình tự tương tác.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effecttriggertype/) bắt đầu cùng với hiệu ứng trước đó.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effecttriggertype/) bắt đầu khi hiệu ứng trước hoàn thành.

Để hoạt ảnh một hình ảnh, biểu đồ hoặc loại hình dạng khác, truyền đối tượng đó vào [Sequence::addEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sequence/addeffect/) thay vì `$targetShape`. Đối với các tùy chọn nhóm riêng cho biểu đồ, xem [Biểu đồ hoạt ảnh](/slides/vi/php-java/animated-charts/).

## **Đọc Hoạt ảnh Hình Dạng**

Sử dụng [Sequence::getEffectsByShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sequence/geteffectsbyshape/) khi bạn biết hình dạng mục tiêu. Để kiểm tra mọi hiệu ứng, duyệt trình tự chính và mọi trình tự tương tác. Việc duyệt giúp tránh giả định rằng một trình tự chứa hiệu ứng ở chỉ mục `0`.

Ví dụ sau tạo một hình dạng có hiệu ứng trong trình tự chính và trình tự tương tác, lấy các hiệu ứng nhắm vào hình dạng đó, và sau đó duyệt mọi trình tự trên slide.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function printSequence($label, $sequence)
{
    $effectCount = java_values($sequence->getCount());

    echo "  " . $label . ": " . $effectCount . " effect(s)" . PHP_EOL;

    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $targetShape = $effect->getTargetShape();
        $targetName = java_is_null($targetShape) ? "unknown" : java_values($targetShape->getName());
        $effectType = java_values($effect->getType());
        $effectSubtype = java_values($effect->getSubtype());
        $triggerType = java_values($effect->getTiming()->getTriggerType());
        echo "    type: " . $effectType . "; subtype: " . $effectSubtype . "; target: " . $targetName . "; trigger: " . $triggerType . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Animated shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $targetEffects = $mainSequence->getEffectsByShape($targetShape);
    $Array = new JavaClass("java.lang.reflect.Array");
    echo "The main sequence contains " . java_values($Array->getLength($targetEffects)) . " effect(s) for " . java_values($targetShape->getName()) . "." . PHP_EOL;

    printSequence("Main sequence", $mainSequence);

    $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
    $interactiveCount = java_values($interactiveSequences->getCount());
    for ($interactiveIndex = 0; $interactiveIndex < $interactiveCount; $interactiveIndex++) {
        $sequence = $interactiveSequences->get_Item($interactiveIndex);
        $sequenceTrigger = $sequence->getTriggerShape();
        $triggerName = java_is_null($sequenceTrigger) ? "unknown" : java_values($sequenceTrigger->getName());
        printSequence("Interactive sequence " . ($interactiveIndex + 1) . ", trigger: " . $triggerName, $sequence);
    }
} finally {
    $presentation->dispose();
}
```

Nếu bạn chỉ cần các hiệu ứng cho một hình dạng, trước tiên xác định hình dạng bằng tên, kiểu placeholder hoặc một thuộc tính ổn định khác; sau đó gọi [Sequence::getEffectsByShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sequence/geteffectsbyshape/). Đừng cho rằng [ShapeCollection::get_Item](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/get_item/) ở chỉ mục `0` luôn là đối tượng mong muốn.

## **Làm việc với Hiệu Ứng Placeholder Kế Thừa**

Một placeholder trên slide bình thường có thể kế thừa hành vi hoạt ảnh từ placeholder tương ứng trên slide bố cục và slide chủ. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getbaseplaceholder/) trả về placeholder cha đó, hoặc `null` nếu không có cha.

Trong bản trình bày ví dụ dưới đây, phần chân trang có **Random Bars** trên slide bình thường, **Split** trên slide bố cục, và **Fly In** trên slide chủ.

![Hiệu ứng hoạt ảnh chân trang trên slide bình thường](slide-shape-animation.png)

![Hiệu ứng hoạt ảnh placeholder chân trang trên slide bố cục](layout-shape-animation.png)

![Hiệu ứng hoạt ảnh placeholder chân trang trên slide chủ](master-shape-animation.png)

Ví dụ tiếp theo sử dụng một cấu trúc placeholder từ một bản trình bày mới. Nó thêm hiệu ứng vào một placeholder chủ, một placeholder bố cục, và placeholder tương ứng trên một slide bình thường. Mọi lần gọi [Shape::getBasePlaceholder](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getbaseplaceholder/) đều được kiểm tra trước khi hình dạng trả về được sử dụng.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

function findLayoutPlaceholderWithBase($layoutSlide)
{
    $shapes = $layoutSlide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_is_null($shape->getBasePlaceholder())) {
            return $shape;
        }
    }

    return null;
}

function findSlidePlaceholderWithBase($slide, $expectedBase)
{
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $basePlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($basePlaceholder) && java_values($basePlaceholder->equals($expectedBase))) {
            return $shape;
        }
    }

    return null;
}

function printEffects($source, $effects)
{
    $Array = new JavaClass("java.lang.reflect.Array");
    echo $source . ": " . java_values($Array->getLength($effects)) . " effect(s)" . PHP_EOL;

    foreach ($effects as $effect) {
        echo "  type: " . java_values($effect->getType()) . "; subtype: " . java_values($effect->getSubtype()) . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);
    $layoutPlaceholder = findLayoutPlaceholderWithBase($layoutSlide);

    if ($layoutPlaceholder === null) {
        throw new RuntimeException("The layout slide does not contain a placeholder linked to its master slide.");
    }

    $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
    $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->addEffect($masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    $layoutSlide->getTimeline()->getMainSequence()->addEffect($layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

    $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $slidePlaceholder = findSlidePlaceholderWithBase($slide, $layoutPlaceholder);

    if ($slidePlaceholder === null) {
        throw new RuntimeException("The slide does not contain a placeholder linked to its layout slide.");
    }

    $slide->getTimeline()->getMainSequence()->addEffect($slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
    printEffects("Normal slide", $slide->getTimeline()->getMainSequence()->getEffectsByShape($slidePlaceholder));

    $baseLayoutPlaceholder = $slidePlaceholder->getBasePlaceholder();
    if (!java_is_null($baseLayoutPlaceholder)) {
        printEffects("Layout slide", $layoutSlide->getTimeline()->getMainSequence()->getEffectsByShape($baseLayoutPlaceholder));

        $baseMasterPlaceholder = $baseLayoutPlaceholder->getBasePlaceholder();
        if (!java_is_null($baseMasterPlaceholder)) {
            printEffects("Master slide", $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($baseMasterPlaceholder));
        }
    }

    $presentation->save("placeholder-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Thay đổi Thời gian Hoạt ảnh**

Hộp thoại **Timing** của PowerPoint ánh xạ tới các thuộc tính của [Timing](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/).

![Hộp thoại Timing của PowerPoint cho một hiệu ứng hoạt ảnh](shape-animation.png)

- **Start** ánh xạ tới [Timing::getTriggerType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/gettriggertype/).
- **Duration** ánh xạ tới [Timing::getDuration](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/getduration/), tính bằng giây.
- **Delay** ánh xạ tới [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/gettriggerdelaytime/), tính bằng giây.
- **Repeat** ánh xạ tới [Timing::getRepeatCount](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/getrepeatuntilnextclick/), hoặc [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Rewind when done playing** ánh xạ tới [Timing::getRewind](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/getrewind/).

Ví dụ độc lập này thêm một hiệu ứng, thay đổi thời gian của nó thông qua đối tượng trả về bởi [Sequence::addEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sequence/addeffect/), và lưu kết quả. Giữ tham chiếu tới [Effect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/) đã trả về giúp tránh việc lấy chỉ mục bộ sưu tập không cần thiết.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Timed animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    $effect->getTiming()->setDuration(2.0);
    $effect->getTiming()->setTriggerDelayTime(0.5);
    $effect->getTiming()->setRepeatUntilNextClick(false);
    $effect->getTiming()->setRepeatUntilEndSlide(false);
    $effect->getTiming()->setRepeatCount(2.0);
    $effect->getTiming()->setRewind(true);

    $presentation->save("shape-animation-timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sử dụng một chế độ lặp lại duy nhất. Kết hợp số lần lặp lại với cờ “until” có thể gây ra kết quả khó hiểu trên các trình xem khác nhau. Khi thay đổi chế độ lặp, đặt [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/setrepeatuntilnextclick/) và [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/setrepeatuntilendslide/) trước [Timing::setRepeatCount](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/setrepeatcount/), vì việc đặt bất kỳ cờ nào cũng sẽ thay đổi chế độ lặp hiện tại.

## **Thêm và Trích xuất Âm thanh Hoạt ảnh**

Một hiệu ứng hoạt ảnh có thể tham chiếu âm thanh nhúng thông qua [Effect::getSound](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/getsound/). [Effect::setStopPreviousSound](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/setstopprevioussound/) chỉ định một hiệu ứng dừng âm thanh đã được bắt đầu bởi hiệu ứng trước đó.

### **Thêm Âm thanh vào Hiệu ứng**

Ví dụ sau giả định có một tệp âm thanh cục bộ tên `animation-sound.wav`. Nó tạo hai hiệu ứng, nhúng tệp đó làm âm thanh cho hiệu ứng đầu tiên, và cấu hình hiệu ứng thứ hai để dừng âm thanh. Nó sử dụng các đối tượng trả về bởi [Sequence::addEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sequence/addeffect/), vì vậy không cần chỉ mục trình tự.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$Files = new JavaClass("java.nio.file.Files");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 100, 240, 80);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 400, 100, 240, 80);
    $firstShape->addTextFrame("Starts sound");
    $secondShape->addTextFrame("Stops sound");

    $sequence = $slide->getTimeline()->getMainSequence();
    $firstEffect = $sequence->addEffect($firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $secondEffect = $sequence->addEffect($secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $baseDirectory = getcwd();
    $audioPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "animation-sound.wav"))->toPath();
    $audioData = $Files->readAllBytes($audioPath);
    $effectSound = $presentation->getAudios()->addAudio($audioData);
    $firstEffect->setSound($effectSound);
    $secondEffect->setStopPreviousSound(true);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "shape-animation-sound.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Trích xuất Âm thanh Hiệu ứng Nhúng**

Ví dụ sau giả định có một bản trình bày cục bộ tên `presentation-with-animation-sounds.pptx`. Nó quét cả trình tự chính và trình tự tương tác và ghi mỗi âm thanh hiệu ứng nhúng vào thư mục `extracted-animation-sounds`. Đuôi tệp được chọn dựa trên loại MIME âm thanh mà [Audio::getContentType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audio/getcontenttype/) cung cấp.

```php
use aspose\slides\Presentation;

function getAudioExtension($contentType)
{
    $normalizedType = strtolower($contentType === null ? "" : java_values($contentType));

    if ($normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if ($normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if ($normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if ($normalizedType === "audio/wav" || $normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds($sequence, $outputDirectory, $soundIndex)
{
    $effectCount = java_values($sequence->getCount());
    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $sound = $effect->getSound();
        if (java_is_null($sound)) {
            continue;
        }

        $extension = getAudioExtension($sound->getContentType());
        $outputPath = $outputDirectory->resolve("effect-sound-" . $soundIndex . $extension);
        $outputStream = new Java("java.io.FileOutputStream", $outputPath->toFile());
        try {
            $outputStream->write($sound->getBinaryData());
        } finally {
            $outputStream->close();
        }
        $soundIndex++;
    }

    return $soundIndex;
}

$baseDirectory = getcwd();
$inputPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "presentation-with-animation-sounds.pptx"))->toPath();
$outputDirectoryName = $baseDirectory . DIRECTORY_SEPARATOR . "extracted-animation-sounds";
if (!is_dir($outputDirectoryName)) {
    mkdir($outputDirectoryName, 0777, true);
}
$outputDirectory = (new Java("java.io.File", $outputDirectoryName))->toPath();

$presentation = new Presentation($inputPath->toString());
try {
    $soundIndex = 1;

    $slides = $presentation->getSlides();
    $slideCount = java_values($slides->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $slides->get_Item($slideIndex);
        $soundIndex = saveSounds($slide->getTimeline()->getMainSequence(), $outputDirectory, $soundIndex);

        $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
        $interactiveCount = java_values($interactiveSequences->getCount());
        for ($sequenceIndex = 0; $sequenceIndex < $interactiveCount; $sequenceIndex++) {
            $sequence = $interactiveSequences->get_Item($sequenceIndex);
            $soundIndex = saveSounds($sequence, $outputDirectory, $soundIndex);
        }
    }

    echo "Extracted " . ($soundIndex - 1) . " sound file(s) to " . java_values($outputDirectory->toAbsolutePath()->toString()) . "." . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Đối với các đối tượng âm thanh lớn, sử dụng [Audio::getStream](https://reference.aspose.com/slides/vi/php-java/aspose.slides/audio/getstream/) và sao chép luồng vào tệp thay vì tải toàn bộ đối tượng vào một mảng byte.

## **Đặt Hành vi Sau Hoạt ảnh**

Tùy chọn **After animation** kiểm soát những gì xảy ra với một hình dạng sau khi hiệu ứng của nó kết thúc.

![Hộp thoại Tùy chọn Hiệu ứng PowerPoint hiển thị cài đặt After animation](shape-after-animation.png)

Lớp [AfterAnimationType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/afteranimationtype/) hỗ trợ để lại hình dạng nguyên trạng, thay đổi màu, ẩn nó sau hoạt ảnh, hoặc ẩn nó khi nhấp lần tiếp theo. Khi kiểu là [AfterAnimationType::Color](https://reference.aspose.com/slides/vi/php-java/aspose.slides/afteranimationtype/), cũng cần đặt [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/getafteranimationcolor/).

Ví dụ độc lập này tạo một hiệu ứng, đặt hành vi sau hoạt ảnh thông qua đối tượng hiệu ứng trả về, và lưu kết quả.

```php
use aspose\slides\AfterAnimationType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Dim after animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->setAfterAnimationType(AfterAnimationType::Color);
    $effect->getAfterAnimationColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("shape-animation-after-effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Thay đổi kiểu khỏi [AfterAnimationType::Color](https://reference.aspose.com/slides/vi/php-java/aspose.slides/afteranimationtype/) sẽ xóa cài đặt màu after‑animation.

## **Hoạt ảnh Văn bản**

Hoạt ảnh văn bản có hai điều khiển liên quan:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textanimation/getbuildtype/) kiểm soát việc các đoạn văn xuất hiện cùng nhau hay theo cấp đoạn.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/getanimatetexttype/) kiểm soát việc văn bản xuất hiện một lúc, theo từ, hoặc theo ký tự. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/getdelaybetweentextparts/) thiết lập độ trễ giữa các từ hoặc ký tự. Giá trị dương là phần trăm của thời lượng hiệu ứng; giá trị âm là độ trễ tính bằng giây.

Ví dụ độc lập sau hoạt ảnh các từ trong một hộp văn bản. [BuildType::AsOneObject](https://reference.aspose.com/slides/vi/php-java/aspose.slides/buildtype/) tắt việc xây dựng đoạn theo đoạn để cài đặt từ áp dụng cho toàn bộ khung văn bản.

```php
use aspose\slides\AnimateTextType;
use aspose\slides\BuildType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 560, 100);
    $textBox->addTextFrame("Aspose.Slides animates this sentence word by word.");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    $effect->setAnimateTextType(AnimateTextType::ByWord);
    $effect->setDelayBetweenTextParts(20.0);

    $presentation->save("animated-text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Để xây dựng một hộp văn bản theo đoạn, đặt [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/vi/php-java/aspose.slides/buildtype/) (hoặc một cấp độ đoạn khác). Để nhắm mục tiêu một đoạn riêng lẻ với hiệu ứng của nó, sử dụng phương thức overload của [Sequence::addEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sequence/addeffect/) chấp nhận một [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/). Xem [Văn bản hoạt ảnh](/slides/vi/php-java/animated-text/) để biết các ví dụ ở cấp độ đoạn.

## **Xuất và Ghi chú Tương thích**

- Lưu dưới dạng PPT hoặc PPTX giữ nguyên mô hình hoạt ảnh, nhưng việc phát lại cuối cùng do trình xem bản trình bày điều khiển.
- PDF và hình ảnh tĩnh không phát hoạt ảnh. Sử dụng [xuất HTML5](/slides/vi/php-java/export-to-html5/), GIF hoạt ảnh, hoặc [chuyển đổi video](/slides/vi/php-java/convert-powerpoint-to-video/) khi đầu ra phải hiển thị chuyển động.
- Đối với HTML5, bật [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/html5options/setanimateshapes/) và, khi cần, [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/html5options/setanimatetransitions/).
- Kết xuất video hỗ trợ nhiều hiệu ứng vào, nhấn mạnh, thoát và đường chuyển động thông thường, nhưng không phải mọi hiệu ứng PowerPoint đều được hỗ trợ. Kiểm tra bảng [các hoạt ảnh và hiệu ứng được hỗ trợ](/slides/vi/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) hiện tại và thử nghiệm các bản trình bày quan trọng với phiên bản Aspose.Slides mục tiêu của bạn.
- Các hiệu ứng tùy chỉnh nâng cao và các hiệu ứng được nhập từ định dạng bản trình bày khác có thể được giữ trong tệp nhưng hiển thị khác nhau trong PowerPoint, HTML5 hoặc video. Xác thực kết quả xuất thay vì chỉ dựa vào tên hiệu ứng.

## **Câu hỏi thường gặp**

**Tại sao một hoạt ảnh xuất hiện trong PowerPoint nhưng không có trong PDF?**

PDF là định dạng tĩnh, vì vậy hoạt ảnh và chuyển đổi slide không được phát. Xuất sang HTML5, GIF hoạt ảnh, hoặc video khi cần giữ chuyển động.

**Tại sao một hiệu ứng chạy khác nhau trong video?**

Xuất video render hoạt ảnh thay vì lưu hành vi PowerPoint gốc. Một số hiệu ứng nâng cao không được hỗ trợ hoặc chỉ được mô phỏng. Kiểm tra bảng hiệu ứng được hỗ trợ và thử nghiệm bản trình bày thực tế trước khi dùng trong sản xuất.

**Di chuyển một hình dạng lên trước hoặc xuống sau có thay đổi thứ tự hoạt ảnh không?**

Không. thứ tự z‑order của hình dạng chỉ điều khiển lớp phủ, trong khi thứ tự trình tự và trình kích hoạt điều khiển việc phát hoạt ảnh. Thay đổi dòng thời gian nếu bạn cần một thứ tự phát khác.