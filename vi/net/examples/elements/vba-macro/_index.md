---
title: Macro VBA
type: docs
weight: 150
url: /vi/net/examples/elements/vba-macro/
keywords:
- macro VBA
- thêm macro VBA
- truy cập macro VBA
- xóa macro VBA
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tự động hoá bản trình chiếu với Aspose.Slides cho .NET: tạo, chạy, nhập và bảo vệ macro VBA trong PPT, PPTX và ODP bằng các ví dụ C# rõ ràng."
---
Bài viết này trình bày cách thêm, truy cập và xoá macro VBA bằng cách sử dụng **Aspose.Slides for .NET**.

## **Thêm một Macro VBA**

Tạo một bản trình chiếu có dự án VBA và một mô-đun macro đơn giản.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Truy cập một Macro VBA**

Lấy mô-đun đầu tiên từ dự án VBA.

```csharp
static void AccessVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = presentation.VbaProject.Modules[0];
}
```

## **Xoá một Macro VBA**

Xoá một mô-đun khỏi dự án VBA.

```csharp
static void RemoveVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    presentation.VbaProject.Modules.Remove(module);
}
```