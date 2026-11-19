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
- nhô ra 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Áp dụng và render các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong C++ bằng Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, nhô ra, màu nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for C++ có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như xoay, nhô ra, viền chùm, chiếu sáng, vật liệu, màu nền gradient hoặc hình ảnh, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide sang hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ hiển thị các hiệu ứng 3D đó vào kết quả 2D đã xuất.
{{% /alert %}}

## **Các khái niệm định dạng 3D**

Sử dụng phương thức [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) để áp dụng định dạng 3D cho một hình dạng. Phương thức này trả về [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/), chịu trách nhiệm điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng phương thức [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/). Điều này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các phương thức quan trọng nhất là:

| Phương thức | Điều gì nó điều khiển | Khi nào sử dụng |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | Điểm nhìn, loại máy ảnh preset, xoay, phóng to và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một preset xoay 3D của PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | Preset ánh sáng, hướng và xoay ánh sáng. | Thay đổi cách các điểm nhấn và bóng xuất hiện trên bề mặt 3D. |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | Vật liệu bề mặt, chẳng hạn phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng một hình học trông phẳng hơn, mềm hơn, bóng hoặc kim loại. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Khoảng mà hình dạng mở rộng ra phía sau từ mặt trước. | Biến một hình dạng phẳng thành một đối tượng 3D dày nhìn thấy được. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Màu của các mặt bên được nhô ra. | Làm cho độ sâu hiển thị hoặc phối màu mặt bên với màu nền phía trước. |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | Độ sâu 3D bổ sung được PowerPoint sử dụng trong định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt bevel và vật liệu. |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) và [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Các cạnh nhô lên hoặc làm tròn trên mặt trước và mặt sau. | Thêm cạnh mềm mại hoặc đúc thay vì mặt phẳng sắc nhọn. |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) và [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong kết quả hiển thị. |

## **Tạo một hình dạng 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi nó trông thuyết phục là 3D:

- Cài đặt máy ảnh, vì góc nhìn mặt trước mặc định có thể ẩn phần nhô ra.  
- Cài đặt ánh sáng, vì ánh sáng giúp các mặt và các cạnh trở nên rõ ràng.  
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được hiển thị.  
- Cài đặt nhô ra hoặc độ sâu, vì một hình dạng phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Các giá trị xoay máy ảnh được tính bằng độ, và chiều cao nhô ra là 100 điểm. Ví dụ này hiển thị slide thành ảnh PNG với kích thước gấp đôi mặc định và lưu bản trình chiếu dưới dạng PPTX.

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
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

![Hình 3D chữ nhật màu xanh lam được render với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay một hình dạng bằng Máy ảnh**

Trong PowerPoint, việc xoay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị xoay X, Y và Z tương ứng với việc xoay bạn đặt qua API máy ảnh.

![Bảng PowerPoint 3-D Rotation với các giá trị xoay X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, truy cập máy ảnh qua [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn mặt trước trực giao, và đặt các góc xoay X, Y, Z thành 20, 30 và 40 độ, tương ứng. Nó cấu hình hình dạng trong bộ nhớ mà không lưu file:

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

presentation->Dispose();
```

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình dạng trên slide. Nó thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides dùng khi render.

### **Sao chép hướng máy ảnh từ một hình mẫu**

Để khớp hướng máy ảnh của một hình mẫu, đọc preset của nó bằng [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) và áp dụng bằng [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/). Ví dụ mở `template.pptx` và sao chép hướng máy ảnh từ hình dạng đầu tiên trên slide đầu tiên sang hình dạng thứ hai. Cả hai hình đều đã có ánh sáng 3D, và hình thứ hai không có xoay máy ảnh rõ ràng.

[GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) trả về các góc tính bằng độ. Chỉ mục `0` là vĩ độ, chỉ mục `1` là kinh độ, và chỉ mục `2` là vòng quay. Gửi các góc này tới [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) theo thứ tự đó. Nếu nguồn không có xoay rõ ràng, `GetRotation` trả về con trỏ null, vì vậy để nguyên góc của hình thứ hai không được đặt. Một xoay rõ ràng `(0, 0, 0)` trả về một mảng ba số 0 và nên được sao chép.

```cpp
#include <DOM/ICamera.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

auto sourceCamera = slide->get_Shape(0)->get_ThreeDFormat()->get_Camera();
auto destinationCamera = slide->get_Shape(1)->get_ThreeDFormat()->get_Camera();

destinationCamera->set_CameraType(sourceCamera->get_CameraType());
auto angles = sourceCamera->GetRotation();
if (angles != nullptr)
{
    destinationCamera->SetRotation(angles[0], angles[1], angles[2]);
}

presentation->Save(u"camera-copy.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Khi bạn mở lại `camera-copy.pptx` trong PowerPoint, mũi tên bên phải có cùng preset máy ảnh và xoay như hình chữ nhật bên trái. Cả hai hình đều sử dụng cùng ánh sáng và độ sâu nhô ra.

![Một hình chữ nhật 3D màu xanh và một mũi tên hướng sang phải với hướng máy ảnh khớp, xem từ trên và bên phải](camera-orientation.png)

## **Thêm Nhô ra và Độ sâu**

Nhô ra làm cho một hình dạng trông dày bằng cách kéo nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu thiết lập độ dày hiển thị này, và điều khiển màu thiết lập màu của các mặt bên.

![Các điều khiển độ sâu trong PowerPoint được ánh xạ tới thuộc tính màu nhô ra và chiều cao nhô ra](img_02_02.png)

Đặt [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) cho độ dày và [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) cho màu mặt bên. Ví dụ này cho hình chữ nhật một nhô ra 100 điểm với các mặt bên màu tím và xoay máy ảnh để lộ độ dày. Nó cấu hình hình dạng trong bộ nhớ mà không lưu file:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

Phương thức [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) đặt độ sâu cho một hình dạng 3D. Phương thức [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) kiểm soát chiều cao của hiệu ứng nhô ra, như trong ví dụ này.

## **Sử dụng màu nền Gradient hoặc Hình ảnh với hiệu ứng 3D**

Định dạng 3D độc lập với màu nền của hình dạng. Bạn có thể áp dụng màu đặc, gradient, mẫu hoặc màu nền hình ảnh cho mặt trước và vẫn sử dụng cùng máy ảnh, ánh sáng, vật liệu và cài đặt nhô ra.

Ví dụ này áp dụng gradient từ xanh lam đến cam cho mặt trước và màu cam đậm cho phần nhô ra 150 điểm. Các điểm dừng gradient tại 0 và 100 đánh dấu đầu và cuối gradient. Các giá trị xoay máy ảnh tính bằng độ. Slide được render thành ảnh PNG với kích thước gấp đôi mặc định:

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
<DOM/ITextFrame.h>
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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
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

Hình ảnh đã render giữ gradient trên mặt trước và render nhô ra riêng biệt:

![Hình 3D chữ nhật với màu nền gradient từ xanh lam sang cam và nhô ra màu cam](img_02_03.png)

Để sử dụng màu nền hình ảnh thay thế, thêm ảnh vào bản trình chiếu và gán nó cho màu nền của hình dạng. Ví dụ này yêu cầu một tệp hiện có có tên "image.jpg" trong thư mục làm việc. Nó kéo dài ảnh để phủ toàn bộ hình chữ nhật, áp dụng nhô ra 150 điểm, và đặt xoay máy ảnh tính bằng độ. Nó cấu hình hình dạng trong bộ nhớ mà không lưu hoặc render file:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

Ảnh được render trên mặt trước, trong khi nhô ra được render như bề mặt bên 3D:

![Hình 3D chữ nhật với màu nền ảnh trên mặt trước và nhô ra màu cam](img_02_04.png)

## **Áp dụng định dạng 3D cho Văn bản**

Định dạng 3D của hình dạng ảnh hưởng tới phần thân hình dạng. Định dạng 3D của văn bản ảnh hưởng tới khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt mà các ký tự cần nhô ra, vật liệu, ánh sáng và cài đặt máy ảnh.

Ví dụ sau tạo văn bản với mẫu lưới cam‑trắng, áp dụng vòm cong lên trên, và cấu hình cài đặt 3D qua [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/). Chiều cao nhô ra và độ sâu tính bằng điểm, và xoay ánh sáng tính bằng độ. Màu nền và viền của hình dạng được ẩn để chỉ văn bản hiển thị. Ví dụ này render ảnh PNG với kích thước gấp đôi slide mặc định và lưu bản trình chiếu dưới dạng PPTX:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
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

Văn bản được render dưới dạng chữ 3D cong, nhô ra:

![Văn bản 3D được render với biến dạng WordArt vòm cong, mẫu màu cam và nhô ra tối màu](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình dạng 3D**

Để giữ văn bản dễ đọc trong khi duy trì diện mạo 3D của hình dạng, gọi [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/) qua [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/). Khi giá trị là `true`, văn bản nằm ngoài cảnh 3D. Khi là `false`, văn bản tham gia vào cảnh và tuân theo hướng 3D.

Cài đặt này không loại bỏ định dạng 3D của hình dạng: máy ảnh, ánh sáng, vật liệu và nhô ra vẫn được cấu hình qua [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/). Nó cũng khác với xoay thông thường. [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) xoay hình dạng trong mặt phẳng slide, trong khi [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) điều khiển xoay tùy chỉnh của văn bản trong khung bao. Giữ văn bản ngoài cảnh 3D không reset bất kỳ góc nào trong hai trường hợp trên.

Ví dụ tự chứa sau tạo một hình chữ nhật xanh với văn bản và sao chép nó bên cạnh bản gốc. Cả hai hình đều có cùng định dạng 3D; chỉ cài đặt văn bản khác nhau: `false` ở bên trái và `true` ở bên phải. Các góc máy ảnh tính bằng độ, và chiều cao nhô ra là 40 điểm. Ví dụ lưu bản trình chiếu dưới dạng PPTX và render slide so sánh thành PNG với kích thước gấp đôi mặc định.

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

![Hai hình chữ nhật 3D cạnh nhau: KeepTextFlat là false ở bên trái và true ở bên phải](keep_text_flat.png)

## **Xuất và hành vi Render**

Aspose.Slides bảo tồn định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D sẽ được raster hoá hoặc vẽ vào đầu ra như một kết quả 2D. Điều này áp dụng khi bạn render slide thành [PNG](/slides/vi/cpp/convert-powerpoint-to-png/), xuất sang [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), xuất sang [HTML](/slides/vi/cpp/convert-powerpoint-to-html/), hoặc tạo khung cho [chuyển đổi video](/slides/vi/cpp/convert-powerpoint-to-video/).

- Hình ảnh và PDF đã xuất không tương tác. Đối tượng không thể được người xem xoay sau khi xuất.  
- Giao diện cuối cùng phụ thuộc vào sự kết hợp của máy ảnh, bộ ánh sáng, vật liệu, nhô ra, màu nền và tỉ lệ slide.  
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên giao diện, đọc [các thuộc tính hình dạng hiệu quả](/slides/vi/cpp/shape-effective-properties/).  
- Một số định dạng đầu ra không thể lưu định dạng 3D PowerPoint có thể chỉnh sửa. Trong các định dạng đó, kết quả trực quan được render thay vì được giữ dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

**Aspose.Slides có thể tạo bài trình chiếu 3D tương tác không?**  
Aspose.Slides tạo và render các hiệu ứng 3D PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML xuất ra trở thành cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác biệt giữa mô hình 3D và hiệu ứng 3D là gì?**  
Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình chiếu. Hiệu ứng 3D là định dạng áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, như xoay, nhô ra, bevel, ánh sáng và vật liệu. Bài viết này chỉ đề cập đến hiệu ứng 3D.

**Cài đặt nào cần thiết để một hình dạng 3D hiển thị?**  
Ít nhất, đặt xoay máy ảnh và một trong hai: nhô ra hoặc độ sâu. Thực tế, cũng nên đặt bộ ánh sáng và vật liệu để các mặt được render có điểm nhấn và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**  
Có. Dùng [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) cho phần thân hình dạng và [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?**  
Có. Aspose.Slides render hiệu ứng 3D khi tạo ảnh slide, xuất PDF, xuất HTML và tạo khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh render, không phải đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc giá trị 3D cuối cùng sau khi áp dụng kế thừa và cài đặt giao diện không?**  
Có. Sử dụng API định dạng hiệu quả được mô tả trong [các thuộc tính hình dạng hiệu quả](/slides/vi/cpp/shape-effective-properties/) để đọc máy ảnh, bộ ánh sáng, bevel và các giá trị 3D liên quan cuối cùng.