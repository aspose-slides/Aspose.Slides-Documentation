---
title: Quản lý sổ làm việc biểu đồ trong bản trình bày bằng Python
linktitle: Sổ làm việc biểu đồ
type: docs
weight: 70
url: /vi/python-net/chart-workbook/
keywords:
- sổ làm việc biểu đồ
- dữ liệu biểu đồ
- ô sổ làm việc
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- sổ làm việc bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục sổ làm việc
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Python thông qua .NET: quản lý sổ làm việc biểu đồ trong PowerPoint và định dạng OpenDocument một cách dễ dàng để tối ưu hóa dữ liệu bản trình bày của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.  

Nó cũng đề cập đến việc làm việc với sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc khả dụng.  

Đối với các ô sổ làm việc đại diện cho dữ liệu thiếu, xem [Kiểm soát Hiển thị các Ô Trống](/slides/vi/python-net/chart-series/) để biết sự khác biệt giữa ô trống và số 0, và so sánh biểu đồ đường của các chế độ hiển thị khả dụng.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Sổ làm việc**

Aspose.Slides cung cấp các phương thức để đọc và ghi sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ được chỉnh sửa bằng Aspose.Cells). **Lưu ý:** Dữ liệu biểu đồ phải được tổ chức theo cùng một cách hoặc có cấu trúc tương tự nguồn.  

Mã Python sau đây minh họa một thao tác mẫu:

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

### **Xác thực Bố cục Biểu đồ Sau Khi Sửa Đổi Sổ làm việc**

Khi bạn thay thế sổ làm việc được nhúng bằng một sổ đã sửa đổi, biểu đồ vẫn giữ lại các bộ sưu tập series và category gốc. Sự không khớp này có thể khiến [IChart.validate_chart_layout](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichart/validate_chart_layout/) thất bại với lỗi chỉ mục ngoài phạm vi. Hãy xóa các series và category hiện có trước khi ghi sổ làm việc đã cập nhật lại vào biểu đồ.

```python
# Sau khi sửa đổi luồng sổ làm việc (ví dụ, sử dụng Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Xóa các tham chiếu dữ liệu hiện có.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Việc xóa các bộ sưu tập đảm bảo cấu trúc dữ liệu biểu đồ nhất quán với sổ làm việc mới, cho phép `validate_chart_layout` hoàn thành mà không có lỗi.

## **Đặt Ô WorkBook làm Nhãn Dữ liệu Biểu đồ**

Đôi khi bạn cần các nhãn biểu đồ được lấy trực tiếp từ các ô trong sổ làm việc dữ liệu nền. Aspose.Slides cho phép bạn liên kết nhãn dữ liệu với các ô sổ làm việc cụ thể để văn bản nhãn luôn phản ánh giá trị của ô. Ví dụ dưới đây cho thấy cách bật nhãn giá trị‑từ‑ô và chỉ định các nhãn được chọn tới các ô tùy chỉnh trong sổ làm việc của biểu đồ.

1. Tạo một thể hiện của lớp [Presentation](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides/presentation/).
2. Lấy tham chiếu đến slide theo chỉ mục.
3. Thêm một biểu đồ bong bóng với dữ liệu mẫu.
4. Truy cập series của biểu đồ.
5. Sử dụng một ô sổ làm việc làm nhãn dữ liệu.
6. Lưu bản trình bày.

Mã Python sau đây cho thấy cách đặt một ô sổ làm việc làm nhãn dữ liệu biểu đồ:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
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

## **Quản lý Worksheet**

Mã Python sau đây minh họa cách sử dụng thuộc tính `worksheets` để truy cập bộ sưu tập worksheet:

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

Mã Python sau đây cho thấy cách chỉ định loại nguồn dữ liệu:

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

## **Phát hiện Định dạng Sổ làm việc Nhúng Không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ làm việc nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng thuộc tính `embedded_workbook_type` trên [ChartData](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/) kết hợp với liệt kê [WorkbookType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó.

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
            # Sổ làm việc nhúng ở định dạng .xlsb, không được hỗ trợ.
            continue

        # Đọc hoặc chỉnh sửa dữ liệu sổ làm việc biểu đồ ở đây.
```

## **Sổ làm việc Bên ngoài**

Aspose.Slides hỗ trợ sử dụng sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Đặt Sổ làm việc Bên ngoài**

Bằng cách sử dụng phương thức [ChartData.set_external_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/), bạn có thể gán một sổ làm việc bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể cập nhật đường dẫn đến sổ làm việc bên ngoài nếu nó đã được di chuyển.

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ làm việc được lưu trên các vị trí hoặc tài nguyên từ xa, bạn vẫn có thể sử dụng các sổ đó làm nguồn dữ liệu bên ngoài. Nếu bạn cung cấp một đường dẫn tương đối cho sổ làm việc bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Mã Python dưới đây cho thấy cách đặt một sổ làm việc bên ngoài:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Truyền False để chỉ lưu đường dẫn: sổ làm việc đích không cần tồn tại ngay.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Tham số `update_chart_data` của phương thức [set_external_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) chỉ định việc sổ Excel có được tải hay không.

