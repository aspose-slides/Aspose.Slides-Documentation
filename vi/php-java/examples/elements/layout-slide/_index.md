---
title: Slide bố cục
type: docs
weight: 20
url: /vi/php-java/examples/elements/layout-slide/
keywords:
- slide bố cục
- thêm slide bố cục
- truy cập slide bố cục
- xóa slide bố cục
- slide bố cục không sử dụng
- sao chép slide bố cục
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Sử dụng PHP để quản lý slide bố cục với Aspose.Slides: tạo, áp dụng, sao chép, đổi tên và tùy chỉnh các trình giữ chỗ và giao diện trong các bản trình bày cho PPT, PPTX và ODP."
---
Bài viết này trình bày cách làm việc với **Layout Slides** trong Aspose.Slides cho PHP qua Java. Một layout slide xác định thiết kế và định dạng được kế thừa bởi các slide thường. Bạn có thể thêm, truy cập, sao chép và xóa layout slides, cũng như dọn dẹp các layout không sử dụng để giảm kích thước bản trình bày.

## **Thêm một Layout Slide**

Bạn có thể tạo một layout slide tùy chỉnh để xác định định dạng có thể tái sử dụng. Ví dụ, bạn có thể thêm một hộp văn bản xuất hiện trên tất cả các slide sử dụng layout này.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // Tạo một slide bố cục với loại bố cục trống và tên tùy chỉnh.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Mẹo 1:** Layout slides hoạt động như mẫu cho từng slide. Bạn có thể định nghĩa các yếu tố chung một lần và tái sử dụng chúng trên nhiều slide.

> 💡 **Mẹo 2:** Khi bạn thêm hình dạng hoặc văn bản vào một layout slide, tất cả các slide dựa trên layout đó sẽ tự động hiển thị nội dung chung này.  
> Ảnh chụp màn hình bên dưới hiển thị hai slide, mỗi slide kế thừa một hộp văn bản từ cùng một layout slide.

![Các slide kế thừa nội dung Layout](layout-slide-result.png)

## **Truy cập một Layout Slide**

Layout slides có thể được truy cập theo chỉ mục hoặc theo loại layout (ví dụ, `Blank`, `Title`, `SectionHeader`, v.v.).

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Truy cập theo chỉ mục.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // Truy cập theo loại bố cục.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa một Layout Slide**

Bạn có thể xóa một layout slide cụ thể nếu nó không còn cần thiết.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Lấy một slide bố cục theo loại và xóa nó.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa các Layout Slides không sử dụng**

Để giảm kích thước bản trình bày, bạn có thể muốn xóa các layout slide không được bất kỳ slide thường nào sử dụng.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Tự động xóa tất cả các slide bố cục không được bất kỳ slide nào tham chiếu.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Sao chép một Layout Slide**

Bạn có thể nhân bản một layout slide bằng phương thức `addClone`.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Lấy một slide bố cục hiện có theo loại.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Sao chép slide bố cục tới cuối bộ sưu tập slide bố cục.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Tóm tắt:** Layout slides là công cụ mạnh mẽ để quản lý định dạng nhất quán trên các slide. Aspose.Slides cho phép kiểm soát đầy đủ việc tạo, quản lý và tối ưu hóa layout slides.