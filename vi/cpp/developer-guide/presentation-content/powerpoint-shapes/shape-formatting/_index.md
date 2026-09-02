---
title: Định dạng các hình dạng PowerPoint trong C++
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/cpp/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường viền
- hiệu ứng phác thảo
- đường viền hình dạng phác thảo
- định dạng kiểu nối
- đổ màu gradient
- đổ màu pattern
- đổ màu picture
- đổ màu texture
- đổ màu đậm
- độ trong suốt hình dạng
- hiển thị hình dạng đen‑trắng
- hiển thị hình dạng xám
- xoay hình dạng
- hiệu ứng bevel 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong C++ bằng Aspose.Slides—đặt các kiểu tô, đường viền và hiệu ứng cho tệp PPT, PPTX và ODP một cách chính xác và toàn quyền kiểm soát."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường nét, bạn có thể định dạng chúng bằng cách chỉnh sửa hoặc áp dụng hiệu ứng cho viền. Ngoài ra, bạn có thể định dạng hình dạng bằng cách chỉ định các cài đặt kiểm soát cách phần bên trong được tô màu.

![định dạng hình dạng powerpoint](format-shape-powerpoint.png)

Aspose.Slides cho C++ cung cấp các giao diện và phương thức cho phép bạn định dạng hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường viền**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [line style](https://reference.aspose.com/slides/vi/cpp/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng của đường.
1. Đặt [dash style](https://reference.aspose.com/slides/vi/cpp/aspose.slides/linedashstyle/) cho đường.
1. Đặt màu đường cho hình dạng.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã sau minh họa cách định dạng một `AutoShape` hình chữ nhật:

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

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Hình chữ nhật.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Đặt màu tô cho hình dạng hình chữ nhật.
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

![Các đường được định dạng trong bản trình bày](formatted-lines.png)

## **Áp dụng Hiệu ứng Phác thảo cho Đường viền Hình dạng**

Hiệu ứng phác thảo làm cho đường viền của hình dạng trông như được vẽ tay. Sử dụng [IShape::get_LineFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_lineformat/) để truy cập các cài đặt đường, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilineformat/get_sketchformat/) để truy cập các cài đặt phác thảo, và [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isketchformat/set_sketchtype/) để chọn một giá trị từ liệt kê [LineSketchType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/linesketchtype/).

Mã C++ dưới đây cho thấy cách áp dụng hiệu ứng [LineSketchType::Curved](https://reference.aspose.com/slides/vi/cpp/aspose.slides/linesketchtype/), đọc giá trị được gán một cách rõ ràng, và xóa hiệu ứng bằng [LineSketchType::None](https://reference.aspose.com/slides/vi/cpp/aspose.slides/linesketchtype/):

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

Giá trị trả về bởi [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isketchformat/get_sketchtype/) đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu việc định dạng đường có thể được kế thừa từ chủ đề, slide chủ hay slide bố cục, hãy sử dụng [ILineFormat::GetEffective](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilineformat/geteffective/), truy cập [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), và đọc [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Giá trị hiệu quả phản ánh định dạng thực tế được áp dụng sau khi kế thừa được giải quyết:

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

Ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Mặc định, khi PowerPoint nối hai đường tại một góc (ví dụ ở góc của hình dạng), nó sử dụng cài đặt **Round**. Tuy nhiên, nếu bạn vẽ một hình dạng có các góc nhọn, bạn có thể muốn chọn tùy chọn **Miter**.

![Kiểu nối trong bản trình bày](join-style-powerpoint.png)

Mã C++ dưới đây minh họa cách ba hình chữ nhật (như trong hình trên) được tạo bằng các cài đặt kiểu nối Miter, Bevel và Round:

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

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
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

// Đặt độ rộng của đường viền.
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

Trong PowerPoint, Đổ màu Gradient là một tùy chọn định dạng cho phép bạn áp dụng một dải màu liên tục lên một hình dạng. Ví dụ, bạn có thể áp dụng hai màu hoặc nhiều hơn sao cho màu này dần chuyển sang màu kia.

Cách áp dụng đổ màu gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu bạn muốn với vị trí xác định bằng các phương thức `Add` của bộ sưu tập gradient stop được cung cấp bởi giao diện [IGradientFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igradientformat/).
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã C++ dưới đây minh họa cách áp dụng hiệu ứng đổ màu gradient cho một hình ellipse:

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

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
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

Kết quả:

![Ellipse với đổ màu gradient](gradient-fill.png)

## **Đổ màu Pattern**

Trong PowerPoint, Đổ màu Pattern là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, vạch chéo hoặc ô vuông—cho một hình dạng. Bạn có thể chọn màu nền và màu nền trước tùy chỉnh cho mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định sẵn mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bản trình bày. Ngay cả khi đã chọn một mẫu được định sẵn, bạn vẫn có thể chỉ định màu sắc chính xác mà nó sẽ sử dụng.

Cách áp dụng đổ màu pattern cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn một kiểu mẫu từ các tùy chọn được định sẵn.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipatternformat/get_backcolor/) cho mẫu.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipatternformat/get_forecolor/) cho mẫu.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã C++ dưới đây minh họa cách áp dụng đổ màu pattern cho một hình chữ nhật:

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

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Hình chữ nhật.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Đặt loại tô là Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Đặt kiểu mẫu.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Đặt màu nền và màu nền trước của mẫu.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hình chữ nhật với đổ màu pattern](pattern-fill.png)

