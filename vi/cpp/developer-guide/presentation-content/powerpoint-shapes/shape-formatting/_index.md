---
title: Định dạng các hình dạng PowerPoint trong C++
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/cpp/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường
- hiệu ứng phác thảo
- đường hình dạng phác thảo
- định dạng kiểu nối
- đổ màu gradient
- đổ mẫu
- đổ hình ảnh
- đổ kết cấu
- đổ màu đồng nhất
- độ trong suốt của hình dạng
- kết xuất hình dạng đen-trắng
- kết xuất hình dạng thang xám
- xoay hình dạng
- hiệu ứng vát 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong C++ bằng Aspose.Slides—đặt kiểu tô, đường viền và hiệu ứng cho các tệp PPT, PPTX và ODP một cách chính xác và kiểm soát hoàn toàn."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách chỉnh sửa hoặc áp dụng hiệu ứng lên viền. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách nội bộ của chúng được tô đầy.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides cho C++ cung cấp các giao diện và phương thức cho phép bạn định dạng các hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide bằng chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) vào slide.
4. Đặt [kiểu đường](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) cho hình dạng.
5. Đặt độ rộng đường.
6. Đặt [kiểu gạch đứt](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) của đường.
7. Đặt màu đường cho hình dạng.
8. Lưu bản trình chiếu đã chỉnh sửa dưới dạng file PPTX.

Mã sau đây cho thấy cách định dạng một `AutoShape` hình chữ nhật:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
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

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các đường đã định dạng trong bản trình chiếu](formatted-lines.png)

## **Áp dụng Hiệu ứng Phác thảo cho Đường Hình dạng**

Một hiệu ứng phác thảo làm cho đường của hình dạng trông như được vẽ tay. Sử dụng [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) để truy cập các cài đặt đường, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) để truy cập các cài đặt phác thảo, và [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) để chọn một giá trị từ enumeration [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) .

Mã C++ sau đây cho thấy cách áp dụng hiệu ứng [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) , đọc giá trị được gán rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) :

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

Giá trị trả về bởi [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide mẫu hoặc slide bố cục, hãy sử dụng [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), truy cập [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), và đọc [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Giá trị hiệu quả phản ánh định dạng thực tế được áp dụng sau khi kế thừa được giải quyết:

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

* Tròn
* Mít
* Ghép

Mặc định, khi PowerPoint nối hai đường ở một góc (như ở góc của một hình dạng), nó sử dụng cài đặt **Tròn**. Tuy nhiên, nếu bạn vẽ một hình dạng với các góc nhọn, bạn có thể thích tùy chọn **Mít**.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Mã C++ sau đây cho thấy cách ba hình chữ nhật (như trong hình trên) được tạo bằng cài đặt kiểu nối Mít, Ghép và Tròn:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
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

// Đặt độ rộng đường.
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

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đổ màu Gradient**

Trong PowerPoint, Đổ màu Gradient là một tùy chọn định dạng cho phép bạn áp dụng một hỗn hợp màu liên tục lên một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho màu này dần dần chuyển sang màu khác.

Dưới đây là cách áp dụng Đổ màu gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide bằng chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) của hình dạng thành `Gradient`.
5. Thêm hai màu ưa thích của bạn cùng vị trí xác định bằng các phương thức `Add` của bộ sưu tập gradient stop được cung cấp bởi giao diện [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/) .
6. Lưu bản trình chiếu đã chỉnh sửa dưới dạng file PPTX.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

// Thêm hai điểm dừng gradient.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Ellipse với màu gradient](gradient-fill.png)

Nếu một gradient trông khác trong hình ảnh được xuất ra so với trong PowerPoint, xem [Chọn Kiểu Kết xuất Gradient](/slides/vi/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Bạn có thể chọn kiểu kết xuất mà không thay đổi gradient được lưu trong bản trình chiếu.

## **Đổ mẫu**

Trong PowerPoint, Đổ mẫu là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, vạch chéo hoặc caro—vào một hình dạng. Bạn có thể chọn màu tùy chỉnh cho tiền cảnh và nền của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu đã định nghĩa sẵn mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bản trình chiếu. Ngay cả khi đã chọn một mẫu đã định nghĩa sẵn, bạn vẫn có thể chỉ định màu chính xác mà nó sẽ sử dụng.

Dưới đây là cách áp dụng Đổ mẫu cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide bằng chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) của hình dạng thành `Pattern`.
5. Chọn một kiểu mẫu từ các tùy chọn đã định nghĩa sẵn.
6. Đặt [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) của mẫu.
7. Đặt [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) của mẫu.
8. Lưu bản trình chiếu đã chỉnh sửa dưới dạng file PPTX.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Đặt kiểu tô là Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Đặt kiểu mẫu.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Đặt màu nền và màu tiền cảnh của mẫu.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Hình chữ nhật với màu mẫu](pattern-fill.png)

