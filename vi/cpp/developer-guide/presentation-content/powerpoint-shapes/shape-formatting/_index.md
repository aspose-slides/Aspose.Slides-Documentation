---
title: Định dạng Hình PowerPoint trong C++
linktitle: Định dạng Hình
type: docs
weight: 20
url: /vi/cpp/shape-formatting/
keywords:
- định dạng hình
- định dạng đường viền
- hiệu ứng phác thảo
- đường viền hình phác thảo
- định dạng kiểu nối
- đổ màu gradient
- đổ màu mẫu
- đổ màu hình ảnh
- đổ màu texture
- đổ màu đặc
- độ trong suốt hình
- xoay hình
- hiệu ứng đuôi 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình PowerPoint trong C++ bằng Aspose.Slides—đặt các kiểu tô, đường viền và hiệu ứng cho tệp PPT, PPTX và ODP một cách chính xác và kiểm soát hoàn toàn."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách sửa đổi hoặc áp dụng hiệu ứng cho viền của chúng. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách bên trong của chúng được tô màu.

![định dạng hình PowerPoint](format-shape-powerpoint.png)

Aspose.Slides cho C++ cung cấp các giao diện và phương thức cho phép bạn định dạng các hình dạng bằng cùng các tùy chọn có sẵn trong PowerPoint.

## **Định dạng Đường viền**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường viền tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [line style](https://reference.aspose.com/slides/vi/cpp/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng của đường viền.
1. Đặt [dash style](https://reference.aspose.com/slides/vi/cpp/aspose.slides/linedashstyle/) cho đường viền.
1. Đặt màu đường viền cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã sau minh họa cách định dạng một `AutoShape` hình chữ nhật:

```cpp
// Tạo thể hiện của lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Hình chữ nhật.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Đặt màu tô cho hình chữ nhật.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Áp dụng định dạng cho các đường viền của hình chữ nhật.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Đặt màu cho đường viền của hình chữ nhật.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các đường đã định dạng trong bản trình chiếu](formatted-lines.png)

## **Áp dụng Hiệu ứng Phác thảo cho Đường viền Hình dạng**

Hiệu ứng phác thảo làm cho đường viền của hình dạng trông như được vẽ tay. Sử dụng [IShape::get_LineFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_lineformat/) để truy cập các cài đặt đường viền, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilineformat/get_sketchformat/) để truy cập các cài đặt phác thảo, và [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isketchformat/set_sketchtype/) để chọn một giá trị từ enumeration [LineSketchType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/linesketchtype/).

Đoạn mã C++ sau cho thấy cách áp dụng hiệu ứng [LineSketchType::Curved](https://reference.aspose.com/slides/vi/cpp/aspose.slides/linesketchtype/), đọc giá trị được gán một cách rõ ràng, và xóa hiệu ứng bằng [LineSketchType::None](https://reference.aspose.com/slides/vi/cpp/aspose.slides/linesketchtype/):

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

Giá trị trả về bởi [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isketchformat/get_sketchtype/) đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường viền có thể được kế thừa từ một chủ đề, slide master hoặc slide layout, hãy sử dụng [ILineFormat::GetEffective](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilineformat/geteffective/), truy cập [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), và đọc [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Giá trị hiệu quả phản ánh định dạng thực tế được áp dụng sau khi kế thừa được giải quyết:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **Định dạng Kiểu Nối**

Dưới đây là ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Mặc định, khi PowerPoint nối hai đường ở một góc (ví dụ tại góc của hình dạng), nó sử dụng cài đặt **Round**. Tuy nhiên, nếu bạn vẽ một hình dạng với các góc nhọn, bạn có thể thích tùy chọn **Miter**.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Đoạn mã C++ sau minh họa cách ba hình chữ nhật (như trong hình trên) được tạo bằng cách sử dụng các cài đặt kiểu nối Miter, Bevel và Round:

```cpp
// Tạo thể hiện của lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm ba auto shape loại Hình chữ nhật.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Đặt màu tô cho mỗi hình chữ nhật.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Đặt độ rộng đường viền.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Đặt màu cho đường viền của mỗi hình chữ nhật.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Đặt kiểu nối.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Thêm văn bản vào mỗi hình chữ nhật.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đổ màu Gradient**

Trong PowerPoint, Đổ màu Gradient là một tùy chọn định dạng cho phép bạn áp dụng một hỗn hợp màu liên tục cho một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần chuyển sang màu khác.

Dưới đây là cách áp dụng đổ màu gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu bạn muốn với vị trí đã định bằng các phương thức `Add` của bộ sưu tập gradient stop được cung cấp bởi giao diện [IGradientFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igradientformat/).
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```cpp
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Áp dụng định dạng gradient cho ellipse.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Đặt hướng của gradient.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Thêm hai gradient stop.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Ellipse với đổ màu gradient](gradient-fill.png)

## **Đổ màu Pattern**

Trong PowerPoint, Đổ màu Pattern là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, chéo hoặc ô vuông—cho một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền trước và nền sau của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định sẵn mà bạn có thể áp dụng cho các hình dạng để nâng cao sức hấp dẫn trực quan của bản trình chiếu. Ngay cả sau khi chọn một mẫu đã định sẵn, bạn vẫn có thể chỉ định các màu chính xác mà nó sẽ sử dụng.

Dưới đây là cách áp dụng đổ màu pattern cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn một kiểu mẫu từ các tùy chọn đã định sẵn.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipatternformat/get_backcolor/) của mẫu.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipatternformat/get_forecolor/) của mẫu.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```cpp
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Hình chữ nhật.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Đặt kiểu tô thành Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Đặt kiểu mẫu.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Đặt màu nền và màu chữ cho mẫu.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hình chữ nhật với đổ màu pattern](pattern-fill.png)

