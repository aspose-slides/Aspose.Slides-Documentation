---
title: Thêm hình chữ nhật vào bài thuyết trình trong Java
linktitle: Hình chữ nhật
type: docs
weight: 80
url: /vi/java/rectangle/
keywords:
- thêm hình chữ nhật
- tạo hình chữ nhật
- hình dạng chữ nhật
- hình chữ nhật đơn giản
- hình chữ nhật đã định dạng
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Nâng cao các bài thuyết trình PowerPoint của bạn bằng cách thêm hình chữ nhật với Aspose.Slides cho Java—dễ dàng thiết kế và chỉnh sửa các hình dạng một cách lập trình."
---
## **Tổng quan**

Bài viết này trình bày cách thêm các hình chữ nhật vào các slide PowerPoint bằng cách sử dụng Aspose.Slides. Nó bao gồm việc tạo một hình chữ nhật đơn giản, tạo một hình chữ nhật đã định dạng, và lưu bản trình chiếu đã cập nhật dưới dạng tệp PPTX.

Bạn cũng sẽ thấy cách áp dụng định dạng cơ bản cho hình chữ nhật, như màu nền đặc, màu viền và độ rộng viền. Ngoài ra, phần FAQ của bài viết chỉ đến các nhiệm vụ liên quan đến hình chữ nhật, bao gồm các góc bo tròn, nền hình ảnh, hiệu ứng hình ảnh, siêu liên kết, khoá hình dạng, các tùy chọn xuất và các thuộc tính hiệu quả.

## **Thêm hình chữ nhật vào slide**
- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số (Index) của nó.
- Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape) loại Rectangle bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection).
- Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một hình chữ nhật đơn giản vào slide đầu tiên của bản trình chiếu.

```java
// Khởi tạo lớp Presentation đại diện cho PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm AutoShape dạng ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Ghi tệp PPTX vào đĩa
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm hình chữ nhật đã định dạng vào slide**
- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số (Index) của nó.
- Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape) loại Rectangle bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection).
- Đặt [Fill Type](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FillType) của Rectangle thành Solid.
- Đặt màu của Rectangle bằng cách sử dụng phương thức [SolidFillColor.setColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) được cung cấp bởi đối tượng [IFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IFillFormat) liên kết với đối tượng [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape).
- Đặt màu của các đường viền của Rectangle.
- Đặt độ rộng của các đường viền của Rectangle.
- Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Các bước trên được thực hiện trong ví dụ dưới đây.

```java
// Khởi tạo lớp Presentation đại diện cho PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm AutoShape dạng ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Áp dụng một số định dạng cho hình ellipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Áp dụng một số định dạng cho đường viền của Ellipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Ghi tệp PPTX vào đĩa
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Làm sao tôi có thể thêm một hình chữ nhật với các góc bo tròn?**

Sử dụng [shape type](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapetype/) có góc bo tròn và điều chỉnh bán kính góc trong thuộc tính của hình; việc bo tròn cũng có thể được áp dụng riêng cho từng góc thông qua các điều chỉnh hình học.

**Làm sao tôi có thể tô nền một hình chữ nhật bằng hình ảnh (texture)?**

Chọn [fill type](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) dạng ảnh, cung cấp nguồn hình ảnh và cấu hình các [stretching/tiling modes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/picturefillmode/).

**Một hình chữ nhật có thể có bóng và ánh hào quang không?**

Có. [Outer/inner shadow, glow, and soft edges](/slides/vi/java/shape-effect/) có sẵn với các tham số có thể điều chỉnh.

**Tôi có thể biến một hình chữ nhật thành nút với siêu liên kết không?**

Có. [Assign a hyperlink](/slides/vi/java/manage-hyperlinks/) cho hành động nhấp vào hình (chuyển tới slide, tệp, địa chỉ web, hoặc email).

**Làm sao tôi có thể bảo vệ một hình chữ nhật khỏi việc di chuyển và thay đổi?**

[Use shape locks](/slides/vi/java/applying-protection-to-presentation/): bạn có thể cấm di chuyển, thay đổi kích thước, chọn hoặc chỉnh sửa văn bản để bảo toàn bố cục.

**Tôi có thể chuyển đổi một hình chữ nhật sang hình ảnh raster hoặc SVG không?**

Có. Bạn có thể [render the shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getImage-int-float-float-) thành hình ảnh với kích thước/tỷ lệ được chỉ định hoặc [export it as SVG](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) để sử dụng dưới dạng vector.

**Làm sao tôi nhanh chóng lấy các thuộc tính thực tế (effective) của một hình chữ nhật khi xét đến theme và kế thừa?**

[Use the shape’s effective properties](/slides/vi/java/shape-effective-properties/): API trả về các giá trị đã tính toán, bao gồm các kiểu theme, bố cục và cài đặt cục bộ, giúp đơn giản hóa việc phân tích định dạng.