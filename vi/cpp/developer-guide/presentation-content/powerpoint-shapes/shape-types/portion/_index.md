---
title: Quản lý các phần văn bản trong trình chiếu bằng C++
linktitle: Phần Văn Bản
type: docs
weight: 70
url: /vi/cpp/portion/
keywords:
- phần văn bản
- đoạn văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách quản lý các phần văn bản trong các bản trình bày PowerPoint bằng Aspose.Slides cho C++, tăng hiệu suất và khả năng tùy chỉnh."
---
## **Giới thiệu**

Một phần văn bản đại diện cho một đoạn văn bản cụ thể bên trong một đoạn và cho phép bạn làm việc với đoạn đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các phần có thể được sử dụng khi bạn cần lấy vị trí của một đoạn văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi văn bản ở mức chi tiết hơn.

## **Lấy tọa độ của một phần văn bản**
**GetCoordinates()** method đã được thêm vào IPortion và lớp Portion cho phép lấy tọa độ của đầu phần:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng liên kết siêu văn bản chỉ cho một phần của văn bản trong cùng một đoạn không?**

Có, bạn có thể [gán một siêu liên kết](/slides/vi/cpp/manage-hyperlinks/) cho một phần riêng lẻ; chỉ đoạn đó sẽ có thể nhấp, không phải toàn bộ đoạn.

**Cách kế thừa kiểu dáng hoạt động như thế nào: một Portion ghi đè gì, và gì được lấy từ Paragraph/TextFrame?**

Các thuộc tính mức Portion có độ ưu tiên cao nhất. Nếu một thuộc tính không được đặt trên [Portion](https://reference.aspose.com/slides/vi/cpp/aspose.slides/portion/), engine sẽ lấy từ [Paragraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraph/); nếu cũng không được đặt ở đó, sẽ lấy từ [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframe/) hoặc kiểu style của [theme](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/theme/).

**Điều gì sẽ xảy ra nếu phông chữ được chỉ định cho một Portion không có trên máy/ máy chủ mục tiêu?**

[Quy tắc thay thế phông chữ](/slides/vi/cpp/font-selection-sequence/) được áp dụng. Văn bản có thể tái luồng: các chỉ số, dấu gạch nối và độ rộng có thể thay đổi, điều này quan trọng đối với việc định vị chính xác.

**Tôi có thể đặt độ trong suốt hoặc gradient màu nền văn bản riêng cho Portion mà không ảnh hưởng đến phần còn lại của đoạn không?**

Có, màu văn bản, nền và độ trong suốt ở mức [Portion](https://reference.aspose.com/slides/vi/cpp/aspose.slides/portion/) có thể khác với các đoạn lân cận.