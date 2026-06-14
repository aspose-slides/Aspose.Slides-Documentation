---
title: Tùy chỉnh biểu đồ bong bóng trong bản trình chiếu bằng PHP
linktitle: Biểu đồ Bong bóng
type: docs
url: /vi/php-java/bubble-chart/
keywords:
- biểu đồ bong bóng
- kích thước bong bóng
- tỷ lệ kích thước
- cách biểu diễn kích thước
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tạo và tùy chỉnh các biểu đồ bong bóng mạnh mẽ trong PowerPoint với Aspose.Slides cho PHP qua Java để nâng cao việc trực quan hóa dữ liệu một cách dễ dàng."
---
## **Tổng quan**

Bài viết này trình bày cách làm việc với biểu đồ bong bóng trong Aspose.Slides. Nó bao gồm hai tùy chỉnh cụ thể: thay đổi kích thước bong bóng thông qua phương thức `setBubbleSizeScale` và kiểm soát cách các giá trị kích thước bong bóng được biểu diễn thông qua phương thức `setBubbleSizeRepresentation`.

Các ví dụ minh họa cách tạo biểu đồ bong bóng, điều chỉnh việc tỷ lệ kích thước, và chuyển cách biểu diễn kích thước bong bóng sang sử dụng chiều rộng. Bài viết cũng bao gồm một mục FAQ ngắn giải thích về việc hỗ trợ loại biểu đồ “Bubble with 3-D”, lưu ý rằng giới hạn thực tế của biểu đồ phụ thuộc vào hiệu năng và phiên bản PowerPoint mục tiêu, và giải thích rằng việc xuất khẩu giữ nguyên giao diện của biểu đồ thông qua động cơ render của Aspose.Slides.

## **Tỷ lệ Kích thước Biểu đồ Bong bóng**
Aspose.Slides for PHP via Java cung cấp hỗ trợ cho việc tỷ lệ kích thước biểu đồ Bong bóng. Trong Aspose.Slides for PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) và [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) đã được thêm vào. Ví dụ mẫu dưới đây được cung cấp. 

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Biểu diễn Dữ liệu dưới dạng Kích thước Biểu đồ Bong bóng**
Các phương thức [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) và [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) đã được thêm vào các lớp [ChartSeries](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseriesgroup/) và các lớp liên quan. **BubbleSizeRepresentation** chỉ định cách các giá trị kích thước bong bóng được biểu diễn trong biểu đồ bong bóng. Các giá trị khả dụng là: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/BubbleSizeRepresentationType#Area) và [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Do đó, enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/BubbleSizeRepresentationType) đã được thêm vào để chỉ định các cách có thể để biểu diễn dữ liệu dưới dạng kích thước biểu đồ bong bóng. Mã mẫu được đưa ra bên dưới.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**
**Liệu biểu đồ "bubble chart with 3-D effect" có được hỗ trợ không, và nó khác gì so với biểu đồ bình thường?**

Có. Có một loại biểu đồ riêng, "Bubble with 3-D." Nó áp dụng kiểu dáng 3-D cho các bong bóng nhưng không thêm trục phụ; dữ liệu vẫn là X-Y-S (kích thước). Loại này có sẵn trong lớp [chart type](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/).

**Có giới hạn nào về số lượng series và điểm trong biểu đồ bong bóng không?**

Không có giới hạn cứng ở mức API; các ràng buộc được xác định bởi hiệu năng và phiên bản PowerPoint mục tiêu. Đề nghị giữ số lượng điểm ở mức hợp lý để đảm bảo khả năng đọc và tốc độ render.

**Việc xuất khẩu sẽ ảnh hưởng như thế nào đến giao diện của biểu đồ bong bóng (PDF, hình ảnh)?**

Xuất sang các định dạng được hỗ trợ sẽ giữ nguyên giao diện của biểu đồ; quá trình render được thực hiện bởi động cơ Aspose.Slides. Đối với các định dạng raster/vector, các quy tắc chung về render đồ họa biểu đồ áp dụng (độ phân giải, khử răng cưa), vì vậy hãy chọn DPI đủ cho việc in ấn.