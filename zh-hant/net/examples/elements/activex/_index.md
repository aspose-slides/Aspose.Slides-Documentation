---
title: ActiveX
type: docs
weight: 200
url: /zh-hant/net/examples/elements/activex/
keywords:
- ActiveX
- 新增 ActiveX
- 存取 ActiveX
- 移除 ActiveX
- ActiveX 屬性
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "請參閱 Aspose.Slides for .NET 的 ActiveX 範例：在 PPT 與 PPTX 簡報中插入、設定與控制 ActiveX 物件，並提供清晰的 C# 程式碼。"
---
本篇文章說明如何在簡報中使用 **Aspose.Slides for .NET** 新增、存取、移除和設定 ActiveX 控制項。

## **新增 ActiveX 控制項**

插入一個新的 ActiveX 控制項，並可選擇設定其屬性。

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 新增一個 ActiveX 控制項。
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // 選擇性設定一些屬性。
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **存取 ActiveX 控制項**

讀取投影片上第一個 ActiveX 控制項的資訊。

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // 存取第一個 ActiveX 控制項。
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **移除 ActiveX 控制項**

從投影片上刪除已存在的 ActiveX 控制項。

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // 移除第一個 ActiveX 控制項。
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **設定 ActiveX 屬性**

新增一個控制項並設定多個 ActiveX 屬性。

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 新增 CommandButton 並設定屬性。
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```