## **Đổ hình ảnh**

Trong PowerPoint, Đổ hình ảnh là một tùy chọn định dạng cho phép bạn chèn một hình ảnh bên trong một hình dạng—thực tế là sử dụng hình ảnh làm nền cho hình dạng.

Dưới đây là cách sử dụng Aspose.Slides để áp dụng Đổ hình ảnh cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide bằng chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) của hình dạng thành `Picture`.
5. Đặt chế độ đổ hình ảnh thành `Tile` (hoặc chế độ ưa thích khác).
6. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
7. Truyền hình ảnh vào phương thức `ISlidesPicture.set_Image` .
8. Lưu bản trình chiếu đã chỉnh sửa dưới dạng file PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình lotus](lotus.png)

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Đặt kiểu tô là Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Đặt chế độ đổ hình ảnh.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Tải một hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Đặt hình ảnh.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Hình dạng với đổ hình ảnh](picture-fill.png)

### **Gạch Hình Ảnh Thành Kết Cấu**

Nếu bạn muốn đặt một hình ảnh dạng gạch làm kết cấu và tùy chỉnh hành vi gạch, bạn có thể sử dụng các phương thức sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) :

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Đặt chế độ đổ hình ảnh—hoặc `Tile` hoặc `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Xác định căn chỉnh của các ô gạch bên trong hình dạng.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Kiểm soát việc lật ô gạch theo chiều ngang, dọc hoặc cả hai.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Đặt độ dịch bịch ngang của ô gạch (theo điểm) so với nguồn gốc của hình dạng.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Đặt độ dịch bịch dọc của ô gạch (theo điểm) so với nguồn gốc của hình dạng.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Xác định tỉ lệ ngang của ô gạch dưới dạng phần trăm.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Xác định tỉ lệ dọc của ô gạch dưới dạng phần trăm.

Mã mẫu sau cho thấy cách thêm một hình chữ nhật với Đổ hình ảnh dạng gạch và cấu hình các tùy chọn gạch:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto firstSlide = presentation->get_Slide(0);

// Thêm một auto shape hình chữ nhật.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Đặt kiểu tô của hình dạng thành Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Tải hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Gán hình ảnh cho hình dạng.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Cấu hình chế độ đổ hình ảnh và các thuộc tính ghép gạch.
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

![Các tùy chọn gạch](tile-options.png)

## **Đổ màu Đơn**

Trong PowerPoint, Đổ màu Đơn là một tùy chọn định dạng làm đầy một hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn này được áp dụng mà không có gradient, kết cấu hay mẫu nào.

Để áp dụng Đổ màu Đơn cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide bằng chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) của hình dạng thành `Solid`.
5. Gán màu tô ưa thích của bạn cho hình dạng.
6. Lưu bản trình chiếu đã chỉnh sửa dưới dạng file PPTX.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Đặt kiểu tô thành Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Đặt màu tô.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Hình dạng với đổ màu đơn](solid-color-fill.png)

## **Đặt Độ Trong Suốt**

Trong PowerPoint, khi bạn áp dụng một màu đơn, gradient, hình ảnh hoặc kết cấu cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của phần tô. Giá trị trong suốt cao hơn khiến hình dạng trở nên trong suốt hơn, cho phép nền hoặc các đối tượng bên dưới hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được dùng để tô. Cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide bằng chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) thành `Solid`.
5. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
6. Lưu bản trình chiếu.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape hình chữ nhật đặc.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Thêm một auto shape hình chữ nhật trong suốt đặt lên trên hình dạng đặc.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi định vị các yếu tố trực quan với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide bằng chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) vào slide.
4. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
5. Lưu bản trình chiếu.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Xoay hình dạng 5 độ.
shape->set_Rotation(5);

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu ứng Vát 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng Vát 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) của chúng.

Để thêm hiệu ứng Vát 3D cho một hình dạng, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide bằng chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) vào slide.
4. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) của hình dạng để định nghĩa cài đặt Vát.
5. Lưu bản trình chiếu.

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Create an instance of the Presentation class.
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

![Hiệu ứng Vát 3D](3D-bevel-effect.png)

## **Thêm Hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng Xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) của chúng.

Để áp dụng Xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide bằng chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) vào slide.
4. Sử dụng [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) và [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) để định nghĩa Xoay 3D.
5. Lưu bản trình chiếu.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Lưu bản trình chiếu dưới dạng file PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Hiệu ứng Xoay 3D](3D-rotation-effect.png)

## **Kiểm soát Kết xuất Đen‑Trắng cho Hình dạng**

Phương thức [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) xác định cách một hình dạng cá nhân được kết xuất khi bản trình chiếu được xem hoặc xử lý ở chế độ đen‑trắng. Nó không tự động bật hiển thị đen‑trắng và không thay đổi màu nền, đường viền hay định dạng khác của hình dạng trong chế độ màu bình thường.

Sử dụng một giá trị từ enumeration [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` cho phép ứng dụng kết xuất chọn cách chuyển đổi, `Gray` và `LightGray` sử dụng màu xám, `BlackWhite` chỉ dùng màu đen và trắng, `Black` và `White` buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` loại bỏ hình dạng trong chế độ đen‑trắng. `NotDefined` có nghĩa là không có chế độ cấp cho mức độ hình dạng.

Mã C++ sau tạo một hình dạng màu và khiến nó hiển thị màu xám trong chế độ hiển thị đen‑trắng:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// Keep the orange fill in color mode, but render the shape with gray coloring in black-and-white mode.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Trong chế độ màu bình thường, hình chữ nhật vẫn giữ màu nền cam. Trong quy trình làm việc hiển thị đen‑trắng, nó sử dụng màu xám vì chế độ đã được đặt thành `Gray`. Điều này cho phép bạn giữ nguyên slide đầy màu trong khi định nghĩa một giao diện riêng biệt cho việc in, xem trước hoặc các quy trình khác tôn trọng cài đặt hiển thị đen‑trắng của bản trình chiếu.

## **Đặt lại Định dạng**

Mã C++ sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có chỗ giữ chỗ trên [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) về cài đặt mặc định của chúng:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // Đặt lại mỗi hình dạng trên slide có chỗ giữ chỗ trong bố cục.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình chiếu không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện nhúng chiếm phần lớn không gian tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng siêu dữ liệu và hầu như không làm tăng kích thước.

**Làm thế nào tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để có thể nhóm chúng?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—các cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là cùng một kiểu và nhóm logic các hình dạng đó, giúp đơn giản hoá việc quản lý kiểu sau này.

**Tôi có thể lưu một bộ các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu có kiểu mong muốn trong một slide mẫu hoặc tệp mẫu .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình dạng đã định dạng cần thiết và áp dụng lại định dạng của chúng ở nơi cần.