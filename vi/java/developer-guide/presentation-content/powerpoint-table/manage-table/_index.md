---
title: Quản lý Bảng trong Bản Thuyết trình Java
linktitle: Quản lý Bảng
type: docs
weight: 10
url: /vi/java/manage-table/
keywords:
- thêm bảng
- tạo bảng
- truy cập bảng
- tỷ lệ khung hình
- canh chỉnh văn bản
- định dạng văn bản
- kiểu bảng
- PowerPoint
- bản thuyết trình
- Java
- Aspose.Slides
description: "Tạo và chỉnh sửa bảng trong các slide PowerPoint bằng Aspose.Slides cho Java. Khám phá các ví dụ mã đơn giản để tối ưu hóa quy trình làm việc với bảng."
---
## **Giới thiệu**

Bảng trong PowerPoint tổ chức thông tin thành các hàng và cột, giúp dễ đọc và so sánh các giá trị hơn.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/), giao diện [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/), lớp [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/), giao diện [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) và các loại khác để cho phép bạn tạo, cập nhật và quản lý các bảng trong bản thuyết trình.

## **Tạo bảng từ đầu**

Tạo một bảng bằng cách chỉ định vị trí, độ rộng cột và chiều cao hàng. Sau khi thêm vào một slide, bạn có thể định dạng viền ô, hợp nhất ô và chèn văn bản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Lấy tham chiếu đến slide theo chỉ số của nó.
3. Định nghĩa một mảng các độ rộng cột tính bằng điểm.
4. Định nghĩa một mảng các chiều cao hàng tính bằng điểm.
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Duyệt qua mỗi [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) để áp dụng định dạng cho các viền trên, dưới, phải và trái.
7. Hợp nhất hai ô đầu tiên của hàng đầu tiên trong bảng.
8. Truy cập ô đã hợp nhất qua phương thức [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) .
9. Đặt văn bản trong ô đã hợp nhất.
10. Lưu bản thuyết trình đã sửa đổi.

Ví dụ dưới đây tạo một bảng có ba cột và năm hàng tại vị trí (100, 50) điểm. Nó áp dụng viền đỏ với độ rộng 5 điểm, hợp nhất hai ô đầu tiên trong hàng đầu tiên và lưu kết quả dưới tên `table.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đánh số trong bảng tiêu chuẩn**

Trong một bảng tiêu chuẩn, chỉ số ô bắt đầu từ 0 và sử dụng thứ tự (cột, hàng). Ô đầu tiên có chỉ số là (0, 0).

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ví dụ này tạo bảng 4 × 4 được minh họa ở trên, với độ rộng cột và chiều cao hàng là 70 điểm và viền ô màu đỏ có độ rộng 5 điểm. Các tọa độ minh họa chỉ số ô; ví dụ để trống các ô và lưu bảng dưới tên `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Truy cập bảng đã tồn tại**

Các bảng được lưu trong bộ sưu tập hình dạng của slide. Duyệt qua các hình dạng để tìm bảng, sau đó sử dụng giao diện [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) để đọc hoặc cập nhật các ô của nó.

1. Tải bản thuyết trình bằng lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Lấy tham chiếu đến slide chứa bảng theo chỉ số của nó.
3. Duyệt qua các đối tượng [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) và dừng lại khi tìm thấy bảng. Nếu slide chứa nhiều bảng, sử dụng [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) để xác định bảng cần thiết.
4. Cập nhật văn bản trong ô mục tiêu.
5. Lưu bản thuyết trình đã sửa đổi.

