---
title: Quản lý các hình dạng trong bản trình chiếu bằng PHP
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/php-java/shape-manipulations/
keywords:
- hình dạng PowerPoint
- hình dạng bản trình chiếu
- hình dạng trên slide
- tìm hình dạng
- sao chép hình dạng
- xóa hình dạng
- ẩn hình dạng
- thay đổi thứ tự hình dạng
- lấy Interop shape ID
- văn bản thay thế cho hình dạng
- định dạng bố cục hình dạng
- hình dạng dưới dạng SVG
- hình dạng sang SVG
- căn chỉnh hình dạng
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách tạo, chỉnh sửa và tối ưu hóa các hình dạng trong Aspose.Slides cho PHP qua Java và cung cấp các bản trình chiếu PowerPoint hiệu năng cao."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các hình dạng trong bản trình chiếu bằng cách sử dụng Aspose.Slides. Nó trình bày cách tìm một hình dạng trên slide, sao chép nó, xóa nó, ẩn nó, thay đổi thứ tự, lấy Interop shape ID, và đặt văn bản thay thế để nhận dạng và xử lý tiếp theo. Nó cũng đề cập cách truy cập định dạng bố cục cho các hình dạng, render hình dạng dưới dạng SVG, căn chỉnh các hình dạng trên slide, và sử dụng các thuộc tính lật để phản chiếu ngang và dọc. Ngoài ra, bài viết còn bao gồm một phần Hỏi đáp ngắn về việc kết hợp hình dạng, thứ tự xếp chồng và khóa hình dạng.

## **Tìm một hình dạng trên slide**
Chủ đề này sẽ mô tả một kỹ thuật đơn giản giúp các nhà phát triển dễ dàng tìm một hình dạng cụ thể trên slide mà không cần sử dụng Id nội bộ của nó. Cần lưu ý rằng các tệp PowerPoint Presentation không có cách nào để xác định các hình dạng trên slide ngoài Id duy nhất nội bộ. Điều này khiến việc tìm một hình dạng bằng Id nội bộ trở nên khó khăn đối với các nhà phát triển. Tất cả các hình dạng được thêm vào slide đều có một số Alt Text. Chúng tôi đề xuất các nhà phát triển sử dụng văn bản thay thế để tìm một hình dạng cụ thể. Bạn có thể sử dụng MS PowerPoint để định nghĩa văn bản thay thế cho các đối tượng mà bạn dự định sẽ thay đổi trong tương lai.

Sau khi đặt văn bản thay thế cho bất kỳ hình dạng nào mong muốn, bạn có thể mở bản trình chiếu đó bằng Aspose.Slides for PHP via Java và lặp qua tất cả các hình dạng được thêm vào một slide. Trong mỗi vòng lặp, bạn có thể kiểm tra văn bản thay thế của hình dạng và hình dạng có văn bản thay thế khớp sẽ là hình dạng bạn cần. Để minh họa kỹ thuật này một cách tốt hơn, chúng tôi đã tạo một phương thức, [findShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) thực hiện việc tìm một hình dạng cụ thể trong slide và trả về hình dạng đó.

```php
  # Khởi tạo một lớp Presentation đại diện cho tệp bản trình chiếu
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Văn bản thay thế của hình dạng cần tìm
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Sao chép một hình dạng**
Để sao chép một hình dạng vào slide bằng Aspose.Slides for PHP via Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ số của nó.
1. Truy cập bộ sưu tập hình dạng của slide nguồn.
1. Thêm slide mới vào bản trình chiếu.
1. Sao chép các hình dạng từ bộ sưu tập hình dạng của slide nguồn sang slide mới.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Ví dụ bên dưới thêm một nhóm hình dạng vào slide.

```php
  # Khởi tạo lớp Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Ghi tệp PPTX vào đĩa
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xóa một hình dạng**
Aspose.Slides cho PHP via Java cho phép các nhà phát triển xóa bất kỳ hình dạng nào. Để xóa hình dạng khỏi bất kỳ slide nào, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Tìm hình dạng có AlternativeText cụ thể.
1. Xóa hình dạng.
1. Lưu tệp lên đĩa.

