---
title: Lấy giới hạn phần văn bản từ bản trình chiếu trong .NET
linktitle: Giới hạn phần
type: docs
weight: 47
url: /vi/net/portion-bounds/
keywords:
- giới hạn phần văn bản
- phần văn bản
- phần văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn phần văn bản trong bản trình chiếu PowerPoint bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Một đoạn văn bản đại diện cho một phần cụ thể của văn bản bên trong một đoạn và cho phép bạn làm việc với phần đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các phần có thể được sử dụng khi bạn cần lấy giới hạn của một đoạn văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi văn bản ở mức chi tiết hơn. Bài viết này hướng dẫn cách lấy hình chữ nhật bao quanh của một phần bằng cách sử dụng [IPortion.GetRect](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/getrect/). Nó cũng chỉ ra cách lấy tọa độ của phần đầu của một phần bằng cách sử dụng [IPortion.GetCoordinates](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/getcoordinates/). Ngoài ra, nó làm nổi bật các kịch bản thường gặp liên quan đến phần, chẳng hạn như áp dụng siêu liên kết cho một đoạn văn bản duy nhất, hiểu cách định dạng được giải quyết qua phần, đoạn, khung văn bản và kế thừa giao diện chủ đề, và xử lý các trường hợp phông chữ được chỉ định không có sẵn.

## **Lấy Hình Chữ Nhật Bao Quanh của Phần Văn Bản**

Sử dụng [IPortion.GetRect](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/getrect/) để lấy hình chữ nhật bao quanh của một phần văn bản:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Lấy Tọa Độ của Phần Văn Bản**

Sử dụng [IPortion.GetCoordinates](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/getcoordinates/) để lấy tọa độ của phần đầu của một phần văn bản:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng siêu liên kết chỉ cho một phần của văn bản trong một đoạn duy nhất không?**

Có, bạn có thể [gán một siêu liên kết](/slides/vi/net/manage-hyperlinks/) cho một phần riêng lẻ; chỉ phần đó sẽ có thể nhấp, không phải toàn bộ đoạn.

**Kế thừa kiểu dáng hoạt động như thế nào: một phần ghi đè gì, và gì được lấy từ đoạn hoặc khung văn bản?**

Các thuộc tính ở cấp độ phần có độ ưu tiên cao nhất. Nếu một thuộc tính không được thiết lập trên [IPortion](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/), Aspose.Slides sẽ lấy nó từ [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/). Nếu cũng không được thiết lập ở đó, Aspose.Slides sẽ sử dụng kiểu dáng của [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) hoặc [theme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/theme/).

**Điều gì xảy ra nếu phông chữ được chỉ định cho một phần không có trên máy hoặc máy chủ đích?**

[Quy tắc thay thế phông chữ](/slides/vi/net/font-selection-sequence/) sẽ được áp dụng. Văn bản có thể được sắp lại: các chỉ số, cách gạch ngang, và độ rộng có thể thay đổi, điều này quan trọng đối với việc định vị chính xác.

**Tôi có thể đặt độ trong suốt hoặc gradient cho phần văn bản một cách riêng biệt so với phần còn lại của đoạn không?**

Có, màu văn bản, màu nền và độ trong suốt ở mức độ [IPortion](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/) có thể khác với các đoạn liền kề.