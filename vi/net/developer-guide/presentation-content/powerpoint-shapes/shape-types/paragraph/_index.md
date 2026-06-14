---
title: Lấy giới hạn đoạn văn từ bản trình chiếu trong .NET
linktitle: Đoạn văn
type: docs
weight: 60
url: /vi/net/paragraph/
keywords:
- giới hạn đoạn văn
- giới hạn phần văn bản
- tọa độ đoạn văn
- tọa độ phần
- kích thước đoạn văn
- kích thước phần văn bản
- khung văn bản
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn đoạn văn và phần văn bản trong Aspose.Slides cho .NET để tối ưu vị trí văn bản trong các bản trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của các đoạn văn và phần văn bản trong Aspose.Slides. Nó cho thấy cách lấy hình chữ nhật của một đoạn trong `TextFrame` bằng cách sử dụng `GetRect()`, cách lấy tọa độ của đoạn và phần bên trong khung văn bản của ô bảng, và nêu bật các chi tiết quan trọng như đơn vị đo, ảnh hưởng của việc ngắt dòng tới giới hạn, chuyển đổi sang pixel và các giá trị định dạng đoạn văn hiệu lực.

## **Lấy Tọa độ Đoạn và Phần trong TextFrame**

Sử dụng Aspose.Slides cho .NET, các nhà phát triển hiện có thể lấy tọa độ hình chữ nhật cho Paragraph trong bộ sưu tập các đoạn của TextFrame. Nó cũng cho phép bạn lấy tọa độ của phần trong bộ sưu tập phần của một Paragraph. Trong chủ đề này, chúng tôi sẽ trình bày với ví dụ cách lấy tọa độ hình chữ nhật cho Paragraph cùng vị trí của phần bên trong Paragraph.

## **Lấy Tọa độ Hình chữ nhật của một Paragraph**
Phương thức mới **GetRect()** đã được thêm vào. Nó cho phép lấy hình chữ nhật giới hạn của Paragraph.

```c#
// Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Lấy Kích thước của Paragraph và Phần trong TextFrame của Ô Bảng**

Để lấy kích thước và tọa độ của [Phần](https://reference.aspose.com/slides/vi/net/aspose.slides/portion) hoặc [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph) trong một khung văn bản ô bảng, bạn có thể sử dụng các phương thức [IPortion.GetRect](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/methods/getrect) và [IParagraph.GetRect](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/methods/getrect).

Mã mẫu này minh họa thao tác đã mô tả:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **CÂU HỎI THƯỜNG GẶP**

**Đơn vị nào được sử dụng để trả về tọa độ cho Paragraph và các phần văn bản?**

Trong đơn vị point, trong đó 1 inch = 72 point. Điều này áp dụng cho tất cả các tọa độ và kích thước trên slide.

**Việc ngắt dòng có ảnh hưởng đến giới hạn của Paragraph không?**

Có. Nếu [wrapping](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat/wraptext/) được bật trong [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/), văn bản sẽ ngắt để phù hợp với độ rộng khu vực, gây thay đổi giới hạn thực tế của Paragraph.

**Có thể ánh xạ tọa độ của Paragraph sang pixel trong hình ảnh xuất ra một cách đáng tin cậy không?**

Có. Chuyển đổi point sang pixel bằng công thức: pixels = points × (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho việc render/đầu ra.

**Làm sao để lấy các tham số định dạng "effective" của Paragraph, tính đến việc kế thừa kiểu?**

Sử dụng [cấu trúc dữ liệu định dạng paragraph effective](/slides/vi/net/shape-effective-properties/); nó trả về các giá trị hợp nhất cuối cùng cho thụt lề, khoảng cách, ngắt dòng, RTL và các thiết lập khác.