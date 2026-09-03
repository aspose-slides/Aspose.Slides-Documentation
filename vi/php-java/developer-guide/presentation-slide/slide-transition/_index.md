---
title: Quản lý chuyển đổi slide trong bài thuyết trình bằng PHP
linktitle: Chuyển đổi Slide
type: docs
weight: 80
url: /vi/php-java/slide-transition/
keywords:
- chuyển đổi slide
- thêm chuyển đổi slide
- áp dụng chuyển đổi slide
- chuyển đổi slide nâng cao
- chuyển đổi morph
- loại chuyển đổi
- hiệu ứng chuyển đổi
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Áp dụng chuyển đổi slide, cấu hình tiến trình slide tự động, và tùy chỉnh Morph và các hiệu ứng chuyển đổi khác với Aspose.Slides cho PHP thông qua Java."
---
## **Tổng quan**

Các chuyển đổi slide kiểm soát cách các slide xuất hiện trong buổi trình chiếu. Với Aspose.Slides cho PHP thông qua Java, bạn có thể chọn hiệu ứng chuyển đổi cho mỗi slide, cấu hình việc chuyển tiếp bằng cú nhấp chuột hoặc bộ hẹn giờ, và điều chỉnh các tùy chọn đặc thù cho một hiệu ứng. Bài viết này sử dụng các ví dụ PHP để áp dụng chuyển đổi, đặt thời lượng chuyển đổi chính xác, quản lý thời gian slide, và tạo chuyển đổi Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu các thiết lập vào tệp PPTX.

## **Thêm chuyển đổi slide**

Để áp dụng một chuyển đổi, tải một bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và truy cập các cài đặt chuyển đổi của slide thông qua [getSlideShowTransition](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslide/#getSlideShowTransition). Sử dụng [setType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setType) với một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/transitiontype/), sau đó lưu bản trình bày.

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

## **Thêm chuyển đổi slide nâng cao**

Bạn có thể cấu hình thời gian một slide hiển thị trên màn hình và liệu một cú nhấp chuột có tiến trình trình chiếu hay không. Các phương pháp sau kiểm soát hành vi này:

- [setAdvanceOnClick](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) cho phép người xem tiến tới bằng cách nhấp chuột.
- [setAdvanceAfter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) cho phép tiến trình tự động.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) chỉ định độ trễ trước khi tiến trình tự động, tính bằng mili giây.

