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
- canh chỉnh văn bản
- định dạng văn bản
- kiểu bảng
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo & chỉnh sửa bảng trong các slide PowerPoint bằng JavaScript và Aspose.Slides cho Node.js. Khám phá các ví dụ mã đơn giản để tối ưu hoá quy trình làm việc với bảng."
---
## **Giới thiệu**

Bảng trong PowerPoint sắp xếp thông tin thành các hàng và cột, giúp dễ đọc và so sánh các giá trị hơn.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) , lớp [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) và các loại khác để cho phép bạn tạo, cập nhật và quản lý các bảng trong bản trình bày.

## **Tạo Bảng Từ Đầu**

Tạo một bảng bằng cách chỉ định vị trí, độ rộng các cột và chiều cao các hàng. Sau khi thêm nó vào một slide, bạn có thể định dạng viền ô, hợp nhất các ô và chèn văn bản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide bằng chỉ số của nó.
3. Định nghĩa một mảng độ rộng cột tính bằng điểm.
4. Định nghĩa một mảng chiều cao hàng tính bằng điểm.
5. Thêm một đối tượng [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) .
6. Lặp qua từng [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) để áp dụng định dạng cho các viền trên, dưới, phải và trái.
7. Hợp nhất hai ô đầu tiên của hàng đầu tiên của bảng.
8. Truy cập ô đã hợp nhất qua phương thức [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) của nó.
9. Đặt văn bản trong ô đã hợp nhất.
10. Lưu bản trình bày đã sửa đổi.

Ví dụ dưới đây tạo một bảng có ba cột và năm hàng tại vị trí (100, 50) điểm. Nó áp dụng viền màu đỏ với độ rộng 5 điểm, hợp nhất hai ô đầu tiên trong hàng đầu tiên, và lưu kết quả dưới dạng `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đánh số trong Bảng Tiêu chuẩn**

Trong một bảng tiêu chuẩn, chỉ số ô bắt đầu từ 0 và sử dụng thứ tự (cột, hàng). Ô đầu tiên có chỉ số là (0, 0).

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ví dụ này tạo bảng 4 × 4 được minh họa ở trên, với độ rộng cột và chiều cao hàng là 70 điểm và viền ô màu đỏ có độ rộng 5 điểm. Các tọa độ minh họa chỉ số ô; ví dụ để các ô trống và lưu bảng dưới dạng `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Truy cập Bảng Đã tồn tại**

Tables được lưu trong bộ sưu tập hình dạng của slide. Duyệt qua các hình dạng để tìm một bảng, sau đó sử dụng lớp [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) để đọc hoặc cập nhật các ô của nó.

1. Tải bản trình bày bằng cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide chứa bảng bằng chỉ số của nó.
3. Duyệt qua các đối tượng [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) và dừng lại khi tìm thấy một bảng. Nếu slide chứa nhiều bảng, sử dụng [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) để xác định bảng bạn cần.
4. Cập nhật văn bản trong ô mục tiêu.
5. Lưu bản trình bày đã sửa đổi.

