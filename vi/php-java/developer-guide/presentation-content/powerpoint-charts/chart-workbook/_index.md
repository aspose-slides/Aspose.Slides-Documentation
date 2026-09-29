---
title: Quản lý Workbook Biểu đồ trong Bản trình chiếu bằng PHP
linktitle: Workbook Biểu đồ
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
- workbook ngoại
- dữ liệu ngoại
- bộ nhớ đệm biểu đồ
- khôi phục workbook
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Khám phá Aspose.Slides cho PHP thông qua Java: quản lý workbook biểu đồ trong các định dạng PowerPoint và OpenDocument một cách dễ dàng để tối ưu dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô trong sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng bao gồm việc làm việc với sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc có sẵn.

Đối với các ô trong sổ làm việc đại diện cho dữ liệu thiếu, xem [Control the Display of Empty Cells](/slides/vi/php-java/chart-series/) để biết sự khác nhau giữa ô trống và giá trị zero, và so sánh biểu đồ đường của các chế độ hiển thị có sẵn.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/setplotvisiblecellsonly/) để kiểm soát liệu biểu đồ có vẽ dữ liệu từ các hàng và cột worksheet ẩn hay không. Đặt giá trị `true` để chỉ vẽ các ô hiển thị, hoặc `false` để bao gồm cả ô hiển thị và ẩn. Cài đặt này chỉ kiểm soát việc vẽ biểu đồ; nó không ẩn hoặc hiển thị lại các hàng hoặc cột worksheet.

Tải về [hidden-source-data.pptx](hidden-source-data.pptx) và đặt nó vào thư mục làm việc. Trang chiếu đầu tiên chứa một biểu đồ cột làm hình dạng đầu tiên. Worksheet nhúng, `Sheet1`, chứa phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng Worksheet | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn thông qua [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getchartdataworkbook/) và đọc [ChartDataCell::isHidden](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/ishidden/) để kiểm tra trạng thái ẩn của chúng. Phương thức này báo cáo trạng thái ẩn mà không thay đổi nó. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `false`, `true`, và `true` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại workbook nhúng bằng [readWorkbookStream](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/readworkbookstream/) và tải lại bằng [writeWorkbookStream](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/writeworkbookstream/). Khi bao gồm tất cả các ô, cũng sử dụng [setRange](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/setrange/) để khôi phục phạm vi đầy đủ, bao gồm danh mục tháng 2 bị ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục được lưu trong bộ nhớ đệm của mẫu này.

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

            // Làm mới dữ liệu biểu đồ từ workbook nhúng.
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

Ví dụ lưu `hidden_cells_true.pptx` chỉ với các giá trị Bán lẻ hiển thị (10 và 20), và `hidden_cells_false.pptx` với cả sáu giá trị. Các hình ảnh dưới đây minh họa hai chế độ vẽ. Hàng 3 và cột C vẫn ẩn trong cả hai workbook nhúng.

| Chỉ các ô hiển thị (`true`) | Tất cả các ô (`false`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho Tháng 1 và Tháng 3.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho Tháng 1, Tháng 2 và Tháng 3.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/setdisplayblanksas/) kiểm soát cách hiển thị các giá trị bị thiếu; nó không bao gồm hoặc loại trừ dữ liệu nguồn ẩn. Xem [Control the Display of Empty Cells](/slides/vi/php-java/chart-series/#control-the-display-of-empty-cells) để xem ví dụ.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Workbook**

Aspose.Slides cho PHP thông qua Java cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/readworkbookstream/) và [writeWorkbookStream](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/writeworkbookstream/) cho phép bạn đọc và ghi các workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ được chỉnh sửa bằng Aspose.Cells). **Note** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự nguồn.

Ví dụ này mở `chart.pptx`, phải chứa một biểu đồ làm hình dạng đầu tiên trên slide đầu tiên. Nó đọc workbook nhúng vào một mảng byte, xóa các series và category hiện có, và ghi lại cùng một workbook. Các thay đổi vẫn tồn tại trong bộ nhớ; ví dụ không lưu bản trình chiếu.

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

### **Xác thực Bố cục Biểu đồ Sau Khi Sửa Workbook**

