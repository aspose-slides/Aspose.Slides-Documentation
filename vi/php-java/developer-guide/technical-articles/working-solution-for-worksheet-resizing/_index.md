---
title: Giải pháp hoạt động cho việc thay đổi kích thước bảng tính
type: docs
weight: 20
url: /vi/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- hình ảnh xem trước
- thay đổi kích thước hình ảnh
- Excel
- bảng tính
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước OLE của bảng tính Excel trong bài thuyết trình: hai cách để giữ khung đối tượng nhất quán—thu phóng khung hoặc trang tính—trên các định dạng PPT và PPTX."
---
{{% alert color="info" title="Note" %}}
Các bảng tính Excel được nhúng dưới dạng đối tượng OLE trong bài thuyết trình PowerPoint bằng các thành phần Aspose có thể thay đổi kích thước một cách không mong muốn sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt về hình ảnh đáng chú ý giữa đối tượng OLE trước và sau khi kích hoạt. Bài viết này giải thích vấn đề và mô tả hai cách để khắc phục.
{{% /alert %}}

## **Nền tảng**

Trong bài viết [Quản lý OLE](/slides/vi/php-java/manage-ole/), chúng tôi đã giải thích cách thêm khung OLE vào bài thuyết trình PowerPoint bằng Aspose.Slides for PHP via Java. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/php-java/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán một ảnh của vùng bảng tính đã chọn cho khung đối tượng OLE. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị ảnh bảng tính, sổ làm việc Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trên sổ Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài sổ Excel đã kích hoạt. Kích thước của khung đối tượng OLE sẽ thay đổi khi người dùng quay lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy vào kích thước của khung OLE và sổ Excel được nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Vì sổ Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước ban đầu khi lần đầu tiên được kích hoạt. Ngược lại, khung đối tượng OLE có kích thước riêng của nó. Theo Microsoft, khi sổ Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỷ lệ đúng như một phần của quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự chênh lệch giữa kích thước cửa sổ Excel và kích thước cũng như vị trí của khung đối tượng OLE.

## **Giải pháp khả thi**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Thu phóng khung OLE trong bài thuyết trình PowerPoint sao cho khớp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn.
- Giữ kích thước khung OLE cố định và thu phóng các hàng và cột đã chọn để vừa vào trong khung.

### **Thu phóng kích thước khung OLE**

Cách tiếp cận này thiết lập kích thước khung OLE sao cho khớp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn trong bảng tính Excel được nhúng.

Ví dụ tải một sổ Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của trang tính đầu tiên bằng chỉ số bắt đầu từ 0. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) xác định phạm vi hiển thị. Bản xem trước được render ở 96 DPI và kích thước pixel được chuyển sang điểm bằng 72 điểm mỗi inch. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) nhúng sổ đã chỉnh sửa vào một khung với các kích thước đó. Bản xem trước được gán thông qua [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) để thay thế placeholder “EMBEDDED OLE OBJECT” trong bản trình chiếu đã lưu.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Nhúng sổ làm việc đã chỉnh sửa và giữ dữ liệu nhị phân trong mảng byte Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

Trợ giúp xem trước thiết lập [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) cho phạm vi đã chọn và loại bỏ lề, tiêu đề và chân trang. Khi bật [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea), [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) render phạm vi dưới dạng ảnh PNG. Trợ giúp trả về một luồng nhập mới chứa ảnh PNG, đặt con trỏ ở đầu để sử dụng trong bài thuyết trình.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **Thu phóng kích thước phạm vi ô**

Cách tiếp cận này thu phóng chiều cao của các hàng đã chọn và chiều rộng của các cột đã chọn sao cho khớp với kích thước khung OLE tùy chỉnh.

Ví dụ tải một sổ Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của trang tính đầu tiên bằng chỉ số bắt đầu từ 0. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) xác định phạm vi hiển thị, và trợ giúp dưới đây thu phóng phạm vi đó để vừa vào khung rộng 400 điểm và cao 100 điểm. Sau khi lưu sổ đã chỉnh sửa vào một luồng, [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) nhúng nó với kích thước đã chỉ định. Một bản xem trước được render ở 96 DPI và gán qua [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), vì vậy bản trình chiếu đã lưu hiển thị các ô đã chọn thay vì placeholder mặc định.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Nhúng sổ làm việc đã chỉnh sửa và giữ dữ liệu nhị phân trong mảng byte Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

Trợ giúp thu phóng tính toán tỷ lệ chiều rộng và chiều cao riêng cho phạm vi đã chọn, bảo toàn tỷ lệ tương đối của các cột và hàng. Nó chuyển đổi các kích thước đã tính từ điểm sang inch trước khi áp dụng bằng [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) và [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch). Phạm vi đã chọn phải có chiều rộng và chiều cao khác 0.

```php
use aspose\cells\CellsUnitType;

// Chiều rộng và chiều cao là kích thước mong muốn của phạm vi ô tính bằng điểm.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

Trợ giúp xem trước này render phạm vi đã thay đổi kích thước bằng [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage). Nó giới hạn [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) ở phạm vi đó, loại bỏ lề, tiêu đề và chân trang, và trả về một luồng PNG đặt con trỏ ở đầu.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **Kết luận**

{{% alert color="info" title="Note" %}}
Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước bảng tính. Hãy chọn cách tiếp cận phù hợp nhất với yêu cầu và trường hợp sử dụng của bạn. Cả hai cách đều hoạt động tương tự, bất kể bản trình chiếu được tạo từ mẫu hay tạo mới. Ngoài ra, không có giới hạn về kích thước khung OLE trong giải pháp này.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tại sao một bảng tính Excel được nhúng lại thay đổi kích thước khi lần đầu được kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng giữ kích thước cửa sổ gốc khi được kích hoạt, trong khi khung OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỷ lệ khung hình, dẫn tới việc thay đổi kích thước.

**Liệu có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?**

Có. Bằng cách thu phóng khung OLE để vừa với kích thước phạm vi ô Excel hoặc thu phóng phạm vi ô để vừa với kích thước khung OLE mong muốn, bạn có thể ngăn việc thay đổi kích thước không mong muốn.

**Nên sử dụng phương pháp thu phóng nào, thu phóng khung OLE hay thu phóng phạm vi ô?**

Chọn **thu phóng khung OLE** nếu bạn muốn giữ nguyên kích thước hàng và cột gốc của Excel. Chọn **thu phóng phạm vi ô** nếu bạn muốn kích thước khung OLE cố định trong bản trình chiếu.

**Các giải pháp này có hoạt động nếu bản trình chiếu của tôi dựa trên một mẫu không?**

Có. Cả hai giải pháp đều hoạt động cho bản trình chiếu được tạo từ mẫu và từ đầu.

**Có giới hạn nào về kích thước khung OLE khi sử dụng các phương pháp này không?**

Không. Bạn có thể đặt khung OLE ở bất kỳ kích thước nào miễn là bạn thiết lập tỷ lệ thích hợp.

**Có cách nào tránh văn bản placeholder “EMBEDDED OLE OBJECT” trong PowerPoint không?**

Có. Bằng cách chụp ảnh phạm vi ô Excel mục tiêu và đặt nó làm ảnh placeholder cho khung OLE, bạn có thể hiển thị ảnh xem trước tùy chỉnh thay cho placeholder mặc định.

## **Bài viết liên quan**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/vi/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/vi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)