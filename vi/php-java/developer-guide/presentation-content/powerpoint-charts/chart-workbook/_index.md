---
title: Quản lý sổ làm việc biểu đồ trong bản trình chiếu bằng PHP
linktitle: Sổ làm việc biểu đồ
type: docs
weight: 70
url: /vi/php-java/chart-workbook/
keywords:
- sổ làm việc biểu đồ
- dữ liệu biểu đồ
- ô sổ làm việc
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- sổ làm việc bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục sổ làm việc
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Khám phá Aspose.Slides cho PHP qua Java: dễ dàng quản lý sổ làm việc biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua các luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập các bộ sưu tập bảng tính, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc khả dụng.

Đối với các ô sổ làm việc đại diện cho dữ liệu thiếu, xem [Kiểm soát việc hiển thị các ô trống](/slides/vi/php-java/chart-series/) để biết sự khác nhau giữa ô trống và số 0, và so sánh biểu đồ đường của các chế độ hiển thị khả dụng.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) để kiểm soát việc biểu đồ vẽ dữ liệu từ các hàng và cột bảng tính ẩn. Đặt `true` để chỉ vẽ các ô hiển thị, hoặc `false` để bao gồm cả ô hiển thị và ô ẩn. Cài đặt này chỉ kiểm soát việc vẽ biểu đồ; nó không ẩn hoặc hiện các hàng hoặc cột bảng tính.

[presentation mẫu](hidden-source-data.pptx) chứa một biểu đồ cột làm hình dạng đầu tiên trên slide đầu tiên. Bảng tính nhúng, `Sheet1`, chứa phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn có giá trị.

