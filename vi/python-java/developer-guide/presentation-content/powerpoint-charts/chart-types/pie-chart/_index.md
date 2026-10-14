---
title: Tùy chỉnh biểu đồ tròn trong bản trình chiếu bằng Python qua Java
linktitle: Biểu đồ tròn
type: docs
url: /vi/python-java/pie-chart/
keywords:
- biểu đồ tròn
- quản lý biểu đồ
- tùy chỉnh biểu đồ
- tùy chọn biểu đồ
- cài đặt biểu đồ
- tùy chọn vẽ
- màu sắc lát
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh biểu đồ tròn trong Python qua Java với Aspose.Slides. Cấu hình đồ thị phụ, hiển thị nhãn dữ liệu và áp dụng màu sắc tự động cho các lát trong PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với biểu đồ tròn trong Aspose.Slides. Nó cho thấy cách cấu hình các tùy chọn đồ thị phụ cho các biểu đồ Pie of Pie và Bar of Pie, và cách bật tính năng tự động tô màu các lát cho biểu đồ tròn tiêu chuẩn.

Các ví dụ tập trung vào các tác vụ tùy chỉnh biểu đồ như thêm biểu đồ vào slide, điều chỉnh cài đặt chuỗi và nhãn, thay thế dữ liệu biểu đồ mặc định bằng các danh mục và giá trị tùy chỉnh, và lưu bản trình bày đã cập nhật.

## **Các tùy chọn đồ thị phụ cho biểu đồ Pie of Pie và Bar of Pie**

Aspose.Slides for Python via Java hỗ trợ các tùy chọn đồ thị phụ cho các biểu đồ Pie of Pie và Bar of Pie. Các tùy chọn này kiểm soát kích thước của đồ thị phụ và cách các điểm dữ liệu được chia giữa hai đồ thị.

Ví dụ sau tạo một biểu đồ Pie of Pie trong một bản trình bày mới và hiển thị giá trị các điểm dữ liệu dưới dạng nhãn. Phương thức [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) đặt kích thước đồ thị phụ bằng 149% của đồ thị chính. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) chọn cách chia dựa trên phần trăm, và [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) đặt ngưỡng ở 53%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # Hiển thị giá trị và cấu hình đồ thị phụ.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Chọn danh mục cho đồ thị phụ**

Sử dụng chia tùy chỉnh khi bạn muốn nhóm các danh mục cụ thể trong đồ thị phụ bất kể giá trị phần trăm của chúng. Ví dụ, một báo cáo bán hàng có thể hiển thị Online và Events cùng nhau để người đọc có thể so sánh hai kênh này, mặc dù chúng chiếm 35% và 10% tổng doanh thu.

Gọi [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) với [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) và chọn các điểm qua [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Phương thức [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) của bộ sưu tập chấp nhận chỉ mục bắt đầu từ 0 trong chuỗi; dùng [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) để thêm đối tượng điểm dữ liệu. Trong ví dụ này, chỉ mục 1 chọn Online, và điểm ở chỉ mục 3 chọn Events. Partners cũng được thêm tạm thời, sau đó bị loại bỏ bằng [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # Thay thế dữ liệu mặc định bằng doanh thu theo kênh.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Chọn Online bằng chỉ mục bắt đầu từ 0 và Events bằng đối tượng điểm dữ liệu của nó.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Loại bỏ Partners khỏi lựa chọn mà không xóa dữ liệu nguồn của nó.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) và Events (10) xuất hiện dưới dạng các lát riêng biệt trong đồ thị phụ. Trong đồ thị chính, chúng được biểu diễn bằng một lát kết hợp có giá trị 45, cùng với Retail (40) và Partners (15). Việc loại bỏ Partners khỏi lựa chọn tùy chỉnh giữ nó trong đồ thị chính; nó không loại bỏ danh mục hoặc giá trị của nó khỏi dữ liệu nguồn của biểu đồ.

Hình ảnh sau cho thấy bản trình bày đã lưu trong PowerPoint:

![Biểu đồ Pie of Pie với Online và Events trong đồ thị phụ và giá trị tổng hợp 45 trong đồ thị chính](pie_of_pie_custom.png)

## **Cài đặt màu sắc tự động cho các lát biểu đồ tròn**

Aspose.Slides for Python via Java có thể tự động gán màu sắc khác nhau cho các lát biểu đồ tròn. Ví dụ sau tạo một biểu đồ tròn với tiêu đề ở giữa và thay thế dữ liệu mặc định bằng ba danh mục quý và giá trị của chúng. Phương thức [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) hiển thị các giá trị 20, 50 và 30 dưới dạng nhãn, trong khi [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) bật màu sắc riêng biệt cho mỗi lát.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Thêm tiêu đề biểu đồ căn giữa.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Thay thế dữ liệu mặc định bằng bảng tính đầu tiên.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # Hiển thị giá trị và gán màu sắc khác nhau cho các lát.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Các biến thể Pie of Pie và Bar of Pie có được hỗ trợ không?**

Có, thư viện [hỗ trợ](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) một đồ thị phụ cho biểu đồ tròn, bao gồm các loại Pie of Pie và Bar of Pie.

**Tôi có thể xuất riêng biểu đồ dưới dạng hình ảnh (ví dụ, PNG) không?**

Có, bạn có thể [xuất biểu đồ dưới dạng hình ảnh](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (ví dụ PNG) mà không cần xuất toàn bộ bản trình bày.