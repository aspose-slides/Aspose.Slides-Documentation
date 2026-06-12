---
title: ActiveX
type: docs
weight: 200
url: /it/net/examples/elements/activex/
keywords:
- ActiveX
- aggiungi ActiveX
- accedi ActiveX
- rimuovi ActiveX
- proprietà ActiveX
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Vedi esempi ActiveX di Aspose.Slides per .NET: inserisci, configura e controlla oggetti ActiveX in presentazioni PPT e PPTX con codice C# chiaro."
---
Questo articolo mostra come aggiungere, accedere, rimuovere e configurare i controlli ActiveX in una presentazione utilizzando **Aspose.Slides for .NET**.

## **Aggiungi un controllo ActiveX**

Inserisci un nuovo controllo ActiveX e, facoltativamente, imposta le sue proprietà.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Aggiungi un nuovo controllo ActiveX.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Facoltativamente imposta alcune proprietà.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Accedi a un controllo ActiveX**

Leggi le informazioni dal primo controllo ActiveX nella diapositiva.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Accedi al primo controllo ActiveX.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **Rimuovi un controllo ActiveX**

Elimina un controllo ActiveX esistente dalla diapositiva.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Rimuovi il primo controllo ActiveX.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **Imposta le proprietà ActiveX**

Aggiungi un controllo e configura diverse proprietà ActiveX.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Aggiungi un CommandButton e configura le proprietà.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```