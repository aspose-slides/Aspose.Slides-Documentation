---
title: Bảng
type: docs
weight: 120
url: /vi/php-java/examples/elements/table/
keywords:
- bảng
- thêm bảng
- truy cập bảng
- xóa bảng
- hợp nhất ô
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tạo và định dạng bảng trong PHP bằng Aspose.Slides: chèn dữ liệu, hợp nhất ô, định dạng viền, căn chỉnh nội dung, và nhập/xuất cho PPT, PPTX và ODP."
---
Các ví dụ về việc thêm bảng, truy cập chúng, xóa chúng và hợp nhất ô bằng **Aspose.Slides for PHP via Java**.

## **Thêm một bảng**

Tạo một bảng đơn giản với hai hàng và hai cột.

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập một bảng**

Lấy hình dạng bảng đầu tiên trên slide.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập bảng đầu tiên trên slide.
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa một bảng**

Xóa một bảng khỏi slide.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử bảng là hình dạng đầu tiên trên slide.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Hợp nhất các ô bảng**

Hợp nhất các ô liền kề của một bảng thành một ô duy nhất.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử bảng là hình dạng đầu tiên trên slide.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```