```php
  # Tạo đối tượng Presentation
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm autoshape loại hình chữ nhật
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Lưu bản trình chiếu vào đĩa
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ẩn một hình dạng**
Aspose.Slides cho PHP via Java cho phép các nhà phát triển ẩn bất kỳ hình dạng nào. Để ẩn hình dạng khỏi bất kỳ slide nào, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Tìm hình dạng có AlternativeText cụ thể.
1. Ẩn hình dạng.
1. Lưu tệp lên đĩa.

```php
  # Khởi tạo lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm autoshape loại hình chữ nhật
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Lưu bản trình chiếu vào đĩa
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thay đổi thứ tự hình dạng**
Aspose.Slides cho PHP via Java cho phép các nhà phát triển thay đổi thứ tự các hình dạng. Việc thay đổi thứ tự xác định hình dạng nào ở phía trước hoặc phía sau. Để thay đổi thứ tự hình dạng trên bất kỳ slide nào, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm một hình dạng.
1. Thêm một số văn bản vào khung văn bản của hình dạng.
1. Thêm một hình dạng khác với cùng tọa độ.
1. Thay đổi thứ tự các hình dạng.
1. Lưu tệp lên đĩa.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lấy Interop Shape ID**
Aspose.Slides cho PHP via Java cho phép các nhà phát triển lấy một định danh hình dạng duy nhất trong phạm vi slide, trái ngược với phương thức [getUniqueId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getuniqueid/) chỉ cho phép lấy định danh duy nhất trong phạm vi bản trình chiếu. Phương thức [getOfficeInteropShapeId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getofficeinteropshapeid/) đã được thêm vào lớp [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) tương ứng. Giá trị trả về bởi phương thức [getOfficeInteropShapeId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getofficeinteropshapeid/) tương ứng với giá trị Id của đối tượng Microsoft.Office.Interop.PowerPoint.Shape. Dưới đây là một đoạn mã mẫu.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Lấy định danh hình dạng duy nhất trong phạm vi slide
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt Văn bản Thay thế cho một Hình dạng**
Aspose.Slides cho PHP via Java cho phép các nhà phát triển đặt AlternateText của bất kỳ hình dạng nào. Các hình dạng trong bản trình chiếu có thể được phân biệt bằng `Alternative Text` hoặc phương thức [Shape Name](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/setname/). Các phương thức [setAlternativeText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/setalternativetext/) và [getAlternativeText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getalternativetext/) có thể được đọc hoặc ghi bằng Aspose.Slides cũng như Microsoft PowerPoint. Bằng cách sử dụng phương thức này, bạn có thể gắn thẻ một hình dạng và thực hiện các thao tác khác nhau như Xóa một hình dạng, Ẩn một hình dạng hoặc Thay đổi thứ tự các hình dạng trên slide. Để đặt AlternateText cho một hình dạng, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm bất kỳ hình dạng nào vào slide.
1. Thực hiện một số công việc với hình dạng vừa thêm.
1. Duyệt qua các hình dạng để tìm một hình dạng.
1. Đặt AlternativeText.
1. Lưu tệp lên đĩa.

