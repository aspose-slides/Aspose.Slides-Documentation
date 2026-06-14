---
title: SmartArt
type: docs
weight: 140
url: /vi/php-java/examples/elements/smartart/
keywords:
- SmartArt
- thêm SmartArt
- truy cập SmartArt
- xóa SmartArt
- bố cục SmartArt
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Xây dựng và chỉnh sửa SmartArt trong PHP với Aspose.Slides: thêm nút, thay đổi bố cục và kiểu dáng, chuyển đổi sang hình dạng một cách chính xác, và xuất ra PPT, PPTX và ODP."
---
Hiển thị cách thêm đồ họa SmartArt, truy cập chúng, xóa chúng và thay đổi bố cục bằng **Aspose.Slides for PHP via Java**.

## **Thêm SmartArt**

Chèn một đồ họa SmartArt bằng một trong các bố cục có sẵn.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập SmartArt**

Lấy đối tượng SmartArt đầu tiên trên một slide.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập SmartArt đầu tiên trên slide.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa SmartArt**

Xóa một hình dạng SmartArt khỏi slide.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên trên slide là một SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Thay đổi bố cục SmartArt**

Cập nhật kiểu bố cục của một đồ họa SmartArt hiện có.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên trên slide là một SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Thay đổi bố cục của SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```