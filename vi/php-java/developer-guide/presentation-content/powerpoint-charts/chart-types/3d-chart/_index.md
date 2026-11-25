---
title: Tùy chỉnh biểu đồ 3D trong bản trình bày bằng PHP
linktitle: Biểu đồ 3D
type: docs
url: /vi/php-java/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tạo biểu đồ 3D trong bản trình bày PowerPoint bằng Aspose.Slides cho PHP qua Java. Điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu biểu đồ và khoảng cách giữa các series bằng các ví dụ PHP."
---
## **Tổng quan**

Aspose.Slides for PHP via Java cho phép bạn tùy chỉnh chế độ xem của biểu đồ 3D thông qua phương thức [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D). Bài viết này minh họa cách điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu, các trục góc phải và khoảng cách giữa các series, sau đó lưu bản trình bày ở định dạng PPTX.

## **Đặt góc quay và độ sâu cho biểu đồ 3D**

Ví dụ dưới tạo một [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) và sử dụng [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) để thêm một biểu đồ cột 3D chồng lên slide đầu tiên. Nó thay thế các series và categories mặc định bằng hai series, mỗi series chứa ba giá trị. Chỉ số worksheet `0` xác định worksheet dữ liệu đầu tiên của biểu đồ; hàng `0` chứa tên series, và cột `0` chứa nhãn category.

Các phương thức [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) và [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) đặt góc quay của biểu đồ lần lượt là 40 và 270 độ. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) đặt độ sâu bằng 150 % chiều rộng, trong khi [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) bật chế độ trục góc phải thay vì phối cảnh. Bản trình bày kết quả chứa biểu đồ đã được thiết lập các thiết lập hiển thị 3D này.

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

## **Áp dụng màu nền ảnh cho bề mặt biểu đồ 3D**

Bạn có thể tô đầy [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) và [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) của biểu đồ 3D một cách độc lập. Đặt [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) của bề mặt thành `Picture` và chỉ định một hình ảnh. Đặt cả [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) và [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) của bề mặt thành `Stretch` để một bản sao của hình ảnh phủ toàn bộ bề mặt.

Lưu tệp [arrow.png](arrow.png) cùng thư mục với script PHP. Ví dụ xoay biểu đồ và tăng giá trị tối đa trên trục dọc để bề mặt floor hiển thị giữa các cột. Sau đó sao chép slide hai lần và áp dụng mũi tên lên bề mặt khác nhau trên mỗi slide. Ba biểu đồ đều giữ cùng dữ liệu, góc nhìn và nền.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint hiển thị ba slide như sau.

| Mặt bên | Mặt sau | Mặt đáy |
| --- | --- | --- |
| ![Mũi tên chỉ vào biểu đồ dọc theo mặt bên](side-wall.png) | ![Mũi tên chỉ sang phải trên mặt sau](back-wall.png) | ![Mũi tên chỉ sang phải trên mặt đáy giữa các cột](floor.png) |

## **Điều chỉnh tỷ lệ chiều cao của biểu đồ 3D**

