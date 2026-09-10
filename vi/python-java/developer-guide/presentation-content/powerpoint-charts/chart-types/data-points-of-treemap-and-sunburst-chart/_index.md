---
title: Tùy chỉnh Điểm dữ liệu trong biểu đồ Treemap và Sunburst bằng Python
linktitle: Điểm dữ liệu trong biểu đồ Treemap và Sunburst
type: docs
url: /vi/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- biểu đồ treemap
- biểu đồ sunburst
- biểu đồ phân cấp
- điểm dữ liệu
- nhãn dữ liệu
- màu nhánh
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách tạo dữ liệu phân cấp và tùy chỉnh các cấp, nhãn và màu sắc trong biểu đồ Treemap và Sunburst với Aspose.Slides cho Python thông qua Java."
---
## **Tổng quan**

Treemap và Sunburst hiển thị cùng một loại dữ liệu phân cấp, nhưng chúng sử dụng bố cục khác nhau. Treemap vẽ cấu trúc phân cấp dưới dạng các hình chữ nhật lồng nhau, trong đó diện tích biểu thị giá trị của các lá. Sunburst vẽ nó dưới dạng các vòng đồng tâm: các nhóm cấp cao nhất nằm gần trung tâm, còn các danh mục lá nằm ở vòng bên ngoài.

Trong Aspose.Slides cho Python thông qua Java, mỗi giá trị số là một [ChartDataPoint](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatapoint/). Phương thức [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) cung cấp quyền truy cập vào lá và các nhóm cha của nó. Bài viết này giải thích phép ánh xạ đó và chỉ ra cách tạo và định dạng cả hai loại biểu đồ từ cùng một tập dữ liệu mẫu.

![Biểu đồ Treemap với các nhánh Consumer và Business](treemap-hierarchy.png)

![Biểu đồ Sunburst với cùng cấu trúc phân cấp Consumer và Business](sunburst-hierarchy.png)

## **Hiểu các Danh mục, Điểm dữ liệu và Cấp độ**

Mẫu được sử dụng dưới đây có ba cấp danh mục và một chuỗi số:

| Chi nhánh | Nhánh | Lá | Doanh thu |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Mỗi hàng tạo một danh mục lá và một điểm dữ liệu. Các cấp nhóm danh mục mô tả đường dẫn từ lá đó lên các cha của nó. Đối với hàng đầu tiên, đường dẫn là `Consumer > Computers > Laptops`.

Các chỉ mục trả về bởi [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) chạy từ lá lên trên:

| `getDataPointLevels()` index | Cấp độ logic | Biểu diễn Treemap | Biểu diễn Sunburst |
| ---: | --- | --- | --- |
| `0` | Lá | Hình chữ nhật giá trị | Đoạn vòng ngoài |
| `1` | Nhánh | Hình chữ nhật cha hoặc tiêu đề | Đoạn vòng giữa |
| `2` | Chi nhánh | Hình chữ nhật cấp cao nhất hoặc tiêu đề | Đoạn vòng trong |

Thứ tự này giống nhau cho cả hai loại biểu đồ dù bố cục hình ảnh khác nhau. Một đoạn cha được chia sẻ bởi nhiều lá. Để định dạng nó, hãy sử dụng cấp tương ứng của điểm dữ liệu đầu tiên trong nhóm đó. Ví dụ, nhánh `Consumer` bắt đầu với điểm `Laptops`, trong khi nhánh `Software` bắt đầu với điểm `Licenses`. Giữ tham chiếu tới các điểm đó rõ ràng và an toàn hơn so với việc dùng các biểu thức không giải thích như `data_points.get_Item(0)` hoặc `data_points.get_Item(6)`.

## **Tạo và Tùy chỉnh Cả Hai Loại Biểu đồ**

Ví dụ đầy đủ sau tạo một biểu đồ Treemap trên slide đầu tiên và một biểu đồ Sunburst trên slide thứ hai. Nó xây dựng cấu trúc phân cấp, hiển thị giá trị cho `Tablets`, áp dụng màu cố định cho các cấp đã chọn, định dạng nhãn nhánh, và lưu bản trình bày.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # Thêm các danh mục lá. Một mục nhóm chỉ được đặt khi một nhóm mới bắt đầu;
        # các danh mục tiếp theo sẽ ở trong nhóm đó cho đến khi một mục khác được đặt.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Hiển thị danh mục và giá trị trên lá Tablets.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Định dạng nhánh Consumer thông qua lá đầu tiên trong nhánh đó.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Định dạng nhánh con Software thông qua lá đầu tiên trong nhánh con đó.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout ảnh hưởng đến nhãn cha của Treemap; Sunburst sử dụng các đoạn vòng.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Các ô danh mục và ô giá trị sử dụng cùng một hàng trong bảng tính, vì vậy vị trí của chúng trong bộ sưu tập vẫn được căn chỉnh. Khi làm việc với một biểu đồ đã tồn tại thay vì tạo mới, trước tiên kiểm tra các hàng danh mục và lưu các tham chiếu được đặt tên tới các điểm dữ liệu và cấp mà bạn muốn định dạng.

## **Hành vi và Các lưu ý Thực tiễn**

### **Sự khác biệt giữa Treemap và Sunburst**

