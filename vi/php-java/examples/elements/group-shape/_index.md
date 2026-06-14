---
title: GroupShape
type: docs
weight: 170
url: /vi/php-java/examples/elements/group-shape/
keywords:
- nhóm
- thêm hình nhóm
- truy cập hình nhóm
- xóa hình nhóm
- tách nhóm các hình
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Làm việc với các hình nhóm trong PHP bằng Aspose.Slides: tạo và tách nhóm, sắp xếp lại các hình con, thiết lập biến đổi và giới hạn trong PowerPoint và OpenDocument."
---
Các ví dụ về việc tạo nhóm các hình dạng, truy cập chúng, tách nhóm và xóa bỏ bằng **Aspose.Slides for PHP via Java**.

## **Thêm Hình Nhóm**

Tạo một nhóm chứa hai hình dạng cơ bản.

```php
function addGroupShape() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $group = $slide->getShapes()->addGroupShape();
        $group->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $group->getShapes()->addAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

        $presentation->save("group_shape.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập Hình Nhóm**

Lấy hình nhóm đầu tiên từ một slide.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập hình nhóm đầu tiên trên slide.
        $firstGroup = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $firstGroup = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa Hình Nhóm**

Xóa một hình nhóm khỏi slide.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Giả sử hình đầu tiên trên slide là một hình nhóm.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Bỏ Nhóm Các Hình**

Di chuyển các hình ra khỏi container nhóm.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình đầu tiên trên slide là một hình nhóm.
        $group = $slide->getShapes()->get_Item(0);

        // Sao chép mỗi hình từ nhóm và thêm nó vào slide.
        $shapeCount = java_values($group->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $group->getShapes()->get_Item($index);
            $slide->getShapes()->addClone($shape);
        }

        $slide->getShapes()->remove($group);

        $presentation->save("ungrouped_shapes.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```