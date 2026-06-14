---
title: Phần
type: docs
weight: 90
url: /vi/net/examples/elements/section/
keywords:
- phần
- phần slide
- thêm phần
- truy cập phần
- xóa phần
- đổi tên phần
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Quản lý các phần slide trong Aspose.Slides cho .NET: tạo, đổi tên, sắp xếp lại và nhóm các slide với các ví dụ C# cho PPT, PPTX và ODP."
---
Các ví dụ về việc quản lý các phần trong bản trình chiếu—thêm, truy cập, xóa và đổi tên chúng một cách lập trình bằng **Aspose.Slides for .NET**.

## **Thêm một phần**

Tạo một phần bắt đầu ở một slide cụ thể.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Chỉ định slide đánh dấu đầu của phần.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Truy cập một phần**

Đọc thông tin phần từ một bản trình chiếu.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Truy cập phần theo chỉ mục.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Xóa một phần**

Xóa một phần đã được thêm trước đó.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Xóa phần đầu tiên.
    presentation.Sections.RemoveSection(section);
}
```

## **Đổi tên một phần**

Thay đổi tên của một phần hiện có.

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```