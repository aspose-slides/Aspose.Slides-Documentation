---
title: Định dạng hình dạng PowerPoint trong PHP
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/php-java/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường
- hiệu ứng phác thảo
- đường viền hình dạng phác thảo
- định dạng kiểu nối
- đổ màu gradient
- đổ mẫu
- đổ hình ảnh
- đổ kết cấu
- đổ màu đơn
- trong suốt hình dạng
- hiển thị hình dạng đen-trắng
- hiển thị hình dạng thang độ xám
- xoay hình dạng
- hiệu ứng chân đế 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong PHP bằng Aspose.Slides—đặt các kiểu tô, đường viền và hiệu ứng cho tệp PPT, PPTX và ODP một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách sửa đổi hoặc áp dụng hiệu ứng cho đường viền của chúng. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách phần bên trong của chúng được tô màu.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java cung cấp các lớp và phương thức cho phép bạn định dạng các hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [line style](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng của đường.
1. Đặt [dash style](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) của đường.
1. Đặt màu đường cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP sau minh họa cách định dạng một `AutoShape` hình chữ nhật:

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape loại Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Đặt màu tô cho hình chữ nhật.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Áp dụng định dạng cho các đường của hình chữ nhật.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Đặt màu cho đường viền của hình chữ nhật.
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

## **Áp dụng Hiệu ứng Phác thảo cho Đường viền Hình**

Hiệu ứng phác thảo làm cho đường viền của hình dạng trông như được vẽ tay. Sử dụng [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) để truy cập các cài đặt đường, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) để truy cập các cài đặt phác thảo, và [SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) để chọn một giá trị từ enumeration [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Mã PHP sau cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/), đọc giá trị được gán một cách rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Truy cập định dạng đường của hình và định dạng phác thảo của nó.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Áp dụng hiệu ứng phác thảo.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Đọc hiệu ứng phác thảo được gán trực tiếp cho hình.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Xóa bỏ hiệu ứng phác thảo.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Giá trị trả về bởi [SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide máster hoặc slide bố cục, hãy sử dụng [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/), truy cập phương thức `getSketchFormat` của đối tượng trả về, và đọc giá trị `getSketchType` của nó. Giá trị hiệu quả phản ánh định dạng thực tế được áp dụng sau khi kế thừa được giải quyết:

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
* Góc nhọn
* Góc xiên

Mặc định, khi PowerPoint nối hai đường ở một góc (chẳng hạn ở góc của một hình dạng), nó sử dụng cài đặt **Tròn**. Tuy nhiên, nếu bạn đang vẽ một hình dạng với các góc sắc, bạn có thể ưu tiên tùy chọn **Góc nhọn**.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Mã PHP sau minh họa cách ba hình chữ nhật (như trong hình trên) được tạo bằng các cài đặt kiểu nối Miter, Bevel và Round:

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
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

Trong PowerPoint, Đổ màu Gradient là một tùy chọn định dạng cho phép bạn áp dụng một sự pha trộn liên tục của các màu vào một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần chuyển sang màu khác.

Cách áp dụng đổ màu gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu bạn ưa thích kèm vị trí đã định nghĩa bằng các phương thức `add` của bộ sưu tập gradient stop được mở ra bởi lớp [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/).
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP sau minh họa cách áp dụng hiệu ứng đổ màu gradient cho một ellipse:

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
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

    // Thêm hai điểm dừng gradient.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hình ellipse với đổ màu gradient](gradient-fill.png)

Nếu một gradient trông khác trong hình ảnh được xuất so với trong PowerPoint, xem [Choose a Gradient Rendering Style](/slides/vi/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Bạn có thể chọn kiểu hiển thị mà không thay đổi gradient được lưu trong bản trình chiếu.

## **Đổ mẫu**

Trong PowerPoint, Đổ mẫu là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, vạch chéo, hoặc ô vuông—vào một hình dạng. Bạn có thể chọn màu tùy chỉnh cho tiền cảnh và nền của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định sẵn mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bản trình chiếu. Ngay cả sau khi chọn một mẫu đã định sẵn, bạn vẫn có thể chỉ định chính xác các màu mà nó sẽ sử dụng.

Cách áp dụng đổ mẫu cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn một kiểu mẫu từ các tùy chọn đã định sẵn.
1. Đặt [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) của mẫu.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) của mẫu.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP sau minh họa cách áp dụng đổ mẫu cho một hình chữ nhật:

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
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

    // Đặt màu nền và màu tiền cảnh của mẫu.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hình chữ nhật với đổ mẫu](pattern-fill.png)

## **Đổ Hình ảnh**

Trong PowerPoint, Đổ hình ảnh là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng—đúng như việc sử dụng hình ảnh làm nền cho hình dạng.

Cách sử dụng Aspose.Slides để áp dụng đổ hình ảnh cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ đổ hình ảnh thành `Tile` (hoặc chế độ ưa thích khác).
1. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) từ hình ảnh bạn muốn sử dụng.
1. Truyền hình ảnh vào phương thức `SlidesPicture.setImage`.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình lotus](lotus.png)

Mã PHP sau minh họa cách đổ hình ảnh vào một hình dạng:

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape loại Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Đặt kiểu tô thành Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Đặt chế độ đổ hình ảnh.
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

![Hình dạng với đổ hình ảnh](picture-fill.png)

