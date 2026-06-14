---
title: Tùy chỉnh biểu đồ bong bóng trong bài thuyết trình trên .NET
linktitle: Biểu đồ bong bóng
type: docs
url: /vi/net/bubble-chart/
keywords:
- biểu đồ bong bóng
- kích thước bong bóng
- điều chỉnh tỷ lệ kích thước
- biểu diễn kích thước
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tạo và tùy chỉnh các biểu đồ bong bóng mạnh mẽ trong PowerPoint với Aspose.Slides cho .NET để nâng cao việc trực quan hóa dữ liệu một cách dễ dàng."
---
## **Tổng quan**

Bài viết này hướng dẫn cách làm việc với biểu đồ bong bóng trong Aspose.Slides. Nó bao gồm hai tùy chọn tùy chỉnh cụ thể: điều chỉnh kích thước bong bóng thông qua thuộc tính `BubbleSizeScale` và kiểm soát cách các giá trị kích thước bong bóng được biểu diễn thông qua thuộc tính `BubbleSizeRepresentation`.

Các ví dụ minh họa cách tạo biểu đồ bong bóng, điều chỉnh tỷ lệ kích thước và chuyển đổi cách biểu diễn kích thước bong bóng sang sử dụng chiều rộng. Bài viết cũng bao gồm một phần FAQ ngắn giải thích việc hỗ trợ loại biểu đồ “Bubble with 3-D”, lưu ý rằng giới hạn thực tế của biểu đồ phụ thuộc vào hiệu năng và phiên bản PowerPoint mục tiêu, và mô tả cách xuất ra bảo toàn giao diện của biểu đồ thông qua engine render của Aspose.Slides.

## **Điều chỉnh kích thước biểu đồ bong bóng**
Aspose.Slides cho .NET cung cấp hỗ trợ cho việc điều chỉnh kích thước biểu đồ bong bóng. Trong Aspose.Slides cho .NET đã bổ sung các thuộc tính **IChartSeries.BubbleSizeScale** và **IChartSeriesGroup.BubbleSizeScale**. Ví dụ mẫu dưới đây được đưa ra.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Biểu diễn dữ liệu dưới dạng kích thước biểu đồ bong bóng**
Đã thêm thuộc tính **BubbleSizeRepresentation** vào các giao diện IChartSeries, IChartSeriesGroup và các lớp liên quan. **BubbleSizeRepresentation** chỉ định cách các giá trị kích thước bong bóng được biểu diễn trong biểu đồ bong bóng. Các giá trị khả dụng là: **BubbleSizeRepresentationType.Area** và **BubbleSizeRepresentationType.Width**. Theo đó, enum **BubbleSizeRepresentationType** đã được thêm vào để chỉ định các cách biểu diễn dữ liệu dưới dạng kích thước biểu đồ bong bóng. Mã mẫu được đưa ra bên dưới.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Biểu đồ bong bóng có hiệu ứng 3D có được hỗ trợ không, và nó khác gì so với biểu đồ thường?**

Có. Có một loại biểu đồ riêng, "Bubble with 3-D." Nó áp dụng kiểu dáng 3D cho các bong bóng nhưng không thêm trục bổ sung; dữ liệu vẫn là X-Y-S (kích thước). Loại này có sẵn trong liệt kê [kiểu biểu đồ](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/charttype/) .

**Có giới hạn nào về số lượng chuỗi và điểm trong biểu đồ bong bóng không?**

Không có giới hạn cứng ở mức API; các ràng buộc được quyết định bởi hiệu năng và phiên bản PowerPoint mục tiêu. Khuyến nghị giữ số lượng điểm ở mức hợp lý để đảm bảo khả năng đọc và tốc độ render.

**Việc xuất ra sẽ ảnh hưởng như thế nào đến giao diện của biểu đồ bong bóng (PDF, hình ảnh)?**

Xuất ra các định dạng được hỗ trợ sẽ bảo toàn giao diện của biểu đồ; quá trình render được thực hiện bởi engine Aspose.Slides. Đối với các định dạng raster/vector, các quy tắc render đồ họa biểu đồ chung áp dụng (độ phân giải, khử răng cưa), vì vậy hãy chọn DPI đủ cao cho việc in ấn.