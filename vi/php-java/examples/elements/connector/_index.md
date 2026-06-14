---
title: Kết nối
type: docs
weight: 190
url: /vi/php-java/examples/elements/connector/
keywords:
- kết nối
- thêm kết nối
- truy cập kết nối
- xóa kết nối
- kết nối lại các hình dạng
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Vẽ và điều khiển các connector trong PHP với Aspose.Slides: thêm, định tuyến, thay đổi tuyến, thiết lập các điểm kết nối, mũi tên và kiểu dáng để liên kết các hình dạng trong PPT, PPTX và ODP."
---
Hiển thị cách kết nối các hình dạng với các connector và thay đổi mục tiêu của chúng bằng **Aspose.Slides for PHP via Java**.

## **Thêm một Connector**

Chèn một hình dạng connector giữa hai điểm trên slide.

```php
function addConnector() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $connector = $slide->Shapes->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $presentation->save("connector.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập một Connector**

Lấy hình dạng connector đầu tiên được thêm vào slide.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập connector đầu tiên trên slide.
        $firstConnector = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $firstConnector = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa một Connector**

Xóa một connector khỏi slide.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử shape đầu tiên trên slide là một connector.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Kết nối lại các hình dạng**

Gắn một connector vào hai hình dạng bằng cách gán mục tiêu bắt đầu và kết thúc.

```php
function reconnectShapes() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
        $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $connector->setStartShapeConnectedTo($shape1);
        $connector->setEndShapeConnectedTo($shape2);

        $presentation->save("shapes_reconnected.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```