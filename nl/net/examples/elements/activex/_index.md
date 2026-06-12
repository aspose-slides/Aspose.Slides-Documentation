---
title: ActiveX
type: docs
weight: 200
url: /nl/net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX toevoegen
- ActiveX benaderen
- ActiveX verwijderen
- ActiveX-eigenschappen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de ActiveX-voorbeelden van Aspose.Slides for .NET: invoegen, configureren en beheren van ActiveX-objecten in PPT- en PPTX-presentaties met duidelijke C#-code."
---
Dit artikel laat zien hoe u ActiveX‑besturingselementen kunt toevoegen, openen, verwijderen en configureren in een presentatie met behulp van **Aspose.Slides for .NET**.

## **Een ActiveX-besturingselement toevoegen**

Voeg een nieuw ActiveX‑besturingselement in en stel desgewenst de eigenschappen in.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Voeg een nieuw ActiveX-besturingselement toe.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Stel optioneel enkele eigenschappen in.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Toegang tot een ActiveX-besturingselement**

Lees de informatie van het eerste ActiveX‑besturingselement op de dia.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Toegang tot het eerste ActiveX-besturingselement.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **Een ActiveX-besturingselement verwijderen**

Verwijder een bestaand ActiveX‑besturingselement van de dia.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Verwijder het eerste ActiveX-besturingselement.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **ActiveX-eigenschappen instellen**

Voeg een besturingselement toe en configureer verschillende ActiveX‑eigenschappen.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Voeg een CommandButton toe en configureer eigenschappen.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```