## **Đổ màu Picture**

Trong PowerPoint, Đổ màu Picture là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng—thực tế sử dụng hình ảnh làm nền của hình dạng.

Cách sử dụng Aspose.Slides để áp dụng đổ màu picture cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ đổ màu picture thành `Tile` (hoặc chế độ khác bạn muốn).
1. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
1. Truyền hình ảnh cho phương thức `ISlidesPicture.set_Image`.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình lotus](lotus.png)

Mã C++ dưới đây minh họa cách đổ một hình dạng bằng hình ảnh:

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

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Hình chữ nhật.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Đặt loại tô là Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Đặt chế độ đổ hình ảnh.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Tải một hình ảnh và thêm vào tài nguyên của bản trình bày.
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

### **Tile Picture As Texture**

Nếu bạn muốn đặt một hình ảnh lặp lại làm texture và tùy chỉnh hành vi lát gạch, bạn có thể sử dụng các phương thức sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Đặt chế độ đổ màu picture—`Tile` hoặc `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Xác định cách căn chỉnh các ô gạch trong hình dạng.
- [set_TileFlip](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Kiểm soát việc lật ô gạch theo chiều ngang, chiều dọc hoặc cả hai.
- [set_TileOffsetX](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Đặt độ lệch ngang của ô gạch (đơn vị point) từ gốc của hình dạng.
- [set_TileOffsetY](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Đặt độ lệch dọc của ô gạch (đơn vị point) từ gốc của hình dạng.
- [set_TileScaleX](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Xác định tỷ lệ ngang của ô gạch dưới dạng phần trăm.
- [set_TileScaleY](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Xác định tỷ lệ dọc của ô gạch dưới dạng phần trăm.

Mã mẫu dưới đây cho thấy cách thêm một hình chữ nhật với đổ màu picture dạng lát và cấu hình các tùy chọn ô gạch:

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

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto firstSlide = presentation->get_Slide(0);

// Thêm một auto shape dạng Hình chữ nhật.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Đặt loại tô của hình dạng thành Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Tải hình ảnh và thêm nó vào tài nguyên của bản trình bày.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Gán hình ảnh cho hình dạng.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Cấu hình chế độ đổ hình ảnh và các thuộc tính lát gạch.
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

![Các tùy chọn ô gạch](tile-options.png)

## **Đổ màu Đậm (Solid Color Fill)**

Trong PowerPoint, Đổ màu Đậm là một tùy chọn định dạng làm đầy một hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn giản này được áp dụng mà không có gradient, texture hay pattern.

Để áp dụng Đổ màu Đậm cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu tô bạn muốn cho hình dạng.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã C++ dưới đây minh họa cách áp dụng Đổ màu Đậm cho một hình chữ nhật trong slide PowerPoint:

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

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape loại Hình chữ nhật.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Đặt loại tô là Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Đặt màu tô.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Lưu tệp PPTX vào đĩa.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hình dạng với Đổ màu Đậm](solid-color-fill.png)

## **Đặt Độ trong suốt (Transparency)**

Trong PowerPoint, khi bạn áp dụng Đổ màu Đậm, gradient, picture hoặc texture cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của màu tô. Giá trị trong suốt cao làm cho hình dạng trở nên trong suốt hơn, cho phép nền hoặc các đối tượng phía dưới hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được sử dụng để tô. Cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` điều khiển độ trong suốt).
1. Lưu bản trình bày.