Ví dụ dưới đây mở `UpdateExistingTable.pptx` và tìm bảng đầu tiên trên slide đầu tiên. Nó đặt ô tại cột 0, hàng 1 thành `New` và lưu kết quả dưới dạng `table1_out.pptx`. Tệp đầu vào phải chứa ít nhất một slide, và bảng đầu tiên trên slide đó phải có ít nhất một cột và hai hàng.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Để thay đổi kích thước hàng trong một bảng đã tồn tại và hiểu vì sao chiều cao thực tế có thể vượt quá mức tối thiểu yêu cầu, xem [Kiểm soát chiều cao hàng](/slides/vi/nodejs-java/manage-rows-and-columns/#control-row-height).

## **Tìm Ô Chủ sở hữu Text Frame**

Khi mã xử lý văn bản chung nhận được một [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) từ một bảng, sử dụng phương thức [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) để lấy [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) sở hữu. Đối với khung văn bản của ô bảng, [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) trả về chủ sở hữu và [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) trả về `null`, mặc dù bảng tự nó là một shape.

Các tọa độ ô có sẵn qua các phương thức chỉ đọc [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) và [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) . [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) cũng cung cấp điều hướng chỉ đọc: nó trả về chủ sở hữu nhưng không thay đổi quyền sở hữu. Luôn kiểm tra ô trả về có phải `null` trước khi sử dụng.

Đối với một ví dụ đầy đủ xác định chủ sở hữu ô bảng và shape, bao gồm các shape liên kết với node SmartArt, xem [Search and Replace Text](/slides/vi/nodejs-java/search-and-replace-text/).

## **Canh chỉnh Văn bản trong Bảng**

Bạn có thể kiểm soát việc neo dọc và hướng văn bản của từng ô bảng. Ví dụ trong phần này căn giữa văn bản trong ô đầu tiên và xoay nó 270 độ.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide bằng chỉ số của nó.
3. Thêm một đối tượng [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) vào slide.
4. Truy cập một đối tượng [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) từ bảng.
5. Truy cập đoạn [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) đầu tiên và đặt văn bản và màu của nó.
6. Đặt việc neo dọc và hướng văn bản của ô bằng cách sử dụng [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) và [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-) .
7. Lưu bản trình bày đã sửa đổi.

Ví dụ này tạo một bảng 4 × 4 với độ rộng cột 120 điểm và chiều cao hàng 100 điểm. Nó định dạng văn bản trong ô (0, 0), thêm giá trị vào các ô còn lại trong hàng đầu tiên, và lưu kết quả dưới dạng `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Định dạng Văn bản ở Cấp độ Bảng**

Sử dụng [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) để áp dụng định dạng văn bản cho tất cả các ô trong một bảng. Các overload của nó chấp nhận định dạng phần, đoạn và khung văn bản, cho phép bạn đặt các thuộc tính này mà không cần lặp qua từng ô riêng lẻ.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide bằng chỉ số của nó.
3. Truy cập một đối tượng [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) từ slide.
4. Đặt kích thước phông chữ bằng [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) cho văn bản.
5. Đặt căn chỉnh đoạn và lề phải bằng [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) và [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) .
6. Đặt hướng văn bản bằng [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. Lưu bản trình bày đã sửa đổi.

Ví dụ dưới đây mở `table.pptx`, phải chứa ít nhất một slide với một bảng là shape đầu tiên. Nó đặt kích thước phông chữ thành 25 điểm, căn phải các đoạn với lề phải 20 điểm, và làm văn bản đứng dọc. Bản trình bày đã định dạng được lưu dưới dạng `result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lấy Thuộc tính Kiểu Bảng**

Sử dụng [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) để đọc kiểu được cài sẵn của bảng và [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) để gán nó. Ví dụ này áp dụng [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) cho một bảng, in ra giá trị preset, và gán cùng một preset cho bảng thứ hai. Cả hai bảng được lưu trong `table-style.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Khóa Tỷ lệ Khung hình của Bảng**

Tỷ lệ khung hình của một bảng là tỉ lệ giữa chiều rộng và chiều cao của nó. Sử dụng [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) để khóa tỉ lệ này cho một bảng.

Ví dụ dưới đây mở `pres.pptx`, phải chứa ít nhất một slide với một bảng là shape đầu tiên. Nó in ra trạng thái khóa hiện tại, bật khóa tỷ lệ khung hình, in ra trạng thái đã cập nhật (`true`), và lưu kết quả dưới dạng `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Tôi có thể bật hướng đọc phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Có. Bảng cung cấp phương thức [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-), và các đoạn có [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-). Sử dụng cả hai đảm bảo thứ tự RTL đúng và hiển thị bên trong các ô.

**Làm sao tôi có thể ngăn người dùng di chuyển hoặc thay đổi kích thước một bảng trong tệp cuối cùng?**

Sử dụng [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) để vô hiệu hoá việc di chuyển, thay đổi kích thước, lựa chọn, v.v. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn hình ảnh vào ô làm nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) cho ô; hình ảnh sẽ phủ toàn bộ khu vực ô theo chế độ đã chọn (giãn hoặc lặp).