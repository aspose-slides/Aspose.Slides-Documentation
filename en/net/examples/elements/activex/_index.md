---
title: ActiveX
type: docs
weight: 200
url: /net/examples/elements/activex/
keywords:
- ActiveX example
- ActiveX control
- add ActiveX
- access ActiveX
- remove ActiveX
- ActiveX properties
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to find, edit, and remove ActiveX controls in C# with Aspose.Slides, including property updates for PowerPoint presentations."
---

Demonstrates how to add, access, remove, and configure ActiveX controls in a presentation using **Aspose.Slides for .NET**.

## **Add an ActiveX Control**

Insert a new ActiveX control and optionally set its properties.

```csharp
static void Add_ActiveX()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Add a new ActiveX control (TextBox)
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Optionally set some properties
    control.Properties["Value"] = "Default text";

    pres.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Access an ActiveX Control**

Read information from the first ActiveX control on the slide.

```csharp
static void Access_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    // Access the first ActiveX control
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **Remove an ActiveX Control**

Delete an existing ActiveX control from the slide.

```csharp
static void Remove_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Remove the first ActiveX control
        slide.Controls.RemoveAt(0);
    }

    pres.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **Set ActiveX Properties**

Add a control and configure several ActiveX properties.

```csharp
static void Set_ActiveX_Properties()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Add a CommandButton and configure properties
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    pres.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```