- Treemap sử dụng diện tích để truyền đạt giá trị và các hình chữ nhật lồng nhau để truyền đạt cấu trúc phân cấp. Phương thức [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartseries/#setParentLabelLayout) kiểm soát cách hiển thị nhãn cha trong loại biểu đồ này.
- Sunburst sử dụng góc để truyền đạt giá trị và độ sâu vòng để truyền đạt cấu trúc phân cấp. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartseries/#setParentLabelLayout) không kiểm soát nhãn vòng của nó.
- Cả hai loại biểu đồ đều sử dụng cùng các cấp nhóm danh mục và cùng thứ tự lá‑đến‑cha trả về bởi [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatapoint/#getDataPointLevels), vì vậy mã xây dựng dữ liệu và định dạng cấp có thể chia sẻ.
- Giá trị cha được tính từ các lá con. Không thêm các điểm số riêng cho các nhánh hoặc nhánh con.

### **Sắp xếp và Thứ tự Đoạn**

Công cụ bố cục biểu đồ quyết định vị trí cuối cùng của các hình chữ nhật và đoạn vòng. Hãy nhóm các hàng danh mục liên quan lại với nhau trước khi thêm chúng, nhưng không dựa vào vị trí hình chữ nhật cụ thể hay góc bắt đầu. Nếu thứ tự mang ý nghĩa, hãy đưa nó vào nhãn hoặc dùng loại biểu đồ có trục danh mục rõ ràng.

### **Giao diện và Màu Cố Định**

Các cấp biểu đồ chưa định dạng kế thừa màu từ giao diện bản trình bày. Ví dụ sử dụng màu RGB cố định để có kết quả dự đoán được. Nếu biểu đồ cần tuân theo thay đổi giao diện, hãy dùng màu sắc theo scheme thay vì giá trị RGB cố định và tránh ghi đè mọi cấp. Đồng thời kiểm tra độ tương phản nhãn sau khi thay đổi màu nền của nhánh hoặc nhánh con.

### **Nhãn và Không gian Có sẵn**

PowerPoint có thể ẩn hoặc cắt ngắn nhãn khi đoạn quá nhỏ. Tăng kích thước biểu đồ, rút ngắn tên danh mục, hoặc hiển thị ít trường nhãn hơn thường cho kết quả rõ ràng hơn. Nhãn có thể kết hợp tên danh mục, tên chuỗi và giá trị qua [DataLabelFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabelformat/), nhưng bật mọi trường thường làm biểu đồ phân cấp khó đọc.

### **Xuất và Kết xuất**

Lưu dưới dạng PPTX giữ biểu đồ có thể chỉnh sửa. Khi Aspose.Slides kết xuất bản trình bày sang PDF hoặc hình ảnh, các màu và thiết lập nhãn được hỗ trợ sẽ được vẽ cùng biểu đồ. Thay thế phông chữ và sự khác biệt nhỏ trong không gian bố cục có thể thay đổi cách gói dòng hoặc hiển thị nhãn, vì vậy hãy cài đặt các phông chữ cần thiết và kiểm tra các mục tiêu xuất quan trọng.

## **Câu hỏi thường gặp**

**Tại sao việc thay đổi một cấp cha lại ảnh hưởng đến nhiều lá?**

Một nhánh hoặc nhánh con là đoạn hình ảnh được chia sẻ. [ChartDataPointLevel](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatapointlevel/) của nó có thể được truy cập qua một lá con, nhưng việc định dạng thuộc về đoạn cha chung chứ không chỉ riêng lá đó.

**Tại sao thiếu nhãn dữ liệu?**

Đầu tiên bật các trường cần thiết trên đối tượng [DataLabelFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabelformat/) của nhãn. Sau đó kiểm tra xem đoạn có đủ không gian hay không. Bố cục nhãn cha trong Treemap, kích thước biểu đồ, độ dài nhãn, kích thước phông chữ và số trường đã bật đều ảnh hưởng đến việc nhãn có được hiển thị hay không.

**Có thể đặt thứ tự hoặc tọa độ chính xác cho các đoạn không?**

Bạn có thể kiểm soát thứ tự các hàng nguồn và giữ mỗi nhóm liên tục, nhưng không thể chỉ định chính xác các hình chữ nhật Treemap hoặc góc Sunburst. Công cụ bố cục biểu đồ tính toán chúng dựa trên cấu trúc, giá trị và không gian khả dụng.

**Tại sao màu sắc thay đổi khi giao diện bản trình bày thay đổi?**

Màu dựa trên giao diện được thiết kế để theo bảng màu của bản trình bày. Áp dụng màu RGB rõ ràng cho các cấp cần cố định, hoặc giữ màu scheme khi muốn thích nghi với giao diện mới.

**Định dạng tùy chỉnh có được giữ khi xuất ra PDF và hình ảnh không?**

Có, các màu và thiết lập nhãn được hỗ trợ sẽ được bao gồm trong quá trình kết xuất. Để có kết quả nhất quán trên các hệ thống, hãy cung cấp các phông chữ cần thiết và kiểm tra kích thước xuất cuối cùng vì việc vừa vặn nhãn phụ thuộc vào bố cục.

## **Xem thêm**

- [Tạo biểu đồ Treemap](/slides/vi/python-java/create-chart/#create-tree-map-charts)
- [Tạo biểu đồ Sunburst](/slides/vi/python-java/create-chart/#create-sunburst-charts)
- [Xuất biểu đồ trong bản trình bày](/slides/vi/python-java/export-chart/)
- [Quản lý giao diện bản trình bày](/slides/vi/python-java/presentation-theme/)