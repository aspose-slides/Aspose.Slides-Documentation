---
title: Quản lý Sổ làm việc Biểu đồ trong Bản trình chiếu bằng PHP
linktitle: Sổ làm việc Biểu đồ
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
description: "Khám phá Aspose.Slides cho PHP thông qua Java: dễ dàng quản lý sổ làm việc biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hoá dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua các luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập bảng tính, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc khả dụng.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Sổ Làm việc**
Aspose.Slides cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/#readWorkbookStream) và [writeWorkbookStream](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/#writeWorkbookStream) cho phép bạn đọc và ghi sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc có cấu trúc tương tự như nguồn.

Đoạn mã PHP sau đây trình bày một thao tác mẫu:

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Xác Thực Bố Cục Biểu Đồ Sau Khi Sửa Đổi Sổ Làm việc**

Khi bạn thay thế một sổ làm việc nhúng bằng một sổ đã được chỉnh sửa, biểu đồ vẫn giữ lại các bộ sưu tập chuỗi và danh mục gốc. Sự không khớp này có thể gây lỗi cho [Chart::validateChartLayout](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/validatechartlayout/) với lỗi chỉ mục ngoài phạm vi. Hãy xóa các chuỗi và danh mục hiện có trước khi ghi lại sổ làm việc đã cập nhật vào biểu đồ.

```php
// Sau khi chỉnh sửa luồng sổ làm việc (ví dụ, sử dụng Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// Xóa các tham chiếu dữ liệu hiện có.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

Việc xóa các bộ sưu tập đảm bảo cấu trúc dữ liệu biểu đồ nhất quán với sổ làm việc mới, cho phép `validateChartLayout` hoàn thành mà không gặp lỗi.

## **Đặt Ô Sổ Làm việc làm Nhãn Dữ liệu Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/php-java/aspose.slides/presentation).  
1. Lấy tham chiếu slide thông qua chỉ mục của nó.  
1. Thêm một biểu đồ Bubble với một số dữ liệu.  
1. Truy cập chuỗi biểu đồ.  
1. Đặt ô sổ làm việc làm nhãn dữ liệu.  
1. Lưu bản trình chiếu.

Đoạn mã PHP sau đây cho bạn cách đặt ô sổ làm việc làm nhãn dữ liệu biểu đồ:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Khởi tạo một lớp trình chiếu đại diện cho tệp trình chiếu
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Quản lý Bảng tính**

Đoạn mã PHP này minh họa một thao tác trong đó phương thức [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/#getWorksheets) được sử dụng để truy cập bộ sưu tập bảng tính:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Chỉ định Loại Nguồn Dữ liệu**

Đoạn mã PHP này cho bạn cách chỉ định một loại cho nguồn dữ liệu:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Phát hiện Định dạng Sổ Làm việc Nhúng Không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ làm việc nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [ChartData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/) cùng với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó.

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # Sổ làm việc nhúng ở định dạng .xlsb, không được hỗ trợ.
      continue;
    }

    # Đọc hoặc chỉnh sửa dữ liệu sổ làm việc biểu đồ ở đây.
  }
} finally {
  $presentation->dispose();
}
```

## **Sổ Làm việc Bên Ngoài**

Aspose.Slides hỗ trợ sổ làm việc bên ngoài làm nguồn dữ liệu cho các biểu đồ.

### **Tạo Sổ Làm việc Bên Ngoài**

Sử dụng các phương thức **`readWorkbookStream`** và **`setExternalWorkbook`**, bạn có thể tạo một sổ làm việc bên ngoài từ đầu hoặc biến một sổ làm việc nội bộ thành bên ngoài.

Đoạn mã PHP sau đây trình bày quy trình tạo sổ làm việc bên ngoài:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Đặt Sổ Làm việc Bên Ngoài**

Sử dụng phương thức **`setExternalWorkbook`**, bạn có thể gán một sổ làm việc bên ngoài cho một biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn đến sổ làm việc bên ngoài (nếu sổ đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ làm việc được lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các sổ đó làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho sổ làm việc bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Đoạn mã PHP sau đây cho bạn cách đặt một sổ làm việc bên ngoài:

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Tham số `ChartData` (được truyền vào phương thức `setExternalWorkbook`) được dùng để chỉ định xem sổ Excel có được tải hay không.

* Khi giá trị `ChartData` được đặt thành `false`, chỉ đường dẫn sổ làm việc được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ sổ đích. Bạn có thể dùng thiết lập này khi sổ đích không tồn tại hoặc không khả dụng.  
* Khi giá trị `ChartData` được đặt thành `true`, dữ liệu biểu đồ sẽ được cập nhật từ sổ đích.

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Lấy Đường dẫn Nguồn Dữ liệu Bên Ngoài của Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/php-java/aspose.slides/presentation).  
1. Lấy tham chiếu slide thông qua chỉ mục của nó.  
1. Tạo một đối tượng cho hình dạng biểu đồ.  
1. Tạo một đối tượng cho loại nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.  
1. Xác định điều kiện liên quan dựa trên việc loại nguồn giống với loại nguồn dữ liệu sổ làm việc bên ngoài.

Đoạn mã PHP này minh họa thao tác:

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Lưu bản trình chiếu
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong sổ làm việc bên ngoài theo cách tương tự như khi thay đổi nội dung của sổ làm việc nội bộ. Khi một sổ làm việc bên ngoài không thể tải, một ngoại lệ sẽ được ném ra.

Đoạn mã PHP này thực hiện quy trình đã mô tả:

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Khôi phục Sổ Làm việc từ Bộ nhớ Đệm Biểu đồ**

Nếu một biểu đồ sử dụng sổ làm việc bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ làm việc biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình chiếu. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/), cấu hình nó với [SpreadsheetOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/spreadsheetoptions/), và gọi [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) với `true` trước khi mở bản trình chiếu.

Ví dụ PHP sau mở một bản trình chiếu mà biểu đồ tham chiếu đến sổ làm việc bên ngoài không khả dụng và truy cập dữ liệu đã khôi phục qua [Chart::getChartData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/#getChartData) và [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Đọc hoặc chỉnh sửa dữ liệu sổ làm việc đã khôi phục ở đây.
} finally {
    $presentation->dispose();
}
```

Nếu sổ làm việc bên ngoài không khả dụng và chế độ khôi phục bị tắt, Aspose.Slides sẽ ném ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là một lựa chọn chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã thực hiện trên sổ làm việc bên ngoài sau lần cập nhật cuối cùng của bản trình chiếu.

## **FAQ**

**Tôi có thể xác định xem một biểu đồ cụ thể có liên kết đến sổ làm việc bên ngoài hay nhúng không?**

Có. Một biểu đồ có [loại nguồn dữ liệu](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getdatasourcetype/) và một [đường dẫn tới sổ làm việc bên ngoài](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getexternalworkbookpath/); nếu nguồn là sổ làm việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới sổ làm việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này tiện lợi cho việc di động dự án; tuy nhiên, lưu ý rằng bản trình chiếu sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể dùng các sổ làm việc nằm trên các tài nguyên/mạng chia sẻ không?**

Có, các sổ làm việc đó có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các sổ làm việc từ xa trong Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản trình chiếu không?**

Không. Bản trình chiếu lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) và sử dụng nó để đọc dữ liệu. Tệp bên ngoài không bị thay đổi khi bản trình chiếu được lưu.

**Nếu tệp bên ngoài được bảo vệ bằng mật khẩu thì tôi phải làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường được dùng là gỡ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng [Aspose.Cells](/cells/php-java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ làm việc bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ khi dữ liệu được tải lại.