---
title: Quản lý các hình dạng trong bản trình chiếu bằng C++
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/cpp/shape-manipulations/
keywords:
- hình dạng PowerPoint
- hình dạng bản trình chiếu
- hình dạng trên slide
- tìm hình dạng
- sao chép hình dạng
- xóa hình dạng
- ẩn hình dạng
- thay đổi thứ tự hình dạng
- lấy ID hình dạng Interop
- văn bản thay thế cho hình dạng
- định dạng bố cục hình dạng
- hình dạng dưới dạng SVG
- hình dạng sang SVG
- căn chỉnh hình dạng
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Học cách tạo, chỉnh sửa và tối ưu hóa các hình dạng trong Aspose.Slides cho C++ và cung cấp các bản trình chiếu PowerPoint hiệu năng cao."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các hình dạng trong bản trình chiếu bằng Aspose.Slides. Nó cho thấy cách tìm một hình dạng trên slide, sao chép nó, xóa nó, ẩn nó, thay đổi thứ tự, lấy ID hình dạng Interop, và đặt văn bản thay thế để nhận dạng và xử lý tiếp.

Nó cũng đề cập đến cách truy cập các định dạng bố cục cho hình dạng, kết xuất một hình dạng dưới dạng SVG, căn chỉnh các hình dạng trên slide, và sử dụng các thuộc tính lật để tạo ảnh phản chiếu ngang và dọc. Ngoài ra, bài viết bao gồm một phần FAQ ngắn về việc kết hợp hình dạng, thứ tự xếp chồng và khóa hình dạng.

## **Tìm một Hình dạng trên Slide**
Bài này sẽ mô tả một kỹ thuật đơn giản giúp các nhà phát triển dễ dàng tìm một hình dạng cụ thể trên slide mà không cần sử dụng Id nội bộ của nó. Điều quan trọng là các tệp PowerPoint Presentation không có cách nào khác để xác định các hình dạng trên slide ngoại trừ Id duy nhất nội bộ. Điều này khiến các nhà phát triển gặp khó khăn khi tìm một hình dạng bằng Id duy nhất nội bộ. Tất cả các hình dạng được thêm vào slide đều có một số Văn bản thay thế. Chúng tôi khuyên các nhà phát triển nên sử dụng Văn bản thay thế để tìm một hình dạng cụ thể. Bạn có thể sử dụng MS PowerPoint để định nghĩa Văn bản thay thế cho các đối tượng mà bạn dự định sẽ thay đổi trong tương lai.

Sau khi thiết lập Văn bản thay thế cho bất kỳ hình dạng mong muốn nào, bạn có thể mở bản trình chiếu đó bằng Aspose.Slides for C++ và duyệt qua tất cả các hình dạng được thêm vào một slide. Trong mỗi vòng lặp, bạn có thể kiểm tra Văn bản thay thế của hình dạng và hình dạng có Văn bản thay thế khớp sẽ là hình dạng bạn cần. Để minh họa kỹ thuật này một cách tốt hơn, chúng tôi đã tạo một phương thức [FindShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) đặt thực hiện việc tìm một hình dạng cụ thể trong slide và trả về hình dạng đó.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **Sao chép một Hình dạng**
Để sao chép một hình dạng vào slide bằng Aspose.Slides for C++:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
3. Truy cập bộ sưu tập hình dạng của slide nguồn.
4. Thêm một slide mới vào bản trình chiếu.
5. Sao chép các hình dạng từ bộ sưu tập hình dạng của slide nguồn sang slide mới.
6. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Ví dụ dưới đây thêm một nhóm hình dạng vào một slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **Xóa một Hình dạng**
Aspose.Slides for C++ cho phép các nhà phát triển xóa bất kỳ hình dạng nào. Để xóa hình dạng khỏi bất kỳ slide nào, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Truy cập slide đầu tiên.
3. Tìm hình dạng có Văn bản thay thế cụ thể.
4. Xóa hình dạng.
5. Lưu tệp lên đĩa.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **Ẩn một Hình dạng**
Aspose.Slides for C++ cho phép các nhà phát triển ẩn bất kỳ hình dạng nào. Để ẩn hình dạng khỏi bất kỳ slide nào, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Truy cập slide đầu tiên.
3. Tìm hình dạng có Văn bản thay thế cụ thể.
4. Ẩn hình dạng.
5. Lưu tệp lên đĩa.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **Thay đổi Thứ tự Hình dạng**
Aspose.Slides for C++ cho phép các nhà phát triển thay đổi thứ tự các hình dạng. Thay đổi thứ tự xác định hình dạng nào ở phía trước và hình dạng nào ở phía sau. Để thay đổi thứ tự hình dạng trên bất kỳ slide nào, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Truy cập slide đầu tiên.
3. Thêm một hình dạng.
4. Thêm một đoạn văn bản vào khung văn bản của hình dạng.
5. Thêm một hình dạng nữa với cùng tọa độ.
6. Thay đổi thứ tự các hình dạng.
7. Lưu tệp lên đĩa.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Lấy ID Hình dạng Interop**
Aspose.Slides for C++ cho phép các nhà phát triển lấy một định danh hình dạng duy nhất trong phạm vi slide, khác với thuộc tính UniqueId cho phép lấy định danh duy nhất trong phạm vi bản trình chiếu. Thuộc tính OfficeInteropShapeId đã được thêm vào giao diện IShape và lớp Shape. Giá trị trả về bởi thuộc tính OfficeInteropShapeId tương ứng với giá trị Id của đối tượng Microsoft.Office.Interop.PowerPoint.Shape. Dưới đây là đoạn mã mẫu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **Đặt Thuộc tính AlternativeText**
Aspose.Slides for C++ cho phép các nhà phát triển đặt AlternativeText cho bất kỳ hình dạng nào. Để đặt AlternativeText cho một hình dạng, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Truy cập slide đầu tiên.
3. Thêm bất kỳ hình dạng nào vào slide.
4. Thực hiện một số thao tác với hình dạng vừa thêm.
5. Duyệt qua các hình dạng để tìm một hình dạng.
6. Đặt AlternativeText.
7. Lưu tệp lên đĩa.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **Truy cập Định dạng Bố cục cho một Hình dạng**
Aspose.Slides for C++ cho phép các nhà phát triển truy cập các định dạng bố cục cho một hình dạng. Bài viết này minh họa cách bạn có thể truy cập các thuộc tính **FillFormat** và **LineFormat** của một hình dạng.

