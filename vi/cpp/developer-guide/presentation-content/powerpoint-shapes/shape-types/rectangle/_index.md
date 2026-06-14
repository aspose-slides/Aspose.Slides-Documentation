---
title: Thêm hình chữ nhật vào bản trình bày trong C++
linktitle: Hình chữ nhật
type: docs
weight: 80
url: /vi/cpp/rectangle/
keywords:
- thêm hình chữ nhật
- tạo hình chữ nhật
- hình chữ nhật
- hình chữ nhật đơn giản
- hình chữ nhật định dạng
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Nâng cao các bản trình bày PowerPoint của bạn bằng cách thêm hình chữ nhật với Aspose.Slides cho C++ — thiết kế và chỉnh sửa các hình dạng một cách dễ dàng lập trình."
---
## **Tổng quan**

Bài viết này hướng dẫn cách thêm các hình chữ nhật vào các slide PowerPoint bằng cách sử dụng Aspose.Slides. Nó bao gồm việc tạo một hình chữ nhật đơn giản, tạo một hình chữ nhật có định dạng, và lưu bản trình bày đã cập nhật dưới dạng tệp PPTX.

## **Tạo một Hình chữ nhật Đơn giản**
Giống như các chủ đề trước, chủ đề này cũng nói về việc thêm một hình dạng và lần này hình dạng chúng ta sẽ thảo luận là Rectangle. Trong chủ đề này, chúng tôi mô tả cách các nhà phát triển có thể thêm các hình chữ nhật đơn giản hoặc có định dạng vào slide của mình bằng Aspose.Slides cho C++. Để thêm một hình chữ nhật đơn giản vào slide đã chọn của bản trình bày, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của[Presentation class](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
1. Thêm một IAutoShape loại Rectangle bằng phương thức AddAutoShape được cung cấp bởi đối tượng IShapes.
1. Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một hình chữ nhật đơn giản vào slide đầu tiên của bản trình bày.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Tạo một Hình chữ nhật Được Định dạng**
Để thêm một hình chữ nhật có định dạng vào slide, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của[Presentation class](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
1. Thêm một IAutoShape loại Rectangle bằng phương thức AddAutoShape được cung cấp bởi đối tượng IShapes.
1. Đặt Fill Type của Rectangle thành Solid.
1. Đặt Color của Rectangle bằng thuộc tính SolidFillColor.Color được cung cấp bởi đối tượng FillFormat liên kết với đối tượng IShape.
1. Đặt Color của các đường viền của Rectangle.
1. Đặt Width của các đường viền của Rectangle.
1. Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.
   Các bước trên được thực hiện trong ví dụ dưới đây.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**Làm thế nào để tôi thêm một hình chữ nhật có các góc bo tròn?**

Sử dụng [shape type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapetype/) có góc bo tròn và điều chỉnh bán kính góc trong thuộc tính của hình; việc bo tròn cũng có thể áp dụng cho từng góc qua các điều chỉnh geometry.

**Làm thế nào để tôi tô đầy một hình chữ nhật bằng hình ảnh (texture)?**

Chọn [fill type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) picture, cung cấp nguồn hình ảnh, và cấu hình [stretching/tiling modes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/picturefillmode/).

**Một hình chữ nhật có thể có bóng và glow không?**

Có. [Outer/inner shadow, glow, and soft edges](/slides/vi/cpp/shape-effect/) có sẵn với các tham số có thể điều chỉnh.

**Tôi có thể biến một hình chữ nhật thành nút bấm với siêu liên kết không?**

Có. [Assign a hyperlink](/slides/vi/cpp/manage-hyperlinks/) cho hành động click vào hình (chuyển tới slide, tệp, địa chỉ web hoặc email).

**Làm sao để bảo vệ một hình chữ nhật khỏi việc di chuyển và thay đổi?**

[Sử dụng shape locks](/slides/vi/cpp/applying-protection-to-presentation/): bạn có thể ngăn việc di chuyển, thay đổi kích thước, chọn, hoặc chỉnh sửa văn bản để giữ nguyên bố cục.

**Tôi có thể chuyển đổi một hình chữ nhật thành hình raster hoặc SVG không?**

Có. Bạn có thể [render the shape](http://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getimage/) thành hình ảnh với kích thước/độ thu phóng xác định hoặc [export it as SVG](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/writeassvg/) để sử dụng dưới dạng vector.

**Làm sao để tôi nhanh chóng lấy các thuộc tính thực tế (effective) của một hình chữ nhật khi tính đến theme và kế thừa?**

[Sử dụng các thuộc tính effective của shape](/slides/vi/cpp/shape-effective-properties/): API trả về các giá trị đã tính toán, bao gồm các kiểu theme, layout và cài đặt cục bộ, giúp đơn giản hoá việc phân tích định dạng.