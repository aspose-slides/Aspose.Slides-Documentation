---
title: Tùy chỉnh thanh lỗi trong biểu đồ trình chiếu bằng JavaScript
linktitle: Thanh lỗi
type: docs
url: /vi/nodejs-java/error-bar/
keywords:
- thanh lỗi
- giá trị tùy chỉnh
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách thêm và tùy chỉnh thanh lỗi trong biểu đồ bằng JavaScript và Aspose.Slides cho Node.js via Java — tối ưu hóa hình ảnh dữ liệu trong các bản trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với thanh lỗi trong biểu đồ trình chiếu bằng cách sử dụng Aspose.Slides. Nó cho thấy cách thêm thanh lỗi vào một chuỗi biểu đồ, cấu hình cài đặt thanh lỗi X và Y, và áp dụng các loại giá trị khác nhau như cố định, phần trăm và giá trị tùy chỉnh.

Nó cũng minh họa cách gán giá trị thanh lỗi tùy chỉnh cho các điểm dữ liệu riêng lẻ trong một chuỗi bằng cách sử dụng bộ sưu tập điểm dữ liệu tương ứng. Ngoài ra, bài viết bao gồm các ghi chú ngắn về cách thanh lỗi hoạt động khi xuất, khả năng tương thích của chúng với các dấu hiệu và nhãn dữ liệu, và nơi tìm các lớp và enum tham chiếu API liên quan.

## **Thêm Thanh Lỗi**

Aspose.Slides for Node.js via Java cung cấp một API đơn giản để quản lý các giá trị thanh lỗi. Mã mẫu áp dụng khi sử dụng loại giá trị tùy chỉnh. Để chỉ định một giá trị, hãy sử dụng thuộc tính **ErrorBarCustomValues** của một điểm dữ liệu cụ thể trong bộ sưu tập[**DataPoints**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartSeriesCollection) của chuỗi:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Thêm một biểu đồ bong bóng trên slide mong muốn.
3. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi X.
4. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi Y.
5. Đặt giá trị và định dạng cho các thanh.
6. Ghi bản trình bày đã chỉnh sửa ra tệp PPTX.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Tạo biểu đồ bong bóng
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Thêm thanh lỗi và thiết lập định dạng của chúng
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // Lưu bản trình bày
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thêm Giá Trị Thanh Lỗi Tùy Chỉnh**

Aspose.Slides for Node.js via Java cung cấp một API đơn giản để quản lý các giá trị thanh lỗi tùy chỉnh. Mã mẫu áp dụng khi thuộc tính[**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) bằng **Custom**. Để chỉ định một giá trị, hãy sử dụng thuộc tính **ErrorBarCustomValues** của một điểm dữ liệu cụ thể trong bộ sưu tập[**DataPoints**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartSeriesCollection) của chuỗi:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Thêm một biểu đồ bong bóng trên slide mong muốn.
3. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi X.
4. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi Y.
5. Truy cập các điểm dữ liệu riêng lẻ của chuỗi biểu đồ và đặt giá trị Thanh Lỗi cho từng điểm dữ liệu của chuỗi.
6. Đặt giá trị và định dạng cho các thanh.
7. Ghi bản trình bày đã chỉnh sửa ra tệp PPTX.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Tạo biểu đồ bong bóng
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Thêm thanh lỗi tùy chỉnh và thiết lập định dạng của chúng
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Truy cập điểm dữ liệu của chuỗi biểu đồ và thiết lập giá trị thanh lỗi cho
    // từng điểm riêng lẻ
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Thiết lập thanh lỗi cho các điểm trong chuỗi biểu đồ
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Lưu bản trình bày
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Điều gì xảy ra với thanh lỗi khi xuất bản trình bày sang PDF hoặc hình ảnh?**

Chúng được vẽ như một phần của biểu đồ và được giữ nguyên trong quá trình chuyển đổi cùng với phần còn lại của định dạng biểu đồ, với giả định có phiên bản hoặc bộ render tương thích.

**Thanh lỗi có thể kết hợp với dấu hiệu và nhãn dữ liệu không?**

Có. Thanh lỗi là một yếu tố riêng biệt và tương thích với các dấu hiệu và nhãn dữ liệu; nếu các yếu tố chồng lên nhau, bạn có thể cần điều chỉnh định dạng.

**Tôi có thể tìm danh sách các thuộc tính và enum để làm việc với thanh lỗi trong API ở đâu?**

Trong tài liệu tham chiếu API: lớp[ErrorBarsFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/errorbarsformat/) và các enum liên quan[ErrorBarType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/errorbartype/) và[ErrorBarValueType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/errorbarvaluetype/).