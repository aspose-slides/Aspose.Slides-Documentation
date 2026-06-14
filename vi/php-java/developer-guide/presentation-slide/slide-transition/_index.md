---
title: Quản lý chuyển đổi slide trong bài thuyết trình bằng PHP
linktitle: Chuyển đổi slide
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
description: "Khám phá cách tùy chỉnh chuyển đổi slide trong Aspose.Slides cho PHP qua Java, với hướng dẫn chi tiết từng bước cho các bài thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý chuyển đổi slide trong bài thuyết trình bằng Aspose.Slides. Nó cho thấy cách áp dụng các loại chuyển đổi cho slide, cấu hình hành vi chuyển đổi như chuyển tiếp khi nhấp chuột hoặc sau một thời gian xác định, kiểm tra và tắt chuyển tiếp tự động, sử dụng chuyển đổi Morph và các loại của nó, và đặt các tùy chọn hiệu ứng chuyển đổi. Các ví dụ minh họa cách tải hoặc tạo một bài thuyết trình, sửa đổi cài đặt chuyển đổi cho các slide được chọn và lưu kết quả dưới dạng tệp PPTX. Bài viết cũng trả lời các câu hỏi thường gặp về tốc độ chuyển đổi, âm thanh chuyển đổi, áp dụng cùng một chuyển đổi cho nhiều slide và kiểm tra chuyển đổi hiện tại đã được đặt trên một slide.

## **Thêm chuyển đổi slide**

Để tạo một hiệu ứng chuyển đổi slide đơn giản, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Áp dụng một Slide Transition Type cho slide từ một trong các hiệu ứng chuyển đổi do Aspose.Slides for PHP via Java cung cấp thông qua enum TransitionType.
1. Ghi tệp bài thuyết trình đã sửa đổi.

```php
  # Khởi tạo lớp Presentation để tải tệp bài thuyết trình nguồn
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Áp dụng chuyển đổi loại circle cho slide 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Áp dụng chuyển đổi loại comb cho slide 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Ghi bài thuyết trình ra đĩa
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Thêm chuyển đổi slide nâng cao**

Trong phần trên, chúng ta chỉ áp dụng một hiệu ứng chuyển đổi đơn giản cho slide. Bây giờ, để làm cho hiệu ứng chuyển đổi đơn giản này tốt hơn và có kiểm soát hơn, hãy thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Áp dụng một Slide Transition Type cho slide từ một trong các hiệu ứng chuyển đổi do Aspose.Slides for PHP via Java cung cấp.
1. Bạn cũng có thể đặt chuyển đổi để Tiến lên Khi Nhấp, sau một khoảng thời gian xác định hoặc cả hai.
1. Nếu chuyển đổi slide được bật Tiến lên Khi Nhấp, chuyển đổi sẽ chỉ tiến lên khi ai đó nhấp chuột. Hơn nữa, nếu thuộc tính Advance After Time được đặt, chuyển đổi sẽ tiến lên tự động sau khi thời gian đã chỉ định kết thúc.
1. Ghi bài thuyết trình đã sửa đổi dưới dạng tệp.

```php
  # Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Áp dụng chuyển đổi loại circle cho slide 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Đặt thời gian chuyển đổi là 3 giây
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Áp dụng chuyển đổi loại comb cho slide 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Đặt thời gian chuyển đổi là 5 giây
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Áp dụng chuyển đổi loại zoom cho slide 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Đặt thời gian chuyển đổi là 7 giây
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Ghi bài thuyết trình ra đĩa
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Chuyển đổi Morph**

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java hiện hỗ trợ [Morph Transition](https://reference.aspose.com/slides/vi/php-java/aspose.slides/morphtransition/). Đây là chuyển đổi morph mới được giới thiệu trong PowerPoint 2019.

{{% /alert %}} 

Chuyển đổi Morph cho phép bạn tạo hoạt ảnh di chuyển mượt mà từ slide này sang slide kế. Bài viết này mô tả khái niệm và cách sử dụng chuyển đổi Morph. Để sử dụng chuyển đổi Morph một cách hiệu quả, bạn cần có hai slide có ít nhất một đối tượng chung. Cách dễ nhất là sao chép slide và sau đó di chuyển đối tượng trên slide thứ hai tới vị trí khác.

Đoạn mã dưới đây cho bạn thấy cách thêm một bản sao của slide có một số văn bản vào bài thuyết trình và đặt chuyển đổi [morph type](https://reference.aspose.com/slides/vi/php-java/aspose.slides/TransitionType) cho slide thứ hai.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Các loại chuyển đổi Morph**

Enum mới [TransitionMorphType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/TransitionMorphType) đã được thêm vào. Nó đại diện cho các loại chuyển đổi slide Morph khác nhau.

Enum TransitionMorphType có ba thành viên:

- ByObject: Chuyển đổi Morph sẽ được thực hiện bằng cách xem các hình dạng như các đối tượng không thể chia nhỏ.
- ByWord: Chuyển đổi Morph sẽ được thực hiện bằng cách chuyển văn bản theo từ khi có thể.
- ByChar: Chuyển đổi Morph sẽ được thực hiện bằng cách chuyển văn bản theo ký tự khi có thể.

Đoạn mã dưới đây cho bạn thấy cách đặt chuyển đổi morph cho slide và thay đổi loại morph:

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Đặt hiệu ứng chuyển đổi**

Aspose.Slides for PHP via Java hỗ trợ việc đặt các hiệu ứng chuyển đổi như, từ màu đen, từ trái, từ phải, v.v. Để đặt hiệu ứng chuyển đổi, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
- Lấy tham chiếu của slide.
- Đặt hiệu ứng chuyển đổi.
- Ghi bài thuyết trình dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/).

Trong ví dụ dưới đây, chúng tôi đã đặt các hiệu ứng chuyển đổi.

```php
  # Tạo một thể hiện của lớp Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Đặt hiệu ứng
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Ghi bài thuyết trình ra đĩa
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát tốc độ phát của chuyển đổi slide không?**

Có. Đặt [speed](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/setspeed/) của chuyển đổi bằng cách sử dụng cài đặt [TransitionSpeed](https://reference.aspose.com/slides/vi/php-java/aspose.slides/transitionspeed/) (ví dụ: slow/medium/fast).

**Tôi có thể đính kèm âm thanh vào chuyển đổi và lặp lại không?**

Có. Bạn có thể nhúng âm thanh cho chuyển đổi và kiểm soát hành vi qua các cài đặt như chế độ âm thanh và vòng lặp (ví dụ: [setSound](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/setsoundloop/), cùng các siêu dữ liệu như [setSoundIsBuiltIn](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) và [setSoundName](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Cấu hình loại chuyển đổi mong muốn trên cài đặt chuyển đổi của từng slide; chuyển đổi được lưu riêng cho mỗi slide, vì vậy áp dụng cùng một loại cho tất cả các slide sẽ cho kết quả đồng nhất.

**Làm sao để kiểm tra chuyển đổi hiện tại đã được đặt trên một slide?**

Kiểm tra [transition settings](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslide/#getSlideShowTransition) của slide và đọc [transition type](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideshowtransition/settype/); giá trị đó cho bạn biết chính xác hiệu ứng nào đang được áp dụng.