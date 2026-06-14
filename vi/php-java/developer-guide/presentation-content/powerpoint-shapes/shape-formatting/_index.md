---
title: Định dạng các hình dạng PowerPoint trong PHP
linktitle: Định dạng Hình
type: docs
weight: 20
url: /vi/php-java/shape-formatting/
keywords:
- định dạng hình
- định dạng đường
- định dạng kiểu nối
- đổ màu gradient
- đổ mẫu
- đổ hình ảnh
- đổ kết cấu
- đổ màu đơn
- độ trong suốt hình dạng
- xoay hình dạng
- hiệu ứng bo vi 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong PHP bằng Aspose.Slides - đặt các kiểu đổ, đường và hiệu ứng cho tệp PPT, PPTX và ODP một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách sửa đổi hoặc áp dụng hiệu ứng lên viền. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách nội bộ của chúng được tô màu.

![Định dạng hình dạng trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP qua Java cung cấp các lớp và phương thức cho phép bạn định dạng hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [kiểu đường](https://reference.aspose.com/slides/vi/php-java/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng đường.
1. Đặt [dash style](https://reference.aspose.com/slides/vi/php-java/aspose.slides/linedashstyle/) cho đường.
1. Đặt màu đường cho hình dạng.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Đoạn mã PHP dưới đây minh họa cách định dạng một `AutoShape` hình chữ nhật:

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape kiểu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Đặt màu tô cho hình chữ nhật.
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

## **Định dạng Kiểu Nối**

Dưới đây là ba tùy chọn kiểu nối:

* Tròn
* Vát
* Xiên

Mặc định, khi PowerPoint nối hai đường ở một góc (chẳng hạn tại góc của hình dạng), nó sử dụng thiết lập **Tròn**. Tuy nhiên, nếu bạn đang vẽ một hình dạng có các góc sắc nét, bạn có thể ưu tiên tùy chọn **Vát**.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Đoạn mã PHP dưới đây minh họa cách ba hình chữ nhật (như trong hình trên) được tạo bằng cách sử dụng các thiết lập kiểu nối Miter, Bevel và Round:

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm ba auto shape kiểu Rectangle.
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

Trong PowerPoint, Đổ màu Gradient là một tùy chọn định dạng cho phép bạn áp dụng sự pha trộn liên tục của các màu vào một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần chuyển sang màu khác.

Dưới đây là cách áp dụng đổ màu gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu bạn muốn với vị trí đã định bằng các phương thức `add` của bộ sưu tập gradient stop được cung cấp bởi lớp [GradientFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/gradientformat/).
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape kiểu Ellipse.
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

## **Đổ mẫu**

Trong PowerPoint, Đổ mẫu là một tùy chọn định dạng cho phép bạn áp dụng thiết kế hai màu—như chấm, sọc, vạch chéo, hoặc ô vuông—cho một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền trước và nền sau của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định trước mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bản trình chiếu. Ngay cả sau khi chọn một mẫu được định trước, bạn vẫn có thể chỉ định các màu chính xác mà nó sẽ sử dụng.

Đây là cách áp dụng đổ mẫu cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn một kiểu mẫu trong các tùy chọn được định trước.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/php-java/aspose.slides/patternformat/#getBackColor) của mẫu.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/php-java/aspose.slides/patternformat/#getForeColor) của mẫu.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape kiểu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Đặt loại fill là Pattern.
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

## **Đổ Hình Ảnh**

Trong PowerPoint, Đổ Hình Ảnh là một tùy chọn định dạng cho phép bạn chèn một hình vào bên trong một hình dạng—thực tế sử dụng hình ảnh làm nền cho hình dạng.

Đây là cách sử dụng Aspose.Slides để áp dụng đổ hình ảnh cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ đổ hình ảnh thành `Tile` (hoặc chế độ khác mà bạn muốn).
1. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) từ hình ảnh bạn muốn sử dụng.
1. Truyền hình ảnh vào phương thức `SlidesPicture.setImage`.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình lotus](lotus.png)

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape kiểu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Đặt loại fill là Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Đặt chế độ đổ hình ảnh.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Tải ảnh và thêm vào tài nguyên của bản trình chiếu.
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

### **Hình Ảnh Lát làm Kết Cấu**

Nếu bạn muốn đặt một hình ảnh lát làm kết cấu và tùy chỉnh hành vi lát, bạn có thể sử dụng các phương thức sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Đặt chế độ đổ hình ảnh—hoặc `Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileAlignment): Xác định vị trí căn chỉnh của các ô lát trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileFlip): Kiểm soát việc lật ô lát theo chiều ngang, dọc, hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Đặt độ lệch ngang của ô lát (theo điểm) so với gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Đặt độ lệch dọc của ô lát (theo điểm) so với gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileScaleX): Xác định tỷ lệ ngang của ô lát dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#setTileScaleY): Xác định tỷ lệ dọc của ô lát dưới dạng phần trăm.

Đoạn mã mẫu dưới đây cho thấy cách thêm một hình chữ nhật với đổ hình ảnh lát và cấu hình các tùy chọn lát:

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape dạng Rectangle.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Đặt loại fill của hình dạng thành Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Tải ảnh và thêm vào tài nguyên của bản trình chiếu.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Gán ảnh cho hình dạng.
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

![Các tùy chọn ô lát](tile-options.png)

## **Đổ màu Đơn**

Trong PowerPoint, Đổ màu Đơn là một tùy chọn định dạng làm đầy một hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn giản này được áp dụng mà không có gradient, kết cấu hay mẫu nào.

Để áp dụng đổ màu đơn cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu đổ mà bạn muốn cho hình dạng.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape kiểu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Đặt loại fill thành Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Đặt màu fill.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Lưu tệp PPTX vào đĩa.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hình dạng với đổ màu đơn](solid-color-fill.png)

## **Đặt Độ Trong Suốt**

Trong PowerPoint, khi bạn áp dụng đổ màu đơn, gradient, hình ảnh hoặc kết cấu lên các hình dạng, bạn cũng có thể thiết lập mức độ trong suốt để kiểm soát độ mờ của lớp đổ. Giá trị trong suốt cao hơn làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng phía dưới hiển thị một phần.

Aspose.Slides cho phép bạn thiết lập mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được sử dụng cho lớp đổ. Cách thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
1. Lưu bản trình chiếu.

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
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

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình Dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi đặt vị trí các thành phần hình ảnh với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

```php
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một auto shape kiểu Rectangle.
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

## **Thêm hiệu ứng Bo vi 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng Bo vi 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/).

Để thêm hiệu ứng Bo vi 3D cho một hình dạng, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/) của hình dạng để xác định cài đặt bo vi.
1. Lưu bản trình chiếu.

