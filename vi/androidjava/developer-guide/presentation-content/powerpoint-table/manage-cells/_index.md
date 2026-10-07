---
title: Quản lý các ô bảng trong bản trình chiếu trên Android
linktitle: Quản lý ô
type: docs
weight: 30
url: /vi/androidjava/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa đường viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Quản lý các ô bảng PowerPoint trên Android: xác định các ô đã hợp nhất, xóa đường viền, tách ô, và đặt màu nền cũng như hình ảnh bằng Aspose.Slides cho Android qua Java."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và chỉnh sửa các ô bảng trong bản trình chiếu PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa đường viền ô, làm việc với đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô, và thêm hình ảnh vào bên trong một ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình chiếu, lấy bảng từ một slide, cập nhật định dạng ô qua các thuộc tính ô, và lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ số bắt đầu từ 0 để truy cập các ô bảng theo thứ tự `(column, row)`.

## **Xác định ô bảng đã hợp nhất**

Ví dụ mở một bản trình chiếu hiện có và truy cập hình dạng đầu tiên trên slide đầu tiên dưới dạng bảng. Nó giả định rằng slide và hình dạng tồn tại và hình dạng là một bảng. Sau đó nó duyệt qua tất cả các hàng và cột và sử dụng [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) để xác định các ô trong vùng đã hợp nhất. Đối với mỗi kết quả phù hợp, nó in tọa độ ô theo thứ tự `row;column`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), và tọa độ bắt đầu của vùng, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) và [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

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

Tạo một [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) và thêm một bảng vào slide đầu tiên của nó bằng [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Độ rộng cột, chiều cao hàng và vị trí bảng được chỉ định bằng điểm. Ví dụ đặt bốn đường viền ô thành [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), khiến chúng không hiển thị.

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

## **Hợp nhất các ô bảng**

Sử dụng [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) để kết hợp một phạm vi hình chữ nhật của các ô bảng thành một ô. Chỉ định các ô ở góc trên‑trái và góc dưới‑phải của phạm vi. Tham số cuối cùng kiểm soát việc hợp nhất có thể bao gồm các ô ngoài phạm vi chỉ định hay không; `false` giữ hợp nhất trong phạm vi đó.

Ví dụ tạo một bảng 4‑by‑4 với các cột và hàng có độ rộng 70 điểm, sau đó hợp nhất bốn ô trung tâm từ `(1, 1)` tới `(2, 2)`. Ô kết quả chiếm hai cột và hai hàng, trong khi lưới cơ sở của bảng vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã hợp nhất, sử dụng vị trí trên‑trái của nó: `table.get_Item(1, 1)` trong ví dụ này. Các vị trí khác trong phạm vi hợp nhất vẫn là một phần của lưới bảng, vì vậy chỉ số của các ô nằm ngoài phạm vi không thay đổi.

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

Việc hợp nhất các ô trong ví dụ trước giữ nguyên lưới của bảng. Tách một ô có thể tạo ra một cột lưới mới và thay đổi chỉ số cột của các ô phía bên phải nó. Aspose.Slides tuân theo mô hình lưới bảng của PowerPoint.

Ví dụ này tạo một bảng 4‑by‑4 với các cột và hàng có độ rộng 70 điểm và gọi [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) trên ô `(1, 1)`. Một nửa độ rộng 70 điểm của ô được truyền vào để tạo hai ô có độ rộng bằng nhau.

Sau khi tách, hai nửa ô được truy cập dưới dạng `table.get_Item(1, 1)` và `table.get_Item(2, 1)`. Lưới bảng bây giờ có năm cột: các ô ban đầu ở cột 2 và 3 chuyển sang cột 3 và 4 tương ứng. Chỉ số hàng vẫn không thay đổi. Sử dụng các chỉ số cột đã cập nhật khi truy cập các ô sau khi tách.

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

### **Tách các ô đã hợp nhất theo phạm vi hàng hoặc cột**

Để chuẩn bị các ô mẫu đã hợp nhất cho việc đưa dữ liệu, sử dụng [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) để tách theo ranh giới hàng hiện có, hoặc [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) để tách theo ranh giới cột.

Tham số `index` đếm các hàng ở phần trên hoặc các cột ở phần trái của việc tách; nó tương đối với vùng đã hợp nhất:

- Tách hàng: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Tách cột: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Ví dụ giả định bản trình chiếu có một bảng là hình dạng đầu tiên trên slide đầu tiên, với các ô `(1, 2)` và `(1, 3)` hợp nhất theo chiều dọc. Bắt đầu từ vị trí thấp hơn, nó sử dụng [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) và [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) để xác định gốc và kiểm tra cả hai phạm vi. `splitByRowSpan(1)` sau đó tách các hàng 2 và 3 cho tên sản phẩm. Đối với hợp nhất ngang hai cột, thay vào đó dùng `splitByColSpan(1)`.

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

Lưới bảng và các chỉ số ô xung quanh vẫn không thay đổi. Lấy các ô kết quả bằng tọa độ của chúng; ở đây, cả hai có phạm vi 1 và [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) trả về `false`. Các vùng lớn hơn có thể vẫn còn một phần hợp nhất sau một lần tách.

Văn bản gốc và định dạng của nó vẫn ở ô trên (hoặc trái); ô mới rỗng nhưng kế thừa định dạng ô như màu nền, đường viền và lề. Điền nội dung vào các ô sau khi tách và đặt bất kỳ định dạng văn bản yêu cầu nào một cách rõ ràng.

Bản trình chiếu đã lưu chứa các ô riêng biệt “Product A” và “Product B” với định dạng ô của mẫu được giữ nguyên. Xem [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) để biết chi tiết.

## **Thay đổi màu nền ô bảng**

Ví dụ này tạo một bảng với các cột 150 điểm và các hàng 50 điểm. Nó sử dụng [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) để chọn màu nền đặc và đặt màu trả về bởi [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) thành màu đỏ cho ô `(2, 3)`, trong cột thứ ba và hàng thứ tư.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Đặt hình ảnh đầu vào trong thư mục làm việc trước khi chạy ví dụ này. Nó tải hình ảnh bằng [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) và thêm nó vào bộ sưu tập hình ảnh của bản trình chiếu bằng [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Sau đó nó gán hình ảnh cho phần lấp đầy hình ảnh của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) kéo dài hình ảnh để lấp đầy ô, có thể làm thay đổi tỷ lệ khung hình. Độ rộng cột và chiều cao hàng được tính bằng điểm. Hình ảnh đã tải sẽ được giải phóng trong khối `finally` sau khi đã được thêm vào bản trình chiếu.

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

**Có thể đặt độ dày và kiểu đường viền khác nhau cho các phía của một ô duy nhất không?**

Có. Các đường viền [trên](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[dưới](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[trái](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[phải](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi phía có thể khác nhau.

**Sẽ xảy ra gì với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đặt ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [chế độ lấp đầy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). Với chế độ stretch, hình ảnh sẽ điều chỉnh theo ô mới; với chế độ tile, các lát sẽ được tính lại.

**Có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/androidjava/manage-hyperlinks/) được đặt ở mức đoạn văn bản (portion) bên trong khung văn bản của ô hoặc ở mức toàn bảng/hình dạng. Trong thực tế, bạn gán liên kết cho một đoạn hoặc cho toàn bộ văn bản trong ô.

**Có thể đặt phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [đoạn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (runs) với định dạng độc lập — họa tiết phông, kiểu, kích thước và màu.