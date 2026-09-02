---
title: Định dạng các hình dạng PowerPoint trong PHP
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/php-java/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường
- hiệu ứng vẽ tay
- đường viền hình dạng vẽ tay
- định dạng kiểu nối
- đổ màu gradient
- đổ màu pattern
- đổ ảnh
- đổ kết cấu
- đổ màu đặc
- độ trong suốt hình dạng
- xoay hình dạng
- hiệu ứng bevel 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong PHP bằng Aspose.Slides—đặt các kiểu tô, đường viền và hiệu ứng cho tệp PPT, PPTX và ODP một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách chỉnh sửa hoặc áp dụng hiệu ứng cho viền của chúng. Ngoài ra, bạn cũng có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách nội dung bên trong được tô màu.

![định dạng hình dạng PowerPoint](format-shape-powerpoint.png)

Aspose.Slides cho PHP thông qua Java cung cấp các lớp và phương thức cho phép bạn định dạng các hình dạng bằng những tùy chọn có sẵn trong PowerPoint.

## **Định dạng Đường**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [định dạng đường viền](https://reference.aspose.com/slides/vi/php-java/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng của đường viền.
1. Đặt [dash style](https://reference.aspose.com/slides/vi/php-java/aspose.slides/linedashstyle/) cho đường viền.
1. Đặt màu đường viền cho hình dạng.
1. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape loại Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Đặt màu tô cho hình dạng rectangle.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Áp dụng định dạng cho các đường của rectangle.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Đặt màu cho đường của rectangle.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Các đường viền được định dạng trong bản trình bày](formatted-lines.png)

## **Áp dụng hiệu ứng Sketch cho Đường viền Hình dạng**

Hiệu ứng sketch làm cho đường viền của hình dạng trông như vẽ tay. Sử dụng [Shape.getLineFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) để truy cập cài đặt đường viền, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/lineformat/) để truy cập cài đặt sketch, và [SketchFormat.setSketchType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sketchformat/) để chọn một giá trị từ liệt kê [LineSketchType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/linesketchtype/).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Truy cập định dạng đường viền của hình dạng và định dạng sketch của nó.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Áp dụng hiệu ứng sketch.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Đọc hiệu ứng sketch được gán trực tiếp cho hình dạng.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Xóa bỏ hiệu ứng sketch.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Giá trị trả về bởi [SketchFormat.getSketchType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sketchformat/) đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường viền có thể được kế thừa từ chủ đề, slide chủ hoặc slide bố cục, hãy sử dụng [LineFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/lineformat/), truy cập phương thức `getSketchFormat` của đối tượng trả về, và đọc giá trị `getSketchType` của nó. Giá trị hiệu quả phản ánh định dạng thực sự được áp dụng sau khi kế thừa được giải quyết:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Định dạng Kiểu Nối**

Dưới đây là ba tùy chọn kiểu nối:

* Tròn
* Mũi
* Vát

Mặc định, khi PowerPoint nối hai đường ở một góc (như ở góc của một hình dạng), nó sử dụng cài đặt **Tròn**. Tuy nhiên, nếu bạn đang vẽ một hình dạng với các góc nhọn, bạn có thể muốn chọn tùy chọn **Mũi**.

![Kiểu nối trong bản trình bày](join-style-powerpoint.png)

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm ba auto shape loại Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Đặt màu tô cho mỗi hình chữ nhật.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Đặt độ rộng đường viền.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Đặt màu cho đường viền của mỗi hình chữ nhật.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Đặt kiểu nối.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Thêm văn bản vào mỗi hình chữ nhật.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đổ màu Gradient**

Trong PowerPoint, Đổ màu Gradient là một tùy chọn định dạng cho phép bạn áp dụng sự pha trộn liên tục của các màu lên một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần dần chuyển sang màu khác.

Cách áp dụng Đổ màu Gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu bạn muốn với vị trí đã định nghĩa bằng các phương thức `add` của bộ sưu tập gradient stop được khai thác bởi lớp [GradientFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/gradientformat/) .
1. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape loại Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Áp dụng định dạng gradient cho ellipse.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Đặt hướng cho gradient.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Thêm hai điểm dừng gradient.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Ellipse với đổ màu gradient](gradient-fill.png)

## **Đổ màu Pattern**

Trong PowerPoint, Đổ màu Pattern là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, chéo hay ô vuông—cho một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền và màu nền trước của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định nghĩa sẵn mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bản trình bày. Ngay cả sau khi chọn một mẫu được định nghĩa sẵn, bạn vẫn có thể chỉ định màu chính xác mà nó sẽ sử dụng.

Cách áp dụng Đổ màu Pattern cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn kiểu mẫu từ các tùy chọn được định nghĩa sẵn.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/php-java/aspose.slides/patternformat/#getBackColor) cho nền mẫu.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/php-java/aspose.slides/patternformat/#getForeColor) cho màu nền trước của mẫu.
1. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape loại Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Đặt kiểu tô thành Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Đặt kiểu mẫu.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Đặt màu nền và màu nền trước của mẫu.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hình chữ nhật với đổ mẫu](pattern-fill.png)

## **Đổ ảnh**

Trong PowerPoint, Đổ ảnh là một tùy chọn định dạng cho phép bạn chèn một hình ảnh bên trong một hình dạng—thực chất sử dụng hình ảnh làm nền cho hình dạng.

