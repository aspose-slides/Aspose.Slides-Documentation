---
title: Lấy giới hạn phần văn bản trong bài trình chiếu bằng C++
linktitle: Giới hạn phần
type: docs
weight: 47
url: /vi/cpp/portion-bounds/
keywords:
- giới hạn phần văn bản
- phần văn bản
- đoạn văn bản
- tọa độ văn bản
- vị trí văn bản
- PowerPoint
- bài trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn phần văn bản trong các bài trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides cho C++."
---
## **Tổng quan**

Một phần văn bản đại diện cho một đoạn cụ thể bên trong một đoạn văn và cho phép bạn làm việc với đoạn đó một cách độc lập so với nội dung xung quanh. Trong Aspose.Slides, các phần có thể được sử dụng khi bạn cần lấy giới hạn của một đoạn văn bản, áp dụng định dạng chỉ cho một phần của đoạn, hoặc kiểm soát hành vi văn bản ở mức chi tiết hơn.

Bài viết này hướng dẫn cách lấy hình chữ nhật bao quanh của một phần bằng cách sử dụng [IPortion::GetRect](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/getrect/). Nó cũng chỉ ra cách lấy tọa độ bắt đầu của một phần bằng cách sử dụng [IPortion::GetCoordinates](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/getcoordinates/). Ngoài ra, bài viết còn nhấn mạnh các kịch bản thường gặp liên quan đến phần, chẳng hạn như gán siêu liên kết cho một đoạn văn bản đơn, hiểu cách định dạng được giải quyết qua phần, đoạn, khung văn bản và kế thừa chủ đề, và xử lý các trường hợp phông chữ được chỉ định không có sẵn.

## **Lấy giới hạn của một phần văn bản**

Sử dụng [IPortion::GetRect](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/getrect/) để lấy hình chữ nhật bao quanh của một phần văn bản:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Lấy tọa độ của một phần văn bản**

Sử dụng [IPortion::GetCoordinates](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/getcoordinates/) để lấy tọa độ bắt đầu của một phần văn bản:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Tôi có thể gán siêu liên kết cho chỉ một phần của văn bản trong một đoạn duy nhất không?**

Có, bạn có thể [gán một siêu liên kết](/slides/vi/cpp/manage-hyperlinks/) cho một phần riêng lẻ; chỉ đoạn văn đó sẽ có thể nhấp được, không phải toàn bộ đoạn.

**Cơ chế kế thừa kiểu dáng hoạt động như thế nào: phần nào được ghi đè, và gì được lấy từ đoạn hoặc khung văn bản?**

Các thuộc tính mức phần có độ ưu tiên cao nhất. Nếu một thuộc tính không được đặt trên [IPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/), Aspose.Slides sẽ lấy nó từ [IParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/). Nếu cũng không được đặt ở đó, Aspose.Slides sẽ sử dụng kiểu dáng từ [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) hoặc [theme](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/theme/).

**Nếu phông chữ được chỉ định cho một phần thiếu trên máy hoặc máy chủ mục tiêu thì sẽ xảy ra gì?**

[Quy tắc thay thế phông chữ](/slides/vi/cpp/font-selection-sequence/) sẽ được áp dụng. Văn bản có thể bị tái luồng: các chỉ số đo, cách gạch nối và độ rộng có thể thay đổi, điều này ảnh hưởng đến việc định vị chính xác.

**Tôi có thể thiết lập độ trong suốt hoặc gradient màu nền cho phần văn bản một cách riêng biệt so với phần còn lại của đoạn không?**

Có, màu chữ, nền và độ trong suốt ở mức [IPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/) có thể khác với các đoạn văn bản lân cận.