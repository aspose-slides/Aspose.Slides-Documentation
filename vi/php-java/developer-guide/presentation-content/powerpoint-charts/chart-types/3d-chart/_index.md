---
title: Tùy chỉnh biểu đồ 3D trong bản trình chiếu bằng PHP
linktitle: Biểu đồ 3D
type: docs
url: /vi/php-java/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tạo biểu đồ 3D trong bản trình chiếu PowerPoint với Aspose.Slides cho PHP thông qua Java. Điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu của biểu đồ và khoảng cách giữa các chuỗi bằng các ví dụ PHP."
---
## **Tổng quan**

Aspose.Slides cho PHP thông qua Java cho phép bạn tùy chỉnh cách hiển thị của biểu đồ 3D thông qua phương thức [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D). Bài viết này mô tả cách điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu, trục góc vuông và khoảng cách giữa các chuỗi, sau đó lưu bản trình chiếu ở định dạng PPTX.

## **Đặt góc quay và độ sâu của biểu đồ 3D**

Ví dụ dưới đây tạo một [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) và sử dụng [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) để thêm một biểu đồ cột 3D chồng vào slide đầu tiên. Nó thay thế các chuỗi và danh mục mặc định bằng hai chuỗi, mỗi chuỗi chứa ba giá trị. Chỉ mục bảng tính `0` xác định bảng dữ liệu đầu tiên của biểu đồ; hàng `0` chứa tên chuỗi, và cột `0` chứa nhãn danh mục.

[setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) và [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) đặt góc quay của biểu đồ lần lượt là 40 và 270 độ. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) đặt độ sâu của nó ở mức 150% chiều rộng, trong khi [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) bật trục góc vuông thay vì phối cảnh. Bản trình chiếu kết quả chứa biểu đồ đã được điền dữ liệu với các thiết lập hiển thị 3D này.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Điều chỉnh tỷ lệ chiều cao của biểu đồ 3D**