Khi bạn thay thế workbook nhúng bằng một workbook đã chỉnh sửa, biểu đồ vẫn giữ lại các collection series và category ban đầu. Sự không khớp này có thể khiến [Chart::validateChartLayout](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/validatechartlayout/) gặp lỗi index-out-of-range. Hãy xóa các series và category hiện có trước khi ghi workbook cập nhật trở lại biểu đồ. Ví dụ này yêu cầu `chart.pptx` có một biểu đồ làm hình dạng đầu tiên trên slide đầu tiên. Bình luận đánh dấu vị trí sẽ chỉnh sửa workbook; ví dụ thực thi ghi lại workbook gốc và xác thực bố cục trong bộ nhớ.

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

        // Sửa đổi các byte workbook ở đây, ví dụ, bằng cách sử dụng Aspose.Cells.

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

Việc xóa các collection loại bỏ các tham chiếu dữ liệu cũ trước khi workbook được ghi lại. Hãy xây dựng lại bất kỳ ánh xạ series và category nào cần thiết cho workbook đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt Ô Workbook làm Nhãn Dữ liệu Biểu đồ**

Bạn có thể sử dụng văn bản từ các ô workbook làm nhãn dữ liệu cho biểu đồ. Các bước dưới đây cho thấy cách liên kết các nhãn trong biểu đồ bong bóng với các ô trong workbook dữ liệu của nó.

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập slide đầu tiên bằng chỉ số bắt đầu từ 0.
3. Thêm một biểu đồ bong bóng với dữ liệu mặc định.
4. Truy cập series của biểu đồ.
5. Đặt ô workbook làm nhãn dữ liệu.
6. Lưu bản trình chiếu.

Ví dụ này mở `chart2.pptx`, phải chứa ít nhất một slide, và thêm một biểu đồ bong bóng với dữ liệu mặc định. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ các ô, và lưu kết quả vào `resultchart.pptx`.

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

Phương thức [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/getworksheets/) cung cấp quyền truy cập vào các worksheet trong một chart workbook. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi worksheet ra console.

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

## **Chỉ định Kiểu Nguồn Dữ liệu**

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt tên cho hai series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng chuỗi literal; tên thứ hai sử dụng ô C1 trên worksheet 0. Enum [DataSourceType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datasourcetype/) chọn nguồn cho mỗi tên. Kết quả được lưu vào `pres.pptx`.

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

