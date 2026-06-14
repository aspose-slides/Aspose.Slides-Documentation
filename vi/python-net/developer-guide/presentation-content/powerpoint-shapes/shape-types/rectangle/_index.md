---
title: Thêm các hình chữ nhật vào bản trình bày bằng Python
linktitle: Hình chữ nhật
type: docs
weight: 80
url: /vi/python-net/rectangle/
keywords:
- thêm hình chữ nhật
- tạo hình chữ nhật
- hình dạng hình chữ nhật
- hình chữ nhật đơn giản
- hình chữ nhật có định dạng
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Nâng cao các bản trình bày PowerPoint & OpenDocument của bạn bằng cách thêm hình chữ nhật với Aspose.Slides cho Python qua .NET—dễ dàng thiết kế và chỉnh sửa các hình dạng một cách lập trình."
---
## **Tổng quan**

Bài viết này trình bày cách thêm các hình chữ nhật vào các slide PowerPoint bằng cách sử dụng Aspose.Slides. Nó bao gồm việc tạo một hình chữ nhật đơn giản, tạo một hình chữ nhật có định dạng, và lưu bản trình bày đã cập nhật dưới dạng tệp PPTX. Bạn cũng sẽ thấy cách áp dụng định dạng cơ bản cho hình chữ nhật, như màu nền đặc, màu đường viền và độ rộng đường viền. Ngoài ra, phần FAQ của bài viết chỉ tới các nhiệm vụ liên quan đến hình chữ nhật, bao gồm góc bo tròn, đổ ảnh, hiệu ứng trực quan, siêu liên kết, khóa hình, tùy chọn xuất và các thuộc tính thực tế.

## **Tạo hình chữ nhật đơn giản**
Như các chủ đề trước, mục này cũng nói về việc thêm một hình và lần này hình mà chúng ta sẽ thảo luận là Rectangle. Trong chủ đề này, chúng tôi đã mô tả cách các nhà phát triển có thể thêm các hình chữ nhật đơn giản hoặc có định dạng vào slide của họ bằng Aspose.Slides for Python via .NET. Để thêm một hình chữ nhật đơn giản vào một slide được chọn của bản trình bày, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/)class.
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
3. Thêm một IAutoShape loại Rectangle bằng cách sử dụng phương thức AddAutoShape được cung cấp bởi đối tượng IShapes.
4. Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một hình chữ nhật đơn giản vào slide đầu tiên của bản trình bày.

```py
import aspose.slides as slides

# Tạo một lớp Presentation đại diện cho PPTX
with slides.Presentation() as pres:
    # Lấy slide đầu tiên
    sld = pres.slides[0]

    # Thêm autoshape loại rectangle
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Ghi tệp PPTX vào đĩa
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tạo hình chữ nhật có định dạng**
Để thêm một hình chữ nhật có định dạng vào slide, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/)class.
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
3. Thêm một IAutoShape loại Rectangle bằng cách sử dụng phương thức AddAutoShape được cung cấp bởi đối tượng IShapes.
4. Đặt kiểu đổ màu của Rectangle thành Solid.
5. Đặt màu của Rectangle bằng thuộc tính SolidFillColor.Color được cung cấp bởi đối tượng FillFormat liên kết với đối tượng IShape.
6. Đặt màu của các đường viền của Rectangle.
7. Đặt độ rộng của các đường viền của Rectangle.
8. Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Các bước trên được thực hiện trong ví dụ dưới đây.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho PPTX
with slides.Presentation() as pres:
    # Lấy slide đầu tiên
    sld = pres.slides[0]

    # Thêm autoshape loại rectangle
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Áp dụng một số định dạng cho hình chữ nhật
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Áp dụng một số định dạng cho đường viền của hình chữ nhật
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Ghi tệp PPTX vào đĩa
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Làm thế nào để thêm một hình chữ nhật với các góc bo tròn?**

Sử dụng [shape type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapetype/) có góc bo tròn và điều chỉnh bán kính góc trong thuộc tính của hình; việc bo tròn cũng có thể được áp dụng cho từng góc thông qua điều chỉnh hình học.

**Làm sao để đổ màu cho hình chữ nhật bằng một hình ảnh (texture)?**

Chọn [fill type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/filltype/) kiểu hình ảnh, cung cấp nguồn ảnh, và cấu hình [stretching/tiling modes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillmode/).

**Một hình chữ nhật có thể có bóng và ánh sáng phát sáng không?**

Có. [Outer/inner shadow, glow, and soft edges](/slides/vi/python-net/shape-effect/) có sẵn với các tham số có thể điều chỉnh.

**Tôi có thể biến một hình chữ nhật thành nút với siêu liên kết không?**

Có. [Assign a hyperlink](/slides/vi/python-net/manage-hyperlinks/) cho hành động click vào hình (nhảy tới slide, tệp, địa chỉ web, hoặc email).

**Làm sao tôi có thể bảo vệ một hình chữ nhật khỏi việc di chuyển và thay đổi?**

Sử dụng [shape locks](/slides/vi/python-net/applying-protection-to-presentation/): bạn có thể ngăn chặn việc di chuyển, thay đổi kích thước, chọn, hoặc chỉnh sửa văn bản để bảo toàn bố cục.

**Tôi có thể chuyển đổi một hình chữ nhật thành hình ảnh raster hoặc SVG không?**

Có. Bạn có thể [render the shape](http://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_image/) thành ảnh với kích thước/tỷ lệ được chỉ định hoặc [export it as SVG](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/write_as_svg/) để sử dụng dạng vector.

**Làm sao tôi nhanh chóng lấy các thuộc tính thực tế (effective) của một hình chữ nhật khi xét đến theme và kế thừa?**

Sử dụng [shape’s effective properties](/slides/vi/python-net/shape-effective-properties/): API trả về các giá trị đã tính toán, tính đến style theme, bố cục và cài đặt cục bộ, giúp đơn giản hoá việc phân tích định dạng.