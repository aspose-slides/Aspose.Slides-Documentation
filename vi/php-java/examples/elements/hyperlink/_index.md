---
title: Siêu liên kết
type: docs
weight: 130
url: /vi/php-java/examples/elements/hyperlink/
keywords:
- siêu liên kết
- thêm siêu liên kết
- truy cập siêu liên kết
- xóa siêu liên kết
- cập nhật siêu liên kết
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Thêm, chỉnh sửa và xóa siêu liên kết trong PHP với Aspose.Slides: văn bản liên kết, hình dạng, slide, URL và email; đặt mục tiêu và hành động cho PPT, PPTX và ODP."
---
Minh họa cách thêm, truy cập, xóa và cập nhật siêu liên kết trên các hình dạng bằng **Aspose.Slides for PHP via Java**.

## **Thêm Siêu Liên Kết**
Tạo một hình chữ nhật có siêu liên kết trỏ tới một trang web bên ngoài.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập Siêu Liên Kết**
Đọc thông tin siêu liên kết từ phần văn bản của một hình dạng.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên chứa siêu liên kết.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa Siêu Liên Kết**
Xóa bỏ siêu liên kết khỏi văn bản của một hình dạng.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên chứa siêu liên kết.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Cập nhật Siêu Liên Kết**
Thay đổi đích của một siêu liên kết hiện có. Sử dụng `HyperlinkManager` để sửa đổi văn bản đã chứa siêu liên kết, mô phỏng cách PowerPoint cập nhật siêu liên kết một cách an toàn.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên chứa siêu liên kết.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // Thay đổi siêu liên kết trong văn bản hiện có nên thực hiện qua
        // HyperlinkManager thay vì thiết lập thuộc tính trực tiếp.
        // Điều này mô phỏng cách PowerPoint cập nhật siêu liên kết một cách an toàn.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```