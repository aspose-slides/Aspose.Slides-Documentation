---
title: Tùy chỉnh thanh lỗi trong biểu đồ trình chiếu trên Android
linktitle: Thanh lỗi
type: docs
url: /vi/androidjava/error-bar/
keywords:
- thanh lỗi
- giá trị tùy chỉnh
- PowerPoint
- trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm và tùy chỉnh thanh lỗi trong biểu đồ bằng Aspose.Slides cho Android qua Java—tối ưu hóa hình ảnh dữ liệu trong các bản trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các thanh lỗi trong biểu đồ trình chiếu bằng cách sử dụng Aspose.Slides. Nó mô tả cách thêm thanh lỗi vào một chuỗi biểu đồ, cấu hình cài đặt thanh lỗi X và Y, và áp dụng các loại giá trị khác nhau như cố định, phần trăm và giá trị tùy chỉnh.

Nó cũng minh họa cách gán giá trị thanh lỗi tùy chỉnh cho các điểm dữ liệu riêng lẻ trong một chuỗi bằng cách sử dụng bộ sưu tập điểm dữ liệu tương ứng. Ngoài ra, bài viết đưa ra một số ghi chú ngắn gọn về cách thanh lỗi hoạt động khi xuất, tính tương thích của chúng với các dấu hiệu và nhãn dữ liệu, và nơi tìm các lớp và enum tham chiếu API liên quan.

## **Thêm thanh lỗi**
Aspose.Slides for Android via Java cung cấp một API đơn giản để quản lý các giá trị thanh lỗi. Mã mẫu áp dụng khi sử dụng loại giá trị tùy chỉnh. Để chỉ định một giá trị, sử dụng thuộc tính **ErrorBarCustomValues** của một điểm dữ liệu cụ thể trong bộ sưu tập [**DataPoints**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartSeriesCollection) của chuỗi:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Thêm một biểu đồ bong bóng vào slide mong muốn.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi X.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi Y.
1. Đặt giá trị và định dạng cho các thanh.
1. Ghi bản trình chiếu đã sửa đổi vào tệp PPTX.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Tạo một biểu đồ bong bóng
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Thêm thanh lỗi và đặt định dạng cho chúng
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Lưu bản trình chiếu
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm giá trị thanh lỗi tùy chỉnh**
Aspose.Slides for Android via Java cung cấp một API đơn giản để quản lý các giá trị thanh lỗi tùy chỉnh. Mã mẫu áp dụng khi thuộc tính [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) bằng **Custom**. Để chỉ định một giá trị, sử dụng thuộc tính **ErrorBarCustomValues** của một điểm dữ liệu cụ thể trong bộ sưu tập [**DataPoints**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartSeriesCollection) của chuỗi:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Thêm một biểu đồ bong bóng vào slide mong muốn.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi X.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi Y.
1. Truy cập các điểm dữ liệu cá nhân của chuỗi biểu đồ và đặt giá trị Thanh Lỗi cho từng điểm dữ liệu trong chuỗi.
1. Đặt giá trị và định dạng cho các thanh.
1. Ghi bản trình chiếu đã sửa đổi vào tệp PPTX.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Tạo một biểu đồ bong bóng
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Thêm thanh lỗi tùy chỉnh và đặt định dạng cho chúng
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Truy cập điểm dữ liệu của chuỗi biểu đồ và đặt giá trị thanh lỗi cho
    // từng điểm riêng lẻ
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Đặt thanh lỗi cho các điểm của chuỗi biểu đồ
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Lưu bản trình chiếu
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Điểm lỗi sẽ như thế nào khi xuất bản trình chiếu sang PDF hoặc hình ảnh?**

Chúng được hiển thị như một phần của biểu đồ và được giữ nguyên trong quá trình chuyển đổi cùng với phần còn lại của định dạng biểu đồ, với giả định rằng phiên bản hoặc trình render tương thích.

**Thanh lỗi có thể kết hợp với dấu hiệu và nhãn dữ liệu không?**

Có. Thanh lỗi là một yếu tố riêng biệt và tương thích với dấu hiệu và nhãn dữ liệu; nếu các yếu tố chồng lên nhau, bạn có thể cần điều chỉnh định dạng.

**Tôi có thể tìm danh sách các thuộc tính và lớp để làm việc với thanh lỗi trong API ở đâu?**

Trong tài liệu API: lớp [ErrorBarsFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/errorbarsformat/) và các lớp liên quan [ErrorBarType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/errorbartype/) và [ErrorBarValueType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/errorbarvaluetype/).