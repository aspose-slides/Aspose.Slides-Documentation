---
title: Quản lý các ô bảng trong bản trình bày bằng JavaScript
linktitle: Quản lý Ô
type: docs
weight: 30
url: /vi/nodejs-java/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các ô bảng PowerPoint trong JavaScript: xác định các ô đã hợp nhất, xóa viền, tách ô, và đặt màu nền và hình ảnh bằng Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và chỉnh sửa các ô bảng trong bản trình bày PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa viền ô, làm việc với đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô và thêm hình ảnh vào bên trong một ô bảng. Các ví dụ minh họa cách tạo hoặc mở bản trình bày, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính của ô, và lưu bản trình chiếu đã sửa dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ mục bắt đầu từ 0 để truy cập các ô bảng theo thứ tự `(cột, hàng)`.

## **Xác định ô bảng đã hợp nhất**

Ví dụ mở một bản trình bày hiện có và truy cập hình dạng đầu tiên trên slide đầu tiên dưới dạng bảng. Giả sử slide và hình dạng tồn tại và hình dạng là bảng. Sau đó duyệt qua mọi hàng và cột và sử dụng [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) để xác định các ô trong vùng hợp nhất. Đối với mỗi khớp, nó in tọa độ ô theo thứ tự `hàng;cột`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), và tọa độ bắt đầu của vùng, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) và [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

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

## **Xóa viền ô bảng**

Tạo một [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) và thêm bảng vào slide đầu tiên bằng [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). Độ rộng cột, chiều cao hàng và vị trí bảng được chỉ định bằng điểm. Ví dụ đặt cả bốn viền ô thành [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), khiến chúng không hiển thị.

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

## **Thêm viền chéo cho ô**

Sử dụng [getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/) để vẽ một đường từ góc trên‑trái đến góc dưới‑phải, và [getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/) để vẽ một đường từ góc dưới‑trái đến góc trên‑phải. Đường chéo có thể đánh dấu tiêu đề góc; hai đường chéo cùng nhau tạo thành chữ X để đánh dấu ô không áp dụng.

Mỗi đường chéo là một [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/). Trong [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/), dùng [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) để chọn [FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) và chọn màu qua [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/). Đặt độ rộng của đường bằng điểm bằng [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/).

Ví dụ tạo ba ô trong một hàng: một đường chéo xuống màu đỏ, một đường chéo lên màu xanh lam và cả hai đường chéo. Các viền trên, dưới, trái và phải của ô giữ nguyên.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [210, 210, 210]);
    const rowHeights = java.newArray("double", [160]);
    const table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    const downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    downwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    downwardBorder.setWidth(3);

    const upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    upwardBorder.setWidth(5);

    const crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    crossDownwardBorder.setWidth(3);

    const crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đường chéo là thuộc tính định dạng, không phải tách ô. Mỗi ô giữ một khung văn bản duy nhất, truy cập qua [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/); các vùng ở hai bên của đường chéo không thể chỉnh sửa độc lập.

Bảng đã lưu, được hiển thị trong Microsoft PowerPoint:

![Ba ô bảng hiển thị một đường chéo đỏ từ trên‑trái đến dưới‑phải, một đường chéo xanh lam từ dưới‑trái đến trên‑phải, và cả hai đường chéo tạo thành chữ X.](diagonal-cell-borders.png)

*Trái sang phải: đường chéo xuống (đỏ, 3 pt), đường chéo lên (xanh lam, 5 pt), và cả hai đường chéo.*

## **Hợp nhất ô bảng**

Sử dụng [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) để kết hợp một vùng hình chữ nhật của các ô thành một ô. Xác định các ô ở góc trên‑trái và góc dưới‑phải của vùng. Đối số cuối cùng điều khiển việc hợp nhất có thể bao gồm các ô ngoài phạm vi đã chỉ định; `false` giữ hợp nhất trong phạm vi đó.

Ví dụ tạo bảng 4×4 với cột và hàng có độ rộng 70 điểm, sau đó hợp nhất bốn ô trung tâm từ `(1, 1)` đến `(2, 2)`. Ô kết quả phủ rộng hai cột và hai hàng, trong khi lưới cơ bản của bảng vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã hợp nhất, dùng vị trí góc trên‑trái: `table.get_Item(1, 1)` trong ví dụ này. Các vị trí khác trong vùng hợp nhất vẫn là một phần của lưới bảng, vì vậy chỉ số của các ô ngoài vùng không thay đổi.

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

## **Tách ô bảng**

Việc hợp nhất ô trong ví dụ trước giữ nguyên lưới bảng. Tách một ô có thể tạo thêm một cột lưới mới và thay đổi chỉ số cột của các ô nằm bên phải nó. Aspose.Slides tuân theo mô hình lưới bảng của PowerPoint.

Ví dụ này tạo bảng 4×4 với cột và hàng có độ rộng 70 điểm và gọi [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) trên ô `(1, 1)`. Một nửa độ rộng 70 điểm của ô được truyền vào để tạo hai ô có độ rộng bằng nhau.

Sau khi tách, hai nửa được truy cập dưới dạng `table.get_Item(1, 1)` và `table.get_Item(2, 1)`. Lưới bảng hiện có năm cột: các ô ban đầu ở cột 2 và 3 chuyển sang cột 3 và 4 tương ứng. Chỉ số hàng giữ nguyên. Sử dụng các chỉ số cột đã cập nhật khi truy cập ô sau khi tách.

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