Sử dụng [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm của chiều rộng. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ sau tạo một biểu đồ [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) với dữ liệu mặc định: ba chuỗi và bốn danh mục. Nó lưu ba bản trình chiếu với tỷ lệ chiều cao lần lượt là 50%, 100% và 200%. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn cố định. Dữ liệu, góc quay, độ sâu, khoảng cách giữa các chuỗi và định dạng đều giống nhau trong ba tệp; chỉ có phần trăm chiều cao thay đổi.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Các hình ảnh sau minh họa cùng một thiết lập chiều cao trong ví dụ .NET tương đương và đã được xuất bằng Microsoft PowerPoint. Một phần trăm nhỏ hơn tạo ra một cảnh phẳng hơn, trong khi một phần trăm lớn hơn tạo ra một cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng cách các tick trên trục và vị trí nhãn để phù hợp với cảnh.

| Chiều cao: 50% | Chiều cao: 100% | Chiều cao: 200% |
| --- | --- | --- |
| ![Biểu đồ cột 3D với chiều cao được đặt ở 50% chiều rộng](height_percent_50.png) | ![Biểu đồ cột 3D với chiều cao được đặt ở 100% chiều rộng](height_percent_100.png) | ![Biểu đồ cột 3D với chiều cao được đặt ở 200% chiều rộng](height_percent_200.png) |

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu quả |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Chiều cao của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng điểm. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Độ sâu của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Khoảng cách giữa các chuỗi dọc theo trục độ sâu, tính bằng phần trăm của độ rộng dấu đánh dấu. |

Cài đặt chiều cao ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ đường, khu vực, bánh và bề mặt 3D. So sánh ở trên sử dụng kiểu `Column3D` đã được xác minh. Cài đặt này không thay đổi giao diện của biểu đồ 2D `ClusteredColumn` hoặc biểu đồ `BubbleWith3D`; những tên này là thành viên của lớp [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Đối với các cài đặt giao diện biểu đồ khác, xem [Định dạng biểu đồ](/slides/vi/php-java/chart-formatting/).

## **Điều chỉnh khoảng cách giữa các chuỗi**

Sử dụng [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) để kiểm soát khoảng cách giữa các chuỗi dữ liệu dọc theo trục độ sâu của biểu đồ 3D, được biểu thị dưới dạng phần trăm của độ rộng dấu đánh dấu. Sử dụng các giá trị từ **0 đến 500**, bao gồm: `0` loại bỏ khoảng trống, trong khi các giá trị lớn hơn tăng khoảng cách. Với độ sâu biểu đồ cố định, tăng khoảng trống làm cho các dấu đánh dấu mỏng hơn dọc theo trục độ sâu.

Truy cập nhóm thông qua [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). Cài đặt áp dụng cho mọi chuỗi trong nhóm đó, không chỉ chuỗi được dùng để truy cập. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) trả về khoảng trống độ sâu và phản ánh cài đặt của nhóm cha.

Cài đặt này ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ đường và khu vực 3D. Giao diện phụ thuộc vào việc các chuỗi được sắp xếp theo độ sâu, nhóm lại, hay chồng lên nhau. Để so sánh rõ ràng khoảng cách giữa các chuỗi riêng biệt, sử dụng `ChartType::Column3D` từ lớp [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu quả |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Khoảng cách giữa các chuỗi dọc theo trục độ sâu, tính bằng phần trăm của độ rộng dấu đánh dấu. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Khoảng cách giữa các cụm cột hoặc thanh liền kề, tính bằng phần trăm của độ rộng cột hoặc thanh. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Độ sâu tổng thể của biểu đồ, tính bằng phần trăm của chiều rộng biểu đồ. |

Ví dụ tự chứa sau đây sử dụng dữ liệu biểu đồ mặc định, bao gồm ba chuỗi và bốn danh mục. Nó lưu hai bản trình chiếu với dữ liệu, góc quay, độ rộng khoảng trống và độ sâu biểu đồ giống nhau; chỉ độ sâu khoảng trống thay đổi.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Các hình ảnh sau minh họa cùng một cài đặt độ sâu khoảng trống trong ví dụ .NET tương đương và đã được xuất bằng Microsoft PowerPoint.

| Độ sâu khoảng trống: 0% | Độ sâu khoảng trống: 500% |
| --- | --- |
| ![Biểu đồ cột 3D không có khoảng trống giữa các chuỗi dọc theo trục độ sâu](gap_depth_0.png) | ![Biểu đồ cột 3D có khoảng trống 500% giữa các chuỗi dọc theo trục độ sâu](gap_depth_500.png) |

## **Thay đổi kiểu chuỗi 3D và hình dạng thanh**

Trong một biểu đồ hình trụ nhóm, chuỗi đầu tiên bắt đầu với hình dạng thanh hình trụ. Ví dụ in ra các giá trị nguyên trả về bởi [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) và [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) trước và sau mỗi thay đổi. Bảng cung cấp các tên hằng tương ứng.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Thay đổi cho chuỗi đầu tiên | Kiểu chuỗi | Hình dạng thanh |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

Đặt hình dạng thành `Box` cũng thay đổi kiểu chuỗi thành `ClusteredColumn3D`. Nếu mã của bạn phân nhánh dựa trên kiểu chuỗi, hãy gọi [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) sau khi thay đổi hình dạng. Giá trị được lưu trước khi gán vẫn sẽ chọn nhánh `ClusteredCone`.

![So sánh PowerPoint hiển thị chuỗi đầu tiên là hình trụ, hình nón và cột chữ nhật từ trái sang phải](series-shapes.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được mở ra qua lớp [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Để có danh sách chính xác và cập nhật, kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) trong tài liệu API của phiên bản đã cài đặt.

**Tôi có thể lấy hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ thành hình ảnh bằng [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) hoặc [render the entire slide](/slides/vi/php-java/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần bản xem trước dạng raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc xây dựng và hiển thị các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp của hình ảnh. Để đạt kết quả tốt nhất, giữ hiệu ứng 3D ở mức tối thiểu, tránh sử dụng kết cấu nặng trên các bề mặt và vùng vẽ, hạn chế số điểm dữ liệu mỗi chuỗi khi có thể, và xuất ra kích thước phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in.