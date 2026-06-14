---
title: Quản lý các dấu dữ liệu biểu đồ trong bản trình bày bằng Java
linktitle: Dấu dữ liệu
type: docs
url: /vi/java/chart-data-marker/
keywords:
- biểu đồ
- điểm dữ liệu
- dấu
- tùy chọn dấu
- kích thước dấu
- kiểu nền
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Tìm hiểu cách tùy chỉnh dấu dữ liệu biểu đồ trong Aspose.Slides cho Java, nâng cao hiệu quả bản trình bày trên các định dạng PPT và PPTX với các ví dụ mã Java rõ ràng."
---
## **Overview**

Bài viết này giải thích cách làm việc với các dấu dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách tạo biểu đồ, truy cập một series và các điểm dữ liệu của nó, áp dụng nền ảnh cho các dấu ở mức điểm dữ liệu, điều chỉnh kích thước dấu, và lưu bản trình bày đã cập nhật. Nó cũng lưu ý rằng các hình dạng dấu tiêu chuẩn có sẵn qua enumeration `MarkerStyleType` và rằng giao diện dấu được giữ nguyên khi xuất biểu đồ sang định dạng raster hoặc SVG.

## **Set Chart Marker Options**
Các dấu có thể được đặt trên các điểm dữ liệu của biểu đồ trong một series cụ thể. Để thiết lập tùy chọn dấu biểu đồ, vui lòng làm theo các bước dưới đây:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
- Tạo biểu đồ mặc định.
- Đặt hình ảnh.
- Lấy series biểu đồ đầu tiên.
- Thêm điểm dữ liệu mới.
- Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã thiết lập tùy chọn dấu biểu đồ ở mức độ các điểm dữ liệu.

```java
// Tạo bản trình bày trống
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Tạo biểu đồ mặc định
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Lấy chỉ mục WorkSheet dữ liệu biểu đồ mặc định
    int defaultWorksheetIndex = 0;
    
    // Lấy WorkSheet dữ liệu biểu đồ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Xóa series demo
    chart.getChartData().getSeries().clear();
    
    // Thêm series mới
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Tải hình ảnh 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Tải hình ảnh 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Lấy series biểu đồ đầu tiên
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Thêm điểm mới (1:3) ở đó.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Thay đổi dấu series biểu đồ
    series.getMarker().setSize(15);
    
    // Lưu bản trình bày có biểu đồ
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Những hình dạng dấu nào có sẵn mặc định?**

Các hình dạng tiêu chuẩn có sẵn (hình tròn, hình vuông, hình thoi, hình tam giác, v.v.); danh sách được định nghĩa bởi lớp [MarkerStyleType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markerstyletype/). Nếu bạn cần một hình dạng không tiêu chuẩn, hãy sử dụng dấu với nền ảnh để mô phỏng hình ảnh tùy chỉnh.

**Các dấu có được giữ nguyên khi xuất biểu đồ thành ảnh hoặc SVG không?**

Có. Khi render biểu đồ sang [raster formats](/slides/vi/java/convert-powerpoint-to-png/) hoặc lưu [shapes as SVG](/slides/vi/java/render-a-slide-as-an-svg-image/), các dấu giữ nguyên giao diện và cài đặt của chúng, bao gồm kích thước, nền và viền.