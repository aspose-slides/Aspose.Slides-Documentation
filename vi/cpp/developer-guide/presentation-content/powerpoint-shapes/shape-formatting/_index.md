---
title: Định dạng các hình dạng PowerPoint trong C++
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/cpp/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường viền
- định dạng kiểu nối
- đổ gradient
- đổ pattern
- đổ hình ảnh
- đổ texture
- đổ màu đồng nhất
- độ trong suốt hình dạng
- xoay hình dạng
- hiệu ứng bevel 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong C++ bằng Aspose.Slides—đặt kiểu tô, đường viền và hiệu ứng cho tệp PPT, PPTX và ODP một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách chỉnh sửa hoặc áp dụng hiệu ứng cho viền của chúng. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách phần bên trong của chúng được tô màu.

![Định dạng hình dạng trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides cho C++ cung cấp các giao diện và phương thức cho phép bạn định dạng các hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường viền**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [định dạng đường](https://reference.aspose.com/slides/vi/cpp/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng đường.
1. Đặt [kiểu gạch](https://reference.aspose.com/slides/vi/cpp/aspose.slides/linedashstyle/) của đường.
1. Đặt màu đường cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã sau đây minh họa cách định dạng một `AutoShape` hình chữ nhật:

```cpp
// Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Đặt màu tô cho hình dạng hình chữ nhật.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Áp dụng định dạng cho các đường của hình chữ nhật.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Đặt màu cho đường của hình chữ nhật.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Lưu tệp PPTX vào ổ đĩa.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các đường được định dạng trong bản trình chiếu](formatted-lines.png)

## **Định dạng Kiểu Nối**

Dưới đây là ba tùy chọn kiểu nối:

* Tròn
* Đỉnh
* Góc

Mặc định, khi PowerPoint nối hai đường ở một góc (ví dụ như ở góc của một hình dạng), nó sử dụng thiết lập **Tròn**. Tuy nhiên, nếu bạn vẽ một hình dạng có các góc sắc, bạn có thể thích tùy chọn **Đỉnh**.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

```cpp
// Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm ba auto shape loại Rectangle.
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

// Đặt màu cho đường của mỗi hình chữ nhật.
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

// Lưu tệp PPTX vào ổ đĩa.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đổ Gradient**

Trong PowerPoint, Đổ Gradient là một tùy chọn định dạng cho phép bạn áp dụng một sự pha trộn liên tục của các màu lên một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho màu này dần chuyển sang màu khác.

Cách áp dụng Đổ Gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu ưa thích của bạn với vị trí đã định nghĩa bằng các phương thức `Add` của bộ sưu tập gradient stop được cung cấp bởi giao diện[IGradientFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igradientformat/).
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

```cpp
// Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
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

// Thêm hai điểm dừng gradient.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Lưu tệp PPTX vào ổ đĩa.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Ellipse với Đổ Gradient](gradient-fill.png)

## **Đổ Pattern**

Trong PowerPoint, Đổ Pattern là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, dấu chéo, hoặc ô vuông—cho một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền và màu nền trước của pattern.

Aspose.Slides cung cấp hơn 45 kiểu pattern được định sẵn mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bài thuyết trình. Ngay cả sau khi chọn một pattern có sẵn, bạn vẫn có thể chỉ định chính xác các màu mà nó sẽ sử dụng.

Cách áp dụng Đổ Pattern cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn một kiểu pattern từ các tùy chọn được định sẵn.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipatternformat/get_backcolor/) của pattern.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipatternformat/get_forecolor/) của pattern.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

```cpp
// Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Đặt kiểu tô là Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Đặt kiểu mẫu.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Đặt màu nền và màu nền trước của mẫu.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Lưu tệp PPTX vào ổ đĩa.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hình chữ nhật với Đổ Pattern](pattern-fill.png)

## **Đổ Picture**

Trong PowerPoint, Đổ Picture là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng—thực chất sử dụng hình ảnh làm nền cho hình dạng.

Cách sử dụng Aspose.Slides để áp dụng Đổ Picture cho một hình dạng:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ đổ picture thành `Tile` (hoặc chế độ ưa thích khác).
1. Tạo một đối tượng[IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
1. Truyền hình ảnh vào phương thức `ISlidesPicture.set_Image`.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh dưới đây:

![Hình lotus](lotus.png)

```cpp
// Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Đặt kiểu tô là Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Đặt chế độ đổ ảnh.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Tải một hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Đặt ảnh.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Lưu tệp PPTX vào ổ đĩa.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hình dạng với Đổ Picture](picture-fill.png)

### **Tile Picture As Texture**

Nếu bạn muốn đặt một ảnh lặp làm texture và tùy chỉnh hành vi lặp, bạn có thể sử dụng các phương thức sau của giao diện[IPictureFillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/) và lớp[PictureFillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Đặt chế độ đổ picture—`Tile` hoặc `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Xác định cách căn chỉnh các ô trong hình dạng.
- [set_TileFlip](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Kiểm soát việc lật ô theo chiều ngang, chiều dọc hoặc cả hai.
- [set_TileOffsetX](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Đặt khoảng dịch chuyển ngang của ô (đơn vị điểm) so với gốc của hình dạng.
- [set_TileOffsetY](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Đặt khoảng dịch chuyển dọc của ô (đơn vị điểm) so với gốc của hình dạng.
- [set_TileScaleX](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Xác định tỷ lệ ngang của ô dưới dạng phần trăm.
- [set_TileScaleY](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Xác định tỷ lệ dọc của ô dưới dạng phần trăm.

```cpp
// Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto firstSlide = presentation->get_Slide(0);

// Thêm một auto shape hình chữ nhật.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Đặt kiểu tô của hình dạng là Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Tải hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Gán hình ảnh cho hình dạng.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Cấu hình chế độ đổ ảnh và các thuộc tính lặp.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Lưu tệp PPTX vào ổ đĩa.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các tùy chọn lặp](tile-options.png)

## **Đổ Solid Color**

Trong PowerPoint, Đổ Solid Color là một tùy chọn định dạng làm đầy một hình dạng bằng một màu duy nhất, đồng nhất. Nền màu này được áp dụng mà không có gradient, texture hoặc pattern nào.

Để áp dụng Đổ Solid Color cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu điền ưa thích của bạn cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

```cpp
// Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Đặt kiểu tô là Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Đặt màu tô.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Lưu tệp PPTX vào ổ đĩa.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hình dạng với Đổ Solid Color](solid-color-fill.png)

## **Đặt Độ Trong Suốt**

Trong PowerPoint, khi bạn áp dụng màu solid, gradient, picture hoặc texture cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của lớp nền. Giá trị trong suốt cao hơn làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng phía sau hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu dùng để đổ. Cách thực hiện:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` điều khiển độ trong suốt).
1. Lưu bản trình chiếu.

```cpp
// Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape hình chữ nhật đặc.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Thêm một auto shape hình chữ nhật trong suốt lên trên hình dạng đặc.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Lưu tệp PPTX vào ổ đĩa.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình Dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi định vị các yếu tố hình ảnh với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

```cpp
// Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Xoay hình dạng 5 độ.
shape->set_Rotation(5);

// Lưu tệp PPTX vào ổ đĩa.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu Ứng Bevel 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng bevel 3D cho các hình dạng bằng cách cấu hình các thuộc tính[ThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/threedformat/).

Để thêm hiệu ứng bevel 3D cho một hình dạng, thực hiện các bước sau:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/threedformat/) của hình dạng để định nghĩa các cài đặt bevel.
1. Lưu bản trình chiếu.

```cpp
// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Add a shape to the slide.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Set the shape's ThreeDFormat properties.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Save the presentation as a PPTX file.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hiệu ứng bevel 3D](3D-bevel-effect.png)

## **Thêm Hiệu Ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính[ThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/threedformat/).

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Sử dụng[set_CameraType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icamera/set_cameratype/) và[set_LightType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilightrig/set_lighttype/) để định nghĩa xoay 3D.
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

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Đặt Lại Định Dạng**

Mã C++ sau đây cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có trình giữ chỗ trên[LayoutSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/layoutslide/) về thiết lập mặc định:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Đặt lại mỗi hình dạng trên slide có trình giữ chỗ trên bố cục.
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình chiếu không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện được nhúng chiếm phần lớn không gian tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng metadata và hầu như không làm tăng kích thước thêm.

**Làm sao tôi có thể phát hiện các hình dạng trên một slide có định dạng giống nhau để có thể nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là cùng một kiểu và nhóm logic các hình dạng đó, giúp việc quản lý kiểu sau này đơn giản hơn.

**Tôi có thể lưu một tập hợp các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu với kiểu mong muốn trong một slide mẫu hoặc tệp .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình dạng đã định dạng và áp dụng lại định dạng của chúng ở nơi cần thiết.