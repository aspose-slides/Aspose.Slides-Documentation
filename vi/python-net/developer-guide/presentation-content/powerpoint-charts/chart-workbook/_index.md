---
title: Quản lý sổ công việc biểu đồ trong bản trình bày bằng Python
linktitle: Sổ công việc biểu đồ
type: docs
weight: 70
url: /vi/python-net/chart-workbook/
keywords:
- sổ công việc biểu đồ
- dữ liệu biểu đồ
- ô sổ công việc
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- sổ công việc bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục sổ công việc
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Python qua .NET: dễ dàng quản lý sổ công việc biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ công việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua các luồng sổ công việc, sử dụng các ô trong sổ công việc làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập bảng tính, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sổ công việc bên ngoài như là nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ công việc bên ngoài, lấy đường dẫn của sổ công việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ công việc khả dụng.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Sổ công việc**

Aspose.Slides cung cấp các phương thức để đọc và ghi sổ công việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Lưu ý:** Dữ liệu biểu đồ phải được sắp xếp theo cùng cách hoặc có cấu trúc tương tự như nguồn.

The following Python code demonstrates a sample operation:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

## **Đặt một Ô trong WorkBook làm Nhãn Dữ liệu Biểu đồ**

Đôi khi bạn cần các nhãn biểu đồ được lấy trực tiếp từ các ô trong sổ công việc dữ liệu nền. Aspose.Slides cho phép bạn ràng buộc nhãn dữ liệu vào các ô workbook cụ thể để văn bản nhãn luôn phản ánh giá trị của ô. Ví dụ dưới đây cho thấy cách kích hoạt nhãn lấy giá trị từ ô và chỉ định các nhãn đã chọn tới các ô tùy chỉnh trong workbook của biểu đồ.

1. Tạo một thể hiện của lớp [Presentation](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides/presentation/).
1. Lấy tham chiếu tới slide theo chỉ mục.
1. Thêm một biểu đồ bubble với dữ liệu mẫu.
1. Truy cập vào series của biểu đồ.
1. Sử dụng một ô trong workbook làm nhãn dữ liệu.
1. Lưu bản trình bày.

The following Python code shows how to set a workbook cell as a chart data label:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Tạo một thể hiện của lớp Presentation đại diện cho một tệp trình chiếu.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Quản lý Worksheets**

The following Python code demonstrates how to use the `worksheets` property to access the worksheet collection:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **Chỉ định Loại Nguồn Dữ liệu**

The following Python code shows how to specify a data source type:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Phát hiện Định dạng Sổ công việc Nhúng Không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ công việc nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng thuộc tính `embedded_workbook_type` trên [ChartData](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/) kết hợp với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # Sổ công việc nhúng ở định dạng .xlsb, không được hỗ trợ.
            continue

        # Đọc hoặc chỉnh sửa dữ liệu sổ công việc của biểu đồ tại đây.
```

## **External Workbooks**

Aspose.Slides hỗ trợ việc sử dụng sổ công việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Set External Workbooks**

Bằng cách sử dụng phương thức [ChartData.set_external_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/), bạn có thể gán một sổ công việc bên ngoài cho biểu đồ như là nguồn dữ liệu của nó. Phương thức này cũng có thể cập nhật đường dẫn tới sổ công việc bên ngoài nếu nó đã được di chuyển.

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ công việc được lưu trên các vị trí hoặc tài nguyên từ xa, nhưng bạn vẫn có thể sử dụng các sổ công việc đó làm nguồn dữ liệu bên ngoài. Nếu bạn cung cấp một đường dẫn tương đối cho sổ công việc bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

The following Python code shows how to set an external workbook:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

The `update_chart_data` parameter of the [set_external_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) method specifies whether the Excel workbook will be loaded.

- Khi `update_chart_data` được đặt là `False`, chỉ đường dẫn workbook được cập nhật; dữ liệu biểu đồ không được tải hoặc làm mới từ workbook mục tiêu. Sử dụng cài đặt này khi workbook mục tiêu không tồn tại hoặc không khả dụng.
- Khi `update_chart_data` được đặt là `True`, dữ liệu biểu đồ được tải và cập nhật từ workbook mục tiêu.

### **Create External Workbooks**

Bằng cách sử dụng các phương thức [read_workbook_stream](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) và [set_external_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/), bạn có thể tạo một sổ công việc bên ngoài từ đầu hoặc chuyển đổi một sổ công việc nội bộ thành một sổ công việc bên ngoài.

This Python code demonstrates the external workbook creation process:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Get the External Data Source Workbook Path for a Chart**

Đôi khi dữ liệu của một biểu đồ được liên kết tới một sổ công việc Excel bên ngoài thay vì dữ liệu nhúng trong bản trình bày. Với Aspose.Slides, bạn có thể kiểm tra nguồn dữ liệu của biểu đồ và, nếu đó là một sổ công việc bên ngoài, đọc đường dẫn đầy đủ của sổ công việc.

1. Tạo một thể hiện của lớp [Presentation](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides/presentation/).
1. Lấy tham chiếu tới slide bằng chỉ mục của nó.
1. Lấy tham chiếu tới hình dạng biểu đồ.
1. Lấy nguồn ([ChartDataSourceType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatasourcetype/)) đại diện cho nguồn dữ liệu của biểu đồ.
1. Kiểm tra xem loại nguồn có khớp với loại nguồn dữ liệu sổ công việc bên ngoài không.

The following Python code demonstrates the operation:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Edit Chart Data**

Bạn có thể chỉnh sửa dữ liệu trong sổ công việc bên ngoài giống như chỉnh sửa dữ liệu trong sổ công việc nội bộ. Nếu sổ công việc bên ngoài không thể được tải, một ngoại lệ sẽ được ném.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Recover a Workbook from the Chart Cache**

Nếu một biểu đồ sử dụng một sổ công việc bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ công việc biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/), sau đó bật [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/vi/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) thông qua [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/spreadsheet_options/) trước khi mở bản trình bày.

The following Python example opens a presentation whose chart references an unavailable external workbook and accesses the recovered data through [Chart.chart_data](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/chart_data/) and [ChartData.chart_data_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Đọc hoặc chỉnh sửa dữ liệu sổ công việc đã khôi phục ở đây.
```

Nếu sổ công việc bên ngoài không khả dụng và chế độ khôi phục bị tắt, Aspose.Slides sẽ ném một ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là một giải pháp dự phòng chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi được thực hiện trên sổ công việc bên ngoài sau lần cập nhật cuối cùng của bản trình bày.

## **FAQ**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết tới sổ công việc bên ngoài hay sổ công việc nhúng không?**

Có. Một biểu đồ có [loại nguồn dữ liệu](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/data_source_type/) và một [đường dẫn tới sổ công việc bên ngoài](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/external_workbook_path/); nếu nguồn là một sổ công việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới sổ công việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này thuận tiện cho việc di động của dự án; tuy nhiên, lưu ý rằng bản trình bày sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng sổ công việc nằm trên tài nguyên/mạng chia sẻ không?**

Có, những sổ công việc như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các sổ công việc từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản trình bày không?**

Không. Bản trình bày lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) và sử dụng nó để đọc dữ liệu. Tệp bên ngoài sẽ không bị thay đổi khi bản trình bày được lưu.

**Tôi nên làm gì nếu tệp bên ngoài được bảo mật bằng mật khẩu?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường được dùng là loại bỏ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng cách sử dụng [Aspose.Cells](/cells/python-net/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ công việc bên ngoài không?**

Có. Mỗi biểu đồ lưu trữ liên kết riêng của mình. Nếu tất cả chúng đều trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.