## **Phát hiện Định dạng Workbook Nhúng Không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [ChartData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/) kết hợp với enum [WorkbookType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các shape trên slide đầu tiên của `sample.pptx`, bỏ qua các shape không phải biểu đồ, và in thông báo chẩn đoán cho mỗi biểu đồ có workbook .xlsb nhúng.

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

        // Đọc hoặc sửa đổi dữ liệu workbook biểu đồ được hỗ trợ tại đây.
    }
} finally {
    $presentation->dispose();
}
```

## **Workbook Ngoại**

Aspose.Slides hỗ trợ việc sử dụng workbook ngoại làm nguồn dữ liệu cho biểu đồ.

### **Tạo một Workbook Ngoại**

Sử dụng [readWorkbookStream](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/readworkbookstream/) và [setExternalWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/setexternalworkbook/) để xuất workbook biểu đồ nhúng ra một tệp và liên kết biểu đồ tới workbook ngoại đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định, ghi workbook của nó vào `externalWorkbook1.xlsx`, và hoàn thành việc ghi tệp trước khi gán tệp làm nguồn dữ liệu cho biểu đồ. Nó lưu bản trình chiếu đã liên kết vào `externalWorkbook.pptx`.

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

### **Đặt một Workbook Ngoại**

Sử dụng phương thức [setExternalWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/setexternalworkbook/), bạn có thể gán một workbook ngoại cho biểu đồ như là nguồn dữ liệu của nó. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook ngoại (nếu workbook đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu ở vị trí hoặc tài nguyên từ xa, bạn vẫn có thể sử dụng các workbook đó làm nguồn dữ liệu ngoại. Nếu cung cấp đường dẫn tương đối cho một workbook ngoại, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Ví dụ này yêu cầu `externalWorkbook.xlsx` trong thư mục làm việc. Worksheet có tên `Sheet1` phải chứa tên series ở B1, tên danh mục ở A2:A4, và các giá trị số ở B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết workbook, và sử dụng [setRange](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/setrange/) để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu kết quả vào `Presentation_with_externalWorkbook.pptx`.

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

Tham số `updateChartData` của [setExternalWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/setexternalworkbook/) kiểm soát việc có tải workbook hay không.

* Khi `updateChartData` là `false`, chỉ đường dẫn workbook được cập nhật. Dữ liệu biểu đồ không được tải hoặc cập nhật từ workbook đích, do đó workbook có thể không có sẵn.
* Khi `updateChartData` là `true`, dữ liệu biểu đồ được cập nhật từ workbook đích.

Ví dụ dưới đây gán một URL placeholder với `updateChartData` đặt thành `false`. Nó giữ nguyên dữ liệu mặc định của biểu đồ tròn và lưu bản trình chiếu mà không tải workbook không khả dụng.

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

### **Lấy Đường dẫn Workbook Nguồn Dữ liệu Ngoại của một Biểu đồ**

Để xác định workbook liên kết với một biểu đồ, trước tiên kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu ngoại hay không. Nếu có, bạn có thể lấy đường dẫn workbook bằng cách thực hiện các bước sau.

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Truy cập slide đầu tiên bằng chỉ số bắt đầu từ 0.
3. Kiểm tra rằng shape đầu tiên là một biểu đồ.
4. Đọc kiểu nguồn dữ liệu của biểu đồ.
5. Nếu nguồn là một workbook ngoại, đọc đường dẫn của nó.

Ví dụ này mở `externalWorkbook.pptx`, được tạo trong ví dụ trước, và kiểm tra shape đầu tiên trên slide đầu tiên. Nếu nó là một biểu đồ được liên kết với workbook ngoại, ví dụ sẽ in [getExternalWorkbookPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ra console. Sau đó nó lưu một bản sao của bản trình chiếu vào `Result.pptx`.

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

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong workbook ngoại tương tự như cách bạn thay đổi nội dung của workbook nội bộ. Khi một workbook ngoại không thể tải, một ngoại lệ sẽ được ném.

Ví dụ này yêu cầu `presentation.pptx` có một biểu đồ làm shape đầu tiên trên slide đầu tiên và một workbook ngoại có thể truy cập. Nó đặt giá trị được hỗ trợ bởi ô của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình chiếu vào `presentation_out.pptx`. Việc chỉnh sửa giá trị ô có thể cập nhật tệp XLSX ngoại được liên kết, vì vậy hãy sử dụng một bản sao nếu bạn cần giữ nguyên workbook gốc.

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

### **Khôi phục Workbook từ Bộ nhớ Đệm của Biểu đồ**

Nếu một biểu đồ sử dụng workbook ngoại bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo chart workbook từ dữ liệu được lưu trong bộ nhớ đệm của bản trình chiếu. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/), gọi [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), và đặt [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) thành `true` trước khi mở bản trình chiếu.

Ví dụ PHP dưới đây mở `presentation.pptx`, trong đó shape đầu tiên trên slide đầu tiên phải là một biểu đồ tham chiếu đến workbook ngoại không khả dụng, và truy cập dữ liệu đã khôi phục thông qua [Chart::getChartData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/getchartdata/) và [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Đọc hoặc sửa đổi dữ liệu workbook đã khôi phục ở đây.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Nếu workbook ngoại không khả dụng và việc khôi phục bị tắt, Aspose.Slides sẽ ném ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là một phương án chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi được thực hiện trên workbook ngoại sau khi bản trình chiếu được cập nhật lần cuối.

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có được liên kết với workbook ngoại hay nhúng không?**

Có. Một biểu đồ có [data source type](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getdatasourcetype/) và một [đường dẫn tới workbook ngoại](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getexternalworkbookpath/); nếu nguồn là một workbook ngoại, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp ngoại đang được sử dụng.

**Các đường dẫn tương đối tới workbook ngoại có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình chiếu lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển workbook có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng các workbook nằm trên tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được sử dụng làm nguồn dữ liệu ngoại. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa qua Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè tệp XLSX ngoại khi lưu bản trình chiếu không?**

Bản trình chiếu lưu một [liên kết tới tệp ngoại](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật tệp XLSX địa phương đã liên kết. Hãy sử dụng một bản sao của workbook nếu cần giữ nguyên bản gốc.

**Nếu tệp ngoại được bảo vệ bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách phổ biến là loại bỏ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, sử dụng [Aspose.Cells](https://reference.aspose.com/cells/java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook ngoại không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.