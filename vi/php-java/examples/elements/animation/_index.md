---
title: Hoạt ảnh
type: docs
weight: 100
url: /vi/php-java/examples/elements/animation/
keywords:
- hoạt ảnh
- thêm hoạt ảnh
- truy cập hoạt ảnh
- xóa hoạt ảnh
- chuỗi hoạt ảnh
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Thành thạo các hoạt ảnh slide trong PHP với Aspose.Slides: thêm, chỉnh sửa và xóa các hiệu ứng, thời gian và trình kích hoạt để tạo các bản trình bày động ở định dạng PPT, PPTX và ODP."
---
Hiển thị cách tạo các hoạt ảnh đơn giản và quản lý chuỗi của chúng bằng **Aspose.Slides for PHP via Java**.

## **Thêm một Hoạt Ảnh**

Tạo một hình chữ nhật và áp dụng hiệu ứng mờ dần khi nhấp chuột.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // Hiệu ứng mờ dần.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập một Hoạt Ảnh**

Lấy hiệu ứng hoạt ảnh đầu tiên từ dòng thời gian của slide.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập hiệu ứng hoạt ảnh đầu tiên.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa một Hoạt Ảnh**

Gỡ bỏ hiệu ứng hoạt ảnh khỏi chuỗi.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // Xóa hiệu ứng.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Chuỗi Hoạt Ảnh**

Thêm nhiều hiệu ứng và trình bày thứ tự các hoạt ảnh diễn ra.

```php
function sequenceAnimations() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 200, 50, 100, 100);

        $sequence = $slide->getTimeline()->getMainSequence();
        $sequence->addEffect($shape1, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
        $sequence->addEffect($shape2, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);

        $presentation->save("animation_sequence.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```