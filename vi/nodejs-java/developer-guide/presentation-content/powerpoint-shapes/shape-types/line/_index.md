---
title: Thêm Hình dạng Đường vào Bản trình bày trong JavaScript
linktitle: Đường
type: docs
weight: 50
url: /vi/nodejs-java/line/
keywords:
- đường
- tạo đường
- thêm đường
- đường thẳng đơn
- cấu hình đường
- tùy chỉnh đường
- kiểu gạch
- đầu mũi tên
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách thao tác định dạng đường trong các bản trình bày PowerPoint bằng JavaScript và Aspose.Slides cho Node.js. Khám phá các thuộc tính, phương thức và ví dụ."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm các hình dạng đường vào các slide PowerPoint một cách lập trình. Bài viết này cho biết cách tạo một đường đơn giản và cách tùy chỉnh một đường sao cho nó hiển thị dưới dạng mũi tên.

Bạn sẽ học cách thêm một hình dạng đường vào slide, điều chỉnh giao diện trực quan của nó và lưu bản trình bày đã cập nhật. Các ví dụ tập trung vào các cài đặt định dạng đường thực tế như kiểu, độ rộng, mẫu gạch, tùy chọn đầu mũi tên và màu nền.

## **Tạo Đường Thẳng Đơn Giản**

Để thêm một đường thẳng đơn giản vào slide đã chọn của bản trình bày, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một AutoShape loại Line bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection).
- Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một đường vào slide đầu tiên của bản trình bày.

```javascript
// Khởi tạo lớp PresentationEx đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Thêm một AutoShape loại đường
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Ghi PPTX ra đĩa
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tạo Đường Hình Mũi Tên**

Aspose.Slides for Node.js via Java cũng cho phép các nhà phát triển cấu hình một số thuộc tính của đường để làm cho nó trông hấp dẫn hơn. Hãy thử cấu hình một vài thuộc tính của đường để nó trông giống như một mũi tên. Vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một AutoShape loại Line bằng cách sử dụng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection).
- Đặt [Line Style](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/LineStyle) thành một trong các kiểu được Aspose.Slides for Node.js via Java cung cấp.
- Đặt độ rộng của đường.
- Đặt [Dash Style](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/LineDashStyle) của đường thành một trong các kiểu được Aspose.Slides for Node.js via Java cung cấp.
- Đặt [Arrow Head Style](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/LineArrowheadStyle) và [Length](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/LineArrowheadLength) của điểm bắt đầu của đường.
- Đặt [Arrow Head Style](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/LineArrowheadStyle) và [Length](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/LineArrowheadLength) của điểm kết thúc của đường.
- Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

```javascript
// Khởi tạo lớp PresentationEx đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Thêm một AutoShape loại đường
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Áp dụng một số định dạng cho đường
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Ghi PPTX ra đĩa
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể chuyển một đường thường thành kết nối để nó "bám" vào các hình dạng không?**

Không. Một đường thường (một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) loại [Line](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapetype/)) không tự động trở thành kết nối. Để làm cho nó bám vào các hình dạng, hãy sử dụng loại [Connector](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/connector/) chuyên dụng và các [corresponding APIs](/slides/vi/nodejs-java/connector/) cho việc kết nối.

**Tôi nên làm gì nếu các thuộc tính của một đường được kế thừa từ theme và khó xác định giá trị cuối cùng?**

[Đọc các thuộc tính hiệu quả](/slides/vi/nodejs-java/shape-effective-properties/) qua các lớp `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` — những lớp này đã tính tới việc kế thừa và các kiểu theme.

**Tôi có thể khóa một đường để ngăn việc chỉnh sửa (di chuyển, thay đổi kích thước) không?**

Có. Các hình dạng cung cấp [lock objects](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/getautoshapelock/) cho phép bạn ngăn các thao tác chỉnh sửa.