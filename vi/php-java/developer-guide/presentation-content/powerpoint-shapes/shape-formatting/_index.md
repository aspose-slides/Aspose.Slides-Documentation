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
- đường hình dạng vẽ tay
- định dạng kiểu nối
- đổ màu gradient
- đổ mẫu
- đổ hình ảnh
- đổ texture
- đổ màu đồng nhất
- độ trong suốt hình dạng
- hiển thị hình dạng đen-trắng
- hiển thị hình dạng thang xám
- xoay hình dạng
- hiệu ứng Bo 3D
- hiệu ứng Xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong PHP bằng Aspose.Slides—đặt kiểu tô, đường viền và hiệu ứng cho các tệp PPT, PPTX và ODP một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách chỉnh sửa hoặc áp dụng hiệu ứng cho viền của chúng. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách nội bên trong được tô màu.

![định dạng hình dạng PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java cung cấp các lớp và phương thức cho phép bạn định dạng hình dạng bằng các tùy chọn có sẵn trong PowerPoint.

## **Định dạng Đường**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [line style](https://reference.aspose.com/slides/vi/php-java/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng đường.
1. Đặt [dash style](https://reference.aspose.com/slides/vi/php-java/aspose.slides/linedashstyle/) cho đường.
1. Đặt màu đường cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa thành tệp PPTX.

Đoạn mã PHP sau minh họa cách định dạng một `AutoShape` hình chữ nhật:

```php
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape loại Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Đặt màu tô cho hình dạng hình chữ nhật.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Áp dụng định dạng cho các đường của hình chữ nhật.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Đặt màu cho đường của hình chữ nhật.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Các đường đã định dạng trong bản trình chiếu](formatted-lines.png)

## **Áp dụng Hiệu ứng Sketch cho Đường của Hình dạng**

Hiệu ứng sketch làm cho đường của hình dạng trông như được vẽ tay. Sử dụng [Shape.getLineFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) để truy cập cài đặt đường, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/lineformat/) để truy cập cài đặt sketch, và [SketchFormat.setSketchType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sketchformat/) để chọn một giá trị từ enum [LineSketchType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/linesketchtype/).

Đoạn mã PHP sau cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/vi/php-java/aspose.slides/linesketchtype/), đọc giá trị đã gán trực tiếp, và loại bỏ hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/vi/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Truy cập định dạng đường của hình dạng và định dạng sketch của nó.
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

Giá trị trả về bởi [SketchFormat.getSketchType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sketchformat/) đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide chủ, hoặc slide bố cục, hãy sử dụng [LineFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/lineformat/), truy cập phương thức `getSketchFormat` của đối tượng trả về, và đọc giá trị `getSketchType` của nó. Giá trị hiệu quả phản ánh định dạng thực sự được áp dụng sau khi kế thừa được giải quyết:

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

* Round → Tròn
* Miter → Mối
* Bevel → Đầu Vát

Mặc định, khi PowerPoint nối hai đường ở một góc (ví dụ tại góc của hình dạng), nó sử dụng cài đặt **Round**. Tuy nhiên, nếu bạn đang vẽ một hình dạng có các góc nhọn, bạn có thể ưu tiên tùy chọn **Miter**.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Đoạn mã PHP sau minh họa cách ba hình chữ nhật (như trong hình trên) được tạo bằng các cài đặt kiểu nối Miter, Bevel và Round:

```php
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
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

    // Đặt độ rộng đường.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Đặt màu cho đường của mỗi hình chữ nhật.
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

Trong PowerPoint, Gradient Fill là một tùy chọn định dạng cho phép bạn áp dụng một sự pha trộn liên tục của các màu lên một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần dần chuyển sang màu khác.

Cách áp dụng Gradient Fill cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu ưa thích của bạn với vị trí được xác định bằng các phương thức `add` của bộ sưu tập gradient stop được cung cấp bởi lớp [GradientFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/gradientformat/) .
1. Lưu bản trình chiếu đã chỉnh sửa thành tệp PPTX.

Đoạn mã PHP sau minh họa cách áp dụng hiệu ứng Gradient Fill cho một hình ellipse:

```php
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape loại Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Áp dụng định dạng gradient cho ellipse.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Đặt hướng của gradient.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Thêm hai gradient stop.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Ellipse với màu gradient](gradient-fill.png)

## **Đổ mẫu**

Trong PowerPoint, Pattern Fill là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, vằn chéo, hoặc kẻ ô—cho một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền trước và nền sau của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định nghĩa sẵn mà bạn có thể áp dụng cho hình dạng để tăng tính thẩm mỹ cho bản trình chiếu. Ngay cả khi đã chọn một mẫu đã định nghĩa, bạn vẫn có thể chỉ định màu chính xác mà nó sẽ sử dụng.

Cách áp dụng Pattern Fill cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn một kiểu mẫu từ các tùy chọn được định nghĩa sẵn.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/php-java/aspose.slides/patternformat/#getBackColor) của mẫu.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/php-java/aspose.slides/patternformat/#getForeColor) của mẫu.
1. Lưu bản trình chiếu đã chỉnh sửa thành tệp PPTX.

Đoạn mã PHP sau minh họa cách áp dụng Pattern Fill cho một hình chữ nhật:

```php
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape loại Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Đặt loại tô thành Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Đặt kiểu mẫu.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Đặt màu nền và màu tiền nền của mẫu.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hình chữ nhật với mẫu tô](pattern-fill.png)

## **Đổ hình ảnh**

Trong PowerPoint, Picture Fill là một tùy chọn định dạng cho phép bạn chèn một hình ảnh bên trong một hình dạng—hiệu quả như việc sử dụng hình ảnh làm nền cho hình dạng.

Cách sử dụng Aspose.Slides để áp dụng Picture Fill cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ Picture Fill thành `Tile` (hoặc chế độ khác ưa thích).
1. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) từ hình ảnh bạn muốn sử dụng.
1. Đưa hình ảnh vào phương thức `SlidesPicture.setImage` .
1. Lưu bản trình chiếu đã chỉnh sửa thành tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình ảnh hoa sen](lotus.png)

