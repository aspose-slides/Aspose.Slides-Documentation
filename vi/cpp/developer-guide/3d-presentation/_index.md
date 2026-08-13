---
title: Tạo hiệu ứng 3D trong bài thuyết trình bằng C++
linktitle: Bài thuyết trình 3D
type: docs
weight: 232
url: /vi/cpp/3d-presentation/
keywords:
- PowerPoint 3D
- bài thuyết trình 3D
- xoay 3D
- độ sâu 3D
- đùn 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Áp dụng và hiển thị các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong C++ với Aspose.Slides. Cấu hình camera, ánh sáng, vật liệu, đùn, màu nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for C++ có thể tạo, chỉnh sửa, giữ lại và hiển thị định dạng 3D theo phong cách PowerPoint cho các hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như xoay, đùn, viền, ánh sáng, vật liệu, tô màu gradient hoặc hình ảnh, và văn bản 3D.

{{% alert color="info" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không đề cập đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide sang hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ hiển thị các hiệu ứng 3D đó trong kết quả 2D đã xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng phương thức [get_ThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_threedformat/) của giao diện [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) để áp dụng định dạng 3D cho một hình dạng. Phương thức này trả về [IThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/), điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng phương thức [get_ThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/get_threedformat/) của giao diện [ITextFrameFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/). Điều này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các phương pháp quan trọng nhất là:

| Phương thức | Điều gì nó điều khiển | Khi nào nên sử dụng |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_camera/) | Góc nhìn, loại camera preset, xoay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một preset xoay 3D của PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_lightrig/) | Preset ánh sáng, hướng và góc quay ánh sáng. | Thay đổi cách các điểm sáng và bóng xuất hiện trên bề mặt 3D. |
| [set_Material](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/set_material/) | Vật liệu bề mặt, như phẳng, mờ, nhựa, hoặc kim loại. | Làm cho hình học cùng dạng trông phẳng hơn, mềm hơn, bóng hoặc kim loại. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Khoảng cách hình mở rộng ra phía sau mặt trước. | Biến một hình phẳng thành đối tượng 3D dày có thể nhìn thấy. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Màu của các mặt bên bị đùn. | Làm cho độ sâu hiển thị hoặc phối màu mặt bên với màu nền mặt trước. |
| [set_Depth](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/set_depth/) | Độ sâu 3D bổ sung được PowerPoint sử dụng cho định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với thiết lập bevel và vật liệu. |
| [get_BevelTop](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_beveltop/) và [get_BevelBottom](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Các cạnh được nâng lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm cạnh mềm mại hoặc được tạo khuôn thay vì mặt phẳng sắc nét. |
| [get_ContourColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_contourcolor/) và [set_ContourWidth](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong kết quả hiển thị. |

## **Tạo một Hình 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi nó trông thực sự 3D:

- Cài đặt camera, vì góc nhìn mặt trước mặc định có thể ẩn phần đùn.
- Cài đặt ánh sáng, vì ánh sáng giúp các mặt và các bên dễ nhìn.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được hiển thị.
- Cài đặt đùn hoặc độ sâu, vì một hình phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước, áp dụng định dạng 3D, lưu bản trình chiếu dưới dạng PPTX và xuất slide ra hình PNG.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hình ảnh slide đã render hiển thị hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D màu xanh được render với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay một Hình bằng Camera**

Trong PowerPoint, việc xoay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị xoay X, Y và Z tương ứng với việc xoay bạn thiết lập qua API camera.

![Bảng 3-D Rotation của PowerPoint với các giá trị xoay X, Y và Z được làm nổi bật](img_02_01.png)

Trong Aspose.Slides, thiết lập loại camera và góc quay qua [IThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/):

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Sử dụng camera khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides sử dụng khi render.

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình dạng trông dày bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu đặt độ dày hiển thị này, và điều khiển màu đặt màu cho các mặt bên.

![Các điều khiển độ sâu của PowerPoint được ánh xạ tới thuộc tính màu đùn và chiều cao đùn](img_02_02.png)

Thiết lập [set_ExtrusionHeight](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/set_extrusionheight/) cho độ dày và [get_ExtrusionColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) cho màu mặt bên:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Sử dụng [set_Depth](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/set_depth/) khi bạn cần làm việc trực tiếp với giá trị độ sâu của PowerPoint hoặc kết hợp độ sâu với bevel, vật liệu và hiệu ứng văn bản. Trong nhiều trường hợp hình dạng, `set_ExtrusionHeight` là cài đặt rõ ràng hơn vì nó diễn đạt trực tiếp độ đùn có thể nhìn thấy.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với Hiệu ứng 3D**

Định dạng 3D độc lập với việc đổ màu cho hình dạng. Bạn có thể áp dụng màu đặc, gradient, họa tiết hoặc hình ảnh cho mặt trước và vẫn sử dụng cùng các cài đặt camera, ánh sáng, vật liệu và đùn.

Ví dụ này áp dụng màu gradient cho hình và màu đùn tối hơn cho các mặt bên:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

Kết quả render giữ gradient trên mặt trước và render đùn riêng biệt:

![Hình chữ nhật 3D được render với màu gradient từ xanh đến cam và đùn màu cam](img_02_03.png)

Để sử dụng đổ hình ảnh thay thế, thêm hình ảnh vào bản trình chiếu và gán nó làm màu nền cho hình:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Hình ảnh được render trên mặt trước, trong khi đùn được render như bề mặt bên 3D:

![Hình chữ nhật 3D được render với màu nền ảnh trên mặt trước và đùn màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D cho hình ảnh ảnh hưởng đến phần thân hình dạng. Định dạng 3D cho văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt, nơi các ký tự cần đùn, vật liệu, ánh sáng và cài đặt camera.

Ví dụ sau tạo văn bản với màu nền họa tiết, áp dụng biến đổi WordArt và cấu hình cài đặt 3D trên [ITextFrameFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/):

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Văn bản được render dưới dạng chữ 3D cong, đùn:

![Văn bản 3D được render với biến đổi WordArt cong, màu nền họa tiết màu cam và đùn màu tối](img_02_05.png)

## **Hành vi Xuất và Render**

Aspose.Slides giữ lại định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D sẽ được raster hóa hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn render slide sang [PNG](/slides/vi/cpp/convert-powerpoint-to-png/), xuất sang [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), xuất sang [HTML](/slides/vi/cpp/convert-powerpoint-to-html/), hoặc tạo khung cho [chuyển đổi video](/slides/vi/cpp/convert-powerpoint-to-video/).

Hãy nhớ các điểm sau:

- Hình ảnh và PDF đã xuất không có tính tương tác. Đối tượng không thể được người xem xoay sau khi xuất.
- Giao diện cuối cùng phụ thuộc vào sự kết hợp của camera, hệ thống ánh sáng, vật liệu, đùn, màu nền và tỷ lệ slide.
- Nếu cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên giao diện, đọc [effective shape properties](/slides/vi/cpp/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D có thể chỉnh sửa của PowerPoint. Trong các định dạng đó, kết quả hiển thị được render thay vì được giữ lại dưới dạng cài đặt 3D có thể chỉnh sửa.

## **FAQ**

### Aspose.Slides có thể tạo bản trình bày 3D tương tác không?

Aspose.Slides tạo và render các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML đã xuất thành các cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint nếu định dạng hỗ trợ.

### Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?

Mô hình 3D là một đối tượng 3D riêng được chèn vào bản trình bày. Hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, như xoay, đùn, bevel, ánh sáng và vật liệu. Bài viết này đề cập đến các hiệu ứng 3D.

### Cài đặt nào bắt buộc để có một hình 3D có thể nhìn thấy?

Tối thiểu, cần thiết lập góc quay camera và hoặc đùn hoặc độ sâu. Thực tế, cũng nên thiết lập hệ thống ánh sáng và vật liệu để các mặt được render có điểm sáng và bóng rõ ràng.

### Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?

Có. Sử dụng [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) cho phần thân hình dạng và [ITextFrameFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/) cho văn bản.

### Các hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?

Có. Aspose.Slides render các hiệu ứng 3D khi tạo hình ảnh slide, đầu ra PDF, HTML và các khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa giao diện đã render, không phải đối tượng 3D có thể chỉnh sửa.

### Tôi có thể đọc các giá trị 3D cuối cùng sau khi áp dụng kế thừa và cài đặt giao diện không?

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [Shape Effective Properties](/slides/vi/cpp/shape-effective-properties/) để đọc các giá trị camera, hệ thống ánh sáng, bevel và các giá trị 3D liên quan cuối cùng.