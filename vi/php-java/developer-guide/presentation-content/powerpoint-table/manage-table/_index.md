---
title: Quản lý bảng trình chiếu trong PHP
linktitle: Quản lý Bảng
type: docs
weight: 10
url: /vi/php-java/manage-table/
keywords:
- thêm bảng
- tạo bảng
- truy cập bảng
- tỷ lệ khung hình
- căn chỉnh văn bản
- định dạng văn bản
- kiểu bảng
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tạo và chỉnh sửa bảng trong các slide PowerPoint bằng Aspose.Slides cho PHP thông qua Java. Khám phá các ví dụ mã đơn giản để tối ưu hóa quy trình làm việc với bảng."
---
## **Giới thiệu**

Bảng trong PowerPoint sắp xếp thông tin thành các hàng và cột, giúp dễ dàng đọc và so sánh các giá trị.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) , lớp [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) , và các loại khác cho phép bạn tạo, cập nhật và quản lý các bảng trong bản trình bày.

## **Tạo bảng từ đầu**

Tạo một bảng bằng cách chỉ định vị trí, chiều rộng các cột và chiều cao các hàng. Sau khi thêm nó vào một slide, bạn có thể định dạng viền ô, hợp nhất các ô và chèn văn bản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Xác định một mảng các chiều rộng cột tính bằng point.
4. Xác định một mảng các chiều cao hàng tính bằng point.
5. Thêm một đối tượng [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) .
6. Duyệt qua từng [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) để áp dụng định dạng cho các viền trên, dưới, phải và trái.
7. Hợp nhất hai ô đầu tiên của hàng đầu tiên của bảng.
8. Truy cập ô đã hợp nhất thông qua phương thức [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) .
9. Đặt văn bản vào ô đã hợp nhất.
10. Lưu bản trình bày đã chỉnh sửa.

Ví dụ dưới đây tạo một bảng với ba cột và năm hàng tại (100, 50) point. Nó áp dụng viền màu đỏ với độ rộng 5 point, hợp nhất hai ô đầu tiên ở hàng đầu tiên, và lưu kết quả dưới tên `table.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đánh số trong bảng chuẩn**

Trong một bảng chuẩn, chỉ số ô bắt đầu từ 0 và sử dụng thứ tự (cột, hàng). Ô đầu tiên có chỉ số (0, 0).

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ví dụ này tạo bảng 4 × 4 như minh họa ở trên, với chiều rộng cột và chiều cao hàng là 70 point và viền ô màu đỏ với độ rộng 5 point. Các tọa độ minh họa chỉ số ô; ví dụ để các ô trống và lưu bảng dưới tên `StandardTables_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Truy cập bảng hiện có**

Các bảng được lưu trong bộ sưu tập shape của slide. Duyệt qua các shape để tìm bảng, sau đó sử dụng lớp [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) để đọc hoặc cập nhật các ô của nó.

1. Tải bản trình bày bằng cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide chứa bảng theo chỉ mục của nó.
3. Duyệt qua các đối tượng [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) , và dừng khi tìm thấy một bảng. Nếu slide chứa nhiều bảng, sử dụng [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) để xác định bảng bạn cần.
4. Cập nhật văn bản trong ô mục tiêu.
5. Lưu bản trình bày đã chỉnh sửa.