## **Đổ màu Hình ảnh**

Trong PowerPoint, Đổ màu Picture là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng—thực tế là sử dụng hình ảnh làm nền cho hình dạng.

Dưới đây là cách áp dụng đổ màu picture cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ đổ hình ảnh thành `Tile` (hoặc chế độ khác ưu thích).
1. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
1. Truyền hình ảnh vào phương thức `ISlidesPicture.set_Image`.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình ảnh lotus](lotus.png)

```cpp
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Hình chữ nhật.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Đặt kiểu tô thành Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Đặt chế độ đổ hình ảnh.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Tải một hình ảnh và thêm vào tài nguyên của bản trình chiếu.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Đặt hình ảnh.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hình dạng với đổ màu picture](picture-fill.png)

### **Đặt Hình ảnh Lát làm Kết cấu**

Nếu bạn muốn đặt một hình ảnh lát làm kết cấu và tùy chỉnh hành vi lát, bạn có thể sử dụng các phương thức sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/picturefillformat/):

- set_PictureFillMode: Đặt chế độ đổ hình ảnh—hoặc `Tile` hoặc `Stretch`.
- set_TileAlignment: Xác định vị trí căn chỉnh của các ô lát bên trong hình dạng.
- set_TileFlip: Kiểm soát việc lật ô lát theo chiều ngang, dọc, hoặc cả hai.
- set_TileOffsetX: Đặt độ lệch ngang của ô lát (đơn vị điểm) so với gốc của hình dạng.
- set_TileOffsetY: Đặt độ lệch dọc của ô lát (đơn vị điểm) so với gốc của hình dạng.
- set_TileScaleX: Xác định tỷ lệ ngang của ô lát dưới dạng phần trăm.
- set_TileScaleY: Xác định tỷ lệ dọc của ô lát dưới dạng phần trăm.

Đoạn mã mẫu sau cho thấy cách thêm một hình chữ nhật với đổ hình ảnh lát và cấu hình các tùy chọn lát:

```cpp
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto firstSlide = presentation->get_Slide(0);

// Thêm một auto shape hình chữ nhật.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Đặt kiểu tô của hình dạng thành Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Tải hình ảnh và thêm vào tài nguyên của bản trình chiếu.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Gán hình ảnh cho hình dạng.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Cấu hình chế độ đổ hình ảnh và các thuộc tính lát.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các tùy chọn lát](tile-options.png)

## **Đổ màu Đặc Hóa**

Trong PowerPoint, Đổ màu Solid là một tùy chọn định dạng cho phép bạn lấp đầy một hình dạng bằng một màu duy nhất, đồng đều. Màu nền đơn giản này được áp dụng mà không có gradient, kết cấu hay mẫu nào.

Để áp dụng đổ màu đặc cho một hình dạng bằng Aspose.Slides, làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu tô bạn muốn vào hình dạng.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```cpp
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Hình chữ nhật.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Đặt kiểu tô thành Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Đặt màu tô.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hình dạng với đổ màu đặc](solid-color-fill.png)

## **Đặt Độ trong Suất**

Trong PowerPoint, khi bạn áp dụng đổ màu đặc, gradient, picture hoặc texture cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của lớp tô. Giá trị trong suốt cao hơn làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng dưới đó hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh thành phần alpha trong màu được dùng để tô. Cách thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
1. Lưu bản trình chiếu.

```cpp
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape hình chữ nhật đặc.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Thêm một auto shape hình chữ nhật trong suốt lên trên hình dạng đặc.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi cần đặt các yếu tố trực quan với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

```cpp
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Hình chữ nhật.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Xoay hình dạng 5 độ.
shape->set_Rotation(5);

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu ứng Đuôi 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng đuôi 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/threedformat/).

Để thêm hiệu ứng đuôi 3D cho một hình dạng, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/threedformat/) của hình dạng để xác định các cài đặt đuôi.
1. Lưu bản trình chiếu.

```cpp
// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Thêm một hình dạng vào slide.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Đặt các thuộc tính ThreeDFormat của hình dạng.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Lưu bản trình chiếu dưới dạng tệp PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hiệu ứng Đuôi 3D](3D-bevel-effect.png)

## **Thêm Hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/threedformat/).

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Sử dụng [set_CameraType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icamera/set_cameratype/) và [set_LightType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilightrig/set_lighttype/) để xác định xoay 3D.
1. Lưu bản trình chiếu.

```cpp
// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Lưu bản trình chiếu dưới dạng tệp PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hiệu ứng Xoay 3D](3D-rotation-effect.png)

## **Đặt lại Định dạng**

Đoạn mã C++ sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có trình giữ chỗ trên [LayoutSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/layoutslide/) về cài đặt mặc định:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Đặt lại mỗi hình dạng trên slide có trình giữ chỗ trong bố cục.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Định dạng hình dạng có ảnh hưởng đến kích thước tệp bản trình chiếu cuối cùng không?**

Chỉ một mức độ rất nhỏ. Các hình ảnh và phương tiện nhúng chiếm phần lớn không gian tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng metadata và gần như không tăng thêm kích thước.

**Làm thế nào để tôi phát hiện các hình dạng trên một slide có cùng định dạng để có thể nhóm chúng?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là có cùng kiểu và nhóm chúng lại, điều này giúp việc quản lý kiểu sau này dễ dàng hơn.

**Tôi có thể lưu một tập hợp các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu với kiểu mong muốn trong một slide deck mẫu hoặc tệp .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình dạng đã định dạng mà bạn cần và áp dụng lại định dạng của chúng ở nơi cần thiết.