| Hàng bảng tính | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hàng ẩn) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Truy cập các ô nguồn qua [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) và đọc [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) để kiểm tra trạng thái ẩn của chúng. Phương thức này báo cáo trạng thái ẩn mà không thay đổi. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `false`, `true`, và `true` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại sổ làm việc nhúng bằng [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) và tải lại bằng [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Khi bao gồm tất cả các ô, cũng sử dụng [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) để khôi phục phạm vi đầy đủ, bao gồm danh mục tháng February ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục đã được lưu trong bộ nhớ đệm của mẫu này.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // Làm mới dữ liệu biểu đồ từ sổ làm việc được nhúng.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Khôi phục phạm vi nguồn đầy đủ, bao gồm các danh mục ẩn.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Ví dụ lưu hai phiên bản của bản trình chiếu: một chỉ có các giá trị Bán lẻ hiển thị (10 và 20), và một khác có tất cả sáu giá trị. Hình ảnh dưới minh họa hai chế độ vẽ. Hàng 3 và cột C vẫn ẩn trong cả hai sổ làm việc nhúng.

| Chỉ các ô hiển thị (`true`) | Tất cả các ô (`false`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho January và March.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho January, February và March.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với ô trống. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hoặc loại trừ dữ liệu nguồn ẩn. Xem [Kiểm soát việc hiển thị các ô trống](/slides/vi/php-java/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Lấy phạm vi dữ liệu của biểu đồ**

Trước khi cập nhật dữ liệu sổ làm việc trong một bản trình chiếu hiện có, kiểm tra các phạm vi nguồn để xác định ô bảng tính nào mỗi biểu đồ sử dụng. Phương thức [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) trả về phạm vi dữ liệu hiện tại dưới dạng công thức có định danh bảng tính, chẳng hạn `Sheet1!$A$1:$D$5`. Ở đây, `Sheet1` là tên bảng tính, `!` ngăn cách nó với phạm vi ô, và `$A$1:$D$5` chỉ các ô A1 đến D5, bao gồm. Dấu `$` chỉ ra tham chiếu tuyệt đối theo hàng và cột.

Phương thức đọc phạm vi hiện tại mà không thay đổi biểu đồ hay sổ làm việc. Nếu biểu đồ không sử dụng sổ làm việc làm nguồn dữ liệu, nó sẽ ném ngoại lệ. Để biết thêm, xem [Tham chiếu API ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Ví dụ này mở một bản trình chiếu và kiểm tra các hình dạng trên mỗi slide để tìm biểu đồ. Nó in ra tên và phạm vi nguồn của mỗi biểu đồ. Nếu một biểu đồ không dùng sổ làm việc, nó in thông báo và tiếp tục với biểu đồ tiếp theo.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Đọc và ghi dữ liệu biểu đồ từ sổ làm việc**

Aspose.Slides for PHP via Java cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) và [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) cho phép bạn đọc và ghi sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng một cách hoặc có cấu trúc tương tự nguồn.

Ví dụ này sử dụng một bản trình chiếu có biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Nó đọc sổ làm việc nhúng vào một mảng byte, xóa các series và category hiện có, và ghi lại cùng một sổ làm việc. Các thay đổi vẫn tồn tại trong bộ nhớ; ví dụ không lưu bản trình chiếu.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Xác thực bố cục biểu đồ sau khi sửa sổ làm việc**

Khi bạn thay thế sổ làm việc nhúng bằng một sổ làm việc đã sửa, biểu đồ vẫn giữ các bộ sưu tập series và category ban đầu. Sự không khớp này có thể làm cho [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) thất bại với lỗi chỉ mục ngoài phạm vi. Xóa các series và category hiện có trước khi ghi sổ làm việc đã cập nhật trở lại biểu đồ. Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Các chú thích đánh dấu nơi sẽ thực hiện chỉnh sửa sổ làm việc; ví dụ có thể chạy sẽ ghi lại sổ làm việc gốc và xác thực bố cục trong bộ nhớ.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // Sửa đổi các byte của workbook ở đây, ví dụ, sử dụng Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Xóa các bộ sưu tập sẽ loại bỏ các tham chiếu dữ liệu cũ trước khi sổ làm việc được ghi lại. Tái tạo bất kỳ mapping series và category cần thiết nào cho sổ làm việc đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt định dạng số tùy chỉnh cho các ô sổ làm việc**

Sử dụng [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) để kiểm soát cách các giá trị số hiển thị trong sổ làm việc nhúng của biểu đồ. Ví dụ, một báo cáo có thể cần tỷ lệ chuyển đổi hiển thị dưới dạng phần trăm với bốn chữ số thập phân và một hệ số hiển thị với năm chữ số thập phân. Giữ cả hai giá trị ở dạng số để chúng vẫn có thể dùng cho tính toán và vẽ biểu đồ.

Định dạng số thay đổi cách hiển thị, không thay đổi giá trị lưu trữ. Định dạng `0.0000%` hiển thị `0.125` thành `12.5000%`; nó không thay thế số lưu trữ bằng `12.5`. Tương tự, `0.00000` hiển thị `0.1234567` thành `0.12346` mà không làm tròn giá trị lưu trữ. Nếu định dạng tùy chỉnh là chuỗi rỗng (`""`), định dạng trả về bởi [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) sẽ được dùng thay thế.

Ví dụ sau tạo một biểu đồ cột và truy cập các ô của nó qua [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). Trên worksheet 0, B2 chứa tỷ lệ chuyển đổi và C2 chứa hệ số. Cả hai ô đều cung cấp giá trị cho biểu đồ. Ví dụ cũng bật nhãn giá trị liên kết với định dạng nguồn.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Định dạng ô sổ làm việc riêng biệt với các định dạng được đặt trực tiếp trên trục biểu đồ hoặc nhãn dữ liệu. Trong ví dụ này, mỗi nhãn hiển thị giá trị của ô nguồn vì [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) được đặt `true`, và tuân theo định dạng số nguồn vì [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) cũng `true`. Sau khi lưu và mở lại bản trình chiếu, các nhãn hiển thị `12.5000%` và `0.12346`, như dưới đây. Trục dọc sử dụng định dạng số riêng, được gán bằng [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) là `0.00`, với [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) đặt `false`.

Để định dạng một nhãn dữ liệu một cách độc lập, đặt cờ liên kết nguồn của nó thành `false` và gán định dạng bằng [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). Điều này không thay đổi định dạng của ô sổ làm việc. Ví dụ, một định dạng nhãn độc lập `0.00` sẽ hiển thị giá trị đầu tiên là `0.13`, trong khi B2 vẫn hiển thị `12.5000%`. Xem [Chart Data Labels](/slides/vi/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) để biết cách định dạng nhãn trực tiếp.

Hình ảnh dưới được tạo từ bản trình chiếu đã lưu sau khi mở lại:

![Biểu đồ cột với nhãn liên kết nguồn hiển thị 12.5000% và 0.12346 và trục số được định dạng độc lập.](custom-cell-formats.png)

## **Đặt một ô sổ làm việc làm nhãn dữ liệu biểu đồ**

Bạn có thể sử dụng văn bản từ các ô sổ làm việc làm nhãn dữ liệu biểu đồ.

Ví dụ này thêm một biểu đồ bong bóng với dữ liệu mặc định vào slide đầu tiên của một bản trình chiếu hiện có. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ ô, và lưu bản trình chiếu đã cập nhật.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Quản lý các worksheet**

Phương thức [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) cung cấp quyền truy cập vào các worksheet trong một sổ làm việc biểu đồ. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi worksheet ra console.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Chỉ định loại nguồn dữ liệu**

Giá trị điểm series cũng có thể được lưu trữ trực tiếp dưới dạng các literal số. Xem [Set Series Values Using Numeric Literals](/slides/vi/php-java/chart-series/#set-series-values-using-numeric-literals) để có ví dụ đầy đủ về việc lưu và đọc chúng. Loại nguồn của các giá trị điểm tách biệt với cấu hình sổ làm việc nội bộ hoặc bên ngoài của biểu đồ; việc sử dụng các literal số không tự động loại bỏ sổ làm việc nhúng.

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên dùng literal chuỗi; tên thứ hai dùng ô C1 trên worksheet 0. Định danh [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) chọn nguồn cho mỗi tên. Ví dụ lưu bản trình chiếu với các tên series đã cập nhật.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Phát hiện định dạng sổ làm việc nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ làm việc Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) cùng với định danh [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) để phát hiện các định dạng không hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các hình dạng trên slide đầu tiên của một bản trình chiếu hiện có, bỏ qua các hình không phải biểu đồ, và in thông báo chẩn đoán cho mỗi biểu đồ có sổ làm việc .xlsb nhúng.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // Đọc hoặc chỉnh sửa dữ liệu sổ làm việc biểu đồ hỗ trợ ở đây.
    }
} finally {
    $presentation->dispose();
}
```

## **Sổ làm việc bên ngoài**

Aspose.Slides hỗ trợ việc sử dụng sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo một sổ làm việc bên ngoài**

Sử dụng [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) và [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) để xuất sổ làm việc biểu đồ nhúng ra file và liên kết biểu đồ với sổ làm việc bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và xuất sổ làm việc của nó. Nó hoàn thành việc ghi file trước khi gán sổ làm việc bên ngoài làm nguồn dữ liệu biểu đồ, sau đó lưu bản trình chiếu đã liên kết.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Đặt một sổ làm việc bên ngoài**

Bằng cách sử dụng phương thức [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), bạn có thể gán một sổ làm việc bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sổ làm việc bên ngoài (nếu sổ làm việc đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ làm việc lưu trữ tại các vị trí từ xa hoặc tài nguyên, bạn vẫn có thể dùng các sổ làm việc đó làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho sổ làm việc bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Ví dụ này sử dụng một sổ làm việc bên ngoài có worksheet tên `Sheet1` chứa một tên series trong B1, các tên danh mục trong A2:A4, và các giá trị số trong B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết sổ làm việc, và sử dụng [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu bản trình chiếu với biểu đồ đã liên kết.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tham số `updateChartData` của [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) điều khiển việc có tải sổ làm việc hay không.

* Khi `updateChartData` là `false`, chỉ cập nhật đường dẫn sổ làm việc. Dữ liệu biểu đồ không được tải hoặc cập nhật từ sổ làm việc mục tiêu, vì vậy sổ làm việc có thể không khả dụng.
* Khi `updateChartData` là `true`, dữ liệu biểu đồ được cập nhật từ sổ làm việc mục tiêu.

Ví dụ sau gán một URL placeholder với `updateChartData` đặt là `false`. Nó giữ dữ liệu mặc định của biểu đồ tròn và lưu bản trình chiếu mà không tải sổ làm việc không khả dụng.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Lấy đường dẫn sổ làm việc nguồn dữ liệu bên ngoài của một biểu đồ**

Để xác định sổ làm việc được liên kết với một biểu đồ, kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài không và lấy đường dẫn sổ làm việc của nó.

Ví dụ này kiểm tra hình dạng đầu tiên trên slide đầu tiên của một bản trình chiếu có sổ làm việc bên ngoài đã liên kết. Nếu đó là một biểu đồ được liên kết với sổ làm việc bên ngoài, ví dụ in [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ra console. Sau đó lưu một bản sao của bản trình chiếu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Chỉnh sửa dữ liệu biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong sổ làm việc bên ngoài giống như chỉnh sửa nội dung của sổ làm việc nội bộ. Khi một sổ làm việc bên ngoài không thể tải, một ngoại lệ sẽ được ném.

Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và được liên kết với một sổ làm việc bên ngoài có thể truy cập. Nó đặt giá trị được hỗ trợ bởi ô cho điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình chiếu đã cập nhật. Chỉnh sửa giá trị ô có thể cập nhật file XLSX bên ngoài được liên kết, vì vậy hãy sử dụng bản sao nếu bạn cần giữ nguyên sổ làm việc gốc.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Khôi phục sổ làm việc từ bộ nhớ đệm của biểu đồ**

Nếu một biểu đồ sử dụng sổ làm việc bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ làm việc biểu đồ từ dữ liệu đã được lưu trong bộ nhớ đệm của bản trình chiếu. Tạo [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), gọi [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), và đặt [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) thành `true` trước khi mở bản trình chiếu.

Ví dụ PHP sau khôi phục dữ liệu sổ làm việc cho một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và tham chiếu tới một sổ làm việc bên ngoài không khả dụng. Nó truy cập dữ liệu đã khôi phục qua [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) và [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // Đọc hoặc chỉnh sửa dữ liệu sổ làm việc đã khôi phục ở đây.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Nếu sổ làm việc bên ngoài không khả dụng và chế độ khôi phục bị tắt, Aspose.Slides sẽ ném ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là cách tiếp cận chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã được thực hiện trên sổ làm việc bên ngoài sau lần cập nhật cuối cùng của bản trình chiếu.

## **Câu hỏi thường gặp**

**Tôi có thể xác định được một biểu đồ cụ thể có được liên kết tới sổ làm việc bên ngoài hay sổ làm việc nhúng không?**

Có. Một biểu đồ có [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) và một [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); nếu nguồn là sổ làm việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn một tệp bên ngoài đang được dùng.

**Các đường dẫn tương đối tới sổ làm việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình chiếu lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển sổ làm việc có thể cần cập nhật liên kết.

**Tôi có thể sử dụng các sổ làm việc nằm trên tài nguyên/mạng chia sẻ không?**

Có, các sổ làm việc như vậy có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các sổ làm việc từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình chiếu không?**

Bản trình chiếu lưu một [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật file XLSX địa phương được liên kết. Hãy sử dụng một bản sao của sổ làm việc nếu bản gốc phải được giữ nguyên.

**Nếu file bên ngoài được bảo vệ bằng mật khẩu, tôi phải làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi tạo liên kết. Một cách thường dùng là gỡ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng [Aspose.Cells](https://reference.aspose.com/cells/java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ làm việc bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu tất cả chúng trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ khi dữ liệu được tải lại.