---
title: ActiveX
type: docs
weight: 200
url: /de/net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX hinzufügen
- ActiveX zugreifen
- ActiveX entfernen
- ActiveX-Eigenschaften
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Siehe Aspose.Slides for .NET ActiveX-Beispiele: Einfügen, Konfigurieren und Steuern von ActiveX-Objekten in PPT- und PPTX-Präsentationen mit klarem C#-Code."
---
Dieser Artikel demonstriert, wie Sie ActiveX‑Steuerelemente in einer Präsentation hinzufügen, darauf zugreifen, entfernen und konfigurieren, indem Sie **Aspose.Slides for .NET** verwenden.

## **ActiveX‑Steuerelement hinzufügen**

Fügen Sie ein neues ActiveX‑Steuerelement ein und setzen Sie optional dessen Eigenschaften.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Ein neues ActiveX-Steuerelement hinzufügen.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Optional einige Eigenschaften festlegen.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Zugriff auf ein ActiveX‑Steuerelement**

Lesen Sie Informationen vom ersten ActiveX‑Steuerelement auf der Folie.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Auf das erste ActiveX-Steuerelement zugreifen.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **ActiveX‑Steuerelement entfernen**

Löschen Sie ein vorhandenes ActiveX‑Steuerelement von der Folie.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Das erste ActiveX-Steuerelement entfernen.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **ActiveX‑Eigenschaften festlegen**

Fügen Sie ein Steuerelement hinzu und konfigurieren Sie mehrere ActiveX‑Eigenschaften.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Einen CommandButton hinzufügen und Eigenschaften konfigurieren.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```