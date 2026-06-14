---
title: Nhóm các hình dạng trình chiếu trong PHP
linktitle: Nhóm Hình
type: docs
weight: 40
url: /vi/php-java/group/
keywords:
- nhóm hình
- hình nhóm
- thêm nhóm
- văn bản thay thế
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Học cách nhóm và bỏ nhóm các hình trong bộ trình chiếu PowerPoint bằng Aspose.Slides cho PHP qua Java — hướng dẫn nhanh, từng bước với mã nguồn miễn phí."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các group shape trong Aspose.Slides. Nó cho thấy cách thêm một group shape vào slide, đặt các shape bên trong và lưu bản trình bày đã cập nhật. Ngoài ra, bài viết còn trình bày cách truy cập các shape lưu trong một group và đọc giá trị `AlternativeText` của chúng. Thêm vào đó, bài viết ngắn gọn đề cập đến các khả năng liên quan đến group‑shape như nhóm lồng nhau, thứ tự z‑order và các tùy chọn khóa.

## **Thêm một Group Shape**
Aspose.Slides hỗ trợ làm việc với group shape trên các slide. Tính năng này giúp các nhà phát triển tạo ra các bản trình bày phong phú hơn. Aspose.Slides for PHP via Java hỗ trợ việc thêm hoặc truy cập các group shape. Bạn có thể thêm các shape vào một group shape đã tạo để lấp đầy nó hoặc truy cập bất kỳ thuộc tính nào của group shape. Để thêm một group shape vào slide bằng Aspose.Slides for PHP via Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Lấy tham chiếu của slide bằng cách sử dụng Index của nó
1. Thêm một group shape vào slide.
1. Thêm các shape vào group shape đã thêm.
1. Lưu bản trình bày đã sửa đổi dưới dạng file PPTX.

Ví dụ bên dưới thêm một group shape vào slide.

```php
  # Tạo instance của lớp Presentation
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Truy cập bộ sưu tập shape của các slide
    $slideShapes = $sld->getShapes();
    # Thêm một group shape vào slide
    $groupShape = $slideShapes->addGroupShape();
    # Thêm các shape vào bên trong group shape đã thêm
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Thêm khung cho group shape
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Ghi file PPTX vào đĩa
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Truy cập thuộc tính AltText**
Chủ đề này trình bày các bước đơn giản, kèm theo ví dụ mã, để thêm một group shape và truy cập thuộc tính AltText của các group shape trên slide. Để truy cập AltText của một group shape trong slide bằng Aspose.Slides for PHP via Java:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) đại diện cho file PPTX.
1. Lấy tham chiếu của slide bằng cách sử dụng Index của nó.
1. Truy cập bộ sưu tập shape của các slide.
1. Truy cập group shape.
1. Truy cập thuộc tính [Alternative Text](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getAlternativeText).

Ví dụ bên dưới truy cập văn bản thay thế của group shape.

```php
  # Tạo instance của lớp Presentation đại diện cho file PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Truy cập bộ sưu tập shape của các slide
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Truy cập group shape.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Truy cập thuộc tính AltText
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Liệu việc nhóm lồng nhau (một nhóm bên trong một nhóm) có được hỗ trợ không?**

Có. [GroupShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/groupshape/) có phương thức [getParentGroup](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getparentgroup/) trực tiếp cho thấy hỗ trợ cấu trúc phân cấp (một nhóm có thể là con của một nhóm khác).

**Làm sao tôi có thể kiểm soát z‑order của nhóm so với các đối tượng khác trên slide?**

Sử dụng phương thức [getZOrderPosition](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getzorderposition/) của [GroupShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/groupshape/) để kiểm tra vị trí của nó trong ngăn xếp hiển thị.

**Tôi có thể ngăn việc di chuyển/chỉnh sửa/ungroup không?**

Có. Phần khóa của nhóm được mở ra qua [GroupShapeLock](https://reference.aspose.com/slides/vi/php-java/aspose.slides/groupshape/getgroupshapelock/), cho phép bạn hạn chế các thao tác trên đối tượng.