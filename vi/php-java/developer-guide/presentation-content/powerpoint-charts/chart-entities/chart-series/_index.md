---
title: Quản lý Dữ liệu Series Biểu đồ trong Bản thuyết trình bằng PHP
linktitle: Series Dữ liệu
type: docs
url: /vi/php-java/chart-series/
keywords:
- series biểu đồ
- giao nhau của series
- màu series
- tên series
- điểm dữ liệu
- ô workbook
- khoảng cách series
- giá trị âm
- PowerPoint
- bản thuyết trình
- PHP
- Aspose.Slides
description: "Tìm hiểu cách quản lý series biểu đồ, điểm dữ liệu, ô workbook, định dạng, giao nhau, độ rộng khoảng cách và giá trị âm trong bản thuyết trình bằng PHP."
---
## **Tổng quan**

Biểu đồ có thể lưu các giá trị đã vẽ vào các ô của workbook hoặc trực tiếp dưới dạng các literal số. Một [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) đại diện cho một điểm trong tập hợp đó. Các đối tượng [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) cung cấp các nhãn hoặc giá trị nhóm được các chuỗi dùng chung. Trong các biểu đồ được tạo với dữ liệu mặc định, tên chuỗi, danh mục và giá trị điểm sử dụng các đối tượng [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) từ workbook của biểu đồ.

Đối với một biểu đồ danh mục điển hình, workbook mặc định sử dụng hàng 0 cho tên chuỗi, cột 0 cho tên danh mục và các ô còn lại cho giá trị chuỗi. Các chỉ mục worksheet, hàng và cột được truyền cho [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) là dựa trên chỉ số 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản thuyết trình đã tải, hãy kiểm tra các ô được chuỗi, danh mục và điểm dữ liệu tham chiếu trước khi thay đổi giá trị trong workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:
- Cài đặt mức chuỗi, chẳng hạn như [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), cung cấp giao diện mặc định cho tất cả các điểm trong một chuỗi.
- Cài đặt mức điểm dữ liệu, chẳng hạn như [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), ghi đè giao diện chuỗi cho một điểm.
- Cài đặt nhóm áp dụng cho các chuỗi tương thích thuộc cùng [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/), truy cập nhóm qua [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) khi bạn cần đặt các tùy chọn như overlap hoặc gap width.

Khi không có màu nền điểm hoặc chuỗi nào được đặt rõ ràng, kiểu biểu đồ và chủ đề sẽ quyết định giao diện tự động. Khi cả định dạng chuỗi và điểm đều có, định dạng điểm sẽ được ưu tiên cho điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt Giá Trị Chuỗi Bằng Literal Số**

