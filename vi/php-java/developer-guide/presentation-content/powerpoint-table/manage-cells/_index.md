---
title: Quản lý các ô bảng trong bản trình bày bằng PHP
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
- bản trình bày
- PHP
- Aspose.Slides
description: "Quản lý các ô bảng PowerPoint trong PHP: xác định ô đã hợp nhất, xóa viền, tách ô, và thiết lập màu nền và hình ảnh bằng Aspose.Slides cho PHP thông qua Java."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và chỉnh sửa các ô bảng trong bản trình bày PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa viền ô, làm việc với việc đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô, và chèn hình ảnh bên trong một ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình bày, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính của ô, và lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ số bắt đầu từ 0 để truy cập các ô bảng theo thứ tự `(column, row)`.

## **Xác định ô bảng đã hợp nhất**

Ví dụ mở một bản trình bày hiện có và truy cập hình dạng đầu tiên trên slide đầu tiên như một bảng. Nó giả định rằng slide và hình dạng tồn tại và hình dạng là một bảng. Sau đó nó lặp qua tất cả các hàng và cột và sử dụng [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) để xác định các ô trong vùng đã hợp nhất. Đối với mỗi kết quả, nó in tọa độ ô theo thứ tự `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), và tọa độ bắt đầu của vùng, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) và [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

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

## **Thêm viền chéo cho ô**

Sử dụng [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) để vẽ một đường từ góc trên‑trái đến góc dưới‑phải, và [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) để vẽ một đường từ góc dưới‑trái đến góc trên‑phải. Một đường chéo có thể đánh dấu tiêu đề góc; cả hai đường chéo có thể tạo thành chữ X để đánh dấu ô không áp dụng.

Mỗi đường chéo có [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) riêng. Trong [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) của nó, dùng [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) để chọn [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) và chọn màu qua [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/). Đặt độ rộng của đường bằng điểm với [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/).

Ví dụ tạo ba ô trong một hàng: một đường chéo đỏ đi xuống, một đường chéo xanh đi lên, và cả hai đường chéo. Nó để nguyên các viền trên, dưới, trái và phải của ô.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Một đường chéo chỉ thay đổi định dạng ô. Mỗi ô vẫn giữ một khung văn bản đơn, truy cập qua [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/). Các vùng ở hai bên của đường chéo không thể chỉnh sửa độc lập.

Bảng đã lưu, hiển thị trong Microsoft PowerPoint:

![Ba ô bảng hiển thị một đường chéo màu đỏ từ trên‑trái đến dưới‑phải, một đường chéo màu xanh từ dưới‑trái đến trên‑phải, và cả hai đường chéo tạo thành chữ X.](diagonal-cell-borders.png)

*Trái sang phải: đường chéo xuống (đỏ, 3 pt), đường chéo lên (xanh, 5 pt), và cả hai đường chéo.*

## **Hợp nhất các ô bảng**

Sử dụng [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) để kết hợp một phạm vi hình chữ nhật của các ô bảng thành một ô. Xác định các ô ở góc trên‑trái và góc dưới‑phải của phạm vi. Đối số cuối cùng điều khiển việc hợp nhất có thể bao gồm các ô ngoài phạm vi đã chỉ định; `false` giữ hợp nhất trong phạm vi đó.

Ví dụ tạo một bảng 4×4 với các cột và hàng có độ rộng/chiều cao 70 điểm, sau đó hợp nhất bốn ô trung tâm từ `(1, 1)` tới `(2, 2)`. Ô kết quả kéo dài qua hai cột và hai hàng, trong khi lưới nền của bảng vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã hợp nhất, dùng vị trí trên‑trái của nó: `$table->get_Item(1, 1)` trong ví dụ này. Các vị trí khác trong phạm vi hợp nhất vẫn là một phần của lưới bảng, vì vậy chỉ số của các ô ngoài phạm vi không thay đổi.

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

Kết hợp các ô trong ví dụ trước giữ nguyên lưới bảng. Tách một ô có thể tạo thêm một cột lưới mới và thay đổi chỉ số cột của các ô bên phải nó. Aspose.Slides tuân theo mô hình lưới bảng của PowerPoint.

Ví dụ này tạo một bảng 4×4 với các cột và hàng 70 điểm và gọi [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) trên ô `(1, 1)`. Một nửa chiều rộng 70 điểm của ô được truyền vào để tạo hai ô có độ rộng bằng nhau.

Sau khi tách, hai nửa được truy cập dưới dạng `$table->get_Item(1, 1)` và `$table->get_Item(2, 1)`. Lưới bảng bây giờ có năm cột: các ô ban đầu ở cột 2 và 3 di chuyển tới cột 3 và 4, tương ứng. Chỉ số hàng không thay đổi. Sử dụng các chỉ số cột đã cập nhật khi truy cập ô sau khi tách.

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


<!-- visual-explanation:manage-cells:start -->
[![Một ô 70 điểm chưa hợp nhất được tách thành hai ô 35 điểm, thêm một cột lưới thứ năm và dịch các chỉ số sang bên phải.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Việc tách chiều rộng ảnh hưởng đến ô (1, 1), sử dụng chỉ số bắt đầu từ 0 (cột, hàng). Các hàng khác giữ một ô kéo dài qua cả hai vị trí cột mới.*
<!-- visual-explanation:manage-cells:end -->

### **Tách các ô đã hợp nhất theo dòng hoặc cột**

Để chuẩn bị các ô mẫu đã hợp nhất cho việc điền dữ liệu, sử dụng [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) để tách theo ranh giới dòng hiện có, hoặc [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) để tách theo ranh giới cột.

Tham số `index` đếm các dòng ở phần trên hoặc các cột ở phần trái của phần tách; nó tương đối với vùng đã hợp nhất:

- Tách dòng: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Tách cột: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Ví dụ giả định một bản trình bày có một bảng là hình dạng đầu tiên trên slide đầu tiên, với ô `(1, 2)` và `(1, 3)` hợp nhất theo chiều dọc. Bắt đầu từ vị trí dưới, nó dùng [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) và [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) để xác định nguồn gốc và kiểm tra cả hai phạm vi. `splitByRowSpan(1)` sau đó tách các dòng 2 và 3 cho tên sản phẩm. Đối với một hợp nhất ngang hai cột, dùng `splitByColSpan(1)` thay thế.

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

Lưới bảng và các chỉ số ô xung quanh vẫn không thay đổi. Lấy các ô kết quả theo tọa độ của chúng; ở đây, cả hai đều có phạm vi 1 và [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) trả về `false`. Các vùng lớn hơn có thể vẫn còn một phần hợp nhất sau một lần tách.

Văn bản gốc và định dạng của nó vẫn ở ô trên (hoặc trái); ô mới trống nhưng kế thừa định dạng ô như màu nền, viền và lề. Điền nội dung vào các ô sau khi tách và đặt bất kỳ định dạng văn bản nào cần thiết một cách rõ ràng.

Bản trình bày đã lưu chứa các ô “Product A” và “Product B” riêng biệt với định dạng ô của mẫu được giữ nguyên. Xem [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) để biết chi tiết.

### **Tách một ô ở chiều cao nhất định**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) nhận chiều cao của phần trên bằng điểm. [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) nhận số hàng lưới hiện có ở phần trên. Để căn giữa một ô 40 điểm trong cột bên phải, lấy chiều cao thực tế của ô trừ 40 và chia phần còn lại đều lên trên và dưới ô.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Lần tách đầu tiên thêm một hàng lưới và để lại 90 điểm ở ô `(1, 1)`. Lần tách thứ hai chia ô đó thành một ô trung tâm 40 điểm và một ô dưới 50 điểm. Cột bên phải bây giờ có ba ô với chiều cao lần lượt là 50, 40 và 50 điểm từ trên xuống dưới. Ô bên trái kéo dài qua cả ba hàng và giữ nguyên chiều cao gốc 140 điểm.

![Ô bên trái kéo dài toàn bộ chiều cao bảng bên cạnh ba ô với phần ở giữa ở trung tâm.](split-by-height.png)

## **Thay đổi màu nền của ô bảng**

Ví dụ này tạo một bảng với các cột 150 điểm và các hàng 50 điểm. Nó dùng [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) để chọn màu nền đặc và đặt màu trả về bởi [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) thành màu đỏ cho ô `(2, 3)`, ở cột thứ ba và hàng thứ tư.

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

Đặt ảnh đầu vào trong thư mục làm việc trước khi chạy ví dụ này. Nó tải ảnh bằng [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) và thêm nó vào bộ sưu tập ảnh của bản trình bày bằng [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Sau đó gán ảnh vào phần fill hình ảnh của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) kéo dài ảnh để lấp đầy ô, có thể làm thay đổi tỷ lệ khung hình. Độ rộng cột và chiều cao hàng được tính bằng điểm. Ảnh đã tải sẽ được giải phóng trong khối `finally` sau khi được thêm vào bản trình bày.

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

**Tôi có thể đặt độ dày và kiểu đường viền khác nhau cho các cạnh của một ô duy nhất không?**

Có. Các viền [trên](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/), [dưới](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/), [trái](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/), [phải](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) có thuộc tính riêng, vì vậy độ dày và kiểu của mỗi cạnh có thể khác nhau.

**Điều gì xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đặt ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Khi kéo dài, ảnh sẽ điều chỉnh theo ô mới; khi lát, các viên gạch sẽ được tính lại.

**Tôi có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/php-java/manage-hyperlinks/) được đặt ở mức đoạn văn bản (portion) bên trong khung văn bản của ô hoặc ở mức toàn bộ bảng/hình dạng. Thực tế, bạn gán liên kết cho một đoạn hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt các phông chữ khác nhau trong một ô không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (run) với định dạng độc lập—gia đình phông, kiểu, kích thước và màu.