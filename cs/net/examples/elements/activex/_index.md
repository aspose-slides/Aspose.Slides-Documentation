---
title: ActiveX
type: docs
weight: 200
url: /cs/net/examples/elements/activex/
keywords:
- ActiveX
- přidat ActiveX
- přístup k ActiveX
- odstranit ActiveX
- vlastnosti ActiveX
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si příklady ActiveX v Aspose.Slides pro .NET: vkládání, konfigurace a řízení objektů ActiveX v prezentacích PPT a PPTX s jasným kódem C#."
---
Tento článek ukazuje, jak přidávat, přistupovat, odstraňovat a konfigurovat ActiveX ovládací prvky v prezentaci pomocí **Aspose.Slides for .NET**.

## **Přidat ActiveX ovládací prvek**

Vložte nový ActiveX ovládací prvek a volitelně nastavte jeho vlastnosti.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Přidejte nový ActiveX ovládací prvek.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Volitelně nastavte některé vlastnosti.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Přístup k ActiveX ovládacímu prvku**

Načtěte informace z prvního ActiveX ovládacího prvku na snímku.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Přístup k prvnímu ActiveX ovládacímu prvku.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **Odstranit ActiveX ovládací prvek**

Odstraňte existující ActiveX ovládací prvek ze snímku.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Odstraňte první ActiveX ovládací prvek.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **Nastavit vlastnosti ActiveX**

Přidejte ovládací prvek a nakonfigurujte několik vlastností ActiveX.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Přidejte CommandButton a nakonfigurujte vlastnosti.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```