### **Lát Hình ảnh làm Kết cấu**

Nếu bạn muốn đặt một hình ảnh lát làm kết cấu và tùy chỉnh hành vi lát, bạn có thể sử dụng các phương thức sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Đặt chế độ đổ hình ảnh—hoặc `Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Xác định căn chỉnh của các ô lát trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Kiểm soát việc ô lát có bị lật ngang, dọc hoặc cả hai hay không.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Đặt độ lệch ngang của ô lát (theo điểm) so với gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Đặt độ lệch dọc của ô lát (theo điểm) so với gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Xác định tỉ lệ ngang của ô lát dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Xác định tỉ lệ dọc của ô lát dưới dạng phần trăm.

Mã mẫu dưới đây cho thấy cách thêm một hình chữ nhật với đổ hình ảnh lát và cấu hình các tùy chọn lát:

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape hình chữ nhật.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Đặt kiểu tô của hình dạng thành Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Tải hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Gán hình ảnh cho hình dạng.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Cấu hình chế độ đổ hình ảnh và các thuộc tính lát.
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

## **Đổ màu Đơn**

Trong PowerPoint, Đổ màu Đơn là một tùy chọn định dạng làm đầy một hình dạng bằng một màu duy nhất, đồng nhất. Nền màu này được áp dụng mà không có gradient, kết cấu hay mẫu nào.

Để áp dụng đổ màu đơn cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu đổ ưa thích của bạn cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP sau minh họa cách áp dụng đổ màu đơn cho một hình chữ nhật trong slide PowerPoint:

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
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

Kết quả:

![Hình dạng với đổ màu đơn](solid-color-fill.png)

## **Đặt Độ trong suốt**

Trong PowerPoint, khi bạn áp dụng màu đơn, gradient, hình ảnh hoặc kết cấu cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của phần tô. Giá trị trong suốt cao hơn làm cho hình dạng trở nên trong suốt hơn, cho phép nền hoặc các đối tượng bên dưới được hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được dùng để tô. Cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color` để xác định một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
1. Lưu bản trình chiếu.

Mã PHP sau minh họa cách áp dụng màu tô trong suốt cho một hình chữ nhật:

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
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

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi bố trí các yếu tố hình ảnh cần căn chỉnh hoặc thiết kế đặc thù.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt thuộc tính quay của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

Mã PHP sau minh họa cách xoay một hình dạng 5 độ:

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
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

## **Thêm Hiệu ứng Chân đế 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng chân đế 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Để thêm hiệu ứng chân đế 3D cho một hình dạng, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) của hình dạng để định nghĩa các cài đặt chân đế.
1. Lưu bản trình chiếu.

Mã PHP sau cho thấy cách áp dụng hiệu ứng chân đế 3D cho một hình dạng:

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

![Hiệu ứng chân đế 3D](3D-bevel-effect.png)

## **Thêm Hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vào slide.
1. Sử dụng [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) và [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) để định nghĩa xoay 3D.
1. Lưu bản trình chiếu.

Mã PHP sau minh họa cách áp dụng hiệu ứng xoay 3D cho một hình dạng:

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

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Kiểm soát Hiển thị Đen-Trắng cho Hình dạng**

Phương thức [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) chỉ định cách một hình dạng riêng lẻ được hiển thị khi bản trình chiếu được xem hoặc xử lý ở chế độ đen-trắng. Nó không tự động bật hiển thị đen-trắng và không thay đổi màu nền, đường viền hoặc các định dạng khác trong chế độ màu bình thường.

Sử dụng một giá trị từ lớp [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` để ứng dụng hiển thị tự động lựa chọn chuyển đổi, `Gray` và `LightGray` sử dụng màu xám, `BlackWhite` chỉ dùng đen và trắng, `Black` và `White` buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` ẩn hình dạng trong chế độ đen-trắng. `NotDefined` có nghĩa là không có chế độ cấp cho hình dạng.

Mã PHP sau tạo một hình dạng có màu và làm cho nó hiển thị màu xám trong chế độ hiển thị đen-trắng:

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

Trong chế độ màu bình thường, hình chữ nhật vẫn giữ màu nền cam. Trong quy trình hiển thị đen-trắng, nó sử dụng màu xám vì chế độ được đặt thành `Gray`. Điều này cho phép bạn giữ slide màu đầy đủ trong khi định nghĩa cách hiển thị riêng cho việc in, xem trước hoặc các quy trình khác tôn trọng cài đặt hiển thị đen-trắng của bản trình chiếu.

## **Đặt lại Định dạng**

Mã Java sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có trình giữ chỗ trên [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) về cài đặt mặc định:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Đặt lại mỗi hình dạng trên slide có trình giữ chỗ trên bố cục.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình chiếu không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện nhúng chiếm phần lớn không gian tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng siêu dữ liệu và gần như không làm tăng kích thước.

**Làm sao tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để có thể nhóm chúng?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—các cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi kiểu của chúng là giống nhau và nhóm logic các hình dạng đó, giúp đơn giản hoá việc quản lý kiểu sau này.

**Tôi có thể lưu một tập hợp các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu với kiểu mong muốn trong một slide mẫu hoặc tệp mẫu .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình dạng đã định dạng bạn cần và áp dụng lại định dạng của chúng ở nơi cần thiết.