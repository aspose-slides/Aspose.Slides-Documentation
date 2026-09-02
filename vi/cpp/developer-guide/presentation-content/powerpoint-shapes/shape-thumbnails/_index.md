---
title: Tạo hình thu nhỏ cho các hình dạng trong bản trình chiếu bằng C++
linktitle: Hình Thu Nhỏ Hình Dạng
type: docs
weight: 70
url: /vi/cpp/shape-thumbnails/
keywords:
- hình thu nhỏ hình dạng
- hình ảnh hình dạng
- render hình dạng
- kết xuất hình dạng
- giới hạn hiển thị
- giới hạn hình dạng
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tạo hình thu nhỏ hình dạng chất lượng cao từ các slide PowerPoint với Aspose.Slides cho C++ – dễ dàng tạo và xuất hình thu nhỏ bản trình chiếu."
---
## **Giới thiệu**

Aspose.Slides được sử dụng để tạo tệp trình chiếu, trong đó mỗi trang là một slide. Các slide này có thể được xem bằng cách mở tệp trình chiếu bằng Microsoft PowerPoint. Tuy nhiên, đôi khi các nhà phát triển có thể cần xem hình ảnh của các hình dạng riêng biệt trong một trình xem ảnh. Trong các trường hợp đó, Aspose.Slides giúp bạn tạo hình thu nhỏ của các hình dạng trong slide. Cách sử dụng tính năng này được mô tả trong bài viết này.  
Bài viết này giải thích cách tạo hình thu nhỏ slide theo các cách khác nhau:

- Tạo hình thu nhỏ cho một hình dạng trong slide.  
- Tạo hình thu nhỏ cho một hình dạng slide với kích thước do người dùng định nghĩa.  
- Tạo hình thu nhỏ cho một hình dạng trong giới hạn hiển thị của hình dạng.

## **Tạo hình thu nhỏ hình dạng từ một slide**
Để tạo hình thu nhỏ cho một hình dạng từ bất kỳ slide nào bằng Aspose.Slides cho C++:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).  
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.  
1. Lấy hình thu nhỏ của hình dạng trên slide đã tham chiếu với tỷ lệ mặc định.  
1. Lưu hình thu nhỏ tới bất kỳ định dạng ảnh mong muốn nào.

Ví dụ dưới đây tạo hình thu nhỏ cho hình dạng.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Tạo hình thu nhỏ với hệ số co giãn do người dùng định nghĩa**
Để tạo hình thu nhỏ cho một hình dạng slide bất kỳ bằng Aspose.Slides cho C++:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).  
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.  
1. Lấy hình thu nhỏ của slide đã tham chiếu kèm giới hạn hình dạng.  
1. Lưu hình thu nhỏ tới bất kỳ định dạng ảnh mong muốn nào.

Ví dụ dưới đây tạo hình thu nhỏ với hệ số co giãn do người dùng định nghĩa.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Tỉ lệ theo các trục X và Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Tạo hình thu nhỏ dựa trên giới hạn hiển thị của hình dạng**
Phương pháp này để tạo hình thu nhỏ cho các hình dạng cho phép các nhà phát triển tạo hình thu nhỏ trong giới hạn hiển thị của hình dạng. Nó tính đến tất cả các hiệu ứng của hình dạng. Hình thu nhỏ được tạo sẽ bị giới hạn bởi khung slide. Để tạo hình thu nhỏ cho bất kỳ hình dạng slide nào trong giới hạn hiển thị của nó, sử dụng đoạn mã mẫu sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).  
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.  
1. Lấy hình thu nhỏ của slide đã tham chiếu với giới hạn hình dạng như là hiển thị.  
1. Lưu hình thu nhỏ tới bất kỳ định dạng ảnh mong muốn nào.

Ví dụ dưới đây tạo một hình thu nhỏ với việc tạo hình thu nhỏ với hệ số co giãn do người dùng định nghĩa.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Tỉ lệ theo các trục X và Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Lấy giới hạn hiển thị thực tế của một hình dạng**

