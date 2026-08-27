---
title: Quản lý Bảng trong Bản Trình Bày bằng PHP
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
- phong cách bảng
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tạo & chỉnh sửa bảng trong slide PowerPoint với Aspose.Slides cho PHP qua Java. Khám phá các ví dụ mã đơn giản để tối ưu hoá quy trình làm việc với bảng."
---
## **Giới thiệu**

Bảng trong PowerPoint là một cách hiệu quả để hiển thị và trình bày thông tin. Thông tin trong lưới các ô (được sắp xếp theo hàng và cột) rõ ràng và dễ hiểu.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Table) , lớp [Cell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cell/) và các kiểu khác để cho phép bạn tạo, cập nhật và quản lý các bảng trong mọi loại bản trình bày.

## **Tạo bảng từ đầu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó. 
3. Xác định một mảng `columnWidth`.
4. Xác định một mảng `rowHeight`.
5. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/table/) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addtable/).
6. Lặp qua từng [Cell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cell/) để áp dụng định dạng cho các viền trên, dưới, phải và trái.
7. Hợp nhất hai ô đầu tiên của hàng đầu tiên trong bảng. 
8. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) của một [Cell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cell/).
9. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/).
10. Lưu bản trình bày đã sửa đổi.

Mã PHP này cho bạn thấy cách tạo bảng trong một bản trình bày:

