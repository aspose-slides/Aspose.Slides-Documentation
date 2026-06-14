---
title: Tùy chỉnh các Điểm Dữ Liệu trong Biểu Đồ Treemap và Sunburst bằng Python
linktitle: Các Điểm Dữ Liệu trong Biểu Đồ Treemap và Sunburst
type: docs
url: /vi/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- biểu đồ treemap
- biểu đồ sunburst
- điểm dữ liệu
- màu nhãn
- màu nhánh
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý các điểm dữ liệu trong biểu đồ treemap và sunburst với Aspose.Slides cho Python qua .NET, tương thích với định dạng PowerPoint và OpenDocument."
---
## **Giới thiệu**

Trong số các loại biểu đồ PowerPoint khác, có hai loại biểu đồ phân cấp — **Treemap** và **Sunburst** (còn được gọi là Đồ thị Sunburst, Sơ đồ Sunburst, Biểu đồ Xuyên tâm, Đồ thị Xuyên tâm, hoặc Biểu đồ Tròn Đa Cấp). Các biểu đồ này hiển thị dữ liệu phân cấp được tổ chức dưới dạng cây — từ các lá tới đỉnh của một nhánh. Các lá được xác định bởi các điểm dữ liệu của series, và mỗi cấp nhóm lồng nhau tiếp theo được xác định bằng danh mục tương ứng. Aspose.Slides for Python via .NET cho phép bạn định dạng các điểm dữ liệu của biểu đồ Sunburst và Treemap trong Python.

Đây là một biểu đồ Sunburst trong đó dữ liệu ở cột Series1 xác định các nút lá, trong khi các cột khác xác định các điểm dữ liệu phân cấp:

![Ví dụ biểu đồ Sunburst](sunburst_example.png)

Hãy bắt đầu bằng cách thêm một biểu đồ Sunburst mới vào bản trình chiếu:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="See also" %}}
- [**Tạo Biểu Đồ Sunburst**](/slides/vi/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Nếu bạn cần định dạng các điểm dữ liệu của biểu đồ, hãy sử dụng các API sau:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapointlevel/), và thuộc tính [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) . Chúng cung cấp quyền truy cập để định dạng các điểm dữ liệu trong biểu đồ Treemap và Sunburst. ChartDataPointLevelsManager được sử dụng để truy cập các danh mục đa cấp; nó đại diện cho một container của các đối tượng ChartDataPointLevel. Nó thực chất là một wrapper quanh ChartCategoryLevelsManager với các thuộc tính bổ sung đặc thù cho các điểm dữ liệu. Kiểu ChartDataPointLevel cung cấp hai thuộc tính — [format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapointlevel/format/) và [label](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatapointlevel/label/) — cho phép truy cập vào các cài đặt tương ứng.

## **Hiển thị Giá Trị Điểm Dữ Liệu**

Phần này trình bày cách hiển thị giá trị cho từng điểm dữ liệu trong biểu đồ Treemap và Sunburst. Bạn sẽ thấy cách bật nhãn giá trị cho các điểm đã chọn.

Hiển thị giá trị của điểm dữ liệu "Leaf 4":

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Giá trị điểm dữ liệu](data_point_value.png)

## **Đặt Nhãn và Màu cho Điểm Dữ Liệu**

Phần này hướng dẫn cách đặt nhãn và màu tùy chỉnh cho từng điểm dữ liệu trong biểu đồ Treemap và Sunburst. Bạn sẽ học cách truy cập một điểm dữ liệu cụ thể, gán nhãn, và áp dụng tô đầy đặc để làm nổi bật các nút quan trọng.

Đặt nhãn dữ liệu "Branch 1" để hiển thị tên series ("Series1") thay vì tên danh mục, sau đó đặt màu văn bản thành màu vàng:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Nhãn và màu của điểm dữ liệu](data_point_color.png)

## **Đặt Màu Nhánh cho Điểm Dữ Liệu**

Sử dụng màu nhánh để kiểm soát cách các nút cha và con được nhóm lại về mặt trực quan trong biểu đồ Treemap và Sunburst. Phần này trình bày cách đặt màu nhánh tùy chỉnh cho một điểm dữ liệu cụ thể để bạn có thể làm nổi bật các cây con quan trọng và cải thiện khả năng đọc biểu đồ.

Thay đổi màu của nhánh "Stem 4":

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Màu nhánh](branch_color.png)

## **Câu Hỏi Thường Gặp**

**Có thể thay đổi thứ tự (sắp xếp) của các đoạn trong Sunburst/Treemap không?**

Không. PowerPoint tự động sắp xếp các đoạn (thường theo giá trị giảm dần, theo chiều kim đồng hồ). Aspose.Slides phản chiếu hành vi này: bạn không thể thay đổi thứ tự trực tiếp; thay vào đó bạn phải tiền xử lý dữ liệu.

**Giao diện bản trình chiếu ảnh hưởng như thế nào đến màu sắc của các đoạn và nhãn?**

Màu biểu đồ kế thừa [giao diện/bảng màu](/slides/vi/python-net/presentation-theme/) của bản trình chiếu trừ khi bạn thiết lập màu nền/phông chữ một cách rõ ràng. Để có kết quả nhất quán, hãy cố định màu nền đặc và định dạng văn bản ở các mức cần thiết.

**Việc xuất ra PDF/PNG có giữ lại màu nhánh tùy chỉnh và cài đặt nhãn không?**

Có. Khi xuất bản trình chiếu, các cài đặt biểu đồ (màu nền, nhãn) được giữ nguyên trong các định dạng đầu ra vì Aspose.Slides render với định dạng biểu đồ đã áp dụng.

**Có thể tính toán tọa độ thực tế của nhãn/đối tượng để đặt lớp phủ tùy chỉnh lên trên biểu đồ không?**

Có. Sau khi bố cục biểu đồ được xác nhận, `actual_x`/`actual_y` có sẵn cho các phần tử (ví dụ, một [DataLabel](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/datalabel/)), giúp định vị chính xác các lớp phủ.