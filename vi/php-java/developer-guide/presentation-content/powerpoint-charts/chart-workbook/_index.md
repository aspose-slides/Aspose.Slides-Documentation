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
- workbook bên ngoài
- dữ liệu bên ngoài
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Khám phá Aspose.Slides cho PHP thông qua Java: dễ dàng quản lý workbook biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với workbook biểu đồ trong Aspose.Slides. Nó mô tả cách đọc và ghi dữ liệu biểu đồ thông qua các stream workbook, sử dụng các ô workbook làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet và chỉ định kiểu nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với workbook bên ngoài như là nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một workbook bên ngoài, truy xuất đường dẫn của workbook bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi workbook khả dụng.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Workbook**
Aspose.Slides cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/#readWorkbookStream) và [writeWorkbookStream](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/#writeWorkbookStream) cho phép bạn đọc và ghi workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Note** rằng dữ liệu biểu đồ phải được sắp xếp theo cùng một cách hoặc phải có cấu trúc tương tự như nguồn.

Mã PHP này minh họa một thao tác mẫu:

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

## **Đặt Ô Workbook làm Nhãn Dữ liệu Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/php-java/aspose.slides/presentation) .
1. Lấy tham chiếu đến một slide thông qua chỉ mục của nó.
1. Thêm biểu đồ Bubble với một số dữ liệu.
1. Truy cập series của biểu đồ.
1. Đặt ô workbook làm nhãn dữ liệu.
1. Lưu bản trình chiếu.

Mã PHP này cho thấy cách đặt ô workbook làm nhãn dữ liệu biểu đồ:

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

## **Quản lý Worksheets**

Mã PHP này minh họa một thao tác trong đó phương thức [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/#getWorksheets) được sử dụng để truy cập bộ sưu tập worksheet:

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

## **Chỉ định Kiểu Nguồn Dữ liệu**

Mã PHP này cho thấy cách chỉ định kiểu cho một nguồn dữ liệu:

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

## **Phát hiện Định dạng Workbook Nhúng Không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [ChartData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/) kết hợp với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó.

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
      # Workbook nhúng ở định dạng .xlsb, không được hỗ trợ.
      continue;
    }

    # Đọc hoặc sửa dữ liệu workbook của biểu đồ ở đây.
  }
} finally {
  $presentation->dispose();
}
```

## **Workbook Bên Ngoài**

Aspose.Slides hỗ trợ workbook bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo Workbook Bên Ngoài**

Sử dụng các phương thức **`readWorkbookStream`** và **`setExternalWorkbook`**, bạn có thể tạo một workbook bên ngoài từ đầu hoặc biến một workbook nội bộ thành bên ngoài.

Mã PHP này minh họa quy trình tạo workbook bên ngoài:

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

### **Đặt Workbook Bên Ngoài**

Sử dụng phương thức **`setExternalWorkbook`**, bạn có thể gán một workbook bên ngoài cho một biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu workbook đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các workbook này như một nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho workbook bên ngoài, nó sẽ tự động được chuyển sang đường dẫn tuyệt đối.

Mã PHP này cho thấy cách đặt một workbook bên ngoài:

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

Tham số `ChartData` (được truyền vào phương thức `setExternalWorkbook`) được dùng để chỉ định liệu workbook Excel có được tải hay không.

* Khi giá trị `ChartData` được đặt là `false`, chỉ đường dẫn workbook được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ workbook mục tiêu. Bạn có thể dùng thiết lập này khi workbook mục tiêu không tồn tại hoặc không khả dụng. 
* Khi giá trị `ChartData` được đặt là `true`, dữ liệu biểu đồ sẽ được cập nhật từ workbook mục tiêu.

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

### **Lấy Đường dẫn Workbook Nguồn Dữ liệu Bên Ngoài của Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/php-java/aspose.slides/presentation) .
1. Lấy tham chiếu đến một slide thông qua chỉ mục của nó.
1. Tạo một đối tượng cho shape biểu đồ.
1. Tạo một đối tượng cho kiểu nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
1. Xác định điều kiện phù hợp dựa trên việc kiểu nguồn giống với kiểu nguồn dữ liệu workbook bên ngoài.

Mã PHP này minh họa thao tác:

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

Bạn có thể chỉnh sửa dữ liệu trong workbook bên ngoài theo cách tương tự như khi thay đổi nội dung của workbook nội bộ. Khi không thể tải workbook bên ngoài, một ngoại lệ sẽ được ném ra.

Mã PHP này là triển khai của quy trình đã mô tả:

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

## **FAQ**

**Tôi có thể xác định xem một biểu đồ cụ thể có được liên kết với workbook bên ngoài hay nhúng không?**

Có. Một biểu đồ có [kiểu nguồn dữ liệu](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getdatasourcetype/) và [đường dẫn tới workbook bên ngoài](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getexternalworkbookpath/); nếu nguồn là workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Có hỗ trợ đường dẫn tương đối tới workbook bên ngoài không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định đường dẫn tương đối, nó sẽ tự động được chuyển sang đường dẫn tuyệt đối. Điều này thuận tiện cho việc di động dự án; tuy nhiên, lưu ý rằng bản trình chiếu sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng workbook nằm trên tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa workbook từ xa trực tiếp bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình chiếu không?**

Không. Bản trình chiếu lưu một [liên kết tới file bên ngoài](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) và sử dụng liên kết này để đọc dữ liệu. File bên ngoài sẽ không bị thay đổi khi bản trình chiếu được lưu.

**Nếu file bên ngoài được bảo mật bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Cách thường dùng là gỡ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng cách sử dụng [Aspose.Cells](/cells/php-java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu tất cả chúng cùng trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ vào lần kế tiếp dữ liệu được tải.