Bật cả tiến trình bằng cú nhấp và tiến trình có thời gian để cho phép người xem chuyển tiếp bằng cú nhấp hoặc đợi bộ hẹn giờ. Để chỉ sử dụng bộ hẹn giờ, truyền `false` vào [setAdvanceOnClick](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Độ trễ kiểm soát thời điểm trình chiếu chuyển tiếp; nó không đặt thời lượng của hiệu ứng chuyển đổi trực quan.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật tiến trình tự động sau 3, 5 và 7 giây, tương ứng. Các cú nhấp chuột cũng có thể tiến trình các slide này. Sử dụng tệp `input.pptx` có ít nhất ba slide.

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

Để kiểm tra liệu tiến trình có thời gian có được bật hay không, gọi [getAdvanceAfter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Một độ trễ đã lưu riêng lẻ không cho biết rằng bộ hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ hẹn giờ đã bật, và tắt tiến trình tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật cú nhấp chuột cho các slide đó và lưu các cài đặt đã cập nhật.

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

## **Kiểm soát thời gian chuyển đổi một cách chính xác**

Sử dụng [setDuration](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setDuration) để chỉ định độ dài chính xác của một hiệu ứng chuyển đổi bằng mili giây. Phương thức [getSlideShowTransition](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslide/#getSlideShowTransition) của slide mở ra các cài đặt này thông qua [SlideShowTransition](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/):

| Phương thức | Mục đích |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setDuration) | Đặt thời lượng của chính hiệu ứng chuyển đổi, tính bằng mili giây. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Đặt độ trễ trước khi slide tiến tự động, tính bằng mili giây. Truyền `true` vào [setAdvanceAfter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) để kích hoạt bộ hẹn giờ này. |
| [setSpeed](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setSpeed) | Chọn một danh mục tốc độ được định trước từ [TransitionSpeed](https://reference.aspose.com/slides/vi/php-java/aspose.slides/transitionspeed/): Slow, Medium, hoặc Fast. Nó được dùng khi không chỉ định thời lượng chính xác. |

[setDuration] chỉ kiểm soát hiệu ứng chuyển đổi; nó không xác định thời gian slide còn hiển thị. Cấu hình độ trễ tiến trình tự động riêng biệt. Khi không có thời lượng rõ ràng được đặt, Aspose.Slides xác định thời lượng hiệu ứng dựa trên loại chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#getSpeed).

### **Áp dụng cùng thời lượng cho mọi slide**

Để duy trì tốc độ đồng đều, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/transitiontype/), và đặt thời lượng 750 mili giây cho mỗi chuyển đổi. Nó riêng biệt bật tiến trình tự động sau 5.000 mili giây và tắt tiến trình bằng cú nhấp chuột, sau đó lưu kết quả dưới dạng PPTX.

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

        // Cấu hình tiến trình tự động một cách độc lập với thời lượng hiệu ứng.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Đặt thời lượng khác nhau cho từng slide**

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng chuyển đổi ngắn cho slide tiêu đề và chuyển đổi dài hơn cho phần giới thiệu. Ví dụ này đặt 500 mili giây cho slide đầu tiên và 1.200 mili giây cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

### **Phối hợp chuyển đổi với đầu ra động**

Khi chuẩn bị một [animated GIF](/slides/vi/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/php-java/export-to-html5/), hoặc [video](/slides/vi/php-java/convert-powerpoint-to-video/), đặt thời lượng chuyển đổi chính xác trước khi xuất để phù hợp với nhịp độ dự định. Ví dụ, sử dụng hiệu ứng mờ 600 mili giây giữa các cảnh, và điều chỉnh độ trễ tiến trình của mỗi slide riêng biệt để cho phép thời gian cho lời thuyết minh hoặc nội dung của nó.

Đối với GIF và video, phối hợp tốc độ khung hình đầu ra với thời lượng hiệu ứng: 600 mili giây tương đương 18 khung hình ở tốc độ 30 khung/giây. Trong HTML5, bật chuyển đổi động trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian được hỗ trợ của định dạng xuất đã chọn, và xem trước đầu ra để xác nhận đồng bộ.

### **Đọc thời lượng chuyển đổi hiện có**

Gọi [getDuration](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#getDuration) trước khi chỉnh sửa chuyển đổi để xác định liệu có giá trị cụ thể nào được lưu hay không. Giá trị `-1` có nghĩa là không đặt thời lượng cụ thể; một giá trị không âm chỉ định thời lượng đã lưu bằng mili giây. Giá trị chưa đặt không phải là thời lượng phát lại được tính toán: Aspose.Slides sử dụng loại chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#getSpeed) để xác định thời lượng đó. Đặt một loại chuyển đổi có thể khởi tạo thời lượng, vì vậy hãy kiểm tra các cài đặt gốc trước.

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

## **Chuyển đổi Morph**

Chuyển đổi Morph tạo hoạt ảnh cho các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển đổi Morph cho slide thứ hai. Điều này cung cấp các đối tượng tương ứng cho chuyển đổi để hoạt ảnh giữa trạng thái gốc và đã sửa đổi.

Ví dụ sau tạo một slide với một hình chữ nhật chứa văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong một trình xem bản trình bày hỗ trợ Morph để xem hiệu ứng trong buổi trình chiếu.

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

## **Các loại chuyển đổi Morph**

Liệt kê [TransitionMorphType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt ảnh nội dung:

- [ByObject](https://reference.aspose.com/slides/vi/php-java/aspose.slides/transitionmorphtype/#ByObject) xem mỗi hình dạng như một đối tượng toàn bộ.
- [ByWord](https://reference.aspose.com/slides/vi/php-java/aspose.slides/transitionmorphtype/#ByWord) hoạt ảnh văn bản bằng cách khớp các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/vi/php-java/aspose.slides/transitionmorphtype/#ByChar) hoạt ảnh văn bản bằng cách khớp các ký tự khi có thể.

Sử dụng [setType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setType) để chọn Morph trước khi truy cập [getValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#getValue). Giá trị sau đó cung cấp một đối tượng [MorphTransition](https://reference.aspose.com/slides/vi/php-java/aspose.slides/morphtransition/), phương thức [setMorphType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/morphtransition/#setMorphType) của nó chọn chế độ khớp.

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

## **Đặt hiệu ứng chuyển đổi**

Một số chuyển đổi tiết lộ các tùy chọn bổ sung, chẳng hạn như hướng hoặc liệu hiệu ứng có bắt đầu từ màn hình đen hay không. Các tùy chọn khả dụng phụ thuộc vào chuyển đổi được chọn bằng [setType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setType). Đặt loại trước, sau đó sử dụng đối tượng chuyển đổi phù hợp từ [getValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#getValue).

Ví dụ sau áp dụng chuyển đổi Cut cho slide đầu tiên của `input.pptx`. Nó gọi [setFromBlack](https://reference.aspose.com/slides/vi/php-java/aspose.slides/optionalblacktransition/#setFromBlack) thông qua [OptionalBlackTransition](https://reference.aspose.com/slides/vi/php-java/aspose.slides/optionalblacktransition/) để chuyển đổi bắt đầu từ màn hình đen.

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

## **FAQ**

**Tôi có thể kiểm soát tốc độ phát của một chuyển đổi slide không?**

Có. Ưu tiên sử dụng [setDuration](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setDuration) khi bạn cần thời lượng hiệu ứng chính xác tính bằng mili giây. Sử dụng [setSpeed](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setSpeed) khi một danh mục [TransitionSpeed](https://reference.aspose.com/slides/vi/php-java/aspose.slides/transitionspeed/) được định trước—Slow, Medium, hoặc Fast—đủ và không có thời lượng cụ thể được đặt. Các cài đặt này kiểm soát hiệu ứng chuyển đổi một cách độc lập với độ trễ tiến trình tự động.

**Tôi có thể đính kèm âm thanh vào chuyển đổi và lặp lại không?**

Có. Gán âm thanh được nhúng bằng [setSound](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setSound), truyền StartSound từ liệt kê [TransitionSoundMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/transitionsoundmode/) vào [setSoundMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setSoundMode), và bật [setSoundLoop](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setSoundLoop) với `true`. Âm thanh sẽ lặp lại cho đến sự kiện âm thanh tiếp theo trong buổi trình chiếu.

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Lặp qua bộ sưu tập [getSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSlides) của bản trình bày và gọi [setType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#setType) với cùng một giá trị cho mỗi chuyển đổi của slide. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để duy trì hành vi nhất quán trên các slide.

**Làm sao tôi có thể kiểm tra chuyển đổi hiện đang được đặt trên một slide?**

Gọi [getType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/#getType) trên kết quả của [getSlideShowTransition](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslide/#getSlideShowTransition) của slide. Nó trả về một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/transitiontype/); None có nghĩa là không có hiệu ứng chuyển đổi nào được áp dụng.