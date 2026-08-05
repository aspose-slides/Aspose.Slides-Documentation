---
title: Tùy chỉnh các Điểm dữ liệu trong Biểu đồ Treemap và Sunburst bằng Python
linktitle: Các Điểm dữ liệu trong Biểu đồ Treemap và Sunburst
type: docs
url: /vi/python-net/data-points-of-treemap-and-sunburst-chart/
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
- Aspose.Slides
description: "Tìm hiểu cách tạo dữ liệu phân cấp và tùy chỉnh các cấp độ, nhãn và màu sắc trong biểu đồ Treemap và Sunburst với Aspose.Slides cho Python thông qua .NET."
---
## **Tổng quan**

Biểu đồ Treemap và Sunburst hiển thị cùng một loại dữ liệu phân cấp, nhưng chúng sử dụng bố cục khác nhau. Treemap vẽ phân cấp dưới dạng các hình chữ nhật lồng nhau, trong đó diện tích biểu thị giá trị của lá. Sunburst vẽ nó dưới dạng các vòng đồng tâm: các nhóm cấp cao nhất nằm gần trung tâm, và các danh mục lá nằm ở vòng ngoài.

Trong Aspose.Slides for Python thông qua .NET, mỗi giá trị số là một [ChartDataPoint](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/). Bộ sưu tập [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) cung cấp truy cập tới lá và các nhóm cha của nó. Bài viết này giải thích việc ánh xạ đó và chỉ ra cách tạo và định dạng cả hai loại biểu đồ từ cùng một dữ liệu mẫu.

![Biểu đồ Treemap với các nhánh Consumer và Business](treemap-hierarchy.png)

![Biểu đồ Sunburst với cùng cấu trúc phân cấp Consumer và Business](sunburst-hierarchy.png)

## **Hiểu Các Danh Mục, Điểm Dữ Liệu và Cấp Độ**

Mẫu được sử dụng dưới đây có ba cấp độ danh mục và một chuỗi số:

| Nhánh | Cây con | Lá | Doanh thu |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Mỗi dòng tạo một danh mục lá và một điểm dữ liệu. Các cấp độ nhóm danh mục mô tả đường đi từ lá đó đến các cha của nó. Đối với dòng đầu tiên, đường đi là `Consumer > Computers > Laptops`.

Chỉ mục trong [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) chạy từ lá lên trên:

| `data_point_levels` index | Cấp độ logic | Biểu diễn Treemap | Biểu diễn Sunburst |
| ---: | --- | --- | --- |
| `0` | Lá | Hình chữ nhật giá trị | Đoạn vòng ngoài |
| `1` | Cây con | Hình chữ nhật hoặc tiêu đề cha | Đoạn vòng giữa |
| `2` | Nhánh | Hình chữ nhật hoặc tiêu đề cấp cao nhất | Đoạn vòng trong |

Thứ tự này giống nhau cho cả hai loại biểu đồ mặc dù bố cục trực quan của chúng khác nhau. Một đoạn cha được chia sẻ bởi nhiều lá. Để định dạng nó, hãy sử dụng cấp độ tương ứng của điểm dữ liệu đầu tiên trong nhóm đó. Ví dụ, nhánh `Consumer` bắt đầu với điểm `Laptops`, trong khi cây con `Software` bắt đầu với điểm `Licenses`. Giữ tham chiếu tới các điểm đó rõ ràng và an toàn hơn so với việc sử dụng các biểu thức không giải thích như `data_points[0]` hoặc `data_points[6]`.

## **Tạo và Tùy chỉnh Cả Hai Loại Biểu Đồ**

Ví dụ hoàn chỉnh dưới đây tạo một biểu đồ Treemap trên slide đầu tiên và một biểu đồ Sunburst trên slide thứ hai. Nó xây dựng phân cấp, hiển thị giá trị cho `Tablets`, áp dụng màu cố định cho các cấp độ đã chọn, định dạng nhãn nhánh và lưu bản trình bày.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # Thêm các danh mục lá. Mục nhóm chỉ được đặt khi một nhóm mới bắt đầu;
    # các danh mục tiếp theo sẽ ở lại trong nhóm đó cho đến khi mục khác được đặt.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Hiển thị danh mục và giá trị trên lá Tablets.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Định dạng nhánh Consumer thông qua lá đầu tiên trong nhánh đó.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Định dạng cây con Software thông qua lá đầu tiên trong cây con đó.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout ảnh hưởng đến nhãn cha của Treemap; Sunburst sử dụng các đoạn vòng.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

Các ô danh mục và ô giá trị sử dụng cùng một hàng trong bảng tính, vì vậy vị trí trong bộ sưu tập của chúng vẫn được căn chỉnh. Khi bạn làm việc với một biểu đồ đã có thay vì tạo mới, hãy kiểm tra các hàng danh mục trước và lưu các tham chiếu có tên tới các điểm dữ liệu và cấp độ mà bạn dự định định dạng.

## **Hành vi và Các Lưu ý Thực tế**

### **Sự khác biệt giữa Treemap và Sunburst**