Sử dụng các literal số khi giá trị chuỗi đến từ dữ liệu hoặc tính toán trong ứng dụng và không cần tham chiếu tới ô worksheet. Gọi [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) với [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) trước khi gán kết quả của [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) cho mỗi điểm thông qua [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Cài đặt bộ sưu tập kiểm soát loại nguồn của tất cả các giá trị điểm trong chuỗi đó. Phương thức [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) của mỗi giá trị điểm trả về loại đã chọn; thay đổi nó qua cài đặt bộ sưu tập. Khi dùng `Worksheet`, sử dụng [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) để truy cập ô được tham chiếu. Khi dùng `DoubleLiterals`, sử dụng [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) hoặc `setAsLiteralDouble` để đọc hoặc ghi số trực tiếp.

Ví dụ sau tạo một biểu đồ cột với các chuỗi và danh mục mặc định, sau đó gán các giá trị tính toán 10, 20, … cho các điểm hiện có của chuỗi đầu tiên. Nó lưu bản thuyết trình, mở lại và in các giá trị đã lưu.

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Loại nguồn giá trị điểm tách rời khỏi [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), xác định cấu hình workbook nội bộ hoặc ngoại bộ của biểu đồ. Sử dụng các literal số không tự động loại bỏ workbook nhúng. Trong ví dụ này, workbook vẫn còn khả dụng cho nhãn danh mục, tên chuỗi và các chuỗi khác. Xem [Chart Workbook](/slides/vi/php-java/chart-workbook/) để quản lý workbook.

Đối với biểu đồ scatter và bubble, sử dụng [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) và [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) để chọn nguồn cho [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) và [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/). Biểu đồ bubble cũng sử dụng [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) cho [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/). Đặt mỗi nguồn áp dụng thành `DoubleLiterals` trước khi gán số qua phương thức `setAsLiteralDouble` của giá trị đó.

## **Đặt Độ Giao Nhau Chuỗi Biểu Đồ**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) báo cáo mức độ giao nhau của các cột hoặc thanh trong biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm chuỗi cha. Sử dụng [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) để cập nhật mọi chuỗi tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các cột hoặc thanh nhóm; nó không ảnh hưởng đến các nhóm chuỗi không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt độ giao nhau cho nhóm chứa chuỗi đầu tiên:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Biểu đồ mới chứa các series mẫu, các danh mục và các giá trị.
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

![The series overlap](series_overlap.png)

## **Thay Đổi Màu Nền Chuỗi**

Sử dụng [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) để đặt màu nền mặc định cho toàn bộ chuỗi. Nếu một điểm đã có màu nền rõ ràng, cài đặt [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) của nó sẽ ghi đè màu nền chuỗi cho điểm đó.

Ví dụ sau áp dụng màu nền xanh đậm trên chuỗi đầu tiên:

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

![The color of the series](series_color.png)

## **Thay Đổi Tên Chuỗi**

Tên chuỗi được lưu trong workbook dữ liệu biểu đồ và thường hiển thị trong chú giải. Trong workbook mặc định được tạo cho biểu đồ cột nhóm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của chuỗi đầu tiên. Các biến được đặt tên trong ví dụ sau làm rõ cấu trúc này:

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

Bạn cũng có thể cập nhật ô đã được [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/) tham chiếu. Cách này tránh việc giả định một hàng và cột cụ thể trong biểu đồ hiện có:

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

![The series name](series_name.png)

### **Tạo Chuỗi Với Tên Từ Nhiều Ô**

Tên chuỗi tổng hợp hữu ích khi tên sản phẩm và giai đoạn báo cáo được lưu trong các ô workbook riêng biệt. Ví dụ, bạn có thể kết hợp `Product A` ở B1 và `2026` ở C1 thành một tên chuỗi duy nhất trong khi vẫn giữ cả hai phần liên kết tới ô nguồn.

Sử dụng [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) để lấy phạm vi tên, sau đó truyền bộ sưu tập đó cho [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/). Tham số `skipHiddenCells` điều khiển việc có bao gồm các ô ẩn hay không: `true` loại bỏ chúng, `false` bao gồm chúng. Ví dụ này sử dụng `false` để bao gồm mọi ô trong phạm vi tên.

Ví dụ sau tạo một bản thuyết trình với một chuỗi và hai điểm dữ liệu. Các ô B1:C1 cung cấp chỉ tên chuỗi; A2:A3 cung cấp nhãn danh mục, và B2:B3 cung cấp các giá trị số.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Hai ô này cung cấp tên series.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Các ô riêng biệt cung cấp các danh mục và các điểm dữ liệu số.
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tên chuỗi kết quả là `Product A 2026`, với dấu cách giữa hai giá trị ô. Chú giải hiển thị điều này như một mục duy nhất cho cả hai cột. Hình ảnh dưới đây minh họa kết quả:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Lấy Màu Nền Tự Động Của Chuỗi**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) trả về màu được tính dựa trên chỉ số chuỗi và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền chuỗi không được xác định rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu nền mới.

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

Kết quả ví dụ cho kiểu biểu đồ mặc định:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Màu chính xác phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt Màu Nền Đảo Ngược Cho Chuỗi Biểu Đồ**

