---
title: Quản lý Bảng trong Bản trình chiếu bằng JavaScript
linktitle: Quản lý Bảng
type: docs
weight: 10
url: /vi/nodejs-java/manage-table/
keywords:
- thêm bảng
- tạo bảng
- truy cập bảng
- tỷ lệ khung hình
- căn chỉnh văn bản
- định dạng văn bản
- kiểu bảng
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo và chỉnh sửa bảng trong các slide PowerPoint bằng JavaScript và Aspose.Slides cho Node.js. Khám phá các ví dụ mã đơn giản để tinh giản quy trình làm việc với bảng của bạn."
---
## **Giới thiệu**

Bảng trong PowerPoint là một cách hiệu quả để hiển thị và trình bày thông tin. Thông tin trong lưới các ô (được sắp xếp theo hàng và cột) rất đơn giản và dễ hiểu.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table), lớp [Cell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cell/) và các kiểu khác để cho phép bạn tạo, cập nhật và quản lý các bảng trong mọi loại bản trình bày.

## **Tạo bảng từ đầu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Định nghĩa một mảng `columnWidth`.
4. Định nghĩa một mảng `rowHeight`.
5. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Duyệt qua mỗi [Cell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cell/) để áp dụng định dạng cho các viền trên, dưới, phải và trái.
7. Hợp nhất hai ô đầu tiên của hàng đầu tiên của bảng. 
8. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của một [Cell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cell/).
9. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/).
10. Lưu bản trình bày đã chỉnh sửa.

Đoạn mã JavaScript này cho bạn thấy cách tạo một bảng trong bản trình bày:

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Xác định các cột với độ rộng và các hàng với độ cao
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Thêm hình dạng bảng vào slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Đặt định dạng viền cho mỗi ô
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Hợp nhất các ô 1 và 2 của hàng 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Thêm một số văn bản vào ô đã hợp nhất
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Lưu bản trình chiếu vào đĩa
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đánh số trong Bảng tiêu chuẩn**

Trong một bảng tiêu chuẩn, việc đánh số các ô là đơn giản và bắt đầu từ 0. Ô đầu tiên trong một bảng được đánh chỉ mục là 0,0 (cột 0, hàng 0). 

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Đoạn mã JavaScript này cho bạn thấy cách chỉ định đánh số cho các ô trong một bảng:

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Xác định các cột với độ rộng và các hàng với độ cao
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Thêm hình dạng bảng vào slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Đặt định dạng viền cho mỗi ô
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Lưu bản trình chiếu vào đĩa
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Truy cập Bảng hiện có**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu đến slide chứa bảng thông qua chỉ mục của nó. 
3. Tạo một đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) và gán nó thành null.
4. Duyệt qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) cho đến khi tìm thấy bảng.

   Nếu bạn nghi ngờ slide đang làm việc chỉ chứa một bảng, bạn có thể đơn giản kiểm tra tất cả các shape mà nó chứa. Khi một shape được xác định là một bảng, bạn có thể ép kiểu nó thành đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table). Tuy nhiên nếu slide chứa nhiều bảng, thì tốt hơn hết là tìm kiếm bảng bạn cần thông qua thuộc tính [setAlternativeText(String value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Sử dụng đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) để làm việc với bảng. Trong ví dụ dưới đây, chúng tôi đã thêm một hàng mới vào bảng.
6. Lưu bản trình bày đã chỉnh sửa.

Đoạn mã JavaScript này cho bạn thấy cách truy cập và làm việc với một bảng hiện có:

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Khởi tạo TableEx null
    var tbl = null;
    // Duyệt qua các shape và đặt tham chiếu đến bảng được tìm thấy
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Đặt văn bản cho cột đầu tiên của hàng thứ hai
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Lưu bản trình chiếu đã chỉnh sửa vào đĩa
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Căn chỉnh văn bản trong bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) vào slide.
4. Truy cập một đối tượng [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) từ bảng.
5. Truy cập [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) của [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/).
6. Căn chỉnh văn bản theo chiều dọc.
7. Lưu bản trình bày đã chỉnh sửa.

