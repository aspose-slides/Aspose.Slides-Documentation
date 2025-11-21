---
title: ActiveX
type: docs
weight: 200
url: /zh/net/examples/elements/activex/
keywords:
- ActiveX 示例
- ActiveX 控件
- 添加 ActiveX
- 访问 ActiveX
- 删除 ActiveX
- ActiveX 属性
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何在 C# 中使用 Aspose.Slides 查找、编辑和删除 ActiveX 控件，包括对 PowerPoint 演示文稿的属性更新。"
---

演示如何在演示文稿中使用 **Aspose.Slides for .NET** 添加、访问、删除和配置 ActiveX 控件。

## 添加 ActiveX 控件

插入一个新的 ActiveX 控件，并可选地设置其属性。
```csharp
static void Add_ActiveX()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 添加一个新的 ActiveX 控件 (TextBox)
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // 可选地设置一些属性
    control.Properties["Value"] = "Default text";

    pres.Save("add_activex.pptm", SaveFormat.Pptm);
}
```


## 访问 ActiveX 控件

读取幻灯片上第一个 ActiveX 控件的信息。
```csharp
static void Access_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    // 访问第一个 ActiveX 控件
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```


## 删除 ActiveX 控件

从幻灯片中删除已有的 ActiveX 控件。
```csharp
static void Remove_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // 删除第一个 ActiveX 控件
        slide.Controls.RemoveAt(0);
    }

    pres.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```


## 设置 ActiveX 属性

添加控件并配置多个 ActiveX 属性。
```csharp
static void Set_ActiveX_Properties()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 添加 CommandButton 并配置属性
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    pres.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```
