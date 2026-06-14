---
title: Tùy chỉnh các Điểm Dữ liệu trong Biểu đồ Treemap và Sunburst bằng PHP
linktitle: Các Điểm Dữ liệu trong Biểu đồ Treemap và Sunburst
type: docs
url: /vi/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- biểu đồ treemap
- biểu đồ sunburst
- điểm dữ liệu
- màu nhãn
- màu nhánh
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tìm hiểu cách quản lý các điểm dữ liệu trong biểu đồ treemap và sunburst với Aspose.Slides cho PHP qua Java, tương thích với các định dạng PowerPoint."
---
## **Giới thiệu**

Trong các loại biểu đồ PowerPoint khác, có hai loại “hierarchical” - **Treemap** và **Sunburst** ( còn được gọi là Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph hoặc Multi Level Pie Chart). Các biểu đồ này hiển thị dữ liệu phân cấp được tổ chức dưới dạng cây - từ lá tới đỉnh nhánh. Các lá được xác định bởi các điểm dữ liệu trong series, và mỗi mức nhóm lồng nhau tiếp theo được xác định bởi danh mục tương ứng. Aspose.Slides for PHP via Java cho phép định dạng các điểm dữ liệu của biểu đồ Sunburst và Treemap .

Đây là một biểu đồ Sunburst, trong đó dữ liệu trong cột Series1 xác định các nút lá, trong khi các cột khác xác định các điểm dữ liệu phân cấp:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Hãy bắt đầu bằng cách thêm biểu đồ Sunburst mới vào bản trình bày:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Xem thêm" %}} 
- [**Tạo hoặc Cập nhật Biểu đồ Bản trình bày PowerPoint trong PHP**](/slides/vi/php-java/create-chart/)
{{% /alert %}}

Nếu cần định dạng các điểm dữ liệu của biểu đồ, chúng ta nên sử dụng những thứ sau:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapointlevelsmanager/), [**ChartDataPointLevel**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapointlevel/) **classes** và phương thức [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) cung cấp quyền truy cập để định dạng các điểm dữ liệu của biểu đồ Treemap và Sunburst. [**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapointlevelsmanager/) được dùng để truy cập các danh mục đa mức - nó đại diện cho container của các đối tượng [**ChartDataPointLevel**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapointlevel/). Về cơ bản, nó là một wrapper cho [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartcategorylevelsmanager/) với các thuộc tính được thêm riêng cho các điểm dữ liệu. Lớp [**ChartDataPointLevel**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapointlevel/) có hai phương thức: [**getFormat**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapointlevel/#getFormat) và [**getDataLabel**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapointlevel/#getLabel) cung cấp quyền truy cập vào các cài đặt tương ứng.

## **Hiển thị Giá trị Điểm Dữ liệu**
Hiển thị giá trị của điểm dữ liệu “Leaf 4”:

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Đặt Nhãn và Màu cho Điểm Dữ liệu**
Đặt nhãn dữ liệu “Branch 1” để hiển thị tên series (“Series1”) thay vì tên danh mục. Sau đó đặt màu văn bản thành màu vàng:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Đặt Màu Nhánh cho Điểm Dữ liệu**
Thay đổi màu của nhánh “Steam 4”:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Câu hỏi thường gặp**

**Tôi có thể thay đổi thứ tự (sắp xếp) của các phân đoạn trong Sunburst/Treemap không?**

Không. PowerPoint tự động sắp xếp các phân đoạn (thường theo giá trị giảm dần, theo chiều kim đồng hồ). Aspose.Slides phản chiếu hành vi này: bạn không thể thay đổi thứ tự trực tiếp; bạn phải thực hiện bằng cách tiền xử lý dữ liệu.

**Chủ đề của bản trình bày ảnh hưởng như thế nào đến màu sắc của các phân đoạn và nhãn?**

Màu biểu đồ kế thừa [chủ đề/bảng màu](/slides/vi/php-java/presentation-theme/) của bản trình bày trừ khi bạn tự đặt màu nền/phông chữ. Để có kết quả nhất quán, hãy cố định các màu nền đặc và định dạng văn bản ở các mức cần thiết.

**Xuất ra PDF/PNG có giữ nguyên màu nhánh tùy chỉnh và cài đặt nhãn không?**

Có. Khi xuất bản trình bày, các cài đặt biểu đồ (màu nền, nhãn) được giữ nguyên trong các định dạng đầu ra vì Aspose.Slides render với định dạng của biểu đồ đã áp dụng.

**Tôi có thể tính toán tọa độ thực tế của một nhãn/đối tượng để đặt lớp phủ tùy chỉnh lên trên biểu đồ không?**

Có. Sau khi bố cục biểu đồ được xác nhận, giá trị *x* thực tế và *y* thực tế có sẵn cho các phần tử (ví dụ, một [DataLabel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datalabel/)), giúp định vị lớp phủ một cách chính xác.