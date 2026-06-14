---
title: Quản lý các ô bảng trong bản trình bày .NET
linktitle: Quản lý các ô
type: docs
weight: 30
url: /vi/net/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Quản lý các ô bảng trong PowerPoint một cách dễ dàng với Aspose.Slides cho .NET. Thành thạo việc truy cập, chỉnh sửa và định dạng ô nhanh chóng để tự động hoá slide liền mạch."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và chỉnh sửa các ô bảng trong bản trình bày PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa viền ô, làm việc với việc đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô và thêm hình ảnh bên trong ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình bày, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính ô, và lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

## **Xác định ô bảng đã hợp nhất**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) class.  
2. Lấy bảng từ slide đầu tiên.  
3. Duyệt qua các hàng và cột của bảng để tìm các ô đã hợp nhất.  
4. In thông báo khi phát hiện ô đã hợp nhất.

Đoạn mã C# sau cho bạn thấy cách xác định các ô bảng đã hợp nhất trong một bản trình bày:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // giả sử rằng Slide#0.Shape#0 là một bảng
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **Xóa viền ô bảng**

1. Tạo một thể hiện của lớp `Presentation`.  
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.  
3. Định nghĩa một mảng các cột với độ rộng.  
4. Định nghĩa một mảng các hàng với chiều cao.  
5. Thêm một bảng vào slide bằng phương thức `AddTable`.  
6. Duyệt qua mọi ô để xóa viền trên, dưới, phải và trái.  
7. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã C# sau cho bạn thấy cách xóa viền khỏi các ô bảng:

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{
   // Truy cập slide đầu tiên
    Slide sld = (Slide)pres.Slides[0];

    // Định nghĩa các cột với độ rộng và các hàng với chiều cao
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Thêm hình dạng bảng vào slide
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Đặt định dạng viền cho mỗi ô
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Ghi tệp PPTX ra đĩa
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Đánh số trong ô hợp nhất**

Nếu chúng ta hợp nhất 2 cặp ô (1, 1) x (2, 1) và (1, 2) x (2, 2), bảng kết quả sẽ được đánh số. Đoạn mã C# sau minh họa quy trình:

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation presentation = new Presentation())
{
    // Truy cập slide đầu tiên
    ISlide sld = presentation.Slides[0];

    // Định nghĩa các cột với độ rộng và các hàng với chiều cao
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Thêm hình dạng bảng vào slide
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Đặt định dạng viền cho mỗi ô
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Hợp nhất các ô (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Hợp nhất các ô (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

Sau đó chúng ta tiếp tục hợp nhất các ô bằng cách hợp nhất (1, 1) và (1, 2). Kết quả là một bảng chứa một ô hợp nhất lớn ở trung tâm:

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation presentation = new Presentation())
{
    // Truy cập slide đầu tiên
    ISlide slide = presentation.Slides[0];

    // Định nghĩa các cột với độ rộng và các hàng với chiều cao
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Thêm hình dạng bảng vào slide
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Đặt định dạng viền cho mỗi ô
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Hợp nhất các ô (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Hợp nhất các ô (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Hợp nhất các ô (1, 2) x (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    //Ghi tệp PPTX ra đĩa
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **Đánh số trong ô đã tách**

Trong các ví dụ trước, khi các ô bảng được hợp nhất, hệ thống đánh số trong các ô khác không thay đổi.

Lần này, chúng ta lấy một bảng thông thường (bảng không có ô hợp nhất) và sau đó cố gắng tách ô (1,1) để có được một bảng đặc biệt. Bạn có thể muốn chú ý đến cách đánh số của bảng này, có thể được coi là lạ. Tuy nhiên, đó là cách Microsoft PowerPoint đánh số các ô bảng và Aspose.Slides cũng làm tương tự.

Đoạn mã C# sau minh họa quy trình mà chúng tôi mô tả:

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation presentation = new Presentation())
{
    // Truy cập slide đầu tiên
    ISlide slide = presentation.Slides[0];

    // Định nghĩa các cột với độ rộng và các hàng với chiều cao
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Thêm hình dạng bảng vào slide
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Đặt định dạng viền cho mỗi ô
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Hợp nhất các ô (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Hợp nhất các ô (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Tách ô (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    //Ghi tệp PPTX ra đĩa
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Thay đổi màu nền ô bảng**

Đoạn mã C# sau cho bạn thấy cách thay đổi màu nền của một ô bảng:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // tạo một bảng mới
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // đặt màu nền cho một ô 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Thêm hình ảnh vào bên trong ô bảng**

1. Tạo một thể hiện của lớp `Presentation`.  
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.  
3. Định nghĩa một mảng các cột với độ rộng.  
4. Định nghĩa một mảng các hàng với chiều cao.  
5. Thêm một bảng vào slide bằng phương thức `AddTable`.  
6. Tạo một đối tượng `Bitmap` để giữ tệp hình ảnh.  
7. Thêm hình ảnh bitmap vào đối tượng `IPPImage`.  
8. Đặt `FillFormat` cho ô bảng thành `Picture`.  
9. Thêm hình ảnh vào ô đầu tiên của bảng.  
10. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX

Đoạn mã C# sau cho bạn thấy cách đặt hình ảnh vào bên trong ô bảng khi tạo bảng:

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation presentation = new Presentation())
{
    // Truy cập slide đầu tiên
    ISlide slide = presentation.Slides[0];

    // Định nghĩa các cột với độ rộng và các hàng với chiều cao
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Thêm hình dạng bảng vào slide
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Tải hình ảnh từ tệp và thêm vào tài nguyên của bản trình bày
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Thêm hình ảnh vào ô bảng đầu tiên
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Lưu tệp PPTX ra đĩa
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Tôi có thể đặt độ dày và kiểu đường khác nhau cho các mặt khác nhau của một ô duy nhất không?**

Có. Các viền [trên](https://reference.aspose.com/slides/vi/net/aspose.slides/cellformat/bordertop/)/[dưới](https://reference.aspose.com/slides/vi/net/aspose.slides/cellformat/borderbottom/)/[trái](https://reference.aspose.com/slides/vi/net/aspose.slides/cellformat/borderleft/)/[phải](https://reference.aspose.com/slides/vi/net/aspose.slides/cellformat/borderright/) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi phía có thể khác nhau. Điều này hợp lý dựa trên việc kiểm soát viền theo từng phía cho một ô được trình bày trong bài viết.

**Điều gì xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đặt hình ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [chế độ lấp đầy](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillmode/) (stretch/tile). Khi kéo dài, hình ảnh sẽ điều chỉnh theo ô mới; khi điều chỉnh dạng lưới, các ô lưới sẽ được tính lại. Bài viết đề cập đến các chế độ hiển thị hình ảnh trong ô.

**Tôi có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/net/manage-hyperlinks/) được đặt ở mức độ văn bản (phần) bên trong khung văn bản của ô hoặc ở mức độ toàn bộ bảng/hình. Trong thực tế, bạn gán liên kết cho một phần hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/vi/net/aspose.slides/portion/) (các đoạn) với định dạng độc lập—gia đình phông chữ, kiểu, kích thước và màu.