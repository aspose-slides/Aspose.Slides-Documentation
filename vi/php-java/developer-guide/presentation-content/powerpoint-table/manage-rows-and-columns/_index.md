---
title: Quản lý hàng và cột trong bảng PowerPoint bằng PHP
linktitle: Hàng và Cột
type: docs
weight: 20
url: /vi/php-java/manage-rows-and-columns/
keywords:
- hàng bảng
- cột bảng
- hàng đầu tiên
- đầu đề bảng
- nhân bản hàng
- nhân bản cột
- sao chép hàng
- sao chép cột
- xóa hàng
- xóa cột
- định dạng văn bản hàng
- định dạng văn bản cột
- kiểu bảng
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Quản lý các hàng và cột của bảng trong PowerPoint với Aspose.Slides for PHP qua Java, giúp tăng tốc việc chỉnh sửa bản trình chiếu và cập nhật dữ liệu."
---
## **Giới thiệu**

Aspose.Slides for PHP via Java cho phép bạn quản lý cấu trúc và định dạng bảng trong các bản trình chiếu PowerPoint thông qua lớp [Bảng](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Bạn có thể chỉ định một hàng tiêu đề, sao chép hoặc xóa các hàng và cột, và áp dụng định dạng văn bản cho toàn bộ hàng hoặc cột.

Bài viết này giải thích các thao tác này bằng các ví dụ PHP. Nó cũng cho thấy cách lấy trước mẫu kiểu bảng để bạn có thể tái sử dụng. Các chỉ số hàng và cột của bảng bắt đầu từ 0.

## **Kiểm soát chiều cao hàng**

Sử dụng [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) để đặt chiều cao tối thiểu của một hàng tính bằng điểm. Đây là giới hạn dưới, không phải chiều cao cố định. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) trả về chiều cao thực tế. Truy cập hàng thông qua [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

Ví dụ tải [row-height-input.pptx](row-height-input.pptx), trong đó có một bảng là hình dạng đầu tiên trên slide đầu tiên. Hàng đầu tiên bắt đầu ở 70 điểm. Các ô sử dụng văn bản Arial 18 điểm, có ngắt dòng và lề trên dưới 6 điểm; văn bản dài hơn ở cột thứ hai ngắt dòng thành nhiều dòng. Ví dụ tăng tối thiểu lên 100 điểm, sau đó giảm xuống 20 điểm, in ra chiều cao thực tế sau mỗi thay đổi và lưu cả hai kết quả.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Với bản trình chiếu được cung cấp, tăng tối thiểu sẽ thêm không gian vào hàng. Giảm tối thiểu sẽ loại bỏ không gian thêm đó, nhưng chiều cao thực tế vẫn lớn hơn 20 điểm vì văn bản và lề ô cần nhiều không gian hơn. Chỉ giảm tối thiểu không thể ép hàng xuống dưới mức không gian cần thiết cho nội dung của nó.

Một số yếu tố ảnh hưởng đến chiều cao thực tế:

- **Văn bản và kích thước phông chữ:** văn bản dài hơn, ngắt dòng rõ ràng hoặc phông chữ lớn hơn có thể yêu cầu nhiều không gian dọc hơn.
- **Việc ngắt dòng và độ rộng cột:** khi bật ngắt dòng, giảm độ rộng cột bằng [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) có thể tạo ra nhiều dòng hơn. Cột rộng hơn có thể giảm không gian cần thiết theo chiều dọc.
- **Lề ô:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) và [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) thêm không gian dọc. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) và [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) giảm độ rộng có sẵn cho văn bản và có thể gây ra việc ngắt dòng thêm.

Đối với bảng này không có ô hợp nhất, ô cần nhiều không gian dọc nhất sẽ xác định giới hạn dưới do nội dung quyết định cho toàn bộ hàng. Để làm hàng ngắn hơn, bạn cũng có thể cần rút ngắn văn bản, giảm kích thước phông chữ hoặc lề, hoặc làm rộng một cột.

Các hình ảnh dưới đây cho thấy cùng một bảng ở cùng tỉ lệ. Trong các kết quả minh họa, chiều cao thực tế là 70, 100 và 55,2 điểm: hàng cuối vẫn cao hơn mức tối thiểu 20 điểm. Các đo lường văn bản chính xác có thể thay đổi tùy vào phông chữ có trong môi trường của bạn. Tải các kết quả đã lưu: [tối thiểu tăng](row-height-increased.pptx) và [tối thiểu giảm](row-height-decreased.pptx).

| Ban đầu: tối thiểu 70 pt, thực tế 70 pt | Tăng: tối thiểu 100 pt, thực tế 100 pt | Giảm: tối thiểu 20 pt, thực tế 55.2 pt |
| --- | --- | --- |
| ![Bảng gốc với hàng đầu tiên 70 điểm.](row-height-before.png) | ![Bảng sau khi tăng tối thiểu của hàng đầu tiên lên 100 điểm.](row-height-increased.png) | ![Bảng sau khi giảm tối thiểu của hàng đầu tiên xuống 20 điểm; văn bản ngắt dòng giữ cho hàng cao hơn mức tối thiểu.](row-height-decreased.png) |

## **Đặt hàng đầu tiên làm tiêu đề**

