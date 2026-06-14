---
title: Tùy chỉnh các điểm dữ liệu trong biểu đồ Treemap và Sunburst bằng Java
linktitle: Các điểm dữ liệu trong biểu đồ Treemap và Sunburst
type: docs
url: /vi/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- biểu đồ treemap
- biểu đồ sunburst
- điểm dữ liệu
- màu nhãn
- màu nhánh
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý các điểm dữ liệu trong biểu đồ treemap và sunburst với Aspose.Slides cho Java, tương thích với các định dạng PowerPoint."
---
## **Giới thiệu**

Trong số các loại biểu đồ PowerPoint khác, có hai loại “phân cấp” - biểu đồ **Treemap** và **Sunburst** (còn được gọi là Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph hoặc Multi Level Pie Chart). Những biểu đồ này hiển thị dữ liệu phân cấp được tổ chức như một cây - từ các lá tới đỉnh của nhánh. Các lá được xác định bởi các điểm dữ liệu của series, và mỗi mức nhóm lồng nhau tiếp theo được xác định bởi danh mục tương ứng. Aspose.Slides for Java cho phép định dạng các điểm dữ liệu của biểu đồ Sunburst và Treemap trong Java.

Dưới đây là một biểu đồ Sunburst, trong đó dữ liệu trong cột Series1 xác định các nút lá, trong khi các cột khác xác định các điểm dữ liệu phân cấp:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Hãy bắt đầu bằng cách thêm một biểu đồ Sunburst mới vào bản trình chiếu:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="See also" %}} 
- [**Create or Update PowerPoint Presentation Charts in Java**](/slides/vi/java/create-chart/)
{{% /alert %}}

Nếu cần định dạng các điểm dữ liệu của biểu đồ, chúng ta nên sử dụng các thành phần sau:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataPointLevel) classes 
and [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) method 
provide access to format data points of Treemap and Sunburst charts. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataPointLevelsManager) 
is used for accessing multi-level categories - it represents the container of 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartCategoryLevelsManager) with 
the properties added specific for data points. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataPointLevel) class has 
two methods: [**getFormat**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataPointLevel#getFormat--) và 
[**getDataLabel**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataPointLevel#getLabel--) which 
provide access to corresponding settings.

## **Hiển thị Giá trị Điểm Dữ liệu**

Hiển thị giá trị của điểm dữ liệu "Leaf 4":

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Đặt Nhãn và Màu cho Điểm Dữ liệu**

Đặt nhãn dữ liệu "Branch 1" để hiển thị tên series ("Series1") thay vì tên danh mục. Sau đó đặt màu văn bản thành màu vàng:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Đặt Màu Nhánh cho Điểm Dữ liệu**

Thay đổi màu của nhánh "Steam 4":

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Câu hỏi thường gặp**

**Tôi có thể thay đổi thứ tự (sắp xếp) của các phân đoạn trong Sunburst/Treemap không?**

Không. PowerPoint tự động sắp xếp các phân đoạn (thông thường theo giá trị giảm dần, theo chiều kim đồng hồ). Aspose.Slides mô phỏng hành vi này: bạn không thể thay đổi thứ tự trực tiếp; bạn phải làm việc này bằng cách tiền xử lý dữ liệu.

**Chủ đề của bản trình chiếu ảnh hưởng như thế nào đến màu sắc của các phân đoạn và nhãn?**

Màu biểu đồ kế thừa [theme/palette](/slides/vi/java/presentation-theme/) của bản trình chiếu trừ khi bạn thiết lập màu nền/phông chữ một cách rõ ràng. Để có kết quả nhất quán, hãy cố định các màu nền đặc và định dạng văn bản ở các mức cần thiết.

**Xuất ra PDF/PNG có giữ lại màu nhánh tùy chỉnh và cài đặt nhãn không?**

Có. Khi xuất bản trình chiếu, các cài đặt biểu đồ (màu nền, nhãn) được giữ lại trong các định dạng đầu ra vì Aspose.Slides render với định dạng biểu đồ đã áp dụng.

**Tôi có thể tính toán tọa độ thực tế của nhãn/đối tượng để đặt lớp phủ tùy chỉnh lên trên biểu đồ không?**

Có. Sau khi bố cục biểu đồ được xác nhận, tọa độ *x* và *y* thực tế có sẵn cho các phần tử (ví dụ, một [DataLabel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/datalabel/)), giúp định vị chính xác các lớp phủ.