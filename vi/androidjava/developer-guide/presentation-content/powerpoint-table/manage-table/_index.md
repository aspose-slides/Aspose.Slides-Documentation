---
title: Quản lý Bảng trong Bản trình chiếu trên Android
linktitle: Quản lý Bảng
type: docs
weight: 10
url: /vi/androidjava/manage-table/
keywords:
- thêm bảng
- tạo bảng
- truy cập bảng
- tỷ lệ khía cạnh
- căn chỉnh văn bản
- định dạng văn bản
- kiểu bảng
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tạo & chỉnh sửa bảng trong các slide PowerPoint bằng Aspose.Slides cho Android. Khám phá các ví dụ mã Java đơn giản để tối ưu hoá quy trình làm việc với bảng của bạn."
---
## **Giới thiệu**

Bảng trong PowerPoint sắp xếp thông tin thành các hàng và cột, giúp dễ đọc và so sánh các giá trị hơn.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) , giao diện [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) , lớp [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) , giao diện [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) và các kiểu khác để cho phép bạn tạo, cập nhật và quản lý các bảng trong bản trình chiếu.

## **Tạo một Bảng từ Đầu**

Tạo một bảng bằng cách chỉ định vị trí, độ rộng cột và chiều cao hàng. Sau khi thêm vào một slide, bạn có thể định dạng viền ô, hợp nhất ô và chèn văn bản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide bằng chỉ mục của nó.
3. Xác định một mảng độ rộng cột bằng điểm.
4. Xác định một mảng chiều cao hàng bằng điểm.
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) .
6. Lặp lại qua mỗi [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) để áp dụng định dạng cho các viền trên, dưới, phải và trái.
7. Hợp nhất hai ô đầu tiên của hàng đầu tiên của bảng.
8. Truy cập vào ô đã hợp nhất thông qua phương thức [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) .
9. Đặt văn bản trong ô đã hợp nhất.
10. Lưu bản trình chiếu đã sửa đổi.

Ví dụ dưới đây tạo một bảng với ba cột và năm hàng tại vị trí (100, 50) điểm. Nó áp dụng viền đỏ với độ rộng 5 điểm, hợp nhất hai ô đầu tiên trong hàng đầu tiên, và lưu kết quả dưới dạng `table.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Đánh số trong Bảng Tiêu chuẩn**

Trong một bảng tiêu chuẩn, chỉ số ô bắt đầu từ 0 và sử dụng thứ tự (cột, hàng). Ô đầu tiên có chỉ số là (0, 0).

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ví dụ này tạo bảng 4 × 4 như trên, với độ rộng cột và chiều cao hàng là 70 điểm và viền ô đỏ có độ rộng 5 điểm. Các tọa độ minh họa chỉ số ô; ví dụ để các ô trống và lưu bảng dưới dạng `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Truy cập Bảng hiện có**

Các bảng được lưu trong bộ sưu tập shape của slide. Duyệt qua các shape để tìm một bảng, sau đó sử dụng giao diện [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) để đọc hoặc cập nhật các ô của nó.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide chứa bảng bằng chỉ mục của nó.
3. Duyệt qua các đối tượng [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) và dừng lại khi tìm thấy một bảng. Nếu slide chứa nhiều bảng, sử dụng [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) để xác định bảng bạn cần.
4. Cập nhật văn bản trong ô mục tiêu.
5. Lưu bản trình chiếu đã sửa đổi.

Ví dụ dưới đây mở `UpdateExistingTable.pptx` và tìm bảng đầu tiên trên slide đầu tiên. Nó đặt ô ở cột 0, hàng 1 thành `New` và lưu kết quả dưới dạng `table1_out.pptx`. Tệp đầu vào phải chứa ít nhất một slide, và bảng đầu tiên trên slide đó phải có ít nhất một cột và hai hàng.

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

