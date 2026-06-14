---
title: Mực
type: docs
weight: 180
url: /vi/php-java/examples/elements/ink/
keywords:
- mực
- truy cập mực
- xóa mực
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Xử lý mực kỹ thuật số trên các slide trong PHP với Aspose.Slides: thêm nét bút, chỉnh sửa đường dẫn, đặt màu và độ rộng, và xuất kết quả sang PowerPoint và OpenDocument."
---
Cung cấp các ví dụ về cách truy cập các hình dạng mực hiện có và xóa chúng bằng cách sử dụng **Aspose.Slides for PHP via Java**.

> ❗ **Lưu ý:** Các hình dạng mực đại diện cho đầu vào của người dùng từ các thiết bị chuyên dụng. Aspose.Slides không thể tạo các nét mực mới bằng chương trình, nhưng bạn có thể đọc và chỉnh sửa mực hiện có.

## **Truy cập Mực**

Lấy hình dạng mực đầu tiên trên một slide.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập hình mực đầu tiên trên slide.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa Mực**

Xóa một hình dạng mực khỏi slide.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên trên slide là một hình mực.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```