Đối với các chuỗi thanh, cột và bubble, [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) có thể hiển thị các giá trị âm với màu nền khác. Đặt màu nền chuỗi thường thành đặc, bật chế độ đảo, và gán màu giá trị âm qua [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Các số âm không thay đổi trong workbook; chỉ màu hiển thị của chúng thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một chuỗi. Hàng 0 của worksheet chứa tên chuỗi, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Bạn có thể bật đảo cho một điểm thông qua [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Trong ví dụ sau, đảo được tắt cho chuỗi và chỉ bật cho điểm đã chọn. Điểm này cũng được gán giá trị âm để hiệu ứng hiển thị:

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

Để làm một điểm trống mà không xóa các điểm khác, đặt ô workbook của nó thành `null`. Đối với biểu đồ cột, giá trị được vẽ có sẵn qua [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/). Điểm dữ liệu vẫn ở cùng vị trí danh mục, nhưng biểu đồ sẽ coi giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

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

Biểu đồ scatter sử dụng các ô X và Y riêng biệt, và biểu đồ bubble cũng sử dụng một ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) khi bạn muốn giữ lại các điểm khác, vì phương thức này sẽ xóa mọi điểm dữ liệu trong bộ sưu tập.

## **Kiểm Soát Hiển Thị Các Ô Trống**

Các ô ẩn chứa giá trị là một trường hợp riêng so với các ô trống. Để bao gồm hoặc loại trừ dữ liệu từ các hàng và cột worksheet ẩn, xem [Include Data from Hidden Rows and Columns](/slides/vi/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô workbook trống đại diện cho dữ liệu bị thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Gọi [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) với `null` để làm ô trở nên trống. Số 0 vẫn là 0 bất kể cài đặt ô trống.

Sử dụng [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách các ô trống được vẽ, mà không lấp đầy ô workbook trống bằng số 0 hay giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một chuỗi, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với mỗi chế độ. Không cần tệp đầu vào. [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho giá trị; hàng 0 chứa tên chuỗi. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

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

    // Để Ngày 3 thực sự trống, đồng thời giữ lại danh mục và điểm dữ liệu của nó.
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

Mỗi tệp đầu ra lưu chế độ được chỉ định trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản thuyết trình một lần thay vì lặp lại qua các chế độ.

So sánh dưới đây hiển thị cùng một dữ liệu trong ba tệp. Ngày 3 là trống trong workbook trong mọi trường hợp:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Biểu đồ đường khiến ba chế độ dễ so sánh. Biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `Span` không thể tạo đoạn nối như trên; một cột thiếu và một cột có chiều cao 0 cũng có thể trông giống nhau. Tương tự, biểu đồ scatter chỉ có các dấu marker không có đường nối. Đừng mong đợi ba kết quả riêng biệt cho mọi loại biểu đồ; hãy kiểm tra đầu ra cho loại bạn đang dùng.

## **Đặt Độ Rộng Khoảng Cách Chuỗi**

Khoảng cách (gap width) là không gian giữa các cụm thanh hoặc cột liền kề, được biểu thị dưới dạng phần trăm của độ rộng thanh hoặc cột. Giống như overlap, nó thuộc về nhóm chuỗi cha chứ không phải một chuỗi riêng. Gọi [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) một lần cho nhóm. Giá trị lớn hơn tạo nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi khoảng cách và chỉ lưu bản thuyết trình cuối cùng:

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

![The gap width](gap_width.png)

## **FAQ**

**Các loại biểu đồ nào hỗ trợ series dữ liệu?**

Tất cả các loại biểu đồ được biểu diễn bởi enum [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng các series của chúng không phải luôn có cùng cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ scatter sử dụng giá trị X và Y, và biểu đồ bubble thêm kích thước bubble. Hãy dùng phương thức tạo điểm dữ liệu phù hợp với loại series. Các tùy chọn như overlap và gap width chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Nhóm series biểu đồ là gì?**

Một [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) chứa các series tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một series không nhất thiết thay đổi mọi series trong biểu đồ.

**Biểu đồ mới tạo có chứa dữ liệu mặc định không?**

Có. Mặc định, [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) tạo các series, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô đó hoặc xóa cả bộ sưu tập series và danh mục trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô workbook như thế nào?**

Tên series, nhãn danh mục và giá trị điểm dữ liệu tham chiếu tới các ô trong một [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ cho các hàng danh mục và các hàng giá trị series đồng bộ để mỗi điểm được vẽ dưới đúng danh mục.

**Làm thế nào để xóa một điểm thay vì toàn bộ series?**

Đặt ô giá trị tương ứng thành `null` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ sử dụng [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) khi bạn muốn xóa mọi điểm trong series đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi series sao cho giá trị của chúng vẫn đồng bộ với bộ sưu tập danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và giá trị được cấu hình qua [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/). Các biểu đồ hỗ trợ có thể hiển thị các điểm trống dưới dạng khoảng trống, giá trị zero, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản thuyết trình của bạn. Xem [Control the Display of Empty Cells](#control-the-display-of-empty-cells) để có ví dụ hoàn chỉnh và so sánh hình ảnh.

**Giá trị âm được định dạng như thế nào?**

Đối với các series thanh, cột và bubble được hỗ trợ, gọi [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) và đặt màu được trả về bởi [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Những phương thức này ảnh hưởng tới định dạng, không phải giá trị số được lưu.

**Định dạng nào được ưu tiên khi cả series và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng sẽ được ưu tiên cho điểm đó. Các điểm khác tiếp tục sử dụng định dạng series rõ ràng hoặc, khi định dạng series không được xác định, kiểu và chủ đề biểu đồ tự động. Các cài đặt nhóm như overlap và gap width kiểm soát bố cục và không phải là ghi đè định dạng mức điểm.

**Có giới hạn số lượng series mà một biểu đồ có thể chứa không?**

Aspose.Slides không đặt giới hạn cố định cho số lượng series. Trong thực tế, các ràng buộc của tệp bản thuyết trình, bộ nhớ khả dụng, thời gian render và khả năng đọc của biểu đồ quyết định giới hạn thực tế.

**Tôi nên thay đổi gì khi các cột quá gần nhau hoặc quá xa nhau?**

Gọi [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) trên nhóm series cha phù hợp. Tăng giá trị để mở rộng khoảng cách giữa các cụm, hoặc giảm giá trị để các cụm lại gần nhau hơn.