```php
  # Khởi tạo một lớp Presentation đại diện cho tệp PPTX file
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Định nghĩa các cột với độ rộng và các hàng với chiều cao
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Thêm một shape bảng vào slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Đặt định dạng viền cho mỗi ô
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # Hợp nhất các ô 1 và 2 của hàng 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Thêm một số văn bản vào ô đã hợp nhất
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Lưu bản trình bày vào đĩa
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đánh số trong bảng tiêu chuẩn**

Trong một bảng tiêu chuẩn, việc đánh số các ô là đơn giản và bắt đầu từ 0. Ô đầu tiên trong bảng có chỉ mục là 0,0 (cột 0, hàng 0). 

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Mã PHP này cho bạn thấy cách chỉ định đánh số cho các ô trong một bảng:

```php
  # Khởi tạo một lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Truy cập slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Định nghĩa các cột với độ rộng và các hàng với chiều cao
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Thêm một shape bảng vào slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Đặt định dạng viền cho mỗi ô
    $rows = $tbl->getRows();
    foreach($rows as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Lưu bản trình bày vào đĩa
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Truy cập bảng hiện có**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu tới slide chứa bảng thông qua chỉ mục của nó. 
3. Tạo một đối tượng [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Table) và đặt nó thành null.
4. Lặp qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) cho đến khi tìm thấy bảng.

   Nếu bạn nghi ngờ slide hiện tại chứa một bảng duy nhất, bạn có thể chỉ cần kiểm tra tất cả các shape mà nó chứa. Khi một shape được xác định là bảng, bạn có thể ép kiểu nó thành đối tượng [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Table). Tuy nhiên nếu slide chứa nhiều bảng, bạn nên tìm kiếm bảng cần thiết thông qua [setAlternativeText(String value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/setalternativetext/).

5. Sử dụng đối tượng [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Table) để làm việc với bảng. Trong ví dụ dưới đây, chúng tôi đã thêm một hàng mới vào bảng.
6. Lưu bản trình bày đã sửa đổi.

Mã PHP này cho bạn thấy cách truy cập và làm việc với một bảng hiện có:

```php
  # Khởi tạo lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Truy cập slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Khởi tạo TableEx null
    $tbl = null;
    # Duyệt qua các shape và đặt tham chiếu tới bảng được tìm thấy
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Đặt văn bản cho cột đầu tiên của hàng thứ hai
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Lưu bản trình bày đã sửa đổi vào đĩa
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tìm ô sở hữu một Text Frame**

Khi mã xử lý văn bản chung nhận được một [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) từ một bảng, hãy sử dụng phương thức [TextFrame::getParentCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentCell) để truy xuất [Cell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cell/) sở hữu. Đối với TextFrame của ô bảng, [TextFrame::getParentCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentCell) trả về chủ sở hữu và [TextFrame::getParentShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentShape) trả về `null`, mặc dù bảng tự nó là một shape.

Các tọa độ của ô có sẵn thông qua các phương thức chỉ‑đọc [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cell/#getFirstColumnIndex) và [Cell::getFirstRowIndex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame::getParentCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentCell) cũng cung cấp chức năng duyệt chỉ‑đọc: nó trả về chủ sở hữu nhưng không thay đổi quyền sở hữu. Luôn kiểm tra ô trả về bằng `java_is_null` trước khi sử dụng.

Đối với ví dụ hoàn chỉnh xác định chủ sở hữu ô bảng và shape, bao gồm các shape liên quan đến nút SmartArt, xem [Search and Replace Text](/slides/vi/php-java/search-and-replace-text/).

## **Căn chỉnh văn bản trong bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó. 
3. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Table) vào slide.
4. Truy cập đối tượng [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) từ bảng.
5. Truy cập [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/).
6. Căn chỉnh văn bản theo chiều dọc.
7. Lưu bản trình bày đã sửa đổi.

Mã PHP này cho bạn thấy cách căn chỉnh văn bản trong một bảng:

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Định nghĩa các cột với độ rộng và các hàng với chiều cao
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Thêm shape bảng vào slide
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Truy cập khung văn bản
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Tạo đối tượng Paragraph cho khung văn bản
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Tạo đối tượng Portion cho đoạn văn
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Căn chỉnh văn bản theo chiều dọc
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Lưu bản trình bày vào đĩa
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt định dạng văn bản ở mức bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó. 
3. Truy cập một đối tượng [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Table) từ Slide.
4. Đặt [setFontHeight(float value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setFontHeight) cho văn bản.
5. Đặt [setAlignment(int value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setalignment/) và [setMarginRight(float value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Đặt [setTextVerticalType(byte value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Lưu bản trình bày đã sửa đổi. 

Mã PHP này cho bạn thấy cách áp dụng các tùy chọn định dạng ưa thích cho văn bản trong một bảng:

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Giả sử rằng shape đầu tiên trên slide đầu tiên là một bảng
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Đặt chiều cao phông chữ cho các ô bảng
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Đặt căn chỉnh văn bản và lề phải cho các ô bảng trong một lệnh
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Đặt loại văn bản dọc cho các ô bảng
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lấy thuộc tính phong cách bảng**

Aspose.Slides cho phép bạn lấy các thuộc tính phong cách của một bảng để bạn có thể sử dụng các chi tiết này cho bảng khác hoặc ở nơi khác. Mã PHP này cho bạn thấy cách lấy các thuộc tính phong cách từ một kiểu bảng đã định sẵn:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// thay đổi giao diện mẫu mặc định

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Khóa tỷ lệ khung hình của bảng**

Tỷ lệ khung hình của một hình học là tỷ lệ kích thước của nó ở các chiều khác nhau. Aspose.Slides cung cấp phương thức [setAspectRatioLocked](https://reference.aspose.com/slides/vi/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) để cho phép bạn khóa cài đặt tỷ lệ khung hình cho bảng và các shape khác.

Mã PHP này cho bạn thấy cách khóa tỷ lệ khung hình cho một bảng:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Tôi có thể bật hướng đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Đúng. Bảng cung cấp phương thức [setRightToLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/table/setrighttoleft/), và các đoạn văn có [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setrighttoleft/). Sử dụng cả hai đảm bảo thứ tự RTL đúng và hiển thị chính xác trong các ô.

**Làm thế nào để ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong tệp cuối cùng?**

Sử dụng khóa shape để vô hiệu hoá việc di chuyển, thay đổi kích thước, lựa chọn, v.v. Những khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn hình ảnh vào ô làm nền không?**

Đúng. Bạn có thể đặt [picture fill](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/) cho một ô; hình ảnh sẽ bao phủ khu vực ô theo chế độ đã chọn (kéo dãn hoặc lát).