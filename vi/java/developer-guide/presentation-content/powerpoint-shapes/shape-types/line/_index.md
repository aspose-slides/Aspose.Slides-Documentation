---
title: Thêm Các Hình dạng Đường vào Bản trình bày trong Java
linktitle: Đường
type: docs
weight: 50
url: /vi/java/line/
keywords:
- đường
- tạo đường
- thêm đường
- đường thẳng đơn giản
- cấu hình đường
- tùy chỉnh đường
- kiểu gạch
- đầu mũi tên
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Tìm hiểu cách thao tác định dạng đường trong các bản trình bày PowerPoint với Aspose.Slides for Java. Khám phá các thuộc tính, phương thức và ví dụ."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm các hình dạng đường vào các slide PowerPoint một cách lập trình. Bài viết này trình bày cách tạo một đường đơn giản và cách tùy chỉnh đường để nó hiển thị dưới dạng mũi tên.

Bạn sẽ học cách thêm một hình dạng đường vào slide, điều chỉnh giao diện trực quan của nó và lưu bản trình bày đã cập nhật. Các ví dụ tập trung vào các thiết lập định dạng đường thực tế như kiểu, độ rộng, mẫu gạch, tùy chọn đầu mũi tên và màu nền.

## **Tạo một Đường Thẳng Đơn Giản**

Để thêm một đường thẳng đơn giản vào một slide được chọn trong bản trình bày, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số (Index) của nó.
- Thêm một AutoShape loại Line bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection).
- Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một đường vào slide đầu tiên của bản trình bày.

```java
// Khởi tạo lớp PresentationEx đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Thêm một AutoShape loại line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Ghi tệp PPTX ra đĩa
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tạo Đường Thẳng Dạng Mũi Tên**

Aspose.Slides for Java cũng cho phép các nhà phát triển cấu hình một số thuộc tính của đường để làm cho nó trông hấp dẫn hơn. Hãy thử cấu hình vài thuộc tính của đường để nó giống như một mũi tên. Vui lòng thực hiện các bước sau để thực hiện:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số (Index) của nó.
- Thêm một AutoShape loại Line bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection).
- Đặt [Line Style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LineStyle) thành một trong các kiểu được Aspose.Slides for Java cung cấp.
- Đặt độ rộng (Width) của đường.
- Đặt [Dash Style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LineDashStyle) của đường thành một trong các kiểu do Aspose.Slides for Java cung cấp.
- Đặt [Arrow Head Style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LineArrowheadStyle) và [Length](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LineArrowheadLength) của điểm bắt đầu (start point) của đường.
- Đặt [Arrow Head Style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LineArrowheadStyle) và [Length](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LineArrowheadLength) của điểm kết thúc (end point) của đường.
- Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

```java
// Khởi tạo lớp PresentationEx đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm một AutoShape loại line
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

    // Ghi tệp PPTX ra đĩa
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể chuyển một đường thường thành kết nối để nó "bắt" vào các hình dạng không?**

Không. Một đường thường (một [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/) loại [Line](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapetype/)) sẽ không tự động trở thành kết nối. Để làm cho nó bắt vào các hình dạng, hãy sử dụng loại [Connector](https://reference.aspose.com/slides/vi/java/com.aspose.slides/connector/) chuyên dụng và các [API tương ứng](/slides/vi/java/connector/) để kết nối.

**Tôi nên làm gì nếu các thuộc tính của đường được kế thừa từ giao diện (theme) và khó xác định giá trị cuối cùng?**

[Đọc các thuộc tính thực tế](/slides/vi/java/shape-effective-properties/) thông qua các giao diện [ILineFormatEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinefillformateffectivedata/) — những giao diện này đã tính đến kế thừa và kiểu giao diện.

**Tôi có thể khóa một đường để ngăn chỉnh sửa (di chuyển, đổi kích thước) không?**

Có. Các hình dạng cung cấp [đối tượng khóa](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/#getAutoShapeLock--) cho phép bạn [ngăn các thao tác chỉnh sửa](/slides/vi/java/applying-protection-to-presentation/).