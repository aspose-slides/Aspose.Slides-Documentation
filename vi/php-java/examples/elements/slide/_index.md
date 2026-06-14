---
title: Trình chiếu
type: docs
weight: 10
url: /vi/php-java/examples/elements/slide/
keywords:
- slide
- thêm slide
- truy cập slide
- chỉ mục slide
- sao chép slide
- sắp xếp lại các slide
- xóa slide
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Quản lý các slide trong PHP bằng Aspose.Slides: tạo, sao chép, sắp xếp lại, ẩn, thiết lập nền và kích thước, áp dụng chuyển đổi và xuất ra cho PowerPoint và OpenDocument."
---
Bài viết này cung cấp một loạt các ví dụ minh họa cách làm việc với các slide bằng **Aspose.Slides for PHP via Java**. Bạn sẽ học cách thêm, truy cập, sao chép, sắp xếp lại và xóa slide bằng lớp `Presentation`.

Mỗi ví dụ bên dưới bao gồm một giải thích ngắn gọn đi kèm với đoạn mã mẫu bằng PHP.

## **Thêm slide**

Để thêm một slide mới, trước tiên bạn phải chọn một bố cục. Trong ví dụ này, chúng tôi sử dụng bố cục `Blank` và thêm một slide trống vào bản trình bày.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Mỗi slide dựa trên một bố cục, mà bản thân nó cũng dựa trên một slide chủ.
        // Sử dụng bố cục Blank để tạo một slide mới.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Thêm một slide trống mới bằng cách sử dụng bố cục đã chọn.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Mẹo:** Mỗi bố cục slide được tạo ra từ một slide chủ, định nghĩa thiết kế tổng thể và cấu trúc các placeholder. Hình ảnh dưới đây minh họa cách các slide chủ và các bố cục liên quan được tổ chức trong PowerPoint.

![Mối quan hệ giữa Slide Chủ và Bố cục](master-layout-slide.png)

## **Truy cập slide theo chỉ mục**

Bạn có thể truy cập các slide bằng chỉ mục của chúng.

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Truy cập một slide theo chỉ mục.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Sao chép một slide**

Ví dụ này minh họa cách sao chép một slide hiện có. Slide đã sao chép sẽ tự động được thêm vào cuối bộ sưu tập slide.

```php
function cloneSlide() {
    // Mặc định, bản trình bày chứa một slide trống.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Sao chép slide đầu tiên; nó sẽ được thêm vào cuối bản trình bày.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // Chỉ mục của slide đã sao chép là 1 (slide thứ hai trong bản trình bày).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Sắp xếp lại các slide**

Bạn có thể thay đổi thứ tự của các slide bằng cách di chuyển một slide tới một chỉ mục mới. Trong trường hợp này, chúng tôi di chuyển một slide đến vị trí đầu tiên.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Di chuyển slide đến vị trí đầu tiên (các slide còn lại dịch xuống).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa một slide**

Để xóa một slide, chỉ cần tham chiếu đến nó và gọi `remove`. Ví dụ này xóa các slide theo chỉ mục và theo tham chiếu.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Xóa một slide theo chỉ mục.
        $presentation->getSlides()->removeAt(0);

        // Xóa một slide theo tham chiếu.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```