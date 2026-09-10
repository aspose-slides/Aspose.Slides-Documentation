---
title: Tùy chỉnh biểu đồ bánh tròn rỗng trong bản trình chiếu bằng Python qua Java
linktitle: Biểu đồ bánh tròn rỗng
type: docs
weight: 30
url: /vi/python-java/doughnut-chart/
keywords:
- biểu đồ bánh tròn rỗng
- khoảng trống trung tâm
- kích thước lỗ
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh biểu đồ bánh tròn rỗng trong Aspose.Slides cho Python qua Java, hỗ trợ định dạng PowerPoint cho các bản trình chiếu động."
---
## **Tổng quan**

Bài viết này cho thấy cách làm việc với biểu đồ bánh tròn rỗng trong Aspose.Slides bằng cách thêm biểu đồ vào slide, thiết lập kích thước lỗ trung tâm, và lưu bản trình chiếu. Nội dung tập trung vào phương thức [setDoughnutHoleSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) và trình bày các bước cơ bản cần thiết để tùy chỉnh loại biểu đồ này trong mã.

Nó cũng bao gồm một phần Câu hỏi thường gặp ngắn gọn về các kịch bản liên quan đến biểu đồ bánh tròn rỗng, chẳng hạn như sử dụng nhiều chuỗi để tạo nhiều vòng, làm việc với biểu đồ bánh tròn rỗng nổ (exploded), và xuất biểu đồ dưới dạng hình ảnh raster hoặc SVG.

## **Xác định Khoảng trống Trung tâm trong Biểu đồ Bánh tròn Rỗng**

{{% alert color="info" title="Lưu ý" %}}
Aspose.Slides cho Python thông qua Java hỗ trợ việc chỉ định kích thước lỗ trong biểu đồ bánh tròn rỗng. Phần này minh họa cách chỉ định kích thước lỗ bằng một ví dụ.
{{% /alert %}}

Để chỉ định kích thước lỗ trong biểu đồ bánh tròn rỗng, thực hiện các bước sau:

1. Tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Thêm biểu đồ bánh tròn rỗng vào slide.
3. Xác định kích thước lỗ trong biểu đồ bánh tròn rỗng.
4. Ghi bản trình chiếu ra đĩa.

Ví dụ sau thiết lập kích thước lỗ trong biểu đồ bánh tròn rỗng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Ghi bản trình chiếu ra đĩa.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể tạo bánh tròn rỗng đa cấp với nhiều vòng không?**

Có. Thêm nhiều chuỗi vào một biểu đồ bánh tròn rỗng — mỗi chuỗi sẽ trở thành một vòng riêng. Thứ tự các vòng được xác định bởi thứ tự của các chuỗi trong bộ sưu tập.

**Biểu đồ bánh tròn rỗng "exploded" (các lát tách rời) có được hỗ trợ không?**

Có. Có một [chart type](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/) Exploded Doughnut và thuộc tính nổ trên các điểm dữ liệu; bạn có thể tách các lát riêng lẻ.

**Làm thế nào để lấy hình ảnh của biểu đồ bánh tròn rỗng (PNG/SVG) cho báo cáo?**

Biểu đồ là một [shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/); bạn có thể render nó thành một [raster image](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage) hoặc xuất biểu đồ ra hình ảnh SVG.