Mã C++ dưới đây minh họa cách áp dụng màu tô trong suốt cho một hình chữ nhật:

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

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
auto presentation = MakeObject<Presentation>();

// Lấy slide đầu tiên.
auto slide = presentation->get_Slide(0);

// Thêm một auto shape hình chữ nhật dạng đặc.
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

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình bày PowerPoint. Điều này hữu ích khi vị trí các yếu tố hình ảnh cần sự căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
1. Lưu bản trình bày.

Mã C++ dưới đây minh họa cách xoay một hình dạng 5 độ:

```cpp
#include <IAutoShape.h>
#include <IShapeCollection.h> 
```

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu ứng Bevel 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng bevel 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/threedformat/).

Để thêm hiệu ứng bevel 3D cho một hình dạng, thực hiện các bước:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/threedformat/) của hình dạng để định nghĩa các cài đặt bevel.
1. Lưu bản trình bày.

Mã C++ dưới đây cho thấy cách áp dụng hiệu ứng bevel 3D cho một hình dạng:

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

Kết quả:

![Hiệu ứng bevel 3D](3D-bevel-effect.png)

## **Thêm Hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/threedformat/).

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
1. Sử dụng [set_CameraType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icamera/set_cameratype/) và [set_LightType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilightrig/set_lighttype/) để định nghĩa xoay 3D.
1. Lưu bản trình bày.

Mã C++ dưới đây minh họa cách áp dụng hiệu ứng xoay 3D cho một hình dạng:

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

// Tạo một thể hiện của lớp Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Lưu bản trình bày dưới dạng tệp PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Kiểm soát Định dạng Đen‑Trắng cho Hình dạng**

Phương thức [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/set_blackwhitemode/) chỉ định cách một hình dạng riêng lẻ được hiển thị khi bản trình bày được xem hoặc xử lý ở chế độ đen‑trắng. Phương thức này không bật chế độ hiển thị đen‑trắng tự động và không thay đổi màu nền, viền hay định dạng khác của hình dạng trong chế độ màu bình thường.

Sử dụng một giá trị từ liệt kê [BlackWhiteMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` để ứng dụng lựa chọn chuyển đổi, `Gray` và `LightGray` sử dụng màu xám, `BlackWhite` chỉ dùng đen và trắng, `Black` và `White` buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` ẩn hình dạng trong chế độ đen‑trắng. `NotDefined` nghĩa là không có chế độ cấp cho hình dạng.

Mã C++ dưới đây tạo một hình dạng màu và làm cho nó hiển thị màu xám trong chế độ hiển thị đen‑trắng:

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

// Giữ màu nền cam trong chế độ màu, nhưng hiển thị hình dạng với màu xám trong chế độ đen-trắng.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Trong chế độ màu bình thường, hình chữ nhật vẫn giữ màu nền cam. Khi ở quy trình hiển thị đen‑trắng, nó sẽ sử dụng màu xám vì chế độ đã được đặt thành `Gray`. Điều này cho phép bạn giữ slide đầy màu trong khi định nghĩa cách hiển thị riêng cho việc in ấn, xem trước hoặc các quy trình khác tôn trọng cài đặt hiển thị đen‑trắng của bản trình bày.

## **Đặt lại Định dạng**

Mã C++ dưới đây cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/layoutslide/) về cài đặt mặc định:

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
    // Đặt lại các hình dạng trên slide có placeholder trong bố cục.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của file bản trình bày không?**

Chỉ ảnh hưởng rất ít. Hình ảnh và phương tiện nhúng chiếm phần lớn dung lượng file, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng metadata và hầu như không làm tăng kích thước.

**Làm thế nào để phát hiện các hình dạng trên slide có cùng định dạng để có thể nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—các cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là giống nhau và nhóm logic các hình dạng lại, giúp đơn giản hóa việc quản lý kiểu sau này.

**Tôi có thể lưu một bộ các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình bày khác không?**

Có. Lưu các hình mẫu có kiểu mong muốn trong một slide mẫu hoặc tệp .POTX. Khi tạo bản trình bày mới, mở mẫu, sao chép các hình mẫu cần thiết và áp dụng lại định dạng của chúng ở nơi cần.