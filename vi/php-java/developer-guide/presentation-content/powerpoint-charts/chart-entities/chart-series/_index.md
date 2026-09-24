---
title: Quản lý chuỗi dữ liệu biểu đồ trong bản trình chiếu bằng PHP
linktitle: Chuỗi dữ liệu
type: docs
url: /vi/php-java/chart-series/
keywords:
- chuỗi biểu đồ
- độ chồng lấn chuỗi
- màu chuỗi
- tên chuỗi
- điểm dữ liệu
- ô sổ làm việc
- khoảng trống chuỗi
- giá trị âm
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách quản lý chuỗi biểu đồ, điểm dữ liệu, ô sổ làm việc, định dạng, độ chồng lấn, độ rộng khoảng trống và giá trị âm trong bản trình chiếu bằng PHP."
---
## **Tổng quan**

Một biểu đồ lưu trữ dữ liệu đã vẽ của nó trong một sổ làm việc dữ liệu biểu đồ. Một [ChartSeries](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [ChartDataPoint](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapoint/) trong chuỗi tham chiếu tới một hoặc nhiều ô trong sổ làm việc. Các đối tượng [ChartCategory](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các chuỗi. Do đó, tên chuỗi, các danh mục và giá trị điểm được kết nối với các đối tượng [ChartDataCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/), thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ danh mục tiêu chuẩn, sổ làm việc mặc định sử dụng hàng 0 cho tên chuỗi, cột 0 cho tên danh mục và các ô còn lại cho giá trị chuỗi. Các chỉ số worksheet, row và column được truyền vào [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/#getCell) là dựa trên chỉ số 0. Bố cục này hữu ích khi bạn tạo một biểu đồ với dữ liệu mặc định, nhưng đừng cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình chiếu đã tải, hãy kiểm tra các ô được tham chiếu bởi chuỗi, danh mục và điểm dữ liệu trước khi thay đổi giá trị trong sổ làm việc.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt cấp chuỗi, chẳng hạn như [ChartSeries.getFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/#getFormat), cung cấp giao diện mặc định cho tất cả các điểm trong một chuỗi.
- Cài đặt điểm dữ liệu, chẳng hạn như [ChartDataPoint.getFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapoint/#getFormat), ghi đè giao diện của chuỗi cho một điểm.
- Cài đặt nhóm áp dụng cho các chuỗi tương thích thuộc cùng một [ChartSeriesGroup](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseriesgroup/). Truy cập nhóm qua [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/#getParentSeriesGroup) khi bạn cần đặt các tùy chọn như độ chồng lấn hoặc độ rộng khoảng trống.

Khi không có màu nền điểm hoặc chuỗi nào được đặt một cách rõ ràng, kiểu biểu đồ và chủ đề sẽ quyết định giao diện tự động. Khi cả định dạng chuỗi và định dạng điểm đều tồn tại, định dạng điểm sẽ có ưu tiên cho điểm đó.

![chuỗi biểu đồ PowerPoint](chart-series-powerpoint.png)

## **Đặt Độ Chồng Lấn Của Chuỗi Biểu Đồ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/#getOverlap) báo cáo mức độ các thanh hoặc cột chồng lên nhau trong một biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm chuỗi cha. Sử dụng [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseriesgroup/#setOverlap) để cập nhật mọi chuỗi tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng đến các nhóm chuỗi không liên quan trong một biểu đồ kết hợp.

Ví dụ sau đặt độ chồng lấn cho nhóm chứa chuỗi đầu tiên:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Biểu đồ mới chứa các chuỗi mẫu, danh mục và giá trị.
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Kết quả:

![Độ chồng lấn chuỗi](series_overlap.png)

## **Thay Đổi Màu Nền Chuỗi**

Sử dụng [ChartSeries.getFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/#getFormat) để đặt màu nền mặc định cho toàn bộ chuỗi. Nếu một điểm đã có màu nền rõ ràng, cài đặt [ChartDataPoint.getFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapoint/#getFormat) của nó sẽ ghi đè màu nền chuỗi cho điểm đó.

Ví dụ sau áp dụng màu nền xanh đậm cho chuỗi đầu tiên:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Kết quả:

![Màu của chuỗi](series_color.png)

## **Thay Đổi Tên Chuỗi**

Tên chuỗi được lưu trong sổ làm việc dữ liệu biểu đồ và thường được hiển thị trong chú giải. Trong sổ làm việc mặc định được tạo cho biểu đồ cột nhóm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của chuỗi đầu tiên. Các biến được đặt tên trong ví dụ sau làm rõ cấu trúc này:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Bạn cũng có thể cập nhật ô đã được tham chiếu bởi [ChartSeries.getName](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/#getName). Cách này tránh việc giả định một hàng và cột cụ thể trong một biểu đồ đã tồn tại:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Kết quả:

![Tên chuỗi](series_name.png)

## **Lấy Màu Nền Tự Động Của Chuỗi**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) trả về màu được tính dựa trên chỉ số chuỗi và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền chuỗi chưa được xác định rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu nền mới.

Ví dụ sau in màu tự động của mỗi chuỗi mặc định:

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Kết quả mẫu cho kiểu biểu đồ mặc định:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Các màu chính xác phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt Màu Nền Đảo Ngược Cho Chuỗi Biểu Đồ**

Đối với các chuỗi thanh, cột và bóng, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/#setInvertIfNegative) có thể hiển thị giá trị âm bằng một màu nền khác. Đặt màu nền chuỗi thông thường thành màu đặc, bật tính năng đảo ngược và chỉ định màu giá trị âm thông qua [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Các số âm vẫn không thay đổi trong sổ làm việc; chỉ màu hiển thị của chúng thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một chuỗi. Hàng worksheet 0 chứa tên chuỗi, cột 0 chứa tên danh mục và cột 1 chứa các giá trị:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Kết quả:

![Màu nền đặc đảo ngược](inverted_solid_fill_color.png)

Bạn có thể bật đảo ngược cho một điểm thông qua [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Trong ví dụ sau, đảo ngược bị tắt cho chuỗi và chỉ bật cho điểm được chọn. Điểm này cũng được gán giá trị âm để hiệu ứng hiển thị:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Xóa Giá Trị Điểm Dữ Liệu Cụ Thể**

Để làm cho một điểm trống mà không xóa các điểm khác, đặt ô trong sổ làm việc hỗ trợ nó thành `null`. Đối với biểu đồ cột, giá trị đã vẽ có thể được truy cập qua [ChartDataPoint.getValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapoint/#getValue). Điểm dữ liệu vẫn giữ vị trí danh mục, nhưng biểu đồ sẽ xem giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

Ví dụ sau chỉ xóa điểm thứ hai trong chuỗi đầu tiên:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Biểu đồ scatter sử dụng các ô X và Y riêng biệt, và biểu đồ bubble còn sử dụng ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Đừng gọi [ChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapointcollection/#clear) khi bạn muốn giữ các điểm còn lại, vì phương thức đó sẽ xóa mọi điểm dữ liệu trong bộ sưu tập.

## **Kiểm Soát Hiển Thị Ô Trống**

Một ô trống trong sổ làm việc biểu thị dữ liệu thiếu; một ô chứa `0` biểu thị một giá trị số đã biết. Gọi [ChartDataCell::setValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setValue) với `null` để làm ô trở nên trống. Số không vẫn là số không bất kể cài đặt ô trống như thế nào.

Sử dụng [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/#setDisplayBlanksAs) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách các ô trống được vẽ, mà không điền ô trống trong sổ làm việc bằng zero hay một giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một chuỗi, xóa giá trị cho Ngày 3 và lưu cùng một biểu đồ với mỗi chế độ. Không cần tệp đầu vào. [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục và cột 1 cho giá trị; hàng 0 giữ tên chuỗi. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Để Ngày 3 thực sự trống, trong khi vẫn giữ lại danh mục và điểm dữ liệu của nó.
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Mỗi tệp đầu ra lưu chế độ được gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản trình chiếu một lần thay vì lặp qua các chế độ.

So sánh dưới đây cho thấy cùng một dữ liệu trong ba tệp. Ngày 3 là trống trong sổ làm việc ở mọi trường hợp:

![Biểu đồ đường với dữ liệu giống nhau: Gap ngắt đoạn tại Ngày 3, Zero hạ đường xuống không, và Span nối Ngày 2 tới Ngày 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Một biểu đồ đường làm cho ba chế độ dễ so sánh. Các biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `Span` không thể tạo đoạn nối như trên; một cột thiếu và một cột có chiều cao zero cũng có thể trông giống nhau. Tương tự, một biểu đồ scatter chỉ có dấu hiệu sẽ không có đường nối. Đừng kỳ vọng ba kết quả riêng biệt cho mọi loại biểu đồ; hãy kiểm tra đầu ra cho loại bạn đang sử dụng.

## **Đặt Độ Rộng Khoảng Trống Của Chuỗi**

Độ rộng khoảng trống là khoảng cách giữa các cụm thanh hoặc cột liền kề, biểu thị dưới dạng phần trăm của độ rộng thanh hoặc cột. Giống như độ chồng lấn, nó thuộc về nhóm chuỗi cha chứ không phải một chuỗi riêng lẻ. Gọi [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseriesgroup/#setGapWidth) một lần cho nhóm. Giá trị lớn hơn tạo ra khoảng cách lớn hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khoảng trống và lưu chỉ bản trình chiếu cuối cùng:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Kết quả:

![Độ rộng khoảng trống](gap_width.png)

## **FAQ**

**Các loại biểu đồ nào hỗ trợ chuỗi dữ liệu?**

Tất cả các loại biểu đồ được đại diện bởi liệt kê [ChartType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng các chuỗi của chúng không có cùng cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ scatter sử dụng giá trị X và Y, và biểu đồ bubble còn thêm kích thước bubble. Sử dụng phương pháp tạo điểm dữ liệu phù hợp với loại chuỗi. Các tùy chọn như độ chồng lấn và độ rộng khoảng trống chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Nhóm chuỗi biểu đồ là gì?**

Một [ChartSeriesGroup](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseriesgroup/) chứa các chuỗi tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một chuỗi không nhất thiết làm thay đổi mọi chuỗi trong biểu đồ.

**Biểu đồ mới tạo có dữ liệu mặc định không?**

Có. Theo mặc định, [ShapeCollection.addChart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addChart) tạo ra các chuỗi mẫu, danh mục và giá trị. Bạn có thể chỉnh sửa các ô này hoặc xóa cả hai bộ sưu tập chuỗi và danh mục trước khi thêm một tập dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ mà không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô trong sổ làm việc như thế nào?**

Tên chuỗi, nhãn danh mục và giá trị điểm dữ liệu tham chiếu các ô trong một [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật thành phần biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và các hàng giá trị chuỗi căn chỉnh để mỗi điểm được vẽ dưới đúng danh mục dự định.

**Làm sao để xóa một điểm thay vì toàn bộ chuỗi?**

Đặt ô giá trị liên quan thành `null` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ sử dụng [ChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapointcollection/#clear) khi bạn muốn xóa tất cả các điểm trong chuỗi đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi chuỗi để giá trị của chúng vẫn căn chỉnh với bộ sưu tập danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và giá trị được cấu hình thông qua [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/#setDisplayBlanksAs). Các biểu đồ được hỗ trợ có thể hiển thị ô trống dưới dạng khoảng trống, giá trị zero, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình chiếu của bạn. Xem mục **Kiểm soát Hiển Thị Ô Trống** để biết ví dụ đầy đủ và so sánh trực quan.

**Các giá trị âm được định dạng như thế nào?**

Đối với các chuỗi thanh, cột và bubble được hỗ trợ, gọi [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/#setInvertIfNegative) và đặt màu trả về bởi [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Các phương thức này ảnh hưởng đến định dạng, không thay đổi giá trị số lưu trữ.

**Định dạng nào thắng khi cả chuỗi và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng có ưu tiên cho điểm đó. Các điểm khác vẫn sử dụng định dạng chuỗi rõ ràng hoặc, khi không có định dạng chuỗi, sử dụng kiểu và chủ đề biểu đồ tự động. Các cài đặt nhóm như độ chồng lấn và độ rộng khoảng trống kiểm soát bố cục và không phải là ghi đè định dạng ở mức điểm.

**Có giới hạn số chuỗi mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt một giới hạn cố định riêng cho số chuỗi. Trong thực tế, các hạn chế về kích thước tệp bản trình chiếu, bộ nhớ khả dụng, thời gian render và khả năng đọc của biểu đồ quyết định giới hạn thực tế.

**Nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Gọi [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseriesgroup/#setGapWidth) trên nhóm chuỗi cha phù hợp. Tăng giá trị để mở rộng khoảng cách giữa các cụm, hoặc giảm để đưa các cụm lại gần nhau hơn.