```php
  # Khởi tạo lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm autoshape loại hình chữ nhật
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Lưu bản trình chiếu vào đĩa
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Truy cập Định dạng Bố cục cho một Hình dạng**
Aspose.Slides cho PHP via Java cung cấp một API đơn giản để truy cập định dạng bố cục cho một hình dạng. Bài viết này minh họa cách bạn có thể truy cập các định dạng bố cục.

Dưới đây là đoạn mã mẫu.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Render một Hình dạng dưới dạng SVG**
Bây giờ Aspose.Slides cho PHP via Java hỗ trợ render một hình dạng dưới dạng svg. Phương thức [writeAsSvg](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/writeassvg/) (và các overload của nó) đã được thêm vào lớp [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/). Phương thức này cho phép lưu nội dung của hình dạng dưới dạng tệp SVG. Đoạn mã dưới đây cho thấy cách xuất hình dạng của slide thành tệp SVG.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Căn chỉnh một Hình dạng**
Aspose.Slides cho phép căn chỉnh các hình dạng either relative to the slide margins or relative to each other. Để thực hiện mục tiêu này, phương thức nạp chồng [SlidesUtil::alignShapes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideutil/alignshapes/) đã được thêm vào. Phân loại [ShapesAlignmentType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapesalignmenttype/) định nghĩa các tùy chọn căn chỉnh khả dụng.

**Example 1**

Mã nguồn dưới đây căn chỉnh các hình dạng có chỉ số 1,2 và 4 dọc theo biên trên của slide.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Example 2**

Ví dụ dưới đây cho thấy cách căn toàn bộ bộ sưu tập hình dạng so với hình dạng dưới cùng trong bộ sưu tập.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thuộc tính Lật**

Trong Aspose.Slides, lớp [ShapeFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapeframe/) cung cấp khả năng kiểm soát việc phản chiếu ngang và dọc của các hình dạng thông qua các thuộc tính `flipH` và `flipV`. Cả hai thuộc tính đều có kiểu [NullableBool](https://reference.aspose.com/slides/vi/php-java/aspose.slides/nullablebool/), cho phép giá trị `True` để lật, `False` để không lật, hoặc `NotDefined` để sử dụng hành vi mặc định. Các giá trị này có thể truy cập từ [Frame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getFrame) của một hình dạng.

Để sửa đổi cài đặt lật, một thực thể mới của [ShapeFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapeframe/) được tạo ra với vị trí và kích thước hiện tại của hình dạng, các giá trị mong muốn cho `flipH` và `flipV`, và góc quay. Gán thực thể này cho [Frame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getFrame) của hình dạng và lưu bản trình chiếu sẽ áp dụng các phép biến đổi phản chiếu và ghi chúng vào tệp đầu ra.

Giả sử chúng ta có tệp sample.pptx trong đó slide đầu tiên chứa một hình dạng duy nhất với cài đặt lật mặc định, như hình dưới.

![Hình dạng cần lật](shape_to_be_flipped.png)

Đoạn mã sau đây lấy các thuộc tính lật hiện tại của hình dạng và lật nó cả theo chiều ngang và chiều dọc.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Lấy thuộc tính lật ngang của hình dạng.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Lấy thuộc tính lật dọc của hình dạng.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Lật ngang.
    $flipV = NullableBool::True; // Lật ngang.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hình dạng đã lật](flipped_shape.png)

## **FAQ**

**Can I combine shapes (union/intersect/subtract) on a slide like in a desktop editor?**  
Không có API thao tác Boolean tích hợp. Bạn có thể gần đúng bằng cách tự xây dựng đường viền mong muốn—ví dụ, tính toán hình học kết quả (via [GeometryPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometrypath/)) và tạo một hình dạng mới với đường viền đó, tùy chọn loại bỏ các hình dạng gốc.

**How can I control the stacking order (z-order) so a shape always stays "on top"?**  
Thay đổi thứ tự chèn/di chuyển trong bộ sưu tập [shapes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslide/#getShapes) của slide. Để có kết quả dự đoán được, hoàn thiện z-order sau khi thực hiện tất cả các sửa đổi khác trên slide.

**Can I "lock" a shape to prevent users from editing it in PowerPoint?**  
Có. Đặt các cờ bảo vệ ở mức hình dạng (ví dụ: khóa chọn, di chuyển, thay đổi kích thước, chỉnh sửa văn bản). Nếu cần, có thể áp dụng hạn chế trên master hoặc layout. Lưu ý đây là bảo vệ ở mức giao diện người dùng, không phải tính năng bảo mật; để bảo vệ mạnh hơn, kết hợp với các hạn chế ở mức tệp như khuyến nghị chỉ đọc hoặc mật khẩu ([read-only recommendations or passwords](/slides/vi/php-java/password-protected-presentation/)).