---
title: Quản lý dấu dữ liệu biểu đồ trong bản trình bày bằng JavaScript
linktitle: Dấu dữ liệu
type: docs
url: /vi/nodejs-java/chart-data-marker/
keywords:
- biểu đồ
- điểm dữ liệu
- dấu
- tùy chọn dấu
- kích thước dấu
- loại tô
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách tùy chỉnh dấu dữ liệu biểu đồ trong Aspose.Slides cho Node.js, nâng cao tác động của bản trình bày trên các định dạng PPT và PPTX với các ví dụ mã rõ ràng."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các dấu dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách tạo biểu đồ, truy cập một series và các điểm dữ liệu của nó, áp dụng màu ảnh vào các dấu ở mức điểm dữ liệu, điều chỉnh kích thước dấu, và lưu bản trình bày đã cập nhật. Nó cũng lưu ý rằng các hình dạng dấu tiêu chuẩn có sẵn qua enumeration `MarkerStyleType` và rằng ngoại hình của dấu được bảo toàn khi xuất biểu đồ sang các định dạng raster hoặc SVG.

## **Cài đặt tùy chọn dấu biểu đồ**

Các dấu có thể được đặt trên các điểm dữ liệu biểu đồ trong các series cụ thể. Để cài đặt tùy chọn dấu biểu đồ, hãy làm theo các bước sau:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
- Tạo biểu đồ mặc định.
- Đặt hình ảnh.
- Lấy series biểu đồ đầu tiên.
- Thêm điểm dữ liệu mới.
- Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt tùy chọn dấu biểu đồ ở mức điểm dữ liệu.

```javascript
// Tạo bản trình bày trống
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Tạo biểu đồ mặc định
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Lấy chỉ mục WorkSheet dữ liệu biểu đồ mặc định
    var defaultWorksheetIndex = 0;
    // Lấy WorkSheet dữ liệu biểu đồ
    var fact = chart.getChartData().getChartDataWorkbook();
    // Xóa series mẫu
    chart.getChartData().getSeries().clear();
    // Thêm series mới
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Tải hình ảnh 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Tải hình ảnh 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Lấy series biểu đồ đầu tiên
    var series = chart.getChartData().getSeries().get_Item(0);
    // Thêm điểm mới (1:3) ở đó.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // Thay đổi dấu series biểu đồ
    series.getMarker().setSize(15);
    // Lưu bản trình bày kèm biểu đồ
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Những hình dạng dấu nào có sẵn ngay lập tức?**

Các hình dạng tiêu chuẩn có sẵn (hình tròn, hình vuông, hình kim cương, hình tam giác, v.v.); danh sách được định nghĩa bởi enumeration [MarkerStyleType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markerstyletype/). Nếu bạn cần một hình dạng không tiêu chuẩn, hãy sử dụng dấu với màu ảnh để mô phỏng các hình ảnh tùy chỉnh.

**Các dấu có được giữ nguyên khi xuất biểu đồ ra ảnh hoặc SVG không?**

Có. Khi render biểu đồ sang [định dạng raster](/slides/vi/nodejs-java/convert-powerpoint-to-png/) hoặc lưu [hình dạng dưới dạng SVG](/slides/vi/nodejs-java/render-a-slide-as-an-svg-image/), các dấu giữ nguyên ngoại hình và cài đặt của chúng, bao gồm kích thước, màu nền và viền.