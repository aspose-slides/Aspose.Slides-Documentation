---
title: Quản lý các phần văn bản trong bản trình chiếu trên .NET
linktitle: Phần Văn Bản
type: docs
weight: 70
url: /vi/net/portion/
keywords:
- phần văn bản
- phần văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách quản lý các phần văn bản trong bản trình chiếu PowerPoint bằng Aspose.Slides cho .NET, nâng cao hiệu suất và khả năng tùy chỉnh."
---
## **Tổng quan**

Một phần văn bản đại diện cho một đoạn cụ thể của văn bản trong một đoạn và cho phép bạn làm việc với đoạn đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các phần có thể được sử dụng khi bạn cần lấy vị trí của một đoạn văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi văn bản ở mức chi tiết hơn.

Bài viết này mô tả cách lấy tọa độ của đầu phần bằng cách sử dụng phương thức `GetCoordinates()`. Nó cũng nêu bật các kịch bản thường gặp liên quan đến phần, chẳng hạn như áp dụng siêu liên kết cho một đoạn văn bản duy nhất, hiểu cách định dạng được giải quyết qua phần, đoạn, khung văn bản và kế thừa chủ đề, và xử lý các trường hợp phông chữ được chỉ định không có sẵn. Ngoài ra, nó lưu ý rằng đổ màu, màu sắc và độ trong suốt của văn bản có thể được đặt khác nhau cho từng phần riêng biệt trong cùng một đoạn.

## **Lấy tọa độ của một phần văn bản**
Phương thức **GetCoordinates()** đã được thêm vào IPortion và lớp Portion, cho phép lấy tọa độ của đầu phần:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng siêu liên kết chỉ cho một phần của văn bản trong cùng một đoạn không?**

Có, bạn có thể [gán một siêu liên kết](/slides/vi/net/manage-hyperlinks/) cho một phần riêng lẻ; chỉ đoạn đó sẽ có thể nhấp, không phải toàn bộ đoạn.

**Cơ chế kế thừa kiểu dáng hoạt động như thế nào: Portion ghi đè gì, và gì được lấy từ Paragraph/TextFrame?**

Các thuộc tính ở mức Portion có độ ưu tiên cao nhất. Nếu một thuộc tính không được đặt trên [Portion](https://reference.aspose.com/slides/vi/net/aspose.slides/portion/), engine sẽ lấy từ [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/); nếu cũng không đặt ở đó, sẽ lấy từ [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) hoặc kiểu [theme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/theme/).

**Điều gì sẽ xảy ra nếu phông chữ được chỉ định cho một Portion không có trên máy/chủ sở hữu mục tiêu?**

[Các quy tắc thay thế phông chữ](/slides/vi/net/font-selection-sequence/) sẽ được áp dụng. Văn bản có thể tái bố trí: các chỉ số, gạch nối và độ rộng có thể thay đổi, điều này quan trọng đối với việc định vị chính xác.

**Tôi có thể đặt độ trong suốt hoặc gradient cho phần văn bản riêng biệt mà không ảnh hưởng đến phần còn lại của đoạn không?**

Có, màu văn bản, đổ màu và độ trong suốt ở mức [Portion](https://reference.aspose.com/slides/vi/net/aspose.slides/portion/) có thể khác với các đoạn lân cận.