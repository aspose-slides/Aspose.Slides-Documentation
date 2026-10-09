---
title: "Quản lý Workbook biểu đồ trong bản trình bày bằng PHP"
linktitle: "Workbook biểu đồ"
type: docs
weight: 70
url: /vi/php-java/chart-workbook/
keywords:
- workbook biểu đồ
- dữ liệu biểu đồ
- ô workbook
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- workbook bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục workbook
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Khám phá Aspose.Slides for PHP via Java: dễ dàng quản lý workbook biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hoá dữ liệu bản trình bày của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập các bộ sưu tập worksheet, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.  

Nó cũng đề cập đến việc làm việc với sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc có sẵn.  

Đối với các ô workbook đại diện cho dữ liệu thiếu, hãy xem [Kiểm soát hiển thị các ô trống](/slides/vi/php-java/chart-series/) để biết sự khác biệt giữa ô trống và số 0, và so sánh biểu đồ đường của các chế độ hiển thị có sẵn.  

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) để kiểm soát liệu biểu đồ có vẽ dữ liệu từ các hàng và cột worksheet ẩn hay không. Đặt nó thành `true` để chỉ vẽ các ô hiển thị, hoặc `false` để bao gồm cả ô hiển thị và ẩn. Cài đặt này điều khiển việc vẽ biểu đồ; nó không ẩn hoặc hiện lại các hàng hoặc cột worksheet.  

Bản trình bày mẫu [bản trình bày mẫu](hidden-source-data.pptx) chứa một biểu đồ cột là hình dạng đầu tiên trên slide đầu tiên. Worksheet được nhúng, `Sheet1`, chứa phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.  

