---
title: Chuyển tiếp slide
type: docs
weight: 110
url: /vi/php-java/examples/elements/slide-transition/
keywords:
- chuyển tiếp slide
- thêm chuyển tiếp slide
- truy cập chuyển tiếp slide
- xóa chuyển tiếp slide
- thời lượng chuyển tiếp
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Kiểm soát chuyển tiếp slide trong PHP với Aspose.Slides: chọn loại, tốc độ, âm thanh và thời gian để tinh chỉnh bản trình bày ở định dạng PPT, PPTX và ODP."
---
Minh họa cách áp dụng hiệu ứng chuyển tiếp slide và thời gian với **Aspose.Slides for PHP via Java**.

## **Thêm chuyển tiếp slide**

Áp dụng hiệu ứng chuyển đổi mờ (fade) cho slide đầu tiên.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Áp dụng chuyển đổi mờ.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập chuyển tiếp slide**

Đọc loại chuyển tiếp được gán cho một slide.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập loại chuyển tiếp.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa chuyển tiếp slide**

Xóa mọi hiệu ứng chuyển tiếp bằng cách đặt loại thành `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Xóa chuyển tiếp bằng cách đặt không.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Đặt thời lượng chuyển tiếp**

Xác định thời gian slide hiển thị trước khi tự động chuyển tiếp.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // tính bằng mili giây.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```