- Khi `update_chart_data` được đặt thành `False`, chỉ đường dẫn sổ làm việc được cập nhật; dữ liệu biểu đồ không được tải hoặc làm mới từ sổ làm việc mục tiêu. Sử dụng cài đặt này khi sổ làm việc mục tiêu không tồn tại hoặc không khả dụng.
- Khi `update_chart_data` được đặt thành `True` (mặc định), dữ liệu biểu đồ được tải và cập nhật từ sổ làm việc mục tiêu. Nếu sổ đó không thể mở, một ngoại lệ với thông báo "External workbook is not available" sẽ được ném.

### **Tạo Sổ làm việc Bên ngoài**

Bằng cách sử dụng các phương thức [read_workbook_stream](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) và [set_external_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/), bạn có thể tạo một sổ làm việc bên ngoài từ đầu hoặc chuyển đổi một sổ làm việc nội bộ thành sổ bên ngoài.

Mã Python này minh họa quy trình tạo sổ làm việc bên ngoài:

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

### **Lấy Đường dẫn Sổ làm việc Nguồn Dữ liệu Bên ngoài cho Biểu đồ**

Đôi khi dữ liệu của biểu đồ được liên kết với một sổ Excel bên ngoài thay vì dữ liệu nhúng trong bản trình bày. Với Aspose.Slides, bạn có thể kiểm tra nguồn dữ liệu của biểu đồ và, nếu nó là sổ làm việc bên ngoài, đọc đường dẫn đầy đủ của sổ làm việc.

1. Tạo một thể hiện của lớp [Presentation](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides/presentation/).
2. Lấy tham chiếu đến slide theo chỉ mục của nó.
3. Lấy tham chiếu đến hình dạng biểu đồ.
4. Lấy nguồn ([ChartDataSourceType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatasourcetype/)) đại diện cho nguồn dữ liệu của biểu đồ.
5. Kiểm tra xem loại nguồn có khớp với loại nguồn dữ liệu sổ làm việc bên ngoài hay không.

Mã Python dưới đây minh họa thao tác:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong sổ làm việc bên ngoài theo cùng cách như chỉnh sửa dữ liệu trong sổ làm việc nội bộ. Nếu không thể tải sổ làm việc bên ngoài, một ngoại lệ sẽ được ném.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Khôi phục Sổ làm việc từ Bộ nhớ Đệm Biểu đồ**

Nếu một biểu đồ sử dụng sổ làm việc bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ làm việc biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/), sau đó bật [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/vi/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) thông qua [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/spreadsheet_options/) trước khi mở bản trình bày.  

Ví dụ Python dưới đây mở một bản trình bày mà biểu đồ tham chiếu một sổ làm việc bên ngoài không khả dụng và truy cập dữ liệu đã khôi phục thông qua [Chart.chart_data](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/chart_data/) và [ChartData.chart_data_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Đọc hoặc chỉnh sửa dữ liệu sổ làm việc đã khôi phục ở đây.
```

Nếu sổ làm việc bên ngoài không khả dụng và việc khôi phục bị tắt, Aspose.Slides sẽ ném một ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là một giải pháp dự phòng chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã thực hiện trên sổ làm việc bên ngoài sau lần cập nhật cuối cùng của bản trình bày.

## **CÂU HỎI THƯỜNG GẶP**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết tới sổ làm việc bên ngoài hay sổ làm việc nhúng không?**  
Có. Một biểu đồ có một [loại nguồn dữ liệu](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/data_source_type/) và một [đường dẫn tới sổ làm việc bên ngoài](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/external_workbook_path/); nếu nguồn là một sổ làm việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới sổ làm việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**  
Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này tiện lợi cho việc di động của dự án; tuy nhiên, lưu ý rằng bản trình bày sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng sổ làm việc nằm trên tài nguyên/mạng chia sẻ không?**  
Có, các sổ làm việc như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa sổ làm việc từ xa trực tiếp qua Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản trình bày không?**  
Chỉ khi bạn chỉnh sửa dữ liệu biểu đồ. Bản trình bày lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) và sử dụng nó để đọc dữ liệu, vì vậy việc mở và lưu bản trình bày sẽ không làm thay đổi sổ làm việc. Tuy nhiên, các giá trị bạn thay đổi qua dữ liệu biểu đồ (xem [Chỉnh sửa Dữ liệu Biểu đồ](#edit-chart-data) ở trên) sẽ được ghi trở lại vào sổ làm việc bên ngoài khi lưu bản trình bày — hãy làm việc trên bản sao nếu bản gốc phải được giữ nguyên.

**Tôi nên làm gì nếu tệp bên ngoài được bảo mật bằng mật khẩu?**  
Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bỏ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, sử dụng [Aspose.Cells](/cells/python-net/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ làm việc bên ngoài không?**  
Có. Mỗi biểu đồ lưu trữ liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo khi dữ liệu được tải.