- Treemap sử dụng diện tích để truyền tải giá trị và các hình chữ nhật lồng nhau để truyền tải phân cấp. Thuộc tính [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/parent_label_layout/) điều khiển cách nhãn cha xuất hiện trong loại biểu đồ này.
- Sunburst sử dụng góc để truyền tải giá trị và độ sâu vòng để truyền tải phân cấp. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartseries/parent_label_layout/) không điều khiển các nhãn vòng của nó.
- Cả hai loại biểu đồ đều sử dụng cùng các cấp độ nhóm danh mục và cùng thứ tự lá‑đến‑cha trong `data_point_levels`, do đó mã xây dựng dữ liệu và định dạng cấp độ có thể được chia sẻ.
- Giá trị cha được tính từ các lá con của chúng. Không thêm các điểm số riêng cho các nhánh hoặc cây con.

### **Sắp xếp và Thứ tự Đoạn**

Công cụ bố trí biểu đồ xác định vị trí cuối cùng của các hình chữ nhật và các đoạn vòng. Sắp xếp các hàng danh mục liên quan với nhau trước khi thêm chúng, nhưng không dựa vào một vị trí hình chữ nhật hoặc góc bắt đầu cụ thể. Nếu thứ tự mang ý nghĩa, hãy bao gồm nó trong nhãn hoặc sử dụng loại biểu đồ có trục danh mục rõ ràng.

### **Chủ đề và Màu Cố Định**

Các cấp độ biểu đồ chưa định dạng kế thừa màu từ chủ đề của bản trình bày. Ví dụ sử dụng màu RGB cụ thể để có kết quả dự đoán được. Nếu biểu đồ cần theo thay đổi chủ đề, hãy sử dụng màu dự án (scheme colors) thay vì giá trị RGB cố định và tránh ghi đè mọi cấp độ. Cũng kiểm tra độ tương phản nhãn sau khi thay đổi màu nền của nhánh hoặc cây con.

### **Nhãn và Không gian Có sẵn**

PowerPoint có thể ẩn hoặc cắt ngắn nhãn khi một đoạn quá nhỏ. Tăng kích thước biểu đồ, rút ngắn tên danh mục, hoặc hiển thị ít trường nhãn hơn thường tạo ra kết quả rõ ràng hơn. Nhãn có thể kết hợp tên danh mục, tên chuỗi và giá trị thông qua [DataLabelFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/datalabelformat/), nhưng kích hoạt mọi trường thường làm cho biểu đồ phân cấp khó đọc.

### **Xuất và Kết xuất**

Lưu dưới dạng PPTX giữ cho biểu đồ có thể chỉnh sửa. Khi Aspose.Slides kết xuất bản trình bày sang PDF hoặc hình ảnh, các màu nền và cài đặt nhãn được hỗ trợ sẽ được kết xuất cùng biểu đồ. Thay thế phông chữ và những khác biệt nhỏ trong không gian bố trí khả dụng có thể thay đổi việc ngắt dòng hoặc hiển thị nhãn, vì vậy hãy cài đặt các phông chữ cần thiết và xác minh các mục tiêu xuất quan trọng.

## **Câu hỏi thường gặp**

**Tại sao việc thay đổi một cấp độ cha lại ảnh hưởng tới nhiều lá?**

Một nhánh hoặc cây con là một đoạn hình ảnh được chia sẻ. [ChartDataPointLevel](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapointlevel/) của nó có thể được truy cập qua một lá con, nhưng việc định dạng thuộc về đoạn cha chung chứ không chỉ riêng lá đó.

**Tại sao nhãn dữ liệu lại bị thiếu?**

Đầu tiên hãy bật các trường cần thiết trên đối tượng [DataLabelFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/datalabelformat/) của nhãn. Sau đó kiểm tra xem đoạn có đủ không gian không. Bố cục nhãn cha của Treemap, kích thước biểu đồ, độ dài nhãn, kích thước phông chữ và số lượng trường đã bật đều ảnh hưởng đến việc nhãn có thể hiển thị hay không.

**Tôi có thể đặt thứ tự hoặc tọa độ chính xác cho các đoạn không?**

Bạn có thể kiểm soát thứ tự các hàng nguồn và giữ mỗi nhóm liên tiếp, nhưng không thể chỉ định các hình chữ nhật Treemap hoặc góc Sunburst chính xác. Công cụ bố trí biểu đồ tính toán chúng dựa trên phân cấp, giá trị và không gian khả dụng.

**Tại sao màu sắc thay đổi sau khi thay đổi chủ đề bản trình bày?**

Màu nền dựa trên chủ đề được thiết kế để theo bảng màu của bản trình bày. Áp dụng màu RGB cụ thể cho các cấp độ cần giữ cố định, hoặc duy trì màu dự án khi ưu tiên điều chỉnh theo chủ đề mới.

**Định dạng tùy chỉnh sẽ được giữ trong xuất PDF và hình ảnh không?**

Có, các màu nền và cài đặt nhãn được hỗ trợ sẽ được bao gồm trong quá trình kết xuất. Để có kết quả nhất quán trên các hệ thống, hãy cung cấp các phông chữ cần thiết và kiểm tra kích thước xuất cuối cùng vì việc vừa khít nhãn phụ thuộc vào bố trí.

## **Xem thêm**

- [Tạo biểu đồ Treemap](/slides/vi/python-net/create-chart/#create-tree-map-charts)
- [Tạo biểu đồ Sunburst](/slides/vi/python-net/create-chart/#create-sunburst-charts)
- [Xuất biểu đồ bản trình bày](/slides/vi/python-net/export-chart/)
- [Quản lý chủ đề bản trình bày](/slides/vi/python-net/presentation-theme/)