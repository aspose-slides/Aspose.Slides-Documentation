---
title: "Phần"
type: docs
weight: 90
url: /vi/php-java/examples/elements/section/
keywords:
- "phần"
- "phần slide"
- "thêm phần"
- "truy cập phần"
- "xóa phần"
- "đổi tên phần"
- "ví dụ mã"
- "PowerPoint"
- "OpenDocument"
- "bản trình chiếu"
- "PHP"
- "Aspose.Slides"
description: "Quản lý các phần slide trong PHP với Aspose.Slides: tạo, đổi tên, sắp xếp lại dễ dàng, di chuyển slide giữa các phần và kiểm soát khả năng hiển thị cho PPT, PPTX và ODP."
---
Ví dụ về việc quản lý các phần của bản trình chiếu — thêm, truy cập, xóa và đổi tên chúng một cách lập trình bằng **Aspose.Slides for PHP via Java**.

## **Thêm một phần**

Tạo một phần bắt đầu tại một slide cụ thể.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Chỉ định slide đánh dấu đầu của phần.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập một phần**

Đọc thông tin phần từ bản trình chiếu.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Truy cập một phần theo chỉ mục.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa một phần**

Xóa một phần đã được thêm trước đó.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Xóa phần.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Đổi tên một phần**

Thay đổi tên của một phần hiện có.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```