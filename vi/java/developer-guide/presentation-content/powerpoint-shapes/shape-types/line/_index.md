---
title: Thêm Hình Dạng Đường Vào Bản Trình Chiếu Trong Java
linktitle: Đường
type: docs
weight: 50
url: /vi/java/Line/
keywords:
- đường
- tạo đường
- thêm đường
- đường thẳng
- cấu hình đường
- tùy chỉnh đường
- kiểu gạch đứt
- đầu mũi tên
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Học cách thao tác định dạng đường trong các bản trình chiếu PowerPoint với Aspose.Slides cho Java. Khám phá các thuộc tính, phương thức và ví dụ."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm các hình dạng đường vào các slide PowerPoint một cách lập trình. Bài viết này trình bày cách tạo một đường đơn giản và cách tùy chỉnh đường sao cho nó hiển thị dưới dạng mũi tên.

Bạn sẽ học cách thêm một hình dạng đường vào slide, điều chỉnh giao diện hiển thị của nó, và lưu bản trình chiếu đã cập nhật. Các ví dụ tập trung vào các thiết lập định dạng đường thực tế như kiểu, độ rộng, mẫu gạch, tùy chọn đầu mũi tên và màu nền.

## **Tạo một đường thẳng đơn giản**

Để thêm một đường thẳng đơn giản vào slide đã chọn của bản trình chiếu, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số (Index) của nó.
- Thêm một AutoShape kiểu Line bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection).
- Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một đường vào slide đầu tiên của bản trình chiếu.

```java
// Khởi tạo lớp PresentationEx đại diện cho file PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Thêm một AutoShape kiểu line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Ghi PPTX vào đĩa
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tạo một đường có hình mũi tên**

Aspose.Slides for Java cũng cho phép các nhà phát triển cấu hình một số thuộc tính của đường để làm cho nó trông hấp dẫn hơn. Hãy thử cấu hình một vài thuộc tính của đường để nó giống như một mũi tên. Vui lòng thực hiện các bước dưới đây để thực hiện:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số (Index) của nó.
- Thêm một AutoShape kiểu Line bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection).
- Thiết lập [Line Style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LineStyle) thành một trong các kiểu được Aspose.Slides for Java cung cấp.
- Đặt độ rộng (Width) của đường.
- Thiết lập [Dash Style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LineDashStyle) của đường thành một trong các kiểu được Aspose.Slides for Java cung cấp.
- Thiết lập [Arrow Head Style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LineArrowheadStyle) và [Length](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LineArrowheadLength) của điểm bắt đầu của đường.
- Thiết lập [Arrow Head Style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LineArrowheadStyle) và [Length](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LineArrowheadLength) của điểm kết thúc của đường.
- Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```java
// Khởi tạo lớp PresentationEx đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm một AutoShape kiểu line
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Áp dụng một số định dạng cho đường
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Ghi PPTX vào đĩa
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể chuyển một đường bình thường thành connector để nó "bám" vào các hình dạng không?**

Không. Một đường bình thường (một [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/) kiểu [Line](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapetype/)) không tự động trở thành connector. Để làm cho nó bám vào các hình dạng, hãy sử dụng loại [Connector](https://reference.aspose.com/slides/vi/java/com.aspose.slides/connector/) chuyên dụng và [các API tương ứng](/slides/vi/java/connector/) cho kết nối.

**Tôi nên làm gì nếu các thuộc tính của đường được kế thừa từ theme và khó xác định giá trị cuối cùng?**

Bạn có thể [đọc các thuộc tính thực tế](/slides/vi/java/shape-effective-properties/) thông qua các giao diện [ILineFormatEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinefillformateffectivedata/)—các giao diện này đã tính đến việc kế thừa và các kiểu theme.

**Tôi có thể khóa một đường để tránh việc chỉnh sửa (di chuyển, thay đổi kích thước) không?**

Có. Các hình dạng cung cấp [đối tượng khóa](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/#getAutoShapeLock--) cho phép bạn [ngăn chặn các thao tác chỉnh sửa](/slides/vi/java/applying-protection-to-presentation/).