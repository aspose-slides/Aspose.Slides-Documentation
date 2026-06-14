---
title: Quản lý các biểu tượng dữ liệu biểu đồ trong bản trình chiếu trên Android
linktitle: Biểu tượng dữ liệu
type: docs
url: /vi/androidjava/chart-data-marker/
keywords:
- biểu đồ
- điểm dữ liệu
- biểu tượng
- tùy chọn biểu tượng
- kích thước biểu tượng
- loại tô
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tùy chỉnh các biểu tượng dữ liệu biểu đồ trong Aspose.Slides cho Android, tăng cường hiệu quả bản trình chiếu trên các định dạng PPT và PPTX với các ví dụ mã Java rõ ràng."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các biểu tượng dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách tạo biểu đồ, truy cập một series và các điểm dữ liệu của nó, áp dụng điền ảnh vào các biểu tượng ở mức điểm dữ liệu, điều chỉnh kích thước biểu tượng và lưu bản trình chiếu đã cập nhật. Nó cũng lưu ý rằng các hình dạng biểu tượng tiêu chuẩn có sẵn qua enumeration `MarkerStyleType` và rằng giao diện biểu tượng được giữ nguyên khi xuất biểu đồ sang các định dạng raster hoặc SVG.

## **Cài đặt tùy chọn biểu tượng biểu đồ**
Các biểu tượng có thể được đặt trên các điểm dữ liệu của biểu đồ trong một series cụ thể. Để thiết lập các tùy chọn biểu tượng biểu đồ, vui lòng thực hiện các bước dưới đây:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) class.
- Tạo biểu đồ mặc định.
- Đặt hình ảnh.
- Lấy series biểu đồ đầu tiên.
- Thêm điểm dữ liệu mới.
- Ghi bản trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã cài đặt các tùy chọn biểu tượng biểu đồ ở mức điểm dữ liệu.

```java
// Tạo bản trình chiếu trống
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

    // Tải ảnh 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Tải ảnh 2
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
    
    // Thay đổi biểu tượng series biểu đồ
    series.getMarker().setSize(15);
    
    // Lưu bản trình chiếu cùng biểu đồ
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Những hình dạng biểu tượng nào có sẵn mặc định?**

Các hình dạng tiêu chuẩn có sẵn (hình tròn, hình vuông, hình thoi, hình tam giác, v.v.); danh sách được định nghĩa bởi lớp [MarkerStyleType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markerstyletype/). Nếu bạn cần một hình dạng không tiêu chuẩn, hãy sử dụng biểu tượng với điền ảnh để mô phỏng hình ảnh tùy chỉnh.

**Biểu tượng có được giữ lại khi xuất biểu đồ thành hình ảnh hoặc SVG không?**

Có. Khi render biểu đồ sang [định dạng raster](/slides/vi/androidjava/convert-powerpoint-to-png/) hoặc lưu [các hình dạng dưới dạng SVG](/slides/vi/androidjava/render-a-slide-as-an-svg-image/), các biểu tượng giữ nguyên giao diện và cài đặt của chúng, bao gồm kích thước, màu nền và đường viền.