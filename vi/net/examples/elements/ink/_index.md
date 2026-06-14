---
title: Mực
type: docs
weight: 180
url: /vi/net/examples/elements/ink/
keywords:
- mực
- truy cập mực
- xóa mực
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Làm việc với Mực trong Aspose.Slides cho .NET: vẽ, nhập và chỉnh sửa đường nét, điều chỉnh màu và độ rộng, và xuất ra PPT, PPTX và ODP bằng các ví dụ C#."
---
Bài viết này cung cấp các ví dụ về việc truy cập các hình mực hiện có và xóa chúng bằng cách sử dụng **Aspose.Slides for .NET**.

> ❗ **Lưu ý:** Các hình mực đại diện cho đầu vào của người dùng từ các thiết bị chuyên dụng. Aspose.Slides không thể tạo các đường mực mới một cách lập trình, nhưng bạn có thể đọc và chỉnh sửa các mực hiện có.

## **Truy cập Ink**

Đọc các thẻ từ hình mực đầu tiên trên một slide.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Sử dụng tagName khi cần.
        }
    }
}
```

## **Xóa Ink**

Xóa một hình mực khỏi slide nếu có.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```