Các thuộc tính khung của [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/)—`IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()`, và `IShape::get_Height()`—miêu tả hình chữ nhật được lưu trong mô hình trình chiếu. Nội dung thực tế được vẽ có thể mở rộng ra ngoài khung đó hoặc chiếm một hình chữ nhật khác được căn trục. Xoay, viền, mũi tên, bố cục và tràn văn bản, hình học SmartArt được tạo ra, và các hiệu ứng rendering khác đều có thể thay đổi diện tích chiếm dụng.

Sử dụng [Shape::GetVisualBounds](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getvisualbounds/) để tính toán diện tích này mà không cần tạo ảnh. Phương thức trả về một [RectangleF](https://reference.aspose.com/slides/vi/cpp/system.drawing/rectanglef/) trong tọa độ slide. Hình chữ nhật trả về không bị cắt theo slide, vì vậy tọa độ của nó có thể âm khi nội dung mở rộng ra ngoài gốc slide.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getvisualbounds/) hiện chưa được khai báo trong giao diện [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/). Do đó, giữ hình dạng lấy được từ bộ sưu tập hình dạng của slide dưới dạng giá trị giao diện và chỉ thực hiện ép kiểu khi gọi phương thức.

Ví dụ sau lấy và so sánh khung và giới hạn hiển thị:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

[RectangleF](https://reference.aspose.com/slides/vi/cpp/system.drawing/rectanglef/) có thể được sử dụng để căn chỉnh các hình dạng gần nhau theo cạnh `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` hoặc `RectangleF::get_Bottom()`; dự trữ đủ không gian trong bố cục được tạo; hoặc phát hiện nội dung ngoài vùng cho phép. Giới hạn hiển thị đặc biệt hữu ích cho SmartArt, ô văn bản, mũi tên, hình ảnh, hình dạng quay, và nhóm hình dạng, nơi khung lưu trữ có thể không phản ánh đầy đủ kết quả rendering.

Sử dụng [Shape::GetVisualBounds](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getvisualbounds/) khi bạn cần tọa độ cho bố cục hoặc xác thực và không cần bitmap. Sử dụng [IShape::GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/getimage/) khi bạn cần render hình dạng. Với [ShapeThumbnailBounds](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` định kích thước ảnh dựa trên giới hạn hình dạng, bao gồm cài đặt viền, trong khi `ShapeThumbnailBounds::Appearance` định kích thước dựa trên hiển thị của hình dạng và giới hạn kết quả trong khung slide. Ngược lại, [Shape::GetVisualBounds](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getvisualbounds/) chỉ trả về hình chữ nhật đã tính và không cắt nó theo slide.

## **Câu hỏi thường gặp**

**Các định dạng ảnh nào có thể sử dụng khi lưu hình thu nhỏ hình dạng?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imageformat/), và các định dạng khác. Các hình dạng cũng có thể được [xuất ra dưới dạng SVG vector](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/writeassvg/) bằng cách lưu nội dung hình dạng dưới dạng SVG.

**Sự khác biệt giữa giới hạn Shape và Appearance khi render một hình thu nhỏ là gì?**

`Shape` sử dụng hình học của hình dạng; `Appearance` tính đến [các hiệu ứng hình ảnh](/slides/vi/cpp/shape-effect/) (bóng, ánh sáng, v.v.).

**Nếu một hình dạng được đánh dấu là ẩn thì sẽ thế nào? Nó vẫn được render thành hình thu nhỏ không?**

Một hình dạng ẩn vẫn là một phần của mô hình và có thể được render; cờ ẩn ảnh hưởng đến việc hiển thị trong chế độ chiếu slide nhưng không ngăn việc tạo ảnh của hình dạng.

**Các nhóm hình dạng, biểu đồ, SmartArt và các đối tượng phức tạp khác có được hỗ trợ không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chart/), và [SmartArt](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/smartart/)) đều có thể được lưu dưới dạng hình thu nhỏ hoặc SVG.

**Phông chữ được cài đặt trên hệ thống có ảnh hưởng đến chất lượng hình thu nhỏ cho các hình dạng văn bản không?**

Có. Bạn nên [cung cấp các phông chữ cần thiết](/slides/vi/cpp/custom-font/) (hoặc [cấu hình thay thế phông chữ](/slides/vi/cpp/font-substitution/)) để tránh việc fallback không mong muốn và thay đổi bố cục văn bản.