Để thay đổi kích thước hàng trong một bảng hiện có và hiểu tại sao chiều cao thực tế có thể vượt quá chiều cao tối thiểu đã yêu cầu, hãy xem [Control Row Height](/slides/vi/androidjava/manage-rows-and-columns/#control-row-height).

## **Tìm ô Chủ sở hữu Khung Văn bản**

Khi mã xử lý văn bản chung nhận được một [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) từ một bảng, sử dụng phương thức [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) để lấy [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) sở hữu. Đối với khung văn bản của ô bảng, [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) trả về chủ sở hữu và [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) trả về `null`, mặc dù bảng tự nó là một shape.

Các tọa độ ô có sẵn thông qua các phương thức chỉ đọc [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) và [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--). [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) cũng cung cấp điều hướng chỉ đọc: nó trả về chủ sở hữu nhưng không thay đổi quyền sở hữu. Luôn kiểm tra ô trả về có `null` trước khi sử dụng.

Để xem ví dụ đầy đủ xác định chủ sở hữu ô bảng và shape, bao gồm các shape liên quan tới nút SmartArt, hãy xem [Search and Replace Text](/slides/vi/androidjava/search-and-replace-text/).

## **Căn chỉnh Văn bản trong Bảng**

Bạn có thể kiểm soát việc neo dọc và hướng văn bản của các ô riêng lẻ. Ví dụ trong phần này căn giữa văn bản trong ô đầu tiên và xoay nó 270 độ.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide bằng chỉ mục của nó.
3. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) vào slide.
4. Truy cập một đối tượng [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) từ bảng.
5. Truy cập [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) đầu tiên và đặt văn bản và màu sắc cho nó.
6. Đặt căn dọc của ô và hướng văn bản bằng cách sử dụng [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) và [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-).
7. Lưu bản trình chiếu đã sửa đổi.

Ví dụ này tạo bảng 4 × 4 với độ rộng cột 120 điểm và chiều cao hàng 100 điểm. Nó định dạng văn bản trong ô (0, 0), thêm giá trị vào các ô còn lại trong hàng đầu tiên, và lưu kết quả dưới dạng `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Đặt Định dạng Văn bản ở Cấp độ Bảng**

Sử dụng [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) để áp dụng định dạng văn bản cho tất cả các ô trong một bảng. Các phiên bản overload cho phép định dạng phần, đoạn và khung văn bản, vì vậy bạn có thể đặt các thuộc tính này mà không cần lặp qua từng ô.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide bằng chỉ mục của nó.
3. Truy cập một đối tượng [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) từ slide.
4. Đặt kích thước phông chữ bằng cách sử dụng [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) cho văn bản.
5. Đặt căn chỉnh đoạn và lề phải bằng [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) và [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Đặt hướng văn bản bằng [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Lưu bản trình chiếu đã sửa đổi.

Ví dụ dưới đây mở `table.pptx`, tệp này phải chứa ít nhất một slide với một bảng là shape đầu tiên. Nó đặt kích thước phông chữ thành 25 điểm, căn phải các đoạn với lề phải 20 điểm và làm văn bản đứng dọc. Bản trình chiếu đã định dạng được lưu dưới tên `result.pptx`.

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

## **Lấy Thuộc tính Kiểu Bảng**

Sử dụng [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) để đọc kiểu đặt trước của bảng và [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) để chỉ định nó. Ví dụ này áp dụng [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) cho một bảng, in giá trị kiểu đặt trước, và gán cùng kiểu cho bảng thứ hai. Cả hai bảng được lưu trong `table-style.pptx`.

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

## **Khóa Tỷ lệ Khía cạnh của Bảng**

Tỷ lệ khía cạnh của một bảng là tỉ lệ giữa chiều rộng và chiều cao của nó. Sử dụng [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) để khóa tỉ lệ này cho một bảng.

Ví dụ dưới đây mở `pres.pptx`, tệp này phải chứa ít nhất một slide với một bảng là shape đầu tiên. Nó in trạng thái khóa hiện tại, bật khóa tỷ lệ khía cạnh, in trạng thái đã cập nhật (`true`), và lưu kết quả dưới dạng `pres-out.pptx`.

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

## **FAQ**

**Tôi có thể bật hướng đọc phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Có. Bảng cung cấp phương thức [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-), và các đoạn có [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Sử dụng cả hai đảm bảo thứ tự RTL đúng và hiển thị bên trong các ô.

**Làm thế nào để ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong file cuối cùng?**

Sử dụng [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) để vô hiệu hoá việc di chuyển, thay đổi kích thước, chọn, v.v. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn hình ảnh vào ô làm nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) cho ô; hình ảnh sẽ bao phủ khu vực ô theo chế độ được chọn (giãn hoặc lát).