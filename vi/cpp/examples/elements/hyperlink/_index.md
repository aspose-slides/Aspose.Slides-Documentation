---
title: Siêu liên kết
type: docs
weight: 130
url: /vi/cpp/examples/elements/hyperlink/
keywords:
- ví dụ mã
- siêu liên kết
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Thêm và quản lý siêu liên kết trong Aspose.Slides for C++: liên kết văn bản, hình dạng và hình ảnh, đặt mục tiêu và hành động cho PPT, PPTX và ODP với các ví dụ C++."
---
Bài viết này trình bày cách thêm, truy cập, xóa và cập nhật siêu liên kết trên các hình dạng bằng **Aspose.Slides for C++**.

## **Thêm Siêu liên kết**

Tạo một hình chữ nhật có siêu liên kết trỏ tới một trang web bên ngoài.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **Truy cập Siêu liên kết**

Đọc thông tin siêu liên kết từ phần văn bản của hình dạng.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **Xóa Siêu liên kết**

Xóa siêu liên kết khỏi văn bản của hình dạng.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **Cập nhật Siêu liên kết**

Thay đổi đích của siêu liên kết hiện có. Sử dụng `HyperlinkManager` để chỉnh sửa văn bản đã chứa siêu liên kết, mô phỏng cách PowerPoint cập nhật siêu liên kết một cách an toàn.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // Thay đổi siêu liên kết trong văn bản hiện có nên được thực hiện qua
    // HyperlinkManager thay vì thiết lập thuộc tính trực tiếp.
    // Điều này mô phỏng cách PowerPoint cập nhật siêu liên kết một cách an toàn.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```