Dưới đây là đoạn mã mẫu.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Kết xuất một Hình dạng dưới dạng SVG**
Bây giờ Aspose.Slides cho C++ hỗ trợ việc kết xuất một hình dạng dưới dạng SVG. Phương thức WriteAsSvg (và các overload) đã được thêm vào lớp Shape và giao diện IShape. Phương thức này cho phép lưu nội dung của hình dạng dưới dạng tệp SVG. Đoạn mã dưới đây cho thấy cách xuất hình dạng của slide sang tệp SVG.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Căn chỉnh Hình dạng**
Aspose.Slides cho phép căn chỉnh các hình dạng hoặc tương đối với lề slide hoặc tương đối với nhau. Để thực hiện việc này, một phương thức overload [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) đã được thêm vào. Kiểu enum [ShapesAlignmentType](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) định nghĩa các tùy chọn căn chỉnh có thể.

**Ví dụ 1**

Mã nguồn dưới đây căn chỉnh các hình dạng với chỉ số 1, 2 và 4 dọc theo rìa trên của slide.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**Ví dụ 2**

Ví dụ dưới đây cho thấy cách căn chỉnh toàn bộ bộ sưu tập hình dạng tương đối với hình dạng ở dưới cùng của bộ sưu tập.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **Thuộc tính Lật**

Trong Aspose.Slides, lớp [ShapeFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapeframe/) cung cấp khả năng kiểm soát việc lật ngang và dọc của các hình dạng thông qua các thuộc tính `flipH` và `flipV`. Cả hai thuộc tính đều có kiểu [NullableBool](https://reference.aspose.com/slides/vi/cpp/aspose.slides/nullablebool/), cho phép giá trị `True` để chỉ lật, `False` để không lật, hoặc `NotDefined` để sử dụng hành vi mặc định. Các giá trị này có thể truy cập từ [Frame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_frame/) của một hình dạng.

Để thay đổi cài đặt lật, một thể hiện [ShapeFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapeframe/) mới được khởi tạo với vị trí và kích thước hiện tại của hình dạng, các giá trị mong muốn cho `flipH` và `flipV`, và góc xoay. Gán thể hiện này cho [Frame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_frame/) của hình dạng và lưu bản trình chiếu sẽ áp dụng các biến đổi lật và ghi chúng vào tệp đầu ra.

Giả sử chúng ta có tệp sample.pptx trong đó slide đầu tiên chứa một hình dạng duy nhất với cài đặt lật mặc định, như hình dưới đây.

![The shape to be flipped](shape_to_be_flipped.png)

Đoạn mã sau đây lấy các thuộc tính lật hiện tại của hình dạng và lật nó cả chiều ngang và chiều dọc.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Lấy thuộc tính lật ngang của hình dạng.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Lấy thuộc tính lật dọc của hình dạng.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Lật ngang.
auto flipV = NullableBool::True; // Lật ngang.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![The flipped shape](flipped_shape.png)

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp các hình dạng (hợp/điểm giao/khấu) trên một slide giống như trong trình chỉnh sửa Desktop không?**

Không có API thao tác Boolean tích hợp. Bạn có thể xấp xỉ bằng cách tự tạo đường viền mong muốn—ví dụ, tính toán hình học kết quả (qua [GeometryPath](https://reference.aspose.com/slides/vi/cpp/aspose.slides/geometrypath/)) và tạo một hình dạng mới với đường viền đó, tùy chọn xóa các hình dạng gốc.

**Làm thế nào tôi có thể kiểm soát thứ tự xếp chồng (z-order) để một hình dạng luôn ở trên cùng?**

Thay đổi thứ tự chèn/di chuyển trong bộ sưu tập [shapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseslide/get_shapes/) của slide. Để có kết quả dự đoán được, hãy hoàn thiện z-order sau khi đã thực hiện mọi thay đổi khác trên slide.

**Tôi có thể “khóa” một hình dạng để ngăn người dùng chỉnh sửa nó trong PowerPoint không?**

Có. Đặt các cờ bảo vệ ở cấp độ hình dạng (/slides/vi/cpp/applying-protection-to-presentation/) (ví dụ: khóa lựa chọn, di chuyển, thay đổi kích thước, chỉnh sửa văn bản). Nếu cần, có thể áp dụng các hạn chế tương tự trên master hoặc layout. Lưu ý đây là bảo vệ ở mức giao diện người dùng, không phải tính năng bảo mật; để bảo vệ mạnh hơn, kết hợp với các hạn chế cấp tệp như [đề xuất chỉ đọc hoặc mật khẩu](/slides/vi/cpp/password-protected-presentation/).