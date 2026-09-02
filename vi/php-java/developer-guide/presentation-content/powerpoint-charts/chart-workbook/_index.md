---
title: Quản lý Workbook Biểu đồ trong Bản trình bày bằng PHP
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
- workbook ngoại vi
- dữ liệu ngoại vi
- bộ nhớ đệm biểu đồ
- khôi phục workbook
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Khám phá Aspose.Slides cho PHP thông qua Java: dễ dàng quản lý workbook biểu đồ trong định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình bày của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với workbook biểu đồ trong Aspose.Slides. Nó chỉ ra cách đọc và ghi dữ liệu biểu đồ thông qua luồng workbook, sử dụng các ô workbook làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với workbook ngoại vi làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một workbook ngoại vi, lấy đường dẫn của workbook ngoại vi được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi workbook có sẵn.

## **Đọc và Ghi Dữ liệu Biểu đồ Từ Workbook**
Aspose.Slides cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/#readWorkbookStream) và [writeWorkbookStream](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/#writeWorkbookStream) cho phép bạn đọc và ghi workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc có cấu trúc tương tự nguồn.

Mã PHP này trình bày một thao tác mẫu:

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

## **Đặt Ô WorkBook Là Nhãn Dữ liệu Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/php-java/aspose.slides/presentation) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Thêm biểu đồ Bubble với một số dữ liệu.
4. Truy cập series của biểu đồ.
5. Đặt ô workbook làm nhãn dữ liệu.
6. Lưu bản trình bày.

Mã PHP này cho bạn cách đặt một ô workbook làm nhãn dữ liệu biểu đồ:

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

Mã PHP này trình bày một thao tác trong đó phương thức [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/#getWorksheets) được sử dụng để truy cập bộ sưu tập worksheet:

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

Mã PHP này cho bạn cách chỉ định một kiểu cho nguồn dữ liệu:

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

Aspose.Slides không hỗ trợ định dạng workbook Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [ChartData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/) cùng với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó.

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

    # Đọc hoặc chỉnh sửa dữ liệu workbook biểu đồ tại đây.
  }
} finally {
  $presentation->dispose();
}
```

## **External Workbook**

Aspose.Slides hỗ trợ workbook ngoại vi làm nguồn dữ liệu cho biểu đồ.

### **Tạo một Workbook Ngoại vi**

Bằng cách sử dụng các phương thức **`readWorkbookStream`** và **`setExternalWorkbook`**, bạn có thể tạo một workbook ngoại vi từ đầu hoặc chuyển một workbook nội bộ thành ngoại vi.

Mã PHP này trình bày quy trình tạo workbook ngoại vi:

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

### **Đặt một Workbook Ngoại vi**

Bằng cách sử dụng phương thức **`setExternalWorkbook`**, bạn có thể gán một workbook ngoại vi cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook ngoại vi (nếu workbook này đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các workbook đó làm nguồn dữ liệu ngoại vi. Nếu cung cấp đường dẫn tương đối cho một workbook ngoại vi, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Mã PHP này cho bạn cách đặt một workbook ngoại vi:

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

Tham số `ChartData` (dưới phương thức `setExternalWorkbook`) được dùng để chỉ định liệu workbook Excel có được tải hay không.

* Khi giá trị `ChartData` được đặt thành `false`, chỉ đường dẫn workbook được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ workbook đích. Bạn có thể muốn sử dụng thiết lập này khi workbook đích không tồn tại hoặc không khả dụng. 
* Khi giá trị `ChartData` được đặt thành `true`, dữ liệu biểu đồ sẽ được cập nhật từ workbook đích.

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

### **Lấy Đường dẫn Workbook Nguồn Dữ liệu Ngoại vi của Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/php-java/aspose.slides/presentation) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Tạo một đối tượng cho shape biểu đồ.
4. Tạo một đối tượng cho kiểu nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
5. Xác định điều kiện liên quan dựa trên việc kiểu nguồn giống với kiểu nguồn dữ liệu workbook ngoại vi.

Mã PHP này trình bày thao tác:

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
    # Lưu bản trình bày
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong workbook ngoại vi tương tự như khi thay đổi nội dung của workbook nội bộ. Khi một workbook ngoại vi không thể tải, một ngoại lệ sẽ được ném.

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

### **Khôi phục Workbook từ Bộ nhớ Đệm Biểu đồ**

Nếu một biểu đồ sử dụng workbook ngoại vi bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/), cấu hình nó với [SpreadsheetOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/spreadsheetoptions/), và gọi [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) với `true` trước khi mở bản trình bày.

Ví dụ PHP sau mở một bản trình bày mà biểu đồ tham chiếu tới một workbook ngoại vi không khả dụng và truy cập dữ liệu đã khôi phục thông qua [Chart::getChartData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/#getChartData) và [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Đọc hoặc chỉnh sửa dữ liệu workbook đã khôi phục tại đây.
} finally {
    $presentation->dispose();
}
```

Nếu workbook ngoại vi không khả dụng và tính năng khôi phục bị tắt, Aspose.Slides sẽ ném một ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã được lưu trong bộ nhớ đệm là giải pháp chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã thực hiện trên workbook ngoại vi sau lần cập nhật cuối cùng của bản trình bày.

## **FAQ**

**Tôi có thể xác định liệu một biểu đồ cụ thể có được liên kết với workbook ngoại vi hay nhúng không?**

Có. Một biểu đồ có một [kiểu nguồn dữ liệu](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getdatasourcetype/) và một [đường dẫn tới workbook ngoại vi](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getexternalworkbookpath/); nếu nguồn là workbook ngoại vi, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp ngoại vi đang được sử dụng.

**Các đường dẫn tương đối tới workbook ngoại vi có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này thuận tiện cho tính di động của dự án; tuy nhiên, hãy lưu ý rằng bản trình bày sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng workbook nằm trên tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được sử dụng làm nguồn dữ liệu ngoại vi. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX ngoại vi khi lưu bản trình bày không?**

Không. Bản trình bày lưu một [liên kết tới file ngoại vi](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) và sử dụng nó để đọc dữ liệu. File ngoại vi tự nó không bị thay đổi khi bản trình bày được lưu.

**Nếu file ngoại vi được bảo mật bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bỏ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng [Aspose.Cells](/cells/php-java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu tới cùng một workbook ngoại vi không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu tất cả chúng đều trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ vào lần tải dữ liệu tiếp theo.