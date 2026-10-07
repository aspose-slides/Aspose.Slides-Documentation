---
title: Quản lý các ô bảng trong bản trình chiếu bằng PHP
linktitle: Quản lý ô
type: docs
weight: 30
url: /vi/php-java/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Quản lý các ô bảng PowerPoint trong PHP: xác định các ô đã hợp nhất, xóa viền, tách ô, và thiết lập màu nền cùng hình ảnh với Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và chỉnh sửa các ô bảng trong bản trình chiếu PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa viền ô, làm việc với đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô, và chèn hình ảnh vào trong một ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình chiếu, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính ô, và lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ mục bắt đầu từ 0 để truy cập các ô bảng theo thứ tự `(column, row)`.

## **Xác định ô bảng đã hợp nhất**

Ví dụ mở một bản trình chiếu hiện có và truy cập shape đầu tiên trên slide đầu tiên như một bảng. Giả sử slide và shape tồn tại và shape là một bảng. Sau đó vòng lặp qua tất cả các hàng và cột và sử dụng [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) để xác định các ô trong vùng đã hợp nhất. Đối với mỗi kết quả khớp, nó in tọa độ ô theo thứ tự `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), và tọa độ bắt đầu của vùng, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) và [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Xóa viền ô bảng**

Tạo một [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) và thêm một bảng vào slide đầu tiên của nó bằng [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Độ rộng cột, chiều cao hàng và vị trí bảng được chỉ định bằng điểm. Ví dụ đặt tất cả bốn viền ô thành [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), khiến chúng trở nên vô hình.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hợp nhất các ô bảng**

Sử dụng [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) để kết hợp một phạm vi hình chữ nhật của các ô bảng thành một ô. Xác định các ô ở góc trên‑trái và góc dưới‑phải của phạm vi. Đối số cuối cùng kiểm soát việc hợp nhất có thể bao gồm các ô ngoài phạm vi đã chỉ định hay không; `false` giữ hợp nhất trong phạm vi đó.

Ví dụ tạo một bảng 4x4 với các cột và hàng có độ rộng/chiều cao 70 điểm, sau đó hợp nhất bốn ô trung tâm từ `(1, 1)` đến `(2, 2)`. Ô kết quả chiếm hai cột và hai hàng, trong khi lưới cơ bản của bảng vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã hợp nhất, sử dụng vị trí trên‑trái của nó: `$table->get_Item(1, 1)` trong ví dụ này. Các vị trí khác trong phạm vi hợp nhất vẫn là một phần của lưới bảng, vì vậy chỉ mục của các ô ngoài phạm vi không thay đổi.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tách các ô bảng**

Việc hợp nhất các ô trong ví dụ trước giữ nguyên lưới bảng. Tách một ô có thể tạo thêm một cột lưới mới và thay đổi chỉ mục cột của các ô ở phía bên phải. Aspose.Slides tuân theo mô hình lưới bảng của PowerPoint.

Ví dụ này tạo một bảng 4x4 với các cột và hàng 70 điểm và gọi [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) trên ô `(1, 1)`. Một nửa độ rộng 70 điểm của ô được truyền vào để tạo hai ô có độ rộng bằng nhau.

Sau khi tách, hai nửa được truy cập dưới dạng `$table->get_Item(1, 1)` và `$table->get_Item(2, 1)`. Lưới bảng bây giờ có năm cột: các ô ban đầu ở cột 2 và 3 di chuyển đến cột 3 và 4, tương ứng. Chỉ mục hàng giữ nguyên. Sử dụng các chỉ mục cột đã cập nhật khi truy cập các ô sau khi tách.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Tách các ô đã hợp nhất theo chiều hàng hoặc cột**

Để chuẩn bị các ô mẫu đã hợp nhất cho việc điền dữ liệu, sử dụng [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) để tách dọc theo ranh giới hàng hiện có, hoặc [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) để tách dọc theo ranh giới cột.

Tham số `index` đếm số hàng ở phần trên hoặc số cột ở phần trái của phần tách; nó tương đối với vùng đã hợp nhất:

- Tách hàng: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Tách cột: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Ví dụ giả định bản trình chiếu có một bảng là shape đầu tiên trên slide đầu tiên, với các ô `(1, 2)` và `(1, 3)` hợp nhất theo chiều dọc. Bắt đầu từ vị trí dưới, nó sử dụng [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) và [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) để xác định nguồn gốc và kiểm tra cả hai span. `splitByRowSpan(1)` sau đó tách các hàng 2 và 3 cho tên sản phẩm. Đối với một hợp nhất ngang gồm hai cột, sử dụng `splitByColSpan(1)` thay thế.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // Lấy các ô kết quả từ bảng sau khi tách.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Lưới bảng và các chỉ mục ô xung quanh vẫn không thay đổi. Lấy các ô kết quả bằng tọa độ của chúng; ở đây, cả hai đều có span bằng 1 và [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) in ra `false`. Các vùng lớn hơn có thể vẫn còn một phần hợp nhất sau một lần tách.

Văn bản gốc và định dạng của nó vẫn ở ô trên (hoặc bên trái); ô mới rỗng nhưng kế thừa định dạng ô như màu nền, viền và khoảng lề. Điền dữ liệu vào các ô sau khi tách và đặt bất kỳ định dạng văn bản nào cần thiết một cách rõ ràng.

Bản trình chiếu đã lưu chứa các ô riêng biệt "Product A" và "Product B" với định dạng ô của mẫu được giữ lại. Xem [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) để biết chi tiết.

## **Thay đổi màu nền ô bảng**

Ví dụ này tạo một bảng với các cột 150 điểm và các hàng 50 điểm. Nó sử dụng [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) để chọn một màu nền đặc và đặt màu trả về bởi [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) thành màu đỏ cho ô `(2, 3)`, ở cột thứ ba và hàng thứ tư.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Thêm hình ảnh vào bên trong ô bảng**

Đặt hình ảnh đầu vào trong thư mục làm việc trước khi chạy ví dụ này. Nó tải hình ảnh bằng [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) và thêm nó vào bộ sưu tập hình ảnh của bản trình chiếu bằng [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Sau đó nó gán hình ảnh vào nền hình ảnh của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) kéo dài hình ảnh để lấp đầy ô, có thể thay đổi tỷ lệ khung hình của nó. Độ rộng cột và chiều cao hàng được tính bằng điểm. Hình ảnh đã tải sẽ được giải phóng trong khối `finally` sau khi nó được thêm vào bản trình chiếu.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Có thể đặt độ dày và kiểu đường viền khác nhau cho từng phía của một ô duy nhất không?**

Đúng. Các viền [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi phía có thể khác nhau.

**Điều gì sẽ xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đã đặt hình ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/). Khi kéo dài, hình ảnh sẽ điều chỉnh theo ô mới; khi lặp (tile), các ô lặp sẽ được tính lại.

**Có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/php-java/manage-hyperlinks/) được đặt ở mức độ văn bản (phần) bên trong khung văn bản của ô hoặc ở mức độ toàn bộ bảng/shape. Trong thực tế, bạn gán liên kết cho một phần hoặc cho toàn bộ văn bản trong ô.

**Có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Đúng. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (các đoạn) với định dạng độc lập—gia đình phông chữ, kiểu, kích thước và màu.