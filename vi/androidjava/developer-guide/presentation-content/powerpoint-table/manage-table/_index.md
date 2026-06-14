---
title: Quản lý bảng trình chiếu trên Android
linktitle: Quản lý Bảng
type: docs
weight: 10
url: /vi/androidjava/manage-table/
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
- Android
- Java
- Aspose.Slides
description: "Tạo & chỉnh sửa bảng trong slide PowerPoint với Aspose.Slides cho Android. Khám phá các ví dụ mã Java đơn giản để tối ưu hoá quy trình làm việc với bảng."
---
## **Giới thiệu**

Bảng trong PowerPoint là một cách hiệu quả để hiển thị và trình bày thông tin. Thông tin trong lưới các ô (được sắp xếp theo hàng và cột) dễ hiểu và trực quan.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Table), giao diện [ITable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITable), lớp [Cell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/cell/) , giao diện [ICell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icell/) và các kiểu khác để cho phép bạn tạo, cập nhật và quản lý bảng trong mọi loại bản trình chiếu.

## **Tạo bảng từ đầu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Xác định một mảng `columnWidth`.
4. Xác định một mảng `rowHeight`.
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITable) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Lặp qua từng [ICell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icell/) để áp dụng định dạng cho các đường viền trên, dưới, phải và trái.
7. Hợp nhất hai ô đầu tiên của hàng đầu tiên của bảng. 
8. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframe/) của một [ICell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icell/).
9. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframe/).
10. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã Java này cho bạn thấy cách tạo bảng trong một bản trình chiếu:

```java
// Tạo một đối tượng Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Định nghĩa các cột với độ rộng và các hàng với độ cao
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Thêm một hình bảng vào slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Đặt định dạng viền cho mỗi ô
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
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
    // Hợp nhất ô 1 và 2 của hàng 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Thêm một số văn bản vào ô đã hợp nhất
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Lưu bản trình chiếu vào đĩa
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đánh số trong bảng tiêu chuẩn**

Trong một bảng tiêu chuẩn, việc đánh số các ô là đơn giản và bắt đầu từ 0. Ô đầu tiên trong bảng có chỉ mục là 0,0 (cột 0, hàng 0). 

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Đoạn mã Java này cho bạn thấy cách chỉ định đánh số cho các ô trong bảng:

```java
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Định nghĩa các cột với độ rộng và các hàng với độ cao
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Thêm một shape bảng vào slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Đặt định dạng viền cho mỗi ô
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Lưu bản trình chiếu vào đĩa
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Truy cập bảng hiện có**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu tới slide chứa bảng thông qua chỉ mục của nó. 
3. Tạo một đối tượng [ITable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITable) và gán nó thành null.
4. Lặp qua tất cả các đối tượng [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/) cho đến khi tìm thấy bảng.

   Nếu bạn nghi ngờ slide đang làm việc chứa một bảng duy nhất, bạn có thể đơn giản kiểm tra tất cả các shape mà nó chứa. Khi một shape được xác định là một bảng, bạn có thể ép kiểu nó thành đối tượng [Table](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Table). Nhưng nếu slide chứa nhiều bảng, bạn nên tìm kiếm bảng cần thiết thông qua [setAlternativeText(String value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Sử dụng đối tượng [ITable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITable) để làm việc với bảng. Trong ví dụ dưới đây, chúng tôi đã thêm một hàng mới vào bảng.
6. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã Java này cho bạn thấy cách truy cập và làm việc với một bảng hiện có:

```java
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Truy cập slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Khởi tạo null TableEx
    ITable tbl = null;

    // Duyệt qua các shape và đặt tham chiếu đến bảng được tìm thấy
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Đặt văn bản cho cột đầu tiên của hàng thứ hai
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Lưu bản trình chiếu đã chỉnh sửa vào đĩa
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Căn chỉnh văn bản trong bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITable) vào slide.
4. Truy cập một đối tượng [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) từ bảng.
5. Truy cập [IParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraph/) của [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/).
6. Canh chỉnh văn bản theo chiều dọc.
7. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã Java này cho bạn thấy cách căn chỉnh văn bản trong bảng:

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Định nghĩa các cột với độ rộng và các hàng với độ cao
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Thêm shape bảng vào slide
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Truy cập khung văn bản
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Tạo đối tượng Paragraph cho khung văn bản
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Tạo đối tượng Portion cho đoạn văn
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Canh lề văn bản theo chiều dọc
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Lưu bản trình chiếu vào đĩa
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt định dạng văn bản ở mức bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Truy cập một đối tượng [ITable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITable) từ Slide.
4. Đặt [setFontHeight(float value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) cho văn bản.
5. Đặt [setAlignment(int value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) và [setMarginRight(float value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Đặt [setTextVerticalType(byte value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Lưu bản trình chiếu đã chỉnh sửa. 

Đoạn mã Java này cho bạn thấy cách áp dụng các tùy chọn định dạng ưa thích của bạn cho văn bản trong bảng:

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Giả sử shape đầu tiên trên slide đầu tiên là một bảng
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Đặt chiều cao phông chữ cho các ô bảng
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Đặt căn chỉnh văn bản và lề phải cho các ô bảng trong một lần gọi
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Đặt kiểu dọc cho văn bản của các ô bảng
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lấy thuộc tính kiểu bảng**

Aspose.Slides cho phép bạn lấy các thuộc tính kiểu cho một bảng để bạn có thể sử dụng các chi tiết đó cho bảng khác hoặc nơi khác. Đoạn mã Java này cho bạn thấy cách lấy các thuộc tính kiểu từ một kiểu bảng được đặt sẵn:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // thay đổi giao diện mẫu mặc định
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Khóa tỷ lệ khung hình của bảng**

Tỷ lệ khung hình của một hình dạng hình học là tỷ lệ kích thước của nó ở các chiều khác nhau. Aspose.Slides cung cấp thuộc tính [**setAspectRatioLocked**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) để cho phép bạn khóa cài đặt tỷ lệ khung hình cho bảng và các shape khác.

Đoạn mã Java này cho bạn thấy cách khóa tỷ lệ khung hình cho một bảng:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // đảo ngược

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể bật hướng đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Có. Bảng cung cấp phương thức [setRightToLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-), và các đoạn văn có [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Khi sử dụng cả hai, sẽ đảm bảo thứ tự RTL đúng và hiển thị chính xác bên trong các ô.

**Làm thế nào để ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong file cuối cùng?**

Sử dụng khóa shape để tắt việc di chuyển, thay đổi kích thước, chọn, v.v. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn hình ảnh vào bên trong ô làm nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/picturefillformat/) cho ô; hình ảnh sẽ bao phủ khu vực ô theo chế độ đã chọn (kéo dãn hoặc lát gạch).