| Hàng worksheet | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn thông qua [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) và đọc [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) để kiểm tra trạng thái ẩn của chúng. Phương thức này báo cáo trạng thái ẩn mà không thay đổi. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `false`, `true`, và `true` tương ứng.  

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại workbook được nhúng bằng [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) và tải lại bằng [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Khi bao gồm tất cả các ô, cũng sử dụng [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) để khôi phục phạm vi đầy đủ, bao gồm danh mục tháng 2 bị ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục đã lưu trong bộ nhớ đệm của mẫu này.  

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

            // Làm mới dữ liệu biểu đồ từ workbook được nhúng.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Khôi phục toàn bộ phạm vi nguồn, bao gồm các danh mục ẩn.
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

Ví dụ này lưu hai phiên bản của bản trình bày: một chỉ có các giá trị Bán lẻ hiển thị (10 và 20), và một khác có tất cả sáu giá trị. Các hình ảnh dưới đây minh họa hai chế độ vẽ. Hàng 3 và cột C vẫn bị ẩn trong cả hai workbook được nhúng.  

| Chỉ các ô hiển thị (`true`) | Tất cả các ô (`false`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho Tháng 1 và Tháng 3.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho Tháng 1, Tháng 2 và Tháng 3.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hay loại trừ dữ liệu nguồn ẩn. Xem [Kiểm soát hiển thị các ô trống](/slides/vi/php-java/chart-series/#control-the-display-of-empty-cells) để xem ví dụ.  

## **Lấy phạm vi dữ liệu của biểu đồ**

Trước khi cập nhật dữ liệu workbook trong một bản trình bày hiện có, kiểm tra các phạm vi nguồn để xác định ô worksheet nào mỗi biểu đồ sử dụng. Phương thức [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) trả về phạm vi dữ liệu hiện tại dưới dạng công thức có định danh worksheet, ví dụ `Sheet1!$A$1:$D$5`. Ở đây, `Sheet1` là tên worksheet, `!` ngăn cách nó với phạm vi ô, và `$A$1:$D$5` xác định các ô A1 đến D5, bao gồm cả. Dấu `$` chỉ ra tham chiếu hàng và cột tuyệt đối.  

Phương thức này đọc phạm vi hiện tại mà không thay đổi biểu đồ hay workbook của nó. Nếu biểu đồ không sử dụng workbook làm nguồn dữ liệu, nó sẽ ném ngoại lệ. Để biết thêm thông tin, xem [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).  

Ví dụ này mở một bản trình bày và kiểm tra các shape trực tiếp trên mỗi slide để tìm biểu đồ. Nó in ra tên mỗi biểu đồ và phạm vi nguồn. Nếu một biểu đồ không sử dụng workbook, nó in thông báo và tiếp tục với biểu đồ tiếp theo.  

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

## **Đọc và ghi dữ liệu biểu đồ từ workbook**

Aspose.Slides for PHP via Java cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) và [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) cho phép bạn đọc và ghi workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã chỉnh sửa bằng Aspose.Cells). **Note** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự như nguồn.  

Ví dụ này sử dụng một bản trình bày có biểu đồ là shape đầu tiên trên slide đầu tiên. Nó đọc workbook được nhúng vào một mảng byte, xóa các series và categories hiện có, và ghi lại cùng một workbook. Các thay đổi vẫn ở trong bộ nhớ; ví dụ không lưu bản trình bày.  

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

### **Xác thực bố cục biểu đồ sau khi sửa đổi workbook**

Khi bạn thay thế một workbook được nhúng bằng một workbook đã sửa đổi, biểu đồ vẫn giữ các series và collections danh mục ban đầu. Sự không khớp này có thể khiến [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) thất bại với lỗi chỉ mục ngoài phạm vi. Xóa các series và categories hiện có trước khi ghi workbook đã cập nhật trở lại biểu đồ. Ví dụ này sử dụng một biểu đồ là shape đầu tiên trên slide đầu tiên. Đoạn chú thích chỉ ra nơi sẽ thực hiện chỉnh sửa workbook; ví dụ chạy được sẽ ghi lại workbook gốc và xác thực bố cục trong bộ nhớ.  

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

        // Sửa đổi các byte workbook ở đây, ví dụ, sử dụng Aspose.Cells.

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

Xóa các collection loại bỏ các tham chiếu dữ liệu cũ trước khi workbook được ghi lại. Tái xây dựng bất kỳ mapping series và category nào cần thiết cho workbook đã cập nhật trước khi sử dụng biểu đồ.  

## **Đặt ô workbook làm nhãn dữ liệu biểu đồ**

Bạn có thể sử dụng văn bản từ các ô workbook làm nhãn dữ liệu biểu đồ.  

Ví dụ này thêm một biểu đồ bubble với dữ liệu mặc định vào slide đầu tiên của một bản trình bày hiện có. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ ô, và lưu bản trình bày đã cập nhật.  

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

## **Quản lý Worksheets**

Phương thức [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) cung cấp quyền truy cập vào các worksheet trong một workbook biểu đồ. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi worksheet ra console.  

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

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng một chuỗi literal; tên thứ hai sử dụng ô C1 trên worksheet 0. Phân loại [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) chọn nguồn cho mỗi tên. Ví dụ lưu bản trình bày với các tên series đã cập nhật.  

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

## **Phát hiện các định dạng workbook nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) cùng với phân loại [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các shape trên slide đầu tiên của một bản trình bày hiện có, bỏ qua các shape không phải là biểu đồ, và in thông báo chẩn đoán cho mỗi biểu đồ có workbook .xlsb được nhúng.  

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

        // Đọc hoặc chỉnh sửa dữ liệu workbook biểu đồ được hỗ trợ tại đây.
    }
} finally {
    $presentation->dispose();
}
```

## **Workbook bên ngoài**

Aspose.Slides hỗ trợ sử dụng workbook bên ngoài làm nguồn dữ liệu cho biểu đồ.  

### **Tạo một Workbook bên ngoài**

Sử dụng [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) và [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) để xuất workbook biểu đồ được nhúng ra file và liên kết biểu đồ với workbook bên ngoài đó.  

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và xuất workbook của nó. Nó hoàn thành việc ghi file trước khi gán workbook bên ngoài làm nguồn dữ liệu biểu đồ, sau đó lưu bản trình bày đã liên kết.  

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

### **Đặt một Workbook bên ngoài**

Sử dụng phương thức [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) bạn có thể gán một workbook bên ngoài cho một biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu workbook đó đã được di chuyển).  

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các workbook như một nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho một workbook bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.  

Ví dụ này sử dụng một workbook bên ngoài mà worksheet có tên `Sheet1` chứa tên series trong B1, tên danh mục trong A2:A4, và giá trị số trong B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết workbook, và sử dụng [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu bản trình bày với biểu đồ đã liên kết.  

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

Tham số `updateChartData` của [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) kiểm soát việc tải workbook.  

* Khi `updateChartData` là `false`, chỉ đường dẫn workbook được cập nhật. Dữ liệu biểu đồ không được tải hoặc cập nhật từ workbook mục tiêu, vì vậy workbook có thể không có sẵn.  
* Khi `updateChartData` là `true`, dữ liệu biểu đồ được cập nhật từ workbook mục tiêu.  

Ví dụ sau gán một URL placeholder với `updateChartData` đặt thành `false`. Nó giữ dữ liệu mặc định của biểu đồ tròn và lưu bản trình bày mà không tải workbook không khả dụng.  

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

### **Lấy đường dẫn Workbook nguồn dữ liệu bên ngoài của biểu đồ**

Để xác định workbook được liên kết với một biểu đồ, kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài không và lấy đường dẫn workbook của nó.  

Ví dụ này kiểm tra shape đầu tiên trên slide đầu tiên của một bản trình bày có workbook bên ngoài được liên kết. Nếu đó là một biểu đồ được liên kết với workbook bên ngoài, ví dụ in [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ra console. Sau đó nó lưu một bản sao của bản trình bày.  

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

Bạn có thể chỉnh sửa dữ liệu trong các workbook bên ngoài tương tự như cách bạn thay đổi nội dung của workbook nội bộ. Khi một workbook bên ngoài không thể được tải, một ngoại lệ sẽ được ném.  

Ví dụ này sử dụng một biểu đồ là shape đầu tiên trên slide đầu tiên và được liên kết với một workbook bên ngoài có thể truy cập. Nó đặt giá trị ô hỗ trợ của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình bày đã cập nhật. Việc chỉnh sửa giá trị ô có thể cập nhật file XLSX bên ngoài đã liên kết, vì vậy hãy sử dụng một bản sao nếu bạn cần giữ nguyên workbook gốc.  

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

### **Khôi phục Workbook từ bộ nhớ đệm biểu đồ**

Nếu một biểu đồ sử dụng một workbook bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể xây dựng lại workbook biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), gọi [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), và đặt [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) thành `true` trước khi mở bản trình bày.  

Ví dụ PHP sau khôi phục dữ liệu workbook cho một biểu đồ là shape đầu tiên trên slide đầu tiên và tham chiếu một workbook bên ngoài không khả dụng. Nó truy cập dữ liệu đã khôi phục thông qua [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) và [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):  

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

        // Đọc hoặc chỉnh sửa dữ liệu workbook đã khôi phục tại đây.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Nếu workbook bên ngoài không khả dụng và việc khôi phục bị tắt, Aspose.Slides sẽ ném ngoại lệ. Chỉ bật việc khôi phục khi sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là một cách dự phòng chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã thực hiện trên workbook bên ngoài sau lần cập nhật cuối cùng của bản trình bày.  

## **Câu hỏi thường gặp**

**Tôi có thể xác định xem một biểu đồ cụ thể có được liên kết với workbook bên ngoài hay được nhúng không?**  
Có. Một biểu đồ có một [loại nguồn dữ liệu](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) và một [đường dẫn tới workbook bên ngoài](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); nếu nguồn là một workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.  

**Đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**  
Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình bày lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển workbook có thể yêu cầu cập nhật liên kết.  

**Tôi có thể sử dụng workbook nằm trên các nguồn tài nguyên hoặc chia sẻ mạng không?**  
Có, các workbook như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa remote workbook trực tiếp từ Aspose.Slides không được hỗ trợ — chúng chỉ có thể được sử dụng làm nguồn.  

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình bày không?**  
Bản trình bày lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Việc chỉnh sửa dữ liệu biểu đồ được hỗ trợ bởi ô có thể cũng cập nhật file XLSX local đã liên kết. Hãy sử dụng một bản sao của workbook nếu bản gốc phải được giữ nguyên.  

**Nếu file bên ngoài được bảo vệ bằng mật khẩu, tôi nên làm gì?**  
Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách phổ biến là loại bỏ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, sử dụng [Aspose.Cells](https://reference.aspose.com/cells/java/)) và liên kết tới bản sao đó.  

**Nhiều biểu đồ có thể tham chiếu cùng một workbook bên ngoài không?**  
Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một file, việc cập nhật file sẽ được phản ánh trong mỗi biểu đồ vào lần tiếp theo dữ liệu được tải.  