Ví dụ dưới đây mở `UpdateExistingTable.pptx` và tìm bảng đầu tiên trên slide đầu tiên. Nó đặt ô ở cột 0, hàng 1 thành `New` và lưu kết quả dưới tên `table1_out.pptx`. Tập tin đầu vào phải chứa ít nhất một slide, và bảng đầu tiên trên slide đó phải có ít nhất một cột và hai hàng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Để thay đổi kích thước hàng trong một bảng đã tồn tại và hiểu vì sao chiều cao thực tế có thể vượt quá mức tối thiểu đã yêu cầu, xem [Control Row Height](/slides/vi/java/manage-rows-and-columns/#control-row-height).

## **Tìm ô chứa một khung văn bản**

Khi mã xử lý văn bản chung nhận được một đối tượng [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) từ bảng, sử dụng phương thức [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) để lấy ô sở hữu [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/). Đối với khung văn bản của ô bảng, [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) trả về chủ sở hữu và [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) trả về `null`, mặc dù bảng tự nó cũng là một hình dạng.

Các tọa độ ô có sẵn thông qua các phương thức chỉ-đọc [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) và [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--). [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) cũng cung cấp khả năng điều hướng chỉ-đọc: nó trả về chủ sở hữu nhưng không thay đổi quyền sở hữu. Luôn kiểm tra giá trị trả về có `null` trước khi sử dụng.

Đối với một ví dụ hoàn chỉnh xác định chủ sở hữu ô bảng và hình dạng, bao gồm các hình dạng liên quan đến nút SmartArt, xem [Search and Replace Text](/slides/vi/java/search-and-replace-text/).

## **Canh chỉnh văn bản trong bảng**

Bạn có thể kiểm soát việc neo dọc và hướng văn bản của từng ô bảng. Ví dụ trong phần này căn giữa văn bản trong ô đầu tiên và xoay nó 270 độ.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Lấy tham chiếu đến slide theo chỉ số của nó.
3. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) vào slide.
4. Truy cập một đối tượng [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) từ bảng.
5. Truy cập đoạn văn [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) đầu tiên và đặt văn bản cũng như màu sắc cho nó.
6. Đặt neo dọc và hướng văn bản của ô bằng cách sử dụng [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) và [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-).
7. Lưu bản thuyết trình đã sửa đổi.

Ví dụ này tạo một bảng 4 × 4 với độ rộng cột 120 điểm và chiều cao hàng 100 điểm. Nó định dạng văn bản trong ô (0, 0), thêm giá trị vào các ô còn lại trong hàng đầu tiên và lưu kết quả dưới tên `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt định dạng văn bản ở mức bảng**

Sử dụng [setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) để áp dụng định dạng văn bản cho tất cả các ô trong một bảng. Các overload của nó chấp nhận định dạng phần, đoạn và khung văn bản, cho phép bạn đặt các thuộc tính này mà không cần duyệt qua từng ô riêng lẻ.

1. Tải bản thuyết trình bằng lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Lấy tham chiếu đến slide theo chỉ số của nó.
3. Truy cập một đối tượng [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) từ slide.
4. Đặt kích thước phông chữ bằng [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) cho văn bản.
5. Đặt căn chỉnh đoạn và lề phải bằng [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) và [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Đặt hướng văn bản bằng [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Lưu bản thuyết trình đã sửa đổi.

Ví dụ dưới đây mở `table.pptx`, bản này phải chứa ít nhất một slide có bảng là hình dạng đầu tiên. Nó đặt kích thước phông chữ thành 25 điểm, căn phải các đoạn với lề phải 20 điểm và làm văn bản theo chiều dọc. Bản thuyết trình đã định dạng được lưu dưới tên `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lấy thuộc tính kiểu bảng**

Sử dụng [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) để đọc kiểu mẫu đã đặt trước của bảng và [setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) để gán nó. Ví dụ này áp dụng [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) cho một bảng, in ra giá trị mẫu, và gán cùng mẫu cho bảng thứ hai. Cả hai bảng được lưu trong `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Khóa tỷ lệ khung hình của bảng**

Tỷ lệ khung hình của bảng là tỉ lệ giữa chiều rộng và chiều cao. Sử dụng [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) để khóa tỉ lệ này cho một bảng.

Ví dụ dưới đây mở `pres.pptx`, bản này phải chứa ít nhất một slide có bảng là hình dạng đầu tiên. Nó in ra trạng thái khóa hiện tại, bật khóa tỷ lệ khung hình, in ra trạng thái đã cập nhật (`true`), và lưu kết quả dưới tên `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể bật chế độ đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô không?**

Có. Bảng cung cấp phương thức [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-), và các đoạn có [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Sử dụng cả hai đảm bảo thứ tự RTL và việc hiển thị đúng bên trong các ô.

**Làm sao ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong tệp cuối cùng?**

Sử dụng [shape locks](/slides/vi/java/applying-protection-to-presentation/) để vô hiệu hoá việc di chuyển, thay đổi kích thước, chọn, v.v. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn ảnh vào ô làm nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) cho ô; ảnh sẽ bao phủ vùng ô theo chế độ đã chọn (kéo dài hoặc lặp).