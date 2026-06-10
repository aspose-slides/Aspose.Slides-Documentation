---
title: ActiveX
type: docs
weight: 200
url: /hu/net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX hozzáadása
- ActiveX elérése
- ActiveX eltávolítása
- ActiveX tulajdonságok
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Lásd az Aspose.Slides for .NET ActiveX példákat: ActiveX objektumok beszúrása, konfigurálása és vezérlése PPT és PPTX bemutatókban világos C# kóddal."
---
Ez a cikk bemutatja, hogyan lehet hozzáadni, elérni, eltávolítani és konfigurálni az ActiveX vezérlőket egy bemutatóban a **Aspose.Slides for .NET** használatával.

## **ActiveX vezérlő hozzáadása**

Új ActiveX vezérlő beszúrása és opcionálisan a tulajdonságainak beállítása.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Új ActiveX vezérlő hozzáadása.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Opcionálisan néhány tulajdonság beállítása.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **ActiveX vezérlő elérése**

Információk olvasása a dián lévő első ActiveX vezérlőből.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Az első ActiveX vezérlő elérése.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **ActiveX vezérlő eltávolítása**

Egy meglévő ActiveX vezérlő törlése a diáról.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Az első ActiveX vezérlő eltávolítása.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **ActiveX tulajdonságok beállítása**

Vezérlő hozzáadása és több ActiveX tulajdonság konfigurálása.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Parancsgomb hozzáadása és a tulajdonságok beállítása.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```