<!-- visual-explanation:manage-cells:start -->
[![Một ô 70 điểm chưa hợp nhất tách thành hai ô 35 điểm, thêm một cột lưới thứ năm và dịch các chỉ số sang phải.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Việc tách độ rộng ảnh hưởng đến ô (1, 1), sử dụng chỉ số bắt đầu từ 0 (cột, hàng). Các hàng khác giữ ô phủ cả hai vị trí cột mới.*
<!-- visual-explanation:manage-cells:end -->

### **Tách ô đã hợp nhất theo hàng hoặc cột**

Để chuẩn bị các ô mẫu đã hợp nhất cho việc nhập dữ liệu, sử dụng [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) để tách theo ranh giới hàng hiện có, hoặc [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) để tách theo ranh giới cột.

Đối số `index` đếm số hàng ở phần trên hoặc số cột ở phần trái của phép tách; nó tương đối với vùng đã hợp nhất:

- Tách hàng: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Tách cột: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Ví dụ giả định bản trình bày có một bảng là hình dạng đầu tiên trên slide đầu tiên, với `(1, 2)` và `(1, 3)` hợp nhất theo chiều dọc. Bắt đầu từ vị trí thấp hơn, nó dùng [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) và [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) để xác định nguồn gốc và kiểm tra cả hai phạm vi. `splitByRowSpan(1)` sau đó tách các hàng 2 và 3 cho tên sản phẩm. Đối với hợp nhất ngang hai cột, dùng `splitByColSpan(1)` thay thế.

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

Lưới bảng và các chỉ số ô xung quanh không thay đổi. Lấy các ô kết quả theo tọa độ; ở đây, cả hai đều có phạm vi 1 và [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) trả về `false`. Các vùng lớn hơn có thể vẫn còn một phần hợp nhất sau một lần tách.

Văn bản gốc và định dạng của nó vẫn ở ô trên (hoặc trái); ô mới rỗng nhưng kế thừa định dạng ô như màu nền, viền và lề. Hãy điền dữ liệu vào các ô sau khi tách và đặt bất kỳ định dạng văn bản cần thiết nào một cách rõ ràng.

Bản trình bày đã lưu chứa các ô “Product A” và “Product B” riêng biệt với định dạng ô mẫu được giữ nguyên. Xem [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) để biết chi tiết.

### **Tách ô theo chiều cao cụ thể**

[splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/) nhận chiều cao của phần trên bằng điểm. [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) nhận số hàng lưới hiện có ở phần trên. Để căn giữa một ô 40 điểm trong cột phải, trừ 40 điểm từ chiều cao thực tế của ô và chia phần còn lại đều lên trên và dưới ô.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [160, 160]);
    const rowHeights = java.newArray("double", [140]);

    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    const height = table.get_Item(1, 0).getHeight();
    const margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lần tách đầu tiên thêm một hàng lưới và để lại 90 điểm ở ô `(1, 1)`. Lần tách thứ hai chia ô đó thành một ô giữa 40 điểm và một ô dưới 50 điểm. Cột phải hiện có ba ô với chiều cao lần lượt là 50, 40 và 50 điểm từ trên xuống dưới. Ô trái phủ ba hàng và giữ nguyên chiều cao gốc 140 điểm.

![Ô trái phủ toàn bộ chiều cao bảng bên cạnh ba ô có “Middle” ở giữa.](split-by-height.png)

## **Thay đổi màu nền ô bảng**

Ví dụ này tạo bảng với cột 150 điểm và hàng 50 điểm. Nó sử dụng [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) để chọn tô đầy đặc và đặt màu trả về bởi [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) thành màu đỏ cho ô `(2, 3)`, nằm ở cột thứ ba và hàng thứ tư.

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

## **Thêm hình ảnh vào bên trong ô bảng**

Đặt hình ảnh đầu vào trong thư mục làm việc trước khi chạy ví dụ này. Nó tải hình ảnh bằng [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) và thêm nó vào bộ sưu tập hình ảnh của bản trình bày bằng [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). Sau đó gán hình ảnh cho nền picture fill của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) kéo dài hình ảnh để lấp đầy ô, có thể thay đổi tỷ lệ khung hình. Độ rộng cột và chiều cao hàng tính bằng điểm. Hình ảnh đã tải sẽ được giải phóng trong khối `finally` sau khi được thêm vào bản trình bày.

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

**Tôi có thể đặt độ dày và kiểu đường viền khác nhau cho các phía của một ô duy nhất không?**

Có. Các viền [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi phía có thể khác nhau.

**Điều gì xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đã đặt picture làm nền cho ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Khi kéo dài, hình ảnh sẽ điều chỉnh theo ô mới; khi gạch lát, các ô sẽ được tính lại.

**Tôi có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/nodejs-java/manage-hyperlinks/) được đặt ở mức văn bản (phần) bên trong khung văn bản của ô hoặc ở mức toàn bộ bảng/hình dạng. Thực tế, bạn gán liên kết cho một phần hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt phông chữ khác nhau trong cùng một ô không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (run) với định dạng độc lập—gia đình phông, kiểu, kích thước và màu.