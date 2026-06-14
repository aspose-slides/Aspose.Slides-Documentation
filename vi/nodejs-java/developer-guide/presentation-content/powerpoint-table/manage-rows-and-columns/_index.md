---
title: Quản lý hàng và cột trong bảng PowerPoint bằng JavaScript
linktitle: Hàng và Cột
type: docs
weight: 20
url: /vi/nodejs-java/manage-rows-and-columns/
keywords:
- hàng bảng
- cột bảng
- hàng đầu tiên
- tiêu đề bảng
- sao chép hàng
- sao chép cột
- chép hàng
- chép cột
- xóa hàng
- xóa cột
- định dạng văn bản hàng
- định dạng văn bản cột
- kiểu bảng
- PowerPoint
- bản thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các hàng và cột của bảng trong PowerPoint bằng JavaScript và Aspose.Slides cho Node.js thông qua Java, tăng tốc việc chỉnh sửa bản thuyết trình và cập nhật dữ liệu."
---
## **Giới thiệu**

Để cho phép bạn quản lý các hàng và cột của bảng trong một bản thuyết trình PowerPoint, Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/table/) và các kiểu khác.

## **Đặt Hàng Đầu Tiên Là Tiêu Đề**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và tải bản thuyết trình.
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Tạo một đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) và đặt nó thành null.
4. Duyệt qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) để tìm bảng liên quan.
5. Đặt hàng đầu tiên của bảng làm tiêu đề.

```javascript
// Khởi tạo lớp Presentation
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Khởi tạo TableEx null
    var tbl = null;
    // Duyệt qua các shape và thiết lập tham chiếu tới bảng
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Đặt hàng đầu tiên của bảng làm tiêu đề
            tbl.setFirstRow(true);
        }
    }
    // Lưu bản thuyết trình vào đĩa
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sao Chép Hàng Hoặc Cột Của Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và tải bản thuyết trình,
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Xác định một mảng `columnWidth`.
4. Xác định một mảng `rowHeight`.
5. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
6. Sao chép hàng của bảng.
7. Sao chép cột của bảng.
8. Lưu bản thuyết trình đã chỉnh sửa.

```javascript
// Khởi tạo lớp Presentation
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Định nghĩa các cột với độ rộng và các hàng với chiều cao
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Thêm một shape bảng vào slide
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Thêm một số văn bản vào ô hàng 1 cột 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Thêm một số văn bản vào ô hàng 1 cột 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Sao chép hàng 1 vào cuối bảng
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Thêm một số văn bản vào ô hàng 2 cột 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Thêm một số văn bản vào ô hàng 2 cột 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Sao chép hàng 2 làm hàng thứ 4 của bảng
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Sao chép cột đầu tiên vào cuối
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Sao chép cột thứ 2 ở vị trí cột thứ 4
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Lưu bản thuyết trình vào đĩa
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xóa Hàng Hoặc Cột Khỏi Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và tải bản thuyết trình,
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Xác định một mảng `columnWidth`.
4. Xác định một mảng `rowHeight`.
5. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
6. Xóa hàng của bảng.
7. Xóa cột của bảng.
8. Lưu bản thuyết trình đã chỉnh sửa.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Định Dạng Văn Bản ở Cấp Độ Hàng Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và tải bản thuyết trình,
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Truy cập đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) liên quan từ slide.
4. Đặt [setFontHeight(float value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) cho các ô của hàng đầu tiên.
5. Đặt [setAlignment(int value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) và [setMarginRight(float value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) cho các ô của hàng đầu tiên.
6. Đặt [setTextVerticalType(byte value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) cho các ô của hàng thứ hai.
7. Lưu bản thuyết trình đã chỉnh sửa.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Giả sử shape đầu tiên trên slide đầu tiên là một bảng
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Đặt độ cao phông chữ cho các ô của hàng đầu tiên
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Đặt căn chỉnh văn bản và lề phải cho các ô của hàng đầu tiên
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Đặt kiểu văn bản dọc cho các ô của hàng thứ hai
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Lưu bản thuyết trình vào đĩa
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Định Dạng Văn Bản ở Cấp Độ Cột Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và tải bản thuyết trình,
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Truy cập đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) liên quan từ slide.
4. Đặt [setFontHeight(float value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) cho các ô của cột đầu tiên.
5. Đặt [setAlignment(int value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) và [setMarginRight(float value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) cho các ô của cột đầu tiên.
6. Đặt [setTextVerticalType(byte value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) cho các ô của cột thứ hai.
7. Lưu bản thuyết trình đã chỉnh sửa.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Giả sử shape đầu tiên trên slide đầu tiên là một bảng
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Đặt độ cao phông chữ cho các ô của cột đầu tiên
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Đặt căn chỉnh văn bản và lề phải cho các ô của cột đầu tiên trong một lần gọi
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Đặt kiểu văn bản dọc cho các ô của cột thứ hai
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lấy Thuộc Tính Kiểu Bảng**

Aspose.Slides cho phép bạn lấy các thuộc tính kiểu cho một bảng để bạn có thể sử dụng những chi tiết đó cho bảng khác hoặc ở nơi khác. Đoạn mã JavaScript này cho bạn thấy cách lấy các thuộc tính kiểu từ một kiểu bảng được định sẵn:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// thay đổi giao diện preset mặc định
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng giao diện/phong cách PowerPoint vào một bảng đã được tạo không?**

Có. Bảng sẽ kế thừa giao diện của slide/bố cục/mẫu chính, và bạn vẫn có thể ghi đè màu nền, viền và màu chữ lên trên giao diện đó.

**Tôi có thể sắp xếp các hàng của bảng giống như trong Excel không?**

Không, các bảng Aspose.Slides không có tính năng sắp xếp hoặc lọc tích hợp. Hãy sắp xếp dữ liệu trong bộ nhớ trước, sau đó đưa các hàng bảng vào lại theo thứ tự đó.

**Tôi có thể có các cột được dải màu (striped) trong khi giữ màu tùy chỉnh cho các ô cụ thể không?**

Có. Bật tính năng cột dải màu, sau đó ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng ở mức ô sẽ có ưu tiên hơn kiểu bảng.