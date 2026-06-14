---
title: Thêm Hình Chữ Nhật vào Bản Trình Chiếu trên Android
linktitle: Hình Chữ Nhật
type: docs
weight: 80
url: /vi/androidjava/rectangle/
keywords:
- thêm hình chữ nhật
- tạo hình chữ nhật
- hình dạng chữ nhật
- hình chữ nhật đơn giản
- hình chữ nhật có định dạng
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Nâng cao các bản trình chiếu PowerPoint của bạn bằng cách thêm hình chữ nhật với Aspose.Slides cho Android qua Java—dễ dàng thiết kế và chỉnh sửa các hình dạng một cách lập trình."
---
## **Tổng quan**

Bài viết này trình bày cách thêm các hình chữ nhật vào các slide PowerPoint bằng cách sử dụng Aspose.Slides. Nó bao gồm việc tạo một hình chữ nhật đơn giản, tạo một hình chữ nhật được định dạng, và lưu bản thuyết trình đã cập nhật dưới dạng tệp PPTX.

Bạn cũng sẽ thấy cách áp dụng định dạng cơ bản cho hình chữ nhật, chẳng hạn như màu nền đặc, màu đường viền và độ dày đường viền. Ngoài ra, mục FAQ của bài viết chỉ đến các tác vụ liên quan đến hình chữ nhật, bao gồm góc bo tròn, nền hình ảnh, hiệu ứng trực quan, siêu liên kết, khóa hình dạng, tùy chọn xuất và các thuộc tính hiệu quả.

## **Thêm Hình Chữ Nhật vào Slide**
- Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) .
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
- Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAutoShape) loại Rectangle bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection) .
- Ghi bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một hình chữ nhật đơn giản vào slide đầu tiên của bản thuyết trình.

```java
// Khởi tạo lớp Presentation đại diện cho file PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm AutoShape loại ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Ghi file PPTX vào đĩa
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm Hình Chữ Nhật Định Dạng vào Slide**
- Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) .
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
- Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAutoShape) loại Rectangle bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection) .
- Đặt [Fill Type](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FillType) của Rectangle thành Solid.
- Đặt màu của Rectangle bằng phương thức [SolidFillColor.setColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) được cung cấp bởi đối tượng [IFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IFillFormat) liên kết với đối tượng [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape) .
- Đặt màu của các đường viền của Rectangle.
- Đặt độ rộng của các đường viền của Rectangle.
- Ghi bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Các bước trên được thực hiện trong ví dụ dưới đây.

```java
// Khởi tạo lớp Presentation đại diện cho file PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm AutoShape loại ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Áp dụng một số định dạng cho hình ellipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Áp dụng một số định dạng cho đường viền của Ellipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Ghi file PPTX vào đĩa
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Làm thế nào để thêm một hình chữ nhật với các góc bo tròn?**

Sử dụng [shape type](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shapetype/) có góc bo tròn và điều chỉnh bán kính góc trong các thuộc tính của shape; việc bo tròn cũng có thể được áp dụng riêng cho từng góc thông qua điều chỉnh hình học.

**Làm thế nào để điền màu cho một hình chữ nhật bằng hình ảnh (kết cấu)?**

Chọn [fill type](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) cho hình ảnh, cung cấp nguồn hình ảnh và cấu hình [stretching/tiling modes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/picturefillmode/) .

**Hình chữ nhật có thể có bóng và ánh sáng phát sáng không?**

Có. [Outer/inner shadow, glow, and soft edges](/slides/vi/androidjava/shape-effect/) có sẵn với các tham số có thể điều chỉnh.

**Tôi có thể biến một hình chữ nhật thành nút có siêu liên kết không?**

Có. [Assign a hyperlink](/slides/vi/androidjava/manage-hyperlinks/) cho việc nhấp vào shape (chuyển đến slide, tệp, địa chỉ web hoặc email) .

**Làm sao tôi có thể bảo vệ một hình chữ nhật khỏi việc di chuyển và thay đổi?**

Sử dụng khóa shape: bạn có thể ngăn việc di chuyển, thay đổi kích thước, chọn hoặc chỉnh sửa văn bản để bảo vệ bố cục.

**Tôi có thể chuyển đổi một hình chữ nhật thành ảnh raster hoặc SVG không?**

Có. Bạn có thể [render the shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) thành ảnh với kích thước/tỷ lệ nhất định hoặc [export it as SVG](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) để sử dụng vector.

**Làm sao để nhanh chóng lấy các thuộc tính thực tế (effective) của một hình chữ nhật tính đến chủ đề và kế thừa?**

[Use the shape’s effective properties](/slides/vi/androidjava/shape-effective-properties/): API trả về các giá trị đã tính toán, bao gồm các kiểu chủ đề, bố cục và cài đặt cục bộ, giúp đơn giản hoá việc phân tích định dạng.