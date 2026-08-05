---
title: Tiêu đề và Chân trang
type: docs
weight: 220
url: /vi/net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
keywords:
  - tiêu đề và chân trang
  - thêm tiêu đề và chân trang
  - cập nhật tiêu đề và chân trang
  - ví dụ mã
  - PowerPoint
  - OpenDocument
  - bản trình chiếu
  - .NET
  - C#
  - Aspose.Slides
description: "Kiểm soát tiêu đề và chân trang của slide với Aspose.Slides cho .NET: thêm ngày, số slide và văn bản tùy chỉnh trong PPT, PPTX và ODP với các ví dụ C#."
---
Bài viết này trình bày cách thêm chân trang và cập nhật các trình giữ chỗ ngày giờ bằng **Aspose.Slides for .NET**.

## **Thêm chân trang**

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

## **Cập nhật ngày và giờ**

Chỉnh sửa trình giữ chỗ ngày và giờ trên một slide.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```