Đoạn mã JavaScript này cho bạn thấy cách căn chỉnh văn bản trong một bảng:

```javascript
    // Tạo một thể hiện của lớp Presentation
    var pres = new aspose.slides.Presentation();
    try {
        // Lấy slide đầu tiên
        var slide = pres.getSlides().get_Item(0);
        // Xác định các cột với độ rộng và các hàng với độ cao
        var dblCols = java.newArray("double", [120, 120, 120, 120]);
        var dblRows = java.newArray("double", [100, 100, 100, 100]);
        // Thêm hình dạng bảng vào slide
        var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
        tbl.get_Item(1, 0).getTextFrame().setText("10");
        tbl.get_Item(2, 0).getTextFrame().setText("20");
        tbl.get_Item(3, 0).getTextFrame().setText("30");
        // Truy cập khung văn bản
        var txtFrame = tbl.get_Item(0, 0).getTextFrame();
        // Tạo đối tượng Paragraph cho khung văn bản
        var paragraph = txtFrame.getParagraphs().get_Item(0);
        // Tạo đối tượng Portion cho đoạn văn
        var portion = paragraph.getPortions().get_Item(0);
        portion.setText("Text here");
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        // Căn chỉnh văn bản theo chiều dọc
        var cell = tbl.get_Item(0, 0);
        cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
        cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
        // Lưu bản trình chiếu vào đĩa
        pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Đặt định dạng văn bản ở cấp độ bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Truy cập một đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) từ Slide.
4. Đặt [setFontHeight(float value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) cho văn bản.
5. Đặt [setAlignment(int value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) và [setMarginRight(float value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Đặt [setTextVerticalType(byte value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Lưu bản trình bày đã chỉnh sửa. 

Đoạn mã JavaScript này cho bạn thấy cách áp dụng các tùy chọn định dạng ưa thích của bạn cho văn bản trong bảng:

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Giả sử rằng shape đầu tiên trên slide đầu tiên là một bảng
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Đặt chiều cao phông chữ cho các ô bảng
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Đặt căn chỉnh văn bản và lề phải cho các ô bảng trong một lần gọi
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Đặt kiểu văn bản dọc cho các ô bảng
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lấy thuộc tính kiểu bảng**

Aspose.Slides cho phép bạn truy xuất các thuộc tính kiểu cho một bảng để bạn có thể sử dụng chi tiết đó cho bảng khác hoặc nơi khác. Đoạn mã JavaScript này cho bạn thấy cách lấy các thuộc tính kiểu từ một kiểu bảng được cài sẵn:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// thay đổi preset giao diện mặc định
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Khóa tỷ lệ khung hình của bảng**

Tỷ lệ khung hình của một hình dạng hình học là tỷ lệ kích thước của nó theo các chiều khác nhau. Aspose.Slides cung cấp thuộc tính [**setAspectRatioLocked**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) để cho phép bạn khóa cài đặt tỷ lệ khung hình cho các bảng và các shape khác.

Đoạn mã JavaScript này cho bạn thấy cách khóa tỷ lệ khung hình cho một bảng:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể bật chế độ đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Có. Bảng cung cấp phương thức [setRightToLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/table/setrighttoleft/), và các đoạn văn có [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Việc sử dụng cả hai đảm bảo thứ tự RTL đúng và hiển thị chính xác bên trong các ô.

**Làm thế nào để tôi ngăn người dùng di chuyển hoặc thay đổi kích thước của bảng trong tệp cuối cùng?**

Sử dụng khóa shape để vô hiệu hoá việc di chuyển, thay đổi kích thước, chọn, v.v. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn hình ảnh vào bên trong một ô làm nền không?**

Có. Bạn có thể đặt [picture fill](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/) cho một ô; hình ảnh sẽ bao phủ khu vực ô theo chế độ đã chọn (kéo dãn hoặc lặp).