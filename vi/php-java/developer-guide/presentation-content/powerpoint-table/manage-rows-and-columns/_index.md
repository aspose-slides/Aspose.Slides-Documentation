---
title: Quản lý các hàng và cột trong bảng PowerPoint bằng PHP
linktitle: Hàng và Cột
type: docs
weight: 20
url: /vi/php-java/manage-rows-and-columns/
keywords:
- hàng bảng
- cột bảng
- hàng đầu tiên
- tiêu đề bảng
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
description: "Quản lý các hàng và cột của bảng trong PowerPoint bằng Aspose.Slides cho PHP thông qua Java và tăng tốc việc chỉnh sửa bản trình chiếu cùng cập nhật dữ liệu."
---
## **Giới thiệu**

Để cho phép bạn quản lý các hàng và cột của bảng trong một bản thuyết trình PowerPoint, Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/table/) và nhiều kiểu khác.

## **Đặt Hàng Đầu Tiên Là Tiêu Đề**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và tải bản thuyết trình.  
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.  
3. Tạo một đối tượng [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Table) và đặt nó thành null.  
4. Duyệt qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) để tìm bảng tương ứng.  
5. Đặt hàng đầu tiên của bảng làm tiêu đề.  

Đoạn mã PHP này cho bạn thấy cách đặt hàng đầu tiên của bảng làm tiêu đề:

```php
  # Khởi tạo lớp Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Truy cập slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Khởi tạo TableEx null
    $tbl = null;
    # Duyệt qua các shape và đặt tham chiếu tới bảng
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Đặt hàng đầu tiên của bảng làm tiêu đề
        $tbl->setFirstRow(true);
      }
    }
    # Lưu bản trình chiếu vào đĩa
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sao Chép Hàng Hoặc Cột Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và tải bản thuyết trình,  
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.  
3. Xác định một mảng `columnWidth`.  
4. Xác định một mảng `rowHeight`.  
5. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Table) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addtable/).  
6. Sao chép hàng bảng.  
7. Sao chép cột bảng.  
8. Lưu bản thuyết trình đã sửa đổi.  

Đoạn mã PHP này cho bạn thấy cách sao chép hàng hoặc cột của bảng PowerPoint:

```php
  # Khởi tạo lớp Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Truy cập slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Định nghĩa các cột với độ rộng và các hàng với chiều cao
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Thêm hình dạng bảng vào slide
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Thêm một số văn bản vào ô 1 của hàng 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Thêm một số văn bản vào ô 2 của hàng 1
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Sao chép Hàng 1 vào cuối bảng
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Thêm một số văn bản vào ô 1 của hàng 2
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Thêm một số văn bản vào ô 2 của hàng 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Sao chép Hàng 2 thành hàng thứ 4 của bảng
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Sao chép cột đầu tiên vào cuối
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Sao chép cột thứ 2 vào vị trí cột thứ 4
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Lưu bản trình chiếu vào đĩa
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xóa Hàng Hoặc Cột Khỏi Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và tải bản thuyết trình,  
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.  
3. Xác định một mảng `columnWidth`.  
4. Xác định một mảng `rowHeight`.  
5. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Table) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addtable/).  
6. Xóa hàng bảng.  
7. Xóa cột bảng.  
8. Lưu bản thuyết trình đã sửa đổi.  

Đoạn mã PHP này cho bạn thấy cách xóa một hàng hoặc cột khỏi bảng:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt Định Dạng Văn Bản Ở Mức Hàng Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và tải bản thuyết trình,  
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.  
3. Truy cập đối tượng [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Table) liên quan từ slide.  
4. Đặt [setFontHeight(float value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setFontHeight) cho các ô của hàng đầu tiên.  
5. Đặt [setAlignment(int value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setalignment/) và [setMarginRight(float value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setmarginright/) cho các ô của hàng đầu tiên.  
6. Đặt [setTextVerticalType(byte value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/settextverticaltype/) cho các ô của hàng thứ hai.  
7. Lưu bản thuyết trình đã sửa đổi.  

Đoạn mã PHP này minh họa thao tác.

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    # Giả sử rằng shape đầu tiên trên slide đầu tiên là một bảng
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Đặt độ cao phông chữ cho các ô của hàng đầu tiên
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Đặt căn chỉnh văn bản và lề phải cho các ô của hàng đầu tiên
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Đặt loại văn bản dọc cho các ô của hàng thứ hai
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Lưu bản trình chiếu vào đĩa
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt Định Dạng Văn Bản Ở Mức Cột Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và tải bản thuyết trình,  
2. Lấy tham chiếu của một slide thông qua chỉ số của nó.  
3. Truy cập đối tượng [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Table) liên quan từ slide.  
4. Đặt [setFontHeight(float value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setFontHeight) cho các ô của cột đầu tiên.  
5. Đặt [setAlignment(int value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setalignment/) và [setMarginRight(float value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/setmarginright/) cho các ô của cột đầu tiên.  
6. Đặt [setTextVerticalType(byte value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/settextverticaltype/) cho các ô của cột thứ hai.  
7. Lưu bản thuyết trình đã sửa đổi.  

Đoạn mã PHP này minh họa thao tác:

```php
  # Tạo một thể hiện của lớp Presentation
  $pres = new Presentation();
  try {
    # Giả sử rằng shape đầu tiên trên slide đầu tiên là một bảng
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Đặt độ cao phông chữ cho các ô của cột đầu tiên
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Đặt căn chỉnh văn bản và lề phải cho các ô của cột đầu tiên trong một lệnh
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Đặt loại văn bản dọc cho các ô của cột thứ hai
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lấy Thuộc Tính Kiểu Bảng**

Aspose.Slides cho phép bạn truy xuất các thuộc tính kiểu cho một bảng để bạn có thể sử dụng các chi tiết đó cho bảng khác hoặc ở nơi khác. Đoạn mã PHP này cho bạn thấy cách lấy các thuộc tính kiểu từ một kiểu bảng được đặt trước:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// thay đổi preset kiểu mặc định

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Can I apply PowerPoint themes/styles to a table that’s already created?**  
Có. Bảng sẽ kế thừa chủ đề của slide/layout/master, và bạn vẫn có thể ghi đè màu nền, viền và màu chữ lên trên chủ đề đó.

**Can I sort table rows like in Excel?**  
Không, các bảng trong Aspose.Slides không có tính năng sắp xếp hay bộ lọc tích hợp. Hãy sắp xếp dữ liệu trong bộ nhớ trước, sau đó đưa lại các hàng bảng theo thứ tự đó.

**Can I have banded (striped) columns while keeping custom colors on specific cells?**  
Có. Bật tính năng cột kẻ sọc, sau đó ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng cấp ô sẽ ưu tiên hơn kiểu bảng.