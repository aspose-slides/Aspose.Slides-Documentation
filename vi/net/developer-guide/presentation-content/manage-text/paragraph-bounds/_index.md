---
title: Lấy giới hạn đoạn văn từ các bản thuyết trình trong .NET
linktitle: Giới hạn đoạn văn
type: docs
weight: 43
url: /vi/net/paragraph-bounds/
keywords:
- giới hạn đoạn văn
- tọa độ đoạn văn
- kích thước đoạn văn
- khung văn bản
- PowerPoint
- bản thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn đoạn văn trong Aspose.Slides cho .NET để tối ưu vị trí văn bản trong các bản thuyết trình PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của các đoạn văn trong Aspose.Slides. Nó chỉ ra cách truy xuất hình chữ nhật của một đoạn văn từ một [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) bằng cách sử dụng [IParagraph.GetRect](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/getrect/), cách lấy tọa độ đoạn văn trong khung văn bản ô bảng, và nêu bật các chi tiết quan trọng như đơn vị đo, ảnh hưởng của việc tự động ngắt dòng lên giới hạn, chuyển đổi pixel, và các giá trị định dạng đoạn văn “hiệu quả”.

## **Lấy tọa độ hình chữ nhật của một đoạn văn**

Sử dụng [IParagraph.GetRect](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/getrect/) để lấy hình chữ nhật bao quanh của một đoạn văn.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Lấy kích thước của một đoạn văn trong khung văn bản ô bảng**

Để lấy kích thước và tọa độ của một [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/) trong khung văn bản ô bảng, hãy sử dụng [IParagraph.GetRect](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/getrect/). Hình chữ nhật trả về là tương đối so với khung văn bản ô bảng, vì vậy hãy cộng vị trí bảng và độ dịch ô khi bạn cần tọa độ ở cấp slide.

Ví dụ sau đây lấy giới hạn đoạn văn trong ô bảng và vẽ các hình chữ nhật trên slide để hiển thị các giới hạn đó:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Câu hỏi thường gặp**

**Các tọa độ đoạn văn được đo bằng đơn vị nào?**

Chúng được đo bằng điểm, trong đó 1 inch tương đương 72 điểm. Điều này áp dụng cho mọi tọa độ và kích thước trên slide.

**Việc tự động ngắt dòng có ảnh hưởng đến giới hạn của đoạn văn không?**

Có. Nếu [TextFrameFormat.WrapText](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat/wraptext/) được bật cho [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/), văn bản sẽ tự động ngắt để phù hợp với chiều rộng vùng, điều này làm thay đổi giới hạn thực tế của đoạn văn.

**Có thể ánh xạ tọa độ đoạn văn sang pixel trong hình ảnh xuất ra một cách đáng tin cậy không?**

Có. Chuyển đổi điểm sang pixel bằng công thức này: pixel = điểm × (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho việc render hoặc xuất.

**Làm thế nào để tôi lấy các tham số định dạng đoạn văn “hiệu quả”, có tính đến kế thừa kiểu?**

Sử dụng [effective paragraph formatting data structure](/slides/vi/net/shape-effective-properties/); nó trả về các giá trị hợp nhất cuối cùng cho thụt lề, khoảng cách, ngắt dòng, RTL và các thuộc tính khác.