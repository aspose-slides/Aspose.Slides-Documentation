---
title: Tạo hiệu ứng 3D trong bản trình chiếu bằng C++
linktitle: Bản trình chiếu 3D
type: docs
weight: 232
url: /vi/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- bản trình chiếu 3D
- xoay 3D
- độ sâu 3D
- đùn 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Áp dụng và render hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong C++ với Aspose.Slides. Cấu hình camera, ánh sáng, vật liệu, đùn, nền màu và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for C++ có thể tạo, chỉnh sửa, bảo tồn và render định dạng 3D kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này bao gồm các hiệu ứng 3D như xoay, đùn, bevels, ánh sáng, vật liệu, gradient hoặc picture fills, và văn bản 3D.

{{% alert color="primary" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ render các hiệu ứng 3D đó vào đầu ra 2D đã xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng phương thức [get_ThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_threedformat/) của giao diện [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) để áp dụng định dạng 3D cho một hình dạng. Phương thức này trả về [IThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/), điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng phương thức [get_ThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/get_threedformat/) của giao diện [ITextFrameFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/). Phương thức này áp dụng định dạng 3D cho khung văn bản thay vì cho thân hình dạng.

Các phương thức quan trọng nhất là:

| Phương thức | Điều khiển gì | Khi nào sử dụng |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_camera/) | Góc nhìn, loại camera cài sẵn, xoay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với cài đặt xoay 3D của PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_lightrig/) | Cài đặt ánh sáng, hướng và góc quay ánh sáng. | Thay đổi cách các điểm sáng và bóng xuất hiện trên bề mặt 3D. |
| [set_Material](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/set_material/) | Vật liệu bề mặt, như phẳng, mờ, nhựa, hoặc kim loại. | Làm cho hình dạng cùng một hình học trông phẳng hơn, mềm hơn, bóng hoặc kim loại. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Khoảng cách mà hình dạng mở rộng ra phía sau mặt trước. | Biến một hình dạng phẳng thành một đối tượng 3D có độ dày nhìn thấy được. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Màu của các mặt bên được đùn ra. | Làm cho độ sâu hiển thị hoặc đồng bộ màu bên với nền mặt trước. |
| [set_Depth](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/set_depth/) | Độ sâu 3D bổ sung được PowerPoint sử dụng trong định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt bevel và vật liệu. |
| [get_BevelTop](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_beveltop/) và [get_BevelBottom](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Các cạnh nâng lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm cạnh mềm mại hoặc đúc thay vì mặt phẳng sắc nét. |
| [get_ContourColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_contourcolor/) và [set_ContourWidth](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong kết quả render. |

## **Tạo hình dạng 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi trông thật 3D:

- Cài đặt camera, vì góc nhìn mặt trước mặc định có thể ẩn phần đùn.  
- Cài đặt ánh sáng, vì ánh sáng giúp các mặt và các cạnh trở nên rõ ràng.  
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được render.  
- Cài đặt đùn hoặc độ sâu, vì một hình dạng phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước, áp dụng định dạng 3D, lưu bản trình chiếu dưới dạng PPTX và render slide thành ảnh PNG.

```cpp
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

Hình ảnh slide được render hiển thị hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D màu xanh được render với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay hình dạng bằng Camera**

Trong PowerPoint, xoay 3D được cấu hình từ bảng điều khiển 3‑D Rotation. Các giá trị xoay X, Y và Z tương ứng với xoay bạn thiết lập qua API camera.

![Bảng điều khiển 3‑D Rotation của PowerPoint với các giá trị xoay X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, đặt loại camera và xoay qua [IThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/):

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Sử dụng camera khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides dùng khi render.

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình dạng trông dày hơn bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu đặt độ dày hiển thị này, và điều khiển màu đặt màu cho các mặt bên.

![Các điều khiển độ sâu của PowerPoint được ánh xạ tới thuộc tính màu đùn và chiều cao đùn](img_02_02.png)

Đặt [set_ExtrusionHeight](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/set_extrusionheight/) để xác định độ dày và [get_ExtrusionColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) để đặt màu mặt bên:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Sử dụng [set_Depth](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/set_depth/) khi bạn cần làm việc trực tiếp với giá trị độ sâu của PowerPoint hoặc kết hợp độ sâu với bevel, vật liệu và hiệu ứng văn bản. Trong nhiều trường hợp, `set_ExtrusionHeight` là cài đặt rõ ràng hơn vì nó biểu thị trực tiếp độ đùn nhìn thấy được.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với Hiệu ứng 3D**

Định dạng 3D độc lập với màu nền của hình. Bạn có thể áp dụng màu đặc, gradient, pattern hoặc picture fill cho mặt trước và vẫn sử dụng cùng một camera, ánh sáng, vật liệu và cài đặt đùn.

Ví dụ này áp dụng màu nền gradient cho hình và màu đùn tối hơn cho các mặt bên:

```cpp
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

Kết quả render giữ gradient trên mặt trước và render phần đùn riêng biệt:

![Hình chữ nhật 3D được render với màu nền gradient từ xanh đến cam và màu đùn cam](img_02_03.png)

Để sử dụng picture fill thay thế, thêm ảnh vào bản trình chiếu và gán nó cho màu nền của hình:

```cpp
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

Ảnh được render trên mặt trước, trong khi phần đùn được render như bề mặt 3D bên:

![Hình chữ nhật 3D được render với nền ảnh trên mặt trước và màu đùn cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D của hình ảnh ảnh hưởng đến thân hình. Định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt, nơi các chữ cái cần đùn, vật liệu, ánh sáng và cài đặt camera.

Ví dụ sau tạo văn bản với pattern fill, áp dụng biến đổi WordArt và cấu hình cài đặt 3D trên [ITextFrameFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/):

```cpp
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

Văn bản được render dưới dạng chữ 3D cong, có đùn, pattern màu cam và đùn đậm:

![Văn bản 3D được render với biến đổi WordArt cong, nền mẫu màu cam và đùn tối](img_02_05.png)

## **Hành vi Xuất và Render**

Aspose.Slides bảo tồn định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn render slide thành [PNG](/slides/vi/cpp/convert-powerpoint-to-png/), xuất sang [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), xuất sang [HTML](/slides/vi/cpp/convert-powerpoint-to-html/), hoặc tạo khung cho [video conversion](/slides/vi/cpp/convert-powerpoint-to-video/).

Lưu ý các điểm sau:

- Hình ảnh và PDF đã xuất không tương tác. Đối tượng không thể được xoay bởi người xem sau khi xuất.  
- Giao diện cuối cùng phụ thuộc vào sự kết hợp của camera, rig ánh sáng, vật liệu, đùn, nền và tỉ lệ slide.  
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên giao diện, đọc [thuộc tính hình dạng hiệu quả](/slides/vi/cpp/shape-effective-properties/).  
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D có thể chỉnh sửa của PowerPoint. Trong các định dạng đó, kết quả hình ảnh được render thay vì được giữ dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

**Aspose.Slides có thể tạo bản trình chiếu 3D tương tác không?**

Aspose.Slides tạo và render các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML xuất ra trở thành cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình chiếu. Hiệu ứng 3D là định dạng áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, chẳng hạn xoay, đùn, bevel, ánh sáng và vật liệu. Bài viết này chỉ đề cập đến hiệu ứng 3D.

**Cài đặt nào bắt buộc để một hình dạng 3D hiển thị?**

Ít nhất, cần đặt xoay camera và một trong hai: đùn hoặc độ sâu. Thực tế, cũng nên đặt rig ánh sáng và vật liệu để các mặt được render có điểm sáng và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) cho thân hình và [ITextFrameFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides render hiệu ứng 3D khi tạo ảnh slide, output PDF, output HTML và các khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh đã render, không phải đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc giá trị 3D cuối cùng sau khi áp dụng kế thừa và giao diện không?**

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [Shape Effective Properties](/slides/vi/cpp/shape-effective-properties/) để đọc camera, rig ánh sáng, bevel và các giá trị 3D liên quan cuối cùng.