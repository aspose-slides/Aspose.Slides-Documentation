---
title: Quản lý chuyển tiếp slide trong bài thuyết trình bằng PHP
linktitle: Chuyển tiếp slide
type: docs
weight: 80
url: /vi/php-java/slide-transition/
keywords:
- chuyển tiếp slide
- thêm chuyển tiếp slide
- áp dụng chuyển tiếp slide
- chuyển tiếp slide nâng cao
- chuyển tiếp morph
- loại chuyển tiếp
- hiệu ứng chuyển tiếp
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Áp dụng chuyển tiếp slide, cấu hình tiến tới slide tự động, và tùy chỉnh Morph cũng như các hiệu ứng chuyển tiếp khác với Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Các chuyển tiếp slide kiểm soát cách các slide xuất hiện trong buổi chiếu slide. Với Aspose.Slides for PHP via Java, bạn có thể chọn hiệu ứng chuyển tiếp cho mỗi slide, cấu hình việc tiến tới bằng cú nhấp chuột hoặc bộ đếm thời gian, và điều chỉnh các tùy chọn đặc thù cho một hiệu ứng. Bài viết này sử dụng các ví dụ PHP để áp dụng chuyển tiếp, đặt thời lượng chuyển tiếp chính xác, quản lý thời gian slide, và tạo chuyển tiếp Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu các thiết lập vào tệp PPTX.

## **Thêm chuyển tiếp cho slide**

Để áp dụng một chuyển tiếp, tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) và truy cập cài đặt chuyển tiếp của slide qua [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). Sử dụng [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) với một giá trị từ enum [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), sau đó lưu bản trình chiếu.

Ví dụ dưới áp dụng chuyển tiếp Circle cho slide đầu tiên và chuyển tiếp Comb cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

## **Chuyển tiếp Wheel**

Phương thức [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) kiểm soát số sector dạng bán kính hiển thị slide đích. Sử dụng [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) để chọn Wheel từ [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), sau đó gọi [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) để truy cập các cài đặt của [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/).

Ví dụ tạo hai cặp slide giống hệt nhau. Mỗi cặp bắt đầu bằng một slide màu đen và kết thúc bằng một slide được phủ một hình chữ nhật màu vàng. Slide 2 sử dụng một spoke và slide 4 sử dụng tám. Cả hai chuyển tiếp đều dùng tốc độ chậm giống nhau, được đặt bằng [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), và thời lượng rõ ràng 8.000 mil giây, được đặt bằng [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration).

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

Mở bản trình chiếu đã lưu trong PowerPoint và bắt đầu chiếu slide. Tiến tới slide 2 từ slide 1 để thấy một vòng quay đồng hồ duy nhất. Sau đó tiến tới slide 4 từ slide 3 để thấy tám sector dạng bán kính hiển thị đồng thời hình chữ nhật cùng một lúc.

## **Fade Through Black với chuyển tiếp Reveal**

Đặt loại chuyển tiếp của slide đích thành Reveal, sau đó gọi [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) trên cài đặt [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/) của nó. Ví dụ tạo một slide nguồn màu xanh ngọc và một slide đích màu san hô, sau đó sao chép cả hai. Mỗi cặp sử dụng cùng một chuyển tiếp Reveal hai giây. Chỉ cặp thứ hai mới fade qua màu đen.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionLeftRightDirectionType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $source = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addClone($source);

    foreach ([
        [$source, new Color(0, 128, 128), "Source"],
        [$destination, new Color(255, 127, 80), "Destination"],
    ] as [$slide, $color, $label]) {
        $slide->getBackground()->setType(BackgroundType::OwnBackground);
        $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
        $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
        $shape->getTextFrame()->setText($label);
        $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(44);
    }

    $presentation->getSlides()->addClone($source);
    $clonedDestination = $presentation->getSlides()->addClone($destination);
    foreach ([[$destination, false], [$clonedDestination, true]] as [$slide, $throughBlack]) {
        $slide->getSlideShowTransition()->setType(TransitionType::Reveal);
        $slide->getSlideShowTransition()->setSpeed(TransitionSpeed::Slow);
        $slide->getSlideShowTransition()->setDuration(2000);
        $slide->getSlideShowTransition()->getValue()->setDirection(TransitionLeftRightDirectionType::Left);
        $slide->getSlideShowTransition()->getValue()->setThroughBlack($throughBlack);
    }

    $presentation->save("reveal-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Mở bản trình chiếu đã lưu trong PowerPoint và bắt đầu chiếu slide. Tiến tới slide 2 từ slide 1 để thấy màu xanh ngọc fade trực tiếp sang màu san hô. Sau đó tiến tới slide 4 từ slide 3. Màn hình sẽ tối dần gần như màu đen trước khi slide san hô xuất hiện. Cả hai slide vẫn giữ màu nền gốc của chúng.

Các hàng bên dưới hiển thị khung hình từ PowerPoint mỗi nửa giây. So sánh khung giữa trong mỗi hàng để thấy hiệu ứng.

![Các thanh riêng biệt xác định thời lượng chuyển tiếp 750 ms và thiết lập tự động tiến tới 5.000 ms.](reveal-through-black.png)

## **Thêm chuyển tiếp slide nâng cao**

Bạn có thể cấu hình thời gian một slide tồn tại trên màn hình và việc một cú nhấp chuột có tiến tới buổi chiếu slide hay không. Các phương thức sau kiểm soát hành vi này:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) cho phép người xem tiến tới bằng cách nhấp chuột.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) kích hoạt tiến tới tự động.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) xác định độ trễ trước khi tiến tới tự động, tính bằng mil giây.

