---
title: HeaderFooter
type: docs
weight: 220
url: /vi/php-java/examples/elements/header-footer/
keywords:
- đầu trang và chân trang
- thêm đầu trang và chân trang
- cập nhật đầu trang và chân trang
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Kiểm soát đầu trang và chân trang trong PHP với Aspose.Slides: thêm hoặc chỉnh sửa ngày/giờ, số slide, và văn bản chân trang, hiển thị hoặc ẩn các trình giữ chỗ trên PPT, PPTX và ODP."
---
Hiển thị cách thêm phần chân trang và cập nhật các trình giữ chỗ ngày và giờ bằng **Aspose.Slides for PHP via Java**.

## **Thêm phần chân trang**

Thêm văn bản vào khu vực chân trang của một slide và hiển thị nó.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Cập nhật ngày và giờ**

Sửa đổi trình giữ chỗ ngày và giờ trên một slide.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```