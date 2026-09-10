---
title: Tùy chỉnh thanh lỗi trong biểu đồ trình chiếu bằng Python
linktitle: Thanh lỗi
type: docs
url: /vi/python-java/error-bar/
keywords:
- thanh lỗi
- giá trị tùy chỉnh
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm và tùy chỉnh thanh lỗi trong biểu đồ với Aspose.Slides cho Python qua Java - tối ưu hóa hình ảnh dữ liệu trong các bản trình bày PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các thanh lỗi trong biểu đồ trình chiếu bằng cách sử dụng Aspose.Slides. Nó cho thấy cách thêm thanh lỗi vào một chuỗi biểu đồ, cấu hình các thiết lập thanh lỗi X và Y, và áp dụng các kiểu giá trị khác nhau như cố định, phần trăm và giá trị tùy chỉnh.

Nó cũng trình bày cách gán giá trị thanh lỗi tùy chỉnh cho các điểm dữ liệu riêng lẻ trong một chuỗi bằng cách sử dụng bộ sưu tập điểm dữ liệu tương ứng. Ngoài ra, bài viết có các ghi chú ngắn gọn về cách thanh lỗi hoạt động khi xuất, tính tương thích của chúng với các dấu hiệu và nhãn dữ liệu, và nơi tìm các lớp và enum tham chiếu API liên quan.

## **Thêm thanh lỗi**

Aspose.Slides for Python via Java cung cấp một API đơn giản để quản lý các giá trị thanh lỗi. Mã mẫu sau sử dụng các kiểu giá trị cố định và phần trăm.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Thêm một biểu đồ bong bóng vào slide mong muốn.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi X.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi Y.
1. Đặt các giá trị và định dạng cho thanh lỗi.
1. Ghi bản trình bày đã chỉnh sửa vào tệp PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    # Tạo một biểu đồ bong bóng.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Thêm thanh lỗi và thiết lập định dạng cho chúng.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # Lưu bản trình bày.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thêm giá trị thanh lỗi tùy chỉnh**

Aspose.Slides for Python via Java cung cấp một API đơn giản để quản lý các giá trị thanh lỗi tùy chỉnh. Mã mẫu sau áp dụng khi [getValueType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/errorbarsformat/#getValueType) trả về [ErrorBarValueType.Custom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/errorbarvaluetype/#Custom). Để chỉ định một giá trị, sử dụng [getErrorBarsCustomValues](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) cho một điểm dữ liệu cụ thể trong bộ sưu tập trả về bởi phương thức chuỗi [getDataPoints](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartseries/#getDataPoints).

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Thêm một biểu đồ bong bóng vào slide mong muốn.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi X.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi Y.
1. Truy cập các điểm dữ liệu riêng lẻ trong chuỗi biểu đồ và đặt giá trị thanh lỗi cho chúng.
1. Đặt các giá trị và định dạng cho thanh lỗi.
1. Ghi bản trình bày đã chỉnh sửa vào tệp PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    # Tạo một biểu đồ bong bóng.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Thêm thanh lỗi tùy chỉnh và thiết lập định dạng cho chúng.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Truy cập các điểm dữ liệu của chuỗi biểu đồ và cấu hình nguồn giá trị thanh lỗi của chúng.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Đặt giá trị thanh lỗi cho các điểm dữ liệu của chuỗi biểu đồ.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Lưu bản trình bày.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Điều gì xảy ra với các thanh lỗi khi xuất bản trình bày sang PDF hoặc hình ảnh?**

Chúng được vẽ như một phần của biểu đồ và được giữ lại trong quá trình chuyển đổi cùng với phần còn lại của định dạng biểu đồ, với giả định phiên bản hoặc bộ render tương thích.

**Thanh lỗi có thể kết hợp với dấu hiệu và nhãn dữ liệu không?**

Có. Thanh lỗi là một phần tử riêng biệt và tương thích với dấu hiệu và nhãn dữ liệu; nếu các phần tử chồng lên nhau, bạn có thể cần điều chỉnh định dạng.

**Tôi có thể tìm danh sách các thuộc tính và lớp để làm việc với thanh lỗi trong API ở đâu?**

Trong tài liệu tham chiếu API: lớp [ErrorBarsFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/errorbarsformat/) và các lớp liên quan [ErrorBarType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/errorbartype/) và [ErrorBarValueType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/errorbarvaluetype/).