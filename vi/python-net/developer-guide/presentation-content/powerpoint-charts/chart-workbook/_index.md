---
title: Quản lý Workbook biểu đồ trong bản trình chiếu bằng Python
linktitle: Workbook biểu đồ
type: docs
weight: 70
url: /vi/python-net/chart-workbook/
keywords:
- workbook biểu đồ
- dữ liệu biểu đồ
- ô workbook
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- workbook ngoại
- dữ liệu ngoại
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Python thông qua .NET: quản lý workbook biểu đồ trong định dạng PowerPoint và OpenDocument một cách dễ dàng để tối ưu hóa dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với workbook biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng workbook, sử dụng các ô workbook làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập tới việc làm việc với workbook bên ngoài làm nguồn dữ liệu biểu đồ. Các ví dụ minh họa cách tạo và gán một workbook bên ngoài, lấy đường dẫn của workbook bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi workbook có sẵn.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Workbook**

Aspose.Slides cung cấp các phương thức để đọc và ghi workbook dữ liệu biểu đồ (có chứa dữ liệu biểu đồ được chỉnh sửa bằng Aspose.Cells). **Lưu ý:** Dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc có cấu trúc tương tự như nguồn.

Đoạn mã Python sau đây minh họa một thao tác mẫu:

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

## **Đặt Ô WorkBook làm Nhãn Dữ liệu Biểu đồ**

Đôi khi bạn cần các nhãn biểu đồ lấy trực tiếp từ các ô trong workbook dữ liệu nền. Aspose.Slides cho phép bạn ràng buộc nhãn dữ liệu với các ô workbook cụ thể để văn bản nhãn luôn phản ánh giá trị của ô. Ví dụ dưới đây cho thấy cách bật nhãn lấy giá trị từ ô và chỉ các nhãn đã chọn tới các ô tùy chỉnh trong workbook của biểu đồ.

1. Tạo một thể hiện của lớp [Presentation](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide theo chỉ mục.
3. Thêm một biểu đồ bubble với dữ liệu mẫu.
4. Truy cập series của biểu đồ.
5. Sử dụng một ô workbook làm nhãn dữ liệu.
6. Lưu bản trình bày.

Đoạn mã Python sau cho thấy cách đặt một ô workbook làm nhãn dữ liệu biểu đồ:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
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

Đoạn mã Python sau đây minh họa cách sử dụng thuộc tính `worksheets` để truy cập bộ sưu tập worksheet:

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

## **Xác định Loại Nguồn Dữ liệu**

Đoạn mã Python sau cho thấy cách chỉ định một loại nguồn dữ liệu:

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

## **Phát hiện Định dạng Workbook Nhúng không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng thuộc tính `embedded_workbook_type` trên [ChartData](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/) kết hợp với enum [WorkbookType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua những biểu đồ đó.

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
            # Sổ làm việc nhúng có định dạng .xlsb, định dạng này không được hỗ trợ.
            continue

        # Đọc hoặc sửa đổi dữ liệu workbook của biểu đồ ở đây.
```

## **Workbook Ngoại**

Aspose.Slides hỗ trợ sử dụng workbook ngoại làm nguồn dữ liệu cho biểu đồ.

### **Đặt Workbook Ngoại**

Bằng cách sử dụng phương thức [ChartData.set_external_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/), bạn có thể gán một workbook bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể cập nhật đường dẫn tới workbook bên ngoài nếu nó đã được di chuyển.

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook lưu trên các vị trí hoặc tài nguyên từ xa, bạn vẫn có thể sử dụng những workbook đó làm nguồn dữ liệu ngoại. Nếu bạn cung cấp một đường dẫn tương đối cho workbook bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Đoạn mã Python sau cho thấy cách đặt một workbook bên ngoài:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Tham số `update_chart_data` của phương thức [set_external_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/) chỉ định liệu workbook Excel có được tải hay không.

- Khi `update_chart_data` được đặt thành `False`, chỉ đường dẫn workbook được cập nhật; dữ liệu biểu đồ không được tải hoặc làm mới từ workbook mục tiêu. Sử dụng thiết lập này khi workbook mục tiêu không tồn tại hoặc không khả dụng.
- Khi `update_chart_data` được đặt thành `True`, dữ liệu biểu đồ được tải và cập nhật từ workbook mục tiêu.

### **Tạo Workbook Ngoại**

Bằng cách sử dụng các phương thức [read_workbook_stream](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) và [set_external_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/set_external_workbook/), bạn có thể tạo một workbook bên ngoài từ đầu hoặc chuyển đổi một workbook nội bộ thành một workbook bên ngoài.

Đoạn mã Python này trình bày quy trình tạo workbook bên ngoài:

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

### **Lấy Đường Dẫn Workbook Nguồn Dữ liệu Ngoại cho Biểu đồ**

Đôi khi dữ liệu của một biểu đồ được liên kết tới một workbook Excel bên ngoài thay vì dữ liệu nhúng trong bản trình bày. Với Aspose.Slides, bạn có thể kiểm tra nguồn dữ liệu của biểu đồ và, nếu đó là một workbook ngoại, đọc đầy đủ đường dẫn workbook.

1. Tạo một thể hiện của lớp [Presentation](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide theo chỉ mục của nó.
3. Lấy tham chiếu tới shape biểu đồ.
4. Lấy nguồn ([ChartDataSourceType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatasourcetype/)) đại diện cho nguồn dữ liệu của biểu đồ.
5. Kiểm tra xem loại nguồn có khớp với loại nguồn workbook ngoại hay không.

Đoạn mã Python sau minh họa thao tác này:

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

Bạn có thể chỉnh sửa dữ liệu trong workbook ngoại giống như khi chỉnh sửa dữ liệu trong workbook nội bộ. Nếu một workbook ngoại không thể tải, một ngoại lệ sẽ được ném.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có được liên kết tới workbook ngoại hay workbook nhúng không?**

Có. Một biểu đồ có một [data source type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/data_source_type/) và một [path to an external workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/external_workbook_path/); nếu nguồn là workbook ngoại, bạn có thể đọc đầy đủ đường dẫn để chắc chắn rằng một tệp ngoại đang được sử dụng.

**Các đường dẫn tương đối tới workbook ngoại có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này thuận tiện cho việc di động dự án; tuy nhiên, lưu ý rằng bản trình bày sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng workbook nằm trên tài nguyên/mạng chia sẻ không?**

Có, những workbook như vậy có thể được dùng làm nguồn dữ liệu ngoại. Tuy nhiên, việc chỉnh sửa workbook từ xa trực tiếp bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX ngoại khi lưu bản trình bày không?**

Không. Bản trình bày lưu một [link to the external file](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) và sử dụng nó để đọc dữ liệu. File ngoại không bị thay đổi khi bản trình bày được lưu.

**Nếu file ngoại được bảo mật bằng mật khẩu, tôi phải làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bỏ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, dùng [Aspose.Cells](/cells/python-net/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook ngoại không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu tất cả chúng trỏ tới cùng một file, việc cập nhật file sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.