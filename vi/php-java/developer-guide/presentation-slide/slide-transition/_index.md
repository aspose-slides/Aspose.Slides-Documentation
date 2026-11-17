---
title: Quản lý chuyển đổi slide trong các bài thuyết trình bằng PHP
linktitle: Chuyển đổi Slide
type: docs
weight: 80
url: /vi/php-java/slide-transition/
keywords:
- chuyển đổi slide
- thêm chuyển đổi slide
- áp dụng chuyển đổi slide
- chuyển đổi slide nâng cao
- chuyển đổi Morph
- loại chuyển đổi
- hiệu ứng chuyển đổi
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Áp dụng chuyển đổi slide, cấu hình chuyển tiếp slide tự động và tùy chỉnh Morph cùng các hiệu ứng chuyển đổi khác với Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Hiệu ứng chuyển đổi slide điều khiển cách các slide xuất hiện trong buổi trình chiếu. Với Aspose.Slides cho PHP thông qua Java, bạn có thể chọn một hiệu ứng chuyển đổi cho mỗi slide, cấu hình việc chuyển tiếp bằng nhấp chuột hoặc bộ hẹn giờ, và điều chỉnh các tùy chọn riêng cho một hiệu ứng. Bài viết này sử dụng các ví dụ PHP để áp dụng chuyển đổi, đặt thời lượng chuyển đổi chính xác, quản lý thời gian slide, và tạo chuyển đổi Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu các cài đặt vào tệp PPTX.

## **Thêm Chuyển Đổi Slide**

Để áp dụng một chuyển đổi, tải một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) và truy cập các cài đặt chuyển đổi của slide thông qua [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). Sử dụng [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) với một giá trị từ enumeration [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), sau đó lưu bản trình chiếu.

Ví dụ sau áp dụng chuyển đổi Circle cho slide đầu tiên và chuyển đổi Comb cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Chuyển Đổi Wheel**

Phương thức [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) kiểm soát số lượng sector tia radial để tiết lộ slide đích. Sử dụng [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) để chọn Wheel từ [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), sau đó gọi [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) để truy cập các cài đặt [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/).

Ví dụ tạo ra hai cặp slide giống hệt nhau. Mỗi cặp bắt đầu bằng một slide màu đen và kết thúc bằng một slide được phủ bởi một hình chữ nhật màu vàng. Slide 2 sử dụng một spoke và slide 4 sử dụng tám. Cả hai chuyển đổi đều sử dụng tốc độ chậm giống nhau, được đặt bằng [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), và một thời lượng rõ ràng là 8.000 mil giây, được đặt bằng [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration).

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Mở bản trình chiếu đã lưu trong PowerPoint và bắt đầu buổi trình chiếu. Tiến tới slide 1 sang slide 2 để thấy một quét theo chiều kim đồng hồ duy nhất. Sau đó tiến tới slide 3 sang slide 4 để thấy tám sector tia radial tiết lộ cùng một hình chữ nhật đồng thời.

## **Thêm Chuyển Đổi Slide Nâng Cao**

Bạn có thể cấu hình thời gian một slide hiển thị trên màn hình và liệu việc nhấp chuột có chuyển tiếp buổi trình chiếu hay không. Các phương thức sau kiểm soát hành vi này:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) cho phép người xem chuyển tiếp bằng cách nhấp chuột.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) bật chuyển tiếp tự động.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) chỉ định độ trễ trước khi chuyển tiếp tự động, tính bằng mil giây.

