---
title: ActiveX
type: docs
weight: 200
url: /vi/php-java/examples/elements/activex/
keywords:
- ActiveX
- Điều khiển ActiveX
- thêm ActiveX
- truy cập ActiveX
- xóa ActiveX
- thuộc tính ActiveX
- ví dụ mã
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách tìm, chỉnh sửa và xóa các điều khiển ActiveX trong PHP bằng Aspose.Slides, bao gồm cập nhật thuộc tính cho các bản trình chiếu PowerPoint."
---
Minh họa cách thêm, truy cập, xóa và cấu hình các điều khiển ActiveX trong một bản trình chiếu bằng **Aspose.Slides for PHP via Java**.

## **Thêm một điều khiển ActiveX**

Chèn một điều khiển ActiveX mới.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Thêm một điều khiển ActiveX mới.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Giải phóng bản trình chiếu.
        $presentation->dispose();
    }
}
```

## **Truy cập một điều khiển ActiveX**

Đọc thông tin từ điều khiển ActiveX đầu tiên trên slide.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập điều khiển ActiveX đầu tiên.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Giải phóng bản trình chiếu.
        $presentation->dispose();
    }
}
```

## **Xóa một điều khiển ActiveX**

Xóa một điều khiển ActiveX hiện có khỏi slide.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Xóa điều khiển ActiveX đầu tiên.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Giải phóng bản trình chiếu.
        $presentation->dispose();
    }
}
```

## **Đặt thuộc tính ActiveX**

Cấu hình một số thuộc tính ActiveX.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử điều khiển đầu tiên là cái mà chúng ta đã thêm.
        $control = $slide->getControls()->get_Item(0);

        // Cấu hình các thuộc tính.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Giải phóng bản trình chiếu.
        $presentation->dispose();
    }
}
```