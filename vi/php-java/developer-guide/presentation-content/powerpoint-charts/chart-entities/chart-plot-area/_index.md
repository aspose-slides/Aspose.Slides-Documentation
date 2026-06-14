---
title: Tùy chỉnh khu vực vẽ của biểu đồ trong bản trình chiếu bằng PHP
linktitle: Khu vực vẽ
type: docs
url: /vi/php-java/chart-plot-area/
keywords:
- biểu đồ
- khu vực vẽ
- chiều rộng khu vực vẽ
- chiều cao khu vực vẽ
- kích thước khu vực vẽ
- chế độ bố cục
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Khám phá cách tùy chỉnh khu vực vẽ của biểu đồ trong bản trình chiếu PowerPoint bằng Aspose.Slides cho PHP thông qua Java. Nâng cao hình ảnh slide của bạn một cách dễ dàng."
---
## **Tổng quan**

Bài viết này trình bày cách làm việc với khu vực vẽ (plot area) của biểu đồ trong Aspose.Slides. Nó giải thích cách lấy vị trí và kích thước thực tế của khu vực vẽ bằng cách xác thực bố cục biểu đồ và sau đó đọc các giá trị X, Y, chiều rộng và chiều cao của nó.

Nó cũng minh họa cách cấu hình chế độ bố cục của khu vực vẽ khi bố cục được đặt thủ công, sử dụng `LayoutTargetType` để xác định khu vực vẽ được tính dựa trên vùng bên trong hay vùng bên ngoài cùng với các trục và nhãn trục.

## **Lấy Chiều Rộng và Chiều Cao của Khu Vực Vẽ Biểu Đồ**
Aspose.Slides for PHP via Java cung cấp một API đơn giản cho .

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) .
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Gọi phương thức [Chart.validateChartLayout](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/validatechartlayout/) trước để lấy các giá trị thực tế.
5. Lấy vị trí X thực tế (trái) của phần tử biểu đồ so với góc trái trên của biểu đồ.
6. Lấy vị trí trên thực tế của phần tử biểu đồ so với góc trái trên của biểu đồ.
7. Lấy chiều rộng thực tế của phần tử biểu đồ.
8. Lấy chiều cao thực tế của phần tử biểu đồ.

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt Chế Độ Bố Cục của Khu Vực Vẽ Biểu Đồ**
Aspose.Slides for PHP via Java cung cấp một API đơn giản để đặt chế độ bố cục của khu vực vẽ biểu đồ. Các phương thức [**setLayoutTargetType**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) và [**getLayoutTargetType**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) đã được thêm vào lớp [**ChartPlotArea**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ChartPlotArea). Nếu bố cục của khu vực vẽ được định nghĩa thủ công, thuộc tính này chỉ định xem có bố trí khu vực vẽ bằng phần trong (không bao gồm trục và nhãn trục) hay phần ngoài (bao gồm trục và nhãn trục). Có hai giá trị khả dụng được định nghĩa trong enum [**LayoutTargetType**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LayoutTargetType#Inner) - chỉ định rằng kích thước khu vực vẽ sẽ quyết định kích thước của khu vực vẽ, không bao gồm các dấu tick và nhãn trục.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LayoutTargetType#Outer) - chỉ định rằng kích thước khu vực vẽ sẽ quyết định kích thước của khu vực vẽ, các dấu tick và nhãn trục.

Mã mẫu được đưa ở bên dưới.

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Đơn vị nào được sử dụng cho x thực tế, y thực tế, chiều rộng thực tế và chiều cao thực tế?**  
Bằng điểm; 1 inch = 72 điểm. Đây là đơn vị tọa độ của Aspose.Slides.

**Khu vực vẽ (Plot Area) khác gì so với khu vực biểu đồ (Chart Area) về nội dung?**  
Khu vực vẽ là vùng vẽ dữ liệu (dòng dữ liệu, lưới, đường xu hướng, v.v.); khu vực biểu đồ bao gồm các thành phần xung quanh (tiêu đề, chú giải, v.v.). Trong các biểu đồ 3D, khu vực vẽ cũng bao gồm các bức tường/mặt sàn và các trục.

**Khi bố cục được đặt thủ công, x, y, chiều rộng và chiều cao của khu vực vẽ được diễn giải như thế nào?**  
Chúng là các tỷ lệ (0–1) của kích thước tổng thể của biểu đồ; trong chế độ này, việc định vị tự động bị tắt và các tỷ lệ bạn thiết lập sẽ được sử dụng.

**Tại sao vị trí của khu vực vẽ lại thay đổi sau khi thêm/chuyển vị chú giải?**  
Chú giải nằm trong khu vực biểu đồ bên ngoài khu vực vẽ nhưng ảnh hưởng đến bố cục và không gian khả dụng, vì vậy khu vực vẽ có thể dịch chuyển khi tính năng định vị tự động đang hoạt động. (Đây là hành vi tiêu chuẩn của các biểu đồ PowerPoint.)