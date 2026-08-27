---
title: Quản lý Bảng trong Bài thuyết trình bằng JavaScript
linktitle: Quản lý Bảng
type: docs
weight: 10
url: /vi/nodejs-java/manage-table/
keywords:
- thêm bảng
- tạo bảng
- truy cập bảng
- tỷ lệ khía cạnh
- căn chỉnh văn bản
- định dạng văn bản
- kiểu bảng
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo và chỉnh sửa bảng trong slide PowerPoint bằng JavaScript và Aspose.Slides cho Node.js. Khám phá các ví dụ mã đơn giản để tối ưu quy trình làm việc với bảng."
---
## **Giới thiệu**

Bảng trong PowerPoint là một cách hiệu quả để hiển thị và truyền đạt thông tin. Thông tin trong lưới các ô (được sắp xếp theo hàng và cột) rất đơn giản và dễ hiểu.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table), lớp [Cell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cell/) và các kiểu khác để cho phép bạn tạo, cập nhật và quản lý bảng trong mọi loại bài thuyết trình.

## **Tạo Bảng từ Đầu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Xác định một mảng `columnWidth`.
4. Xác định một mảng `rowHeight`.
5. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Duyệt qua từng [Cell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cell/) để áp dụng định dạng cho các viền trên, dưới, phải và trái.
7. Hợp nhất bốn ô ở góc trên‑trái của bảng (hai cột đầu tiên của hai hàng đầu tiên) thành một ô duy nhất. 
8. Truy cập vào [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của một [Cell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cell/).
9. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/).
10. Lưu bài thuyết trình đã sửa đổi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Định nghĩa các cột với độ rộng và các hàng với độ cao
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Thêm một shape bảng vào slide
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
    // Hợp nhất khối 2x2 ô ở góc trên‑trái thành một ô
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Thêm một số văn bản vào ô đã hợp nhất
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Lưu bài thuyết trình vào đĩa
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đánh số trong Bảng chuẩn**

Trong một bảng chuẩn, việc đánh số các ô là đơn giản và bắt đầu từ 0. Ô đầu tiên trong bảng có chỉ mục là 0,0 (cột 0, hàng 0). 

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Đoạn mã JavaScript này cho bạn thấy cách chỉ định đánh số cho các ô trong bảng:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Định nghĩa các cột với độ rộng và các hàng với độ cao
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Thêm một shape bảng vào slide
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
    // Lưu bài thuyết trình vào đĩa
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Truy cập Bảng hiện có**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).

2. Lấy tham chiếu tới slide chứa bảng thông qua chỉ mục của nó. 

3. Tạo một đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) và gán nó bằng null.

4. Duyệt qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) cho đến khi tìm thấy bảng.

   Nếu bạn nghi ngờ slide bạn đang xử lý chứa một bảng duy nhất, bạn có thể đơn giản kiểm tra tất cả các shape mà nó chứa. Khi một shape được xác định là một bảng, bạn có thể ép kiểu nó thành đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table). Tuy nhiên nếu slide bạn đang xử lý chứa nhiều bảng, thì bạn nên tìm kiếm bảng cần thiết thông qua phương thức [setAlternativeText(String value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Sử dụng đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) để làm việc với bảng. Trong ví dụ dưới đây, chúng tôi đặt văn bản cho một ô trong bảng.

6. Lưu bài thuyết trình đã sửa đổi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Khởi tạo lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Khởi tạo TableEx null
    var tbl = null;
    // Duyệt qua các shape và đặt tham chiếu tới bảng được tìm thấy
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Đặt văn bản cho cột đầu tiên của hàng thứ hai
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Lưu bài thuyết trình đã sửa đổi vào đĩa
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tìm Ô sở hữu Text Frame**

Khi mã xử lý văn bản chung nhận được một [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) từ bảng, hãy sử dụng phương thức [TextFrame.getParentCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentCell--) để lấy [Cell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cell/) sở hữu. Đối với một khung văn bản của ô trong bảng, [TextFrame.getParentCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentCell--) trả về chủ sở hữu và [TextFrame.getParentShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentShape--) trả về `null`, mặc dù bảng tự nó là một shape.

Các tọa độ ô có sẵn qua các phương thức chỉ đọc [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) và [Cell.getFirstRowIndex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) . [TextFrame.getParentCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentCell--) cũng cung cấp khả năng điều hướng chỉ đọc: nó trả về chủ sở hữu nhưng không thay đổi quyền sở hữu. Luôn kiểm tra ô trả về có `null` hay không trước khi sử dụng.

Đối với một ví dụ hoàn chỉnh xác định chủ sở hữu của ô bảng và shape, bao gồm các shape liên kết với các nút SmartArt, hãy xem [Search and Replace Text](/slides/vi/nodejs-java/search-and-replace-text/).

## **Căn chỉnh Văn bản trong Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) vào slide.
4. Truy cập vào một đối tượng [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) từ bảng.
5. Truy cập vào [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) của [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/).
6. Căn chỉnh văn bản theo chiều dọc.
7. Lưu bài thuyết trình đã sửa đổi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Định nghĩa các cột với độ rộng và các hàng với độ cao
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Thêm shape bảng vào slide
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Truy cập vào text frame
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Tạo đối tượng Paragraph cho text frame
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Tạo đối tượng Portion cho đoạn văn
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Căn chỉnh văn bản theo chiều dọc
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // Lưu bài thuyết trình vào đĩa
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Định dạng Văn bản ở Cấp độ Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Truy cập vào một đối tượng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Table) từ Slide.
4. Đặt [setFontHeight(float value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) cho văn bản.
5. Đặt [setAlignment(int value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) và [setMarginRight(float value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Đặt [setTextVerticalType(byte value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Lưu bài thuyết trình đã sửa đổi. 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Giả sử shape đầu tiên trên slide đầu tiên là một bảng
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Đặt độ cao phông chữ cho các ô của bảng
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Đặt căn chỉnh văn bản và lề phải cho các ô của bảng trong một lần gọi
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Đặt kiểu dọc của văn bản cho các ô của bảng
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Kiểu Bảng Tiên Định**

Aspose.Slides cung cấp các kiểu bảng PowerPoint tích hợp sẵn dưới dạng liệt kê [TableStylePreset](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tablestylepreset/), vì vậy bạn có thể áp dụng cùng một giao diện cho bất kỳ bảng nào. Đoạn mã JavaScript này cho bạn thấy cách thay thế kiểu mặc định của một bảng bằng kiểu tiên định:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **Khóa Tỷ lệ Khía cạnh của Bảng**

Tỷ lệ khía cạnh của một hình dạng hình học là tỉ lệ các kích thước của nó ở các chiều khác nhau. Aspose.Slides cung cấp thuộc tính [**setAspectRatioLocked**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) để cho phép bạn khóa thiết lập tỷ lệ khía cạnh cho bảng và các hình dạng khác.

Đoạn mã JavaScript này cho bạn thấy cách khóa tỷ lệ khía cạnh cho một bảng:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// đảo ngược
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Có thể bật hướng đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Có. Bảng cung cấp phương thức [setRightToLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/table/setrighttoleft/), và các đoạn văn có [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Sử dụng cả hai sẽ đảm bảo thứ tự RTL đúng và hiển thị chính xác bên trong các ô.

**Làm thế nào để ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong tệp cuối cùng?**

Sử dụng khóa shape để vô hiệu hóa việc di chuyển, thay đổi kích thước, chọn, v.v. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn hình ảnh vào trong ô làm nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/) cho ô; hình ảnh sẽ bao phủ khu vực ô theo chế độ đã chọn (kéo dài hoặc lát).