Sử dụng phương thức [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) để đánh dấu hàng đầu tiên cho định dạng tiêu đề. Hiển thị của nó phụ thuộc vào kiểu bảng được áp dụng cho bảng.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Truy cập bảng được lưu dưới dạng hình dạng đầu tiên trên slide.
4. Bật định dạng tiêu đề cho hàng đầu tiên của nó.
5. Lưu bản trình chiếu đã sửa đổi.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên. Nó bật định dạng tiêu đề cho hàng đầu tiên và lưu `First_row_header.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sao chép hàng hoặc cột của bảng**

Sao chép các hàng hoặc cột để tái sử dụng nội dung và định dạng của chúng. Bạn có thể thêm bản sao vào cuối bảng hoặc chèn vào vị trí cụ thể.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Xác định độ rộng cột và chiều cao hàng.
4. Thêm một bảng bằng phương thức [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Sao chép các hàng cần thiết.
6. Sao chép các cột cần thiết.
7. Lưu bản trình chiếu đã sửa đổi.

Ví dụ yêu cầu `Test.pptx` có ít nhất một slide. Nó tạo một bảng có ba cột và năm hàng, với kích thước được chỉ định bằng điểm. Nó thêm bản sao của hàng và cột đầu tiên, sau đó chèn bản sao của hàng và cột thứ hai tại chỉ số 3 (vị trí thứ tư). Bảng kết quả có bảy hàng và năm cột. Tham số `false` vô hiệu hoá việc sao chép vào các hàng hoặc cột hợp nhất liền kề; bảng này không có ô hợp nhất.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Xóa một hàng hoặc cột khỏi bảng**

Xóa các hàng hoặc cột không còn cần thiết trong bảng. Khi xóa một mục, các chỉ số của các hàng hoặc cột phía sau sẽ được dịch chuyển.

1. Tạo một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Xác định độ rộng cột và chiều cao hàng.
4. Thêm một bảng bằng phương thức [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Xóa hàng thứ hai và cột thứ hai.
6. Lưu bản trình chiếu đã sửa đổi.

Ví dụ này tạo một bảng ba‑by‑ba và xóa hàng và cột tại chỉ số 1, để lại một bảng hai‑by‑hai trong `TestTable_out.pptx`. Các kích thước tính bằng điểm. Tham số `false` vô hiệu hoá việc xóa các hàng hoặc cột hợp nhất liền kề; bảng này không có ô hợp nhất.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt định dạng văn bản ở mức hàng của bảng**

Áp dụng định dạng văn bản cho toàn bộ hàng để giữ cho các ô của nó nhất quán. Bạn có thể thiết lập thuộc tính phông chữ, định dạng đoạn văn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Sử dụng [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) cho hàng đầu tiên.
4. Sử dụng [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) và [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) cho hàng đầu tiên.
5. Sử dụng [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) cho hàng thứ hai.
6. Lưu bản trình chiếu đã sửa đổi.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên và ít nhất hai hàng. Nó áp dụng văn bản 25‑point, căn phải và lề đoạn văn phải 20‑point cho hàng đầu tiên, sau đó đặt văn bản dọc cho hàng thứ hai.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt định dạng văn bản ở mức cột của bảng**

Áp dụng định dạng văn bản cho toàn bộ cột để giữ cho các ô của nó nhất quán. Bạn có thể thiết lập thuộc tính phông chữ, định dạng đoạn văn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Sử dụng [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) cho cột đầu tiên.
4. Sử dụng [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) và [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) cho cột đầu tiên.
5. Sử dụng [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) cho cột thứ hai.
6. Lưu bản trình chiếu đã sửa đổi.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên và ít nhất hai cột. Nó áp dụng văn bản 25‑point, căn phải và lề đoạn văn phải 20‑point cho cột đầu tiên, sau đó đặt văn bản dọc cho cột thứ hai.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lấy thuộc tính kiểu bảng**

Sử dụng phương thức [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) để lấy trước mẫu kiểu đã áp dụng cho một bảng và tái sử dụng nó trên bảng khác. Điều này xác định trước mẫu thay vì các ghi đè định dạng ô riêng lẻ.

Ví dụ tạo một bảng, áp dụng [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1), và đọc lại trước mẫu. Nó in ra giá trị số nguyên tương ứng với `DarkStyle1` và lưu bảng trong `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng giao diện/kiểu mẫu PowerPoint cho một bảng đã được tạo không?**

Có. Bảng kế thừa giao diện slide/bố cục/mảnh, và bạn vẫn có thể ghi đè các màu nền, viền và màu văn bản phía trên giao diện đó.

**Tôi có thể sắp xếp các hàng của bảng giống như trong Excel không?**

Không, các bảng Aspose.Slides không có tính năng sắp xếp hoặc bộ lọc tích hợp. Hãy sắp xếp dữ liệu trong bộ nhớ trước, sau đó điền lại các hàng bảng theo thứ tự đó.

**Tôi có thể có các cột có dải (kẻ sọc) trong khi vẫn giữ màu tùy chỉnh cho các ô cụ thể không?**

Có. Bật chế độ cột có dải, sau đó ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng ở mức ô sẽ ưu tiên hơn kiểu bảng.