---
title: Thêm Các Hình Dạng Đường Vào Bản Trình Chiếu trên Android
linktitle: Đường
type: docs
weight: 50
url: /vi/androidjava/line/
keywords:
- đường
- tạo đường
- thêm đường
- đường đơn giản
- cấu hình đường
- tùy chỉnh đường
- kiểu gạch
- đầu mũi tên
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách thao tác định dạng đường trong các bản trình chiếu PowerPoint với Aspose.Slides cho Android. Khám phá các thuộc tính, phương thức và ví dụ Java."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm các hình dạng đường vào các slide PowerPoint một cách lập trình. Bài viết này chỉ ra cách tạo một đường đơn giản và cách tùy chỉnh đường để nó hiển thị như một mũi tên.

Bạn sẽ học cách thêm một hình dạng đường vào slide, điều chỉnh giao diện hiển thị của nó, và lưu bản trình chiếu đã cập nhật. Các ví dụ tập trung vào các cài đặt định dạng đường thực tế như kiểu, độ rộng, mẫu gạch, tùy chọn đầu mũi tên và màu nền.

## **Tạo đường đơn giản**

Để thêm một đường đơn giản vào slide được chọn của bản trình chiếu, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số (Index) của nó.
- Thêm một AutoShape loại Line bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection).
- Ghi bản trình chiếu đã chỉnh sửa dưới dạng file PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một đường vào slide đầu tiên của bản trình chiếu.

```java
// Tạo một thể hiện của lớp PresentationEx đại diện cho tệp PPTX
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

## **Tạo đường dạng mũi tên**

Aspose.Slides for Android via Java cũng cho phép các nhà phát triển cấu hình một số thuộc tính của đường để làm cho nó trông hấp dẫn hơn. Hãy thử cấu hình một vài thuộc tính của đường để nó trông giống mũi tên. Vui lòng làm theo các bước dưới đây để thực hiện:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số (Index) của nó.
- Thêm một AutoShape loại Line bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection).
- Đặt [Line Style](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/LineStyle) thành một trong các kiểu được Aspose.Slides for Android via Java cung cấp.
- Đặt Width (độ rộng) cho đường.
- Đặt [Dash Style](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/LineDashStyle) cho đường thành một trong các kiểu do Aspose.Slides for Android via Java cung cấp.
- Đặt [Arrow Head Style](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/LineArrowheadStyle) và [Length](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/LineArrowheadLength) của điểm bắt đầu của đường.
- Đặt [Arrow Head Style](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/LineArrowheadStyle) và [Length](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/LineArrowheadLength) của điểm kết thúc của đường.
- Ghi bản trình chiếu đã chỉnh sửa dưới dạng file PPTX.

```java
// Tạo một thể hiện của lớp PresentationEx đại diện cho tệp PPTX
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

**Tôi có thể chuyển một đường thường thành connector để nó “bắt dính” vào các hình không?**

Không. Một đường thường (một [AutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/autoshape/) loại [Line](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shapetype/)) sẽ không tự động trở thành connector. Để làm cho nó bắt dính vào các hình, hãy sử dụng loại [Connector](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/connector/) chuyên dụng và các [API tương ứng](/slides/vi/androidjava/connector/) để kết nối.

**Nếu các thuộc tính của một đường được kế thừa từ theme và khó xác định giá trị cuối cùng, tôi nên làm gì?**

[Đọc các thuộc tính hiệu quả](/slides/vi/androidjava/shape-effective-properties/) thông qua các giao diện [ILineFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — chúng đã tính đến việc kế thừa và kiểu theme.

**Tôi có thể khóa một đường để ngăn chỉnh sửa (di chuyển, thay đổi kích thước) không?**

Có. Các hình dạng cung cấp [đối tượng khóa](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) cho phép bạn ngăn các thao tác chỉnh sửa.