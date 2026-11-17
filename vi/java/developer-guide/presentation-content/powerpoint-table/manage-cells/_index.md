---
title: Quản lý các ô bảng trong bản trình bày bằng Java
linktitle: Quản lý Ô
type: docs
weight: 30
url: /vi/java/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa đường viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Quản lý các ô bảng PowerPoint trong Java: xác định các ô đã hợp nhất, xóa đường viền, tách ô, và đặt màu nền và hình ảnh với Aspose.Slides cho Java."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và chỉnh sửa các ô bảng trong bản trình bày PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa đường viền ô, làm việc với việc đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô, và thêm hình ảnh bên trong một ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình bày, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính của ô, và lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ mục bắt đầu từ 0 để truy cập các ô bảng theo thứ tự `(column, row)`.

## **Xác định ô bảng đã hợp nhất**

Ví dụ mở một bản trình bày hiện có và truy cập hình dạng đầu tiên trên slide đầu tiên dưới dạng bảng. Nó giả định rằng slide và hình dạng tồn tại và hình dạng là một bảng. Sau đó nó lặp qua tất cả các hàng và cột và sử dụng [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) để xác định các ô trong vùng đã hợp nhất. Đối với mỗi kết quả khớp, nó in tọa độ ô theo thứ tự `row;column`, [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), và tọa độ bắt đầu của vùng, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) và [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Xóa đường viền ô bảng**

Tạo một [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) và thêm một bảng vào slide đầu tiên của nó bằng [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Chiều rộng cột, chiều cao hàng và vị trí bảng được chỉ định bằng điểm. Ví dụ đặt tất cả bốn đường viền ô thành [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/), khiến chúng trở nên vô hình.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm đường viền chéo cho ô**

Sử dụng [getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) để vẽ một đường từ góc trên‑trái đến góc dưới‑phải, và [getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) để vẽ một đường từ góc dưới‑trái đến góc trên‑phải. Đường chéo có thể đánh dấu tiêu đề góc; cả hai đường chéo có thể tạo thành một ký hiệu X để đánh dấu ô là không áp dụng.

Mỗi đường chéo là một [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/). Trong [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) của nó, sử dụng [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) để chọn [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) và chọn màu qua [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--). Đặt độ rộng của đường bằng điểm bằng [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-).

Ví dụ tạo ba ô trong một hàng: một đường chéo đỏ đi xuống, một đường chéo xanh đi lên, và cả hai đường chéo. Nó để nguyên các đường viền trên, dưới, trái và phải của ô.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Một đường chéo là một thuộc tính định dạng, không phải là việc tách ô. Mỗi ô giữ lại một khung văn bản duy nhất, truy cập thông qua [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--); các vùng ở hai phía của đường chéo không thể chỉnh sửa độc lập.

Bảng đã lưu, được hiển thị trong Microsoft PowerPoint:

![Ba ô bảng hiển thị một đường chéo đỏ từ góc trên‑trái đến góc dưới‑phải, một đường chéo xanh từ góc dưới‑trái đến góc trên‑phải, và cả hai đường chéo tạo thành chữ X.](diagonal-cell-borders.png)

*Trái sang phải: đường chéo xuống (đỏ, 3 pt), đường chéo lên (xanh, 5 pt), và cả hai đường chéo.*

## **Hợp nhất các ô bảng**

Sử dụng [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) để kết hợp một phạm vi hình chữ nhật của các ô bảng thành một ô duy nhất. Xác định các ô ở góc trên‑trái và góc dưới‑phải của phạm vi. Tham số cuối cùng kiểm soát việc hợp nhất có thể bao gồm các ô ngoài phạm vi đã chỉ định; `false` giữ hợp nhất trong phạm vi đó.

Ví dụ tạo một bảng 4×4 với các cột và hàng có độ rộng/độ cao 70 điểm, sau đó hợp nhất bốn ô trung tâm từ `(1, 1)` đến `(2, 2)`. Ô kết quả chiếm hai cột và hai hàng, trong khi lưới nền của bảng vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã hợp nhất, sử dụng vị trí góc trên‑trái của nó: `table.get_Item(1, 1)` trong ví dụ này. Các vị trí khác trong phạm vi hợp nhất vẫn là một phần của lưới bảng, vì vậy chỉ mục của các ô ngoài phạm vi không thay đổi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tách các ô bảng**

Merging cells in the previous example preserves the table's grid. Splitting a cell can introduce a new grid column and change the column indices of cells to its right. Aspose.Slides follows PowerPoint's table grid model.

This example creates a 4-by-4 table with 70-point columns and rows and calls [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) on cell `(1, 1)`. Half of the cell's 70-point width is passed to create two equal-width cells.

After this split, the two halves are accessed as `table.get_Item(1, 1)` and `table.get_Item(2, 1)`. The table grid now has five columns: cells originally in columns 2 and 3 move to columns 3 and 4, respectively. Row indices remain unchanged. Use these updated column indices when accessing cells after the split.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![Một ô 70-point chưa hợp nhất được tách thành hai ô 35-point, thêm một cột lưới thứ năm và dịch các chỉ số sang bên phải của nó.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Việc tách chiều rộng ảnh hưởng đến ô (1, 1), sử dụng chỉ mục bắt đầu từ 0 (cột, hàng). Các hàng khác giữ ô kéo dài qua cả hai vị trí cột mới.*
<!-- visual-explanation:manage-cells:end -->

### **Tách các ô đã hợp nhất theo độ cao hàng hoặc độ rộng cột**

Để chuẩn bị các ô mẫu đã hợp nhất cho việc điền dữ liệu, sử dụng [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) để tách theo ranh giới hàng hiện có, hoặc [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) để tách theo ranh giới cột.

Tham số `index` đếm các hàng ở phần trên hoặc các cột ở phần trái của việc tách; nó tương đối với vùng đã hợp nhất:

- Tách theo hàng: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- Tách theo cột: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

Ví dụ yêu cầu bản trình bày có một bảng là hình dạng đầu tiên trên slide đầu tiên, với `(1, 2)` và `(1, 3)` hợp nhất theo chiều dọc. Bắt đầu từ vị trí thấp hơn, nó sử dụng [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) và [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) để xác định nguồn gốc và kiểm tra cả hai độ rộng. `splitByRowSpan(1)` sau đó tách các hàng 2 và 3 cho tên sản phẩm. Đối với một hợp nhất ngang hai cột, sử dụng `splitByColSpan(1)` thay thế.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Lấy các ô kết quả từ bảng sau khi tách.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Lưới bảng và các chỉ mục ô xung quanh vẫn không thay đổi. Lấy các ô kết quả bằng tọa độ của chúng; ở đây, cả hai đều có độ rộng 1 và [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) in ra `false`. Các vùng lớn hơn có thể vẫn phần nào hợp nhất sau một lần tách.

Văn bản gốc và định dạng của nó vẫn ở ô trên (hoặc trái); ô mới trống nhưng kế thừa định dạng ô như màu nền, đường viền và lề. Điền dữ liệu vào các ô sau khi tách và thiết lập bất kỳ định dạng văn bản nào cần thiết một cách rõ ràng.

Bản trình bày đã lưu chứa các ô riêng biệt "Product A" và "Product B" với định dạng ô của mẫu được giữ lại. Xem [Tham chiếu API Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) để biết chi tiết.

### **Tách một ô ở chiều cao cụ thể**

[splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) lấy chiều cao của phần trên tính bằng điểm. [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) lấy số hàng lưới hiện có ở phần trên. Để căn giữa một ô 40 điểm trong cột phải, lấy chiều cao thực tế của ô trừ 40 và chia phần còn lại đều cho phần trên và phần dưới.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };
    
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lần tách đầu tiên thêm một hàng lưới và để lại 90 điểm ở phần dưới của ô `(1, 1)`. Lần tách thứ hai chia ô đó thành một ô giữa 40 điểm và một ô dưới 50 điểm. Cột phải bây giờ có ba ô với chiều cao 50, 40 và 50 điểm từ trên xuống dưới. Ô trái kéo dài qua cả ba hàng và giữ nguyên chiều cao gốc 140 điểm.

![Ô bên trái kéo dài toàn bộ chiều cao bảng bên cạnh ba ô với ô Giữa ở trung tâm.](split-by-height.png)

## **Thay đổi màu nền ô bảng**

Ví dụ này tạo một bảng với các cột 150 điểm và các hàng 50 điểm. Nó sử dụng [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) để chọn màu nền đặc và đặt màu trả về bởi [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) thành màu đỏ cho ô `(2, 3)`, ở cột thứ ba và hàng thứ tư.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm hình ảnh vào trong ô bảng**

Đặt ảnh đầu vào trong thư mục làm việc trước khi chạy ví dụ này. Nó tải ảnh bằng [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) và thêm nó vào bộ sưu tập ảnh của bản trình bày bằng [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Sau đó nó gán ảnh cho phần hình ảnh của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) kéo dài ảnh để lấp đầy ô, có thể thay đổi tỷ lệ khung hình. Chiều rộng cột và chiều cao hàng được tính bằng điểm. Ảnh đã tải sẽ được giải phóng trong khối `finally` sau khi đã thêm vào bản trình bày.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Có thể đặt độ dày và kiểu đường viền khác nhau cho từng phía của một ô duy nhất không?**

Có. Các đường viền [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi phía có thể khác nhau.

**Điều gì xảy ra với ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đã đặt hình ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile). Khi kéo dài, ảnh sẽ điều chỉnh theo ô mới; khi ghép lát, các lát sẽ được tính lại.

**Có thể gắn siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/java/manage-hyperlinks/) được đặt ở mức đoạn văn bản (portion) bên trong khung văn bản của ô hoặc ở mức toàn bảng/hình dạng. Trong thực tế, bạn gán liên kết cho một đoạn hoặc cho toàn bộ văn bản trong ô.

**Có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (run) với định dạng độc lập—gia đình phông, kiểu, kích thước và màu.