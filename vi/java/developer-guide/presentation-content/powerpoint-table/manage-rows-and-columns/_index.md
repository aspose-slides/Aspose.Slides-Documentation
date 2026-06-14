---
title: Quản lý hàng và cột trong bảng PowerPoint bằng Java
linktitle: Hàng và Cột
type: docs
weight: 20
url: /vi/java/manage-rows-and-columns/
keywords:
- hàng bảng
- cột bảng
- hàng đầu tiên
- tiêu đề bảng
- nhân bản hàng
- nhân bản cột
- sao chép hàng
- sao chép cột
- xóa hàng
- xóa cột
- định dạng văn bản hàng
- định dạng văn bản cột
- kiểu bảng
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Quản lý hàng và cột của bảng trong PowerPoint với Aspose.Slides cho Java và tăng tốc việc chỉnh sửa bài thuyết trình cũng như cập nhật dữ liệu."
---
## **Giới thiệu**

Để cho phép bạn quản lý các hàng và cột của bảng trong một bài thuyết trình PowerPoint, Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/java/com.aspose.slides/table/) , giao diện [ITable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITable) và nhiều loại khác. 

## **Đặt hàng đầu tiên làm tiêu đề**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và tải bài thuyết trình. 
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Tạo một đối tượng [ITable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITable) và đặt nó thành null. 
4. Duyệt qua tất cả các đối tượng [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) để tìm bảng liên quan. 
5. Đặt hàng đầu tiên của bảng làm tiêu đề. 

Đoạn mã Java này cho bạn thấy cách đặt hàng đầu tiên của bảng làm tiêu đề:

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Truy cập slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Khởi tạo TableEx null
    ITable tbl = null;

    // Duyệt qua các shape và thiết lập tham chiếu tới bảng
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Đặt hàng đầu tiên của bảng làm tiêu đề
            tbl.setFirstRow(true);
        }
    }
    
    // Lưu bài thuyết trình vào đĩa
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Sao chép một hàng hoặc cột của bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và tải bài thuyết trình, 
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Xác định một mảng `columnWidth`. 
4. Xác định một mảng `rowHeight`. 
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITable) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. Sao chép hàng bảng. 
7. Sao chép cột bảng. 
8. Lưu bài thuyết trình đã sửa đổi. 

Đoạn mã Java này cho bạn thấy cách sao chép hàng hoặc cột của bảng PowerPoint:

```java
 // Khởi tạo lớp Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Truy cập slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Xác định các cột với chiều rộng và các hàng với chiều cao
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Thêm một shape bảng vào slide
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Thêm một số văn bản vào ô hàng 1 cột 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Thêm một số văn bản vào ô hàng 1 cột 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Sao chép hàng 1 vào cuối bảng
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Thêm một số văn bản vào ô hàng 2 cột 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Thêm một số văn bản vào ô hàng 2 cột 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Sao chép hàng 2 thành hàng thứ 4 của bảng
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Sao chép cột đầu tiên vào cuối
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Sao chép cột thứ 2 vào vị trí cột thứ 4
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Lưu bài thuyết trình vào đĩa
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa một hàng hoặc cột khỏi bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và tải bài thuyết trình, 
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Xác định một mảng `columnWidth`. 
4. Xác định một mảng `rowHeight`. 
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITable) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. Xóa hàng bảng. 
7. Xóa cột bảng. 
8. Lưu bài thuyết trình đã sửa đổi. 

Đoạn mã Java này cho bạn thấy cách xóa một hàng hoặc cột khỏi bảng:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt định dạng văn bản ở mức độ hàng của bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và tải bài thuyết trình, 
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Truy cập đối tượng [ITable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITable) liên quan từ slide. 
4. Đặt [setFontHeight(float value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) cho các ô hàng đầu tiên. 
5. Đặt [setAlignment(int value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) và [setMarginRight(float value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) cho các ô hàng đầu tiên. 
6. Đặt [setTextVerticalType(byte value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) cho các ô hàng thứ hai. 
7. Lưu bài thuyết trình đã sửa đổi. 

Đoạn mã Java này trình bày thao tác.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Giả sử rằng shape đầu tiên trên slide đầu tiên là một bảng
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Đặt độ cao phông chữ cho các ô hàng đầu tiên
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Đặt căn chỉnh văn bản và lề phải cho các ô hàng đầu tiên
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Đặt kiểu dọc của văn bản cho các ô hàng thứ hai
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Lưu bài thuyết trình vào đĩa
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt định dạng văn bản ở mức độ cột của bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và tải bài thuyết trình, 
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Truy cập đối tượng [ITable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITable) liên quan từ slide. 
4. Đặt [setFontHeight(float value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) cho các ô cột đầu tiên. 
5. Đặt [setAlignment(int value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) và [setMarginRight(float value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) cho các ô cột đầu tiên. 
6. Đặt [setTextVerticalType(byte value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) cho các ô cột thứ hai. 
7. Lưu bài thuyết trình đã sửa đổi. 

Đoạn mã Java này trình bày thao tác: 

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Giả sử shape đầu tiên trên slide đầu tiên là một bảng
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Đặt độ cao phông chữ cho các ô của cột đầu tiên
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Đặt căn chỉnh văn bản và lề phải cho các ô của cột đầu tiên trong một lần gọi
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Đặt kiểu dọc của văn bản cho các ô của cột thứ hai
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lấy các thuộc tính kiểu bảng**

Aspose.Slides cho phép bạn lấy các thuộc tính kiểu cho một bảng để bạn có thể sử dụng các chi tiết đó cho bảng khác hoặc nơi khác. Đoạn mã Java này cho bạn thấy cách lấy các thuộc tính kiểu từ kiểu bảng đã định sẵn:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // thay đổi chủ đề preset kiểu mặc định
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Có thể áp dụng các chủ đề/kiểu PowerPoint cho một bảng đã được tạo không?**

Có. Bảng kế thừa chủ đề của slide/bố cục/máster, và bạn vẫn có thể ghi đè màu nền, viền và màu chữ phía trên chủ đề đó.

**Có thể sắp xếp các hàng của bảng giống như trong Excel không?**

Không, các bảng trong Aspose.Slides không có tính năng sắp xếp hay bộ lọc tích hợp. Hãy sắp xếp dữ liệu trong bộ nhớ trước, sau đó điền lại các hàng bảng theo thứ tự đó.

**Có thể có các cột sọc (striped) trong khi vẫn giữ màu tùy chỉnh cho các ô cụ thể không?**

Có. Bật chế độ cột sọc, sau đó ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng cấp ô sẽ có ưu tiên hơn kiểu bảng.