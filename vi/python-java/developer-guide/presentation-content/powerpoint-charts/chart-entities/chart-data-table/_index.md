---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong bản trình chiếu bằng Python
linktitle: Bảng Dữ Liệu
type: docs
url: /vi/python-java/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tùy chỉnh phông chữ, viền và các ký hiệu chú giải của bảng dữ liệu biểu đồ trong bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Aspose.Slides for Python via Java cho phép bạn hiển thị bảng dữ liệu của biểu đồ và tùy chỉnh định dạng văn bản, viền và các ký hiệu chú giải. Bài viết này giải thích cách bật bảng, định dạng văn bản, điều khiển từng loại viền và hiển thị hoặc ẩn các ký hiệu chú giải. Các ví dụ lưu các biểu đồ đã cấu hình vào tệp PPTX.

## **Đặt Thuộc Tính Phông Chữ**

Để hiển thị bảng dữ liệu của biểu đồ, truyền `True` vào [setDataTable](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#setDataTable). Sử dụng [getChartDataTable](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#getChartDataTable) để truy cập bảng và cấu hình định dạng văn bản.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Thêm một biểu đồ cột nhóm vào slide đầu tiên.
1. Bật bảng dữ liệu của biểu đồ.
1. Bật văn bản in đậm bằng [setFontBold](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setFontBold) và truyền `20` vào [setFontHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setFontHeight) để có văn bản 20 điểm.
1. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ sau yêu cầu có tệp `test.pptx` trong thư mục làm việc với ít nhất một slide. Nó thêm một biểu đồ với dữ liệu mặc định tại vị trí (50, 50), chiều rộng 600 điểm và chiều cao 400 điểm. Tệp `output.pptx` được lưu chứa biểu đồ với bảng dữ liệu được bật và áp dụng các cài đặt phông chữ đã chỉ định.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tùy Chỉnh Viền Bảng Dữ Liệu**

Bật bảng bằng [Chart.setDataTable](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#setDataTable) và truy cập nó qua [Chart.getChartDataTable](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#getChartDataTable). Bạn có thể điều khiển ba loại viền độc lập:

- [setBorderHorizontal](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datatable/#setBorderHorizontal) điều khiển viền ô ngang.
- [setBorderVertical](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datatable/#setBorderVertical) điều khiển viền ô dọc.
- [setBorderOutline](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datatable/#setBorderOutline) điều khiển viền ngoài của bảng.

Truyền `True` vào mỗi phương thức để hiển thị viền hoặc `False` để ẩn chúng. Ví dụ sau tạo một biểu đồ cột nhóm với dữ liệu mặc định, hiển thị viền ngang và viền ngoài, và ẩn viền dọc. Không yêu cầu tệp đầu vào. Vị trí và kích thước của biểu đồ được chỉ định bằng điểm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

So sánh dưới đây sử dụng cùng một dữ liệu biểu đồ và cùng một cài đặt ký hiệu chú giải trong bốn trường hợp. Bắt đầu với tất cả các viền được bật, mỗi biến thể còn lại chỉ tắt một loại viền. Biến thể góc dưới‑trái khớp với cài đặt viền trong ví dụ.

![Bảng dữ liệu biểu đồ với tất cả viền bật, không có viền ngang, không có viền dọc và không có viền ngoài](data-table-borders.png)

## **Hiển Thị Hoặc Ẩn Ký Hiệu Chú Giải**

Ký hiệu chú giải là các dấu màu nhỏ bên cạnh tên chuỗi trong bảng dữ liệu. Chúng giúp người đọc liên kết mỗi hàng của bảng với một chuỗi biểu đồ. Truyền `True` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datatable/#setShowLegendKey) để hiển thị các dấu này hoặc `False` để ẩn chúng.

Chú giải riêng của biểu đồ được điều khiển bằng [Chart.setLegend](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#setLegend). Các cài đặt này độc lập: ẩn chú giải riêng không ẩn các ký hiệu trong bảng dữ liệu, và ẩn ký hiệu trong bảng không ẩn chú giải riêng.

Ví dụ sau tạo một biểu đồ với dữ liệu mặc định, bật bảng dữ liệu và hiển thị ký hiệu chú giải bên trong khi ẩn chú giải riêng. Tất cả các viền bảng được bật rõ ràng. Không cần bản trình chiếu đầu vào. Để chỉ ẩn các ký hiệu của bảng, truyền `False` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datatable/#setShowLegendKey).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

So sánh dưới đây cho thấy cùng một bảng với ký hiệu chú giải được bật và bị tắt. Tất cả các viền vẫn được bật, và chú giải riêng của biểu đồ được ẩn trong cả hai trường hợp.

![Bảng dữ liệu biểu đồ với ký hiệu chú giải hiển thị ở bên trái và ẩn ở bên phải](data-table-legend-keys.png)

## **Câu Hỏi Thường Gặp**

**Tôi có thể hiển thị ký hiệu chú giải trong bảng dữ liệu của biểu đồ không?**

Có. Truyền `True` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datatable/#setShowLegendKey) để hiển thị ký hiệu chú giải hoặc `False` để ẩn chúng.

**Bảng dữ liệu có được giữ lại khi xuất bản trình chiếu sang PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides sẽ render biểu đồ và bảng dữ liệu đã hiển thị như một phần của slide khi xuất sang [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/vi/python-java/convert-powerpoint-to-html/) hoặc [hình ảnh](/slides/vi/python-java/convert-powerpoint-to-png/).

**Tôi có thể làm việc với bảng dữ liệu trong các biểu đồ được tải từ mẫu không?**

Có. Đối với một biểu đồ được tải từ bản trình chiếu hoặc mẫu hiện có, sử dụng [hasDataTable](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#hasDataTable) và [setDataTable](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#setDataTable) để kiểm tra hoặc thay đổi việc bảng dữ liệu có được hiển thị hay không.

**Làm sao tôi có thể tìm các biểu đồ đã bật bảng dữ liệu?**

Duyệt qua các shape trên mỗi slide, xác định các biểu đồ, và gọi phương thức [hasDataTable](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#hasDataTable) của chúng. Giá trị `True` cho biết bảng dữ liệu đang được bật.