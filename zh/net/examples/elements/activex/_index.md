---
title: ActiveX
type: docs
weight: 200
url: /zh/net/examples/elements/activex/
keywords:
- ActiveX
- 添加 ActiveX
- 访问 ActiveX
- 删除 ActiveX
- ActiveX 属性
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "查看 Aspose.Slides for .NET 的 ActiveX 示例：在 PPT 和 PPTX 演示文稿中插入、配置和控制 ActiveX 对象，提供清晰的 C# 代码。"
---
本文演示了如何在演示文稿中使用 **Aspose.Slides for .NET** 添加、访问、删除和配置 ActiveX 控件。

## **添加 ActiveX 控件**

插入一个新的 ActiveX 控件，并可选地设置其属性。

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 添加新的 ActiveX 控件。
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // 可选地设置一些属性。
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **访问 ActiveX 控件**

读取幻灯片上第一个 ActiveX 控件的信息。

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // 访问第一个 ActiveX 控件。
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **删除 ActiveX 控件**

从幻灯片中删除现有的 ActiveX 控件。

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // 删除第一个 ActiveX 控件。
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **设置 ActiveX 属性**

添加一个控件并配置多个 ActiveX 属性。

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 添加 CommandButton 并配置属性。
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```