Kích hoạt cả hai cách chuyển tiếp bằng nhấp chuột và thời gian để cho phép người xem tiếp tục bằng một cú nhấp hoặc chờ bộ hẹn giờ. Để chỉ sử dụng bộ hẹn giờ, truyền `false` cho [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Độ trễ kiểm soát thời điểm buổi trình chiếu chuyển tiếp; nó không đặt thời lượng của hiệu ứng chuyển đổi trực quan.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật chuyển tiếp tự động sau 3, 5 và 7 giây, tương ứng. Nhấp chuột cũng có thể chuyển tiếp các slide này. Sử dụng tệp `input.pptx` có ít nhất ba slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Để kiểm tra xem chuyển tiếp thời gian đã được bật chưa, gọi [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Một độ trễ được lưu riêng không có nghĩa là bộ hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ hẹn giờ đã bật, và tắt chuyển tiếp tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật nhấp chuột cho những slide đó và lưu các cài đặt đã cập nhật.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kiểm Soát Thời Gian Chuyển Đổi Một Cách Chính Xác**

Sử dụng [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) để chỉ định độ dài chính xác của một hiệu ứng chuyển đổi bằng mil giây. Phương thức [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) của slide tiết lộ các cài đặt này thông qua [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| Phương thức | Mục đích |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Đặt thời lượng của chính hiệu ứng chuyển đổi, tính bằng mil giây. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Đặt độ trễ trước khi slide tự động chuyển tiếp, tính bằng mil giây. Truyền `true` cho [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) để kích hoạt bộ hẹn giờ này. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Chọn một danh mục tốc độ được định sẵn từ [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium hoặc Fast. Nó được sử dụng khi không có thời lượng chính xác được đặt. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) chỉ kiểm soát hiệu ứng chuyển đổi; nó không quyết định thời gian slide vẫn hiển thị. Cấu hình độ trễ chuyển tiếp tự động riêng biệt. Khi không có thời lượng rõ ràng nào được đặt, Aspose.Slides xác định thời lượng hiệu ứng dựa trên loại chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Các thanh riêng biệt xác định thời lượng chuyển đổi 750‑ms và cài đặt chuyển tiếp tự động 5,000‑ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Ví dụ chung này đưa mỗi slide một chuyển đổi Fade 750‑ms và riêng biệt bật chuyển tiếp tự động sau 5.000 ms. Thời lượng chuyển đổi điều khiển hiệu ứng; chuyển tiếp điều khiển thời điểm rời slide. Những thanh này là cài đặt sơ đồ, không phải một thời gian biểu hợp đo lường.*
<!-- visual-explanation:slide-transition:end -->

### **Áp Dụng Thời Lượng Giống Nhau cho Mọi Slide**

Để duy trì nhịp độ nhất quán, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), và đặt thời lượng 750 mil giây cho mỗi chuyển đổi. Nó riêng biệt bật chuyển tiếp tự động sau 5.000 mil giây và tắt chuyển tiếp bằng nhấp chuột, sau đó lưu kết quả dưới dạng PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // Cấu hình chuyển tiếp tự động một cách độc lập với thời lượng hiệu ứng.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Đặt Thời Lượng Khác Nhau cho Các Slide Riêng Lẻ**

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng một chuyển đổi ngắn cho slide tiêu đề và một chuyển đổi dài hơn cho phần giới thiệu. Ví dụ này đặt 500 mil giây cho slide đầu tiên và 1.200 mil giây cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Phối Hợp Chuyển Đổi với Đầu Ra Hoạt Hình**

Khi chuẩn bị một [animated GIF](/slides/vi/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/php-java/export-to-html5/), hoặc [video](/slides/vi/php-java/convert-powerpoint-to-video/), đặt thời lượng chuyển đổi chính xác trước khi xuất để phù hợp với nhịp độ mong muốn. Ví dụ, sử dụng fade 600‑mil giây giữa các cảnh, và điều chỉnh độ trễ chuyển tiếp của mỗi slide riêng biệt để cho phép thời gian cho lời thuyết minh hoặc nội dung.

Đối với GIF và video, phối hợp tốc độ khung hình đầu ra với thời lượng hiệu ứng: 600 mil giây tương đương 18 khung hình ở tốc độ 30 khung hình/giây. Trong HTML5, bật chuyển đổi hoạt hình trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian mà định dạng xuất đã chọn hỗ trợ, và xem trước đầu ra để xác nhận đồng bộ.

### **Đọc Thời Lượng Chuyển Đổi Đã Tồn Tại**

Gọi [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) trước khi sửa đổi chuyển đổi để xác định xem có giá trị rõ ràng nào được lưu hay không. Giá trị `-1` có nghĩa là không có thời lượng rõ ràng được đặt; một giá trị không âm chỉ định thời lượng được lưu bằng mil giây. Giá trị chưa đặt không phải là thời lượng phát lại được tính: Aspose.Slides sử dụng loại chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) để xác định thời lượng đó. Đặt một loại chuyển đổi có thể khởi tạo một thời lượng, vì vậy hãy kiểm tra các cài đặt gốc trước.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Chuyển Đổi Morph**

Chuyển đổi Morph tạo hoạt ảnh cho các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo một hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển đổi Morph cho slide thứ hai. Điều này cho phép chuyển đổi các đối tượng tương ứng để hoạt ảnh giữa trạng thái gốc và đã sửa đổi.

Ví dụ sau tạo một slide với một hình chữ nhật chứa văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ enumeration [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong một trình xem bản trình chiếu hỗ trợ Morph để xem hiệu ứng trong buổi trình chiếu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Các Kiểu Chuyển Đổi Morph**

Enumeration [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt ảnh nội dung:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) coi mỗi hình dạng như một đối tượng nguyên khối.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) hoạt ảnh văn bản bằng cách khớp các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) hoạt ảnh văn bản bằng cách khớp các ký tự khi có thể.

Sử dụng [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) để chọn Morph trước khi truy cập [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). Giá trị sau đó cung cấp một đối tượng [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/), trong đó phương thức [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) chọn chế độ khớp.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Đặt Hiệu Ứng Chuyển Đổi**

Một số chuyển đổi cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc liệu hiệu ứng có bắt đầu từ màn hình đen hay không. Các tùy chọn khả dụng phụ thuộc vào chuyển đổi được chọn bằng [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType). Đặt loại trước, sau đó sử dụng đối tượng chuyển đổi phù hợp từ [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

Ví dụ sau áp dụng chuyển đổi Cut cho slide đầu tiên của `input.pptx`. Nó gọi [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) thông qua [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) để chuyển đổi bắt đầu từ màn hình đen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát tốc độ phát lại của chuyển đổi slide không?**

Đúng. Ưu tiên sử dụng [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) khi bạn cần thời lượng hiệu ứng chính xác tính bằng mil giây. Sử dụng [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) khi một danh mục [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) đã định sẵn — Slow, Medium hoặc Fast — là đủ và không có thời lượng rõ ràng nào được đặt. Các cài đặt này kiểm soát hiệu ứng chuyển đổi một cách độc lập với độ trễ chuyển tiếp tự động.

**Tôi có thể đính kèm âm thanh vào chuyển đổi và lặp lại không?**

Đúng. Gán âm thanh nhúng bằng [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound), truyền giá trị StartSound từ enumeration [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) cho [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode), và bật [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) với `true`. Âm thanh sẽ lặp lại cho đến sự kiện âm thanh tiếp theo trong buổi trình chiếu.

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Lặp qua bộ sưu tập [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) của bản trình chiếu và gọi [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) với cùng một giá trị cho mỗi chuyển đổi của slide. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để duy trì hành vi nhất quán trên các slide.

**Làm sao tôi có thể kiểm tra chuyển đổi nào hiện đang được đặt trên một slide?**

Gọi [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) trên kết quả của [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) của slide. Nó trả về một giá trị từ enumeration [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); None có nghĩa là không có hiệu ứng chuyển đổi nào được áp dụng.