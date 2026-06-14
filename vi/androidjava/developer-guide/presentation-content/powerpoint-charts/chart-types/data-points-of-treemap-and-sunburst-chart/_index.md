---
title: Tùy chỉnh các Điểm Dữ liệu trong biểu đồ Treemap và Sunburst trên Android
linktitle: Các Điểm Dữ liệu trong Biểu đồ Treemap và Sunburst
type: docs
url: /vi/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- biểu đồ treemap
- biểu đồ sunburst
- điểm dữ liệu
- màu nhãn
- màu nhánh
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý các điểm dữ liệu trong biểu đồ treemap và sunburst bằng Aspose.Slides cho Android qua Java, tương thích với các định dạng PowerPoint."
---
## **Giới thiệu**

Trong số các loại biểu đồ PowerPoint, có hai loại “phân cấp” – **Treemap** và **Sunburst** (còn được gọi là Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph hoặc Multi Level Pie Chart). Những biểu đồ này hiển thị dữ liệu phân cấp được tổ chức dạng cây – từ các lá tới phần trên của nhánh. Các lá được xác định bởi các điểm dữ liệu của series, và mỗi cấp nhóm lồng nhau tiếp theo được xác định bằng danh mục tương ứng. Aspose.Slides for Android via Java cho phép định dạng các điểm dữ liệu của biểu đồ Sunburst và Treemap trong Java.

Dưới đây là một biểu đồ Sunburst, trong đó dữ liệu ở cột Series1 xác định các nút lá, trong khi các cột khác xác định các điểm dữ liệu phân cấp:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Hãy bắt đầu bằng cách thêm một biểu đồ Sunburst mới vào bài thuyết trình:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Xem thêm" %}} 
- [**Tạo hoặc Cập nhật Biểu đồ PowerPoint trên Android**](/slides/vi/androidjava/create-chart/)
{{% /alert %}}

Nếu cần định dạng các điểm dữ liệu của biểu đồ, chúng ta nên sử dụng các lớp:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataPointLevel) 
và [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) 
để truy cập và định dạng các điểm dữ liệu của biểu đồ Treemap và Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataPointLevelsManager)
được dùng để truy cập các danh mục đa cấp – nó đại diện cho bộ chứa của 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataPointLevel) objects.
Cơ bản nó là một wrapper cho 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartCategoryLevelsManager) với các thuộc tính được thêm vào đặc thù cho các điểm dữ liệu. 
Lớp [**IChartDataPointLevel**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataPointLevel) có hai phương thức: [**getFormat**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) và [**getDataLabel**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) cung cấp quyền truy cập vào các cài đặt tương ứng.

## **Hiển thị Giá trị Điểm Dữ liệu**

Hiển thị giá trị của điểm dữ liệu “Leaf 4”:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Thiết lập Nhãn và Màu cho Điểm Dữ liệu**

Đặt nhãn dữ liệu “Branch 1” hiển thị tên series (“Series1”) thay vì tên danh mục. Sau đó đặt màu văn bản thành màu vàng:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Thiết lập Màu Nhánh cho Điểm Dữ liệu**

Thay đổi màu của nhánh “Steam 4”:

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

Không. PowerPoint tự động sắp xếp các phân đoạn (thường theo giá trị giảm dần, theo chiều kim đồng hồ). Aspose.Slides phản chiếu hành vi này: bạn không thể thay đổi thứ tự trực tiếp; bạn phải thực hiện trước việc tiền xử lý dữ liệu.

**Giao diện trình chiếu ảnh hưởng như thế nào đến màu sắc của các phân đoạn và nhãn?**

Màu biểu đồ kế thừa [giao diện/chủ đề](/slides/vi/androidjava/presentation-theme/) của trình chiếu trừ khi bạn tự đặt màu nền/phông chữ. Để có kết quả nhất quán, hãy khóa màu nền đặc và định dạng văn bản ở các cấp cần thiết.

**Xuất ra PDF/PNG có giữ nguyên màu nhánh và cài đặt nhãn tùy chỉnh không?**

Có. Khi xuất trình chiếu, các cài đặt biểu đồ (đổ màu, nhãn) được bảo tồn trong các định dạng đầu ra vì Aspose.Slides render với định dạng biểu đồ đã được áp dụng.

**Tôi có thể tính toán tọa độ thực tế của nhãn/đối tượng để đặt overlay tùy chỉnh lên trên biểu đồ không?**

Có. Sau khi bố cục biểu đồ được xác nhận, giá trị *x* và *y* thực tế của các phần tử (ví dụ, một [DataLabel](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/datalabel/)) có sẵn, giúp định vị chính xác các overlay.