Đoạn mã PHP sau minh họa cách đổ hình ảnh vào một hình dạng:

```php
    // Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
    $presentation = new Presentation();
    try {
        // Lấy slide đầu tiên.
        $slide = $presentation->getSlides()->get_Item(0);
    
        // Thêm một auto shape loại Rectangle.
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    
        // Đặt loại tô thành Picture.
        $shape->getFillFormat()->setFillType(FillType::Picture);
    
        // Đặt chế độ Picture Fill.
        $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);
    
        // Tải một hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
        $image = Images::fromFile("lotus.png");
        $picture = $presentation->getImages()->addImage($image);
        $image->dispose();
    
        // Đặt hình ảnh.
        $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    
        // Lưu tệp PPTX vào đĩa.
        $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
```

Kết quả:

![Hình dạng với màu đổ hình ảnh](picture-fill.png)

### **Lát Hình ảnh làm Texture**

Nếu bạn muốn đặt một hình ảnh lặp lại làm texture và tùy chỉnh hành vi lặp, bạn có thể sử dụng các phương thức sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Đặt chế độ Picture Fill—`Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileAlignment): Xác định căn chỉnh của các ô trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileFlip): Kiểm soát việc lật ô theo chiều ngang, chiều dọc hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Đặt độ dịch chuyển ngang của ô (theo điểm) so với gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Đặt độ dịch chuyển dọc của ô (theo điểm) so với gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileScaleX): Xác định tỉ lệ ngang của ô dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileScaleY): Xác định tỉ lệ dọc của ô dưới dạng phần trăm.

Đoạn mẫu mã sau cho thấy cách thêm một hình chữ nhật với Picture Fill dạng lặp và cấu hình các tùy chọn lặp:

```php
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape loại Rectangle.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Đặt loại tô của hình dạng thành Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Tải hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Gán hình ảnh cho hình dạng.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Cấu hình chế độ Picture Fill và các thuộc tính lặp.
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

Kết quả:

![Các tùy chọn lát](tile-options.png)

## **Đổ màu Đặc**

Trong PowerPoint, Solid Color Fill là một tùy chọn định dạng để tô một hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn giản này được áp dụng mà không có gradient, texture hay mẫu nào.

Để áp dụng Solid Color Fill cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu tô ưa thích của bạn cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa thành tệp PPTX.

Đoạn mã PHP sau minh họa cách áp dụng Solid Color Fill cho một hình chữ nhật trong slide PowerPoint:

