---
title: Tạo biểu đồ Excel và nhúng chúng vào bản trình bày dưới dạng đối tượng OLE
type: docs
weight: 30
url: /vi/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- biểu đồ Excel
- nhúng biểu đồ
- đối tượng OLE
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tạo một biểu đồ Excel bằng Aspose.Cells for PHP via Java và nhúng workbook vào bản trình bày PowerPoint bằng Aspose.Slides for PHP via Java, bao gồm cả hình xem trước biểu đồ."
---
## **Tổng quan**

Bài viết này cho thấy cách tạo biểu đồ cột Excel bằng Aspose.Cells for PHP via Java và nhúng workbook của nó vào một bản trình bày PowerPoint bằng Aspose.Slides for PHP via Java. Workbook được nhúng chứa cả dữ liệu nguồn và biểu đồ. Một bản xem trước PNG riêng biệt hiển thị biểu đồ trên slide trước khi đối tượng OLE được kích hoạt.

Kết quả là một đối tượng Excel được nhúng, không phải là biểu đồ PowerPoint gốc. Việc chỉnh sửa workbook qua OLE yêu cầu một ứng dụng máy tính để bàn hỗ trợ kích hoạt OLE và cài đặt Excel tương thích.

## **Điều kiện tiên quyết**

Cấu hình Aspose.Cells for PHP via Java và Aspose.Slides for PHP via Java với cùng một phiên bản PHP/Java Bridge. Tải cả hai wrapper PHP và làm cho các thư viện Java của cả hai sản phẩm khả dụng cho bridge. Microsoft Office không bắt buộc để tạo bản trình bày với các thư viện này.

Không cần tệp đầu vào: ví dụ tạo dữ liệu và biểu đồ trong bộ nhớ, sau đó ghi `OutputChart.pptx` vào thư mục làm việc hiện tại. Áp dụng giấy phép cho cả hai sản phẩm khi chạy ngoài chế độ đánh giá.

## **Cách nhúng hoạt động**

1. Tạo một workbook có một worksheet dữ liệu và một chart sheet.  
2. Đặt chart sheet làm sheet hoạt động để workbook mở ở biểu đồ.  
3. Đặt phạm vi hiển thị OLE của workbook và render biểu đồ thành PNG.  
4. Lưu workbook dưới dạng XLSX trong bộ nhớ và nhúng các byte đó vào một slide.  
5. Gán PNG làm hình xem trước của đối tượng OLE và lưu bản trình bày dưới dạng PPTX.

Phạm vi hiển thị của workbook và khung trên slide có các vai trò khác nhau. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) nhận chỉ số hàng và cột bắt đầu/kết thúc dựa trên chỉ số 0. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) thay vào đó nhận hàng trên cùng, cột trái, hàng dưới cùng và cột phải. Ví dụ sử dụng chỉ số hàng 55 và chỉ số cột 25 làm giới hạn phía dưới‑phải; các giá trị này là lựa chọn bố cục, không phải số lượng hàng hoặc cột dữ liệu.

Khung trên slide sử dụng đơn vị điểm. Ví dụ căn khung vào trong slide và căn giữa trong khi giữ tỷ lệ khung hình của PNG, thay vì kéo dài hình xem trước để lấp đầy slide.

## **Tạo và Nhúng Biểu Đồ**

Ví dụ đầy đủ sau đây điền `DataSheet` với bốn hàng và năm cột giá trị. Mỗi hàng trở thành một chuỗi biểu đồ. `ChartSheet` được chọn làm sheet hoạt động trước khi workbook được lưu.

Workbook được lưu một cách rõ ràng dưới dạng XLSX, khớp với phần mở rộng `xlsx` được truyền cho [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). Kết quả số của Java được chuyển đổi bằng `java_values` trước khi PHP thực hiện phép toán, trong khi dữ liệu nhị phân vẫn giữ trong các mảng byte của Java. PNG được tải trực tiếp từ các byte của nó mà không cần chuyển đổi bitmap trung gian. Gán nó qua [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) thay thế nội dung giữ chỗ OLE mặc định.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Giữ PNG và XLSX dưới dạng mảng byte Java khi truyền chúng tới Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Căn chỉnh và đặt trung tâm hình xem trước đồng thời giữ nguyên tỷ lệ khung hình.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Kết quả mong đợi**

`OutputChart.pptx` chứa một slide với một workbook Excel được nhúng và một hình xem trước biểu đồ. Workbook chứa dữ liệu gốc và một biểu đồ cột với bốn chuỗi. Hình xem trước được căn giữa trên slide và giữ nguyên tỷ lệ kích thước.

![Biểu đồ cột Excel được hiển thị làm hình xem trước của workbook được nhúng](excel-chart-ole-preview.png)

Trong môi trường PowerPoint máy tính để bàn tương thích có Excel, nhấp đúp vào đối tượng để kích hoạt và chỉnh sửa workbook được nhúng. Việc kích hoạt và chỉnh sửa phụ thuộc vào hỗ trợ OLE và cài đặt bảo mật của ứng dụng chủ.

## **Câu hỏi thường gặp**

**Tại sao cần hình xem trước?**

Workbook được nhúng và hình xem trước trên slide là nội dung riêng biệt. Cung cấp một hình ảnh biểu đồ để slide hiển thị biểu đồ thay vì nội dung giữ chỗ mặc định “EMBEDDED OLE OBJECT”. Xem [Object Preview Issue when Adding OleObjectFrame](/slides/vi/php-java/object-preview-issue-when-adding-oleobjectframe/).

**Hình xem trước có tự động cập nhật khi tôi thay đổi workbook trong mã không?**

Xem trước được coi là một ảnh chụp. Khi cập nhật dữ liệu workbook bằng chương trình, cần tạo lại hình ảnh biểu đồ và thay thế cả hình xem trước lẫn dữ liệu workbook được nhúng.

**Tôi có thể dùng XLS thay vì XLSX không?**

Có. Lưu workbook ở định dạng XLS và sử dụng `xls` làm phần mở rộng dữ liệu được nhúng. Phần mở rộng phải khớp với định dạng thực tế của workbook; chỉ thay đổi phần mở rộng mà không chuyển đổi dữ liệu sẽ không có hiệu lực.

**Tại sao đối tượng có thể thay đổi kích thước sau khi kích hoạt?**

Ứng dụng chủ có thể cập nhật cách trình bày của đối tượng OLE khi kích hoạt workbook. Cả phạm vi hiển thị OLE của workbook và kích thước khung trên slide đều ảnh hưởng. Xem [Working Solution for Chart Resizing in PPTX](/slides/vi/java/working-solution-for-chart-resizing-in-pptx/).

## **Các phần liên quan**

- [Working Solution for Chart Resizing in PPTX](/slides/vi/java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/vi/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Manage OLE Objects](/slides/vi/php-java/manage-ole/)