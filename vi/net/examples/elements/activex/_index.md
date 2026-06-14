---
title: ActiveX
type: docs
weight: 200
url: /vi/net/examples/elements/activex/
keywords:
- ActiveX
- thêm ActiveX
- truy cập ActiveX
- xóa ActiveX
- thuộc tính ActiveX
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Xem các ví dụ ActiveX của Aspose.Slides for .NET: chèn, cấu hình và điều khiển các đối tượng ActiveX trong bản trình chiếu PPT và PPTX bằng mã C# rõ ràng."
---
Bài viết này trình bày cách thêm, truy cập, xóa và cấu hình các điều khiển ActiveX trong bản trình chiếu bằng **Aspose.Slides for .NET**.

## **Thêm một điều khiển ActiveX**
Chèn một điều khiển ActiveX mới và tùy chọn thiết lập các thuộc tính của nó.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Thêm một điều khiển ActiveX mới.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Tùy chọn thiết lập một số thuộc tính.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Truy cập một điều khiển ActiveX**
Đọc thông tin từ điều khiển ActiveX đầu tiên trên slide.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Truy cập điều khiển ActiveX đầu tiên.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **Xóa một điều khiển ActiveX**
Xóa một điều khiển ActiveX hiện có khỏi slide.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Xóa điều khiển ActiveX đầu tiên.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **Đặt thuộc tính ActiveX**
Thêm một điều khiển và cấu hình một số thuộc tính ActiveX.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Thêm một CommandButton và cấu hình các thuộc tính.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```