```php
// Khởi tạo một thể hiện của lớp Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một hình vào slide.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Đặt các thuộc tính ThreeDFormat của hình.
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

![Hiệu ứng Bo vi 3D](3D-bevel-effect.png)

## **Thêm hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng Xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/).

Để áp dụng Xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) vào slide.
1. Sử dụng [setCameraType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/camera/#setCameraType) và [setLightType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/lightrig/#setLightType) để xác định Xoay 3D.
1. Lưu bản trình chiếu.

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

## **Đặt lại Định dạng**

Đoạn mã Java dưới đây cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/) về cài đặt mặc định:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Đặt lại mỗi hình trên slide có placeholder trên bố cục.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình chiếu không?**

Chỉ rất ít. Các hình ảnh và phương tiện được nhúng chiếm hầu hết dung lượng tệp, trong khi các tham số của hình dạng như màu sắc, hiệu ứng và gradient được lưu dưới dạng metadata và hầu như không tăng thêm kích thước.

**Làm sao tôi có thể phát hiện các hình dạng trên một slide có định dạng giống nhau để tôi có thể nhóm chúng?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi kiểu của chúng là giống nhau và nhóm logic các hình dạng đó, giúp đơn giản hóa việc quản lý kiểu sau này.

**Tôi có thể lưu một bộ các kiểu dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu với các kiểu mong muốn vào một bộ slide mẫu hoặc tệp mẫu .POTX. Khi tạo một bản trình chiếu mới, mở mẫu, sao chép các hình dạng đã định dạng mà bạn cần và áp dụng lại định dạng của chúng ở bất kỳ nơi nào cần thiết.