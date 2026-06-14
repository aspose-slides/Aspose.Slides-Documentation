---
title: Tùy chỉnh biểu đồ bong bóng trong bài thuyết trình bằng Python
linktitle: Biểu đồ bong bóng
type: docs
url: /vi/python-net/bubble-chart/
keywords:
- biểu đồ bong bóng
- kích thước bong bóng
- điều chỉnh tỷ lệ kích thước
- cách biểu diễn kích thước
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tạo và tùy chỉnh các biểu đồ bong bóng mạnh mẽ trong PowerPoint và OpenDocument với Aspose.Slides cho Python qua .NET để nâng cao việc trực quan hoá dữ liệu một cách dễ dàng."
---
## **Tổng quan**

Bài viết này hướng dẫn cách làm việc với biểu đồ bong bóng trong Aspose.Slides. Nó đề cập đến hai tùy chỉnh cụ thể: điều chỉnh kích thước bong bóng thông qua thuộc tính `bubble_size_scale` và kiểm soát cách các giá trị kích thước bong bóng được biểu diễn thông qua thuộc tính `bubble_size_representation`.

Các ví dụ minh họa cách tạo biểu đồ bong bóng, điều chỉnh việc chia tỷ lệ kích thước và chuyển đổi cách biểu diễn kích thước bong bóng sang sử dụng chiều rộng. Bài viết cũng bao gồm một phần FAQ ngắn giải thích việc hỗ trợ loại biểu đồ “Bubble with 3-D”, lưu ý rằng giới hạn thực tế của biểu đồ phụ thuộc vào hiệu năng và phiên bản PowerPoint mục tiêu, và giải thích rằng quá trình xuất giữ nguyên giao diện của biểu đồ thông qua engine render của Aspose.Slides.

## **Điều chỉnh tỷ lệ kích thước biểu đồ bong bóng**

Aspose.Slides for Python via .NET cung cấp hỗ trợ cho việc điều chỉnh kích thước biểu đồ bong bóng. Trong Aspose.Slides for Python via .NET đã thêm các thuộc tính **ChartSeries.bubble_size_scale** và **ChartSeriesGroup.bubble_size_scale**. Dưới đây là ví dụ mẫu.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Biểu diễn dữ liệu dưới dạng kích thước biểu đồ bong bóng**

Thuộc tính **bubble_size_representation** đã được thêm vào các lớp ChartSeries, ChartSeriesGroup. **bubble_size_representation** chỉ định cách các giá trị kích thước bong bóng được biểu diễn trong biểu đồ bong bóng. Các giá trị khả dụng là: **BubbleSizeRepresentationType.AREA** và **BubbleSizeRepresentationType.WIDTH**. Theo đó, enum **BubbleSizeRepresentationType** đã được thêm vào để chỉ định các cách biểu diễn dữ liệu dưới dạng kích thước cho biểu đồ bong bóng. Đoạn mã mẫu được đưa ra dưới đây.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Biểu đồ bong bóng có hiệu ứng 3-D có được hỗ trợ không, và nó khác gì so với biểu đồ thường?**

Có. Có một loại biểu đồ riêng, “Bubble with 3-D”. Nó áp dụng kiểu dáng 3-D cho các bong bóng nhưng không thêm trục phụ; dữ liệu vẫn là X-Y-S (kích thước). Loại này có trong enumeration [chart type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/charttype/).

**Có giới hạn nào về số lượng series và điểm trong biểu đồ bong bóng không?**

Không có giới hạn cứng ở mức API; các ràng buộc được quyết định bởi hiệu năng và phiên bản PowerPoint mục tiêu. Khuyến nghị giữ số lượng điểm ở mức hợp lý để đảm bảo khả năng đọc và tốc độ render.

**Quá trình xuất sẽ ảnh hưởng như thế nào đến giao diện của biểu đồ bong bóng (PDF, hình ảnh)?**

Xuất sang các định dạng được hỗ trợ sẽ giữ nguyên giao diện của biểu đồ; quá trình render được thực hiện bởi engine Aspose.Slides. Đối với các định dạng raster/vector, các quy tắc chung về render đồ họa biểu đồ áp dụng (độ phân giải, khử răng cưa), vì vậy hãy chọn DPI đủ cho việc in.