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
description: "Quản lý các ô bảng PowerPoint trong JavaScript: xác định các ô đã hợp nhất, xóa đường viền, tách ô, và đặt màu nền cùng hình ảnh bằng Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và sửa đổi các ô bảng trong bản trình bày PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa đường viền ô, làm việc với việc đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô và chèn hình ảnh vào bên trong ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình bày, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính ô, và lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ mục bắt đầu từ 0 để truy cập các ô bảng theo thứ tự `(cột, hàng)`.

## **Xác định ô bảng đã hợp nhất**

Ví dụ mở một bản trình bày hiện có và truy cập hình dạng đầu tiên trên slide đầu tiên dưới dạng bảng. Nó giả định rằng slide và hình dạng tồn tại và hình dạng là một bảng. Sau đó nó lặp qua tất cả các hàng và cột và sử dụng [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) để xác định các ô trong vùng hợp nhất. Đối với mỗi kết quả phù hợp, nó in tọa độ ô theo thứ tự `hàng;cột`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), và tọa độ bắt đầu của vùng, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) và [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Xóa đường viền ô bảng**

Tạo một [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) và thêm một bảng vào slide đầu tiên của nó bằng [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). Độ rộng cột, chiều cao hàng và vị trí bảng được chỉ định bằng điểm. Ví dụ này đặt tất cả bốn đường viền ô thành [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), khiến chúng không hiển thị.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hợp nhất các ô bảng**

Sử dụng [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) để kết hợp một phạm vi hình chữ nhật các ô bảng thành một ô duy nhất. Xác định các ô ở góc trên‑trái và góc dưới‑phải của phạm vi. Tham số cuối cùng điều khiển việc hợp nhất có cho phép bao gồm các ô bên ngoài phạm vi đã chỉ định hay không; `false` giữ cho hợp nhất chỉ nằm trong phạm vi đó.

Ví dụ tạo một bảng 4x4 với các cột và hàng có độ rộng 70 điểm, sau đó hợp nhất bốn ô ở giữa từ `(1, 1)` tới `(2, 2)`. Ô kết quả trải rộng qua hai cột và hai hàng, trong khi lưới cơ bản của bảng vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã hợp nhất, sử dụng vị trí trên‑trái của nó: `table.get_Item(1, 1)` trong ví dụ này. Các vị trí còn lại trong phạm vi hợp nhất vẫn là một phần của lưới bảng, vì vậy các chỉ mục của các ô ngoài phạm vi không thay đổi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tách các ô bảng**

Việc hợp nhất các ô trong ví dụ trước giữ nguyên lưới của bảng. Tách một ô có thể tạo thêm một cột lưới mới và thay đổi chỉ mục cột của các ô nằm bên phải nó. Aspose.Slides tuân theo mô hình lưới bảng của PowerPoint.

Ví dụ này tạo một bảng 4x4 với các cột và hàng có độ rộng 70 điểm và gọi [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) trên ô `(1, 1)`. Một nửa độ rộng 70 điểm của ô được truyền vào để tạo hai ô có độ rộng bằng nhau.

Sau khi tách, hai nửa được truy cập dưới dạng `table.get_Item(1, 1)` và `table.get_Item(2, 1)`. Lưới bảng giờ có năm cột: các ô ban đầu ở cột 2 và 3 di chuyển tới cột 3 và 4 tương ứng. Các chỉ mục hàng không thay đổi. Hãy sử dụng các chỉ mục cột đã cập nhật khi truy cập các ô sau khi tách.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Tách các ô đã hợp nhất theo độ rộng hàng hoặc cột**

Để chuẩn bị các ô mẫu đã hợp nhất cho việc đưa dữ liệu, sử dụng [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) để tách theo ranh giới hàng hiện có, hoặc [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) để tách theo ranh giới cột.

Tham số `index` đếm số hàng ở phần trên hoặc số cột ở phần trái của phần tách; nó tương đối với vùng đã hợp nhất:

- Tách hàng: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Tách cột: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Ví dụ giả sử bản trình bày có một bảng là hình dạng đầu tiên trên slide đầu tiên, với các ô `(1, 2)` và `(1, 3)` đã hợp nhất theo chiều dọc. Bắt đầu từ vị trí phía dưới, nó sử dụng [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) và [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) để xác định gốc và kiểm tra cả hai phạm vi. `splitByRowSpan(1)` sau đó tách các hàng 2 và 3 cho tên sản phẩm. Đối với một hợp nhất ngang hai cột, thay vào đó sử dụng `splitByColSpan(1)`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // Lấy các ô kết quả từ bảng sau khi tách.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Lưới bảng và các chỉ mục ô xung quanh vẫn không thay đổi. Lấy các ô kết quả theo tọa độ của chúng; ở đây, cả hai ô đều có phạm vi là 1 và [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) trả về `false`. Các vùng lớn hơn có thể vẫn còn phần nào được hợp nhất sau một lần tách.

Văn bản gốc và định dạng của nó vẫn nằm trong ô trên (hoặc trái); ô mới trống nhưng kế thừa định dạng ô như màu nền, đường viền và lề. Hãy điền dữ liệu vào các ô sau khi tách và thiết lập bất kỳ định dạng văn bản nào cần thiết một cách rõ ràng.

Bản trình bày đã lưu sẽ chứa các ô “Product A” và “Product B” riêng biệt với định dạng ô mẫu được giữ nguyên. Xem [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) để biết chi tiết.

## **Thay đổi màu nền của ô bảng**

Ví dụ này tạo một bảng với các cột 150 điểm và các hàng 50 điểm. Nó sử dụng [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) để chọn màu nền đặc và đặt màu trả về bởi [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) thành màu đỏ cho ô `(2, 3)`, tức là cột thứ ba và hàng thứ tư.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm hình ảnh vào bên trong một ô bảng**

Đặt hình ảnh đầu vào vào thư mục làm việc trước khi chạy ví dụ này. Nó tải hình ảnh bằng [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) và thêm nó vào bộ sưu tập hình ảnh của bản trình bày bằng [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). Sau đó nó gán hình ảnh cho phần fill dạng ảnh của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) kéo dài hình ảnh để lấp đầy ô, có thể làm thay đổi tỷ lệ khung hình. Độ rộng cột và chiều cao hàng được tính bằng điểm. Hình ảnh đã tải sẽ được giải phóng trong khối `finally` sau khi đã được thêm vào bản trình bày.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt độ dày và kiểu đường viền khác nhau cho từng phía của một ô duy nhất không?**

Có. Các đường viền [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) có thuộc tính riêng, vì vậy độ dày và kiểu của mỗi phía có thể khác nhau.

**Điều gì sẽ xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đặt ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Khi kéo dài, hình ảnh sẽ điều chỉnh theo ô mới; khi xếp lát, các ô ảnh sẽ được tính lại.

**Tôi có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/nodejs-java/manage-hyperlinks/) được đặt ở mức văn bản (phần) bên trong khung văn bản của ô hoặc ở mức toàn bộ bảng/hình dạng. Trong thực tế, bạn gán liên kết cho một phần hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt các phông chữ khác nhau trong cùng một ô không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (run) với định dạng độc lập — họa tiết phông, kiểu, kích thước và màu.