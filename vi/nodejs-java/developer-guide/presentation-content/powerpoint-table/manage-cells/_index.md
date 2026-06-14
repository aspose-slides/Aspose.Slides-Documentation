---
title: Quản lý các ô bảng trong bản trình bày bằng JavaScript
linktitle: Quản lý ô
type: docs
weight: 30
url: /vi/nodejs-java/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa đường viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các ô bảng trong PowerPoint với Aspose.Slides cho Node.js. Thành thạo việc truy cập, sửa đổi và tạo kiểu cho các ô nhanh chóng để tự động hoá slide một cách liền mạch."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và sửa đổi các ô bảng trong bản trình bày PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa đường viền ô, làm việc với việc đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô, và chèn hình ảnh vào bên trong ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình bày, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính của ô, và lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

## **Xác định ô bảng đã hợp nhất**
1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy bảng từ slide đầu tiên. 
3. Duyệt qua các hàng và cột của bảng để tìm các ô hợp nhất. 
4. In thông báo khi tìm thấy ô đã hợp nhất. 

Đoạn mã JavaScript này cho bạn thấy cách xác định các ô bảng đã hợp nhất trong một bản trình bày:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// giả sử Slide#0.Shape#0 là một bảng
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xóa đường viền ô bảng**
1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của slide qua chỉ số của nó. 
3. Xác định một mảng các cột với độ rộng. 
4. Xác định một mảng các hàng với chiều cao. 
5. Thêm một bảng vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) . 
6. Duyệt qua mọi ô để xóa các đường viền trên, dưới, phải và trái. 
7. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX. 

Đoạn mã JavaScript này cho bạn thấy cách xóa các đường viền khỏi các ô bảng:

```javascript
// Khởi tạo lớp Presentation đại diện cho một tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Xác định các cột với độ rộng và các hàng với chiều cao
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Thêm hình dạng bảng vào slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Đặt định dạng viền cho mỗi ô
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // Ghi tệp PPTX ra đĩa
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đánh số trong các ô đã hợp nhất**
Nếu chúng ta hợp nhất 2 cặp ô (1, 1) x (2, 1) và (1, 2) x (2, 2), bảng kết quả sẽ được đánh số. Đoạn mã JavaScript này minh họa quá trình:

```javascript
// Khởi tạo lớp Presentation đại diện cho một tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Xác định các cột với độ rộng và các hàng với chiều cao
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
    // Hợp nhất các ô (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Hợp nhất các ô (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Tiếp theo chúng ta tiếp tục hợp nhất các ô bằng cách hợp nhất (1, 1) và (1, 2). Kết quả là một bảng chứa một ô hợp nhất lớn ở trung tâm: 

```javascript
// Khởi tạo lớp Presentation đại diện cho một tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Xác định các cột với độ rộng và các hàng với chiều cao
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
    // Hợp nhất các ô (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Hợp nhất các ô (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Hợp nhất các ô (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // Ghi tệp PPTX ra đĩa
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đánh số trong ô đã tách**
Trong các ví dụ trước, khi các ô bảng được hợp nhất, hệ thống đánh số hoặc số thứ tự trong các ô khác không thay đổi. 

Lần này, chúng ta lấy một bảng thông thường (bảng không có ô hợp nhất) và sau đó cố gắng tách ô (1,1) để có một bảng đặc biệt. Bạn có thể muốn chú ý đến việc đánh số của bảng này, có thể được coi là lạ. Tuy nhiên, đó là cách Microsoft PowerPoint đánh số các ô bảng và Aspose.Slides cũng làm tương tự. 

Đoạn mã JavaScript này minh họa quá trình chúng tôi mô tả:

```javascript
// Khởi tạo lớp Presentation đại diện cho một tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Xác định các cột với độ rộng và các hàng với chiều cao
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
    // Hợp nhất các ô (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Hợp nhất các ô (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Tách ô (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // Ghi tệp PPTX ra đĩa
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thay đổi màu nền ô bảng**

Đoạn mã JavaScript này cho bạn thấy cách thay đổi màu nền của một ô bảng:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // tạo một bảng mới
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // đặt màu nền cho một ô
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Thêm hình ảnh vào bên trong ô bảng**

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của slide qua chỉ số của nó. 
3. Xác định một mảng các cột với độ rộng. 
4. Xác định một mảng các hàng với chiều cao. 
5. Thêm một bảng vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) . 
6. Tạo một đối tượng `Images` để chứa tệp hình ảnh. 
7. Thêm hình ảnh `IImage` vào đối tượng `PPImage`. 
8. Đặt `FillFormat` cho ô bảng thành `Picture`. 
9. Thêm hình ảnh vào ô đầu tiên của bảng. 
10. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX 

Đoạn mã JavaScript này cho bạn thấy cách chèn hình ảnh vào bên trong ô bảng khi tạo bảng:

```javascript
// Khởi tạo lớp Presentation đại diện cho một tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var islide = pres.getSlides().get_Item(0);
    // Xác định các cột với độ rộng và các hàng với chiều cao
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // Thêm hình dạng bảng vào slide
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // Tạo đối tượng PPImage bằng tệp hình ảnh
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Thêm hình ảnh vào ô bảng đầu tiên
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Lưu tệp PPTX ra đĩa
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Tôi có thể đặt độ dày và kiểu đường khác nhau cho các mặt khác nhau của một ô duy nhất không?**

Có. Các đường viền [top](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cellformat/getborderright/) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi mặt có thể khác nhau. Điều này hợp lý dựa trên việc kiểm soát đường viền từng mặt cho một ô được minh họa trong bài viết.

**Điều gì sẽ xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đặt một ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Với chế độ kéo dài, hình ảnh sẽ điều chỉnh theo ô mới; với chế độ lặp, các ô ảnh sẽ được tính lại. Bài viết đề cập đến các chế độ hiển thị hình ảnh trong ô.

**Tôi có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/nodejs-java/manage-hyperlinks/) được đặt ở mức độ văn bản (phần) bên trong khung văn bản của ô hoặc ở mức độ của toàn bộ bảng/hình dạng. Trong thực tế, bạn gán liên kết cho một phần hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) (runs) với định dạng độc lập—gia đình phông, kiểu, kích thước và màu.