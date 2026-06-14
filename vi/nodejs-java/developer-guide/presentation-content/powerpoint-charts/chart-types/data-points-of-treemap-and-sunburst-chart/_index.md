---
title: Tuỳ chỉnh các điểm dữ liệu trong biểu đồ Treemap và Sunburst bằng JavaScript
linktitle: Các điểm dữ liệu trong biểu đồ Treemap và Sunburst
type: docs
url: /vi/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- biểu đồ treemap
- biểu đồ sunburst
- điểm dữ liệu
- màu nhãn
- màu nhánh
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: Tìm hiểu cách quản lý các điểm dữ liệu trong biểu đồ treemap và sunburst bằng JavaScript và Aspose.Slides cho Node.js qua Java, tương thích với các định dạng PowerPoint.
---
## **Giới thiệu**

Trong số các loại biểu đồ PowerPoint khác, có hai loại biểu đồ “phân cấp” - **Treemap** và **Sunburst** (còn được gọi là Đồ thị Sunburst, Sơ đồ Sunburst, Biểu đồ Tâm tròn, Đồ thị Tâm tròn hoặc Biểu đồ Pie Đa cấp). Các biểu đồ này hiển thị dữ liệu phân cấp được tổ chức dưới dạng cây - từ các lá tới đầu nhánh. Các lá được xác định bởi các điểm dữ liệu của chuỗi, và mỗi mức nhóm lồng nhau tiếp theo được xác định bởi danh mục tương ứng. Aspose.Slides cho Node.js thông qua Java cho phép định dạng các điểm dữ liệu của biểu đồ Sunburst và Treemap trong JavaScript.

Đây là một biểu đồ Sunburst, trong đó dữ liệu ở cột Series1 xác định các nút lá, trong khi các cột khác xác định các điểm dữ liệu phân cấp:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Hãy bắt đầu bằng việc thêm một biểu đồ Sunburst mới vào bản trình bày:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="Xem thêm" %}} 
- [**Tạo hoặc Cập nhật Biểu đồ PowerPoint trong JavaScript**](/slides/vi/nodejs-java/create-chart/)
{{% /alert %}}

Nếu cần định dạng các điểm dữ liệu của biểu đồ, chúng ta nên sử dụng những thứ sau:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataPointLevel) classes 
and [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) method 
cung cấp quyền truy cập để định dạng các điểm dữ liệu của biểu đồ Treemap và Sunburst. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataPointLevelsManager)
được sử dụng để truy cập các danh mục đa cấp - nó đại diện cho bộ chứa của 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataPointLevel) objects.
Về cơ bản, nó là một wrapper cho 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartCategoryLevelsManager) với 
các thuộc tính được thêm vào đặc thù cho các điểm dữ liệu. 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataPointLevel) class có 
hai phương thức: [**getFormat**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) và 
[**getDataLabel**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) which 
cung cấp quyền truy cập tới các cài đặt tương ứng.

## **Hiển thị Giá trị Điểm Dữ liệu**

Hiển thị giá trị của điểm dữ liệu "Leaf 4":

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Đặt Nhãn và Màu cho Điểm Dữ liệu**

Đặt nhãn dữ liệu "Branch 1" để hiển thị tên chuỗi ("Series1") thay vì tên danh mục. Sau đó đặt màu văn bản thành màu vàng:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Đặt Màu Nhánh cho Điểm Dữ liệu**

Thay đổi màu của nhánh "Steam 4":

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Câu hỏi thường gặp**

**Tôi có thể thay đổi thứ tự (sắp xếp) của các phân đoạn trong Sunburst/Treemap không?**

Không. PowerPoint tự động sắp xếp các phân đoạn (thông thường theo giá trị giảm dần, theo chiều kim đồng hồ). Aspose.Slides phản chiếu hành vi này: bạn không thể thay đổi thứ tự trực tiếp; bạn phải thực hiện bằng cách tiền xử lý dữ liệu.

**Giao diện bản trình bày ảnh hưởng như thế nào đến màu sắc của các phân đoạn và nhãn?**

Màu sắc của biểu đồ kế thừa [giao diện/bảng màu](/slides/vi/nodejs-java/presentation-theme/) của bản trình bày trừ khi bạn thiết lập màu nền/phông chữ một cách rõ ràng. Để có kết quả nhất quán, hãy cố định màu nền đặc và định dạng văn bản ở các cấp cần thiết.

**Xuất ra PDF/PNG có giữ nguyên màu nhánh tùy chỉnh và cài đặt nhãn không?**

Có. Khi xuất bản trình bày, các cài đặt biểu đồ (màu nền, nhãn) được giữ trong các định dạng đầu ra vì Aspose.Slides render với định dạng của biểu đồ được áp dụng.

**Tôi có thể tính toán tọa độ thực tế của nhãn/phần tử để đặt lớp phủ tùy chỉnh lên trên biểu đồ không?**

Có. Sau khi bố cục biểu đồ được xác nhận, giá trị X thực tế và Y thực tế có sẵn cho các phần tử (ví dụ, một [DataLabel](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/datalabel/)), giúp định vị chính xác các lớp phủ.