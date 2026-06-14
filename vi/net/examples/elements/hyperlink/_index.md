---
title: Siêu liên kết
type: docs
weight: 130
url: /vi/net/examples/elements/hyperlink/
keywords:
- siêu liên kết
- thêm siêu liên kết
- truy cập siêu liên kết
- xóa siêu liên kết
- cập nhật siêu liên kết
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Thêm và quản lý siêu liên kết trong Aspose.Slides for .NET: liên kết văn bản, hình dạng và hình ảnh, thiết lập mục tiêu và hành động cho PPT, PPTX và ODP với các ví dụ C#."
---
Bài viết này trình bày cách thêm, truy cập, xóa và cập nhật siêu liên kết trên các hình dạng bằng cách sử dụng **Aspose.Slides for .NET**.

## **Thêm Siêu Liên Kết**

Tạo một hình chữ nhật có siêu liên kết trỏ tới một trang web bên ngoài.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **Truy Cập Siêu Liên Kết**

Đọc thông tin siêu liên kết từ phần văn bản của hình dạng.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **Xóa Siêu Liên Kết**

Xóa siêu liên kết khỏi văn bản của hình dạng.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **Cập Nhật Siêu Liên Kết**

Thay đổi đích đến của một siêu liên kết hiện có. Sử dụng `HyperlinkManager` để sửa đổi văn bản đã chứa siêu liên kết, mô phỏng cách PowerPoint cập nhật siêu liên kết một cách an toàn.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Thay đổi siêu liên kết trong văn bản hiện có nên được thực hiện qua
    // HyperlinkManager thay vì thiết lập thuộc tính trực tiếp.
    // Điều này mô phỏng cách PowerPoint cập nhật siêu liên kết một cách an toàn.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```