```php
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape loại Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Đặt loại tô thành Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Đặt màu tô.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hình dạng với màu đổ đặc](solid-color-fill.png)

## **Đặt Độ trong suốt**

Trong PowerPoint, khi bạn áp dụng màu đặc, gradient, hình ảnh hoặc texture Fill cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của màu tô. Giá trị trong suốt cao hơn làm cho hình dạng càng trong suốt, cho phép nền hoặc các đối tượng phía sau hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được dùng để tô. Cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
1. Lưu bản trình chiếu.

Đoạn mã PHP sau minh họa cách áp dụng màu tô trong suốt cho một hình chữ nhật:

```php
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape hình chữ nhật đặc.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Thêm một auto shape hình chữ nhật trong suốt lên trên hình dạng đặc.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi bố trí các yếu tố trực quan với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

Đoạn mã PHP sau minh họa cách xoay một hình dạng 5 độ:

```php
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
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

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu ứng Bo 3D**

Aspose.Slides cho phép bạn áp dụng các hiệu ứng Bo 3D cho hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/) của chúng.

Để thêm hiệu ứng Bo 3D cho một hình dạng, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/) của hình dạng để định nghĩa các thiết lập Bo.
1. Lưu bản trình chiếu.

Đoạn mã PHP sau cho thấy cách áp dụng hiệu ứng Bo 3D cho một hình dạng:

```php
// Tạo một thể hiện của lớp Presentation.
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

    // Lưu bản trình chiếu dưới dạng tệp PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hiệu ứng Bo 3D](3D-bevel-effect.png)

## **Thêm Hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng các hiệu ứng Xoay 3D cho hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/) của chúng.

Để áp dụng Xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Sử dụng [setCameraType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/camera/#setCameraType) và [setLightType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/lightrig/#setLightType) để định nghĩa xoay 3D.
1. Lưu bản trình chiếu.

Đoạn mã PHP sau minh họa cách áp dụng hiệu ứng Xoay 3D cho một hình dạng:

```php
// Tạo một thể hiện của lớp Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Lưu bản trình chiếu dưới dạng tệp PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hiệu ứng Xoay 3D](3D-rotation-effect.png)

## **Kiểm soát Hiển thị Đen-Trắng cho Hình dạng**

Phương thức [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#setBlackWhiteMode) xác định cách một hình dạng riêng lẻ được hiển thị khi bản trình chiếu được xem hoặc xử lý ở chế độ đen-trắng. Phương thức này không kích hoạt chế độ đen-trắng tự động và không thay đổi màu nền, đường viền hoặc các định dạng khác trong chế độ màu bình thường.

Sử dụng một giá trị từ lớp [BlackWhiteMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` để ứng dụng chuyển đổi, `Gray` và `LightGray` dùng màu xám, `BlackWhite` chỉ dùng đen và trắng, `Black` và `White` buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` ẩn hình dạng trong chế độ đen-trắng. `NotDefined` nghĩa là không có chế độ cấp mức cho hình dạng.

Đoạn mã PHP sau tạo một hình dạng màu và khiến nó hiển thị màu xám trong chế độ hiển thị đen-trắng:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // Giữ màu tô cam trong chế độ màu, nhưng hiển thị hình dạng với màu xám trong chế độ đen-trắng.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Trong chế độ màu bình thường, hình chữ nhật vẫn giữ màu nền cam. Trong quy trình hiển thị đen-trắng, nó dùng màu xám vì chế độ đã được đặt thành `Gray`. Điều này cho phép bạn giữ slide đầy màu trong khi định nghĩa cách hiển thị riêng cho in ấn, xem trước hoặc các quy trình khác tôn trọng cài đặt hiển thị đen-trắng của bản trình chiếu.

## **Đặt lại Định dạng**

Đoạn mã Java sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/) về trạng thái mặc định:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Đặt lại mỗi hình dạng trên slide có placeholder trên bố cục.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Việc định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình chiếu không?**

Chỉ ảnh hưởng rất ít. Các ảnh và media nhúng chiếm phần lớn không gian tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng metadata và thực tế không làm tăng kích thước đáng kể.

**Làm thế nào để phát hiện các hình dạng trên một slide có cùng định dạng để tôi có thể nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng — cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là cùng một kiểu và nhóm logic các hình dạng đó, giúp việc quản lý kiểu sau này trở nên đơn giản hơn.

**Tôi có thể lưu một tập hợp các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu với các kiểu mong muốn trong một slide mẫu hoặc tệp .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình dạng đã định dạng cần thiết và áp dụng lại định dạng của chúng ở bất kỳ nơi nào cần.