---
title: Tạo ảnh thu nhỏ cho các hình dạng trong bản trình chiếu bằng C++
linktitle: Ảnh thu nhỏ hình dạng
type: docs
weight: 70
url: /vi/cpp/shape-thumbnails/
keywords:
- ảnh thu nhỏ hình dạng
- hình ảnh hình dạng
- kết xuất hình dạng
- kết xuất hình dạng
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tạo các ảnh thu nhỏ hình dạng chất lượng cao từ các slide PowerPoint bằng Aspose.Slides cho C++ – dễ dàng tạo và xuất ảnh thu nhỏ của bản trình chiếu."
---
## **Giới thiệu**

Aspose.Slides được sử dụng để tạo các tệp trình chiếu, trong đó mỗi trang là một slide. Các slide này có thể được xem bằng cách mở tệp trình chiếu bằng Microsoft PowerPoint. Tuy nhiên đôi khi, các nhà phát triển có thể cần xem ảnh của các hình dạng riêng biệt trong một trình xem ảnh. Trong các trường hợp như vậy, Aspose.Slides giúp bạn tạo ra các ảnh thumbnail của các hình dạng trên slide. Cách sử dụng tính năng này được mô tả trong bài viết này.  
Bài viết này giải thích cách tạo thumbnail cho slide theo các cách khác nhau:

- Tạo thumbnail cho một hình dạng bên trong một slide.  
- Tạo thumbnail cho một hình dạng trên slide với kích thước do người dùng định nghĩa.  
- Tạo thumbnail cho một hình dạng trong phạm vi hiển thị của hình dạng đó.

## **Tạo Thumbnail cho Hình dạng từ Slide**
Để tạo thumbnail cho một hình dạng từ bất kỳ slide nào bằng Aspose.Slides for C++:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
3. Lấy ảnh thumbnail của hình dạng trên slide đã tham chiếu ở tỷ lệ mặc định.
4. Lưu ảnh thumbnail ra bất kỳ định dạng ảnh mong muốn nào.

Ví dụ dưới đây tạo thumbnail cho hình dạng.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Tạo Thumbnail với Hệ số Thu Phóng Do Người Dùng Định Nghĩa**
Để tạo thumbnail cho hình dạng trên bất kỳ slide nào bằng Aspose.Slides for C++:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
3. Lấy ảnh thumbnail của slide đã tham chiếu với phạm vi hình dạng.
4. Lưu ảnh thumbnail ra bất kỳ định dạng ảnh mong muốn nào.

Ví dụ dưới đây tạo thumbnail với hệ số thu phóng do người dùng định nghĩa.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Thu phóng theo trục X và Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Tạo Thumbnail Dựa trên Phạm vi Hiển thị của Hình dạng**
Phương pháp này cho phép các nhà phát triển tạo thumbnail trong phạm vi hiển thị của hình dạng, tính đến tất cả các hiệu ứng của hình dạng. Thumbnail được tạo sẽ bị giới hạn bởi phạm vi của slide. Để tạo thumbnail cho bất kỳ hình dạng nào trên slide trong phạm vi hiển thị của nó, sử dụng đoạn mã mẫu sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
3. Lấy ảnh thumbnail của slide đã tham chiếu với phạm vi hình dạng như là hiển thị.
4. Lưu ảnh thumbnail ra bất kỳ định dạng ảnh mong muốn nào.

Ví dụ dưới đây tạo thumbnail với hệ số thu phóng do người dùng định nghĩa.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Thu phóng theo trục X và Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Các định dạng ảnh nào có thể được sử dụng khi lưu thumbnail của hình dạng?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imageformat/), và các định dạng khác. Các hình dạng cũng có thể được [xuất dưới dạng vector SVG](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/writeassvg/) bằng cách lưu nội dung của hình dạng dưới dạng SVG.

**Sự khác biệt giữa giới hạn Shape và Appearance khi tạo thumbnail là gì?**

`Shape` sử dụng hình học của hình dạng; `Appearance` tính đến [hiệu ứng trực quan](/slides/vi/cpp/shape-effect/) (bóng, hào quang, v.v.).

**Điều gì xảy ra nếu một hình dạng được đánh dấu là ẩn? Nó vẫn sẽ được tạo thumbnail không?**

Một hình dạng ẩn vẫn là một phần của mô hình và có thể được tạo; cờ ẩn chỉ ảnh hưởng đến việc hiển thị trong trình chiếu nhưng không ngăn việc tạo ảnh của hình dạng.

**Các hình dạng nhóm, biểu đồ, SmartArt và các đối tượng phức tạp khác có được hỗ trợ không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chart/), và [SmartArt](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/smartart/)) đều có thể được lưu dưới dạng thumbnail hoặc dưới dạng SVG.

**Các phông chữ được cài đặt trên hệ thống có ảnh hưởng đến chất lượng thumbnail của các hình dạng văn bản không?**

Có. Bạn nên [cung cấp các phông chữ cần thiết](/slides/vi/cpp/custom-font/) (hoặc [cấu hình thay thế phông chữ](/slides/vi/cpp/font-substitution/)) để tránh việc chuyển đổi không mong muốn và thay đổi bố cục văn bản.