Bật cả tiến tới bằng nhấp chuột và tiến tới theo thời gian để người xem có thể di chuyển bằng nhấp chuột hoặc chờ bộ đếm. Để chỉ dùng bộ đếm, truyền `false` vào [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Độ trễ kiểm soát thời điểm buổi chiếu slide tiến tới; nó không đặt thời lượng của hiệu ứng chuyển tiếp trực quan.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật tiến tới tự động sau 3, 5 và 7 giây, tương ứng. Người xem cũng có thể nhấp chuột để tiến tới các slide này. Sử dụng tệp `input.pptx` có ít nhất ba slide.

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

Để kiểm tra xem tiến tới theo thời gian có được bật hay không, gọi [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Một độ trễ được lưu không đồng nghĩa với việc bộ đếm đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ đếm đã bật, và tắt tiến tới tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật nhấp chuột cho các slide đó và lưu lại các cài đặt đã cập nhật.

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

## **Kiểm soát thời gian chuyển tiếp một cách chính xác**

Sử dụng [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) để chỉ định độ dài chính xác của một hiệu ứng chuyển tiếp tính bằng mil giây. Phương thức [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) của slide cung cấp các cài đặt này thông qua [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| Phương thức | Mục đích |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Đặt thời lượng của chính hiệu ứng chuyển tiếp, tính bằng mil giây. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Đặt độ trễ trước khi slide tự động tiến tới, tính bằng mil giây. Truyền `true` vào [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) để kích hoạt bộ đếm này. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Chọn một hạng mục tốc độ đã định nghĩa trước từ [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium hoặc Fast. Được dùng khi không có thời lượng cụ thể được chỉ định. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) chỉ kiểm soát hiệu ứng chuyển tiếp; nó không quyết định thời gian slide còn lại trên màn hình. Cấu hình độ trễ tiến tới tự động riêng biệt. Khi không đặt thời lượng cụ thể, Aspose.Slides sẽ xác định thời lượng hiệu ứng dựa trên loại chuyển tiếp và giá trị [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Các thanh riêng biệt xác định thời lượng chuyển tiếp 750‑ms và thiết lập tự động tiến tới 5.000‑ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Ví dụ chung này đặt mỗi slide có chuyển tiếp Fade 750‑ms và riêng biệt bật tiến tới tự động sau 5.000 ms. Thời lượng chuyển tiếp kiểm soát hiệu ứng; tiến tới kiểm soát thời điểm rời slide. Các thanh này là cấu hình mô hình, không phải một dòng thời gian đo lường thực tế.*
<!-- visual-explanation:slide-transition:end -->

### **Áp dụng cùng một thời lượng cho mọi slide**

Để duy trì nhịp độ nhất quán, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), và đặt thời lượng cho mỗi chuyển tiếp là 750 mil giây. Nó cũng bật tiến tới tự động sau 5.000 mil giây và tắt tiến tới bằng nhấp chuột, sau đó lưu kết quả dưới dạng PPTX.

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

        // Cấu hình tiến tới tự động độc lập với thời lượng hiệu ứng.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Đặt thời lượng khác nhau cho từng slide riêng lẻ**

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng chuyển tiếp ngắn cho slide tiêu đề và chuyển tiếp dài hơn cho phần giới thiệu. Ví dụ này đặt 500 ms cho slide đầu tiên và 1 200 ms cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

### **Phối hợp chuyển tiếp với đầu ra hoạt hình**

Khi chuẩn bị một [animated GIF](/slides/vi/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/php-java/export-to-html5/), hoặc [video](/slides/vi/php-java/convert-powerpoint-to-video/), đặt thời lượng chuyển tiếp chính xác trước khi xuất để khớp với nhịp độ mong muốn. Ví dụ, sử dụng fade 600 ms giữa các cảnh, và điều chỉnh độ trễ tiến tới của từng slide riêng biệt để cho phép thời gian cho lời thuyết minh hoặc nội dung của nó.

Đối với GIF và video, phối hợp tốc độ khung hình đầu ra với thời lượng hiệu ứng: 600 ms tương đương 18 khung hình ở 30 fps. Trong HTML5, bật chuyển tiếp hoạt hình trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian được hỗ trợ bởi định dạng xuất đã chọn, và xem trước đầu ra để xác nhận đồng bộ.

### **Đọc thời lượng chuyển tiếp hiện có**

Gọi [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) trước khi chỉnh sửa chuyển tiếp để xác định liệu đã lưu một giá trị rõ ràng hay chưa. Giá trị `-1` có nghĩa là không có thời lượng cụ thể được đặt; giá trị không âm chỉ thời lượng đã lưu tính bằng mil giây. Giá trị chưa đặt không phải là thời lượng phát lại được tính toán: Aspose.Slides dùng loại chuyển tiếp và giá trị [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) để xác định thời lượng đó. Đặt một loại chuyển tiếp có thể khởi tạo thời lượng, vì vậy hãy kiểm tra các cài đặt ban đầu trước.

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

## **Chuyển tiếp Morph**

Chuyển tiếp Morph hoạt họa các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển tiếp Morph cho slide thứ hai. Điều này cung cấp các đối tượng tương ứng để hoạt họa giữa trạng thái gốc và đã chỉnh sửa.

Ví dụ sau tạo một slide có một hình chữ nhật chứa văn bản, sao chép slide đó, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ enum [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong trình xem bản trình chiếu hỗ trợ Morph để xem hiệu ứng trong buổi chiếu slide.

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

## **Các loại chuyển tiếp Morph**

Enum [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt họa nội dung:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) xem mỗi hình dạng như một đối tượng toàn bộ.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) hoạt họa văn bản bằng cách ghép các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) hoạt họa văn bản bằng cách ghép các ký tự khi có thể.

Sử dụng [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) để chọn Morph trước khi truy cập [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). Giá trị trả về sau đó cung cấp một đối tượng [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/), trong đó phương thức [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) chọn chế độ ghép.

Ví dụ này mở bản trình chiếu được tạo ở phần trước và cấu hình slide thứ hai sử dụng hoạt họa Morph dựa trên từ.

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

## **Đặt hiệu ứng chuyển tiếp**

Một số chuyển tiếp cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc việc hiệu ứng bắt đầu từ màn hình đen. Các tùy chọn khả dụng phụ thuộc vào chuyển tiếp đã chọn bằng [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType). Đặt loại trước, sau đó sử dụng đối tượng chuyển tiếp phù hợp từ [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

Ví dụ sau áp dụng chuyển tiếp Cut cho slide đầu tiên của `input.pptx`. Nó gọi [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) thông qua [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) để chuyển tiếp bắt đầu từ màn hình đen.

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

**Tôi có thể kiểm soát tốc độ phát của một chuyển tiếp slide không?**

Có. Ưu tiên sử dụng [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) khi bạn cần thời lượng hiệu ứng chính xác tính bằng mil giây. Sử dụng [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) khi một hạng mục tốc độ đã định nghĩa trước từ [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) — Slow, Medium hoặc Fast — là đủ và không có thời lượng cụ thể được đặt. Các cài đặt này kiểm soát hiệu ứng chuyển tiếp độc lập với độ trễ tiến tới tự động.

**Tôi có thể gắn âm thanh vào một chuyển tiếp và lặp lại nó không?**

Có. Gán âm thanh nhúng bằng [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound), truyền `StartSound` từ enum [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) vào [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode), và bật [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) với `true`. Âm thanh sẽ lặp cho tới sự kiện âm thanh tiếp theo trong buổi chiếu slide.

**Cách nhanh nhất để áp dụng cùng một chuyển tiếp cho mọi slide là gì?**

Duyệt qua bộ sưu tập [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) của bản trình chiếu và gọi [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) với cùng một giá trị cho từng slide. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để duy trì hành vi nhất quán giữa các slide.

**Làm thế nào tôi có thể kiểm tra chuyển tiếp nào hiện đang được đặt trên một slide?**

Gọi [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) trên kết quả của [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) của slide. Nó trả về một giá trị từ enum [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); `None` có nghĩa là không có hiệu ứng chuyển tiếp nào được áp dụng.