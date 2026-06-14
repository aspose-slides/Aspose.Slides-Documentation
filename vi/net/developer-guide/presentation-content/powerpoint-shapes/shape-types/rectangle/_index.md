---
title: Thêm Hình Chữ Nhật vào Bản Trình Bày trong .NET
linktitle: Hình Chữ Nhật
type: docs
weight: 80
url: /vi/net/rectangle/
keywords:
- thêm hình chữ nhật
- tạo hình chữ nhật
- hình dạng hình chữ nhật
- hình chữ nhật đơn giản
- hình chữ nhật có định dạng
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Nâng cao các bài thuyết trình PowerPoint của bạn bằng cách thêm hình chữ nhật với Aspose.Slides cho .NET—dễ dàng thiết kế và chỉnh sửa các hình dạng một cách lập trình."
---
## **Tổng quan**

Bài viết này hướng dẫn cách thêm các hình chữ nhật vào các slide PowerPoint bằng cách sử dụng Aspose.Slides. Nó bao gồm việc tạo một hình chữ nhật đơn giản, tạo một hình chữ nhật có định dạng, và lưu bản trình bày đã cập nhật dưới dạng tệp PPTX.  
Bạn cũng sẽ thấy cách áp dụng định dạng cơ bản cho hình chữ nhật, chẳng hạn màu nền đặc, màu viền và độ rộng viền. Ngoài ra, phần FAQ của bài viết chỉ đến các tác vụ liên quan đến hình chữ nhật, bao gồm góc bo tròn, nền hình ảnh, hiệu ứng trực quan, siêu liên kết, khoá hình dạng, tùy chọn xuất và các thuộc tính hiệu quả.

## **Tạo một Hình Chữ Nhật Đơn Giản**
Giống như các chủ đề trước, mục này cũng nói về việc thêm một hình dạng và lần này hình dạng chúng ta sẽ thảo luận là Hình Chữ Nhật. Trong chủ đề này, chúng tôi đã mô tả cách mà các nhà phát triển có thể thêm các hình chữ nhật đơn giản hoặc có định dạng vào slide của họ bằng cách sử dụng Aspose.Slides cho .NET. Để thêm một hình chữ nhật đơn giản vào một slide được chọn của bản trình bày, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)class.
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
3. Thêm một IAutoShape loại Rectangle bằng phương thức AddAutoShape được cung cấp bởi đối tượng IShapes.
4. Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một hình chữ nhật đơn giản vào slide đầu tiên của bản trình bày.

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{

    // Lấy slide đầu tiên
    ISlide sld = pres.Slides[0];

    // Thêm autoshape kiểu hình chữ nhật
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //Ghi tệp PPTX ra đĩa
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Tạo một Hình Chữ Nhật Có Định Dạng**
Để thêm một hình chữ nhật có định dạng vào slide, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)class.
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
3. Thêm một IAutoShape loại Rectangle bằng phương thức AddAutoShape được cung cấp bởi đối tượng IShapes.
4. Đặt Kiểu Đổ màu của Rectangle thành Solid.
5. Đặt Màu của Rectangle bằng thuộc tính SolidFillColor.Color được cung cấp bởi đối tượng FillFormat liên kết với đối tượng IShape.
6. Đặt Màu của các đường viền của Rectangle.
7. Đặt Độ rộng của các đường viền của Rectangle.
8. Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Các bước trên được thực hiện trong ví dụ dưới đây.

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{

    // Lấy slide đầu tiên
    ISlide sld = pres.Slides[0];

    // Thêm autoshape kiểu hình chữ nhật
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Áp dụng một số định dạng cho hình dạng hình chữ nhật
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Áp dụng một số định dạng cho đường viền của hình chữ nhật
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Write tệp PPTX ra đĩa
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Làm thế nào để thêm một hình chữ nhật với góc bo tròn?**  
Sử dụng [shape type](https://reference.aspose.com/slides/vi/net/aspose.slides/shapetype/) có góc bo tròn và điều chỉnh bán kính góc trong thuộc tính của hình; việc bo tròn cũng có thể được áp dụng cho từng góc thông qua các điều chỉnh hình học.

**Làm thế nào để đổ màu cho một hình chữ nhật bằng hình ảnh (texture)?**  
Chọn [fill type](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của ảnh, cung cấp nguồn hình ảnh và cấu hình [stretching/tiling modes](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillmode/).

**Một hình chữ nhật có thể có bóng và phát sáng không?**  
Có. [Outer/inner shadow, glow, and soft edges](/slides/vi/net/shape-effect/) có sẵn với các tham số có thể điều chỉnh.

**Tôi có thể biến một hình chữ nhật thành nút với siêu liên kết không?**  
Có. [Assign a hyperlink](/slides/vi/net/manage-hyperlinks/) cho việc nhấp vào hình dạng (đi đến một slide, tệp, địa chỉ web hoặc email).

**Làm thế nào để bảo vệ một hình chữ nhật khỏi việc di chuyển và thay đổi?**  
[Use shape locks](/slides/vi/net/applying-protection-to-presentation/): bạn có thể cấm di chuyển, thay đổi kích thước, chọn hoặc chỉnh sửa văn bản để giữ nguyên bố cục.

**Tôi có thể chuyển đổi một hình chữ nhật thành hình ảnh raster hoặc SVG không?**  
Có. Bạn có thể [render the shape](http://reference.aspose.com/slides/vi/net/aspose.slides/shape/getimage/) thành hình ảnh với kích thước/tỷ lệ được chỉ định hoặc [export it as SVG](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/writeassvg/) để sử dụng dạng vector.

**Làm thế nào để nhanh chóng lấy các thuộc tính thực tế (effective) của một hình chữ nhật khi xét đến chủ đề và kế thừa?**  
[Use the shape’s effective properties](/slides/vi/net/shape-effective-properties/): API trả về các giá trị đã tính toán, bao gồm các kiểu chủ đề, bố cục và cài đặt cục bộ, giúp đơn giản hoá việc phân tích định dạng.