Cách sử dụng Aspose.Slides để áp dụng Đổ ảnh cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ đổ ảnh thành `Tile` (hoặc chế độ khác bạn thích).
1. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) từ hình ảnh bạn muốn dùng.
1. Truyền hình ảnh vào phương thức `SlidesPicture.setImage`.

![Hình ảnh bồ đề](lotus.png)

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape loại Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Đặt kiểu tô thành Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Đặt chế độ đổ ảnh.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Tải ảnh và thêm vào tài nguyên của bản trình bày.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Đặt ảnh.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hình dạng với đổ ảnh](picture-fill.png)

### **Đặt ảnh lặp lại làm kết cấu**

Nếu bạn muốn đặt một ảnh lặp lại làm kết cấu và tùy chỉnh hành vi lặp, bạn có thể sử dụng các phương thức sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Đặt chế độ đổ ảnh—hoặc `Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileAlignment): Xác định vị trí căn chỉnh của các ô trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileFlip): Kiểm soát việc lật ô theo chiều ngang, chiều dọc hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Đặt khoảng dịch ngang của ô (theo điểm) so với nguồn của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Đặt khoảng dịch dọc của ô (theo điểm) so với nguồn của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileScaleX): Xác định tỷ lệ ngang của ô dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileScaleY): Xác định tỷ lệ dọc của ô dưới dạng phần trăm.

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape hình chữ nhật.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Đặt kiểu tô của hình dạng thành Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Tải ảnh và thêm vào tài nguyên của bản trình bày.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Gán ảnh cho hình dạng.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Cấu hình chế độ đổ ảnh và các thuộc tính lặp.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Các tùy chọn ô](tile-options.png)

## **Đổ màu Đặc**

Trong PowerPoint, Đổ màu Đặc là một tùy chọn định dạng làm đầy một hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn này được áp dụng mà không có gradient, kết cấu hay mẫu nào.

Để áp dụng Đổ màu Đặc cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu tô mà bạn muốn cho hình dạng.
1. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

```php
    // Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
    $presentation = new Presentation();
    try {
        // Lấy slide đầu tiên.
        $slide = $presentation->getSlides()->get_Item(0);

        // Thêm một auto shape loại Rectangle.
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

        // Đặt kiểu tô thành Solid.
        $shape->getFillFormat()->setFillType(FillType::Solid);

        // Đặt màu tô.
        $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

        // Lưu tệp PPTX vào đĩa.
        $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
```

![Hình dạng với đổ màu đặc](solid-color-fill.png)

## **Đặt trong suốt**

Trong PowerPoint, khi bạn áp dụng màu đặc, gradient, ảnh hoặc kết cấu cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của phần tô. Giá trị trong suốt cao hơn làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng phía dưới hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức trong suốt bằng cách điều chỉnh giá trị alpha trong màu được dùng để tô. Cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát mức trong suốt).
1. Lưu bản trình bày.

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape hình chữ nhật đặc.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Thêm một auto shape hình chữ nhật trong suốt phía trên hình dạng đặc.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong các bản trình bày PowerPoint. Điều này hữu ích khi định vị các yếu tố trực quan với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
1. Lưu bản trình bày.

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape loại Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Xoay hình dạng 5 độ.
    $shape->setRotation(5);

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Xoay hình dạng](shape-rotation.png)

## **Thêm hiệu ứng 3D Bevel**

Aspose.Slides cho phép bạn áp dụng hiệu ứng 3D Bevel cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/) của chúng.

Để thêm hiệu ứng 3D Bevel cho một hình dạng, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/) của hình dạng để định nghĩa các cài đặt bevel.
1. Lưu bản trình bày.

```php
// Khởi tạo một thể hiện của lớp Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một hình dạng vào slide.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Đặt các thuộc tính ThreeDFormat của hình dạng.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Lưu bản trình bày dưới dạng tệp PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hiệu ứng 3D bevel](3D-bevel-effect.png)

## **Thêm hiệu ứng xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/) của chúng.

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Sử dụng [setCameraType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/camera/#setCameraType) và [setLightType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/lightrig/#setLightType) để định nghĩa xoay 3D.
1. Lưu bản trình bày.

```php
// Khởi tạo một thể hiện của lớp Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Lưu bản trình bày dưới dạng tệp PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Đặt lại Định dạng**

Mã Java sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/) về cài đặt mặc định:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Đặt lại mỗi hình dạng trên slide có placeholder trên layout.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình bày không?**

Chỉ rất ít. Ảnh và phương tiện nhúng chiếm phần lớn dung lượng tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng siêu dữ liệu và hầu như không làm tăng kích thước.

**Làm thế nào tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để tôi có thể nhóm chúng?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là cùng một kiểu và nhóm logic các hình dạng đó, giúp việc quản lý kiểu sau này trở nên đơn giản hơn.

**Tôi có thể lưu một bộ kiểu hình dạng tùy chỉnh vào một tệp riêng để sử dụng lại trong các bản trình bày khác không?**

Có. Lưu các hình mẫu với các kiểu mong muốn vào một slide mẫu hoặc tệp mẫu .POTX. Khi tạo bản trình bày mới, mở mẫu, sao chép các hình dạng đã định dạng mà bạn cần và áp dụng lại định dạng của chúng ở bất kỳ nơi nào cần thiết.