---
title: Đầu và Chân trang
type: docs
weight: 220
url: /vi/net/examples/elements/header-footer/
keywords:
- đầu và chân trang
- thêm đầu và chân trang
- cập nhật đầu và chân trang
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Kiểm soát tiêu đề và chân trang của slide bằng Aspose.Slides cho .NET: thêm ngày, số slide và văn bản tùy chỉnh trong PPT, PPTX và ODP với các ví dụ C#."
---
Bài viết này trình bày cách thêm chân trang và cập nhật các placeholder ngày giờ bằng **Aspose.Slides for .NET**.

## **Thêm Chân Trang**

Thêm văn bản vào khu vực chân trang của một slide và hiển thị nó.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Cập Nhật Ngày và Giờ**

Sửa đổi placeholder ngày và giờ trên một slide.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```