---
title: Quản lý các ô bảng trong bản thuyết trình bằng Java
linktitle: Quản lý ô
type: docs
weight: 30
url: /vi/java/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bản thuyết trình
- Java
- Aspose.Slides
description: "Dễ dàng quản lý các ô bảng trong PowerPoint với Aspose.Slides cho Java. Thành thạo việc truy cập, chỉnh sửa và tạo kiểu ô một cách nhanh chóng để tự động hoá slide mượt mà."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và chỉnh sửa các ô bảng trong bản thuyết trình PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa viền ô, làm việc với việc đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô, và thêm hình ảnh vào bên trong một ô bảng. Các ví dụ minh họa cách tạo hoặc mở một bản thuyết trình, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính của ô, và lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

## **Xác định ô bảng đã hợp nhất**
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) class.
2. Lấy bảng từ slide đầu tiên. 
3. Duyệt qua các hàng và cột của bảng để tìm các ô đã hợp nhất.
4. In ra thông báo khi phát hiện các ô đã hợp nhất.

Mã Java này cho bạn thấy cách xác định các ô bảng đã hợp nhất trong một bản thuyết trình:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // giả sử Slide#0.Shape#0 là một bảng
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa viền ô bảng**
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) class.
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Định nghĩa một mảng các cột với chiều rộng.
4. Định nghĩa một mảng các hàng với chiều cao.
5. Thêm một bảng vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. Duyệt qua mọi ô để xóa các viền trên, dưới, phải và trái.
7. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Java này cho bạn thấy cách xóa viền khỏi các ô bảng:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Định nghĩa các cột với độ rộng và các hàng với chiều cao
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Thêm hình dạng bảng vào slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Đặt định dạng viền cho từng ô
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // Ghi tệp PPTX ra đĩa
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đánh số trong các ô đã hợp nhất**
Nếu chúng tôi hợp nhất 2 cặp ô (1, 1) x (2, 1) và (1, 2) x (2, 2), bảng kết quả sẽ được đánh số. Mã Java này minh họa quy trình:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Định nghĩa các cột với độ rộng và các hàng với chiều cao
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Thêm hình dạng bảng vào slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Đặt định dạng viền cho từng ô
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

    // Hợp nhất các ô (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Hợp nhất các ô (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Sau đó chúng tôi tiếp tục hợp nhất các ô bằng cách hợp nhất (1, 1) và (1, 2). Kết quả là một bảng chứa một ô hợp nhất lớn ở giữa: 

```java
// Khởi tạo lớp Presentation đại diện cho một tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Định nghĩa các cột với độ rộng và các hàng với chiều cao
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Thêm hình dạng bảng vào slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Đặt định dạng viền cho từng ô
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

    // Hợp nhất các ô (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Hợp nhất các ô (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Hợp nhất các ô (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	//Ghi tệp PPTX ra đĩa
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đánh số trong ô đã tách**
Trong các ví dụ trước, khi các ô bảng được hợp nhất, hệ thống đánh số hoặc số thứ tự trong các ô khác không thay đổi. 

Lần này chúng tôi lấy một bảng thường (bảng không có ô hợp nhất) và sau đó cố gắng tách ô (1,1) để có được một bảng đặc biệt. Bạn có thể muốn chú ý đến cách đánh số của bảng này, có thể được coi là lạ. Tuy nhiên, đó là cách Microsoft PowerPoint đánh số các ô bảng và Aspose.Slides cũng làm tương tự. 

Mã Java này minh họa quy trình chúng tôi đã mô tả:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Định nghĩa các cột với độ rộng và các hàng với chiều cao
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Thêm hình dạng bảng vào slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Đặt định dạng viền cho từng ô
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

    // Hợp nhất các ô (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Hợp nhất các ô (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Tách ô (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // Ghi tệp PPTX ra đĩa
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay đổi màu nền của ô bảng**

Mã Java này cho bạn thấy cách thay đổi màu nền của ô bảng:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    //    tạo một bảng mới
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    //    đặt màu nền cho một ô 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Thêm hình ảnh vào bên trong ô bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) class.
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Định nghĩa một mảng các cột với chiều rộng.
4. Định nghĩa một mảng các hàng với chiều cao.
5. Thêm một bảng vào slide thông qua phương thức [AddTable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. Tạo một đối tượng `Images` để chứa tệp hình ảnh.
7. Thêm hình ảnh `IImage` vào đối tượng `IPPImage`.
8. Đặt `FillFormat` cho ô bảng thành `Picture`.
9. Thêm hình ảnh vào ô đầu tiên của bảng.
10. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX

Mã Java này cho bạn thấy cách đặt hình ảnh vào ô bảng khi tạo một bảng:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide islide = pres.getSlides().get_Item(0);

    // Định nghĩa các cột với độ rộng và các hàng với chiều cao
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Thêm hình dạng bảng vào slide
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Tạo một đối tượng IPPImage bằng tệp hình ảnh
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Thêm hình ảnh vào ô bảng đầu tiên
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Lưu tệp PPTX vào đĩa
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt độ dày và kiểu đường viền khác nhau cho các mặt của một ô duy nhất không?**

Có. Các viền [top](https://reference.aspose.com/slides/vi/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/vi/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/vi/java/com.aspose.slides/cellformat/#getBorderRight--) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi mặt có thể khác nhau. Điều này hợp lý dựa trên việc kiểm soát viền từng mặt cho một ô được trình bày trong bài viết.

**Điều gì sẽ xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đặt một bức ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/picturefillmode/) (kéo dài/điệu). Khi kéo dài, hình ảnh sẽ điều chỉnh theo ô mới; khi điệu, các mẫu sẽ được tính lại. Bài viết đề cập đến các chế độ hiển thị hình ảnh trong ô.

**Tôi có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/java/manage-hyperlinks/) được đặt ở mức đoạn văn bản (portion) bên trong khung văn bản của ô hoặc ở mức toàn bộ bảng/hình. Trong thực tế, bạn gán liên kết cho một đoạn hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) (runs) với định dạng độc lập—gia đình phông chữ, kiểu, kích thước và màu.