Sử dụng [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm của chiều rộng. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ dưới tạo một biểu đồ [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) với dữ liệu mặc định: ba series và bốn categories. Nó lưu ba bản trình bày với tỷ lệ chiều cao lần lượt là 50 %, 100 % và 200 %. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn cố định. Dữ liệu, góc quay, độ sâu, khoảng cách series và định dạng đều giống nhau trong cả ba tệp; chỉ phần tỷ lệ chiều cao thay đổi.

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

Các hình ảnh dưới minh hoạ cùng một thiết lập chiều cao trong ví dụ .NET tương đương và được xuất bằng Microsoft PowerPoint. Phần trăm thấp hơn tạo cảnh phẳng hơn, trong khi phần trăm cao hơn tạo cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng cách tick trục và vị trí nhãn để phù hợp với cảnh.

| Chiều cao: 50 % | Chiều cao: 100 % | Chiều cao: 200 % |
| --- | --- | --- |
| ![Biểu đồ cột 3D với chiều cao bằng 50 % chiều rộng](height_percent_50.png) | ![Biểu đồ cột 3D với chiều cao bằng 100 % chiều rộng](height_percent_100.png) | ![Biểu đồ cột 3D với chiều cao bằng 200 % chiều rộng](height_percent_200.png) |

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu quả |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Chiều cao của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng điểm. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Độ sâu của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Khoảng cách giữa các series dọc theo trục sâu, dưới dạng phần trăm của độ rộng marker. |

Cài đặt chiều cao ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ đường, khu vực, tròn và bề mặt 3D. So sánh ở trên sử dụng kiểu `Column3D` đã được xác minh. Cài đặt này không thay đổi diện mạo của biểu đồ `ClusteredColumn` 2D hoặc biểu đồ `BubbleWith3D`; những tên này là thành viên của lớp [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Đối với các cài đặt diện mạo biểu đồ khác, xem mục [Chart Formatting](/slides/vi/php-java/chart-formatting/).

## **Điều chỉnh khoảng cách giữa các series**

Sử dụng [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) để kiểm soát khoảng cách giữa các series dữ liệu dọc theo trục sâu của biểu đồ 3D, biểu thị dưới dạng phần trăm của độ rộng marker. Giá trị cho phép từ **0 đến 500**, bao gồm: `0` loại bỏ khoảng cách, trong khi giá trị lớn hơn làm tăng khoảng cách. Với độ sâu biểu đồ cố định, tăng khoảng cách khiến các marker mảnh hơn dọc theo trục sâu.

Truy cập group thông qua [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). Cài đặt này áp dụng cho mọi series trong group đó, không chỉ series được dùng để truy cập. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) trả về khoảng cách sâu và phản ánh cài đặt của group cha.

Cài đặt này ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ đường và khu vực 3D. Diện mạo phụ thuộc vào việc các series được sắp xếp theo chiều sâu, thành cụm hay chồng. Để so sánh rõ ràng khoảng cách giữa các series riêng biệt, sử dụng `ChartType::Column3D` từ lớp [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu quả |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Khoảng cách giữa các series dọc theo trục sâu, dưới dạng phần trăm của độ rộng marker. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Khoảng cách giữa các cụm thanh hoặc cột kề nhau, dưới dạng phần trăm của độ rộng thanh hoặc cột. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Độ sâu tổng thể của biểu đồ, dưới dạng phần trăm của chiều rộng biểu đồ. |

Ví dụ tự chứa dưới đây sử dụng dữ liệu biểu đồ mặc định, gồm ba series và bốn categories. Nó lưu hai bản trình bày với dữ liệu, góc quay, độ rộng khoảng cách và độ sâu biểu đồ giống nhau; chỉ độ sâu khoảng cách thay đổi.

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

Các hình ảnh dưới minh hoạ cùng một cài đặt độ sâu khoảng cách trong ví dụ .NET tương đương và được xuất bằng Microsoft PowerPoint.

| Độ sâu khoảng cách: 0 % | Độ sâu khoảng cách: 500 % |
| --- | --- |
| ![Biểu đồ cột 3D không có khoảng cách giữa các series dọc theo trục sâu](gap_depth_0.png) | ![Biểu đồ cột 3D có khoảng cách 500 % giữa các series dọc theo trục sâu](gap_depth_500.png) |

## **Thay đổi loại series 3D và hình dạng thanh**

Trong biểu đồ hình trụ nhóm, series đầu tiên bắt đầu với hình dạng thanh trụ. Ví dụ in ra các giá trị nguyên trả về bởi [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) và [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) trước và sau mỗi thay đổi. Bảng dưới cung cấp tên hằng tương ứng.

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

| Thay đổi cho series đầu tiên | Loại series | Hình dạng thanh |
| --- | --- | --- |
| Tạo biểu đồ | `ClusteredCylinder` | `Cylinder` |
| Đặt loại series thành `ClusteredCone` | `ClusteredCone` | `Cone` |
| Đặt hình dạng thanh thành `Box` | `ClusteredColumn3D` | `Box` |

Việc đặt hình dạng thành `Box` cũng thay đổi loại series thành `ClusteredColumn3D`. Nếu mã của bạn phân nhánh dựa trên loại series, hãy gọi [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) sau khi thay đổi hình dạng. Giá trị được lưu trong bộ nhớ đệm trước khi gán vẫn sẽ chọn nhánh `ClusteredCone`.

![So sánh PowerPoint hiển thị series đầu tiên dưới dạng trụ, nón và cột chữ nhật từ trái sang phải](series-shapes.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100 % Stacked Column 3D, cùng các loại 3D liên quan được khai báo trong lớp [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Để có danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) trong tài liệu API của phiên bản bạn đang dùng.

**Tôi có thể lấy hình ảnh raster của biểu đồ 3D để dùng trong báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ thành hình ảnh bằng [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) hoặc [render toàn bộ slide](/slides/vi/php-java/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi cần bản xem trước raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào quy mô dữ liệu và độ phức tạp trực quan. Để đạt kết quả tốt nhất, hãy giảm thiểu hiệu ứng 3D, tránh sử dụng kết cấu nặng trên các bức tường và khu vực vẽ, hạn chế số điểm dữ liệu mỗi series khi có thể, và render với độ phân giải và kích thước phù hợp với mục tiêu hiển thị hoặc in.