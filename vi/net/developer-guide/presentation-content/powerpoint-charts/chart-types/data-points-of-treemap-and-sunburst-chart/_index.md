---
title: Tùy chỉnh các Điểm Dữ liệu trong Biểu đồ Treemap và Sunburst trên .NET
linktitle: Các Điểm Dữ liệu trong Biểu đồ Treemap và Sunburst
type: docs
url: /vi/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- biểu đồ treemap
- biểu đồ sunburst
- điểm dữ liệu
- màu nhãn
- màu nhánh
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách quản lý các điểm dữ liệu trong biểu đồ treemap và sunburst bằng Aspose.Slides cho .NET, tương thích với các định dạng PowerPoint."
---
## **Giới thiệu**

Trong số các loại biểu đồ PowerPoint, có hai loại “phân cấp” – **Treemap** và biểu đồ **Sunburst** (còn được gọi là Đồ thị Sunburst, Sơ đồ Sunburst, Biểu đồ Tâm Tròn, Đồ thị Tâm Tròn hoặc Biểu đồ Pie Nhiều Cấp). Các biểu đồ này hiển thị dữ liệu phân cấp được tổ chức dạng cây - từ các lá đến đỉnh nhánh. Các lá được xác định bởi các điểm dữ liệu của series, và mỗi cấp nhóm lồng nhau tiếp theo được xác định bởi danh mục tương ứng. Aspose.Slides for .NET cho phép định dạng các điểm dữ liệu của biểu đồ Sunburst và Treemap bằng C#.

Dưới đây là một biểu đồ Sunburst, trong đó dữ liệu ở cột Series1 xác định các nút lá, trong khi các cột khác xác định các điểm dữ liệu phân cấp:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Hãy bắt đầu bằng cách thêm một biểu đồ Sunburst mới vào bản trình chiếu:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Xem thêm" %}} 
- [**Tạo biểu đồ Sunburst**](/slides/vi/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Nếu cần định dạng các điểm dữ liệu của biểu đồ, chúng ta nên sử dụng các lớp và thuộc tính sau:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/IChartDataPointLevelsManager),
[IChartDataPointLevel](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapointlevel) và
[**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) cung cấp khả năng truy cập để định dạng các điểm dữ liệu của biểu đồ Treemap và Sunburst.
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/IChartDataPointLevelsManager) được sử dụng để truy cập các danh mục đa cấp – nó đại diện cho bộ chứa các đối tượng
[**IChartDataPointLevel**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/IChartDataPointLevel).
Cơ bản nó là một wrapper cho
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/IChartCategoryLevelsManager) với các thuộc tính được thêm vào riêng cho các điểm dữ liệu.
Lớp [**IChartDataPointLevel**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/IChartDataPointLevel) có hai thuộc tính: [**Format**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapointlevel/properties/format) và
[**DataLabel**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapointlevel/properties/label) cung cấp quyền truy cập vào các cài đặt tương ứng.

## **Hiển thị Giá trị Điểm Dữ liệu**
Hiển thị giá trị của điểm dữ liệu “Leaf 4”:

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Đặt Nhãn và Màu cho Điểm Dữ liệu**
Đặt nhãn “Branch 1” để hiển thị tên series (“Series1”) thay vì tên danh mục. Sau đó đặt màu chữ thành màu vàng:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Đặt Màu Nhánh cho Điểm Dữ liệu**
Thay đổi màu của nhánh “Stem 4”:

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Câu hỏi thường gặp**

**Tôi có thể thay đổi thứ tự (sắp xếp) của các đoạn trong Sunburst/Treemap không?**

Không. PowerPoint tự động sắp xếp các đoạn (thông thường theo giá trị giảm dần, theo chiều kim đồng hồ). Aspose.Slides phản chiếu hành vi này: bạn không thể thay đổi thứ tự trực tiếp; bạn cần tiền xử lý dữ liệu để đạt được mục tiêu.

**Giao diện bản trình chiếu ảnh hưởng như thế nào đến màu sắc của các đoạn và nhãn?**

Màu biểu đồ kế thừa [giao diện/chủ đề](/slides/vi/net/presentation-theme/) của bản trình chiếu trừ khi bạn thiết lập màu nền/phông chữ một cách rõ ràng. Để có kết quả nhất quán, hãy khóa màu nền rắn và định dạng văn bản ở các cấp cần thiết.

**Khi xuất ra PDF/PNG, các màu nhánh và cài đặt nhãn tùy chỉnh có được giữ lại không?**

Có. Khi xuất bản trình chiếu, các cài đặt biểu đồ (màu nền, nhãn) được bảo tồn trong các định dạng đầu ra vì Aspose.Slides render với định dạng biểu đồ đã được áp dụng.

**Tôi có thể tính toán tọa độ thực tế của một nhãn/đối tượng để đặt lớp phủ tùy chỉnh lên trên biểu đồ không?**

Có. Sau khi bố cục biểu đồ được xác nhận, các thuộc tính `ActualX`/`ActualY` có sẵn cho các phần tử (ví dụ, một [DataLabel](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/datalabel/)), giúp định vị chính xác các lớp phủ.