Ví dụ dưới đây mở `UpdateExistingTable.pptx` và tìm bảng đầu tiên trên slide đầu tiên. Nó đặt ô tại cột 0, hàng 1 thành `New` và lưu kết quả dưới tên `table1_out.pptx`. Tệp đầu vào phải chứa ít nhất một slide, và bảng đầu tiên trên slide đó phải có ít nhất một cột và hai hàng.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Để thay đổi kích thước hàng trong một bảng hiện có và hiểu tại sao chiều cao thực tế có thể vượt quá mức tối thiểu được yêu cầu, xem [Kiểm soát chiều cao hàng](/slides/vi/php-java/manage-rows-and-columns/#control-row-height).

## **Tìm ô sở hữu Text Frame**

Khi mã xử lý văn bản chung nhận được một [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) từ một bảng, sử dụng phương thức [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) để lấy [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) sở hữu. Đối với khung văn bản trong ô bảng, [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) trả về chủ sở hữu và [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) trả về `null`, mặc dù bảng tự thân là một shape.

Các tọa độ ô có thể truy cập qua các phương thức chỉ đọc [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) và [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) . [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) cũng cung cấp khả năng điều hướng chỉ đọc: nó trả về chủ sở hữu nhưng không thay đổi quyền sở hữu. Luôn kiểm tra ô trả về bằng `java_is_null` trước khi sử dụng.

Đối với một ví dụ đầy đủ xác định chủ sở hữu ô bảng và shape, bao gồm các shape liên quan đến nút SmartArt, xem [Tìm kiếm và thay thế văn bản](/slides/vi/php-java/search-and-replace-text/).

## **Căn chỉnh văn bản trong bảng**

Bạn có thể kiểm soát việc neo dọc và hướng văn bản của từng ô bảng. Ví dụ trong phần này căn giữa văn bản trong ô đầu tiên và quay nó 270 độ.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide theo chỉ mục.
3. Thêm một đối tượng [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) vào slide.
4. Truy cập một đối tượng [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) từ bảng.
5. Truy cập [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) đầu tiên và đặt văn bản và màu của nó.
6. Đặt neo dọc của ô và hướng văn bản bằng cách sử dụng [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) và [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/) .
7. Lưu bản trình bày đã chỉnh sửa.

Ví dụ này tạo một bảng 4 × 4 với chiều rộng cột 120 point và chiều cao hàng 100 point. Nó định dạng văn bản trong ô (0, 0), thêm các giá trị vào các ô còn lại trong hàng đầu tiên, và lưu kết quả dưới tên `Vertical_Align_Text_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt định dạng văn bản ở mức bảng**

Sử dụng [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) để áp dụng định dạng văn bản cho tất cả các ô trong một bảng. Các overload của nó chấp nhận định dạng phần, đoạn và khung văn bản, vì vậy bạn có thể đặt các thuộc tính này mà không cần duyệt qua từng ô.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide theo chỉ mục.
3. Truy cập một đối tượng [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) từ slide.
4. Đặt kích thước phông chữ bằng [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) cho văn bản.
5. Đặt căn chỉnh đoạn và lề phải bằng [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) và [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) .
6. Đặt hướng văn bản bằng [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) .
7. Lưu bản trình bày đã chỉnh sửa.

Ví dụ dưới đây mở `table.pptx`, tệp này phải chứa ít nhất một slide với một bảng là shape đầu tiên. Nó đặt kích thước phông chữ là 25 point, căn phải các đoạn với lề phải 20 point, và đặt văn bản theo chiều dọc. Bản trình bày đã định dạng được lưu dưới tên `result.pptx`.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lấy thuộc tính kiểu bảng**

Sử dụng [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) để đọc kiểu mẫu đã định trước của bảng và [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) để gán nó. Ví dụ này áp dụng [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) cho một bảng, in giá trị mẫu, và gán cùng một mẫu cho bảng thứ hai. Cả hai bảng đều được lưu trong `table-style.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Khóa tỷ lệ khung hình của bảng**

Tỷ lệ khung hình của bảng là tỉ lệ giữa chiều rộng và chiều cao của nó. Sử dụng [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) để khóa tỉ lệ này cho một bảng.

Ví dụ dưới đây mở `pres.pptx`, tệp này phải chứa ít nhất một slide với một bảng là shape đầu tiên. Nó in trạng thái khoá hiện tại, bật khóa tỷ lệ khung hình, in trạng thái đã cập nhật (`true`), và lưu kết quả dưới tên `pres-out.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể bật hướng đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Có. Bảng cung cấp phương thức [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) , và các đoạn có [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/) . Sử dụng cả hai đảm bảo thứ tự RTL đúng và việc hiển thị bên trong các ô.

**Làm thế nào để ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong tệp cuối cùng?**

Sử dụng [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) để vô hiệu hoá việc di chuyển, thay đổi kích thước, chọn, v.v. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn hình ảnh vào ô làm nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) cho ô; hình ảnh sẽ bao phủ toàn bộ khu vực ô theo chế độ đã chọn (kéo dài hoặc lát).