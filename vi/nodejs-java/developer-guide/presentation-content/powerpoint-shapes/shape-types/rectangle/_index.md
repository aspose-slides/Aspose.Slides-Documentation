---
title: Thêm Hình Chữ Nhật vào Bản Trình Bày trong JavaScript
linktitle: Hình Chữ Nhật
type: docs
weight: 80
url: /vi/nodejs-java/rectangle/
keywords:
- thêm hình chữ nhật
- tạo hình chữ nhật
- hình dạng chữ nhật
- hình chữ nhật đơn giản
- hình chữ nhật có định dạng
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Nâng cao các bài thuyết trình PowerPoint của bạn bằng cách thêm hình chữ nhật với JavaScript và Aspose.Slides cho Node.js—thiết kế và chỉnh sửa hình dạng một cách lập trình dễ dàng."
---
## **Tổng quan**

Bài viết này trình bày cách thêm hình chữ nhật vào các slide PowerPoint bằng Aspose.Slides. Nó bao gồm việc tạo một hình chữ nhật đơn giản, tạo một hình chữ nhật có định dạng, và lưu bản trình bày đã cập nhật dưới dạng tệp PPTX.

Bạn cũng sẽ thấy cách áp dụng định dạng cơ bản cho hình chữ nhật, chẳng hạn như màu nền đặc, màu đường viền và độ rộng đường viền. Ngoài ra, phần FAQ của bài viết chỉ đến các tác vụ liên quan đến hình chữ nhật, bao gồm các góc bo tròn, nền ảnh, hiệu ứng hình ảnh, siêu liên kết, khóa hình dạng, tùy chọn xuất và các thuộc tính hiệu quả. 

## **Thêm hình chữ nhật vào Slide**

Giống như các chủ đề trước, chủ đề này cũng nói về việc thêm một hình dạng và lần này chúng ta sẽ thảo luận về Rectangle. Trong chủ đề này, chúng tôi mô tả cách các nhà phát triển có thể thêm các hình chữ nhật đơn giản hoặc có định dạng vào slide của mình bằng Aspose.Slides. 

Để thêm một hình chữ nhật đơn giản vào slide được chọn của bản trình bày, hãy làm theo các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
- Lấy tham chiếu tới một slide bằng cách sử dụng Index của nó.
- Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) loại Rectangle bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection).
- Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một hình chữ nhật đơn giản vào slide đầu tiên của bản trình bày.

```javascript
// Tạo thể hiện lớp Presentation đại diện cho PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Thêm AutoShape loại ellipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Ghi tệp PPTX vào đĩa
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thêm hình chữ nhật có định dạng vào Slide**
Để thêm một hình chữ nhật có định dạng vào slide, hãy thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
- Lấy tham chiếu tới một slide bằng cách sử dụng Index của nó.
- Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) loại Rectangle bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection).
- Đặt [Fill Type](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FillType) của Rectangle thành Solid.
- Đặt màu của Rectangle bằng phương thức [SolidFillColor.setColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) được cung cấp bởi đối tượng [FillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FillFormat) liên kết với đối tượng [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape).
- Đặt màu cho các đường viền của Rectangle.
- Đặt độ rộng cho các đường viền của Rectangle.
- Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Các bước trên được triển khai trong ví dụ dưới đây.

```javascript
// Tạo thể hiện lớp Presentation đại diện cho PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Thêm AutoShape loại ellipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Áp dụng một số định dạng cho hình ellipse
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Áp dụng một số định dạng cho đường viền của Ellipse
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Ghi tệp PPTX vào đĩa
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Làm thế nào để thêm một hình chữ nhật với các góc bo tròn?**

Sử dụng [shape type](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapetype/) có góc bo tròn và điều chỉnh bán kính góc trong các thuộc tính của shape; việc bo tròn cũng có thể áp dụng từng góc riêng qua các điều chỉnh hình học.

**Làm thế nào để đổ màu cho một hình chữ nhật bằng hình ảnh (texture)?**

Chọn [fill type](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) kiểu picture, cung cấp nguồn ảnh và cấu hình [stretching/tiling modes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillmode/).

**Một hình chữ nhật có thể có bóng và hào sáng không?**

Có. [Outer/inner shadow, glow, and soft edges](/slides/vi/nodejs-java/shape-effect/) đều khả dụng với các tham số có thể điều chỉnh.

**Tôi có thể biến một hình chữ nhật thành nút bấm có siêu liên kết không?**

Có. [Assign a hyperlink](/slides/vi/nodejs-java/manage-hyperlinks/) cho việc nhấp vào shape (chuyển tới slide, tệp, địa chỉ web hoặc email).

**Làm sao để bảo vệ một hình chữ nhật khỏi việc di chuyển và thay đổi?**

Sử dụng khóa shape: bạn có thể ngăn việc di chuyển, thay đổi kích thước, chọn hoặc chỉnh sửa văn bản để giữ nguyên bố cục.

**Tôi có thể chuyển đổi một hình chữ nhật sang hình ảnh raster hoặc SVG không?**

Có. Bạn có thể [render the shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getImage) ra ảnh với kích thước/độ thu phóng xác định hoặc [export it as SVG](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/writeassvg/) để sử dụng dạng vector.

**Làm sao để nhanh chóng lấy các thuộc tính thực tế (effective) của một hình chữ nhật xét đến theme và kế thừa?**

[Use the shape’s effective properties](/slides/vi/nodejs-java/shape-effective-properties/): API trả về các giá trị đã tính toán, bao gồm các kiểu theme, layout và cài đặt cục bộ, giúp đơn giản hoá việc phân tích định dạng.