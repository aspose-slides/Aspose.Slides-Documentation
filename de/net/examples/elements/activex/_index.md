---
title: ActiveX
type: docs
weight: 200
url: /de/net/examples/elements/activex/
keywords:
- ActiveX-Beispiel
- ActiveX-Steuerelement
- ActiveX hinzufügen
- ActiveX-Zugriff
- ActiveX entfernen
- ActiveX-Eigenschaften
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie ActiveX-Steuerelemente in C# mit Aspose.Slides finden, bearbeiten und entfernen, einschließlich der Aktualisierung von Eigenschaften für PowerPoint-Präsentationen."
---

Zeigt, wie man ActiveX‑Steuerelemente in einer Präsentation hinzufügt, darauf zugreift, sie entfernt und konfiguriert, wobei **Aspose.Slides for .NET** verwendet wird.

## **Ein ActiveX‑Steuerelement hinzufügen**

Fügen Sie ein neues ActiveX‑Steuerelement ein und setzen Sie optional dessen Eigenschaften.
```csharp
static void Add_ActiveX()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Füge ein neues ActiveX-Steuerelement (TextBox) hinzu
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Setze optional einige Eigenschaften
    control.Properties["Value"] = "Default text";

    pres.Save("add_activex.pptm", SaveFormat.Pptm);
}
```


## **Zugriff auf ein ActiveX‑Steuerelement**

Lesen Sie Informationen vom ersten ActiveX‑Steuerelement auf der Folie.
```csharp
static void Access_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    // Zugriff auf das erste ActiveX-Steuerelement
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```


## **Ein ActiveX‑Steuerelement entfernen**

Löschen Sie ein vorhandenes ActiveX‑Steuerelement von der Folie.
```csharp
static void Remove_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Entferne das erste ActiveX-Steuerelement
        slide.Controls.RemoveAt(0);
    }

    pres.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```


## **ActiveX‑Eigenschaften festlegen**

Fügen Sie ein Steuerelement hinzu und konfigurieren Sie mehrere ActiveX‑Eigenschaften.
```csharp
static void Set_ActiveX_Properties()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Füge einen CommandButton hinzu und konfiguriere die Eigenschaften
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    pres.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```
